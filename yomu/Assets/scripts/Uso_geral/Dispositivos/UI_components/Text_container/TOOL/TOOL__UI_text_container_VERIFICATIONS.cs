


public static class TOOL__UI_text_container_VERIFICATIONS {


    public static void verify( UI_text_container _text_container ){


        if( _text_container.data.type == Type_UI_text_container.not_give )
            { CONTROLLER__errors.Throw( $"text_container { _text_container.data.path_locator }" ); }

    }

}