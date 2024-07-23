using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

using System.Reflection;


public static class Geral {
    



                public static int trava_i= 0;
                public static void Trava(){  


                    trava_i++;
                    //Debug.Log("tava_atual: " + trava_i);

                    if(trava_i > 5_000){ 

                            throw new ArgumentException("passou do limite");

                    }
                        
                }






            public static int n = 0;
            public static bool foi_setado = false;
            public static void erro( int _n ){


                if( _n == -1) { 

                    throw new ArgumentException("a");
                    Debug.LogError("a");
                    return;


                }

                if( ! foi_setado){

                    foi_setado = true;
                    n = _n;
                    return;

                }

                n--;
                if(n > 0) return;

                //Debug.LogError("a");
                throw new ArgumentException("a");

            }


            public static void Salvar_string( string _text , int n = -1 ){

                    string path_dir = System.IO.Directory.GetCurrentDirectory();

                    string path_para_salvar = path_dir + "\\Assets\\scripts\\Main\\";

                    

                    string path_final = path_para_salvar + "texto_para_verificar.txt";

                    if(System.IO.File.Exists( path_final )) System.IO.File.Delete( path_final );

                  //  foreach( char ch in _text ) Debug.Log("|" + ( (int)ch));

                    

                    System.IO.File.WriteAllText( path_final ,("texto:\r\n" +   _text) );

                    erro( n );


            }



            public static void Salvar_string( char[] _text_c , int n = -1 ){

                    string _text = new string (_text_c );

                    string path_dir = System.IO.Directory.GetCurrentDirectory();

                    string path_para_salvar = path_dir + "\\Assets\\scripts\\Main\\";

                    

                    string path_final = path_para_salvar + "texto_para_verificar.txt";

                    if(System.IO.File.Exists( path_final )) System.IO.File.Delete( path_final );

                    

                    System.IO.File.WriteAllText( path_final ,("texto:\r\n" +   _text) );
                    erro( n );


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
                    erro( n );


            }

            public static void Salvar_byte_array( byte[] _bytes , int n = -1 ){

                    
                    string path_dir = System.IO.Directory.GetCurrentDirectory();

                    string path_para_salvar = path_dir + "\\Assets\\scripts\\Main\\";

                    
                    string path_final = path_para_salvar + "texto_para_verificar.txt";

                    if(System.IO.File.Exists( path_final )) {System.IO.File.Delete( path_final );}



                    

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

                    string path_para_salvar = path_dir + "\\Assets\\scripts\\Main\\";

                    
                    string path_final = path_para_salvar + "texto_para_verificar.txt";

                    if(System.IO.File.Exists( path_final )) {System.IO.File.Delete( path_final );}



                    

                    
                    string[] str_arr = new string[ _bytes.Length + 1 ];
                     str_arr[ 0 ] = "texto:";


                    for( int k = 0 ; k < _bytes.Length ;k++ ){

                        str_arr[ k + 1 ] = _bytes[ k ].ToString();
                        

                    }

                    System.IO.File.WriteAllLines( path_final ,  str_arr );
                    


            }









        public static void ClearLog() {

            // Assembly assembly = Assembly.GetAssembly (typeof(SceneView));
            // Type logEntries = assembly.GetType ("UnityEditor.LogEntries");
            // MethodInfo clearConsoleMethod = logEntries.GetMethod ("Clear");
            // clearConsoleMethod.Invoke (new object (), null);

        }




    

}



 


































    public static class  console {

         public static int count_update_slow = 0;
          
         public static void log (string _txt, int _type = 0){

            count_update_slow = (count_update_slow+1)%16  ;

            if(  _type == 0    &&  count_update_slow == 0) Debug.Log(_txt);
            if(  _type == 1    && ( count_update_slow == 0  ||   count_update_slow == 8)) Debug.Log(_txt);
            if(  _type == 2    && ( count_update_slow == 0  ||   count_update_slow == 5  || count_update_slow == 10      )) Debug.Log(_txt);

            return;
               
         }


  }


