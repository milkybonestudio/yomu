using UnityEngine;

public static class TOOL__UI_button_handler_SIMPLE {

        // --- OFF

        public static void Handle_off_static( Botao_dispositivo _button ){

                
                if(  _button.esta_houver )
                    { TOOL__UI_button_SET_SIMPLE.SET_transition_OFF_to_ON( _button ); return; } // --- TEM QUE IR PARA TRANSICAO

                return;
                        
        }


        // --- ON
        public static void Handle_on_static( Botao_dispositivo _button ){


                // --- VERIFICA SE O MAUSE SAIU
                if( !!!( _button.esta_houver ) )
                    { TOOL__UI_button_SET_SIMPLE.SETAR_transicao_ON_para_OFF( _button ); return; } // --- INICIAR TRANSICAO ON => OFF

                return;
                
        }



        // --- TRANSICAO

        public static void Handle_transition_animation_OFF_to_ON( Botao_dispositivo _button ){


                switch( _button.data.tipo_transicao ){

                     // TOOL__UI_button_SET_SIMPLE
                    case DEVICE_button_transition_type_OFF_ON.nada : TOOL__UI_button_SET_SIMPLE.SET_ON_static( _button ); break;
                    case DEVICE_button_transition_type_OFF_ON.cor : TOOL__UI_button_TRANSITION_SIMPLE.Handle_transition_animation_OFF_to_ON_color( _button ); break;
                    
                    default: CONTROLLER__errors.Throw( $"Can not handle { _button.data.tipo_transicao } with type { _button.type }" ); break;
                
                }


        }


        // --- ON -> OFF

        public static void Lidar_transicao_animacao_ON_para_OFF( Botao_dispositivo _button ){
            
                switch( _button.data.tipo_transicao ){

                    case DEVICE_button_transition_type_OFF_ON.nada : TOOL__UI_button_SET_SIMPLE.SET_OFF_static( _button ); break;
                    case DEVICE_button_transition_type_OFF_ON.cor : TOOL__UI_button_TRANSITION_SIMPLE.Handle_transition_animation_ON_to_OFF_color( _button ); break;

                    default: CONTROLLER__errors.Throw( $"Can not handle { _button.data.tipo_transicao } with type { _button.type }" ); break;
                
                }



        }



}