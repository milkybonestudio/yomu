


public static class Teste_cartas {



        public static void Criar( string _chave ){
                

                // mudar update jogo para movimento
                // ** definir os dados do teste 
                


                switch( _chave ){

                        case "generico" : Cartas_teste_estado_generico.Ativar(); break;

                }

                // --- DEAULT
                

                // --- INICIAR 

                Jogo.Pegar_instancia().bloco_atual = Bloco.cartas;
                BLOCO_cartas.Pegar_instancia().Iniciar_bloco_cartas();
                return;
         

        }





}