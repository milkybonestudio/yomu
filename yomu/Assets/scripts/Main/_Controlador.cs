using System;
using System.Collections;
using UnityEngine;



public class Controlador : MonoBehaviour {  


            public static Controlador Pegar_instancia() {return instancia;}
            public static Controlador instancia;


            public Controlador_modo modo_controlador_atual;
            public static bool jogo_ativo = true;

            public Player_estado_atual player_estado_atual;
            public GameObject canvas;


            public Task_req task_reconstruir;
            public bool esta_reconstruindo = false;


            // --- BLOCOS

            public Login login;
            public Menu menu;
            public Jogo jogo;

            // --- USO CONTROLADOR

            public Controlador_transicao controlador_transicao;
            public Desenvolvimento desenvolvimento;
            public Controlador_UI controlador_UI;


            [NonSerialized]  public  Dados_blocos  dados_blocos = null;
            [NonSerialized]  public  int   posicao_anterior  = 0;
            [NonSerialized]  public  Bloco   bloco_atual  = Bloco.nada;
            [NonSerialized]  public  int   script_inicial = 0;


            public void Start(){


                  return;

                  canvas = GameObject.Find( "Tela/Canvas" );

            
                  Controlador_multithread.jogo_ativo = true;

                  instancia = this;      
                  QualitySettings.vSyncCount = 0;
                  Application.targetFrameRate = 60;
                  Application.runInBackground = true;


                  Controlador_cache.Construir();
                  Controlador_multithread.Construir();
                  Controlador_audio.Construir();
                  Controlador_cursor.Construir();
                  Controlador_dados.Construir();
                  Controlador_configuracoes.Construir();

                  #if UNITY_EDITOR 

                        Teste_geral.Testar();
                        Controlador_development.Verificar();
                        Desenvolvimento.Construir();  

                        bool em_teste = Desenvolvimento.Pegar_instancia().Verificar_teste();

                        if( em_teste ) 
                              { return ; }


                  #endif
                  

                  // --- VERIFICAR ARQUIVO DE SEGURANCA
                  bool arquivo_foi_encerrado_corretamente = Garantir_arquivo_de_seguranca();
                  if( !( arquivo_foi_encerrado_corretamente ) )
                        { return; }


                  login = Login.Construir();

            }


            public void Update() {

                  Console.Log( "aa" );
                  Console.Update();

                  return;
                  
                  if( esta_reconstruindo )
                        { return ; }  


                  if( Input.GetKey( KeyCode.F1 ) && Input.GetKey(KeyCode.Escape ) ) { Application.Quit(); } 

                  Controlador_audio.Pegar_instancia().Update();

                  Controlador_input.Update_mouse();
                  Controlador_dados.Pegar_instancia().Atualizar_mouse_atual(); 


                  switch (  modo_controlador_atual ) {
                        
                        case Controlador_modo.jogo :  jogo.Update(); break;
                        case Controlador_modo.login :  login.Update() ; break;
                        case Controlador_modo.menu : menu.Update() ; break;
                        case Controlador_modo.desenvolvimento: desenvolvimento.Update(); break;
                        case Controlador_modo.transicao: console.log("esta no modo_tela transicao"); break;
                        case Controlador_modo.nada: console.log("esta no modo_tela NADA"); break;

                  }


                  Controlador_input.Update();
                  Controlador_multithread.Pegar_instancia().Update();
      
            }


            public IEnumerator C_reconstruindo_save (){

                  // colocar video algo deu errado, um momento

                  while( esta_reconstruindo ){ yield return null; }
                  yield break;

            }


            public bool Garantir_arquivo_de_seguranca(){

                  byte[] dados = Verificador_arquivo_de_seguranca.Pegar_dados();
                  bool arquivo_foi_encerrado_corretamente = Verificador_arquivo_de_seguranca.Programa_foi_encerrado_corretamente( dados );

                  if( !( arquivo_foi_encerrado_corretamente ) )
                        {
                              // --- PRECISA ARRUMAR DADOS
                              int save = Verificador_arquivo_de_seguranca.Pegar_save( dados );

                              task_reconstruir = new Task_req( new Chave_cache() , "reconstruindo_save" );

                              task_reconstruir.fn_iniciar = ( Task_req _req ) => {

                                    Reestruturador_save.Reconstruir_save( save );
                                    return;

                              };

                              task_reconstruir.fn_finalizar = ( Task_req _req ) => {

                                    esta_reconstruindo = false;
                                    login = Login.Construir();
                                    return;

                              };
                              
                              Controlador_multithread.Pegar_instancia().Adicionar_task( task_reconstruir );
                              esta_reconstruindo = true;
                              StartCoroutine( C_reconstruindo_save() );
                              return false;
                              
                        }


                  return true;
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
