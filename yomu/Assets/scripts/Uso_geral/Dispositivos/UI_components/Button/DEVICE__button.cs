using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Botao_dispositivo {

        // --- GAME OBEJCTS

            // ** OFF 

                public GameObject IMAGEM_container;

                public Unity_main_components IMAGE_animation_back;
                public Unity_main_components IMAGE_base;
                public Unity_main_components IMAGE_animation_back_text;
                public GameObject IMAGE_text_game_object;
                public Unity_main_components IMAGE_decoration;
                public Unity_main_components IMAGE_animation_front_text;
                
                
                    public GameObject IMAGE_composed_decoration_game_object;


            // ** TRANSICAO
                public GameObject TRANSITION_container;

                public Unity_main_components TRANSITION_animation_back;
                public Unity_main_components TRANSITION_base;
                public Unity_main_components TRANSITION_animation_back_text;
                public GameObject TRANSITION_texo_game_object;
                public Unity_main_components TRANSITION_decoration;
                public Unity_main_components TRANSITION_animation_front_text;

                    public GameObject TRANSITION_composed_decoration;




            // ** COLLIDERS

                public GameObject COLLIDERS_container;

                    public GameObject OFF_collider_game_object;
                    public GameObject ON_collider_game_object;


                public Image[] TRANSITION_composed_decoration_images;
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
        


        public Dados_botao_dispositivo data;
        public GameObject botao_game_object;

        public string button_name = "Nao_colocou";


        // --- LOGICA INTERNA


        public UI_button_type type;


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
                        esta_houver = Polygon.Check_point_inside( ON_collider.points, ( Vector2 ) IMAGE_base.game_object.transform.position , Controlador_cursor.Pegar_instancia().posicao_cursor );
                        if( !!!( esta_houver ) )
                            { esta_down = false; return; } // --- SAIU
                    }
                    else
                    { 
                        // --- VERIFICA SE ENTROU
                        esta_houver = Polygon.Check_point_inside( OFF_collider.points, ( Vector2 ) IMAGE_base.game_object.transform.position , Controlador_cursor.Pegar_instancia().posicao_cursor ); 
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

                        case DEVICE_button_visual_state.off_estatico: TOOL__UI_button_HANDLER.Handle_off_static( this ); break;
                        case DEVICE_button_visual_state.off_animacao: TOOL__UI_button_HANDLER.Handle_off_animation( this ); break;
                        case DEVICE_button_visual_state.on_estatico: TOOL__UI_button_HANDLER.Handle_on_static( this ); break;
                        case DEVICE_button_visual_state.on_animacao: TOOL__UI_button_HANDLER.Handle_on_animation( this ); break;

                        case DEVICE_button_visual_state.transicao_animacao_OFF_para_ON: TOOL__UI_button_HANDLER.Handle_transition_animation_OFF_to_ON( this ); break;
                        case DEVICE_button_visual_state.transicao_animacao_ON_para_OFF: TOOL__UI_button_HANDLER.Lidar_transicao_animacao_ON_para_OFF( this ); break;

                }

                return;


        }
        


}
