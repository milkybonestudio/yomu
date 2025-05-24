


public struct Device_state__TRANSITIONS {

    public static Device_state__TRANSITIONS Construct(){

        Device_state__TRANSITIONS transitions = default;

            Transition default_transition = Transition.Construct();

                transitions.nothing__TO__inactive = default_transition;
                transitions.inactive__TO__active = default_transition;
                transitions.active__TO__inactive = default_transition;
                transitions.inactive__TO__nothing = default_transition;

        return transitions;



    }

    
    public Transition nothing__TO__inactive;
    public Transition inactive__TO__active;
    public Transition active__TO__inactive;
    public Transition inactive__TO__nothing;
    
}
