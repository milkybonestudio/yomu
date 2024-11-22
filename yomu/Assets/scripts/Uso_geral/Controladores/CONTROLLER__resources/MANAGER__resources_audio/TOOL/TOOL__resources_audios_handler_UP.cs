using System;
using UnityEngine;


public static class TOOL__resources_audios_handler_UP {


        public static int Handle_waiting_to_start( MANAGER__resources_audios _manager, RESOURCE__audio _audio ){


                TOOL__resource_audio.Verify_audio( _audio );

                CONTROLLER__errors.Verify( ( _audio.actual_content != Resource_audio_content.nothing ), $"the image { _audio.name } came to the Handle_waiting_to_start() but the actual content is { _audio.actual_content }" );

                int weight = 0;

                    _audio.stage_getting_resource = Resources_getting_audio_stage.finished;

                    if( _audio.content_going_to == Resource_audio_content.nothing )
                        {
                            _audio.actual_content = Resource_audio_content.nothing;
                            return weight; 
                        }

                    if( _audio.content_going_to == Resource_audio_content.audio_clip )
                        {
                            
                            _audio.audio_clip = ( Resources.Load<AudioClip>(   _audio.audio_context.ToString() + "\\" + _audio.audio_key ) );
                            _audio.audio_clip.LoadAudioData();
                            

                            _audio.actual_content = Resource_audio_content.audio_clip;
                            weight += 1;
                            return weight; 
                        }



                return CONTROLLER__errors.Throw( $"Could not handle content_going_to { _audio.content_going_to } of the audio { _audio.name }" );

        }


}