using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;




public class UI_button_SIMPLE : UI_button {

        
        public static UI_button_SIMPLE Get_button( string _name ){ 

                UI_button_SIMPLE button = Containers.UI_button_SIMPLE.Get();
                
                    button.use_state = UI_use_state.used;
                    button.name = _name;

                DEFAULT_APPLICATOR__UI_button_SIMPLE.Apply_default( button );

                return button;
            
        }
        protected override void Destroy_abs(){

            resources_container.Delete_all_resources();
            Containers.UI_button_SIMPLE.Return_object( this );
            
        }
            
            
        public override void Force_active(){}
        public override void Force_inactive(){ TOOL__UI_button_SET_SIMPLE.SET_OFF_static( this ); }
        public override void Force_nothing(){}



        public UI_button_type type = UI_button_type.simple;

        public DATA_CREATION__UI_button_SIMPLE creation_data;
        public DATA__UI_button_SIMPLE data;

        public MANAGER__UI_button_resources_SIMPLE manager_resources;
        

        public Unity_main_components IMAGE_body;
        public Unity_main_components IMAGE_text;

        public Unity_main_components TRANSITION_body;
        public Unity_main_components TRANSITION_text;



        public UI_button_SIMPLE_visual_state current_visual_state;
        public UI_button_SIMPLE_visual_state visual_state_going_to;



        public UI_button_SIMPLE_visual_state estado_visual_botao;
        public UI_button_SIMPLE_visual_state ultimo_estado_visual_botao;



        
        public override void Change_text( string _text ){

                data.text_off = _text;
                data.text_on  = _text;
        }


        public override void Update_parte_visual(){

                    if( data.bloquear_update_visual  )
                        { return; }

                    ultimo_estado_visual_botao = estado_visual_botao;

                    switch( estado_visual_botao ){

                            case UI_button_SIMPLE_visual_state.off_estatico: TOOL__UI_button_handler_SIMPLE.Handle_off_static( this ); break;
                            case UI_button_SIMPLE_visual_state.on_estatico: TOOL__UI_button_handler_SIMPLE.Handle_on_static( this ); break;

                            case UI_button_SIMPLE_visual_state.transicao_animacao_OFF_para_ON: TOOL__UI_button_handler_SIMPLE.Handle_transition_animation_OFF_to_ON( this ); break;
                            case UI_button_SIMPLE_visual_state.transicao_animacao_ON_para_OFF: TOOL__UI_button_handler_SIMPLE.Lidar_transicao_animacao_ON_para_OFF( this ); break;

                            default: CONTROLLER__errors.Throw( $"can not handle stage { estado_visual_botao }" ); break;

                    }

            
        }

    
    protected override void Create_data_FROM_creation_data(){

            // ** data + creation_data -> thing

                // --- VERIFICATIONS
                TOOL__UI_button_VERIFICATIONS_SIMPLE.Verify_default( this );

                data.Ativar = creation_data.Activate;

                // ** passing normal data
                main_folder = creation_data.main_folder;
                context = creation_data.context;
                material = creation_data.material;

                // --- TEXT
                
                if( creation_data.text != null )
                    {
                        // ** nao pode ter nenhum

                        if( creation_data.text_off != null )
                            { CONTROLLER__errors.Throw( $"button { name } defines a text <Color=lightBlue>{ creation_data.text }</Color> for OFF and ON but in the OFF text is <Color=lightBlue>{  creation_data.text_off }</Color>" ); }

                        if( creation_data.text_on != null )
                            { CONTROLLER__errors.Throw( $"button { name } defines a text <Color=lightBlue>{ creation_data.text }</Color> for OFF and ON but in the OFF text is <Color=lightBlue>{  creation_data.text_on }</Color>" ); }
                
                        data.text_off = creation_data.text;
                        data.text_on  = creation_data.text;
                    }
                    else
                    {
                        // ** tem que ter os 2

                        if( creation_data.text_off == null )
                            { CONTROLLER__errors.Throw( $"button { name } Dont define the text for the <Color=lightBlue>OFF</Color>" ); }

                        if( creation_data.text_on == null )
                            { CONTROLLER__errors.Throw( $"button { name } Dont define the text for the <Color=lightBlue>ON</Color>" ); }

                        data.text_off = creation_data.text_off;
                        data.text_on  = creation_data.text_on;
                    }


                // --- IMAGES
                if( creation_data.image_path != null )
                    {

                        if( creation_data.image_path_OFF != null )
                            { CONTROLLER__errors.Throw( $"button { name } defines a path <Color=lightBlue>{ creation_data.image_path }</Color> for OFF and ON but in the OFF path is <Color=lightBlue>{  creation_data.image_path_OFF }</Color>" ); }

                        if( creation_data.image_path_ON != null )
                            { CONTROLLER__errors.Throw( $"button { name } defines a path <Color=lightBlue>{ creation_data.image_path }</Color> for OFF and ON but in the ON path is <Color=lightBlue>{ data.button_ON_frame.path }</Color>" ); }

                        data.button_OFF_frame.path  = creation_data.image_path;
                        data.button_ON_frame.path   = creation_data.image_path;


                    }
                    else
                    {
                        
                        if( creation_data.image_path_ON == null )
                            { CONTROLLER__errors.Throw( $"button { name } do not define <Color=lightBlue>path_ON</Color>" ); }

                        if( creation_data.image_path_OFF == null )
                            { CONTROLLER__errors.Throw( $"button { name } do not define <Color=lightBlue>path_OFF</Color>" ); }

                            
                        data.button_OFF_frame.path  = creation_data.image_path_OFF;
                        data.button_ON_frame.path   = creation_data.image_path_ON;

                    }

                
                if( data.time_transition_ON_to_OFF == 0 )
                    { data.time_transition_ON_to_OFF = creation_data.tempo_transicao; }

                if( data.time_transition_OFF_to_ON == 0 )
                    { data.time_transition_OFF_to_ON = creation_data.tempo_transicao; }

                manager_resources.minimun.image = creation_data.image_resource_pre_allocation;
                manager_resources.minimun.audio = creation_data.audio_resource_pre_allocation;


                
                MANAGER__resources_images resources_image = Controllers.resources.images;

                // OFF 
                    data.button_OFF_frame.image_ref = resources_image.Get_image_reference( context, main_folder, data.button_OFF_frame.path, manager_resources.minimun.image );
                    data.button_OFF_frame.image_ref.image.name = "button_OFF";
                    data.button_OFF_frame.color = TOOL__UI_button_change_colors.Guarantee_color(  data.button_OFF_frame.color, Cores.grey_90 );
                    data.button_OFF_text_color = TOOL__UI_button_change_colors.Guarantee_color(  data.button_OFF_text_color, Cores.black );

                // ON
                    data.button_ON_frame.image_ref = resources_image.Get_image_reference( context, main_folder, data.button_ON_frame.path, manager_resources.minimun.image  );
                    data.button_ON_frame.image_ref.image.name = "button_ON";
                    data.button_ON_frame.color = TOOL__UI_button_change_colors.Guarantee_color(  data.button_ON_frame.color, Cores.white );
                    data.button_ON_text_color = TOOL__UI_button_change_colors.Guarantee_color(  data.button_ON_text_color, Cores.black );


                // // --- DEFINE
                // TOOL__UI_button_DEFINER_SIMPLE.Define( this );

        }


        protected override void Link_to_UI_game_object_in_structure( GameObject _UI_game_object ){

                // data -> unity data

                try {

                        // ** containers 
                        COLLIDERS_container       =  _UI_game_object.transform.GetChild( 0 ).gameObject;
                        IMAGE_container           =  _UI_game_object.transform.GetChild( 1 ).gameObject;
                        TRANSITION_container      =  _UI_game_object.transform.GetChild( 2 ).gameObject;

                        
                        // ** colliders
                        ON_collider_game_object   =  COLLIDERS_container.transform.GetChild( 0 ).gameObject;
                        ON_collider   =  ON_collider_game_object.GetComponent<PolygonCollider2D>();
                        
                        OFF_collider_game_object  =  COLLIDERS_container.transform.GetChild( 1 ).gameObject;
                        OFF_collider   =  OFF_collider_game_object.GetComponent<PolygonCollider2D>();


                        // ** IMAGE
                        IMAGE_body.game_object = IMAGE_container.transform.GetChild( 0 ).gameObject;
                        IMAGE_body.sprite_render       = IMAGE_body.game_object.GetComponent<SpriteRenderer>();


                        IMAGE_text.game_object    = IMAGE_container.transform.GetChild( 1 ).gameObject;

                        IMAGE_text.tmp_text       = IMAGE_text.game_object.GetComponent<TMP_Text>();

                        // check
                        IMAGE_text.tmp_text.text = IMAGE_text.tmp_text.text;

                        

                        // ** TRANSITION
                        TRANSITION_body.game_object = TRANSITION_container.transform.GetChild( 0 ).gameObject;
                        TRANSITION_body.sprite_render       = TRANSITION_body.game_object.GetComponent<SpriteRenderer>();

                        TRANSITION_text.game_object = TRANSITION_container.transform.GetChild( 1 ).gameObject;
                        TRANSITION_text.tmp_text    = TRANSITION_text.game_object.GetComponent<TMP_Text>();

                    }
                    catch( Exception e )
                    {
                        Console.LogError( $"Could not link to the game object for the button { name }. <Color=lightBlue>PROBABLY THE PREFAB IS NOT RIGHT</Color>" );
                        CONTROLLER__errors.Throw( e.Message );

                    }
                        

        }

        protected override void Delete_abs(){

                manager_resources.Delete();
                body.self_container.SetActive( false );

        }


}
