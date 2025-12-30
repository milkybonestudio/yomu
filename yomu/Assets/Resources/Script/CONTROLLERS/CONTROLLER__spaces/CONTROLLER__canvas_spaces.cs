

using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;



public class CONTROLLER__canvas_spaces {

        public static CONTROLLER__canvas_spaces instance;
        public static CONTROLLER__canvas_spaces Get_instance(){ return instance; }



        // --- DO NOT CHANGE 
            
            public Stage_spaces stage;
            public Space_switcher current_switcher;



            public Screen_view current_screen_view;
            public Screen_view new_screen_view;
            public Screen_view transition_screen_view;

            // ->

            public int current;
            public Canvas_space canvas_space_1;
            public Canvas_space canvas_space_2;

            public Canvas_space canvas_space_current;
            public Canvas_space canvas_space_new;


            public Canvas_space canvas_space_transition;


            public Camera main_camera;



            // ** SYSTEM_UI
            public Camera system_UI_camera;
            public GameObject system_UI_camera_game_object; // ??


            public string current_camera_name =  "__not_give__";
            
            
            public void Update(){


                    if( stage == Stage_spaces.switching && current_switcher == null )
                        { CONTROLLER__errors.Throw( "The stage in controller_canvas_spaces is <Color=lightBlue>switching</Color> but the <Color=lightBlue>cameras_switching_data</Color> is null" ); }
                        
                    canvas_space_1.Update();
                    canvas_space_2.Update();
                    canvas_space_transition.Update();

                    if( ( canvas_space_current.state == Canvas_space_state.not_rendering ) && ( stage == Stage_spaces.normal )  )
                        { CONTROLLER__errors.Throw( "The current canvas space is not rendering" ); }
                    
            }



        public Space_switcher Switch_cameras( string _name_new_space ){

                
                // --- VERIFICATIONS DEFAULT

                if( stage == Stage_spaces.switching )
                    { CONTROLLER__errors.Throw( $"Tried to switch cameras, but the camera  <Color=lightBlue>{ canvas_space_new.name }</Color> is <Color=lightBlue>not finished</Color>" ); }

                if( ( ++current % 2 ) == 0 )
                    {
                        canvas_space_current = canvas_space_2;
                        canvas_space_new = canvas_space_1;

                    }
                    else
                    {
                        canvas_space_current = canvas_space_1;
                        canvas_space_new = canvas_space_2;

                    }

                    
                
                canvas_space_current.Change_screen_view( current_screen_view );
                canvas_space_new.Change_screen_view( new_screen_view );
                    
                current_switcher = Space_switcher.Construct( canvas_space_current, canvas_space_new, canvas_space_transition );

                // canvas_space_current.Show();
                // canvas_space_new.Show();
                
                // --- CAMERA OPERATORS

                current_camera_name = _name_new_space;
                canvas_space_new.name = _name_new_space;
                stage = Stage_spaces.switching;
            
                return current_switcher;
            
        }




        
        public void End_switch(){


                // --- VERIFICATIONS DEFAULT    

                if( stage != Stage_spaces.switching )
                    { CONTROLLER__errors.Throw( $"Tried to <Color=lightBlue>END</Color> switch cameras, but the current state is normal" ); }

                stage = Stage_spaces.normal;


                // ** LIMPA
                canvas_space_current.Free();
                canvas_space_transition.Free();

                // ** ESCONDE SCREENS
                new_screen_view.Hide();
                transition_screen_view.Hide();

                // ** TROCA PARA A SCREEN CERTA
                canvas_space_new.Change_screen_view( current_screen_view );
                
                // ** ARRUMA PARA REFERENCIAS
                canvas_space_current = canvas_space_new;


        }





        public Texture2D Screen_shot( string _path_to_save ){


                RenderTexture render_texture = new RenderTexture( Screen.width, Screen.height, 24 );
                
                
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

