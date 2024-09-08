// using System;
// using UnityEngine;
// using UnityEngine.UI;


// public static class Fn_methods_tela {


//       public static void Tremer_tela ( string args  ){}
//       public static void Mudar_cor_tela ( string args  ){}
//       public static void Colocar_filtro_tela ( string args  ){}

//       public static void Transicao ( string args  ){}
//       public static void Zoom_tela ( string args  ){}

//       public static void Mover_background ( string args  ){}
//       public static void Colocar_itens_para_pegar ( string args  ){}
//       public static void Criar_objeto ( string args  ){}
//       public static void Modificar_objeto ( string args  ){}

//       public static void Escolha_rapida ( string args  ){}
    
//       public static void Rotacionar_objeto ( string args  ){}



//       public static void Mostrar_mensagem ( string args  ){}





  






//     public static void Mudar_background( string _args ){


//             //  tipo  auto   nome  tem_transicao  tipo_foco id_cor path

//             /*

//                   tem que lembrar que as cores vao vir com +48.

//                   ** se vir de mudar_foco o path vai vir como 0

//                   ** path sempre começa no index 8

//             */

//             char[] args = _args.ToCharArray();

            


//             int foco = ( ( int ) args[ 4 ] - 48 ) ;

//             int cor =  (( int )args[ 5 ]  - 48 )  ;

//             //bool[] transicao_arr = new bool[2];

//             bool instantaneo = ( args[3] == 'f' ) ;

//             char[] path_char  = new char[ args.Length - 6 ];

//             for( int i = 0 ;  i <  path_char.Length ; i++){

//                   path_char[ i ] = args[  i + 6 ];

//             }

//             string novo_background_path = new string( path_char );


//             Controlador_tela_visual_novel.Pegar_instancia().Mudar_background( novo_background_path , !instantaneo, foco , cor ); 
//             return;      


//    }

    

    


//    public static void Mudar_foco_camera_personagens( string _args ){


//             char[] args = _args.ToCharArray();

//             char modo_char = args[ 3 ];


//             bool instantaneo = ( args[ 4 ] == 't' ) ;

//             string modo = "normal";

//             switch( modo_char  ){

//                   case '0': modo = "normal" ; break;
//                   case '1': modo = "afastado" ; break;
//                   case '2': modo = "proximo" ; break;


//             }


//             Controlador_personagens_visual_novel.Pegar_instancia().Mudar_foco_camera_personagens(modo, instantaneo);

//             return;


//    }



//    public static  void Flip_foco(string args){


//       Controlador_tela_visual_novel controlador_tela_visual_novel = Controlador_tela_visual_novel.Pegar_instancia();



//             int tipo_foco = 1;
//             bool tem_transicao = true;

//             if(args.Length > 0) {

//                   tipo_foco = Convert.ToInt32( args[ 0 ] );

//             }

//             if(args.Length > 1) {
            
//                   tem_transicao = Convert.ToBoolean( args[ 1 ] );
//                   return;

//             }

//             controlador_tela_visual_novel.Mudar_background(  "" , tem_transicao , tipo_foco , -1);

//             return;

//    }




//    public static void Encerrar_transicao(){

//       Controlador_tela_visual_novel controlador_tela = Controlador_tela_visual_novel.Pegar_instancia();

//       if( controlador_tela.transicao_coroutine != null ){
//             controlador_tela.Resetar_transicao();
            
//       }

//    }





















// }