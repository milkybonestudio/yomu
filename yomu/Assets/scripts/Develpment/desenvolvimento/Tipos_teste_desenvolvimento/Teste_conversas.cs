


public static class Teste_conversas {



        public static void Criar( string _chave ){
                

                // mudar update jogo para movimento
                // ** definir os dados do teste 
                


                switch( _chave ){

                        case "generico" : Conversas_teste_estado_generico.Ativar(); break;
                        default : throw new System.Exception( $"nao foi achado a <b><color=white>chave: \"{ _chave }\"</color></b> em testar <b><color=lime>conversas</color></b>");

                }

                // --- DEFAULT


                // --- INICIA 
                
                Jogo.Pegar_instancia().bloco_atual = Bloco.conversas;
                Jogo.Pegar_instancia().bloco_conversas = BLOCO_conversas.Iniciar_bloco_conversas();
                return;


        }





}