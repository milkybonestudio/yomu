


public static class TESTE_controlador_plots {

    public static void Construir_controlador(){

   
                Controlador_plots controlador = new Controlador_plots();


                        controlador.gerenciador_dados_dinamicos = new Gerenciador_dados_dinamicos_plots();
                        controlador.gerenciador_save = new Gerenciador_save_plots( controlador );

                        controlador.dados_sistema_plots_essenciais = new Dados_sistema_plot_essenciais[ Enum.GetNames( typeof( Plot_nome ) ).Length ];
                        controlador.plots_ativos_ids = new int[ 0 ];

            
                Controlador_plots.instancia = controlador;
                return;     

    }


}