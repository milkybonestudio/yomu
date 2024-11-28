using UnityEngine;
using System;



public static class TOOL__UI_button_handler_COMPLETE {


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



        // --- TRANSICAO

        public static void Handle_transition_animation_OFF_to_ON( Botao_dispositivo _button ){


                switch( _button.data.tipo_transicao ){

                    case DEVICE_button_transition_type_OFF_ON.nada : TOOL__UI_button_SET_COMPLEX.SET_ON_static( _button ); break;
                    case DEVICE_button_transition_type_OFF_ON.cor : Botao_dispositivo_TRANSICAO.Handle_transition_animation_OFF_to_ON_color( _button ); break;
                    default: CONTROLLER__errors.Throw( $"Can not handle { _button.data.tipo_transicao } in the COMPLETE type" ); break;
                    

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