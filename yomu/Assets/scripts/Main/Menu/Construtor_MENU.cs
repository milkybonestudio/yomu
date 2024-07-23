using System;
using UnityEngine;
using UnityEngine.UI;

public static class Construtor_MENU {

        
        public static Menu Construir( Dados_menu _dados_menu ){


            Menu menu = new Menu();

            
            menu.menu_background = _dados_menu.tipo_menu_background;


            //mark
            // ** nao faz sentido ficar aqui
            // Controlador.Pegar_instancia().modo_controlador_atual = Controlador_modo.menu; 


            menu.controlador_dados = Controlador_dados.Pegar_instancia();
            
          
            // --- SETA INPUT
            Controlador_input.ativar_movimentacao_mouse = true;
            Controlador_cursor.Pegar_instancia().Mudar_cursor( Cor_cursor.off );
            Controlador_input.tipo_teclado = Tipo_teclado.plataforma; // ???


            //   |>  bg // infor imagens // objetos static // opcoes

            
            // --- CONSTROI TELA

            menu.controlador_tela_menu = Construtor_controlador_tela_menu.Construir( _dados_menu );

            // --- CRIAR BLOCOS

            menu.novo_jogo_menu = Construtor_NOVO_JOGO_MENU.Construir( menu, _dados_menu );
            menu.galeria_menu = Construtor_GALERIA_MENU.Construir( menu, _dados_menu );
            menu.saves_menu = Construtor_SAVES_MENU.Construir( menu, _dados_menu );
            menu.configuracoes_menu = Construtor_CONFIGURACOES_MENU.Construir( menu, _dados_menu );
            menu.personagens_menu = Construtor_PERSONAGENS_MENU.Construir( menu, _dados_menu );


            // --- CRIAR OBJETOS ESTATICOS

            // --- CRIA SLOTS OBJETOS ESTATICOS


            int numero_objetos_ativos = BOOL.Pegar_numero_de_trues( _dados_menu.objetos_estaticos_liberados );


            menu.controlador_tela_menu.canvas_individuais_menu_objetos_estaticos = new GameObject[ numero_objetos_ativos ];
            menu.controlador_tela_menu.canvas_individuais_menu_imagens_objetos_estaticos = new Image[ numero_objetos_ativos ];
            menu.controlador_tela_menu.canvas_individuais_menu_rects_objetos_estaticos = new RectTransform[ numero_objetos_ativos ];


            for( int objeto_index = 0 ; objeto_index < _dados_menu.objetos_estaticos_liberados.Length ; objeto_index++ ){

                

            }



            //  botoes


            menu.opcoes_container = new GameObject("Opcoes_container");
            Image opcoes_container_image = menu.opcoes_container.AddComponent<Image>();
            RectTransform opcoes_container_rect = menu.opcoes_container.GetComponent<RectTransform>();
            opcoes_container_rect.SetSizeWithCurrentAnchors( RectTransform.Axis.Horizontal, 1920f  );
            opcoes_container_rect.SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, 1080f );



            Sprite sprite_opcoes_container = Resources.Load<Sprite>("images/menu_images/menu_new_opcoes");

            opcoes_container_image.sprite = sprite_opcoes_container;

            if( sprite_opcoes_container == null )
                { throw new ArgumentException("a"); } //???
    
            menu.opcoes_container.transform.SetParent( menu.controlador_tela_menu.canvas_menu.transform, false );
            menu.opcoes_container.transform.localPosition = new Vector3( 0f, 0f, 0f );

            string som_click = "audio/geral_sfx/botoes/click_2";
            
            Sprite[] imagens_personagens = new Sprite[ 2 ];

            imagens_personagens[ 0 ] = Resources.Load<Sprite>("images/menu_images/botao_characters_off");
            imagens_personagens[ 1 ] = Resources.Load<Sprite>("images/menu_images/botao_characters_on");


            menu.botoes[ 0 ] = new Botao(
                
                "Personagens_opcao",

                250f,
                85f,
                -600f,
                -480f,
                menu.opcoes_container.transform,
                () => { menu.controlador_tela_menu.Movimentar_tela( Menu_bloco.personagens ); },
                Tipo_botao.dinamico,
                true, 
                imagens_personagens

            );

            menu.botoes[ 0 ] .Colocar_som_click(som_click);

            Sprite[] imagens_galeria = new Sprite[2];
            imagens_galeria[ 0 ] = Resources.Load<Sprite>("images/menu_images/botao_galeria_off");
            imagens_galeria[ 1]  = Resources.Load<Sprite>("images/menu_images/botao_galeria_on");


            menu.botoes[ 1 ] = new Botao(
                
                "Galeria_opcao",

                250f,
                85f,
                -300f,
                -480f,
                menu.opcoes_container.transform,
                () => { menu.controlador_tela_menu.Movimentar_tela( Menu_bloco.galeria ); },
                Tipo_botao.dinamico,
                true, 
                imagens_galeria

            );

            menu.botoes[ 1 ].Colocar_som_click( som_click );


            Sprite[] imagens_new_game = new Sprite[ 2 ];
            imagens_new_game[ 0 ] = Resources.Load<Sprite>("images/menu_images/botao_new_game_off");
            imagens_new_game[ 1 ] = Resources.Load<Sprite>("images/menu_images/botao_new_game_on");


            menu.botoes[ 2 ] = new Botao(
                
                "new_game_opcao",

                250f,
                85f,
                0f,
                -480f,
                menu.opcoes_container.transform,
                () => { menu.controlador_tela_menu.Movimentar_tela( Menu_bloco.novo_jogo ); },
                Tipo_botao.dinamico,
                true, 
                imagens_new_game

            );

            menu.botoes[ 2 ].Colocar_som_click(som_click);

            Sprite[] imagens_save = new Sprite[2];
            imagens_save[ 0 ] = Resources.Load<Sprite>("images/menu_images/botao_saves_off");
            imagens_save[ 1 ] = Resources.Load<Sprite>("images/menu_images/botao_saves_on");


            menu.botoes[ 3 ] = new Botao(
                
                "save_opcao",

                250f,
                85f,
                300f,
                -480f,
                menu.opcoes_container.transform,
                () => { menu.controlador_tela_menu.Movimentar_tela( Menu_bloco.saves ); },
                Tipo_botao.dinamico,
                true, 
                imagens_save

            );

            menu.botoes[ 3 ].Colocar_som_click(som_click);


            Sprite[] imagens_config = new Sprite[2];
            imagens_config[ 0 ] = Resources.Load<Sprite>("images/menu_images/botao_config_off");
            imagens_config[ 1 ] = Resources.Load<Sprite>("images/menu_images/botao_config_on");


            menu.botoes[ 4 ] = new Botao(
                
                "config_opcao",

                250f,
                85f,
                600f,
                -480f,
                menu.opcoes_container.transform,
                () => { menu.controlador_tela_menu.Movimentar_tela( Menu_bloco.configuracoes ); },
                Tipo_botao.dinamico,
                true, 
                imagens_config

            );

            menu.botoes[ 4 ].Colocar_som_click( som_click );



            string audio_path =  "audio/blocos_pequenos/menu/" + Controlador_configuracoes.Pegar_instancia().music_menu;

        
            Controlador_audio.Pegar_instancia().Start_music( _slot: 1 , audio_path );

            return menu;


    }










}