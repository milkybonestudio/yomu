using UnityEngine;




public static class Botao_dispositivo_SETAR {


        public static void SETAR_ON_estatico( Botao_dispositivo botao ){


                // esconde outros
                botao.IMAGEM_container.SetActive( true );
                botao.TRANSICAO_container.SetActive( false );

                Estado_visual_botao_dispositivo estado = Estado_visual_botao_dispositivo.on_estatico;
                int pointer = Botao_dispositivo_SUPORTE.Pegar_pointer_inicial_estado( botao, estado  );
                Botao_dispositivo_MUDAR_IMAGEM.Mudar_imagens_IMAGEM( botao, pointer );



                // ** mudar texto 
                botao.IMAGEM_texto.color = botao.dados.on.texto_cor;
                botao.IMAGEM_texto.text = botao.dados.on.texto;
                


                // --- RESETA DADOS
                botao.animacao_atual_tempo_ms = botao.dados.animacao_on_tempos.tempo_espera_para_ativar_ms;
                botao.sprite_atual_index = ( pointer - 1 );
                botao.estado_visual_botao = estado;

                botao.Update_parte_visual();

                return;


        }



        public static void SETAR_ON_animacao( Botao_dispositivo botao ){


                // esconde outros
                botao.IMAGEM_container.SetActive( true );
                botao.TRANSICAO_container.SetActive( false );
                

                Estado_visual_botao_dispositivo estado = Estado_visual_botao_dispositivo.on_animacao;
                int pointer = Botao_dispositivo_SUPORTE.Pegar_pointer_inicial_estado( botao, estado  );
                Botao_dispositivo_MUDAR_IMAGEM.Mudar_imagens_IMAGEM( botao, pointer );

                // ** mudar texto 
                botao.IMAGEM_texto.color = botao.dados.on.texto_cor;
                botao.IMAGEM_texto.text = botao.dados.on.texto;



                botao.animacao_sprite_atual_tempo_ms = 0f; // *** vai forcar mudar para a primeira sprite
                botao.sprite_atual_index = ( pointer - 1 ); 
                botao.estado_visual_botao = estado;

                Botao_dispositivo_MUDAR_IMAGEM.Mudar_imagens_IMAGEM( botao, pointer );

                botao.Update_parte_visual();

                return;


        }







        public static void SETAR_transicao_ON_para_OFF( Botao_dispositivo botao ){




                     if( botao.dados.tipo_transicao == Tipo_transicao_botao_OFF_ON_dispositivo.cor )
                        {
                            // --- COR

                            botao.IMAGEM_container.SetActive( true );
                            botao.TRANSICAO_container.SetActive( true );

                    
                            int pointer_off_cor = botao.dados.pointers.pointer_imagem_estatica_OFF;
                            int pointer_on_cor = botao.dados.pointers.pointer_imagem_estatica_ON;

                            Botao_dispositivo_MUDAR_IMAGEM.Mudar_imagens_IMAGEM( botao, pointer_on_cor );
                            Botao_dispositivo_MUDAR_IMAGEM.Mudar_imagens_TRANSICAO( botao, pointer_off_cor );


                            // ** mudar texto 
                            botao.IMAGEM_texto.text = botao.dados.on.texto;
                            botao.TRANSICAO_texto.text = botao.dados.off.texto;



                            // --- RESETA DADOS
                            botao.animacao_atual_tempo_ms = botao.dados.animacao_ON_para_OFF_tempos.tempo_espera_para_ativar_ms;
                            botao.sprite_atual_index = -1;
                            botao.estado_visual_botao = Estado_visual_botao_dispositivo.transicao_animacao_ON_para_OFF;

                            botao.Update_parte_visual();

                            return;

                        }
                else if( botao.dados.tipo_transicao == Tipo_transicao_botao_OFF_ON_dispositivo.animacao_individual )
                        {
                            // --- INDIVIDUAL


                            botao.IMAGEM_container.SetActive( false );
                            botao.TRANSICAO_container.SetActive( true );

                            // ** quando for colocar no update ja vai colocar 
                            // int pointer_individual = botao.dados.pointers.pointer_imagem_estatica_OFF;
                            // Botao_dispositivo_MUDAR_IMAGEM.Mudar_imagens_TRANSICAO( botao, pointer_individual );


                            // --- RESETA DADOS
                            
                            botao.animacao_sprite_atual_tempo_ms = 0f; // vai para o primeiro
                            botao.sprite_atual_index = ( botao.dados.pointers.pointer_inicio_transicao_ON_para_OFF - 1 );
                            botao.estado_visual_botao = Estado_visual_botao_dispositivo.transicao_animacao_ON_para_OFF;

                            botao.Update_parte_visual();



                            return;

                        }
                    else    
                        {
                            // --- NADA
                            botao.estado_visual_botao = Estado_visual_botao_dispositivo.transicao_animacao_ON_para_OFF;
                            botao.Update_parte_visual();
                            return;

                        }

        }



        public static void SETAR_transicao_OFF_para_ON( Botao_dispositivo botao ){




                     if( botao.dados.tipo_transicao == Tipo_transicao_botao_OFF_ON_dispositivo.cor )
                        {
                            // --- COR

                            botao.IMAGEM_container.SetActive( true );
                            botao.TRANSICAO_container.SetActive( true );

                    
                            int pointer_off_cor = botao.dados.pointers.pointer_imagem_estatica_OFF;
                            int pointer_on_cor = botao.dados.pointers.pointer_imagem_estatica_ON;

                            Botao_dispositivo_MUDAR_IMAGEM.Mudar_imagens_IMAGEM( botao, pointer_off_cor );
                            Botao_dispositivo_MUDAR_IMAGEM.Mudar_imagens_TRANSICAO( botao, pointer_on_cor );



                            // ** mudar texto 
                            botao.IMAGEM_texto.text = botao.dados.off.texto;
                            botao.TRANSICAO_texto.text = botao.dados.on.texto;

                            // --- RESETA DADOS
                            botao.animacao_atual_tempo_ms = botao.dados.animacao_OFF_para_ON_tempos.tempo_espera_para_ativar_ms;
                            botao.sprite_atual_index = -1;
                            botao.estado_visual_botao = Estado_visual_botao_dispositivo.transicao_animacao_OFF_para_ON;

                            botao.Update_parte_visual();

                            return;

                        }
                else if( botao.dados.tipo_transicao == Tipo_transicao_botao_OFF_ON_dispositivo.animacao_individual )
                        {
                            // --- INDIVIDUAL


                            botao.IMAGEM_container.SetActive( false );
                            botao.TRANSICAO_container.SetActive( true );

                            // int pointer_individual = botao.dados.pointers.pointer;
                            // Botao_dispositivo_MUDAR_IMAGEM.Mudar_imagens_TRANSICAO( botao, pointer_individual );


                            // --- RESETA DADOS
                            
                            botao.animacao_sprite_atual_tempo_ms = 0f; // vai para o primeiro
                            botao.sprite_atual_index = ( botao.dados.pointers.pointer_inicio_transicao_OFF_para_ON - 1 );
                            botao.estado_visual_botao = Estado_visual_botao_dispositivo.transicao_animacao_OFF_para_ON;

                            botao.Update_parte_visual();



                            return;

                        }
                    else    
                        {
                            // --- NADA
                            botao.estado_visual_botao = Estado_visual_botao_dispositivo.transicao_animacao_OFF_para_ON;
                            botao.Update_parte_visual();
                            return;

                        }

        }





        public static void SETAR_OFF_estatico( Botao_dispositivo botao ){


                // esconde outros
                botao.IMAGEM_container.SetActive( true );
                botao.TRANSICAO_container.SetActive( false );

                Estado_visual_botao_dispositivo estado = Estado_visual_botao_dispositivo.off_estatico;
                int pointer = Botao_dispositivo_SUPORTE.Pegar_pointer_inicial_estado( botao, estado  );
                Botao_dispositivo_MUDAR_IMAGEM.Mudar_imagens_IMAGEM( botao, pointer );



                // ** mudar texto 
                botao.IMAGEM_texto.color = botao.dados.off.texto_cor;
                botao.IMAGEM_texto.text = botao.dados.off.texto;




                // --- RESETA DADOS
                botao.animacao_atual_tempo_ms = botao.dados.animacao_off_tempos.tempo_espera_para_ativar_ms;
                botao.sprite_atual_index = ( pointer - 1 );
                botao.estado_visual_botao = estado;

                botao.Update_parte_visual();

                return;


        }

        public static void SETAR_OFF_animacao( Botao_dispositivo botao ){


                // esconde outros
                botao.IMAGEM_container.SetActive( true );
                botao.TRANSICAO_container.SetActive( false );
                

                Estado_visual_botao_dispositivo estado = Estado_visual_botao_dispositivo.off_animacao;
                int pointer = Botao_dispositivo_SUPORTE.Pegar_pointer_inicial_estado( botao, estado  );
                Botao_dispositivo_MUDAR_IMAGEM.Mudar_imagens_IMAGEM( botao, pointer );

                // ** mudar texto 
                botao.IMAGEM_texto.color = botao.dados.off.texto_cor;
                botao.IMAGEM_texto.text = botao.dados.off.texto;



                botao.animacao_sprite_atual_tempo_ms = 0f; // *** vai forcar mudar para a primeira sprite
                botao.sprite_atual_index = ( pointer - 1 ); 
                botao.estado_visual_botao = estado;

                Botao_dispositivo_MUDAR_IMAGEM.Mudar_imagens_IMAGEM( botao, pointer );

                botao.Update_parte_visual();

                return;


        }





}