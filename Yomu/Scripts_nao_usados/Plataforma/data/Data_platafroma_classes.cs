using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;




public class Controlador_background_plataforma {

        public string[] nomes_imagens = null;
        public string[] paths_imagens = null;

        public float[][] posicoes_referencia = null;
        public float[] distancias_para_ativar = null;
        public float[] distancia_para_ativar_quadrado = null; 



        public string[] nome_imagem_atual = null;
        public string[] path_atual = null;

        public float[] posicao_referencia_atual = null;
        public float[] distancia_para_ativar_atual = null;

        public GameObject plano_de_fundo_container = null;


        public GameObject plano_de_fundo_game_object = null;
        public GameObject plano_de_fundo_transicao_game_object = null;

        public Image plano_de_fundo_imagem_slot = null;
        public Image plano_de_fundo_transicao_imagem_slot = null;


        public Coroutine background_coroutine = null;


        public float[] posicao_player = null;


        public void Atualizar_background(){

            
            int numero_backgrounds = this.nomes_imagens.Length;

            float player_position_x = this.posicao_player[0];
            float player_position_y = this.posicao_player[1];

            float position_x_background = 0f;
            float position_y_background = 0f;

            float d_x = 0f;
            float d_y = 0f;

            bool ver = false;

            float distancia_para_ativar_quadrado = 0f;
                
            
            for(   int background_teste = 0 ;   background_teste < numero_backgrounds  ; background_teste++   ){


                    position_x_background = this.posicoes_referencia[  background_teste  ][0];
                    position_y_background = this.posicoes_referencia[  background_teste  ][1];

                    d_x = position_x_background - player_position_x;
                    d_y = position_y_background - player_position_y;

                    distancia_para_ativar_quadrado = this.distancia_para_ativar_quadrado [  background_teste  ];

                    ver = (  d_x * d_x + d_y * d_y ) < distancia_para_ativar_quadrado;

                    if(   ver   ) {Trocar_background( background_teste ); return;}
                    


            }


            return;


        }


        
        public void Trocar_background(int _id_background){



            /// Aumentar_distancia do selecionado talvez ciclos?

            if(background_coroutine != null) {
                Mono_instancia.Stop_coroutine( background_coroutine );

                this.plano_de_fundo_imagem_slot.sprite = this.plano_de_fundo_transicao_imagem_slot.sprite;
                this.plano_de_fundo_imagem_slot.color = new Color(1f,1f,1f,1f);

                this.plano_de_fundo_transicao_imagem_slot.sprite = null;
                this.plano_de_fundo_transicao_imagem_slot.color = new Color(1f,1f,1f,0f);
                
            }

            this.background_coroutine = Mono_instancia.Start_coroutine(  Trocar_background_c(_id_background) );

            return;


        }


        public void Colocar_valores(){

            BLOCO_plataforma plataforma = BLOCO_plataforma.Pegar_instancia();


            this.plano_de_fundo_container = new GameObject("platafroma_background_container");
            this.plano_de_fundo_container.transform.SetParent(plataforma.background.transform, false);


            

            this.plano_de_fundo_game_object = Geral.Criar_imagem("Plataforma_background", this.plano_de_fundo_container);
            this.plano_de_fundo_imagem_slot = Geral.ultima_imagem;
            this.plano_de_fundo_imagem_slot.color = Color.black;
            

            this.plano_de_fundo_transicao_game_object = Geral.Criar_imagem("Plataforma_background_transicao", this.plano_de_fundo_container );
            this.plano_de_fundo_transicao_imagem_slot = Geral.ultima_imagem;
            


            this.posicao_player = plataforma.controlador_player.player_atual.fisica.position;



        }

        public IEnumerator Trocar_background_c(int _id_background){

            string path = this.paths_imagens[ _id_background ];
            string path_completo = "images/plataforma/backgrounds/" + path;

            
            Sprite novo_background = Resources.Load<Sprite>( path_completo );
            if(novo_background == null){ throw new ArgumentException("nao foi achado imagem no path: " +  path_completo + ". nome: " + this.nomes_imagens[ _id_background ]);}

            this.plano_de_fundo_transicao_imagem_slot.sprite = novo_background;

            
            float tempo_ms = 200f;

            float ciclos_float = ( (tempo_ms / 1000f) * 60f);

            float d_alpha = 1f / ciclos_float;
            int ciclos =  (int) ciclos_float;
            int ciclo_atual = 0;

            float aplha_acumulado = 0f;
            
            while( ciclo_atual < ciclos  ){

                    ciclo_atual++;

                    aplha_acumulado += d_alpha;
                    this.plano_de_fundo_transicao_imagem_slot.color =  new Color(1f,1f,1f, aplha_acumulado);

                    yield return null;

            }




            this.plano_de_fundo_imagem_slot.sprite = this.plano_de_fundo_transicao_imagem_slot.sprite;
            this.plano_de_fundo_imagem_slot.color = new Color(1f,1f,1f,1f);


            this.plano_de_fundo_transicao_imagem_slot.sprite = null;
            this.plano_de_fundo_transicao_imagem_slot.color = new Color(1f,1f,1f,0f);
            
            yield break;


            


            }



}





