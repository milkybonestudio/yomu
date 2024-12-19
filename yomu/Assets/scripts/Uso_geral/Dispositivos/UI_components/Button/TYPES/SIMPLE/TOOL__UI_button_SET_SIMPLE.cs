using UnityEngine;


public static class TOOL__UI_button_SET_SIMPLE {


        public static void Hide( UI_button_SIMPLE botao ){

                botao.IMAGE_container.SetActive( false );
                botao.TRANSITION_container.SetActive( false );

        }

        public static void SET_ON_static( UI_button_SIMPLE botao ){


                // esconde outros
                botao.IMAGE_container.SetActive( true );
                botao.TRANSITION_container.SetActive( false );


                botao.IMAGE_body.image.sprite = botao.data.button_ON_frame.image_ref.Get_sprite();
                botao.IMAGE_body.image.color = botao.data.button_ON_frame.color;
                
                botao.IMAGE_text.tmp_text.text = botao.data.text_on;
                botao.IMAGE_text.tmp_text.color = botao.data.button_ON_text_color;

            
                botao.estado_visual_botao = DEVICE_button_visual_state.on_estatico;
                botao.Update_parte_visual();

                return;


        }


        public static void SET_OFF_static( UI_button_SIMPLE botao ){

                // esconde outros
                botao.IMAGE_container.SetActive( true );
                botao.TRANSITION_container.SetActive( false );


                botao.IMAGE_body.image.sprite = botao.data.button_OFF_frame.image_ref.Get_sprite();
                botao.IMAGE_body.image.color = botao.data.button_OFF_frame.color;
                
                botao.IMAGE_text.tmp_text.text = botao.data.text_off;
                botao.IMAGE_text.tmp_text.color = botao.data.button_OFF_text_color;

            
                botao.estado_visual_botao = DEVICE_button_visual_state.off_estatico;
                botao.Update_parte_visual();

                return;

        }





        public static void SETAR_transicao_ON_para_OFF( UI_button_SIMPLE botao ){


                     if( botao.data.tipo_transicao == DEVICE_button_transition_type_OFF_ON.cor )
                        {
                            // --- COR

                            // --- MOSTRAR 2 GAME_OBJECTS
                            botao.IMAGE_container.SetActive( true );
                            botao.TRANSITION_container.SetActive( true );


                            // --- PUT SPRITES
                            botao.IMAGE_body.image.sprite = botao.data.button_ON_frame.image_ref.Get_sprite();
                            botao.IMAGE_body.image.color = botao.data.button_ON_frame.color;

                            botao.TRANSITION_body.image.sprite = botao.data.button_OFF_frame.image_ref.Get_sprite();
                            botao.TRANSITION_body.image.color = botao.data.button_OFF_frame.color;
                            

                            // --- PUT TEXT
                            botao.IMAGE_text.tmp_text.text = botao.data.text_on;
                            botao.IMAGE_text.tmp_text.color = botao.data.button_ON_text_color;

                            botao.TRANSITION_text.tmp_text.text = botao.data.text_off;
                            botao.TRANSITION_text.tmp_text.color = botao.data.button_OFF_text_color;



                            // --- RESETA DADOS
                            botao.animacao_atual_tempo_ms = botao.data.time_transition_ON_to_OFF;
                            botao.estado_visual_botao = DEVICE_button_visual_state.transicao_animacao_ON_para_OFF;

                            botao.Update_parte_visual();

                            return;

                        }

                else if( true )
                        {
                            // --- NADA
                            SET_OFF_static( botao );
                            botao.estado_visual_botao = DEVICE_button_visual_state.off_estatico;
                            return;

                        }

                CONTROLLER__errors.Throw( $"Can not handle <Color=lightBlue>{ botao.data.tipo_transicao }</Color>" );

        }



        public static void SET_transition_OFF_to_ON( UI_button_SIMPLE botao ){

                
                     if( botao.data.tipo_transicao == DEVICE_button_transition_type_OFF_ON.cor )
                        {
                            // --- COR

                            // --- MOSTRAR 2 GAME_OBJECTS
                            botao.IMAGE_container.SetActive( true );
                            botao.TRANSITION_container.SetActive( true );




                            // --- PUT SPRITES
                            botao.IMAGE_body.image.sprite = botao.data.button_OFF_frame.image_ref.Get_sprite();
                            botao.IMAGE_body.image.color = botao.data.button_OFF_frame.color;

                            botao.TRANSITION_body.image.sprite = botao.data.button_ON_frame.image_ref.Get_sprite();
                            botao.TRANSITION_body.image.color = botao.data.button_ON_frame.color;
                            

                            // --- PUT TEXT
                            botao.IMAGE_text.tmp_text.text = botao.data.text_off;
                            botao.IMAGE_text.tmp_text.color = botao.data.button_OFF_text_color;

                            botao.TRANSITION_text.tmp_text.text = botao.data.text_on;
                            botao.TRANSITION_text.tmp_text.color = botao.data.button_ON_text_color;



                            // --- RESETA DADOS
                            botao.animacao_atual_tempo_ms = botao.data.time_transition_OFF_to_ON;
                            botao.estado_visual_botao = DEVICE_button_visual_state.transicao_animacao_OFF_para_ON;
                            
                            botao.Update_parte_visual();

                            return;

                        }

                else if( true )
                        {
                            // --- NADA
                            SET_ON_static( botao );
                            botao.estado_visual_botao = DEVICE_button_visual_state.on_estatico;
                            return;

                        }

                CONTROLLER__errors.Throw( $"Can not handle <Color=lightBlue>{ botao.data.tipo_transicao }</Color>" );

        }






}