using UnityEngine;

public static class EXAMPLE_UI_text_container {


        public static UI_text_container_SIMPLE Simple( GameObject _text_container ){

                UI_text_container_SIMPLE text_container = UI_text_container_SIMPLE.Get_text_container();
                ref DATA_CREATION__UI_text_container_SIMPLE data = ref text_container.creation_data;

                // ** put date

                data.initial_text = "pera";
                data.font_color = Color.green;

                text_container.Define();
                text_container.Link_to_game_object( _text_container );
                text_container.Activate_text_container();

                
                return text_container;

        }

}


