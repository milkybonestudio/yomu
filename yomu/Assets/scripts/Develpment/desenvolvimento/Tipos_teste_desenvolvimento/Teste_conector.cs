using UnityEngine;
using System;
using System.Reflection;




public static class Teste_conector {


        // ** criar ferramentas de suporte 

        public static void Criar( string _chave ){
                

                Ativer_estado( _chave );

                Jogo.Pegar_instancia().bloco_atual = Bloco.conector;
                Jogo.Pegar_instancia().bloco_conector =  BLOCO_conector.Iniciar_bloco_conector();

                Ativar_script_inicial( _chave );
                
                return;
                

        }


        public static void Ativer_estado( string _chave ){
                
                Chamar_classes_teste( _chave, "estado" );
                return;

        }

        public static void Ativar_script_inicial( string _chave ){

                Chamar_classes_teste( _chave, "script_inicial" );
                return;

        }


        public static void Chamar_classes_teste( string _chave , string _modelo ){



                switch( _chave ){

                        case "generico" : Conector_teste_estado_generico.Ativar( _modelo ); break;
                        default : Console.LogError( $"<b><coler=red>nao</color></b> foi achado a <b><color=white>chave: \"{ _chave }\"</color></b> em testar <b><color=lime>conector</color></b>" ); throw new System.Exception();

                }

                

        }



}