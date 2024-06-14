




public class Gerenciador_containers_dados_plot {

    public byte[] Compilar_dados(){ return null;}
   


}


public class Gerenciador_personagens_plot {



}

public class Gerenciador_dados_sistema_plot {

    public Dados_sistema_plot Pegar_dados(){

            return dados;

    }


    public Dados_sistema_plot[] dados;




}


public class Plot {

    public Plot( int _plot_id ){

        plot_id = _plot_id;
    }

    public Gerenciador_personagens_plot gerenciador_personagens_plot;
    public Gerenciador_containers_dados_plot gerenciador_containers_dados_plot;
    public Gerenciador_dados_sistema_plot gerenciador_dados_sistema;
    public int plot_id;



}