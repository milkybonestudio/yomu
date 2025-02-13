


using System;
using System.Runtime.CompilerServices;




unsafe public class CONTROLLER__program_transition {

        public static CONTROLLER__program_transition instance;
        public static CONTROLLER__program_transition Get_instance(){ return instance; }


        public Transition transition;
        public Swithcing_program_transition_state state;

        // ** used only in transition for reference
        private PROGRAM_MODE old_mode;
        private PROGRAM_MODE new_mode;
        
        // --- PROTECTION

        public System.Diagnostics.Stopwatch watch;
        public long[] max_time_to_transition_ms;

        public void Update( Control_flow _control_flow ){


                if( state == Swithcing_program_transition_state.nothing )
                    { return; }

                if( watch.ElapsedMilliseconds > max_time_to_transition_ms[ ( int ) new_mode.type ] )    
                    { CONTROLLER__errors.Throw( $"Time exceeded in program_transition, time: { ( float )watch.ElapsedMilliseconds / 1_000f } seconds" ); }

                
                // --- NEED TO BE BEFORE
                _control_flow.Set_UI( ( transition.stage_to_liberate_UI <= transition.stage ) );
                _control_flow.Block_program_mode_update();
                
                switch( transition.stage ){

                    
                    case Transition_stage.up   : Handle_UP( _control_flow ); break;
                    case Transition_stage.mid  : handle_MID( _control_flow ); break;
                    case Transition_stage.down : Handle_DOWN( _control_flow ); break;
                    case Transition_stage.mode_set : Handle_MODE_SET( _control_flow ); break;
                    case Transition_stage.mode_start : Handle_MODE_START( _control_flow ); return; // ** nao deixa ir, vai dar erro
                    default: CONTROLLER__errors.Throw( $"In Program_transition the type was <Color=lightBlue>{ transition.stage }</Color>" ); break;

                }
                    
        }



        public void Switch_program_mode(  Program_mode _new_mode, Transition_data _mode_transition ){


                Program program = Controllers_program.program;

                // --- VERIFICATIONS

                    if( program.control_flow.program_mode_update_blocked )
                        { CONTROLLER__errors.Throw( $"Tried to switch to program mode <Color=lightBlue>{ _new_mode }</Color> but the program update is blocked. the only thing that can call Switch_program_mode() is another mode" ); }

                    if( state == Swithcing_program_transition_state.switching )
                        { CONTROLLER__errors.Throw( $"Tried to go to the mode <Color=lightBlue>{ state }</Color> but the controller is already swithing from <Color=lightBlue>{ old_mode.type }</Color> to <Color=lightBlue>{ new_mode.type }</Color>" ); }

                    if( program.current_mode == _new_mode )
                        { CONTROLLER__errors.Throw( $"Is in mode <Color=lightBlue>{ program.current_mode }</Color>, but is trying to go to the same mode again" ); }

                // --- GET DATA
    
                    new_mode = program.modes[ ( int ) _new_mode ];
                    old_mode = program.modes[ ( int ) program.current_mode ];
                

                    new_mode.Construct();

                    Lock_program_data* lock_data = Program_data.Get_lock( _new_mode );

                    if( !!!( lock_data->put_data ) )
                        { CONTROLLER__errors.Throw( "Did not put data" ); }

                        transition = new_mode.Construct_transition( _mode_transition );

                    lock_data->put_data = false;

                    if( transition == null )
                        {  CONTROLLER__errors.Throw( $"The <Color=lightBlue>transition</Color> to the mode <Color=lightBlue>{ _new_mode }</Color> was null" ); }

                // --- SET STATES

                    state = Swithcing_program_transition_state.switching;
                    new_mode.state = Program_mode_state.swithing_to_active;
                    old_mode.state = Program_mode_state.swithing_to_inactive;

                // --- GET CAMERA DATA
                    transition.cameras_data = Controllers.cameras.Switch_cameras( _new_mode.ToString() );
                
                // --- START

                    Cast_actions_NO_REF( ref transition.sections_actions.preparation ); // ** começa a carregar os recursos
                    Pass_stage( ref transition.checks, transition.stage );
                    return;

        }




        // --- INTERN


        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        private void Pass_stage( ref Transition_checks[] _checks , Transition_stage _stage ){

                int index = ( int ) _stage;
                ref Transition_checks checks = ref _checks[ index ];

                if( !!!( checks.new_part ) )
                    { return; }
                if( !!!( checks.old_part ) )
                    { return; }
                if( !!!( checks.screen_part ) )
                    { return; }
                if( !!!( checks.UI_part ) )
                    { return; }
                    
                transition.Pass_stage();

        }




        private void Handle_UP( Control_flow _control_flow ){

                Cast_actions_REF( ref transition.sections_actions.up ); 
                Pass_stage( ref transition.checks, transition.stage );
                return; 

        }

        private void handle_MID( Control_flow _control_flow ){

                Cast_actions_REF( ref transition.sections_actions.mid );

                if( !!!( transition.resource_container_minimun_checker.End() ) )
                    { return; }

                if( ( transition.data_requisition?.finalizado != true ) && ( transition.data_requisition != null ) )
                    { return; }

                if( ( transition.resources_requisition?.finalizado != true ) && ( transition.resources_requisition != null ) )
                    { return; }
                
                if( !!!( TASK_REQ.Verify_all_finalized( transition.tasks, Task_req_handle_array_null._true ) ) )
                    { return; }

                
                // --- FORCE PASS
                transition.checks[ ( int ) Transition_stage.mid ].new_part = true;
                transition.checks[ ( int ) Transition_stage.mid ].old_part = true;
                transition.checks[ ( int ) Transition_stage.mid ].screen_part = true;
                transition.checks[ ( int ) Transition_stage.mid ].UI_part = true;
                transition.Pass_stage();

                return;

        }




        private void Handle_DOWN( Control_flow _control_flow ){

                Cast_actions_REF( ref transition.sections_actions.down );
                Pass_stage( ref transition.checks, transition.stage );
                
        }



        private void Handle_MODE_SET( Control_flow _control_flow ){ 

                Cast_actions_REF( ref transition.sections_actions.mode_set );
                _control_flow.Set_UI( transition.stage_to_liberate_UI <= transition.stage );
                _control_flow.Block_program_mode_update();
                Pass_stage( ref transition.checks, transition.stage );

        }



        private void Handle_MODE_START( Control_flow _control_flow ){

                Pass_stage( ref transition.checks, transition.stage );

            //** logic back

                Cast_actions_NO_REF( ref transition.sections_actions.mode_start );

                // --- OLD
                    old_mode.Clean_resources();
                    old_mode.Destroy();
                    old_mode.state = Program_mode_state.inactive;
                    old_mode = null;


                // --- NEW

                    Controllers_program.program.current_mode = new_mode.type;
                    new_mode.state = Program_mode_state.active;
                    new_mode = null;


                transition = null;
                watch.Reset();
                state = Swithcing_program_transition_state.nothing;


                _control_flow.Unblock_program_mode_update();
                _control_flow.Unblock_UI();
                Controllers.cameras.End_switch();


        }


    // ---- INTER


        private void Cast_actions_NO_REF( ref Transition_section_actions_WITH_NO_REF _sections ){

                //mark
                // essa parte faz sentido kinda mas ta estranha

                ref Transition_checks checks = ref transition.checks[ ( int ) transition.stage ];

                if( _sections.NEW != null )
                    { _sections.NEW(); }

                checks.new_part = true; 

                if( _sections.OLD != null )
                    { _sections.OLD(); }

                checks.old_part = true; 
                
                if( _sections.screen != null )
                    { _sections.screen(); }

                checks.screen_part = true; 

                if( _sections.UI != null )
                    { _sections.UI(); }

                checks.UI_part = true; 

        }

        private void Cast_actions_REF( ref Transition_section_actions_WITH_REF _sections ){

                ref Transition_checks checks = ref transition.checks[ ( int ) transition.stage ];

                if( _sections.NEW != null )
                    { _sections.NEW( transition ); }
                    else
                    { checks.new_part = true; }

                if( _sections.OLD != null )
                    { _sections.OLD( transition ); }
                    else
                    { checks.old_part = true; }
                
                if( _sections.screen != null )
                    { _sections.screen( transition ); }
                    else
                    { checks.screen_part = true; }

                if( _sections.UI != null )
                    { _sections.UI( transition ); }
                    else
                    { checks.UI_part = true; }

        }


}
