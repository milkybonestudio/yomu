using UnityEngine;

public static class Construtor_jogo{

        public static Jogo Construir(){

                // ** coisas que interagem com o canvas nao podem ser usados na multitrhead 
                //    entao tem que ser criados aqui
                
                // jogo vai criar o canvas do jogo e os objetos necessarios

                Jogo jogo = new Jogo(); 
                        
                        jogo.canvas = GameObject.Find( "Tela/Canvas" );
                        jogo.canvas_3d = GameObject.Find( "Canvas_3d" );
                        GameObject jogo_canvas = new GameObject( "Jogo" );
                        jogo_canvas.transform.SetParent( jogo.canvas.transform, false );


                        // --- BLOCOS

                        jogo.interfaces_blocos = new INTERFACE__bloco[ 20 ];

                        jogo.interfaces_blocos[ ( int ) Bloco.interacao ]     =  Construtor_bloco_INTERACAO.Construir();
                        jogo.interfaces_blocos[ ( int ) Bloco.story ] = Construtor_bloco_STORY.Construir();

                        jogo.interfaces_blocos[ ( int ) Bloco.minigames ]    = Construtor_bloco_MINIGAMES.Construir();
                        jogo.interfaces_blocos[ ( int ) Bloco.cartas ]       = Construtor_bloco_CARTAS.Construir();


                        // --- TRANSICAO TEM QUE FICAR NA FRENTE
                        Construtor_controlador_transicao_jogo.Construir( jogo );


                Jogo.instancia = jogo;
                return jogo;
                

        }

        
}