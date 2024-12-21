

using UnityEngine;

public static class TOOL__resource_logic_testing {


        public static void Test( ref RESOURCE__logic_ref _logic_ref, object[] _args ){


                Process_weight p = new (){ weight = 10 };
                CONTROLLER__resources.Get_instance().Update( ref p );
                
                CONTROLLER__tasks.Pegar_instancia().Update();



                int i = 0;

                // --- CHANGE PRE ALLOC

                if( Input.GetKeyDown( KeyCode.X ) )
                    { i++; }


                // --- UP

                if( Input.GetKeyDown( KeyCode.Q ) )
                    { i++; _logic_ref.Load(); }


               if( Input.GetKeyDown( KeyCode.W ) )
                    { i++; _logic_ref.Activate(); }
                
               if( Input.GetKeyDown( KeyCode.W ) )
                    { i++; _logic_ref.Invoke( _args ); }



                // --- DOWN

                if( Input.GetKeyDown( KeyCode.A ) )
                    { i++; _logic_ref.Unload(); }

               if( Input.GetKeyDown( KeyCode.S ) )
                    { i++; _logic_ref.Deactivate(); }


                

                // --- CHANGE LEVEL PRE ALLOC
                if( Input.GetKeyDown( KeyCode.Alpha1 ) )
                    { i++; _logic_ref.Change_level_pre_allocation( Resource_logic_content.nothing );  }

                if( Input.GetKeyDown( KeyCode.Alpha2 ) )
                    { i++; _logic_ref.Change_level_pre_allocation( Resource_logic_content.method_info );  }

                

                

                if( i > 0 )
                    { Print_logic_data( _logic_ref ); }   

        }

        public static void Print_logic_data( RESOURCE__logic_ref _logic_ref ){


                if( _logic_ref == null )
                    { return; }

                RESOURCE__logic logic = _logic_ref.logic;

                // Console.Clear();

                Console.Log( "<Color=lightBlue>-------------------</Color>" );
                Console.Log( "<Color=lightBlue>REF:</Color>" );


                Console.Log( $" state: { _logic_ref.state } " );
                Console.Log( $" actual_need_content: { _logic_ref.actual_need_content } " );
                Console.Log( $" level_pre_allocation: { _logic_ref.level_pre_allocation } " );
                Console.Log( $" ref_state: { _logic_ref.ref_state } " );
                Console.Log( $" module: { _logic_ref.module } " );
                Console.Log( $" logic: { _logic_ref.logic } " );
                Console.Log( $" logic_slot_index: { _logic_ref.logic_slot_index } " );

                if( logic == null )
                    {  return; }

                Console.Log( "<Color=lightBlue>  logic:</Color>" );
                Console.Log( $"   actual_content: { logic.actual_content }" );
                Console.Log( $"   content_going_to: { logic.content_going_to }" );
                Console.Log( $"   stage_getting_resource: { logic.stage_getting_resource }" );

                

        }



}