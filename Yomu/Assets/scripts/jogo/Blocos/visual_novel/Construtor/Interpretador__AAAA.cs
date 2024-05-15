// using System.Collections;
// using System;
// using System.Collections.Generic;
// using UnityEngine;
// using System.Text.RegularExpressions;

// /*

//   screen_play:
//      - sempre inicia com set e sempre finaliza com end.
//      - só tem 1 set por screen.
//      - pode ter mais de 1 end por screen.

// */



// public static class Interpretador {





//         public static Cenas Construir(  Nome_screen_play _nome  ) {

//           /*

//               construir_por_compilado só re-compila caso o arquivo nao exista. se o arquivo de produção tiver mudado nao vai atualizar. 
//               em teoria no editor eu so vou forçar usar o compilado para ver se o leitor e o compilador estão funcionando

//               ** posso colocar um opcao em teste para forçar compilar algum arquivo 

//           */


//             if( Application.isEditor ){

//                 Garantir_backup( _nome );              
//                 return Construir_por_producao( _nome );

//                 // if (  Config.visual_novel_testar_compilado  ){
//                 //     return Construir_por_compilado( _nome );
//                 // }

//             }




//             // RUN

//             return Construir_por_compilado( _nome );


//         }






//         // public static void Garantir_backup( Nome_screen_play _nome ){

//         //     /// pode ser multicory

//         //     ///  garante que as versos estao corretas

//         //     Debug.Log("veio em garantir backup");
//         // //

//         // }





//         public static void Garantir_compilado_existe( string _path_nome ){

//             string path =  Visual_novel_paths.Pegar_path_file_compilado( _nome_file_path: _path_nome , _retirar_extensao: true ) ; 


//             TextAsset text = Resources.Load<TextAsset>( path );

//             if( text == null ){

//                 string path_screen_play_em_producao = Visual_novel_paths.Pegar_path_file_producao( _path_nome );
//                 bool file_producao_nao_existe =  ! System.IO.File.Exists( path_screen_play_em_producao );

//                 if( file_producao_nao_existe ){

//                     throw new ArgumentException("screen play não foi encontrado tanto compilado quanto em producao. nome: " + _path_nome);

//                 }

//                 Compilador_screen_play.Compilar( _path_nome );
                
//                 Debug.Log(" Compilador_screen_play.Compilar foi ativado");



//             }
//         //
//         //
//         }



//         public static void verificar_se_producao_existe( string _path_nome ){

//                 string path_completo =   Visual_novel_paths.Pegar_path_file_producao( _path_nome );

//                 bool screen_play_nao_existe =  !System.IO.File.Exists( path_completo );

//                 Debug.Log("path_completo: " + path_completo);

//                 if(screen_play_nao_existe){

//                    throw new ArgumentException ("screen_play de produção nao foi encontrada no path: " + path_completo);

//                 }

//                 Debug.Log("producao_existe");

//                 return;

//         }

  
//         public static Cenas Construir_por_producao (  Nome_screen_play _nome  ){


//               // Compilador_screen_play.Compilar( _nome  );

//               // return Construir_por_compilado( _nome );


//               var watch = System.Diagnostics.Stopwatch.StartNew();

//               string path_nome = Visual_novel_paths.Pegar_nome_path_screen_play( _nome );

//               Debug.Log("path_nome: " + path_nome);

//               if(Application.isEditor) { verificar_se_producao_existe( path_nome );}

//               string path_completo = Visual_novel_paths.Pegar_path_file_producao( path_nome );

//               string cenas_raw = System.IO.File.ReadAllText( path_completo );


//               Cenas cenas_feitas = new Cenas();


//               int[] linhas_localizador_cenas = Pegar_linhas_localizador( cenas_raw );




//               Debug.Log(cenas_raw.Length);
//             //  cenas_raw = Regex.Replace( cenas_raw, @".\[", "\\]");


//               cenas_raw = Regex.Replace( cenas_raw, @"\](.|\s)*?\[", "]\r\n[");


//             //  cenas_raw = Regex.Replace( cenas_raw, @".\r\n", String.Empty);
//               Debug.Log(cenas_raw.Length);
              

              
//               // cenas_raw = Regex.Replace(cenas_raw, @"(\r\n)+", "\r\n").Trim();
//               // cenas_raw = Regex.Replace(cenas_raw, @"(?<=$//).*?(?=\r\n)", "\r\n");
//               // cenas_raw = Regex.Replace(cenas_raw, @"\r\n( )+\r\n", "\r\n");


//               string[] cenas_raw_lines = cenas_raw.Split("]\r\n[");






//               cenas_raw_lines[0] = cenas_raw_lines[0].Split("[")[1].Trim() ;
//               cenas_raw_lines[cenas_raw_lines.Length-1] = cenas_raw_lines[cenas_raw_lines.Length-1].Trim();
//               cenas_raw_lines[cenas_raw_lines.Length-1] = cenas_raw_lines[cenas_raw_lines.Length-1].Remove(     cenas_raw_lines[cenas_raw_lines.Length-1].Length -1    ) ;
              
//               foreach(   string LINE_ in cenas_raw_lines ) Debug.Log( LINE_ );
              
//               int total_cenas = cenas_raw_lines.Length;
            
          
//               cenas_feitas.cenas_ids = new int [total_cenas];
//               cenas_feitas.cenas_tipos = new int [total_cenas];
              
//               string line;
//               string tipo;



//               int set_id = 0;
//               int ic_id =  1;
//               int text_id =  2;
//               int mov_id =  3;
//               int choice_id =  4;
//               int fn_id =  5;
//               int audio_id =  6;
//               int pointer_id =  7;
//               int jump_id =  9;
//               int end_id =  10;
              
//               int[] quantidade_cenas = new int[ end_id + 1];


              
//               for ( int i = 0  ;   i<total_cenas   ;i++   ){

//                   line = cenas_raw_lines[i];
//                   tipo = Pegar_tipo(line);


                  
                
//                   switch ( tipo ){

//                         case "set" :    cenas_feitas.cenas_ids[i] = quantidade_cenas[ set_id ]  ; quantidade_cenas[ set_id ]++ ; cenas_feitas.cenas_tipos[i] = set_id ; break;
//                         case "ic" :    cenas_feitas.cenas_ids[i] = quantidade_cenas[ ic_id ]  ; quantidade_cenas[ ic_id ]++ ; cenas_feitas.cenas_tipos[i] = ic_id ; break;
//                         case "text" :    cenas_feitas.cenas_ids[i] = quantidade_cenas[ text_id ]  ; quantidade_cenas[ text_id ]++ ; cenas_feitas.cenas_tipos[i] = text_id ; break;
//                         case "mov" :    cenas_feitas.cenas_ids[i] = quantidade_cenas[ mov_id ]  ; quantidade_cenas[ mov_id ]++ ; cenas_feitas.cenas_tipos[i] = mov_id ; break;
//                         case "choice" :    cenas_feitas.cenas_ids[i] = quantidade_cenas[ choice_id ]  ; quantidade_cenas[ choice_id ]++ ; cenas_feitas.cenas_tipos[i] = choice_id ; break;
//                         case "fn" :    cenas_feitas.cenas_ids[i] = quantidade_cenas[ fn_id ]  ; quantidade_cenas[ fn_id ]++ ; cenas_feitas.cenas_tipos[i] = fn_id ; break;
//                         case "audio" :    cenas_feitas.cenas_ids[i] = quantidade_cenas[ audio_id ]  ; quantidade_cenas[ audio_id ]++ ; cenas_feitas.cenas_tipos[i] = audio_id ; break; 
//                         case "pointer" :    cenas_feitas.cenas_ids[i] = quantidade_cenas[ pointer_id ]  ; quantidade_cenas[ pointer_id ]++ ; cenas_feitas.cenas_tipos[i] = pointer_id ; break; 
//                         case "jump" :    cenas_feitas.cenas_ids[i] = quantidade_cenas[ jump_id ]  ; quantidade_cenas[ jump_id ]++ ; cenas_feitas.cenas_tipos[i] = jump_id ; break; 
//                         case "end" :    cenas_feitas.cenas_ids[i] = quantidade_cenas[end_id  ]  ; quantidade_cenas[ end_id ]++ ; cenas_feitas.cenas_tipos[i] = end_id ; break; 

//                         //case ' ' :   if(line.Trim() == ""){ pulo_por_espacos++;continue;} Debug.Log("AAAAAAAAAAAAAAA");break;
                        
//                         default : throw new ArgumentException("nao foi achado tipo cena na linha: " + linhas_localizador_cenas[ i ] );

//                     } 

//               }



    
      
            




//                 cenas_feitas.cenas_set = new Cena_set [quantidade_cenas[ set_id ]];
//                 cenas_feitas.cenas_ic = new Cena_ic [quantidade_cenas[ ic_id ]];
//                 cenas_feitas.cenas_text = new Cena_text [quantidade_cenas[  text_id  ]];
//                 cenas_feitas.cenas_mov = new Cena_mov [quantidade_cenas[ mov_id ]];
//                 cenas_feitas.cenas_choice = new Cena_choice [quantidade_cenas[ choice_id ]];
//                 cenas_feitas.cenas_fn = new Cena_fn [quantidade_cenas[ fn_id ]];
//                 cenas_feitas.cenas_audio = new Cena_audio [quantidade_cenas[ audio_id ]];
//                 cenas_feitas.cenas_pointer = new Cena_pointer [quantidade_cenas[ pointer_id ]];
//                 cenas_feitas.cenas_jump = new Cena_jump [quantidade_cenas[ jump_id ]];
//                 cenas_feitas.cenas_end = new Cena_end [quantidade_cenas[ end_id ]];

                
//               string[] jump_ids = new string[100];
//               int[]  jump_ids_cenas = new int[100];
              
//                 int jump_id_atual = 0;


//               int k = 0;


//               try{


//               for(k = 0 ;  k < total_cenas ;k++) {


//                     line = cenas_raw_lines[k];
                    

//                     switch(cenas_feitas.cenas_tipos[k]){
                    
//                       case 0: cenas_feitas.cenas_set[cenas_feitas.cenas_ids[k]] = new Cena_set(); Construir_sets(  cenas_feitas.cenas_set[cenas_feitas.cenas_ids[k]] , line , k ,jump_ids, jump_ids_cenas, ref jump_id_atual)  ; break;
//                       case 1: cenas_feitas.cenas_ic[cenas_feitas.cenas_ids[k]] = new Cena_ic(); Construir_ics(  cenas_feitas.cenas_ic[cenas_feitas.cenas_ids[k]] , line , k ,jump_ids, jump_ids_cenas, ref jump_id_atual)  ; break;
//                       case 2: cenas_feitas.cenas_text[cenas_feitas.cenas_ids[k]] = new Cena_text(); Construir_texts(  cenas_feitas.cenas_text[cenas_feitas.cenas_ids[k]] , line , k ,jump_ids, jump_ids_cenas, ref jump_id_atual)  ; break;
//                       case 3: cenas_feitas.cenas_mov[cenas_feitas.cenas_ids[k]] = new Cena_mov(); Construir_movs(  cenas_feitas.cenas_mov[cenas_feitas.cenas_ids[k]] , line , k ,jump_ids, jump_ids_cenas, ref jump_id_atual)  ; break;
//                       case 4: cenas_feitas.cenas_choice[cenas_feitas.cenas_ids[k]] = new Cena_choice(); Construir_choices(  cenas_feitas.cenas_choice[cenas_feitas.cenas_ids[k]] , line , k ,jump_ids, jump_ids_cenas, ref jump_id_atual)  ; break;
//                       case 5:  cenas_feitas.cenas_fn[cenas_feitas.cenas_ids[k]] = new Cena_fn(); Construir_fns(  cenas_feitas.cenas_fn[cenas_feitas.cenas_ids[k]] , line , k ,jump_ids, jump_ids_cenas, ref jump_id_atual)  ; break;
//                       case 6: cenas_feitas.cenas_audio[cenas_feitas.cenas_ids[k]] = new Cena_audio(); Construir_audios(  cenas_feitas.cenas_audio[cenas_feitas.cenas_ids[k]] , line , k ,jump_ids, jump_ids_cenas, ref jump_id_atual)  ; break;
//                       case 7: cenas_feitas.cenas_pointer[cenas_feitas.cenas_ids[k]] = new Cena_pointer(); Construir_poiters(  cenas_feitas.cenas_pointer[cenas_feitas.cenas_ids[k]] , line , k ,jump_ids, jump_ids_cenas, ref jump_id_atual)  ; break;
//                       case 8: cenas_feitas.cenas_end[cenas_feitas.cenas_ids[k]] = new Cena_end(); Construir_ends(  cenas_feitas.cenas_end[cenas_feitas.cenas_ids[k]] , line , k ,jump_ids, jump_ids_cenas, ref jump_id_atual)  ; break;


//                   }


//                 } 

//               } catch( Exception e){ 

//                     throw new ArgumentException ("problema na cena da linha: " + linhas_localizador_cenas[ k ] );

//               }



          
//               //foreach(   string LINE in cenas_feitas.cenas_set[0].chars ) Debug.Log( "char: " + LINE );



//               throw new ArgumentException("AAAAAAAAAAAAAAAAAAAAAAA");



//               cenas_feitas.jump_ids_cenas = jump_ids_cenas;
//               cenas_feitas.jump_ids = jump_ids;
//               cenas_feitas.linhas_localizador_cenas = linhas_localizador_cenas;


//               BLOCO_visual_novel.Pegar_instancia().screen_play_dados.choice_chaves = new string[cenas_feitas.cenas_choice.Length];
//               BLOCO_visual_novel.Pegar_instancia().screen_play_dados.choice_respostas = new string[cenas_feitas.cenas_choice.Length];






//               watch.Stop();
//               var elapsedMs = watch.ElapsedMilliseconds;

//               Debug.Log("tempo para construir cenas: " + elapsedMs + "ms");





//             return cenas_feitas;




//               int[] Pegar_linhas_localizador(string _texto_completo){

//                   int[] retorno = new int[1000]; 

//                   int cena_atual = 0;
//                   int linha_atual = 1;

//                   int numero_caracteres = _texto_completo.Length;
                  
//                   for( int index_char = 0 ; index_char < numero_caracteres ; index_char++     ){

//                         char caracter = _texto_completo[ index_char ];

//                         if(caracter == '[') {

//                             retorno [ cena_atual ] = linha_atual;
//                             cena_atual++;

//                         } 

//                         if( caracter == '\r' ){
                            
//                               index_char++;
//                               caracter = _texto_completo[ index_char ];

//                               if(caracter == '\n'){

//                                   linha_atual++;

//                               }

//                         }

//                   }

//                   return  retorno;

//               }




//             string Pegar_tipo( string linha ){

                    
//                     int index_inicial = 0;
//                     int index_final = 0;

//                     int numero_caracteres = linha.Length;
//                     int numero_caracteres_tipo = 0;

//                     int index = -1;

//                     while( index < numero_caracteres ){

//                           index++;

//                           if(linha[ index ] == '[') continue;
//                           if(linha[ index ] == ' ') continue;
//                           if(linha[ index ] == '\r') continue;
//                           if(linha[ index ] == '\n') continue;

                          
//                           index_inicial = index;
                  
//                           break;


//                     }


//                     while( index < numero_caracteres  ){

//                         index++;
//                         if( linha[ index ] == ' ' || linha [ index ] == ',' ) {

//                             index_final = index;
//                             break;
                            
//                         }
                         
//                     }


//                     numero_caracteres_tipo = index_final - index_inicial;

//                     char[] linha_char = new char[ numero_caracteres_tipo ];


//                     for(int i = 0;  i < numero_caracteres_tipo  ;  i++){

//                         linha_char[ i ] = linha[i + index_inicial];
                
//                     }

//                     string retorno = new string( linha_char );

//                     return retorno;



//               }







// }















//         public static Cenas Construir_por_compilado( Nome_screen_play _nome){

//               /*

//                   string path_nome = Visual_novel_paths.Pegar_nome_path_screen_play( _nome );


//                   if(Application.isEditor) { Garantir_compilado_existe( path_nome );}


//                   string[] screen_play_cenas = Resources.Load<TextAsset>( path ).Split("\r\n");
                  
//                   Cenas cenas_feitas = new Cenas();


//                         var watch = System.Diagnostics.Stopwatch.StartNew();


//                   int linhas_usadas_para_dados_internos = 0;// colocar depois


//                   int total_cenas = cenas_raw_lines.Length - linhas_usadas_para_dados_internos;

              
//                   cenas_feitas.cenas_ids = new int [ total_cenas ];
//                   cenas_feitas.cenas_tipos = new int [ total_cenas ];
                  
//                   string line;

//                   int[] quantidade_cenas = new int[9];

                  
//                   for ( int i = 0  ;   i<total_cenas   ;i++   ){

//                     line = cenas_raw_lines[i];

//                     char tipo_cena = line[0];

                    
                    
                  
//                     switch ( tipo_cena ){

//                       case '0' :    cenas_feitas.cenas_ids[i] = quantidade_cenas[0]  ; quantidade_cenas[0]++ ; cenas_feitas.cenas_tipos[i] = 0 ; break;
//                       case '1' :    cenas_feitas.cenas_ids[i] = quantidade_cenas[1]  ; quantidade_cenas[1]++ ; cenas_feitas.cenas_tipos[i] = 1 ; break;
//                       case '2' :    cenas_feitas.cenas_ids[i] = quantidade_cenas[2]  ; quantidade_cenas[2]++ ; cenas_feitas.cenas_tipos[i] = 2 ; break;
//                       case '3' :    cenas_feitas.cenas_ids[i] = quantidade_cenas[3]  ; quantidade_cenas[3]++ ; cenas_feitas.cenas_tipos[i] = 3 ; break;
//                       case '4' :    cenas_feitas.cenas_ids[i] = quantidade_cenas[4]  ; quantidade_cenas[4]++ ; cenas_feitas.cenas_tipos[i] = 4 ; break;
//                       case '5' :    cenas_feitas.cenas_ids[i] = quantidade_cenas[5]  ; quantidade_cenas[5]++ ; cenas_feitas.cenas_tipos[i] = 5 ; break;
//                       case '6' :    cenas_feitas.cenas_ids[i] = quantidade_cenas[6]  ; quantidade_cenas[6]++ ; cenas_feitas.cenas_tipos[i] = 6 ; break; 
//                       case '7' :    cenas_feitas.cenas_ids[i] = quantidade_cenas[7]  ; quantidade_cenas[7]++ ; cenas_feitas.cenas_tipos[i] = 7 ; break; 
//                       case '8' :    cenas_feitas.cenas_ids[i] = quantidade_cenas[8]  ; quantidade_cenas[8]++ ; cenas_feitas.cenas_tipos[i] = 8 ; break; 

//                       //case ' ' :   if(line.Trim() == ""){ pulo_por_espacos++;continue;} Debug.Log("AAAAAAAAAAAAAAA");break;
                      
//                       default :  Debug.Log("line: " + i);  foreach( char ch in line ){Debug.Log(ch);}  ; throw new ArgumentException("nao foi achado tipo scena: " + line[1] );

//                       } 

                      


//                       }

//                     cenas_feitas.cenas_set = new Cena_set [quantidade_cenas[0]];
//                     cenas_feitas.cenas_ic = new Cena_ic [quantidade_cenas[1]];
//                     cenas_feitas.cenas_text = new Cena_text [quantidade_cenas[2]];
//                     cenas_feitas.cenas_mov = new Cena_mov [quantidade_cenas[3]];
//                     cenas_feitas.cenas_choice = new Cena_choice [quantidade_cenas[4]];
//                     cenas_feitas.cenas_fn = new Cena_fn [quantidade_cenas[5]];
//                     cenas_feitas.cenas_audio = new Cena_audio [quantidade_cenas[6]];
//                     cenas_feitas.cenas_pointer = new Cena_pointer [quantidade_cenas[7]];
//                     cenas_feitas.cenas_end = new Cena_end [quantidade_cenas[8]];

                    
//                   String[] jump_ids = new string[100];
//                   int[]  jump_ids_cenas = new int[100];
                  
//                     int jump_id_atual = 0;





//                   for(int k = 0 ;  k < total_cenas ;k++) {


//                         line = cenas_raw_lines[k];
                        

//                         switch(cenas_feitas.cenas_tipos[k]){
                        
//                           case 0: cenas_feitas.cenas_set[cenas_feitas.cenas_ids[k]] = new Cena_set(); Construir_sets(  cenas_feitas.cenas_set[cenas_feitas.cenas_ids[k]] , line , k ,jump_ids, jump_ids_cenas, ref jump_id_atual)  ; break;
//                           case 1: cenas_feitas.cenas_ic[cenas_feitas.cenas_ids[k]] = new Cena_ic(); Construir_ics(  cenas_feitas.cenas_ic[cenas_feitas.cenas_ids[k]] , line , k ,jump_ids, jump_ids_cenas, ref jump_id_atual)  ; break;
//                           case 2: cenas_feitas.cenas_text[cenas_feitas.cenas_ids[k]] = new Cena_text(); Construir_texts(  cenas_feitas.cenas_text[cenas_feitas.cenas_ids[k]] , line , k ,jump_ids, jump_ids_cenas, ref jump_id_atual)  ; break;
//                           case 3: cenas_feitas.cenas_mov[cenas_feitas.cenas_ids[k]] = new Cena_mov(); Construir_movs(  cenas_feitas.cenas_mov[cenas_feitas.cenas_ids[k]] , line , k ,jump_ids, jump_ids_cenas, ref jump_id_atual)  ; break;
//                           case 4: cenas_feitas.cenas_choice[cenas_feitas.cenas_ids[k]] = new Cena_choice(); Construir_choices(  cenas_feitas.cenas_choice[cenas_feitas.cenas_ids[k]] , line , k ,jump_ids, jump_ids_cenas, ref jump_id_atual)  ; break;
//                           case 5:  cenas_feitas.cenas_fn[cenas_feitas.cenas_ids[k]] = new Cena_fn(); Construir_fns(  cenas_feitas.cenas_fn[cenas_feitas.cenas_ids[k]] , line , k ,jump_ids, jump_ids_cenas, ref jump_id_atual)  ; break;
//                           case 6: cenas_feitas.cenas_audio[cenas_feitas.cenas_ids[k]] = new Cena_audio(); Construir_audios(  cenas_feitas.cenas_audio[cenas_feitas.cenas_ids[k]] , line , k ,jump_ids, jump_ids_cenas, ref jump_id_atual)  ; break;
//                           case 7: cenas_feitas.cenas_pointer[cenas_feitas.cenas_ids[k]] = new Cena_pointer(); Construir_poiters(  cenas_feitas.cenas_pointer[cenas_feitas.cenas_ids[k]] , line , k ,jump_ids, jump_ids_cenas, ref jump_id_atual)  ; break;
//                           case 8: cenas_feitas.cenas_end[cenas_feitas.cenas_ids[k]] = new Cena_end(); Construir_ends(  cenas_feitas.cenas_end[cenas_feitas.cenas_ids[k]] , line , k ,jump_ids, jump_ids_cenas, ref jump_id_atual)  ; break;


//                       }


//                     }  







//                   cenas_feitas.jump_ids_cenas = jump_ids_cenas;
//                   cenas_feitas.jump_ids = jump_ids;


//                   BLOCO_visual_novel.Pegar_instancia().screen_play_dados.choice_chaves = new string[cenas_feitas.cenas_choice.Length];
//                   BLOCO_visual_novel.Pegar_instancia().screen_play_dados.choice_respostas = new string[cenas_feitas.cenas_choice.Length];






//                   watch.Stop();
//                   var elapsedMs = watch.ElapsedMilliseconds;

//                   Debug.Log("tempo para construir cenas: " + elapsedMs + "ms");





//                 return cenas_feitas;

//                 */

              

//               return null;


//         ////

//         }












              
//    public static void Construir_sets( Cena_set _cena , string _line , int _id , string[] _jump_ids, int[] _jump_ids_cenas , ref int _jump_id_atual){
    


//         _line = _line.Trim();

//         string[] itens =  _line.Split("\r\n");

//         string auto_str = itens[1].Split(":")[1].Trim();

//         int numero_itens_sem_o_primeiro = itens.Length - 1;

//         int numero_personagens = 0;

//         int i = 0;

//         for(  i = 0 ;  i < numero_itens_sem_o_primeiro  ; i++   ){


//                 if(   itens[ i ].Length != 0  ){ numero_personagens++;}
                

//         }

//         string[] personagens_nomes = new string[ numero_personagens ];
//         string[] personagens_nomes_display = new string[ numero_personagens ];

        
//         for(  i = 0 ; i < numero_itens_sem_o_primeiro  ; i++   ){


//                 if(   itens[ i ].Length != 0  ){

//                     string[] personagem_E_nome_display = itens[ i ].Split(":");
//                     string personagem = personagem_E_nome_display[0].Trim();
//                     personagens_nomes[ i ] = personagem;

//                     bool tem_nome_display = personagem_E_nome_display.Length > 1;

//                     if( tem_nome_display ){ 

//                         string nome_display = personagem_E_nome_display[1].Trim();
//                         personagens_nomes_display[i] = nome_display;
                        
//                     }
                    
//                 }
                

//         }

//         _cena.auto  = Convert.ToBoolean( auto_str );    
//         _cena.personagens_nomes = personagens_nomes;
//         _cena.personagens_nomes_display = personagens_nomes_display;


//         return;

// ///    
    
//   }


//    public static void Construir_ics( Cena_ic _cena , string _line , int _id , string[] _jump_ids, int[] _jump_ids_cenas  , ref int _jump_id_atual){

//         string[] itens =  _line.Split(",");
//         _cena.auto  = Convert.ToBoolean(itens[1].Trim());
//         _cena.chars_image_id = new string[  itens.Length - 2  ];

//         for(int character = 0 ;  character<   itens.Length - 2  ; character++ ){  

//              _cena.chars_image_id[character] = itens[character + 2] .Trim();

//         }

//         return;
    
//    }




//    public static void  Construir_texts( Cena_text _cena , string _line , int _id , string[] _jump_ids, int[] _jump_ids_cenas, ref int _jump_id_atual){


//         string[] itens =  _line.Split("," , 5);

//         _cena.auto  = Convert.ToBoolean(itens[1].Trim());
//         _cena.tipo_texto = Convert.ToInt32( itens[2].Trim());

//         _cena.personagem =  itens[3].Trim();
//         _cena.texto      =  itens[4].Trim();

//         return;
    
//    }




//    public static void Construir_movs( Cena_mov _cena , string _line , int _id , string[] _jump_ids, int[] _jump_ids_cenas, ref int _jump_id_atual){

  


//     string[] itens =  _line.Split(",");
//     _cena.auto  = Convert.ToBoolean(itens[1]);
    
    
     


//     if(  itens[2].Trim() ==  "xy" ){

//         int i = 3, k = 4;

//         _cena.x_position = new float[ (int) (itens.Length-3)/2  ];
//         _cena.y_position = new float[ (int) (itens.Length-3)/2 ];

//         string novo_valor;
//         float novo_ponto;

//         while( i  <   itens.Length  ){  
           
//           novo_valor = itens[i].Trim();
//           novo_ponto = novo_valor == "p"?  -1 :  Convert.ToSingle( novo_valor );
          
          
//           _cena.x_position[ (i-3 )/2] = novo_ponto;
           


//            novo_valor = itens[k].Trim();
//            novo_ponto = novo_valor == "p"?  -1 :  Convert.ToSingle( novo_valor );
            
//            _cena.y_position[ (i-3 )/2] = novo_ponto  ;

//            i = i + 2;
//            k = k + 2; 
      
//         }

//         return;
//      }

    
//     _cena.x_position = new float[ itens.Length-2  ];
//     _cena.y_position = new float[ itens.Length-2  ];

//     for(int j = 2 ; j <   itens.Length  ; j++ ){ 

//       if(itens[j].Trim() == "p") {

//         _cena.x_position[j-2] = -1;

//         _cena.y_position[j-2] = -1;


//         continue;
//       }


//      _cena.x_position[j-2] = Convert.ToSingle(itens[j]);

//      _cena.y_position[j-2] = -1;

     
      
//        }
    
//     return;
    
//    }








//    public static  void Construir_choices( Cena_choice _cena , string _line , int _id, string[] _jump_ids, int[] _jump_ids_cenas, ref int _jump_id_atual){





//       string[] itens =  _line.Split(",",3);
//      _cena.auto  = Convert.ToBoolean(itens[1].Trim());
     



     




//      string[]  perguntas_respostas = itens[2].Split("\r\n");

//      int k = 0;

//      for(  int i = 0  ;  i < perguntas_respostas.Length   ; i++  ){

//       perguntas_respostas[k] = perguntas_respostas[i].Trim();

//       if(perguntas_respostas[k] != "") k ++;

            

//        }
        
//          _cena.pergunta = perguntas_respostas[0];

//          _cena.opcoes = new String[k-1];



//         for(int p = 0;  p<k-1 ;p++){

//            _cena.opcoes[p] = perguntas_respostas[p+1];

//         }

        

    
   
       
//   //      int d_n = 1;
//   //      int d_l = 0;
//   //      if(perguntas_respostas[0] == "") d_n = 2;

//   //      if(perguntas_respostas[perguntas_respostas.Length-1] == "")  { d_l = 1; }
     
//   //  //  0 =>  "\r\n" 

//   //     _cena.pergunta = perguntas_respostas[d_n-1].Trim();
      
        

//   //      = new string[perguntas_respostas.Length - d_n - d_l];


//   //      int d_f = 0;
//   //     for(int i = 0;   i   <_cena.opcoes.Length  ;i++){
        
//   //          _cena.opcoes[i] = perguntas_respostas[i+d_n].Trim();

//   //     }

   

//   // _cena.opcoes = new string[perguntas_respostas.Length - d_n - d_l];



//   //     for(int i = 0;   i   <_cena.opcoes.Length  ;i++){
        
//   //          _cena.opcoes[i] = perguntas_respostas[i+d_n].Trim();

//   //     }



    
//     return;
    
//    }










   
//    public static  void Construir_fns( Cena_fn _cena , string _line , int _id , string[] _jump_ids, int[] _jump_ids_cenas, ref int _jump_id_atual){


//             bool modelo_linha_unica = _line.Split("\r\n").Length == 1 ;

//             if( modelo_linha_unica ){

//                   string[] itens =  _line.Split(",",4);
                  
//                     _cena.auto  = Convert.ToBoolean(itens[1].Trim());
                  
//                   _cena.fn_name = itens[2].Trim(); 

//                   if(  itens.Length < 4 ) {  _cena.args = new string[0];  return;}


//                     if(Is_special(_cena.fn_name)) {
                      
//                       _cena.args = new string[1]{  itens[3] };
                      

//                       return;
                      
//                     }

                    
//                     itens = itens[3].Split(",");
//                     _cena.args = new string[itens.Length];  
                  
//                     for(int m = 0 ; m<_cena.args.Length   ;m++){
                    
//                       _cena.args[m] = itens[m].Trim();
                      
//                       }
                    
                  
                  
                  
//                   return;






//             }










//         //     parse vai ser na fn
//             bool Is_special(string _fn_name){
                  
//                   switch(_fn_name){

//                     case "jump": return true;
//                     case "iniciar_plataforma": return true;
//                     case "mudar_cor_texto_persoangens": return true;
//                     case "trocar_nomes_display": return true;
//                     //case "iniciar_animacao": return true;

//                   }
//                   return false;

//             }
    
//     }




//  public static  void Construir_poiters( Cena_pointer _cena , string _line , int _id , string[] _jump_ids, int[] _jump_ids_cenas, ref int _jump_id_atual){

//    _cena.id =  _line.Split(",")[1].Trim()  ;

//      _jump_ids[_jump_id_atual] = _cena.id ;

//       _jump_ids_cenas[_jump_id_atual] = _id ;

//       _jump_id_atual++;
    
//     return;
    
//    }



//    public static void Construir_audios( Cena_audio _cena , string _line , int _id , string[] _jump_ids, int[] _jump_ids_cenas, ref int _jump_id_atual){


//         ///    [audio, true, tipo(music_1, music_2, sfx... etc2) , path, transicao up, transicao_down, ]

//         //                           op              
//         // [audio, true, path , transicao_duracao, , modificador_volume]

//         //                       IF transicao_duracao == 0 => nao tem transicao

//      string[] itens =  _line.Split(",");

     

//      _cena.auto = Convert.ToBoolean( itens[1].Trim() );
//      _cena.tipo =    itens[2].Trim();
     
//      _cena.path = itens[3].Trim();

//      if(itens.Length > 4 ){



//         _cena.tempo_transicao_tirar_ms =  Convert.ToSingle(itens[4].Trim());

//      }

//      if(itens.Length > 5 ){


//           _cena.tempo_transicao_colocar_ms =  Convert.ToSingle(itens[5].Trim());

//      } else {

//           _cena.tempo_transicao_colocar_ms = _cena.tempo_transicao_tirar_ms;

//      }

//      if(itens.Length > 6){


//       _cena.modificador_volume = Convert.ToSingle(itens[6].Trim()) / 100f;

//      }

    
//     return;
    
//    }





//    public static  void Construir_ends( Cena_end _cena , string _line , int _id , string[] _jump_ids, int[] _jump_ids_cenas, ref int _jump_id_atual){

//         /// [end, script_cenas , script_controlador ,  path]

//         /*

//             seria interessante colocar no end como string, fazer um dic => numero para rodar no editor e na compilacao trocar para

//         */


//         string texto_ajustado = Regex.Replace( _line , @"(\r\n)+", "\r\n").Trim();
//         string[] itens = texto_ajustado.Trim().Split("\r\n");

      

//         string script_controlador_str   = itens[1].Trim().Split(":")[1].Trim();
//         string script_cenas_str         = itens[2].Trim().Split(":")[1].Trim();
//         Nome_screen_play nome_proxima_screen_play    =   (Nome_screen_play) Enum.Parse(  typeof(  Nome_screen_play  ),    ( itens[3].Trim().Split(":")[1].Trim())     )  ;
//         string tem_transicao_str        = itens[4].Trim().Split(":")[1].Trim();


//         int  script_controlador = Convert.ToInt32(script_controlador_str);
//         int script_cenas = Convert.ToInt32(script_cenas_str);
//         bool tem_transicao = Convert.ToBoolean(tem_transicao_str);

//         _cena.tem_transicao = tem_transicao;
//         _cena.script_controlador = script_controlador;
//         _cena.script_cenas = script_cenas;
//         _cena.nome_proxima_screen_play = nome_proxima_screen_play;

            
//         return;
    
//    }
   
   


// }
