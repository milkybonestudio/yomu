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


                int y = 0;
                int _i = 0;
                int n_1 = 100;

                string path_para_salvar = "C:\\Users\\User\\Desktop\\yomu_things\\yomu\\dados_de_producao\\folder_para_teste_EXCLUIR_BUILD";

                int buffer_size = 4096;
                    

                if( !System.IO.Directory.Exists( path_para_salvar ) ){ System.IO.Directory.CreateDirectory( path_para_salvar ); }

                //Assembly s = Assembly.LoadFrom(Application.dataPath + "/Plugins/a.dll" );
                // var b =   s.GetType("teste_dll.Math_teste").GetMethod("Somar");
                // Action action = DelegateBuilder.BuildDelegate<Action<float, float>>( b );
                //flow d = new flow( b );
                // b c = new b();
                //float g =  (float) b.Invoke(   null , new System.Object[] {  1f,1f  }   );
                // float x  = 0f;

                System.Diagnostics.Stopwatch timePerParse = System.Diagnostics.Stopwatch.StartNew();

                while( _i < n_1 ){

                        _i++;

                }

                timePerParse.Stop();



                long ticksThisTime = timePerParse.ElapsedMilliseconds;



                System.Diagnostics.Stopwatch timePerParse_2 = System.Diagnostics.Stopwatch.StartNew();

                _i = 0;



                while( _i < n_1 ){

                        _i++;


                }


                timePerParse.Stop();
                long ticksThisTime_2 = timePerParse_2.ElapsedMilliseconds;

                Debug.Log("tempo dif: " + (ticksThisTime - ticksThisTime_2) + "ms");

                if( ticksThisTime_2 > 0l ){

                        float dif_percentual = ((  ((ticksThisTime - ticksThisTime_2) * 100l ) / ticksThisTime_2 )  ) ;
                        Debug.Log("tempo dif_percent: " + dif_percentual + "%");
                }

                Debug.Log("tempo 1: " + (ticksThisTime) + "ms");
                Debug.Log("tempo 2: " + ( ticksThisTime_2) + "ms");


                }



}