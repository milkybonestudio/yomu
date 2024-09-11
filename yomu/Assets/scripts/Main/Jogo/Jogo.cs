using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;



public class Jogo { 


        public static Jogo instancia;
        public static Jogo Pegar_instancia(){ if( instancia == null ){ throw new Exception("tentou pegar Jogo mas estava null"); } return instancia; }

        public INTERFACE__bloco[] interfaces_blocos;

        // --- CONTROLADORES
        public Controlador_armazenamento_disco controlador_armazenamento_disco;
        public Controlador_sistema controlador_sistema;
        public Controlador_AI controlador_AI;
        

        // TELA 
        public GERENCIADOR__tela_jogo gerenciador_tela_jogo;
        

        // ** isso ficaria em controlador_sistema_estado_atual
        public Bloco bloco_atual = Bloco.nada;
        public Game_update_mode game_update_mode;


        public void Update(){

                controlador_armazenamento_disco.Update();

                switch( game_update_mode ){

                    case Game_update_mode.blocks: interfaces_blocos[ ( int ) bloco_atual ].Update(); break;
                    case Game_update_mode.transition: break;

                }

                Verity_transition();

        }

        private void Verity_transition(){

                if( CONTROLLER__transition.instancia.transition_request_visual != null )
                    { 
                        // --- INCIA TRANSICAO
                        game_update_mode = Game_update_mode.transition; 
                        CONTROLLER__transition.instancia.Start_transition_BLOCK();
                    }

                return;

        }


        public static void Zerar_dados(){


                instancia = null;

                // --- ZERAR BLOCOS
                foreach( INTERFACE__bloco bloco_interface in Jogo.Pegar_instancia().interfaces_blocos )
                    { bloco_interface.Destruir(); }

                Finalizador_UI.Finalizar();
                CONTROLLER__game_data.instancia = null;


                return;


        }



}