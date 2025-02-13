using UnityEngine;


public static class Construtor_CONFIGURACOES_MENU {


    public static Configuracoes_menu Construir( Menu _menu, Dados_menu _dados_menu ){

        Configuracoes_menu configuracoes_menu = new Configuracoes_menu();

            // _menu.configuracoes_menu = configuracoes_menu;

                
            // configuracoes_menu.config = new GameObject("Config");
            // configuracoes_menu.config.transform.SetParent( _menu.controlador_tela_menu.canvas_menu_movel.transform, false);
            // configuracoes_menu.config.transform.localPosition = new Vector3(3120f,0f,0f);


            // string path_prefab = "prefabs/menu/Configurations_container";
            // GameObject prefab_config_container = Resources.Load<GameObject>( path_prefab );

            // configuracoes_menu.configuration_container = GameObject.Instantiate( prefab_config_container ).GetComponent< Configuration_container >();
    
            // configuracoes_menu.configuration_container.game_object.transform.SetParent( configuracoes_menu.config.transform, false );
            // configuracoes_menu.configuration_container.game_object.transform.localPosition = new Vector3( 0f, 100f, 0f );
            
                    
        



        return configuracoes_menu;

    }



}