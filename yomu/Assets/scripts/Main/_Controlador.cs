using System;
using System.Collections;
using System.Threading;
using UnityEngine;



public class Controlador : MonoBehaviour {  


            public static Controlador Pegar_instancia() {return instancia;}
            public static Controlador instancia;

            public Controlador_modo modo_controlador_atual;
            public static bool jogo_ativo = true;

            public Player_estado_atual player_estado_atual;
            public GameObject canvas;

            // --- SEGURANCA 

            public bool esta_reconstruindo_save = false;


            // --- MODOS

            public Login login;
            public Menu menu;
            public Jogo jogo;


            // --- USO CONTROLADOR

            public Desenvolvimento desenvolvimento;
            public Controlador_UI controlador_UI;

            

            public void Start(){

                  // --- SET THREAD

                  if( Thread.CurrentThread.Name == null )
                        { Thread.CurrentThread.Name = "Main"; }

                  Controlador_multithread.jogo_ativo = true;
                        
                  
                  canvas = GameObject.Find( "Tela/Canvas" );

                  // --- SETTINGS

                  instancia = this;      
                  QualitySettings.vSyncCount = 0;
                  Application.targetFrameRate = 60;
                  Application.runInBackground = true;


                  // --- CONSTRUIR CONTROLADORES GERAIS

                  Controlador_cache.Construir();
                  Controlador_multithread.Construir();
                  Controlador_audio.Construir();
                  Controlador_cursor.Construir();
                  Controlador_dados.Construir();
                  Controlador_configuracoes.Construir();


                  #if UNITY_EDITOR 

                        // --- VERIFICAR DESENVOLVIMENTO

                        desenvolvimento = Desenvolvimento.Construir();  
                        Teste_geral.Testar();
                        Controlador_development.Verificar();


                        bool em_teste = ( desenvolvimento.desenvolvimento_atual != Desenvolvimento_atual.nada );
                        
                        if( em_teste ) 
                              { 
                                    // --- VAI TESTAR

                                    Console.Log( "veio em iniciar jogo teste" );
                                    Console.Log( $"modo atual: { desenvolvimento.desenvolvimento_atual }" );
                                    modo_controlador_atual = Controlador_modo.desenvolvimento;

                                    // --- SETA TUDO COMO DEFAULT
                                    this.jogo =  Jogo.Construir();
                                    
                                    // --- DESENVOLVIMENTO UTILIDADES
                                    desenvolvimento.Colocar_estado_teste();
                                    desenvolvimento.Iniciar_ferramentas();

                                    return;
                              }


                  #else

                  
                        // --- VERIFICAR ARQUIVO DE SEGURANCA
                        bool arquivo_foi_encerrado_corretamente = Gerenciador_seguranca_main.Garantir_arquivo_de_seguranca();
                        if( !( arquivo_foi_ncerrado_corretamente ) )
                              { return; }

                  #endif


                  login = Login.Construir();

            }


            public void Update() {


                  if( Input.GetKey( KeyCode.F1 ) && Input.GetKey(KeyCode.Escape ) ) 
                        { Application.Quit(); } 

                  Console.Update();
                  Controlador_audio.Pegar_instancia().Update();
                  Controlador_input.Update_mouse();
                  Controlador_dados.Pegar_instancia().Atualizar_mouse_atual(); 
                  
                  if( esta_reconstruindo_save )
                        { return ; }  


                  switch (  modo_controlador_atual ) {
                        
                        // --- SE EM DESENVOLVIMENTO : DESENVOLVIMENTO.UPDATE => MODO ESPECIFICO UPDATE
                        case Controlador_modo.desenvolvimento: desenvolvimento.Update(); break;

                        case Controlador_modo.jogo :  jogo.Update(); break;
                        case Controlador_modo.login :  login.Update() ; break;
                        case Controlador_modo.menu : menu.Update() ; break;
                        case Controlador_modo.transicao: console.log("esta no modo_tela transicao"); break;
                        case Controlador_modo.nada: console.log("esta no modo_tela NADA"); break;

                  }


                  Controlador_input.Update();
                  Controlador_multithread.Pegar_instancia().Update();
                  
      
            }




            public void OnApplicationQuit(){
                  
                  #if !UNITY_EDITOR

                  Controlador_multithread.jogo_ativo = false;
                  controlador_configuracoes.Salvar_configurations();

                  #endif
                  
            }



            public void OnDisable(){

                  Controlador_multithread.jogo_ativo = false;
                  
            }

}
