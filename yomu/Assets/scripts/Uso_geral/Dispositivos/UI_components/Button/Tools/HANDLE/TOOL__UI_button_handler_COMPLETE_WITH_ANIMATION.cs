using UnityEngine;


public static class TOOL__UI_button_handler_COMPLETE_WITH_ANIMATION {


        // --- OFF

        public static void Handle_off_static( Botao_dispositivo _button ){


                // --- VERIFICA SE TEM INTERACAO COM O MOUSE
                if(  _button.esta_houver )
                    { TOOL__UI_button_SET_COMPLEX.SET_transition_OFF_to_ON( _button ); return; } // --- TEM QUE IR PARA TRANSICAO


                _button.animacao_atual_tempo_ms -= ( Time.deltaTime * 1000f );

                // --- VERIFICA SE PODE INICIAR ANIMACAO OFF
                if( _button.animacao_atual_tempo_ms < 0f )
                    { TOOL__UI_button_SET_COMPLEX.SET_OFF_animation( _button ); }// --- VAI INICIAR ANIMACAO

                return;
                
            
        }




        public static void Handle_off_animation( Botao_dispositivo _button ){
            

                // --- PASSAR TEMPO
                if( _button.esta_houver )
                    { _button.animacao_sprite_atual_tempo_ms -= _button.data.animacao_off_tempos.multiplicador_saida_padrao_animacao * ( Time.deltaTime * 1000f ) ;}// --- PRECISA ACELERAR PARA FINALIZAR RAPIOD
                    else
                    { _button.animacao_sprite_atual_tempo_ms -= ( Time.deltaTime * 1000f ) ; } // --- TEMPO NORMAL

                
                // --- VERIFICA SE TEM QUE ESPERAR
                if( _button.animacao_sprite_atual_tempo_ms > 0f )
                    { return; }

                
                // --- VERIFICA SE ESSA ERA A ULTIMA SPRITE
                if( _button.sprite_atual_index == ( _button.data.pointers.pointer_final_animacao_OFF - 1 ) )
                    { TOOL__UI_button_SET_COMPLEX.SET_OFF_static( _button ); return; } // --- VOLTAR PARA STATIC

                
                // ---TROCAR SPRITE
                _button.sprite_atual_index++;
                Botao_dispositivo_MUDAR_IMAGEM.Change_images_IMAGE( _button, _button.sprite_atual_index );

                // RENOVA TEMPO
                if( _button.data.animacao_off_tempos.tempo_troca_sprite_ms_por_sprite != null )
                    { _button.animacao_sprite_atual_tempo_ms = _button.data.animacao_off_tempos.tempo_troca_sprite_ms_por_sprite[ _button.sprite_atual_index ]; }// --- TEM TEMPO DIFERENTE PARA CADA SPRITE
                    else
                    { _button.animacao_sprite_atual_tempo_ms = _button.data.animacao_off_tempos.tempo_troca_sprite_ms; } // --- TEMPO UNICO


                return;


        }


        // --- ON

        public static void Handle_on_static( Botao_dispositivo _button ){


                // --- VERIFICA SE O MAUSE SAIU
                if( !!!( _button.esta_houver ) )
                    { TOOL__UI_button_SET_COMPLEX.SETAR_transicao_ON_para_OFF( _button ); return; } // --- INICIAR TRANSICAO ON => OFF

                _button.animacao_atual_tempo_ms -= ( Time.deltaTime * 1000f );


                // --- VERIFICA SE PODE INICIAR ANIMACAO ON
                if( _button.animacao_atual_tempo_ms < 0f )
                    { TOOL__UI_button_SET_COMPLEX.SETAR_ON_animacao( _button ); }  // --- TEM ANIMACAO ON ESTATICA 


                return;
                
        }


        public static void Handle_on_animation( Botao_dispositivo _button ){
            

                // --- PASSAR TEMPO
                if( !!!( _button.esta_houver ) )
                    { _button.animacao_sprite_atual_tempo_ms -= _button.data.animacao_on_tempos.multiplicador_saida_padrao_animacao * ( Time.deltaTime * 1000f ) ;}// --- PRECISA ACELERAR PARA FINALIZAR RAPIOD
                    else
                    { _button.animacao_sprite_atual_tempo_ms -= ( Time.deltaTime * 1000f ) ; } // --- TEMPO NORMAL


                // --- VERIFICA SE TEM QUE ESPERAR
                if( _button.animacao_sprite_atual_tempo_ms > 0f )
                    { return; }


                // --- TEM QUE TROCAR FRAME


                //// --- VERIFICA SE ESSA ERA A ULTIMA SPRITE
                    if( _button.sprite_atual_index == ( _button.data.pointers.pointer_final_animacao_ON - 1 ) )
                    { TOOL__UI_button_SET_COMPLEX.SET_ON_static( _button ); return; }// --- VOLTAR PARA STATIC 


                // --- TROCAR SPRITE
                _button.sprite_atual_index++;
                Botao_dispositivo_MUDAR_IMAGEM.Change_images_IMAGE( _button, _button.sprite_atual_index );

                
                // --- RENOVA TEMPO
                if( _button.data.animacao_on_tempos.tempo_troca_sprite_ms_por_sprite != null )
                    { _button.animacao_sprite_atual_tempo_ms = _button.data.animacao_on_tempos.tempo_troca_sprite_ms_por_sprite[ _button.sprite_atual_index ]; }// --- TEM TEMPO DIFERENTE PARA CADA SPRITE
                    else
                    { _button.animacao_sprite_atual_tempo_ms = _button.data.animacao_on_tempos.tempo_troca_sprite_ms; } // --- TEMPO UNICO


                return;


        }


        // --- TRANSICAO

        public static void Handle_transition_animation_OFF_to_ON( Botao_dispositivo _button ){


                switch( _button.data.tipo_transicao ){

                    case DEVICE_button_transition_type_OFF_ON.nada : TOOL__UI_button_SET_COMPLEX.SET_ON_static( _button ); break;
                    case DEVICE_button_transition_type_OFF_ON.cor : Botao_dispositivo_TRANSICAO.Handle_transition_animation_OFF_to_ON_color( _button ); break;
                    case DEVICE_button_transition_type_OFF_ON.animacao_individual : Botao_dispositivo_TRANSICAO.Handle_transition_animation_OFF_to_ON_individual_animation( _button ); break;
                
                }


        }


        // --- ON -> OFF

        public static void Lidar_transicao_animacao_ON_para_OFF( Botao_dispositivo _button ){
            
                switch( _button.data.tipo_transicao ){

                    case DEVICE_button_transition_type_OFF_ON.nada : TOOL__UI_button_SET_COMPLEX.SET_OFF_static( _button ); break;
                    case DEVICE_button_transition_type_OFF_ON.cor : Botao_dispositivo_TRANSICAO.Lidar_transicao_animacao_ON_para_OFF_cor( _button ); break;
                    case DEVICE_button_transition_type_OFF_ON.animacao_individual : Botao_dispositivo_TRANSICAO.Lidar_transicao_animacao_ON_para_OFF_animacao_individual( _button ); break;
                
                }



        }







}