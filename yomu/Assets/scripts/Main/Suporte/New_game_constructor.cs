

public static class New_game_constructor {



        public static void Construct( int _save ){

                // *** tem que iniciar o save antes
                // ** TIRAR DEPOIS 
                return;

                
                // acho que seria melhor colocar somente os personagens principais 
                // Poderia ter uma funcao Adicionar_personagem 
                // mas os dados genericos ainda estariam no geral

                /*

                        a unica coisa de dados_sistema que precisa ter realmente dados fixos é onde que o personagem começa 
                        talvez eu faça uma lista com os dados e o resto é criado tudo por default 

                */


                // --- PERSONAGEM

                        // *** vai ter que estar vazio
                        string path_folder_dados_personagens_novo_save = Paths_sistema.path_folder__dados_save_personagens;
                        string path_folder_dados_personagens_novo_save_MORTE =  Paths_sistema.path_folder__dados_save_personagens_MORTE;
                        
                        string path_folder_save_default_personagens = Paths_sistema.path_folder__entidades_para_copiar_novo_save_personagens;


                        // --- COPIA OS DADOS
                        Arquivos.Copiar_pasta_inteira( _local_para_salvar: path_folder_dados_personagens_novo_save, _local_para_copiar : path_folder_save_default_personagens );
                        Arquivos.Copiar_pasta_inteira( _local_para_salvar: path_folder_dados_personagens_novo_save_MORTE, _local_para_copiar : path_folder_save_default_personagens );



                // --- CIDADES

                        // *** vai ter que estar vazio
                        string path_folder_dados_cidades_novo_save = Paths_sistema.path_folder__dados_save_cidades;
                        string path_folder_dados_cidades_novo_save_MORTE =  Paths_sistema.path_folder__dados_save_cidades_MORTE;
                        
                        string path_folder_save_default_cidades = Paths_sistema.path_folder__entidades_para_copiar_novo_save_cidades;

                        // --- COPIA OS DADOS
                        Arquivos.Copiar_pasta_inteira( _local_para_salvar: path_folder_dados_cidades_novo_save, _local_para_copiar : path_folder_save_default_cidades );
                        Arquivos.Copiar_pasta_inteira( _local_para_salvar: path_folder_dados_cidades_novo_save_MORTE, _local_para_copiar : path_folder_save_default_cidades );



                // --- PLOTS

                        // *** vai ter que estar vazio
                        string path_folder_dados_plots_novo_save = Paths_sistema.path_folder__dados_save_plots;
                        string path_folder_dados_plots_novo_save_MORTE =  Paths_sistema.path_folder__dados_save_plots_MORTE;
                        
                        string path_folder_save_default_plots = Paths_sistema.path_folder__entidades_para_copiar_novo_save_plots;


                        // --- COPIA OS DADOS
                        Arquivos.Copiar_pasta_inteira( _local_para_salvar: path_folder_dados_cidades_novo_save, _local_para_copiar : path_folder_save_default_plots );
                        Arquivos.Copiar_pasta_inteira( _local_para_salvar: path_folder_dados_cidades_novo_save_MORTE, _local_para_copiar : path_folder_save_default_plots );



                // --- BOSSES

                        // *** vai ter que estar vazio
                        string path_folder_dados_bosses_novo_save = Paths_sistema.path_folder__dados_save_bosses;
                        string path_folder_dados_bosses_novo_save_MORTE =  Paths_sistema.path_folder__dados_save_bosses_MORTE;
                        
                        string path_folder_save_default_bosses = Paths_sistema.path_folder__entidades_para_copiar_novo_save_bosses;


                        // --- COPIA OS DADOS
                        Arquivos.Copiar_pasta_inteira( _local_para_salvar: path_folder_dados_bosses_novo_save, _local_para_copiar : path_folder_save_default_bosses );
                        Arquivos.Copiar_pasta_inteira( _local_para_salvar: path_folder_dados_bosses_novo_save_MORTE, _local_para_copiar : path_folder_save_default_bosses );



                // --- MOBS

                        // *** vai ter que estar vazio
                        string path_folder_dados_mobs_novo_save = Paths_sistema.path_folder__dados_save_mobs;
                        string path_folder_dados_mobs_novo_save_MORTE =  Paths_sistema.path_folder__dados_save_mobs_MORTE;
                        
                        string path_folder_save_default_mobs = Paths_sistema.path_folder__entidades_para_copiar_novo_save_mobs;


                        // --- COPIA OS DADOS
                        Arquivos.Copiar_pasta_inteira( _local_para_salvar: path_folder_dados_mobs_novo_save, _local_para_copiar : path_folder_save_default_mobs );
                        Arquivos.Copiar_pasta_inteira( _local_para_salvar: path_folder_dados_mobs_novo_save_MORTE, _local_para_copiar : path_folder_save_default_mobs );




                // --- REINOS

                        // *** vai ter que estar vazio
                        string path_folder_dados_reinos_novo_save = Paths_sistema.path_folder__dados_save_reinos;
                        string path_folder_dados_reinos_novo_save_MORTE =  Paths_sistema.path_folder__dados_save_reinos_MORTE;
                        
                        string path_folder_save_default_reinos = Paths_sistema.path_folder__entidades_para_copiar_novo_save_reinos;

                        // --- COPIA OS DADOS
                        Arquivos.Copiar_pasta_inteira( _local_para_salvar: path_folder_dados_reinos_novo_save, _local_para_copiar : path_folder_save_default_reinos );
                        Arquivos.Copiar_pasta_inteira( _local_para_salvar: path_folder_dados_reinos_novo_save_MORTE, _local_para_copiar : path_folder_save_default_reinos );


                return;


        }




}