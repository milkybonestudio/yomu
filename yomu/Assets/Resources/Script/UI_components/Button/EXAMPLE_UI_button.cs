using UnityEngine;


public static class EXAMPLE_UI_button {



        // define -> usa os dados de criação para criar o objeto principal com os objetos recursos já pegos.
        //           se em algum momento der problema optimizar o quao rapido pega os recursos 
        // link   -> quem tom o botao sinaliza que já foi carregado a struct 
        // load   -> fala que pode carregar os minimos do botao


        public static UI_button_SIMPLE Simple( GameObject _button_game_object ){


                UI_button_SIMPLE botao = UI_button_SIMPLE.Get_button();

                ref DATA_CREATION__UI_button_SIMPLE data_creation = ref botao.creation_data;

                // --- PUT DATA

                        data_creation.name = "Botao_exemplo";
                        data_creation.main_folder = "teste";
                        data_creation.context = Resource_context.Devices;

                        
                        data_creation.tipo_ativacao = UI_button_activation_type.clicar;

                        data_creation.image_path_OFF = "a";
                        data_creation.image_path_ON = "b";

                        data_creation.text = "TESTE";

                        data_creation.tipo_transicao = DEVICE_button_transition_type_OFF_ON.cor;
                        
                        
                        data_creation.image_resource_pre_allocation = Resource_image_content.compress_data;

                
                
                botao.Define_button();
                botao.Link_to_game_object( _button_game_object ); // precisa que struct esteja ativa
                botao.Load();
                botao.Activate_button();


                return botao;

        }


}
