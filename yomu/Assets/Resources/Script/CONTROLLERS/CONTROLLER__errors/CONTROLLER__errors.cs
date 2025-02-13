using System;
using System.Runtime.CompilerServices;
using System.Threading;


public class CONTROLLER__errors {


        [MethodImpl( MethodImplOptions.NoInlining )]
        public static int Throw( string _message ){ Get_instance().Throw_intern( _message ); return -1; }

        // public static void Verify( bool _bool , string _message ){ if( _bool ){ instance.Throw_intern( _message ); } }

        public static void Throw_exception( Exception _exp ){ Get_instance().Throw_exception_internal( _exp ); }

        public static CONTROLLER__errors instance;
        public static CONTROLLER__errors Get_instance(){ return instance; }

        public bool is_checking_pointer_length = true;
        public bool is_checking_dll_data = true;


        public static string exception_trace_multithread;

        private void Throw_intern( string _message ){


                CONTROLLER__tasks.Pegar_instancia().modulo_multithread.Matar_thread();
                Console.Update();
                // ** garante 

                throw new Exception( _message );

        }

        public void Check_pointer_length( bool _check, string _message ){

            if( is_checking_pointer_length && _check )
                {
                    // ** fazer depois 
                    throw new System.Exception( "Error: " + _message );
                }

        }

        public void Check_dll_data( bool _check, string _message ){

            if( is_checking_dll_data && _check )
                {
                    // ** fazer depois 
                    throw new System.Exception( "Error: " + _message );
                }

        }

        private void Throw_exception_internal( Exception _exp  ){

            
            string[] pre = _exp.StackTrace.Split( "\n" );
            string final_line  = ( pre.Length == 2 )? ( pre[ 1 ].Split( " in " )[ 1 ] ) : ( pre[ 0 ].Split( " in " )[ 1 ] ) ;
            
            string[] file_and_line = final_line.Replace( ".cs:", ".cs>>>" ).Split( ">>>" );

        
            if( file_and_line.Length == 2 )
                {
                    Console.LogErrorException( _exp.Message , $"<a href=\"{ file_and_line[ 0 ] }\" line=\"{ file_and_line[ 1 ] }\">{ _exp.Message }</a>" );
                    Console.Update();
                }
            
            throw _exp;

        }


}

