using UnityEngine;



public static class Construtor_controlador_development{

        public static CONTROLLER__development Construir(){

                CONTROLLER__development controlador = new CONTROLLER__development();
                CONTROLLER__development.instancia = controlador;


                    controlador.program = Program.instancia;

                    controlador.bloqueado_por_ferramenta = false;
                    controlador.ferramenta_atual = Ferramenta_desenvolvimento.nada;
                    controlador.tools = new NODE_DEVELOPEMENT_TOOLs[ ( int ) Block_type.END, 10 ];
                    controlador.tools_game_object = GameObject.Find( "Screen/System_UI/Tools" ).transform.gameObject;

                    //  --- MODO TESTE ATUAL

                    controlador.desenvolvimento_atual = Desenvolvimento_atual.interacao;
                    controlador.teste_development_atual = new Teste_development(); // => nada
                    controlador.chave_teste = "generico";

                    

                return controlador;

            
        }

}