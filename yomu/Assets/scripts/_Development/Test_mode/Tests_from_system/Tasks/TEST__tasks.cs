using System.Threading;
using UnityEngine;

public unsafe static class TEST__tasks{



    public static Task_req Get_task( string _name ){

                Task_req req = new Task_req( _name );

                // --- SINGLE 
                    req.Give_single_final((Task_req _req) =>{ 

                        Console.Log( "ACTION SINGLE FINAL IN TASK: " + _req.nome );
                        Thread.Sleep( 25 ); 
                        Console.Log( "passou 1s na SINGLE FINAL " ); 
                        Thread.Sleep( 50 ); 
                        Console.Log( "passou 2s na SINGLE FINAL " ); 

                    });

                    // -- ACTION 1      
                    req.Give_single_sequencial_action((Task_req _req) =>{ 

                        Console.Log( "ACTION 1 SINGLE SEQUENCIAL IN TASK: " + _req.nome );
                        Thread.Sleep( 25 ); 
                        Console.Log( "passou 1s na SINGLE SEQUENCIAL " ); 
                        Thread.Sleep( 50 ); 
                        Console.Log( "passou 2s na SINGLE SEQUENCIAL " ); 

                    });


                    
                    // -- ACTION 2    
                    req.Give_single_sequencial_action((Task_req _req) =>{ 

                        Console.Log( "ACTION 2 SINGLE SEQUENCIAL IN TASK: " + _req.nome );
                        Thread.Sleep( 25 ); 
                        Console.Log( "passou 1s na SINGLE SEQUENCIAL " ); 
                        Thread.Sleep( 50 ); 
                        Console.Log( "passou 2s na SINGLE SEQUENCIAL " ); 

                    });


                // --- MULTITHREAD

                req.Give_multithread_final((Task_req _req) =>{ 

                    Console.Log( "ACTION MULTITHREAD FINAL IN TASK: " + _req.nome ); 
                    Thread.Sleep( 25 ); 
                    Console.Log( "passou 1s na MULTIUTHREAD FINAL " ); 
                    Thread.Sleep( 50 ); 
                    Console.Log( "passou 2s na MULTIUTHREAD FINAL " ); 

                });


                // -- ACTION 1      
                req.Give_multithread_sequencial_action((Task_req _req) =>{ 

                    Console.Log( "ACTION 1 MULTITHREAD SEQUENCIAL IN TASK: " + _req.nome );
                    Thread.Sleep( 25 ); 
                    Console.Log( "passou 1s na MULTIUTHREAD SEQUENCIAL " ); 
                    Thread.Sleep( 50 ); 
                    Console.Log( "passou 2s na MULTIUTHREAD SEQUENCIAL " ); 

                });


                
                // -- ACTION 2    
                req.Give_multithread_sequencial_action((Task_req _req) =>{ 

                    Console.Log( "ACTION 2 MULTITHREAD SEQUENCIAL IN TASK: " + _req.nome );
                    Thread.Sleep( 25 ); 
                    Console.Log( "passou 1s na MULTIUTHREAD SEQUENCIAL " ); 
                    Thread.Sleep( 50 ); 
                    Console.Log( "passou 2s na MULTIUTHREAD SEQUENCIAL " ); 

                });

            return req;


    }

    public static void Update(){

        if( Input.GetKeyDown( KeyCode.Alpha1 ) )
            {
                Task_req req_1 = Get_task( "TEST LOW PRIORITY" );
                Controllers.tasks.Adicionar_task( req_1 );

            }

        
        if( Input.GetKeyDown( KeyCode.Alpha2 ) )
            {
                Task_req req_2 = Get_task( "TEST MID PRIORITY" );
                req_2.priority = 10;
                Controllers.tasks.Adicionar_task( req_2 );

            }


        
        if( Input.GetKeyDown( KeyCode.Alpha3 ) )
            {
                Task_req req_3 = Get_task( "TEST HIGH PRIORITY" );
                req_3.priority = 50;
                Controllers.tasks.Adicionar_task( req_3 );

            }


        





    }



}