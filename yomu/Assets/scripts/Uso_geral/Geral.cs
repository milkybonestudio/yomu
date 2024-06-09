using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

using System.Reflection;






public static class Geral {




            public static void Ler_todos( string[] _str_arr){

                for(  int i = 0 ;  i < _str_arr.Length  ;i++ ){

                    Debug.Log("item " + i + ": " + _str_arr[ i ]);

                }

            }

            public static void Ler_todos( char[] _char_arr){

                for(  int i = 0 ;  i < _char_arr.Length  ;i++ ){

                    Debug.Log("item " + i + ": " + ( ( int ) _char_arr[ i ]));

                }

            }




    

    public static string  Transformar_path_em_nome( string _path){

        string nome_com_ponto = System.IO.Path.GetFileName(_path);
        string nome_sem_ponto = nome_com_ponto.Split(".")[0];
        return nome_sem_ponto;

    }



    public static Image ultima_imagem;

    public static GameObject Criar_imagem(  string _nome,  GameObject _pai , float _width = 1920f, float _height = 1080f , string _path_imagem = null, float _alpha = 0f  ){


        GameObject novo_game_object = new GameObject(_nome);
        novo_game_object.transform.SetParent( _pai.transform , false);
        

        Image imagem = novo_game_object.AddComponent<Image>();
        imagem.color = new Color(1f,1f,1f, _alpha );

        if(_path_imagem != null){
            
            Sprite sprite = Resources.Load<Sprite>(_path_imagem);
            if(sprite == null) throw new ArgumentException("nao foi achado imagem no path : " + _path_imagem );
            imagem.sprite = sprite;

        }

        ultima_imagem = imagem;

        RectTransform rect = novo_game_object.GetComponent<RectTransform>();

        rect.SetSizeWithCurrentAnchors( RectTransform.Axis.Horizontal, _width);
        rect.SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, _height);

        return novo_game_object;


    }


    public static void Resize(GameObject _game_object, float _width = 1920f, float _height = 1080f){

        RectTransform rect = _game_object.GetComponent<RectTransform>();
        rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, _width);
        rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, _height);


    }






    public static string  Int_arr_to_string(  int[] _arr ){


                    string[] a = new string[ ( _arr.Length * 2 ) - 1 ];

                    for( int  i = 0 ;  i < _arr.Length  ;i++ ){

                            a[ (i * 2 ) ] = Convert.ToString( _arr[ i ] );

                            if( (i * 2 ) == (a.Length - 1) )  break;

                            a[ (i * 2 ) + 1 ] = ",";

                    }

                    string retorno = string.Concat(a);
                    Debug.Log("A: " + retorno);

                    return retorno;



                }



                public static int trava_i= 0;
                public static void Trava(){  


                    trava_i++;
                    //Debug.Log("tava_atual: " + trava_i);

                    if(trava_i > 100_000){ 

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


