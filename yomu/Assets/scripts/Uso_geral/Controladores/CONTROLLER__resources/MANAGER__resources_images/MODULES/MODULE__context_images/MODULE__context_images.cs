using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class MODULE__context_images {

        /*
                por hora todo o contexto vai estar em 1 grande container. Quando for precisar ter mais precisa fazer de um jeito para nao ficar criando e destruindo streams. 
                por hora pode ter sempre 1 em cada modelo.        
        */

        //mark
        // por hora nao vai ser preocupar com os pointers, no final vai ter um arquivo  context_folder.txt na pasta com os pointers


        public MODULE__context_images( Resource_context _context, int _initial_capacity, int _buffer_cache ){


                context = _context;
                context_folder = _context.ToString();

                #if !!! UNITY_EDITOR
                    file_stream = FILE_STREAM.Criar_stream( _path, buffer_cache );
                #endif

                images_dictionary = new Dictionary<string, RESOURCE__image>();
                images_dictionary.EnsureCapacity( _initial_capacity );


        }

        public int Get_bytes(){ return 0; }


        private string context_folder;
        private Resource_context context;

        public MANAGER__resources_images manager;

        private FileStream file_stream;
        public Dictionary<string, RESOURCE__image> images_dictionary;

        

        public RESOURCE__image_ref Get_image_ref(  string _main_folder, string _path, Resource_image_content _level_pre_allocation  ){


                Dictionary<string, RESOURCE__image> dic = Get_dictionary( _main_folder );
                string path = ( _main_folder + "\\" + _path ); // ** quando for expandir vai ser somente o _path


                RESOURCE__image image = null;
                
                if( !!!( dic.TryGetValue( path, out image ) ) )
                    { 
                        // ** create new 
                        image = new RESOURCE__image( this, context, _main_folder, _path );  
                        image.path_locator = path;
                        dic.Add( path, image );
                    } 

                RESOURCE__image_ref image_ref = new RESOURCE__image_ref( image );

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

                                    case Resource_image_content.nothing: image.stage_getting_resource = Resources_request_image_stage.waiting_to_start; break;
                                    case Resource_image_content.compress_data: image.stage_getting_resource = Resources_request_image_stage.getting_wait_file; break;
                                    // ** se estava no minimo e o minimo já era o maior não tem como o novo minimo ser maior
                                    default: CONTROLLER__errors.Throw( $"In the image { image.name } tried to change the minimun level to { _level_pre_allocation }. But the image already have the hiest level of resources. Should not come here" ); break;

                                }

                            } 

                        if( image.current_state == Resource_image_state.going_to_minimun )
                            { image.final_resource_state = _level_pre_allocation;}

                    }

                Increase_count( image );

                Debug.Log("iamge ref: "  + image_ref );

                return image_ref;
                

        }




        public Sprite Get_sprite( RESOURCE__image_ref _ref ){

            return null;

        }

        public Texture2D Get_texture( RESOURCE__image_ref _ref ){

            return null;

        }



        // ** imagem vai ser deletada completamente 
        public void Delete( RESOURCE__image_ref _ref ){ 

                RESOURCE__image image = _ref.image;

                Decrease_count( image );

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

                images_dictionary.Remove( image.path_locator );
                Unload( _ref );
                
                return;

        } 

        // ** dados vao ser perdidos, mas a referencia da imagem volta 
        public void Unload( RESOURCE__image_ref _ref ){


                RESOURCE__image image = _ref.image;

                Decrease_count( image );

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



        public void Free( RESOURCE__image_ref _ref ){



        }


        // --- PEGAR RECURSOS

        // ** sinaliza que a imagem pode carregar o minimo 
        public void Load( RESOURCE__image_ref _ref ){


                RESOURCE__image image = _ref.image;

                // ** verifica se tem que fazer algo
                if( image.current_content >= image.level_pre_allocation_image )
                    { return; }
                


        }

        // ** sinaliza que pode começar a pegar a texture
        public void Get_ready( RESOURCE__image_ref _ref ){



        }






        // --- INTERNAL

        private Dictionary<string, RESOURCE__image> Get_dictionary( string _main_folder ){

                // ** por hora vai ter somentye 1 container então só vai ter 1 dicionario. 
                // ** depois cada _main_folder vai ter             

                return images_dictionary;

        }


    
        public byte[] Get_single_data( RESOURCE__image _image ){

                byte[] image = null;

                // switch( _image.image_context ){

                //     case Resource_context.characters: return  characters_images.Get_data( _image ); 
                //     default: throw new Exception( $"Can not handle the type { _image.image_context}" ); 
                    
                // }

                return image;
            
        }

        public byte[][] Get_multiple_data( RESOURCE__image _image ){

                throw new Exception("tem que fazerr");


        }


        private void Increase_count( RESOURCE__image _image ){

                switch( _image.current_content ){

                    case Resource_image_content.nothing : _image.count_places_being_used_nothing++; break;
                    case Resource_image_content.compress_data : _image.count_places_being_used_compress_data++; break;
                    case Resource_image_content.texture : _image.count_places_being_used_texture++; break;
                }

        }

        private void Decrease_count( RESOURCE__image _image ){

                switch( _image.current_content ){

                    case Resource_image_content.nothing : _image.count_places_being_used_nothing--; break;
                    case Resource_image_content.compress_data : _image.count_places_being_used_compress_data--; break;
                    case Resource_image_content.texture : _image.count_places_being_used_texture--; break;
                }

        }



}