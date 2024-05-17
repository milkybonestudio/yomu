using System.Collections;
using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Reflection;
using Png_decoder;
using Unity.Collections;



using System.Drawing;




//using UnityEditor.Animations;

using UnityEngine.SceneManagement;
 

using System.Runtime.InteropServices;

using System.Text;
using UnityEngine.Rendering.VirtualTexturing;




public enum teste_enum {

     a,
     b,
     c,
     d,
     e,
     f,
     g

}


public class Test_dll:MonoBehaviour{


     [DllImport("a")] public static extern float Somar(float a, float b);




}






public  class Teste {



      
        public static Teste instancia;
        public static Teste Pegar_instancia(){ return instancia; }
        public static Teste Construir(){ instancia = new Teste(); return instancia;}


     public void Iniciar(){}




     public Controlador controlador;

     public bool bloquear_testes = false ;



     public bool teste_generico = true ;

     public bool testar_login = false;
     public bool testar_menu = false ;



     public bool testar_plataform = false ;
     public string teste_fase = "";




     public bool testar_jogo = false ;
     public Ponto_nome ponto_nome =   Ponto_nome.UP_quarto_nara ; 

     public int[] interativos = new int[]{};
     public int testar_save = 0;



     public bool testar_visual_novel = false ;
     public Nome_screen_play screen_play_teste =  Nome_screen_play.NARA_INTRODUCAO_dia_introducao_carruagem ;        //"cenas_obrigatorias/1/sara_wake_up/rota_final"; 



     public Teste(){

          controlador  =  Controlador.instancia;
     
     }


    GameObject teste_body;
    Image imagem;
    public Rigidbody2D   body ;

    public Animator anim ;

    int  run_1_HASH = 0;

     public void teste_generico_escopo() {


          Sprite[] sprites_arr = new Sprite[10];

          System.Object object_  =  ( System.Object ) sprites_arr ;



          // Imagem_dados imagem_dados = Pegar_dados( key );
          // byte[] iamge_png = imagem_dados.png_bytes;

          // Chave_cache chave_imagem = Controlador_cache.Pegar_instancia().Pedir_slot();

          // Task_req req =  Suporte_multithread.Lidar_imagem_png(  _chave , imagem_byte_arr  ,"nome" );

          // Controlador_multithread.Pegar_instancia().Adicionar_task( req );


          
          


          // string path =   "C:\\Users\\User\\Desktop\\yomu_things\\game\\versoes\\versao_002\\teste_carregar_imagem\\a.png" ;
          // byte[] byte_arr; 
          // byte_arr = System.IO.File.ReadAllBytes (  path ); 

          // Debug.Log("b: " + byte_arr.Length);


          // Texture2D tex = new Texture2D(1,1); 
          // tex.LoadImage( byte_arr );          
          // Sprite _sprite  =   Sprite.Create(tex  ,     new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);


          GameObject canvas_game_object = GameObject.Find( "Tela/Canvas" ) ;
          // GameObject canvas_teste = new GameObject("canvas_teste");

          // canvas_teste.transform.SetParent( canvas_game_object.transform , false );

          // Image img = canvas_teste.AddComponent<Image>();
          // img.sprite = _sprite;


          teste_body =  GameObject.Find("Tela/a");
          teste_body.transform.SetParent( canvas_game_object.transform , false );

          imagem = teste_body.GetComponent<Image>();
          //imagem.color = UnityEngine.Color.black;



   




          

          return;

//          SceneManager.LoadScene( "fase_1" , LoadSceneMode.Additive);


//          GameObject player = Geral.Criar_imagem (_nome : "player",  _pai : canvas_teste ,  _width : 100f,  _height : 100f ,  _path_imagem : null,  _alpha : 1f );









          // GameObject player = GameObject.Find( "Tela/Canvas/player" ) ;

          // anim = player.GetComponent<Animator>();

          // AnimatorController cont = Resources.Load<AnimatorController>( "Animation/player" );

          // run_1_HASH =  Animator.StringToHash( "run_1" );


          // // body =  player.AddComponent < Rigidbody2D > ();
          // // player.AddComponent < Animator > () ;
          
          // // body.bodyType = RigidbodyType2D.Kinematic ;



     }




     public void Update(){




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

     
                    Texture2D tex = new Texture2D(  width  , height , TextureFormat.RGBA32,  false ); 

                    for( k = 0 ; k < numero_sprites ; k++ ){


                              long tempo_por_sprite = ( timePerParse.ElapsedMilliseconds)  ;

                              //tex.SetPixelData( t , 0);
                              //tex.SetPixelData( n_a_bytes , 0);




                              // melhor
                              tex.SetPixelData( teste_cor , 0);

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


                         byte[]  byte_arr = System.IO.File.ReadAllBytes (  path ); 
                         Texture2D tex_2 = new Texture2D(  1  , 1 ); 
                         tex.LoadImage( byte_arr );          
                         sprites_arr[ k ]  =   Sprite.Create(tex  ,     new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f ,0, SpriteMeshType.FullRect   );


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

     public void Update_pre(){

          // if( Input.GetKeyDown( KeyCode.P ) ){

          //      Debug.Log("aaaaaa");
               
          //       Pergaminho_modelo_1.pergaminho.Finalizar_conversas();}

          

          // return;

     }





public bool Verificar_teste(){

     // nao tem teste
     return false;

     Teste_performace();
     teste_generico_escopo();


     return true;

     /*
     choice
     */
     // refazer

     // int a = 10;

     // a++;


     //           if( bloquear_testes ) { return false ;}


               

     //           Teste_performace();
     //           //   Teste_com_timer();

     //           bool retorno = false;


     //           void verificar(){

     //                if( retorno ) throw new ArgumentException("tem 2 testes ativados ao mesmo tempo");
     //                retorno = true;
     //                return;

                    
     //           }


     //           if( teste_generico) { 
                    

     //                Player_estado_atual.Pegar_instancia().bloco_atual = Bloco.teste;
     //                teste_generico_escopo();
     //                verificar();

                    
     //           } else {


     //                controlador.dados_blocos.req_transicao = new Req_transicao(

     //                     Tipo_troca_bloco.START,
     //                     Bloco.jogo,
     //                     Tipo_transicao.instantaneo

     //                );

 


     //                controlador.dados_blocos.jogo_START = new Jogo_START();
                    
     //                controlador.controlador_transicao.Mudar_bloco();



     //                if(ponto_nome != Ponto_nome.nada ) controlador.bloco_jogo.controlador_movimento.Mover_player(  ponto_nome );

     //           }










     //     if( testar_jogo ) { verificar();}

         

     //     if(  testar_menu ) { 

               

     //          verificar();

     //           controlador.dados_blocos.req_transicao = new Req_transicao(

     //                Tipo_troca_bloco.START,
     //                Bloco.menu,
     //                Tipo_transicao.instantaneo

     //           );

     //           controlador.dados_blocos.menu_START = new Menu_START();
     //           controlador.controlador_transicao.Mudar_bloco();
               


     //      }

          
     //     if(  testar_visual_novel) { 

     //           verificar();
                  

     //           controlador.dados_blocos.req_transicao = new Req_transicao(

     //                Tipo_troca_bloco.START,
     //                Bloco.visual_novel,
     //                Tipo_transicao.instantaneo

     //           );

     //           controlador.dados_blocos.visual_novel_START = new Visual_novel_START( screen_play_teste );
     //           controlador.controlador_transicao.Mudar_bloco();
                 
     
     //      }


     //      if(testar_plataform){
               
     //          verificar();

     //           controlador.dados_blocos.req_transicao = new Req_transicao(

     //                Tipo_troca_bloco.START,
     //                Bloco.plataforma,
     //                Tipo_transicao.instantaneo

     //           );

     //           controlador.dados_blocos.plataforma_START = new Plataforma_START();
     //           if(teste_fase != "")  controlador.dados_blocos.plataforma_START.fase_to_load = teste_fase;

     //           controlador.controlador_transicao.Mudar_bloco();


               
     //      }




     //     return retorno;

}




     // System.Diagnostics.Stopwatch time = System.Diagnostics.Stopwatch.StartNew();

     // time.Stop();

     // long tempo_ms = time.ElapsedMilliseconds;
  




public void Teste_com_timer(){


     // ---------------------------------------------



//       float t_segundos = 2f;
//       bool loop = true;

//      controlador.StartCoroutine(  a() );

//      IEnumerator a(){

//           void q(){


//           /*-------------- THINGS  ----------------*/



//                     controlador.controlador_audio.Acrecentar_sfx("");


//           /*-------------------------------------*/


//           }


//           if(loop) {
                 
//                while(true){
                     
//                      q();
//                      yield return new WaitForSeconds(t_segundos);

//                }

//           } else{

//                   yield return new WaitForSeconds(t_segundos);

//                   q();

        


//                  yield break;


//           }


              
       
                



//      }






//       float t_segundos_2 = 20f;
//       bool loop_2 = false;

//      controlador.StartCoroutine(  b() );

//      IEnumerator b(){

//           void q(){




//           /*-------------- THINGS  ----------------*/


//           Debug.Log("CHECOU!");



//                     controlador.controlador_audio.Checar_sfx();


//           /*-------------------------------------*/


//           }


//           if(loop_2) {
                 
//                while(true){
                     
//                      q();
//                      yield return new WaitForSeconds(t_segundos_2);

//                }

//           } else{

//                   yield return new WaitForSeconds(t_segundos_2);

//                   q();

        


//                  yield break;


//           }


              
       
                



//      }



// // ---------------------------------------------



}








public delegate int Subtrair( int i );



public class Personagem {

     public Subtrair sub;

     public Personagem(){


               Somar_um = () => {

               valor += 1;
               return;

          };


          sub = ( int i ) => { return i + 5 ; };

     


     }


     public int valor = 1;


     public Action Somar_um;

     public void Somar_dois(){

          valor += 2;
          return;
     }

     public delegate int Somar_tres();

}



public class Maki : Personagem {

     public void Somar_dois(){

          valor += 3;
          return;

     }




}


 


 public void Teste_performace(){


          string bloco_teste = "";


     
bloco_teste += "                      nome : clothes@happy@esquerda ";
bloco_teste +=  " \n\r                 ";
bloco_teste +=  " \n\r                                           base            =>    imagem_nome // path ";
bloco_teste +=  " \n\r                                           secundaria      =>    iamgem_nome // path : posicao ";
bloco_teste +=  " \n\r                                           animacao_boca   =>  { ";
bloco_teste +=  " \n\r                                           a ";
bloco_teste +=  " \n\r                                           a ";
bloco_teste +=  " \n\r                                           a ";
bloco_teste +=  " \n\r                                            } ";


bloco_teste +=  " \n\r                                           animacao_boca   =>  { ";
bloco_teste +=  " \n\r                                           a ";
bloco_teste +=  " \n\r                                           a ";
bloco_teste +=  " \n\r                                           a ";
bloco_teste +=  " \n\r                                            } ";



bloco_teste +=  " \n\r                                           animacao_olhos    => {} ";
bloco_teste +=  " \n\r                                           animacao_completa => {} ";

          




// Atualizar_imagens_personagens_especificos( bloco_teste) ;
// return;
        void Atualizar_imagens_personagens_especificos( string bloco ){



     
                                int numero_imagens_extras = 0;
                                bool ja_pegou_na_linha = false;
                                bool iniciou_extras = false;
                                char caracter_em_analise = '0';

                                for( int c = 0 ; c < bloco.Length ; c++ ){


                                        // caracter_em_analise = bloco[ c ];

                                        // // vai comecar a pegar
                                        // if( caracter_em_analise == '{'){

                                        //         bool vazio = false;
                                        //         c++;
                                        //         for( ;c < bloco.Length; c++){


                                        //                 caracter_em_analise = bloco[ c ];
                                        //                 if( caracter_em_analise == ' ') {continue;}
                                        //                 if( caracter_em_analise == '}' ){
                                        //                         vazio =true;
                                        //                         break;
                                        //                 }
                                        //                 break;

                                        //         }
                                        //         if( vazio ){ continue;}
                                                  
                                        //           // nao conta a posicao
                                        //           numero_imagens_extras--;
                                        //           for( ;c < bloco.Length ; c++ ){

                                        //                     caracter_em_analise = bloco[ c ];


                                        //                     if( caracter_em_analise == '}' ){break;}
                                        //                     if( caracter_em_analise == ' ' ){continue;}
                                        //                     if( caracter_em_analise == '\r' ){continue;}
                                        //                     if( caracter_em_analise == '\n' ){
                                        //                               ja_pegou_na_linha = false;
                                        //                          continue;
                                        //                     }

                                        //                     if( ja_pegou_na_linha ){ continue;}
                                                            
                                        //                     numero_imagens_extras++;
                                        //                     ja_pegou_na_linha = true;



                                        //           }


                                        // }

                                      



                                }

                               // Debug.Log("esxtras: " + numero_imagens_extras);





        }


























     string a = "abcde";
     string b = "abcdef";

     char[] a_arr = new char[]{
          'a',
          'b',
          'c',
          'd',
          'e'
     };


     char[] b_arr = new char[]{
          'a',
          'b',
          'c',
          'd',
          'e',
          'f'
     } ;







       System.Diagnostics.Stopwatch timePerParse = System.Diagnostics.Stopwatch.StartNew();
      
       
//        int k = 0;

       int _i = 0;

// //        t T = new t();
   

        int n_1 = 1000 * 1000 ;

// //           Assembly s = Assembly.LoadFrom(Application.dataPath + "/Plugins/a.dll" );

// //           var b = s.GetType("teste_dll.Math_teste").GetMethod("Somar");
          
// //           //   float g =  (float) b.Invoke(   null , new System.Object[] {  1f,1f  }   );


// //           float x  = 0f;


          void abc( string a ){ 

               if( a.Length > 1000 ){
                    a = "";
                    return;
               }

          }

          void abcd( char[] a ){ 

               if( a.Length > 1000 ){
                    a[ 0 ] = 'a';
                    return;
               }

          }


        while( _i < n_1  ){

               _i++;

          //p.Somar_um()   ;
          //maki.Somar_dois();

               //     abc( a );
               // abc( b );



          // int a_arr_length = a_arr.Length;
          // int b_arr_length = b_arr.Length;

          
                           if( b_arr.Length == a_arr.Length ){

                    bool igual = true;

                    for( int c = 0 ; c < a_arr.Length ;c++ ){

                         if( a_arr[ c ] != b_arr[ c ] ){ 
                              igual = false;
                              break; 
                         }

                    }
                    if( igual ){
                         a = "aaa";
                    }

          }
  







              
        }
  
      timePerParse.Stop();

     long ticksThisTime = timePerParse.ElapsedMilliseconds;


  

          _i = 0;
          System.Diagnostics.Stopwatch timePerParse_2 = System.Diagnostics.Stopwatch.StartNew();

        

        while( _i < n_1 ){
 
          _i++;


  
               
               // abcd( a_arr );
               // abcd( b_arr );


   

               
               if( a.Length == b.Length ){

                    if( a == b ){
                         a = "aaaaaa";

                    }

               }





 




        

              // string c = new string ( a_arr );



          
          

               //p.Somar_dois();
               //a();
               //abc();


        }




      timePerParse.Stop();
     long ticksThisTime_2 = timePerParse_2.ElapsedMilliseconds;




//      //Debug.Log("tempo dif: " + (ticksThisTime - ticksThisTime_2) + "ms");
//      float dif_percentual = ((  ((ticksThisTime - ticksThisTime_2) * 100l ) / ticksThisTime_2 )  ) ;
     
//    Debug.Log("tempo dif_percent: " + dif_percentual + "%");
     
//      Debug.Log("tempo 1: " + (ticksThisTime) + "ms");
//      Debug.Log("tempo 2: " + ( ticksThisTime_2) + "ms");

     




     }


}


