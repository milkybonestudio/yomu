

public enum Resources_getting_image_stage {

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

}