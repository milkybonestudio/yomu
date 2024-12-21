using UnityEngine;



public static class TOOL__UI_button_VERIFICATIONS_SIMPLE {


        // ** assume que os dados já estao prontos
        public static void Verify_default( UI_button_SIMPLE _button ){


                ref DATA_CREATION__UI_button_SIMPLE data_creation = ref _button.creation_data;

                if( data_creation.name == null )
                    { CONTROLLER__errors.Throw( $"There was no name in a button" ); }



                if( _button.state != Resource_use_state.used )
                    { CONTROLLER__errors.Throw( $"Tried to define button { data_creation.name } but the button is with the state { _button.state }" ); }
                
                // --- TEMPO
                if( data_creation.tempo_transicao == 0f )
                    { CONTROLLER__errors.Throw( $"in the button { data_creation.name } the transition default time is 0" ); }
                

                // --- VERIFICACOES

                if( data_creation.main_folder == null )
                    { CONTROLLER__errors.Throw( $"Button { data_creation.name } does not have the main folder" ); }


                if( data_creation.context == Resource_context.not_given )
                    { CONTROLLER__errors.Throw( $"Button { data_creation.name } have context <Color=lightBlue>NOT_GIVE</Color>" ); }



                if( data_creation.image_path != null )
                    {

                        if( data_creation.image_path_OFF != null )
                            { CONTROLLER__errors.Throw( $"button { data_creation.name } defines a path <Color=lightBlue>{ data_creation.image_path }</Color> for OFF and ON but in the OFF path is <Color=lightBlue>{  data_creation.image_path_OFF }</Color>" ); }

                        if( data_creation.image_path_ON != null )
                            { CONTROLLER__errors.Throw( $"button { data_creation.name } defines a path <Color=lightBlue>{ data_creation.image_path }</Color> for OFF and ON but in the ON path is <Color=lightBlue>{ data_creation.image_path_ON }</Color>" ); }

                    }
                    else
                    {
                        
                        if( data_creation.image_path_ON == null )
                            { CONTROLLER__errors.Throw( $"button { data_creation.name } do not define <Color=lightBlue>path_ON</Color>" ); }

                        if( data_creation.image_path_OFF == null )
                            { CONTROLLER__errors.Throw( $"button { data_creation.name } do not define <Color=lightBlue>path_OFF</Color>" ); }                

                    }

                if( ( data_creation.text == null ) && ( data_creation.text_off == null ) && ( data_creation.text_on == null )  )
                    { CONTROLLER__errors.Throw( $"int the button{ data_creation.name } none text was put in" ); }




                if( data_creation.tipo_transicao == DEVICE_button_transition_type_OFF_ON.animacao_individual )
                    { CONTROLLER__errors.Throw( $"Button { data_creation.name } came in Define_button_SIMPLE but the type was animation" ); }

                        
        }


}



