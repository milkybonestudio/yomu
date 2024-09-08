using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public static class Ativador_novo_jogo_menu {


        public static void Ativar_novo_jogo() {

                Menu menu = Menu.Pegar_instancia();

                #if UNITY_EDITOR

                    // *** ativar pelo menu vai funcionar somente na build
                    //return;

                #endif

                int save = Pegar_save_disponivel();

                if( save == -1 )
                    {
                        // *nao tem saves livres 
                        //mark
                        // *** ver deposi 
                        // Sistema_mensagens.Alertar_player( "nao tem saves disponivel" );
                        // nao deixa iniciar o jogo
                        
                        return; 

                    }


                Controlador.Pegar_instancia().jogo = Construtor_jogo.Construir();
                Task_req task_para_carregar = Primeiro_jogo_suporte.Pegar_task_criar_primeiro_jogo_default( _save: save , _novo_jogo: true  );
                Controlador_tasks.Pegar_instancia().Adicionar_task( task_para_carregar );


                Mono_instancia.Start_coroutine( novo_jogo_start_c() );

                IEnumerator novo_jogo_start_c(){

                    
                        GameObject game_object = new GameObject( "canvas_menu_transicao" );
                        Image imagem = IMAGE.Criar_imagem  (
                            
                                                                _game_object: game_object,
                                                                _pai : Controlador.Pegar_instancia().canvas,
                                                                _width: 1920f,
                                                                _height: 1080f,
                                                                _path : null,
                                                                _sprite: null,
                                                                _alpha: 0f

                                                            );



                        while( imagem.color[ 3 ] < 1f ){

                                float novo_alp = imagem.color[ 3 ] + (Time.deltaTime * 0.75f);
                                imagem.color = new Color( 0f,0f,0f , novo_alp );
                                yield return null;

                        }

                        while( true ){

                                if( task_para_carregar.finalizado )
                                    { break; }

                                continue;

                        }

                        

                        GameObject.Destroy( menu.controlador_tela_menu.canvas_menu );
                        Controlador.Pegar_instancia().menu = null;
                        Controlador.Pegar_instancia().modo_controlador_atual = Controlador_modo.jogo;


                        yield break;


                }


            int Pegar_save_disponivel(){

                // por hora sempre vai no 1
                return 1;

            }



    	}



    



}