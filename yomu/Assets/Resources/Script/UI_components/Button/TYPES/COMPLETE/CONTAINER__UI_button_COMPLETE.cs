using UnityEngine;



public class CONTAINER__UI_button_COMPLETE : CONTAINER__generic<UI_button_COMPLETE> {


        public override void Reset_data( UI_button_COMPLETE button ){
            
                // ** COLLIDERS

                    button.COLLIDERS_container = null;

                    button.OFF_collider_game_object = null;
                    button.ON_collider_game_object = null;

                    button.OFF_collider = null;
                    button.ON_collider = null;



                // --- COMPLETE

                // ** OFF 

                    button.IMAGE_container = null;

                        button.IMAGE_animation_back = default; 
                        button.IMAGE_base = default;  
                        button.IMAGE_animation_back_text = default;  
                        button.IMAGE_text = default;  
                        button.IMAGE_decoration = default;  
                        button.IMAGE_animation_front_text = default;  
                        
                        
                            button.IMAGE_composed_decoration_game_object = null;


                // ** TRANSICAO
                    button.TRANSITION_container = null;

                        button.TRANSITION_animation_back = default; 
                        button.TRANSITION_base = default; 
                        button.TRANSITION_animation_back_text = default; 
                        button.TRANSITION_text = default; 
                        button.TRANSITION_decoration = default; 
                        button.TRANSITION_animation_front_text = default; 

                            button.TRANSITION_composed_decoration = null; 


                        button.TRANSITION_composed_decoration_images = null; 
                        button.IMAGE_composed_decoration_images = null ; 



                button.resource_state = Resource_state.nothing;


                button.manager_resources = default; 
                button.data = default; 

                


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

                button.current_visual_state = UI_button_COMPLETE_visual_state.off_estatico;
                button.visual_state_going_to = UI_button_COMPLETE_visual_state.off_estatico;



                // ?? 
                button.estado_visual_botao = UI_button_COMPLETE_visual_state.off_animacao;
                button.ultimo_estado_visual_botao = UI_button_COMPLETE_visual_state.off_estatico;



        }


        


}
