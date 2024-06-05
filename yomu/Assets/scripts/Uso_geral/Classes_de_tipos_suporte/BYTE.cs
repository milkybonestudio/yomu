







public static class BYTE {


        
        public static byte[] Aumentar_length_array( byte[] _arr , int numero_para_aumentar ){


                int numero_antigo = _arr.Length ;
                int novo_numero = ( numero_antigo + numero_para_aumentar );
                byte[] novo_array = new byte[ novo_numero ];

                for( int index =0 ; index < numero_antigo ; index++ ){

                        novo_array [ index ] = _arr[ index ];

                }

                return novo_array;


        }

        public static byte[][] Aumentar_length_array_2d(  byte[][] _arr , int numero_para_aumentar ){


                int numero_antigo = _arr.Length ;
                int novo_numero = ( numero_antigo + numero_para_aumentar );
                byte[][] novo_array = new byte[ novo_numero ][];

                for( int index =0 ; index < numero_antigo ; index++ ){

                        novo_array [ index ] = _arr[ index ];

                }

                return novo_array;


        }






}