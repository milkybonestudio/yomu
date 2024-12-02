using UnityEngine;

public static class TOOL__UI_button_UPDATE {








        public static void Update_logica( UI_button _button ){


                
                if( _button.data.bloquear_update_logico )
                    { return; }


                // --- VERIFICAR HOUVER
                if( _button.esta_houver )
                    {
                        // --- VERIFICA SE MOUSE CONTINUA NO BOTAO
                        _button.esta_houver = Polygon.Check_point_inside( _button.ON_collider.points, ( Vector2 ) _button.botao_game_object.transform.position , CONTROLLER__input.Pegar_instancia().pointer_position );
                    
                        if( !!!( _button.esta_houver ) )
                            { _button.esta_down = false; return; } // --- SAIU
                    }
                    else
                    { 
                        // --- VERIFICA SE ENTROU
                        _button.esta_houver = Polygon.Check_point_inside( _button.OFF_collider.points, ( Vector2 ) _button.botao_game_object.transform.position , CONTROLLER__input.Pegar_instancia().pointer_position ); 
                        
                        if( !!!( _button.esta_houver ) )
                            { return; } // --- NAO ENTROU
                            
                        // --- VERIFICA SE EH TIPO ENTRADA
                        if( _button.data.tipo_ativacao == Botao_dispositivo_tipo_ativacao.entrar_no_botao )
                            { _button.data.Ativar(); return; } // --- ATIVAR BOTAO
            
                    } 


                // --- VERIFICAR DOWN

                if( Input.GetMouseButtonDown( 0 ) )
                    { 

                        _button.esta_down = true; 
                        if( _button.data.tipo_ativacao == Botao_dispositivo_tipo_ativacao.clicar )
                            { _button.data.Ativar(); } // --- ATIVAR BOTAO
                        
                    }


                if( Input.GetMouseButtonUp( 0 ) && _button.esta_down )
                    { 
                        // --- ATIVA SOMENTE QUANDO DEU DOWN ANTERIORMENTE
                        if( _button.data.tipo_ativacao == Botao_dispositivo_tipo_ativacao.clicar_e_soltar && _button.esta_down )
                            { _button.data.Ativar(); } // --- ATIVAR BOTAO

                    }


                if( !!!( Input.GetMouseButton( 0 ) ) )
                    { _button.esta_down = false; }


        }





        // --- PART VISUAL

        public static void Update_parte_visual( UI_button _button ){

                
                if( _button.data.bloquear_update_visual  )
                    { return; }


                _button.ultimo_estado_visual_botao = _button.estado_visual_botao;


                switch( _button.type ){

                    case UI_button_type.simple: Update_visual_part_SIMPLE( _button ); break;
                    case UI_button_type.complete: Update_visual_part_COMPLETE( _button ); break;
                    case UI_button_type.complex: Update_visual_part_COMPLEX( _button ); break;
                    default: CONTROLLER__errors.Throw( $"Can not handle the type { _button.type } in Update visual part button" ); break;

                }

        }



        public static void Update_visual_part_SIMPLE( UI_button _button ){

                
                switch( _button.estado_visual_botao ){

                        case DEVICE_button_visual_state.off_estatico: TOOL__UI_button_handler_SIMPLE.Handle_off_static( _button ); break;
                        case DEVICE_button_visual_state.on_estatico: TOOL__UI_button_handler_SIMPLE.Handle_on_static( _button ); break;

                        case DEVICE_button_visual_state.transicao_animacao_OFF_para_ON: TOOL__UI_button_handler_SIMPLE.Handle_transition_animation_OFF_to_ON( _button ); break;
                        case DEVICE_button_visual_state.transicao_animacao_ON_para_OFF: TOOL__UI_button_handler_SIMPLE.Lidar_transicao_animacao_ON_para_OFF( _button ); break;

                        default: CONTROLLER__errors.Throw( $"can not handle stage { _button.estado_visual_botao }" ); break;

                }

        }


        public static void Update_visual_part_COMPLETE( UI_button _button ){


                switch( _button.estado_visual_botao ){

                        case DEVICE_button_visual_state.off_estatico: TOOL__UI_button_handler_COMPLETE.Handle_off_static( _button ); break;
                        case DEVICE_button_visual_state.on_estatico: TOOL__UI_button_handler_COMPLETE.Handle_on_static( _button ); break;

                        case DEVICE_button_visual_state.transicao_animacao_OFF_para_ON: TOOL__UI_button_handler_COMPLETE.Handle_transition_animation_OFF_to_ON( _button ); break;
                        case DEVICE_button_visual_state.transicao_animacao_ON_para_OFF: TOOL__UI_button_handler_COMPLETE.Lidar_transicao_animacao_ON_para_OFF( _button ); break;

                        default: CONTROLLER__errors.Throw( $"can not handle stage { _button.estado_visual_botao }" ); break;

                }


        }

        
        public static void Update_visual_part_COMPLEX( UI_button _button ){


                switch( _button.estado_visual_botao ){

                        case DEVICE_button_visual_state.off_estatico: TOOL__UI_button_handler_COMPLEX.Handle_off_static( _button ); break;
                        case DEVICE_button_visual_state.off_animacao: TOOL__UI_button_handler_COMPLEX.Handle_off_animation( _button ); break;
                        case DEVICE_button_visual_state.on_estatico: TOOL__UI_button_handler_COMPLEX.Handle_on_static( _button ); break;
                        case DEVICE_button_visual_state.on_animacao: TOOL__UI_button_handler_COMPLEX.Handle_on_animation( _button ); break;

                        case DEVICE_button_visual_state.transicao_animacao_OFF_para_ON: TOOL__UI_button_handler_COMPLEX.Handle_transition_animation_OFF_to_ON( _button ); break;
                        case DEVICE_button_visual_state.transicao_animacao_ON_para_OFF: TOOL__UI_button_handler_COMPLEX.Handle_transition_animation_ON_to_OFF( _button ); break;

                }


        }

        
    

}