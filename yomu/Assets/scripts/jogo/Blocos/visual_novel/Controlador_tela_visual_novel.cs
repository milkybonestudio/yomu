using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;





// public enum Tipo_objeto_visual_novel {

//         simples = 0,

// }


// public enum Tipo_plano_objeto_visual_novel {

//         nada = 0,
//         persoangem, 
//         background,
//         frente,

// }


// public class Visual_novel_objetos {

//         public Tipo_plano_objeto_visual_novel plano = nullTipo_plano_objeto_visual_novel.nada ; 
//         public Tipo_objeto_visual_novel tipo  = Tipo_objeto_visual_novel.simples ; 
//         public GameObject game_object = null;

// }



public class Controlador_tela_visual_novel {


        public static Controlador_tela_visual_novel instancia;
        public static Controlador_tela_visual_novel Pegar_instancia(){ return instancia; }
        public static Controlador_tela_visual_novel Construir(){ instancia = new Controlador_tela_visual_novel(); return instancia;}



        public void  Iniciar(){

                bloco_visual_novel = BLOCO_visual_novel.Pegar_instancia();
                desfoco_opacidade = Resources.Load<Material>("materials/desfoco_opacidade");/// *tem que pegar desfoco

        }


        public BLOCO_visual_novel bloco_visual_novel;

        
        public Coroutine background_coroutine_visual_novel = null;
        public Coroutine background_coroutine_shadow = null;


        
        public GameObject canvas_visual_novel;

        public GameObject background_1;
        public GameObject background_2;

        public GameObject animacao;

        public GameObject objetos_background;
        public GameObject objetos_frente;




        // what?
        public GameObject transicao_game_object;
        public Coroutine transicao_coroutine = null;
        public bool vai_ser_escondido = false ;
        public string tipo_transicao_atual = "nada"; // what?




        public Image background_1_image;
        public Image background_2_image;

        public Image[] animacao_images_arr;

        public Image transicao_image;




        public Material  em_foco = null;
        public Material  desfoco_fixo;
        public Material  desfoco_opacidade;
        public float[]   posicao_mouse;


        public Pergaminho_modelo_1 pergaminho;
        public Animacao_visual_novel animacao_visual_novel;
        public Coroutine animacao_coroutine;

        



        public void Criar_tela(){

     
                canvas_visual_novel = GameObject.Find("Tela/Canvas/Jogo/Visual_novel");


                GameObject background = new GameObject("Background");
                background.transform.SetParent( canvas_visual_novel.transform , false );

                background_1 = Geral.Criar_imagem( "Background_1",background);
                background_1_image = Geral.ultima_imagem;

                background_2 = Geral.Criar_imagem( "Background_2",background );
                background_2_image = Geral.ultima_imagem;

                


                objetos_background = new GameObject("Objetos_background");
                objetos_background.transform.SetParent(   canvas_visual_novel.transform,   false ) ;


                Controlador_personagens_visual_novel controlador_personagens = Controlador_personagens_visual_novel.Pegar_instancia();
                controlador_personagens.personagens_container = new GameObject("Personagens_container");
                controlador_personagens.personagens_container.transform.SetParent(  canvas_visual_novel.transform , false   );

                
                objetos_frente = new GameObject("Objetos_frente");
                objetos_frente.transform.SetParent(   canvas_visual_novel.transform,   false ) ;



                animacao =  new GameObject("Animacao");
                animacao.transform.SetParent( canvas_visual_novel.transform,  false );



                transicao_game_object = new GameObject("Transicao");

                transicao_game_object.transform.SetParent(   canvas_visual_novel.transform   ,false);

                


                em_foco = background_1_image.material;
                background_2_image.material  =  em_foco;


                // "Tela/Canvas/Visual_novel"

                // pergaminho = new Pergaminho_modelo_1();


                posicao_mouse = Controlador_dados.Pegar_instancia().posicao_mouse;




        }



        public void Resetar_variaveis(){



                if(background_coroutine_visual_novel != null ) { Mono_instancia.Stop_coroutine(background_coroutine_visual_novel); background_coroutine_visual_novel = null;}
                if(background_coroutine_shadow != null ) { Mono_instancia.Stop_coroutine(background_coroutine_shadow); background_coroutine_shadow = null;}
                if(transicao_coroutine != null ) { Mono_instancia.Stop_coroutine(transicao_coroutine); transicao_coroutine = null;}



                canvas_visual_novel = null;

                background_1 = null;
                background_2 = null;

                animacao = null;

                objetos_background = null;
                objetos_frente = null;

                transicao_game_object = null;



        }

        



        public void Update_animation(){ 

                        if(animacao_visual_novel.ciclos_bloqueio>0) {animacao_visual_novel.ciclos_bloqueio--;}

                
                        bool tem_que_trocar_frames = animacao_visual_novel.frames_passados > animacao_visual_novel.frame_jogo_Por_frame_animacao ;

                        if(  tem_que_trocar_frames  ){

                                animacao_visual_novel.imagem_atual++;
                                animacao_visual_novel.frames_passados = 0;

                                if(animacao_visual_novel.imagem_atual == animacao_visual_novel.sequencias[0].Length ){

                                        if( animacao_visual_novel.loop ){

                                                animacao_visual_novel.imagem_atual = 0;

                                        } else{

                                                //Debug.Log("nao foi loop");
                                                if(animacao_visual_novel.proxima_animacao_visual_novel != null){

                                                        animacao_visual_novel = animacao_visual_novel.proxima_animacao_visual_novel;

                                                } else {

                                                                
                                                        animacao_visual_novel = null;
                                                        int numero_childs = animacao.transform.childCount;

                                                        for(int k = 0;  k < numero_childs  ;k++){

                                                                Mono_instancia.Destroy(  animacao.transform.GetChild(k).gameObject );

                                                        }

                                                        return;

                                                }

                                        }

                                }

                                string folder_path = animacao_visual_novel.folder_path;

                                for(int i = 0; i < animacao_visual_novel.numero_quadros ;i++){

                                        int[] sequencia = animacao_visual_novel.sequencias[i];
                                        int numero_sequencia =  sequencia[animacao_visual_novel.imagem_atual];

                                        string path_completo =  folder_path + Convert.ToString(i) + "_" +  Convert.ToString(numero_sequencia);

                                        animacao_visual_novel.images[i].sprite = Resources.Load<Sprite>(path_completo);
                                        if(animacao_visual_novel.images[i].sprite == null) throw new ArgumentException("nao foi achado sprite em update_animation. path_completo: " + path_completo );

                                }
        

                        } else {

                                animacao_visual_novel.frames_passados++;

                        }


        }



        
        public bool Background_esta_em_foco(){

                return ( background_2_image.material == em_foco );


        }






        public void Mudar_background( string _path,  bool _tem_transicao  , int _foco , int _id_cor  ){

                
                Garantir_troca_background();

                /*
                *  tem em_foco: 0 => nao muda, 1 =  flip ,  2 = tem desfoco, 3 => nao tem desfoco
                */


                Sprite new_background_sprite = background_1_image.sprite;

                if(_path != "0") { 

                        new_background_sprite = Resources.Load<Sprite>(_path);
                        
                        
                
                } // "" == nao muda
                

                if(new_background_sprite == null) throw new ArgumentException("nao foi achado background no path: " + _path);


                if(  !_tem_transicao  ) {

                        
                        background_1_image.sprite = new_background_sprite;
                        background_2_image.sprite = new_background_sprite;

                        Nome_cor nome_cor =  ( Nome_cor ) _id_cor;
                        
                        background_1_image.color = Cores.Pegar_cor( nome_cor );
                        

                        //background_2_image.color = Color.clear;

                        
                        Color cor_final = background_2_image.color;
                        cor_final[3] = 0f;
                        background_2_image.color =  cor_final;


                        
                         if(  _foco != 0 ) { 

                                if(_foco == 1){

                                        if(background_1_image.material == em_foco) {

                                                background_1_image.material = desfoco_opacidade;
                                                background_2_image.material = desfoco_opacidade;
                                                
                                        } else{
                                                background_1_image.material = em_foco;
                                                background_2_image.material = em_foco;
                                                
                                        }
                                } else
                                if(_foco == 2 ){
                                        if(background_1_image.material == em_foco){
                                                background_1_image.material = desfoco_opacidade;
                                                background_2_image.material = desfoco_opacidade;
                                                
                                        }
                                } else 
                                if(_foco == 3 ){
                                        if(background_1_image.material == desfoco_opacidade){
                                                background_1_image.material = em_foco;
                                                background_2_image.material = em_foco ;
                                                

                                        }

                                } else {throw new ArgumentException("nao veio int aceitavel para mudar o foco, veio: " + _foco);}                    
                        }

                        return;

                        
                }

                
        
                background_coroutine_visual_novel = Mono_instancia.Start_coroutine( a() );

                IEnumerator a(){


                        /// te que colocar as outras transicoes aqui no meio tambem 


                        if(  _foco != 0 ) { 
                            

                                if(_foco == 1){

                                    

                                        if(background_1_image.material == em_foco) {
                                                
                                                background_2_image.material = desfoco_opacidade;
                                        
                                        } else{
                                        
                                                background_2_image.material = em_foco;
                                                
                                        }
                                } else
                                if(_foco == 2 ){
                                        if(background_1_image.material == em_foco){
                                                
                                                background_2_image.material = desfoco_opacidade;                            
                                                
                                        }
                                } else 
                                if(_foco == 3 ){
                                        if(background_1_image.material == desfoco_opacidade){

                                                background_2_image.material = em_foco ;
                                                
                                        }

                                } else {throw new ArgumentException("nao veio int aceitavel para mudar o foco, veio: " + _foco);}


                        }

                        background_2_image.sprite = new_background_sprite;
                       // background_2_image.color = Color.clear;

                       
                        
                        Color cor_final = Cores.Pegar_cor(  ( Nome_cor ) _id_cor  );

                
                        int numero_ciclos = 15;

                        float v_i_1 = background_1_image.color[0];
                        float v_i_2 = background_1_image.color[1];
                        float v_i_3 = background_1_image.color[2];

                        float v_f_1 = cor_final[0];
                        float v_f_2 = cor_final[1];
                        float v_f_3 = cor_final[2];

                        float d_1 = (v_f_1 - v_i_1) / numero_ciclos ;
                        float d_2 = (v_f_2 - v_i_2) / numero_ciclos ;
                        float d_3 = (v_f_3 - v_i_3) / numero_ciclos ;

                        float d_opacidade = 1f / numero_ciclos;
                        float opacidade = 0f;

                        int i = 0;
                    
                        while(i < numero_ciclos){
                                i++;

                                v_i_1 += d_1;
                                v_i_2 += d_2;
                                v_i_3 += d_3;
                                opacidade += d_opacidade;

                                background_2_image.color = new Color( v_i_1, v_i_2 , v_i_3, opacidade );
                                
                                yield return null;

                        }

                        background_1_image.sprite = new_background_sprite;

                        background_1_image.color = cor_final;
                        background_1_image.material = background_2_image.material;

                        
                        Color cor_final_sem_opacidade = background_2_image.color;
                        cor_final_sem_opacidade[3] = 0f;
                        background_2_image.color =  cor_final_sem_opacidade;

                        background_2_image.sprite = null;


                        background_coroutine_visual_novel = null;

                        yield break;


                }




        }






        public void Criar_objeto_simples ( string _plano , string _obj_path , float _p_x , float _p_y ){

                // if( _plano == "background" ){

                //         objetos_background


                        


                //         return;

                // }


                // if( _plano == "frente" ){



                //         return; 
                // }



        }





  




    public  Image[] Criar_frames(  int _numero_quadros, string _nome ="animacao", bool _tem_transicao = false){


                if( animacao_coroutine != null ){ 

                        Mono_instancia.Stop_coroutine( animacao_coroutine );
                        
                }

                Transform animacao_transform = animacao.transform;
                GameObject animacao_container = new GameObject("Animacao_" + _nome);
                

                Image[] animacao_images_arr = new Image[_numero_quadros];

                for(int quadro = 0;  quadro < _numero_quadros  ; quadro++){

                        GameObject quadro_game_object = new GameObject("Quadro_" + Convert.ToString(quadro));
                        animacao_images_arr[quadro] = quadro_game_object.AddComponent<Image>();

                        RectTransform rect_quadro = quadro_game_object.GetComponent<RectTransform>();
                        rect_quadro.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal , 1920f);
                        rect_quadro.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical , 1080f);

                        animacao_images_arr[quadro].color = new Color(1f,1f,1f,0f);

                        animacao_images_arr[quadro].sprite = Resources.Load<Sprite>("images/utilidade_geral/vazio");

                        quadro_game_object.transform.SetParent(  animacao_container.transform , false);

                }


                if( _tem_transicao ){

                        animacao_coroutine = Mono_instancia.Start_coroutine(  Trocar()  );


                } else {

                        int numero_childs =  animacao_transform.childCount;

                        for (int child = 0 ;  child  <  numero_childs ; child++) {

                                Transform child_transform =  animacao_transform.GetChild( child );
                                GameObject child_object = child_transform.gameObject;
                                Mono_instancia.Destroy(child_object);

                        }

                        for(int quadro_cor = 0;  quadro_cor < _numero_quadros  ; quadro_cor++){

                                animacao_images_arr[quadro_cor].color = new Color(1f,1f,1f,1f);

                        }


                }
                
                
                animacao_container.transform.SetParent(animacao_transform, false);

                return animacao_images_arr;

                IEnumerator Trocar(){

                        float tempo = 100f;
                        Color cor_inicial = new Color(1f,1f,1f,0f);
                        Color cor_final = new Color(1f,1f,1f,1f);

                        yield return Coroutine_ferramentas.Transicionar_cor( cor_inicial, cor_final,  tempo,  animacao_images_arr );


                }

    }



           

        
        public void Garantir_troca_background(){

            /// passa b2 para b1

        
            if(background_coroutine_visual_novel != null) {
                        
                Mono_instancia.Stop_coroutine(background_coroutine_visual_novel);

                
                Color cor_final = background_2_image.color;
                cor_final[3] = 1f;
                
                background_1_image.sprite = background_2_image.sprite;
                background_1_image.material = background_2_image.material  ;
                ///                        sempre tira a opacidade 
           
                background_1_image.color = cor_final;

                // background_2_image.sprite = null;
                // background_2_image.color =  cor_final;

                background_coroutine_visual_novel = null;

            }

            return;
        }



        public void Encerrar_transicao(){

                

                vai_ser_escondido = false; 


                if( transicao_coroutine != null ) { 

                        Mono_instancia.Stop_coroutine( transicao_coroutine );                        
                        transicao_coroutine = null;

                }

                if( transicao_game_object.transform.childCount > 0 ){

                       // throw new ArgumentException("");

                        Mono_instancia.Destroy ( transicao_game_object.transform.GetChild( 0 ).gameObject );

                }


            }

        public void Transicao_cor_inicio ( int _tempo_ms ){

                Encerrar_transicao();


                vai_ser_escondido = true;
                GameObject transicao_cor_game_object =  Geral.Criar_imagem(  "transicao_cor" , transicao_game_object , 1920f , 1080f );
                Image transicao_cor_image = Geral.ultima_imagem;

                float tempo_ms_float = Convert.ToSingle( _tempo_ms )  ;

                transicao_coroutine = Mono_instancia.Start_coroutine(  a() );

                IEnumerator a() {


                        yield return  Coroutine_ferramentas.Transicionar_cor(   Color.clear  , Color.black ,   tempo_ms_float , new Image[] { transicao_cor_image }  ) ;
//                        throw new ArgumentException("");
                        transicao_coroutine = null;
                        yield break;

                }



        }



        public void Transicao_cor_final ( int _tempo_ms ){



                Encerrar_transicao();

                vai_ser_escondido = false;

                GameObject transicao_cor_game_object =  Geral.Criar_imagem(  "transicao_cor" , transicao_game_object , 1920f , 1080f );
                Image transicao_cor_image = Geral.ultima_imagem;

                float tempo_ms_float = Convert.ToSingle( _tempo_ms )  ;

                transicao_coroutine = Mono_instancia.Start_coroutine(  a() );

                IEnumerator a(){

                        yield  return  Coroutine_ferramentas.Transicionar_cor(   Color.black  , Color.clear ,   tempo_ms_float , new Image[] { transicao_cor_image }  ) ;
                        transicao_coroutine = null;
                        yield break;
                }

        

        }

            public void Transicao_inicio(  string _tipo ){

                        if( transicao_coroutine != null  ){

                                Mono_instancia.Stop_coroutine(transicao_coroutine);
                                transicao_coroutine  = null;
                        }


                        if(_tipo == "true"){

                                transicao_image.color = new Color(0f,0f,0f,1f);
                                return;
                        }


                        float div = 0.05f;
                        
                        if(_tipo == "longa") div = 0.02f;
                        
                        transicao_coroutine  = Mono_instancia.Start_coroutine(a());
                        
                        IEnumerator a(){
                                
                                // yield return null;

                                float opacidade = 0f;

                                while(transicao_image.color.a<0.9f){
                                
                                opacidade += div;
                                transicao_image.color = new Color(0f,0f,0f,opacidade);

                                //yield return new WaitForSeconds(0.017f); 
                                yield return null;

                                }
                        
                                transicao_image.color = new Color(0f,0f,0f,1f);

                                transicao_coroutine = null;
                                yield break;

                        }

            }




        //public void Transicao_cor(  )

                
            public void Transicao( ){

                        // Resetar_transicao();

                        // switch( _transicao_objeto.tipo_atual ){

                        //         case "cor": return _transicao_objeto.Transicao_cor_objeto.Iniciar( transicao_game_object );
                        //         default: throw new ArgumentException("a");
                        // }

                

                        // if( transicao_coroutine != null  ){
                                
                        //         Mono_instancia.Stop_coroutine(transicao_coroutine) ;

                        // }
                        
                        // float duration = -1 ;

                        // switch(_tipo){
                                
                        //         case "curta":  duration = 0.003f  ; break;
                        //         case "normal":  duration = 0.002f ; break;
                        //         case "longa":  duration =  0.001f ; break;
                        //         default: throw new ArgumentException("em transicao background nao veio uma duracao aceitavel, veio: " + _tipo);

                        // }

                        //         transicao_coroutine  = Mono_instancia.Start_coroutine(a());


                        
                        // IEnumerator a(){





                        
                                
                        //         //  yield return null;

                        //         float opacidade = 1f;
                        //         float final = opacidade;
                        //         float variante;

                        //         while(transicao_image.color.a > 0.05f){

                        //         variante = opacidade >0.95f? -0.001f:    opacidade >0.90f?   0f :  opacidade > 0.80f? 0.005f :  opacidade > 0.600f? 0.007f : 0.02f ;
                        
                        //         opacidade -=  (  0.001f  +  duration + variante );

                                
                        //         final =    Mathf.Sqrt(opacidade) + 0.002f;

                        //         transicao_image.color = new Color(0f,0f,0f,opacidade);


                        //         //yield return new WaitForSeconds(0.017f); 
                        //         yield return null;

                        //         }

                                

                        //         transicao_image.color = new Color(0f,0f,0f,0f);

                        //         transicao_coroutine = null;
                        //         yield break;

                        // }



            }



};