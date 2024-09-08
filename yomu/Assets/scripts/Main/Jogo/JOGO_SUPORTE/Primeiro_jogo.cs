



public static class Primeiro_jogo_suporte {


        public static Task_req Pegar_task_criar_primeiro_jogo_default( int _save, bool _novo_jogo  ){


                if( Jogo.instancia == null )
                    {  throw new System.Exception( "Pediu a req para criar o primeiro jogo como default mas a instancia de jogo estava null" );}

                Task_req req_iniciar_jogo = new Task_req ( "Iniciar_jogo" );

                req_iniciar_jogo.fn_multithread = ( Task_req _req )  =>     { 
                                                                                Jogo.instancia.controlador_armazenamento_disco = Construtor_controlador_armazenamento_disco.Construir( _save, _novo_jogo );
                                                                                Jogo.instancia.controlador_AI = Controlador_AI.Construir();
                                                                        };

                //Controlador_multithread.Pegar_instancia().Adicionar_task( req_iniciar_jogo );

                return req_iniciar_jogo;

        }


        // ** isso aqui nao vai mais ser usado 
        public static void  Iniciar(){


             // tem que estar no main 


                    Req_transicao req =  Controlador_pedidos_sistema.instancia.Create_new_transition_req();

                    req.tipo_transicao = Tipo_transicao.instantaneo;
                    req.tipo_troca_bloco = Tipo_troca_bloco.START;
                    req.novo_bloco = Bloco.story;
                    
                    Story_START story_START =  Dados_blocos.Get_data_start_BLOCK();
                    story_START.nome_screen_play =  Nome_screen_play.NARA_INTRODUCAO_riku_introducao;
                    Dados_blocos.story_START = story_START;

                    return;

        }




}
