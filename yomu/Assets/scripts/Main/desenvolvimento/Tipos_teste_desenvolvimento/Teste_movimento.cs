using UnityEngine;
using System;
using System.Reflection;




public static class Teste_movimento {


        // ** criar ferramentas de suporte 

        public static void Criar(){
                

                // mudar update jogo para movimento
                // ** definir os dados do teste 
                

                Jogo.Pegar_instancia().bloco_atual = Bloco.movimento;
                
                Definir_estado_jogo_1();





        }

        


        public static void Definir_estado_jogo_1(){

                // --- construir personagem

                Posicao_geral posicao_geral = new Posicao_geral();
                Atividade atividade = Atividade.nada;

                Personagem lily = new Personagem( ( int ) Personagem_nome.Lily , posicao_geral, ( int ) atividade );

                Dados_containers_personagem dados_para_construir_personagem = new Dados_containers_personagem();
                
                // Controlador_dados_dinamicos.Pegar_instancia().perso.Carregar_personagem( lily );
                //Controlador_personagens.Pegar_instancia().personagens[ ( int ) Personagem_nome.Lily ] = lily;
                return;



        }


}