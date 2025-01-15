using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;







public class MANAGER__resources_combined_images : MANAGER__RESOURCES {

        public MANAGER__resources_combined_images(){

            camera_renders_container = GameObject.Find( "Containers/Camera_renders" );

        }



        public RESOURCE__combined_image Get_combined_image( GameObject _game_object, Image_link[] _links ){ 

                // ** assume que as imagens já foram carregadas
                RESOURCE__combined_image image = new RESOURCE__combined_image();

                image.images_game_object = _game_object;
                image.links = _links;

                image.render = Create_render( _game_object, _links );


                return image;

        }


        private Combined_image_render Create_render( GameObject _game_object, Image_link[] _links ){

                
                int line = -1;
                int collum = -1;

                for( int line_slot = 0 ; line_slot < spaces.GetLength( 0 ) ; line_slot++ ){

                        for( int collum_slot = 0 ; collum_slot < spaces.GetLength( 1 ) ; collum_slot++ ){

                            if( spaces[ line_slot, collum_slot ] )
                                { continue; }

                            line = line_slot;
                            collum = collum_slot;
                            break;

                        }

                }

                if( line + collum < 0 )
                    { CONTROLLER__errors.Throw( "There is no slot available..? how tha fk I write this" ); }

                int width = line * width_space;
                int height = collum * height_space;

                GameObject camera_game_object = new GameObject( $"Camera { width }/{ height }" );
                Camera camera = camera_game_object.AddComponent<Camera>();

                camera.orthographic = true;

                Vector3 position = new Vector3( width, height, 0f );

                camera_game_object.transform.SetParent( camera_renders_container.transform, false );
                camera_game_object.transform.localPosition = position;
                camera_game_object.transform.localRotation *= Quaternion.Euler( 0f, 0f, 0f );

                _game_object.transform.SetParent( camera_renders_container.transform, false );
                _game_object.transform.localPosition = position + new Vector3( 0f, 0f, 10f );


                Combined_image_render render = new Combined_image_render( _game_object, _links, camera, camera_game_object,  line, collum );

                return render;
                

            

        }


        public GameObject camera_renders_container;


        // --- UPDATE

        private const int weight_to_stop = 5;
        private int context_frame;
        public override void Update(){}

        // ** controls max size
        public const int width_space = 2_000;
        public const int height_space = 2_000;

        public bool[,] spaces = new bool[ 25, 25 ];
        public Combined_image_render[] renders;





        // --- EXTRA

        public override int Get_bytes_allocated(){

                int accumulator = 0;
                return accumulator;
            
        }

}
