using UnityEngine;
using UnityEngine.UI;
using TMPro;



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

        // --- SIMPLE

            public Unity_main_components simple_container;
            public Unity_main_components simple_text;
        

        public DATA__UI_text_container data;

        
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









}