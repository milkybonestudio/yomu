using System;
using UnityEngine;
using UnityEngine.UI;

public static class TOOL__module_context_audios_actions {



        public static AudioClip Get_audio_clip( RESOURCE__audio_ref _ref ){


                RESOURCE__audio audio = _ref.audio;
                                
                if( _ref.state != Resource_state.instanciated )
                    { Instanciate( _ref  ); }

                return audio.audio_clip;

        }


        // --- DOWN

        // ** imagem vai ser deletada completamente 
        public static void Delete( RESOURCE__audio_ref _ref ){


                RESOURCE__audio audio = _ref.audio;

                // ** LOSE REF
                audio.need_reajust = true;
                audio.refs[ _ref.audio_slot_index ] = null;

                TOOL__resource_audio.Decrease_count( audio, _ref.actual_need_content ); 
                audio.module_audios.manager.container_audio_refs.Return_audio_ref( _ref );
                
                TOOL__module_context_audios.Update_resource_level( audio );
                
                return;

        } 

        
        public static void Unload( RESOURCE__audio_ref _ref ){

                // ** VAI PARA O NADA

                Console.Log( "Veio Unload()" );
                CONTROLLER__errors.Verify( ( _ref.audio == null ), $"Tried to Unload ref { _ref.identifire }, but the RESOURCE__audio is null" );

                if( _ref.state == Resource_state.nothing )
                    { return; } _ref.state = Resource_state.nothing;

                if( _ref.actual_need_content == Resource_audio_content.nothing )
                    { return; }

                TOOL__resource_audio.Change_actual_content_count( _ref, Resource_audio_content.nothing );

                TOOL__module_context_audios.Update_resource_level( _ref.audio );

                return;            

        }

        public static void Deactivate( RESOURCE__audio_ref _ref ){

            // ** GO BACK TO MINIMUN

                // ** VAI PARA O NADA

                Console.Log( "Veio Deactivate()" );
                CONTROLLER__errors.Verify( ( _ref.audio == null ), $"Tried to Deactivate ref { _ref.identifire }, but the RESOURCE__audio is null" );


                if( _ref.state <= Resource_state.minimun )
                    { return; } _ref.state = Resource_state.minimun;

                if( _ref.actual_need_content == _ref.level_pre_allocation )
                    { return; }

                TOOL__resource_audio.Change_actual_content_count( _ref, _ref.level_pre_allocation );

                TOOL__module_context_audios.Update_resource_level( _ref.audio );

                return;    


        }

        public static void Deinstanciate( RESOURCE__audio_ref _ref ){

            // ** FORCE TO GO TO activate if isntanciate

                Console.Log( "Veio Deinstanciate()" );
                CONTROLLER__errors.Verify( ( _ref.audio == null ), $"Tried to Deactivate ref { _ref.identifire }, but the RESOURCE__audio is null" );


                if( _ref.state <= Resource_state.active )
                    { return; } _ref.state = Resource_state.active;

                if( _ref.actual_need_content == Resource_audio_content.audio_clip )
                    { return; }


                TOOL__resource_audio.Change_actual_content_count( _ref, _ref.level_pre_allocation );

                TOOL__module_context_audios.Update_resource_level( _ref.audio );

                return;    

        }



        // --- UP

        // ** sinaliza que a imagem pode carregar o minimo 
        public static void Load( RESOURCE__audio_ref _ref ){


                Console.Log( "Veio Load()" );
                CONTROLLER__errors.Verify( ( _ref.audio == null ), $"Tried to Load ref { _ref.identifire }, but the RESOURCE__audio is null" );


                Console.Log(  "_ref.state: " + _ref.state  );
                Console.Log(  "_ref.actual_need_content: " + _ref.actual_need_content  );

                if( _ref.state >= Resource_state.minimun )
                    { return; } _ref.state = Resource_state.minimun;

                if( _ref.actual_need_content >= _ref.level_pre_allocation )
                    { return; }

            
                TOOL__resource_audio.Change_actual_content_count( _ref, _ref.level_pre_allocation );

                TOOL__module_context_audios.Update_resource_level( _ref.audio );

                return;

        }

        // ** sinaliza que pode começar a pegar a texture
        public static void Activate( RESOURCE__audio_ref _ref ){


                Console.Log( "veio Activate()" );

                CONTROLLER__errors.Verify( ( _ref.audio == null ), $"Tried to Activate ref { _ref.identifire }, but the RESOURCE__audio is null" );

                if( _ref.state >= Resource_state.active )
                    { return; } _ref.state = Resource_state.active;

                if( _ref.actual_need_content == Resource_audio_content.audio_clip )
                    { Console.Log( "a precisava do audio_clip" ); return; }


                Console.Log( "a precisava do audio_clip" );
                TOOL__resource_audio.Change_actual_content_count( _ref, Resource_audio_content.audio_clip );

                TOOL__module_context_audios.Update_resource_level( _ref.audio );

                Console.Log( _ref.audio.actual_content );
                
                return;

        }

    
        public static void Instanciate( RESOURCE__audio_ref _ref ){

                // ** FORCE TO GET AUDIO


                Console.Log( "Veio Instanciate()" );

                CONTROLLER__errors.Verify( ( _ref.audio == null ), $"Tried to Activate ref { _ref.identifire }, but the RESOURCE__audio is null" );

                if( _ref.state == Resource_state.instanciated )
                    { return; } _ref.state = Resource_state.instanciated;

                RESOURCE__audio audio = _ref.audio;


                if( audio.actual_content == Resource_audio_content.nothing )
                    {
                        audio.audio_clip = Resources.Load<AudioClip>( ( audio.audio_context.ToString() + "\\" + audio.audio_key ) );
                        audio.actual_content = Resource_audio_content.audio_clip;
                    }

                if( audio.actual_content == Resource_audio_content.audio_clip )
                    { /*nada*/ }

                CONTROLLER__errors.Verify( ( audio.audio_clip == null ), $"There was no image in the resources: { audio.audio_key }. Actual content: { audio.actual_content }" );
                                            
                TOOL__resource_audio.Change_actual_content_count( _ref, Resource_audio_content.audio_clip );


                
                return;

        }


}