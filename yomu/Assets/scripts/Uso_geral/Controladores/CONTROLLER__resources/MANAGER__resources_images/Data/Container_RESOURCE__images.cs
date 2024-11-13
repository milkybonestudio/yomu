using System;
using UnityEngine;



public class Container_RESOURCE__images {


        public Container_RESOURCE__images(){

                images_available = new RESOURCE__image[ 100 ];

                for( int index = 0 ; index < images_available.Length ; index++ )
                    { images_available[ index ] = new RESOURCE__image(); }

        }


        public RESOURCE__image[] images_available;

        public RESOURCE__image Get_resource_image( MODULE__context_images _module_images,  Resource_context _context,  string _main_folder, string _path, Resource_image_localizer locator ){

               int image_slot = 0;

                while(  image_slot++ < ( images_available.Length - 1 )  ){

                        RESOURCE__image image = images_available[ image_slot ];
                        if( images_available[ image_slot ] == null )
                            { continue; }

                        Put_data_image( image, _module_images, _context, _main_folder, _path, locator );
                        images_available[ image_slot ] = null;
                        return image;
                        
                }

                Console.Log( "vai entrar" );
                Array.Resize( ref images_available, images_available.Length + 25 );

                while(  image_slot++ < ( images_available.Length - 1 )  ){

                        images_available[ image_slot ] = new RESOURCE__image();
                        
                }

                RESOURCE__image new_image = images_available[ ^1 ];
                images_available[ ^1 ] = null;
                return new_image;
            

        }


        public void Return_image( RESOURCE__image _image ){


                for( int image_slot = 0 ; image_slot < images_available.Length ; image_slot++ ){

                        if( images_available[ image_slot ] != null )
                            { continue; }
                        
                        images_available[ image_slot ] = _image;
                        Reset_data( _image );
                        return;
                        
                }

                CONTROLLER__errors.Throw( "tried to return a resource__image but there was no space for it" );

        }


        private void Put_data_image( RESOURCE__image _image,  MODULE__context_images _module_images,  Resource_context _context,  string _main_folder, string _path_local, Resource_image_localizer locator ){

            Console.Log( "veiuo Put_data_image()" );


                // ** IMAGE DATA
                _image.single_image.used = true;


                _image.image_context = _context; 
                _image.main_folder = _main_folder;
                _image.local_path = _path_local;

                //mark
                // ** depois mudar para somente _path_local
                Console.Log( _path_local );
                _image.image_key = $"{ _main_folder }\\{ _path_local }";
                _image.module_images = _module_images;



                _image.stage_getting_resource = Resources_getting_image_stage.finished;
                _image.actual_content = Resource_image_content.nothing;
                _image.content_going_to = Resource_image_content.nothing;
                

                _image.width = locator.width;
                _image.height = locator.height;
                _image.pointer_container = locator.pointer;
                _image.data_size = locator.length;

                if( _image.data_size > 2_000 )
                    { _image.have_low_quality = true; }
                    else
                    { _image.have_low_quality = false; }


        }

        private void Reset_data( RESOURCE__image _image ){

                // ** RESET DATA
                    _image.single_image.used = false;
                    _image.single_image.image_compress = null;

                    _image.single_image.have_low_quality_compress = false; // false => can not have the webp
                    _image.single_image.image_low_quality_compress = null;

                    // ** Nao deveria ter
                    CONTROLLER__errors.Verify( ( _image.single_image.texture_exclusiva != null ), "deu um reset na image_data mas a texture ainda estava aqui" );

                    _image.single_image.texture_exclusiva = null;
                    _image.single_image.texture_exclusiva_native_array.Dispose();
                    _image.single_image.sprite = null;

                _image.image_context = Resource_context.not_given; 
                _image.main_folder = null;
                _image.local_path = null;
                _image.image_key = null;
                _image.module_images = null;
                _image.have_low_quality = false;


                _image.stage_getting_resource = Resources_getting_image_stage.not_give;
                _image.actual_content = Resource_image_content.not_give;
                _image.content_going_to = Resource_image_content.not_give;
                

                _image.width = 0;
                _image.height = 0;
                _image.pointer_container = 0;
                _image.data_size = 0;
        

        }


}

