using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;



public static class Console {


        public static bool multithread_ativado = false;

        // --- MAIN

        public static int index_atual_main;
        public static int pointer_run_time;
        public static string[] logs_main;
        public static Log_type[] logs_tipos_main;

        // --- MULTITHREAD

        public static int index_atual_m;
        public static int pointer_run_time_m;
        public static string[] logs_m;
        public static Log_type[] logs_tipos_m;


        public static int slow_value;
        public static int super_slow_value;
        public static void Log_slow( string _message ){ if( slow_value == 0 ){ Log_intern( _message, Log_type.normal, ( Thread.CurrentThread.Name == "Main" ) ); return; }  }
        public static void Log_super_slow( string _message ){ if( super_slow_value == 0 ){ super_slow_value++; Log_intern( _message, Log_type.normal, ( Thread.CurrentThread.Name == "Main" ) ); return; }  }
        public static void Log_TEST( object _message ){ _message = "<TESTE> " + _message; Log_intern( Convert.ToString(  _message ), Log_type.normal, ( Thread.CurrentThread.Name == "Main" ) ); return; }
        public static void Log( string _message ){ Log_intern( _message, Log_type.normal, ( Thread.CurrentThread.Name == "Main" ) ); return; }
        public static void Log( object _message ){ Log_intern( Convert.ToString(  _message ), Log_type.normal, ( Thread.CurrentThread.Name == "Main" ) ); return; }
        public static void LogError( string _message, int _trace_to_ignore = 0 ){ Log_intern( _message, Log_type.error, ( Thread.CurrentThread.Name == "Main" ), _trace_to_ignore ); return; }

        


        public static void Log_player_need_to_read( string _message ){ Log_intern( ( "PLAYER NEED TO READ: " + _message ), Log_type.normal, ( Thread.CurrentThread.Name == "Main" ) ); return;  }



        // sempre usar consts como flags para fazer optimização na build
        [ MethodImpl(MethodImplOptions.AggressiveInlining) ]
        public static void Log( bool _flag, string _message ){ if( _flag ){ Log( _message ); }; }

        [ MethodImpl(MethodImplOptions.AggressiveInlining) ]
        public static void Log( bool _flag, object _message ){ if( _flag ){ Log( _message ); }; }

        public static void Log( bool _activate, string _m_1, string _m_2 = "", string _m_3 = "", string _m_4 = "" ){ if( !!!( _activate ) ){ return; } Log_intern( ( _m_1 + _m_2 + _m_3 + _m_4 ), Log_type.normal, ( Thread.CurrentThread.Name == "Main" ) ); return; }

        public static void Clear(){

            Assembly asm = Assembly.GetAssembly( typeof( UnityEditor.Editor ) );
            asm.GetType( "UnityEditor.LogEntries" ).GetMethod( "Clear" ).Invoke( null, null );

        }

        public static void LogErrorException( string _message, string _path ){


                _message = $"<Size=13>{ _message }</Size>";

                string message_with_trace = $"{ _message }\n{ _path }";

                bool _main_thread = ( Thread.CurrentThread.Name == "Main" );
                Log_type _type = Log_type.error;
                

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

        private static SpinLock spinLock = default;

        private static void Log_intern( string _message, Log_type _type, bool _main_thread, int _trace_to_ignore = 0 ){

            bool good = false;
            spinLock.Enter( ref good );

            if( !!!( good ) )
                { CONTROLLER__errors.Throw( "no good" ); }

            try {

                if( _message == null )
                    { _message = "__NULL__"; }

                
                if( _message == "" )
                    { _message = "__EMPTY_STRING__"; }

                _message = $"<Size=13>{ _message }</Size>";

                
                string message_with_trace = Get_trace( _message, _trace_to_ignore );

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


            }
            finally{
                spinLock.Exit();
            }


            return;

        }


        public static string Get_trace( string _message, int _trace_to_ignore ){


                System.Diagnostics.StackFrame[] frames = ( new System.Diagnostics.StackTrace( true ) ).GetFrames();
                

                // ** na multithread aparentemente tem mais frames que o necessario. Confirmar pelo nome do arquivo, se for null considera como o final
                int numero_frames = 0;
                foreach( System.Diagnostics.StackFrame f in frames ){

                    if( f.GetFileName() != null )
                        { numero_frames++; }
                        else
                        { break; }

                }

                int margin_message = 1;
                int margin_lines = 20;
                int remove_log_frame = ( 3 + _trace_to_ignore );
                int message_with_link = 1; 

                string[] frames_stack = new string[ ( ( numero_frames - remove_log_frame ) + margin_message + margin_lines + message_with_link ) ];   

                string assets_path = System.IO.Directory.GetParent( Application.dataPath ).FullName;

                // --- MESSAGE 

                string file_name_primeiro = frames[ remove_log_frame ].GetFileName();       
                int linha_primeiro = frames[ remove_log_frame ].GetFileLineNumber();
                string path_primeiro = System.IO.Path.GetRelativePath( assets_path , file_name_primeiro ).Replace( "\\", "/" );

                int frame_stack = 0;
                frames_stack[ frame_stack++ ] = _message;
                frames_stack[ frame_stack++ ] =  $"<a href=\"{ path_primeiro }\" line=\"{ linha_primeiro }\">{ _message }</a>";

                    // --- STACK

                    for( int frame_id = ( remove_log_frame + 1 )  ; frame_id < numero_frames ; frame_id++ ){

                        System.Diagnostics.StackFrame s_frame = frames[ frame_id ];

                        string file_name = s_frame.GetFileName();             
                        string path = System.IO.Path.GetRelativePath( assets_path , file_name ).Replace( "\\", "/" );
                        
                        string className = s_frame.GetMethod().DeclaringType.Name;
                        string methodName = s_frame.GetMethod().Name;
                        int linha = s_frame.GetFileLineNumber();

                        frames_stack[ frame_stack++ ] = $"{className}:{methodName} () (at <a href=\"{path}\" line=\"{ linha }\">{ path }:{ linha }</a> )";

                    }

                for( int i = 0; i < 20 ;i++ )
                    { frames_stack[ ^( i + 1 ) ] = "---------------------------"; }

                return string.Join( "\n\r", frames_stack  );

        }


        private static void Log_unity( string _message, Log_type _type ){

            switch( _type ){

                case Log_type.normal: UnityEngine.Debug.Log( _message ); break;
                case Log_type.error: UnityEngine.Debug.LogError( _message ); break;

            }

        }


        public static void Update(){

                
                slow_value = ( slow_value + 1 ) % 60;
                super_slow_value = ( super_slow_value + 1 ) % 1_000;

                // ** Console.Update é o unico update que nao precisa do Control_flow
                
                if( pointer_run_time == index_atual_main && pointer_run_time_m == index_atual_m )
                        { return; }

                //UnityEngine.Debug.Log( "" );
                Debug_conditional( multithread_ativado, "<b><color=lime>---------- MAIN -------------</color></b>" );
                


                int starter_point = pointer_run_time;
                pointer_run_time = index_atual_main;

                for( int log_index = starter_point; log_index < index_atual_main ; log_index++ ){

                        if( logs_main[ log_index ] == null )
                            { break; }
                        
                        Log_unity( logs_main[ log_index ], logs_tipos_main[ log_index ] );

                }

                Debug_conditional( multithread_ativado, "<b><color=lime>------------------------------</color></b>", "<b><color=FF4747 >---------- MULTI -------------</color></b>" );
                //Debug_conditional( multithread_ativado, "<b><color=FF4747 >---------- MULTI -------------</color></b>" );

                int starter_point_m = pointer_run_time_m;
                pointer_run_time_m = index_atual_m;

                for( int log_index_m = starter_point_m; log_index_m < index_atual_m ; log_index_m++ ){

                        if( logs_m[ log_index_m ] == null )
                            { break; }
                        
                        Log_unity( logs_m[ log_index_m ], logs_tipos_m[ log_index_m ] );
                }

                Debug_conditional( multithread_ativado, "<b><color=FF4747 >------------------------------</color></b>" );

                return;
            
        }

        private static void Debug_conditional( bool _cond, string _message_1 = null, string _message_2 = null ){


                if( !!!( _cond ) )
                    { return; }

                if( _message_1 != null )
                    { UnityEngine.Debug.Log( $"<Size=14>{ _message_1 }</Size>"); }

                if( _message_2 != null )
                    { UnityEngine.Debug.Log( $"<Size=14>{ _message_2 }</Size>"); }

                return;

        }



        public static void Start(){

                // UnityEngine.Debug.Log( "vai dar start" );
                
                // --- MAIN

                index_atual_main = 0;
                pointer_run_time = 0;
                logs_main = new string[ 1_000 ];
                logs_tipos_main = new Log_type[ 1_000 ];

                // --- MULTITHREAD

                index_atual_m = 0;
                pointer_run_time_m = 0;
                logs_m = new string[ 1_000 ];
                logs_tipos_m = new Log_type[ 1_000 ];

                return;

        }

}