using UnityEngine;

public static class TOOL__module_context_audios {


        public static void Update_resource_level( RESOURCE__audio _image ){


                Console.Log( "veio: { Update_resource_level }" );

                Verify_stage_for_content( _image );

                Resources_getting_audio_stage blocked_for_now = ( Resources_getting_audio_stage.getting_texture | Resources_getting_audio_stage.applying_texture );

                CONTROLLER__errors.Verify( ( int ) ( _image.stage_getting_resource & blocked_for_now  ), $"Tried to update resources level, but the current resources stage is not allowed: { _image.stage_getting_resource }" );
                
                if( _image.count_places_being_used_nothing > 0 )
                    { Going_to_resource_level_NOTHING( _image ); return; }

                // ** imagem perdeu todas as referencias, tem que deletar tudo

                // ** DELETE IMAGE

                
                _image.module_images.actives_images_dictionary.Remove( _image.image_key ); // ** nao tem mais update
                _image.module_images.manager.container_images.Return_image( _image ); 
                
         
        }

        
        private static int Going_to_resource_level_NOTHING( RESOURCE__audio _image ){

                Console.Log( "Veio Going_to_resource_level_NOTHING()" );

                if( _image.content_going_to == Resource_audio_content.nothing )
                    { return 0; } // ** ja nivelado
                _image.content_going_to = Resource_audio_content.nothing;


                // --- UP                
                // --- EQUAL

                    if( _image.actual_content == Resource_audio_content.nothing )
                        { 
                            if( _image.stage_getting_resource == Resources_getting_audio_stage.getting_compress_low_quality_file )
                                { return TOOL__resource_audio.Set_stage_cancelling_task( _image, Resources_getting_audio_stage.finished, ref _image.module_images.manager.task_getting_compress_low_quality_file ); }
                                else
                                { return TOOL__resource_audio.Set_stage( _image, Resources_getting_audio_stage.finished ); }
                        }

                // --- DOWN

                    return TOOL__resource_audio.Down_resources( _image );

        }


        private static void Verify_stage_for_content( RESOURCE__audio _image ){


                Resources_getting_audio_stage possible_stages = Resources_getting_audio_stage.not_give;

                switch( _image.actual_content ){

                    case Resource_audio_content.nothing: possible_stages = Resources_getting_audio_stage.nothing_acceptable_stages; break;
                    
                }

                CONTROLLER__errors.Verify( !!!( TOOL__resource_audio.Verify_stage( _image, possible_stages ) ), $"Image { _image.name } is with content { _image.actual_content } but the stage is { _image.stage_getting_resource }" );
                    
                return;

        }


}