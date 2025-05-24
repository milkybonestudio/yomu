using UnityEngine;



public struct MANAGER__resources_combined_images_render_textures {

        // ** pega um espaço no world para fazer as operaçoes

        public static MANAGER__resources_combined_images_render_textures Construct(){

            MANAGER__resources_combined_images_render_textures manager = default;
            return manager;

        }




        public RenderTexture Get_render_texture( Dimensions _dimensions ){

                if( _dimensions.width > width_space )
                    { { CONTROLLER__errors.Throw( $"Tried to get a textureRender but the width is <Color=lightBlue>{ _dimensions.width }</Color> " ); } }

                if( _dimensions.height > height_space )
                    { { CONTROLLER__errors.Throw( $"Tried to get a textureRender but the height is <Color=lightBlue>{ _dimensions.width }</Color> " ); } }

                current_ram_usage += ( bytes_per_pixel * _dimensions.width * _dimensions.height );

                if( current_ram_usage > limit_ram_usage )
                    { CONTROLLER__errors.Throw( $"Tried to get a textureRender but with the render the ram will be <Color=lightBlue>{ current_ram_usage }</Color> " ); }

                RenderTexture render_texture = new RenderTexture( _dimensions.width, _dimensions.height, 0, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Default );
                render_texture.filterMode = FilterMode.Point;
                render_texture.Create();

                return render_texture;

        }

        public void Delete_render_texture( RenderTexture _render_texture ){

            current_ram_usage -= ( _render_texture.width * _render_texture.height * bytes_per_pixel );

            GameObject.Destroy( _render_texture );

        }

        public const int bytes_per_pixel = 4;
        public int current_ram_usage;
        public const int limit_ram_usage = 1_000_000_000; // ** 1gb+-

        // ** controls max size
        public const int width_space = 4_000;
        public const int height_space = 4_000;



        public Dimensions_combined_images Calculate_dimensions( GameObject _game_object, Image_link[] _links ){


                float y_min  = 0;
                float y_max  = 0;
                float x_min  = 0;
                float x_max =  0;

                for( int slot = 0 ; slot < _links.Length ; slot++ ){

                        Image_link link = _links[ slot ];

                        if( link.game_object == null )
                            { break; }

                        float half_width_sprite = link.resource_ref.image.width_float / 2 ;
                        float half_height_sprite = link.resource_ref.image.height_float / 2;

                            
                        Vector3 position_image = link.game_object.transform.localPosition;

                        float position_x = ( position_image.x * 100f );
                        float position_y = ( position_image.y * 100f );
                        

                        // ** Y 
                        if( y_min > ( position_y - half_height_sprite ) )
                            { y_min = ( position_y - half_height_sprite ); }

                        if( y_max < ( position_y + half_height_sprite ) )
                            { y_max = ( position_y + half_height_sprite ); }

                        // ** X
                        if( x_min > ( position_x - half_width_sprite ) )
                            { x_min = ( position_x - half_width_sprite ); }

                        if( x_max < ( position_x + half_width_sprite ) )
                            { x_max = ( position_x + half_width_sprite ); }

                    
                }


                int width = ( int )( x_max - x_min );
                int height = ( int )( y_max - y_min );


                return new(){
                    width = width, 
                    height = height,
                    off_set_width = ( ( x_max + x_min ) / 2 ),
                    off_set_height = ( ( y_max + y_min ) / 2 )
                };



        }




        
}