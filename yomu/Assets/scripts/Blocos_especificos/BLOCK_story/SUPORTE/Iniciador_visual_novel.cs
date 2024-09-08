


public static class Iniciador_visual_novel {


        public static void Iniciar( BLOCO_story bloco ){


                // --- INICIAR SCREEN PLAY

                Story_START data_visual_novel_start = Dados_blocos.story_START;

                if( data_visual_novel_start == null )
                { throw new System.Exception( "nao veio os dados para iniciar visual novel" ); }

                string  path_background_inicial =   data_visual_novel_start.path_background_inicial;

                //mark
                // tem que mudar
                Nome_screen_play nome = data_visual_novel_start.nome_screen_play;
                

        
                // --- TELA
                
                bloco.controlador_tela_story.Criar_tela();
                bloco.controlador_tela_story.Mudar_background( _path: path_background_inicial , _tem_transicao:false , _foco: 0 , _id_cor: ( int ) Nome_cor.white ); 

                
                bloco.screen_play = Interpretador.Pegar_screen_play ( nome );

                bloco.screen_play.path_background_atual = path_background_inicial;
                bloco.screen_play.esta_ativo = true;

                bloco.leitor_visual_novel.Ativar( bloco.screen_play );




        }


}