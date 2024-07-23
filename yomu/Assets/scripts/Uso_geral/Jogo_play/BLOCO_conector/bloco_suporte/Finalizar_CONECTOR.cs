

public static class Finalizador_CONECTOR {

    public static void Finalizar(){

            string[] finalizar_localizador = Dados_blocos.conector_finalizar_localizador;

            if( finalizar_localizador == null )
                { throw new System.Exception( $"Nao foi colocado o finalizar do conector" ); }

            string modo = finalizar_localizador[ 0 ];

            if( modo == "menu" )
                {
                    // --- VOLTAR PARA O MENU
                }

            if( modo == "sair_jogo" )
                {
                    // --- SAI DO JOGO 
                }

            

            // --- SEMPRE 

            BLOCO_conector.instancia = null;

            Controlador_interativos.instancia = null;
            Controlador_tela_conector.instancia = null;
            Controlador_cursor.instancia = null;
            Controlador_dados.instancia = null;

            
            return;

    }

}