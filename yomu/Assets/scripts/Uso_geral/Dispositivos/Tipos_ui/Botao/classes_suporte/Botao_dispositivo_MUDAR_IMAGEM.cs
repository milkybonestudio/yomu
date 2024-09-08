


public static class Botao_dispositivo_MUDAR_IMAGEM {





        public static void Mudar_imagens_TRANSICAO(  Botao_dispositivo botao, int pointer ){



                // ** animacao_back_image
                botao.TRANSICAO_animacao_back_image.sprite          =  botao.dados.sprites_animacoes_completas[  ( int ) Botao_dispositivo_animacao_parte.animacao_back , pointer ];
                botao.TRANSICAO_animacao_back_image.color           =  botao.dados.cores_animacoes_completas[  ( int ) Botao_dispositivo_animacao_parte.animacao_back , pointer ];

                // _base_image
                botao.TRANSICAO_base_image.sprite                   =  botao.dados.sprites_animacoes_completas[  ( int ) Botao_dispositivo_animacao_parte.animacao_base , pointer ];
                botao.TRANSICAO_base_image.color                    =  botao.dados.cores_animacoes_completas[  ( int ) Botao_dispositivo_animacao_parte.animacao_base , pointer ];

                // _animacao_atras_texto_image
                botao.TRANSICAO_animacao_atras_texto_image.sprite   =  botao.dados.sprites_animacoes_completas[  ( int ) Botao_dispositivo_animacao_parte.animacao_atras_texto , pointer ];
                botao.TRANSICAO_animacao_atras_texto_image.color    =  botao.dados.cores_animacoes_completas[  ( int ) Botao_dispositivo_animacao_parte.animacao_atras_texto , pointer ];

                // _texto
                botao.TRANSICAO_texto.color                         =  botao.dados.cores_animacoes_completas[  ( int ) Botao_dispositivo_animacao_parte.animacao_atras_texto , pointer ];

                // _decoracao_image
                botao.TRANSICAO_decoracao_image.sprite              =  botao.dados.sprites_animacoes_completas[  ( int ) Botao_dispositivo_animacao_parte.animacao_decoracao , pointer ];
                botao.TRANSICAO_decoracao_image.color               =  botao.dados.cores_animacoes_completas[  ( int ) Botao_dispositivo_animacao_parte.animacao_decoracao , pointer ];

                // _animacao_frente_texto_image
                botao.TRANSICAO_animacao_frente_texto_image.sprite  =  botao.dados.sprites_animacoes_completas[  ( int ) Botao_dispositivo_animacao_parte.animacao_frente_texto , pointer ];
                botao.TRANSICAO_animacao_frente_texto_image.color   =  botao.dados.cores_animacoes_completas[  ( int ) Botao_dispositivo_animacao_parte.animacao_frente_texto , pointer ];

                if( botao.TRANSICAO_decoracao_composta_game_object != null  )
                    {
                        // --- TEM DECORACAO COMPOSTA

                        for( int index = 0 ; index < botao.IMAGEM_decoracao_composta_images.Length ; index++ ){

                            botao.TRANSICAO_decoracao_composta_images[ index ].color = botao.dados.cores_decoracao_composta[ index, pointer ];
                            botao.TRANSICAO_decoracao_composta_images[ index ].sprite =  botao.dados.sprites_decoracao_composta[ index, pointer ];

                        }
                        
                    }


        }



        public static void Mudar_imagens_IMAGEM(  Botao_dispositivo botao, int pointer ){



                // ** animacao_back_image
                botao.IMAGEM_animacao_back_image.sprite          =  botao.dados.sprites_animacoes_completas[  ( int ) Botao_dispositivo_animacao_parte.animacao_back , pointer ];
                botao.IMAGEM_animacao_back_image.color           =  botao.dados.cores_animacoes_completas[  ( int ) Botao_dispositivo_animacao_parte.animacao_back , pointer ];

                // _base_image
                botao.IMAGEM_base_image.sprite                   =  botao.dados.sprites_animacoes_completas[  ( int ) Botao_dispositivo_animacao_parte.animacao_base , pointer ];
                botao.IMAGEM_base_image.color                    =  botao.dados.cores_animacoes_completas[  ( int ) Botao_dispositivo_animacao_parte.animacao_base , pointer ];

                // _animacao_atras_texto_image
                botao.IMAGEM_animacao_atras_texto_image.sprite   =  botao.dados.sprites_animacoes_completas[  ( int ) Botao_dispositivo_animacao_parte.animacao_atras_texto , pointer ];
                botao.IMAGEM_animacao_atras_texto_image.color    =  botao.dados.cores_animacoes_completas[  ( int ) Botao_dispositivo_animacao_parte.animacao_atras_texto , pointer ];

                // _texto
                botao.IMAGEM_texto.color                         =  botao.dados.cores_animacoes_completas[  ( int ) Botao_dispositivo_animacao_parte.animacao_atras_texto , pointer ];
                

                // _decoracao_image
                botao.IMAGEM_decoracao_image.sprite              =  botao.dados.sprites_animacoes_completas[  ( int ) Botao_dispositivo_animacao_parte.animacao_decoracao , pointer ];
                botao.IMAGEM_decoracao_image.color               =  botao.dados.cores_animacoes_completas[  ( int ) Botao_dispositivo_animacao_parte.animacao_decoracao , pointer ];

                // _animacao_frente_texto_image
                botao.IMAGEM_animacao_frente_texto_image.sprite  =  botao.dados.sprites_animacoes_completas[  ( int ) Botao_dispositivo_animacao_parte.animacao_frente_texto , pointer ];
                botao.IMAGEM_animacao_frente_texto_image.color   =  botao.dados.cores_animacoes_completas[  ( int ) Botao_dispositivo_animacao_parte.animacao_frente_texto , pointer ];


                if( botao.IMAGEM_decoracao_composta_game_object != null  )
                    {
                        // --- TEM DECORACAO COMPOSTA

                        for( int index = 0 ; index < botao.IMAGEM_decoracao_composta_images.Length ; index++ ){

                            botao.IMAGEM_decoracao_composta_images[ index ].color = botao.dados.cores_decoracao_composta[ index, pointer ];
                            botao.IMAGEM_decoracao_composta_images[ index ].sprite =  botao.dados.sprites_decoracao_composta[ index, pointer ];

                        }
                        
                    }

                return;

        }







  





}