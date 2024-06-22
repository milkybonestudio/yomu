using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;

public static class Transicao_jogo_cor {



        public static IEnumerator Ativar ( Req_transicao _req ){

                Controlador_transicao_jogo controlador_transicao_jogo = Controlador_transicao_jogo.Pegar_instancia();

                GameObject game_object = controlador_transicao_jogo.coberta_canvas;
                Image game_object_imagem = controlador_transicao_jogo.coberta_canvas_imagem;


                game_object.SetActive( true );
                game_object_imagem.color = Color.clear;

                float a_dif = 0.01f;

                // mudar formato mara DeltaTime
                while( game_object_imagem.color.a <  0.98f){

                        game_object_imagem.color = new Color( 0f,0f,0f,  game_object_imagem.color.a + a_dif );
                        yield return null;

                }

                game_object_imagem.color = new Color( 0f,0f,0f,1f );
                

                controlador_transicao_jogo.Trocar_blocos( _req.novo_bloco  , _req.tipo_troca_bloco  ) ;

                // if( _req.bloco_para_excluir  !=  Bloco.nada )
                //     { Controlador_transicao_jogo.Pegar_instancia().Deletar_game_objects_bloco ( _req.bloco_para_excluir ) ; }



                
                a_dif = -0.01f;

                while(game_object_imagem.color.a > 0.5f){

                
                        game_object_imagem.color = new Color(0f,0f,0f,  game_object_imagem.color.a + a_dif );
                        yield return null;

                }                

                a_dif = -0.1f;
                while(game_object_imagem.color.a > 0.05f){

                        game_object_imagem.color = new Color(0f,0f,0f,  game_object_imagem.color.a + a_dif );
                        yield return null;

                }


                game_object_imagem.color = new Color(0f,0f,0f,0f);
                game_object.SetActive(false);
             
                controlador_transicao_jogo.coroutine_tela = null;
                
                yield break;

        }




}