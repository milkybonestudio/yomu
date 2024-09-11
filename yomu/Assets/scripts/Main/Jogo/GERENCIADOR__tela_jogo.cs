using UnityEngine;



public class GERENCIADOR__tela_jogo {


        public GERENCIADOR__tela_jogo(){

                
                canvas = GameObject.Find( "Tela/Canvas" );
                canvas_3d = GameObject.Find( "Canvas_3d" );


                story_block_container = GameObject.Find( "Tela/Canvas/Blocks/Story_container" );
                minigames_block_container = GameObject.Find( "Tela/Canvas/Blocks/Minigames_container" );
                cards_block_container = GameObject.Find( "Tela/Canvas/Blocks/Cards_container" );
                interaction_block_container = GameObject.Find( "Tela/Canvas/Blocks/Interaction_container" );


        }

        public GameObject canvas;
        public GameObject canvas_3d;

        public GameObject story_block_container;
        public GameObject minigames_block_container;
        public GameObject cards_block_container;
        public GameObject interaction_block_container;

}