


using UnityEngine;


public static class Construtor_SAVES_MENU {


    public static Saves_menu Construir( Menu _menu, Dados_menu _dados_menu ){

        Saves_menu saves_menu = new Saves_menu();

            _menu.saves_menu = saves_menu;



            saves_menu.save_container = new GameObject( "Save_container" );
            saves_menu.save_container.transform.SetParent( _menu.controlador_tela_menu.canvas_menu_movel.transform, false );
            saves_menu.save_container.transform.localPosition = new Vector3( 1560f, 0f, 0f );

            
            saves_menu.menu_saves_arr[0] = new Menu_objects_generico( "Menu_save_1",saves_menu.save_container , "images/menu_images/sem_save_image",   -279f , 216f , 287f ,142f);
            saves_menu.menu_save_information_arr[0] = new Save_information("Menu_save_1_info",saves_menu.save_container, -283f,396f);

            saves_menu.menu_saves_arr[1] = new Menu_objects_generico( "Menu_save_2",saves_menu.save_container , "images/menu_images/sem_save_image" ,  -279f , -186f ,  287f ,142f);
            saves_menu.menu_save_information_arr[1] = new Save_information("Menu_save_2_info",saves_menu.save_container, -282f,  -10f);
            
            saves_menu.menu_saves_arr[2] = new Menu_objects_generico( "Menu_save_3", saves_menu.save_container ,"images/menu_images/sem_save_image" , 314f , 215f,287f ,142f);
            saves_menu.menu_save_information_arr[2] = new Save_information("Menu_save_3_info",saves_menu.save_container, 322f,394f);

            saves_menu.menu_saves_arr[3] = new Menu_objects_generico( "Menu_save_4",saves_menu.save_container ,"images/menu_images/sem_save_image" , 315f , -186f , 287f ,142f);
            saves_menu.menu_save_information_arr[3] = new Save_information("Menu_save_4_info",saves_menu.save_container, 311f, -11f);

            saves_menu.Verificar_saves();



        
        return saves_menu;

    }



}