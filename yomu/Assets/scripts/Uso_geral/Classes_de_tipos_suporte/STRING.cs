


public static class  STRING {




        public static string[] Aumentar_length_array( string[] _array , int quantidade_para_adicionar = 5 ){


                int length_atual = _array.Length;
                int novo_length = ( length_atual + quantidade_para_adicionar ) ;

                string[] novo_array = new string[ novo_length ];

                for( int i = 0; i < _array.Length ; i++ ){

                        novo_array[ i ] = _array[ i ];

                }

                return novo_array;

                

        }


        public static bool Verificar_se_array_2d_esta_preenchido_corretamente( string[] _arr, int _length ){

                if( _arr.Length != _length )
                        { return false; }

                for( int string_index = 0 ; string_index < _arr.Length ; string_index++ ){

                        string string_para_verificar = _arr[ string_index ];

                        if( string_para_verificar == null || string_para_verificar == "" )
                                { return false; }
                        

                }

                return true;



        }



        public static string[] Deixar_somente_a_primeira_letra_maiuscula_array( string[] _array ){

                string[] retorno = new string[ _array.Length ];

                for( int elemento_index = 0 ; elemento_index < _array.Length ; elemento_index++ ){

                        retorno[ elemento_index ] = Deixar_somente_a_primeira_letra_maiuscula( _array[ elemento_index ] );

                }


                return retorno;

        }



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