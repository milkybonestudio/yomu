using System;
using System.Runtime;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System.Reflection;
using System.Runtime.InteropServices;




unsafe public class CONTROLLER__data {



        public static CONTROLLER__data instancia;
        public static CONTROLLER__data Pegar_instancia(){ return instancia; }


        public MODULO__leitor_dll modulo__leitor_dll_dados_blocos;

        public FileStream stream_arquivo;


        // ** teste


        public IntPtr pointer_general_data;
        public int number_bytes = 200_000;

        public void Get_more_space(){

                int novo_numero_bytes = number_bytes + 100_000;

                IntPtr novo_pointer = Marshal.AllocHGlobal( number_bytes + 100_000 );

                int* pointer_novo_array_1 = ( int* ) novo_pointer.ToPointer();
                int* pointer_novo_array_2 = pointer_novo_array_1 + 1;
                int* pointer_novo_array_3 = pointer_novo_array_1 + 2;
                int* pointer_novo_array_4 = pointer_novo_array_1 + 3;

                int* pointer_data_1 = ( int* ) pointer_general_data.ToPointer();
                int* pointer_data_2 = pointer_data_1 + 1 ;
                int* pointer_data_3 = pointer_data_1 + 2 ;
                int* pointer_data_4 = pointer_data_1 + 3 ;

                int numero_ciclos = novo_numero_bytes / ( 4 * sizeof( int ) );

                for( int i = 0 ; i < numero_ciclos ; i++ ){

                        *pointer_data_1 = *pointer_novo_array_1;
                        *pointer_data_2 = *pointer_novo_array_2;
                        *pointer_data_3 = *pointer_novo_array_3;
                        *pointer_data_4 = *pointer_novo_array_4;

                        pointer_novo_array_1 += 4;
                        pointer_novo_array_2 += 4;
                        pointer_novo_array_3 += 4;
                        pointer_novo_array_4 += 4;

                        pointer_data_1 += 4;
                        pointer_data_2 += 4;
                        pointer_data_3 += 4;
                        pointer_data_4 += 4;

                }

                int faltando = ( number_bytes - numero_ciclos * 4 * sizeof( int )) ;

                byte* pointer_data_final = ( byte* ) pointer_data_1;
                byte* pointer_novo_array_final = ( byte* ) pointer_novo_array_1;

                for( int k = 0 ; k < faltando ; k++ ){

                        *pointer_data_final = *pointer_novo_array_final;
                        pointer_novo_array_final++;
                        pointer_data_final++;
                        
                }

                // --- todos os dados foram transferidos
                Marshal.FreeHGlobal( pointer_general_data );
                pointer_general_data = novo_pointer;
                number_bytes = novo_numero_bytes;

                return;

        }

        

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