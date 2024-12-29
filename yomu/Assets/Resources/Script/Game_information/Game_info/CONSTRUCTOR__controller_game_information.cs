using UnityEngine;

public static class CONSTRUCTOR__controller_game_information {


        public static CONTROLLER__application_information Construir(){

            CONTROLLER__application_information controlador = new CONTROLLER__application_information();
            CONTROLLER__application_information.instance = controlador;

            return controlador;

        }


}

