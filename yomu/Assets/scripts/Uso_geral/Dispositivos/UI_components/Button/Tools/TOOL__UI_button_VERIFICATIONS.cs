using UnityEngine;



public static class TOOL__UI_button_VERIFICATIONS {



        public static void Verify_default( Botao_dispositivo _button ){


                if( _button.state != Resource_use_state.used )
                    { CONTROLLER__errors.Throw( $"Tried to define button { _button.button_name } but the button is with the state { _button.state }" ); }
                
                if( _button.data == null )
                    { CONTROLLER__errors.Throw( $"Tried to define button { _button.button_name } but the data was null" ); }
                
                if( _button.data.state != Resource_use_state.used )
                    { CONTROLLER__errors.Throw(  $"Tried to define button { _button.button_name } but the data was with state { _button.data.state }" ); }
                
                if( _button.data.tempo_transicao == 0f )
                    { CONTROLLER__errors.Throw( $"in the button { _button.button_name } the transition default time is 0" ); }
                
                TOOL__device_UI_SUPPORT.Verificar_nome( _button.data.nome );

                // --- VERIFICACOES

                if( _button.data.main_folder == null )
                    { CONTROLLER__errors.Throw( $"Button { _button.button_name } does not have the main folder" ); }

                if( _button.data.text_off == null )
                    { CONTROLLER__errors.Throw( $"Button { _button.button_name } does not have the <Color=light_blue>text_off</Color>" ); }

                if( ( ( _button.data.text_on != null ) && ( _button.data.text_OFF_and_ON_equal ) ) )
                    { CONTROLLER__errors.Throw( $"Button { _button.button_name } have text_OFF_and_ON_equal but the text on ON is <Color=light_blue>{ _button.data.text_on }</Color>" ); }
                
                if( _button.data.text_OFF_and_ON_equal )
                    { _button.data.text_on = _button.data.text_on; }

                if( _button.data.text_on == null )
                    { CONTROLLER__errors.Throw( $"Button { _button.button_name } does not have the <Color=light_blue>text_ON</Color>" );}

                        
        }


}



