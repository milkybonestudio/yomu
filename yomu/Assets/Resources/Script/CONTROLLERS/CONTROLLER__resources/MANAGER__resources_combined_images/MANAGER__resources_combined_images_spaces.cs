


using UnityEngine;



public struct MANAGER__resources_combined_images_spaces {

        // ** pega um espaço no world para fazer as operaçoes

        public static MANAGER__resources_combined_images_spaces Construct(){

            MANAGER__resources_combined_images_spaces manager = default;
            
                manager.spaces = new bool[ 25, 25 ];
                manager.camera_renders_containers = GameObject.Find( "Containers/Camera_renders" );

            return manager;

        }

        public Camera_space_combined_images_key Get_space_key(){

                int line = -1;
                int collum = -1;

                for( int line_slot = 0 ; line_slot < spaces.GetLength( 0 ) ; line_slot++ ){

                        for( int collum_slot = 0 ; collum_slot < spaces.GetLength( 1 ) ; collum_slot++ ){

                            if( spaces[ line_slot, collum_slot ] )
                                { continue; }

                            spaces[ line_slot, collum_slot ] = true;
                            line = line_slot;
                            collum = collum_slot;
                            break;

                        }

                }

                return new(){
                    horizontal = line, 
                    vertical = collum,
                };

        }


        public void Free_space( Camera_space_combined_images_key _key ){

                if( !!!( spaces[ _key.horizontal, _key.vertical ] ) )
                    { CONTROLLER__errors.Throw( $"Tried to free a space that was already free" ); }

                spaces[ _key.horizontal, _key.vertical ] = false;

        }

        public Camera_space_combined_images_setting Get_camera_setting( Camera_space_combined_images_key _key, Dimensions _dimensions ){


                int width = _key.horizontal * width_space;
                int height = _key.vertical * height_space;

                float world_width = ( ( float ) width * PPU.value_inverse );
                float world_height = ( ( float ) height * PPU.value_inverse );

                GameObject main = GAME_OBJECT.Criar_filho( $"container_{ width }/{ height }", camera_renders_containers );
                main.transform.localPosition = new Vector3( world_width, world_height, 0f );

                    GameObject camera_game_object = GAME_OBJECT.Criar_filho( "Camera", main );
                    Camera camera = camera_game_object.AddComponent<Camera>();

                        camera.orthographic = true;
                        camera.farClipPlane = 15f;
                        camera.orthographicSize = ( ( _dimensions.height * PPU.value_inverse ) / 2f );
                        camera_game_object.SetActive( false );

                    GameObject container_to_place = GAME_OBJECT.Criar_filho( "container_to_place", main ); 

                        container_to_place.transform.localPosition = new Vector3( 0, 0, 7f );


                return new(){

                    main_container = main, 
                    camera = camera, 
                    camera_game_object = camera_game_object,
                    current_camera_game_object_set_active = false,
                    container_to_place = container_to_place,

                };


        }


        


        public Camera_space_combined_images_output Get_output( Material _material, RenderTexture _render_texture, Camera_space_combined_images_setting _settings ){

                _settings.camera.targetTexture = _render_texture;

                GameObject container_quad = new GameObject( "Container_quad" );
                    container_quad.transform.SetParent( _settings.main_container.transform, false );
                    container_quad.transform.localPosition = new Vector3( 0, 0, -7f );


                GameObject quad_render = GameObject.Instantiate( Resources.Load<GameObject>( "Quad" ) );

                    quad_render.transform.SetParent( container_quad.transform, false );
                    MeshRenderer mesh_render = quad_render.GetComponent<MeshRenderer>();
                    mesh_render.material = _material;
                    mesh_render.material.SetTexture( "_MainTex", _render_texture );

                return new(){

                    quad_render = quad_render,
                    mesh_render = mesh_render,
                    render_texture = _render_texture,
                    container_quad = container_quad,
                    
                };
                


        }


        public GameObject camera_renders_containers;

        public const int Limit_spaces = 2_000;
        public const int Limit_ram_usage = 1_000_000_000; // ** 1gb+-

        // ** controls max size
        public const int width_space = 4_000;
        public const int height_space = 4_000;

        public bool[,] spaces;
        



}