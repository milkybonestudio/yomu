


public static class TOOL__UI_button {



        
        public static void Define_button( Dispositivo dispositivo, Botao_dispositivo _botao ){

                CONTROLLER__errors.Verify( ( _botao.data == null ), $"Tried to define button { _botao.button_name } but the data was null" );
                CONTROLLER__errors.Verify( ( _botao.data.state != Resource_use_state.used ), $"Tried to define button { _botao.button_name } but the data was with state { _botao.data.state }" );


                // --- VERIFICACOES
                TOOL__device_UI_SUPPORT.Verificar_nome( dispositivo.nome_dispositivo, _botao.data.nome );
                _botao.button_name = ( dispositivo.nome_dispositivo + "_BOTAO_" + _botao.data.nome ); // ** so pode ter o nome quando os dados forem preenchidos 


                switch( _botao.type ){

                    case UI_button_type.simple: TOOL__UI_button_constructor.Construir_botao_SIMPLE( _botao ); break;
                    case UI_button_type.complete: TOOL__UI_button_constructor.Construir_botao_COMPLETE( _botao ); break;
                    default: CONTROLLER__errors.Throw( $"Can not handle type { _botao.type }" ); break;

                }

                return;                    

        }



}