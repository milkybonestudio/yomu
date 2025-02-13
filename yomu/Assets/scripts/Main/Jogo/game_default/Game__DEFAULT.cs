


using System;
using System.Runtime.InteropServices;

unsafe public class Game__DEFAULT : PROGRAM_MODE {  


        public Game__DEFAULT(){ type = Program_mode.jogo; }

        public BLOCK[] interfaces_blocos;

        // --- CONTROLADORES
        public Controlador_armazenamento_disco controlador_armazenamento_disco;
        public Controlador_sistema controlador_sistema;
        public Controlador_AI controlador_AI;

        
        public override void Construct(){

            PROGRAM_DATA__game* data = &(Controllers_program.data.pointer->game);

            
        
        }


        public override Transition Construct_transition( Transition_data _data ){ return new Transition(); }


        // TELA 
        public GERENCIADOR__tela_jogo gerenciador_tela_jogo;
        

        // ** isso ficaria em controlador_sistema_estado_atual
        public Block_type bloco_atual = Block_type.nada;
        public Game_update_mode game_update_mode;


        public override void Update( Control_flow _control_flow ){

                

                controlador_armazenamento_disco.Update( _control_flow );

                switch( game_update_mode ){

                    case Game_update_mode.blocks: interfaces_blocos[ ( int ) bloco_atual ].Update( _control_flow ); break;
                    case Game_update_mode.transition: break;

                }

                Verity_transition();

        }

        public override void Clean_resources(){}
        public override void Destroy(){}

        private void Verity_transition(){

                if( CONTROLLER__transition.instancia.transition_request_visual == null )
                    { return; }

                // --- INCIA TRANSICAO
                game_update_mode = Game_update_mode.transition; 
                CONTROLLER__transition.instancia.Start_transition_BLOCK();

                return;

        }


        public static void Zerar_dados(){


                //mark
                // ** ativar depois
                // // --- ZERAR BLOCOS
                // foreach( INTERFACE__bloco bloco_interface in Jogo.Pegar_instancia().interfaces_blocos )
                //     { bloco_interface.Destruir(); }

                Controllers.data.Destroy_data();

 

                Finalizador_UI.Finalizar();
                CONTROLLER__game_data.instancia = null;


                return;


        }



}