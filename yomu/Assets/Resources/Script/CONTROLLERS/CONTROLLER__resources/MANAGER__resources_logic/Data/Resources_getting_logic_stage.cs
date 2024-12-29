

public enum Resources_getting_logic_stage {
    


    // ** UP

            not_give = 0b_0000_0000__0000_0000__0000_0000__0000_0000,

            waiting_to_start = 0b_0000_0000__0000_0000__0000_0000__0000_0001,

            finished = 0b_0000_0000__0000_0000__0000_1000__0000_0000,


    // ** DOWN
        
    // ** REAJUST


    nothing_acceptable_stages = (
                                        Resources_getting_logic_stage.waiting_to_start
                                    |   Resources_getting_logic_stage.finished

                                ),


    method_acceptable_stages =  (
                                        Resources_getting_logic_stage.finished
                                ),




        



}