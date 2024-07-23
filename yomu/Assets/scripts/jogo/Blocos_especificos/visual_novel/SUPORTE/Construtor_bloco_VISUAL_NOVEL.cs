using UnityEngine;

public static class Construtor_bloco_VISUAL_NOVEL {
    

        public static BLOCO_visual_novel Construir( ){


                    // --- VERIFICAR SE O BLOCO JA NAO FOI CRIADO
                    if( BLOCO_visual_novel.instancia != null )
                        { throw new System.Exception( "Tentou iniciar o BLOCO_visual_novel mas a instancia não estava null" ); }


                    // --- TELA

                    BLOCO_visual_novel bloco = BLOCO_visual_novel.instancia;
                    BLOCO_visual_novel.instancia = bloco;


                        // --- FERRAMENTAS

                        bloco.leitor_visual_novel  = Leitor_visual_novel.Construir();
                        bloco.controlador_personagens_visual_novel = Controlador_personagens_visual_novel.Construir();
                        bloco.controlador_tela_visual_novel = Controlador_tela_visual_novel.Construir();
                        bloco.controlador_UI_visual_novel = new Controlador_UI_visual_novel();
                        bloco.bloqueador = new Bloqueador_cenas_visual_novel();

                        
                        // --- ACTIONS 

                        bloco.Mudar_UI = Visual_novel_mudar_UI.Default ; 
                        bloco.Mudar_input = Visual_novel_mudar_input.Default ; 
                        bloco.Lidar_retorno = Visual_novel_lidar_retorno.Default;

                        // *** isso deveria vir da req também 
                        bloco.Mudar_UI();
                        bloco.Mudar_input();




                        // --- INICIAR SCREEN PLAY

                        Visual_novel_START data_visual_novel_start = Dados_blocos.visual_novel_START;

                        if( data_visual_novel_start == null )
                        { throw new System.Exception( "nao veio os dados para iniciar visual novel" ); }

                        string  path_background_inicial =   data_visual_novel_start.path_background_inicial;
                        Nome_screen_play nome = data_visual_novel_start.nome_screen_play;

                
                        // --- TELA
                        
                        bloco.controlador_tela_visual_novel.Criar_tela();
                        bloco.controlador_tela_visual_novel.Mudar_background( _path: path_background_inicial , _tem_transicao:false , _foco: 0 , _id_cor: ( int ) Nome_cor.white ); 

                        
                        bloco.screen_play = Interpretador.Pegar_screen_play ( nome );

                        bloco.screen_play.path_background_atual = path_background_inicial;
                        bloco.screen_play.esta_ativo = true;

                        bloco.leitor_visual_novel.Ativar( bloco.screen_play );
                        
                    return bloco;

        }




}