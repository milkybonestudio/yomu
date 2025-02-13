using UnityEngine;



// ** exemplos sempre vao usar contexto Testing



public static class EXAMPLE_UI_button {


        // ** a logica do botao NAO vai ser: pegar structure -> links -> instanciate
        // ** os UI components vao ser sempre usados dentro de outras structures
        // ** a logica seria structure -> game_object do botao -> link ( generico ) -> instanciate 
        // ** UIs nao tem structures, pois ela vai estar na structure do objeto principal 


        // Convert_creation_data_TO_resources -> usa os dados de criação para criar o objeto principal com os objetos recursos já pegos.
        //                                       se em algum momento der problema optimizar o quao rapido pega os recursos
        // link   -> quem tom o botao sinaliza que já foi carregado a struct 
        // load   -> fala que pode carregar os minimos do botao

        
        // convert, link e load geralmente nao vao ser chamados individualmente a não ser que o device seja pequeno
        // todo Body tem um List<UI_components> e metodos Link_UIs(), Load_UIs() e Convert_creation_data_TO_resources_UIs()


        // ** o botao constroe a parte visual e a logica é definida em quem pediu o botao
        // ** o _path_to_button é om path relativo a structure
        public static UI_button Construct( string _path_to_button_in_device ){
            

                // ** um botao só consegue pegar recursos do contexto e do main folder. 
                // ** porem um device pode ter botoes de diferentes contextos

                UI_button_SIMPLE botao = UI_button_SIMPLE.Get_button();
                
                botao.path_to_UI = _path_to_button_in_device;

                ref DATA_CREATION__UI_button_SIMPLE data_creation = ref botao.creation_data;

                // --- PUT DATA

                        data_creation.name = "Botao_exemplo";
                        data_creation.main_folder = "main_folder";
                        data_creation.context = Resource_context.Testing;

                        
                        data_creation.tipo_ativacao = UI_button_activation_type.clicar;

                        // ** sempre passa objetivo, se precisar encurtar usar root + final

                        data_creation.image_path_OFF = "a";
                        data_creation.image_path_ON = "device_folder_1/buttons/b";

                        data_creation.text = "TESTE";

                        data_creation.tipo_transicao = DEVICE_button_transition_type_OFF_ON.cor;
                        
                        
                        data_creation.image_resource_pre_allocation = Resource_image_content.compress_data;


                return botao;

            
        }

        public static UI_button Construct_unitary( string _path_to_button_in_world ){

                string path_in_device = null;
                UI_button botao = EXAMPLE_UI_button.Construct( path_in_device ); // nao vai usar o path pois vai pegar o gameObject que esta no mundo

                botao.Convert_creation_data_TO_resources();

                GameObject button_game_object = GameObject.Find( _path_to_button_in_world );


                botao.Instanciate_UI();
                
                return botao;

        }


        public static void In_device(){

                // ** o device fica responsavel por criar os botoes
                // ** Example_devices_with_UIs ( chama ) =>  EXAMPLE_UI_button
                Example_devices_with_UIs device = Example_devices_with_UIs.Construct( Example_devices_with_UIs_types.type_1 );


                // ** device sempre faz todas as operacoes
                device.Convert_creation_data_TO_resources_UIs();

                // ** device já contem a structure, entao ele nao precisa de nenhuma outra referencia
                device.Link_to_game_object_UIs();

                device.Load_UIs();

                GameObject place_to_put_the_device = GameObject.Find( "place_to_put_the_device" );
                device.Instanciate( place_to_put_the_device );


        }





}

