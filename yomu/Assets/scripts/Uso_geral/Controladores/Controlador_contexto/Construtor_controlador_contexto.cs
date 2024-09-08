using UnityEngine;

public static class Construtor_controlador_contexto {


        public static Controlador_contexto Construir(){

            Controlador_contexto controlador = new Controlador_contexto();
            Controlador_contexto.instancia = controlador;



            return controlador;

        }


}

