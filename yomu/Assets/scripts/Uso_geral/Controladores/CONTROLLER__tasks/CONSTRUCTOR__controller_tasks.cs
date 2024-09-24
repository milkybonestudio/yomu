using UnityEngine;

public static class CONSTRUCTOR__controller_tasks {


        public static CONTROLLER__tasks Construct(){

            CONTROLLER__tasks controlador = new CONTROLLER__tasks();
            CONTROLLER__tasks.instancia = controlador;



            return controlador;

        }


}

