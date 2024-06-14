




public class Gerenciador_containers_dados_plot {

    public byte[] Compilar_dados(){ return null;}
   


}


public class Gerenciador_personagens_plot {



}


public class Plot {

    public Plot( int _plot_id ){

        plot_id = _plot_id;
    }

    public Gerenciador_personagens_plot gerenciador_personagens_plot;
    public Gerenciador_containers_dados_plot gerenciador_containers_dados_plot;
    public int plot_id;



}