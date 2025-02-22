using UnityEngine;
using UnityEngine.UI;




public static class CONSTRUCTOR__controller_cameras {


        public static CONTROLLER__cameras Construct(){

                CONTROLLER__cameras controller = new CONTROLLER__cameras();
                CONTROLLER__cameras.instance = controller;


                        controller.cameras_switching_data = new Cameras_switching_data();

                    
                    // --- DO NOT CHANGE 
                            
                        controller.main_camera_game_object = GameObject.Find( "Screen/Camera_main" );
                        controller.main_camera_game_object.SetActive( true );
                        controller.main_camera = controller.main_camera_game_object.transform.GetChild( 0 ).gameObject.GetComponent<Camera>();

                        // ** somente de sistema, so liga quando usar
                        controller.system_UI_camera_game_object = GameObject.Find( "Screen/System_UI/Camera_main_UI" );
                        controller.system_UI_camera = controller.system_UI_camera_game_object.transform.GetChild( 0 ).gameObject.GetComponent<Camera>();


                    // --- MODES

                        // mesh -> material -> render_texture

                        // ** MAIN
                            controller.mode_main_operator = new Camera_operator( "Mode_main", "Screen/mode_main", "Screen/mode_main_mesh_render" );
                                controller.mode_main_operator.Start_render();
                                controller.mode_main_operator.Update();
                                
                            controller.mode_transition_operator = new Camera_operator( "Mode_transition", "Screen/mode_transition", "Screen/mode_transition_mesh_render" );
                                controller.mode_transition_operator.Stop_render();
                                controller.mode_transition_operator.Update();

                            controller.mode_transition_UI_operator = new Camera_operator( "Mode_transition_UI", "Screen/mode_transition_UI", "Screen/mode_transition_UI_mesh_render" );
                                controller.mode_transition_UI_operator.Stop_render();
                                controller.mode_transition_UI_operator.Update();


                    
                return controller;

        }

}