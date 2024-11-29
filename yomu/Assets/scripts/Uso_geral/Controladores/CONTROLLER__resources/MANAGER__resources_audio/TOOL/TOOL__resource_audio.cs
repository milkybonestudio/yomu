using UnityEngine;

public static class TOOL__resource_audio {



        public static void Verify_audio( RESOURCE__audio _audio ){ 


                if( _audio.audio_clip == null )
                    { return; }

                if( _audio.audio_clip.loadType != AudioClipLoadType.Streaming )
                    { CONTROLLER__errors.Throw( $"audio { _audio.name } have the loadType { _audio.audio_clip.loadType }. Only stream is accepted for now" ); }

        
                return; 
                
        }
        public static bool Need_to_update( RESOURCE__audio _audio ){ return true; }


        public static int Down_resources( RESOURCE__audio _audio ){ 

                int weight = 0;
                
                if( _audio.content_going_to <= Resource_audio_content.nothing )
                    { weight += Destroy_audio_clip( _audio ); }
                
                return 0; 

        }

        private static int Destroy_audio_clip( RESOURCE__audio _audio ){

                if( _audio.actual_content < Resource_audio_content.audio_clip )
                    { return 0; }

                Resources.UnloadAsset( _audio.audio_clip );
                _audio.audio_clip = null;
                _audio.actual_content = Resource_audio_content.nothing;

                return 0;

        }


        public static void Verify_audio_ref ( RESOURCE__audio_ref audio_ref ){ return; }


        public static void Change_actual_content_count( RESOURCE__audio_ref _audio_ref, Resource_audio_content _new_content ){


                RESOURCE__audio audio = _audio_ref.audio;

                Resource_audio_content old_content = _audio_ref.actual_need_content;
                
                if( old_content == _new_content )
                    { return; }

                Increase_count( audio, _new_content );
                Decrease_count( audio, old_content );

                _audio_ref.actual_need_content = _new_content;

                return;

        }
        
        public static void Increase_count( RESOURCE__audio _audio, Resource_audio_content _content ){ Change( _audio, _content, 1 ); }
        public static void Decrease_count( RESOURCE__audio _audio, Resource_audio_content _content ){ Change( _audio, _content, -1 ); }


        public static void Change( RESOURCE__audio _audio, Resource_audio_content _content, int _value ){

                
                switch( _content ){

                    case Resource_audio_content.nothing: _audio.count_places_being_used_nothing += _value; return;
                    case Resource_audio_content.audio_clip: _audio.count_places_being_used_audio_clip += _value; return;
                    default: CONTROLLER__errors.Throw( $"Can not ahndle the content <Color=lightBlue>{ _content }</Color> in the audio { _audio.name }" ); return;
                    
                }

        }





        public static bool Verify_stage( RESOURCE__audio _audio, Resources_getting_audio_stage _stage ){

            return ( ( _audio.stage_getting_resource & _stage ) != 0 );

        }

    
        public static bool Verify_actual_content( RESOURCE__audio _audio, Resource_audio_content _content ){

            return ( ( _audio.actual_content & _content ) != 0 );

        }

    
        public static int Set_stage( RESOURCE__audio _audio,  Resources_getting_audio_stage _stage ){

            _audio.stage_getting_resource = _stage;
            return 0;

        }

        public static int Set_stage_cancelling_task( RESOURCE__audio _audio,  Resources_getting_audio_stage _stage, ref Task_req _task_ref ){

            _audio.stage_getting_resource = _stage;
            TASK_REQ.Cancel_task( ref _task_ref );
            return 0;

        }






}