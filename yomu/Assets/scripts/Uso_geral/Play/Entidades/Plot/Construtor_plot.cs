






public static class Construtor_plot {


	    public static  Plot Construir(  int _plot_id, Dados_sistema_plot_essenciais _dados_sistema_plot_essenciais , Dados_containers_plot _dados,  System.Object _plot_AI ){


				Plot plot = new Plot( _plot_id );

				return plot;

		}

		public static Plot Construir_plot_teste( int _plot_id , Dados_sistema_plot_essenciais _dados_sistema_plot_essenciais , Dados_containers_plot _dados,  System.Object _plot_AI ){

				// a unica diferená é que aqui se vier null ele só constroi o objeto sem dados;

				Plot plot = new Plot( _plot_id );

				return plot;

		}

	




}