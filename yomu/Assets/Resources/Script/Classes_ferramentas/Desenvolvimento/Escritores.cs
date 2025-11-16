
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

using System.Reflection;


unsafe public static class Escritores {
    


        public static void Salvar_string( string _text , int n = -1 ){

                string path_dir = System.IO.Directory.GetCurrentDirectory();

                string path_para_salvar = path_dir + "\\Assets\\scripts\\Main\\";

                string path_final = path_para_salvar + "texto_para_verificar.txt";

                if(System.IO.File.Exists( path_final )) 
                    {System.IO.File.Delete( path_final );}

                
                System.IO.File.WriteAllText( path_final ,("texto:\r\n" +   _text) );

                System.Diagnostics.Process.Start( path_final );
                throw new Exception( );

        }



        public static void Salvar_string( char[] _text_c , int n = -1 ){

                string _text = new string (_text_c );

                string path_dir = System.IO.Directory.GetCurrentDirectory();

                string path_para_salvar = path_dir + "\\Assets\\scripts\\Main\\";

                

                string path_final = path_para_salvar + "texto_para_verificar.txt";

                if(System.IO.File.Exists( path_final )) System.IO.File.Delete( path_final );

                

                System.IO.File.WriteAllText( path_final ,("texto:\r\n" +   _text) );

                System.Diagnostics.Process.Start( path_final );
                throw new Exception( );
                


        }



        public static void Salvar_string( string[] _text , int n = -1 ){

                
                string path_dir = System.IO.Directory.GetCurrentDirectory();

                string path_para_salvar = path_dir + "\\Assets\\scripts\\Main\\";

                
                string path_final = path_para_salvar + "texto_para_verificar.txt";

                if(System.IO.File.Exists( path_final )) System.IO.File.Delete( path_final );

                

                string[] t = new string[_text.Length + 1 ];

                for( int i = 0  ; i < _text.Length ;i++ ){
                    t[ i + 1 ] = _text[ i ];
                }

                t[ 0 ] = "texto:";

                

                //System.IO.File.WriteAllLines( path_final ,( t) );
                System.IO.File.WriteAllLines( path_final ,  t );

                System.Diagnostics.Process.Start( path_final );
                throw new Exception( );
    


        }

        public static void Salvar_byte_array( byte[] _bytes , int n = -1, string path_final = null ){


                if( path_final == null )
                    { path_final = $"{ System.IO.Directory.GetCurrentDirectory() }\\Assets\\Editor\\texto_para_verificar.txt"; }
                

                if( System.IO.File.Exists( path_final ) ) 
                    { System.IO.File.Delete( path_final );}
                

                char[] t = new char[_bytes.Length ];
                string[] str_arr = new string[ _bytes.Length + 1 ];

                for( int k = 0 ; k < _bytes.Length ;k++ ){

                    str_arr[ k + 1 ] = _bytes[ k ].ToString();
                    

                }

                    str_arr[ 0 ] = "texto:";

                for( int i = 0  ; i < _bytes.Length ;i++ ){

                    t[ i ] = ( char ) _bytes[ i ] ;
                }





                string texto_final = "texto: \n\r"   + new string( t );

                

                //System.IO.File.WriteAllLines( path_final ,( t) );
                System.IO.File.WriteAllLines( path_final ,  str_arr );

                


        }


        public static void Salvar_int_array( int[] _bytes , int n = -1 ){

                
                string path_dir = System.IO.Directory.GetCurrentDirectory();

                string path_para_salvar = path_dir + "\\Assets\\Editor\\";

                
                string path_final = path_para_salvar + "a.txt";

                if(System.IO.File.Exists( path_final )) {System.IO.File.Delete( path_final );}



                

                
                string[] str_arr = new string[ _bytes.Length + 1 ];
                    str_arr[ 0 ] = "texto:";


                for( int k = 0 ; k < _bytes.Length ;k++ ){

                    str_arr[ k + 1 ] = _bytes[ k ].ToString();
                    

                }

                System.IO.File.WriteAllLines( path_final ,  str_arr );

                // System.Diagnostics.Process.Start( path_final );
                // throw new Exception( );
                


        }

        public static void Salvar_pointer( void* _pointer, int _length, string path_final ){

                byte[] _bytes = new byte[ _length ];

                Files.Transfer_data( _pointer, _bytes );

                if( System.IO.File.Exists( path_final ) ) 
                    { System.IO.File.Delete( path_final );}
                

                char[] t = new char[_bytes.Length ];
                string[] str_arr = new string[ _bytes.Length + 1 ];

                for( int k = 0 ; k < _bytes.Length ;k++ ){

                    str_arr[ k + 1 ] = _bytes[ k ].ToString();
                    

                }

                    str_arr[ 0 ] = "texto:";

                for( int i = 0  ; i < _bytes.Length ;i++ ){

                    t[ i ] = ( char ) _bytes[ i ] ;
                }





                string texto_final = "texto: \n\r"   + new string( t );

                

                //System.IO.File.WriteAllLines( path_final ,( t) );
                System.IO.File.WriteAllLines( path_final ,  str_arr );





        }

        









        public static void ClearLog() {

            // Assembly assembly = Assembly.GetAssembly (typeof(SceneView));
            // Type logEntries = assembly.GetType ("UnityEditor.LogEntries");
            // MethodInfo clearConsoleMethod = logEntries.GetMethod ("Clear");
            // clearConsoleMethod.Invoke (new object (), null);

        }




    

}
