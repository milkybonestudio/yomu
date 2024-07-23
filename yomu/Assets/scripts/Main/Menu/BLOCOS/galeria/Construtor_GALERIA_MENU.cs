using UnityEngine;


public static class Construtor_GALERIA_MENU {


    public static Galeria_menu Construir( Menu _menu, Dados_menu _dados_menu ){

        Galeria_menu galeria_menu = new Galeria_menu();

            _menu.galeria_menu = galeria_menu;

            // [ id * 2  + 0 ], [ id * 2  + 1 ]  => posicao
            //float[] imagens_estaticas_ativas_ids = _dados.objetos_estaticos_posicoes_por_bloco[ ( int ) Menu_bloco.galeria  ];

            // --- COLOCAR POSICAO BLOCO
            float posicao_x = _dados_menu.posicoes_blocos[ ( ( ( int ) Menu_bloco.saves * 2 ) + 0 ) ];
            float posicao_y = _dados_menu.posicoes_blocos[ ( ( ( int ) Menu_bloco.saves * 2 ) + 1 ) ];

            galeria_menu.galery_container = new GameObject( "Galery_container" );
            galeria_menu.galery_container.transform.SetParent( _menu.controlador_tela_menu.canvas_menu_movel.transform, false );
            galeria_menu.galery_container.transform.localPosition = new Vector3( posicao_x, posicao_y, 0f );

        
            // --- COLOCAR OBJETOS ESTATICOS



            // --- COLOCAR INTERATIVOS MENU
        
            galeria_menu.menu_galery_arr[ 0 ]    =   new Menu_objects_generico( "Menu_galery_1" , galeria_menu.galery_container , "images/menu_images/default_galeria_1_menu" ,  0f  , 140f,    398f , 177f  );
            galeria_menu.menu_galery_arr[ 1 ]    =   new Menu_objects_generico( "Menu_galery_2" , galeria_menu.galery_container , "images/menu_images/default_galeria_2_menu" ,   395f ,  99f ,   282f , 191f );
            galeria_menu.menu_galery_arr[ 2 ]    =   new Menu_objects_generico( "Menu_galery_3" , galeria_menu.galery_container , "images/menu_images/default_galeria_3_menu" ,  104f,  -147f ,  474f , 182f );
            galeria_menu.menu_galery_arr[ 3 ]    =   new Menu_objects_generico( "Menu_galery_4" , galeria_menu.galery_container , "images/menu_images/default_galeria_4_menu" , -352f , -98f , 139f, 297f );
            galeria_menu.menu_galery_arr[ 4 ]    =   new Menu_objects_generico( "Menu_galery_5" , galeria_menu.galery_container , "images/menu_images/default_galeria_5_menu" , -454f , 156f,  225f , 131f );
            galeria_menu.menu_galery_arr[ 5 ]    =   new Menu_objects_generico( "Menu_galery_6" , galeria_menu.galery_container , "images/menu_images/default_galeria_6_menu" , 17f , 395f  ,  305f,  188f );
            
            galeria_menu.menu_galery_botao_proximo  = new Menu_objects_generico( "Menu_galery_botao_proximo" , galeria_menu.galery_container , "images/menu_images/menu_seta_direita" ,  378f  , 339f,    191f , 113f  );
            galeria_menu.menu_galery_arr[ 6 ] = galeria_menu.menu_galery_botao_proximo;

            galeria_menu.menu_galery_botao_anterior  = new Menu_objects_generico( "Menu_galery_botao_anterior" , galeria_menu.galery_container , "images/menu_images/menu_seta_esquerda" ,  -332f  , 336f,    196f , 109f  );
            galeria_menu.menu_galery_arr[ 7 ] = galeria_menu.menu_galery_botao_anterior;


            galeria_menu.Verificar_galeria();





        return galeria_menu;

    }



}