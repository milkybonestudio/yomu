using UnityEngine;

public static class Construtor_bloco_STORY {
    

        public static Block Construir( GameObject _container ){


                    // --- VERIFICAR SE O BLOCO JA NAO FOI CRIADO
                    if( BLOCO_story.instancia != null )
                        { CONTROLLER__errors.Throw( "Tentou iniciar o BLOCO_story mas a instancia não estava null" ); }


                    // --- TELA

                    //????????????????????????????????????????????????????????????
                    BLOCO_story bloco = new BLOCO_story();
                    BLOCO_story.instancia = bloco;

                        // --- FERRAMENTAS

                        bloco.leitor_visual_novel  = Leitor_visual_novel.Construir();
                        bloco.controlador_personagens_visual_novel = Controlador_personagens_visual_novel.Construir();
                        bloco.controlador_tela_story = Controlador_tela_story.Construir( _container );
                        bloco.controlador_UI_visual_novel = new Controlador_UI_visual_novel();
                        bloco.bloqueador = new Bloqueador_cenas_visual_novel();

                        
                    return ( Block ) bloco;

        }




}