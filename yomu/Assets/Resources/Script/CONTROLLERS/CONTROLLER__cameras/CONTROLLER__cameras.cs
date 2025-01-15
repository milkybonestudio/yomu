

using System.Collections.Generic;
using UnityEngine;


public enum Stage_camera {

    switching,
    normal,

}

public class CONTROLLER__cameras {

        public static CONTROLLER__cameras instance;
        public static CONTROLLER__cameras Get_instance(){ return instance; }

        // ** sempre mudar para a main
        public Camera screen_camera;
        public GameObject screen_camera_game_object;

        // ** ui do systema // esc
        public Camera screen_UI_camera;
        public GameObject screen_UI_camera_game_object;
        
        
        public Dictionary<string,Camera_operator> cameras = new Dictionary<string, Camera_operator>();

        public GameObject screen_game_object;
        public RenderTexture render_screen;
        public Material screen_material;

        public GameObject screen_transition_game_object;
        public RenderTexture render_screen_transition;
        public Material screen_transition_material;

        public Camera_operator current_camera;
        public Camera_operator new_camera;

        public Camera_switch[] switchers;
        public Camera_switch switcher;

        public int i = 0;


        public void Update(){


                if( new_camera == null )
                    { return; } // ** talvez depois tenha algum efeito
                
                if( switcher.Update() )
                    { End_switch(); }

            
        }


        public void Switch_cameras( Camera_switch_type _type, string _new_camera ){


                // --- VERIFICATIONS DEFAULT

                    if( new_camera != null  )
                        { End_switch(); }

                    if( current_camera == null )
                        { CONTROLLER__errors.Throw( "Do not put the first camera" ); }

                    if( _new_camera == current_camera.name )
                        { Console.Log( "tried to switch to the same camera" ); return; }

                    
                // --- SWITCHER

                    switcher = switchers[ ( int ) _type ];
                    
                    if( switcher == null )
                        { CONTROLLER__errors.Throw( $"Can not handle type { _type }" ); }

                // --- CAMERA OPERATORS

                    if( !!!( cameras.TryGetValue( _new_camera, out Camera_operator new_operator ) ) )
                        { CONTROLLER__errors.Throw( $"Could not find camera { _new_camera }" ); }

                    new_camera = new_operator;

                new_camera.Start_render();
                new_camera.Change_target( render_screen_transition );
                screen_transition_game_object.SetActive( true );

                switcher.Start(); // ** IMPORTANT
                
        }


        public void End_switch(){

                switcher.Finish();

                current_camera.Stop_render();
                current_camera.Change_target( null );

                new_camera.Start_render();
                new_camera.Change_target( render_screen );

                
                current_camera = new_camera;
                new_camera = null;

                
                switcher = null;

                screen_transition_game_object.SetActive( false );

        }


        public void Put_camera_screen_transition( Camera _camera ){



        }




}