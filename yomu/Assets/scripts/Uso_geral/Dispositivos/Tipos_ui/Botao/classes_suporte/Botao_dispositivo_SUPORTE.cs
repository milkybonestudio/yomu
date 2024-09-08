


public static class  Botao_dispositivo_SUPORTE {


    public static int Pegar_pointer_inicial_estado( Botao_dispositivo botao, Estado_visual_botao_dispositivo _estado_para_ir ){


            
                switch( _estado_para_ir ){

                    // ** ESTATICA
                    case Estado_visual_botao_dispositivo.off_estatico: return botao.dados.pointers.pointer_imagem_estatica_OFF;
                    case Estado_visual_botao_dispositivo.on_estatico: return botao.dados.pointers.pointer_imagem_estatica_ON; 

                    // ** OFF para ON
                    case Estado_visual_botao_dispositivo.transicao_animacao_OFF_para_ON: return botao.dados.pointers.pointer_inicio_transicao_OFF_para_ON; 
                    case Estado_visual_botao_dispositivo.transicao_animacao_ON_para_OFF: return botao.dados.pointers.pointer_inicio_transicao_ON_para_OFF; 

                    // ** ANIMACOES
                    case Estado_visual_botao_dispositivo.on_animacao: return botao.dados.pointers.pointer_inicio_animacao_ON; 
                    case Estado_visual_botao_dispositivo.off_animacao: return botao.dados.pointers.pointer_inicio_animacao_OFF;
                    default: throw new System.Exception( $"Tipo { _estado_para_ir } nao aceito" ); 

                }


        }



}


