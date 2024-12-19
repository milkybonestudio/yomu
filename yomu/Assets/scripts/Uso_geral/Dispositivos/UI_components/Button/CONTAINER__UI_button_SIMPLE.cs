

public class CONTAINER__UI_button_SIMPLE {


        private class Args {}

        private void Put_data_args(){}


        public static void Put_data( object _obj ){

            Args args = CONTAINER__UI_button_SIMPLE.args;
            UI_button_SIMPLE Exemplo = ( UI_button_SIMPLE ) _obj;

            // ** change

        }

        public static void Remove_data( object _obj ){
            

                UI_button_SIMPLE button = ( UI_button_SIMPLE ) _obj;
                // ** change

                // ** COLLIDERS

                    button.COLLIDERS_container = null;

                        button.OFF_collider_game_object = null;
                        button.ON_collider_game_object = null;

                        button.OFF_collider = null;
                        button.ON_collider = null;


                // --- IMAGE
                    button.IMAGE_container = null;
                        button.IMAGE_text = new Unity_main_components();
                        button.IMAGE_body = new Unity_main_components();

                // --- TRANSICAO
                    button.TRANSITION_container = null;
                        button.TRANSITION_text = new Unity_main_components();
                        button.TRANSITION_body = new Unity_main_components();




                button.resource_state = Resource_state.nothing;


                button.manager_resources = new MANAGER__UI_button_resources_SIMPLE();
                button.data = new DATA__UI_button_SIMPLE();


                button.container = new UI_container();
                // button.botao_game_object;


                button.button_name = "Nao_colocou";


                // --- LOGICA

                button.is_active = false;
                button.state = Resource_use_state.unused;



                button.type = UI_button_type.not_give;


                button.esta_down = false; 
                button.esta_houver = false;


                // nome ta meio merda
                button.animacao_atual_tempo_ms = 0f;
                button.animacao_sprite_atual_tempo_ms = 0f;
                button.sprite_atual_index = -1;




                // ---- VISUAL

                button.current_visual_state = DEVICE_button_visual_state.off_estatico;
                button.visual_state_going_to = DEVICE_button_visual_state.off_estatico;



                // ?? 
                button.estado_visual_botao = DEVICE_button_visual_state.off_animacao;
                button.ultimo_estado_visual_botao = DEVICE_button_visual_state.off_estatico;



        }


        private static Args args = new Args();

        public CONTAINER__generic container_generic = new CONTAINER__generic( typeof( UI_button_SIMPLE ), 300, Put_data, Remove_data );

        public UI_button_SIMPLE Get_button(){  Put_data_args(); return ( UI_button_SIMPLE ) container_generic.Get(); }
        public void Return_button( UI_button_SIMPLE exemplo ){ container_generic.Return_object( exemplo ); }
        public int Update( int _weight_to_stop, int _current_weight  ){ return container_generic.Update( _weight_to_stop, _current_weight ); }




}
