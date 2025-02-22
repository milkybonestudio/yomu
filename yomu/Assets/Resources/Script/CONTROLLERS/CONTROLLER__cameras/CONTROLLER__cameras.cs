

using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;




public class CONTROLLER__cameras {

        public static CONTROLLER__cameras instance;
        public static CONTROLLER__cameras Get_instance(){ return instance; }



        public Stage_camera stage = Stage_camera.normal;

        // --- DO NOT CHANGE 
            
            public Cameras_switching_data cameras_switching_data;

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

            public string current_camera_name =  "__not_give__";
            
        
        public void Update( Control_flow _control_flow ){


                if( Input.GetKeyDown( KeyCode.Alpha1 ) )
                    { Switch_cameras( "teste" ); End_switch(); }


                if( Input.GetKeyDown( KeyCode.Alpha2 ) )
                    { Switch_cameras( "teste_2" ); End_switch(); }

                mode_main_operator.Update();
                mode_transition_operator.Update();
                mode_transition_UI_operator.Update();

        }



        public Cameras_switching_data Switch_cameras( string _name ){

                
                
                // --- VERIFICATIONS DEFAULT

                    if( stage == Stage_camera.switching )
                        { CONTROLLER__errors.Throw( $"Tried to switch cameras, but the camera  <Color=lightBlue>{ mode_transition_operator.name }</Color> is <Color=lightBlue>not finished</Color>" ); }


                // --- CAMERA OPERATORS

                current_camera_name = _name;
                stage = Stage_camera.switching;
                mode_transition_operator.Start_render();
                mode_transition_UI_operator.Start_render();

                
                    // --- GET UI CONTAINERS
                    cameras_switching_data.UI_above = mode_transition_UI_operator.container_unique_UI;
                    cameras_switching_data.unique_UI_container_main = mode_main_operator.container_unique_UI;
                    cameras_switching_data.unique_UI_container_transition = mode_transition_operator.container_unique_UI;

                    // --- GET MATERIAL
                    cameras_switching_data.material_mode_main = mode_main_operator.mesh_render_material;
                    cameras_switching_data.material_mode_transition = mode_transition_operator.mesh_render_material;

                    // --- GET WORLD CONTAINERS
                    cameras_switching_data.main_world_container = mode_main_operator.container;
                    cameras_switching_data.transition_world_container = mode_transition_operator.container;

                
                return cameras_switching_data;
            
        }




        
        public void End_switch(){

                /*

                        antes do end os 3 renders vão estar ativos
                        quem tem o switching vai dar o End()
                        quando o end for dado as unicas coisas que vão sobrar na tela vao ser o "transition" que vai ser renomeado para "main"
                        o resto vai ser deletado.

                        controlador camera vai ser o mais simples possivel, se algo estiver no plano que não deveria, vai ser deletado e vai dar erro
                        ele não vai guardar Device[] ou algo do genero
                        qualquer tipo de logica tem que ser feita em blocos superiores
                        
                */



                // --- VERIFICATIONS DEFAULT    

                if( stage != Stage_camera.switching )
                    { CONTROLLER__errors.Throw( $"Tried to <Color=lightBlue>END</Color> switch cameras, but the camera { mode_transition_operator.name } is normal" ); }

                mode_main_operator.Stop_render();
                mode_main_operator.Reset_material();
                mode_main_operator.Destroy_structures_to_container();

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





        public Texture2D Screen_shot( string _path_to_save ){


                RenderTexture render_texture = new RenderTexture(Screen.width, Screen.height, 24 );
                
                
                main_camera.targetTexture = render_texture;
                main_camera.Render();

                Texture2D screen_shot = new Texture2D( render_texture.width, render_texture.height, TextureFormat.RGB24, false);

                
                RenderTexture.active = render_texture;
                screen_shot.ReadPixels(new Rect(0, 0, render_texture.width, render_texture.height), 0, 0);
                screen_shot.Apply();

                // Reset the RenderTexture and camera settings
                main_camera.targetTexture = null;
                RenderTexture.active = null;
                GameObject.Destroy( render_texture );

                return screen_shot;




        }


        



}