using UnityEngine;

public static class Construtor_bloco_STORY {
    

        public static INTERFACE__bloco Construir( GameObject _container ){


                    // --- VERIFICAR SE O BLOCO JA NAO FOI CRIADO
                    if( BLOCO_story.instancia != null )
                        { throw new System.Exception( "Tentou iniciar o BLOCO_story mas a instancia não estava null" ); }


                    // --- TELA

                    BLOCO_story bloco = BLOCO_story.instancia;
                    BLOCO_story.instancia = bloco;


                        // --- FERRAMENTAS

                        bloco.leitor_visual_novel  = Leitor_visual_novel.Construir();
                        bloco.controlador_personagens_visual_novel = Controlador_personagens_visual_novel.Construir();
                        bloco.controlador_tela_story = Controlador_tela_story.Construir( _container );
                        bloco.controlador_UI_visual_novel = new Controlador_UI_visual_novel();
                        bloco.bloqueador = new Bloqueador_cenas_visual_novel();



                        //mark
                        // precisa pegar do save se tem algum
                        
                        // // --- ACTIONS 

                        // bloco.Mudar_UI = Visual_novel_mudar_UI.Default ; 
                        // bloco.Mudar_input = Visual_novel_mudar_input.Default ; 
                        // bloco.Lidar_retorno = Visual_novel_lidar_retorno.Default;

                        // // *** isso deveria vir da req também 
                        // bloco.Mudar_UI();
                        // bloco.Mudar_input();

                        
                    return ( INTERFACE__bloco ) bloco;

        }




}