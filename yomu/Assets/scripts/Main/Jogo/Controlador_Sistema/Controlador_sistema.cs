using System;
using UnityEngine;
using Unity.Jobs;
using System.Collections.Generic;





public class Controlador_sistema {


        // A principal funcao de controlador sistema deve ser pega requests e executar eles 


        public static Controlador_sistema instancia;
        public static Controlador_sistema Pegar_instancia(){ return instancia; }


        // --- CONTROLADORES

        public INTERFACE__controlador_entidade[] controladores_entidades;

        public CONTROLLER__characters controlador_personagens;
        public CONTROLLER__cities controlador_cidades;
        public Controlador_plots controlador_plots;


        // --- GERENCIADORES 

        public Gerenciador_sistema_estado_atual gerenciador_sistema_estado_atual;
        public Gerenciador_player gerenciador_player;
        public GERENCIADOR__save_dados_sistema gerenciador_save;


        // --- DADOS 



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
                                Jogo.Pegar_instancia().bloco_atual = Block_type.interacao;
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
