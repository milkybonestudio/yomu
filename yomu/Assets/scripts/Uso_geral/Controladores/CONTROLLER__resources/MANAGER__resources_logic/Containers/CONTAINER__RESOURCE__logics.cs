using System;
using UnityEngine;



public class CONTAINER__RESOURCE__logics {


        public CONTAINER__RESOURCE__logics(){

                images_available = new RESOURCE__logic[ 100 ];

                for( int index = 0 ; index < images_available.Length ; index++ )
                    { images_available[ index ] = new RESOURCE__logic(); }

                images_waiting_to_reset = new RESOURCE__logic[ 20 ];

        }


        private RESOURCE__logic[] images_available;        

        private RESOURCE__logic[] images_waiting_to_reset;
        private int pointer_image_to_delete = 0;

        public RESOURCE__logic Get_resource_logic( MODULE__context_logics _module_logics,  Resource_context _context,  string _class_name, string _path, string _key ){

               int image_slot = 0;

                while(  image_slot++ < ( images_available.Length - 1 )  ){

                        RESOURCE__logic image = images_available[ image_slot ];
                        if( images_available[ image_slot ] == null )
                            { continue; }

                        Put_data_logic( image, _module_logics, _context, _class_name, _path, _key );
                        images_available[ image_slot ] = null;
                        return image;
                        
                }

                Console.Log( "vai entrar" );
                Array.Resize( ref images_available, images_available.Length + 25 );

                while(  image_slot++ < ( images_available.Length - 1 )  ){

                        images_available[ image_slot ] = new RESOURCE__logic();
                        
                }

                RESOURCE__logic new_image = images_available[ ^1 ];
                images_available[ ^1 ] = null;
                return new_image;
            

        }


        public void Return_logic( RESOURCE__logic _image ){


                _image.logic_state = Resource_use_state.waiting_to_delete; 

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



        private int Return_image_to_available( RESOURCE__logic _image ){


                for( int image_slot = 0 ; image_slot < images_available.Length ; image_slot++ ){

                        if( images_available[ image_slot ] != null )
                            { continue; }
                        
                        images_available[ image_slot ] = _image;
                        return Reset_data( _image );
                        
                }

                CONTROLLER__errors.Throw( "tried to return a resource__logic but there was no space for it" );
                return 0;

        }


        private void Put_data_logic( RESOURCE__logic _logic,  MODULE__context_logics _module_logics,  Resource_context _context,  string _class_name, string _method_name, string _key ){

                _logic.logic_context = _context;

                _logic.class_name = _class_name;
                _logic.method_name = _method_name;
                _logic.logic_key = _key;
                
                _logic.module_logics = _module_logics;



                _logic.stage_getting_resource = Resources_getting_logic_stage.finished;
                _logic.actual_content = Resource_logic_content.nothing;
                _logic.content_going_to = Resource_logic_content.nothing;
                

        }

        private int Reset_data( RESOURCE__logic _image ){


                int weight = 0;

                // ** IMPORTANT
                _image.logic_state = Resource_use_state.unused;


                _image.logic_context = Resource_context.not_given; 
                _image.class_name = null;
                _image.method_name = null;
                _image.method_info = null;

                _image.module_logics = null;
                


                _image.stage_getting_resource = Resources_getting_logic_stage.not_give;
                _image.actual_content = Resource_logic_content.not_give;
                _image.content_going_to = Resource_logic_content.not_give;
                
                return weight;
        

        }


}

