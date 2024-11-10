

public enum Resources_getting_image_stage {


    not_give = 0b_0000_0000__0000_0000__0000_0000__0000_0000,

    // ** waiting to start start in the sequence of recources. Need to have nothing to be here
    waiting_to_start = 0b_0000_0000__0000_0000__0000_0000__0000_0001, // ** get webp
    
            getting_compress_low_quality_file = 0b_0000_0000__0000_0000__0000_0000__0000_0010,

            waiting_to_get_compress_file = 0b_0000_0000__0000_0000__0000_0000__0000_0100, // ** png

        getting_compress_file = 0b_0000_0000__0000_0000__0000_0000__0000_1000, // ** task req ativada 

            waiting_to_get_texture = 0b_0000_0000__0000_0000__0000_0000__0001_0000, 

        getting_texture = 0b_0000_0000__0000_0000__0000_0000__0010_0000, // ** 

            waiting_to_pass_data_to_texture = 0b_0000_0000__0000_0000__0000_0000__0100_0000,

        passing_data_to_texture = 0b_0000_0000__0000_0000__0000_0000__1000_0000,

            waiting_to_apply_texture = 0b_0000_0000__0000_0000__0000_0001__0000_0000,

        applying_texture = 0b_0000_0000__0000_0000__0000_0010__0000_0000, // ** vale a pena esperar varias textures colocarem os pixels na texture antes de dar o apply

            waiting_to_create_sprite = 0b_0000_0000__0000_0000__0000_0100__0000_0000, // main

    finished = 0b_0000_0000__0000_0000__0000_1000__0000_0000,


    // ** only down
        waiting_to_destroy_current_resource = 0b_0000_0000__0000_0000__0001_0000__0000_0000,

        //destroying_texture,


        




        nothing_acceptable_stages = ( Resources_getting_image_stage.finished | Resources_getting_image_stage.waiting_to_start ),

        compress_low_quality_data_acceptable_stages  =  ( 
                                                                Resources_getting_image_stage.finished 
                                                            | Resources_getting_image_stage.waiting_to_destroy_current_resource
                                                            | Resources_getting_image_stage.getting_compress_low_quality_file
                                                            | Resources_getting_image_stage.waiting_to_get_compress_file 
                                                        ),

        compress_data_acceptable_stages  =  ( 
                                                    Resources_getting_image_stage.finished 
                                                | Resources_getting_image_stage.waiting_to_destroy_current_resource
                                                // | Resources_getting_image_stage.getting_texture
                                                | Resources_getting_image_stage.waiting_to_get_texture
                                            ),



        texture_acceptable_stages = ( 
                                          Resources_getting_image_stage.waiting_to_destroy_current_resource
                                        | Resources_getting_image_stage.waiting_to_pass_data_to_texture
                                        | Resources_getting_image_stage.passing_data_to_texture
                                    ),


        texture_with_pixels_acceptable_stages = ( 
                                                        Resources_getting_image_stage.waiting_to_destroy_current_resource
                                                    | Resources_getting_image_stage.waiting_to_apply_texture
                                                    // | Resources_getting_image_stage.applying_texture
                                                ),


        texture_with_pixels_applied_acceptable_stages = ( 
                                                                Resources_getting_image_stage.waiting_to_destroy_current_resource
                                                            | Resources_getting_image_stage.waiting_to_create_sprite
                                                        ),

        sprite_acceptable_stages =  ( 
                                            Resources_getting_image_stage.waiting_to_destroy_current_resource
                                        | Resources_getting_image_stage.finished
                                    ),                                                    


                                    


        



}