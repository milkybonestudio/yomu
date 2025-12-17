using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;



  //fn logica_E_visual Visual( logica ){...}






public class Transicao_cor : INTERFACE__transition_request_visual {


        // --- INTERFACE

        public string Get_name(){ return "Transicao_cor"; }
        
        public Transition_plane transition_plane;
        public Transition_plane Get_transition_plane(){ return transition_plane; }



        public void Set_transition_space(){

                tela_image  =  IMAGE.Criar_imagem_filho ( 
                                                            _nome : "tela_cor",
                                                            _objeto: out tela,
                                                            _pai : controlador_transicao_jogo.canvas
                                                        );

                tela_image.color = Color.clear;
                return;

        }


        // --- DADOS
        public CONTROLLER__game_transition controlador_transicao_jogo = CONTROLLER__game_transition.Get_instance();
        public GameObject tela;
        public Image tela_image;



        // --- ANIMACOES

        public IEnumerator Get_down_IE(){

                // --- COMECA A MOSTRAR O BLOCO
                yield return Mono_instancia.Start_coroutine( IMAGE.Get_IEn_change_alpha_image( _image: tela_image, _alpha_destino: 0.5f, _tempo_ms: 60f ) );
                yield return Mono_instancia.Start_coroutine( IMAGE.Get_IEn_change_alpha_image( _image: tela_image, _alpha_destino: 0f, _tempo_ms: 60f ) );

                yield break;

        }

        
        public IEnumerator Get_waiting_task_to_finish(){ yield break;}

        public IEnumerator Get_hide_IE(){

                
                // ** tem que ver o tempo certinho
                yield return Mono_instancia.Start_coroutine( IMAGE.Get_IEn_change_alpha_image( _image: tela_image, _alpha_destino: 0.5f, _tempo_ms: 60f ) );
                yield return Mono_instancia.Start_coroutine( IMAGE.Get_IEn_change_alpha_image( _image: tela_image, _alpha_destino: 1f, _tempo_ms: 60f ) );

                yield break;

                
        }





}