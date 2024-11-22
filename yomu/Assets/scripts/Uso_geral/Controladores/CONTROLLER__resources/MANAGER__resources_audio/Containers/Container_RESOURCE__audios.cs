using System;
using UnityEngine;



public class Container_RESOURCE__audios {


        public Container_RESOURCE__audios(){

                images_available = new RESOURCE__audio[ 100 ];

                for( int index = 0 ; index < images_available.Length ; index++ )
                    { images_available[ index ] = new RESOURCE__audio(); }

                images_waiting_to_reset = new RESOURCE__audio[ 20 ];

        }


        private RESOURCE__audio[] images_available;        

        private RESOURCE__audio[] images_waiting_to_reset;
        private int pointer_image_to_delete = 0;

        public RESOURCE__audio Get_resource_audio( MODULE__context_audios _module_images,  Resource_context _context,  string _main_folder, string _path, Resource_audio_localizer locator ){

               int image_slot = 0;

                while(  image_slot++ < ( images_available.Length - 1 )  ){

                        RESOURCE__audio image = images_available[ image_slot ];
                        if( images_available[ image_slot ] == null )
                            { continue; }

                        Put_data_image( image, _module_images, _context, _main_folder, _path, locator );
                        images_available[ image_slot ] = null;
                        return image;
                        
                }

                Console.Log( "vai entrar" );
                Array.Resize( ref images_available, images_available.Length + 25 );

                while(  image_slot++ < ( images_available.Length - 1 )  ){

                        images_available[ image_slot ] = new RESOURCE__audio();
                        
                }

                RESOURCE__audio new_image = images_available[ ^1 ];
                images_available[ ^1 ] = null;
                return new_image;
            

        }


        public void Return_audio( RESOURCE__audio _image ){


                _image.audio_state = Resource_use_state.waiting_to_delete; 

                if( images_waiting_to_reset.Length == pointer_image_to_delete )
                    { Array.Resize( ref images_waiting_to_reset, ( images_waiting_to_reset.Length + 10 ) );  }

                images_waiting_to_reset[ pointer_image_to_delete++ ] = _image;

        }


        public int Update( int _weight_to_stop, int _current_weight ){

                for( int slot = 0 ; slot < pointer_image_to_delete ; slot++ ){

                        if( images_waiting_to_reset[ slot ] == null )
                            { continue; }

                        _current_weight += Return_image_to_available( images_waiting_to_reset[ slot ] );
                        images_waiting_to_reset[ slot ] = null;

                        if( _current_weight >= _weight_to_stop )
                            { return _current_weight; }

                        continue;
                    
                }

                return _current_weight;

        }



        private int Return_image_to_available( RESOURCE__audio _image ){


                for( int image_slot = 0 ; image_slot < images_available.Length ; image_slot++ ){

                        if( images_available[ image_slot ] != null )
                            { continue; }
                        
                        images_available[ image_slot ] = _image;
                        return Reset_data( _image );
                        
                }

                CONTROLLER__errors.Throw( "tried to return a resource__audio but there was no space for it" );
                return 0;

        }


        public string Get_image_key( string _main_folder, string _path_local ){

            return  $"{ _main_folder }\\{ _path_local }";
        }


        private void Put_data_image( RESOURCE__audio _image,  MODULE__context_audios _module_audios,  Resource_context _context,  string _main_folder, string _path_local, Resource_audio_localizer locator ){

            Console.Log( "veiuo Put_data_image()" );


                _image.audio_context = _context;
                _image.main_folder = _main_folder;
                _image.local_path = _path_local;

                //mark
                // ** depois mudar para somente _path_local
                Console.Log( _path_local );
                _image.audio_key = Get_image_key( _main_folder, _path_local );
                _image.module_audios = _module_audios;



                _image.stage_getting_resource = Resources_getting_audio_stage.finished;
                _image.actual_content = Resource_audio_content.nothing;
                _image.content_going_to = Resource_audio_content.nothing;
                



        }

        private int Reset_data( RESOURCE__audio _image ){


                int weight = 0;

                // ** IMPORTANT
                _image.audio_state = Resource_use_state.unused;


                _image.audio_context = Resource_context.not_given; 
                _image.main_folder = null;
                _image.local_path = null;
                _image.audio_key = null;
                _image.module_audios = null;
                


                _image.stage_getting_resource = Resources_getting_audio_stage.not_give;
                _image.actual_content = Resource_audio_content.not_give;
                _image.content_going_to = Resource_audio_content.not_give;
                
                return weight;
        

        }


}

