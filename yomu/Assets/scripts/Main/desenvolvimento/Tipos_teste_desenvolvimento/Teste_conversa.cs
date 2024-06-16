


public static class Teste_conversa {



        public static void Criar( string _chave ){
                

                // mudar update jogo para movimento
                // ** definir os dados do teste 
                

                Jogo.Pegar_instancia().bloco_atual = Bloco.conversa;

                switch( _chave ){

                        case "generico" : Conversa_estado_generico.Ativar(); return;

                }

                // --- DEFAULT
                


        }





}