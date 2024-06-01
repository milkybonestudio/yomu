using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using Png_decoder;
using Unity.Collections;
using UnityEngine.SceneManagement;


public static class Teste_escopo {


        public static bool ativado = false;


        public static GameObject teste_body;
        public static Image imagem;
        public static Rigidbody2D   body ;

        public static Animator anim ;

        public static int  run_1_HASH = 0;



        public static void Testar(){

                if( ! ( ativado ) ){ return; }
                // iniciar 


                Sprite[] sprites_arr = new Sprite[10];

                System.Object object_  =  ( System.Object ) sprites_arr ;

                GameObject canvas_game_object = GameObject.Find( "Tela/Canvas" ) ;


                teste_body =  GameObject.Find("Tela/a");
                teste_body.transform.SetParent( canvas_game_object.transform , false );

                imagem = teste_body.GetComponent<Image>();
                //imagem.color = UnityEngine.Color.black;


                return;





        }


        public static void Update(){



          // Debug.Log("numero cameras: " +  Camera.allCamerasCount );
          // Debug.Log("current: " + Camera.current );


          int a  = 5;

          



          if( Input.GetKeyDown( KeyCode.L ) ){

               Controlador_multithread.Pegar_instancia().Matar_thread();



          }



          if( Input.GetKeyDown( KeyCode.U ) ){

               


               // Chave_cache chave =  Controlador_cache.Pegar_instancia().Pedir_slot();

               // chave.senha += 1;

               // Controlador_cache.Pegar_instancia().Adicionar_dados(  chave , new System.Object()  );
               // Controlador_cache.Pegar_instancia().Excluir_dados( chave );




          }


          if( Input.GetKeyDown( KeyCode.J ) ){

               

                    // Chave_cache chave =  Controlador_cache.Pegar_instancia().Pedir_slot();
                    // Task_req req = new Task_req (chave, "a");
                    // req.fn_iniciar = ( Task_req req ) => {

                    //      Debug.Log("a");
                    // req.dados = ( System.Object ) ( new Color32[50] ); }; 

                    // Controlador_multithread.Pegar_instancia().Adicionar_task( req );





               //    Task_req req = new Task_req (

               //      "task teste",
               //      ( Task_req req ) => { Debug.Log("parte inicio") ; System.Threading.Thread.Sleep( 3000 ); },
               //      ( Task_req req ) => {Debug.Log("parte final") ; System.Threading.Thread.Sleep( 3000 ); }, 
               //      new Action<Task_req>[] {

               //           ( Task_req req ) => {Debug.Log( "parte fracionada 1") ; System.Threading.Thread.Sleep( 3000 ); }, 
               //           ( Task_req req ) => {Debug.Log( "parte fracionada 2") ; System.Threading.Thread.Sleep( 2000 ); }, 
               //           ( Task_req req ) => {Debug.Log( "parte fracionada 3") ; System.Threading.Thread.Sleep( 2000 ); } 

               //      }
               
               //    );

                  
               //    Controlador_multithread.Pegar_instancia().Adicionar_task( req );




          }



          
          void fn(){





                 string path = "C:\\Users\\User\\Desktop\\yomu_things\\game\\versoes\\versao_002\\teste_carregar_imagem\\kuni_1.png";

                // string path = Application.dataPath +  "/final_big_completo.png";





                    //Bitmap bitmap = new Bitmap(@"C:\\Users\\User\\Desktop\\yomu_things\\game\\versoes\\versao_002\\teste_carregar_imagem\\final_big_completo.png");


                    // Color clr = bitmap.GetPixel(0, 0);

                    
                    

                    var stream = File.OpenRead( path );
                    Png image = Png.Open(stream);

                    int width = ( int )image.Width;
                    int height = ( int )image.Height;

                    int total_bytes =  width *  height * 4;

                    byte[] t = new byte[ total_bytes ];


                    Color32[] teste_cor = new Color32[  ( width *  height )  ];

                    UnityEngine.Color[] cores = new UnityEngine.Color[ ( width *  height )  ];





                    

                    for( int h = 0 ; h < height ; h++ ){
                         for(  int w = 0 ; w < width ; w++ ){

                              Pixel pixel = image.GetPixel( w, ( height - 1 -  h ) );

                              int p = ( w  ) + (h  * width );

                              teste_cor[ p ].r =  pixel.R;
                              teste_cor[ p ].g =  pixel.G; 
                              teste_cor[ p ].b =  pixel.B; 
                              teste_cor[ p ].a =  pixel.A; 

                              cores[ p ].r = pixel.R ;
                              cores[ p ].g = pixel.G ;
                              cores[ p ].b = pixel.B ;
                              cores[ p ].a = pixel.A ;


                         }
                    }


                    for( int h = 0 ; h < height ; h++ ){
                         for(  int w = 0 ; w < width ; w++ ){

                              Pixel pixel = image.GetPixel( w, ( height - 1 -  h ) );

                              int p = ( w * 4 ) + (h * 4 * width );
                              

                              t[ p ] =  pixel.R;
                              t[ p + 1 ] =  pixel.G; 
                              t[ p + 2 ] =  pixel.B; 
                              t[ p + 3 ] =  pixel.A; 


                         }
                    }


                    NativeArray<byte> n_a_bytes = new NativeArray<byte>( t , Allocator.Temp ); 






                    int numero_sprites = 10;
                    int numero_copias = 1000 * 10;
                    int  k = 0 ;
                    Sprite _sprite = null;


                    System.Object[] object_arr =  new System.Object[ numero_copias ];
                    Sprite[] sprites_arr = new Sprite[ numero_copias ];


                              


                    System.Diagnostics.Stopwatch timePerParse = System.Diagnostics.Stopwatch.StartNew();

     

                    for( k = 0 ; k < numero_sprites ; k++ ){


                              long tempo_por_sprite = ( timePerParse.ElapsedMilliseconds)  ;

                              //tex.SetPixelData( t , 0);
                              //tex.SetPixelData( n_a_bytes , 0);




                              // melhor
                              Texture2D tex = new Texture2D(  width  , height , TextureFormat.RGBA32,  false ); 

                              tex.SetPixelData( teste_cor , 0 );

                              // for(   int w = 0  ; w < width ; w++   ){
                              //      for(  int h = 0 ; h < height ;h++ ){

                              //           int pixel_atual = ( ( w ) + h * width );

                              //           tex.SetPixel( w , h , cores[ pixel_atual ] , 0 );


                              //      }
                              // }

                              

                              // tempo_por_sprite = ( timePerParse.ElapsedMilliseconds) - tempo_por_sprite ;
                              // Debug.Log( "tempo parte : " + tempo_por_sprite  );
          
                              //long tempo_por_sprite = ( timePerParse.ElapsedMilliseconds)  ;
                              //Debug.Log( "tempo setPixels : " + tempo_por_sprite  );


                              tex.Apply( false, false );
                              tex.filterMode = UnityEngine.FilterMode.Point;



                              //Debug.Log( "tempo aplly : " + tempo_por_sprite  );


                              sprites_arr[ k ]  =   Sprite.Create(tex  ,     new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f ,0, SpriteMeshType.FullRect   );
                              
                              imagem.sprite = sprites_arr[ k ] ;



                              
                    }


                    long __tempo_por_sprite = ( timePerParse.ElapsedMilliseconds)  ;
                    timePerParse.Stop();
                    Debug.Log( "parte na main thread : " + __tempo_por_sprite  );
                    timePerParse = System.Diagnostics.Stopwatch.StartNew();


                    for( k = 0 ; k < numero_sprites ; k++ ){


                         // byte[]  byte_arr = System.IO.File.ReadAllBytes (  path ); 
                         // Texture2D tex_2 = new Texture2D(  1  , 1 ); 
                         // tex.LoadImage( byte_arr );          
                         // sprites_arr[ k ]  =   Sprite.Create(tex  ,     new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f ,0, SpriteMeshType.FullRect   );


                    }



                    
                    timePerParse.Stop();
                    long _tempo_por_sprite = ( timePerParse.ElapsedMilliseconds)  ;
          
                    Debug.Log( "tudo na main thread: " + _tempo_por_sprite );

                    
















          }

          



          if( Input.GetKeyDown( KeyCode.P ) ) { 

               fn();




                    
                    // for(  k = 0 ; k < numero_copias ; k++ ){
                         
  
                    //           sprites_arr[ k ] = _sprite;
                              
                    // }


                    
                    // for(  k = 0 ; k < numero_copias ; k++ ){
                         
  
                    //           object_arr[ k ]  =  (System.Object ) sprites_arr[ k ] ;

                    // }


                    

                    
                    // for(  k = 0 ; k < numero_copias ; k++ ){
                         
  
                    //           sprites_arr[ k ]  =  ( Sprite ) object_arr [ k ] ;

                    // }




                    //Debug.Log("tempo 1: " + (ticksThisTime) + "ms");
               
               
          }

          
          if( Input.GetKeyDown( KeyCode.O ) ) { 

               
               // anim.Play( run_1_HASH , 0 , 0f ) ;

               SceneManager.LoadScene( "in_game" );
               
               
          }



          if( Input.GetKey( KeyCode.LeftArrow ) ){

               teste_body.transform.localPosition += new Vector3( -5f, 0f, 0f  );


          } 

          
          if( Input.GetKey( KeyCode.RightArrow ) ){

               teste_body.transform.localPosition += new Vector3( 5f, 0f, 0f );


          } 


          if( Input.GetKey( KeyCode.UpArrow ) ){

               teste_body.transform.localPosition += new Vector3( 0f, 5f, 0f  );


          } 


          if( Input.GetKey( KeyCode.DownArrow ) ){

               teste_body.transform.localPosition += new Vector3( 0f, -5f, 0f  );


          } 




          // if( Input.GetKeyDown( KeyCode.P ) ){

          //      Debug.Log("aaaaaa");
               
          //       Pergaminho_modelo_1.pergaminho.Finalizar_conversas();}

          

          // return;


        }



}