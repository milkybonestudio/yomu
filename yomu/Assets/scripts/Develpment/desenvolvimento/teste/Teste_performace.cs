using System;
using System.IO;
using System.Reflection;
using UnityEngine;

using System.Runtime.CompilerServices;



unsafe public static class Teste_performace {

        // public class Test_dll : MonoBehaviour{
        //         [DllImport("a")] public static extern float Somar(float a, float b);
        // }

        
        //public static fixed byte arr[ 50_000_000 ];
        public static byte[] arr;

        public static bool ativado = false;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool teste_ret( int valor ){

                if( valor == 15 )return true;
                //if( valor == 144444 )return true;
                // if( valor == 1444464 )return true;
                // if( valor == 1464444 )return true;
                // if( valor == 2 )return true;
                // if( valor == 21 )return true;
                // if( valor == 211 )return true;
                

                return false;
                
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void teste_void( int valor ){

                if( valor == 15 ){
                        throw new Exception();
                }

                // if( valor == 16 ){
                //         throw new Exception();
                // }

                // if( valor == 1645444 ){
                //         throw new Exception();
                // }

                // if( valor == 16445544 ){
                //         throw new Exception();
                // }

                // if( valor == 16224444 ){
                //         throw new Exception();
                // }

                // if( valor == 16444224 ){
                //         throw new Exception();
                // }

                return;
                
        }

        public unsafe static void Testar(){



                if( ! ( ativado ) ){ return; }


                Debug.Log( "teste performace <b><color=lime>ATIVADO</color></b>" );

                int _i = 0;
                int n_1 =  1_000_000; 



                System.Diagnostics.Stopwatch timePerParse = null;


                


                int acumulador = 0;

                timePerParse  = System.Diagnostics.Stopwatch.StartNew();

                                int[][] arr_1 = new int[ 3 ][]{
                                        new int[ 100 ],
                                        new int[ 100 ],
                                        new int[ 100 ]
                                };

                                int[] arr_1_1 = arr_1[ 0 ];
                                int[] arr_1_2 = arr_1[ 1 ];
                                int[] arr_1_3 = arr_1[ 2 ];

                                ref int[][] ref_arr = ref arr_1;


                                int[] aaa = new int[ 1000 ];
                                ref int[] aaa_ref = ref aaa;
        
                        while( _i < n_1 ){


                                _i++;
                                // --- ESCOPO 1

                                

                                for( int i = 0 ; i < aaa.Length ; i++ ){

                                        aaa[ i ] = -1;

                                }




                             
                        }






                timePerParse.Stop();    
                Debug.Log( $"acumulador: { acumulador.ToString( "#,0").Replace( ".", "_" ) }");
                



                long ticksThisTime = timePerParse.ElapsedMilliseconds;



                System.Diagnostics.Stopwatch timePerParse_2 = System.Diagnostics.Stopwatch.StartNew();

                _i = 0;



                while( _i < n_1 * 0 ){

                        _i++;

                        // --- ESCOPO 2
             


                }


                timePerParse.Stop();
                long ticksThisTime_2 = timePerParse_2.ElapsedMilliseconds;

                Debug.Log("tempo dif: " + (ticksThisTime - ticksThisTime_2) + "ms");

                if( ticksThisTime_2 > 0l )
                        {

                                float dif_percentual = ((  ((ticksThisTime - ticksThisTime_2) * 100l ) / ticksThisTime_2 )  ) ;
                                Debug.Log("tempo dif_percent: " + dif_percentual + "%");
                        }

                        else 
                        {
                                Debug.Log("tempo 1: " + (ticksThisTime) + "ms");
                                return;

                        }
                        
                Debug.Log("tempo 1: " + (ticksThisTime) + "ms");
                Debug.Log("tempo 2: " + ( ticksThisTime_2) + "ms");


                }



}