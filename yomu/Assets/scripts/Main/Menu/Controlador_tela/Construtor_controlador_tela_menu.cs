using UnityEngine;
using UnityEngine.UI;

public static class Construtor_controlador_tela_menu {


    public static Controlador_tela_menu Construir( Dados_menu _dados_menu ){


        Controlador_tela_menu controlador_tela_menu = new Controlador_tela_menu();


            // *** posico que vai ser colocado os objetos estaticos e objetos de bloco
            // _dados menu tem os dados para criar completamente 

            
            //controlador_tela_menu.posicoes_blocos = _dados_menu.posicoes_blocos;


            //   canvas 

            // ** VER DEPOIS
            //string path = "images/menu_images/" + _dados_menu.menu_background; 



            Sprite menu_background = null; //Resources.Load<Sprite>( path );
            

            GameObject canvas = GameObject.Find("Tela/Canvas");


            // controlador_tela_menu.canvas_menu = new GameObject("Menu");
            // controlador_tela_menu.canvas_menu.transform.SetParent( canvas.transform, false);
            // controlador_tela_menu.canvas_menu_movel = new GameObject("Canvas_menu_movel");
            // controlador_tela_menu.canvas_menu_movel.transform.SetParent( controlador_tela_menu.canvas_menu.transform, false );


            // int numero_blocos = ( System.Enum.GetValues( typeof( Menu_bloco ) ) ).Length;


            // controlador_tela_menu.container_backgrounds = new GameObject( "container_backgrounds" );
            // controlador_tela_menu.container_backgrounds.transform.SetParent( controlador_tela_menu.canvas_menu_movel.transform, false );

            // controlador_tela_menu.container_blocos_menu = new GameObject( "container_blocos_menu" );
            // controlador_tela_menu.container_blocos_menu.transform.SetParent( controlador_tela_menu.canvas_menu_movel.transform, false );

            // controlador_tela_menu.container_objetos_estaticos = new GameObject( "container_objetos_estaticos" );
            // controlador_tela_menu.container_objetos_estaticos.transform.SetParent( controlador_tela_menu.canvas_menu_movel.transform, false );


            // controlador_tela_menu.containers_blocos_especificos = new GameObject[ numero_blocos ];




            // // --- CRIA SLOTS BACKGROUNDS
            // controlador_tela_menu.canvas_individuais_menu_backgrounds = new GameObject[ ( _dados_menu.background_imagens_ids_E_posicoes.Length / 3 ) ];
            // controlador_tela_menu.canvas_individuais_menu_imagens_backgrounds = new Image[ ( _dados_menu.background_imagens_ids_E_posicoes.Length / 3 ) ];
            // controlador_tela_menu.canvas_individuais_menu_rects_backgrounds = new RectTransform[ ( _dados_menu.background_imagens_ids_E_posicoes.Length / 3 ) ];

            // // --- CRIAR SLOTS BLOCOS


            // controlador_tela_menu.containers_blocos_especificos = new GameObject[ numero_blocos ];

            // controlador_tela_menu.canvas_individuais_interativos_menu_POR_BLOCO = new GameObject[ numero_blocos ][];
            // controlador_tela_menu.canvas_individuais_imagens_interativos_menu_POR_BLOCO = new Image[ numero_blocos ][];
            // controlador_tela_menu.canvas_individuais_rects_interativos_menu_POR_BLOCO = new RectTransform[ numero_blocos ][];





            // // --- COLOCAR IMAGENS 

            // for( int index = 0 ; index  < _dados_menu.background_imagens_ids_E_posicoes.Length ; index += 3  ){


            //         int imagem_id = _dados_menu.background_imagens_ids_E_posicoes[ index + 0 ];
            //         int posicao_x = _dados_menu.background_imagens_ids_E_posicoes[ index + 1 ];
            //         int posicao_y = _dados_menu.background_imagens_ids_E_posicoes[ index + 2 ];


            //         Sprite sprite_imagem_atual = Gerenciador_imagens_MENU.Pegar_sprite_background( imagem_id );


            //         // --- CRIA SLOTS
            //         GameObject game_object = new GameObject( $"Background_id_{ imagem_id }" );
            //         Image image = game_object.AddComponent<Image>();
            //         RectTransform rect = image.GetComponent<RectTransform>();


            //         // --- COLOCA DADOS NOS SLOTS
            //         controlador_tela_menu.canvas_individuais_menu_backgrounds[ imagem_id ] = game_object; 
            //         controlador_tela_menu.canvas_individuais_menu_imagens_backgrounds[ imagem_id ] =  image;
            //         controlador_tela_menu.canvas_individuais_menu_rects_backgrounds[ imagem_id ] =  rect;


            //         // --- ARRUMA OS DADOS

            //         game_object.transform.SetParent(  controlador_tela_menu.container_backgrounds.transform ,false );

            //         game_object.transform.localPosition = new Vector3( posicao_x, posicao_y , 0f );

            //         image.sprite = sprite_imagem_atual;

            //         rect.SetSizeWithCurrentAnchors(   RectTransform.Axis.Horizontal  , sprite_imagem_atual.rect.width );
            //         rect.SetSizeWithCurrentAnchors(   RectTransform.Axis.Vertical  , sprite_imagem_atual.rect.height );


            //         // --- 
            //         controlador_tela_menu.canvas_menu_image = controlador_tela_menu.canvas_menu_movel.AddComponent<Image>();
            //         controlador_tela_menu.canvas_menu_rect = controlador_tela_menu.canvas_menu_movel.GetComponent<RectTransform>();
            //         controlador_tela_menu.canvas_menu_rect.SetSizeWithCurrentAnchors(   RectTransform.Axis.Horizontal  , 8160f);
            //         controlador_tela_menu.canvas_menu_rect.SetSizeWithCurrentAnchors(   RectTransform.Axis.Vertical  , 1080f);
                    
            //         controlador_tela_menu.canvas_menu_image.sprite = menu_background;

            //         continue;                

            // }



    




        return controlador_tela_menu;

    }




}
