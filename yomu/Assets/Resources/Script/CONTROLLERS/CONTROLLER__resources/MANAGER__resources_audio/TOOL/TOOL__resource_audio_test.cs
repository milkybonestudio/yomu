

using UnityEngine;

public static class TOOL__resource_audio_testing {


        public static void Test( ref RESOURCE__audio_ref _audio_ref, AudioSource _audio_source  ){

                
                Controllers.resources.Update();
            
                CONTROLLER__tasks.Pegar_instancia().Update();

                int i = 0;

                // --- CHANGE PRE ALLOC

                if( Input.GetKeyDown( KeyCode.X ) )
                    { i++; }


                // --- UP

                if( Input.GetKeyDown( KeyCode.Q ) )
                    { i++; _audio_ref.Load(); }

               if( Input.GetKeyDown( KeyCode.W ) )
                    { i++; _audio_ref.Activate(); }

               if( Input.GetKeyDown( KeyCode.E ) )
                    { i++; _audio_source.clip = _audio_ref.Get_audio_clip(); _audio_source.Play(); }


                // --- DOWN

                if( Input.GetKeyDown( KeyCode.A ) )
                    { i++; _audio_ref.Unload(); }

               if( Input.GetKeyDown( KeyCode.S ) )
                    { i++; _audio_ref.Deactivate(); }

               if( Input.GetKeyDown( KeyCode.D ) )
                    { i++; _audio_ref.Deinstanciate(); _audio_source.clip = null; }

                
                if( Input.GetKeyDown( KeyCode.F ) )
                    { i++; _audio_ref.Delete(); _audio_ref = null; }

                

                // --- CHANGE LEVEL PRE ALLOC
                if( Input.GetKeyDown( KeyCode.Alpha1 ) )
                    { i++; _audio_ref.Change_level_pre_allocation( Resource_audio_content.nothing );  }

                if( Input.GetKeyDown( KeyCode.Alpha2 ) )
                    { i++; _audio_ref.Change_level_pre_allocation( Resource_audio_content.audio_clip );  }

                

                

                if( i > 0 )
                    { Print_audio_data( _audio_ref ); }   

        }

        public static void Print_audio_data( RESOURCE__audio_ref _audio_ref ){


                if( _audio_ref == null )
                    { return; }

                RESOURCE__audio audio = _audio_ref.audio;

                Console.Clear();

                Console.Log( "<Color=lightBlue>-------------------</Color>" );
                Console.Log( "<Color=lightBlue>REF:</Color>" );


                Console.Log( $" state: { _audio_ref.state } " );
                Console.Log( $" actual_need_content: { _audio_ref.actual_need_content } " );
                Console.Log( $" level_pre_allocation: { _audio_ref.level_pre_allocation } " );
                Console.Log( $" ref_state: { _audio_ref.ref_state } " );
                Console.Log( $" module: { _audio_ref.module } " );
                Console.Log( $" audio: { _audio_ref.audio } " );
                Console.Log( $" audio_slot_index: { _audio_ref.audio_slot_index } " );

                if( audio == null )
                    {  return; }

                Console.Log( "<Color=lightBlue>  AUDIO:</Color>" );
                Console.Log( $"   actual_content: { audio.actual_content }" );
                Console.Log( $"   content_going_to: { audio.content_going_to }" );
                Console.Log( $"   stage_getting_resource: { audio.stage_getting_resource }" );

                

        }



}