using UnityEngine;



public static class TOOL__UI_button_VERIFICATIONS_COMPLETE {


        // ** assume que os dados já estao prontos
        public static void Verify_default( UI_button_COMPLETE _button ){

                throw new System.Exception( "tem que fazer" );

                // if( _button.state != Resource_use_state.used )
                //     { CONTROLLER__errors.Throw( $"Tried to define button { _button.button_name } but the button is with the state { _button.state }" ); }
                
                // if( _button.creation_data.tempo_transicao == 0f )
                //     { CONTROLLER__errors.Throw( $"in the button { _button.button_name } the transition default time is 0" ); }
                
                // TOOL__device_UI_SUPPORT.Verificar_nome( _button.button_name );

                // // --- VERIFICACOES

                // if( _button.data.main_folder == null )
                //     { CONTROLLER__errors.Throw( $"Button { _button.button_name } does not have the main folder" ); }

                // if( _button.button_name == null )
                //     { CONTROLLER__errors.Throw( $"Tried to instanciate a button but it does not have a name" ); }


                // if( _button.creation_data.simple_image_path != null )
                //     {

                //         if( _button.creation_data.simple_image_path_OFF != null )
                //             { CONTROLLER__errors.Throw( $"button { _button.button_name } defines a path <Color=lightBlue>{ _button.creation_data.simple_image_path }</Color> for OFF and ON but in the OFF path is <Color=lightBlue>{  _button.creation_data.simple_image_path_OFF }</Color>" ); }

                //         if( _button.creation_data.simple_image_path_ON != null )
                //             { CONTROLLER__errors.Throw( $"button { _button.button_name } defines a path <Color=lightBlue>{ _button.creation_data.simple_image_path }</Color> for OFF and ON but in the ON path is <Color=lightBlue>{ _button.data.simple_button_ON_frame.path }</Color>" ); }

                //     }
                //     else
                //     {
                        
                //         if( _button.creation_data.simple_image_path_ON == null )
                //             { CONTROLLER__errors.Throw( $"button { _button.button_name } do not define <Color=lightBlue>path_ON</Color>" ); }

                //         if( _button.creation_data.simple_image_path_OFF == null )
                //             { CONTROLLER__errors.Throw( $"button { _button.button_name } do not define <Color=lightBlue>path_OFF</Color>" ); }                

                //     }



                        
        }


}



