using System;
using UnityEngine;

unsafe public static class teste_pointer{


    public static void Testar(){

                Debug.Log( "teste performace pointer <b><color=lime>ATIVADO</color></b>" );

                int _i = 0;
                int n_1 =  200_000_000; // ints


                byte[] arr = new byte[ 200_000_000 * 4 ];

                
                for( int index = 0 ;  index < arr.Length ;  index += 4 ){

                        arr [ index   + 0 ] = 10;
                        arr [ index   + 1 ] = 0;
                        arr [ index   + 2 ] = 0;
                        arr [ index   + 3 ] = 0;
                }

                Posicao p = new Posicao();

                p.regiao_id = 50;
                p.trecho_id = 45;
                p.cidade_no_trecho_id = 40;
                p.zona_id = 35;
                p.local_id = 30;
                p.area_id = 25;
                p.ponto_id = 20;




                System.Diagnostics.Stopwatch timePerParse = null;

                int acumulador = 0;

                fixed( byte* p_b = arr ) {

                        unchecked {

                        
                                int* p_i = ( int* ) p_b;
                                decimal* p_d = ( decimal* ) p_b;
        
                                timePerParse  = System.Diagnostics.Stopwatch.StartNew();

                               // try{

                                                                    
                                        int length = 16;
                                        int def = ( n_1 - ( n_1 % length ) ) / length;

                                        Debug.Log( "vezes: " + def );

                                        while( _i < def ){

                                        
                                                // --- ESCOPO 1



                                                int* pointer = ( p_i + ( _i * 16 ) );
                                                _i++;


                                                int acc_interno = 0;

                                                decimal* d_pointer = ( decimal *) (  pointer  );

                                                // 1
                                                pointer = ( int* )( &( *d_pointer ) ); 
                                                d_pointer++;

                                                acc_interno +=  *( pointer  ) ;
                                                pointer ++;
                                                acc_interno +=  *( pointer  ) ;
                                                pointer ++;
                                                acc_interno +=  *( pointer  ) ;
                                                pointer ++;
                                                acc_interno +=  *( pointer  ) ;

                                                // 2 
                                                pointer = ( int* )( &( *d_pointer ) ); 
                                                d_pointer++;


                                                acc_interno +=  *( pointer  ) ;
                                                pointer ++;
                                                acc_interno +=  *( pointer  ) ;
                                                pointer ++;
                                                acc_interno +=  *( pointer  ) ;
                                                pointer ++;
                                                acc_interno +=  *( pointer  ) ;

                                                

                                                // 3
                                                pointer = ( int* )( &( *d_pointer ) ); 
                                                d_pointer++;


                                                acc_interno +=  *( pointer  ) ;
                                                pointer ++;
                                                acc_interno +=  *( pointer  ) ;
                                                pointer ++;
                                                acc_interno +=  *( pointer  ) ;
                                                pointer ++;
                                                acc_interno +=  *( pointer  ) ;

                                                

                                                // 4
                                                pointer = ( int* )( &( *d_pointer ) ); 

                                                acc_interno +=  *( pointer  ) ;
                                                pointer ++;
                                                acc_interno +=  *( pointer  ) ;
                                                pointer ++;
                                                acc_interno +=  *( pointer  ) ;
                                                pointer ++;
                                                acc_interno +=  *( pointer  ) ;

                                                acumulador += acc_interno;

                                        }



                                        _i *= length;

                                        while( _i < n_1  ){

                                                _i++;
                                                acumulador += *( p_i + _i );
                                        }



                                // } 
                                // catch( Exception e )
                                // {
                                //         Debug.Log( "parou no " + (  (long) (p_i +  ( long ) (sizeof( int ) * _i))   ) );
                                //         throw e;
                                // }
                                

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