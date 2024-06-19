using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;



public class Personagem_dados_visual_novel {


        public GameObject game_object = null;
        public GameObject imagem_game_object = null ;
        public Image image = null;
        public RectTransform rect_transform = null;


        public string nome_display = null;
        public string nome = null;

        public int index_nome = -1;


        public int cor_personagem_atual_id = ( int ) Nome_cor.white;

        
        // public Color cor_texto_default = Color.black;
        // public int cor_default_id = -1;




        public Color cor_texto_atual = Color.black;
        public int cor_texto_atual_id = ( int ) Nome_cor.black;


        

        public bool tem_transicao_movimento = true;
        public Coroutine transicao_movimento_coroutine = null;

        public bool tem_transicao_cor = true;
        public Coroutine transicao_cor_coroutine = null;

        public Color cor_final = new Color(1f,1f,1f,0f);


        public bool personagem_esta_focado = true;

        

        public bool tem_highlight = true;


        public bool personagem_esta_aparente = false;
        public float[] posicao = new float[2];


        //  usar para o inverso 
        public int path_localizador_imagem_atual =  0;


        



}



public class Controlador_personagens_visual_novel{


      

        public static Controlador_personagens_visual_novel instancia;
        public static Controlador_personagens_visual_novel Pegar_instancia(){ return instancia; }

        public static Controlador_personagens_visual_novel Construir(){ 
            
            Controlador_personagens_visual_novel controlador = new Controlador_personagens_visual_novel(); 
            
                controlador.bloco_visual_novel = BLOCO_visual_novel.Pegar_instancia();;

            instancia = controlador;
            return instancia;
            
        }


    public Coroutine_objeto foco_camera_personagens_coroutine_objeto = new Coroutine_objeto( 2 + 1 );

    public GameObject personagens_container;
    public BLOCO_visual_novel bloco_visual_novel;

    public Personagem_dados_visual_novel[] personagens_dados = null;
    public Personagem_dados_visual_novel[] extras_dados = null;


    public Personagem_dados_visual_novel narrador_dados;
    public Personagem_dados_visual_novel god;
    public Personagem_dados_visual_novel game;
    public Personagem_dados_visual_novel generico;





    public Vector3 posicao_0 = new Vector3(0f,0f,0f);
    

    public Vector3 personagens_container_normal_size = new Vector3(1f, 1f, 1f);
    public Vector3 personagens_container_normal_size_transform_posicao = new Vector3(0f,0f,0f);


    public Vector3 personagens_container_big_size = new Vector3(1.7f, 1.7f, 1.7f);
    public Vector3 personagens_container_big_size_transform_posicao = new Vector3(0f,-200f/108f,0f);




    public void Iniciar(){ 

        // ???
        personagens_container = GameObject.Find("Tela/Canvas/Visual_novel/Personagens_container");

    }



    public void Resetar_variaveis(){



        if(personagens_dados != null){

            for(int k = 0 ;  k < personagens_dados.Length  ; k++){

                   Personagem_dados_visual_novel personagem = personagens_dados[k];

                    Mono_instancia.DestroyImmediate( personagens_dados[k].game_object ) ;
                    if(personagem.transicao_cor_coroutine != null) Mono_instancia.Stop_coroutine(personagem.transicao_cor_coroutine);
                    if(personagem.transicao_movimento_coroutine != null) Mono_instancia.Stop_coroutine(personagem.transicao_movimento_coroutine);
            }

            personagens_dados = null;
            
        
        }

        extras_dados = null;


        foco_camera_personagens_coroutine_objeto.Stop();


    }





    public void Criar_personagens(string[] _personagens_nomes){

        Resetar_variaveis();

        int numero_personagens = _personagens_nomes.Length;
        personagens_dados = new Personagem_dados_visual_novel[numero_personagens];


     
        for( int i = 0 ; i < numero_personagens ; i++ ){ 


                Personagem_dados_visual_novel personagem = new Personagem_dados_visual_novel();
                personagens_dados[ i ] = personagem;
                personagem.nome  =   _personagens_nomes[ i ];
                personagem.nome_display = personagem.nome;
                personagem.index_nome = i ;


                /// pensar em algo melhor depois            
             //   Nome_cor personagem_nome_cor = (Nome_cor) Enum.Parse( typeof( Nome_cor) ,  (personagem.nome + "_default_text_color" )  );
             
                Nome_cor personagem_nome_cor;
                Enum.TryParse( (personagem.nome + "_default_text_color" )  , true , out personagem_nome_cor  );



                personagem.cor_texto_atual = Cores.Pegar_cor( personagem_nome_cor );

                personagem.cor_texto_atual_id    =  ( int ) personagem_nome_cor;


            
                string nome = "Personagem_" + _personagens_nomes[ i ] ;
                GameObject personagem_game_object = new GameObject( nome ) ;
                personagem_game_object.transform.SetParent(personagens_container.transform, false);
                personagem.game_object = personagem_game_object;

                personagem.imagem_game_object = new GameObject( "IMAGEM_" + nome );
                personagem.image  = IMAGE.Criar_imagem(
                                                                _game_object: personagem.imagem_game_object,
                                                                _pai : personagem_game_object,
                                                                _width: 1080f,
                                                                _height: 1080f,
                                                                _path : null,
                                                                _sprite: null,
                                                                _alpha: 0f

                                                        );
                                                        



                personagem.image.color = Color.clear;
                personagem.rect_transform = personagem.imagem_game_object.GetComponent<RectTransform>();
                                     

            
        }


        extras_dados = new Personagem_dados_visual_novel[ 10 ];

        extras_dados[ (int) Visual_novel_extras.narrator - 50 ] = new Personagem_dados_visual_novel();
        extras_dados[ (int) Visual_novel_extras.narrator - 50 ].nome = "narrator";
        extras_dados[ (int) Visual_novel_extras.narrator - 50 ].nome_display = "narrator";

        extras_dados[ (int) Visual_novel_extras.god - 50 ] = new Personagem_dados_visual_novel();
        extras_dados[ (int) Visual_novel_extras.god - 50 ].nome = "god";
        extras_dados[ (int) Visual_novel_extras.god - 50 ].nome_display = "god";

        
        extras_dados[ (int) Visual_novel_extras.game - 50 ] = new Personagem_dados_visual_novel();
        extras_dados[ (int) Visual_novel_extras.game - 50 ].nome = "game";
        extras_dados[ (int) Visual_novel_extras.game - 50 ].nome_display = "game";
        
        
        extras_dados[ (int) Visual_novel_extras.developer - 50 ] = new Personagem_dados_visual_novel();
        extras_dados[ (int) Visual_novel_extras.developer - 50 ].nome = "developer";
        extras_dados[ (int) Visual_novel_extras.developer - 50 ].nome_display = "developer";

        extras_dados[ (int) Visual_novel_extras.marketing_guy - 50 ] = new Personagem_dados_visual_novel();
        extras_dados[ (int) Visual_novel_extras.marketing_guy - 50 ].nome = "marketing_guy";
        extras_dados[ (int) Visual_novel_extras.marketing_guy - 50 ].nome_display = "marketing_guy";
        
        


    }




    public Personagem_dados_visual_novel Pegar_personagem(string _nome_personagem){

            for(int i = 0;i< personagens_dados.Length ; i++){

                if(  personagens_dados[i].nome == _nome_personagem ) return personagens_dados[i];

            }

            if(_nome_personagem == "narrator") return narrador_dados;
            if(_nome_personagem == "god") return god;
            if(_nome_personagem == "game") return game;

            generico.nome = _nome_personagem;
            generico.nome_display = _nome_personagem;

            return generico;


    }



            public void Mudar_cor_personagem(      Personagem_dados_visual_novel _personagem   , Color _cor_final){
 

                    _personagem.cor_final = _cor_final;
                    

    
                    if( _personagem.transicao_cor_coroutine != null    ){

                        Mono_instancia.Stop_coroutine( _personagem.transicao_cor_coroutine );
                        _personagem.transicao_cor_coroutine= null;

                    }



                    float modificador_highlight = 1f;

                    bool personagem_nao_tem_highlight = !_personagem.personagem_esta_focado;

                    if(personagem_nao_tem_highlight ) {modificador_highlight = 0.6f;}

                    Color cor_com_highlight = new Color(
                        _cor_final[0] * modificador_highlight,
                        _cor_final[1] * modificador_highlight,
                        _cor_final[2] * modificador_highlight,
                        _cor_final[3]  
                    );

                    


                    bool vai_ser_instantaneo = !_personagem.tem_transicao_cor;

                    if( vai_ser_instantaneo ){

                        _personagem.image.color = cor_com_highlight;
                        return;
                    
                    }


                _personagem.transicao_cor_coroutine = Mono_instancia.Start_coroutine(  Mudar_cor_personagem()  );

                IEnumerator Mudar_cor_personagem(){
                            
                            yield return null;
                            

                        //   WaitForSeconds time = new WaitForSeconds(0.016f);



                            Color cor_inicial = _personagem.image.color;

                            float r_final = cor_com_highlight.r;
                            float g_final = cor_com_highlight.g;
                            float b_final = cor_com_highlight.b;
                            float a_final = cor_com_highlight.a;


                            float r_inicial = cor_inicial.r;
                            float g_inicial = cor_inicial.g;
                            float b_inicial = cor_inicial.b;
                            float a_inicial = cor_inicial.a;

                            float r_dif = 0.034f *  (r_final - r_inicial);
                            float g_dif = 0.034f *  (g_final - g_inicial);
                            float b_dif = 0.034f *  (b_final - b_inicial);
                            float a_dif = 0.034f *  (a_final - a_inicial);

                        



                        
                        int count = 0;

                            while (count < 28 ){
                                
                            
                        
                                count++;

                                r_inicial += r_dif;
                                g_inicial += g_dif;
                                b_inicial += b_dif;
                                a_inicial += a_dif;
                            
                            
                                _personagem.image.color = new Color(   r_inicial , g_inicial  , b_inicial   ,  a_inicial   );

                            
                            //yield  return time;

                            yield  return null;

                            } 


                        _personagem.image.color  =  cor_com_highlight;

                        _personagem.transicao_cor_coroutine = null;


                        yield break;


                }


        }



            // public void Aplicar_highlight_todos_personagens(string _nome_personagem_foco){


            //     for(int i = 0;  i  <  personagens_dados.Length   ;i++){  

            //             Personagem_dados_visual_novel personagem = personagens_dados[i];
                        
            //             if(personagem.nome == _nome_personagem_foco){

            //                 personagem.personagem_esta_focado = true;

            //                 Mudar_cor_personagem(personagem, personagem.cor_final );

            //                 continue;
            //             }
                        
            //             personagem.personagem_esta_focado = false;
            //             Mudar_cor_personagem(personagem, personagem.cor_final );
            //             continue;
                    
            //     };

            
            //     return;
            // }


            public void Tirar_highlight_todos_personagens(){


                    for(int personagem_index = 0;  personagem_index  <  personagens_dados.Length   ;   personagem_index ++){  

                            Personagem_dados_visual_novel personagem = personagens_dados[ personagem_index ];

                            personagem.personagem_esta_focado = true;
                            Mudar_cor_personagem( personagem, personagem.cor_final );
                            continue;

                        
                    };

                
                    return;


            }


            
            public void Aplicar_highlight_todos_personagens ( int _index_personagem_foco ){ 


                for(int personagem_index = 0;  personagem_index  <  personagens_dados.Length   ;   personagem_index ++){  

                        Personagem_dados_visual_novel personagem = personagens_dados[ personagem_index ];

                        if(  personagem_index == _index_personagem_foco  || !personagem.tem_highlight  ){

                            personagem.personagem_esta_focado = true;
                            Mudar_cor_personagem(personagem, personagem.cor_final );
                            continue;

                        }

                        

                        
                        personagem.personagem_esta_focado = false;
                        Mudar_cor_personagem(personagem, personagem.cor_final );
                        continue;
                    
                };

            
                return;
            }



   public void Mover_char(   Personagem_dados_visual_novel _personagem, float _x_position , float _y_position = 0f ){


            _personagem.posicao[ 0 ] = _x_position;
            _personagem.posicao[ 1 ] = _y_position;

        if(!_personagem.tem_transicao_movimento ){

                _personagem.game_object.transform.localPosition = new Vector3(  _x_position , _y_position , 0f  );
                _personagem.transicao_movimento_coroutine = null;
                return;

        }


  
        if(  _personagem.transicao_movimento_coroutine != null ){
                  
            Mono_instancia.Stop_coroutine( _personagem.transicao_movimento_coroutine );
            _personagem.transicao_movimento_coroutine = null;

        }


    

      _personagem.transicao_movimento_coroutine  =  Mono_instancia.Start_coroutine( Mover_char_c(_x_position , _y_position)  );



    IEnumerator Mover_char_c(float _x_position , float _y_position){


            float p_x = _personagem.game_object.transform.localPosition.x ;
            float p_y = _personagem.game_object.transform.localPosition.y ;

            float med = Mathf.Sqrt(   Mathf.Pow(p_x - _x_position , 2f)  + Mathf.Pow(p_y - _y_position , 2f)  );


            float speed_0 = 5f;
            float speed_multiplier = 15f;
            float speed_dif_range = 1750f;

            float numero_ciclos =    speed_0      +    (    med   /    ( (Mathf.Pow(   med / speed_dif_range  ,   2f  )  + 1f )  * speed_multiplier  )  )      ;  //       med < 200? 15  : med <400? 20 : med <600? 25 :    med <1000? 35 : 45;


            float d_x =    (p_x - _x_position ) /  numero_ciclos   ;
            float d_y =     (p_y - _y_position)  /  numero_ciclos   ;


            float k = 0;

            while(k<numero_ciclos){

                    k += 1f;
                    _personagem.game_object.transform.localPosition -= new Vector3(   d_x , d_y , 0f);
                    yield return null;
                
            }

            _personagem.game_object.transform.localPosition = new Vector3(   _x_position, _y_position , 0f);
            _personagem.transicao_movimento_coroutine = null;
            // _personagem.posicao[ 0 ] = _x_position;
            // _personagem.posicao[ 1 ] = _y_position;

            yield break;

            
    } 
      
      return; 


   }




            public void Mudar_foco_camera_personagens (  string  _modo, bool _eh_instantaneo ){


                    float valor_scale;
                    Vector3 valor_position;


                    foco_camera_personagens_coroutine_objeto.Stop();


                    switch( _modo ){
                        
                        case "sem_alteracao" : valor_scale  = 1f ; valor_position = new Vector3(0f, 0f, 0f); break;

                        case "normal":  valor_scale  = 1.3f ; valor_position = new Vector3(0f,-50f,0f); break;
                        case "afastado": valor_scale = 1f   ; valor_position = new Vector3(0f,-20f,0f); break;
                        case "proximo": valor_scale  = 1.7f ; valor_position = new Vector3(0f,-125f,0f); break;
                        default: throw new ArgumentException("");

                    }


                    
                    if( _eh_instantaneo ) {

                            personagens_container.transform.GetComponent<Transform>().localScale =  new Vector3( valor_scale, valor_scale, valor_scale ) ;
                            personagens_container.transform.GetComponent<Transform>().localPosition = valor_position;
                            return;

                    }
                    
                    foco_camera_personagens_coroutine_objeto.Iniciar_coroutine( slot: 0, IEn:  a(   valor_position , valor_scale   )  );


                    IEnumerator a(  Vector3 _position,  float _valor_scale    ){

                        float tempo_ms = 400f;

                        
                        foco_camera_personagens_coroutine_objeto.Iniciar_coroutine(  slot: 1  , IEn: Coroutine_ferramentas .Mudar_position_generico(tempo_ms , personagens_container.transform, _position )  );
                        foco_camera_personagens_coroutine_objeto.Iniciar_coroutine(  slot: 2  , IEn: Coroutine_ferramentas.Mudar_scale_generico(tempo_ms , personagens_container.transform, _valor_scale )  );

                        yield return foco_camera_personagens_coroutine_objeto.coroutine_arr[ 1 ];

                        foco_camera_personagens_coroutine_objeto.Stop();
                        yield break;

                        
                    }



                    return;
            
            }







                public void Mudar_scale(Personagem_dados_visual_novel _personagem ,  float _nova_scale  ){


                        // talvez fazer com coroutine depois?

                        _personagem.game_object.transform.localScale = new Vector3(_nova_scale,_nova_scale,_nova_scale);

                        return;

                }










}