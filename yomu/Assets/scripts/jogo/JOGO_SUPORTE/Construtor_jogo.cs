using UnityEngine;

public static class Construtor_jogo{

        public static Jogo Construir(){

                // ** coisas que interagem com o canvas nao podem ser usados na multitrhead 
                //    entao tem que ser criados aqui
                
                // jogo vai criar o canvas do jogo e os objetos necessarios

                Jogo jogo = new Jogo(); 
                Jogo.instancia = jogo;
                        
                        jogo.canvas = GameObject.Find( "Tela/Canvas" );
                        jogo.canvas_3d = GameObject.Find( "Canvas_3d" );
                        GameObject jogo_canvas = new GameObject( "Jogo" );
                        jogo_canvas.transform.SetParent( jogo.canvas.transform, false );

                        Controlador_UI.Construir();

                        // --- TRANSICAO TEM QUE FICAR NA FRENTE
                        Construtor_controlador_transicao_jogo.Construir( jogo );

                return jogo;
                

        }

        
}