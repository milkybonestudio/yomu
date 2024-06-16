


public static class INT {
        

        public static int Length_elementos_maiores_que_0 (  int[] _arr  ){

                        int length = 0 ;
                        for( int i = 0 ; i < _arr.Length ; i++ ){
                                if( _arr[ i ] > 0 )
                                        { length++; }
                                continue;
                        }

                        return length;
                        

        }


        public static bool Tem_valor_no_array( int[] _arr , int _valor ){

                for(  int i = 0 ;  i < _arr.Length ; i++ ){

                        if( _arr[ i ] == _valor ) return true;

                }

                return false;

        }


        public static int Pegar_index_valor( int[] _arr , int _valor ){

                for(  int i = 0 ;  i < _arr.Length ; i++ ){

                        if( _arr[ i ] == _valor ) 
                                {return i;}

                }

                return -1;

        }



        public static void Trocar_valor ( int[] _arr , int _valor_para_trocar , int _novo_valor ){

                for(  int i = 0 ;  i < _arr.Length ; i++ ){

                        if( _arr[ i ] == _valor_para_trocar ) { _arr[ i ] = _novo_valor ; return ;}

                }

                return;

        }


        public static int[] Aumentar_length_array( int[] _array , int quantidade_para_adicionar = 5 ){


                int length_atual = _array.Length;
                int novo_length = ( length_atual + quantidade_para_adicionar ) ;

                int[] novo_array = new int[ novo_length ];

                for( int i = 0; i < _array.Length ; i++ ){

                        novo_array[ i ] = _array[ i ];

                }

                return novo_array;

                

        }


        public static int Acrescentar_valor_COMPLETO_GARANTIDO( ref int[] arr , int _valor ){

                int[] novo_arr = new int[ arr.Length + 1 ];
                int index = 0;

                for( index = 0 ; index < arr.Length ; index++ ){

                        novo_arr[ index ] = arr[ index ];

                }

                novo_arr[ arr.Length ] = _valor;
                arr = novo_arr;

                return index;



        }

        public static void Tirar_valor_COMPLETO_GARANTIDO( ref int[] arr , int _valor ){

                int[] novo_arr = new int[ arr.Length - 1  ];

                for( int index = 0 ; index < arr.Length ; index++ ){

                        if( arr[ index ] == _valor)
                                { continue; }
                        novo_arr[ index ] = arr[ index ];

                }

                novo_arr[ arr.Length ] = _valor;
                arr = novo_arr;
                
                return;



        }


        public static void Trocar_valor_no_array( int[] _array, int _valor_para_trocart, int _novo_valor ){

                

        }




}