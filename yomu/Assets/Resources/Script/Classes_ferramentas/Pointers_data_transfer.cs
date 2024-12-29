

unsafe public static class Pointers_data_transfer {


    // ** assume que quem invocar a funcao colocou o pointer em fixed()
    public static void Transfer( byte* _pointer_destino, byte* _pointer_dados, int _length  ){


            if( _length < 16 )
                { Simple_transfer( _pointer_destino,  _pointer_dados, _length ); return; }


            int* pointer_destino_origem = ( int* ) _pointer_destino;
            int* pointer_destino_1 = ( pointer_destino_origem + 0 ) - 4 ;
            int* pointer_destino_2 = ( pointer_destino_origem + 1 ) - 4 ;
            int* pointer_destino_3 = ( pointer_destino_origem + 2 ) - 4 ;
            int* pointer_destino_4 = ( pointer_destino_origem + 3 ) - 4 ;
            
            int* _pointer_dados_origem = ( int* ) _pointer_dados;
            int* _pointer_dados_1 = ( _pointer_dados_origem + 0 ) - 4 ;
            int* _pointer_dados_2 = ( _pointer_dados_origem + 1 ) - 4 ;
            int* _pointer_dados_3 = ( _pointer_dados_origem + 2 ) - 4 ;
            int* _pointer_dados_4 = ( _pointer_dados_origem + 3 ) - 4 ;


            int length_com_4_X_4 = _length / ( sizeof( int ) * 4 );



            for( int index = 0 ; index < length_com_4_X_4 ; index += 4 ){


                    _pointer_dados_1 += 4;
                    _pointer_dados_2 += 4;
                    _pointer_dados_3 += 4;
                    _pointer_dados_4 += 4;


                    pointer_destino_1 += 4;
                    pointer_destino_2 += 4;
                    pointer_destino_3 += 4;
                    pointer_destino_4 += 4;

                    
                    *pointer_destino_1 = *_pointer_dados_1 ;
                    *pointer_destino_2 = *_pointer_dados_2 ;
                    *pointer_destino_3 = *_pointer_dados_3 ;
                    *pointer_destino_4 = *_pointer_dados_4 ;

                    continue;

            }


            // ** termina de transferir o resto
            int resto_em_bytes = _length %  ( sizeof( int ) * 4 );

            int numero_bytes_passados = length_com_4_X_4 * ( sizeof( int ) * 4 );

            // --- AJUSTA BYTES
            _pointer_destino += numero_bytes_passados;
            _pointer_dados +=  numero_bytes_passados;

            Simple_transfer( _pointer_destino,  _pointer_dados, resto_em_bytes );

            return;


    }

    private static void Simple_transfer( byte* _pointer_destino, byte* _pointer_dados, int _length  ){


            for( int index = 0 ; index < _length ; index ++ ){

                    *_pointer_destino = *_pointer_dados;
                    _pointer_destino++;
                    _pointer_dados++;
                    continue;
            }

            return;

    }

}