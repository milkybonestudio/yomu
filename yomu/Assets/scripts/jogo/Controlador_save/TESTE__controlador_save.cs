
#if UNITY_EDITOR 

    public static class TESTE__controlador_save {

            public static Controlador_save Construir(){

                    // vai ser executado na main thread
                    Controlador_save.esta_em_teste = true;

                    
                    Controlador_save controlador = new Controlador_save(); 


                            // ** tem que deixar o jogo na posicao "0"
                            // personagem inicial : nara 
                            // posicao inicial: ( 0 , 0  , 0 ) ( cidade:  )
                            Paths_sistema.Colocar_save( 0 );      
                            Dados_blocos.Resetar();
                            Controlador_timer.Construir_teste( null );
                            //Controlador_dados_dinamicos.Construir_teste( null );

                            TESTE__player_estado_atual.Construir();
                            TESTE__jogo_estado_atual.Construir();

                            
                            // nao vai construir nenhum personagem além da nara
                            TESTE_controlador_personagens.Construir_controlador();
                            TESTE_controlador_cidades.Construir_controlador();
                            TESTE_controlador_plots.Construir_controlador();
                            TESTE_controlador_sistema.Construir_controlador();

                    Controlador_save.instancia = controlador;
                    return controlador;          

                
            }

    }


#endif