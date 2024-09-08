using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Transicao_jogo_instantania : INTERFACE__transition_blocks {

        public Tipo_transicao Get_transition_type(){ return Tipo_transicao.instantaneo; }
        public IEnumerator Get_transition_IE ( Req_transicao _req ){

                
                Controlador_transicao_jogo controlador = Controlador_transicao_jogo.Pegar_instancia();
                GameObject game_object = controlador.coberta_canvas;
                Image game_object_imagem = controlador.coberta_canvas_imagem;
                
                game_object_imagem.color = new Color( 0f, 0f, 0f, 1f );
                game_object.SetActive( false );

                controlador.Trocar_blocos( _req.novo_bloco, _req.tipo_troca_bloco  ) ;

                yield break;

        }


}