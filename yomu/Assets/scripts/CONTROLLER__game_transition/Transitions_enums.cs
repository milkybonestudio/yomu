


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



public enum Transition_section {

            screen,
            OLD,
            NEW,
            UI,

        END,

}


public struct Transition_sections_actions {

        public static Transition_sections_actions Construct(){

            Transition_sections_actions ret = default;

                ret.preparation = Default_fn;

                    ret.up = Default_fn;
                    ret.mid = Default_fn;
                    ret.mid_all_loaded = Default_fn;
                    ret.down = Default_fn;

                ret.mode_set = Default_fn;
                ret.mode_start = Default_fn;

            return ret;


        }

        public static bool Default_fn(){ return true; }

        public Transition_response preparation;
            
                public Transition_response up;
                public Transition_response mid;  // ** alguns podem ter animações que nao podem ser interrompidas 
                public Transition_response mid_all_loaded;  // ** alguns podem ter animações que nao podem ser interrompidas 
                public Transition_response down; 
                

        public Transition_response mode_set;

        public Transition_response mode_start;


} 


