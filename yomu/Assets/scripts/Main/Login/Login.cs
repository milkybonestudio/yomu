using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;


public  class Login {



        public static Login instancia;
        public static Login Pegar_instancia(){ return instancia; }
        public static Login Construir(){ instancia = new Login(); return instancia ;}


        public Login(){


        
            posicao_mouse = CONTROLLER__data.Pegar_instancia().posicao_mouse;

            // Menu e login vão sempre mudar diretamente o modo do controlador
            Controlador.Pegar_instancia().modo_controlador_atual = Controlador_modo.login;

            Iniciar_login();
            return;
            

        }


        public  Coroutine login_coroutine;
        public  GameObject canvas_login;
        public  Image canvas_login_image;

        public GameObject correntes;
        public Image imagem_correntes;

        // ** MUDOU
        // public  Botao botao;
        public UI_button botao;


        public  float[] posicao_mouse;
        // todas vão ser deletadas quando o mobjeto for destruido
        public Chave_cache[] chaves_imagens;

        
        public GameObject canvas;



        public bool esta_entrando_menu = false;

        public void Update(){


                if( esta_entrando_menu )
                    { return; }

                if( Input.GetMouseButtonDown( 0 ) )
                    { CONTROLLER__audio.Pegar_instancia().Acrecentar_sfx( "audio/geral_sfx/botoes/click_4"  ); }
                    
                botao.Update();

        }


    

        public  void Iniciar_login(){


                // string nome_background = CONTROLLER__configurations.Pegar_instancia().login_background;

                // Sprite login_image = Resources.Load<Sprite>("images/login_images/" + nome_background);
                    
                // canvas = GameObject.Find("Tela/Canvas");                

                // canvas_login =  new GameObject("Canvas_login");
                // canvas_login.transform.SetParent(canvas.transform, false);
                // canvas_login_image  =    canvas_login.AddComponent<Image>();
                // RectTransform rect = canvas_login.GetComponent<RectTransform>();
                // rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal , 1920f);
                // rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical , 1080f);


                // correntes = new GameObject("Correntes");
                // correntes.transform.SetParent(canvas_login.transform, false);

                // imagem_correntes = correntes.AddComponent<Image>();
                // imagem_correntes.color = Color.clear;

                // RectTransform rect_corrente = correntes.GetComponent<RectTransform>();

                // rect_corrente.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal , 1920f);
                // rect_corrente.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical , 1080f);

                // canvas_login_image.sprite = login_image;
                // canvas_login_image.color = Color.black;

                // Sprite[] imagens = new Sprite[2];
                // imagens[0] = Resources.Load<Sprite>("images/login_images/login_botao_off");
                // imagens[1] = Resources.Load<Sprite>("images/login_images/login_botao_on");
                
                
                // botao = new Botao(

                //     "Botao_login",
                //     250f,
                //     85f,
                //     0f,
                //     -64f,
                //     canvas_login.transform,
                //     Entrar_menu,
                //     Tipo_botao.dinamico,
                //     true, 
                //     imagens
                
                // );

                // botao.Colocar_texto(

                //     "Iniciar",
                //     200f ,
                //     75f ,
                //     50f

                // );


                // botao.Mudar_cor_hover(Cor_cursor.red);

                // botao.Esconder_botao(0f);
                // botao.Trancar_botao();

                
                // login_coroutine = Mono_instancia.Start_coroutine(  Iniciar_login_coroutine()  );
                
                // string audio_path  = "audio/blocos_pequenos/login/" + CONTROLLER__configurations.Pegar_instancia().music_login;

                // CONTROLLER__audio.Pegar_instancia().Start_music( _slot: 1 , _path_completo: audio_path , _tempo_ms_tirar : 0f , _tempo_ms_colocar : 500f , _modificador_volume: 0.7f );

                    
        }


        
        public void Entrar_menu(){

                esta_entrando_menu = true;

                Mono_instancia.Start_coroutine( Entrar_menu_c() );

                IEnumerator Entrar_menu_c(){


                        // inicia a pegar as imagens do menu no miultithread


                        yield return null;


                        GameObject transicao_canvas = new GameObject( "transicao_canvas" );
                        transicao_canvas.transform.SetParent( canvas_login.transform,  false );

                        Image transicao_image = transicao_canvas.AddComponent<Image>();

                        RectTransform rect = transicao_canvas.GetComponent<RectTransform>();
                        rect.SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, 1080f );
                        rect.SetSizeWithCurrentAnchors( RectTransform.Axis.Horizontal, 1920f );
                        transicao_image.color = Color.clear;


                        float variante = 0.01f;

                        // vai para o 1f => preto
                        while( transicao_image.color.a < 0.95f ){

                                float cor_atual = transicao_image.color[ 3 ];
                                float nova_cor = cor_atual + variante;
                                
                                transicao_image.color = new Color( 0f, 0f, 0f, nova_cor );  
                                yield return null;

                        }


                        Controlador.Pegar_instancia().menu = Menu.Construir();
                        Debug.Log( Controlador.Pegar_instancia().menu );
                        Controlador.Pegar_instancia().login = null;

                        Controlador.Pegar_instancia().modo_controlador_atual = Controlador_modo.menu; 

                        
                        // colocar depois
                        // Controlador_cache.Pegar_instancia().Excluir_dados( chaves_imagens );

                        
                        GameObject.Destroy( canvas_login );

                        instancia = null;

                        yield break;


                }


        }


        


        public IEnumerator Iniciar_login_coroutine(){

                
                // yield return new WaitForSeconds(1.5f);

                // float d_a = 0.005f;

                // float total_cor = 0f;

                // while(canvas_login_image.color.r < 0.95f ){

                //         float total_cor_alterada = total_cor * total_cor;

                //         Color cor_atual = new Color(total_cor_alterada, total_cor_alterada, total_cor_alterada, 1f);  
                //         canvas_login_image.color = cor_atual;
                //         total_cor += d_a;
                //         yield return null;

                // }

                
                // canvas_login_image.color = new Color(  1f ,   1f,   1f,   1f  );

                // CONTROLLER__audio.Pegar_instancia().Acrecentar_sfx( "audio/blocos_pequenos/login/correntes_abrindo" );

                // yield return new WaitForSeconds(0.25f);

                // imagem_correntes.sprite = Resources.Load<Sprite>("images/login_images/login_botao_correntes");


                // total_cor = 0f;
                // d_a = 0.01f;

                // while(imagem_correntes.color.a < 0.95f ){

                //         Color cor_atual = new Color(1f, 1f, 1f, total_cor);  
                //         imagem_correntes.color = cor_atual;
                //         total_cor += d_a;
                //         yield return null;

                // }

                // imagem_correntes.color = new Color(  1f ,   1f,   1f,   1f  );


                // yield return Mono_instancia.Start_coroutine(  botao.Mudar_visibilidade_botao_c( 1f, 750f ) );

                // botao.Liberar_botao();
                
                yield break;
            

        }


}
