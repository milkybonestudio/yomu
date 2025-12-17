using UnityEngine;

public static class Construtor_controlador_transicao {

        public static CONTROLLER__game_transition Construir(){

                CONTROLLER__game_transition controlador = new CONTROLLER__game_transition();
                CONTROLLER__game_transition.instancia = controlador;

                    controlador.canvas = GameObject.Find("");

                return controlador;

        }


}

