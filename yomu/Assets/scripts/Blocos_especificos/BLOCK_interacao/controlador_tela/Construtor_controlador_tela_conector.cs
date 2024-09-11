using UnityEngine;


public static class Construtor_controlador_tela_conector{

        public static Controlador_tela_conector Construir( GameObject _container ){

                Controlador_tela_conector controlador = new Controlador_tela_conector();
                Controlador_tela_conector.instancia = controlador;


                        controlador.container_conector = _container;

                        controlador.posicao_mouse = Controlador_dados.Pegar_instancia().posicao_mouse;
                        controlador.controlador_interativos = Controlador_interativos.Pegar_instancia();
                        controlador.controlador_cursor = Controlador_cursor.Pegar_instancia();
                        controlador.player_estado_atual = Player_estado_atual.Pegar_instancia();

                        // ---CRIAR TELA

                        Construtor_tela_conector.Criar_tela( controlador );

                        // --- PEGAR LOCALIZADORES

                        // byte[] localizador_interativos = Paths_sistema.path_localizador_interativos;
                        // byte[] localizador_backgrounds = Paths_sistema.path_localizador_interativos;

                        controlador.gerenciador_imagens_background_conector = new Gerenciador_imagens_background_conector();
                        controlador.gerenciador_imagens_interativos = new Gerenciador_imagens_interativos( );

                return controlador;

            
        }

}