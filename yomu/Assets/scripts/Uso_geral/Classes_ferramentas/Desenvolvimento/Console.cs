using System;
using System.Threading;
using UnityEngine;



// ** tem que direcionar referentes ao nomes das threads 


public static class Console {

        public static int i = 0;
        public const int i_m = 10;

        public static void Log_intervalado( string m ){ i = ( ( i + 1 ) % i_m ); if( i == 0 ){ Debug.Log( m ); }  }

        //public static System.Diagnostics.StackTrace stack_trace_normal = new System.Diagnostics.StackTrace( true );
        //public static int a = 10;
        

        public static int index_atual = 0;
        public static int pointer_run_time = 0;
        public static string[] logs = new string[ 5 ];
        public static int[] logs_tipos = new int[ 5 ];

        public static int index_atual_m = 0;
        public static int pointer_run_time_m = 0;
        public static string[] logs_m = new string[ 5 ];
        public static int[] logs_tipos_m = new int[ 5 ];

        
        private static string Get_trace( string _message ){


                System.Diagnostics.StackFrame[] frames = ( new System.Diagnostics.StackTrace( true ) ).GetFrames();

                const int margin_message = 1;
                const int margin_lines = 20;

                const int remove_log_frame = 2;

                string[] frames_stack = new string[ ( ( frames.Length - remove_log_frame ) + margin_message + margin_lines ) ];   

                frames_stack[ 0 ] = _message;
                int frame_stack = 1;

                    for( int frame_id = remove_log_frame  ; frame_id < frames.Length ; frame_id++){

                            System.Diagnostics.StackFrame s_frame = frames[ frame_id ];

                            string file_name = s_frame.GetFileName();
                            string assets_path = System.IO.Directory.GetParent( Application.dataPath ).FullName;
                            string path = System.IO.Path.GetRelativePath( assets_path , file_name ).Replace( "\\", "/" );

                            string className = s_frame.GetMethod().DeclaringType.Name;
                            string methodName = s_frame.GetMethod().Name;
                            int linha = s_frame.GetFileLineNumber();

                            frames_stack[ frame_stack++ ] = $"{className}:{methodName} () (at <a href=\"{path}\" line=\"{ linha }\">{ path }:{ linha }</a> )";
                            //Debug.Log( $"frame{ frame_id }: { frames_stack[ frame_id + margin_message ] }" );

                    }

                for( int i = 0; i < 20 ;i++ ){ frames_stack[ ^( i + 1 ) ] = "--------------------------"; }

                


                return string.Join( "\n\r", frames_stack  );

        }

        public static void Log( string _txt  ){


                string thread_name = Thread.CurrentThread.Name;

                string message_with_trace = Get_trace( _txt );

                if( thread_name == "Main" ){

                        if( index_atual == logs.Length )
                        { Array.Resize( ref logs, ( logs.Length + 200 ) ); Array.Resize( ref logs_tipos, ( logs_tipos.Length + 200 ) ); }

                        logs[ index_atual ] = message_with_trace;
                        logs_tipos[ index_atual ] = 1;
                        index_atual++;
                        return;

                }

                // mult
                if( index_atual_m == logs_m.Length )
                { Array.Resize( ref logs_m , ( logs_m.Length + 200 ) ); Array.Resize( ref logs_tipos_m , ( logs_tipos_m.Length + 200 ) ); }

                
                logs_m[ index_atual_m ] = message_with_trace;
                logs_tipos_m[ index_atual_m ] = 1;
                index_atual_m++;
                
                return;


        }

        public static void LogError( string _txt ){



                if( index_atual == logs.Length )
                    {  Array.Resize( ref logs, ( logs.Length + 200 ) ); Array.Resize( ref logs_tipos, ( logs_tipos.Length + 200 ) ); }

                logs[ index_atual ] = _txt;
                logs_tipos[ index_atual ] = -1;
                index_atual++;

                return;


        }

        



        public static void Update(){

                

                if( pointer_run_time == index_atual && pointer_run_time_m == index_atual_m )
                        { return; }

                
                int logs_length = logs.Length;
                int logs_m_length = logs_m.Length;


                bool tem_2 =    (
                                        ( index_atual != 0 ) 
                                        && 
                                        ( index_atual_m != 0 ) 

                                );
                                  

                if( tem_2 )
                        {

                                //Debug.Log( "length: " + ( logs_length + logs_m_length ) );
                                Debug.Log( "<b><color=lime>---------- MAIN -------------</color></b>" );

                        }


                for( int log_index = pointer_run_time ; log_index < logs_length ; log_index++ ){

                        
                        string texto = logs[ log_index ];
                        int tipo = logs_tipos[ log_index ];
                        if( texto == null )
                            { break; }

                        pointer_run_time++;

                        if( tipo == 1 )
                                { Debug.Log( texto ); }
                                else
                                { Debug.LogError( texto ); }
                        
                        continue;

                }

                if( tem_2 )
                    {
                            Debug.Log( "<b><color=lime>------------------------------</color></b>" );
                            Debug.Log( "<b><color=FF4747 >---------- MULTI -------------</color></b>" );
                    }




                for( int log_m_index = pointer_run_time_m ; log_m_index < logs_m_length ; log_m_index++ ){


                        string texto = logs_m[ log_m_index ];
                        int tipo = logs_tipos_m[ log_m_index ];

                        if( texto == null )
                            { break; }

                        pointer_run_time_m++;
                        //index_atual_m++;

                        if(tipo == 1 )
                                {
                                        Debug.Log( texto );
                                    
                                }
                                else
                                {
                                        Debug.LogError( texto );
                                }
                        
                        continue;

                }

                if( tem_2 )
                        {
                                
                                Debug.Log( "<b><color=FF4747 >------------------------------</color></b>" );
                                Debug.Log( "--" );
                                //Debug.Log( "--" );

                        }


                
                return;
            
        }





        public static void Resetar(){

                index_atual = 0;
                logs = new string[ 50 ];
                return;

        }

}