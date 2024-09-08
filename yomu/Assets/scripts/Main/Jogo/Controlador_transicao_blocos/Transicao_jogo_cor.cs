using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;





public class Transicao_jogo_cor : INTERFACE__transition_blocks {


        public Tipo_transicao Get_transition_type(){ return Tipo_transicao.cor; }
        
        public IEnumerator Get_transition_IE ( Req_transicao _req ){

                Controlador_transicao_jogo controlador_transicao_jogo = Controlador_transicao_jogo.Pegar_instancia();

                GameObject game_object = controlador_transicao_jogo.coberta_canvas;
                Image game_object_imagem = controlador_transicao_jogo.coberta_canvas_imagem;
                INTERFACE__bloco interface_bloco = Jogo.Pegar_instancia().interfaces_blocos[ ( int ) _req.novo_bloco ];


                game_object.SetActive( true );
                game_object_imagem.color = Color.clear;

                float a_dif = 0.01f;

                // mudar formato mara DeltaTime
                while( game_object_imagem.color.a <  0.98f){

                        game_object_imagem.color = new Color( 0f,0f,0f,  game_object_imagem.color.a + a_dif );
                        yield return null;

                }

                // *** 100% black
                game_object_imagem.color = new Color( 0f,0f,0f,1f );

                
                Task_req req_dados = interface_bloco.Carregar_dados();

                // *** prioridade maxima
                req_dados.prioridade = 1;

                if( req_dados != null )
                    {
                        // --- TEM DADOS PARA CARREGAR

                        float tempo_carregando_ms = 0f;

                        while( true ){

                            tempo_carregando_ms += Time.deltaTime * 1000f;
                            if( tempo_carregando_ms > 10_000f )
                                { throw new Exception( $"Tempo para carregar dados passou de 10 segundo. Wtf?" ); }

                            //mark
                            // ** depois fazer animacao aqui dentro

                            // animacao** 

                            if( req_dados.finalizado )
                                { break; }

                            yield return null;

                        }


                    }

            
                controlador_transicao_jogo.Trocar_blocos( _req.novo_bloco  , _req.tipo_troca_bloco  ) ;

                yield return null;

                
                // --- COMECA A MOSTRAR O BLOCO
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


                // --- FINALIZA TRANSICAO
                game_object_imagem.color = new Color( 0f, 0f, 0f, 0f );
                game_object.SetActive( false );
                controlador_transicao_jogo.coroutine_tela = null;


                // --- ATIVA O NOVO MODO

                controlador_transicao_jogo.em_transicao = false;
                Jogo.Pegar_instancia().bloco_atual = _req.novo_bloco;

                
                yield break;

        }




}