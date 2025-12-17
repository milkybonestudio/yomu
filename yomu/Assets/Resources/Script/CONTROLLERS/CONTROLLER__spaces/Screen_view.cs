using UnityEngine;


// meshRender 
//     --> Material    
//         --> texture ( renderTexture )
//     --> targetTexture
// camera


public class Screen_view {

    public static Screen_view Construct( string _path ){

        Screen_view screen_view = new Screen_view();

            screen_view.game_object = GameObject.Find( _path );
            screen_view.mesh_render = screen_view.game_object.GetComponent<MeshRenderer>();
            screen_view.mesh_render.material = new Material( Shaders.screen_view );
            screen_view.material = screen_view.mesh_render.material;
            
            screen_view.render_texture = screen_view.render_texture = new RenderTexture( 1920, 1080, 0 );
            screen_view.material.SetTexture( "_MainTex", screen_view.render_texture );


            screen_view.game_object.SetActive( false );
            
        return screen_view;


    }

    public MeshRenderer mesh_render;
    public GameObject game_object;
    public Material material;
    public RenderTexture render_texture; 

    public void Hide(){

        game_object.SetActive( false );

    }

    public void Show(){

        game_object.SetActive( true );

    }



}

