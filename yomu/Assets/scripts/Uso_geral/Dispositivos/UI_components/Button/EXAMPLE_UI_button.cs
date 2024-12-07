using UnityEngine;


public static class EXAMPLE_UI_button {


        public static UI_button Simple( GameObject _button_game_object ){


                UI_button botao = UI_button.Get_button();
                ref DATA__UI_button dados = ref botao.data;

                // --- PUT DATA

                        dados.tipo_ativacao = Botao_dispositivo_tipo_ativacao.clicar;

                        dados.simple_button_OFF_frame.path = "a";
                        dados.OFF_and_ON_equal = true;
                        dados.tipo_transicao = DEVICE_button_transition_type_OFF_ON.cor;
                        dados.type = UI_button_type.simple;
                        
                        dados.path_locator = "a";
                        dados.main_folder = "teste";

                        dados.text_on = "on";
                        dados.text_off = "off";
                        dados.text_OFF_and_ON_equal = false;

                        dados.image_resource_pre_allocation = Resource_image_content.compress_data;
                

                // ** get resources 
                botao.Define_button();

                //Console.Log( "Minimun image: " +  botao.manager_resources.minimun.image );

                // ** link to game_object
                
                botao.Link_to_game_object( _button_game_object ); // precisa que struct esteja ativa

                // RESOURCE__structure_copy s_c = null;
                // botao.Get_data( s_c.Get_component_game_object( "botao" ) );

                botao.manager_resources.Load();

                botao.Activate_button();


                return botao;

        }


}
