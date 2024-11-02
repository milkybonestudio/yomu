
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;


public class MODULE__context_structures {


        public MODULE__context_structures( Resource_context _context, int _initial_capacity, int _buffer_cache ){


                context = _context;
                context_folder = _context.ToString();

                #if !!! UNITY_EDITOR
                    file_stream = FILE_STREAM.Criar_stream( _path, buffer_cache );
                #endif

                actives_structures_dictionary = new Dictionary<string, RESOURCE__structure>();
                actives_structures_dictionary.EnsureCapacity( _initial_capacity );


        }

        public int Get_bytes(){ return 0; }

        private string context_folder;
        private Resource_context context;

        public MANAGER__resources_structures manager;
        
        public Dictionary<string, RESOURCE__structure> actives_structures_dictionary;
        

        public RESOURCE__structure_copy Get_structure_copy(  string _main_folder, Structure_locators _locators, Resource_structure_content _level_pre_allocation  ){

                CONTROLLER__errors.Verify( ( _locators == null ), $"Sub_struct came null" );
                CONTROLLER__errors.Verify( ( _locators.main_struct_name == null ), $"Sub_struct doesnt has a name" );

                // --- GET RESOURCE
                
                if( !!!( Get_dictionary( _main_folder ).TryGetValue( Get_path( _main_folder, _locators.main_struct_name ),  out RESOURCE__structure structure ) ) )
                    { structure = Create_new_structure( _main_folder, _locators, _level_pre_allocation ); }

                
                return Get_copy( structure, _level_pre_allocation ); // --- CREATE COPY
                
        }


        private RESOURCE__structure Create_new_structure( string _main_folder, Structure_locators _locators, Resource_structure_content _level_pre_allocation ){


                RESOURCE__structure new_structure = new RESOURCE__structure( this, context, _main_folder, _locators );
                Get_dictionary( _main_folder ).Add( Get_path( _main_folder, _locators.main_struct_name ), new_structure );

                if( _locators.sub_structs == null )
                    { return new_structure; }

                // --- HAVE SUB STRUCTURES

                    new_structure.sub_structures = new RESOURCE__structure_copy[ _locators.sub_structs.Length ];
                    for( int index = 0 ; index < _locators.sub_structs.Length ; index++ ) 
                        { new_structure.sub_structures[ index ] = Get_structure_copy(  _main_folder, _locators.sub_structs[ index ], _level_pre_allocation  ); }

                return new_structure;

        }


        private RESOURCE__structure_copy Get_copy( RESOURCE__structure _structure, Resource_structure_content _copy_level_pre_allocation  ){

                
                // --- CREATE COPY 
                RESOURCE__structure_copy copy = new RESOURCE__structure_copy( _structure, _copy_level_pre_allocation );

                TOOL__resources_structures.Increase_count( _structure, Resource_structure_content.nothing );

                if( _structure.copies.Length == _structure.copies_pointer )
                    { Array.Resize( ref _structure.copies, ( _structure.copies.Length + 10 ) ); }

                _structure.copies[ _structure.copies_pointer++ ] = copy;

                return copy;

        }





        private string Get_path( string _main_folder, string _name ){ 

                // ** quando for expandir vai ser somente o _path porque vai ter 1 dic para cada main_folder
                return ( _main_folder + "\\" + _name );

        } 




        public void Delete( RESOURCE__structure_copy _ref ){  return; } 

        // ** dados vao ser perdidos, mas a referencia da imagem volta 
        public void Unload( RESOURCE__structure_copy _ref ){}

        // ** vai para o minimo
        public void Free( RESOURCE__structure_copy _ref ){}



        // --- PEGAR RECURSOS

        // ** sinaliza que a imagem pode carregar o pre alloc
        public void Load( RESOURCE__structure_copy _copy ){


                RESOURCE__structure structure = _copy.structure;

                Resource_structure_content old_need_content = _copy.actual_need_content;
                Resource_structure_content new_need_content = _copy.level_pre_allocation;


                // --- VERIFICA SE JA EH IGUAL OU MAIOR
                if( new_need_content <= old_need_content )
                    { return; } // ** ja com o pre_alloc ou algo maior, vai ignorar essa chamada


                // ** ATUALIZOU RECURSO DA COPIA 

                if( new_need_content == Resource_structure_content.instance )
                    { structure.number_copies_need_to_get_instanciated++; } // --- NEED TO GET EVRYTHING + INSTANCE

                TOOL__resources_structures.Decrease_count( structure, old_need_content );
                TOOL__resources_structures.Increase_count( structure, new_need_content ); 

                // VAI ATUALIZAR O RECURSO ORIGINAL
                Update_resource_level( structure );

                return;

        }



        public void Update_resource_level( RESOURCE__structure _structure ){

                // ** CHAMADO DOTA VEZ QUE ALGUMA COPIA TIVER O NIVEL DE RECURSO MODIFICADO
                // ** VAI SEMPRE DEIXAR COMO O NIVEL MAIS ALTO

                if( ( _structure.count_places_being_used_instance > 0 ) || ( _structure.count_places_being_used_structure_data > 0 ) )
                    {
                        // --- TEM ALGO

                        if( _structure.content_going_to == Resource_structure_content.structure_data )
                            { return; } // ** nivel já nivelado

                        _structure.content_going_to = Resource_structure_content.structure_data;
                        _structure.stage_getting_resource = Resources_getting_structure_stage.waiting_to_start;
                    
                        return;
                    }

            
                if( _structure.count_places_being_used_nothing >= 0  )
                    {
                        // --- NAO TEM QUE TER NADA

                        if( _structure.actual_content == Resource_structure_content.nothing )
                            { return; } // ** nivelado

                        // ** se estivber aqui cada copia também vai estar sem o prefab. Fica por responsabilidades deles de deletarem

                        // --- TEM QUE LIMPAR
                        _structure.prefab = null;
                        _structure.content_going_to = Resource_structure_content.nothing;
                        _structure.actual_content   = Resource_structure_content.nothing;
                        
                        return;
                    }

        }




        
        public void Get_ready( RESOURCE__structure_copy _ref ){}





        // --- INTERNAL

        private Dictionary<string, RESOURCE__structure> Get_dictionary( string _main_folder ){

                // ** por hora vai ter somentye 1 container então só vai ter 1 dicionario. 
                // ** depois cada _main_folder vai ter             

                return actives_structures_dictionary;

        }

        private Dictionary<string, Resource_image_localizer> Get_dictionary_locators( string _main_folder ){

                // ** por hora vai ter somentye 1 container então só vai ter 1 dicionario. 
                // ** depois cada _main_folder vai ter             

                return null;

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







}