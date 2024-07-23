

public static class Construtor_bloco_UTILIDADES {

        public static BLOCO_utilidades Construir(){

            if ( BLOCO_utilidades.instancia != null)
                { throw new System.Exception( "Tentou construir o BLOCO_utilidades mas o bloco ja estava construido" ); }

            BLOCO_utilidades bloco = new BLOCO_utilidades();
            BLOCO_utilidades.instancia = bloco;




                    // --- FUNCOES TRANSICOES BLOCOS DEFAULT

                    // bloco.Finalizar = Minigames_finalizar_suporte.Finalizar_default;
                    // bloco.Lidar_retorno = Minigames_lidar_retorno_suporte.Lidar_retorno_default;
                    // bloco.Colocar_UI =  Minigames_colocar_UI_suporte.Colocar_UI_default;
                    // bloco.Colocar_input = Minigames_colocar_input_suporte.Colocar_input_default;


                    // *** coisas

            return bloco;

    }

}