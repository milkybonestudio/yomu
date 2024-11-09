

public enum Resources_getting_image_stage {

    not_give,

    // ** waiting to start start in the sequence of recources. Need to have nothing to be here
    waiting_to_start, // ** get webp
    
            getting_compress_low_quality_file,

            waiting_to_get_compress_file, // ** png

        getting_compress_file, // ** task req ativada 

            waiting_to_get_texture, 

        getting_texture, // ** 

            waiting_to_pass_data_to_texture,

        passing_data_to_texture,

            waiting_to_apply_texture,

        applying_texture, // ** vale a pena esperar varias textures colocarem os pixels na texture antes de dar o apply

            waiting_to_create_sprite, // main

    finished,


    // ** only down
        waiting_to_destroy_current_resource,

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