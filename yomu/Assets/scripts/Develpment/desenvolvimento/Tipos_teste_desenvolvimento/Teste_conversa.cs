


public static class Teste_conversa {



        public static void Criar( string _chave ){
                

                // mudar update jogo para movimento
                // ** definir os dados do teste 
                


                switch( _chave ){

                        case "generico" : Conversa_teste_estado_generico.Ativar(); break;

                }

                // --- DEFAULT


                // --- INICIA 
                
                Jogo.Pegar_instancia().bloco_atual = Bloco.conversa;
                BLOCO_conversas.Pegar_instancia().Iniciar_bloco_conversa();
                return;


        }





}