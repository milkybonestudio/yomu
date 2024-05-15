




public static class BOOL {

        public static int Pegar_index_true( bool[] _arr ){

            for( int index = 0 ; index < _arr.Length ; index++ ){

                if( _arr[ index ] == true ) { return index; }

            }

            return -1;

        }


        
        public static int Pegar_index_false( bool[] _arr ){

            for( int index = 0 ; index < _arr.Length ; index++ ){

                if( _arr[ index ] == false ) { return index; }

            }

            return -1;

        }



        public static void Aumentar_length_array( ref bool[] _arr , int numero_para_aumentar ){


                int numero_antigo = _arr.Length ;
                int novo_numero = ( numero_antigo + numero_para_aumentar );
                bool[] novo_array = new bool[ novo_numero ];

                for( int index =0 ; index < numero_antigo ; index++ ){

                        novo_array [ index ] = _arr[ index ];

                }

                _arr = novo_array;


        }





}