using UnityEngine;


public static class TOOL__UI_button_SET_COMPLETE {


        public static void SET_ON_static( Botao_dispositivo botao ){


                // esconde outros
                botao.IMAGE_container.SetActive( true );
                botao.TRANSITION_container.SetActive( false );

                DEVICE_button_visual_state estado = DEVICE_button_visual_state.on_estatico;
                int pointer = Botao_dispositivo_SUPORTE.Pegar_pointer_inicial_estado( botao, estado  );
                Botao_dispositivo_MUDAR_IMAGEM.Change_images_IMAGE( botao, pointer );


                // ** mudar texto 
                botao.IMAGE_text.tmp_text.color = botao.data.on.texto_cor;
                botao.IMAGE_text.tmp_text.text = botao.data.on.texto;
                


                // --- RESETA DADOS
                botao.animacao_atual_tempo_ms = botao.data.animacao_on_tempos.tempo_espera_para_ativar_ms;
                botao.sprite_atual_index = ( pointer - 1 );
                botao.estado_visual_botao = estado;

                TOOL__UI_button_UPDATE.Update_parte_visual( botao );

                return;


        }


        public static void SET_OFF_static( Botao_dispositivo botao ){


                // esconde outros
                botao.IMAGE_container.SetActive( true );
                botao.TRANSITION_container.SetActive( false );

                DEVICE_button_visual_state estado = DEVICE_button_visual_state.off_estatico;
                int pointer = Botao_dispositivo_SUPORTE.Pegar_pointer_inicial_estado( botao, estado  );
                Botao_dispositivo_MUDAR_IMAGEM.Change_images_IMAGE( botao, pointer );



                // ** mudar texto 
                botao.IMAGE_text.tmp_text.color = botao.data.off.texto_cor;
                botao.IMAGE_text.tmp_text.text = botao.data.off.texto;




                // --- RESETA DADOS
                botao.animacao_atual_tempo_ms = botao.data.animacao_off_tempos.tempo_espera_para_ativar_ms;
                botao.sprite_atual_index = ( pointer - 1 );
                botao.estado_visual_botao = estado;

                TOOL__UI_button_UPDATE.Update_parte_visual( botao );

                return;


        }





        public static void SETAR_transicao_ON_para_OFF( Botao_dispositivo botao ){




                     if( botao.data.tipo_transicao == DEVICE_button_transition_type_OFF_ON.cor )
                        {
                            // --- COR

                            botao.IMAGE_container.SetActive( true );
                            botao.TRANSITION_container.SetActive( true );

                    
                            int pointer_off_cor = botao.data.pointers.pointer_imagem_estatica_OFF;
                            int pointer_on_cor = botao.data.pointers.pointer_imagem_estatica_ON;

                            Botao_dispositivo_MUDAR_IMAGEM.Change_images_IMAGE( botao, pointer_on_cor );
                            Botao_dispositivo_MUDAR_IMAGEM.Mudar_imagens_TRANSICAO( botao, pointer_off_cor );


                            // ** mudar texto 
                            botao.IMAGE_text.tmp_text.text = botao.data.on.texto;
                            botao.TRANSITION_text.tmp_text.text = botao.data.off.texto;



                            // --- RESETA DADOS
                            botao.animacao_atual_tempo_ms = botao.data.animacao_ON_para_OFF_tempos.tempo_espera_para_ativar_ms;
                            botao.sprite_atual_index = -1;
                            botao.estado_visual_botao = DEVICE_button_visual_state.transicao_animacao_ON_para_OFF;

                            TOOL__UI_button_UPDATE.Update_parte_visual( botao );

                            return;

                        }
                else if( botao.data.tipo_transicao == DEVICE_button_transition_type_OFF_ON.animacao_individual )
                        {
                            // --- INDIVIDUAL


                            botao.IMAGE_container.SetActive( false );
                            botao.TRANSITION_container.SetActive( true );

                            // ** quando for colocar no update ja vai colocar 
                            // int pointer_individual = botao.data.pointers.pointer_imagem_estatica_OFF;
                            // Botao_dispositivo_MUDAR_IMAGEM.Mudar_imagens_TRANSICAO( botao, pointer_individual );


                            // --- RESETA DADOS
                            
                            botao.animacao_sprite_atual_tempo_ms = 0f; // vai para o primeiro
                            botao.sprite_atual_index = ( botao.data.pointers.pointer_inicio_transicao_ON_para_OFF - 1 );
                            botao.estado_visual_botao = DEVICE_button_visual_state.transicao_animacao_ON_para_OFF;

                            TOOL__UI_button_UPDATE.Update_parte_visual( botao );



                            return;

                        }
                    else    
                        {
                            // --- NADA
                            botao.estado_visual_botao = DEVICE_button_visual_state.transicao_animacao_ON_para_OFF;
                            TOOL__UI_button_UPDATE.Update_parte_visual( botao );
                            return;

                        }

        }



        public static void SET_transition_OFF_to_ON( Botao_dispositivo botao ){


                     if( botao.data.tipo_transicao == DEVICE_button_transition_type_OFF_ON.cor )
                        {
                            // --- COR

                            botao.IMAGE_container.SetActive( true );
                            botao.TRANSITION_container.SetActive( true );

                    
                            int pointer_off_cor = botao.data.pointers.pointer_imagem_estatica_OFF;
                            int pointer_on_cor = botao.data.pointers.pointer_imagem_estatica_ON;

                            Botao_dispositivo_MUDAR_IMAGEM.Change_images_IMAGE( botao, pointer_off_cor );
                            Botao_dispositivo_MUDAR_IMAGEM.Mudar_imagens_TRANSICAO( botao, pointer_on_cor );



                            // ** mudar texto 
                            botao.IMAGE_text.tmp_text.text = botao.data.off.texto;
                            botao.TRANSITION_text.tmp_text.text = botao.data.on.texto;

                            // --- RESETA DADOS
                            botao.animacao_atual_tempo_ms = botao.data.animacao_OFF_para_ON_tempos.tempo_espera_para_ativar_ms;
                            botao.sprite_atual_index = -1;
                            botao.estado_visual_botao = DEVICE_button_visual_state.transicao_animacao_OFF_para_ON;

                            TOOL__UI_button_UPDATE.Update_parte_visual( botao );

                            return;

                        }
                else if( botao.data.tipo_transicao == DEVICE_button_transition_type_OFF_ON.animacao_individual )
                        {
                            // --- INDIVIDUAL


                            botao.IMAGE_container.SetActive( false );
                            botao.TRANSITION_container.SetActive( true );

                            // int pointer_individual = botao.data.pointers.pointer;
                            // Botao_dispositivo_MUDAR_IMAGEM.Mudar_imagens_TRANSICAO( botao, pointer_individual );


                            // --- RESETA DADOS
                            
                            botao.animacao_sprite_atual_tempo_ms = 0f; // vai para o primeiro
                            botao.sprite_atual_index = ( botao.data.pointers.pointer_inicio_transicao_OFF_para_ON - 1 );
                            botao.estado_visual_botao = DEVICE_button_visual_state.transicao_animacao_OFF_para_ON;

                            TOOL__UI_button_UPDATE.Update_parte_visual( botao );



                            return;

                        }
                    else    
                        {
                            // --- NADA
                            botao.estado_visual_botao = DEVICE_button_visual_state.transicao_animacao_OFF_para_ON;
                            TOOL__UI_button_UPDATE.Update_parte_visual( botao );
                            return;

                        }

        }






}