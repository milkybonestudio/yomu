using System;
using UnityEngine;
using UnityEngine.UI;

public static class TOOL__module_context_audios_actions {


        public static void Change_level_pre_allocation( RESOURCE__audio_ref _ref, Resource_audio_content _new_pre_alloc ){


                Console.Log( "Veio Change_pre_alloc()" );

                // --- CHANGE
                Resource_audio_content old_pre_alloc = _ref.level_pre_allocation;
                _ref.level_pre_allocation = _new_pre_alloc;

                if( _ref.state != Resource_state.minimum )
                    { return; } // ** nao vai importar

                if( old_pre_alloc == _new_pre_alloc )
                    { Console.Log( "Mesmo alloc" ); return; } // ** eh o mesmo

                // ** IS IN MINIMUm AND IS DIFERENT
                TOOL__resource_audio.Change_actual_content_count( _ref, _new_pre_alloc );
                
                TOOL__module_context_audios.Update_resource_level( _ref.audio );


        }


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

                if( _ref.state == Resource_state.nothing )
                    { return; } _ref.state = Resource_state.nothing;

                if( _ref.actual_need_content == Resource_audio_content.nothing )
                    { return; }

                TOOL__resource_audio.Change_actual_content_count( _ref, Resource_audio_content.nothing );

                TOOL__module_context_audios.Update_resource_level( _ref.audio );

                return;            

        }

        public static void Deactivate( RESOURCE__audio_ref _ref ){

            // ** GO BACK TO MINIMUm

                // ** VAI PARA O NADA

                Console.Log( "Veio Deactivate()" );
                

                if( _ref.state <= Resource_state.minimum )
                    { return; } _ref.state = Resource_state.minimum;

                if( _ref.actual_need_content == _ref.level_pre_allocation )
                    { return; }

                TOOL__resource_audio.Change_actual_content_count( _ref, _ref.level_pre_allocation );

                TOOL__module_context_audios.Update_resource_level( _ref.audio );

                return;    


        }

        public static void Deinstanciate( RESOURCE__audio_ref _ref ){

            // ** FORCE TO GO TO activate if isntanciate

                Console.Log( "Veio Deinstanciate()" );
                

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
                

                Console.Log(  "_ref.state: " + _ref.state  );
                Console.Log(  "_ref.actual_need_content: " + _ref.actual_need_content  );

                if( _ref.state >= Resource_state.minimum )
                    { return; } _ref.state = Resource_state.minimum;

                if( _ref.actual_need_content >= _ref.level_pre_allocation )
                    { return; }

            
                TOOL__resource_audio.Change_actual_content_count( _ref, _ref.level_pre_allocation );

                TOOL__module_context_audios.Update_resource_level( _ref.audio );

                return;

        }

        // ** sinaliza que pode começar a pegar a texture
        public static void Activate( RESOURCE__audio_ref _ref ){


                Console.Log( "veio Activate()" );

                
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

                
                if( _ref.state == Resource_state.instanciated )
                    { return; } _ref.state = Resource_state.instanciated;

                RESOURCE__audio audio = _ref.audio;

                audio.stage_getting_resource = Resources_getting_audio_stage.finished;


                if( audio.actual_content == Resource_audio_content.nothing )
                    {
                        audio.audio_clip = Resources.Load<AudioClip>( ( audio.audio_context.ToString() + "\\" + audio.audio_key ) );
                        audio.actual_content = Resource_audio_content.audio_clip;
                    }

                if( audio.actual_content == Resource_audio_content.audio_clip )
                    { /*nada*/ }

                if( audio.audio_clip == null )
                    { CONTROLLER__errors.Throw( $"There was no image in the resources: { audio.audio_key }. Actual content: { audio.actual_content }" ); }
                                            
                TOOL__resource_audio.Change_actual_content_count( _ref, Resource_audio_content.audio_clip );


                
                return;

        }


}