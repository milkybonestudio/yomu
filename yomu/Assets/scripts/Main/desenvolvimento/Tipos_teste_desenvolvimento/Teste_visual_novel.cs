


public static class Teste_movimento {



        public static void Criar( string _chave ){
                

                // mudar update jogo para movimento
                // ** definir os dados do teste 
                

                Jogo.Pegar_instancia().bloco_atual = Bloco.visual_novel;

                switch( _chave ){

                        case "lily_quarto" : Definir_estado_jogo_1(); return;

                }

                // --- 
                
                Definir_estado_jogo_1();





        }





}