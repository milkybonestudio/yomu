using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public  class BLOCO_login {



    public bool pode_entrar_menu = false;



      
    public static BLOCO_login instancia;
    public static BLOCO_login Pegar_instancia( bool _forcar = false  ){

            if( _forcar ) {if( Verificador_instancias_nulas.Verificar_se_pode_criar_objetos("BLOCO_login")) { instancia = new BLOCO_login();instancia.Iniciar();} return instancia;}
            if(  instancia == null) { instancia = new BLOCO_login(); instancia.Iniciar(); }
            return instancia;

    }


    public  Coroutine login_coroutine;
    public  GameObject canvas_login;
    public  Image canvas_login_image;

    public GameObject correntes;
    public Image imagem_correntes;
    public  Botao botao;
    public  float[] posicao_mouse;

    public Dados_blocos dados_blocos;


   

    public void Iniciar(){

          posicao_mouse = Controlador_data.Pegar_instancia(true).posicao_mouse;
          dados_blocos = Dados_blocos.Pegar_instancia(true);

          return;

    }




    public void Update(){


            bool mouse_down = Controlador_input.Get_down(Key_code.mouse_left);

            if( mouse_down )  Controlador_audio.Pegar_instancia().Acrecentar_sfx( "audio/geral_sfx/botoes/click_4"  );
                
            botao.Update(   mouse_down ,  posicao_mouse);



            // if(pode_entrar_menu){
            
            //     _data.login_data_OUTPUT = new Login_data_OUTPUT();

            //     //Zerar_dados();
            
            // }

          
    }


    



    public void Entrar_menu(){ 


        // mudar formato

        // Dados_blocos dados_blocos = Dados_blocos.Pegar_instancia();

        // Req_transicao req = new Req_transicao (

        //     Tipo_troca_bloco.SWAP,
        //     Bloco.menu,
        //     Tipo_transicao.cor
        
        // );




        //  dados_blocos.req_transicao = req;



        // pode_entrar_menu = true;
        
    }

    public GameObject canvas;


    public  void Iniciar_login(){



        Controlador_input.ativar_movimentacao_mouse = true;
        Controlador_cursor.Pegar_instancia().Mudar_cursor(Cor_cursor.off);
        Controlador_input.tipo_teclado = Tipo_teclado.normal;



        Login_START data = dados_blocos.login_START;


        Sprite login_image = data.background_image;
            
        canvas = GameObject.Find("Tela/Canvas/Login");

        canvas_login =  new GameObject("Canvas_login");


          canvas_login.transform.SetParent(canvas.transform, false);
          canvas_login_image  =    canvas_login.AddComponent<Image>();
          RectTransform rect = canvas_login.GetComponent<RectTransform>();
          rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal , 1920f);
          rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical , 1080f);

          




          correntes = new GameObject("Correntes");
 
          correntes.transform.SetParent(canvas_login.transform, false);

          imagem_correntes = correntes.AddComponent<Image>();
          imagem_correntes.color = Color.clear;

          RectTransform rect_corrente = correntes.GetComponent<RectTransform>();

          rect_corrente.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal , 1920f);
          rect_corrente.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical , 1080f);





          canvas_login_image.sprite = login_image;
          canvas_login_image.color = Color.black;


          Sprite[] imagens = new Sprite[2];
          imagens[0] = Resources.Load<Sprite>("images/login_images/login_botao_off");
          imagens[1] = Resources.Load<Sprite>("images/login_images/login_botao_on");
          
          
          botao = new Botao(

          "Botao_login",
          250f,
          85f,
          0f,
          -64f,
          canvas_login.transform,
          Entrar_menu,
          Tipo_botao.dinamico,
          true, 
          imagens
        
          );

          botao.Colocar_texto(
          "Iniciar",
          200f ,
          75f ,
          50f

          );


          botao.Mudar_cor_hover(Cor_cursor.red);

          botao.Esconder_botao(0f);
          botao.Trancar_botao();

        
      login_coroutine = Mono_instancia.Start_coroutine(  Iniciar_login_coroutine()  );


      string audio_path  = "audio/blocos_pequenos/login/" + Controlador_configuration.Pegar_instancia().music_login;


      Controlador_audio.Pegar_instancia().Start_music( _slot: 1 , _path_completo: audio_path , _tempo_ms_tirar : 0f , _tempo_ms_colocar : 500f , _modificador_volume: 0.7f );

      
      
      // AudioClip clip = Resources.Load<AudioClip>(audio_path);


      // float audio_volume = controlador.controlador_configuration.volume /100f;
       
      // audio_login.volume = audio_volume;
      
      // audio_login.clip = clip;
      
      // audio_login.Play();


        
    }



    public void Zerar_dados(){


      canvas = null;
      canvas_login = null;
      canvas_login_image = null;
      pode_entrar_menu = false;

    }
    


    public  IEnumerator Iniciar_login_coroutine(){

          

          yield return new WaitForSeconds(1.5f);


          float d_a = 0.005f;

          float total_cor = 0f;

          while(canvas_login_image.color.r < 0.95f ){

              float total_cor_alterada = total_cor * total_cor;

              Color cor_atual = new Color(total_cor_alterada, total_cor_alterada, total_cor_alterada, 1f);  
              canvas_login_image.color = cor_atual;
              total_cor += d_a;
              yield return null;

          }

          
          canvas_login_image.color = new Color(  1f ,   1f,   1f,   1f  );

          Controlador_audio.Pegar_instancia().Acrecentar_sfx( "audio/blocos_pequenos/login/correntes_abrindo" );

          yield return new WaitForSeconds(0.25f);

          imagem_correntes.sprite = Resources.Load<Sprite>("images/login_images/login_botao_correntes");


          total_cor = 0f;
          d_a = 0.01f;

          while(imagem_correntes.color.a < 0.95f ){

              Color cor_atual = new Color(1f, 1f, 1f, total_cor);  
              imagem_correntes.color = cor_atual;
              total_cor += d_a;
              yield return null;

          }

          imagem_correntes.color = new Color(  1f ,   1f,   1f,   1f  );


          

          yield return Mono_instancia.Start_coroutine(  botao.Mudar_visibilidade_botao_c( 1f, 750f ) );

          botao.Liberar_botao();
          yield break;
    

    }





   

}
