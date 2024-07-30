using System;
using System.IO;
using System.Reflection;
using UnityEngine;
using UnityEngine.Jobs;
using Unity.Jobs;

using System.Runtime.CompilerServices;



public static class abc {

        public volatile static int a = 10;

}

public struct teste_job: IJob {

        public void Execute(){

                // ** code 

                for( int i = 0 ; i < 1_000_000 ;i++ ){

                        if ( i > 452_000 )
                                { break; }

                }

                abc.a = 25;

        }

}


public static class Teste_performace {


        public static byte[] arr;

        public static bool ativado = false;

        public  static void Testar(){


                if( !( ativado ) )
                        { return; }


                Debug.Log( "teste performace <b><color=lime>ATIVADO</color></b>" );

                int _i = 0;
                int n_1 =  1; 



                // 0,3ms => 3k/segundo

                System.Diagnostics.Stopwatch timePerParse = null;


                //abc _abc = new abc();

                teste_job teste = new teste_job();
                JobHandle j_h = teste.Schedule();
                

                

                GameObject[] game_objects = new GameObject[ n_1 + 1] ;
                int acumulador = 0;

                int[] arr = new int[ 1000 ];

                byte[][] dados = new byte[ 10 ][];

                timePerParse  = System.Diagnostics.Stopwatch.StartNew();

                        GameObject canvas = GameObject.Find( "Tela/Canvas" );
        
                        while( _i < n_1 ){


                                _i++;
                                // --- ESCOPO 1

                                FileMode file_mode = FileMode.Open;
                                FileAccess file_accees = FileAccess.Read;
                                FileShare file_share = FileShare.Read;
                                FileOptions file_options = FileOptions.None; // talvez nao?


                                FileStream file_stream = new FileStream( $"C:\\Users\\User\\Desktop\\yomu_things\\concrete\\splashes\\sets_obrigatorios\\sara_wake_up\\feitos\\{ _i }.png", file_mode, file_accees , file_share, 1000 , file_options );

                                file_stream.Flush();
                                file_stream.Close();



                                dados[ 0 ] = System.IO.File.ReadAllBytes( $"C:\\Users\\User\\Desktop\\yomu_things\\concrete\\splashes\\sets_obrigatorios\\sara_wake_up\\feitos\\red\\carriage_window_albuin_group_1-min.png" );

                                


                                // // dados[ 0 ][ 7 ] = ( byte ) 75;
                                // dados[ 1 ][ 7 ] = ( byte ) 75;
                                // dados[ 2 ][ 7 ] = ( byte ) 75;
                                // dados[ 3 ][ 7 ] = ( byte ) 75;
                                // dados[ 4 ][ 7 ] = ( byte ) 75;
                             
                        }






                timePerParse.Stop();    
                Debug.Log( $"acumulador: { acumulador.ToString( "#,0").Replace( ".", "_" ) }");

                _i = 0;


                        while( _i < ( n_1 ) ){

                                _i++;

                                FileMode file_mode = FileMode.Open;
                                FileAccess file_accees = FileAccess.Read;
                                FileShare file_share = FileShare.Read;
                                FileOptions file_options = FileOptions.None; // talvez nao?


                                FileStream file_stream = new FileStream( $"C:\\Users\\User\\Desktop\\yomu_things\\concrete\\splashes\\sets_obrigatorios\\sara_wake_up\\feitos\\{ _i }.png", file_mode, file_accees , file_share, 1000 , file_options );

                                file_stream.Flush();
                                file_stream.Close();

                        }
                



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