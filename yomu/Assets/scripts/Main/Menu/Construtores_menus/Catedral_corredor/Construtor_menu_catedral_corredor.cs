


public static class Construtor_dados_menu_CATEDRAL_CORREDOR {


        public static Dados_menu Construir( Dados_menu dados_menu_retorno ){


                // *** VAI CARREGAR O DEFAULT


                // *** Tem que ser criado quando o login for criado
                // *** usar para pegar as imagens com antecedencia


                // --- PEGA DADOS

                dados_menu_retorno.tipo_menu_background = Tipo_menu_background.catedral_corredor;


                // --- GERAL


                // --- BACKGROUND


                dados_menu_retorno.background_imagens_ids_E_posicoes = new int[] {

                        ( int ) Catedral_corredor_imagens_background.background_unico, 
                        0, // x
                        0  // y

                };


                

                // --- BLOCOS

                        // --- GALERIA

                                int[] posicoes_interativos_galeria = dados_menu_retorno.posicoes_interativos_menu_por_bloco[ ( ( int ) Menu_bloco.galeria ) ];
                                int[] interativos_menu_galeria_imagens = dados_menu_retorno.interativos_menu_imagens_por_bloco[ ( ( int ) Menu_bloco.galeria ) ];
                                // ** talvez depois
                                // int[][] interativos_menu_animacoes_por_bloco = dados_menu_retorno.interativos_menu_animacoes_por_bloco[ ( ( int ) Menu_bloco.galeria ) ];


                                // ** slot 1
                                posicoes_interativos_galeria [ ( 2 * 0 ) + 0 ] = 0;
                                posicoes_interativos_galeria [ ( 2 * 0 ) + 1 ] = 0;


                                interativos_menu_galeria_imagens[ 0 ] = ( int ) Catedral_corredor_interativos_imagens.galeria_quadro_1;
                                
                                
                                // ** slot 2
                                posicoes_interativos_galeria [ ( 2 * 1 ) + 0 ] = 0;
                                posicoes_interativos_galeria [ ( 2 * 1 ) + 1 ] = 0;


                                interativos_menu_galeria_imagens[ 1 ] = ( int ) Catedral_corredor_interativos_imagens.galeria_quadro_2;


                                // ** slot 3
                                posicoes_interativos_galeria [ ( 2 * 2 ) + 0 ] = 0;
                                posicoes_interativos_galeria [ ( 2 * 2 ) + 1 ] = 0;


                                interativos_menu_galeria_imagens[ 2 ] = ( int ) Catedral_corredor_interativos_imagens.galeria_quadro_3;


                                // ** slot 4
                                posicoes_interativos_galeria [ ( 2 * 3 ) + 0 ] = 0;
                                posicoes_interativos_galeria [ ( 2 * 3 ) + 1 ] = 0;


                                interativos_menu_galeria_imagens[ 3 ] = ( int ) Catedral_corredor_interativos_imagens.galeria_quadro_4;
                        

                                // ** slot 5
                                posicoes_interativos_galeria [ ( 2 * 4 ) + 0 ] = 0;
                                posicoes_interativos_galeria [ ( 2 * 4 ) + 1 ] = 0;


                                interativos_menu_galeria_imagens[ 4 ] = ( int ) Catedral_corredor_interativos_imagens.galeria_quadro_5;
                                

                                // ** slot 6
                                posicoes_interativos_galeria [ ( 2 * 5 ) + 0 ] = 0;
                                posicoes_interativos_galeria [ ( 2 * 5 ) + 1 ] = 0;


                                interativos_menu_galeria_imagens[ 5 ] = ( int ) Catedral_corredor_interativos_imagens.galeria_quadro_6;



                                // ** botao esquerda
                                posicoes_interativos_galeria [ ( 2 * 6 ) + 0 ] = 0;
                                posicoes_interativos_galeria [ ( 2 * 6 ) + 1 ] = 0;


                                interativos_menu_galeria_imagens[ 6 ] = ( int ) Catedral_corredor_interativos_imagens.botao_esquerda_generico;


                                // ** botao direita
                                posicoes_interativos_galeria [ ( 2 * 7 ) + 0 ] = 0;
                                posicoes_interativos_galeria [ ( 2 * 7 ) + 1 ] = 0;



                                interativos_menu_galeria_imagens[ 7 ] = ( int ) Catedral_corredor_interativos_imagens.botao_direita_generico;




                        // --- CONFIGURACOES


                                // --- POSICAO BLOCO 
                                dados_menu_retorno.posicoes_blocos[ ( ( ( int ) Menu_bloco.configuracoes * 2 ) + 0 ) ] = 0;
                                dados_menu_retorno.posicoes_blocos[ ( ( ( int ) Menu_bloco.configuracoes * 2 ) + 1 ) ] = 1;



                        // --- NOVO JOGO
                                
                                // --- POSICAO BLOCO
                                int[] posicoes_interativos_novo_jogo = dados_menu_retorno.posicoes_interativos_menu_por_bloco[ ( ( int ) Menu_bloco.novo_jogo ) ];
                                int[]   interativos_menu_novo_jogo_imagens = dados_menu_retorno.interativos_menu_imagens_por_bloco[ ( ( int ) Menu_bloco.novo_jogo ) ];


                                // ** slot 1
                                posicoes_interativos_novo_jogo [ ( 2 * 0 ) + 0 ] = 11;
                                posicoes_interativos_novo_jogo [ ( 2 * 0 ) + 1 ] = 126;


                                interativos_menu_novo_jogo_imagens[ 0 ] = ( int ) Catedral_corredor_interativos_imagens.quadro_novo_jogo;


                        
                        // SAVES
                                
                                int[] posicoes_interativos_saves = dados_menu_retorno.posicoes_interativos_menu_por_bloco[ ( ( int ) Menu_bloco.saves ) ];
                                int[] interativos_menu_saves_imagens = dados_menu_retorno.interativos_menu_imagens_por_bloco[ ( ( int ) Menu_bloco.saves ) ];
                                // ** talvez depois
                                // int[][] interativos_menu_animacoes_por_bloco = dados_menu_retorno.interativos_menu_animacoes_por_bloco[ ( ( int ) Menu_bloco.saves ) ];


                                // ** slot 1
                                posicoes_interativos_saves [ ( 2 * 0 ) + 0 ] = 0;
                                posicoes_interativos_saves [ ( 2 * 0 ) + 1 ] = 0;


                                interativos_menu_saves_imagens[ 0 ] = ( int ) Catedral_corredor_interativos_imagens.save_slot_gernerico;
                                
                                
                                // ** slot 2
                                posicoes_interativos_saves [ ( 2 * 1 ) + 0 ] = 0;
                                posicoes_interativos_saves [ ( 2 * 1 ) + 1 ] = 0;


                                interativos_menu_saves_imagens[ 1 ] = ( int ) Catedral_corredor_interativos_imagens.save_slot_gernerico;


                                // ** slot 3
                                posicoes_interativos_saves [ ( 2 * 2 ) + 0 ] = 0;
                                posicoes_interativos_saves [ ( 2 * 2 ) + 1 ] = 0;


                                interativos_menu_saves_imagens[ 2 ] = ( int ) Catedral_corredor_interativos_imagens.save_slot_gernerico;


                                // ** slot 4
                                posicoes_interativos_saves [ ( 2 * 3 ) + 0 ] = 0;
                                posicoes_interativos_saves [ ( 2 * 3 ) + 1 ] = 0;


                                interativos_menu_saves_imagens[ 3 ] = ( int ) Catedral_corredor_interativos_imagens.save_slot_gernerico;
                        

                                // ** slot 5
                                posicoes_interativos_saves [ ( 2 * 4 ) + 0 ] = 0;
                                posicoes_interativos_saves [ ( 2 * 4 ) + 1 ] = 0;


                                interativos_menu_saves_imagens[ 4 ] = ( int ) Catedral_corredor_interativos_imagens.save_slot_gernerico;
                                

                                // ** slot 6
                                posicoes_interativos_saves [ ( 2 * 5 ) + 0 ] = 0;
                                posicoes_interativos_saves [ ( 2 * 5 ) + 1 ] = 0;


                                interativos_menu_saves_imagens[ 5 ] = ( int ) Catedral_corredor_interativos_imagens.save_slot_gernerico;



                                // ** botao esquerda
                                posicoes_interativos_saves [ ( 2 * 6 ) + 0 ] = 0;
                                posicoes_interativos_saves [ ( 2 * 6 ) + 1 ] = 0;


                                interativos_menu_saves_imagens[ 6 ] = ( int ) Catedral_corredor_interativos_imagens.botao_esquerda_generico;


                                // ** botao direita
                                posicoes_interativos_saves [ ( 2 * 7 ) + 0 ] = 0;
                                posicoes_interativos_saves [ ( 2 * 7 ) + 1 ] = 0;



                                interativos_menu_saves_imagens[ 7 ] = ( int ) Catedral_corredor_interativos_imagens.botao_direita_generico;


                        
                        // PERSONAGENS
                                
                                int[] posicoes_interativos_personagens = dados_menu_retorno.posicoes_interativos_menu_por_bloco[ ( ( int ) Menu_bloco.personagens ) ];
                                int[]   interativos_menu_personagens_imagens = dados_menu_retorno.interativos_menu_imagens_por_bloco[ ( ( int ) Menu_bloco.personagens ) ];
                                // ** talvez depois
                                // int[][] interativos_menu_animacoes_por_bloco = dados_menu_retorno.interativos_menu_animacoes_por_bloco[ ( ( int ) Menu_bloco.galeria ) ];


                                // ** slot 1
                                posicoes_interativos_personagens [ ( 2 * 0 ) + 0 ] = 0;
                                posicoes_interativos_personagens [ ( 2 * 0 ) + 1 ] = 0;


                                interativos_menu_personagens_imagens[ 0 ] = ( int ) Catedral_corredor_interativos_imagens.personagem_slot_generico;
                                
                                
                                // ** slot 2
                                posicoes_interativos_personagens [ ( 2 * 1 ) + 0 ] = 0;
                                posicoes_interativos_personagens [ ( 2 * 1 ) + 1 ] = 0;


                                interativos_menu_personagens_imagens[ 1 ] = ( int ) Catedral_corredor_interativos_imagens.personagem_slot_generico;


                                // ** slot 3
                                posicoes_interativos_personagens [ ( 2 * 2 ) + 0 ] = 0;
                                posicoes_interativos_personagens [ ( 2 * 2 ) + 1 ] = 0;


                                interativos_menu_personagens_imagens[ 2 ] = ( int ) Catedral_corredor_interativos_imagens.personagem_slot_generico;


                                // ** slot 4
                                posicoes_interativos_personagens [ ( 2 * 3 ) + 0 ] = 0;
                                posicoes_interativos_personagens [ ( 2 * 3 ) + 1 ] = 0;


                                interativos_menu_personagens_imagens[ 3 ] = ( int ) Catedral_corredor_interativos_imagens.personagem_slot_generico;
                        

                                // ** slot 5
                                posicoes_interativos_personagens [ ( 2 * 4 ) + 0 ] = 0;
                                posicoes_interativos_personagens [ ( 2 * 4 ) + 1 ] = 0;


                                interativos_menu_personagens_imagens[ 4 ] = ( int ) Catedral_corredor_interativos_imagens.personagem_slot_generico;
                                

                                // ** slot 6
                                posicoes_interativos_personagens [ ( 2 * 5 ) + 0 ] = 0;
                                posicoes_interativos_personagens [ ( 2 * 5 ) + 1 ] = 0;


                                interativos_menu_personagens_imagens[ 5 ] = ( int ) Catedral_corredor_interativos_imagens.personagem_slot_generico;



                                // ** botao esquerda
                                posicoes_interativos_personagens [ ( 2 * 6 ) + 0 ] = 0;
                                posicoes_interativos_personagens [ ( 2 * 6 ) + 1 ] = 0;


                                interativos_menu_personagens_imagens[ 6 ] = ( int ) Catedral_corredor_interativos_imagens.botao_esquerda_generico;


                                // ** botao direita
                                posicoes_interativos_personagens [ ( 2 * 7 ) + 0 ] = 0;
                                posicoes_interativos_personagens [ ( 2 * 7 ) + 1 ] = 0;



                                interativos_menu_personagens_imagens[ 7 ] = ( int ) Catedral_corredor_interativos_imagens.botao_direita_generico;





                // public int[][] posicoes_interativos_menu_por_bloco;
                // public int[][] tamanho_interativos_por_bloco;
                // public int[][] interativos_menu_imagens_por_bloco;





                return dados_menu_retorno;


                




        }


}