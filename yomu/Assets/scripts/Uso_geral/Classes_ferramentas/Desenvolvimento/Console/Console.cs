using System;
using System.Threading;
using UnityEngine;



public static class Console {


        public static int i = 0;
        public const int i_m = 10;

        public static void Log_intervalado( string m ){ i = ( ( i + 1 ) % i_m ); if( i == 0 ){ Debug.Log( m ); }  }


        public static bool multithread_ativado = false;

        // --- MAIN

        public static int index_atual_main = 0;
        public static int pointer_run_time = 0;
        public static string[] logs_main = new string[ 5 ];
        public static Log_type[] logs_tipos_main = new Log_type[ 5 ]{ Log_type.warning,Log_type.warning, Log_type.warning, Log_type.warning,Log_type.warning };

        // --- MULTITHREAD

        public static int index_atual_m = 0;
        public static int pointer_run_time_m = 0;
        public static string[] logs_m = new string[ 7 ];
        public static Log_type[] logs_tipos_m = new Log_type[ 7 ];



        public static void Log( string _message ){ Log_intern( _message, Log_type.normal, ( Thread.CurrentThread.Name == "Main" ) ); return; }
        public static void LogError( string _message ){ Log_intern( _message, Log_type.error, ( Thread.CurrentThread.Name == "Main" ) ); return; }


        private static void Log_intern( string _message, Log_type _type, bool _main_thread ){


                string message_with_trace = Get_trace( _message );

                if( !!!( _main_thread ) )
                    { multithread_ativado = true; }

                // --- PEGA REFS DA THREAD ATUAL
                Log_type[] logs_tipos = _main_thread ? ( logs_tipos_main ) : ( logs_tipos_m ) ;
                string[] logs = _main_thread ? ( logs_main ) : ( logs_m ) ;
                int index_atual =  _main_thread ? ( index_atual_main++ ) : ( index_atual_m++ ) ;


                if( index_atual > ( logs.Length - 10 ) )
                        { 
                            Array.Resize( ref logs, ( logs.Length + 2_000 ) ); Array.Resize( ref logs_tipos, ( logs_tipos.Length + 2_000 ) ); 
                            if( _main_thread )
                                { logs_main = logs; logs_tipos_main = logs_tipos; }
                                else
                                { logs_m = logs; logs_tipos_m = logs_tipos; }
                        }
                        
                logs[ index_atual ] = message_with_trace;
                logs_tipos[ index_atual ] = _type;

                return;

        }

        public static string name = null;
        private static string Get_trace( string _message ){


                System.Diagnostics.StackFrame[] frames = ( new System.Diagnostics.StackTrace( true ) ).GetFrames();

                const int margin_message = 1;
                const int margin_lines = 20;

                const int remove_log_frame = 2;

                string[] frames_stack = new string[ ( ( frames.Length - remove_log_frame ) + margin_message + margin_lines ) ];   

                frames_stack[ 0 ] = _message;
                int frame_stack = 1;

                    for( int frame_id = remove_log_frame  ; frame_id < frames.Length ; frame_id++){

                            if( name != null && Thread.CurrentThread.Name == "Main")
                                { Debug.Log( "name: " + name ); }

                            try {

                                System.Diagnostics.StackFrame s_frame = frames[ frame_id ];

                                string file_name = s_frame.GetFileName();

                                
                                if( name != null && Thread.CurrentThread.Name != "Main")
                                    { name = file_name; }

                                

                                string assets_path = System.IO.Directory.GetParent( Application.dataPath ).FullName;
                                string path = System.IO.Path.GetRelativePath( assets_path , file_name ).Replace( "\\", "/" );

                                string className = s_frame.GetMethod().DeclaringType.Name;
                                string methodName = s_frame.GetMethod().Name;
                                int linha = s_frame.GetFileLineNumber();

                                frames_stack[ frame_stack++ ] = $"{className}:{methodName} () (at <a href=\"{path}\" line=\"{ linha }\">{ path }:{ linha }</a> )";
                                
                            } catch ( Exception e ){



                            }


                            continue;

                    }

                for( int i = 0; i < 20 ;i++ ){ frames_stack[ ^( i + 1 ) ] = "--------------------------"; }

                return string.Join( "\n\r", frames_stack  );

        }


        private static void Log_unity( string _message, Log_type _type ){

                switch( _type ){

                    case Log_type.normal: Debug.Log( _message ); break;
                    case Log_type.error: Debug.LogError( _message ); break;

                }

        }


        public static void Update(){

                
                if( pointer_run_time == index_atual_main && pointer_run_time_m == index_atual_m )
                        { return; }

                Debug_conditional( multithread_ativado, "<b><color=lime>---------- MAIN -------------</color></b>" );


                int starter_point = pointer_run_time;
                pointer_run_time = index_atual_main;

                for( int log_index = starter_point; log_index < index_atual_main ; log_index++ ){

                        if( logs_main[ log_index ] == null )
                            { break; }
                        
                        Log_unity( logs_main[ log_index ], logs_tipos_main[ log_index ] );

                }

                Debug_conditional( multithread_ativado, "<b><color=lime>------------------------------</color></b>", "<b><color=FF4747 >---------- MULTI -------------</color></b>" );

                int starter_point_m = pointer_run_time_m;
                pointer_run_time_m = index_atual_m;

                for( int log_index_m = starter_point_m; log_index_m < index_atual_m ; log_index_m++ ){

                        if( logs_m[ log_index_m ] == null )
                            { break; }
                        
                        Log_unity( logs_m[ log_index_m ], logs_tipos_m[ log_index_m ] );
                }

                Debug_conditional( multithread_ativado, "<b><color=FF4747 >------------------------------</color></b>", "--" );

                return;
            
        }

        private static void Debug_conditional( bool _cond, string _message_1 = null, string _message_2 = null ){


                if( !!!( _cond ) )
                    { return; }

                if( _message_1 != null )
                    { Debug.Log( _message_1 ); }

                if( _message_2 != null )
                    { Debug.Log( _message_2 ); }

                return;

        }



        public static void Resetar(){

                // --- MAIN

                index_atual_main = 0;
                pointer_run_time = 0;
                logs_main = new string[ 5 ];
                logs_tipos_main = new Log_type[ 5 ]{ Log_type.warning,Log_type.warning, Log_type.warning, Log_type.warning,Log_type.warning };

                // --- MULTITHREAD

                index_atual_m = 0;
                pointer_run_time_m = 0;
                logs_m = new string[ 7 ];
                logs_tipos_m = new Log_type[ 7 ];

                return;

        }

}