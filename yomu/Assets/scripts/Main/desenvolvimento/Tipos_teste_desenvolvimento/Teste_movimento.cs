using UnityEngine;
using System;
using System.Reflection;




public static class Teste_movimento {


        // ** criar ferramentas de suporte 

        public static void Criar( string _chave ){
                

                // mudar update jogo para movimento
                // ** definir os dados do teste 
                

                Jogo.Pegar_instancia().bloco_atual = Bloco.movimento;

                switch( _chave ){

                        case "lily_quarto" : Movimento_estado_generico.Ativar(); return;

                }

                // --- 
                
                Definir_estado_jogo_1();





        }

        


        public static void Definir_estado_jogo_1(){




        }


}