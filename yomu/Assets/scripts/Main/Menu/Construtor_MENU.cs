using System;
using UnityEngine;
using UnityEngine.UI;

public static class Construtor_MENU {

        
        public static Menu Construir( Dados_menu _dados_menu ){


            Menu menu = new Menu();
            
            menu.menu_background = _dados_menu.tipo_menu_background;


            // --- COLCOAR PREFAB


            GameObject canvas = GameObject.Find("Tela/Canvas"); 

            // --- PEGA MENU
            string nome_prefab = Paths_system.path_folder__prefabs  + "/Menu/" +  ( _dados_menu.tipo_menu_background ).ToString() + "_prefab";
            GameObject menu_prefab = Resources.Load<GameObject>( nome_prefab );

            menu_prefab.transform.SetParent( canvas.transform, false );

            
          
            // --- SETA INPUT
            // menu.controlador_dados = Controlador_dados.Pegar_instancia();
            // Controlador_input.ativar_movimentacao_mouse = true;
            // Controlador_cursor.Pegar_instancia().Mudar_cursor( Cor_cursor.off );
            // Controlador_input.tipo_teclado = Tipo_teclado.plataforma; // ???


            // --- CONSTRUTORES ENDIVIDUAIS
            menu.novo_jogo_menu = new Novo_jogo_menu();
            menu.galeria_menu = new Galeria_menu();
            menu.saves_menu = new Saves_menu();
            menu.configuracoes_menu = new Configuracoes_menu();
            menu.personagens_menu = new Personagens_menu();

            #if UNITY_EDITOR


                    // --- COLOCAR IMAGENS 

                    // --- BACKGROUNDS

                    Sprite[] sprites_backgrounds = Gerenciador_imagens_MENU.sprites_background;
                    string[] sprites_backgrounds_nomes = Gerenciador_imagens_MENU.sprites_backgrounds_nomes;

                    for( int background_id = 0 ; background_id < sprites_backgrounds.Length  ; background_id++ ){


                            GameObject game_object = GameObject.Find(  $"MENU__BACKGROUND__{ sprites_backgrounds_nomes[ background_id ] }" );
                            Image image = game_object.GetComponent<Image>();
                            image.sprite = sprites_backgrounds[ background_id ];
                            continue;

                    }


                    // --- INTERATIVOS

                    Sprite[] sprites_interativos = Gerenciador_imagens_MENU.sprites_interativos;
                    string[] sprites_interativos_nomes = Gerenciador_imagens_MENU.sprites_interativos_nomes;

                    for( int interativo_id = 0 ; interativo_id < sprites_backgrounds.Length  ; interativo_id++ ){


                            GameObject game_object = GameObject.Find(  $"MENU__INTERATIVO__{ sprites_interativos_nomes[ interativo_id ] }" );
                            Image image = game_object.GetComponent<Image>();
                            image.sprite = sprites_interativos[ interativo_id ];
                            continue;

                    }


                    // --- OBJETOS

                    Sprite[] sprites_objetos = Gerenciador_imagens_MENU.sprites_objetos;
                    string[] sprites_objetos_nomes = Gerenciador_imagens_MENU.sprites_objetos_nomes;

                    for( int objeto_id = 0 ; objeto_id < sprites_backgrounds.Length  ; objeto_id++ ){


                            GameObject game_object = GameObject.Find(  $"MENU__OBJETO__{ sprites_interativos_nomes[ objeto_id ] }" );
                            Image image = game_object.GetComponent<Image>();

                            if( sprites_interativos[ objeto_id ] == null )
                                {
                                    // --- NAO PODE MOSTRAR
                                    image.color = Color.clear;
                                }
                                else
                                {
                                    // --- TEM QUE MOSTRAR
                                    image.sprite = sprites_interativos[ objeto_id ];
                                    image.color = Color.white;
                                }


                            continue;

                    }






            #endif







            // // --- CONSTRUTORES DADOS

            // Menu_bloco[] blocos = ( Menu_bloco[] ) System.Enum.GetValues( typeof( Menu_bloco ) ) ;
            // int numero_de_blocos = blocos.Length;

            // // --- PEGAR MENU_OBJECTS
            // Interativo_menu[][] blocos_interativos_menu = new Interativo_menu[ numero_de_blocos ][];

            // blocos_interativos_menu[ ( int ) Menu_bloco.personagens ] = menu.personagens_menu.personagens_arr;
            // blocos_interativos_menu[ ( int ) Menu_bloco.galeria ] = menu.galeria_menu.galeria_arr;
            // blocos_interativos_menu[ ( int ) Menu_bloco.novo_jogo ] = menu.novo_jogo_menu.novo_jogo_arr;
            // blocos_interativos_menu[ ( int ) Menu_bloco.saves ] = menu.saves_menu.saves_arr;
            // blocos_interativos_menu[ ( int ) Menu_bloco.configuracoes ] = menu.configuracoes_menu.configuracoes_arr;


            // // --- PEGAR VERIFICADORES
            // Action[] blocos_verificadores = new Action[ numero_de_blocos ];

            // blocos_verificadores[ ( int ) Menu_bloco.personagens ] = null;
            // blocos_verificadores[ ( int ) Menu_bloco.galeria ] = menu.galeria_menu.Verificar_galeria;
            // blocos_verificadores[ ( int ) Menu_bloco.novo_jogo ] = null;
            // blocos_verificadores[ ( int ) Menu_bloco.saves ] = menu.saves_menu.Verificar_saves;
            // blocos_verificadores[ ( int ) Menu_bloco.configuracoes ] = null;

            
            
            // // --- CONSTRUIR TELA
            // // *** Constroi backgrounds

            // menu.controlador_tela_menu = Construtor_controlador_tela_menu.Construir( _dados_menu );


            // // --- CRIA INTERATIVOS MENU

            // for(  int bloco_id = 1; bloco_id < blocos.Length ; bloco_id++ ){


            //         Menu_bloco bloco = ( Menu_bloco ) bloco_id;

            //         string bloco_nome = bloco.ToString();


            //         int posicao_x_bloco_int = _dados_menu.posicoes_blocos[ ( bloco_id * 2 ) + 0 ];
            //         int posicao_y_bloco_int = _dados_menu.posicoes_blocos[ ( bloco_id * 2 ) + 1 ];

            //         float posicao_x_bloco =  Convert.ToSingle( posicao_x_bloco_int );
            //         float posicao_y_bloco =  Convert.ToSingle( posicao_y_bloco_int );
                    


            //         GameObject game_object_bloco  = new GameObject( $"{ bloco_nome }_container" );
            //         game_object_bloco.transform.SetParent(  menu.controlador_tela_menu.container_blocos_menu.transform, false );
            //         game_object_bloco.transform.localPosition = new Vector3( posicao_x_bloco, posicao_y_bloco, 0f );


            //         menu.controlador_tela_menu.containers_blocos_especificos[ bloco_id ] = game_object_bloco;


            //         int[] ids = _dados_menu.interativos_menu_imagens_por_bloco[ bloco_id ];
            //         int[] posicoes_interativos_menu = _dados_menu.posicoes_interativos_menu_por_bloco[ bloco_id ];

            //         Interativo_menu[] interativos_menu_do_bloco = blocos_interativos_menu[ bloco_id ];

            //         for( int index = 0 ; index < ids.Length ; index++ ){


            //                 int id = ids[ index ];
            //                 float posicao_x = Convert.ToSingle( posicoes_interativos_menu[ ( index * 2  ) + 0 ] );
            //                 float posicao_y = Convert.ToSingle( posicoes_interativos_menu[ ( index * 2  ) + 1 ] );

            //                 Sprite sprite = Gerenciador_imagens_MENU.Pegar_sprite_interativo( id );

            //                 interativos_menu_do_bloco[ index ]  = new Interativo_menu       ( 
            //                                                                                     $"Personagem_interativop_menu__{ id }",
            //                                                                                     menu.controlador_tela_menu.containers_blocos_especificos[ bloco_id ],
            //                                                                                     sprite,
            //                                                                                     posicao_x,
            //                                                                                     posicao_y
            //                                                                                 );


            //                 continue;

            //         }

            //         Action Verificador =  blocos_verificadores[ bloco_id ];
            //         if( Verificador != null )
            //             { Verificador(); }
                    

            //         continue;


            // }




            // // --- CRIAR OBJETOS ESTATICOS

            //     // --- CRIA SLOTS OBJETOS ESTATICOS

            //     GameObject[] objetos_estaticos_game_objects = new GameObject[ _dados_menu.objetos_estaticos_ids.Length ];
            //     menu.controlador_tela_menu.canvas_individuais_menu_objetos_estaticos = objetos_estaticos_game_objects;

            //     Image[] objetos_estaticos_images = new Image[ _dados_menu.objetos_estaticos_ids.Length ];
            //     menu.controlador_tela_menu.canvas_individuais_menu_imagens_objetos_estaticos = objetos_estaticos_images;

            //     RectTransform[] objetos_estaticos_rects = new RectTransform[ _dados_menu.objetos_estaticos_ids.Length ];
            //     menu.controlador_tela_menu.canvas_individuais_menu_rects_objetos_estaticos = objetos_estaticos_rects;

            

            //     int[] objetos_estaticos_ids =  _dados_menu.objetos_estaticos_ids;
            //     int[] posicoes = _dados_menu.objetos_estaticos_posicoes;


            //     for( int objeto_index = 0 ; objeto_index < objetos_estaticos_ids.Length ; objeto_index++ ){

            //             int id = objetos_estaticos_ids[ objeto_index ];

            //             // --- PEGA POSICOES
            //             int posicao_x_objeto_estatico_int = posicoes[ ( objeto_index * 2 ) + 0 ];
            //             int posicao_y_objeto_estatico_int = posicoes[ ( objeto_index * 2 ) + 1 ];

            //             float posicao_x_objeto_estatico =  Convert.ToSingle( posicao_x_objeto_estatico_int );
            //             float posicao_y_objeto_estatico =  Convert.ToSingle( posicao_y_objeto_estatico_int );

            //             // --- CRIA OBJETO ESTATICO
            //             objetos_estaticos_game_objects[ objeto_index ] = new GameObject( $"Objeto_estatico_menu_{ objeto_index }" );

            //             objetos_estaticos_images[ objeto_index ]  =  IMAGE.Criar_imagem_somente_com_sprite  (
            //                                                                                                     objetos_estaticos_game_objects[ objeto_index ],
            //                                                                                                     menu.controlador_tela_menu.container_objetos_estaticos,
            //                                                                                                     Gerenciador_imagens_MENU.Pegar_sprite_objeto_estatico( id )
            //                                                                                                 );

            //             // ta meio feio                                          
            //             objetos_estaticos_rects[ objeto_index ] = objetos_estaticos_game_objects[ objeto_index ].GetComponent<RectTransform>();

            //             objetos_estaticos_game_objects[ objeto_index ].transform.localPosition = new Vector3( posicao_x_objeto_estatico, posicao_y_objeto_estatico, 0f );



            //             continue;



            //     }



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



            string audio_path =  "audio/blocos_pequenos/menu/" + CONTROLLER__configurations.Pegar_instancia().music_menu;

        
            CONTROLLER__audio.Pegar_instancia().Start_music( _slot: 1 , audio_path );

            return menu;


    }










}