using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;

public static class Transicao_jogo_instantania {


        public static void Ativar ( Req_transicao _req ){


                Controlador_transicao_jogo controlador = Controlador_transicao_jogo.Pegar_instancia();
                GameObject game_object = controlador.transicao_canvas;
                Image game_object_imagem = controlador.transicao_canvas_imagem;
                
                game_object_imagem.color = new Color( 0f, 0f, 0f, 1f );
                game_object.SetActive( false );

                controlador.Trocar_blocos( _req.novo_bloco, _req.tipo_troca_bloco  ) ;

                return;

        }


}