using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Botao_dispositivo {


        // --- GAME OBEJCTS

            // ** OFF 
                public GameObject IMAGEM_container;

                public GameObject IMAGEM_animacao_back_game_object;
                public GameObject IMAGEM_base_game_object;
                public GameObject IMAGEM_animacao_atras_texto_game_object;
                public GameObject IMAGEM_texto_game_object;
                public GameObject IMAGEM_decoracao_game_object;
                public GameObject IMAGEM_animacao_frente_texto_game_object;
                
                public GameObject IMAGEM_decoracao_composta_game_object;

            // ** TRANSICAO
                public GameObject TRANSICAO_container;

                public GameObject TRANSICAO_animacao_back_game_object;
                public GameObject TRANSICAO_base_game_object;
                public GameObject TRANSICAO_animacao_atras_texto_game_object;
                public GameObject TRANSICAO_texto_game_object;
                public GameObject TRANSICAO_decoracao_game_object;
                public GameObject TRANSICAO_animacao_frente_texto_game_object;

                public GameObject TRANSICAO_decoracao_composta_game_object;


            // ** COLLIDERS

                public GameObject COLLIDERS_container;

                public GameObject OFF_collider_game_object;
                public GameObject ON_collider_game_object;


        // --- IMAGES

            // ** IMAGEM
                public Image IMAGEM_animacao_back_image;
                public Image IMAGEM_base_image;
                public Image IMAGEM_decoracao_image;
                public Image IMAGEM_animacao_atras_texto_image;
                public Image IMAGEM_animacao_frente_texto_image;

                public Image[] TRANSICAO_decoracao_composta_images;

            // ** TRANSICAO

                public Image TRANSICAO_animacao_back_image;
                public Image TRANSICAO_base_image;
                public Image TRANSICAO_decoracao_image;
                public Image TRANSICAO_animacao_atras_texto_image;
                public Image TRANSICAO_animacao_frente_texto_image;

                public Image[] IMAGEM_decoracao_composta_images;


        // --- TEXTO

            public TMP_Text IMAGEM_texto;
            public TMP_Text TRANSICAO_texto;

        // --- COLLIDERS

            public PolygonCollider2D OFF_collider;
            public PolygonCollider2D ON_collider;
        

        // --- INTERNO

        public float posicao_x;
        public float posicao_y;



        public AudioClip audio_click; 
        public AudioClip audio_houver; 
        //public AudioClip audio_houver;


        public Dados_botao_dispositivo dados;
        public GameObject botao_game_object;


        // --- LOGICA INTERNA


        public bool esta_down = false; 
        public bool esta_houver = false;



        public float animacao_atual_tempo_ms = 0f;
        public float animacao_sprite_atual_tempo_ms = 0f;
        public int sprite_atual_index = -1;

    
        public Estado_visual_botao_dispositivo estado_visual_botao;


        // ---- SUPORTE INTERNO

        public Estado_visual_botao_dispositivo ultimo_estado_visual_botao;


        public void Update(){


        
                if( dados.update_para_substituir != null )
                    {
                        dados.update_para_substituir( this );
                        return;
                    }
        
                Update_logica(); 
                Update_parte_visual(); 


                if( dados.Update_secundario != null )
                    { dados.Update_secundario(); }

                return;

        }


        public void Update_logica(){


                if( dados.bloquear_update_logico )
                    { return; }


                // --- VERIFICAR HOUVER
                if( esta_houver )
                    {

                        // --- VERIFICA SE MOUSE CONTINUA NO BOTAO
                        esta_houver = Mat.Verificar_ponto_dentro_poligono( ON_collider.points, ( Vector2 ) IMAGEM_base_game_object.transform.position , Controlador_cursor.Pegar_instancia().posicao_cursor );
                        if( !!!( esta_houver ) )
                            { 
                                // --- SAIU
                                esta_down = false;
                                return; 
                            }
                    }
                    else
                    { 
                        // --- VERIFICA SE ENTROU
                        esta_houver = Mat.Verificar_ponto_dentro_poligono( OFF_collider.points, ( Vector2 ) IMAGEM_base_game_object.transform.position , Controlador_cursor.Pegar_instancia().posicao_cursor ); 
                        if( !!!( esta_houver ) )
                            { 
                                // --- NAO ENTROU
                                return;

                            }
                            
                        // --- VERIFICA SE EH TIPO ENTRADA
                        if( dados.tipo_ativacao == Botao_dispositivo_tipo_ativacao.entrar_no_botao )
                            {
                                // --- ATIVAR BOTAO
                                dados.Ativar(); 
                                return;

                            }
            
                    } 


                // --- VERIFICAR DOWN

                if( Input.GetMouseButtonDown( 0 ) )
                    { 

                        esta_down = true; 
                        if( dados.tipo_ativacao == Botao_dispositivo_tipo_ativacao.clicar )
                            { 
                                // --- ATIVAR BOTAO
                                dados.Ativar(); 
                            }
                        
                    }


                if( Input.GetMouseButtonUp( 0 ) && esta_down )
                    { 
                        // --- ATIVA SOMENTE QUANDO DEU DOWN ANTERIORMENTE
                        if( dados.tipo_ativacao == Botao_dispositivo_tipo_ativacao.clicar_e_soltar && esta_down )
                            { 
                                // --- ATIVAR BOTAO
                                dados.Ativar(); 
                            }

                    }


                if( !!!( Input.GetMouseButton( 0 ) ) )
                    { esta_down = false; }


        }


        public void Update_parte_visual(){



                if( dados.bloquear_update_visual )
                    { return; }


                if( estado_visual_botao != ultimo_estado_visual_botao )
                    {
                        //Debug.Log( $"Novo estado_visual_botao: { estado_visual_botao  }" );
                        ultimo_estado_visual_botao = estado_visual_botao;
                    }


                switch( estado_visual_botao ){

                        case Estado_visual_botao_dispositivo.off_estatico: Lidar_off_estatico(); break;
                        case Estado_visual_botao_dispositivo.off_animacao: Lidar_off_animacao(); break;
                        case Estado_visual_botao_dispositivo.on_estatico: Lidar_on_estatico(); break;
                        case Estado_visual_botao_dispositivo.on_animacao: Lidar_on_animacao(); break;

                        case Estado_visual_botao_dispositivo.transicao_animacao_OFF_para_ON: Lidar_transicao_animacao_OFF_para_ON(); break;
                        case Estado_visual_botao_dispositivo.transicao_animacao_ON_para_OFF: Lidar_transicao_animacao_ON_para_OFF(); break;

                }


        }
        

        
        // --- OFF

        public void Lidar_off_estatico(){


                // --- VERIFICA SE TEM INTERACAO COM O MOUSE
                if(  esta_houver )
                    { Botao_dispositivo_SETAR.SETAR_transicao_OFF_para_ON( this ); return; } // --- TEM QUE IR PARA TRANSICAO


                animacao_atual_tempo_ms -= ( Time.deltaTime * 1000f );

                // --- VERIFICA SE PODE INICIAR ANIMACAO OFF
                if( animacao_atual_tempo_ms < 0f )
                    { Botao_dispositivo_SETAR.SETAR_OFF_animacao( this ); }// --- VAI INICIAR ANIMACAO

                return;
                
            
        }




        public void Lidar_off_animacao(){
            

                // --- PASSAR TEMPO
                if( esta_houver )
                    { animacao_sprite_atual_tempo_ms -= dados.animacao_off_tempos.multiplicador_saida_padrao_animacao * ( Time.deltaTime * 1000f ) ;}// --- PRECISA ACELERAR PARA FINALIZAR RAPIOD
                    else
                    { animacao_sprite_atual_tempo_ms -= ( Time.deltaTime * 1000f ) ; } // --- TEMPO NORMAL

                
                // --- VERIFICA SE TEM QUE ESPERAR
                if( animacao_sprite_atual_tempo_ms > 0f )
                    { return; }

                
                // --- VERIFICA SE ESSA ERA A ULTIMA SPRITE
                if( sprite_atual_index == ( dados.pointers.pointer_final_animacao_OFF - 1 ) )
                    { Botao_dispositivo_SETAR.SETAR_OFF_estatico( this ); return; } // --- VOLTAR PARA STATIC

                
                // ---TROCAR SPRITE
                sprite_atual_index++;
                Botao_dispositivo_MUDAR_IMAGEM.Mudar_imagens_IMAGEM( this, sprite_atual_index );

                // RENOVA TEMPO
                if( dados.animacao_off_tempos.tempo_troca_sprite_ms_por_sprite != null )
                    { animacao_sprite_atual_tempo_ms = dados.animacao_off_tempos.tempo_troca_sprite_ms_por_sprite[ sprite_atual_index ]; }// --- TEM TEMPO DIFERENTE PARA CADA SPRITE
                    else
                    { animacao_sprite_atual_tempo_ms = dados.animacao_off_tempos.tempo_troca_sprite_ms; } // --- TEMPO UNICO


                return;


        }


        // --- ON

        public void Lidar_on_estatico(){


                // --- VERIFICA SE O MAUSE SAIU
                if( !!!( esta_houver ) )
                    { Botao_dispositivo_SETAR.SETAR_transicao_ON_para_OFF( this ); return; } // --- INICIAR TRANSICAO ON => OFF

                animacao_atual_tempo_ms -= ( Time.deltaTime * 1000f );


                // --- VERIFICA SE PODE INICIAR ANIMACAO ON
                if( animacao_atual_tempo_ms < 0f )
                    { Botao_dispositivo_SETAR.SETAR_ON_animacao( this ); }  // --- TEM ANIMACAO ON ESTATICA 


                return;
                
        }


        public void Lidar_on_animacao(){
            

                // --- PASSAR TEMPO
                if( !!!(esta_houver) )
                    { animacao_sprite_atual_tempo_ms -= dados.animacao_on_tempos.multiplicador_saida_padrao_animacao * ( Time.deltaTime * 1000f ) ;}// --- PRECISA ACELERAR PARA FINALIZAR RAPIOD
                    else
                    { animacao_sprite_atual_tempo_ms -= ( Time.deltaTime * 1000f ) ; } // --- TEMPO NORMAL


                // --- VERIFICA SE TEM QUE ESPERAR
                if( animacao_sprite_atual_tempo_ms > 0f )
                    { return; }


                // --- TEM QUE TROCAR FRAME


                //// --- VERIFICA SE ESSA ERA A ULTIMA SPRITE
                    if( sprite_atual_index == ( dados.pointers.pointer_final_animacao_ON - 1 ) )
                    { Botao_dispositivo_SETAR.SETAR_ON_estatico( this ); return; }// --- VOLTAR PARA STATIC 


                // --- TROCAR SPRITE
                sprite_atual_index++;
                Botao_dispositivo_MUDAR_IMAGEM.Mudar_imagens_IMAGEM( this, sprite_atual_index );

                
                // --- RENOVA TEMPO
                if( dados.animacao_on_tempos.tempo_troca_sprite_ms_por_sprite != null )
                    { animacao_sprite_atual_tempo_ms = dados.animacao_on_tempos.tempo_troca_sprite_ms_por_sprite[ sprite_atual_index ]; }// --- TEM TEMPO DIFERENTE PARA CADA SPRITE
                    else
                    { animacao_sprite_atual_tempo_ms = dados.animacao_on_tempos.tempo_troca_sprite_ms; } // --- TEMPO UNICO


                return;


        }


        // --- TRANSICAO

        private void Lidar_transicao_animacao_OFF_para_ON(){


                switch( dados.tipo_transicao ){

                    case Tipo_transicao_botao_OFF_ON_dispositivo.nada : Botao_dispositivo_SETAR.SETAR_ON_estatico( this ); break;
                    case Tipo_transicao_botao_OFF_ON_dispositivo.cor : Botao_dispositivo_TRANSICAO.Lidar_transicao_animacao_OFF_para_ON_cor( this ); break;
                    case Tipo_transicao_botao_OFF_ON_dispositivo.animacao_individual : Botao_dispositivo_TRANSICAO.Lidar_transicao_animacao_OFF_para_ON_animacao_individual( this ); break;
                
                }


        }


        // --- ON -> OFF

        public void Lidar_transicao_animacao_ON_para_OFF(){
            
                switch( dados.tipo_transicao ){

                    case Tipo_transicao_botao_OFF_ON_dispositivo.nada : Botao_dispositivo_SETAR.SETAR_OFF_estatico( this ); break;
                    case Tipo_transicao_botao_OFF_ON_dispositivo.cor : Botao_dispositivo_TRANSICAO.Lidar_transicao_animacao_ON_para_OFF_cor( this ); break;
                    case Tipo_transicao_botao_OFF_ON_dispositivo.animacao_individual : Botao_dispositivo_TRANSICAO.Lidar_transicao_animacao_ON_para_OFF_animacao_individual( this ); break;
                
                }



        }








        public void Construir( Dados_botao_dispositivo _dados, string _path_dispositivo  ){

                // ** vai colocar os dados

                dados = _dados;

                string path_botao = _path_dispositivo + "/" + _dados.nome;

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

                                IMAGEM_animacao_back_game_object         =  IMAGEM_container.transform.GetChild( 0 ).gameObject;
                                IMAGEM_base_game_object                  =  IMAGEM_container.transform.GetChild( 1 ).gameObject;
                                IMAGEM_animacao_atras_texto_game_object  =  IMAGEM_container.transform.GetChild( 2 ).gameObject;
                                IMAGEM_texto_game_object                 =  IMAGEM_container.transform.GetChild( 3 ).gameObject;
                                IMAGEM_decoracao_game_object             =  IMAGEM_container.transform.GetChild( 4 ).gameObject;
                                IMAGEM_animacao_frente_texto_game_object =  IMAGEM_container.transform.GetChild( 5 ).gameObject;




                            // ** TRANSICAO
                                TRANSICAO_container = botao_game_object.transform.GetChild( 2 ).gameObject;

                                TRANSICAO_animacao_back_game_object         =   TRANSICAO_container.transform.GetChild( 0 ).gameObject;
                                TRANSICAO_base_game_object                  =   TRANSICAO_container.transform.GetChild( 1 ).gameObject;
                                TRANSICAO_animacao_atras_texto_game_object  =   TRANSICAO_container.transform.GetChild( 2 ).gameObject;
                                TRANSICAO_texto_game_object                 =   TRANSICAO_container.transform.GetChild( 3 ).gameObject;
                                TRANSICAO_decoracao_game_object             =   TRANSICAO_container.transform.GetChild( 4 ).gameObject;
                                TRANSICAO_animacao_frente_texto_game_object =   TRANSICAO_container.transform.GetChild( 5 ).gameObject;
                                

                                
                        // --- PEGAR IMAGES

                            // IMAGEM 

                                IMAGEM_animacao_back_image         =  IMAGEM_animacao_back_game_object.GetComponent<Image>();
                                IMAGEM_base_image                  =  IMAGEM_base_game_object.GetComponent<Image>();
                                IMAGEM_decoracao_image             =  IMAGEM_decoracao_game_object.GetComponent<Image>();
                                IMAGEM_animacao_atras_texto_image  =  IMAGEM_animacao_atras_texto_game_object.GetComponent<Image>();
                                IMAGEM_animacao_frente_texto_image =  IMAGEM_animacao_frente_texto_game_object.GetComponent<Image>();


                            // ** transicao

                                TRANSICAO_animacao_back_image         =  TRANSICAO_animacao_back_game_object.GetComponent<Image>();
                                TRANSICAO_base_image                  =  TRANSICAO_base_game_object.GetComponent<Image>();
                                TRANSICAO_decoracao_image             =  TRANSICAO_decoracao_game_object.GetComponent<Image>();
                                TRANSICAO_animacao_atras_texto_image  =  TRANSICAO_animacao_atras_texto_game_object.GetComponent<Image>();
                                TRANSICAO_animacao_frente_texto_image =  TRANSICAO_animacao_frente_texto_game_object.GetComponent<Image>();



                                // --- VERIFICA DECORACAO COMPOSTA
                                if( IMAGEM_decoracao_game_object.transform.childCount > 0 )
                                    {


                                        // --- TEM DECORACAO COMPOSTA
                                        // ** copia o game object para detro da imagem da transicao

                                        if( IMAGEM_decoracao_game_object.transform.childCount != 1 )
                                            { throw new Exception("Dentro de decoracao tinha mais de 1 gameObject. Se a decoracao for composta ela precisa estar dentro de outro container: decoracao => container_dec_composta => gameObjects[]. O sistema vai somente copiar o gameObject para a transicao"); }

                                        if( _dados.sprites_decoracao_composta == null )
                                            { throw new Exception( $"Tinha um gameObject contianer na decoracao do botao <color=lightBlue><b>{ _dados.nome}</b></color> no dispositivo <color=lightBlue><b>{ _dados.nome_dispositivo }</b></color> MAS nao foi declarado as imagens das sprites." );}


                                        IMAGEM_decoracao_composta_game_object = IMAGEM_decoracao_game_object.transform.GetChild( 0 ).gameObject;
                                        TRANSICAO_decoracao_composta_game_object = GameObject.Instantiate( IMAGEM_decoracao_composta_game_object );

                                        TRANSICAO_decoracao_composta_game_object.transform.SetParent( TRANSICAO_decoracao_game_object.transform, false );


                                        int numero_imagens_decoracao_composta = IMAGEM_decoracao_composta_game_object.transform.childCount;

                                        if( numero_imagens_decoracao_composta == 0 )
                                            { throw new Exception( $"Tinha um gameObject contianer na decoracao do botao <color=lightBlue><b>{ _dados.nome}</b></color> no dispositivo <color=lightBlue><b>{ _dados.nome_dispositivo }</b></color> mas ele nao tinha nenhum gameObject." );}

                                        if( _dados.sprites_decoracao_composta.GetLength( 0 ) > numero_imagens_decoracao_composta )
                                            { throw new Exception( $"Tinha um gameObject contianer na decoracao do botao <color=lightBlue><b>{ _dados.nome}</b></color> no dispositivo <color=lightBlue><b>{ _dados.nome_dispositivo }</b></color> MAS o numero de gameObjects [ { numero_imagens_decoracao_composta } ] é menor que o numero de sprites [ { _dados.sprites_decoracao_composta.GetLength( 0 ) } ]." );}


                                        IMAGEM_decoracao_composta_images = new Image[ numero_imagens_decoracao_composta ];
                                        TRANSICAO_decoracao_composta_images = new Image[ numero_imagens_decoracao_composta ];

                                        for( int imagem = 0 ; imagem < numero_imagens_decoracao_composta ; imagem++ ){


                                                IMAGEM_decoracao_composta_images[ imagem ] = IMAGEM_decoracao_composta_game_object.transform.GetChild( imagem ).gameObject.GetComponent<Image>();
                                                TRANSICAO_decoracao_composta_images[ imagem ] = TRANSICAO_decoracao_composta_game_object.transform.GetChild( imagem ).gameObject.GetComponent<Image>();

                                                IMAGEM_decoracao_composta_images[ imagem ].material = dados.material_dispositivo; 
                                                TRANSICAO_decoracao_composta_images[ imagem ].material = dados.material_dispositivo;
                                                
                                                continue;

                                        }



                                    }

                                

                        // --- PEGAR TEXTO

                            IMAGEM_texto = IMAGEM_texto_game_object.GetComponent<TMP_Text>();
                            TRANSICAO_texto = TRANSICAO_texto_game_object.GetComponent<TMP_Text>();


                        // --- COLIDERS

                            ON_collider = ON_collider_game_object.GetComponent<PolygonCollider2D>();
                            OFF_collider = OFF_collider_game_object.GetComponent<PolygonCollider2D>();
                        
                        
                        posicao_x =  botao_game_object.transform.localPosition.x;
                        posicao_y =  botao_game_object.transform.localPosition.y;


                }
                catch ( System.Exception exc )
                {
                    Debug.LogError( $"Nao conseguiu pegar os dados do botao <color=lightBlue><b>{ _dados.nome}</b></color> no dispositivo <color=lightBlue><b>{ _dados.nome_dispositivo }</b></color>." );
                    throw exc;

                }

                // --- COLOCAR MATERIAL

                    // ** OFF

                        IMAGEM_animacao_back_image.material = dados.material_dispositivo;
                        IMAGEM_base_image.material = dados.material_dispositivo;
                        IMAGEM_decoracao_image.material = dados.material_dispositivo;
                        IMAGEM_animacao_atras_texto_image.material = dados.material_dispositivo;
                        IMAGEM_animacao_frente_texto_image.material = dados.material_dispositivo;
                        IMAGEM_texto.material = dados.material_dispositivo;



                    // ** TRANSICAO

                        TRANSICAO_base_image.material = dados.material_dispositivo;
                        TRANSICAO_decoracao_image.material = dados.material_dispositivo;
                        TRANSICAO_animacao_atras_texto_image.material = dados.material_dispositivo;
                        TRANSICAO_animacao_frente_texto_image.material = dados.material_dispositivo;
                        TRANSICAO_texto.material = dados.material_dispositivo;

                
                // --- LOGICA 


                Botao_dispositivo_SETAR.SETAR_OFF_estatico( this );
            
                return;


        }





        // --- AUDIOS



}
