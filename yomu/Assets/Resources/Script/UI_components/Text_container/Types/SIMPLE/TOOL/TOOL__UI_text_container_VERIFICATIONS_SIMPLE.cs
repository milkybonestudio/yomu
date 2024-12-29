


public static class TOOL__UI_text_container_VERIFICATIONS_SIMPLE {


    public static void verify( UI_text_container_SIMPLE _text_container ){

        if( _text_container.type == Type_UI_text_container.not_give )
            { CONTROLLER__errors.Throw( $"text_container { _text_container.name }" ); }

    }

}