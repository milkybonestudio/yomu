using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Botao_dispositivo {

        public Botao_dispositivo( Dados_botao_dispositivo _data ){ data = _data; }


        // --- GAME OBEJCTS

            // ** OFF 
                public GameObject IMAGEM_container;

                public GameObject IMAGE_animation_back_game_object; 
                public GameObject IMAGE_base_game_object;
                public GameObject IMAGE_animation_back_text_game_object;
                public GameObject IMAGE_text_game_object;
                public GameObject IMAGE_decoration_game_object;
                public GameObject IMAGE_animation_front_text_game_object;
                
                public GameObject IMAGE_composed_decoration_game_object;

            // ** TRANSICAO
                public GameObject TRANSITION_container;

                public GameObject TRANSITION_animation_back_game_object;
                public GameObject TRANSITION_base_game_object;
                public GameObject TRANSITION_animation_back_text_game_object;
                public GameObject TRANSITION_texo_game_object;
                public GameObject TRANSITION_decoration_game_object;
                public GameObject TRANSITION_animation_front_text_game_object;

                public GameObject TRANSITION_composed_decoration_game_object;


            // ** COLLIDERS

                public GameObject COLLIDERS_container;

                public GameObject OFF_collider_game_object;
                public GameObject ON_collider_game_object;


        // --- IMAGES

            // ** IMAGEM
                public Image IMAGE_animation_back_image;
                public Image IMAGE_base_image;
                public Image IMAGE_animation_back_text_image;
                public Image IMAGE_decoration_image;
                public Image IMAGE_animation_front_text_image;

                public Image[] TRANSITION_composed_decoration_images;

            // ** TRANSICAO

                public Image TRANSITION_animation_back_image;
                public Image TRANSITION_base_image;
                public Image TRANSITION_animation_back_text_image;
                public Image TRANSITION_decoration_image;
                public Image TRANSITION_animation_front_text_image;

                public Image[] IMAGE_composed_decoration_images;


        // --- TEXTO

            public TMP_Text IMAGE_text;
            public TMP_Text TRANSITION_text;

        // --- COLLIDERS

            public PolygonCollider2D OFF_collider;
            public PolygonCollider2D ON_collider;
        

        // --- INTERNO

        public float position_x;
        public float position_y;



        public AudioClip audio_click; 
        public AudioClip audio_houver; 
        //public AudioClip audio_houver;


        //mark 
        // ** trocar para data
        //public Dados_botao_dispositivo dados;

        public Dados_botao_dispositivo data;
        public GameObject botao_game_object;


        // --- LOGICA INTERNA


        public bool esta_down = false; 
        public bool esta_houver = false;



        public float animacao_atual_tempo_ms = 0f;
        public float animacao_sprite_atual_tempo_ms = 0f;
        public int sprite_atual_index = -1;

    
        public DEVICE_button_visual_state estado_visual_botao;


        // ---- SUPORTE INTERNO

        public DEVICE_button_visual_state ultimo_estado_visual_botao;


        public void Update(){


        
                if( data.update_para_substituir != null )
                    {
                        data.update_para_substituir( this );
                        return;
                    }
        
                Update_logica(); 
                Update_parte_visual(); 


                if( data.Update_secundario != null )
                    { data.Update_secundario(); }

                return;

        }


        public void Update_logica(){


                if( data.bloquear_update_logico )
                    { return; }


                // --- VERIFICAR HOUVER
                if( esta_houver )
                    {
                        //mark
                        // ** nao esta usando o colider?

                        // --- VERIFICA SE MOUSE CONTINUA NO BOTAO
                        esta_houver = Polygon.Check_point_inside( ON_collider.points, ( Vector2 ) IMAGE_base_game_object.transform.position , Controlador_cursor.Pegar_instancia().posicao_cursor );
                        if( !!!( esta_houver ) )
                            { esta_down = false; return; } // --- SAIU
                    }
                    else
                    { 
                        // --- VERIFICA SE ENTROU
                        esta_houver = Polygon.Check_point_inside( OFF_collider.points, ( Vector2 ) IMAGE_base_game_object.transform.position , Controlador_cursor.Pegar_instancia().posicao_cursor ); 
                        if( !!!( esta_houver ) )
                            { return; } // --- NAO ENTROU
                            
                        // --- VERIFICA SE EH TIPO ENTRADA
                        if( data.tipo_ativacao == Botao_dispositivo_tipo_ativacao.entrar_no_botao )
                            { data.Ativar(); return; } // --- ATIVAR BOTAO
            
                    } 


                // --- VERIFICAR DOWN

                if( Input.GetMouseButtonDown( 0 ) )
                    { 

                        esta_down = true; 
                        if( data.tipo_ativacao == Botao_dispositivo_tipo_ativacao.clicar )
                            { data.Ativar(); } // --- ATIVAR BOTAO
                        
                    }


                if( Input.GetMouseButtonUp( 0 ) && esta_down )
                    { 
                        // --- ATIVA SOMENTE QUANDO DEU DOWN ANTERIORMENTE
                        if( data.tipo_ativacao == Botao_dispositivo_tipo_ativacao.clicar_e_soltar && esta_down )
                            { data.Ativar(); } // --- ATIVAR BOTAO

                    }


                if( !!!( Input.GetMouseButton( 0 ) ) )
                    { esta_down = false; }


        }


        public void Update_parte_visual(){


                if( data.bloquear_update_visual )
                    { return; }


                if( estado_visual_botao != ultimo_estado_visual_botao )
                    { ultimo_estado_visual_botao = estado_visual_botao; }


                switch( estado_visual_botao ){

                        case DEVICE_button_visual_state.off_estatico: Handle_off_static(); break;
                        case DEVICE_button_visual_state.off_animacao: Handle_off_animation(); break;
                        case DEVICE_button_visual_state.on_estatico: Handle_on_static(); break;
                        case DEVICE_button_visual_state.on_animacao: Handle_on_animation(); break;

                        case DEVICE_button_visual_state.transicao_animacao_OFF_para_ON: Handle_transition_animation_OFF_to_ON(); break;
                        case DEVICE_button_visual_state.transicao_animacao_ON_para_OFF: Lidar_transicao_animacao_ON_para_OFF(); break;

                }

                return;


        }
        

        
        // --- OFF

        public void Handle_off_static(){


                // --- VERIFICA SE TEM INTERACAO COM O MOUSE
                if(  esta_houver )
                    { Botao_dispositivo_SETAR.SET_transition_OFF_to_ON( this ); return; } // --- TEM QUE IR PARA TRANSICAO


                animacao_atual_tempo_ms -= ( Time.deltaTime * 1000f );

                // --- VERIFICA SE PODE INICIAR ANIMACAO OFF
                if( animacao_atual_tempo_ms < 0f )
                    { Botao_dispositivo_SETAR.SET_OFF_animation( this ); }// --- VAI INICIAR ANIMACAO

                return;
                
            
        }




        public void Handle_off_animation(){
            

                // --- PASSAR TEMPO
                if( esta_houver )
                    { animacao_sprite_atual_tempo_ms -= data.animacao_off_tempos.multiplicador_saida_padrao_animacao * ( Time.deltaTime * 1000f ) ;}// --- PRECISA ACELERAR PARA FINALIZAR RAPIOD
                    else
                    { animacao_sprite_atual_tempo_ms -= ( Time.deltaTime * 1000f ) ; } // --- TEMPO NORMAL

                
                // --- VERIFICA SE TEM QUE ESPERAR
                if( animacao_sprite_atual_tempo_ms > 0f )
                    { return; }

                
                // --- VERIFICA SE ESSA ERA A ULTIMA SPRITE
                if( sprite_atual_index == ( data.pointers.pointer_final_animacao_OFF - 1 ) )
                    { Botao_dispositivo_SETAR.SET_OFF_static( this ); return; } // --- VOLTAR PARA STATIC

                
                // ---TROCAR SPRITE
                sprite_atual_index++;
                Botao_dispositivo_MUDAR_IMAGEM.Change_images_IMAGE( this, sprite_atual_index );

                // RENOVA TEMPO
                if( data.animacao_off_tempos.tempo_troca_sprite_ms_por_sprite != null )
                    { animacao_sprite_atual_tempo_ms = data.animacao_off_tempos.tempo_troca_sprite_ms_por_sprite[ sprite_atual_index ]; }// --- TEM TEMPO DIFERENTE PARA CADA SPRITE
                    else
                    { animacao_sprite_atual_tempo_ms = data.animacao_off_tempos.tempo_troca_sprite_ms; } // --- TEMPO UNICO


                return;


        }


        // --- ON

        public void Handle_on_static(){


                // --- VERIFICA SE O MAUSE SAIU
                if( !!!( esta_houver ) )
                    { Botao_dispositivo_SETAR.SETAR_transicao_ON_para_OFF( this ); return; } // --- INICIAR TRANSICAO ON => OFF

                animacao_atual_tempo_ms -= ( Time.deltaTime * 1000f );


                // --- VERIFICA SE PODE INICIAR ANIMACAO ON
                if( animacao_atual_tempo_ms < 0f )
                    { Botao_dispositivo_SETAR.SETAR_ON_animacao( this ); }  // --- TEM ANIMACAO ON ESTATICA 


                return;
                
        }


        public void Handle_on_animation(){
            

                // --- PASSAR TEMPO
                if( !!!(esta_houver) )
                    { animacao_sprite_atual_tempo_ms -= data.animacao_on_tempos.multiplicador_saida_padrao_animacao * ( Time.deltaTime * 1000f ) ;}// --- PRECISA ACELERAR PARA FINALIZAR RAPIOD
                    else
                    { animacao_sprite_atual_tempo_ms -= ( Time.deltaTime * 1000f ) ; } // --- TEMPO NORMAL


                // --- VERIFICA SE TEM QUE ESPERAR
                if( animacao_sprite_atual_tempo_ms > 0f )
                    { return; }


                // --- TEM QUE TROCAR FRAME


                //// --- VERIFICA SE ESSA ERA A ULTIMA SPRITE
                    if( sprite_atual_index == ( data.pointers.pointer_final_animacao_ON - 1 ) )
                    { Botao_dispositivo_SETAR.SET_ON_static( this ); return; }// --- VOLTAR PARA STATIC 


                // --- TROCAR SPRITE
                sprite_atual_index++;
                Botao_dispositivo_MUDAR_IMAGEM.Change_images_IMAGE( this, sprite_atual_index );

                
                // --- RENOVA TEMPO
                if( data.animacao_on_tempos.tempo_troca_sprite_ms_por_sprite != null )
                    { animacao_sprite_atual_tempo_ms = data.animacao_on_tempos.tempo_troca_sprite_ms_por_sprite[ sprite_atual_index ]; }// --- TEM TEMPO DIFERENTE PARA CADA SPRITE
                    else
                    { animacao_sprite_atual_tempo_ms = data.animacao_on_tempos.tempo_troca_sprite_ms; } // --- TEMPO UNICO


                return;


        }


        // --- TRANSICAO

        private void Handle_transition_animation_OFF_to_ON(){


                switch( data.tipo_transicao ){

                    case DEVICE_button_transition_type_OFF_ON.nada : Botao_dispositivo_SETAR.SET_ON_static( this ); break;
                    case DEVICE_button_transition_type_OFF_ON.cor : Botao_dispositivo_TRANSICAO.Handle_transition_animation_OFF_to_ON_color( this ); break;
                    case DEVICE_button_transition_type_OFF_ON.animacao_individual : Botao_dispositivo_TRANSICAO.Handle_transition_animation_OFF_to_ON_individual_animation( this ); break;
                
                }


        }


        // --- ON -> OFF

        public void Lidar_transicao_animacao_ON_para_OFF(){
            
                switch( data.tipo_transicao ){

                    case DEVICE_button_transition_type_OFF_ON.nada : Botao_dispositivo_SETAR.SET_OFF_static( this ); break;
                    case DEVICE_button_transition_type_OFF_ON.cor : Botao_dispositivo_TRANSICAO.Lidar_transicao_animacao_ON_para_OFF_cor( this ); break;
                    case DEVICE_button_transition_type_OFF_ON.animacao_individual : Botao_dispositivo_TRANSICAO.Lidar_transicao_animacao_ON_para_OFF_animacao_individual( this ); break;
                
                }



        }








        public void Get_data_from_prefab( string _path_dispositivo  ){

                // ** vai colocar os dados

                
                string path_botao = _path_dispositivo + "/" + data.nome;

                botao_game_object = GameObject.Find( path_botao );
                if( botao_game_object == null )
                    { throw new System.Exception( $"Botao nao foi encontrado no path { path_botao }" ); }

                    // --- ACHOU O PONTO DE ENTRADA

                try {


                        // --- PEGAR GAMEOBJECTS

                            // ** COLLIDERS

                                COLLIDERS_container  = botao_game_object.transform.GetChild( 0 ).gameObject;
                                
                                ON_collider_game_object   =  COLLIDERS_container.transform.GetChild( 0 ).gameObject;
                                OFF_collider_game_object  =  COLLIDERS_container.transform.GetChild( 1 ).gameObject;


                            // IMAGEM
                                IMAGEM_container = botao_game_object.transform.GetChild( 1 ).gameObject;

                                IMAGE_animation_back_game_object         =  IMAGEM_container.transform.GetChild( 0 ).gameObject;
                                IMAGE_base_game_object                   =  IMAGEM_container.transform.GetChild( 1 ).gameObject;
                                IMAGE_animation_back_text_game_object    =  IMAGEM_container.transform.GetChild( 2 ).gameObject;
                                IMAGE_text_game_object                   =  IMAGEM_container.transform.GetChild( 3 ).gameObject;
                                IMAGE_decoration_game_object             =  IMAGEM_container.transform.GetChild( 4 ).gameObject;
                                IMAGE_animation_front_text_game_object   =  IMAGEM_container.transform.GetChild( 5 ).gameObject;




                            // ** TRANSICAO
                                TRANSITION_container = botao_game_object.transform.GetChild( 2 ).gameObject;

                                TRANSITION_animation_back_game_object         =   TRANSITION_container.transform.GetChild( 0 ).gameObject;
                                TRANSITION_base_game_object                  =   TRANSITION_container.transform.GetChild( 1 ).gameObject;
                                TRANSITION_animation_back_text_game_object  =   TRANSITION_container.transform.GetChild( 2 ).gameObject;
                                TRANSITION_texo_game_object                 =   TRANSITION_container.transform.GetChild( 3 ).gameObject;
                                TRANSITION_decoration_game_object             =   TRANSITION_container.transform.GetChild( 4 ).gameObject;
                                TRANSITION_animation_front_text_game_object =   TRANSITION_container.transform.GetChild( 5 ).gameObject;
                                

                                
                        // --- PEGAR IMAGES

                            // IMAGEM 

                                IMAGE_animation_back_image         =  IMAGE_animation_back_game_object.GetComponent<Image>();
                                IMAGE_base_image                  =  IMAGE_base_game_object.GetComponent<Image>();
                                IMAGE_decoration_image             =  IMAGE_decoration_game_object.GetComponent<Image>();
                                IMAGE_animation_back_text_image  =  IMAGE_animation_back_text_game_object.GetComponent<Image>();
                                IMAGE_animation_front_text_image =  IMAGE_animation_front_text_game_object.GetComponent<Image>();


                            // ** transicao

                                TRANSITION_animation_back_image         =  TRANSITION_animation_back_game_object.GetComponent<Image>();
                                TRANSITION_base_image                  =  TRANSITION_base_game_object.GetComponent<Image>();
                                TRANSITION_decoration_image             =  TRANSITION_decoration_game_object.GetComponent<Image>();
                                TRANSITION_animation_back_text_image  =  TRANSITION_animation_back_text_game_object.GetComponent<Image>();
                                TRANSITION_animation_front_text_image =  TRANSITION_animation_front_text_game_object.GetComponent<Image>();




                                // --- VERIFICA DECORACAO COMPOSTA
                                if( IMAGE_decoration_game_object.transform.childCount > 0 )
                                    {

                                        //mark 
                                        // nao tenho ideia de como isso funciona

                                        // --- TEM DECORACAO COMPOSTA
                                        // ** copia o game object para detro da imagem da transicao

                                        if( IMAGE_decoration_game_object.transform.childCount != 1 )
                                            { throw new Exception("Dentro de decoracao tinha mais de 1 gameObject. Se a decoracao for composta ela precisa estar dentro de outro container: decoracao => container_dec_composta => gameObjects[]. O sistema vai somente copiar o gameObject para a transicao"); }

                                        if( data.sprites_decoracao_composta == null )
                                            { throw new Exception( $"Tinha um gameObject contianer na decoracao do botao <color=lightBlue><b>{ data.nome}</b></color> no dispositivo <color=lightBlue><b>{ data.nome_dispositivo }</b></color> MAS nao foi declarado as imagens das sprites." );}


                                        IMAGE_composed_decoration_game_object = IMAGE_decoration_game_object.transform.GetChild( 0 ).gameObject;
                                        TRANSITION_composed_decoration_game_object = GameObject.Instantiate( IMAGE_composed_decoration_game_object );

                                        TRANSITION_composed_decoration_game_object.transform.SetParent( TRANSITION_decoration_game_object.transform, false );


                                        int numero_imagens_decoracao_composta = IMAGE_composed_decoration_game_object.transform.childCount;

                                        if( numero_imagens_decoracao_composta == 0 )
                                            { throw new Exception( $"Tinha um gameObject contianer na decoracao do botao <color=lightBlue><b>{ data.nome}</b></color> no dispositivo <color=lightBlue><b>{ data.nome_dispositivo }</b></color> mas ele nao tinha nenhum gameObject." );}

                                        if( data.sprites_decoracao_composta.GetLength( 0 ) > numero_imagens_decoracao_composta )
                                            { throw new Exception( $"Tinha um gameObject contianer na decoracao do botao <color=lightBlue><b>{ data.nome }</b></color> no dispositivo <color=lightBlue><b>{ data.nome_dispositivo }</b></color> MAS o numero de gameObjects [ { numero_imagens_decoracao_composta } ] é menor que o numero de sprites [ { data.sprites_decoracao_composta.GetLength( 0 ) } ]." );}


                                        IMAGE_composed_decoration_images = new Image[ numero_imagens_decoracao_composta ];
                                        TRANSITION_composed_decoration_images = new Image[ numero_imagens_decoracao_composta ];

                                        for( int imagem = 0 ; imagem < numero_imagens_decoracao_composta ; imagem++ ){


                                                IMAGE_composed_decoration_images[ imagem ] = IMAGE_composed_decoration_game_object.transform.GetChild( imagem ).gameObject.GetComponent<Image>();
                                                TRANSITION_composed_decoration_images[ imagem ] = TRANSITION_composed_decoration_game_object.transform.GetChild( imagem ).gameObject.GetComponent<Image>();

                                                IMAGE_composed_decoration_images[ imagem ].material = data.device_material; 
                                                TRANSITION_composed_decoration_images[ imagem ].material = data.device_material;
                                                
                                                continue;

                                        }



                                    }

                                

                        // --- PEGAR TEXTO

                            IMAGE_text = IMAGE_text_game_object.GetComponent<TMP_Text>();
                            TRANSITION_text = TRANSITION_texo_game_object.GetComponent<TMP_Text>();


                        // --- COLIDERS

                            ON_collider = ON_collider_game_object.GetComponent<PolygonCollider2D>();
                            OFF_collider = OFF_collider_game_object.GetComponent<PolygonCollider2D>();
                        
                        
                        position_x =  botao_game_object.transform.localPosition.x;
                        position_y =  botao_game_object.transform.localPosition.y;


                }
                catch ( System.Exception exc )
                {
                    Debug.LogError( $"Nao conseguiu pegar os dados do botao <color=lightBlue><b>{ data.nome}</b></color> no dispositivo <color=lightBlue><b>{ data.nome_dispositivo }</b></color>." );
                    throw exc;

                }

                // --- COLOCAR MATERIAL

                    // ** OFF

                        IMAGE_animation_back_image.material = data.device_material;
                        IMAGE_base_image.material = data.device_material;
                        IMAGE_decoration_image.material = data.device_material;
                        IMAGE_animation_back_text_image.material = data.device_material;
                        IMAGE_animation_front_text_image.material = data.device_material;
                        IMAGE_text.material = data.device_material;



                    // ** TRANSICAO

                        TRANSITION_base_image.material = data.device_material;
                        TRANSITION_decoration_image.material = data.device_material;
                        TRANSITION_animation_back_text_image.material = data.device_material;
                        TRANSITION_animation_front_text_image.material = data.device_material;
                        TRANSITION_text.material = data.device_material;

                
                // --- LOGICA 


                Botao_dispositivo_SETAR.SET_OFF_static( this );
            
                return;


        }





        // --- AUDIOS



}
