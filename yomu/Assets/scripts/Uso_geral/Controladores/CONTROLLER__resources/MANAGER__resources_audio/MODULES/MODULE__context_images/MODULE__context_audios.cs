using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;



public class MODULE__context_audios {


        public MODULE__context_audios( MANAGER__resources_audios _manager, Resource_context _context, int _initial_capacity, int _buffer_cache ){


                context = _context;
                context_folder = _context.ToString();
                manager = _manager;

                #if !!! UNITY_EDITOR
                    file_stream = FILE_STREAM.Criar_stream( _path, buffer_cache );
                #endif

                actives_images_dictionary = new Dictionary<string, RESOURCE__audio>();
                actives_images_dictionary.EnsureCapacity( _initial_capacity );

        }

        public int Get_bytes(){ return 0; }


        public string context_folder;
        public Resource_context context;

        public MANAGER__resources_audios manager;

        public FileStream file_stream;
        
        public Dictionary<string, RESOURCE__audio> actives_images_dictionary;
    

        // sempre single
        public RESOURCE__audio_ref Get_audio_ref(  string _main_folder, string _path_local,  Resource_audio_content _level_pre_allocation  ){


                RESOURCE__audio image = null;
                
                // --- VERIFY IF IMAGE ALREADY EXISTS
                if( !!!( Get_dictionary( _main_folder ).TryGetValue( _path_local, out image ) ) )
                    {  image = Create_new_image( _main_folder, _path_local  );} 

                return Create_audio_ref( image, _level_pre_allocation );
                    
        }



        private RESOURCE__audio Create_new_image( string _main_folder, string _path_local ){



                if( Application.isEditor )
                    { return Create_new_audio_EDITOR( _main_folder, _path_local ); }
                    else
                    { return Create_new_audio_BUILD( _main_folder, _path_local ); }



                // --- EDITOR
                RESOURCE__audio Create_new_audio_EDITOR( string _main_folder, string _path_local ){

                
                        Resource_audio_localizer locator = new Resource_audio_localizer();

                        // ** no editor posso pegar a imagem e verificar o tamanho dela, nao tem problema se demorar um pouco para iniciar, depois de colocar no cache ficar verificando vai ser muito rapido. 
                        // ** provavelmente vai ser mais rapido usar streamreader para pegar somente os primeiros bytes, o os provavelmente vai copiar o png inteiro de um lugar para o outro na ram se nao fizer
                        string png_path = System.IO.Path.Combine( Application.dataPath, "Resources", context.ToString(), manager.container_images.Get_image_key( _main_folder, _path_local ) + ".png");
                
                        byte[] png = System.IO.File.ReadAllBytes( png_path );
                        Dimensions dimensions = PNG.Get_dimensions( System.IO.File.ReadAllBytes( png_path ) );

                            locator.width = dimensions.width;
                            locator.height = dimensions.height;
                            locator.pointer = -1;
                            locator.length = png.Length;


                        RESOURCE__audio image = manager.container_images.Get_resource_audio( this, context, _main_folder, _path_local, locator );

                        Get_dictionary( _main_folder ).Add( _path_local, image );

                        return image;

                }

                // --- BUILD
                RESOURCE__audio Create_new_audio_BUILD( string _main_folder, string _path_local ){

                    
                        RESOURCE__audio image = manager.container_images.Get_resource_audio( this, context, _main_folder, _path_local, ( new Resource_audio_localizer() ) );

                        Get_dictionary( _main_folder ).Add( _path_local, image );

                        return image;

                }

        }




        private RESOURCE__audio_ref Create_audio_ref( RESOURCE__audio _image, Resource_audio_content _level_pre_allocation ){


                RESOURCE__audio_ref image_ref = manager.container_image_refs.Get_resource_audio_ref( _image, _level_pre_allocation );

                ARRAY.Guaranty_size( ref _image.refs, _image.refs_pointer, 1, 20 );

                // --- GURADA REF
                image_ref.image_slot_index = _image.refs_pointer;
                _image.refs[ _image.refs_pointer++ ] = image_ref;
                
                TOOL__resource_audio.Increase_count( _image, Resource_audio_content.nothing );

                return image_ref;

        }




        // --- INTERNAL

        private Dictionary<string, RESOURCE__audio> Get_dictionary( string _main_folder ){

                // ** por hora vai ter somentye 1 container então só vai ter 1 dicionario. 
                // ** depois cada _main_folder vai ter             

                return actives_images_dictionary;

        }




        #if UNITY_EDITOR

            private string Get_path_file( string _main_folder, string _path ){

                    return Path.Combine( Application.dataPath, "Resources", context_folder, _main_folder,  ( _path + ".png") ) ;     

            }

            private string Get_folder_file( string _main_folder, string _path ){

                return Directory.GetParent( Get_path_file(_main_folder, _path) ).FullName;

            }


        #endif

    



}