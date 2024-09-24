using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine;


public static class Ativador_novo_jogo_menu {


        public static void Ativar_novo_jogo() {

                Menu menu = Menu.Pegar_instancia();

                #if UNITY_EDITOR

                    // *** ativar pelo menu vai funcionar somente na build
                    //return;

                #endif

                int save = Pegar_save_disponivel();

                if( save == -1 )
                    { Console.Log( "nao tem saves disponivel" ); return; } // *nao tem saves livres 


                Task_req task_para_carregar =   Primeiro_jogo_suporte.Pegar_task_criar_primeiro_jogo_default( save );

                CONTROLLER__tasks.Pegar_instancia().Adicionar_task( task_para_carregar );

                Mono_instancia.Start_coroutine( Start_new_game_animation( task_para_carregar ) );





    	}


        
        public static int Pegar_save_disponivel(){

            // por hora sempre vai no 1
            return 1;

        }


        private static IEnumerator Start_new_game_animation( Task_req _task_req ){

                    
                GameObject canvas = new GameObject( "canvas_menu_transicao" );

                Image imagem = IMAGE.Criar_imagem  (
                    
                                                        _game_object: canvas,
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

                        if( _task_req.finalizado )
                            { break; }

                        continue;

                }

                Menu.instancia.Finalizar();
                yield break;


        }




    



}