using UnityEngine;



public static class TOOL__UI_button_VERIFICATIONS {



        public static void Verify_default( Botao_dispositivo _button ){

                CONTROLLER__errors.Verify( ( _button.state != Resource_use_state.used ), $"Tried to define button { _button.button_name } but the button is with the state { _button.state }" );
                CONTROLLER__errors.Verify( ( _button.data == null ), $"Tried to define button { _button.button_name } but the data was null" );
                CONTROLLER__errors.Verify( ( _button.data.state != Resource_use_state.used ), $"Tried to define button { _button.button_name } but the data was with state { _button.data.state }" );

                CONTROLLER__errors.Verify( ( _button.data.tempo_transicao == 0f ), $"in the button { _button.button_name } the transition default time is 0" );

                // --- VERIFICACOES
                TOOL__device_UI_SUPPORT.Verificar_nome( _button.data.nome );

                CONTROLLER__errors.Verify( ( _button.data.main_folder == null ), $"Button { _button.button_name } does not have the main folder" );

                CONTROLLER__errors.Verify( ( _button.data.text_off == null ), $"Button { _button.button_name } does not have the <Color=light_blue>text_off</Color>" );

                CONTROLLER__errors.Verify( ( ( _button.data.text_on != null ) && ( _button.data.text_OFF_and_ON_equal ) ), $"Button { _button.button_name } have text_OFF_and_ON_equal but the text on ON is <Color=light_blue>{ _button.data.text_on }</Color>" );

                if( _button.data.text_OFF_and_ON_equal )
                    { _button.data.text_on = _button.data.text_on; }

                CONTROLLER__errors.Verify( ( _button.data.text_on == null ), $"Button { _button.button_name } does not have the <Color=light_blue>text_ON</Color>" );

                        

        }


}



