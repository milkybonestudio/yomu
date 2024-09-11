using UnityEngine;

public static class Construtor_controlador_transicao {

        public static CONTROLLER__transition Construir(){

                CONTROLLER__transition controlador = new CONTROLLER__transition();
                CONTROLLER__transition.instancia = controlador;

                    controlador.canvas = GameObject.Find("");

                return controlador;

        }


}

