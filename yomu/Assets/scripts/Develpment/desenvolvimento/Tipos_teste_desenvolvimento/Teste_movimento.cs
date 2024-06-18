using UnityEngine;
using System;
using System.Reflection;




public static class Teste_movimento {


        // ** criar ferramentas de suporte 

        public static void Criar( string _chave ){
                


                switch( _chave ){

                        case "generico" : Movimento_teste_estado_generico.Ativar(); break;

                }

                // --- DEFAULT
                
                // --- Iniciar

                Jogo.Pegar_instancia().bloco_atual = Bloco.movimento;
                BLOCO_movimento.Pegar_instancia().Iniciar_bloco_movimento();
                return;
                

        }



}