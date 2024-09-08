using System;
using System.Runtime;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System.Reflection;




public class Controlador_dados {



        public static Controlador_dados instancia;
        public static Controlador_dados Pegar_instancia(){ return instancia; }
        public static Controlador_dados Construir(){ 
                
                Controlador_dados controlador  = new Controlador_dados(); 
                Controlador_dados.instancia = controlador;

                    controlador.modulo__leitor_dll_dados_blocos = new MODULO__leitor_dll( "Dados_blocos_RUN_TIME", 50 );

                return instancia;

        }


        public MODULO__leitor_dll modulo__leitor_dll_dados_blocos;

        public FileStream stream_arquivo;
        

        public bool ja_pegou_dados_do_ciclo = false;

        public void Update(){}


        public bool Pode_pedir_dados(){  return ! ( ja_pegou_dados_do_ciclo ); }

        

        public byte[] Pedir_dados_run_time_byte_arr( string _path_dados ){

                // talvez valha mais a pena retornoar a stream?

                ja_pegou_dados_do_ciclo = true;

                if ( System.IO.File.Exists( _path_dados ) ){

                    throw new Exception( $"não foi achado o path { _path_dados } para pegar os dados" );

                }

                byte[] arquivo = System.IO.File.ReadAllBytes( _path_dados );
                return arquivo;



                
        }




      // testei e a velocidade para struc é basicamente a mesma. 
      public float[] posicao_mouse = new float[ 2 ];
      public float  screen_h = 0f;
      public float  screen_w = 0f;
      public float  alpha = 0f;

      public float  dif = 0f;



        public Vector2 Ajustar_posicao_vec2( Vector2 _vec ){

                return _vec * (1080f / Screen.height);


        }    


        public void Mudar_scale( Vector2 _vec ){

            _vec *= 1080f / Screen.height;

        }



        public void Atualizar_mouse_atual(){


                posicao_mouse[ 0 ] =   Input.mousePosition.x  * (  1920f / Screen.width ) ;
                posicao_mouse[ 1 ] =   Input.mousePosition.y  * (  1920f / Screen.width )  ;

        }


        // public void Atualizar_mouse_atual(){

        //         screen_h = Screen.height;
        //         screen_w = Screen.width;

                
        //         Debug.Log( "antigo_x: " + Input.mousePosition[ 0 ] );
        //         Debug.Log( "antigo_y: " + Input.mousePosition[ 1 ] );

        //         if( screen_h / screen_w  < 0.5625f ){

        //                 alpha  =   1080f / screen_h;
        //                 dif = (screen_w -  screen_h  * 1.7777f) / 2f;

        //                                     //  real  * alp => virtual
        //                 posicao_mouse[0] =  ( Input.mousePosition[0] - dif ) * alpha ;
        //                 posicao_mouse[1] =  ( Input.mousePosition[1]  ) * alpha ;

        //         }
        //         else{

        //                 alpha  =   1920f / screen_w;
        //                 dif = (screen_h  -  screen_w  * 0.5625f)/2f;

        //                 posicao_mouse[0] =  (Input.mousePosition[0]) * alpha ;
        //                 posicao_mouse[1] =  (Input.mousePosition[1] - dif ) * alpha ;

        //         }

        //         Debug.Log( "novo_x: " + posicao_mouse[ 0 ] );
        //         Debug.Log( "novo_y: " + posicao_mouse[ 1 ] );


        //         return;

        // }


}