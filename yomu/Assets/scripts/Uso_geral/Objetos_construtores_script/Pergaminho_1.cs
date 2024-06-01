using UnityEngine; 
using UnityEngine.UI ;
using System;
using System.Collections;
using TMPro;


   public class Pergaminho_modelo_1 {


        public static Pergaminho_modelo_1 pergaminho;



        public bool esta_escondido = false;
         
                
        public Display_texto display_texto;
        public Display_texto_simples nome;


        public Coroutine afastar_pergaminho_coroutine;
        
        public Coroutine                    pergaminho_coroutine;
        public Coroutine                    mudar_posicao_pergaminho_coroutine = null;
        
        public float                        pergaminho_direcao        =     1f ;
        public float                        pergaminho_abaixado       =  -880f ;
        public float                        pergaminho_levantado      =  -550f ;

        public bool                         pergaminho_em_movimento   =   false ;

        public bool                         pergaminho_is_abaixado    =   true ;

        public Lado                         lado_pergaminho_atual          = Lado.baixo;

        public   RectTransform             pergaminho_rect;


        public    GameObject            pergaminho_container;
        public    GameObject            pergaminho_texto;

        public    Image                 pergaminho_texto_image;



        // usa para choices 
        public    GameObject            pergaminho_choices;

        public    GameObject            pergaminho_choice_parte_1;
        public    Image                 pergaminho_choice_parte_1_image;

        public    GameObject            pergaminho_choice_parte_2;
        public    Image                 pergaminho_choice_parte_2_image;

        public    GameObject            pergaminho_choice_papel;
        public    Image                 papel_choice_image_game_object_image;

        public    Nome_cor              cor_pergaminho_atual = Nome_cor.white;


        public   GameObject[]           choices_game_objects = new GameObject[5];
        public   TMP_Text[]             choices_text = new TMP_Text[5];


        public string pergunta_atual = null;
        public int pergunta_index = -1;
        public string[] possiveis_respostas = null;
        public float[][] choices_areas = new float[5][];
        public bool choices_esta_ativa = false;
        public bool choices_concluida = false;


        

        public bool blocos_conversas_esta_ativo = false;
        public bool blocos_conversas_esta_concluido = false;
        public int[] blocos_numeros = null;
        public Display_texto_simples[] blocos_textos = null;
        public float[][] blocos_conversas_areas = null;

        


        public float pergaminho_width = 941f;
        public float pergaminho_height = 772f;
        public float pergaminho_default_position = -872f;
        public float pergaminho_default_choice_position = -512f;


        public float choice_text_width = 800f;
        public float choice_text_height = 50f;
        public float choice_font_size = 50f;
        public float altura_espaco = 50f;

        public float choice_pergaminho_height = 26f;

        // public float choice_width = 941f;
        // public float choice_height = 26f;

        public float pergaminho_choice_parte_1_posicao = 13f;
        public float pergaminho_choice_parte_2_posicao = -13f;

        public float choice_inicial_position = 0f;



        public int numero_bloqueio_clicks = 0;

        public bool Aceita_clicks(){

                if( numero_bloqueio_clicks < 1 ) return true;

                numero_bloqueio_clicks--;
                return false;

        }

        public void Mudar_bloqueio_clicks(int _numero){

                numero_bloqueio_clicks = _numero;
                return;

        }



        public Pergaminho_modelo_1( Transform _pai  ){


                

                pergaminho = this;

                // string _path = ""
                // GameObject pai = GameObject.Find(_path);
                // if(pai == null ) throw new ArgumentException("nao foi achado game object pergaminho");


                pergaminho_container = new GameObject("Pergaminho_container");

                pergaminho_container.transform.SetParent( _pai, false );

        
                GameObject suporte_pergaminho_1 = new GameObject("Suporte_pergaminho_1");

                        suporte_pergaminho_1.transform.SetParent(pergaminho_container.transform, false );

                        Image suporte_pergaminho_1_image = suporte_pergaminho_1.AddComponent<Image>();
                        suporte_pergaminho_1_image.sprite = Resources.Load<Sprite>("images/in_game/ui/interface/dialogo/suporte_pergaminho_modelo_1_parte_1");
                        RectTransform    rect_suporte_pergaminho_1 = suporte_pergaminho_1.GetComponent<RectTransform>();
                        
                        /*
                        *   depois mudar, a imagem esta por hora como furu hd
                        */
                                            
                        rect_suporte_pergaminho_1.SetSizeWithCurrentAnchors(  RectTransform.Axis.Vertical , 1080f );
                        rect_suporte_pergaminho_1.SetSizeWithCurrentAnchors(  RectTransform.Axis.Horizontal , 1920f );
                
                        // pergaminho_texto

                        pergaminho_texto = new GameObject("Pergaminho_texto");

                                pergaminho_texto.transform.SetParent(pergaminho_container.transform , false);
                                pergaminho_texto.transform.localPosition = new Vector3(  0f, pergaminho_default_position  ,0f);

                                pergaminho_texto_image = pergaminho_texto.AddComponent<Image>();
                                pergaminho_texto_image.sprite = Resources.Load<Sprite>("images/in_game/ui/interface/dialogo/pergaminho_aberto_chao");

                                RectTransform pergaminho_texto_rect = pergaminho_texto.GetComponent<RectTransform>();
                                pergaminho_texto_rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, pergaminho_height);
                                pergaminho_texto_rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, pergaminho_width);

                                display_texto = new Display_texto( _nome : "Texto", _width : 827f, _height : 265f, _font_size : 40f);
                                display_texto.Setar_display(pergaminho_texto.transform, 0f, 178f);

                                nome = new Display_texto_simples( _nome : "Nome", _width : 800f, _height : 50f, _font_size : 34f);
                                nome.Setar_display(pergaminho_texto.transform, -15f,330f );


                        //
                        pergaminho_choices = new GameObject("Pergaminho_choices");
                        pergaminho_choices.transform.SetParent(pergaminho_container.transform, false);

                        pergaminho_choices.transform.localPosition = new Vector3(0f, pergaminho_default_choice_position , 0f);

                                pergaminho_choice_papel = new GameObject("Papel_choice");
                                pergaminho_choice_papel.transform.SetParent(pergaminho_choices.transform, false);
                                //pergaminho_choice_papel.transform.localPosition = new Vector3(  0f, pergaminho_default_position  ,0f);
                                pergaminho_choice_papel.AddComponent<RectMask2D>();
                                RectTransform rect   =  pergaminho_choice_papel.GetComponent<RectTransform>();
                                
                                
                                // muda com a mask
                                rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical  ,  0f);
                                rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal  ,pergaminho_width  );



                                        GameObject papel_choice_image_game_object = new GameObject("Papel_choice_image");
                                        papel_choice_image_game_object.transform.SetParent(pergaminho_choice_papel.transform, false);
                                        

                                        papel_choice_image_game_object_image = papel_choice_image_game_object.AddComponent<Image>();

                                        papel_choice_image_game_object_image.sprite  = Resources.Load<Sprite>("images/in_game/ui/interface/dialogo/pergaminho_aberto_chao");

                                        RectTransform rect_papel_choice_image_game_object   =  papel_choice_image_game_object.GetComponent<RectTransform>();

                                        // muda com a mask
                                        rect_papel_choice_image_game_object.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical  ,  pergaminho_height);
                                        rect_papel_choice_image_game_object.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal  ,pergaminho_width  );

                                        for(int i = 0 ;  i < 5 ; i++){

                                                choices_game_objects[i] = new GameObject("Choice_" + Convert.ToString(i + 1));
                                                
                                                choices_game_objects[i].transform.SetParent(pergaminho_choices.transform, false);

                                                TMP_Text a =  choices_game_objects[i].AddComponent<TextMeshProUGUI>();
                                                a.alignment = TextAlignmentOptions.MidlineGeoAligned;
                                                
                                                choices_text[i] = a;


                                             //  choices_text[i]  = (TMP_Text)  ( choices_game_objects[i].AddComponent<TextMeshProUGUI>());
                                                choices_text[i].fontSize = choice_font_size;

                                                RectTransform rect_choice = choices_game_objects[i] .GetComponent<RectTransform>();
                                                    
                                                rect_choice.SetSizeWithCurrentAnchors(  RectTransform.Axis.Vertical , choice_text_height );
                                                rect_choice.SetSizeWithCurrentAnchors(  RectTransform.Axis.Horizontal , choice_text_width );


                                        }

                                pergaminho_choice_parte_1 = new GameObject("Pergaminho_fechado_parte_1");
                                pergaminho_choice_parte_1.transform.SetParent(pergaminho_choices.transform, false);
                                pergaminho_choice_parte_1.transform.localPosition = new Vector3(0f, pergaminho_choice_parte_1_posicao  ,0f);
                                

                                pergaminho_choice_parte_1_image  = pergaminho_choice_parte_1.AddComponent<Image>();
                                pergaminho_choice_parte_1_image.sprite = Resources.Load<Sprite>("images/in_game/ui/interface/dialogo/pergaminho_1");

                                RectTransform rect_choice_1 = pergaminho_choice_parte_1.GetComponent<RectTransform>();
                                    
                                rect_choice_1.SetSizeWithCurrentAnchors(  RectTransform.Axis.Vertical , choice_pergaminho_height );
                                rect_choice_1.SetSizeWithCurrentAnchors(  RectTransform.Axis.Horizontal , pergaminho_width );




                                pergaminho_choice_parte_2 = new GameObject("Pergaminho_fechado_parte_2");
                                pergaminho_choice_parte_2.transform.SetParent(pergaminho_choices.transform, false);
                                pergaminho_choice_parte_2.transform.localPosition = new Vector3(0f, pergaminho_choice_parte_2_posicao  ,0f);

                                pergaminho_choice_parte_2_image  = pergaminho_choice_parte_2.AddComponent<Image>();
                                pergaminho_choice_parte_2_image.sprite = Resources.Load<Sprite>("images/in_game/ui/interface/dialogo/pergaminho_2");
                                                                
                                RectTransform rect_choice_2 = pergaminho_choice_parte_2.GetComponent<RectTransform>();
                                    
                                rect_choice_2.SetSizeWithCurrentAnchors(  RectTransform.Axis.Vertical , choice_pergaminho_height );
                                rect_choice_2.SetSizeWithCurrentAnchors(  RectTransform.Axis.Horizontal , pergaminho_width );

                            ///




                /// suporte_2



                GameObject suporte_pergaminho_2 = new GameObject("Suporte_pergaminho_2");
                suporte_pergaminho_2.transform.SetParent(pergaminho_container.transform, false );

                Image suporte_pergaminho_2_image = suporte_pergaminho_2.AddComponent<Image>();
                suporte_pergaminho_2_image.sprite = Resources.Load<Sprite>("images/in_game/ui/interface/dialogo/suporte_pergaminho_modelo_1_parte_2");
                RectTransform    rect_suporte_pergaminho_2 = suporte_pergaminho_2.GetComponent<RectTransform>();

                 
                 /*
                 *   depois mudar, a imagem esta por hora como furu hd
                 */
                                    
                rect_suporte_pergaminho_2.SetSizeWithCurrentAnchors(  RectTransform.Axis.Vertical , 1080f );
                rect_suporte_pergaminho_2.SetSizeWithCurrentAnchors(  RectTransform.Axis.Horizontal , 1920f );

                pergaminho_choices.SetActive(false);
                
          }




        public Coroutine mudar_cor_pergaminho_coroutine = null;
        
        

      // Mudar_cor_pergaminho(0, Color.white);

        public void Mudar_cor_pergaminho(   Nome_cor _nome_cor ){


                cor_pergaminho_atual = _nome_cor;
                Color cor_final  = Cores.Pegar_cor( _nome_cor ) ;




                if(mudar_cor_pergaminho_coroutine != null) {Mono_instancia.Stop_coroutine(mudar_cor_pergaminho_coroutine);mudar_cor_pergaminho_coroutine = null;}

                Color cor_inicial = pergaminho_texto_image.color;

                Image[] locais = new Image[4];

                locais[0] = pergaminho_texto_image;
                locais[1] = pergaminho_choice_parte_1_image;
                locais[2] = pergaminho_choice_parte_2_image;
                locais[3] = papel_choice_image_game_object_image;

                mudar_cor_pergaminho_coroutine = Mono_instancia.Start_coroutine( Coroutine_ferramentas.Transicionar_cor(  cor_inicial , cor_final, 300f, locais));
                return;
                
        }


        





        public void Mudar_posicao_pergaminho(  string _lado  ){



                if( this.esta_escondido ){ 

                        Debug.Log("pergaminho esta escondido");
                        Debug.Log("lado: " + _lado);
                        return; }



                if(mudar_posicao_pergaminho_coroutine != null) {

                        if(afastar_pergaminho_coroutine != null) { Mono_instancia.Stop_coroutine(afastar_pergaminho_coroutine); }

                        Forcar_mudar_posicao_pergaminho();
                        Mono_instancia.Stop_coroutine(mudar_posicao_pergaminho_coroutine);
                        mudar_posicao_pergaminho_coroutine = null;

                }

                if(pergaminho_coroutine != null) {

                     
                        Mono_instancia.Stop_coroutine(pergaminho_coroutine);
                        pergaminho_coroutine = null;
                        
                };


                        Mudar_bloqueio_clicks(5);


                      
                        bool  pergaminho_esta_levantado = !pergaminho_is_abaixado;

                        Lado novo_lado =   (Lado)  Enum.Parse(  typeof(Lado) , _lado  );
                        

                        float pergaminho_container_rotation = 0f;
                        float pergaminho_container_position_x = 0f;
                        float pergaminho_container_position_y = 0f;


                        float display_width  = 0f; 
                        float display_height = 0f;

                        float display_container_rotation = 0f;
                        float display_container_position_x = 0f;
                        float display_container_position_y = 0f;

                        float nome_container_rotation = 0f;
                        float nome_container_position_x = 0f;
                        float nome_container_position_y = 0f;

                        float pergaminho_levantado_novo_valor = 0;


                        if(novo_lado == Lado.cima){
                                                        
                                pergaminho_container_rotation = 180f;
                                pergaminho_container_position_x = 0f;
                                pergaminho_container_position_y = 45f;

                                display_width  = 827f; 
                                display_height = 265f;

                                display_container_rotation = 180f;
                                display_container_position_x = 0f;
                                display_container_position_y = 230f;


                                nome_container_rotation = 180f;
                                nome_container_position_x = 15f;
                                nome_container_position_y = 75f;

                                pergaminho_levantado_novo_valor = -550;

                        } else 

                        if(novo_lado == Lado.baixo) {

                                pergaminho_container_rotation = 0f;
                                pergaminho_container_position_x = 0f;
                                pergaminho_container_position_y = -45f;

                                display_width  = 827f; 
                                display_height = 265f;

                                display_container_rotation = 0f;
                                display_container_position_x = 0f;
                                display_container_position_y = 178f;


                                nome_container_rotation = 0f;
                                nome_container_position_x = -15f;
                                nome_container_position_y = 330f;

                                pergaminho_levantado_novo_valor = -550f;                                


                        } else
                        if(novo_lado == Lado.direita) {

                                pergaminho_container_rotation = 90f;
                                pergaminho_container_position_x = 467f;
                                pergaminho_container_position_y = 0f;

                                display_width  = 550f; 
                                display_height = 827f;

                                display_container_rotation = -90f;
                                display_container_position_x = -84f;
                                display_container_position_y = 75f;


                                nome_container_rotation = -90f;
                                nome_container_position_x = 360f;
                                nome_container_position_y = -60f;

                                pergaminho_levantado_novo_valor = -300f;


                        } else

                        if(novo_lado == Lado.esquerda) {

                                pergaminho_container_rotation = -90f;
                                pergaminho_container_position_x = -467f;
                                pergaminho_container_position_y = 0f;

                                display_width  = 550f; 
                                display_height = 827f;

                                display_container_rotation = 90f;
                                display_container_position_x = 84f;
                                display_container_position_y = 95f;


                                nome_container_rotation = 90f;
                                nome_container_position_x = -360f;
                                nome_container_position_y = 208f;

                                pergaminho_levantado_novo_valor = -300;

                        } 


                mudar_posicao_pergaminho_coroutine = Mono_instancia.Start_coroutine(  Mudar_posicao_para_cima_c()  );

                IEnumerator Mudar_posicao_para_cima_c(){


                        pergaminho_coroutine  = Mono_instancia.Start_coroutine(  Abaixar_pergaminho_c()  );

                        yield return pergaminho_coroutine;

                        yield return new WaitForSeconds(0.2f);

                        afastar_pergaminho_coroutine = Mono_instancia.Start_coroutine(  Afastar_pergaminho()  );
                        
                        yield return afastar_pergaminho_coroutine;

                        pergaminho_texto.transform.localPosition = new Vector3(  0f,  pergaminho_abaixado ,0f);

                        
                        pergaminho_container.transform.localRotation = Quaternion.Euler( 0f,0f, pergaminho_container_rotation );
                        pergaminho_container.transform.localPosition = new Vector3(   pergaminho_container_position_x, pergaminho_container_position_y ,0f  );


                        display_texto.Mudar_tamanho(  display_width , display_height  );
                        display_texto.game_object.transform.localRotation = Quaternion.Euler(  0f,  0f, display_container_rotation );
                        display_texto.game_object.transform.localPosition = new Vector3(  display_container_position_x  , display_container_position_y, 0f  );


                        nome.game_object.transform.localRotation = Quaternion.Euler(  0f,  0f, nome_container_rotation );
                        nome.game_object.transform.localPosition = new Vector3(  nome_container_position_x , nome_container_position_y, 0f  );

                        

                        pergaminho_levantado =  pergaminho_levantado_novo_valor;

                        lado_pergaminho_atual   =  novo_lado;



                        yield return new WaitForSeconds(0.4f);

                        yield return Mono_instancia.Start_coroutine(  Trazer_pergaminho()  );

                        yield return new WaitForSeconds(0.2f);

                        if( pergaminho_esta_levantado ) { Levantar_pergaminho(); }

                        Mudar_bloqueio_clicks(0);
                        
                        mudar_posicao_pergaminho_coroutine = null;
                        yield break;


                }

        }





        public void Forcar_mudar_posicao_pergaminho( ){


                      
                        bool  pergaminho_esta_levantado = !pergaminho_is_abaixado;


                        float pergaminho_container_rotation = 0f;
                        float pergaminho_container_position_x = 0f;
                        float pergaminho_container_position_y = 0f;


                        float display_width  = 0f; 
                        float display_height = 0f;

                        float display_container_rotation = 0f;
                        float display_container_position_x = 0f;
                        float display_container_position_y = 0f;

                        float nome_container_rotation = 0f;
                        float nome_container_position_x = 0f;
                        float nome_container_position_y = 0f;

                        float pergaminho_levantado_novo_valor = 0;


                        if(lado_pergaminho_atual == Lado.cima){
                                                        
                                pergaminho_container_rotation = 180f;
                                pergaminho_container_position_x = 0f;
                                pergaminho_container_position_y = 0f;

                                display_width  = 827f; 
                                display_height = 265f;

                                display_container_rotation = 180f;
                                display_container_position_x = 0f;
                                display_container_position_y = 230f;


                                nome_container_rotation = 180f;
                                nome_container_position_x = 300f;
                                nome_container_position_y = 75f;

                                pergaminho_levantado_novo_valor = -550;

                        } else 

                        if(lado_pergaminho_atual == Lado.baixo) {

                                pergaminho_container_rotation = 0f;
                                pergaminho_container_position_x = 0f;
                                pergaminho_container_position_y = 0f;

                                display_width  = 827f; 
                                display_height = 265f;

                                display_container_rotation = 0f;
                                display_container_position_x = 0f;
                                display_container_position_y = 178f;


                                nome_container_rotation = 0f;
                                nome_container_position_x = -300f;
                                nome_container_position_y = 330f;

                                pergaminho_levantado_novo_valor = -550f;                                


                        } else
                        if(lado_pergaminho_atual == Lado.direita) {

                                pergaminho_container_rotation = 90f;
                                pergaminho_container_position_x = 422f;
                                pergaminho_container_position_y = 0f;

                                display_width  = 550f; 
                                display_height = 827f;

                                display_container_rotation = -90f;
                                display_container_position_x = -84f;
                                display_container_position_y = 75f;


                                nome_container_rotation = -90f;
                                nome_container_position_x = 360f;
                                nome_container_position_y = 230f;

                                pergaminho_levantado_novo_valor = -300f;


                        } else

                        if(lado_pergaminho_atual == Lado.esquerda) {

                                pergaminho_container_rotation = -90f;
                                pergaminho_container_position_x = -422f;
                                pergaminho_container_position_y = 0f;

                                display_width  = 550f; 
                                display_height = 827f;

                                display_container_rotation = 90f;
                                display_container_position_x = 84f;
                                display_container_position_y = 95f;


                                nome_container_rotation = 90f;
                                nome_container_position_x = -360f;
                                nome_container_position_y = -85f;

                                pergaminho_levantado_novo_valor = -300;

                        } 


                        pergaminho_texto.transform.localPosition = new Vector3(  0f,  pergaminho_abaixado ,0f);

                        pergaminho_container.transform.localRotation = Quaternion.Euler( 0f,0f, pergaminho_container_rotation );
                        pergaminho_container.transform.localPosition = new Vector3(   pergaminho_container_position_x, pergaminho_container_position_y ,0f  );

                        display_texto.Mudar_tamanho(  display_width , display_height  );
                        display_texto.game_object.transform.localRotation = Quaternion.Euler(  0f,  0f, display_container_rotation );
                        display_texto.game_object.transform.localPosition = new Vector3(  display_container_position_x  , display_container_position_y, 0f  );

                        nome.game_object.transform.localRotation = Quaternion.Euler(  0f,  0f, nome_container_rotation );
                        nome.game_object.transform.localPosition = new Vector3(  nome_container_position_x , nome_container_position_y, 0f  );

                        pergaminho_levantado = pergaminho_levantado_novo_valor;
                        


                        if(pergaminho_esta_levantado) {

                                 pergaminho_texto.transform.localPosition = new Vector3(  0f,  pergaminho_levantado_novo_valor ,0f);

                        } else {

                                 pergaminho_texto.transform.localPosition = new Vector3(  0f,  pergaminho_abaixado ,0f);

                        };
                                
                        


        }








        public void Esconder( bool _instantaneo ){


                this.esta_escondido = true;

                if( afastar_pergaminho_coroutine != null ){ 

                        Mono_instancia.Stop_coroutine( afastar_pergaminho_coroutine );
                        afastar_pergaminho_coroutine = null;

                }

                Abaixar_pergaminho();


                if( _instantaneo ){

                        float p_x_final = 0f ;
                        float p_y_final = 0f ;


                        switch ( lado_pergaminho_atual ){

                                case Lado.cima : p_y_final =  ( 55f )  ; break;
                                case Lado.baixo : p_y_final = (-55f )  ; break;
                                
                                case Lado.esquerda : p_x_final = ( - 467f ) ; break;
                                case Lado.direita : p_x_final =  (  467f  ) ; break;

                        }

                        pergaminho_container.transform.localPosition = new Vector3(   p_x_final ,  p_y_final ,  0f);
                        return;

                }


                afastar_pergaminho_coroutine = Mono_instancia.Start_coroutine(  Afastar_pergaminho()  );


        }


        public void Mostrar( bool _instantaneo ){


                this.esta_escondido = false;

                if( afastar_pergaminho_coroutine != null ){ 

                        Mono_instancia.Stop_coroutine( afastar_pergaminho_coroutine );
                        afastar_pergaminho_coroutine = null;

                }

                
                if( _instantaneo ){

                        float p_x_final = 0f ;
                        float p_y_final = 0f ;


                        switch ( lado_pergaminho_atual ){

                                case Lado.cima : p_y_final =  0  ; break;
                                case Lado.baixo : p_y_final = 0  ; break;
                                
                                case Lado.esquerda : p_x_final = ( - 422f ) ; break;
                                case Lado.direita : p_x_final =  (  422f  ) ; break;

                        }

                        pergaminho_container.transform.localPosition = new Vector3(   p_x_final ,  p_y_final ,  0f);
                        return;

                }

                
                afastar_pergaminho_coroutine = Mono_instancia.Start_coroutine(  Trazer_pergaminho()  );

        }



        public IEnumerator Afastar_pergaminho(){

                float variante_x = 0f;
                float variante_y = 0f;

                int numero_ciclos = 15;

                Vector3 posicao_inicial = pergaminho_container.transform.localPosition;

                float p_x = posicao_inicial[0];
                float p_y = posicao_inicial[1];


                switch ( lado_pergaminho_atual ){

                        case Lado.cima : variante_y =  ( 55f - p_y  )  / (float) numero_ciclos ; break;
                        case Lado.baixo : variante_y = (-55f - p_y )   / (float) numero_ciclos ; break;
                        
                        case Lado.esquerda : variante_x = ( -p_x  - 467f )/ (float) numero_ciclos ; break;
                        case Lado.direita : variante_x =  ( -p_x  + 467f  )/ (float) numero_ciclos ; break;

                }


                int i = 0;
                

                while( i != numero_ciclos ) {
                        
                        i++;

                        pergaminho_container.transform.localPosition = new Vector3(   p_x  +  variante_x ,   p_y + variante_y ,  0f);

                        p_x += variante_x;
                        p_y += variante_y;

                        yield return null;

                }

                pergaminho_container.transform.localPosition = new Vector3(   p_x  ,   p_y  ,  0f);

                afastar_pergaminho_coroutine = null;

                yield break;



        }

        public IEnumerator Trazer_pergaminho(){

                float variante_x = 0f;
                float variante_y = 0f;

                int numero_ciclos = 15;
                

                Vector3 posicao_inicial = pergaminho_container.transform.localPosition;

                float p_x = posicao_inicial[0];
                float p_y = posicao_inicial[1];

                switch (lado_pergaminho_atual){


                        
                        case Lado.cima : variante_y     =   (  -p_y )  / (float) numero_ciclos ; break;
                        case Lado.baixo : variante_y    =   (  -p_y )   / (float) numero_ciclos ; break;

                        case Lado.esquerda : variante_x =   ( - p_x - 422f ) / (float) numero_ciclos ; break;
                        case Lado.direita : variante_x  =   ( - p_x + 422f ) / (float) numero_ciclos ; break;

                        // case Lado.cima : variante_y = (-45f - p_y )/ (float) numero_ciclos ; break;
                        // case Lado.baixo : variante_y =( 45f - p_y )/ (float) numero_ciclos ; break;
                        // case Lado.esquerda : variante_x =( 45f - p_x  )/ (float) numero_ciclos ; break;
                        // case Lado.direita : variante_x = (-45f - p_x )/ (float) numero_ciclos ; break;

                }


                int i = 0;

                while( i != numero_ciclos){
                        

                        i++;

                        pergaminho_container.transform.localPosition = new Vector3(   p_x  +  variante_x ,   p_y + variante_y ,  0f);
                        
                        p_x += variante_x;
                        p_y += variante_y;

                        yield return null;

                }

                afastar_pergaminho_coroutine = null;

                yield break;



        }








        public void Levantar_pergaminho(){

                
                if(pergaminho_coroutine != null) {

                        Mono_instancia.Stop_coroutine(pergaminho_coroutine);
                        pergaminho_coroutine = null;
                        
                };


                pergaminho_is_abaixado = false;
                pergaminho_em_movimento = true;

                pergaminho_coroutine = Mono_instancia.Start_coroutine( Levantar_pergaminho_c());



        }



        public IEnumerator  Levantar_pergaminho_c(){

       

               // yield return null;

                float speed = 10f;

                while(pergaminho_texto.transform.localPosition.y <  pergaminho_levantado - 0.07f){

                        pergaminho_texto.transform.localPosition += new Vector3(  0f,  speed   , 0f );
                        speed = speed + 0.1f;
                        yield return null;

                }

                pergaminho_texto.transform.localPosition = new Vector3(  0f,  pergaminho_levantado ,0f);


                pergaminho_coroutine = null;
                pergaminho_em_movimento = false;
                

                yield break;

        }


      
        public void Abaixar_pergaminho(){

                if(pergaminho_coroutine != null) {

                        Mono_instancia.Stop_coroutine(pergaminho_coroutine);
                        pergaminho_coroutine = null;
                        
                };


                pergaminho_is_abaixado = true;
                pergaminho_em_movimento = true;

                pergaminho_coroutine = Mono_instancia.Start_coroutine(Abaixar_pergaminho_c()  );
                return;


        }


        public IEnumerator  Abaixar_pergaminho_c(){



               // yield return null;

                float speed = 15f;

                while(pergaminho_texto.transform.localPosition.y >  pergaminho_abaixado){

                        pergaminho_texto.transform.localPosition -= new Vector3(  0f,  speed  , 0f );
                        speed = speed + 0.1f;
                        

                        yield return null;

                }



                pergaminho_texto.transform.localPosition = new Vector3(  0f,  pergaminho_abaixado ,0f);



                pergaminho_coroutine = null;
                pergaminho_em_movimento = false;

                yield break;

        }





        public bool is_building(){

                if(display_texto.texto_coroutine == null) return false;
                return true;

        }

        public void  Force_complete(){

                display_texto.Force_complete();
                return;

        }



        public string Pegar_nome_atual(){


                string nome_atual_pre  = this.nome.Pegar_texto();

                if(  nome_atual_pre == null || nome_atual_pre == "" ) { return ""; }

                char[] nome_char = new char[ nome_atual_pre.Length - 2 ];

                for( int i = 1 ; i < nome_atual_pre.Length - 1 ;i++){

                        nome_char[ i - 1  ] = nome_atual_pre[ i ];

                }

                string nome_final = new string( nome_char );
                nome_final = nome_final.Trim();

                return nome_final;

        }

        public void Mudar_nome( string _nome ){

                string novo_nome = "< " +  _nome + " >";

                nome.Colocar_texto( novo_nome, Color.clear  );

        }


        public void Mudar_cor( Color _cor ){


                this.nome.text.color = _cor;
                this.display_texto.caixa_texto.color = _cor;
                return;


        }


        public void Escrever (  string _texto ,string _personagem , Color _cor, int _tipo , Tipo_construcao_texto _tipo_construcao = Tipo_construcao_texto.config_default ){

                display_texto.Colocar_texto(_texto, _tipo, _cor , _tipo_construcao);
                
                string nome_texto = "";

                if( _personagem.Length > 0 ){

                        nome_texto = "< " + _personagem + " >";

                }

                nome.Colocar_texto( nome_texto ,  _cor );

        }




        public void Resetar (){

                Abaixar_pergaminho();

                /// esta colidindo com mostrar/esconder 
                /// as 2 coroutines trabalham em cima do mesmo objeto mas tem coroutines diferentes 
                /// no final ela sempre fica aparecendo;
                // Mudar_posicao_pergaminho( "baixo" );

                Mudar_bloqueio_clicks( 0 );

                display_texto.Colocar_texto("",0, Color.black, Tipo_construcao_texto.config_default );
                nome.Colocar_texto( "",  Color.black );

                return;

        }







        public void Iniciar_conversas ( string[] _blocos_textos , int[] _numero_blocos ) {

                blocos_conversas_esta_ativo = true;

                nome.Colocar_texto( "<>", Color.black  );
                display_texto.Limpar_texto();

                Levantar_pergaminho();



                blocos_numeros =  _numero_blocos;

                GameObject conversas_blocos_textos = new GameObject("blocos_conversas");

                conversas_blocos_textos.transform.SetParent( display_texto.game_object.transform , false  );
                

                int numero_blocos = _blocos_textos.Length;

                if( numero_blocos > 4 ){

                        throw new ArgumentException("passou limite blocos conversa");

                }

                blocos_textos = new Display_texto_simples[ numero_blocos ];

                for( int bloco = 0 ; bloco < numero_blocos ; bloco++ ){


                        string bloco_texto =  "-> " +  _blocos_textos[ bloco ] ;

                        float posicao_y = ( float ) (  bloco * -50 ) + 112f  ; // - 50f ; // talvez tenha que ajustar

                        string nome =  ( "bloco_" + bloco.ToString() );

                        Display_texto_simples display = new Display_texto_simples(     _nome: nome  ,  _width : 827f, _height : 40f , _font_size: 36f );

                        display.Colocar_texto( bloco_texto , Color.black );

                        display.Setar_display( conversas_blocos_textos.transform, 0f,  posicao_y  );

                        blocos_textos[ bloco ] = display;



                }


        }

        public void Finalizar_conversas(){


                GameObject c_go = display_texto.game_object.transform.GetChild( 0 ).gameObject;
                Mono_instancia.Destroy( c_go );

                blocos_textos = null;
                blocos_numeros = null;

                blocos_conversas_esta_ativo = false;
                blocos_conversas_esta_concluido = false; // acho que nao precisa.choices precisa por causa da transicao

                return;


        }










public void Finalizar_choices(){

        choices_esta_ativa = false;

      for(int i = 0; i < choices_game_objects.Length;i++){
        choices_text[i].text = "";
      }

      Mono_instancia.Start_coroutine(c());

       IEnumerator c(){

        
                int numero_choices = possiveis_respostas.Length;


                Transform rt = pergaminho_choices.GetComponent<Transform>();

                RectTransform rt_p1 = pergaminho_choice_parte_1.GetComponent<RectTransform>();
                RectTransform rt_p2 = pergaminho_choice_parte_2.GetComponent<RectTransform>();
                RectTransform rt_papel = pergaminho_choice_papel.GetComponent<RectTransform>();


                yield return new WaitForSeconds(0.1f);

                float final_position= (((numero_choices - 1 ) * (choice_text_height + altura_espaco) ) / 2f)  +  100f  ;
                float time_ms = 300f;

                float trava = 0f;



                float numero_vezes = ( (time_ms  * 60) /  1000);
                float y_dif = final_position / numero_vezes  ;

                yield return new WaitForSeconds(0.25f);



                while( trava < numero_vezes ){

                        trava += 1f;

                        float new_x = rt.localPosition.x;
                        float new_y_1 = rt_p1.localPosition.y - y_dif;
                        float new_y_2 = rt_p2.localPosition.y + y_dif;

                        float new_height = rt_papel.rect.height - (2 * y_dif);
                        float width = rt_papel.rect.width;


                        rt_p1.localPosition = new Vector3(new_x, new_y_1, 0f);
                        rt_p2.localPosition = new Vector3(new_x, new_y_2, 0f);
                        rt_papel.SetSizeWithCurrentAnchors( RectTransform.Axis.Horizontal, width  ) ;
                        rt_papel.SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, new_height ) ;

                        yield return null;

                }



                trava = 0f;

                final_position = 512f;
                time_ms = 250f;
                numero_vezes = ( (time_ms  * 60) /  1000);
                y_dif = final_position / numero_vezes  ;



                yield return new WaitForSeconds(0.25f);

                while( trava < numero_vezes ){

                        trava += 1f;

                        float new_x = rt.localPosition.x;
                        float new_y = rt.localPosition.y - y_dif;


                        rt.localPosition = new Vector3(new_x, new_y, 0f);

                        yield return null;

                }

                
                pergaminho_texto.SetActive(true);
                pergaminho_choices.SetActive(false);
                choices_concluida = true;

             //  

                yield break;


       }

}







public void Ajustar_opcoes(string[] _possiveis_respostas){


    int numero_choices = _possiveis_respostas.Length;
    choices_areas = new float[numero_choices][];

    
    float ponto_atual = ((numero_choices - 1 ) * (choice_text_height + altura_espaco) ) / 2f;
    

    
    float choice_width_half = choice_text_width / 2f;
    float choice_height_half = choice_text_height / 2f;


    for(int i = 0;  i < numero_choices  ;i++){

        choices_game_objects[i].transform.localPosition = new Vector3(0f , ponto_atual , 0f );
        choices_text[i].text = _possiveis_respostas[i];

        choices_areas[i] = new float[10];

        choices_areas[i][0] =   940f - choice_width_half  + ponto_atual;
        choices_areas[i][1] =   540f +  choice_height_half  + ponto_atual;

        choices_areas[i][2] =    940f + choice_width_half  + ponto_atual;
        choices_areas[i][3] =    540f +  choice_height_half+ ponto_atual;

        choices_areas[i][4] =    940f  +  choice_width_half + ponto_atual;
        choices_areas[i][5] =    540f -  choice_height_half+ ponto_atual;

        choices_areas[i][6] =   940f - choice_width_half + ponto_atual; 
        choices_areas[i][7] =   540f -  choice_height_half+ ponto_atual;


        choices_areas[i][8] =   940f - choice_width_half + ponto_atual;
        choices_areas[i][9] =   540f +  choice_height_half+ ponto_atual;

        ponto_atual = ponto_atual - (  choice_text_height + altura_espaco  );

    }

    return;


}

public  void Iniciar_choices( string _pergunta , int _pergunta_index,  string[] _possiveis_respostas ){
 
        pergunta_atual = _pergunta;

        pergunta_index = _pergunta_index;
       
        possiveis_respostas = _possiveis_respostas;

        int numero_choices  = _possiveis_respostas.Length;

        choices_esta_ativa = false;


        Mono_instancia.Start_coroutine( c() );
        

        IEnumerator c(){

                
                if(!pergaminho_is_abaixado){

                        Abaixar_pergaminho();
                        while(  !pergaminho_is_abaixado || pergaminho_em_movimento ){ yield return null ; }
                        
                }

                yield return new WaitForSeconds(0.10f);



                pergaminho_texto.SetActive(false);
                pergaminho_choices.SetActive(true);

                


                Transform rt = pergaminho_choices.GetComponent<Transform>();

                RectTransform rt_p1 = pergaminho_choice_parte_1.GetComponent<RectTransform>();
                RectTransform rt_p2 = pergaminho_choice_parte_2.GetComponent<RectTransform>();
                RectTransform rt_papel = pergaminho_choice_papel.GetComponent<RectTransform>();




                float trava = 0f;
                float final_position = 512f;
                float time_ms = 450f;
                float numero_vezes = ( (time_ms  * 60) /  1000);
                float y_dif = final_position / numero_vezes  ;



                while( trava < numero_vezes ){

                        trava += 1f;

                        float new_x = rt.localPosition.x;
                        float new_y = rt.localPosition.y + y_dif;


                        rt.localPosition = new Vector3(new_x, new_y, 0f);


                        yield return null;


                }


                float final_x = rt.localPosition.x;
                float final_y = 0f;


                rt.localPosition = new Vector3(final_x, final_y, 0f);


                trava = 0f;

                final_position= (((numero_choices - 1 ) * (choice_text_height + altura_espaco) ) / 2f)  +  100f  ;
                time_ms = 300f;




                numero_vezes = ( (time_ms  * 60) /  1000);
                y_dif = final_position / numero_vezes  ;



                yield return new WaitForSeconds(0.25f);

                while( trava < numero_vezes ){

                        trava += 1f;

                        float new_x = rt.localPosition.x;
                        float new_y_1 = rt_p1.localPosition.y + y_dif;
                        float new_y_2 = rt_p2.localPosition.y - y_dif;
                        float new_height = rt_papel.rect.height + (2 * y_dif);

                        float width = rt_papel.rect.width;


                        rt_p1.localPosition = new Vector3(new_x, new_y_1, 0f) ;
                        rt_p2.localPosition = new Vector3(new_x, new_y_2, 0f) ;
                        rt_papel.SetSizeWithCurrentAnchors( RectTransform.Axis.Horizontal, width  ) ;
                        rt_papel.SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, new_height ) ;

                        yield return null;


                }

                Ajustar_opcoes(_possiveis_respostas);

                choices_esta_ativa = true;





        }

}



   }
