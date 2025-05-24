

public enum Device_state {

    not_give = 0b__0000_0000__0000_0000__0000_0000__0000_0000, 

        nothing = 0b__0000_0000__0000_0000__0000_0000__0000_0001,
        transition_nothing_TO_inactive = 0b__0000_0000__0000_0000__0000_0000__0000_0010,
        inactive = 0b__0000_0000__0000_0000__0000_0000__0000_0100,
        transition_inactive_TO_active = 0b__0000_0000__0000_0000__0000_0000__0000_1000,
        active = 0b__0000_0000__0000_0000__0000_0000__0001_0000, 
        transition_active_TO_inactive = 0b__0000_0000__0000_0000__0000_0000__0010_0000,
        transition_inactive_TO_nothing = 0b__0000_0000__0000_0000__0000_0000__0100_0000,

    END,

    acceptable_states_to_start = ( nothing | inactive | active ),

}
