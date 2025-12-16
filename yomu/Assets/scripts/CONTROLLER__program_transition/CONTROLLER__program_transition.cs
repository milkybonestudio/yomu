


using System;
using System.Runtime.CompilerServices;


/*

    ** HOW TO TRANSITION:

        2 things are necessary: 

            PROGRAM_MODE__thing* thing = Program_mode.Lock_data__THING(); 
            controller_program_transition.Switch( thing, data_transtion );

        Lock_data__THING ensure that will be a transition to THING and no other parte of the code can ask for a transition
        also ensures that where it asks for it gets the right data. if the lock is for the mode X the only switch acceptable is for the X 
        if in a part it chenges the value of Y by mistake it will give a run time error


*/


unsafe public class CONTROLLER__program_transition {


    public static CONTROLLER__program_transition Get_instance(){ return instance; }
    public static CONTROLLER__program_transition instance;


    public Swithcing_program_transition_state state;
    public Transition_program transition;

        // ** used only in transition for reference
        private PROGRAM_MODE current_mode;
        private PROGRAM_MODE new_mode;

    
    // --- PROTECTION

    public System.Diagnostics.Stopwatch watch;
    public long[] max_time_to_transition_ms;

    public void Update( Control_flow _control_flow ){


        if( state == Swithcing_program_transition_state.nothing )
            { return; }

        if( watch.ElapsedMilliseconds > max_time_to_transition_ms[ ( int ) new_mode.type ] )    
            { CONTROLLER__errors.Throw( $"Time exceeded in program_transition to <Color=lightBlue>{ new_mode.type }</Color>, time: <Color=lightBlue>{ ( long )(( float )watch.ElapsedMilliseconds / 1_000f) }</Color> seconds" ); }

        switch( transition.stage ){

            case Transition_stage.up   : Handle_UP( _control_flow ); break;
            case Transition_stage.mid  : handle_MID( _control_flow ); break;
            case Transition_stage.down : Handle_DOWN( _control_flow ); break;
            case Transition_stage.mode_set : Handle_MODE_SET( _control_flow ); break;
            case Transition_stage.mode_start : Handle_MODE_START( _control_flow ); break; 
            default: CONTROLLER__errors.Throw( $"In Program_transition the type was <Color=lightBlue>{ transition.stage }</Color>" ); break;

        }
                
    }


    public void Switch_program_mode(  Program_mode _new_mode, Transition_program_data _mode_transition ){
        
        Console.Log( "vai para: " + _new_mode );

        Program program = Controllers_program.program;

        // --- VERIFICATIONS

            if( program.control_flow.program_mode_update_blocked )
                { CONTROLLER__errors.Throw( $"Tried to switch to program mode <Color=lightBlue>{ _new_mode }</Color> but the program update is blocked. the only thing that can call Switch_program_mode() is another mode" ); }

            if( state == Swithcing_program_transition_state.switching )
                { CONTROLLER__errors.Throw( $"Tried to go to the mode <Color=lightBlue>{ state }</Color> but the controller is already swithing from <Color=lightBlue>{ current_mode.type }</Color> to <Color=lightBlue>{ new_mode.type }</Color>" ); }

            if( program.current_mode == _new_mode )
                { CONTROLLER__errors.Throw( $"Is in mode <Color=lightBlue>{ program.current_mode }</Color>, but is trying to go to the same mode again" ); }

        // --- GET DATA

            new_mode = program.modes[ _new_mode ];
            current_mode = program.modes[ program.current_mode ];
        
            new_mode.Construct();

            
            //mark
            // ** removi
            // Controllers_program.data.modes.Verify_lock_data( _new_mode );
            transition = new_mode.Construct_transition( _mode_transition );
            

            
            if( transition == null )
                {  CONTROLLER__errors.Throw( $"The <Color=lightBlue>transition</Color> to the mode <Color=lightBlue>{ _new_mode }</Color> was null" ); }

        // --- SET STATES

            state = Swithcing_program_transition_state.switching;
            // new_mode.state = Program_mode_state.swithing_to_active;
            // current_mode.state = Program_mode_state.swithing_to_inactive;

        // --- GET CAMERA DATA
            transition.space_switcher = Controllers_program.canvas_spaces.Switch_cameras( _new_mode.ToString() );
        
        // --- START

            transition.sections_actions.preparation();
            transition.resource_container_checker?.Load_all_resources();
            transition.Pass_stage();

            watch.Start();
            return;

    }



    // --- INTERN


    private void Handle_UP( Control_flow _control_flow ){

            if( transition.sections_actions.up() )
                { transition.Pass_stage();}
            return; 

    }

    private void handle_MID( Control_flow _control_flow ){

        transition.sections_actions.mid();
        
        if( ( transition.resource_container_checker != null ) && !!!( transition.resource_container_checker.All_resources_loaded() ) )
            { return; }
        
        if( !!!( TASK_REQ.Verify_all_finalized( transition.tasks, Task_req_handle_array_null._true ) ) )
            { return; }

        if(  transition.sections_actions.mid_all_loaded() )
            { transition.Pass_stage(); }

        return;

    }


    private void Handle_DOWN( Control_flow _control_flow ){

        if( transition.sections_actions.down() )
            { transition.Pass_stage(); return; }

        transition.sections_actions.down();
        return; 
            
    }



    private void Handle_MODE_SET( Control_flow _control_flow ){ 


            if( transition.sections_actions.mode_set() )
                { transition.Pass_stage(); }
            
            _control_flow.Set_UI( transition.stage_to_liberate_UI <= transition.stage );
            _control_flow.Block_program_mode_update();

            return;

    }



    private void Handle_MODE_START( Control_flow _control_flow ){
        
        //** logic back

        transition.sections_actions.mode_start();

        // --- OLD
            current_mode.Clean_resources();
            current_mode.Destroy();
            current_mode = null;


        // --- NEW

            Controllers_program.program.current_mode = new_mode.type;
            new_mode = null;


        transition = null;
        watch.Reset();
        state = Swithcing_program_transition_state.nothing;


        _control_flow.Unblock_program_mode_update();
        _control_flow.Unblock_UI();
        Controllers_program.canvas_spaces.End_switch();
        // Controllers_program.data.modes.Unlock_data();


    }


}
