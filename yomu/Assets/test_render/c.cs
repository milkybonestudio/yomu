using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cs : MonoBehaviour{


    Camera c;
    Texture2D tex;
    GameObject camera_go;
    
    // Start is called before the first frame update
    void Start()
    {
        camera_go = gameObject.transform.GetChild( 0 ).gameObject;
        c = camera_go.GetComponent<Camera>();
        camera_go.SetActive(false);
    }

    void Clear(){

            // Set the render target to the render texture
            Graphics.SetRenderTarget( c.targetTexture ); 

            // Clear the render target (optional: use color and depth clear)
            GL.Clear(true, true, Color.clear);

            // Reset the render target to the default (the screen)
            Graphics.SetRenderTarget( null );

    }


    public bool d = false;

    // Update is called once per frame
    void Update(){


        if( d ){ camera_go.SetActive(false); d =false; }

        if( Input.GetKeyDown( KeyCode.Q ) )
            {

                camera_go.SetActive(true);

                // Clear();
                // c.Render();
                d = true;

            }





        

        
    }
}
