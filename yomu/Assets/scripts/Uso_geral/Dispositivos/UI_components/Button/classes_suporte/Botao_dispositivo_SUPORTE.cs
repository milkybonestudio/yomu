


public static class  Botao_dispositivo_SUPORTE {

    //mark
    // ** vai ser usado somente no complex


    public static int Pegar_pointer_inicial_estado( UI_button botao, DEVICE_button_visual_state _estado_para_ir ){


            
                switch( _estado_para_ir ){

                    // ** ESTATICA
                    case DEVICE_button_visual_state.off_estatico: return botao.data.pointers.pointer_imagem_estatica_OFF;
                    case DEVICE_button_visual_state.on_estatico: return botao.data.pointers.pointer_imagem_estatica_ON; 

                    // ** OFF para ON
                    case DEVICE_button_visual_state.transicao_animacao_OFF_para_ON: return botao.data.pointers.pointer_inicio_transicao_OFF_para_ON; 
                    case DEVICE_button_visual_state.transicao_animacao_ON_para_OFF: return botao.data.pointers.pointer_inicio_transicao_ON_para_OFF; 

                    // ** ANIMACOES
                    case DEVICE_button_visual_state.on_animacao: return botao.data.pointers.pointer_inicio_animacao_ON; 
                    case DEVICE_button_visual_state.off_animacao: return botao.data.pointers.pointer_inicio_animacao_OFF;
                    default: throw new System.Exception( $"Tipo { _estado_para_ir } nao aceito" ); 

                }


        }



}


