using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Botao_dispositivo {



        // ** COLLIDERS

            public GameObject COLLIDERS_container;

                public GameObject OFF_collider_game_object;
                public GameObject ON_collider_game_object;



        // --- SIMPLE 

                public Unity_main_components IMAGE_simple_body;
                public Unity_main_components IMAGE_simple_text;

                public Unity_main_components TRANSITION_simple_body;
                public Unity_main_components TRANSITION_simple_text;


        // --- COMPLETE

            // ** OFF 

                public GameObject IMAGE_container;

                public Unity_main_components IMAGE_animation_back;
                public Unity_main_components IMAGE_base;
                public Unity_main_components IMAGE_animation_back_text;
                public Unity_main_components IMAGE_text;
                public Unity_main_components IMAGE_decoration;
                public Unity_main_components IMAGE_animation_front_text;
                
                
                    public GameObject IMAGE_composed_decoration_game_object;


            // ** TRANSICAO
                public GameObject TRANSITION_container;

                public Unity_main_components TRANSITION_animation_back;
                public Unity_main_components TRANSITION_base;
                public Unity_main_components TRANSITION_animation_back_text;
                public Unity_main_components TRANSITION_text;
                public Unity_main_components TRANSITION_decoration;
                public Unity_main_components TRANSITION_animation_front_text;

                    public GameObject TRANSITION_composed_decoration;




                public Image[] TRANSITION_composed_decoration_images;
                public Image[] IMAGE_composed_decoration_images;


        // --- COLLIDERS

            public PolygonCollider2D OFF_collider;
            public PolygonCollider2D ON_collider;
        

        // --- INTERNO

        public float position_x;
        public float position_y;


        public Resource_state resource_state;

        
        public MANAGER__UI_button_resources manager_resources;


        public RESOURCE__audio_ref audio_click;
        public RESOURCE__audio_ref audio_houver;
        
        

        public Dados_botao_dispositivo data;

        public GameObject botao_game_object;


        public string button_name = "Nao_colocou";


        // --- LOGICA INTERNA

        public bool is_active;
        public Resource_use_state state;



        public UI_button_type type;


        public bool esta_down = false; 
        public bool esta_houver = false;


        public float animacao_atual_tempo_ms = 0f;
        public float animacao_sprite_atual_tempo_ms = 0f;
        public int sprite_atual_index = -1;

    
        public DEVICE_button_visual_state estado_visual_botao;


        // ---- SUPORTE INTERNO

        public DEVICE_button_visual_state ultimo_estado_visual_botao;





        public void Activate_button(){

            is_active = true;
            Update();

        }


        public void Deactivate_button(){

            is_active = false;

        }




        // --- PUBLIC 
        
        public void Update(){

                if( !!!( is_active ) )
                    { return; }
        
                if( data.update_para_substituir != null )
                    { data.update_para_substituir( this ); return; }
        
                TOOL__UI_button_UPDATE.Update_logica( this ); 
                TOOL__UI_button_UPDATE.Update_parte_visual( this ); 


                if( data.Update_secundario != null )
                    { data.Update_secundario(); }

                return;

        }


        // ** declara is nothing -> creation data? 
        // ** declare não faz parte do botao, pois declare vai de nada -> creation data e declara um botao para a estrutura

        public void Define_button(){

                // creation data -> data

                TOOL__UI_button_VERIFICATIONS.Verify_default( this );
                
                button_name = data.nome;
                type = data.type;

                manager_resources =  new MANAGER__UI_button_resources( this );

                CONTROLLER__errors.Verify( ( type == UI_button_type.not_give ), $"In the button { button_name } was not put the button <Color=lightBlue><b>TYPE</b></Color>" );

                switch( type ){

                    case UI_button_type.simple: TOOL__UI_button_DEFINER_SIMPLE.Define( this ); break;
                    case UI_button_type.complete: TOOL__UI_button_DEFINER_COMPLETE.Define( this ); break;
                    case UI_button_type.complex: TOOL__UI_button_DEFINER_COMPLEX.Define( this ); break;
                    default: CONTROLLER__errors.Throw( $"Can not handle type { type }" ); break;

                }

        }


        public void Link_to_game_object( GameObject _button_game_object ){

                // data -> unity data

                CONTROLLER__errors.Verify( ( _button_game_object == null ), $"The button <Color=lightBlue>{ button_name }</Color> came in <Color=lightBlue>Get_data_SIMPLE</Color> but the gameObject was null" );
                botao_game_object = _button_game_object;

                switch( type ){

                    case UI_button_type.simple: TOOL__UI_button_GETTER_SIMPLE.Get( this ); break;    
                    case UI_button_type.complete: TOOL__UI_button_GETTER_COMPLETE.Get( this ); break;
                    case UI_button_type.complex: TOOL__UI_button_GETTER_COMPLETE.Get( this ); break;
                    default : CONTROLLER__errors.Throw( "Button type not accepted: " + type ); break;

                }

        }

        
}
