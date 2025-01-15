using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Main_camera_controller : MonoBehaviour{


    public Camera screen_camera;
    
    void Start(){

            screen_camera = gameObject.transform.GetChild( 0 ).GetComponent<Camera>();
            screen_camera.orthographic = true;
            Resize();
        
    }

    private const float pixels_per_unit = 100f;
    private const float height_default = 1080f;
    private const float width_default = 1920f;
    private const float adjust_half_camera = 2f;

    private const float camera_size_on_large = ( height_default / ( adjust_half_camera * pixels_per_unit ) );
    private const float camera_size_on_tall = ( width_default / ( adjust_half_camera * pixels_per_unit ) );
    
    void Resize(){


        // --- CALCULATE SIZE



        float new_size = 0;
        
        float screen_width = Screen.width;
        float screen_height = Screen.height;

        float alpha_screen = ( screen_width / screen_height );



        if( alpha_screen > 1.7777f )
            { new_size = camera_size_on_large;  }// --- MAIOR WIDTH -> recalcular height
            else
            { new_size = ( camera_size_on_tall / alpha_screen ) ; } // --- MAIOR WIDTH -> recalcular width
        
        
        screen_camera.orthographicSize = new_size ;
        
        
    }


    void Update(){

            if( Input.GetKeyDown( KeyCode.I ) )
                { Resize(); }

            Resize();
        
    }

}
