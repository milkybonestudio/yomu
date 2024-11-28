using UnityEngine;


public static class TOOL__UI_button_CHANGE_SPRITES_COMPLEX {



        public static void Mudar_imagens_TRANSICAO(  Botao_dispositivo botao, int pointer ){


                // ** animacao_back_image
                botao.TRANSITION_animation_back.image.sprite          =  botao.data.images_refs_animacoes_completas[  ( int ) Device_button_animation_part.animation_back , pointer ].Get_sprite();
                botao.TRANSITION_animation_back.image.color           =  botao.data.cores_animacoes_completas[  ( int ) Device_button_animation_part.animation_back , pointer ];

                // _base.image
                botao.TRANSITION_base.image.sprite                   =  botao.data.images_refs_animacoes_completas[  ( int ) Device_button_animation_part.animation_base , pointer ].Get_sprite();
                botao.TRANSITION_base.image.color                    =  botao.data.cores_animacoes_completas[  ( int ) Device_button_animation_part.animation_base , pointer ];

                // _animacao_atras_texto.image
                botao.TRANSITION_animation_back_text.image.sprite   =  botao.data.images_refs_animacoes_completas[  ( int ) Device_button_animation_part.animation_back_text , pointer ].Get_sprite();
                botao.TRANSITION_animation_back_text.image.color    =  botao.data.cores_animacoes_completas[  ( int ) Device_button_animation_part.animation_back_text , pointer ];

                // _texto
                botao.TRANSITION_text.tmp_text.color                         =  botao.data.cores_animacoes_completas[  ( int ) Device_button_animation_part.animation_back_text , pointer ];

                // _decoracao.image
                botao.TRANSITION_decoration.image.sprite              =  botao.data.images_refs_animacoes_completas[  ( int ) Device_button_animation_part.animation_decoration , pointer ].Get_sprite();
                botao.TRANSITION_decoration.image.color               =  botao.data.cores_animacoes_completas[  ( int ) Device_button_animation_part.animation_decoration , pointer ];

                // _animacao_frente_texto.image
                botao.TRANSITION_animation_front_text.image.sprite  =  botao.data.images_refs_animacoes_completas[  ( int ) Device_button_animation_part.animation_front_text , pointer ].Get_sprite();
                botao.TRANSITION_animation_front_text.image.color   =  botao.data.cores_animacoes_completas[  ( int ) Device_button_animation_part.animation_front_text , pointer ];

                if( botao.TRANSITION_composed_decoration != null  )
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
                botao.IMAGE_animation_back.image.sprite          =  botao.data.images_refs_animacoes_completas[  ( int ) Device_button_animation_part.animation_back , pointer ].Get_sprite();
                botao.IMAGE_animation_back.image.color           =  botao.data.cores_animacoes_completas[  ( int ) Device_button_animation_part.animation_back , pointer ];

                // _base_image
                botao.IMAGE_base.image.sprite                    =  botao.data.images_refs_animacoes_completas[  ( int ) Device_button_animation_part.animation_base , pointer ].Get_sprite();
                botao.IMAGE_base.image.color                     =  botao.data.cores_animacoes_completas[  ( int ) Device_button_animation_part.animation_base , pointer ];

                // _animacao_atras_texto_image
                botao.IMAGE_animation_back_text.image.sprite     =  botao.data.images_refs_animacoes_completas[  ( int ) Device_button_animation_part.animation_back_text , pointer ].Get_sprite();
                botao.IMAGE_animation_back_text.image.color      =  botao.data.cores_animacoes_completas[  ( int ) Device_button_animation_part.animation_back_text , pointer ];


                //mark
                 // esta correto?
                // _texto
                botao.IMAGE_text.tmp_text.color                  =  botao.data.cores_animacoes_completas[  ( int ) Device_button_animation_part.animation_back_text , pointer ];
                

                // _decoracao_image
                botao.IMAGE_decoration.image.sprite              =  botao.data.images_refs_animacoes_completas[  ( int ) Device_button_animation_part.animation_decoration , pointer ].Get_sprite();
                botao.IMAGE_decoration.image.color               =  botao.data.cores_animacoes_completas[  ( int ) Device_button_animation_part.animation_decoration , pointer ];

                // _animacao_frente_texto.image
                botao.IMAGE_animation_front_text.image.sprite  =  botao.data.images_refs_animacoes_completas[  ( int ) Device_button_animation_part.animation_front_text , pointer ].Get_sprite();
                botao.IMAGE_animation_front_text.image.color   =  botao.data.cores_animacoes_completas[  ( int ) Device_button_animation_part.animation_front_text , pointer ];


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