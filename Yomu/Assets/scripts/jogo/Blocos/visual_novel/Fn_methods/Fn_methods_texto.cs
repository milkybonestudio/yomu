// using System.Collections;
// using System;
// using System.Collections.Generic;
// using UnityEngine;
// using System.Text.RegularExpressions;


// public static class Fn_methods_texto {


//       public static void Resetar_text( string _args ){

//             Debug.Log("veio resetar");


//             Screen_play screen_play = BLOCO_visual_novel.Pegar_instancia().screen_play;

//             screen_play.personagem_texto_atual = -1;
//             screen_play.texto_atual = "";
//             screen_play.tipo_texto = -1; 




//             char[] args = _args.ToCharArray();
//             bool abaixar_pergaminho = ( args[ 2 ] == 't' ) ;


//             Controlador_tela_visual_novel.Pegar_instancia().pergaminho.Escrever( 

//                   _texto: "",
//                   _personagem: "",
//                   _cor: Color.black,
//                   _tipo: 0

//             );

//             if( abaixar_pergaminho ){

//                   Controlador_tela_visual_novel.Pegar_instancia().pergaminho.Abaixar_pergaminho();

//             }

//             return;



//       }


//       public static void Mudar_cor_pergaminho(string _args){



//             int numero =  ( ( int ) _args[0] + 48 ) ;



//             Controlador_tela_visual_novel.Pegar_instancia().pergaminho.Mudar_cor_pergaminho( Color.white, numero );

//             return;


//       }



//       public static void Mudar_cor_texto_personagens(string _args){



//             //    tipo_cena,     auto,   fn_nome,    per_1_id,  cor_id,  per_2_id, cor_id .... 



//             Personagem_dados_visual_novel[]personagens_dados = Controlador_personagens_visual_novel.Pegar_instancia().personagens_dados;

//             char[] args = _args.ToCharArray();

//             int numero_personagem =  ( ( args.Length - 3 ) / 2 ) ;


//             for(  int index = 0; index < numero_personagem ;index++ ){


//                   char  personagem_id_char = args[  ( index * 2 ) + 3  ] ;
//                   char  personagem_cor_char = args[ ( index * 2 ) + 3 + 1  ];

//                   int cor_id = ( int ) personagem_cor_char - 48;
//                   int personagem_id = ( int ) personagem_id_char - 48;
//                   Personagem_dados_visual_novel personagem = personagens_dados[ personagem_id ];

//                   Nome_cor nome_cor = ( Nome_cor ) cor_id;
//                   personagem.cor_texto_atual_id = cor_id;
                  

//                   if( nome_cor == Nome_cor._default ){

//                         Nome_cor nome = ( Nome_cor )Enum.Parse( typeof( Nome_cor ) ,  (  personagem.nome + "_default_text_color"  ) ) ;

//                         Color cor = Cores.Pegar_cor(  nome  );

//                         personagem.cor_texto_atual = cor;
//                         personagem.cor_texto_atual_id =  ( int ) nome  ;
                        
//                         return;

//                   }

            
//                   Color nova_cor = Cores.Pegar_cor( nome_cor );
//                   personagem.cor_texto_atual = nova_cor;

//                   return;

//             }



//       }


//       public static void Trocar_modelo_pergaminho( string args ){}

//       public static   void Abaixar_texto(){

                  
//             Controlador_tela_visual_novel.Pegar_instancia().pergaminho.Abaixar_pergaminho();

//             return;

//       }
    
//     public static  void Levantar_texto(){

//         Controlador_tela_visual_novel.Pegar_instancia().pergaminho.Levantar_pergaminho();

//         return;

//     }



    





// public static void Tremer_texto( string args  ){}


//    public static void Mudar_posicao_pergaminho(string _args){

//       char dir_c = _args[ 3 ] ;
//       string direcao = null;

//       switch ( dir_c ){

//             case '0': direcao = "baixo"; break;
//             case '1': direcao = "cima"; break;
//             case '2': direcao = "esquerda"; break;
//             case '3': direcao = "direita"; break;
            
//       }


//       BLOCO_visual_novel.Pegar_instancia().screen_play.posicao_pergaminho_atual_id =   ( ( int ) dir_c - 48  );
//       BLOCO_visual_novel.Pegar_instancia().controlador_tela_visual_novel.pergaminho.Mudar_posicao_pergaminho(direcao);

//       return;


//    }




// }