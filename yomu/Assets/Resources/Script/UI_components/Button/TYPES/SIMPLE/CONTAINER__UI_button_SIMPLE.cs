


using UnityEngine;

public class CONTAINER__UI_button_SIMPLE : CONTAINER__generic<UI_button_SIMPLE> {
                                                 

        public override void Reset_data( UI_button_SIMPLE button ){
            
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

                // ** BODY

                    GameObject.Destroy( button.body_container );

                    button.body_container = null;
                    button.off_set_rotation_container = null;
                    button.structure_container = null;

                    button.name = "";
                    button.body_data = Body_data.Construct();


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

                button.current_visual_state = UI_button_SIMPLE_visual_state.off_estatico;  
                button.visual_state_going_to = UI_button_SIMPLE_visual_state.off_estatico; 



                // ?? 
                button.estado_visual_botao = UI_button_SIMPLE_visual_state.off_estatico;
                button.ultimo_estado_visual_botao = UI_button_SIMPLE_visual_state.off_estatico;


        }
        
                
}
