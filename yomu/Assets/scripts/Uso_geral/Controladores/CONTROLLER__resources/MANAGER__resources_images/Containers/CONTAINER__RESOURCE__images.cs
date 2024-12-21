using System;
using UnityEngine;


public class CONTAINER__RESOURCE__images {


        // public static C_resources_args args = new C_resources_args();


        public CONTAINER__RESOURCE__images(){

                images_available = new RESOURCE__image[ 300 ];

                for( int index = 0 ; index < images_available.Length ; index++ )
                    { images_available[ index ] = new RESOURCE__image(); }

                images_waiting_to_reset = new RESOURCE__image[ 100 ];

        }


        private RESOURCE__image[] images_available;
        

        private RESOURCE__image[] images_waiting_to_reset;
        private int pointer_image_to_delete = 0;

        private int pointer_object_to_verify = -1;

        public RESOURCE__image Get_resource_image( MODULE__context_images _module_images,  Resource_context _context,  string _main_folder, string _path, Resource_image_localizer locator ){

               

                while(  pointer_object_to_verify++ < ( images_available.Length - 1 )  ){

                        RESOURCE__image image = images_available[ pointer_object_to_verify ];
                        if( images_available[ pointer_object_to_verify ] == null )
                            { continue; }

                        Put_data_image( image, _module_images, _context, _main_folder, _path, locator );
                        images_available[ pointer_object_to_verify ] = null;
                        return image;
                        
                }


                int old_length = images_available.Length;
                
                Array.Resize( ref images_available, images_available.Length + 150 );

                while(  old_length++ < ( images_available.Length - 1 )  ){

                        images_available[ pointer_object_to_verify ] = new RESOURCE__image();
                        
                }

                RESOURCE__image new_image = images_available[ pointer_object_to_verify ];
                images_available[ pointer_object_to_verify ] = null;
                return new_image;
            

        }


        public void Return_image( RESOURCE__image _image ){


                _image.image_state = Resource_use_state.waiting_to_delete; 

                if( images_waiting_to_reset.Length == pointer_image_to_delete )
                    { Array.Resize( ref images_waiting_to_reset, ( images_waiting_to_reset.Length + 10 ) );  }

                images_waiting_to_reset[ pointer_image_to_delete++ ] = _image;

        }


        public int Update( int _weight_to_stop, int _current_weight ){

                int index_atual = 0;

                for( int slot = 0 ; slot < pointer_image_to_delete ; slot++ ){

                        if( images_waiting_to_reset[ slot ] == null )
                            { continue; }

                        _current_weight += Return_image_to_available( images_waiting_to_reset[ slot ], ref index_atual );
                        images_waiting_to_reset[ slot ] = null;

                        if( _current_weight >= _weight_to_stop )
                            { return _current_weight; }

                        continue;
                    
                }

                return _current_weight;

        }



        private int Return_image_to_available( RESOURCE__image _image, ref int _index_atual ){


                while( _index_atual++ < ( images_available.Length - 1 ) ){

                        if( images_available[ _index_atual ] != null )
                            { continue; }

                        if( pointer_object_to_verify > _index_atual )
                            { pointer_object_to_verify = _index_atual; }
                        
                        images_available[ _index_atual ] = _image;
                        Reset_data( _image );
                        return 0;
                        
                }

                CONTROLLER__errors.Throw( "tried to return a resource__image but there was no space for it" );
                return 0;

        }


        public string Get_image_key( string _main_folder, string _path_local ){

            if( _path_local == null )
                { CONTROLLER__errors.Throw( $"the path_local is null" ); }

            if( _main_folder == null )
                { CONTROLLER__errors.Throw(  $"the main_folder is null" ); }
            
            return  $"{ _main_folder }\\{ _path_local }";
        }


        private void Put_data_image( RESOURCE__image _image,  MODULE__context_images _module_images,  Resource_context _context,  string _main_folder, string _path_local, Resource_image_localizer locator ){


                // ** IMAGE DATA
                _image.single_image.used = true;


                _image.image_context = _context; 
                _image.main_folder = _main_folder;
                _image.local_path = _path_local;

                //mark
                // ** depois mudar para somente _path_local
                _image.image_key = Get_image_key( _main_folder, _path_local );
                _image.module_images = _module_images;



                _image.stage_getting_resource = Resources_getting_image_stage.finished;
                _image.actual_content = Resource_image_content.nothing;
                _image.content_going_to = Resource_image_content.nothing;
                

                _image.width = locator.width;
                _image.height = locator.height;
                _image.pointer_container = locator.pointer;
                _image.data_size = locator.length;

                if( _image.data_size > 2_000 )
                    { _image.system_have_low_quality = true; }
                    else
                    { _image.system_have_low_quality = false; }


        }

        private int Reset_data( RESOURCE__image _image ){


                int weight = 0;

                // ** RESET DATA
                    _image.single_image.used = false;
                    _image.single_image.image_compress = null;

                    _image.single_image.have_low_quality_compress = false; // false => can not have the webp
                    _image.single_image.image_low_quality_compress = null;


                    if( _image.single_image.texture_exclusiva != null )
                        {
                            GameObject.Destroy( _image.single_image.texture_exclusiva );
                            _image.single_image.texture_exclusiva_native_array.Dispose();
                            weight = 1;
                        }
                    _image.single_image.sprite = null;

                // ** IMPORTANT
                _image.image_state = Resource_use_state.unused;


                _image.image_context = Resource_context.not_given; 
                _image.main_folder = null;
                _image.local_path = null;
                _image.image_key = null;
                _image.module_images = null;
                _image.system_have_low_quality = false;


                _image.stage_getting_resource = Resources_getting_image_stage.not_give;
                _image.actual_content = Resource_image_content.not_give;
                _image.content_going_to = Resource_image_content.not_give;
                

                _image.width = 0;
                _image.height = 0;
                _image.pointer_container = 0;
                _image.data_size = 0;


                return weight;
        

        }


}

