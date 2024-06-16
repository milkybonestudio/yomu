


public static class Teste_cartas {



        public static void Criar( string _chave ){
                

                // mudar update jogo para movimento
                // ** definir os dados do teste 
                

                Jogo.Pegar_instancia().bloco_atual = Bloco.cartas;

                switch( _chave ){

                        case "generico" : Cartas_estado_generico.Ativar(); return;

                }

                // --- DEAULT
                
                return;
         

        }





}