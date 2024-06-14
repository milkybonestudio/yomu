using System;
using UnityEngine;




public class Controlador_dados_sistema {

        public static Controlador_dados_sistema instancia;
        public static Controlador_dados_sistema Pegar_instancia(){ return instancia; }


        // --- GERENCIADORES 

        public Gerenciador_sistema_estado_atual gerenciador_sistema_estado_atual;
        public Gerenciador_player gerenciador_player;
        public Gerenciador_save_dados_sistema gerenciador_save;


        // --- DADOS 

        public Dados_sistema_personagem_essenciais[] dados_personagens_essenciais;
        public Dados_sistema_cidade_essenciais[] dados_cidades_essenciais;
        public Dados_sistema_plot_essenciais[] dados_plots_essenciais;

        // ** pega somente dos personagens ativos 
        public Dados_sistema_personagem[] dados_personagens;
        public Dados_sistema_cidade[] dados_cidades;
        public Dados_sistema_plot[] dados_plots;


        public static Controlador_dados_sistema Construir( Dados_sistema_estado_atual _dados_sistema_estado_atual ){

                Controlador_dados_sistema controlador  = new Controlador_dados_sistema();

                        // --- CRIAR GERENCIADORES 

                        controlador.gerenciador_sistema_estado_atual = new Gerenciador_sistema_estado_atual( controlador );
                        controlador.gerenciador_player = new Gerenciador_player( _dados_sistema_estado_atual );
                        controlador.gerenciador_save = new Gerenciador_save_dados_sistema( controlador );



                        // --- PEGAR DADOS

                        controlador.dados_personagens_essenciais = Controlador_personagens.Pegar_instancia().dados_sistema_personagens_essenciais;
                        controlador.dados_cidades_essenciais = Controlador_cidades.Pegar_instancia().dados_sistema_cidades_essenciais;
                        controlador.dados_plots_essenciais = Controlador_plots.Pegar_instancia().dados_sistema_plots_essenciais;

                        controlador.dados_personagens = Controlador_personagens.Pegar_instancia().dados_sistema_personagens;
                        controlador.dados_cidades = Controlador_cidades.Pegar_instancia().dados_sistema_cidades;
                        controlador.dados_plots = Controlador_plots.Pegar_instancia().dados_sistema_plots;


                instancia = controlador; 
                return controlador;

        }

        

        public byte[] Compilar_dados_sistema_atual(){
                        

                        Dados_sistema_estado_atual dados_estado_atual = gerenciador_sistema_estado_atual.Pegar_dados()
                        
                        byte[] dados = Compilador_dados_sistema.Compilar();
                        return dados;
        }


        public Dados_para_salvar Pegar_dados_para_salvar( Modo_save _modo ){

                // ** fazer 
                return null;

        }
		





}