using System;


public static class Teste_story {



        public static void Criar( string _chave ){
                

                Chamar_classes_teste( _chave, "estado" );

                // --- INICIA VN
                Jogo.Pegar_instancia().bloco_atual = Bloco.story;
                Jogo.Pegar_instancia().interfaces_blocos[ ( int ) Bloco.story ] =   Construtor_bloco_STORY.Construir( null );   //  Construtor_bloco_VISUAL_NOVEL.Construir();

                Chamar_classes_teste( _chave, "script_inicial" );

                return;
                
        }

        

        public static void Chamar_classes_teste( string _chave , string _modelo ){

                switch( _chave ){

                        case "generico" : Visual_novel_teste_estado_generico.Ativar( _modelo ); break;
                        default : UnityEngine.Debug.LogError( $"<b><coler=red>nao</color></b> foi achado a <b><color=white>CHAVE: \"{ _chave }\"</color></b> em testar <b><color=lime>VISUAL NOVEL</color></b>" ); throw new System.Exception();

                }

                

        }






}