


public static class Botao_dispositivo_MUDAR_IMAGEM {





        public static void Mudar_imagens_TRANSICAO(  Botao_dispositivo botao, int pointer ){



                // ** animacao_back_image
                botao.TRANSITION_animation_back_image.sprite          =  botao.data.sprites_animacoes_completas[  ( int ) Device_button_animation_part.animation_back , pointer ];
                botao.TRANSITION_animation_back_image.color           =  botao.data.cores_animacoes_completas[  ( int ) Device_button_animation_part.animation_back , pointer ];

                // _base_image
                botao.TRANSITION_base_image.sprite                   =  botao.data.sprites_animacoes_completas[  ( int ) Device_button_animation_part.animation_base , pointer ];
                botao.TRANSITION_base_image.color                    =  botao.data.cores_animacoes_completas[  ( int ) Device_button_animation_part.animation_base , pointer ];

                // _animacao_atras_texto_image
                botao.TRANSITION_animation_back_text_image.sprite   =  botao.data.sprites_animacoes_completas[  ( int ) Device_button_animation_part.animation_back_text , pointer ];
                botao.TRANSITION_animation_back_text_image.color    =  botao.data.cores_animacoes_completas[  ( int ) Device_button_animation_part.animation_back_text , pointer ];

                // _texto
                botao.TRANSITION_text.color                         =  botao.data.cores_animacoes_completas[  ( int ) Device_button_animation_part.animation_back_text , pointer ];

                // _decoracao_image
                botao.TRANSITION_decoration_image.sprite              =  botao.data.sprites_animacoes_completas[  ( int ) Device_button_animation_part.animation_decoration , pointer ];
                botao.TRANSITION_decoration_image.color               =  botao.data.cores_animacoes_completas[  ( int ) Device_button_animation_part.animation_decoration , pointer ];

                // _animacao_frente_texto_image
                botao.TRANSITION_animation_front_text_image.sprite  =  botao.data.sprites_animacoes_completas[  ( int ) Device_button_animation_part.animation_front_text , pointer ];
                botao.TRANSITION_animation_front_text_image.color   =  botao.data.cores_animacoes_completas[  ( int ) Device_button_animation_part.animation_front_text , pointer ];

                if( botao.TRANSITION_composed_decoration_game_object != null  )
                    {
                        // --- TEM DECORACAO COMPOSTA

                        for( int index = 0 ; index < botao.IMAGE_composed_decoration_images.Length ; index++ ){

                            botao.TRANSITION_composed_decoration_images[ index ].color = botao.data.cores_decoracao_composta[ index, pointer ];
                            botao.TRANSITION_composed_decoration_images[ index ].sprite =  botao.data.sprites_decoracao_composta[ index, pointer ];

                        }
                        
                    }


        }



        public static void Change_images_IMAGE(  Botao_dispositivo botao, int pointer ){



                // ** animacao_back_image
                botao.IMAGE_animation_back_image.sprite          =  botao.data.sprites_animacoes_completas[  ( int ) Device_button_animation_part.animation_back , pointer ];
                botao.IMAGE_animation_back_image.color           =  botao.data.cores_animacoes_completas[  ( int ) Device_button_animation_part.animation_back , pointer ];

                // _base_image
                botao.IMAGE_base_image.sprite                    =  botao.data.sprites_animacoes_completas[  ( int ) Device_button_animation_part.animation_base , pointer ];
                botao.IMAGE_base_image.color                     =  botao.data.cores_animacoes_completas[  ( int ) Device_button_animation_part.animation_base , pointer ];

                // _animacao_atras_texto_image
                botao.IMAGE_animation_back_text_image.sprite     =  botao.data.sprites_animacoes_completas[  ( int ) Device_button_animation_part.animation_back_text , pointer ];
                botao.IMAGE_animation_back_text_image.color      =  botao.data.cores_animacoes_completas[  ( int ) Device_button_animation_part.animation_back_text , pointer ];


                //mark
                 // esta correto?
                // _texto
                botao.IMAGE_text.color                           =  botao.data.cores_animacoes_completas[  ( int ) Device_button_animation_part.animation_back_text , pointer ];
                

                // _decoracao_image
                botao.IMAGE_decoration_image.sprite              =  botao.data.sprites_animacoes_completas[  ( int ) Device_button_animation_part.animation_decoration , pointer ];
                botao.IMAGE_decoration_image.color               =  botao.data.cores_animacoes_completas[  ( int ) Device_button_animation_part.animation_decoration , pointer ];

                // _animacao_frente_texto_image
                botao.IMAGE_animation_front_text_image.sprite  =  botao.data.sprites_animacoes_completas[  ( int ) Device_button_animation_part.animation_front_text , pointer ];
                botao.IMAGE_animation_front_text_image.color   =  botao.data.cores_animacoes_completas[  ( int ) Device_button_animation_part.animation_front_text , pointer ];


                if( botao.IMAGE_composed_decoration_game_object != null  )
                    {
                        // --- TEM DECORACAO COMPOSTA

                        for( int index = 0 ; index < botao.IMAGE_composed_decoration_images.Length ; index++ ){

                            botao.IMAGE_composed_decoration_images[ index ].color = botao.data.cores_decoracao_composta[ index, pointer ];
                            botao.IMAGE_composed_decoration_images[ index ].sprite =  botao.data.sprites_decoracao_composta[ index, pointer ];

                        }
                        
                    }

                return;

        }







  





}