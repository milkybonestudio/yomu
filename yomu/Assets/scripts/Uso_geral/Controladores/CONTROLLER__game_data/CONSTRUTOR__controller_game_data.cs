//using System.Drawing.Imaging;
using System.Drawing;
using System.IO;


unsafe public static class CONSTRUCTOR__controller_game_data {



        public static byte* b_p;
        public static byte[] b_arr_s = new byte[ 100 ];

        public static CONTROLLER__game_data Construir( INTERFACE__bloco[] _blocos ){

            CONTROLLER__game_data controlador = new CONTROLLER__game_data();
            CONTROLLER__game_data.instancia = controlador;

                controlador.blocos = _blocos;
                
                
                byte[] b_arr = System.IO.File.ReadAllBytes( "path" );
                
                fixed( byte* data_pointer_origin = b_arr_s ){

                    b_p = data_pointer_origin;

                    fixed( Game_current_state* game_current_state_pointer = &(controlador.game_current_state) ){

                        TOOLS__pointers_data_transfer.Transfer  (  
                                                                    ( byte* ) data_pointer_origin, 
                                                                    ( byte* ) game_current_state_pointer,
                                                                    sizeof( Game_current_state )
                                                                );


                    }
                    
                }


                fixed( byte* b_p_2 = b_arr_s ){



                }

                


            return controlador;

        }


}