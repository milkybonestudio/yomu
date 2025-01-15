

using UnityEngine;

public class Camera_operator {


        public Camera_operator( string _name, string _path ){

                name = _name;
                game_object = GAME_OBJECT.Find( _path );

                if( game_object.transform.childCount == 0 )
                    { CONTROLLER__errors.Throw( $"Camera { _name } dos not have any game objects childs" ); }

                camera_game_object = game_object.transform.GetChild( 0 ).gameObject;
                camera = camera_game_object.GetComponent<Camera>();
                game_object.SetActive( false );

            
        }

        public string name;
        public GameObject game_object;
        public GameObject camera_game_object;
        public Camera camera;

        public void Change_output( RenderTexture _new_render ){ camera.targetTexture = _new_render; }




        public void Stop_render(){ game_object.SetActive( false ); camera.targetTexture = null; }
        public void Start_render(){ game_object.SetActive( true ); }
    
        public void Change_target( RenderTexture _new_target ){ camera.targetTexture = _new_target; }



}