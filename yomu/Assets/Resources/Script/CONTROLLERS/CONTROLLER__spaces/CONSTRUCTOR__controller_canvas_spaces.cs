using UnityEngine;
using UnityEngine.UI;




public static class CONSTRUCTOR__controller_canvas_spaces {


        public static CONTROLLER__canvas_spaces Construct(){

                CONTROLLER__canvas_spaces controller = new CONTROLLER__canvas_spaces();
                CONTROLLER__canvas_spaces.instance = controller;


                        controller.stage = Stage_spaces.normal;

                    // --- SCREEN_VIEWS

                        controller.current_screen_view = Screen_view.Construct( "Screen/mode_mesh_render_1" );
                        controller.new_screen_view = Screen_view.Construct( "Screen/mode_mesh_render_2" );
                        controller.transition_screen_view = Screen_view.Construct( "Screen/mode_mesh_render_transition" );


                    // --- SPACES

                        controller.canvas_space_1 = Canvas_space.Construct( "Screen/mode_1" );
                        controller.canvas_space_2 = Canvas_space.Construct( "Screen/mode_2" );
                        controller.canvas_space_transition = Canvas_space.Construct( "Screen/mode_transition" );



                    // --- MAIN CAMERA

                        controller.main_camera = GameObject.Find( "Screen/Camera_main" ).GetComponent<Camera>();
                        
                    // --- SET FIRST

                        controller.canvas_space_current = controller.canvas_space_1;
                        controller.canvas_space_current.Change_screen_view( controller.current_screen_view );
                                            
                return controller;

        }

}