using UnityEngine;

public static class TOOL__resource_audio {



        public static void Verify_audio( RESOURCE__audio _image ){

                return;

        }


        public static bool Need_to_update( RESOURCE__audio _image ){

                
                return true;
        
        }



        public static int Down_resources( RESOURCE__audio _image ){

                Console.Log( "Veio down resources" );
                return Set_stage( _image, Resources_getting_audio_stage.waiting_to_destroy_current_resource );

        }


        public static void Verify_image_ref ( RESOURCE__audio_ref image_ref ){

                return;

        }


        public static void Change_actual_content_count( RESOURCE__audio_ref _image_ref, Resource_audio_content _new_content ){


                RESOURCE__audio image = _image_ref.image;

                Resource_audio_content old_content = _image_ref.actual_need_content;
                
                if( old_content == _new_content )
                    { return; }

                Increase_count( image, _new_content );
                Decrease_count( image, old_content );

                _image_ref.actual_need_content = _new_content;

                return;

        }
        
        public static void Increase_count( RESOURCE__audio _image, Resource_audio_content _content ){ Change( _image, _content, 1 ); }
        public static void Decrease_count( RESOURCE__audio _image, Resource_audio_content _content ){ Change( _image, _content, -1 ); }


        public static void Change( RESOURCE__audio _image, Resource_audio_content _content, int _value ){

                
                switch( _content ){

                    case Resource_audio_content.nothing: _image.count_places_being_used_nothing += _value; return;
                    
                }

        }





        public static bool Verify_stage( RESOURCE__audio _image, Resources_getting_audio_stage _stage ){

            return ( ( _image.stage_getting_resource & _stage ) != 0 );

        }

    
        public static bool Verify_actual_content( RESOURCE__audio _image, Resource_audio_content _content ){

            return ( ( _image.actual_content & _content ) != 0 );

        }

    
        public static int Set_stage( RESOURCE__audio _image,  Resources_getting_audio_stage _stage ){

            _image.stage_getting_resource = _stage;
            return 0;

        }

        public static int Set_stage_cancelling_task( RESOURCE__audio _image,  Resources_getting_audio_stage _stage, ref Task_req _task_ref ){

            _image.stage_getting_resource = _stage;
            TASK_REQ.Cancel_task( ref _task_ref );
            return 0;

        }




        public static void Print_image_data( RESOURCE__audio_ref _image_ref ){


                if( _image_ref == null )
                    { return; }

                RESOURCE__audio image = _image_ref.image;

                Console.Clear();

                Console.Log( "<Color=lightBlue>-------------------</Color>" );
                Console.Log( "<Color=lightBlue>REF:</Color>" );


                Console.Log( $" state: { _image_ref.state } " );
                Console.Log( $" actual_need_content: { _image_ref.actual_need_content } " );
                Console.Log( $" level_pre_allocation: { _image_ref.level_pre_allocation } " );
                Console.Log( $" ref_state: { _image_ref.ref_state } " );
                Console.Log( $" module: { _image_ref.module } " );
                Console.Log( $" image: { _image_ref.image } " );
                Console.Log( $" image_slot_index: { _image_ref.image_slot_index } " );

                if( image == null )
                    {  return; }

                Console.Log( "<Color=lightBlue>  IMAGE:</Color>" );
                Console.Log( $"   actual_content: { image.actual_content }" );
                Console.Log( $"   content_going_to: { image.content_going_to }" );
                Console.Log( $"   stage_getting_resource: { image.stage_getting_resource }" );

                // -- image 

                if(  image.single_image.image_compress != null )
                    { Console.Log( $"     image_compress.Length:  { Formater.Format_number(  image.single_image.image_compress.Length ) }" ); }
                    else 
                    { Console.Log( $"     image_compress.Length:  " ); }
                    

                Console.Log( $"     tem low_quality: "  + image.single_image.have_low_quality_compress );
                if(  image.single_image.image_low_quality_compress != null )
                    { Console.Log( $"     image_low_quality_compress.Length:  {  Formater.Format_number( image.single_image.image_low_quality_compress.Length ) }" ); }
                    else
                    { Console.Log( $"     image_low_quality_compress.Length:  " ); }


                Console.Log( $"     single_image.sprite: { image.single_image.sprite }" );

                if( image.single_image.texture_exclusiva != null )
                    { Console.Log( $"     tamanho: { Formater.Format_number( image.single_image.texture_exclusiva.width * image.single_image.texture_exclusiva.height ) } px" ); }

                Console.Log( $"     counts: " );
                Console.Log( $"         image.count_places_being_used_nothing: { image.count_places_being_used_nothing }" );
            
                

        }



}