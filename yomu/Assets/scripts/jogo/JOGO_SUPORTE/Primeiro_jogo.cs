



public static class Primeiro_jogo {



    public static void  Iniciar(){


             // tem que estar no main 


                    Req_transicao req  = new Req_transicao( Tipo_troca_bloco.START , Bloco.visual_novel , Tipo_transicao.instantaneo );
                    
                    Visual_novel_START visual_novel_START = new Visual_novel_START( Nome_screen_play.NARA_INTRODUCAO_riku_introducao );

                    Dados_blocos.req_transicao = req;
                    Dados_blocos.visual_novel_START = visual_novel_START;


                    // Debug.Log("ERA PARA MOVER");

                    ///controlador_movimento.Mover_player( _ponto_nome  :  Ponto_nome.BACK_quarto_nara,  _reset: true ,  _instantaneo : true )  ;                    
                    ///controlador_movimento.Mover_player( _ponto_nome  :  Ponto_nome.FRONT_quarto_nara ,  _reset: false , _instantaneo : true ) ; 


                    //Debug.Log("novo_ponto: " + Player_estado_atual.Pegar_instancia().ponto_atual.ponto_nome  );


      
                    Lista_navegacao lista = Controlador_dados_dinamicos.Pegar_instancia().lista_navegacao;


                    /// frente 
                    // tira o espelho 
                    // tirar mesa
                    // tirar corredor 

                    /// tras 
                    // tirar cama 
                    // tirar bau
                    // tirar closet

                    /// muda Lidar retorno 
                    // 

                    int[] slots = new int[ 1 ]{  1  };

                        Interativo_nome[] interativos_default_front = new Interativo_nome[] {  
                        
                            Interativo_nome.MESA_front_quarto_nara,
                            Interativo_nome.ESPELHO_front_quarto_nara,
                            Interativo_nome.CORREDOR_front_quarto_nara

                        };

                        Interativo_nome[] interativos_default_back = new Interativo_nome[] {  
                        
                            Interativo_nome.BURACO_back_quarto_nara,
                            Interativo_nome.CAMA_back_quarto_nara    

                        };

                        Interativo_nome[] interativos_default_mesa = new Interativo_nome[] {  
                        
                                    Interativo_nome.LIVRO_1_mesa_quarto_nara,
                                    Interativo_nome.LIVRO_2_mesa_quarto_nara,
                                    Interativo_nome.LIVRO_3_mesa_quarto_nara,
                                    Interativo_nome.LIVRO_4_mesa_quarto_nara,
                                    Interativo_nome.LIVRO_5_mesa_quarto_nara,
                                    Interativo_nome.LIVRO_6_mesa_quarto_nara,
                                    Interativo_nome.CAIXA_mesa_quarto_nara,
                                    Interativo_nome.CARTAS_mesa_quarto_nara,
                                    Interativo_nome.TINTA_mesa_quarto_nara


                        };


                    lista.Mudar_interativos_para_subtrair(    Ponto_nome.FRONT_quarto_nara ,  slots,  interativos_default_front  );
                    lista.Mudar_interativos_para_subtrair(    Ponto_nome.BACK_quarto_nara ,  slots,  interativos_default_back  );
                    lista.Mudar_interativos_para_subtrair(    Ponto_nome.MESA_quarto_nara ,  slots,  interativos_default_mesa  );

                    lista.Mudar_background_para_substituir( Ponto_nome.MESA_quarto_nara , Periodo_tempo.dia , "mesa_sem_nada_n" );




                    lista.Remover_interativo_para_subtrair (  Ponto_nome.FRONT_quarto_nara ,  slots,  Interativo_nome.ESPELHO_front_quarto_nara  );


                    lista.Adicionar_script_interativo_em_espera( Interativo_nome.ESPELHO_front_quarto_nara , Script_jogo_nome.NARA_INTRODUCAO_espelho );
                    lista.Adicionar_script_interativo_em_espera( Interativo_nome.MACANETA_corredor_quarto_nara , Script_jogo_nome.NARA_INTRODUCAO_corredor );


                    // precisa?
                    //mark

                    // Colocar_UI_atual = () => {


                    //         Req_mudar_UI novo_UI = new Req_mudar_UI() ;

                    //         novo_UI.UI_partes = new bool[3];


                    //         novo_UI.UI_partes[ ( int ) In_game_UI_partes.todas ] = false ;
                    //         novo_UI.UI_partes[ ( int ) In_game_UI_partes.barra_superior ] = false ;
                    //         novo_UI.UI_partes[ ( int ) In_game_UI_partes.pergaminho ] = false ;

                    //         novo_UI.novo_tipo_UI = Tipo_UI.in_game;
                    //         novo_UI.instantaneo = true;

                    //         this.dados_blocos.req_mudar_UI = novo_UI ;



                    // }; 

                    return;



        }








}
