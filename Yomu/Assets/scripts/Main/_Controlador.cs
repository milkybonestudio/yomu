using System.Collections;
using System;
using System.Windows;

using UnityEngine.Experimental.Rendering;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

using Unity.Collections;


/*
 
     passos para entrar:
     
     player inicia todos os modulos => vai entrar no "in_game" => zerar todos os dados/voltar default( garante que sempre tem os dados default ) => tem save? s: => save intera sobre os dados default 
                                                                                                                                                              n: => jogo inicia com os dados default
     
*/




public enum Controlador_modo {

      login,
      menu,
      jogo,

}



public class Controlador : MonoBehaviour {  


      public static Controlador Pegar_instancia() {

            return instancia;

      }

      public static Controlador instancia;
      public static Controlador controlador;

      /*
      *  
      *  os valores default vao estar nas proprias classes, se nao tiver save == new game  => a classe instancia primerio, se tiver save ele troca os valores
      *  isso tecnicamente vai aumentar o tempo de load, mas como a maior parte do tempo de carregamento vai ser por conta dos dados estaticos. por exemplo os dados dinamicos
      *  default vao ser arrays vazios porque nao tem nada, o tempo de carregamento vai ser insignificante. se tiver no save pode demorar, mas nao tem muito oque fazer. 

      */



      public Player_estado_atual player_estado_atual;


    // 


    //----------------------------------------------------------

    // ----------BLOCOS

            // public BLOCO_jogo bloco_jogo;
            // public BLOCO_visual_novel bloco_visual_novel;
            

            public BLOCO_login bloco_login;
            public BLOCO_menu bloco_menu;

            //----------------------------

    //----------------------------------------------------------

    // ----------USO GERAL



            public  Controlador_configuration controlador_configuration;
            public  Controlador_audio controlador_audio;
            public  Controlador_cursor controlador_cursor;
            public  Controlador_cache controlador_cache;
            public Controlador_multithread controlador_multithread;
            





    //----------------------------------------------------------

    // ----------USO CONTROLADOR

            public  Controlador_save controlador_save;
            public Controlador_transicao controlador_transicao;
            public  Teste teste;
            public Controlador_UI controlador_UI;


    //----------------------------------------------------------

    // ----------DATA

            public  Controlador_data controlador_data;
            public  Controlador_dados_dinamicos controlador_dados_dinamicos;
            //public  Controlador_personagens controlador_personagens;
            public  Controlador_timer controlador_timer;
      


      [NonSerialized]  public  Dados_blocos  dados_blocos = null;

      [NonSerialized]  public  int   posicao_anterior  = 0;

      [NonSerialized]  public  Bloco   bloco_atual  = Bloco.nada;

      [NonSerialized]  public  int   script_inicial = 0;







      public  void  Awake(){

            #if UNITY_EDITOR

                  Controlador_development.Verificar();


            #endif

            Texture.allowThreadedTextureCreation = true;

            Controlador_multithread.jogo_ativo = true;

            instancia = this;      
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = 60;
            Application.runInBackground = true;

            
            Verificador_instancias_nulas.Ativar();

            
     // ----------BLOCOS

            //bloco_jogo = BLOCO_jogo.Pegar_instancia(true);
      

            //bloco_visual_novel = BLOCO_visual_novel.Pegar_instancia(true);


            bloco_login = BLOCO_login.Pegar_instancia(true);
            bloco_menu = BLOCO_menu.Pegar_instancia(true);

            

    //----------------------------------------------------------

    // ----------USO GERAL

            controlador_configuration = Controlador_configuration.Pegar_instancia( true );
            controlador_cache = Controlador_cache.Pegar_instancia( true );
            controlador_multithread = Controlador_multithread.Pegar_instancia( true );
            
            controlador_audio = Controlador_audio.Pegar_instancia( true );
            controlador_cursor = Controlador_cursor.Pegar_instancia( true );
            

    //----------------------------------------------------------

    // ----------USO CONTROLADOR

            controlador_save = Controlador_save.Pegar_instancia(true);
            controlador_transicao = Controlador_transicao.Pegar_instancia(true);
            teste = Teste.Pegar_instancia(true);
            controlador_UI = Controlador_UI.Pegar_instancia( true );

      


    //----------------------------------------------------------

    // ----------DATA

            controlador_data = Controlador_data.Pegar_instancia(true);
            controlador_dados_dinamicos = Controlador_dados_dinamicos.Pegar_instancia(true);
            //controlador_personagens = Controlador_personagens.Pegar_instancia(true);
            controlador_timer = Controlador_timer.Pegar_instancia(true);
            player_estado_atual = Player_estado_atual.Pegar_instancia(true);
            dados_blocos =  Dados_blocos.Pegar_instancia(true);


            Verificador_instancias_nulas.Liberar();





                    

      }



       void Start(){

  
           


            
            if( teste.Verificar_teste()  ) {return;}


            //bloco_jogo.canvas_jogo.SetActive(true);

            //dados_blocos.req_transicao = new Req_transicao( Tipo_troca_bloco.START , Bloco.login   ,Tipo_transicao.instantaneo );
            
            dados_blocos.login_START = new Login_START( controlador_configuration.login_background   );

            controlador_transicao.Mudar_bloco();



      }


        public void Update() { 



            if( player_estado_atual.bloco_atual  == Bloco.teste ) { teste.Update_pre(); }
            if(Input.GetKeyDown(KeyCode.F1)) Application.Quit();   
            Controlador_input.Update_mouse();
            controlador_data.Atualizar_mouse_atual(); 

            teste.Update();

            
          //  if(  controlador_UI.Update() ) { return; }


          //  if(controlador_transicao.em_transicao) { return; }


            // controlador_audio.Update();

            
            

            /*

                        NOVO MODELO 
                        só vai ter 2 opcoes, input e output.
                        output => vai ser usado por outros blocos quando sair 
                        input => vai vir de outros blocos 

                        cenas quer iniciar plataforma faz controaldor.plataforma_input = new plataforma_input 
                        quando sair de plataforma faz controaldor.plataforma_output = new output. 
                        handlers vao ficar a cargo de caldo bloco, e cada bloco vai ter acesso a todas as informacoes. 

            */


            //   switch (  player_estado_atual.bloco_atual ) {
                  
            //         case Bloco.visual_novel :  bloco_visual_novel.Update() ;  break;
            //         case Bloco.jogo :  bloco_jogo.Update(); break;
      
            //         case Bloco.login :  bloco_login.Update() ; break;
            //         case Bloco.menu : bloco_menu.Update() ; break;

            //         case Bloco.teste: teste.Update();break;

            //         case Bloco.nada: console.log("esta no modo_tela NADA"); break;

            //   }



            if(dados_blocos.req_transicao != null ){ 

                   controlador_transicao.Mudar_bloco();
            }


            if( dados_blocos.req_mudar_UI != null ){  Controlador_UI.Pegar_instancia().Mudar_UI( ); }



              Controlador_input.Update();

              controlador_multithread.Update();
              

        }

       // asdas 
      

        public void OnApplicationQuit(){
              
              #if !UNITY_EDITOR

              controlador_configuration.Salvar_configurations();

              #endif
            
        }





      
      public static bool jogo_ativo = true;

      public void OnDisable(){

            Controlador_multithread.jogo_ativo = false;
            Debug.Log("veio onDisable");

     }

}
