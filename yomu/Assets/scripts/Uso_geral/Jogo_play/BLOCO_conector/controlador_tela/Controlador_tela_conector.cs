using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;



public class Controlador_tela_conector {


            public static Controlador_tela_conector instancia;
            public static Controlador_tela_conector Pegar_instancia(){ return instancia; }

            public float[] posicao_mouse;

            
            public BLOCO_conector bloco_conector;

            public Controlador_cursor controlador_cursor;
            public Controlador_interativos controlador_interativos;

            public Coroutine background_coroutine = null;

            public Player_estado_atual player_estado_atual;

            public Pergaminho_modelo_1 pergaminho;
            
            public GameObject background_container;

            public GameObject background_1;
            public GameObject background_2;

            public Image background_1_image;
            public Image background_2_image;

            

            public static Controlador_tela_conector Construir(){ 

                        if( instancia != null )
                              { throw new Exception( "tentou construir controlador tela conector mas a instancia nao estava nula" ); }
                        
                        Controlador_tela_conector controlador = new Controlador_tela_conector(); 
                        instancia = controlador;


                              controlador.bloco_conector = BLOCO_conector.Pegar_instancia();

                              controlador.posicao_mouse = Controlador_dados.Pegar_instancia().posicao_mouse;
                              controlador.controlador_interativos = Controlador_interativos.Pegar_instancia();
                              controlador.controlador_cursor = Controlador_cursor.Pegar_instancia();
                              controlador.player_estado_atual = Player_estado_atual.Pegar_instancia();

                              // ---CRIAR TELA

                              Construtor_tela_jogo.Criar_tela( controlador );

                              
                              
                        return instancia;
                        
            }

            



            public void Trocar_tela(   string _background_path,  bool _instantaneo = false){


                  Sprite background_sprite = Resources.Load<Sprite>(_background_path);

                  if( background_sprite == null )  throw new ArgumentException("nao foi achado sprite do path: " + _background_path);

                  if( background_coroutine != null) {

                        Mono_instancia.Stop_coroutine(background_coroutine);

                        background_1_image.sprite = background_2_image.sprite;
                        background_1_image.color = Color.white;

                        background_2_image.color = Color.clear;
                        background_2_image.sprite = null;

                        background_coroutine = null;

                  }


                  if(_instantaneo){

            

                        background_1_image.sprite = background_sprite;
                        background_1_image.color = Color.white;
                        
                        background_2_image.color = Color.clear;
                        background_2_image.sprite = null;
                        

                        return;
                        
                  }

                  background_coroutine = Mono_instancia.Start_coroutine( a() );


                  IEnumerator a(){

                        background_2_image.sprite = background_sprite;

                        

                        float opacidade = 0f;

                        while(opacidade <=1f ){


                              opacidade = opacidade + 0.1f;
                              background_2_image.color = new Color(1f,1f,1f, opacidade);
                              
                              yield return null;

                        }


                        background_1_image.sprite = background_sprite;
                        background_1_image.color = Color.white;

                        background_2_image.color = Color.clear;
                        background_2_image.sprite = null;

                        background_coroutine = null;
                        yield break;


                  }


                  return;

            }




}