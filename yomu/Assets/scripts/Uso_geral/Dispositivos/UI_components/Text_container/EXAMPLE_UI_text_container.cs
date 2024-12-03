using UnityEngine;

public static class EXAMPLE_UI_text_container {


        public static UI_text_container Simple( GameObject _text_container ){

                UI_text_container text_container = UI_text_container.Get_text_container();
                ref DATA__UI_text_container data = ref text_container.data;

                // ** put date

                        data.type = Type_UI_text_container.simple;


                text_container.Define();
                text_container.Link_to_game_object( _text_container );
                text_container.Activate_text_container();

                
                return text_container;

        }

}


