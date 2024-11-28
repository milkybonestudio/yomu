

public static class Finalizador_CONECTOR {

    public static void Finalizar(){


            Interaction_RETURN interaction_return = Dados_blocos.interaction_RETURN;

            string exit_mode = interaction_return.exit_mode;

            if( exit_mode == "menu" )
                {
                    // --- VOLTAR PARA O MENU
                }

            if( exit_mode == "sair_jogo" )
                {
                    // --- SAI DO JOGO 
                }

            

            // --- SEMPRE 


            Controlador_interativos.instancia = null;
            Controlador_tela_conector.instancia = null;
            CONTROLLER__input.instancia = null;
            CONTROLLER__data.instancia = null;

            
            return;

    }

}