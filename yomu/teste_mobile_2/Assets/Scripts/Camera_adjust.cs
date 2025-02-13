using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_adjust : MonoBehaviour{

    // public float 

    
    public static Camera camera_world_public;

    public Camera camera_world;
    public RenderTexture render;

    public MeshRenderer mesh_render;
    public Material material;

    public float render_width;
    public float render_height;

    void Start(){ 


        render = camera_world.targetTexture; 
        mesh_render = gameObject.GetComponent<MeshRenderer>();
        material = mesh_render.material;

        camera_world_public = camera_world;

        camera_final_position = camera_world_public.transform.position;
        normal_position = camera_final_position;
        
    }


    public static Vector3 camera_final_position;
    public static Vector3 normal_position;

    public static void Set_normal_position(){

        Debug.Log( "novo valor: " + normal_position );
        camera_final_position = normal_position;

    }

    private float Abs( float _f ){

        if( _f > 0f )
            { return _f; }
        return -1f * _f;
    }


    void Adjust_camera(){

            // --- CAMERA

            Vector3 camera_position = camera_world_public.gameObject.transform.position;

            Vector3 dif_position = ( camera_position - camera_final_position );
            //Vector3 dif_position = ( camera_final_position - camera_position );


            if(  0.5f > Mathf.Sqrt(  ( dif_position.x * dif_position.x ) + ( dif_position.y * dif_position.y ) + ( dif_position.z * dif_position.z )   ) )
                { 
                    camera_world_public.gameObject.transform.position = camera_final_position;
                    return; 
                }

            float value_eq = 0f;

            float div = ( Abs(dif_position.x) + Abs(dif_position.y) + Abs(dif_position.z) );
        
            if( div != 0f )
                { value_eq = 1f / div; }

            float speed_camera = 35f;
            dif_position *= ( value_eq * speed_camera * Time.deltaTime );


            // Debug.Log( "final_position: " + camera_final_position );
            // Debug.Log( "camera_position: " + camera_position );
            // Debug.Log( "Div: " + div );


            // ** 10f, 15f, 10f

            camera_world_public.gameObject.transform.position -= dif_position;


    }

    void Update(){

            Adjust_camera();


            float width = ( float ) Screen.width;
            float height = ( float ) Screen.height;

            float width_on_screen;
            float height_on_screen;

            Vector3 scale = Vector3.one;

            float alp = ( width / height ); 
            float pixels_per_unit = 100f;


            if( alp > 1.7777f )
                {
                        // ** tem mais width -> usar height
                        scale.y = ( 1080f / height ) * ( 1080f / pixels_per_unit );
                        scale.x = ( scale.y * 1.7777f );

                        height_on_screen =  height;
                        width_on_screen  =  height * 1.7777f;

                }
                else
                {
                        // ** tem amis height -> usar width

                        scale.x = ( 1920f / width ) * ( 1920f / pixels_per_unit );
                        scale.y = ( scale.x / 1.7777f );

                        width_on_screen  =  width;
                        height_on_screen =  width / 1.777f;

                }

            if( ( Check( render_width, width_on_screen ) ) || ( Check( render_height, height_on_screen ) ) )
                { Adjust_texture( height_on_screen, width_on_screen ); }

            gameObject.transform.localScale = scale;


    }

    private bool Check( float _f_1,float _f_2  ){

        float dif = ( _f_1 - _f_2 );

        return ( ( dif < -0.1f ) || ( dif > 0.1f ) ) ;

    }


    private void Adjust_texture( float _height, float _width ){

            render = new RenderTexture( ( int ) _width, ( int ) _height,  0, UnityEngine.Experimental.Rendering.GraphicsFormat.R8G8B8A8_UNorm );
            camera_world.targetTexture = render;

            render_width = _width;
            render_height = _height;

            material.SetTexture( "_MainTex", render );

            // Debug.Log( $"vai ajustar para { render.height }px X { render.width }px" );


    }






}
