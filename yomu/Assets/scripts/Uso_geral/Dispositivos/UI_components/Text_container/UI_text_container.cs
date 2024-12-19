using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System;




public class UI_text_container {

        // op 1 -> text_container tem somente o texto

        /*

                Text_container vai ser um pouco diferente de Button porque button vai dividir a complexidade em construção e updates visuais. 
                Text_container vai ter diferentes funçoes para diferentes tipos

                principais metodos: 

                    -> mostrar texto aos poucos ( 2 modos diferentes )
                    -> append text
                    -> mudar fonte
                    -> mudar cor
                    

                metodos no completo: 
                    -> transicionar textos completos
                    -> multiplos estados [ texto 1 ] ←→ [ texto 2 ] ←→ [ texto 3 ]
                    -> aplicar efeito texto
        
        */

        public static UI_text_container Get_text_container(){ return TOOL__UI_text_container_APPLY_DEFAULT.Apply( new UI_text_container() ); }


        public GameObject game_object;

        public UI_container container;

        
        // --- SIMPLE

            public Unity_main_components simple_text;
        

        public DATA__UI_text_container data;



        // --- UPDATE DATA

        
        public int minRange;
        public int maxRange;   
        public Color32[] vertex_colors;
        public TMP_TextInfo text_info;



        public UI_text_container_writing_state writing_state;

        
        // --- METHODS UI
        public void Define(){

                TOOL__UI_text_container_VERIFICATIONS.verify( this );

                // ** data -> resources 
                switch( data.type ){

                    case Type_UI_text_container.simple: TOOL__UI_text_container_DEFINER_SIMPLE.Define( this ); break;
                    default: CONTROLLER__errors.Throw( $"Can not handle type { data.type }" ); break;

                }

        }


        public void Link_to_game_object( GameObject _game_object ){ 

                if( _game_object == null )
                    { CONTROLLER__errors.Throw( $"Tried to link the text_container <Color=lightBlue>{ data.path_locator }</Color> to the game object, but it was null." ); }

                game_object = _game_object;

                switch( data.type ){

                    case Type_UI_text_container.simple: TOOL__UI_text_container_GETTER_SIMPLE.Link_to_game_object( this, _game_object ); break;
                    default: CONTROLLER__errors.Throw( $"Can not handle type { data.type }" ); break;

                }

        }


        public void Activate_text_container(){

                //** se tem algum texto tem que


        }

        public void Deactivate_text_container(){}




        // --- METHODS FUNCTION



        public void Update(){

            if( writing_state == UI_text_container_writing_state.writing )
                { TOOL__UI_text_container_CHANGE_TEXT.Update_writing( this ); }

        }




        public void Resize( float _width, float _height ){ RECT_TRANSFORM.Resize( simple_text.game_object, _width, _height ); }
        public void Add_dimensions( float _width_to_add, float _height_to_add ){ RECT_TRANSFORM.Add_dimensions( simple_text.game_object, _width_to_add, _height_to_add ); }

        public void Add_dimension_WIDTH( float _width_to_add ){ RECT_TRANSFORM.Add_dimensions( simple_text.game_object, _width_to_add, 0f ); }
        public void Add_dimension_HEIGHT( float _height_to_add ){ RECT_TRANSFORM.Add_dimensions( simple_text.game_object, 0f, _height_to_add ); }




        public void Force_complete(){ TOOL__UI_text_container_CHANGE_TEXT.Force_complete( this ); }

        public void Clean_text(){

                // ** talvez fazer algo como modo de descontrução 
                simple_text.tmp_text.text = "";

        }




        public void Setar_display( Transform _transform_pai, float _x_position = 0f, float _y_position = 0f ){

    
                game_object.transform.SetParent( _transform_pai, false);
                game_object.transform.localPosition = new Vector3(_x_position, _y_position, 0f);
                return;

        }



        public void Change_type_construction(  Type_writing_construction _tipo_construcao  ){

                if( writing_state == UI_text_container_writing_state.writing )
                    { TOOL__UI_text_container_CHANGE_TEXT.Force_complete( this ); }
            
                if( _tipo_construcao == Type_writing_construction.config_default )
                    { _tipo_construcao = CONTROLLER__configurations.Pegar_instancia().tipo_texto; }

                data.tipo_texto = _tipo_construcao;

        }
    
        public void Put_text( string _text, int _tipo_texto, Color _cor_texto ){


                simple_text.tmp_text.color = _cor_texto;


                string pre_text = "";
                string target_text = _text;
                
                switch( _tipo_texto ){
                
                        case 0 : pre_text = "  ";break; // reseta
                        case 1 : pre_text = simple_text.tmp_text.text + " "; break; // mesmo bloco
                        case 2 : pre_text = simple_text.tmp_text.text + "\n  " ;break;   // novo bloco
                    
                }

                TOOL__UI_text_container_CHANGE_TEXT.Build( this, target_text, pre_text );
                return ;

        }



























}