using UnityEngine;


public static class Paths_sistema {


        static Paths_sistema(){

                // --- JOGO

                path_folder_dados_usuario = Paths_gerais.Pegar_path_folder_dados_usuario();

                path_arquivo_configuracoes = System.IO.Path.Combine( path_folder_dados_usuario, "configuracoes.dat" );
                                /*
                                        vai ter somente as configuracoes, coisas que o player podemo mudar

                                */


                path_arquivo_resumo_persona_usuario = System.IO.Path.Combine( path_folder_dados_usuario, "persona_usuario.dat" );
                                /*
                                        vai ter os dados com as tendencias do usuario. Nao vai ser dependente do save, vai ser do usuario como um todo

                                */

                path_arquivo_dados_menu_E_login_dados = System.IO.Path.Combine( path_folder_dados_usuario, "menu_E_login_dados.dat" );
                                /*
                                        Tem os dados atuais do menu e login. tem quais personagens estao liberados, qual as imagens atuais, quais estão disponiveis.. etc

                                */

                

                path_stack_1 = System.IO.Path.Combine( path_folder_dados_usuario, "stack_1.dat" );
                path_stack_2 = System.IO.Path.Combine( path_folder_dados_usuario, "stack_2.dat" );


                // --- DADOS DLL

                path_dlls_dados_dinamicos = Paths_gerais.Pegar_path_dados_dlls();


                // --- DADOS ESTATICOS

                path_dados_estaticos = Paths_gerais.Pegar_path_folder_dados_estaticos();
                path_folder_localizadores = System.IO.Path.Combine( path_dados_estaticos, "Localizadores" );

                // --- PARA LER 

                path_dados_estaticos_interativos = System.IO.Path.Combine( path_dados_estaticos,"Dados_para_ler", "Interativos_dados.dat" );
                path_dados_estaticos_pontos = System.IO.Path.Combine( path_dados_estaticos,"Dados_para_ler", "Pontos_dados.dat" );
                path_dados_estaticos_cartas = System.IO.Path.Combine( path_dados_estaticos,"Dados_para_ler", "Cartas_dados.dat" );
                path_dados_estaticos_itens = System.IO.Path.Combine( path_dados_estaticos,"Dados_para_ler", "Itens_dados.dat" );
                path_dados_estaticos_minigames = System.IO.Path.Combine( path_dados_estaticos,"Dados_para_ler", "Minigames_dados.dat" );
                path_dados_estaticos_scripts = System.IO.Path.Combine( path_dados_estaticos,"Dados_para_ler", "Scripts_dados.dat" );

                path_dados_estaticos_cidades_textos = System.IO.Path.Combine( path_dados_estaticos,"Dados_para_ler", "Cidades_textos.dat" );




                // --- PARA COPIAR

                path_dados_estaticos_entidades_para_copiar_personagens = System.IO.Path.Combine( path_dados_estaticos,"Dados_para_copiar_no_save", "Personagens" );
                path_dados_estaticos_entidades_para_copiar_cidades = System.IO.Path.Combine( path_dados_estaticos,"Dados_para_copiar_no_save", "Cidades" );
                path_dados_estaticos_entidades_para_copiar_plots = System.IO.Path.Combine( path_dados_estaticos,"Dados_para_copiar_no_save", "Plots" );
                path_dados_estaticos_entidades_para_copiar_mobs = System.IO.Path.Combine( path_dados_estaticos,"Dados_para_copiar_no_save", "Mobs" );
                path_dados_estaticos_entidades_para_copiar_bosses = System.IO.Path.Combine( path_dados_estaticos,"Dados_para_copiar_no_save", "Bosses" );
                path_dados_estaticos_entidades_para_copiar_reinos = System.IO.Path.Combine( path_dados_estaticos,"Dados_para_copiar_no_save", "Reinos" );


                path_localizador_interativos = Application.dataPath + "/interativos/localizador_imagens_interativos.dat";
                path_imagens_interativos = Application.dataPath + "/interativos/imagens_interativos_container.dat";

                        
        }


        public static void Colocar_save( int _save ){


                path_save = Paths_gerais.Pegar_path_folder_dados_save( _save );
                path_folder_dados_personagens_morte = System.IO.Path.Combine( path_save,  "Morte" );
                path_dados_sistema = System.IO.Path.Combine( path_save,  "dados_programa.dat" );

                path_dados_save_personagens = System.IO.Path.Combine( path_save, "Personagens" );
                path_dados_save_cidades = System.IO.Path.Combine( path_save, "Cidades" );
                path_dados_save_plots = System.IO.Path.Combine( path_save, "Plots" );
                path_dados_save_mobs = System.IO.Path.Combine( path_save, "Mobs" );
                path_dados_save_bosses = System.IO.Path.Combine( path_save, "Bosses" );
                path_dados_save_reinos = System.IO.Path.Combine( path_save, "Reinos" );
                        


                // --- DADOS ESTATICOS


                
                return;


        }


        // --- UNICOS JOGO

        public static string path_folder_dados_usuario;

        public static string path_arquivo_resumo_persona_usuario;
        public static string path_arquivo_configuracoes;
        public static string path_arquivo_dados_menu_E_login_dados;
        

        public static string path_stack_1;
        public static string path_stack_2;


        // --- DADOS ESTATICOS

        public static string path_folder_localizadores;

        public static string path_dados_estaticos;


        // --- DADOS PARA COPIAR EM CADA SAVE
        public static string path_dados_estaticos_entidades_para_copiar_personagens;
        public static string path_dados_estaticos_entidades_para_copiar_cidades;
        public static string path_dados_estaticos_entidades_para_copiar_plots;
        public static string path_dados_estaticos_entidades_para_copiar_mobs;
        public static string path_dados_estaticos_entidades_para_copiar_bosses;
        public static string path_dados_estaticos_entidades_para_copiar_reinos;

        // --- DADOS PARA LER
        public static string path_dados_estaticos_interativos;
        public static string path_dados_estaticos_pontos;
        public static string path_dados_estaticos_cartas;
        public static string path_dados_estaticos_itens;
        public static string path_dados_estaticos_minigames;
        public static string path_dados_estaticos_scripts;


        // textos

        public static string path_dados_estaticos_interativos_textos;
        public static string path_dados_estaticos_pontos_textos;
        public static string path_dados_estaticos_cartas_textos;
        public static string path_dados_estaticos_itens_textos;
        public static string path_dados_estaticos_minigames_textos;
        public static string path_dados_estaticos_scripts_textos;



        public static string path_dados_estaticos_cidades_textos;
        public static string path_dados_estaticos_personagens_textos;
        public static string path_dados_estaticos_plots_textos;

        // --- DADOS DLLS

        public static string path_dlls_dados_dinamicos;
        
        


        // --- UNICOS SAVE

        public static string path_save;
        public static string path_folder_dados_personagens_morte;

        public static string path_dados_sistema;
        public static string path_dados_player;

        public static string path_dados_save_personagens;
        public static string path_dados_save_cidades;
        public static string path_dados_save_plots;
        public static string path_dados_save_mobs;
        public static string path_dados_save_bosses;
        public static string path_dados_save_reinos;


        



        public static string path_localizador_interativos;
        public static string path_imagens_interativos;

        public static string path_dados_gerais_usuario; // perdatapath

}