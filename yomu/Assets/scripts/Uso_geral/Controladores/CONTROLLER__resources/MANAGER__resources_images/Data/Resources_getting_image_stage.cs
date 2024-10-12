

public enum Resources_getting_image_stage {

    waiting_to_start,

        getting_compress_low_quality_file, // ** webp

            waiting_to_get_compress_file, // ** png

        getting_compress_file, // ** task req ativada 

            waiting_to_get_texture, 

        getting_texture, // ** 

            waiting_to_pass_data_to_texture,

        passing_to_texture,

            waiting_to_apply_texture,

        applying_texture, // ** vale a pena esperar varias textures colocarem os pixels na texture antes de dar o apply

            waiting_to_create_sprite, // main



    finished,

}