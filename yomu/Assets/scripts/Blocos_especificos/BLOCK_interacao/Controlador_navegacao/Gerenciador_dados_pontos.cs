

public class Gerenciador_dados_pontos {


        public MODULO__desmembrador_de_arquivo desmembrador_de_arquivo; 

        public Gerenciador_dados_pontos(){



                path_container = Paths_sistema.path_folder__dados_save_pontos;
                localizador = System.IO.File.ReadAllBytes( Paths_sistema.path_arquivo__localizador__pontos_save );

                desmembrador_de_arquivo = new MODULO__desmembrador_de_arquivo   (   
                                                                                    _gerenciador_nome: "Gerenciador_dados_pontos",
                                                                                    _path_arquivo: path_container,
                                                                                    _numero_inicial_de_slots: 50
                                                                                );            

        }


        public byte[] localizador;

        public byte[] dados_atuais;
        public string path_container;

        public string nome_gerenciador;


}