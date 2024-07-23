using UnityEngine;


public static class Construtor_PERSONAGENS_MENU {


    public static Personagens_menu Construir( Menu _menu, Dados_menu _dados_menu ){

        Personagens_menu personagens_menu = new Personagens_menu();

            _menu.personagens_menu = personagens_menu;
        

            personagens_menu.personagens_container = new GameObject( "Personagens_container" );
            personagens_menu.personagens_container.transform.SetParent( _menu.controlador_tela_menu.canvas_menu_movel.transform, false );
            personagens_menu.personagens_container.transform.localPosition = new Vector3( -3120f, 0f, 0f );


            personagens_menu.menu_personagens_arr[ 0 ]  = new Menu_objects_generico( "Menu_personagem_1", personagens_menu.personagens_container ,"images/menu_images/default_personagem_menu" , -369f , 173f , 172f , 146f );
            personagens_menu.menu_personagens_arr[ 1 ]  = new Menu_objects_generico( "Menu_personagem_2", personagens_menu.personagens_container ,"images/menu_images/default_personagem_menu" , -369f , -86f, 172f , 146f);
            personagens_menu.menu_personagens_arr[ 2 ]  = new Menu_objects_generico( "Menu_personagem_3", personagens_menu.personagens_container ,"images/menu_images/default_personagem_menu" , -4f , 268f, 172f , 146f);
            personagens_menu.menu_personagens_arr[ 3 ]  = new Menu_objects_generico( "Menu_personagem_4", personagens_menu.personagens_container ,"images/menu_images/default_personagem_menu" , -4f , 9f, 172f , 146f);
            personagens_menu.menu_personagens_arr[ 4 ]  = new Menu_objects_generico( "Menu_personagem_5", personagens_menu.personagens_container ,"images/menu_images/default_personagem_menu" , 343f , 173f, 172f , 146f);
            personagens_menu.menu_personagens_arr[ 5 ]  = new Menu_objects_generico( "Menu_personagem_6", personagens_menu.personagens_container ,"images/menu_images/default_personagem_menu" , 343f , -86f, 172f , 146f);


            personagens_menu.menu_personagens_botao_proximo  = new Menu_objects_generico( "Menu_personagens_botao_proximo" , personagens_menu.personagens_container , "images/menu_images/menu_seta_direita" ,  342f  , 341f,    191f , 113f  );
            personagens_menu.menu_personagens_arr[ 6 ] = personagens_menu.menu_personagens_botao_proximo;

            personagens_menu.menu_personagens_botao_anterior  = new Menu_objects_generico( "Menu_personagens_botao_anterior" , personagens_menu.personagens_container , "images/menu_images/menu_seta_esquerda" ,  -371f  , 339f,    196f , 109f  );
            personagens_menu.menu_personagens_arr[ 7 ] = personagens_menu.menu_personagens_botao_anterior;

            


        return personagens_menu;

    }



}