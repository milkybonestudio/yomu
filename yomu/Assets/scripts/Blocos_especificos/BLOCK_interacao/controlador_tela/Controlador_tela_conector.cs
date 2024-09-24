using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;



public class Controlador_tela_conector {

            // *** trocar => muda completamente 
            // *** mudar => muda algumas partes
                  //          Mudar_x__VERIFICAR() => verificar e chama as funcoes pequenas 
                  // preferir Mudar_x__COISA(); para mudar uma coisa especifica


            public static Controlador_tela_conector instancia;
            public static Controlador_tela_conector Pegar_instancia(){ return instancia; }

            public float[] posicao_mouse;

            public BLOCO_interacao bloco_interacao;


            

            public Controlador_cursor controlador_cursor;
            public Controlador_interativos controlador_interativos;

            public Coroutine background_coroutine = null;

            public Player_estado_atual player_estado_atual;

            public Pergaminho_modelo_1 pergaminho;


            public GameObject container_conector;
            
            public GameObject background_container;

            public GameObject background_1;
            public GameObject background_2;

            public Image background_1_image;
            public Image background_2_image;

            public Gerenciador_imagens_background_conector gerenciador_imagens_background_conector; 


            // --- INTERATIVOS

            public Gerenciador_imagens_interativos gerenciador_imagens_interativos;


            public Interativo_tela[] interativo_tela;
            public Interativo_item[] interativo_item;
            public Interativo_personagem[] interativo_personagem;




            // --- INTERATIVOS IMAGENS 

                  public Container_interativo_tela_imagem[] interativos_tela_imagens;
                  public Container_interativo_personagem_imagem[] interativos_personagens_imagens;
                  public Container_interativo_item_imagem[] interativos_itens_imagens;

 
      
            // --- LOGICA

                  public Ponto ponto_sendo_mostrado_para_o_player;





            public void Verificar_movimento_player(){
                  
                  
                //   Personagem personagem_sendo_controlado = Player_estado_atual.Pegar_instancia().personagem_sendo_controlado_player;

                //   if ( ponto_sendo_mostrado_para_o_player.posicao_ponto.posicao_id != personagem_sendo_controlado.posicao.posicao_id )
                //         {
                //               // --- TEM QUE MUDAR PONTO SENDO MOSTRADO

                //               Ponto novo_ponto = Controlador_navegacao.Pegar_instancia().Pegar_ponto( personagem_sendo_controlado.posicao );

                //               ponto_sendo_mostrado_para_o_player = novo_ponto;

                //               Trocar_tela( novo_ponto, Tipo_troca_tela_conector.transicao );

                //         }

                //   return;

            }




            public void Informar_alteracao_ponto_ativo( Ponto _ponto  ){

                  return;

            }




            // vai trocar tudo 
            public void Trocar_tela(  Ponto _novo_ponto, Tipo_troca_tela_conector _tipo_troca ){

                        // ** vai pegar as imagens aqui

                        Locator_position _nova_posicao = _novo_ponto.posicao_ponto;
                        Ponto_ativo ponto_ativo = _novo_ponto.ponto_ativo;


                        // --- PEGA OS INTERATIVOS

                        Interativo_tela[] novos_interativos_tela = ponto_ativo.interativos_tela;
                        Interativo_personagem[] novos_interativos_personagens = ponto_ativo.interativos_personagens;
                        Interativo_item[] novos_interativos_itens = ponto_ativo.interativos_itens;


                        // --- PEGA NOVO BACKGROUND

                        Container_interativo_tela_imagem[] interativos_tela_imagens;
                        Container_interativo_personagem_imagem[] interativos_personagens_imagens;
                        Container_interativo_item_imagem[] interativos_itens_imagens;


                        // Controlador_configuracoes.Pegar_instancia().



                        if   ( _tipo_troca == Tipo_troca_tela_conector.instantaneo )
                              {
                                    // --- FORCAR TROCAR


                                    return;
                              }

                        if( _tipo_troca == Tipo_troca_tela_conector.transicao )
                              {

                                    // --- TRANSICAO



                                    return;

                              }

                        throw new Exception();
                  

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
