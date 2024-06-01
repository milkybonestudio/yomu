using System;
using UnityEngine;
using UnityEngine.UI;


public static class Plot_scripts_jogo_1 {


    public static void NARA_INTRODUCAO_bilhete() {

            
            Controlador_dados_dinamicos.Pegar_instancia().lista_navegacao.Remover_interativo_para_acrescentar(  Ponto_nome.MESA_quarto_nara , new int[ 1 ] , Interativo_nome.CARTA_DIA_mesa_quarto_nara  );
            Scripts_jogo.Iniciar_screen_play( Nome_screen_play.NARA_INTRODUCAO_carta_dia );


    }


}