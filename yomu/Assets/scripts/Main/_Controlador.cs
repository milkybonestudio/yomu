using System.Collections;
using System;
using System.Windows;

using UnityEngine.Experimental.Rendering;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

using Unity.Collections;
using System.Security.Cryptography;
using System.Reflection;




public enum Controlador_modo {

      nada,

      login,
      menu,
      jogo,
      transicao,

      desenvolvimento,

}



public class Controlador : MonoBehaviour {  


      public static Controlador Pegar_instancia() {return instancia;}
      public static Controlador instancia;

      

      public Controlador_modo modo_controlador_atual;
      public static bool jogo_ativo = true;

      public Player_estado_atual player_estado_atual;
      public GameObject canvas;
    


    //----------------------------------------------------------
    // ----------BLOCOS

            public Login login;
            public Menu menu;

            // menu vai iniciar o jogo e instanciar o objeto
            public Jogo jogo;

    //----------------------------------------------------------
    // ----------USO GERAL


            public  Controlador_configuracoes controlador_configuracoes;
            public  Controlador_audio controlador_audio;
            public  Controlador_cursor controlador_cursor;
            public  Controlador_cache controlador_cache;
            public Controlador_multithread controlador_multithread;
            

    //----------------------------------------------------------

    // ----------USO CONTROLADOR

            //public  Controlador_save controlador_save;
            public Controlador_transicao controlador_transicao;
            public  Desenvolvimento desenvolvimento;
            public Controlador_UI controlador_UI;


    //----------------------------------------------------------

    // ----------DATA

            
            public  Controlador_dados_dinamicos controlador_dados_dinamicos;
            //public  Controlador_personagens controlador_personagens;
            
      

            [NonSerialized]  public  Dados_blocos  dados_blocos = null;
            [NonSerialized]  public  int   posicao_anterior  = 0;
            [NonSerialized]  public  Bloco   bloco_atual  = Bloco.nada;
            [NonSerialized]  public  int   script_inicial = 0;


            public  void  Awake(){


                  

            }



            void Start(){



                  #if UNITY_EDITOR 

                        Teste_geral.Testar();

                  #endif
                  




                  canvas = GameObject.Find( "Tela/Canvas" );


                  // Esse arquivo vai ser responsavel por dizer se o sistema foi desligado de forma brusca 

                  

                  // o controlador não vai mais iniciar nada referente ao jogo, somente menu e login 

                  #if UNITY_EDITOR

                        // verifica se tem que alterar algum dado

                        Controlador_development.Verificar();

                  #endif

                  Texture.allowThreadedTextureCreation = true;

                  Controlador_multithread.jogo_ativo = true;

                  instancia = this;      
                  QualitySettings.vSyncCount = 0;
                  Application.targetFrameRate = 60;
                  Application.runInBackground = true;
                  
                  // construir vai colocar as imagens no cache, entao não tem porque 


                  
      

                  Controlador_cache.Construir();

                  
                  Controlador_multithread.Construir();

                  
                  
                  controlador_audio = Controlador_audio.Construir();
                  
                  controlador_cursor = Controlador_cursor.Construir();
                  //controlador_save = Controlador_save.Construir();
                  
                  Controlador_dados.Construir();
                  
                  controlador_configuracoes = Controlador_configuracoes.Construir();
                  

                  // ---- EM TESTE
                  // assumir que depois daqui esta tudo blz 
                  Verificar_pane_sistema();

                  
                  desenvolvimento = Desenvolvimento.Construir();  


                  if( desenvolvimento.Verificar_teste()  ) {return;}

                  login = Login.Construir();

            }




            public void Update() { 



                        if( Teste_escopo.ativado ){ Teste_escopo.Update(); return;}



                        if(Input.GetKeyDown(KeyCode.F1)) { Application.Quit(); }   
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



            public void Verificar_pane_sistema(){


                  return;

                        
                        string path = Paths_gerais.Pegar_path_folder_usuario() + "/dados_sistema.dat";


                        FileStream stream = new FileStream ( 

                                    path, 
                                    FileMode.Open, 
                                    FileAccess.ReadWrite, 
                                    FileShare.Read, 
                                    4096, 
                                    FileOptions.WriteThrough 

                        );

                        
                        // byte == 0 significa que o sistema foi encerrado corretamente 
                        // byte == 1 significa que o sistema foi encerrado bruscamente 
                        bool pane_sistema = ( stream.ReadByte() == ( byte ) 1 );
                        
                        if( pane_sistema ){

                              // Tem que verificar os saves para refazeros dados que estão em run.dat
                              
                              int numero_saves_slots = Controlador_configuracoes.Pegar_instancia().numero_saves_slots;
                              bool[] saves_ativos =  Controlador_configuracoes.Pegar_instancia().saves_ativados;

                              for( int save_slot = 0 ; save_slot < numero_saves_slots  ; save_slot++ ){

                                          bool save_esta_ativo = saves_ativos[ save_slot ];
                                          if( save_esta_ativo ){

                                                // fazer a verificacao
                                                

                                          }

                              }

                        }

                        // fala qeu esta ativado 
                        stream.Seek( 0, SeekOrigin.Begin );
                        byte b = 1;
                        stream.WriteByte( b );
                        stream.Flush();

                        // talvez fazer mais coisas aqui



            }
      

        public void OnApplicationQuit(){
              
              #if !UNITY_EDITOR

              controlador_configuracoes.Salvar_configurations();

              #endif
            
        }





      
      

      public void OnDisable(){

            Controlador_multithread.jogo_ativo = false;
            

     }

}
