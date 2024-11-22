using UnityEngine;

public static class TOOL__module_context_audios {


        public static void Update_resource_level( RESOURCE__audio _audio ){


                Console.Log( "veio: { Update_resource_level }" );

                Verify_stage_for_content( _audio );

                if( _audio.count_places_being_used_nothing > 0 )
                    { Going_to_resource_level_NOTHING( _audio ); return; }

                if( _audio.count_places_being_used_audio_clip > 0 )
                    { Going_to_resource_level_AUDIO_CLIP( _audio ); return; }


                // ** DELETE IMAGE
                
                _audio.module_audios.actives_audios_dictionary.Remove( _audio.audio_key ); // ** nao tem mais update
                _audio.module_audios.manager.container_audios.Return_audio( _audio ); 
                
         
        }

        
        private static int Going_to_resource_level_NOTHING( RESOURCE__audio _audio ){

                Console.Log( "Veio Going_to_resource_level_NOTHING()" );

                if( _audio.content_going_to == Resource_audio_content.nothing )
                    { return 0; } // ** ja nivelado
                _audio.content_going_to = Resource_audio_content.nothing;


                // --- UP                
                // --- EQUAL
                // --- DOWN

                    //if(  )

                return TOOL__resource_audio.Down_resources( _audio );

        }

        private static int Going_to_resource_level_AUDIO_CLIP( RESOURCE__audio _audio ){

                Console.Log( "Veio Going_to_resource_level_AUDIO_CLIP()" );

                
                if( _audio.content_going_to == Resource_audio_content.audio_clip )
                    { return 0; } // ** ja nivelado
                _audio.content_going_to = Resource_audio_content.audio_clip;

                Console.Log( _audio.actual_content );


                // --- UP 
                    if( _audio.actual_content == Resource_audio_content.nothing )
                        { 
                            _audio.stage_getting_resource = Resources_getting_audio_stage.waiting_to_start;
                            return 0;  
                        }

                // --- EQUAL

                    if( _audio.actual_content == Resource_audio_content.audio_clip )
                        { return 0; }

                // --- DOWN

                return TOOL__resource_audio.Down_resources( _audio );

        }
        


        private static void Verify_stage_for_content( RESOURCE__audio _audio ){


                Resources_getting_audio_stage possible_stages = Resources_getting_audio_stage.not_give;

                switch( _audio.actual_content ){

                    case Resource_audio_content.nothing: possible_stages = Resources_getting_audio_stage.nothing_acceptable_stages; break;
                    case Resource_audio_content.audio_clip: possible_stages = Resources_getting_audio_stage.audio_clip_acceptable_stages; break;
                    
                }

                CONTROLLER__errors.Verify( !!!( TOOL__resource_audio.Verify_stage( _audio, possible_stages ) ), $"Image { _audio.name } is with content { _audio.actual_content } but the stage is { _audio.stage_getting_resource }" );
                    
                return;

        }


}