using System;
using System.IO;

using System.Reflection;
using UnityEngine;


public static class Teste_performace {

        // public class Test_dll : MonoBehaviour{
        //         [DllImport("a")] public static extern float Somar(float a, float b);
        // }


        public static bool ativado = false;
        public static void Testar(){

                if( ! ( ativado ) ){ return; }

                Debug.Log( "teste performace <b><color=lime>ATIVADO</color></b>" );

                int _i = 0;
                int n_1 = 100_000;

                int p = 1;

                int ac = 15;

                System.Diagnostics.Stopwatch timePerParse = System.Diagnostics.Stopwatch.StartNew();

                while( _i < n_1 ){

                        _i++;

                        // --- ESCOPO 1
                        


                        try {

                                ac /= p;
                                ac /= p;


                        } catch( Exception e ){
                                ac++;

                        }

                        // ac /= p;
                        // ac /= p;




                }

                timePerParse.Stop();


                long ticksThisTime = timePerParse.ElapsedMilliseconds;



                System.Diagnostics.Stopwatch timePerParse_2 = System.Diagnostics.Stopwatch.StartNew();

                _i = 0;



                while( _i < n_1 * 0 ){

                        _i++;

                        // --- ESCOPO 2
                        ac++;
             


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