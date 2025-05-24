using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public enum UI_use_state {

    used, 
    waiting_to_delete,
    unused,

}


public class UI_button_COMPLETE : UI_button {

            
            
            public static UI_button_COMPLETE Get_button(){ 

                    UI_button_COMPLETE button = Containers.UI_button_COMPLETE.Get();
                    button.use_state = UI_use_state.used;

                    DEFAULT_APPLICATOR__UI_button_COMPLETE.Apply_default( button );

                    return button;
                
            }


        public override void Force_active(){ Console.Log( "tem que fazer" ); }
        public override void Force_inactive(){ TOOL__UI_button_SET_COMPLETE.SET_OFF_static( this ); }
        public override void Force_nothing(){ Console.Log( "tem que fazer" ); }



            protected override void Destroy_abs(){

                resources_container.Delete_all_resources();
                Containers.UI_button_COMPLETE.Return_object( this );
                
            }



            public UI_button_type type = UI_button_type.simple;

            public MANAGER__UI_button_resources_COMPLETE manager_resources;

            public DATA_CREATION__UI_button_COMPLETE creation_data;
            public DATA__UI_button_COMPLETE data;
        

            // ** OFF 


                public Unity_main_components IMAGE_animation_back;
                public Unity_main_components IMAGE_base;
                public Unity_main_components IMAGE_animation_back_text;
                public Unity_main_components IMAGE_text;
                public Unity_main_components IMAGE_decoration;
                public Unity_main_components IMAGE_animation_front_text;
                
                
                    public GameObject IMAGE_composed_decoration_game_object;


            // ** TRANSICAO

            
                public Unity_main_components TRANSITION_animation_back;
                public Unity_main_components TRANSITION_base;
                public Unity_main_components TRANSITION_animation_back_text;
                public Unity_main_components TRANSITION_text;
                public Unity_main_components TRANSITION_decoration;
                public Unity_main_components TRANSITION_animation_front_text;



                    public GameObject TRANSITION_composed_decoration;

                public Image[] TRANSITION_composed_decoration_images;
                public Image[] IMAGE_composed_decoration_images;




        public UI_button_COMPLETE_visual_state current_visual_state;
        public UI_button_COMPLETE_visual_state visual_state_going_to;



        public UI_button_COMPLETE_visual_state estado_visual_botao;
        public UI_button_COMPLETE_visual_state ultimo_estado_visual_botao;





    public override void Change_text( string _text ){ throw new NotImplementedException(); }

    
    protected override void Create_data_FROM_creation_data(){

                // creation -> data


                
                string indentificador = null;

                //mark 
                // ver 
                int numero_de_partes = -1;
                // ponto princiapal => criar os 3 
                data.images_refs_animacoes_completas = new RESOURCE__image_ref[ numero_de_partes, 2 ];
                data.cores_animacoes_completas   = new Color[ numero_de_partes, 2 ]; // criar aqui


                int index_OFF = 0;
                int index_ON = 1;

                data.pointers.pointer_imagem_estatica_OFF = index_OFF;
                data.pointers.pointer_imagem_estatica_ON = index_ON; 


                // ** seta tempos
                data.animacao_on_tempos.tempo_espera_para_ativar_ms = float.MaxValue;
                data.animacao_off_tempos.tempo_espera_para_ativar_ms = float.MaxValue;

                data.animacao_on_tempos.tempo_troca_sprite_ms = 0f;
                data.animacao_off_tempos.tempo_troca_sprite_ms = 0f;
                

                // --- transicao cor
                data.animacao_ON_para_OFF_tempos.tempo_espera_para_ativar_ms = creation_data.tempo_transicao;
                data.animacao_OFF_para_ON_tempos.tempo_espera_para_ativar_ms = creation_data.tempo_transicao;


                data.tipo_transicao = DEVICE_button_transition_type_OFF_ON.cor;

                MANAGER__resources_images resources_image = Controllers.resources.images;
                

                // OFF 


                    data.off.texto_cor = TOOL__UI_button_change_colors.Guarantee_color(  data.off.texto_cor, Cores.black );


                    // ** back
                        data.off.animacao_back.cor = TOOL__UI_button_change_colors.Guarantee_color(  data.off.animacao_back.cor, Cores.grey_90 );
                        data.images_refs_animacoes_completas[ ( int ) Device_button_animation_part.animation_back , index_OFF ] = resources_image.Get_image_reference( Resource_context.Devices, data.main_folder, data.off.animacao_back.image_path, Resource_image_content.sprite  );
                        data.cores_animacoes_completas[ ( int ) Device_button_animation_part.animation_back , index_OFF ] =    data.off.animacao_back.cor;


                    // ** base
                        data.off.animacao_base.cor = TOOL__UI_button_change_colors.Guarantee_color(  data.off.texto_cor, Cores.white );
                        data.images_refs_animacoes_completas[ ( int ) Device_button_animation_part.animation_base , index_OFF ] = resources_image.Get_image_reference( Resource_context.Devices, data.main_folder, data.off.animacao_base.image_path, Resource_image_content.sprite  );
                        data.cores_animacoes_completas[ ( int ) Device_button_animation_part.animation_base , index_OFF ] = data.off.animacao_base.cor;


                    // ** atras-texto
                        data.off.animacao_atras_texto.cor = TOOL__UI_button_change_colors.Guarantee_color(  data.off.animacao_atras_texto.cor, Cores.grey_90 );
                        data.images_refs_animacoes_completas[ ( int ) Device_button_animation_part.animation_back_text , index_OFF ] = resources_image.Get_image_reference( Resource_context.Devices, data.main_folder, data.off.animacao_atras_texto.image_path, Resource_image_content.sprite  );
                        data.cores_animacoes_completas[ ( int ) Device_button_animation_part.animation_back_text , index_OFF ] = data.off.animacao_atras_texto.cor;


                        
                    // ** decoracao
                        data.off.animacao_decoracao.cor = TOOL__UI_button_change_colors.Guarantee_color(  data.off.animacao_decoracao.cor, Cores.grey_90 );
                        data.images_refs_animacoes_completas[ ( int ) Device_button_animation_part.animation_decoration , index_OFF ] =  resources_image.Get_image_reference( Resource_context.Devices, data.main_folder, data.off.animacao_decoracao.image_path, Resource_image_content.sprite  );
                        data.cores_animacoes_completas[ ( int ) Device_button_animation_part.animation_decoration , index_OFF ] = data.off.animacao_decoracao.cor;

                    

                    // ** frente-texto
                        data.off.animacao_frente_texto.cor = TOOL__UI_button_change_colors.Guarantee_color(  data.off.animacao_frente_texto.cor, Cores.grey_90 );
                        data.images_refs_animacoes_completas[ ( int ) Device_button_animation_part.animation_front_text , index_OFF ] =  resources_image.Get_image_reference( Resource_context.Devices, data.main_folder, data.off.animacao_frente_texto.image_path, Resource_image_content.sprite  );
                        data.cores_animacoes_completas[ ( int ) Device_button_animation_part.animation_front_text , index_OFF ] = data.off.animacao_frente_texto.cor;


                    
                // ON


                    data.on.texto_cor = TOOL__UI_button_change_colors.Guarantee_color(  data.on.texto_cor, Cores.black );


                    // ** back
                    indentificador = ( name + "_ON_back" );
                    
                        data.on.animacao_back.cor = TOOL__UI_button_change_colors.Guarantee_color(  data.on.animacao_back.cor, Cores.grey_90 );                
                        data.images_refs_animacoes_completas[ ( int ) Device_button_animation_part.animation_back , index_ON ] =  resources_image.Get_image_reference( Resource_context.Devices, data.main_folder, data.on.animacao_back.image_path, Resource_image_content.sprite  );
                        data.cores_animacoes_completas[ ( int ) Device_button_animation_part.animation_back , index_ON ] = data.on.animacao_back.cor;


                    // ** base
                    indentificador = ( name + "_ON_base" );
                    
                        data.on.animacao_base.cor = TOOL__UI_button_change_colors.Guarantee_color(  data.on.animacao_base.cor, Cores.grey_90 );                    
                        data.images_refs_animacoes_completas[ ( int ) Device_button_animation_part.animation_base , index_ON ] =  resources_image.Get_image_reference( Resource_context.Devices, data.main_folder, data.on.animacao_base.image_path, Resource_image_content.sprite  );
                        data.cores_animacoes_completas[ ( int ) Device_button_animation_part.animation_base , index_ON ] = data.on.animacao_base.cor;


                    // ** atras-texto
                    indentificador = ( name + "_ON_atras_texto" );
            
                        data.on.animacao_atras_texto.cor = TOOL__UI_button_change_colors.Guarantee_color(  data.on.animacao_atras_texto.cor, Cores.grey_90 );                    
                        data.images_refs_animacoes_completas[ ( int ) Device_button_animation_part.animation_back_text , index_ON ] =  resources_image.Get_image_reference( Resource_context.Devices, data.main_folder, data.on.animacao_atras_texto.image_path, Resource_image_content.sprite  );
                        data.cores_animacoes_completas[ ( int ) Device_button_animation_part.animation_back_text , index_ON ] = data.on.animacao_atras_texto.cor;

                    
                    // ** decoracao
                    indentificador = ( name + "_ON_decoracao" );
                    data.on.animacao_decoracao.cor = TOOL__UI_button_change_colors.Guarantee_color(  data.on.animacao_decoracao.cor, Cores.grey_90 );


                    data.images_refs_animacoes_completas[ ( int ) Device_button_animation_part.animation_decoration , index_ON ] =  resources_image.Get_image_reference( Resource_context.Devices, data.main_folder, data.on.animacao_decoracao.image_path, Resource_image_content.sprite  );
                    data.cores_animacoes_completas[ ( int ) Device_button_animation_part.animation_decoration , index_ON ] = data.on.animacao_decoracao.cor;

                    

                    // ** frente-texto
                    indentificador = ( name + "_ON_frente_texto" );
                    
                    data.on.animacao_frente_texto.cor = TOOL__UI_button_change_colors.Guarantee_color(  data.on.animacao_frente_texto.cor, Cores.grey_90 );

                    data.images_refs_animacoes_completas[ ( int ) Device_button_animation_part.animation_front_text , index_ON ] =  resources_image.Get_image_reference( Resource_context.Devices, data.main_folder, data.on.animacao_frente_texto.image_path, Resource_image_content.sprite  );
                    data.cores_animacoes_completas[ ( int ) Device_button_animation_part.animation_front_text , index_ON ] = data.on.animacao_frente_texto.cor;

                    



                    // --- DECORACAO COMPOSTA

                    if( data.off.decoracao_composta != null || data.off.decoracao_composta != null )
                        {  

                            // Criar_decoracao_composta_simples( _dados, _dispositivo, index_OFF, index_ON, name );
            
                            // --- TEM DECORACAO COMPOSTA

                        }







        }
        

        public override void Update_parte_visual(){


                switch( estado_visual_botao ){

                        case UI_button_COMPLETE_visual_state.off_estatico: TOOL__UI_button_handler_COMPLETE.Handle_off_static( this ); break;
                        case UI_button_COMPLETE_visual_state.on_estatico: TOOL__UI_button_handler_COMPLETE.Handle_on_static( this ); break;

                        case UI_button_COMPLETE_visual_state.transicao_animacao_OFF_para_ON: TOOL__UI_button_handler_COMPLETE.Handle_transition_animation_OFF_to_ON( this ); break;
                        case UI_button_COMPLETE_visual_state.transicao_animacao_ON_para_OFF: TOOL__UI_button_handler_COMPLETE.Lidar_transicao_animacao_ON_para_OFF( this ); break;

                        default: CONTROLLER__errors.Throw( $"can not handle stage { estado_visual_botao }" ); break;

                }
            
        }


        protected override void Link_to_UI_game_object_in_structure( GameObject _UI_game_object ){


                // data -> unity data

                try {

                    // --- PEGAR GAMEOBJECTS

                        // ** COLLIDERS

                            COLLIDERS_container  = _UI_game_object.transform.GetChild( 0 ).gameObject;
                            
                            ON_collider_game_object   =  COLLIDERS_container.transform.GetChild( 0 ).gameObject;
                            OFF_collider_game_object  =  COLLIDERS_container.transform.GetChild( 1 ).gameObject;


                        // IMAGEM
                            IMAGE_container = _UI_game_object.transform.GetChild( 1 ).gameObject;

                            IMAGE_animation_back.game_object         =  IMAGE_container.transform.GetChild( 0 ).gameObject;
                            IMAGE_base.game_object                   =  IMAGE_container.transform.GetChild( 1 ).gameObject;
                            IMAGE_animation_back_text.game_object    =  IMAGE_container.transform.GetChild( 2 ).gameObject;
                            IMAGE_text.game_object                   =  IMAGE_container.transform.GetChild( 3 ).gameObject;
                            IMAGE_decoration.game_object             =  IMAGE_container.transform.GetChild( 4 ).gameObject;
                            IMAGE_animation_front_text.game_object   =  IMAGE_container.transform.GetChild( 5 ).gameObject;




                        // ** TRANSICAO
                            TRANSITION_container = _UI_game_object.transform.GetChild( 2 ).gameObject;

                            TRANSITION_animation_back.game_object          =   TRANSITION_container.transform.GetChild( 0 ).gameObject;
                            TRANSITION_base.game_object                    =   TRANSITION_container.transform.GetChild( 1 ).gameObject;
                            TRANSITION_animation_back_text.game_object     =   TRANSITION_container.transform.GetChild( 2 ).gameObject;
                            TRANSITION_text.game_object                    =   TRANSITION_container.transform.GetChild( 3 ).gameObject;
                            TRANSITION_decoration.game_object              =   TRANSITION_container.transform.GetChild( 4 ).gameObject;
                            TRANSITION_animation_front_text.game_object    =   TRANSITION_container.transform.GetChild( 5 ).gameObject;
                            

                            
                    // --- PEGAR IMAGES

                        // IMAGEM 

                            IMAGE_animation_back.image         =  IMAGE_animation_back.game_object.GetComponent<Image>();
                            IMAGE_base.image                   =  IMAGE_base.game_object.GetComponent<Image>();
                            IMAGE_decoration.image             =  IMAGE_decoration.game_object.GetComponent<Image>();
                            IMAGE_animation_back_text.image    =  IMAGE_animation_back_text.game_object.GetComponent<Image>();
                            IMAGE_animation_front_text.image   =  IMAGE_animation_front_text.game_object.GetComponent<Image>();


                        // ** transicao

                            TRANSITION_animation_back.image         =  TRANSITION_animation_back.game_object.GetComponent<Image>();
                            TRANSITION_base.image                   =  TRANSITION_base.game_object.GetComponent<Image>();
                            TRANSITION_decoration.image             =  TRANSITION_decoration.game_object.GetComponent<Image>();
                            TRANSITION_animation_back_text.image    =  TRANSITION_animation_back_text.game_object.GetComponent<Image>();
                            TRANSITION_animation_front_text.image   =  TRANSITION_animation_front_text.game_object.GetComponent<Image>();




                            // --- VERIFICA DECORACAO COMPOSTA
                            if( IMAGE_decoration.game_object.transform.childCount > 0 )
                                {

                                    CONTROLLER__errors.Throw( "ainda nao usar decoração composta. Decoração composta provavelmente vai usar RESOURCE__image_sequences e aind anão esta pronto" );

                                    //mark 
                                    // nao tenho ideia de como isso funciona

                                    // --- TEM DECORACAO COMPOSTA
                                    // ** copia o game object para detro da imagem da transicao

                                    if( IMAGE_decoration.game_object.transform.childCount != 1 )
                                        { CONTROLLER__errors.Throw(  "Dentro de decoracao tinha mais de 1 gameObject. Se a decoracao for composta ela precisa estar dentro de outro container: decoracao => container_dec_composta => gameObjects[]. O sistema vai somente copiar o gameObject para a transicao" ); }

                                    if( data.sprites_decoracao_composta == null )
                                        { CONTROLLER__errors.Throw(  $"Tinha um gameObject contianer na decoracao do botao <color=lightBlue><b>{ name }</b></color> MAS nao foi declarado as imagens das sprites." ); }


                                    IMAGE_composed_decoration_game_object = IMAGE_decoration.game_object.transform.GetChild( 0 ).gameObject;
                                    TRANSITION_composed_decoration = GameObject.Instantiate( IMAGE_composed_decoration_game_object );

                                    TRANSITION_composed_decoration.transform.SetParent( TRANSITION_decoration.game_object.transform, false );


                                    int numero_imagens_decoracao_composta = IMAGE_composed_decoration_game_object.transform.childCount;

                                    if( numero_imagens_decoracao_composta == 0 )
                                        { CONTROLLER__errors.Throw( $"Tinha um gameObject contianer na decoracao do botao <color=lightBlue><b>{ name }</b></color> mas ele nao tinha nenhum gameObject." );}

                                    if( data.sprites_decoracao_composta.GetLength( 0 ) > numero_imagens_decoracao_composta )
                                        { CONTROLLER__errors.Throw( $"Tinha um gameObject contianer na decoracao do botao <color=lightBlue><b>{ name }</b></color> MAS o numero de gameObjects [ { numero_imagens_decoracao_composta } ] é menor que o numero de sprites [ { data.sprites_decoracao_composta.GetLength( 0 ) } ]." );}


                                    IMAGE_composed_decoration_images = new Image[ numero_imagens_decoracao_composta ];
                                    TRANSITION_composed_decoration_images = new Image[ numero_imagens_decoracao_composta ];

                                    for( int imagem = 0 ; imagem < numero_imagens_decoracao_composta ; imagem++ ){


                                            IMAGE_composed_decoration_images[ imagem ] = IMAGE_composed_decoration_game_object.transform.GetChild( imagem ).gameObject.GetComponent<Image>();
                                            TRANSITION_composed_decoration_images[ imagem ] = TRANSITION_composed_decoration.transform.GetChild( imagem ).gameObject.GetComponent<Image>();

                                            IMAGE_composed_decoration_images[ imagem ].material = data.device_material; 
                                            TRANSITION_composed_decoration_images[ imagem ].material = data.device_material;
                                            
                                            continue;

                                    }


                                }

                                

                        // --- PEGAR TEXTO

                            IMAGE_text.tmp_text = IMAGE_text.game_object.GetComponent<TMP_Text>();
                            TRANSITION_text.tmp_text = TRANSITION_text.game_object.GetComponent<TMP_Text>();


                        // --- COLIDERS

                            ON_collider = ON_collider_game_object.GetComponent<PolygonCollider2D>();
                            OFF_collider = OFF_collider_game_object.GetComponent<PolygonCollider2D>();
                        
                        
                }
                catch ( System.Exception exc )
                {
                    Debug.LogError( $"Nao conseguiu pegar os dados do botao <color=lightBlue><b>{ name}</b></color>." );
                    throw exc;

                }

                // --- COLOCAR MATERIAL

                    //mark
                    // ** material ainda esta como device
                    // ** depois ver como fazer

                    // ** OFF

                        IMAGE_animation_back.image.material = data.device_material;
                        IMAGE_base.image.material = data.device_material;
                        IMAGE_decoration.image.material = data.device_material;
                        IMAGE_animation_back_text.image.material = data.device_material;
                        IMAGE_animation_front_text.image.material = data.device_material;
                        IMAGE_text.tmp_text.material = data.device_material;


                    // ** TRANSICAO

                        TRANSITION_base.image.material = data.device_material;
                        TRANSITION_decoration.image.material = data.device_material;
                        TRANSITION_animation_back_text.image.material = data.device_material;
                        TRANSITION_animation_front_text.image.material = data.device_material;
                        TRANSITION_text.tmp_text.material = data.device_material;

                
                // --- LOGICA 


                TOOL__UI_button_SET_COMPLETE.SET_OFF_static( this );
            
                return;


        }



}