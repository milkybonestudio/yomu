

public enum UI_component_type_method_activation {

    not_give,

        pass = 0b_0000_0000__0000_0000__0000_0000__0000_0001,

        unique  = 0b_0000_0000__0000_0000__0000_0000__0000_0010,  // ** botao_TROCAR_IMAGEM_LOGIN
        specific = 0b_0000_0000__0000_0000__0000_0000__0000_0100, // ** botao
        generic = 0b_0000_0000__0000_0000__0000_0000__0000_1000, //  ** UI 
        all = ( unique | specific | generic ), 
    END

}
