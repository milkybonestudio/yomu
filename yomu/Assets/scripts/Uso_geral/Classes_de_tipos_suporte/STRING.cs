


public static class  STRING {



        public static string Deixar_somente_a_primeira_letra_maiuscula( string _string ){


                char[] char_array = _string.ToCharArray();
                char_array[ 0 ] = char.ToUpper( char_array[ 0 ] );

                for( int i = 1 ; i < char_array.Length ; i++ ){

                        char_array[ i ] = char.ToLower( char_array[ i ] );

                }

                string retorno = new string( char_array );

                return retorno;

        }


        public static int Pegar_index_null ( string[] _arr ){


                for( int index = 0 ; index < _arr.Length; index++ ){

                        if( _arr[ index ] == null ) { return index; }

                }

                return -1;

        }


        public static int Pegar_index_valor( string[]_arr , string _valor ){


                for( int index =0 ; index < _arr.Length; index++ ){

                        if( _arr[ index ] == _valor ) { return index; }

                }

                return -1;

        }

        public static void Aumentar_length_array( ref string[] _arr , int numero_para_aumentar ){


                int numero_antigo = _arr.Length ;
                int novo_numero = ( numero_antigo + numero_para_aumentar );
                string[] novo_array = new string[ novo_numero ];

                for( int index =0 ; index < numero_antigo ; index++ ){

                        novo_array [ index ] = _arr[ index ];

                }

                _arr = novo_array;


        }

        public static void Aumentar_length_array_2d ( ref string[][] _arr , int numero_para_aumentar ){


                int numero_antigo = _arr.Length ;
                int novo_numero = ( numero_antigo + numero_para_aumentar );
                string[][] novo_array = new string[ novo_numero ][];

                for( int index =0 ; index < numero_antigo ; index++ ){

                        novo_array [ index ] = _arr[ index ];

                }

                _arr = novo_array;


        }


}