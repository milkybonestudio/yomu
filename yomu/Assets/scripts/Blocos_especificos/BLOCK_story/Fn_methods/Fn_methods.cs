using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;



public static class Fn_methods{


      public static void Bloquear_voltar_cenas(){


            
            BLOCO_story.Pegar_instancia().screen_play.Aumentar_contador_cena();
            return;


      }

      

      public static void Bloquear_passar_cenas( ){

            BLOCO_story.Pegar_instancia().screen_play.Diminuir_contador_cena();
            return;

      }


      
      public static void Bloquear_cenas( string _args ){


            char[] args  =  _args.ToCharArray();

            int duracao_ms  =  ( int ) args [ 3 ] - 48 ;
            bool true_block =  args [ 4 ] == 't';
            int numero_clicks = ( int ) args [ 5 ] - 48 ;

            bool tem_click_apo_terminar = ( args [ 6 ] == 't' );

            int numero_frames = ( 60  *  duracao_ms ) / 1000 ;


            
            BLOCO_story bloco_vs = BLOCO_story.Pegar_instancia();

            // ** refazer com o novo modelo

            // bloco_vs.bloqueador.clicks_em_espera = numero_clicks;
            // bloco_vs.bloqueador.numero_frames_para_esperar = numero_frames;
            // bloco_vs.bloqueador.true_block = true_block; 
            // bloco_vs.bloqueador.tem_click =  tem_click_apo_terminar;


            return;

      }
      
      
      



    public static  void Iniciar_animacao(string _args){

            //  id_animation

            char[] args = _args.ToCharArray();

            return;

            // fazer depois 

            /*

            string animacao_nome =  _args[0].Trim();

            switch( animacao_nome ){
                  case "teste": Controlador_animacao_visual_novel.Teste(); break;

            }

            */


      
    }



    public static  void Pegar_jump_por_script( string args ){}


    public static  void Iniciar_modo_comic( string args ){}


    public static  void Encerrar_animacao(){

    }




 


      public static  void Mudar_volume_cena( string _args){


            ///  [fn, true, tipo(music 1, music 2 ... ) , mod , tempo_ms]
            //      tipo_cena,
            //      auto,
            //      nome_fn,

            //      tipo,
            //      slot,

            //      tempo_transicao,
            //      volume

            char[] args = _args.ToCharArray();

            int tipo_audio_int = ( int ) args[ 3 ] - 48 ;


            Tipo_audio tipo_audio =  (Tipo_audio ) tipo_audio_int;


            float modificador_volume =  ((float) ( int ) args[6] - 48     )  /  100f ;

            if(modificador_volume > 200f){

                  Debug.Log("modificador volume tentou ser mais de 2x");
                  modificador_volume = 200f;

            }

            Debug.Log("modificador_volume: " + modificador_volume);


            float tempo_ms = Convert.ToSingle(  ( int ) args[ 5 ] - 48  ) ;


 

            




            if( tipo_audio == Tipo_audio.music ){
                  Debug.Log("veio aqui");

                  CONTROLLER__audio.Pegar_instancia().Mudar_volume_musica_unico(   _slot: 1  , modificador_volume , tempo_ms );



                  return;

            } 

            if( tipo_audio == Tipo_audio.voice ){

                  throw new ArgumentException("voice ainda não pode ter o volume mudado aqui");
                  

            } 

            if(  tipo_audio == Tipo_audio.sfx ){

                  throw new ArgumentException("sfx ainda não pode ter o volume mudado aqui");

            }

            throw new ArgumentException("what: " + tipo_audio);

            return;

      }







   

 
  public static  void Mudar_scale(string _args){

      //  [ 1 ] => 100 => 1,00 175 => 1,75 ...

      char[] args = _args.ToCharArray();

      int personagem_id = ( ( int ) args[ 0 ] - 48  );

      int nova_scale_int = ( ( int ) args[ 1 ] - 48 ); 

      float nova_scale =   Convert.ToSingle( nova_scale_int ) / 100f  ;



      Controlador_personagens_visual_novel controlador_personagens_visual_novel = Controlador_personagens_visual_novel.Pegar_instancia();
      Personagem_dados_visual_novel personagem = controlador_personagens_visual_novel.personagens_dados[ personagem_id ] ;
 
      controlador_personagens_visual_novel.Mudar_scale(personagem,  nova_scale);

       return;
  }


  
   






      public static  void Esconder_nomes(string _args){ Trocar_mostrar_nome_MESMO_NOME(_args, "???");}
      

      public static  void Trocar_mostrar_nome_MESMO_NOME( string _args, string _novo_nome){


            /// fazer depois


            // int quantidade_personagens = _args.Length;

            // for (int i =0 ;  i < quantidade_personagens  ; i++){

            //       string personagem_nome = _args[i].Trim();
            //       Personagem_dados_visual_novel personagem_dados = Controlador_personagens_visual_novel.Pegar_instancia().Pegar_personagem(personagem_nome);
            //       personagem_dados.nome_display = _novo_nome;

            // }             




      }
      
      public static  void Trocar_nomes_display( string _args){
            



      }



      

      public static void Transicao_cor() {

      }





      public static void Transicao (  string _modelo ,  string  _args ){

/*
                 tipo_cena,
                 't',
                 nome_fn,
                 tipo,
                 duracao,
                 

*/                



            char[] args = _args.ToCharArray();




            char tipo_char = args [ 3 ];

            string tipo = Pegar_tipo( tipo_char );

            int duracao_ms = ( ( int ) args[ 4 ]  -  48 )  ;

            


            if( tipo == "cor" ){  

                  if(  _modelo == "inicio" ){ Controlador_tela_story.Pegar_instancia().Transicao_cor_inicio( duracao_ms );  return ; }
                  if(  _modelo == "final" ){ Controlador_tela_story.Pegar_instancia().Transicao_cor_final( duracao_ms );  return ; }


            }




            throw new ArgumentException("nao era para vir aqui");


            






            string Pegar_tipo(char _tipo_char ){

                  switch( _tipo_char ){

                        case '0' : return "cor";
                        default: throw new ArgumentException("nao veio tipo aceitavel em tranciao. Veio: " +  ( (int)_tipo_char  )  );
                  }
            }
            






            return;

      }





      public static void Resetar_text( string _args ){

            Debug.Log("veio resetar");


            Screen_play screen_play = BLOCO_story.Pegar_instancia().screen_play;

            screen_play.personagem_texto_atual = -1;
            screen_play.texto_atual = "";
            screen_play.tipo_texto = -1; 




            char[] args = _args.ToCharArray();
            


            // Controlador_tela_story.Pegar_instancia().pergaminho.Escrever( 

            //       _texto: "",
            //       _personagem: "",
            //       _cor: Color.black,
            //       _tipo: 0

            // );

            // Controlador_tela_story.Pegar_instancia().pergaminho.Abaixar_pergaminho();

            return;



      }


      public static void Mudar_cor_pergaminho(string _args){


            char[] args = _args.ToCharArray();

            int cor_int = ( ( int ) args [ 3 ] - 48  );

            Nome_cor nome =  ( Nome_cor )  cor_int;

            // Controlador_tela_story.Pegar_instancia().pergaminho.Mudar_cor_pergaminho( nome );

            return;


      }



      public static void Mudar_cor_texto_personagens(string _args){



            //    tipo_cena,     auto,   fn_nome,    per_1_id,  cor_id,  per_2_id, cor_id .... 



            Personagem_dados_visual_novel[]personagens_dados = Controlador_personagens_visual_novel.Pegar_instancia().personagens_dados;

            char[] args = _args.ToCharArray();

            int numero_personagem =  ( ( args.Length - 3 ) / 2 ) ;

            string nome_display_atual = null; //*Controlador_tela_story.Pegar_instancia().pergaminho.Pegar_nome_atual();

            for(  int index = 0; index < numero_personagem ;index++ ){


                  char  personagem_id_char = args[  ( index * 2 ) + 3  ] ;
                  char  personagem_cor_char = args[ ( index * 2 ) + 3 + 1  ];

                  int cor_id = ( int ) personagem_cor_char - 48;
                  int personagem_id = ( int ) personagem_id_char - 48;
                  Personagem_dados_visual_novel personagem = personagens_dados[ personagem_id ];

                  string nome_display = personagem.nome_display;

                  Nome_cor nome_cor = ( Nome_cor ) cor_id;
                  personagem.cor_texto_atual_id = cor_id;
                  

                  if( nome_cor == Nome_cor._default ){

                        Nome_cor nome;
                        Enum.TryParse( (personagem.nome + "_default_text_color" )  , true , out nome  );

                        Color cor = Cores.Pegar_cor(  nome  );

                        personagem.cor_texto_atual = cor;
                        personagem.cor_texto_atual_id =  ( int ) nome  ;
                        
                        continue;

                  }

            
                  Color nova_cor = Cores.Pegar_cor( nome_cor );
                  personagem.cor_texto_atual = nova_cor;

                  if( nome_display_atual == nome_display ){

                        //Controlador_tela_story.Pegar_instancia().pergaminho.Mudar_cor( nova_cor );

                  }


            }

            return;


      }


        public static void Trocar_modelo_pergaminho( string args ){}

        public static   void Abaixar_texto(){return;}

        public static  void Levantar_texto(){return;}



    





        public static void Tremer_texto( string args  ){}


    public static void Mudar_posicao_pergaminho(string _args){

        char dir_c = _args[ 3 ] ;
        string direcao = null;

        switch ( dir_c ){

                case '0': direcao = "baixo"; break;
                case '1': direcao = "cima"; break;
                case '2': direcao = "esquerda"; break;
                case '3': direcao = "direita"; break;
                
        }


        // BLOCO_story.Pegar_instancia().screen_play.posicao_pergaminho_atual_id =   ( ( int ) dir_c - 48  );
        // BLOCO_story.Pegar_instancia().controlador_tela_story.pergaminho.Mudar_posicao_pergaminho(direcao);

        return;


    }






      public static void Tremer_tela ( string args  ){}
      public static void Mudar_cor_tela ( string args  ){}
      public static void Colocar_filtro_tela ( string args  ){}

      
      public static void Zoom_tela ( string args  ){}

      public static void Mover_background ( string args  ){}
      public static void Colocar_itens_para_pegar ( string args  ){}



      public static void Criar_objeto ( string _args  ){

            
            // //  tipo_cena     auto    fn_nome   obj_tipo  

            // char[] args = _args.ToCharArray();

            // Tipo_objeto_visual_novel objeto_tipo = ( Tipo_objeto_visual_novel )  ( ( int ) args[ 3 ] - 48  ) ;

            // // simples
            // if( objeto_tipo == 1 ){


            //       //  tipo_cena     auto    fn_nome   obj_tipo    plano   persoangem_id   sing_x    posicao_x     sign_y    posicao_y     obj_path 

            
                        
            //             Tipo_plano_objeto_visual_novel plano =   ( Tipo_objeto_visual_novel )  ( ( int ) args [ 4 ] - 48 ) ;

            //             float p_x_sign = 1f;  if( args[ 5 ] == '0' ){ p_x_sign = -1f ; }
            //             float p_y_sign = 1f;  if( args[ 7 ] == '0' ){ p_y_sign = -1f ; }

            //             float p_x = Convert.ToSingle(  ( ( int ) ars[ 6 ] - 48 )  )  * p_x_sign ; 
            //             float p_y = Convert.ToSingle(  ( ( int ) ars[ 8 ] - 48 )  )  * p_y_sign ; 

            //             int numero_char_path = args.Length - 9 ;

            //             char[] path_char_arr = new char[ numero_char_path ] ;

            //             for( int c  =0 ; c < numero_char_path ; c++){

            //                   path_char_arr [ c ] = args [ 9 + c] ;

            //             }
            //             obj_path = new string( path_char_arr );

            //             if( plano < 0 ){

            //                   string plano_string = null;

            //                   if( plano == -1 ) { plano_string = "frente" ; }
            //                   if( plano == -2 ) { plano_string = "background" ; }

            //                   Controlador_tela_story.Pegar_instancia().Criar_objeto_simples( plano_string ,  obj_path , p_x , p_y  ) ;  

            //             }

            //             int personagem_index = plano;

            //             Controlador_personagens_visual_novel.Pegar_instancia().Criar_objeto_simples( personagem_index , obj_path , p_x , p_y ) ;

            //             return;

            // }





      }



      public static void Modificar_objeto ( string args  ){}

      public static void Escolha_rapida ( string args  ){}
    
      public static void Rotacionar_objeto ( string args  ){}



      public static void Mostrar_mensagem ( string args  ){}





  






    public static void Mudar_background( string _args ){


            //  tipo  auto   nome  tem_transicao  tipo_foco id_cor path

            /*

                  tem que lembrar que as cores vao vir com +48.

                  ** se vir de mudar_foco o path vai vir como 0

                  ** path sempre começa no index 8

            */

            char[] args = _args.ToCharArray();

            


            int foco = ( ( int ) args[ 4 ] - 48 ) ;

            int cor =  (( int )args[ 5 ]  - 48 )  ;

            //bool[] transicao_arr = new bool[2];

            bool instantaneo = ( args[3] == '0' ) ;

            char[] path_char  = new char[ args.Length - 6 ];

            for( int i = 0 ;  i <  path_char.Length ; i++){

                  path_char[ i ] = args[  i + 6 ];

            }

            string novo_background_path = new string( path_char );


            if( novo_background_path != "0" ) { BLOCO_story.Pegar_instancia().screen_play.path_background_atual = novo_background_path; }

            switch( foco ){

                  case 0 :   if(Controlador_tela_story.Pegar_instancia().Background_esta_em_foco()){ foco = 3; } else { foco = 2; } break;
                  case 1 :   if(Controlador_tela_story.Pegar_instancia().Background_esta_em_foco()){ foco = 2; } else { foco = 3; } break;
                  case 2:    foco = 2 ; break;
                  case 3:    foco = 3 ; break;
                  throw new ArgumentException("nao veio tipo aceitavel em foco, rage era 0-3. veio: " + foco);

            }
         
            BLOCO_story.Pegar_instancia().screen_play.foco_camera_personagens_atual_id = foco;
            

            BLOCO_story.Pegar_instancia().screen_play.background_cor_id = cor;

            

            /*

                  screen_play.dados?

            */


            Controlador_tela_story.Pegar_instancia().Mudar_background( novo_background_path , !instantaneo, foco , cor ); 
            return;      


   }

    

    


   public static void Mudar_foco_camera_personagens( string _args ){


            char[] args = _args.ToCharArray();

            char modo_char = args[ 3 ];


            bool instantaneo = ( args[ 4 ] == 't' ) ;

            string modo = "normal";

            switch( modo_char  ){

                  case '0': modo = "normal" ; break;
                  case '1': modo = "afastado" ; break;
                  case '2': modo = "proximo" ; break;
                  case '3': modo = "sem_alteracao"; break;
                  default: throw new ArgumentException("nao foi achado tipo foco_camera");


            }


            BLOCO_story.Pegar_instancia().screen_play.foco_camera_personagens_atual_id = ( ( int ) modo_char  - 48 );
            BLOCO_story.Pegar_instancia().screen_play.foco_camera_personagens_instantaneo = args[ 4 ];



            Controlador_personagens_visual_novel.Pegar_instancia().Mudar_foco_camera_personagens(modo, instantaneo);

            return;


   }



   public static  void Flip_foco(string args){


      Controlador_tela_story controlador_tela_story = Controlador_tela_story.Pegar_instancia();



            int tipo_foco = 1;
            bool tem_transicao = true;

            if(args.Length > 0) {

                  tipo_foco = Convert.ToInt32( args[ 0 ] );

            }

            if(args.Length > 1) {
            
                  tem_transicao = Convert.ToBoolean( args[ 1 ] );
                  return;

            }

            controlador_tela_story.Mudar_background(  "" , tem_transicao , tipo_foco , -1);

            return;

   }










      public static void Mudar_visibilidade_personagens (  string _args ){

            //                        MOST       p1     p2  p3 ...
            //  tipo  auto   nome_fn  't'/'f'    0     1    0  ....


            Controlador_personagens_visual_novel controlador_personagens_visual_novel = Controlador_personagens_visual_novel.Pegar_instancia();
            

            char[] args = _args.ToCharArray();

            bool mostrar_personagens = ( args[ 3 ] == 't' );


            Personagem_dados_visual_novel[] personagens_dados = controlador_personagens_visual_novel.personagens_dados;

            for( int i = 4   ;   i < args.Length ;  i++  ){

                        int index_personagem = ( ( int ) args[ i ]  - 48 ) ;


                        Personagem_dados_visual_novel personagem = personagens_dados[ index_personagem ];

                        Color cor_final = personagem.cor_final;

                        if( mostrar_personagens ){ cor_final[ 3 ] = 1f; } else { cor_final[ 3 ] = 0f; }

                        personagem.cor_final = cor_final;

                        controlador_personagens_visual_novel.Mudar_cor_personagem(   personagem,  cor_final);
                  
            }

            return;

      }




      public static void Mudar_index_personagens ( string  _args ) {

            // fn auto nome    (   p1      novo_index     )  (    p2  novo_index)      p3 novo_index ...

            int numero = 0 ;
            Controlador_personagens_visual_novel controlador_personagens_visual_novel = Controlador_personagens_visual_novel.Pegar_instancia();
            Screen_play screen_play = BLOCO_story.Pegar_instancia().screen_play;



            char[] args = _args.ToCharArray();
            int numero_personagens = ( args.Length - 3 ) / 2 ;

            
            int[] personagens_indexes = new int[ numero_personagens ];
            int[] novos_indexes = new int[ numero_personagens ];



            for( int i = 0 ;  i < numero_personagens ; i++ ){

 
                        personagens_indexes [ i ] = ( ( int ) args[ ( i * 2 ) + 3 ]    - 48 );
                        novos_indexes [ i  ] = ( ( int ) args[ ( i * 2 ) + 3 + 1 ]   - 48 );

            }



            int numero_maximo_personagens = screen_play.nomes_personagens.Length;

            int[] personagens_POR_index_atual = screen_play.personagens_POR_index;
            int[] novo_personagem_POR_index = new int[ numero_maximo_personagens ];



            for( numero = 0 ; numero < novo_personagem_POR_index.Length ; numero++ ){ novo_personagem_POR_index[ numero ] = -1; }


            for( numero = 0 ; numero < novos_indexes.Length ; numero++ ){

                  
                        int novo_index = novos_indexes[ numero ];
                        int personagem_do_novo_index = personagens_indexes [ numero ];


                        novo_personagem_POR_index[ novo_index ] = personagem_do_novo_index ;

            }

            //   [     4    2    -1   -1    6   -1    ] 


            int pointer_personagem_atual = 0;

            for( numero = 0 ; numero < novo_personagem_POR_index.Length ; numero++ ){


                        int personagem_id =  novo_personagem_POR_index[ numero ];

                        if( personagem_id != -1 ) continue;

                        for( int index_interno = 0 ;  index_interno < 100  ;index_interno++  ){

                                    int per_index = personagens_POR_index_atual [ pointer_personagem_atual ] ;
                                    pointer_personagem_atual++;

                                    bool personagem_esta_em_algum_outro_NOVO_index = INT.Tem_valor_no_array(   _arr: novo_personagem_POR_index   , _valor: per_index  );

                                    if( personagem_esta_em_algum_outro_NOVO_index ){  continue; }

                                    novo_personagem_POR_index[ numero ] = per_index;

                                    break;

                        }


            }


            //    [     4    2    1   5    6  3   ] 

            Personagem_dados_visual_novel[] personagens_dados = Controlador_personagens_visual_novel.Pegar_instancia().personagens_dados;


            for(  numero = 0  ;  numero <  novo_personagem_POR_index.Length ;  numero++  ){


                        int personagem_id = novo_personagem_POR_index[ numero ];
                        
                        Personagem_dados_visual_novel personagem = personagens_dados[  personagem_id  ];

                        personagem.game_object.transform.SetSiblingIndex( numero );

            }


            screen_play.personagens_POR_index = novo_personagem_POR_index;


            //Geral.Salvar_string(      Geral.Int_arr_to_string( novo_personagem_POR_index  )  );

            return;


      }





      public static void Modificar_switch_MODO_personagens ( string _args ) {
            

            //                          switch_MODO      mod         
            //  tipo  auto   nome_fn      'id'          'a'/'d'   

                  char[] args = _args.ToCharArray();


                  Tipo_switch_MODO_fn tipo_switch =  ( Tipo_switch_MODO_fn ) ( ( int ) args[ 3 ] - 48 );
                  bool mod = args[ 4 ] == 'a';


                  BLOCO_story bloco_story = BLOCO_story.Pegar_instancia();

                  
                  switch( tipo_switch ){

                        case Tipo_switch_MODO_fn.highlight:  Controlador_personagens_visual_novel.Pegar_instancia().Tirar_highlight_todos_personagens( ) ;  bloco_story.screen_play.is_highlight_activate = mod  ; break;
                        case Tipo_switch_MODO_fn.sombras: bloco_story.screen_play.is_sombras_activate = mod;  break;
                        case Tipo_switch_MODO_fn.tamanho: bloco_story.screen_play.is_tamanho_activate = mod; break;

                  }       

                  return;


      }






      public static void Modificar_switch_personagens (  string  _args  ){


            //                        variavel_switch_id       _mod          p1_id   p2_id
            //  tipo  auto   nome_fn                      't'/'f'        0        4 

                  char[] args = _args.ToCharArray();

                  Tipo_switch_fn tipo_switch =  ( Tipo_switch_fn ) ( ( int ) args[ 3 ] - 48 );

                  /* 'c'  => colocar  't' => tirar */

                  bool mod = ( args[ 4 ] == 'c' ) ;

                  
                  Personagem_dados_visual_novel[] personagens_dados = Controlador_personagens_visual_novel.Pegar_instancia().personagens_dados;

                  int numero_personagens = (  args.Length - 5  ) ;   


                  for(   int personagem_index = 0 ;   personagem_index  <  numero_personagens   ; personagem_index++  ){


                              int personagem_id =  ( int ) args[ personagem_index   + 5  ] - 48  ;
                                                            
                              Personagem_dados_visual_novel personagem = personagens_dados[ personagem_id ];


                              switch( tipo_switch ){

                                    case Tipo_switch_fn.cor: personagem.tem_transicao_cor = mod  ; break;
                                    case Tipo_switch_fn.movimento: personagem.tem_transicao_movimento = mod;  break;
                                    case Tipo_switch_fn.highlight: personagem.tem_highlight = mod; break;

                              }            
                  
                  }


            
                  return;


      }





      public static void Mudar_cor_personagens ( string  _args ){ 


                  // [fn,true, nome ,   personagem_1  , cor_id, personagem_2  ,cor_id  ....]

                  Personagem_dados_visual_novel[] personagens_dados =  Controlador_personagens_visual_novel.Pegar_instancia().personagens_dados;

                  char[] args = _args.ToCharArray();


                  int numero_de_personegens = (args.Length - 3 ) / 2;

                  for(   int i = 0   ;   i  <  numero_de_personegens    ;  i++   ){


                              int personagem_id  =   ( int ) args[  (  i  *  2  )  +  3  ]  - 48;
                              int cor_id         =   ( int ) args[  (  i  *  2  )  +  3  + 1 ]  - 48;


                              Personagem_dados_visual_novel personagem = personagens_dados[ personagem_id ];

                              personagem.cor_personagem_atual_id = cor_id;

                              Nome_cor nome_cor =  ( Nome_cor ) cor_id;
                              
                              Color cor  = Cores.Pegar_cor( nome_cor );

                              float alp =  personagem.cor_final[ 3 ];

                              Color cor_final = new Color(  cor[0]  , cor[1]  , cor[2]   , alp  );

                              Controlador_personagens_visual_novel.Pegar_instancia().Mudar_cor_personagem(  personagem, cor_final);


                  }
                  return;

      }



      public static void Mudar_nome_display ( string _args ){

            
            //  tipo  auto  nome_fn  id_per novo novo++

            int id_personagem = (  ( int ) _args[ 3 ] - 48 );


            char[] nome = new char[ _args.Length - 4 ];

            for(int i = 4;  i < _args.Length ;i++) {

                  nome[ i - 4 ] = _args[ i ];

            }

            string novo_nome  = new string ( nome );



            Personagem_dados_visual_novel personagem = Controlador_personagens_visual_novel.Pegar_instancia().personagens_dados[ id_personagem ];

            string nome_antigo = personagem.nome_display; 

            personagem.nome_display = novo_nome; 

            // Pergaminho_modelo_1 pergaminho = Controlador_tela_story.Pegar_instancia().pergaminho;

            // if(  pergaminho == null  ) { return ; }


            // if(  pergaminho.Pegar_nome_atual() == nome_antigo ){

            //       pergaminho.Mudar_nome( novo_nome );


            // }

            return;



      }




      public static void Aplicar_efeito_personagens( string _args){

            char[] args = _args.ToCharArray();


      }







   public static void Tremer_personagem( string  args  ){}
   public static void Mudar_scale_personagem( string  args  ){}



   public static void Ativar_sombras( string  args  ){}
   public static void Desativar_sombras( string  args  ){}



   public static void Ativar_desfoco_personagem( string  args  ){}
   public static void Desativar_desfoco_personagem( string  args  ){}


   public static void Rotacionar_personagem( string  args  ){}

   public static void Animar_personagem( string  args  ){}




}
