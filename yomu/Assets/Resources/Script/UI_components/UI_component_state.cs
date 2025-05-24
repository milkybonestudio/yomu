
public enum UI_component_state {

    not_give, 

        transition,

        pass = 1,


        nothing = 0b_0000_0000__0000_0000__0000_0000__0000_0010,
        transition_nothing_TO_inactive = 0b_0000_0000__0000_0000__0000_0000__0000_0100,
        inactive = 0b_0000_0000__0000_0000__0000_0000__0000_1000,
        transition_inactive_TO_active = 0b_0000_0000__0000_0000__0000_0000__0001_0000,
        active = 0b_0000_0000__0000_0000__0000_0000__0010_0000,
        transition_active_TO_inactive = 0b_0000_0000__0000_0000__0000_0000__0100_0000,

        transition_inactive_TO_nothing = 0b_0000_0000__0000_0000__0000_0000__1000_0000,

        states_to_force = ( nothing | inactive | active ), 


    END

}

