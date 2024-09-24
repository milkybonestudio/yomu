using UnityEngine;

public static class CONSTRUCTOR__controller_configurations {


        public static CONTROLLER__configurations Construct(){

            CONTROLLER__configurations controlador = new CONTROLLER__configurations();
            CONTROLLER__configurations.instancia = controlador;


            return controlador;

        }


}

