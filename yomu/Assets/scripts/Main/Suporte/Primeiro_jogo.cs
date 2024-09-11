



public static class Primeiro_jogo_suporte {


        public static Task_req Pegar_task_criar_primeiro_jogo_default( int _save ){


                Task_req req_iniciar_jogo = new Task_req ( "Iniciar_jogo" );

                req_iniciar_jogo.fn_multithread = ( Task_req _req )  => { 

                                                                            New_game_constructor.Construct( _save ); // --- copia todos os dados defaults para o save 
                                                                            Construtor_jogo.Construir( _save );  // --- inicia o jogo
                                                                            
                                                                        }; 

                return req_iniciar_jogo;

        }

}
