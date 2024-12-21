

public static class Construtor_bloco_CONVERSAS {

        public static Block Construir(){

            if ( BLOCO_conversas.instancia != null)
                { throw new System.Exception( "Tentou construir o BLOCO_conversas mas o bloco ja estava construido" ); }

            BLOCO_conversas bloco = new BLOCO_conversas();
            BLOCO_conversas.instancia = bloco;




                    // --- FUNCOES TRANSICOES BLOCOS DEFAULT

                    // bloco.Finalizar = Minigames_finalizar_suporte.Finalizar_default;
                    // bloco.Lidar_retorno = Minigames_lidar_retorno_suporte.Lidar_retorno_default;
                    // bloco.Colocar_UI =  Minigames_colocar_UI_suporte.Colocar_UI_default;
                    // bloco.Colocar_input = Minigames_colocar_input_suporte.Colocar_input_default;


                    // *** coisas

            return ( Block ) bloco;

    }

}