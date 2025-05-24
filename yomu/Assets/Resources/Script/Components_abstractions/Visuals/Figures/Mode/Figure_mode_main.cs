
public struct Figure_mode_main {

        public static Figure_mode_main Construct( int _images_links_length, int _resources_length ){

            Figure_mode_main mode_main = default;

                mode_main.images_links = new Image_link[ _images_links_length ];
                
            return mode_main;

        }

        public int start_pointer_data;
        public int final_pointer_data;
        
        public Image_link[] images_links;


        public void Put_sprites(){

            for( int slot = 0; slot < images_links.Length ; slot++ ){

                if( images_links[ slot ].sprite_render == null )
                    { break; } // ** no more images

                images_links[ slot ].sprite_render.sprite = images_links[ slot ].resource_ref.Get_sprite();

            }

        }

}
