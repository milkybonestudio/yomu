using System;
using System.Collections;
using System.IO;

using System.Reflection;
using UnityEngine;




public static class Teste_performace_com_timer{

    
        public static bool ativado = false;
        public static void Testar(){

                if( !( ativado ) ){ return; }

                float t_segundos = 2f;
                bool loop = true;

                Mono_instancia.Start_coroutine(  a() );

                IEnumerator a(){

                        void q(){

                            
                                System.Diagnostics.Stopwatch timePerParse = System.Diagnostics.Stopwatch.StartNew();



                                /*-------------- THINGS  ----------------*/


                                /*-------------------------------------*/

                                
                                timePerParse.Stop();
                                long ticksThisTime = timePerParse.ElapsedMilliseconds;

                                Debug.Log( "tempo para realizar tarefa teste_performace_com_timer: " + ticksThisTime );



                        }


                        if(loop) {

                                while(true){

                                        q();
                                        yield return new WaitForSeconds(t_segundos);

                                }

                        } 

                        yield return new WaitForSeconds(t_segundos);

                        q();




                        yield break;


                }


        }




}