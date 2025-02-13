

using System.Collections.Generic;
using UnityEngine;

// ** conteiner que vai ser entregue para o controlador_UI 
public struct Switching_cameras_data {


    // --- GIVE TO THE CONTROLLER UI
    public GameObject unique_UI_container_main;
    public GameObject unique_UI_container_transition;
    public GameObject UI_above;

    public GameObject main_world_container;
    public GameObject transition_world_container;

    // --- GIVE TO THE CONTROLLER TRANSITION 
    public Material material_mode_main;
    public Material material_mode_transition;

}


public class CONTROLLER__cameras {

        public static CONTROLLER__cameras instance;
        public static CONTROLLER__cameras Get_instance(){ return instance; }


        public Stage_camera stage = Stage_camera.normal;

        // --- DO NOT CHANGE 
            
            // ** 
            public Camera main_camera;
            public GameObject main_camera_game_object;


            // ** SYSTEM_UI
            public Camera system_UI_camera;
            public GameObject system_UI_camera_game_object;


        // --- MAIN MODE
            public Camera_operator mode_main_operator;
            public Camera_operator mode_transition_operator;
            public Camera_operator mode_transition_UI_operator;

            public string current_camera_name =  "";
            
        
        public void Update( Control_flow _control_flow ){

            // if( stage == Stage_camera.switching )
            //     { /* precisa bloquear o update */ }

            // if( Input.GetKeyDown( KeyCode.Alpha1 ) )
            //     { Switch_cameras( "teste" ); End_switch(); }


            // if( Input.GetKeyDown( KeyCode.Alpha2 ) )
            //     { Switch_cameras( "teste_2" ); End_switch(); }

            mode_main_operator.Update();
            mode_transition_operator.Update();
            mode_transition_UI_operator.Update();



        }



        public Switching_cameras_data Switch_cameras( string _name ){

                
                // --- VERIFICATIONS DEFAULT

                    if( stage == Stage_camera.switching )
                        { CONTROLLER__errors.Throw( $"Tried to switch cameras, but the camera  <Color=lightBlue>{ mode_transition_operator.name }</Color> is <Color=lightBlue>not finished</Color>" ); }


                // --- CAMERA OPERATORS

                current_camera_name = _name;
                stage = Stage_camera.switching;
                mode_transition_operator.Start_render();
                mode_transition_UI_operator.Start_render();

                Switching_cameras_data containers = default;

                    // --- GET UI CONTAINERS
                    containers.UI_above = mode_transition_UI_operator.container_unique_UI;
                    containers.unique_UI_container_main = mode_main_operator.container_unique_UI;
                    containers.unique_UI_container_transition = mode_transition_operator.container_unique_UI;

                    // --- GET MATERIAL
                    containers.material_mode_main = mode_main_operator.mesh_render_material;
                    containers.material_mode_transition = mode_transition_operator.mesh_render_material;

                    // --- GET WORLD CONTAINERS
                    containers.main_world_container = mode_main_operator.container;
                    containers.transition_world_container = mode_transition_operator.container;

                
                return containers;
            
        }


        


        public void End_switch(){


                // --- VERIFICATIONS DEFAULT    

                if( stage != Stage_camera.switching )
                    { CONTROLLER__errors.Throw( $"Tried to <Color=lightBlue>END</Color> switch cameras, but the camera { mode_transition_operator.name } is normal" ); }

                mode_main_operator.Stop_render();
                mode_main_operator.Reset_material();
                mode_main_operator.Move_structures_to_container();

                mode_transition_UI_operator.Stop_render();



                //mark
                // ** passar as uis para o shared 


                // --- CHANGE POSITION

                    Vector3 position_1 = mode_main_operator.mesh_render_game_object.transform.localPosition;
                    Vector3 position_2 = mode_transition_operator.mesh_render_game_object.transform.localPosition;

                    mode_main_operator.mesh_render_game_object.transform.localPosition = position_2;
                    mode_transition_operator.mesh_render_game_object.transform.localPosition = position_1;

                // --- SWITCH OPERATORS
                
                    Camera_operator new_mode_main_operator = mode_transition_operator;
                    Camera_operator new_mode_transition_operator = mode_main_operator;

                    mode_main_operator = new_mode_main_operator;
                    mode_transition_operator = new_mode_transition_operator;

                
                stage = Stage_camera.normal;

        }


        private void Change_position_cameras( Camera_operator _operator_1, Camera_operator _operator_2 ){



        }




}