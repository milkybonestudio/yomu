
                    
public static class CONSTRUCTOR__controller_game_data {


        public static CONTROLLER__game_data Construir( INTERFACE__bloco[] _blocos ){

            CONTROLLER__game_data controlador = new CONTROLLER__game_data();
            CONTROLLER__game_data.instancia = controlador;

                controlador.blocos = _blocos;


            return controlador;

        }


}