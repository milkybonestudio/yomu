using UnityEngine;
using UnityEngine.UI;


public static class Botao_dispositivo_TRANSICAO {





        public static void Handle_transition_animation_OFF_to_ON_individual_animation( Botao_dispositivo botao ){
                // --- TEM 1 ANIMACAO PARA CADA


                // --- PASSA TEMPO                
                if( !!!( botao.esta_houver ) )
                    { botao.animacao_sprite_atual_tempo_ms -= botao.data.animacao_OFF_para_ON_tempos.multiplicador_saida_padrao_animacao * ( Time.deltaTime * 1000f ); }// --- ACELERAR
                    else
                    { botao.animacao_sprite_atual_tempo_ms -= ( Time.deltaTime * 1000f ) ; } // --- TEMPO NORMAL


                // --- VERIFICA SE TEM QUE ESPERAR
                if( botao.animacao_sprite_atual_tempo_ms > 0f )
                    { return; } 

                // --- VERIFICA SE TEM MAIS
                if( botao.sprite_atual_index == ( botao.data.pointers.pointer_final_transicao_OFF_para_ON - 1 ) )
                    { Botao_dispositivo_SETAR.SET_ON_static( botao ); return; } // --- ACABOU ANIMACAO


                // --- VAI TROCAR SPRITE
                botao.sprite_atual_index++;
                Botao_dispositivo_MUDAR_IMAGEM.Mudar_imagens_TRANSICAO( botao, botao.sprite_atual_index );
                
                // RENOVA TEMPO
                if( botao.data.animacao_OFF_para_ON_tempos.tempo_troca_sprite_ms_por_sprite != null )
                    { botao.animacao_sprite_atual_tempo_ms = botao.data.animacao_OFF_para_ON_tempos.tempo_troca_sprite_ms_por_sprite[ botao.sprite_atual_index ]; }// --- TEM TEMPO DIFERENTE PARA CADA SPRITE
                    else
                    { botao.animacao_sprite_atual_tempo_ms = botao.data.animacao_OFF_para_ON_tempos.tempo_troca_sprite_ms; } // --- TEMPO UNICO

                return;


        }



        public static void Lidar_transicao_animacao_ON_para_OFF_animacao_individual( Botao_dispositivo botao ){



                // --- PASSA TEMPO                
                if( botao.esta_houver ) 
                    { botao.animacao_sprite_atual_tempo_ms -= botao.data.animacao_ON_para_OFF_tempos.multiplicador_saida_padrao_animacao * ( Time.deltaTime * 1000f ); }// --- ACELERAR
                    else
                    { botao.animacao_sprite_atual_tempo_ms -= ( Time.deltaTime * 1000f ) ; } // --- TEMPO NORMAL


                // --- VERIFICA SE TEM QUE ESPERAR
                if( botao.animacao_sprite_atual_tempo_ms > 0f )
                    { return; } 


                // --- VERIFICA SE TEM MAIS SPRITES
                if( botao.sprite_atual_index == ( botao.data.pointers.pointer_final_transicao_ON_para_OFF - 1 ) )
                    { Botao_dispositivo_SETAR.SET_OFF_static( botao ); return; } // --- ACABOU ANIMACAO


                // --- TEM MAIS FRAMES
                botao.sprite_atual_index++;
                Botao_dispositivo_MUDAR_IMAGEM.Mudar_imagens_TRANSICAO( botao, botao.sprite_atual_index );

                // RENOVA TEMPO
                if( botao.data.animacao_ON_para_OFF_tempos.tempo_troca_sprite_ms_por_sprite != null )
                    { botao.animacao_sprite_atual_tempo_ms = botao.data.animacao_ON_para_OFF_tempos.tempo_troca_sprite_ms_por_sprite[ botao.sprite_atual_index ]; }// --- TEM TEMPO DIFERENTE PARA CADA SPRITE
                    else
                    { botao.animacao_sprite_atual_tempo_ms = botao.data.animacao_ON_para_OFF_tempos.tempo_troca_sprite_ms; } // --- TEMPO UNICO


                return;


        }



    
        public static void Handle_transition_animation_OFF_to_ON_color( Botao_dispositivo botao ){


                
                if( !!!( botao.esta_houver ) ) 
                    { botao.animacao_atual_tempo_ms -= ( botao.data.animacao_OFF_para_ON_tempos.multiplicador_saida_padrao_animacao * ( Time.deltaTime * 1000f ) ); }
                    
                botao.animacao_atual_tempo_ms -= ( Time.deltaTime * 1000f ) ; 


                if( botao.animacao_atual_tempo_ms < 0.5f )
                    { Botao_dispositivo_SETAR.SET_ON_static( botao ); return; } // --- FINALIZAR


                float rate = (  1f -  ( botao.animacao_atual_tempo_ms  / botao.data.animacao_OFF_para_ON_tempos.tempo_espera_para_ativar_ms ) );

                Debug.Log( $"rate: { rate }" );
                
                // menos vai ser alterada, manter alpha estatico até perto do final

                int pointer_off_estatico = botao.data.pointers.pointer_imagem_estatica_OFF;
                int pointer_on_estatico = botao.data.pointers.pointer_imagem_estatica_ON;


                Change_colors( botao, pointer_off_estatico, pointer_on_estatico, rate );
                return;


        }



        public static void Lidar_transicao_animacao_ON_para_OFF_cor( Botao_dispositivo botao ){

                
                if( botao.esta_houver ) 
                    { botao.animacao_atual_tempo_ms -= botao.data.animacao_ON_para_OFF_tempos.multiplicador_saida_padrao_animacao * ( Time.deltaTime * 1000f ) ; }
                    
                botao.animacao_atual_tempo_ms -= ( Time.deltaTime * 1000f ) ; 


                if( botao.animacao_atual_tempo_ms < 0.5f )
                    { Botao_dispositivo_SETAR.SET_OFF_static( botao ); return; } // --- FINALIZAR


                float rate = (  1f -  ( botao.animacao_atual_tempo_ms  / botao.data.animacao_ON_para_OFF_tempos.tempo_espera_para_ativar_ms ) );


                Debug.Log( $"rate: { rate }" );

                
                // menos vai ser alterada, manter alpha estatico até perto do final

                int pointer_off_estatico = botao.data.pointers.pointer_imagem_estatica_OFF;
                int pointer_on_estatico = botao.data.pointers.pointer_imagem_estatica_ON;


                Change_colors( botao, pointer_on_estatico, pointer_off_estatico, rate );
                return;

        }




        private static void Change_colors( Botao_dispositivo botao, int pointer_imagem_atual, int pointer_nova_imagem, float rate ){



                // ** IMAGEM ATUAL
                Color cor_imagem_atual_back = botao.data.cores_animacoes_completas[  ( int ) Device_button_animation_part.animation_back , pointer_imagem_atual ];
                Color cor_imagem_atual_base = botao.data.cores_animacoes_completas[  ( int ) Device_button_animation_part.animation_base , pointer_imagem_atual ];
                Color cor_imagem_atual_atras_texto = botao.data.cores_animacoes_completas[  ( int ) Device_button_animation_part.animation_back_text , pointer_imagem_atual ];
                Color cor_imagem_atual_texto = botao.data.cores_animacoes_completas[  ( int ) Device_button_animation_part.animation_back_text , pointer_imagem_atual ];
                Color cor_imagem_atual_decoracao = botao.data.cores_animacoes_completas[  ( int ) Device_button_animation_part.animation_decoration , pointer_imagem_atual ];
                Color cor_imagem_atual_frente_texto = botao.data.cores_animacoes_completas[  ( int ) Device_button_animation_part.animation_front_text , pointer_imagem_atual ];


                // ** TRANSICAO
                Color cor_nova_imagem_back = botao.data.cores_animacoes_completas[  ( int ) Device_button_animation_part.animation_back , pointer_nova_imagem ];
                Color cor_nova_imagem_base = botao.data.cores_animacoes_completas[  ( int ) Device_button_animation_part.animation_base , pointer_nova_imagem ];
                Color cor_nova_imagem_atras_texto = botao.data.cores_animacoes_completas[  ( int ) Device_button_animation_part.animation_back_text , pointer_nova_imagem ];
                Color cor_nova_imagem_texto = botao.data.cores_animacoes_completas[  ( int ) Device_button_animation_part.animation_back_text , pointer_nova_imagem ];
                Color cor_nova_imagem_decoracao = botao.data.cores_animacoes_completas[  ( int ) Device_button_animation_part.animation_decoration, pointer_nova_imagem ];
                Color cor_nova_imagem_frente_texto = botao.data.cores_animacoes_completas[  ( int ) Device_button_animation_part.animation_front_text , pointer_nova_imagem ];


                // // ** COR FRAME ATUAL
                // Color cor_do_frame_atual_back         =  COLOR.Blend_color_with_rate(  cor_nova_imagem_back, cor_imagem_atual_back, rate );
                // Color cor_do_frame_atual_base         =  COLOR.Blend_color_with_rate(  cor_nova_imagem_base, cor_imagem_atual_base, rate );
                // Color cor_do_frame_atual_atras_texto  =  COLOR.Blend_color_with_rate(  cor_nova_imagem_atras_texto, cor_imagem_atual_atras_texto, rate );
                // Color cor_do_frame_atual_texto        =  COLOR.Blend_color_with_rate(  cor_nova_imagem_texto, cor_imagem_atual_texto, rate );
                // Color cor_do_frame_atual_decoracao    =  COLOR.Blend_color_with_rate(  cor_nova_imagem_decoracao, cor_imagem_atual_decoracao, rate );
                // Color cor_do_frame_atual_frente_texto =  COLOR.Blend_color_with_rate(  cor_nova_imagem_frente_texto, cor_imagem_atual_frente_texto, rate );

                

                // ** COR FRAME ATUAL
                Color cor_do_frame_atual_back         =  COLOR.Blend_color_with_rate(   cor_imagem_atual_back, cor_nova_imagem_back, rate );
                Color cor_do_frame_atual_base         =  COLOR.Blend_color_with_rate(   cor_imagem_atual_base, cor_nova_imagem_base, rate );
                Color cor_do_frame_atual_atras_texto  =  COLOR.Blend_color_with_rate(   cor_imagem_atual_atras_texto, cor_nova_imagem_atras_texto, rate );
                Color cor_do_frame_atual_texto        =  COLOR.Blend_color_with_rate(   cor_imagem_atual_texto, cor_nova_imagem_texto, rate );
                Color cor_do_frame_atual_decoracao    =  COLOR.Blend_color_with_rate(   cor_imagem_atual_decoracao, cor_nova_imagem_decoracao, rate );
                Color cor_do_frame_atual_frente_texto =  COLOR.Blend_color_with_rate(   cor_imagem_atual_frente_texto, cor_nova_imagem_frente_texto, rate );

                


                cor_do_frame_atual_back.a *= rate;
                cor_do_frame_atual_base.a *= rate;
                cor_do_frame_atual_atras_texto.a *= rate;
                cor_do_frame_atual_texto.a *= rate;
                cor_do_frame_atual_decoracao.a *= rate;
                cor_do_frame_atual_frente_texto.a *= rate;





                // ** MUDA TRANSICAO
                botao.TRANSITION_animation_back.image.color = cor_do_frame_atual_back;
                botao.TRANSITION_base.image.color = cor_do_frame_atual_base;
                botao.TRANSITION_animation_back_text.image.color = cor_do_frame_atual_atras_texto;
                botao.TRANSITION_text.color = cor_do_frame_atual_texto;
                botao.TRANSITION_decoration.image.color = cor_do_frame_atual_decoracao;
                Debug.Log( cor_do_frame_atual_decoracao );
                botao.TRANSITION_animation_front_text.image.color = cor_do_frame_atual_frente_texto;




                float novo_valor = -1;

                if( rate > 0.95f )
                    { novo_valor = ( 1.2f - rate ); } // --- QUASE NO FINAL => tem que alterar alpha 
                    else
                    { novo_valor =      1f;         } // --- AINDA NO INICIO
                
                cor_do_frame_atual_back.a   = (  cor_imagem_atual_back.a *  novo_valor );
                cor_do_frame_atual_base.a = (  cor_imagem_atual_base.a *  novo_valor );
                cor_do_frame_atual_atras_texto.a = (  cor_imagem_atual_atras_texto.a *  novo_valor );
                cor_do_frame_atual_texto.a = (  cor_imagem_atual_texto.a *  novo_valor );
                cor_do_frame_atual_decoracao.a = (  cor_imagem_atual_decoracao.a *  novo_valor );
                
                cor_do_frame_atual_frente_texto.a = (  cor_imagem_atual_frente_texto.a *  novo_valor );


                // ** MUDA IMAGEM ATRAS 
                botao.IMAGE_animation_back.image.color = cor_do_frame_atual_back;
                botao.IMAGE_base.image.color = cor_do_frame_atual_base;
                botao.IMAGE_animation_back_text.image.color = cor_do_frame_atual_atras_texto;
                botao.IMAGE_text.color = cor_do_frame_atual_texto;
                botao.IMAGE_decoration.image.color = cor_do_frame_atual_decoracao;
                botao.IMAGE_animation_front_text.image.color = cor_do_frame_atual_frente_texto;




                // --- VERIFICA SE TEM DECORACAO COMPOSTA
                if( botao.IMAGE_composed_decoration_images != null )
                    {

                        // --- TEM DECORACAO COMPOSTA

                        int numero_imagens_decoracao_composta = botao.IMAGE_composed_decoration_images.Length;
                        Image[] imagens;

                        // --- MUDAR IMAGEM 

                        imagens = botao.IMAGE_composed_decoration_images;
                        for( int index_imagem = 0 ; index_imagem < numero_imagens_decoracao_composta ; index_imagem++ ){


                                Color cor_decoracao_composta_imagem_atual = botao.data.cores_decoracao_composta[ index_imagem,  pointer_imagem_atual ];
                                Color cor_decoracao_composta_nova_imagem = botao.data.cores_decoracao_composta[ index_imagem,  pointer_nova_imagem ];
                                Color cor    =  COLOR.Blend_color_with_rate( cor_decoracao_composta_nova_imagem, cor_decoracao_composta_imagem_atual, rate );

                                cor.a *= rate; 
                                botao.TRANSITION_composed_decoration_images[ index_imagem ].color = cor; 

                                cor.a = ( cor_decoracao_composta_nova_imagem.a * novo_valor );
                                botao.IMAGE_composed_decoration_images[ index_imagem ].color = cor;

                                continue;

                        }


                    }




                return;


        }
                


}