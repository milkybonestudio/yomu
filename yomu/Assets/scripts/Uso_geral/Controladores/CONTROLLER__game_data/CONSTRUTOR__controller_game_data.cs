


public unsafe struct teste {

    public byte* byte_p;
    public Game_current_state* game_state;

}



unsafe public static class CONSTRUCTOR__controller_game_data {


        public static CONTROLLER__game_data Construir( INTERFACE__bloco[] _blocos ){

            CONTROLLER__game_data controlador = new CONTROLLER__game_data();
            CONTROLLER__game_data.instancia = controlador;

                controlador.blocos = _blocos;

                // --- 
                byte[] game_current_state_bytes_arr = System.IO.File.ReadAllBytes( "path" );

                controlador.game_current_state = new Game_current_state();
                
                fixed( byte* data_pointer_origin = game_current_state_bytes_arr ){


                        fixed( Game_current_state* game_current_state_pointer = &(controlador.game_current_state) ){

                                teste t = new teste();
                                t.game_state = game_current_state_pointer;

                                int* data_pointer_int_1 = ( int* ) data_pointer_origin + 0;
                                int* data_pointer_int_2 = ( int* ) data_pointer_origin + 1;
                                int* data_pointer_int_3 = ( int* ) data_pointer_origin + 2;
                                int* data_pointer_int_4 = ( int* ) data_pointer_origin + 3;

                                int* game_current_state_byte_pointer_int_1 = ( int* ) game_current_state_pointer + 0;
                                int* game_current_state_byte_pointer_int_2 = ( int* ) game_current_state_pointer + 1;
                                int* game_current_state_byte_pointer_int_3 = ( int* ) game_current_state_pointer + 2;
                                int* game_current_state_byte_pointer_int_4 = ( int* ) game_current_state_pointer + 3;


                                int numero_ciclos_multiplos_4_ints = ( sizeof( Game_current_state ) / (sizeof( int ) * 4 ) );
                                

                                for( int index = 0 ; index < numero_ciclos_multiplos_4_ints ; index++ ){


                                        // -- passar dados
                                        *data_pointer_int_1 = *game_current_state_byte_pointer_int_1;
                                        *data_pointer_int_2 = *game_current_state_byte_pointer_int_2;
                                        *data_pointer_int_3 = *game_current_state_byte_pointer_int_3;
                                        *data_pointer_int_4 = *game_current_state_byte_pointer_int_4;



                                        // --- arrumar pointers
                                        data_pointer_int_1 += 0;
                                        data_pointer_int_2 += 1;
                                        data_pointer_int_3 += 2;
                                        data_pointer_int_4 += 3;

                                        game_current_state_byte_pointer_int_1 += 0;
                                        game_current_state_byte_pointer_int_2 += 1;
                                        game_current_state_byte_pointer_int_3 += 2;
                                        game_current_state_byte_pointer_int_4 += 3;

                                        continue;

                                }

                                int numero_de_bytes_carregados = numero_ciclos_multiplos_4_ints * (sizeof( int ) * 4 );

                                byte* data_pointer_resto = ( data_pointer_origin + numero_de_bytes_carregados );
                                byte* game_current_state_byte_pointer_resto = ( ( byte* ) game_current_state_pointer + numero_de_bytes_carregados );

                                for( int index_ultimo_loop = numero_de_bytes_carregados ; index_ultimo_loop < sizeof( Game_current_state ) ; index_ultimo_loop++ ){

                                        *game_current_state_byte_pointer_resto = *data_pointer_resto;
                                        data_pointer_resto++;
                                        game_current_state_byte_pointer_resto++;
                                        continue;

                                }


                                // ** resto


                        }


                }

                


            return controlador;

        }


}