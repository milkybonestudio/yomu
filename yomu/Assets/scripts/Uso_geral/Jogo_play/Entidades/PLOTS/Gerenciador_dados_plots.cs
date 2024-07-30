

public class Gerenciador_dados_plots {

    public Gerenciador_dados_plots(){

        // localizador = Paths_sistema.
        leitor_de_arquivos = new MODULO__leitor_de_arquivos (
                                                                _gerenciador_nome : "",
                                                                _path_folder: Paths_sistema.path_folder__dados_save_plots,
                                                                _numero_inicial_de_slots: 50
                                                            ); 
        return;

    }

    public byte[] localizador;
    public MODULO__leitor_de_arquivos leitor_de_arquivos;

}