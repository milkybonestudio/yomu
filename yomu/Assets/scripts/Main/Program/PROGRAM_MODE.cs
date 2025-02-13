




unsafe public abstract class PROGRAM_MODE {

        

        public Program_mode type;
        public Program program = Program.instancia;
        public Program_mode_state state = Program_mode_state.inactive;

            // ** nao faz sentido colocar como obrigação de cada mode ter uma struct propria
            // ** internamente eles vão ter, mas então cada modo fica responsavel por colcoar ele na camera
            
            public abstract void Update( Control_flow _control_flow );
            public abstract Transition Construct_transition( Transition_data _data );
            
            public abstract void Clean_resources();
            // public abstract void End(); // ** need to destroy de object

            // ** used only in the main interface
            public abstract void Construct();

            // ** need in the main interface and the object_interface
            public abstract void Destroy();
            // public abstract void Destroy( Data _data ){ CONTROLLER__errors.Throw( "Came in Destroy, need to override" ) ;}
            

}


public abstract class DATA_POGRAM_MODE {

    public DATA_POGRAM_MODE( Program_mode _mode ){ mode = _mode; }
    public Program_mode mode;

}


public class Program_modes_static_data {



}


public enum Login_type {

    _default,

}


public abstract class Program_mode_transition_visual {

        
        // ** all the data is put in one task req, can be multiples parts to show progressions
        public Task_req data_requisition;
        public Task_req resources_requisition;
        public Task_req[] tasks;

        public Switching_cameras_data cameras_data;

        public Program_transition_state state;

        public abstract void Start_transition();
        public abstract Program_mode_transition_UP_return Up();
        public abstract void Mid_loop(); // ** ends with all the data getted(?)
        public abstract Program_mode_transition_DOWN_return Down();


}


public abstract class Program_mode_transition_logic {

        
        // ** all the data is put in one task req, can be multiples parts to show progressions
        public Task_req data_requisition;
        public Task_req resources_requisition;
        public Task_req[] tasks;

        public Switching_cameras_data cameras_data;

        public Program_transition_state state;

        public abstract void Start_transition();
        public abstract Program_mode_transition_UP_return Up();
        public abstract void Mid_loop(); // ** ends with all the data getted(?)
        public abstract Program_mode_transition_DOWN_return Down();


}


// public enum Program_mode_switch_options {

//     can_switch,
//     can_not_switch,

// }



public enum Program_mode_state{

    not_give, 

        inactive, 
        swithing_to_active,
        swithing_to_inactive,
        active,

}


public struct Program_mode_transition_DOWN_return {

    public bool finished;
    public bool can_execute_mode;

}



public struct Program_mode_transition_UP_return {

    public bool finished;
    public bool can_execute_mode;

}

public enum Program_transition_state {

    not_give,
        up, 
        mid,
        down,
        finished,

}

