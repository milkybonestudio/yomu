


public static class Teste_visual_novel {



        public static void Criar( string _chave ){
                

                // mudar update jogo para movimento
                // ** definir os dados do teste 




                switch( _chave ){

                        case "generico" : Visual_novel_teste_estado_generico.Ativar(); break;

                }


                // --- DEFAULT
                

                // --- INICIA VN
                Jogo.Pegar_instancia().bloco_atual = Bloco.visual_novel;
                BLOCO_visual_novel.Pegar_instancia().Iniciar_bloco_visual_novel();
                
                return;


        }





}