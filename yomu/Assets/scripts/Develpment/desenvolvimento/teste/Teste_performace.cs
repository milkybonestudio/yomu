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

        public static bool ativado = true;

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




                                int[] xp_para_o_proximo_nivel = new int[  99 ];
                                //string[] txtS = new string[ 99 ];



                                for( int level = 1 ; level < 99 ; level++ ){
                                        


                                        int valor = 0;

                                        int level_quadrado = level * level;
                                        int valor_fixo = 176;

                                        switch( (level / 10 ) ) {

                                             case 0 : goto ponto_0;
                                             case 1 : goto ponto_0;

                                             case 2 : goto ponto_1;
                                             case 3 : goto ponto_1;
                                             case 4 : goto ponto_1;

                                             case 5 : goto ponto_2;
                                             case 6 : goto ponto_3;
                                             case 7 : goto ponto_4;
                                             case 8 :  if( level < 85 ){ goto ponto_5;} goto ponto_4; 
                                             case 9 :  if( level < 94 ){ goto ponto_6;} goto ponto_7;

                                        }

                                        ponto_7:
                                        valor += ( 600 * ( level_quadrado )  - ( 600 *94 *94 )  )  ; 
                                        valor += ( 15_000 * ( (level - 94 ) * ( level - 94 ) * ( level - 94 ) ) ) ; 
                                        valor += (  73_999  )  * ( level / 98 )  ;

                                        ponto_6:
                                        valor += ( 375 * ( level_quadrado )  - ( 375 *90 *90 )  )  ; 
                                        ponto_5:
                                        valor += ( 280 * ( level_quadrado )  - ( 275 *85 *85 )  )    ; 
                                        ponto_4:
                                        valor += ( 45  * ( level_quadrado )  - ( 45 *70 * 70 )  )    ; 
                                        ponto_3:
                                        valor += ( 40  * ( level_quadrado )  - ( 40 *60 * 60 )  )    ; 
                                        ponto_2:
                                        valor += ( 15  * ( level_quadrado )  - ( 15 *50 * 50 )  )    ; 
                                        ponto_1:
                                        valor += ( 4 * ( level_quadrado )  - ( 4 *20 *20)   )   ; 

                                        ponto_0:
                                        valor += ( 8 * ( level_quadrado )  )  +  ( level * 7 )  + valor_fixo ; 

                                        xp_para_o_proximo_nivel[ level ] = xp_para_o_proximo_nivel[ ( level - 1 ) ] +  valor;


                                        // valor += ( 8 * ( level_quadrado )  )  +  ( level * 7 )  + valor_fixo ; 
                                        // valor += ( 4 * ( level_quadrado )  - ( 4 *20 *20)   )  * ( level / 20 )  ; 
                                        
                                        // valor += ( 15  * ( level_quadrado )  - ( 15 *50 * 50 )  )  *  ( level / 50 )  ; 
                                        // valor += ( 40  * ( level_quadrado )  - ( 40 *60 * 60 )  )  *  ( level / 60 )  ; 
                                        // valor += ( 45  * ( level_quadrado )  - ( 45 *70 * 70 )  )  *  ( level / 70 )  ; 
                                        // valor += ( 280 * ( level_quadrado )  - ( 275 *85 *85 )  )  *  ( level / 85 )  ; 
                                        // valor += ( 375 * ( level_quadrado )  - ( 375 *90 *90 )  )  *  ( level / 90 )  ; 

                                        // valor += ( 600 * ( level_quadrado )  - ( 600 *94 *94 )  )  *  ( level / 94 )  ; 
                                        // valor += ( 15_000 * ( (level - 94 ) * ( level - 94 ) * ( level - 94 ) * ( level - 94 )  ) * ( level / 94 ) ) ; 
                                        // valor += (  73_999  )  * ( level / 98 )  ;

                                        // xp_para_o_proximo_nivel[ level ] = xp_para_o_proximo_nivel[ ( level - 1 ) ] +  valor;





                                }


                                

//                                 int[] xp_para_o_proximo_nivel = new int[]{

//         /* 0 */    -1,
//         /* 1:  */  191,
//         /* 2:  */  413,
//         /* 3:  */  682,
//         /* 4:  */  1_014,
//         /* 5:  */  1_425,
//         /* 6:  */  1_931,
//         /* 7:  */  2_548,
//         /* 8:  */  3_292,
//         /* 9:  */  4_179,
//         /* 10 :*/   5_225,
//         /* 11 :*/   6_446,
//         /* 12 :*/   7_858,
//         /* 13 :*/   9_477,
//         /* 14 :*/   11_319,
//         /* 15 :*/   13_400,
//         /* 16 :*/   15_736,
//         /* 17 :*/   18_343,
//         /* 18 :*/   21_237,
//         /* 19 :*/   24_434,
//         /* 20 :*/   27_950,
//         /* 21 :*/   31_965,
//         /* 22 :*/   36_503,
//         /* 23 :*/   41_588,
//         /* 24 :*/   47_244,
//         /* 25 :*/   53_495,
//         /* 26 :*/   60_365,
//         /* 27 :*/   67_878,
//         /* 28 :*/   76_058,
//         /* 29 :*/   84_929,
//         /* 30 :*/   94_515,
//         /* 31 :*/   104_840,
//         /* 32 :*/   115_928,
//         /* 33 :*/   127_803,
//         /* 34 :*/   140_489,
//         /* 35 :*/   154_010,
//         /* 36 :*/   168_390,
//         /* 37 :*/   183_653,
//         /* 38 :*/   199_823,
//         /* 39 :*/   216_924,
//         /* 40 :*/   239_780,
//         /* 41 :*/   263_939,
//         /* 42 :*/   289_433,
//         /* 43 :*/   316_294,
//         /* 44 :*/   344_554,
//         /* 45 :*/   374_245,
//         /* 46 :*/   405_399,
//         /* 47 :*/   438_048,
//         /* 48 :*/   472_224,
//         /* 49 :*/   507_959,
//         /* 50 :*/   545_285,
//         /* 51 :*/   585_749,
//         /* 52 :*/   629_413,
//         /* 53 :*/   676_339,
//         /* 54 :*/   726_589,
//         /* 55 :*/   780_225,
//         /* 56 :*/   837_309,
//         /* 57 :*/   897_903,
//         /* 58 :*/   962_069,
//         /* 59 :*/   1_029_869,
//         /* 60 :*/   1_114_165,
//         /* 61 :*/   1_207_543,
//         /* 62 :*/   1_310_153,
//         /* 63 :*/   1_422_145,
//         /* 64 :*/   1_543_669,
//         /* 65 :*/   1_674_875,
//         /* 66 :*/   1_815_913,
//         /* 67 :*/   1_966_933,
//         /* 68 :*/   2_128_085,
//         /* 69 :*/   2_299_519,
//         /* 70 :*/   2_481_385,
//         /* 71 :*/   2_680_178,
//         /* 72 :*/   2_896_138,
//         /* 73 :*/   3_129_505,
//         /* 74 :*/   3_380_519,
//         /* 75 :*/   3_649_420,
//         /* 76 :*/   3_936_448,
//         /* 77 :*/   4_241_843,
//         /* 78 :*/   4_565_845,
//         /* 79 :*/   4_908_694,
//         /* 80 :*/   5_294_630,
//         /* 81 :*/   5_700_537,
//         /* 82 :*/   6_126_663,
//         /* 83 :*/   6_573_256,
//         /* 84 :*/   7_040_564,
//         /* 85 :*/   7_564_960,
//         /* 86 :*/   8_158_447,
//         /* 87 :*/   8_821_833,
//         /* 88 :*/   9_555_926,
//         /* 89 :*/   10_361_534,
//         /* 90 :*/   11_239_465,
//         /* 91 :*/   12_258_402,
//         /* 92 :*/   13_419_903,
//         /* 93 :*/   14_725_526,
//         /* 94 :*/   16_176_829,
//         /* 95 :*/   17_903_770,
//         /* 96 :*/   20_119_107,
//         /* 97 :*/   23_575_598,
//         /* 98 :*/   30_000_000,
//         /* 99 :*/   100_000_000



//     };

                                if( xp_para_o_proximo_nivel[ 45 ] == -1 )
                                        { throw new Exception(); }






                             
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