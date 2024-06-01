using System;
using UnityEngine;
using UnityEngine.UI;






public static  class Fn_methods_personagens {




      public static void Mudar_visibilidade_personagens (  string _args ){

            //                        MOST       p1     p2  p3 ...
            //  tipo  auto   nome_fn  't'/'f'    0     1    0  ....


            Controlador_personagens_visual_novel controlador_personagens_visual_novel = Controlador_personagens_visual_novel.Pegar_instancia();
            

            char[] args = _args.ToCharArray();

            bool mostrar_personagens = ( args[ 3 ] == 't' );

            Debug.Log("mostrar persoangens: " + mostrar_personagens );


            Personagem_dados_visual_novel[] personagens_dados = controlador_personagens_visual_novel.personagens_dados;

            for( int i = 4   ;   i < args.Length ;  i++  ){

                        int index_personagem = ( ( int ) args[ i ]  - 48 ) ;

                        Personagem_dados_visual_novel personagem = personagens_dados[ index_personagem ];

                        Color cor_final = personagem.cor_final;

                        if( mostrar_personagens ){ cor_final[ 3 ] = 1f; } else { cor_final[ 3 ] = 0f; }

                        controlador_personagens_visual_novel.Mudar_cor_personagem(   personagem,  cor_final);
                  
            }

            return;

      }




      public static void Mudar_index_personagens ( string  _args ) {


            char[] args = _args.ToCharArray();


            // fn auto nome    (   p1      novo_index     )  (    p2  novo_index)      p3 novo_index ...


            Controlador_personagens_visual_novel controlador_personagens_visual_novel = Controlador_personagens_visual_novel.Pegar_instancia();
            Screen_play screen_play = BLOCO_visual_novel.Pegar_instancia().screen_play;

            
            int numero_personagens = ( args.Length - 3 ) / 2 ;
            

            int numero = 0 ;

            int[] personagens_indexes = new int[ numero_personagens ];
            int[] novos_indexes = new int[ numero_personagens ];



            for( int i = 0 ;  i < numero_personagens ; i++ ){

                  Debug.Log("lg: " + ( args.Length) );
                  Debug.Log("a: " + (( i * 2 ) + 3) );
 
                        personagens_indexes [ i ] = ( ( int ) args[ ( i * 2 ) + 3 ]    - 48 );
                        novos_indexes [ i  ] = ( ( int ) args[ ( i * 2 ) + 3 + 1 ]   - 48 );

            }


            int numero_maximo_personagens = screen_play.nomes_personagens.Length;
            int[] personagens_POR_index_atual = screen_play.personagens_POR_index;


            int[] novo_personagem_POR_index = new int[ numero_personagens ];
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

                        Debug.Log(personagem.nome  + " vai para o index: " + numero);

                        personagem.game_object.transform.SetSiblingIndex( numero );

            }

            
            return;


      }





      public static void Modificar_switch_MODO_personagens ( string _args ) {
            

            //                          switch_MODO      mod         
            //  tipo  auto   nome_fn      'id'          'a'/'d'   

                  char[] args = _args.ToCharArray();


                  Tipo_switch_MODO_fn tipo_switch =  ( Tipo_switch_MODO_fn ) ( ( int ) args[ 3 ] - 48 );
                  bool mod = args[ 4 ] == 't';


                  BLOCO_visual_novel bloco_visual_novel = BLOCO_visual_novel.Pegar_instancia();

      
                  switch( tipo_switch ){

                        case Tipo_switch_MODO_fn.highlight: Debug.Log("veio highlight"); bloco_visual_novel.screen_play.is_highlight_activate = mod  ; break;


                        case Tipo_switch_MODO_fn.sombras: Debug.Log("veio sombra");bloco_visual_novel.screen_play.is_sombras_activate = mod;  break;

                        
                        case Tipo_switch_MODO_fn.tamanho:Debug.Log("veio tamanho"); bloco_visual_novel.screen_play.is_tamanho_activate = mod; break;

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

                              Debug.Log("mudou " +  personagem.nome + " para " + mod );


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


                              float alp =  personagem.image.color[3];

                              Color cor_final = new Color(  cor[0]  , cor[1]  , cor[2]   , alp  );

                              Controlador_personagens_visual_novel.Pegar_instancia().Mudar_cor_personagem(  personagem, cor_final);
                              return;

                  }

      }



      public static void Mudar_nome_display ( string _args ){

            
            //  tipo  auto  nome_fn  id_per novo novo++

            int id_personagem = (  ( int ) _args[ 3 ] - 48 );


            char[] nome = new char[ _args.Length - 4 ];

            for(int i = 4;  i < _args.Length ;i++){

                  nome[ i - 4 ] = _args[ i ];


            }

            string novo_nome  = new string ( nome );



            Personagem_dados_visual_novel personagem_dados = Controlador_personagens_visual_novel.Pegar_instancia().personagens_dados[ id_personagem ];

            personagem_dados.nome_display = novo_nome;

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