using System;
using UnityEngine;


public static class Paths_sistema {








        // --- UNICOS JOGO

        public static string path_folder__dados_usuario;

        public static string path_arquivo_resumo_persona_usuario;
        public static string path_arquivo_configuracoes;
        public static string path_arquivo_dados_menu_E_login_dados;
        

        public static string path_arquivo__stack_1;
        public static string path_arquivo__stack_2;




        // --- DADOS ESTATICOS


                // --- DADOS PARA COPIAR EM CADA SAVE 


                        public static string path_folder_save_default;


                        // --- ENTIDADES DADOS
                        public static string path_folder__entidades_para_copiar_novo_save_personagens;
                        public static string path_folder__entidades_para_copiar_novo_save_cidades;
                        public static string path_folder__entidades_para_copiar_novo_save_plots;
                        public static string path_folder__entidades_para_copiar_novo_save_mobs;
                        public static string path_folder__entidades_para_copiar_novo_save_bosses;
                        public static string path_folder__entidades_para_copiar_novo_save_reinos;




                // --- DADOS PARA LER
                // ** so na build

                // ** tipos: 
                // => logica => oque a parada eh. minigames podem ter variacoes de fases, numero de inimigos, como inimigos funcionam, ids de imagens, etc
                // => imagens 
                // => textos
                // => audio ( ? )

                // --- LOCALIZADORES

                // *** localizadores so vao ser usados nos parciais 
                public static string path_folder_localizadores;


                // --- PONTOS

                        // ** textos
                        public static string path_arquivo__localizador__backgrounds_imagens;
                        public static string path_arquivo__dados_estaticos__uso_parcial__pontos_background_imagens;


                // --- INTERATIVOS

                        // ** logica
                        public static string path_arquivo__localizador__interativos_logica;
                        public static string path_arquivo__dados_estaticos__uso_parcial__interativos_logica;

                        // ** imagens
                        public static string path_arquivo__localizador__interativos_imagens;
                        public static string path_arquivo__dados_estaticos__uso_parcial__interativos_imagens;

                        // ** textos
                        public static string path_arquivo__localizador__interativos_textos; // [ pointer_lingua ][ interativo_texto_id ] => numero 
                        public static string path_arquivo__dados_estaticos__uso_parcial__interativos_textos;


                // --- CARTAS

                        // ** logica
                        public static string path_arquivo__localizador__cartas_logica;
                        public static string path_arquivo__dados_estaticos__uso_parcial__cartas_logica;

                        // ** imagens
                        public static string path_arquivo__localizador__cartas_imagens;
                        public static string path_arquivo__dados_estaticos__uso_parcial__cartas_imagens;

                        // ** textos
                        public static string path_arquivo__localizador__cartas_textos; // [ pointer_lingua ][ interativo_texto_id ] => numero 
                        public static string path_arquivo__dados_estaticos__uso_parcial__cartas_textos;


                // --- ITENS

                        // ** logica
                        public static string path_arquivo__localizador__itens_logica;
                        public static string path_arquivo__dados_estaticos__uso_parcial__itens_logica;

                        // ** imagens
                        public static string path_arquivo__localizador__itens_imagens;
                        public static string path_arquivo__dados_estaticos__uso_parcial__itens_imagens;

                        // ** textos
                        public static string path_arquivo__localizador__itens_textos; // [ pointer_lingua ][ interativo_texto_id ] => numero 
                        public static string path_arquivo__dados_estaticos__uso_parcial__itens_textos;


                // --- MINIGAMES


                        // ** logica
                        public static string path_arquivo__localizador__minigames_logica;
                        public static string path_arquivo__dados_estaticos__uso_parcial__minigames_logica;

                        // ** imagens
                        public static string path_arquivo__localizador__minigames_imagens;
                        public static string path_arquivo__dados_estaticos__uso_parcial__minigames_imagens;

                        // ** textos
                        public static string path_arquivo__localizador__minigames_textos; // [ pointer_lingua ][ interativo_texto_id ] => numero 
                        public static string path_arquivo__dados_estaticos__uso_parcial__minigames_textos;





                
                
                
        public static string path_folder__arquivo_dados_estaticos;



        public static string path_folder__dlls;

        // --- DLLS

                // --- HANDLER TROCA BLOCOS 

                        public static string path_arquivo__dll__handler_finalizar_VISUAL_NOVEL__E__CONECTOR;
                        public static string path_arquivo__dll__handler_finalizar_UTILIDADES__E__CONECTOR;
                        public static string path_arquivo__dll__handler_finalizar_CARTAS__E__CONECTOR;
                        public static string path_arquivo__dll__handler_finalizar_CONVERSAS__E__CONECTOR;
                        public static string path_arquivo__dll__handler_finalizar_MINIGAME__E__CONECTOR;
                        public static string path_arquivo__dll__handler_finalizar_MINIGAMES__E__VISUAL_NOVEL;
                        public static string path_arquivo__dll__handler_finalizar_MINIGAMES__E__CONVERSAS;
                        public static string path_arquivo__dll__handler_finalizar_MINIGAMES__E__CARTAS;
                        public static string path_arquivo__dll__handler_finalizar_MINIGAMES__E__UTILIDADES;
                        public static string path_arquivo__dll__handler_finalizar_VISUAL_NOVEL__E__CONVERSAS;
                        public static string path_arquivo__dll__handler_finalizar_VISUAL_NOVEL__E__CARTAS;
                        public static string path_arquivo__dll__handler_finalizar_VISUAL_NOVEL__E__UTILIDADES;
                        public static string path_arquivo__dll__handler_finalizar_CARTAS__E__CONVERSAS;
                        public static string path_arquivo__dll__handler_finalizar_CARTAS__E__UTILIDADES;
                        public static string path_arquivo__dll__handler_finalizar_CONVERSAS__E__UTILIDADES;

                




        // --- PERSONAGEM

        public static string path_folder_dlls_dados_dinamicos;

        public static string path_arquivo__dll__personagens;
        public static string path_arquivo__dll__cidades;
        public static string path_arquivos__dll__plots;

        public static string path_arquivos__dll__bosses;
        public static string path_arquivos__dll__mobs;
        public static string path_arquivos__dll__reinos;



        
        
        



        // --- UNICOS SAVE

        // *** INTERNOS

        public static string path_arquivo__dados_dinamicos__uso_completo__dados_sistema;
        
        public static string path_folder__save;
        public static string path_folder__save_MORTE;

        public static string path_folder__entidades;
        public static string path_folder__entidades_MORTE;
        
        public static string path_arquivo__dados_dinamicos__uso_completo__dados_player;
        public static string path_arquivo__dados_dinamicos__uso_completo__dados_player_morte;

        // --- IMAGENS UNICAS SEVA 

        
        public static string path_folder__imagens_galeria;



        // --- POSICOES

        public static string path_arquivo__localizador__pontos_logica;
        public static string path_arquivo__dados_estaticos__uso_parcial__pontos_logica;

                // *** agrupados porcidades
        public static string path_folder__dados_save_pontos;
        public static string path_arquivo__localizador__pontos_save;
        
        
        // --- ENTIDADES
        

                // --- NORMAL
                public static string path_folder__dados_save_personagens;
                public static string path_folder__dados_save_cidades;
                public static string path_folder__dados_save_plots;
                public static string path_folder__dados_save_mobs;
                public static string path_folder__dados_save_bosses;
                public static string path_folder__dados_save_reinos;

                // --- MORTE
                public static string path_folder__dados_save_personagens_MORTE;
                public static string path_folder__dados_save_cidades_MORTE;
                public static string path_folder__dados_save_plots_MORTE;
                public static string path_folder__dados_save_mobs_MORTE;
                public static string path_folder__dados_save_bosses_MORTE;
                public static string path_folder__dados_save_reinos_MORTE;




        // --- DEVELOPMENT

        public static string path_folder_dados_DEVELOPMENT;
        public static string path_folder__imagens_DEVELOPMENT;
        public static string path_folder_imagens_pontos_DEVELOPMENT;
        public static string path_folder_imagens_personagens_DEVELOPMENT;


        //mark
        public static string path_canvas__MENU;
        public static string path_canvas__LOGIN;
        public static string path_canvas__JOGO;





        // public static string path_dados_gerais_usuario; // per_data_path


        // --- USO GERAL

        // *** folder vai ser copiado para a build final
        public static string path_folder__imagens_gerais;
        public static string path_folder__imagens_reutilizaveis;

        public static string path_folder__imagens_dispositivos;
        public static string path_folder__imagens_dispositivos_reutilizaveis;

        


                // --- CURSOR

                        // ** imagens
                        public static string path_arquivo__localizador__cursor_imagens;
                        public static string path_arquivo__dados_estaticos__uso_parcial__cursor_imagens;


                // --- MENU

                        // ** imagens
                        public static string path_arquivo__localizador__menu_imagens;
                        public static string path_arquivo__dados_estaticos__uso_parcial__menu_imagens;

                        // ** texto
                        public static string path_arquivo__localizador__menu_textos;
                        public static string path_arquivo__dados_estaticos__uso_parcial__menu_textos;

                        // ** prefabs

                        public static string path_folder__prefabs_tipos_de_menu;


                // --- LOGIN

                        // ** imagens
                        public static string path_arquivo__localizador__login_imagens;
                        public static string path_arquivo__dados_estaticos__uso_parcial__login_imagens;

                        // ** texto
                        public static string path_arquivo__localizador__login_textos;
                        public static string path_arquivo__dados_estaticos__uso_parcial__login_textos;





        static Paths_sistema(){


                // --- DEVELOPMENT

                #if UNITY_EDITOR

                        // --- FOLDER
                        path_folder_dados_DEVELOPMENT = System.IO.Directory.GetParent( System.IO.Directory.GetCurrentDirectory() ).FullName;

                        // --- SUB-FOLDERS
                                
                                // --- IMAGENS 
                                path_folder__imagens_DEVELOPMENT = System.IO.Path.Combine( path_folder_dados_DEVELOPMENT, "Imagens" );

                                path_folder_imagens_pontos_DEVELOPMENT = System.IO.Path.Combine( path_folder__imagens_DEVELOPMENT, "Pontos" );
                                path_folder_imagens_personagens_DEVELOPMENT = System.IO.Path.Combine( path_folder__imagens_DEVELOPMENT, "Personagens" );



                #endif


                        

                // --- JOGO

                #if UNITY_EDITOR
                        path_folder__dados_usuario = ( Application.dataPath + "Editor/Folder_dados_teste/Dados_usuario" );
                        path_folder_save_default = Application.dataPath + "/Editor/Dados_saves_default";

                #else
                        path_folder__dados_usuario =  System.IO.Path.Combine( Application.persistentDataPath , "Dados_usuario" );  
                        path_folder_save_default =  System.IO.Path.Combine( Application.dataPath, "Dados_saves_default" );
                #endif


        

                path_arquivo_configuracoes = System.IO.Path.Combine( path_folder__dados_usuario, "configuracoes.dat" );
                                /*
                                        vai ter somente as configuracoes, coisas que o player podemo mudar

                                */


                path_arquivo_resumo_persona_usuario = System.IO.Path.Combine( path_folder__dados_usuario, "persona_usuario.dat" );
                                /*
                                        vai ter os dados com as tendencias do usuario. Nao vai ser dependente do save, vai ser do usuario como um todo

                                */

                path_arquivo_dados_menu_E_login_dados = System.IO.Path.Combine( path_folder__dados_usuario, "menu_E_login_dados.dat" );
                                /*
                                        Tem os dados atuais do menu e login. tem quais personagens estao liberados, qual as imagens atuais, quais estão disponiveis.. etc

                                */

                

                path_arquivo__stack_1 = System.IO.Path.Combine( path_folder__dados_usuario, "stack_1.dat" );
                path_arquivo__stack_2 = System.IO.Path.Combine( path_folder__dados_usuario, "stack_2.dat" );


                // --- DADOS DLL


                #if UNITY_EDITOR


                #endif


                // --- DADOS SAVE ( DINAMICOS )













                // ---  DLLs

                #if UNITY_EDITOR


                        // --- AIS ENTIDADES

                                path_arquivo__dll__personagens = Pegar_path_dados_dinamicos_dll(  "Personagens" );
                                path_arquivo__dll__cidades = Pegar_path_dados_dinamicos_dll(  "Cidades" );
                                path_arquivos__dll__plots = Pegar_path_dados_dinamicos_dll(  "Plots" );
                                path_arquivos__dll__bosses = Pegar_path_dados_dinamicos_dll(  "Bosses" );
                                path_arquivos__dll__mobs = Pegar_path_dados_dinamicos_dll(  "Mobs" );
                                path_arquivos__dll__reinos = Pegar_path_dados_dinamicos_dll(  "Reinos" );



                        // --- HANDLER TROCA BLOCOS 

                                path_arquivo__dll__handler_finalizar_VISUAL_NOVEL__E__CONECTOR = Pegar_path_dados_dinamicos_dll(  "handler_finalizar_VISUAL_NOVEL__E__CONECTOR" );
                                path_arquivo__dll__handler_finalizar_UTILIDADES__E__CONECTOR = Pegar_path_dados_dinamicos_dll(  "handler_finalizar_UTILIDADES__E__CONECTOR" );
                                path_arquivo__dll__handler_finalizar_CARTAS__E__CONECTOR = Pegar_path_dados_dinamicos_dll(  "handler_finalizar_CARTAS__E__CONECTOR" );
                                path_arquivo__dll__handler_finalizar_CONVERSAS__E__CONECTOR = Pegar_path_dados_dinamicos_dll(  "handler_finalizar_CONVERSAS__E__CONECTOR" );
                                path_arquivo__dll__handler_finalizar_MINIGAME__E__CONECTOR = Pegar_path_dados_dinamicos_dll(  "handler_finalizar_MINIGAME__E__CONECTOR" );
                                path_arquivo__dll__handler_finalizar_MINIGAMES__E__VISUAL_NOVEL = Pegar_path_dados_dinamicos_dll(  "handler_finalizar_MINIGAMES__E__VISUAL_NOVEL" );
                                path_arquivo__dll__handler_finalizar_MINIGAMES__E__CONVERSAS = Pegar_path_dados_dinamicos_dll(  "handler_finalizar_MINIGAMES__E__CONVERSAS" );
                                path_arquivo__dll__handler_finalizar_MINIGAMES__E__CARTAS = Pegar_path_dados_dinamicos_dll(  "handler_finalizar_MINIGAMES__E__CARTAS" );
                                path_arquivo__dll__handler_finalizar_MINIGAMES__E__UTILIDADES = Pegar_path_dados_dinamicos_dll(  "handler_finalizar_MINIGAMES__E__UTILIDADES" );
                                path_arquivo__dll__handler_finalizar_VISUAL_NOVEL__E__CONVERSAS = Pegar_path_dados_dinamicos_dll(  "handler_finalizar_VISUAL_NOVEL__E__CONVERSAS" );
                                path_arquivo__dll__handler_finalizar_VISUAL_NOVEL__E__CARTAS = Pegar_path_dados_dinamicos_dll(  "handler_finalizar_VISUAL_NOVEL__E__CARTAS" );
                                path_arquivo__dll__handler_finalizar_VISUAL_NOVEL__E__UTILIDADES = Pegar_path_dados_dinamicos_dll(  "handler_finalizar_VISUAL_NOVEL__E__UTILIDADES" );
                                path_arquivo__dll__handler_finalizar_CARTAS__E__CONVERSAS = Pegar_path_dados_dinamicos_dll(  "handler_finalizar_CARTAS__E__CONVERSAS" );
                                path_arquivo__dll__handler_finalizar_CARTAS__E__UTILIDADES = Pegar_path_dados_dinamicos_dll(  "handler_finalizar_CARTAS__E__UTILIDADES" );
                                path_arquivo__dll__handler_finalizar_CONVERSAS__E__UTILIDADES = Pegar_path_dados_dinamicos_dll(  "handler_finalizar_CONVERSAS__E__UTILIDADES" );
                


                #endif




                // --- DADOS ESTATICOS


                #if UNITY_EDITOR



                        path_folder__arquivo_dados_estaticos = System.IO.Path.Combine( Application.dataPath , "Editor/Folder_dados_teste", "Dados_estaticos" );


                        // --- INTERATIVOS

                                // ** logica
                                path_arquivo__localizador__interativos_logica = System.IO.Path.Combine( path_folder__arquivo_dados_estaticos, "Localizador_interativos_logica.dat" );
                                path_arquivo__dados_estaticos__uso_parcial__interativos_logica = System.IO.Path.Combine( path_folder__arquivo_dados_estaticos, "Interativos_logica.dat" );

                                // ** imagens
                                path_arquivo__localizador__interativos_imagens = System.IO.Path.Combine( path_folder__arquivo_dados_estaticos, "Localizador_interativos_imagens.dat" );
                                path_arquivo__dados_estaticos__uso_parcial__interativos_imagens = System.IO.Path.Combine( path_folder__arquivo_dados_estaticos, "Interativos_imagens.dat" );

                                // ** textos
                                path_arquivo__localizador__interativos_textos = System.IO.Path.Combine( path_folder__arquivo_dados_estaticos, "Localizador_interativos_textos.dat" ); 
                                path_arquivo__dados_estaticos__uso_parcial__interativos_textos = System.IO.Path.Combine( path_folder__arquivo_dados_estaticos, "Interativos_textos.dat" );


                        // --- PONTOS

                                // ** imagens
                                path_arquivo__localizador__backgrounds_imagens = System.IO.Path.Combine( path_folder__arquivo_dados_estaticos, "Localizador_backgrounds_imagens.dat" );
                                path_arquivo__dados_estaticos__uso_parcial__pontos_background_imagens = System.IO.Path.Combine( path_folder__arquivo_dados_estaticos, "Backgrounds_imagens.dat" );


                        // --- CARTAS

                                // ** logica
                                path_arquivo__localizador__cartas_logica = System.IO.Path.Combine( path_folder__arquivo_dados_estaticos, "Localizador_cartas_logica.dat" );
                                path_arquivo__dados_estaticos__uso_parcial__cartas_logica = System.IO.Path.Combine( path_folder__arquivo_dados_estaticos, "Cartas_logica.dat" );

                                // ** imagens
                                path_arquivo__localizador__cartas_imagens = System.IO.Path.Combine( path_folder__arquivo_dados_estaticos, "Localizador_cartas_imagens.dat" );
                                path_arquivo__dados_estaticos__uso_parcial__cartas_imagens = System.IO.Path.Combine( path_folder__arquivo_dados_estaticos, "Cartas_imagens.dat" );

                                // ** textos
                                path_arquivo__localizador__cartas_textos = System.IO.Path.Combine( path_folder__arquivo_dados_estaticos, "Localizador_cartas_textos.dat" ); 
                                path_arquivo__dados_estaticos__uso_parcial__cartas_textos = System.IO.Path.Combine( path_folder__arquivo_dados_estaticos, "Cartas_textos.dat" );


                        // --- ITENS

                                // ** logica
                                path_arquivo__localizador__itens_logica = System.IO.Path.Combine( path_folder__arquivo_dados_estaticos, "Localizador_itens_logica.dat" );
                                path_arquivo__dados_estaticos__uso_parcial__itens_logica = System.IO.Path.Combine( path_folder__arquivo_dados_estaticos, "Itens_logica.dat" );

                                // ** imagens
                                path_arquivo__localizador__itens_imagens = System.IO.Path.Combine( path_folder__arquivo_dados_estaticos, "Localizador_tens_imagens.dat" );
                                path_arquivo__dados_estaticos__uso_parcial__itens_imagens = System.IO.Path.Combine( path_folder__arquivo_dados_estaticos, "Itens_imagens.dat" );

                                // ** textos
                                path_arquivo__localizador__itens_textos = System.IO.Path.Combine( path_folder__arquivo_dados_estaticos, "Localizador_itens_textos.dat" ); 
                                path_arquivo__dados_estaticos__uso_parcial__itens_textos = System.IO.Path.Combine( path_folder__arquivo_dados_estaticos, "Itens_textos.dat" );


                        // --- MINIGAMES


                                // ** logica
                                path_arquivo__localizador__minigames_logica = System.IO.Path.Combine( path_folder__arquivo_dados_estaticos, "Localizador_minigames_logica.dat" );
                                path_arquivo__dados_estaticos__uso_parcial__minigames_logica = System.IO.Path.Combine( path_folder__arquivo_dados_estaticos, "Minigames_logica.dat" );

                                // ** imagens
                                path_arquivo__localizador__minigames_imagens = System.IO.Path.Combine( path_folder__arquivo_dados_estaticos, "Localizador_minigames_imagens.dat" );
                                path_arquivo__dados_estaticos__uso_parcial__minigames_imagens = System.IO.Path.Combine( path_folder__arquivo_dados_estaticos, "Minigames_imagens.dat" );

                                // ** textos
                                path_arquivo__localizador__minigames_textos = System.IO.Path.Combine( path_folder__arquivo_dados_estaticos, "Localizador_minigames_textos.dat" ); 
                                path_arquivo__dados_estaticos__uso_parcial__minigames_textos = System.IO.Path.Combine( path_folder__arquivo_dados_estaticos, "Minigames_textos.dat" );



                        // --- USO GERAL

                                // --- DISPOSITIVOS


                                        path_folder__imagens_dispositivos = System.IO.Path.Combine( Application.dataPath, "Resources", "Images", "Uso_geral", "Dispositivos" );
                                        path_folder__imagens_dispositivos_reutilizaveis = System.IO.Path.Combine( Application.dataPath, "Resources", "Images", "Reutilizaveis" );



                                // --- CURSOR

                                        // ** imagens
                                        path_arquivo__localizador__cursor_imagens = System.IO.Path.Combine( path_folder__arquivo_dados_estaticos, "Localizador_cursor_imagens.dat" );
                                        path_arquivo__dados_estaticos__uso_parcial__cursor_imagens = System.IO.Path.Combine( path_folder__arquivo_dados_estaticos, "Cursor_imagens.dat" );



                                // --- MENU

                                        // ** imagens
                                        path_arquivo__localizador__menu_imagens = System.IO.Path.Combine( path_folder__arquivo_dados_estaticos, "Localizador_menu_imagens.dat" );
                                        path_arquivo__dados_estaticos__uso_parcial__menu_imagens = System.IO.Path.Combine( path_folder__arquivo_dados_estaticos, "Menu_imagens.dat" );

                                        // ** texto
                                        path_arquivo__localizador__menu_textos = System.IO.Path.Combine( path_folder__arquivo_dados_estaticos, "Localizador_menu_textos.dat" );
                                        path_arquivo__dados_estaticos__uso_parcial__menu_textos = System.IO.Path.Combine( path_folder__arquivo_dados_estaticos, "Menu_textos.dat" );

                                        //mark
                                        path_folder__prefabs_tipos_de_menu = "prefab/";


                                // --- LOGIN


                                        // ** imagens
                                        path_arquivo__localizador__login_imagens = System.IO.Path.Combine( path_folder__arquivo_dados_estaticos, "Localizador_login_imagens.dat" );
                                        path_arquivo__dados_estaticos__uso_parcial__login_imagens = System.IO.Path.Combine( path_folder__arquivo_dados_estaticos, "Login_imagens.dat" );

                                        // ** texto
                                        path_arquivo__localizador__login_textos = System.IO.Path.Combine( path_folder__arquivo_dados_estaticos, "Localizador_login_textos.dat" );
                                        path_arquivo__dados_estaticos__uso_parcial__login_textos = System.IO.Path.Combine( path_folder__arquivo_dados_estaticos, "Login_textos.dat" );

                                









                #endif


                

                path_folder_localizadores = System.IO.Path.Combine( path_folder__arquivo_dados_estaticos, "Localizadores" );



                // --- PARA COPIAR PRIMEIRO JOGO

                        // --- DADOS ENTIDADES

                        path_folder__entidades_para_copiar_novo_save_personagens = System.IO.Path.Combine( path_folder__arquivo_dados_estaticos,"Dados_para_copiar_no_save", "Personagens" );
                        path_folder__entidades_para_copiar_novo_save_cidades = System.IO.Path.Combine( path_folder__arquivo_dados_estaticos,"Dados_para_copiar_no_save", "Cidades" );
                        path_folder__entidades_para_copiar_novo_save_plots = System.IO.Path.Combine( path_folder__arquivo_dados_estaticos,"Dados_para_copiar_no_save", "Plots" );
                        path_folder__entidades_para_copiar_novo_save_mobs = System.IO.Path.Combine( path_folder__arquivo_dados_estaticos,"Dados_para_copiar_no_save", "Mobs" );
                        path_folder__entidades_para_copiar_novo_save_bosses = System.IO.Path.Combine( path_folder__arquivo_dados_estaticos,"Dados_para_copiar_no_save", "Bosses" );
                        path_folder__entidades_para_copiar_novo_save_reinos = System.IO.Path.Combine( path_folder__arquivo_dados_estaticos,"Dados_para_copiar_no_save", "Reinos" );







                        
        }




        public static string Pegar_path_arquivo__dados_dinamicos__entidade( Entidade_nome _entidade,  string _nome_entidade ){


                string path_folder = null;

                switch( _entidade ){

                        case Entidade_nome.personagem : path_folder = path_folder__dados_save_personagens; break;
                        case Entidade_nome.cidade : path_folder = path_folder__dados_save_cidades; break;
                        case Entidade_nome.plot : path_folder = path_folder__dados_save_plots; break;

                        case Entidade_nome.boss : path_folder = path_folder__dados_save_bosses; break;
                        case Entidade_nome.mob : path_folder = path_folder__dados_save_bosses; break;
                        case Entidade_nome.reino : path_folder = path_folder__dados_save_reinos; break;

                        default : throw new System.Exception( $"nao foi aceito o tipo de entidade { _entidade.ToString() }" );
                        
                }



                return System.IO.Path.Combine( path_folder, _nome_entidade );


        }


        public static string Pegar_path_imagem_save( int _numero_save ){

                if( _numero_save > 4 )
                        { throw new Exception( $"tentou carregar o save { _numero_save }" ); }

                return System.IO.Path.Combine( Application.persistentDataPath, $"save_{ _numero_save.ToString() }", "imagem_save_slot.png" );


        }




        public static void Colocar_save( int _save ){


                // --- PEGA FOLDERS PRINCIPAIS

                #if UNITY_EDITOR
                        path_folder__save = System.IO.Path.Combine( Application.dataPath , "Editor/Folder_dados_teste", $"save_{ _save.ToString() }" );
                #else
                        path_folder__save =  System.IO.Path.Combine( Application.persistentDataPath ,  $"save_{ _save.ToString() }" );
                #endif


                path_folder__save_MORTE = System.IO.Path.Combine( path_folder__save,  "Morte" );

                path_folder__entidades = System.IO.Path.Combine( path_folder__save , "Entidades" );
                path_folder__entidades_MORTE = System.IO.Path.Combine( path_folder__save , "Entidades_morte" ); 

                path_arquivo__dados_dinamicos__uso_completo__dados_sistema = System.IO.Path.Combine( path_folder__save,  "Dados_sistema.dat" ); 

                path_arquivo__dados_dinamicos__uso_completo__dados_player = System.IO.Path.Combine( path_folder__save,  "Dados_player.dat" ); 
                path_arquivo__dados_dinamicos__uso_completo__dados_player_morte = System.IO.Path.Combine( path_folder__save,  "Dados_player_morte.dat" ); 

                path_folder__imagens_galeria = System.IO.Path.Combine( path_folder__save,  "Imagens_galeria" ); 




                // --- POSICOES


                // *** isso faz muito mais sentido ficar em cada cidade como um L1 
                // path_arquivo__localizador__pontos_logica = System.IO.Path.Combine( path_folder__save, "Posicoes", "Localizador_pontos_logica.dat" );
                // path_arquivo__dados_estaticos__uso_parcial__pontos_logica  = System.IO.Path.Combine( path_folder__save, "Posicoes", "Pontos_logica.dat" );
                
                
                // --- ENTIDADES

                        // --- NORMAL 

                        path_folder__dados_save_personagens = System.IO.Path.Combine( path_folder__entidades, "Personagens" );
                        path_folder__dados_save_cidades = System.IO.Path.Combine( path_folder__entidades, "Cidades" );
                        path_folder__dados_save_plots = System.IO.Path.Combine( path_folder__entidades, "Plots" );
                        path_folder__dados_save_mobs = System.IO.Path.Combine( path_folder__entidades, "Mobs" );
                        path_folder__dados_save_bosses = System.IO.Path.Combine( path_folder__entidades, "Bosses" );
                        path_folder__dados_save_reinos = System.IO.Path.Combine( path_folder__entidades, "Reinos" );

                        // --- MORTE

                        path_folder__dados_save_personagens_MORTE = System.IO.Path.Combine( path_folder__entidades, "Personagens" );
                        path_folder__dados_save_cidades_MORTE = System.IO.Path.Combine( path_folder__entidades, "Cidades" );
                        path_folder__dados_save_plots_MORTE = System.IO.Path.Combine( path_folder__entidades, "Plots" );
                        path_folder__dados_save_mobs_MORTE = System.IO.Path.Combine( path_folder__entidades, "Mobs" );
                        path_folder__dados_save_bosses_MORTE = System.IO.Path.Combine( path_folder__entidades, "Bosses" );
                        path_folder__dados_save_reinos_MORTE = System.IO.Path.Combine( path_folder__entidades, "Reinos" );



                // --- DADOS ESTATICOS


                
                return;


        }



        public static string Pegar_path_arquivo__dll__handler_finalizar( Bloco _bloco_1, Bloco _bloco_2  ){



                switch( _bloco_1 ){


                        case Bloco.conector:                    {
                                                                        switch( _bloco_2 ){

                                                                                case Bloco.conector :   throw new Exception( $"veio 2 blocos em pegar path dll handler finalizar, veio { _bloco_1 }");
                                                                                case Bloco.visual_novel :   return path_arquivo__dll__handler_finalizar_VISUAL_NOVEL__E__CONECTOR ; 
                                                                                case Bloco.minigames :   return path_arquivo__dll__handler_finalizar_MINIGAME__E__CONECTOR ;
                                                                                case Bloco.utilidades :   return path_arquivo__dll__handler_finalizar_UTILIDADES__E__CONECTOR;
                                                                                case Bloco.conversas:   return path_arquivo__dll__handler_finalizar_CONVERSAS__E__CONECTOR ;
                                                                                case Bloco.cartas:   return path_arquivo__dll__handler_finalizar_CARTAS__E__CONECTOR ;

                                                                        }


                                                                }
                                                                { break; }
                        case Bloco.visual_novel:                {
                                                                        switch( _bloco_2 ){

                                                                                case Bloco.conector :   return path_arquivo__dll__handler_finalizar_VISUAL_NOVEL__E__CONECTOR ;
                                                                                case Bloco.visual_novel :   throw new Exception( $"veio 2 blocos em pegar path dll handler finalizar, veio { _bloco_1 }");
                                                                                case Bloco.minigames :   return path_arquivo__dll__handler_finalizar_MINIGAMES__E__VISUAL_NOVEL; 
                                                                                case Bloco.utilidades :   return path_arquivo__dll__handler_finalizar_VISUAL_NOVEL__E__UTILIDADES ;
                                                                                case Bloco.conversas:   return path_arquivo__dll__handler_finalizar_VISUAL_NOVEL__E__CONVERSAS ;
                                                                                case Bloco.cartas:   return path_arquivo__dll__handler_finalizar_VISUAL_NOVEL__E__CARTAS;  

                                                                        }


                                                                }
                                                                { break; }                                                
                        case Bloco.minigames:                   {
                                                                        switch( _bloco_2 ){

                                                                                case Bloco.conector :   return path_arquivo__dll__handler_finalizar_MINIGAME__E__CONECTOR ;
                                                                                case Bloco.visual_novel :   return path_arquivo__dll__handler_finalizar_MINIGAMES__E__VISUAL_NOVEL; 
                                                                                case Bloco.minigames :   throw new Exception( $"veio 2 blocos em pegar path dll handler finalizar, veio { _bloco_1 }");
                                                                                case Bloco.utilidades :   return path_arquivo__dll__handler_finalizar_MINIGAMES__E__UTILIDADES;
                                                                                case Bloco.conversas:   return path_arquivo__dll__handler_finalizar_MINIGAMES__E__CONVERSAS;
                                                                                case Bloco.cartas:   return path_arquivo__dll__handler_finalizar_MINIGAMES__E__CARTAS; 

                                                                        }

                                                                }
                                                                { break; }
                        case Bloco.utilidades:                  {
                                                                        switch( _bloco_2 ){

                                                                                case Bloco.conector :   return path_arquivo__dll__handler_finalizar_UTILIDADES__E__CONECTOR ;
                                                                                case Bloco.visual_novel :   return path_arquivo__dll__handler_finalizar_VISUAL_NOVEL__E__UTILIDADES; 
                                                                                case Bloco.minigames :   return path_arquivo__dll__handler_finalizar_MINIGAMES__E__UTILIDADES;
                                                                                case Bloco.utilidades :  throw new Exception( $"veio 2 blocos em pegar path dll handler finalizar, veio { _bloco_1 }");   
                                                                                case Bloco.conversas:   return path_arquivo__dll__handler_finalizar_CONVERSAS__E__UTILIDADES;
                                                                                case Bloco.cartas:   return path_arquivo__dll__handler_finalizar_CARTAS__E__UTILIDADES ; 

                                                                        }

                                                                }
                                                                { break; }
                        case Bloco.conversas:                   {
                                                                        switch( _bloco_2 ){

                                                                                case Bloco.conector :   return path_arquivo__dll__handler_finalizar_CONVERSAS__E__CONECTOR;
                                                                                case Bloco.visual_novel :   return path_arquivo__dll__handler_finalizar_VISUAL_NOVEL__E__CONVERSAS ; 
                                                                                case Bloco.minigames :   return path_arquivo__dll__handler_finalizar_MINIGAMES__E__CONVERSAS;
                                                                                case Bloco.utilidades :   return path_arquivo__dll__handler_finalizar_CONVERSAS__E__UTILIDADES;
                                                                                case Bloco.conversas:   throw new Exception( $"veio 2 blocos em pegar path dll handler finalizar, veio { _bloco_1 }");
                                                                                case Bloco.cartas:   return path_arquivo__dll__handler_finalizar_CARTAS__E__CONVERSAS; 

                                                                        }

                                                                }
                                                                { break; }
                        case Bloco.cartas:                      {
                                                                        switch( _bloco_2 ){

                                                                                case Bloco.conector :   return path_arquivo__dll__handler_finalizar_CARTAS__E__CONECTOR;
                                                                                case Bloco.visual_novel :   return path_arquivo__dll__handler_finalizar_VISUAL_NOVEL__E__CARTAS; 
                                                                                case Bloco.minigames :   return path_arquivo__dll__handler_finalizar_MINIGAMES__E__CARTAS;
                                                                                case Bloco.utilidades :   return path_arquivo__dll__handler_finalizar_CARTAS__E__UTILIDADES;
                                                                                case Bloco.conversas:   return path_arquivo__dll__handler_finalizar_CARTAS__E__CONVERSAS ;
                                                                                case Bloco.cartas:   throw new Exception( $"veio 2 blocos em pegar path dll handler finalizar, veio { _bloco_1 }");

                                                                        }

                                                                }
                                                                { break; }

                        default: throw new Exception( $" Nao veio um modo valido no bloco 1, veio { _bloco_1 }" );

                }

                throw new Exception( $" Nao veio um modo valido no bloco 2, veio { _bloco_2 }" );

                
        } 



        private static string Pegar_path_dados_dinamicos_dll( string _dll_nome ){

                #if UNITY_EDITOR
                        return null;
                #endif

                string path =  System.IO.Path.Combine( path_folder_dlls_dados_dinamicos, _dll_nome );
                path = System.IO.Path.ChangeExtension( path, ".dll"  );

                if( !!!( System.IO.File.Exists( path ) ) )
                        { throw new Exception( $"Nao foi achado a dll" ); }

                return path;

        }





}