

using System;
using UnityEngine;


 // canvas_space -> canvas_region -> content/camera


public class Canvas_region {

        public static Canvas_region Construct( string _path ){

                // _path -> "a/b/c/UI" //  "a/b/c/Content"

                Canvas_region region = new Canvas_region();

                    region.camera = Camera_operator.Construct( _path );
                    region.world = World_operator.Construct( _path);

                return region;

        }

        public void Free(){

            world.Free();
            camera.Stop_render();

        }

        public Camera_operator camera;
        public World_operator world;


}

