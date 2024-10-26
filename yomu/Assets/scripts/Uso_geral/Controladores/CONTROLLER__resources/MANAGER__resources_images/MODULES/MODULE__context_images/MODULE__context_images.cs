using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;




public class MODULE__context_images {

        /*
                por hora todo o contexto vai estar em 1 grande container. Quando for precisar ter mais precisa fazer de um jeito para nao ficar criando e destruindo streams. 
                por hora pode ter sempre 1 em cada modelo.        
        */

        //mark
        // por hora nao vai ser preocupar com os pointers, no final vai ter um arquivo  context_folder.txt na pasta com os pointers
        // ** multiples sempre tem a mesma quantidade de images


        public MODULE__context_images( Resource_context _context, int _initial_capacity, int _buffer_cache ){


                context = _context;
                context_folder = _context.ToString();

                #if !!! UNITY_EDITOR
                    file_stream = FILE_STREAM.Criar_stream( _path, buffer_cache );
                #endif

                actives_images_dictionary = new Dictionary<string, RESOURCE__image>();
                actives_images_dictionary.EnsureCapacity( _initial_capacity );


        }

        public int Get_bytes(){ return 0; }


        private string context_folder;
        private Resource_context context;

        public MANAGER__resources_images manager;

        private FileStream file_stream;

        
        public Dictionary<string, RESOURCE__image> actives_images_dictionary;

        public Dictionary<string, Resource_image_localizer> images_locators_dictionary;




        // sempre single
        public RESOURCE__image_ref Get_image_ref(  string _main_folder, string _path, bool _multiples_images,  Resource_image_content _level_pre_allocation  ){

                //mark 
                // ** nao esta verificando se conseguiu achar a imagem


                Dictionary<string, RESOURCE__image> dic = Get_dictionary( _main_folder );
                string path = ( _main_folder + "\\" + _path ); // ** quando for expandir vai ser somente o _path

                
                RESOURCE__image image = null;
                
                // --- VERIFY IF IMAGE ALREADY EXISTS
                if( !!!( dic.TryGetValue( path, out image ) ) )
                    { 
                        
                        // --- DOINT EXIST

                        Resource_image_localizer locator = new Resource_image_localizer();
                        locator.number_images = 1;

                        #if UNITY_EDITOR

                            // ** no editor o localizador sempre esta vazio, ele tem que preencher os dados agora na parte multiples
                            if( _multiples_images )
                                {
                                    string file_name = Path.GetFileName( path );

                                    string path_folder = Get_folder_file( _main_folder, _path );
                                    string[] files_names = Directory.GetFiles( path_folder );
                                    string[] files_of_the_multiples = files_names.Where( ( str ) => { return str.Contains( file_name ); } ).ToArray();

                                    CONTROLLER__errors.Verify( ( files_of_the_multiples.Length == 0 ), $"there was no files with the name { file_name } in the path { path }" );
                                    CONTROLLER__errors.Verify( ( files_of_the_multiples.Length == 1 ), $"tried to load a sequence of images in the path { path }. But thre was only 1 image" );

                                    //mark
                                    // ** unica informacao relevante no editor
                                    locator.number_images = files_of_the_multiples.Length;                                 
                                }
   
                        #else

                            // ** build
                            // --- GET LOCATOR
                            CONTROLLER__errors.Verify( !!!( Get_dictionary_locators(  _main_folder ).TryGetValue( path, out locator )),  $"Tried to get the locator { path } but was not find" );
                            
                        #endif

                        image = new RESOURCE__image( this, context, _main_folder, _path, locator );  
                        dic.Add( path, image );
                    } 

                


                RESOURCE__image_ref image_ref = new RESOURCE__image_ref( image, _level_pre_allocation );

                // --- GARANTE TAMANHO
                if( image.refs_pointer == image.refs.Length )
                    { Array.Resize( ref image.refs, ( image.refs.Length + 20 ) ); }

                // --- GURADA REF
                image.refs[ image.refs_pointer++ ] = image_ref;



                // --- PEGA O PRE ALLOC MAIS ALTO
                if( _level_pre_allocation  > image.level_pre_allocation_image )
                    { 

                        image.level_pre_allocation_image = _level_pre_allocation; 

                        if( image.current_state == Resource_image_state.minimun )
                            {
                                // -- precisa mudar para o novo minimo 
                                
                                switch( image.current_content ){

                                    case Resource_image_content.nothing: image.stage_getting_resource = Resources_getting_image_stage.waiting_to_start; break;
                                    case Resource_image_content.compress_data: image.stage_getting_resource = Resources_getting_image_stage.waiting_to_get_texture; break;
                                    // ** se estava no minimo e o minimo já era o maior não tem como o novo minimo ser maior
                                    default: CONTROLLER__errors.Throw( $"In the image { image.name } tried to change the minimun level to { _level_pre_allocation }. But the image already have the hiest level of resources. Should not come here" ); break;

                                }

                            } 

                        if( image.current_state == Resource_image_state.going_to_minimun )
                            { image.final_resource_state = _level_pre_allocation;}

                    }

                Increase_count( image, _level_pre_allocation );


                return image_ref;
                

        }




        public Sprite Get_sprite( RESOURCE__image_ref _ref ){

            return null;

        }

        public Texture2D Get_texture( RESOURCE__image_ref _ref ){

            return null;

        }


        //mark 
        // ** tirar recursos tem que tomar mais cuidado sobre quantas referencias them em cada estado 


        // ** imagem vai ser deletada completamente 
        public void Delete( RESOURCE__image_ref _ref ){ 

                RESOURCE__image image = _ref.image;

                Decrease_count( image, _ref.reference_level_pre_allocation_image );

                // ** perde a referencia
                image.refs[ _ref.image_slot_index ] = null;
                image.need_reajust = true;

                if( image.count_places_being_used_texture > 1 )
                    { return; }

                if( image.count_places_being_used_compress_data > 1 )
                    { return; }

                if( image.count_places_being_used_nothing > 1 )
                    { return; } 

                // --- CAN DELETE

                actives_images_dictionary.Remove( image.path_locator );
                Unload( _ref );
                
                return;

        } 

        // ** dados vao ser perdidos, mas a referencia da imagem volta 
        public void Unload( RESOURCE__image_ref _ref ){


                RESOURCE__image image = _ref.image;

                Decrease_count( image, _ref.reference_level_pre_allocation_image );

                if( image.count_places_being_used_texture > 1 )
                    { return; }

                if( image.count_places_being_used_compress_data > 1 )
                    { return; }

                if( image.count_places_being_used_nothing > 1 )



                if( image.single_image != null )
                    { 
                        // --- SINGLE 

                        image.single_image.image_compress = null;
                        manager.textures_manager.Liberate_texture( image.single_image ); 
                    }
                    else
                    { 
                        // --- MULTIPLES

                        for( int index_iamge_data = 0 ; index_iamge_data < image.multiples_images.Length ; index_iamge_data++ )
                            { 
                                image.multiples_images[ index_iamge_data ].image_compress = null;
                                manager.textures_manager.Liberate_texture( image.multiples_images[ index_iamge_data ] );
                            } 
                    }
                

        }


        // ** vai para o minimo
        public void Free( RESOURCE__image_ref _ref ){







        }


        // --- PEGAR RECURSOS

        // ** sinaliza que a imagem pode carregar o minimo 
        public void Load( RESOURCE__image_ref _ref ){


                RESOURCE__image image = _ref.image;

                // ** ou já esta indo para o minimo, já esta la ou esta com nivel mais alto
                if( image.current_final_state >= Resource_image_state.minimun )
                    { return; }


                // -- TE QUE MUDAR 

                image.stage_getting_resource = Resources_getting_image_stage.waiting_to_start;

                // --- STATES
                image.current_final_state = Resource_image_state.minimun;
                image.current_state = Resource_image_state.going_to_minimun;


                // --- RESOURCE
                image.final_resource_state = image.level_pre_allocation_image;
                

                return;


        }

        // ** sinaliza que pode começar a pegar a texture
        public void Get_ready( RESOURCE__image_ref _ref ){



                RESOURCE__image image = _ref.image;

                // ** ou já esta indo para o maximo
                if( image.current_final_state == Resource_image_state.active )
                    { return; }



                // -- TE QUE MUDAR 

                switch( image.current_content ){

                    case Resource_image_content.nothing: image.stage_getting_resource = Resources_getting_image_stage.waiting_to_start; break;
                    case Resource_image_content.compress_data: image.stage_getting_resource = Resources_getting_image_stage.waiting_to_get_texture; break;
                    default: CONTROLLER__errors.Throw( $"Image { image.name } tried to get_ready but the current_final_state was not active but the current content was { image.current_content }" ); break;

                }

                

                

                // --- STATES
                image.current_final_state = Resource_image_state.active;
                image.current_state = Resource_image_state.going_to_active;


                // --- RESOURCE
                image.final_resource_state = Resource_image_content.texture;
                

                return;





        }






        // --- INTERNAL

        private Dictionary<string, RESOURCE__image> Get_dictionary( string _main_folder ){

                // ** por hora vai ter somentye 1 container então só vai ter 1 dicionario. 
                // ** depois cada _main_folder vai ter             

                return actives_images_dictionary;

        }

        private Dictionary<string, Resource_image_localizer> Get_dictionary_locators( string _main_folder ){

                // ** por hora vai ter somentye 1 container então só vai ter 1 dicionario. 
                // ** depois cada _main_folder vai ter             

                return images_locators_dictionary;

        }

        



        #if UNITY_EDITOR

            private string Get_path_file( string _main_folder, string _path ){

                    return Path.Combine( Application.dataPath, "Resources", context_folder, _main_folder,  ( _path + ".png") ) ;     

            }

            private string Get_folder_file( string _main_folder, string _path ){

                return Directory.GetParent( Get_path_file(_main_folder, _path) ).FullName;

            }


        #endif

    

        public byte[] Get_single_data( string _main_folder, string _path ){

                // ** o jogo nao vai usar webp na build então precisa do type
                // ** o webp vai ser path_low_quality

            
                byte[] image = null;

                    // **   pensar da  seguinte forma: ( path sistema(C:\\users\\user...) ) || ( container( Devices, Characters, ...  ) ) || ( chave ( "\\Lily\\normal_clothes\\arms_1.png" ) )
                    // **   no editor path systema vai dado por Application.DataPath + "\\Resources"
                    // **   na build vai ser Application.DataPath + "\\Static_data"

                    #if UNITY_EDITOR

                        string path_arquivo = Get_path_file( _main_folder, _path );

                        try{ return System.IO.File.ReadAllBytes( path_arquivo ); } catch( Exception e ){ Debug.LogError( $"Dont find the image <Color=lightBlue>{ path_arquivo }</Color>" ); throw e; }

                    
                    #elif !!!( UNITY_EDITOR ) && ( UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX || UNITY_STANDALONE_OSX)
                        
                        
                        thorw new Exception( "Ainda tem que fazer" );


                        // int _initial_pointer = _image.single_image.image_localizers.initial_pointer;
                        // int _length = _image.single_image.image_ocalizers.length;


                        FileStream file_stream = null;
                        
                        if( !!!( files_streams.TryGetValue( _path, out file_stream ) ) )
                            { files_streams.Add( _path, FILE_STREAM.Criar_stream( _path, buffer_cache )); }


                        file_stream.Seek( _initial_pointer, SeekOrigin.Begin );

                        byte[] image = new byte[ _length ];

                        file_stream.Read( image, 0, _length );
            
                        return image;

                    
                    #endif



                return image;
            
        }

        public byte[][] Get_multiple_data( string _main_folder, string _path, int _number_images ){

                throw new Exception("tem que fazerr");


        }


        private void Increase_count( RESOURCE__image _image, Resource_image_content _state ){

                switch( _state ){

                    case Resource_image_content.nothing : _image.count_places_being_used_nothing++; break;
                    case Resource_image_content.compress_data : _image.count_places_being_used_compress_data++; break;
                    case Resource_image_content.texture : _image.count_places_being_used_texture++; break;
                }

        }

        private void Decrease_count( RESOURCE__image _image, Resource_image_content _state ){

                switch( _state ){

                    case Resource_image_content.nothing : _image.count_places_being_used_nothing--; break;
                    case Resource_image_content.compress_data : _image.count_places_being_used_compress_data--; break;
                    case Resource_image_content.texture : _image.count_places_being_used_texture--; break;
                }

        }



}