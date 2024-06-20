using UnityEngine;
using System;
using System.Reflection;




public static class Teste_conector {


        // ** criar ferramentas de suporte 

        public static void Criar( string _chave ){
                


                switch( _chave ){

                        case "generico" : Conector_teste_estado_generico.Ativar(); break;

                }

                // --- DEFAULT
                
                // --- Iniciar

                Jogo.Pegar_instancia().bloco_atual = Bloco.conector;
                Jogo.Pegar_instancia().bloco_conector =  BLOCO_conector.Iniciar_bloco_conector();
                return;
                

        }



}