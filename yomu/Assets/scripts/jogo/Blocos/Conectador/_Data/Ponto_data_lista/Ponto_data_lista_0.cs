





public static class Pontos_data_lista_0 {


    public static void Colocar_interativos(  Ponto_data[] pontos_data_lista ){


        int index = 0;




        index =  ( int ) Ponto_nome.UP_quarto_nara;
pontos_data_lista[ index ].folder_path = "";
pontos_data_lista[ index ].background_default_name = "/teste";
pontos_data_lista[ index ].tipo_get_background = Tipo_get_ponto_data.dia_E_noite;
pontos_data_lista[ index ].tipo_get_interativos_default = Tipo_get_ponto_data.dia_E_noite;
pontos_data_lista[ index ].interativos_default_2d = new Interativo_nome[][]{
    
    new Interativo_nome[] {} , // 0,1,2
    new Interativo_nome[] {} , // 3,4
    
};
//----------------------------




index =  ( int ) Ponto_nome.UP_quarto_nara;

pontos_data_lista[ index ].folder_path = "background/catedral/nara_room/";
pontos_data_lista[ index ].background_default_name = "up";
pontos_data_lista[ index ].tipo_get_background = Tipo_get_ponto_data.dia_E_noite;
pontos_data_lista[ index ].tipo_get_interativos_default = Tipo_get_ponto_data.nao_altera;
pontos_data_lista[ index ].interativos_default_2d = new Interativo_nome[][]{
    
    new Interativo_nome[] {  

        Interativo_nome.MESA_up_quarto_nara,
        Interativo_nome.BAU_up_quarto_nara,
        Interativo_nome.BURACO_up_quarto_nara,
        Interativo_nome.JANELA_up_quarto_nara,
        Interativo_nome.ESPELHO_up_quarto_nara,
        Interativo_nome.PORTA_up_quarto_nara,
        Interativo_nome.CAMA_up_quarto_nara,
        Interativo_nome.CLOSET_up_quarto_nara

    } 
    
};

//----------------------------


        index =  ( int ) Ponto_nome.FRONT_quarto_nara;

pontos_data_lista[ index ].folder_path = "background/catedral/nara_room/";
pontos_data_lista[ index ].background_default_name = "front";
pontos_data_lista[ index ].tipo_get_background = Tipo_get_ponto_data.dia_E_noite;
pontos_data_lista[ index ].tipo_get_interativos_default = Tipo_get_ponto_data.nao_altera;
pontos_data_lista[ index ].interativos_default_2d = new Interativo_nome[][]{

    
    new Interativo_nome[] { 

        Interativo_nome.MESA_front_quarto_nara,
        Interativo_nome.ESPELHO_front_quarto_nara,
        Interativo_nome.CORREDOR_front_quarto_nara 

    }
    
};
//----------------------------




        index =  ( int ) Ponto_nome.BACK_quarto_nara;

pontos_data_lista[ index ].folder_path = "background/catedral/nara_room/";
pontos_data_lista[ index ].background_default_name = "back";
pontos_data_lista[ index ].tipo_get_background = Tipo_get_ponto_data.dia_E_noite;
pontos_data_lista[ index ].tipo_get_interativos_default = Tipo_get_ponto_data.nao_altera;
pontos_data_lista[ index ].interativos_default_2d = new Interativo_nome[][]{
    
    new Interativo_nome[] {
        Interativo_nome.BURACO_back_quarto_nara,
        Interativo_nome.CAMA_back_quarto_nara,
    } , // 0,1,2
    
    
};
//----------------------------



        index =  ( int ) Ponto_nome.CORREDOR_quarto_nara;

pontos_data_lista[ index ].folder_path = "background/catedral/nara_room/";
pontos_data_lista[ index ].background_default_name = "corredor";
pontos_data_lista[ index ].tipo_get_background = Tipo_get_ponto_data.dia_E_noite;
pontos_data_lista[ index ].tipo_get_interativos_default = Tipo_get_ponto_data.nao_altera;
pontos_data_lista[ index ].interativos_default_2d = new Interativo_nome[][]{
    
    new Interativo_nome[] {
        
        Interativo_nome.MACANETA_corredor_quarto_nara,
        
    } 
    
    
};




        index =  ( int ) Ponto_nome.MESA_quarto_nara;

pontos_data_lista[ index ].folder_path = "background/catedral/nara_room/";
pontos_data_lista[ index ].background_default_name = "mesa";
pontos_data_lista[ index ].tipo_get_background = Tipo_get_ponto_data.dia_E_noite;
pontos_data_lista[ index ].tipo_get_interativos_default = Tipo_get_ponto_data.nao_altera;

pontos_data_lista[ index ].interativos_default_2d = new Interativo_nome[][]{

    new Interativo_nome[]{  

            Interativo_nome.LIVRO_1_mesa_quarto_nara,
            Interativo_nome.LIVRO_2_mesa_quarto_nara,
            Interativo_nome.LIVRO_3_mesa_quarto_nara,
            Interativo_nome.LIVRO_4_mesa_quarto_nara,
            Interativo_nome.LIVRO_5_mesa_quarto_nara,
            Interativo_nome.LIVRO_6_mesa_quarto_nara,
            Interativo_nome.CAIXA_mesa_quarto_nara,
            Interativo_nome.CARTAS_mesa_quarto_nara,
            Interativo_nome.TINTA_mesa_quarto_nara,

     }, 
    
};
//----------------------------











        index =  ( int ) Ponto_nome.CORREDOR_1;

pontos_data_lista[ index ].folder_path = "background/catedral/public_places/";
pontos_data_lista[ index ].background_default_name = "corredor_1";
pontos_data_lista[ index ].tipo_get_background = Tipo_get_ponto_data.nao_altera;
pontos_data_lista[ index ].tipo_get_interativos_default = Tipo_get_ponto_data.nao_altera;

pontos_data_lista[ index ].interativos_default_2d = new Interativo_nome[][]{

    new Interativo_nome[]{  

            Interativo_nome.LILY_corredor_1
        

     }, 
    
};
//----------------------------







    }

}
