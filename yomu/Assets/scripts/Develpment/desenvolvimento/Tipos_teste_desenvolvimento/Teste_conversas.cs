using System;


public static class Teste_conversas {



        // ** criar ferramentas de suporte 

        public static void Criar( string _chave ){
                

                Chamar_classes_teste( _chave, "estado" );

                Jogo.Pegar_instancia().bloco_atual = Bloco.conversas;
                Jogo.Pegar_instancia().bloco_conversas =  BLOCO_conversas.Iniciar_bloco_conversas();

                Chamar_classes_teste( _chave, "script_inicial" );

                return;
                
        }

        

        public static void Chamar_classes_teste( string _chave , string _modelo ){

                switch( _chave ){

                        case "generico" : Conector_teste_estado_generico.Ativar( _modelo ); break;
                        default : UnityEngine.Debug.LogError( $"<b><coler=red>nao</color></b> foi achado a <b><color=white>chave: \"{ _chave }\"</color></b> em testar <b><color=lime>conector</color></b>" ); throw new System.Exception();

                }

                
        }



}