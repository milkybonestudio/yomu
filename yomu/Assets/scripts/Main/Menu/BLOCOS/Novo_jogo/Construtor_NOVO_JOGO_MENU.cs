using UnityEngine;


public static class Construtor_NOVO_JOGO_MENU {


    public static Novo_jogo_menu Construir( Menu _menu, Dados_menu _dados_menu ){

        Novo_jogo_menu novo_jogo_menu = new Novo_jogo_menu();

            _menu.novo_jogo_menu = novo_jogo_menu;
        
            novo_jogo_menu.novo_jogo_container = new GameObject("novo_jogo_container");
            novo_jogo_menu.novo_jogo_container.transform.SetParent( _menu.controlador_tela_menu.canvas_menu_movel.transform, false );
            novo_jogo_menu.novo_jogo_container.transform.localPosition = new Vector3( 0f, 0f, 0f );

            novo_jogo_menu.novo_jogo = new Menu_objects_generico("New_game", novo_jogo_menu.novo_jogo_container,"images/menu_images/menu_new_quadro_novo_jogo" ,11f,126f, 345f , 358f);
            
            novo_jogo_menu.novo_jogo_arr[ 0 ] = novo_jogo_menu.novo_jogo;



        return novo_jogo_menu;

    }



}