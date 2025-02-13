using System;
using UnityEngine;


public enum Camera_state {

    not_give,
    hide,
    activated,

}

public class Camera_operator {

        public static GameObject container_to_move = GameObject.Find( "Containers" );


        public Camera_operator( string _name, string _path_camera_operator, string _path_mash_render ){

                operator_name = _name;


                // ** MESH_RENDER
                mesh_render_game_object = GameObject.Find( _path_mash_render );
                mesh_render = mesh_render_game_object.GetComponent<MeshRenderer>();
                mesh_render_material = mesh_render.material;

                // ** CAMERA

                camera_game_object = GameObject.Find( ( _path_camera_operator + "/Camera/camera" ) );
                camera = camera_game_object.GetComponent<Camera>();

                //mark
                // ** HDR??
                render_texture = new RenderTexture( 1920, 1080, 0 );
                // Resources.Load<RenderTexture>( "Screen/mode" );

                // ** CONTAINER
                container = GameObject.Find( ( _path_camera_operator + "/Container" ) ).transform.gameObject;
                GameObject.Destroy( container.GetComponent<SpriteRenderer>() );

                // ** set
                camera.targetTexture = render_texture; // ** camera will draw in the texture
                mesh_render_material.SetTexture( "_MainTex", render_texture ); // ** material will show the texture


                camera_unique_UI_game_object = GameObject.Find( ( _path_camera_operator + "/unique_UI/Camera/camera" ) );
                camera_unique_UI = camera_unique_UI_game_object.GetComponent<Camera>();
                
                container_unique_UI = GameObject.Find( ( _path_camera_operator + "/unique_UI/Container" ) ).transform.gameObject;
                container_unique_UI_transform = container_unique_UI.transform;
                GameObject.Destroy( container_unique_UI.GetComponent<SpriteRenderer>() );
                

                camera_unique_UI_game_object.SetActive( false );
                camera_game_object.SetActive( false );


        }

        public string name = "";
        public string operator_name;


        // ** UNIQUE UI ( overlay )
        
        public GameObject camera_unique_UI_game_object;
        public Camera camera_unique_UI;
        
        // ** container
        public GameObject container_unique_UI;
        public Transform container_unique_UI_transform;


        // *** MAIN

        // ** meshrender
        public GameObject mesh_render_game_object;
        public MeshRenderer mesh_render;
        public Material mesh_render_material;

        // ** camera

        public GameObject camera_game_object;
        public Camera camera;
        public RenderTexture render_texture; 

        // ** container
        public GameObject container;


        public Action on_change_target = ()=>{};

        public Camera_state state = Camera_state.hide;


        public void Update(){

            if( state == Camera_state.hide )
                { return; }

            container_unique_UI.SetActive( ( container_unique_UI_transform.childCount != 0 ) );

        }


        public void Move_structures_to_container(){

                // ** controller__camera nao pode destruir nada, ele somente move para um container que nao vai ficar na frente da camera

                Transform container_transform = container.transform;

                int number_objects = container_transform.childCount;

                for( int child_index = 0 ; child_index < number_objects ; child_index++ )
                    { container_transform.GetChild( child_index ).SetParent( container_to_move.transform, false ); }

        }



        public void Stop_render(){ 

                camera_game_object.SetActive( false ); 
                mesh_render_game_object.SetActive( false ); 
                camera_unique_UI_game_object.SetActive( false );
                state = Camera_state.hide;

        }


        public void Start_render(){ 
            
                camera_game_object.SetActive( true ); 
                mesh_render_game_object.SetActive( true ); 
                camera_unique_UI_game_object.SetActive( true );
                state = Camera_state.activated;

        }


    
        public void Reset_material(){

            // ** 

        }


}
