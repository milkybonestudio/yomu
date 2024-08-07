using System;
using System.Runtime.InteropServices;
using System.IO;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Jobs;
using Unity.Jobs;

using System.Runtime.CompilerServices;



public class C{


    public int Pegar_numero(){return 1555;}

}


public static class Teste_performace {


        public static byte[] arr;

        public static bool ativado = false;

        public  static void Testar(){


                if( !( ativado ) )
                        { return; }


                Debug.Log( "teste performace <b><color=lime>ATIVADO</color></b>" );

                int _i = 0;
                int n_1 =  100_000;



                System.Diagnostics.Stopwatch timePerParse = null;


                timePerParse  = System.Diagnostics.Stopwatch.StartNew();

                Vector2 v_2 = new Vector2( 1f,1f );
                Vector3 v_3 = new Vector3( 1f,1f, 1f );
                
                



                
                //byte[] dados_webp = System.IO.File.ReadAllBytes( "C:\\Users\\User\\Desktop\\yomu_things\\teste\\imagem_para_carregar.webp" );
//                byte[] dados_png = System.IO.File.ReadAllBytes( "C:\\Users\\User\\Desktop\\yomu_things\\teste\\a.png" );

                //WebP w = new WebP();



                    int nn = 0;
    
                    while( _i < n_1 ){


                            _i++;
                            // --- ESCOPO 1

                            int acc = 0;

                            for( int index = 0; index < 100 ; index++ ){


                                acc = ( acc + 1 ) % 2;


                            }


                        //GameObject.Find("Tela/Canvas/Jogo/EXCLUIR DEPOIS").GetComponent<Image>().sprite = ( new WebP()).Decode_2( dados_webp );


                            
                    }






                timePerParse.Stop();    
                // Debug.Log( $"acumulador: { acumulador.ToString( "#,0").Replace( ".", "_" ) }");



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