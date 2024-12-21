using UnityEngine;

public static class Construtor_jogo {

        // ** carregar novo jogo nunca é feito no jogo, mas no menu ou no asm main

        public static Jogo Construir( int _save ){

                Jogo jogo = new Jogo(); 

                        // ** 

                        
                        jogo.gerenciador_tela_jogo = new GERENCIADOR__tela_jogo();

                        // --- CONTROLAODRES PRINCIPAIS

                        bool novo_jogo = false; // ver depois

                        jogo.controlador_armazenamento_disco = Construtor_controlador_armazenamento_disco.Construir( null , _save, novo_jogo );
                        jogo.controlador_sistema = Construtor_controlador_sistema.Construir();
                        

                        // --- BLOCOS

                        jogo.interfaces_blocos = new Block[ System_enums.blocks_arr.Length ];

                        jogo.interfaces_blocos[ ( int ) Block_type.interacao ]     =  Construtor_bloco_INTERACAO.Construir( jogo.gerenciador_tela_jogo.interaction_block_container );
                        jogo.interfaces_blocos[ ( int ) Block_type.story ] = Construtor_bloco_STORY.Construir( jogo.gerenciador_tela_jogo.story_block_container );

                        jogo.interfaces_blocos[ ( int ) Block_type.minigames ]    = Construtor_bloco_MINIGAMES.Construir( jogo.gerenciador_tela_jogo.minigames_block_container );
                        jogo.interfaces_blocos[ ( int ) Block_type.cartas ]       = Construtor_bloco_CARTAS.Construir( jogo.gerenciador_tela_jogo.cards_block_container );

                        // ---- CONTROLADORES
                        
                        CONSTRUCTOR__controller_game_data.Construir( _blocos: jogo.interfaces_blocos );
                        



                Jogo.instancia = jogo;
                return jogo;
                

        }

        
}