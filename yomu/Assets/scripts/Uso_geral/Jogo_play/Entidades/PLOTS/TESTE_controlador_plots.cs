using System;


#if UNITY_EDITOR

    public static class TESTE_controlador_plots {

        public static void Construir_controlador(){


            Controlador_plots controlador = new Controlador_plots();


                controlador.leitor_de_arquivos = new MODULO__leitor_de_arquivos (	
                                                                                    _gerenciador_nome : "TESTE__manipuladordados_dinamicos_plots" ,
                                                                                    _path_folder: null, //Paths_sistema.path_dados_save_plots,
                                                                                    _numero_inicial_de_slots: 50 
                                                                                );
                    controlador.gerenciador_save = new Gerenciador_save_plots( controlador );

                controlador.dados_sistema_plots_essenciais = new Dados_sistema_plot_essenciais[ Enum.GetNames( typeof( Plot_nome ) ).Length ];
                controlador.plots_ativos_ids = new int[ 0 ];

        
            Controlador_plots.instancia = controlador;
            return;     

        }


    }

#endif