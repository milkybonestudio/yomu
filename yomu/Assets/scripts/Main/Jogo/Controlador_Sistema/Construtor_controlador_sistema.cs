

public static class Construtor_controlador_sistema {


        public static Controlador_sistema Construir( ){

            Controlador_sistema controlador = new Controlador_sistema();
            Controlador_sistema.instancia = controlador;



                    // --- ENTIDADES

                            // controlador.controladores_entidades = new INTERFACE__controlador_entidade[  System.Enum.GetNames( typeof( Tipo_entidade ) ).Length ];



                            // // --- PEGAR DADOS
                            // Dados_sistema_personagem_essenciais[] dados_sistema_personagens_essenciais = Tradutor_dados_sistema.Descompactar_dados_sistema_personagens_essenciais( dados_sistema );
                            // Dados_sistema_cidade_essenciais[] dados_sistema_cidades_essenciais = Tradutor_dados_sistema.Descompactar_dados_sistema_cidades_essenciais( dados_sistema );
                            // Dados_sistema_plot_essenciais[] dados_sistema_plots_essenciais = Tradutor_dados_sistema.Descompactar_dados_sistema_plots_essenciais( dados_sistema );

                            // // --- CONSTRUIR
                            // controlador.controladores_entidades[ ( int ) Tipo_entidade.personagem ] = Controlador_personagens.Construir( dados_sistema_personagens_essenciais, dados_sistema_estado_atual ); 
                            // controlador.controladores_entidades[ ( int ) Tipo_entidade.cidade ]  = Controlador_cidades.Construir( dados_sistema_cidades_essenciais, dados_sistema_estado_atual ); 
                            // controlador.controladores_entidades[ ( int ) Tipo_entidade.plot ] = Controlador_plots.Construir( dados_sistema_plots_essenciais, dados_sistema_estado_atual ); 






                // --- CRIAR CONTROLADORES 

                //Construtor_controlador_armazenamento_disco.Construir();


                // --- CRIAR GERENCIADORES 

                // controlador.gerenciador_sistema_estado_atual = new Gerenciador_sistema_estado_atual( controlador );
                // controlador.gerenciador_player = new Gerenciador_player( _dados_sistema_estado_atual );
                // controlador.gerenciador_save = new GERENCIADOR__save_dados_sistema();




            return controlador;

        }


}