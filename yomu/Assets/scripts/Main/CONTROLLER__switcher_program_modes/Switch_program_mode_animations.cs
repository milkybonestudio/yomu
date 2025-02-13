

public static class Switch_program_mode_animations {
    

        public static Switch_program_mode Get( Switch_program_mode_type _type ){

                switch( _type ){

                    case Switch_program_mode_type.instant: return new Switch_program_mode(){ type = Switch_program_mode_type.instant };
                    case Switch_program_mode_type.fade: return Create_fade();
                    case Switch_program_mode_type.black_to_normal: return Create_black_to_nomal();
                    default: CONTROLLER__errors.Throw( $"Tried to get the type <Color=lightBlue>{ _type }</Color>, but is not handle" ); return default;

                }

                

        }

        public static Switch_program_mode Create_fade(){

            Switch_program_mode an = new Switch_program_mode();

                an.type = Switch_program_mode_type.fade;
                an.time_ms = 200;

            return an;

        }


        public static Switch_program_mode Create_black_to_nomal(){

            Switch_program_mode an = new Switch_program_mode();

                an.type = Switch_program_mode_type.black_to_normal;
                an.time_up_ms = 200;
                an.time_down_ms = 200;

            return an;


        }

        public static Switch_program_mode Create_drapery(){

            Switch_program_mode an = new Switch_program_mode();

                an.type = Switch_program_mode_type.drapery;
                an.time_up_ms = 200;

                    an.container = new Resources_container();

                    MANAGER__resources_images images =  CONTROLLER__resources.Get_instance().resources_images;

                    an.images_dreapery = new RESOURCE__image_ref[ 20 ];

                    // an.images_dreapery[ 0 ] = images.Get_image_reference()
                    // an.container.Add()

                an.time_down_ms = 200;

            return an;


        }



}