

public class DEFAULT_APPLICATOR__UI_text_container_SIMPLE {

        public static void Apply_default( UI_text_container_SIMPLE _text_container ){


                    ref DATA_CREATION__UI_text_container_SIMPLE creatio_data = ref _text_container.creation_data;
            
                    _text_container.type = Type_UI_text_container.simple;

                    creatio_data.tipo_texto = Type_writing_construction.instant;

                    creatio_data.characters_per_frame = 1;


                    creatio_data.tipo_texto = Type_writing_construction.instant;


                    creatio_data.context = Resource_context.Devices;
                    creatio_data.main_folder = "";

                    


        }

}
