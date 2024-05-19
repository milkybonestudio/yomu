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


/*
 
     passos para entrar:
     
     player inicia todos os modulos => vai entrar no "in_game" => zerar todos os dados/voltar default( garante que sempre tem os dados default ) => tem save? s: => save intera sobre os dados default 
                                                                                                                                                              n: => jogo inicia com os dados default
     
*/




public enum Controlador_modo {

      nada,

      login,
      menu,
      jogo,
      transicao,

      teste,

}



public class Controlador : MonoBehaviour {  

      public static Controlador Pegar_instancia() {return instancia;}
      public static Controlador instancia;

      

      public Controlador_modo modo_controlador_atual;
      public static bool jogo_ativo = true;

      public Player_estado_atual player_estado_atual;
    


    //----------------------------------------------------------
    // ----------BLOCOS

            public Login login;
            public Menu menu;

            // menu vai iniciar o jogo e instanciar o objeto
            public Jogo jogo;

    //----------------------------------------------------------
    // ----------USO GERAL


            public  Controlador_configuration controlador_configuration;
            public  Controlador_audio controlador_audio;
            public  Controlador_cursor controlador_cursor;
            public  Controlador_cache controlador_cache;
            public Controlador_multithread controlador_multithread;
            

    //----------------------------------------------------------

    // ----------USO CONTROLADOR

            //public  Controlador_save controlador_save;
            public Controlador_transicao controlador_transicao;
            public  Teste teste;
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


                       Debug.Log( "bbbbb" );


                        // o controlador não vai mais iniciar nada referente ao jogo, somente menu e login 

                        #if UNITY_EDITOR

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
                        Controlador_data.Construir();

                        controlador_configuration = Controlador_configuration.Construir();

                        Debug.Log("AAAAAAA");
                        
                        teste = Teste.Construir();      
                  


                        Debug.Log("aaaaa");
                  
                        if( teste.Verificar_teste()  ) {return;}
                        login = Login.Construir();

            }


            public void Update() { 


                        if(Input.GetKeyDown(KeyCode.F1)) Application.Quit();   
                        Controlador_input.Update_mouse();
                        Controlador_data.Pegar_instancia().Atualizar_mouse_atual(); 

                        // tirar depois
                        teste.Update();

                        // controlador_audio.Update();


                        switch (  modo_controlador_atual ) {
                              

                              case Controlador_modo.jogo :  jogo.Update(); break;
                              case Controlador_modo.login :  login.Update() ; break;
                              case Controlador_modo.menu : menu.Update() ; break;

                              case Controlador_modo.teste: teste.Update(); break;
                              case Controlador_modo.transicao: console.log("esta no modo_tela transicao"); break;
                              
                              case Controlador_modo.nada: console.log("esta no modo_tela NADA"); break;

                        }



            // if(dados_blocos.req_transicao != null ){ 

            //        controlador_transicao.Mudar_bloco();
            // }


            // if( dados_blocos.req_mudar_UI != null ){  Controlador_UI.Pegar_instancia().Mudar_UI( ); }



              Controlador_input.Update();
              Controlador_multithread.Pegar_instancia().Update();
              

        }

       // asdas 
      

        public void OnApplicationQuit(){
              
              #if !UNITY_EDITOR

              controlador_configuration.Salvar_configurations();

              #endif
            
        }





      
      

      public void OnDisable(){

            Controlador_multithread.jogo_ativo = false;
            Debug.Log("veio onDisable");

     }

}
