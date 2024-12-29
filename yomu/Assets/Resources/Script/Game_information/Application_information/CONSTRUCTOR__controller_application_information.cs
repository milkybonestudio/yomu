using UnityEngine;

public static class CONSTRUCTOR__controller_application_information {


        public static CONTROLLER__application_information Construir(){

            CONTROLLER__application_information controlador = new CONTROLLER__application_information();
            CONTROLLER__application_information.instance = controlador;

            controlador.device =  SystemInfo.deviceType;



            return controlador;

        }


}

