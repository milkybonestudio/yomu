using System;
using UnityEngine;


// ** tem como parar a camera com camera.enabled e dar render manual com camera.Render()
// ** mas a diferença é quase nada
// ** e 60fps no manual é muiuto mais optimizado

public class Camera_operator {

        public static Camera_operator Construct( string _path ){

                Camera_operator camera = new Camera_operator();

                    camera.camera_container_game_object = GameObject.Find( ( _path + "/Camera_container" ) );
                    camera.camera_game_object = GameObject.Find( ( _path + "/Camera_container/Camera" ) );
                    camera.camera = camera.camera_game_object.GetComponent<Camera>();
                    camera.camera_enabled = true;

                return camera;

        }



        public GameObject camera_container_game_object; // ** objeto que a camera esta
        public GameObject camera_game_object; // ** camera de fato
        public Camera camera;
        private bool camera_enabled;

        public Camera_state state = Camera_state.hide;



        public void Change_target( Screen_view _screen ){

            camera.targetTexture = _screen.render_texture;

        }



        public void Stop_render(){ 

                if(  !!!( camera_enabled ) )
                    { return; }

                camera_enabled = false;
                camera.enabled = false;
                    // camera_game_object.SetActive( false ); 
                state = Camera_state.hide;


        }


        public void Start_render(){ 

                if(  camera_enabled )
                    { return; }

                camera_enabled = true;
                camera.enabled = true;
            
            
                state = Camera_state.activated;

                

        }




}
