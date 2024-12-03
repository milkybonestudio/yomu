

public static class TOOL__UI_text_container_APPLY_DEFAULT {


        public static UI_text_container Apply( UI_text_container _text_container ){


                // ** put data

                _text_container.data.tipo_texto = Type_writing_construction.instant;

                _text_container.data.speed = 5f;
                _text_container.data.base_speed = 1;
                _text_container.data.speed_multiplier = 1;
                _text_container.data.characters_multiplier = 1;    
                
                return _text_container;
                

        }


}