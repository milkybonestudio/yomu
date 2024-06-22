using UnityEngine;
using System;
using System.Reflection;




public static class Teste_conector {


        // ** criar ferramentas de suporte 

        public static void Criar( string _chave ){
                


                switch( _chave ){

                        case "generico" : Conector_teste_estado_generico.Ativar(); break;
                        default : throw new System.Exception( $"<b><coler=red>nao</color></b> foi achado a <b><color=white>chave: \"{ _chave }\"</color></b> em testar <b><color=lime>conector</color></b>");

                }

                // --- Iniciar

                Jogo.Pegar_instancia().bloco_atual = Bloco.conector;
                Jogo.Pegar_instancia().bloco_conector =  BLOCO_conector.Iniciar_bloco_conector();
                return;
                

        }



}