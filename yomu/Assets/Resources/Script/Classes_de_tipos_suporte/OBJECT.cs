



public static class OBJECT {


        public static void Aumentar_length_array( ref System.Object[] _arr , int numero_para_aumentar ){


            int numero_antigo = _arr.Length ;
            int novo_numero = ( numero_antigo + numero_para_aumentar );
            System.Object[] novo_array = new System.Object[ novo_numero ];

            for( int index =0 ; index < numero_antigo ; index++ ){

                    novo_array [ index ] = _arr[ index ];

            }

            _arr = novo_array;


    }



}