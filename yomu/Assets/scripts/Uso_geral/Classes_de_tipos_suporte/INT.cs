


public static class INT {



    public static bool Tem_valor_no_array( int[] _arr , int _valor ){

            for(  int i = 0 ;  i < _arr.Length ; i++ ){

                if( _arr[ i ] == _valor ) return true;

            }

            return false;

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





}