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
                BLOCO_conector.Pegar_instancia().Iniciar_bloco_conector();
                return;
                

        }



}