


public static class Finalizador_jogo {

        public static void Finalizar( Pedido_para_finalizar _pedido ){

                BLOCO_interacao.instancia = null;
                BLOCO_story.instancia = null;
                BLOCO_cartas.instancia = null;
                BLOCO_minigames.instancia = null;

        }

}
