using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public static class TOOL__UI_button_GETTER_COMPLETE {


        public static void Get( Botao_dispositivo _button ){


                try {


                    // --- PEGAR GAMEOBJECTS

                        // ** COLLIDERS

                            _button.COLLIDERS_container  = _button.botao_game_object.transform.GetChild( 0 ).gameObject;
                            
                            _button.ON_collider_game_object   =  _button.COLLIDERS_container.transform.GetChild( 0 ).gameObject;
                            _button.OFF_collider_game_object  =  _button.COLLIDERS_container.transform.GetChild( 1 ).gameObject;


                        // IMAGEM
                            _button.IMAGE_container = _button.botao_game_object.transform.GetChild( 1 ).gameObject;

                            _button.IMAGE_animation_back.game_object         =  _button.IMAGE_container.transform.GetChild( 0 ).gameObject;
                            _button.IMAGE_base.game_object                   =  _button.IMAGE_container.transform.GetChild( 1 ).gameObject;
                            _button.IMAGE_animation_back_text.game_object    =  _button.IMAGE_container.transform.GetChild( 2 ).gameObject;
                            _button.IMAGE_text.game_object                   =  _button.IMAGE_container.transform.GetChild( 3 ).gameObject;
                            _button.IMAGE_decoration.game_object             =  _button.IMAGE_container.transform.GetChild( 4 ).gameObject;
                            _button.IMAGE_animation_front_text.game_object   =  _button.IMAGE_container.transform.GetChild( 5 ).gameObject;




                        // ** TRANSICAO
                            _button.TRANSITION_container = _button.botao_game_object.transform.GetChild( 2 ).gameObject;

                            _button.TRANSITION_animation_back.game_object          =   _button.TRANSITION_container.transform.GetChild( 0 ).gameObject;
                            _button.TRANSITION_base.game_object                    =   _button.TRANSITION_container.transform.GetChild( 1 ).gameObject;
                            _button.TRANSITION_animation_back_text.game_object     =   _button.TRANSITION_container.transform.GetChild( 2 ).gameObject;
                            _button.TRANSITION_text.game_object                    =   _button.TRANSITION_container.transform.GetChild( 3 ).gameObject;
                            _button.TRANSITION_decoration.game_object              =   _button.TRANSITION_container.transform.GetChild( 4 ).gameObject;
                            _button.TRANSITION_animation_front_text.game_object    =   _button.TRANSITION_container.transform.GetChild( 5 ).gameObject;
                            

                            
                    // --- PEGAR IMAGES

                        // IMAGEM 

                            _button.IMAGE_animation_back.image         =  _button.IMAGE_animation_back.game_object.GetComponent<Image>();
                            _button.IMAGE_base.image                   =  _button.IMAGE_base.game_object.GetComponent<Image>();
                            _button.IMAGE_decoration.image             =  _button.IMAGE_decoration.game_object.GetComponent<Image>();
                            _button.IMAGE_animation_back_text.image    =  _button.IMAGE_animation_back_text.game_object.GetComponent<Image>();
                            _button.IMAGE_animation_front_text.image   =  _button.IMAGE_animation_front_text.game_object.GetComponent<Image>();


                        // ** transicao

                            _button.TRANSITION_animation_back.image         =  _button.TRANSITION_animation_back.game_object.GetComponent<Image>();
                            _button.TRANSITION_base.image                   =  _button.TRANSITION_base.game_object.GetComponent<Image>();
                            _button.TRANSITION_decoration.image             =  _button.TRANSITION_decoration.game_object.GetComponent<Image>();
                            _button.TRANSITION_animation_back_text.image    =  _button.TRANSITION_animation_back_text.game_object.GetComponent<Image>();
                            _button.TRANSITION_animation_front_text.image   =  _button.TRANSITION_animation_front_text.game_object.GetComponent<Image>();




                            // --- VERIFICA DECORACAO COMPOSTA
                            if( _button.IMAGE_decoration.game_object.transform.childCount > 0 )
                                {

                                    CONTROLLER__errors.Throw( "ainda nao usar decoração composta. Decoração composta provavelmente vai usar RESOURCE__image_sequences e aind anão esta pronto" );

                                    //mark 
                                    // nao tenho ideia de como isso funciona

                                    // --- TEM DECORACAO COMPOSTA
                                    // ** copia o game object para detro da imagem da transicao

                                    CONTROLLER__errors.Verify( ( _button.IMAGE_decoration.game_object.transform.childCount != 1 ), "Dentro de decoracao tinha mais de 1 gameObject. Se a decoracao for composta ela precisa estar dentro de outro container: decoracao => container_dec_composta => gameObjects[]. O sistema vai somente copiar o gameObject para a transicao" );
                                    CONTROLLER__errors.Verify( ( _button.data.sprites_decoracao_composta == null ), $"Tinha um gameObject contianer na decoracao do botao <color=lightBlue><b>{ _button.data.nome }</b></color> no dispositivo <color=lightBlue><b>{ _button.data.nome_dispositivo }</b></color> MAS nao foi declarado as imagens das sprites." );


                                    _button.IMAGE_composed_decoration_game_object = _button.IMAGE_decoration.game_object.transform.GetChild( 0 ).gameObject;
                                    _button.TRANSITION_composed_decoration = GameObject.Instantiate( _button.IMAGE_composed_decoration_game_object );

                                    _button.TRANSITION_composed_decoration.transform.SetParent( _button.TRANSITION_decoration.game_object.transform, false );


                                    int numero_imagens_decoracao_composta = _button.IMAGE_composed_decoration_game_object.transform.childCount;

                                    if( numero_imagens_decoracao_composta == 0 )
                                        { throw new Exception( $"Tinha um gameObject contianer na decoracao do botao <color=lightBlue><b>{ _button.data.nome}</b></color> no dispositivo <color=lightBlue><b>{ _button.data.nome_dispositivo }</b></color> mas ele nao tinha nenhum gameObject." );}

                                    if( _button.data.sprites_decoracao_composta.GetLength( 0 ) > numero_imagens_decoracao_composta )
                                        { throw new Exception( $"Tinha um gameObject contianer na decoracao do botao <color=lightBlue><b>{ _button.data.nome }</b></color> no dispositivo <color=lightBlue><b>{ _button.data.nome_dispositivo }</b></color> MAS o numero de gameObjects [ { numero_imagens_decoracao_composta } ] é menor que o numero de sprites [ { _button.data.sprites_decoracao_composta.GetLength( 0 ) } ]." );}


                                    _button.IMAGE_composed_decoration_images = new Image[ numero_imagens_decoracao_composta ];
                                    _button.TRANSITION_composed_decoration_images = new Image[ numero_imagens_decoracao_composta ];

                                    for( int imagem = 0 ; imagem < numero_imagens_decoracao_composta ; imagem++ ){


                                            _button.IMAGE_composed_decoration_images[ imagem ] = _button.IMAGE_composed_decoration_game_object.transform.GetChild( imagem ).gameObject.GetComponent<Image>();
                                            _button.TRANSITION_composed_decoration_images[ imagem ] = _button.TRANSITION_composed_decoration.transform.GetChild( imagem ).gameObject.GetComponent<Image>();

                                            _button.IMAGE_composed_decoration_images[ imagem ].material = _button.data.device_material; 
                                            _button.TRANSITION_composed_decoration_images[ imagem ].material = _button.data.device_material;
                                            
                                            continue;

                                    }


                                }

                                

                        // --- PEGAR TEXTO

                            _button.IMAGE_text.tmp_text = _button.IMAGE_text.game_object.GetComponent<TMP_Text>();
                            _button.TRANSITION_text.tmp_text = _button.TRANSITION_text.game_object.GetComponent<TMP_Text>();


                        // --- COLIDERS

                            _button.ON_collider = _button.ON_collider_game_object.GetComponent<PolygonCollider2D>();
                            _button.OFF_collider = _button.OFF_collider_game_object.GetComponent<PolygonCollider2D>();
                        
                        
                        _button.position_x =  _button.botao_game_object.transform.localPosition.x;
                        _button.position_y =  _button.botao_game_object.transform.localPosition.y;


                }
                catch ( System.Exception exc )
                {
                    Debug.LogError( $"Nao conseguiu pegar os dados do botao <color=lightBlue><b>{ _button.data.nome}</b></color> no dispositivo <color=lightBlue><b>{ _button.data.nome_dispositivo }</b></color>." );
                    throw exc;

                }

                // --- COLOCAR MATERIAL

                    //mark
                    // ** material ainda esta como device
                    // ** depois ver como fazer

                    // ** OFF

                        _button.IMAGE_animation_back.image.material = _button.data.device_material;
                        _button.IMAGE_base.image.material = _button.data.device_material;
                        _button.IMAGE_decoration.image.material = _button.data.device_material;
                        _button.IMAGE_animation_back_text.image.material = _button.data.device_material;
                        _button.IMAGE_animation_front_text.image.material = _button.data.device_material;
                        _button.IMAGE_text.tmp_text.material = _button.data.device_material;


                    // ** TRANSICAO

                        _button.TRANSITION_base.image.material = _button.data.device_material;
                        _button.TRANSITION_decoration.image.material = _button.data.device_material;
                        _button.TRANSITION_animation_back_text.image.material = _button.data.device_material;
                        _button.TRANSITION_animation_front_text.image.material = _button.data.device_material;
                        _button.TRANSITION_text.tmp_text.material = _button.data.device_material;

                
                // --- LOGICA 


                TOOL__UI_button_SET_COMPLEX.SET_OFF_static( _button );
            
                return;


        }



}