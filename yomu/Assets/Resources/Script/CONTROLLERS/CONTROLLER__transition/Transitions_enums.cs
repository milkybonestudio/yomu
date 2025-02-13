


using System;

public enum Transition_stage {

    preparation,

        up,
        mid, 
        down,
         
    mode_set,
    mode_start,

    END,
    
}


public enum Transition_data_UI_position {

    _default, 
        old_plane, 
        new_plane,
        above,    

}

public enum Transition_data_cameras {

    OLD, 
    NEW,

}

public struct Transition_data_specific_UI_position { 

        public int UI_id;
        public Transition_data_UI_position position;

}

public enum Transition_section {

        screen,
        OLD,
        NEW,
        UI,

        END,

}



public struct Transition_checks {

    public bool screen_part;
    public bool old_part;
    public bool new_part;
    public bool UI_part;

}


public struct Transition_section_actions_WITH_REF {

        // ** if null ignor

        public Action<Transition> screen;
        public Action<Transition> OLD;
        public Action<Transition> NEW;
        public Action<Transition> UI;

}

public struct Transition_section_actions_WITH_NO_REF {

        // ** if null ignor

        public Action screen;
        public Action OLD;
        public Action NEW;
        public Action UI;

}

public struct Transition_sections_actions {

        public Transition_section_actions_WITH_NO_REF preparation;
            

                public Transition_section_actions_WITH_REF up;
                public Transition_section_actions_WITH_REF mid;  // ** alguns podem ter animações que nao podem ser interrompidas 
                public Transition_section_actions_WITH_REF down; 
                

        public Transition_section_actions_WITH_REF mode_set;

        public Transition_section_actions_WITH_NO_REF mode_start;


} 


