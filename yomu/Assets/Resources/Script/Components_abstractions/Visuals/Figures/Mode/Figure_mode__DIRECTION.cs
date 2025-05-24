


public struct Figure_mode__DIRECTION {

        public static Figure_mode__DIRECTION Construct( FIGURE_MODE _mode, Figure_mode_direction _direction ){

            Figure_mode__DIRECTION mode_direction = default;

                mode_direction.mode = _mode;
                mode_direction.direction = _direction;
                mode_direction.main.images_links = new Image_link[ 20 ];
                mode_direction.index_link_atual = -1;
                

            return mode_direction;

        }


        public Dimensions_combined_images image_dimension;


        public FIGURE_MODE mode;



        // ** get data

        // ** main


        // ** mouth
            // public int pointer_mouth_data;
            
        // ** eyes
            // public int pointer_eyes_data;
            

        public bool activated;
        public Figure_mode_direction direction;

        public RESOURCE__structure_copy structure;

        public bool give_link;

        public int index_link_atual;

        public Figure_mode_main main;
        public Figure_mode_animation_SIMPLE mouth_animation;
        public Figure_mode_animation_SIMPLE eyes_animation;
        // public Figure_emojis emojis = Figure_emojis.Get(); // ** talvez nao precise sempre


        public void Link_image( ref Unity_main_components unity_components, RESOURCE__image_ref _resource_image ){

            index_link_atual++;

            main.images_links[ index_link_atual ] = new Image_link { 
                sprite_render = unity_components.sprite_render,
                game_object = unity_components.game_object,
                resource_ref = _resource_image
            };

            main.images_links[ index_link_atual  ].resource_ref.image.name = "FIGURE_IMAGE";
            main.images_links[ index_link_atual  ].sprite_render.material = mode.figure_interface.material;

        }


        public void Update(){

                
                if( !!!( activated ) )
                    { CONTROLLER__errors.Throw( $"Tried to update de direction <Color=lightBlue>{ direction }</Color>, but was not created in <Color=lightBlue>Define_directions()</Color>" ); }

                // Console.Log( "mouth activated: " + mouth_animation.active );
                mouth_animation.Update();
                eyes_animation.Update();

        }


            public void Blink( Blink_data _data ){

                if( eyes_animation.resources_images == null )
                    { return; } // --- DONT HAVE

                if( eyes_animation.number_loops != eyes_animation.current_loop )
                    { return; } // --- ja esta em um loop
                
                eyes_animation.current_loop = 0;
                eyes_animation.number_loops = _data.loops;


                return;

            }

            public void Speak( Speak_data _data ){

                if( _data.loops == 0 )
                    { _data.loops = 5; }
                
                if( mouth_animation.resources_images == null )
                    { Console.Log( "nao tem mouth animation" ); return; } // --- DONT HAVE
            
                mouth_animation.current_loop = 0;
                mouth_animation.number_loops = _data.loops;
                

                return;

            }






}

