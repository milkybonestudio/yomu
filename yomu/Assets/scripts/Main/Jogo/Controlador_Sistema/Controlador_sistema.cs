using System;
using UnityEngine;
using Unity.Jobs;
using System.Collections.Generic;





public class Controlador_sistema {


        // A principal funcao de controlador sistema deve ser pega requests e executar eles 


        public static Controlador_sistema instancia;
        public static Controlador_sistema Pegar_instancia(){ return instancia; }


        // --- CONTROLADORES

        public INTERFACE__controlador_entidade[] controlador_entidades;

        public Controlador_personagens controlador_personagens;
        public Controlador_cidades controlador_cidades;
        public Controlador_plots controlador_plots;


        // --- GERENCIADORES 

        public Gerenciador_sistema_estado_atual gerenciador_sistema_estado_atual;
        public Gerenciador_player gerenciador_player;
        public GERENCIADOR__save_dados_sistema gerenciador_save;


        // --- DADOS 


        // ** cidade e plots tem uma caracteristica em especifico que deixa eles bom para jump_table => pouca quantidade 
        // ** plots tem muitos para colocar tudo em um enum, e na realidade cidades também tem mais 
        // **  pensar em como fazer de um jeito pratico que possa ser optimizado depois 
        // public Dados_sistema_personagem_essenciais[] dados_personagens_essenciais; 
        // public Dados_sistema_cidade_essenciais[] dados_cidades_essenciais; 
        // public Dados_sistema_plot_essenciais[] dados_plots_essenciais;


        public Dictionary<int,Dados_sistema_plot_essenciais> localizador_dados_plots_essenciais;
        public Dictionary<int,Dados_sistema_personagem_essenciais> localizador_dados_personagens_essenciais;
        public Dictionary<int,Dados_sistema_cidade_essenciais> localizador_dados_cidades_essenciais;


        public Dictionary<int,Dados_sistema_plot> localizador_dados_plots;
        public Dictionary<int,Dados_sistema_personagem> localizador_dados_personagens;
        public Dictionary<int,Dados_sistema_cidade> localizador_dados_cidades;

        


        // ** quando for optimizar pode fazer uma jump table. Assumiria que já tem os dados finais e seria usado somente na build 
        // ** essa versao vai ter que ter um save um pouco diferente, vai ter que ser | id | | dados | como o id não vai ser sequencia precisa guardar e converter quando iniciar o jogo

        public Dados_sistema_plot_essenciais Pegar_dados_sistema_plot_essenciais( Plot_localizador _localizador ){

            int indentificador = _localizador.indentificador;
            return localizador_dados_plots_essenciais[ indentificador ]; // ** tem que ter
        }


        public Dados_sistema_personagem_essenciais Pegar_dados_sistema_plot_essenciais( Personagem_localizador _localizador ){

            int indentificador = _localizador.indentificador;
            return localizador_dados_personagens_essenciais[ indentificador ]; // ** tem que ter
        }


        public Dados_sistema_cidade_essenciais Pegar_dados_sistema_plot_essenciais( Cidade_localizador _localizador ){

            int indentificador = _localizador.indentificador;
            return localizador_dados_cidades_essenciais[ indentificador ]; // ** tem que ter
        }


        // --- DADOS PARA TROCA DIA
        public JobHandle job_handler_passada_dia;


        // --- ENTIDADES_PARA_ADICIONAR



        public Personagem_nome[] personagens_para_adicionar = new Personagem_nome[ 20 ];
        public Regiao_nome[] cidades_para_adicionar = new Regiao_nome[ 20 ]; // carrega as cidades no trecho de uma vez
        

        public void Passar_dia(){

                Virar_dia_struct v = new Virar_dia_struct();
                v.Schedule();

        }


        public void Verificar_passar_dia(){

                if( job_handler_passada_dia.IsCompleted )
                        {
                                // *** destruir animacao 
                                Jogo.Pegar_instancia().bloco_atual = Bloco.interacao;
                                return;
                        }

                // *** atualizar animacao
                Debug.Log( "Esta esperando os dados do background serem finalizados" );

        }



        public byte[] Compilar_dados_sistema_atual(){
                        

                        Dados_sistema_estado_atual dados_estado_atual = gerenciador_sistema_estado_atual.Pegar_dados();
                        byte[] dados = Compilador_dados_sistema.Compilar( dados_estado_atual );
                        return dados;
        }




}
