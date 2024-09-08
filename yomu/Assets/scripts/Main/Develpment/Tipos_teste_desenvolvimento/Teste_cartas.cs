


public static class Teste_cartas {




        // ** criar ferramentas de suporte 

        public static void Criar( string _chave ){
                

                Chamar_classes_teste( _chave, "estado" );

                // --- INICIAR 

                Jogo.Pegar_instancia().bloco_atual = Bloco.cartas;
                Jogo.Pegar_instancia().interfaces_blocos[ ( int ) Bloco.cartas ] =  Construtor_bloco_CARTAS.Construir(); // BLOCO_cartas.Iniciar_bloco_cartas();

                Chamar_classes_teste( _chave, "script_inicial" );

                return;
                
        }

        

        public static void Chamar_classes_teste( string _chave , string _modelo ){

                switch( _chave ){

                        case "generico" : Cartas_teste_estado_generico.Ativar( _modelo ); break;
                        default : UnityEngine.Debug.LogError($"nao foi achado a <b><color=white>chave: \"{ _chave }\"</color></b> em testar <b><color=lime>cartas</color></b>"); throw new System.Exception( );

                }

                

        }








}