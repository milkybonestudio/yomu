using UnityEngine;
using System;



// BLOCO_interacao SEMPRE VAI EXISTIR 
// ele pode ter um pouco mais de responsabilidade
// todos os scripts relacionado ao jogo assumem que ele existe 

//** controladores nao podem ter referencias, o finalizar sempre limpa os campos estaticos


public class BLOCO_interacao : BLOCK {


        // --- INSTANCIA

        public static BLOCO_interacao instancia;
        public static BLOCO_interacao Pegar_instancia(){ return instancia; }

        // --- INTERFACE 

        public override void Finalizar(){} // ** fianliza jogo

        // public void Lidar_retorno(){ Lidar_retorno_blocos.Ativar( ( INTERFACE__bloco ) this,  Dados_blocos.localizador_lidar_retorno_interaction ); } // ** vai sempre se chamado na transicao entre blocos

        public BLOCK_INTERACTION__mode update_tipo_atual = BLOCK_INTERACTION__mode.connector; // default

        public override void Destruir(){}
        public override void Iniciar(){}
        public override Task_req Carregar_dados(){ return null; }



        public override void Update(){ 


                // --- VERIFICA SE TEM QUE MUDAR TELA
                // *** fazer interface

                switch( update_tipo_atual ){

                        case BLOCK_INTERACTION__mode.connector: ;break;
                        
                }

                return;


        }

}