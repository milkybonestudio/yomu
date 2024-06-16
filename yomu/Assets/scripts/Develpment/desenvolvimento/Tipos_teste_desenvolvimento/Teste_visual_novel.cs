


public static class Teste_visual_novel {



        public static void Criar( string _chave ){
                

                // mudar update jogo para movimento
                // ** definir os dados do teste 
                

                Jogo.Pegar_instancia().bloco_atual = Bloco.visual_novel;

                BLOCO_visual_novel.Pegar_instancia().Iniciar_visual_novel();

                switch( _chave ){

                        case "lily_quarto" : Visual_novel_estado_generico.Ativar(); return;

                }

                // --- DEFAULT
                




        }





}