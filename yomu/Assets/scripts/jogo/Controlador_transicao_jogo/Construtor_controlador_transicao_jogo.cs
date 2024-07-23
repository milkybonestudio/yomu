using System;
using UnityEngine;
using UnityEngine.UI;


public static class Construtor_controlador_transicao_jogo {

    public static Controlador_transicao_jogo Construir( Jogo _jogo ){


            Controlador_transicao_jogo controlador = new Controlador_transicao_jogo(); 
            Controlador_transicao_jogo.instancia = controlador;

                controlador.jogo = _jogo;
                // ** talves eu nao use
                controlador.canvas_jogo =  GameObject.Find("Tela/Canvas/Jogo");


                controlador.coberta_canvas = GameObject.Find( "Tela/Canvas/Jogo/Coberta" );
                controlador.coberta_canvas_imagem     = controlador.coberta_canvas.GetComponent< Image >();
                
                                

                string[] blocos_nomes = Enum.GetNames( typeof( Bloco ) );


                controlador.blocos_transform = new Transform[ blocos_nomes.Length ];

                int ponto_inicial = ( int ) Bloco.conector ;
                
                for( int bloco_game_object_index = ponto_inicial ; bloco_game_object_index < blocos_nomes.Length  ; bloco_game_object_index++ ){

                        char[] nome_char = blocos_nomes[ bloco_game_object_index ].ToCharArray();
                        nome_char[ 0 ] = char.ToUpper( nome_char[ 0 ] );
                        string nome = new string ( nome_char );
                        
                        controlador.blocos_transform[ bloco_game_object_index ] = GameObject.Find( "Tela/Canvas/Jogo/" + nome ).transform;
                        continue;

                }

            return controlador;



    }


}