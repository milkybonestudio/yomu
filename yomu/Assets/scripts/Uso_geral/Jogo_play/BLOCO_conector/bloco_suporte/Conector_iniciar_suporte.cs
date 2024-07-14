using UnityEngine;


public static class Conector_iniciar_suporte {

    public static void Iniciar( ){

                // --- TELA

                BLOCO_conector bloco = BLOCO_conector.instancia;

                bloco.container_conector = GameObject.Find( "Tela/Canvas/Jogo/Conector" );


                // -- CONTROLADORES

                bloco.controlador_tela_conector = Controlador_tela_conector.Construir();
                bloco.controlador_interativos = Controlador_interativos.Construir();
                bloco.controlador_movimento = Controlador_movimento.Construir();

                bloco.controlador_cursor = Controlador_cursor.Pegar_instancia();
                bloco.controlador_dados = Controlador_dados.Pegar_instancia();



                // --- COISAS
                bloco.posicao_mouse = bloco.controlador_dados.posicao_mouse;
                bloco.player_estado_atual = Player_estado_atual.Pegar_instancia();


                // --- UI / INPUT / RETORNO

                bloco.Colocar_UI_atual = Colocar_UI_bloco_conector.Default ;
                bloco.Colocar_input_atual  = Colocar_input_bloco_conector.Default ;
                bloco.Lidar_retorno = Lidar_retorno_bloco_conector.Default;

                // ** talves colocar na req
                bloco.Colocar_UI_atual();
                bloco.Colocar_input_atual();

                // INICIAR 

                Conector_START dados = Dados_blocos.conector_START;

                if( dados == null )
                        { throw new System.Exception( "nao veio os dados para iniciar conector" ); }

                
                // ** trocar depois
                bloco.controlador_interativos.Criar_interativos( new Ponto() );
                //controlador_interativos.Criar_interativos( player_estado_atual.ponto_atual );


                return;
    }

}