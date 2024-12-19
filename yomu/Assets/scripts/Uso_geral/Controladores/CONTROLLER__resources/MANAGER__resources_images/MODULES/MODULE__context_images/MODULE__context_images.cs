using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;


        /*
                por hora todo o contexto vai estar em 1 grande container. Quando for precisar ter mais precisa fazer de um jeito para nao ficar criando e destruindo streams. 
                por hora pode ter sempre 1 em cada modelo.        
        */

        //mark
        // por hora nao vai ser preocupar com os pointers, no final vai ter um arquivo  context_folder.txt na pasta com os pointers
        // ** multiples sempre tem a mesma quantidade de images



public class MODULE__context_images {


        public MODULE__context_images( MANAGER__resources_images _manager, Resource_context _context, int _initial_capacity, int _buffer_cache ){

                if( _context == Resource_context.not_given )
                    { CONTROLLER__errors.Throw( "tried to create a MODULE__context_images but the context came as <Color=lightBlue>not_give</Color>" ); }

                context = _context;
                context_folder = _context.ToString();
                manager = _manager;

                #if !!! UNITY_EDITOR
                    file_stream = FILE_STREAM.Criar_stream( _path, buffer_cache );
                #endif

                actives_images_dictionary = new Dictionary<string, RESOURCE__image>();
                actives_images_dictionary.EnsureCapacity( _initial_capacity );

                images_locators_dictionary = new Dictionary<string, Resource_image_localizer>();

        }

        public int Get_bytes(){ return 0; }


        public string context_folder;
        public Resource_context context;

        public MANAGER__resources_images manager;

        public FileStream file_stream;
        
        public Dictionary<string, RESOURCE__image> actives_images_dictionary;
        public Dictionary<string, Resource_image_localizer> images_locators_dictionary;


        // sempre single
        public RESOURCE__image_ref Get_image_ref(  string _main_folder, string _path_local,  Resource_image_content _level_pre_allocation  ){

                // ** quando separar por _main_folder tirar
                
                RESOURCE__image image = null;
                
                string key = manager.container_images.Get_image_key( _main_folder, _path_local );

                // --- VERIFY IF IMAGE ALREADY EXISTS
                if( !!!( Get_dictionary( _main_folder ).TryGetValue( key, out image ) ) )
                    {  image = Create_new_image( _main_folder, _path_local  );} 

                return Create_image_ref( image, _level_pre_allocation );
                    
        }



        private RESOURCE__image Create_new_image( string _main_folder, string _path_local ){


                if( Application.isEditor )
                    { return Create_new_image_EDITOR( _main_folder, _path_local ); }
                    else
                    { return Create_new_image_BUILD( _main_folder, _path_local ); }



                // --- EDITOR
                RESOURCE__image Create_new_image_EDITOR( string _main_folder, string _path_local ){

                
                        Resource_image_localizer locator = new Resource_image_localizer();

                        // ** no editor posso pegar a imagem e verificar o tamanho dela, nao tem problema se demorar um pouco para iniciar, depois de colocar no cache ficar verificando vai ser muito rapido. 
                        // ** provavelmente vai ser mais rapido usar streamreader para pegar somente os primeiros bytes, o os provavelmente vai copiar o png inteiro de um lugar para o outro na ram se nao fizer
                        string png_path = System.IO.Path.Combine( Application.dataPath, "Resources", context.ToString(), ( manager.container_images.Get_image_key( _main_folder, _path_local ) + ".png" ) );
                        byte[] png = null;

                        try {

                            png = System.IO.File.ReadAllBytes( png_path );
                        }
                        catch( Exception e ){ CONTROLLER__errors.Throw( "could not find the image in the path: " + png_path ) ;}
                
                        Dimensions dimensions = PNG.Get_dimensions( png );

                            locator.width = dimensions.width;
                            locator.height = dimensions.height;
                            locator.pointer = -1;
                            locator.length = png.Length;


                        RESOURCE__image image = manager.container_images.Get_resource_image( this, context, _main_folder, _path_local, locator );

                        Get_dictionary( _main_folder ).Add( image.image_key, image );

                        return image;

                }

                // --- BUILD
                RESOURCE__image Create_new_image_BUILD( string _main_folder, string _path_local ){

                    
                        Resource_image_localizer locator = new Resource_image_localizer();

                        RESOURCE__image image = manager.container_images.Get_resource_image( this, context, _main_folder, _path_local, locator );

                        if( !!!( Get_dictionary_locators( _main_folder ).TryGetValue( _path_local, out locator ) ) )
                            { CONTROLLER__errors.Throw( $"Locator of the path { _path_local } was not found" ); }

                        Get_dictionary( _main_folder ).Add( _path_local, image );

                        return image;

                }
        }




        private RESOURCE__image_ref Create_image_ref( RESOURCE__image _image, Resource_image_content _level_pre_allocation ){


                RESOURCE__image_ref image_ref = manager.container_image_refs.Get_resource_image_ref( _image, _level_pre_allocation );

                ARRAY.Guaranty_size( ref _image.refs, _image.refs_pointer, 1, 20 );

                // --- GURADA REF
                image_ref.image_slot_index = _image.refs_pointer;
                _image.refs[ _image.refs_pointer++ ] = image_ref;
                
                TOOL__resource_image.Increase_count( _image, Resource_image_content.nothing );

                return image_ref;

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

            // ??????

            private string Get_path_file( string _main_folder, string _path ){

                    return Path.Combine( Application.dataPath, "Resources", context_folder, _main_folder,  ( _path + ".png") ) ;     

            }

            private string Get_folder_file( string _main_folder, string _path ){

                return Directory.GetParent( Get_path_file(_main_folder, _path) ).FullName;

            }


        #endif

    



}