using UnityEngine;

public static class EXAMPLE_UI_text_container {


        public static UI_text_container Construct( string _path_in_structure, string _name = "Example UI text" ){


                UI_text_container text_container = UI_text_container.Get_text_container( _name );
                
                ref DATA_CREATION__UI_text_container data = ref text_container.creation_data;

                // ** put date

                data.initial_text = "pera";
                data.font_color = Color.green;
                
                                
                return text_container;

        }

}


