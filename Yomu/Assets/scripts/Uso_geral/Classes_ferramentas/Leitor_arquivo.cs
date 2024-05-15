using System;
using System.IO;
using UnityEngine;



public static class Leitor_arquivo {





        public static byte[] Pegar_arquivo ( string _path ){

                byte[] byte_arr = System.IO.File.ReadAllBytes (  _path ); 
                return byte_arr;

        }


        public static byte[] Pegar_parte_de_arquivo ( string _path , int _byte_pointer_1,  int _byte_pointer_2  ){

                // com int aceita somente arquivos até 4gb


                if( _byte_pointer_1 < 0 || _byte_pointer_2 < 0 ||  _byte_pointer_1 < _byte_pointer_2 ){

                        throw new ArgumentException("pointer em leitor_arquivo vieram com problema. veio: " + _byte_pointer_1 + " e " + _byte_pointer_2);
                }


                bool arquivo_existe = System.IO.File.Exists( _path );
                if( !( arquivo_existe ) ){

                    Debug.LogError( "arquivo não foi encontrado no path: " + _path );
                    return null;

                }

                int byte_arr_length = ( _byte_pointer_2  - _byte_pointer_1 );

                byte[] byte_arr_retorno = new byte[ byte_arr_length ];

                FileStream file_stream = new FileStream(   _path , FileMode.Open ) ;

                file_stream.Read (  byte_arr_retorno , _byte_pointer_1  , byte_arr_length  ) ;

                return byte_arr_retorno;

        }

}


