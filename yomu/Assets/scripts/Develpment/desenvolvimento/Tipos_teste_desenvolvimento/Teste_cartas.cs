


public static class Teste_cartas {



        public static void Criar( string _chave ){
                

                // mudar update jogo para movimento
                // ** definir os dados do teste 
                


                switch( _chave ){

                        case "generico" : Cartas_teste_estado_generico.Ativar(); break;
                        default : throw new System.Exception( $"nao foi achado a <b><color=white>chave: \"{ _chave }\"</color></b> em testar <b><color=lime>cartas</color></b>");

                }

                // --- INICIAR 


                Jogo.Pegar_instancia().bloco_atual = Bloco.cartas;
                Jogo.Pegar_instancia().bloco_cartas = BLOCO_cartas.Iniciar_bloco_cartas();
                
                return;
         

        }





}