

using UnityEngine;

public static class CONSTRUCTOR__controller_cameras {

    public static CONTROLLER__cameras Construct(){

        CONTROLLER__cameras controller = new CONTROLLER__cameras();
        CONTROLLER__cameras.instance = controller;


            controller.screen_game_object = GameObject.Find( "Screen/Screen_texture" );
            controller.render_screen = Resources.Load<RenderTexture>( "Screen/Screen_render" );
            controller.screen_material = controller.screen_game_object.GetComponent<MeshRenderer>().material;

            controller.screen_transition_game_object = GameObject.Find( "Screen/Screen_transition_texture" );
            controller.render_screen_transition = Resources.Load<RenderTexture>( "Screen/Screen_transition_render" );
            controller.screen_transition_material = controller.screen_transition_game_object.GetComponent<MeshRenderer>().material;

            controller.screen_transition_game_object.SetActive( false );
            


            // --- CREATE SWITCHERS
            controller.switchers = new Camera_switch[ 10 ];
            controller.switchers[ ( int ) Camera_switch_type.fade ] = new Camera_switch_FADE();
            controller.switchers[ ( int ) Camera_switch_type.instant ] = new Camera_switch_INSTANT();


            controller_intern = controller;
                controller.screen_camera_game_object = GameObject.Find( "Screen/Camera_main" );
                controller.screen_camera_game_object.SetActive( true );
                controller.screen_camera = controller.screen_camera_game_object.transform.GetChild( 0 ).gameObject.GetComponent<Camera>();

                // ** somente de sistema, so liga quando usar
                controller.screen_UI_camera_game_object = GameObject.Find( "Screen/UI/Camera_main_UI" );
                controller.screen_UI_camera_game_object.SetActive( false );
                controller.screen_UI_camera = controller.screen_UI_camera_game_object.transform.GetChild( 0 ).gameObject.GetComponent<Camera>();

            
            // --- GET CAMERAS

            Add(  "Nothing" , "Screen/Nothing/Camera" );
            Add(  "Visual_novel" , "Blocks/Story/Visual_novel/Camera" );
            Add(  "Management" , "Blocks/Interaction/Management/Camera" );
            

        // --- SET NOTHING
        Camera_operator nothing_camera = controller_intern.cameras[ "Nothing" ];
        controller.current_camera = nothing_camera;
        nothing_camera.Change_target( controller.render_screen );
        nothing_camera.Start_render();
        


        return controller;

    }


    private static void Add( string _name, string _path ){ controller_intern.cameras.Add( _name, new Camera_operator( _name, _path ) ); }
    private static CONTROLLER__cameras controller_intern;



}