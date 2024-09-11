using UnityEngine;

public static class Construtor_bloco_MINIGAMES {

    public static INTERFACE__bloco Construir( GameObject _container ){

            if ( BLOCO_minigames.instancia != null)
                { throw new System.Exception( "Tentou construir o BLOCO_minigames mas o bloco ja estava construido" ); }

            BLOCO_minigames bloco = new BLOCO_minigames();
            BLOCO_minigames.instancia = bloco;


                    Minigame_START dados_start = Dados_blocos.minigames_START;


                    // --- FUNCOES TRANSICOES BLOCOS DEFAULT

                    bloco.Finalizar = Minigames_finalizar_suporte.Finalizar_default;
                    bloco.Lidar_retorno = Minigames_lidar_retorno_suporte.Lidar_retorno_default;
                    bloco.Colocar_UI =  Minigames_colocar_UI_suporte.Colocar_UI_default;
                    bloco.Colocar_input = Minigames_colocar_input_suporte.Colocar_input_default;



                    if( dados_start != null )
                        {
                            // *** algo
                        }

                    // *** coisas

            return ( INTERFACE__bloco ) bloco;

    }

}