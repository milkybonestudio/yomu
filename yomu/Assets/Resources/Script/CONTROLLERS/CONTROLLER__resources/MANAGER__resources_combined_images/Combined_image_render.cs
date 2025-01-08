using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;


public class Combined_image_render{

        public const bool DEBUG = false;

        public Combined_image_render( GameObject _game_object, Image_link[] _links, Camera _camera, GameObject _camera_game_obj, int _line, int _collum ){

                line = _line;
                collum = _collum;

                c = _camera;
                camera_game_object = _camera_game_obj;

                // _camera_game_obj.SetActive( false );


                

                // ** precisa verificar o tamanho da texture
                // ** também vai setar a camera

                float y_min  = 0;
                float y_max  = 0;
                float x_min  = 0;
                float x_max =  0;

                for( int slot = 0 ; slot < _links.Length ; slot++ ){

                        Image_link link = _links[ slot ];

                        if( link.game_object == null )
                            { break; }

                        if( DEBUG ){ Console.Log( "game object: " + link.game_object.name );}

                        float half_width_sprite = link.resource_ref.image.width_float / 2 ;
                        float half_height_sprite = link.resource_ref.image.height_float / 2;

                        if( DEBUG )
                            { 
                                Console.Log( "h_width: " + half_width_sprite );
                                Console.Log( "h_height: " + half_height_sprite );
                            }
                            
                        Vector3 position_image = link.game_object.transform.localPosition;

                        float position_x = ( position_image.x * 100f );
                        float position_y = ( position_image.y * 100f );


                        if( DEBUG )
                            { 
                                Console.Log( "position_x: " + position_x );
                                Console.Log( "position_y: " + position_y );
                            }
                        

                        // ** Y 
                        if( y_min > ( position_y - half_height_sprite ) )
                            { y_min = ( position_y - half_height_sprite ); }

                        if( y_max < ( position_y + half_height_sprite ) )
                            { y_max = ( position_y + half_height_sprite ); }

                        // ** X
                        if( x_min > ( position_x - half_width_sprite ) )
                            { x_min = ( position_x - half_width_sprite ); }

                        if( x_max < ( position_x + half_width_sprite ) )
                            { x_max = ( position_x + half_width_sprite ); }

                        if( DEBUG )
                            {
                                Console.Log( "y_max: " + y_max );
                                Console.Log( "y_min: " + y_min );
                                Debug.Log( "x_max: " + x_max );
                                Debug.Log( "x_min: " + x_min );
                                Debug.Log( "------------------------------" );
                            }
                        



                }


                if( DEBUG )
                    {
                        Debug.Log( "y_max: " + y_max );
                        Debug.Log( "y_min: " + y_min );

                        Debug.Log( "x_max: " + x_max );
                        Debug.Log( "x_min: " + x_min );
                    }


                float width = ( x_max - x_min );
                float height = ( y_max - y_min );

                if( DEBUG )
                    {
                        Console.Log( "width: " + width );
                        Console.Log( "height: " + height );
                    }

                // mid_off_set     
                _game_object.transform.localPosition -= new Vector3( ( x_max + x_min )/ ( 2 * 100 ) ,  ( ( y_max + y_min )/( 2 * 100 ) ), 0f );
                 

                    
                if( DEBUG ) { Debug.Log( "_______________________" ); }

                // ** Number of bits in depth buffer -> pra que serve?
                render_texture = new RenderTexture( ( int ) width, ( int ) height, 0, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Default );
                render_texture.filterMode = FilterMode.Point;
                c.targetTexture =  render_texture;



                // ** CRIAR PLANE

                quad_render = GameObject.Instantiate( Resources.Load<GameObject>( "Quad" ) );



                float scale_x = ( ( float ) width ) / 100f ;
                float scale_y = ( ( float ) height ) / 100f ;

                MeshRenderer mesh_render = quad_render.GetComponent<MeshRenderer>();
                mesh_render.material = new Material( Shaders.DEFAULT );

                mesh_render.material.SetTexture( "_MainTex", render_texture );


                quad_render.transform.localScale = new Vector3( scale_x, scale_y, 1f );

                c.orthographicSize = scale_y / 2;

                Print();
                
                
        }


        public GameObject quad_render; // pegar


        // ** new
        public RenderTexture render_texture;

        public Camera c;
        public GameObject camera_game_object;

        public int line;
        public int collum;
        

        public void Delete(){


                GameObject.Destroy( render_texture );
                c = null;
                camera_game_object = null;

                CONTROLLER__resources.Get_instance().resources_combined_images.spaces[ line, collum ] = false;

        }


        public void Print(){

                camera_game_object.SetActive( true );
                c.Render();
                camera_game_object.SetActive( false );

        }




}
