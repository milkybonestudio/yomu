using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;





public class Menu { 


      public static Menu instancia;
      public static Menu Pegar_instancia(){ return instancia; }
      public static Menu Construir(){ instancia = new Menu(); return instancia;}
      

      public Menu (){ 

          /*

                Menu precisa de um controlador interno de cache 
                Talvez valha a pena fazer uma classe generica? 
                Controlador_cache vai ficar respensavel por receber dados do controlador_multiThread
          
          */

          Controlador.Pegar_instancia().modo_controlador_atual = Controlador_modo.menu;

          controlador_configuracoes = Controlador_configuracoes.Pegar_instancia();
          controlador_dados = Controlador_dados.Pegar_instancia();
          
          Iniciar_menu();

          
          
          return;
        
      }


      // todas vao ser deletadas quando o meu for destruido;
      public Chave_cache[] chaves_imagens;
     
      
      public  GameObject canvas_menu;
      public  GameObject canvas_menu_movel;
      public  Image canvas_menu_image;
      public  RectTransform canvas_menu_rect;
        
       
      public  Coroutine coroutine_atual;

      public  GameObject menu_background; 
      public  Transform menu_background_transform;
      public  RectTransform menu_background_rect_transform;



      public GameObject galery_container;

      public Menu_objects_generico menu_galery_botao_proximo;
      public Menu_objects_generico menu_galery_botao_anterior;

      public Menu_objects_generico[] menu_galery_arr = new Menu_objects_generico[8];


      public GameObject save_container;

      public Menu_objects_generico[] menu_saves_arr = new Menu_objects_generico[4];

      public Save_information[] menu_save_information_arr = new Save_information[4];



      public GameObject personagens_container;

      public Menu_objects_generico menu_personagens_botao_proximo;
      public Menu_objects_generico menu_personagens_botao_anterior;

      public Menu_objects_generico[] menu_personagens_arr = new Menu_objects_generico[8];


      public GameObject opcoes_container;

      public Menu_objects_generico[] menu_opcoes_arr = new Menu_objects_generico[5];

      public Botao[] botoes = new Botao[ 5 ];

      public GameObject  config;
      public Configuration_container configuration_container;

      
      public GameObject new_game_container;

      public Menu_objects_generico[] new_game_arr = new Menu_objects_generico[1];
      public Menu_objects_generico new_game;

      public Menu_type estado_atual = Menu_type.new_game;

      public int numero_pagina_galeria = 0;
      
      public Controlador_configuracoes controlador_configuracoes;
      
      public Controlador_dados controlador_dados;

    
      
      // vai destruir tudo quando iniciar o jogo
      
      public void Zerar_dados(){

        // Mono_instancia.DestroyImmediate(canvas);
        // canvas = null;
        // canvas_menu = null;
        // canvas_menu_movel = null;
        // canvas_menu_image  = null;
        // canvas_menu_rect  = null;
        
      }

    public void Iniciar_menu(){

            Controlador.Pegar_instancia().modo_controlador_atual = Controlador_modo.menu;


            Controlador_input.ativar_movimentacao_mouse = true;
            Controlador_cursor.Pegar_instancia().Mudar_cursor(Cor_cursor.off);
            // ?
            Controlador_input.tipo_teclado = Tipo_teclado.plataforma;

            //   canvas 

            string path = "images/menu_images/" + controlador_configuracoes.menu_background; 
            Sprite menu_background = Resources.Load<Sprite>(path);
            
            GameObject canvas = GameObject.Find("Tela/Canvas");


            canvas_menu = new GameObject("Menu");
            canvas_menu.transform.SetParent(canvas.transform, false);
            canvas_menu_movel = new GameObject("Canvas_menu_movel");
            canvas_menu_movel.transform.SetParent(canvas_menu.transform, false);

        
            canvas_menu_image = canvas_menu_movel.AddComponent<Image>();
            canvas_menu_rect = canvas_menu_movel.GetComponent<RectTransform>();
            canvas_menu_rect.SetSizeWithCurrentAnchors(   RectTransform.Axis.Horizontal  , 8160f);
            canvas_menu_rect.SetSizeWithCurrentAnchors(   RectTransform.Axis.Vertical  , 1080f);
            
            canvas_menu_image.sprite = menu_background;
            
    
            // new game 
        
            new_game_container = new GameObject("New_game_container");
            new_game_container.transform.SetParent(canvas_menu_movel.transform, false);
            new_game_container.transform.localPosition = new Vector3(0f,0f,0f);

            new_game = new Menu_objects_generico("New_game", new_game_container,"images/menu_images/menu_new_quadro_novo_jogo" ,11f,126f, 345f , 358f);

            new_game.On_click = Ativar_new_game;
            
            new_game_arr[0] = new_game;

            
            //    galeria


            galery_container = new GameObject("Galery_container");
            galery_container.transform.SetParent(canvas_menu_movel.transform, false);
            galery_container.transform.localPosition = new Vector3(-1560f,0f,0f);

        
        
            menu_galery_arr[0]    =   new Menu_objects_generico( "Menu_galery_1" , galery_container , "images/menu_images/default_galeria_1_menu" ,  0f  , 140f,    398f , 177f  );
            menu_galery_arr[1]    =   new Menu_objects_generico( "Menu_galery_2" ,galery_container , "images/menu_images/default_galeria_2_menu" ,   395f ,  99f ,   282f , 191f );
            menu_galery_arr[2]    =   new Menu_objects_generico( "Menu_galery_3" ,galery_container , "images/menu_images/default_galeria_3_menu" ,  104f,  -147f ,  474f , 182f );
            menu_galery_arr[3]    =   new Menu_objects_generico( "Menu_galery_4" ,galery_container , "images/menu_images/default_galeria_4_menu" , -352f , -98f , 139f, 297f );
            menu_galery_arr[4]    =   new Menu_objects_generico( "Menu_galery_5" ,galery_container , "images/menu_images/default_galeria_5_menu" , -454f , 156f,  225f , 131f );
            menu_galery_arr[5]    =   new Menu_objects_generico( "Menu_galery_6" ,galery_container , "images/menu_images/default_galeria_6_menu" , 17f , 395f  ,  305f,  188f );
            
            menu_galery_botao_proximo  = new Menu_objects_generico( "Menu_galery_botao_proximo" , galery_container , "images/menu_images/menu_seta_direita" ,  378f  , 339f,    191f , 113f  );
            menu_galery_arr[6] = menu_galery_botao_proximo;

            menu_galery_botao_anterior  = new Menu_objects_generico( "Menu_galery_botao_anterior" , galery_container , "images/menu_images/menu_seta_esquerda" ,  -332f  , 336f,    196f , 109f  );
            menu_galery_arr[7] = menu_galery_botao_anterior;


            Verificar_galeria();



        //  saves
        
            save_container = new GameObject("Save_container");
            save_container.transform.SetParent(canvas_menu_movel.transform,false);
            save_container.transform.localPosition = new Vector3(1560f,0f,0f);

            
            menu_saves_arr[0] = new Menu_objects_generico( "Menu_save_1", save_container , "images/menu_images/sem_save_image",   -279f , 216f , 287f ,142f);
            menu_save_information_arr[0] = new Save_information("Menu_save_1_info", save_container, -283f,396f);

            menu_saves_arr[1] = new Menu_objects_generico( "Menu_save_2", save_container , "images/menu_images/sem_save_image" ,  -279f , -186f ,  287f ,142f);
            menu_save_information_arr[1] = new Save_information("Menu_save_2_info", save_container, -282f,  -10f);
            
            menu_saves_arr[2] = new Menu_objects_generico( "Menu_save_3", save_container ,"images/menu_images/sem_save_image" , 314f , 215f,287f ,142f);
            menu_save_information_arr[2] = new Save_information("Menu_save_3_info", save_container, 322f,394f);

            menu_saves_arr[3] = new Menu_objects_generico( "Menu_save_4", save_container ,"images/menu_images/sem_save_image" , 315f , -186f , 287f ,142f);
            menu_save_information_arr[3] = new Save_information("Menu_save_4_info", save_container, 311f, -11f);

            Verificar_saves();

    
        //  configs


            config = new GameObject("Config");
            config.transform.SetParent(canvas_menu_movel.transform, false);
            config.transform.localPosition = new Vector3(3120f,0f,0f);


            string path_prefab = "prefabs/menu/Configurations_container";
            GameObject prefab_config_container = Resources.Load<GameObject>( path_prefab );

            configuration_container = GameObject.Instantiate( prefab_config_container ).GetComponent< Configuration_container >();
    
            configuration_container.game_object.transform.SetParent( config.transform, false );
            configuration_container.game_object.transform.localPosition = new Vector3( 0f, 100f, 0f );
            
            

            // characters

            personagens_container = new GameObject("Personagens_container");
            personagens_container.transform.SetParent(canvas_menu_movel.transform,false);
            personagens_container.transform.localPosition = new Vector3(-3120f,0f,0f);


            menu_personagens_arr[ 0 ]  = new Menu_objects_generico( "Menu_personagem_1", personagens_container ,"images/menu_images/default_personagem_menu" , -369f , 173f , 172f , 146f );
            menu_personagens_arr[ 1 ]  = new Menu_objects_generico( "Menu_personagem_2", personagens_container ,"images/menu_images/default_personagem_menu" , -369f , -86f, 172f , 146f);
            menu_personagens_arr[ 2 ]  = new Menu_objects_generico( "Menu_personagem_3", personagens_container ,"images/menu_images/default_personagem_menu" , -4f , 268f, 172f , 146f);
            menu_personagens_arr[ 3 ]  = new Menu_objects_generico( "Menu_personagem_4", personagens_container ,"images/menu_images/default_personagem_menu" , -4f , 9f, 172f , 146f);
            menu_personagens_arr[ 4 ]  = new Menu_objects_generico( "Menu_personagem_5", personagens_container ,"images/menu_images/default_personagem_menu" , 343f , 173f, 172f , 146f);
            menu_personagens_arr[ 5 ]  = new Menu_objects_generico( "Menu_personagem_6", personagens_container ,"images/menu_images/default_personagem_menu" , 343f , -86f, 172f , 146f);


            menu_personagens_botao_proximo  = new Menu_objects_generico( "Menu_personagens_botao_proximo" , personagens_container , "images/menu_images/menu_seta_direita" ,  342f  , 341f,    191f , 113f  );
            menu_personagens_arr[6] = menu_personagens_botao_proximo;

            menu_personagens_botao_anterior  = new Menu_objects_generico( "Menu_personagens_botao_anterior" , personagens_container , "images/menu_images/menu_seta_esquerda" ,  -371f  , 339f,    196f , 109f  );
            menu_personagens_arr[7] = menu_personagens_botao_anterior;

            


            //  botoes


            opcoes_container = new GameObject("Opcoes_container");
            Image opcoes_container_image = opcoes_container.AddComponent<Image>();
            RectTransform opcoes_container_rect = opcoes_container.GetComponent<RectTransform>();
            opcoes_container_rect.SetSizeWithCurrentAnchors( RectTransform.Axis.Horizontal, 1920f  );
            opcoes_container_rect.SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, 1080f );



            Sprite sprite_opcoes_container = Resources.Load<Sprite>("images/menu_images/menu_new_opcoes");

            opcoes_container_image.sprite = sprite_opcoes_container;

            if(sprite_opcoes_container == null) { throw new ArgumentException("a"); }
    
            opcoes_container.transform.SetParent(canvas_menu.transform,false);
            opcoes_container.transform.localPosition = new Vector3(0f,0f,0f);

            string som_click = "audio/geral_sfx/botoes/click_2";
            
            Sprite[] imagens_personagens = new Sprite[2];

            imagens_personagens[0] = Resources.Load<Sprite>("images/menu_images/botao_characters_off");
            imagens_personagens[1] = Resources.Load<Sprite>("images/menu_images/botao_characters_on");


            botoes[0] = new Botao(
                
                "Personagens_opcao",

                250f,
                85f,
                -600f,
                -480f,
                opcoes_container.transform,
                Ir_characters,
                Tipo_botao.dinamico,
                true, 
                imagens_personagens

            );

            botoes[0] .Colocar_som_click(som_click);

            Sprite[] imagens_galeria = new Sprite[2];
            imagens_galeria[0] = Resources.Load<Sprite>("images/menu_images/botao_galeria_off");
            imagens_galeria[1] = Resources.Load<Sprite>("images/menu_images/botao_galeria_on");


            botoes[1] = new Botao(
                
                "Galeria_opcao",

                250f,
                85f,
                -300f,
                -480f,
                opcoes_container.transform,
                Ir_galery,
                Tipo_botao.dinamico,
                true, 
                imagens_galeria

            );

            botoes[1].Colocar_som_click(som_click);


            Sprite[] imagens_new_game = new Sprite[2];
            imagens_new_game[0] = Resources.Load<Sprite>("images/menu_images/botao_new_game_off");
            imagens_new_game[1] = Resources.Load<Sprite>("images/menu_images/botao_new_game_on");


            botoes[2] = new Botao(
                
                "new_game_opcao",

                250f,
                85f,
                0f,
                -480f,
                opcoes_container.transform,
                Ir_new_game,
                Tipo_botao.dinamico,
                true, 
                imagens_new_game

            );

            botoes[2].Colocar_som_click(som_click);

            Sprite[] imagens_save = new Sprite[2];
            imagens_save[0] = Resources.Load<Sprite>("images/menu_images/botao_saves_off");
            imagens_save[1] = Resources.Load<Sprite>("images/menu_images/botao_saves_on");


            botoes[3] = new Botao(
                
                "save_opcao",

                250f,
                85f,
                300f,
                -480f,
                opcoes_container.transform,
                Ir_saves,
                Tipo_botao.dinamico,
                true, 
                imagens_save

            );

            botoes[3].Colocar_som_click(som_click);


            Sprite[] imagens_config = new Sprite[2];
            imagens_config[0] = Resources.Load<Sprite>("images/menu_images/botao_config_off");
            imagens_config[1] = Resources.Load<Sprite>("images/menu_images/botao_config_on");


            botoes[4] = new Botao(
                
                "config_opcao",

                250f,
                85f,
                600f,
                -480f,
                opcoes_container.transform,
                Ir_configurations,
                Tipo_botao.dinamico,
                true, 
                imagens_config

            );

            botoes[4].Colocar_som_click(som_click);



            string audio_path =  "audio/blocos_pequenos/menu/" + controlador_configuracoes.music_menu;

        
            Controlador_audio.Pegar_instancia().Start_music( _slot: 1 , audio_path );


    }




     public void Update(){

          bool esta_nos_botoes = Update_botoes();

          if( esta_nos_botoes  ) { return ;  }
        
          switch(estado_atual){

                case Menu_type.transicao: break;
                case Menu_type.personagens:  Update_generico(menu_personagens_arr); break;
                case Menu_type.galeria:  Update_generico(menu_galery_arr) ; break;
                case Menu_type.new_game: Update_generico(new_game_arr) ; break;
                case Menu_type.saves: Update_generico(menu_saves_arr)    ; break;
                case Menu_type.configurations:  configuration_container._Update() ; break;

          }

          return;

     }



    public bool Update_botoes(){

        
            bool is_click = Controlador_input.Get_up(Key_code.mouse_left);
            
            for(int i = 0 ;    i <  botoes.Length ;   i++){

                    Botao botao = botoes[i];                    
                    if( botao.Update(  is_click, controlador_dados.posicao_mouse )) { return true; }

            }

            return false ;

    }




    public void Update_generico( Menu_objects_generico[] _arr ){
     
          float mouse_x = controlador_dados.posicao_mouse[0] - 960f;
          float mouse_y = controlador_dados.posicao_mouse[1] - 540f;

          
          float x_min ;
          float x_max ;
            
          float y_min;
          float y_max ;
            

          for (int i = 0  ; i < _arr.Length  ;i++ ){

                
             
              _arr[i].image.color = Cores.Pegar_cor( Nome_cor.dark_2 ) ;

              x_min  = _arr[i].rect.localPosition[0] - (_arr[i].rect.rect.width / 2);
              x_max  = _arr[i].rect.localPosition[0] + (_arr[i].rect.rect.width / 2) ;
            
              y_min = _arr[i].rect.localPosition[1] - (_arr[i].rect.rect.height / 2) ;
              y_max = _arr[i].rect.localPosition[1] + (_arr[i].rect.rect.height / 2) ;



              if(Mat.Verificar_ponto_dentro_retangulo(  mouse_x,  mouse_y   , x_min, x_max, y_min , y_max   )   ){

                  _arr[i].image.color = Color.white;

                  if( Controlador_input.Get_down(Key_code.mouse_left)) {
                    
                    _arr[i].On_click();
                    
                  }
                  
                  Controlador_cursor.Pegar_instancia().Mudar_cursor( Cor_cursor.red );

                  return ;
                  
              }

          }

          Controlador_cursor.Pegar_instancia().Mudar_cursor( Cor_cursor.off );

        return;

    }




    public void Update_new_game(){
           
          float mouse_x = controlador_dados.posicao_mouse[0] - 960f;
          float mouse_y = controlador_dados.posicao_mouse[1] - 540f;


          float x_min ;
          float x_max ;
            
          float y_min;
          float y_max ;
            
          new_game.image.color = Cores.Pegar_cor( Nome_cor.dark_2 );

          x_min  = new_game.rect.localPosition[0] - (new_game.rect.rect.width / 2);
          x_max  = new_game.rect.localPosition[0] + (new_game.rect.rect.width / 2) ;
            
          y_min = new_game.rect.localPosition[1] - (new_game.rect.rect.height / 2) ;
          y_max = new_game.rect.localPosition[1] + (new_game.rect.rect.height / 2) ;



          if(Mat.Verificar_ponto_dentro_retangulo(  mouse_x,  mouse_y   , x_min, x_max, y_min , y_max   )   ){

              new_game.image.color = Color.white;
              if( Controlador_input.Get_down(Key_code.mouse_left)){

                    new_game ?. On_click();
                
              }
                  
          }

        
          return;

     }
      public void Update_saves(){ return; }
      public void Update_personagens(){ return; }
      public void Update_galeria(){ return; }

      public int Pegar_save_disponivel(){

        // por hora sempre vai no 1
        return 1;

      }


      public static class Sistema_mensagens{

            public static void Alertar_player( string _mensagem ){

                Debug.Log( "fazer mensagem depois" );
                Debug.Log( _mensagem );
                return;

            }

      }


      public void Ativar_new_game() {




            #if UNITY_EDITOR

                // *** ativar pelo menu vai funcionar somente na build
                //return;

            #endif



            

            int save = Pegar_save_disponivel();

            if( save == -1 ){

                    // *nao tem saves livres 

                    Sistema_mensagens.Alertar_player( "nao tem saves disponivel" );
                    // nao deixa iniciar o jogo
                    return; 

            }


            Controlador.Pegar_instancia().jogo = Jogo.Construir();
            Task_req task_para_carregar = Primeiro_jogo_suporte.Pegar_task_criar_primeiro_jogo_default( _save: save , _novo_jogo: true  );
            Controlador_multithread.Pegar_instancia().Adicionar_task( task_para_carregar );


            Mono_instancia.Start_coroutine( New_game_start_c() );

            IEnumerator New_game_start_c(){

                    
                    GameObject game_object = new GameObject( "canvas_menu_transicao" );
                    Image imagem = IMAGE.Criar_imagem  (
                        
                                                            _game_object: game_object,
                                                            _pai : ( Controlador.Pegar_instancia().canvas ),
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

                        if( task_para_carregar.finalizado )
                            { break; }

                        continue;

                    }

                    

                    GameObject.Destroy( canvas_menu );
                    Controlador.Pegar_instancia().menu = null;
                    Controlador.Pegar_instancia().modo_controlador_atual = Controlador_modo.jogo;


                    yield break;


            }





          



    	}


                          //    360 /   1200  / 360 
                          //      +- 1560

     public void Ir_saves(){ if(coroutine_atual != null) { estado_atual = Menu_type.transicao;  Mono_instancia.Stop_coroutine(coroutine_atual); }; coroutine_atual = Mono_instancia.Start_coroutine( Ir_coroutine(-1560f, Menu_type.saves)); }
     public void Ir_configurations(){ if(coroutine_atual != null) { estado_atual = Menu_type.transicao; Mono_instancia.Stop_coroutine(coroutine_atual)   ; }; coroutine_atual =  Mono_instancia.Start_coroutine(Ir_coroutine(-3120f, Menu_type.configurations)); }
     public void Ir_new_game(){ if(coroutine_atual != null) { estado_atual = Menu_type.transicao; Mono_instancia.Stop_coroutine(coroutine_atual)   ; }; coroutine_atual =  Mono_instancia.Start_coroutine(Ir_coroutine(0f, Menu_type.new_game)); }
     public void Ir_galery(){ if(coroutine_atual != null) { estado_atual = Menu_type.transicao; Mono_instancia.Stop_coroutine(coroutine_atual)   ; }; coroutine_atual =  Mono_instancia.Start_coroutine(Ir_coroutine(1560f, Menu_type.galeria)); }
     public void Ir_characters(){ if(coroutine_atual != null) { estado_atual = Menu_type.transicao; Mono_instancia.Stop_coroutine(coroutine_atual)   ; }; coroutine_atual =  Mono_instancia.Start_coroutine(Ir_coroutine(3120f, Menu_type.personagens)); }


    IEnumerator Ir_coroutine(float x_position, Menu_type _novo_tipo){

        float x_inicial = canvas_menu_movel.transform.localPosition.x;
        float x_dif = x_inicial - x_position;

        float t_x_dif = Mathf.Abs(x_dif);
        float speed_ms = t_x_dif > 6000f ? 600f : t_x_dif > 4000f ?  500f  : t_x_dif > 3000f ?  400f :  300f ;

        float numero_ciclos = speed_ms * 60f / 1000f;
        float d_x = x_dif / numero_ciclos;
        float count = 0f;


        while(  count <  numero_ciclos  ){

            count += 1f;
            x_inicial -= d_x;

            canvas_menu_movel.transform.localPosition = new Vector3( x_inicial , 0f , 0f);
            yield return null;

        }

        canvas_menu_movel.transform.localPosition = new Vector3(x_position,0f,0f);
        coroutine_atual = null;
        estado_atual = _novo_tipo;

        yield break;

          

    }

        public void Verificar_galeria(){

            int p0 =  numero_pagina_galeria * 6;
            for(int i = 0 ;  i < 6 ; i++){

                bool esta_liberada = controlador_configuracoes.galeria_imagens_liberadas[i];
                if( esta_liberada ){  

                  // tem que passar depois para o sistema proprio
                  string path_imagem = "images/menu_images/galeria_image_" + Convert.ToString( i );
                  Sprite imagem_persoangem_galeria_quadro = Resources.Load<Sprite>( path_imagem );
                  menu_galery_arr[i].image.sprite = imagem_persoangem_galeria_quadro;

                }

            }

            return;

        }


        public void Passar_pagina_galeria(){


            int max =  ( controlador_configuracoes.galeria_imagens_liberadas.Length / 6 );

            if(  numero_pagina_galeria  +  1  > max  ){ return; }

            numero_pagina_galeria++;
  
            Verificar_galeria();

        }


        public void Voltar_pagina_galeria(){

            if(  numero_pagina_galeria  - 1  < 0  ) { return; }
            numero_pagina_galeria--;   
            Verificar_galeria();

        }



        public void Verificar_saves() {


            // fazer depois

            // Save_menu_info save_menu_info = dados_blocos.menu_START.save_menu_info;
            
            // if(save_menu_info == null) return;

            // for(  int i = 0 ; i < 4 ; i++  ){

            //       if(save_menu_info.is_active_arr[i]){

            //       menu_saves_arr[i].image.sprite = save_menu_info.image_save_arr[i];
            //       menu_save_information_arr[i].progresso.text = "Progress : " + save_menu_info.progresso_arr[i];
            //       menu_save_information_arr[i].tempo_total_jogo.text = "Time : " + save_menu_info.save_time_arr[i];
            //       menu_save_information_arr[i].x_image.color = new Color(1f,1f,1f, 0f);

            //       }
            //       continue;

            // }


        }
     
    
}
