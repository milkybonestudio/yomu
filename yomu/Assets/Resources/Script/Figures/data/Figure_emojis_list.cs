


public class Figure_emojis_list {


    public static int main_id = 0;
    public static Figure_emojis_list list;

    public static Figure_emoji_data Get( Figure_emoji _emoji ){ return list._Get( _emoji ); }


    public Figure_emoji_data _Get( Figure_emoji _emoji ){
    
        if( images == null )
            { images = CONTROLLER__resources.Get_instance().resources_images; }

        switch( _emoji ){

            case Figure_emoji.heart : return Heart();
            default: CONTROLLER__errors.Throw( $"Can not handle type { _emoji }" ); return new Figure_emoji_data();
        }

    }

    public MANAGER__resources_images images;


    public RESOURCE__image_ref[] heart_images;

    public Figure_emoji_data Heart(){


            Figure_emoji_data emoji = new Figure_emoji_data();

                emoji.move_type = Figure_emoji_movement.linear_out;
                emoji.speed_pixels_per_second = 50;
                emoji.frames_per_second = 2;

                if( heart_images == null )
                    { heart_images = images.Get_images_reference( Resource_context.Effects, "Figures", "Emojis/Heart", Resource_image_content.compress_low_quality_data, 4 ); }


                emoji.images_refs = heart_images;

            return emoji;

    }

}
