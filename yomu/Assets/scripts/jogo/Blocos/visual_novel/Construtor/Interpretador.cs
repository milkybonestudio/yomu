
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

/*
sempreque passar int para char tem que  somar 48. nos caracteres anteriores tem caracteres de quebra de linha. nao é bom
*/



public static class Interpretador {


        public static Screen_play Construir_screen_play( Nome_screen_play _nome ){


                System.Diagnostics.Stopwatch timePerParse = System.Diagnostics.Stopwatch.StartNew();

                Garantir_backup( _nome ) ;

                string[] cenas_compiladas  =  Compilar( _nome );

                Salvar_texto_compilado( _nome , cenas_compiladas );

                /// mudar depois 


                Screen_play screen_play = new Screen_play( cenas_compiladas );

                timePerParse.Stop();
                long ticksThisTime_2 = timePerParse.ElapsedMilliseconds;
                Debug.Log("tempo para construir screen play: " + ticksThisTime_2);

                return screen_play;


        }



        public static Screen_play Pegar_screen_play( Nome_screen_play _nome ){

                #if UNITY_EDITOR

                        return Construir_screen_play( _nome );

                #endif



                string nome_path = Visual_novel_paths.Pegar_nome_path_screen_play( _nome );
                string path_completo =  "files/cenas/" +  nome_path;

                TextAsset text_asset = Resources.Load<TextAsset>( path_completo );

                if( text_asset == null )
                        { throw new ArgumentException("nao foi achado screen_play no path: " + path_completo ); }

                string[] cenas_compiladas = text_asset.text.Split("\r\n");

                Screen_play screen_play_retorno = new Screen_play( cenas_compiladas );

                return screen_play_retorno;


        }


    public static void Garantir_backup( Nome_screen_play _nome ){



                string path_nome       =     Visual_novel_paths.Pegar_nome_path_screen_play( _nome );
                string path_backup     =     Visual_novel_paths.Pegar_path_backup_versoes_dir( path_nome ); 
                string path_file_producao = Visual_novel_paths.Pegar_path_file_producao( path_nome );

                string versao = Pegar_versao_file( path_file_producao );


                if(  Folder_backup_nao_existe_RESOLVER ( versao  , path_backup  , path_file_producao )  ) return;
                if(  Folder_backup_esta_vazio_RESOLVER ( versao  , path_backup  , path_file_producao )  ) return;
                if(  Folder_backup_ja_atualizado_RESOLVER ( versao  , path_backup  , path_file_producao )  ) return;

                Escrever_file_backup( versao  , path_backup  , path_file_producao );

                return;







                bool Folder_backup_nao_existe_RESOLVER( string versao  , string path_backup  , string path_file_producao   ){

                    bool folder_backup_folder_versoes_nao_encontrado = !System.IO.Directory.Exists( path_backup );
                    if( folder_backup_folder_versoes_nao_encontrado ) {
                            System.IO.Directory.CreateDirectory( path_backup );
                            Escrever_file_backup( versao  , path_backup  , path_file_producao );
                            return true;
                    }
                    return false;

                }
                string Pegar_versao_file( string  _path_file_producao ){


                        System.IO.StreamReader reader = new System.IO.StreamReader( _path_file_producao );
                        bool primeira_chave_foi_achada = false;
                        string versao = "";
                        for( int i = 0 ; i < 100 ;i++ ){


                                string line = reader.ReadLine().Trim();

                                if( line == "" ) { continue ; }

                                if( line[0] == '<' ){
                                        if( primeira_chave_foi_achada ){ break;}
                                        primeira_chave_foi_achada = true;
                                }


                                if(line.Length == 0) {continue;} 

                                string[] chave_E_valor = line.Split(":");

                                string chave = chave_E_valor[0].Trim();

                                string valor = "";

                                if( chave_E_valor.Length > 1 ) {valor = chave_E_valor[1].Trim();}

                                if( chave == "versao" ){ versao = valor;}

                        }
                        return versao;
                }
                bool Folder_backup_esta_vazio_RESOLVER( string versao  , string path_backup  , string path_file_producao   ){

                        int total_files = System.IO.Directory.GetFiles( path_backup ).Length;
                        bool folder_backup_folder_versoes_esta_vazio = ( total_files == 0 );
                        if( folder_backup_folder_versoes_esta_vazio ){
                                Escrever_file_backup( versao  , path_backup  , path_file_producao );
                                return true;
                        }
                        return false;
                }
                bool Folder_backup_ja_atualizado_RESOLVER ( string versao  , string path_backup  , string path_file_producao   ){

                        string[] files = System.IO.Directory.GetFiles( path_backup );
                        string nome_final = "ver_" + versao;
                        int total_files = files.Length;
                        for(  int index_screen_play_backup = 0 ; index_screen_play_backup < total_files   ;index_screen_play_backup++ ){
                                string nome_path = files[ index_screen_play_backup ];
                                bool nome_igual = (nome_final == Visual_novel_paths.Pegar_nome_do_file_por_path( nome_path ));
                                if( nome_igual ) {return true;}
                        }
                        return false;
                }
                void Escrever_file_backup( string _versao , string _path_backup_folder_versoes,  string _path_file_producao  ){
                        string producao_copia = System.IO.File.ReadAllText( path_file_producao );
                        Debug.Log("_versao final: "  +  _versao);
                        string novo_file_path = _path_backup_folder_versoes + "\\ver_" + _versao;
                        System.IO.File.Copy(  _path_file_producao , novo_file_path  );
                }





            
////
///
    }



// 





    public static string[] Compilar( Nome_screen_play _nome ){


        //    var watch = System.Diagnostics.Stopwatch.StartNew();


            string texto_raw = Pegar_texto_raw ( _nome );

            //int[] linhas_localizador_cenas = Pegar_linhas_localizador( texto_raw );

            string[] cenas_lines = Pegar_lines( texto_raw );
            
            int numero_cenas = cenas_lines.Length;



            Interpretador_data interpretador_data = new Interpretador_data( texto_raw );
        

            string line ;
            string tipo ;

   
            string[] cenas_pre = new string[ numero_cenas ];

                int cena = 0;

                


            
        //     try  {  


                        // pega pointers 

                        for ( cena = 0 ;   cena < numero_cenas   ; cena++ ){

                                line = cenas_lines[ cena ];
                                tipo = Manipulador_texto.Pegar_tipo( line );
                                

                                if( tipo == "pointer"  ){


                                        cenas_pre[ cena ]  = Compilar_pointer (  line , cena,  interpretador_data ); 
                                        continue;

                                        string pointer_id = line.Split(":")[1].Split("]")[0].Trim();
                                        interpretador_data.Adicionar_pointer( pointer_id );
                                        continue;

                                }

                                // choice pode ser compilado antes, ele sempre so retorna 1 cena 

                                if( tipo == "choice"  ){



                                        cenas_pre[ cena ]  = Compilar_choice (  line , cena,  interpretador_data ); 

                                        continue;

                                }

                                if( tipo == "set" ){

                                        //pega os personagens primeiro
            

                                        
                                        interpretador_data.Receber_personagens_set( line );

                                        

                                        continue;


                                }





                        }



                char auto = 't' ;

                        // set compila por ultimo
                    for ( cena = 1 ;   cena < numero_cenas   ; cena++ ){


                            interpretador_data.cena_em_analise = cena;

                            line = cenas_lines[ cena ];
                            tipo = Manipulador_texto.Pegar_tipo( line );

                            //  pode voltar [cena compilada 1 parte 1]\r\n[cena compilada 1 parte 2 ]

              
                        switch ( tipo ){

                                //   case "set" :     cenas_pre[ cena ]  = Compilar_set (  line , cena,  interpretador_data ) ; break;


                                case "ic" :      cenas_pre[ cena ]  = Compilar_ic (  line , cena,  interpretador_data ) ; break;
                                case "text" :    cenas_pre[ cena ]  = Compilar_text (  line , cena,  interpretador_data ) ; break;
                                case "mov" :     cenas_pre[ cena ]  = Compilar_mov (  line , cena,  interpretador_data ) ; break;
                                case "audio" :   cenas_pre[ cena ]  = Compilar_audio (  line , cena,  interpretador_data ) ; break; 
                                


                                case "fn" :      cenas_pre[ cena ]  = Compilar_fn (  line , cena,  interpretador_data ) ; break;
                                case "choice":  /* cenas_pre[ cena ]  = Compilar_choice (  line , cena,  interpretador_data ); */  break; // já foi em cima
                                case "pointer": /* cenas_pre[ cena ]  = Compilar_pointer (  line , cena,  interpretador_data )*/ ; break; 
                                case "jump" :    cenas_pre[ cena ]  = Compilar_jump (  line , cena,  interpretador_data ) ; break; 
                                case "end" :     cenas_pre[ cena ]  = Compilar_end (  line , cena,  interpretador_data ) ; break; 



                                default : throw new ArgumentException("nao foi achado tipo cena na linha: " + interpretador_data.linhas_localizador_cenas[ cena ] + ". veio: " + tipo );

                        } 

        
                        if(  interpretador_data.bloquear_set_ja_foi_ativado ) { continue ; }

                        if( interpretador_data.auto_atual_para_set == 't' ) { continue ; }

                        interpretador_data.bloquear_set_ja_foi_ativado = true ;

                        cenas_pre[ cena ] = (  cenas_pre[ cena ] + "\r\n" + Fn_compilador.CRIAR_sem_variaveis(  Nome_fn.bloquear_voltar_cenas , new string[]{"fn:t:false"} , interpretador_data ) );
                        
                        continue ;


                    }

                        // sempre por ultimo

                    cenas_pre[ 0 ]  = Compilar_set (  cenas_lines[ 0 ] , 0,  interpretador_data );


        //     }  catch( Exception err ){ 

        //         Debug.LogError( "problema na cena da linha: " + interpretador_data.linhas_localizador_cenas[ cena ] );

        //         throw err  ;

        //     }





            string[] cenas_finais =  Pegar_cenas_strings_finais( cenas_pre , interpretador_data);


            return cenas_finais;






}


        public static void Salvar_texto_compilado( Nome_screen_play _nome , string[] _texto_compilado ){


                string nome_screen_play =  Visual_novel_paths.Pegar_nome_path_screen_play( _nome ) ;
                string path_para_salvar =  Visual_novel_paths.Pegar_path_file_compilado( nome_screen_play ) ;

                Debug.Log( path_para_salvar );

              //  Geral.Salvar_string( _texto_compilado );

                
                string dir_nome = System.IO.Path.GetDirectoryName( path_para_salvar );

                if( !System.IO.Directory.Exists( dir_nome ) ){

                        System.IO.Directory.CreateDirectory( dir_nome );

                }

                if(  System.IO.File.Exists( path_para_salvar ) ) {

                        System.IO.File.Delete( path_para_salvar );

                }

                System.IO.File.WriteAllLines( path_para_salvar , _texto_compilado );

                return;
                
        }




        public static string Pegar_texto_raw ( Nome_screen_play _nome ){

                                
                string nome_path = Visual_novel_paths.Pegar_nome_path_screen_play( _nome );
                string path_producao = Visual_novel_paths.Pegar_path_file_producao( nome_path );

                Verificar_se_producao_existe( nome_path );

                string texto_raw = System.IO.File.ReadAllText( path_producao );
                return texto_raw;


        }


        public static void Verificar_se_producao_existe( string _nome_path ){

                

        }


        public static  string[] Pegar_lines( string _texto_raw  ){



                // for( int i = 0 ;  i < _texto_raw.Length ; i++ ){
                        
                //         if( _texto_raw[ i ] == '}' ) throw new ArgumentException("veio }");
                //         if( _texto_raw[ i ] == '{' ) throw new ArgumentException("veio {");

                // }

                string texto_sem_parte_para_ignorar = _texto_raw.Split("//IGNORAR")[0];

                string texto_somente_com_cenas = Regex.Replace( texto_sem_parte_para_ignorar, @"\](.|\s)*?\[", "]\r\n[");
                string[] cenas_lines = texto_somente_com_cenas.Split("]\r\n[");
                Ajustar_strings( cenas_lines );

                return cenas_lines;

        }

        public static  void Ajustar_strings( string[] _cenas_lines ){
                
                // já tira a versao tambem
                _cenas_lines[0] = _cenas_lines[0].Split("[")[1].Trim();
                _cenas_lines[_cenas_lines.Length-1] = _cenas_lines[_cenas_lines.Length-1].Trim();
                _cenas_lines[_cenas_lines.Length-1] = _cenas_lines[_cenas_lines.Length-1].Remove(     _cenas_lines[_cenas_lines.Length-1].Length -1    ) ;
                return;

        }










        public static string[] Pegar_cenas_strings_finais( string[] _cenas_pre , Interpretador_data _interpretador_data){

                // pega quantas cenas realment eexistem 

                    int numero_cenas_pre = _cenas_pre.Length;
                    
                    int[] numero_cenas_adicionais_por_cena_pre = new int[ numero_cenas_pre ];

                    
                    int numero_final_de_cenas = numero_cenas_pre;


                    // talvez esteja errado, quando tentei passar o _interpretador_data. auto


                    for(  int linha_index = 0 ; linha_index < numero_cenas_pre ; linha_index++  ){

                                string linha_em_analise = _cenas_pre[ linha_index ];

                                if(linha_em_analise == null) {

                                        numero_final_de_cenas--;
                                        numero_cenas_adicionais_por_cena_pre[ linha_index ] = -1;
                                        continue;
                                        
                                };

                                
                                int numero_letras = linha_em_analise.Length;                        

                                for( int letra_index = 0; letra_index < numero_letras ;letra_index++  ){

                                        char letra_em_analise = linha_em_analise[ letra_index ];

                                        if( letra_em_analise == '\r' ) {

                                                        numero_final_de_cenas++;
                                                        numero_cenas_adicionais_por_cena_pre[ linha_index ]++;


                                                        // so diminui
                                                        while( letra_index < numero_letras ){

                                                                        letra_index += 2;

                                                                        if( letra_index == numero_letras ) {

                                                                                        numero_final_de_cenas--;
                                                                                        numero_cenas_adicionais_por_cena_pre[ linha_index ]--;
                                                                                        break;

                                                                        }
                                                                        letra_em_analise = linha_em_analise[ letra_index ];

                                                                        if( letra_em_analise == '\r'){

                                                                                        numero_final_de_cenas--;
                                                                                         numero_cenas_adicionais_por_cena_pre[ linha_index ]--;

                                                                        } else { 

                                                                                        break;
                                                                        }

                                                        }

                                                        continue;

                                        }

                                        continue;

                                }

                    }


                string[] cenas_finais = new string[ numero_final_de_cenas ];


                int index_cenas_finais = 0;
                    

                
                for(  int index_cenas_pre = 0   ;   index_cenas_pre  < numero_cenas_pre  ; index_cenas_pre++  ){


                                string cena = _cenas_pre [ index_cenas_pre ];


                                if( numero_cenas_adicionais_por_cena_pre[ index_cenas_pre ] == -1 ){

                                        continue;

                                } else 
                                
                                if( numero_cenas_adicionais_por_cena_pre[ index_cenas_pre ] == 0 ){

                                        string[] nova_cena = cena.Split("\r\n");

                                        for( int cena_id = 0 ; cena_id < nova_cena.Length ; cena_id++ ){

                                                if( nova_cena[ cena_id ] == "" ) { continue; }
                                                cenas_finais[ index_cenas_finais ] = nova_cena[ cena_id ];
                                                index_cenas_finais++;
                                                break;

                                        }

                                        continue;

                                }

                                // tem mais de 1


                                int numero_cenas_adicionais = numero_cenas_adicionais_por_cena_pre[ index_cenas_pre ]; 
                                
                                string[] novas_cenas = cena.Split("\r\n");
                                

                                for( int possivel_cena = 0 ; possivel_cena < novas_cenas.Length ; possivel_cena++ ){

                                        if( novas_cenas [ possivel_cena ] == "" ) { continue; }

                                        cenas_finais[ index_cenas_finais  ]  = novas_cenas [ possivel_cena ];
                                        index_cenas_finais++;

                                        continue;

                                }

                                continue;

                    }





                    // Ajustar_pointer_ids();

                    char pointer_char_id = ( char ) ( ( int ) Tipo_cena.pointer + 48 );




                    for( int cena = 0 ;  cena < numero_final_de_cenas ; cena++ ){


                                if( cenas_finais[ cena ] [ 0 ] == pointer_char_id ){
                                        
                                        int id = ( ( int ) cenas_finais[ cena ][ 2 ] - 48 ) ;

                                        _interpretador_data.pointer_id_cena_index_arr[ id ] = cena;

                                        string jump_nome = _interpretador_data.pointer_id_str[id ];

                                }


                    }


                    string interpretador_data_str = Pegar_interpretador_str( _interpretador_data );

                    cenas_finais[ 0 ]  = interpretador_data_str;

                    return cenas_finais;


            }
















        public static  char Pegar_char( Tipo_cena _tipo ){


                int tipo_int = ( int ) _tipo + 48; // 48 => '0'
                char tipo_char = (char) tipo_int;
                return tipo_char;

            
        }













    







        public static string Compilar_ic (  string _line , int _numero_cena , Interpretador_data _interpretador_data  ){


        
                
                // tem que verificar se pode adicionar imagem em _interpretador_data.interpretador_data.auto_atual_para_set no fn_compilador deu problema

                //   0t


                string[] linhas_itens = Manipulador_texto.Trim_linha( _line );

                
                char tipo = (char) ( (int) Tipo_cena.ic + 48 );

                

                char auto = linhas_itens[ 0 ].Split(":")[1].Trim()[0];

                _interpretador_data.auto_atual_para_set = auto;

                Manipulador_texto.Checar_auto( auto );


                int numero_personagens = linhas_itens.Length - 1;

                char[] retorno_arr = new char[  numero_personagens * 2 + 2 ];

                retorno_arr[ 0 ] = tipo;
                retorno_arr[ 1 ] = auto;


                for( int personagem_index = 0 ;  personagem_index < numero_personagens  ; personagem_index++ ){

                        string[] nome_E_path = linhas_itens[ personagem_index + 1 ].Split(":");

                        string nome = nome_E_path[0].Trim();
                        string path_imagem  =  nome_E_path[1].Trim();

                        if( path_imagem == "nada" ||  path_imagem == "" ) path_imagem = "0"; // para ignorar




                        int personagem_id = _interpretador_data.Pegar_index_personagem( nome );
                        int index_path = _interpretador_data.Pegar_index_imagem_E_adicionar( path_imagem , personagem_id);

                
                        char personagem_id_char =   ( char ) ( personagem_id + 48 );
                        char path_char = (char) ( index_path + 48 );

                        retorno_arr[ (personagem_index * 2 ) + 2  ] = personagem_id_char;
                        retorno_arr[ (personagem_index * 2 ) + 2 + 1  ] = path_char;

                }


                return new string( retorno_arr );

                
        }













        public static string Compilar_mov (  string _line , int _numero_cena , Interpretador_data _interpretador_data   ){


        
                string[] linhas_itens = Manipulador_texto.Trim_linha( _line );


                char tipo = (char) ((int) Tipo_cena.mov + 48 );

                char auto_cena = linhas_itens[ 0 ].Split(":")[1].Trim()[0];
                _interpretador_data.auto_atual_para_set = auto_cena ; 

                Manipulador_texto.Checar_auto( auto_cena );



                int numero_personagens = linhas_itens.Length - 1;

               


                bool tem_mov_1d = false;
                bool tem_mov_2d = false;

                // +1 => sinal
                
                char[] posicoes_1d = new char[ numero_personagens * 3 ];
                char[] posicoes_2d = new char[ numero_personagens * 5 ];

                

                for(int k = 0 ; k < numero_personagens ; k++){

                        posicoes_1d[ ( k * 3 )  ] = ( char ) 47  ; // => -1 no valor absoluto
                        posicoes_1d[ ( k * 3 )  + 1 ] = ( char ) 47  ; // => -1 no valor absoluto
                        posicoes_1d[ ( k * 3 )  + 2 ] = ( char ) 47  ; // => -1 no valor absoluto

                        posicoes_2d[ (4 * k)  ] = ( char ) 47 ;
                        posicoes_2d[ (4 * k) + 1  ] = ( char ) 47 ;
                        posicoes_2d[ (4 * k) + 2  ] = ( char ) 47 ;
                        posicoes_2d[ (4 * k) + 3  ] = ( char ) 47 ;


                }


                       
           
                
                string[] nome_E_posicao = null;
                string nome = null;
                string posicao = null;

                string[] posicao_componentes = null;

                
                int posicao_X_int = 0;
                int posicao_Y_int = 0;

                char posicao_X = '\u0030';
                char posicao_Y = '\u0030';

                char sign = '\u0030';



                int numero_personagens_1d = 0;
                int numero_personagens_2d = 0;
                int index;


                // '\u0000' => nada 



                for (  index = 0 ; index < numero_personagens ; index++ ){


                        nome_E_posicao = linhas_itens [ index + 1 ].Split(":");

                        nome = nome_E_posicao[0].Trim();

                        int index_personagem = _interpretador_data.Pegar_index_personagem( nome );

                        if( nome_E_posicao.Length == 1 ){ continue;}


                        posicao  =  nome_E_posicao[1].Trim();

                        if( posicao == "nada" ) continue;

                       



                       posicao_componentes = posicao.Split(",");

                       bool IS_2D = ( posicao_componentes.Length > 1 );

                       if( IS_2D ){

                                numero_personagens_2d++;
                                //if ( index_personagem > numero_personagens_2d ) numero_personagens_2d = index_personagem;

                                tem_mov_2d = true;

                                posicao_X_int = Convert.ToInt32 (posicao_componentes[ 0 ].Trim());
                                posicao_Y_int = Convert.ToInt32 (posicao_componentes[ 1 ].Trim());

                                if( posicao_X_int > 0 ){

                                        if( posicao_Y_int > 0 ){
                                                sign = (char) 48;
                                        } else {

                                                posicao_Y_int *= -1;
                                                sign = ( char ) 50; 
                                        }

                                } else {

                                        posicao_X_int *= -1;

                                        if( posicao_Y_int > 0 ){

                                                // x- y+
                                                sign  = (char) 51;

                                        } else {

                                                posicao_Y_int *= -1;
                                                sign  = (char) 49;
                                        }

                                }

    

                                posicao_X =  ( char ) ( posicao_X_int + 48) ;
                                posicao_Y =  ( char ) ( posicao_Y_int + 48) ;

                                


                                posicoes_2d[ (index * 4 ) ] = ( char ) ( index_personagem + 48) ;
                                posicoes_2d[ (index * 4 ) + 1 ] = sign;
                                posicoes_2d[ (index * 4 ) + 2 ] = posicao_X;
                                posicoes_2d[ (index * 4 ) + 3 ] = posicao_Y;
                                
                                continue;

                       }



                        numero_personagens_1d++;

                       //if ( index_personagem > numero_personagens_1d ) numero_personagens_1d = index_personagem;




                       tem_mov_1d = true;
                       posicao_X_int = Convert.ToInt32 (posicao_componentes[ 0 ].Trim());

                       if( posicao_X_int > 0 ) { sign = ( char ) 48; } else { sign = ( char ) 49; posicao_X_int *= -1;}

                       


                       posicao_X =  ( char ) (posicao_X_int + 48);


                        
                        posicoes_1d[ (index * 3 ) ] = ( char ) ( index_personagem + 48) ;
                        posicoes_1d[ (index * 3 ) + 1 ] = sign;
                        posicoes_1d[ (index * 3 ) + 2 ] = posicao_X;
                        continue;


                }

//                foreach(  char a in posicoes_1d  ) Debug.Log( "e: " + a);


                string cena_1d =  "" ;
                string cena_2d =  "" ;
                string join_str = "" ;

                
                char auto_1d;
                char auto_2d;




                        //  nao funciona
                if( !tem_mov_2d && !tem_mov_1d  ){return null;}



                if( tem_mov_2d && tem_mov_1d  ){
                        
                        join_str = "\r\n";

                        cena_1d = Criar_mov_1d(  tipo , 't' , posicoes_1d , numero_personagens_1d ) ;
                        cena_2d = Criar_mov_2d(  tipo , auto_cena  , posicoes_2d , numero_personagens_2d  ) ;



                } else if( tem_mov_1d ) {

                        
                        cena_1d = Criar_mov_1d(  tipo , auto_cena   , posicoes_1d , numero_personagens_1d ) ;

                } else{

                        
                        cena_2d = Criar_mov_1d (  tipo , auto_cena  , posicoes_2d , numero_personagens_2d  ) ;
                }



                string cena_final = string.Concat( cena_1d ,  join_str , cena_2d );


                
                // Geral.Salvar_string( cena_final );
                // erro();

               // Geral.Salvar_string( cena_final , 1);
                return cena_final;      
                


                string Criar_mov_1d (  char _tipo_cena  ,char _auto , char[] _posicoes , int _numero_personagens ){

                       

                        char[] retorno_char = new char[ 3 + _numero_personagens * 3 ];
                        
                        retorno_char[0] = _tipo_cena;
                        retorno_char[1] = _auto;
                        retorno_char[2] = '0';

                        int index_retorno = 3;

                        int numero_maximo_personagens = ( _posicoes.Length / 3 ) ;

                        for(  int personagem_em_analise = 0 ;  personagem_em_analise < numero_maximo_personagens ; personagem_em_analise++  ){

                                if( _posicoes[ personagem_em_analise * 3 ] == ( char ) 47 ) {  continue ; }
                                



                                retorno_char[ index_retorno ] = _posicoes[ ( personagem_em_analise * 3 ) ];
                                retorno_char[ index_retorno + 1 ] = _posicoes[ ( personagem_em_analise * 3 )  + 1 ];
                                retorno_char[ index_retorno + 2 ] = _posicoes[ ( personagem_em_analise * 3 )  + 2 ];
                                index_retorno += 3 ;
                                
                        }

                        string retorno = new string( retorno_char );
                        return retorno;


                }

                string Criar_mov_2d (  char _tipo_cena  ,char _auto , char[] _posicoes , int _numero_personagens ){

                        
                        char[] retorno_char = new char[ 3 + _numero_personagens * 4 ];
                        
                        retorno_char[0] = _tipo_cena;
                        retorno_char[1] = _auto;
                        retorno_char[2] = '1';

                        int index_retorno = 3;

                        int numero_maximo_personagens = ( _posicoes.Length / 4 ) ;


                        for(  int personagem_em_analise = 0 ;  personagem_em_analise < numero_personagens ; personagem_em_analise++  ){

                                if( _posicoes[ personagem_em_analise * 4 ] == ( char ) 47 ) {  continue ; }
                                

                                retorno_char[ index_retorno ] = _posicoes[ ( personagem_em_analise * 4 ) ];
                                retorno_char[ index_retorno + 1 ] = _posicoes[ ( personagem_em_analise * 4 )  + 1 ];
                                retorno_char[ index_retorno + 2 ] = _posicoes[ ( personagem_em_analise * 4 )  + 2 ];
                                retorno_char[ index_retorno + 3 ] = _posicoes[ ( personagem_em_analise * 4 )  + 3 ];

                                index_retorno += 4 ;
                        }

                        string retorno = new string( retorno_char );
                        return retorno;


                }









                
                //         //  nao funciona
                // if( !tem_mov_2d && !tem_mov_1d  ){return null;}



                // if( tem_mov_2d && tem_mov_1d  ){
                        
                //         join_str = "\r\n";

                //         for (  )

                //         cena_1d = Criar_mov(  tipo , 't' ,  '\u0030'  , posicoes_1d , ((numero_personagens_1d * 3) + 3) );
                //         cena_2d = Criar_mov(  tipo , auto_cena , '\u0031' , posicoes_2d , ( (numero_personagens_2d * 4)  + 3) );


                // } else if( tem_mov_1d ) {

                        
                //         cena_1d = Criar_mov(  tipo , auto_cena ,  '\u0030'  , posicoes_1d , ((numero_personagens_1d * 3) + 3) );

                // } else{

                        
                //         cena_2d = Criar_mov(  tipo , auto_cena , '\u0031' , posicoes_2d , ( (numero_personagens_2d * 4)  + 3) );
                // }



                // string cena_final = string.Concat( cena_1d ,  join_str , cena_2d );


                
                // // Geral.Salvar_string( cena_final );
                // // erro();

                // Geral.Salvar_string( cena_final , 1);
                // return cena_final;      
                


                // string Criar_mov(  char _tipo_cena  ,char _auto , char _tipo_mov , char[] _posicoes , int _max_index ){


                       

                //         char[] retorno_char = new char[ _max_index];

                        
                //         retorno_char[0] = _tipo_cena;
                //         retorno_char[1] = _auto;
                //         retorno_char[2] = _tipo_mov;

                //         for( index = 3 ;  index < _max_index ; index++  ){

                //                 retorno_char[ index ] = _posicoes [ index - 3 ];

                //         }


 
 

                //         string retorno = new string( retorno_char );
                //         return retorno;


                // }


                
        } 









             
        public static string Compilar_text (  string _line , int _numero_cena , Interpretador_data _interpretador_data  ){

        /*                 oque é       auto       tipo     personagem      cor       tipo construcao                 texto   */ 
        //   esperado:      0            t          1           3          cor_id                            's' + 't' + 'a' + 'r' + 't' ...

        /* TIPOS:

          0 = > cria novo bloco
          1 => cria texto em baixo
          2 => continua na mesma linha

        */

        /*
           TIPOS CONSTRUCAO:

           0 => default
           1 => instantaneo
           2 => fade 
           3 => typewrite
           .
           .
           .
           se precisar adicionar colocar aqui

        */



                string[] linhas_itens_pre = Manipulador_texto.Trim_linha( _line );

                

                char tipo_cena = (char) ((int) Tipo_cena.text + 48 );
                char auto = Manipulador_texto.Pegar_bool_linha_0( linhas_itens_pre[ 0 ] );
                _interpretador_data.auto_atual_para_set = auto ;
                char personagem = '0'; // narrador
                char tipo = '0';
                char cor_id_char = '0';
                char voice = '0';
                char construcao = '0';
                char[] texto = new char[]{ '>' };


                Manipulador_texto.Verificar_dois_pontos( linhas_itens_pre[ 0 ] );


                for( int t = 1 ; t < linhas_itens_pre.Length ; t++ ){


                        Manipulador_texto.Verificar_dois_pontos( linhas_itens_pre[ t ] );

                        string[] pair = linhas_itens_pre[ t ].Split(":");
                        string linha_tipo = pair[ 0 ].Trim();

                        string valor = pair[1].Trim();

                        switch( linha_tipo ){

                                case "tipo":  tipo = Pegar_tipo_text( valor ) ; break;
                                case "construcao": construcao = Pegar_construcao( valor );break;
                                case "per": personagem = ( char )( _interpretador_data.Pegar_index_personagem( valor )  + 48 ) ; break; // extras 50+ 
                                case "voice":  voice =  ( char ) (Convert.ToInt32( valor ) + 48 ) ; break;
                                case "texto":  texto =   valor.ToCharArray() ; break;
                                case "cor":   cor_id_char = Pegar_cor( valor ) ; break;
                                default: Debug.LogError( "nao veio tipo aceitavel em compilar_text. veio: " + linha_tipo ); throw new ArgumentException("");
                                
                        }


                }



                
                char[] cena_final_arr = new char[ texto.Length + 6 ];

                /*
                        voice => vai criar um [audio] com a voice e anexar

                */

                
          

                cena_final_arr[ 0 ] =  tipo_cena ;
                cena_final_arr[ 1 ] =  auto ;
                cena_final_arr[ 2 ] =  tipo ;
                cena_final_arr[ 3 ] =  personagem ;
                cena_final_arr[ 4 ] =  cor_id_char ;
                cena_final_arr[ 5 ] =  construcao ;
                

                for( int i = 6 ; i < cena_final_arr.Length ;i++ ){

                        cena_final_arr[ i ] = texto[ i - 6 ];

                }


//                Geral.Salvar_string( texto_char_arr_E_info );

                string cena_final = new string( cena_final_arr );
                

                return cena_final;





                char   Pegar_tipo_text  ( string _tipo ){ 

                        if( _tipo == "novo_bloco") return '\u0030'; // 0
                        if( _tipo == "mesma_linha") return '\u0031'; // 1
                        if( _tipo == "nova_linha") return '\u0032'; // 2

                        throw new ArgumentException("tipo texto nao aceito, veio: " + _tipo);

                }

                char Pegar_construcao( string _valor ){

                        switch( _valor ){

                                case "default": return '0';
                                case "instantaneo": return '1';
                                case "fade": return '2';
                                case "type_write": return '3';
                                default: Debug.LogError("nao veio tipoi aceitavel em pegar_construcao em compilar texto. veio: " + _valor); throw new ArgumentException("");

                        }

                }

                char Pegar_cor( string _nome_cor ){

                        Nome_cor nome_cor = ( Nome_cor ) Enum.Parse(  typeof( Nome_cor ) , _nome_cor );
                        char _cor_id_char =  ( char ) ( ( int ) nome_cor + 48 ) ;
                        return _cor_id_char;

                }

     
                
        }



        public static string Compilar_audio (  string _line , int _numero_cena , Interpretador_data _interpretador_data   ){

                
                
                int linhas_necessarias = 7;

                string[] linhas_itens_pre = Manipulador_texto.Trim_linha( _line );

                
                char auto =  Manipulador_texto.Pegar_bool_linha_0(  linhas_itens_pre[0] );
                _interpretador_data.auto_atual_para_set = auto ;
                Manipulador_texto.Checar_auto( auto );

                char tipo = (char)  ((int) Tipo_cena.audio + 48 );
                
                char tipo_audio = '0';
                char slot =  '1';
                char loop = 't';
                char modificador_volume = (char) ( 100 + 48 );
                char tempo_up =  '0';
                char tempo_down =  '0';
                char[] path = new char[] { '0' };



                

                for( int t = 1 ; t < linhas_itens_pre.Length ; t++ ){

                        
                        string[] pair = linhas_itens_pre[ t ].Split(":");
                        if( pair.Length == 1 ){ Debug.LogError("chave veio vazia em compilar_audio, chave:" + pair[ 0 ]); throw new ArgumentException("");}
                        string linha_tipo = pair[ 0 ].Trim();
                        string valor = pair[ 1 ].Trim() ;

                        switch( linha_tipo ){

                                case "tipo":  tipo_audio = Pegar_tipo_audio( valor ) ; break;
                                case "slot":  slot =  (char) ( Convert.ToInt32( valor ) + 48) ; break;
                                case "loop":  loop = valor[0]; Manipulador_texto.Checar_auto( loop ) ; break;
                                case "modificador_volume" : modificador_volume = ( char ) (Convert.ToInt32( valor ) + 48 ) ; break;
                                
                                case "tempo_up":  tempo_up =  (char) (Convert.ToInt32 ( valor ) + 48); break;
                                case "tempo_down":  tempo_down =  (char) (Convert.ToInt32 ( valor ) + 48); break;
                                case "path":  path =  valor.ToCharArray(); break;
                                default: Debug.LogError("nao foi achado chave em compilar_audi. Veio: " + linha_tipo ); throw new ArgumentException("");

                        }

                }


   



                char[] cena_final_char_arr = new char[  path.Length + 8  ];

                cena_final_char_arr[ 0 ] = tipo;
                cena_final_char_arr[ 1 ] = auto;
                cena_final_char_arr[ 2 ] = tipo_audio;
                cena_final_char_arr[ 3 ] = slot;
                cena_final_char_arr[ 4 ] = loop;
                cena_final_char_arr[ 5 ] = modificador_volume;
                cena_final_char_arr[ 6 ] = tempo_down;
                cena_final_char_arr[ 7 ] = tempo_up;
                




                for(  int index = 8;   index < cena_final_char_arr.Length   ; index++  ){

                        cena_final_char_arr[ index ] = path [ index - 8 ];

                }

                
                string cena_final = new string( cena_final_char_arr );

                return cena_final;

        

                char Pegar_tipo_audio( string _tipo ){

                        switch( _tipo ){

                                case "music": return ( char ) ( ( int ) Tipo_audio.music + 48);
                                case "sfx": return ( char ) ( ( int ) Tipo_audio.sfx + 48 );
                                case "voice": return ( char ) ( ( int ) Tipo_audio.voice + 48 );

                        }

                        throw new ArgumentException("tipo em pegar audio nao aceito");

                }
                












                
                        
        }
        public static string Compilar_jump (  string _line , int _numero_cena , Interpretador_data _interpretador_data  ){




                string[] linhas_itens = Manipulador_texto.Trim_linha( _line );

                //if( linhas_itens.Length == 1  ) { linhas_itens = linhas_itens[ 0 ].Split(","); }

                char[] info = new char[ 9 ];


                char tipo_cena = (char) ((int) Tipo_cena.jump + 48);

                char auto = 't';///mudar?

                _interpretador_data.auto_atual_para_set = auto;

                char tem_jump_automatico = 'f';
                char _default = ( char ) ( -1 + 48 );

                char obrigatorio = 'f';
                char id_jump_automatico = ( char ) ( 0 + 47 );

                char tem_script = 'f';
                char script_id = ( char ) 47;

                char run_time_jump_id = ( char ) 48; // se for >0 => ativa  // só é criado/ modificado em run time


                 
                int total_elementos = linhas_itens.Length; 

                int index = 0;

                int index_start = 1;


                for(  index = 1 ; index < 3 ;  index++  ){

                        if( linhas_itens[ index ][0] == 'v' ) break;

                        index_start++;

                        string[] k_v = linhas_itens[ index ].Split(":");

                        string k = k_v[ 0 ].Trim();
                        string v = k_v[ 1 ].Trim();

                        if(v == "nada") continue;

                        switch( k ){

                                case "default": _default =  (char) (_interpretador_data.Pegar_index_pointer( v )  + 48 ) ; break;
                                case "obrigatorio" : obrigatorio = v[0]; break;
                                case "script_id" : tem_script = 't'; script_id = ( char ) (  Convert.ToInt32( v ) + 48 ) ; break;
                                default:  throw new ArgumentException("nao veio propriedade aceita em jump. veio: " + k);

                        }


                }


                

                if( ( total_elementos - index_start ) == 1 ) {

                                // criar automatico


                                tem_jump_automatico = 't';
                                string pointer_nome = linhas_itens[ index_start ].Split(":")[1].Trim();
                                char jump_id = (char) ( _interpretador_data.Pegar_index_pointer( pointer_nome) + 48 ) ;

                                info[ 0 ] = tipo_cena;
                                info[ 1 ] = auto;
                                info[ 2 ] = tem_jump_automatico;
                                info[ 3 ] = jump_id ;
                                info[ 4 ] = 'f';
                                info[ 5 ] = _default;
                                info[ 6 ] = tem_script;
                                info[ 7 ] = script_id;
                                info[ 8 ] = run_time_jump_id;


                                string cena_retorno = new string ( info );

                            //    Debug.LogError("jump: " + cena_retorno );

                                return cena_retorno;

                } else {



                        // tem que verificar

                        bool possibilidades_veio_com_formato_errado = ((total_elementos - index_start ) % 3  != 0 );

                        if(   possibilidades_veio_com_formato_errado   ) { throw new ArgumentException("jump veio com formato errado"); }

                        int numero_possibilidades = ( total_elementos - index_start ) / 3 ;

                        int numero_de_separadores = numero_possibilidades -1;

                        int index_inicial = info.Length;

                        char[] cena_final = new char[   (numero_possibilidades * 3 )  + 9 ] ;

                        cena_final[ 0 ] = tipo_cena;
                        cena_final[ 1 ] = auto;
                        cena_final[ 2 ] = tem_jump_automatico;
                        cena_final[ 3 ] = '0' ;
                        cena_final[ 4 ] =  obrigatorio;
                        cena_final[ 5 ] =  _default;
                        cena_final[ 6 ] =  tem_script;
                        cena_final[ 7 ] =  script_id;
                        cena_final[ 8 ] = run_time_jump_id;

                        

                        for( index = 0  ;   index  < numero_possibilidades   ; index++ ) {

                    
                                /*

                                        jump_nome
                                        pergunta
                                        resposta

                                */
                                

                                //        tem que usar o start 
                                string jump_nome =   linhas_itens[  (index * 3 )   +  index_start ].Split(":")[1].Trim();
                                string pergunta = linhas_itens[  (index * 3 )   + index_start  + 1  ].Split(":")[1].Trim();

                                string resposta_necessaria = linhas_itens[  (index * 3 ) + index_start  + 2  ].Split(":")[1].Trim();

                                if( jump_nome == "") {Debug.LogError(" nao veio jump_nome em choice"); throw new ArgumentException("");}
                                if( pergunta == "") {Debug.LogError("nao veio pergunta em choice"); throw new ArgumentException("");}
                                if( resposta_necessaria == "") {Debug.LogError(" nao veio resposta necessaria em choice "); throw new ArgumentException("");}


                                


                                int jump_index = _interpretador_data.Pegar_index_pointer( jump_nome );
                                int pergunta_index = _interpretador_data.Pegar_pergunta_index( pergunta );

                                int resposta_necessaria_index = _interpretador_data.Pegar_index_possivel_resposta( pergunta, resposta_necessaria );

                                // Debug.LogError( "resposta necessaria nome : " + resposta_necessaria   );
                                // Debug.LogError( "resposta necessaria index : " + resposta_necessaria_index   );

                                cena_final[ (index * 3) + 9 ]    = ( char ) (jump_index + 48);
                                cena_final[ (index * 3) + 9 +  1 ]    = ( char ) (pergunta_index + 48);
                                cena_final[ (index * 3) + 9 + 2 ]    = ( char ) ( resposta_necessaria_index + 48);

                                continue;

                                
                        }


                        string cena_retorno = new string ( cena_final );
                        return cena_retorno;


                }

                throw new ArgumentException("nao era paraver aqui");
                

                
        }
        public static string Compilar_pointer (  string _line , int _numero_cena , Interpretador_data _interpretador_data  ){
                /*
                        cena do pointer vai ter que ficar em outro arr, mas de qualquer jeitoeu so vou precisar delas em run time 

                */


                _interpretador_data.auto_atual_para_set = 't';

                string[] linhas = Manipulador_texto.Trim_linha( _line );


                string  pointer_nome = linhas[ 1 ].Trim();

                _interpretador_data.Colocar_pointer( pointer_nome );

                char[] retorno = new char[ 3 ];

                retorno[ 0 ] = ( char ) (( int ) Tipo_cena.pointer + 48 );
                retorno[ 1 ] = 'a';///?????
                retorno[ 2 ] = ( char )( _interpretador_data.Pegar_index_pointer( pointer_nome ) + 48 );

                string cena_retorno = new string( retorno );
                
                return cena_retorno;

                
        }



        public static string Compilar_choice (  string _line , int _numero_cena , Interpretador_data _interpretador_data  ){


        
        /*                 oque é       auto(sempre falso)          pode voltar         tipo            index_pergunta             pergunta_id_inicio     possivel resposta_id_1   ... */ 
        //   esperado:      0                f                         t/f            'tipo'               'id'                          'id'               '5' 

        //  choice precisa ir para o construtor inverso para pegar o cena[2] paraver se pode voltar a escolha





                // vai interar sobre _interpretador_data.perguntas e respsotas. tem que verificar se pode adicionar e se nao pode extender 

                string[] linhas = Manipulador_texto.Trim_linha( _line );




                char tipo_cena = ( char ) (( int ) Tipo_cena.choice  + 48 );
                char auto = 'f';
                _interpretador_data.auto_atual_para_set = 'f';


                char pode_voltar = 'f';
                char tipo = '0';

                char pergunta_id = '0';
                string pergunta = null;


                int index_inicio_perguntas = 0;

                for( int linha = 1 ; linha < linhas.Length ; linha++ ){


                        if(linhas[ linha ][ 0 ] == 'o') {index_inicio_perguntas = linha; break;}


                        string[] pair = linhas[ linha ].Split(":");
                        string linha_tipo = pair[ 0 ].Trim();
                        string valor = pair[1].Trim() ;
                        

                        switch( linha_tipo ){

                                case "pode_voltar":  pode_voltar = valor[0]; Manipulador_texto.Checar_auto( pode_voltar ); break;
                                case "tipo":  tipo = Pegar_tipo( valor ); break;
                                case "pergunta":  pergunta = valor; break;

                                default:  Debug.LogError("chave nao aceita em choice. veio: " + linha_tipo); throw new ArgumentException("");

                        }

                }

                if(pergunta == "") throw new ArgumentException("nao veio pergunta em choice");

                
                int numero_de_possiveis_resposta = linhas.Length - index_inicio_perguntas;

                _interpretador_data.Adicionar_pergunta( pergunta , numero_de_possiveis_resposta );

                pergunta_id = ( char ) (_interpretador_data.Pegar_pergunta_index( pergunta ) + 48) ;
                
                



                char[] cena_final_arr = new char[ 5 ];

                cena_final_arr[ 0 ] = tipo_cena;
                cena_final_arr[ 1 ] = auto;
                cena_final_arr[ 2 ] = pode_voltar;
                cena_final_arr[ 3 ] = tipo;
                cena_final_arr[ 4 ] = pergunta_id;

                
                for (  int n = 0  ;  n  < numero_de_possiveis_resposta   ;  n++  ){

                        
                        
                        string possivel_resposta = linhas[ n + index_inicio_perguntas  ].Split(":")[1].Trim();
                        

                        _interpretador_data.Adicionar_possivel_resposta(  pergunta , possivel_resposta , n  );

                        // precisa?
                        //cena_final_arr[ n ] = ( char )(  _interpretador_data.Pegar_index_possivel_resposta (  pergunta , possivel_resposta ) + 48);
                

                }

                string cena_final = new string( cena_final_arr );
                return cena_final;


                

                char Pegar_tipo( string _tipo){
                       

                        switch ( _tipo ){

                                case "pergaminho": return '0';
                                default: throw new ArgumentException(" tipo de choice nao aceito");

                        }


                }




        }


        public static string Compilar_fn (  string _line , int _numero_cena , Interpretador_data _interpretador_data  ){


                string[] linhas_itens = Manipulador_texto.Trim_linha( _line );
                

                string[] tipo_fn_auto = linhas_itens[ 0 ].Split(":");

                _interpretador_data.auto_atual_para_set = tipo_fn_auto[ 2 ][ 0 ] ;


                char tipo_cena = ( char ) (( int )  Tipo_cena.fn + 48 );

                

                /*
                        já vai iria perder tempo com enum.parse
                */

                string nome_fn =   tipo_fn_auto[ 1 ].Trim();

                string cena_retorno = "";




        switch( nome_fn ){

                

                /// mudancas grandes

                case "iniciar_plataforma": cena_retorno =  Fn_compilador.CRIAR_iniciar_plataforma( linhas_itens , _interpretador_data ); break;
                case "iniciar_animacao": cena_retorno =  Fn_compilador.CRIAR_iniciar_animacao( linhas_itens , _interpretador_data ); break;
                case "iniciar_modo_comic": cena_retorno =  Fn_compilador.CRIAR_iniciar_modo_comic( linhas_itens , _interpretador_data ); break;

                /// logica

                
                case "bloquear_passar_cenas": cena_retorno =  Fn_compilador.CRIAR_sem_variaveis(  Nome_fn.bloquear_passar_cenas , linhas_itens , _interpretador_data ); break; /*DONE*/// FOCO
                case "bloquear_voltar_cenas": cena_retorno =  Fn_compilador.CRIAR_sem_variaveis(  Nome_fn.bloquear_voltar_cenas , linhas_itens , _interpretador_data ); break; /*DONE*/// FOCO
                case "bloquear_cenas": cena_retorno =  Fn_compilador.CRIAR_bloquear_cenas( linhas_itens , _interpretador_data ); break; /*DONE*/// FOCO


                /// criar_coisas_tela

                case "criar_objeto": cena_retorno =  Fn_compilador.CRIAR_criar_objeto( linhas_itens , _interpretador_data ); break;
                case "modificar_objeto": cena_retorno =  Fn_compilador.CRIAR_modificar_objeto( linhas_itens , _interpretador_data ); break;
                case "rotacionar_objeto": cena_retorno =  Fn_compilador.CRIAR_rotacionar_objeto( linhas_itens , _interpretador_data ); break;
                case "colocar_itens_para_pegar": cena_retorno =  Fn_compilador.CRIAR_colocar_itens_para_pegar( linhas_itens , _interpretador_data ); break;
                case "mostrar_mensagem": cena_retorno =  Fn_compilador.CRIAR_mostrar_mensagem( linhas_itens , _interpretador_data ); break;
                case "zoom_tela": cena_retorno =  Fn_compilador.CRIAR_zoom_tela( linhas_itens , _interpretador_data ); break;

                case "escolha_rapida": cena_retorno =  Fn_compilador.CRIAR_escolha_rapida( linhas_itens , _interpretador_data ); break;



                
                case "transicao_inicio": cena_retorno =  Fn_compilador.CRIAR_transicao( "inicio",  linhas_itens , _interpretador_data ); break;
                case "transicao_meio": cena_retorno =  Fn_compilador.CRIAR_transicao( "meio" , linhas_itens , _interpretador_data ); break;
                case "transicao_final": cena_retorno =  Fn_compilador.CRIAR_transicao( "final", linhas_itens , _interpretador_data ); break;



                case "mudar_cor_tela": cena_retorno =  Fn_compilador.CRIAR_mudar_cor_tela( linhas_itens , _interpretador_data ); break;



                /// referentes backgrounds 

                
                case "mudar_background": cena_retorno =  Fn_compilador.CRIAR_mudar_background( linhas_itens , _interpretador_data ); break;    /*DONE*/// FOCO 



                case "tremer_tela": cena_retorno =  Fn_compilador.CRIAR_tremer_tela( linhas_itens , _interpretador_data ); break; 
                case "colocar_filtro_tela": cena_retorno =  Fn_compilador.CRIAR_colocar_filtro_tela( linhas_itens , _interpretador_data ); break;
                case "mover_background": cena_retorno =  Fn_compilador.CRIAR_mover_background( linhas_itens , _interpretador_data ); break; 


                case "mudar_foco_camera_personagens": cena_retorno =  Fn_compilador.CRIAR_mudar_foco_camera_personagens( linhas_itens , _interpretador_data ); break; /*DONO */// FOCO




                /// referente ao personagens


                case "mostrar_personagens": cena_retorno =  Fn_compilador.CRIAR_visibilidade_personagens(  _visivel:"true" , linhas_itens , _interpretador_data ); break;  /*DONE*/// FOCO
                case "mostrar_personagem": cena_retorno =  Fn_compilador.CRIAR_visibilidade_personagens(     _visivel:"true"  , linhas_itens , _interpretador_data ); break; /*DONE*/// FOCO

                case "esconder_personagens": cena_retorno =  Fn_compilador.CRIAR_visibilidade_personagens(    _visivel:"false"   , linhas_itens , _interpretador_data ); break; /*DONE*/// FOCO
                case "esconder_personagem": cena_retorno =  Fn_compilador.CRIAR_visibilidade_personagens(    _visivel:"false"    , linhas_itens , _interpretador_data ); break; /*DONE*/// FOCO



                case "mudar_index_personagens": cena_retorno =  Fn_compilador.CRIAR_mudar_index_personagens( linhas_itens , _interpretador_data ); break; /*DONE*/// FOCO
                case "mudar_index_personagem": cena_retorno =  Fn_compilador.CRIAR_mudar_index_personagens( linhas_itens , _interpretador_data ); break; /*DONE*/// FOCO






                case "ativar_highlight": cena_retorno =  Fn_compilador.CRIAR_switch_MODO_personagens(   _mod: "ativar", _variavel: "highlight"  , linhas_itens , _interpretador_data ); break; // FOCO
                case "desativar_highlight": cena_retorno =  Fn_compilador.CRIAR_switch_MODO_personagens(   _mod: "desativar", _variavel: "highlight"  , linhas_itens , _interpretador_data ); break; // FOCO




                case "ativar_sombras": cena_retorno    =  Fn_compilador.CRIAR_switch_MODO_personagens(   _mod: "ativar", _variavel: "sombras"  , linhas_itens , _interpretador_data ); break;
                case "desativar_sombras": cena_retorno =  Fn_compilador.CRIAR_switch_MODO_personagens(   _mod: "desativar", _variavel: "sombras"  , linhas_itens , _interpretador_data ); break;

                case "ativar_tamanho": cena_retorno    =  Fn_compilador.CRIAR_switch_MODO_personagens(   _mod: "ativar", _variavel: "tamanho"  , linhas_itens , _interpretador_data ); break;
                case "desativar_tamanho": cena_retorno =  Fn_compilador.CRIAR_switch_MODO_personagens(   _mod: "desativar", _variavel: "tamanho"  , linhas_itens , _interpretador_data ); break;






                case "colocar_highlight_personagens": cena_retorno =  Fn_compilador.CRIAR_switch_personagens(    _mod: "colocar",  _nome: "tem_highlight"  , linhas_itens , _interpretador_data ); break;
                case "colocar_highlight_personagem": cena_retorno =  Fn_compilador.CRIAR_switch_personagens(    _mod: "colocar",  _nome: "tem_highlight"  , linhas_itens , _interpretador_data ); break;

                case "tirar_highlight_personagens": cena_retorno =  Fn_compilador.CRIAR_switch_personagens(    _mod: "tirar",  _nome:"tem_highlight"  , linhas_itens , _interpretador_data ); break;
                case "tirar_highlight_personagem": cena_retorno =  Fn_compilador.CRIAR_switch_personagens(    _mod: "tirar",  _nome:"tem_highlight"  , linhas_itens , _interpretador_data ); break;




                case "colocar_transicao_cor_personagens": cena_retorno =  Fn_compilador.CRIAR_switch_personagens(    _mod: "colocar",  _nome:"cor"  , linhas_itens , _interpretador_data ); break;/*DONE*/// FOCO
                case "colocar_transicao_cor_personagem": cena_retorno =  Fn_compilador.CRIAR_switch_personagens(    _mod: "colocar",  _nome:"cor"  , linhas_itens , _interpretador_data ); break;/*DONE*/// FOCO

                case "tirar_transicao_cor_personagens": cena_retorno =  Fn_compilador.CRIAR_switch_personagens(    _mod: "tirar",  _nome:"cor"  , linhas_itens , _interpretador_data ); break;/*DONE*/// FOCO
                case "tirar_transicao_cor_personagem": cena_retorno =  Fn_compilador.CRIAR_switch_personagens(    _mod: "tirar",  _nome:"cor"  , linhas_itens , _interpretador_data ); break;/*DONE*/// FOCO




                case "colocar_transicao_movimento_personagens": cena_retorno =  Fn_compilador.CRIAR_switch_personagens(    _mod: "colocar",  _nome:"movimento"  , linhas_itens , _interpretador_data ); break; /*DONE*/// FOCO
                case "colocar_transicao_movimento_personagem": cena_retorno =  Fn_compilador.CRIAR_switch_personagens(    _mod: "colocar",  _nome:"movimento"  , linhas_itens , _interpretador_data ); break; /*DONE*/// FOCO

                case "tirar_transicao_movimento_personagens": cena_retorno =  Fn_compilador.CRIAR_switch_personagens(    _mod: "tirar",  _nome:"movimento"  , linhas_itens , _interpretador_data ); break; /*DONE*/ // FOCO
                case "tirar_transicao_movimento_personagem": cena_retorno =  Fn_compilador.CRIAR_switch_personagens(    _mod: "tirar",  _nome:"movimento"  , linhas_itens , _interpretador_data ); break; /*DONE*/ // FOCO




                case "colocar_desfoco_personagens": cena_retorno =  Fn_compilador.CRIAR_switch_personagens(    _mod: "colocar",  _nome:"desfoco"  , linhas_itens , _interpretador_data ); break;
                case "colocar_desfoco_personagem": cena_retorno =  Fn_compilador.CRIAR_switch_personagens(    _mod: "colocar",  _nome:"desfoco"  , linhas_itens , _interpretador_data ); break;

                case "tirar_desfoco_personagens": cena_retorno =  Fn_compilador.CRIAR_switch_personagens(    _mod: "tirar",  _nome:"desfoco"  , linhas_itens , _interpretador_data ); break;
                case "tirar_desfoco_personagem": cena_retorno =  Fn_compilador.CRIAR_switch_personagens(    _mod: "tirar",  _nome:"desfoco"  , linhas_itens , _interpretador_data ); break;










                case "rotacionar_personagem": cena_retorno =  Fn_compilador.CRIAR_rotacionar_personagem( linhas_itens , _interpretador_data ); break;
                case "animar_personagem": cena_retorno =  Fn_compilador.CRIAR_animar_personagem( linhas_itens , _interpretador_data ); break; 
                case "tremer_personagem": cena_retorno =  Fn_compilador.CRIAR_tremer_personagem( linhas_itens , _interpretador_data ); break;

                case "mudar_cor_personagens": cena_retorno =  Fn_compilador.CRIAR_mudar_cor_personagens(  Nome_fn.mudar_cor_personagens , linhas_itens , _interpretador_data ); break; // FOCO
                case "mudar_cor_personagem": cena_retorno =  Fn_compilador.CRIAR_mudar_cor_personagens(  Nome_fn.mudar_cor_personagens , linhas_itens , _interpretador_data ); break; // FOCO

                case "mudar_scale_personagem": cena_retorno =  Fn_compilador.CRIAR_mudar_scale_personagem( linhas_itens , _interpretador_data ); break; 



                /// texto


                case "abaixar_texto": cena_retorno =  Fn_compilador.CRIAR_sem_variaveis( Nome_fn.abaixar_texto, linhas_itens , _interpretador_data ); break;  /*DONE*/// FOCO
                case "levantar_texto": cena_retorno =  Fn_compilador.CRIAR_sem_variaveis( Nome_fn.levantar_texto, linhas_itens , _interpretador_data ); break; /*DONE*/// FOCO

                case "mudar_cor_pergaminho": cena_retorno =  Fn_compilador.CRIAR_mudar_cor_pergaminho (  linhas_itens , _interpretador_data ); break; /*DONE*/// FOCO

                
                case "mudar_posicao_pergaminho": cena_retorno =  Fn_compilador.CRIAR_mudar_posicao_pergaminho( linhas_itens , _interpretador_data ); break; /*DONE*///FOCO

                case "mudar_nomes_display": cena_retorno =  Fn_compilador.CRIAR_mudar_nomes_display( linhas_itens , _interpretador_data ); break; /*DONE*/// FOCO
                case "mudar_nome_display": cena_retorno =  Fn_compilador.CRIAR_mudar_nomes_display( linhas_itens , _interpretador_data ); break; /*DONE*/// FOCO

                case "mudar_cor_texto_personagens": cena_retorno =  Fn_compilador.CRIAR_mudar_cor_personagens(  Nome_fn.mudar_cor_texto_personagens ,  linhas_itens , _interpretador_data ); break; /*DONE*/// FOCO
                case "mudar_cor_texto_personagem": cena_retorno =  Fn_compilador.CRIAR_mudar_cor_personagens(  Nome_fn.mudar_cor_texto_personagens ,  linhas_itens , _interpretador_data ); break; /*DONE*/// FOCO


                case "trocar_modelo_pergaminho": cena_retorno =  Fn_compilador.CRIAR_trocar_modelo_pergaminho( linhas_itens , _interpretador_data ); break;

                case "tremer_texto": cena_retorno =  Fn_compilador.CRIAR_tremer_texto( linhas_itens , _interpretador_data ); break; 



                case "mudar_volume": cena_retorno =  Fn_compilador.CRIAR_mudar_volume( linhas_itens , _interpretador_data ); break; /*DONE*///FOCO



                default: throw new ArgumentException("fn_name nao foi encontrado, veio: " + nome_fn);

           
        }


                return cena_retorno;

                




                // char[] info = new char[] {   tipo_cena, auto,  nome_fn   };

                // linhas_itens[ 0 ] = new string( info );

                // string cenas_finais = string.Join(     "|"  , linhas_itens  );

                // return cenas_finais;



                
        }





        public static string Compilar_end (  string _line , int _numero_cena , Interpretador_data _interpretador_data  ){

                

                string[] linhas_itens = Manipulador_texto.Trim_linha( _line );

                
                string nome_script_visual_novel_end = "nada";
                string nome_screen_play_sequencia = "nada";
                char auto = 'f';
                char tem_transicao_char   = 'f';
                

                for( int i = 1 ;  i < linhas_itens.Length ;i++){

                        string[] k_v = linhas_itens[ i ].Split(":");

                        if( k_v.Length < 2 ) continue;

                        string nome = k_v[ 0 ].Trim();
                        string valor = k_v[ 1 ].Trim();

                        switch( nome ){

                                case "script_end": nome_script_visual_novel_end = valor; break;
                                case"tem_transicao": tem_transicao_char = valor[ 0 ]; break;
                                case "screen_play_sequencia": nome_screen_play_sequencia = valor; break;
                                default: throw new ArgumentException("nao veio chave aceitalve em compilar end. veio: " + nome);

                        }




                }


                char tipo_cena = ( char ) (( int ) Tipo_cena.end + 48);
                char nome_cena_sequencia_id =   ( char ) ( ( int )  ( Nome_screen_play )  Enum.Parse(  typeof( Nome_screen_play ) , nome_screen_play_sequencia  ) + 48);
                char script_end_id   = ( char )  (( int )  ( Nome_script_visual_novel_end )  Enum.Parse(  typeof( Nome_script_visual_novel_end ) , nome_script_visual_novel_end  ) + 48);
                Manipulador_texto.Checar_auto( tem_transicao_char );



                char[] cena_retorno_arr = new char[ 5 ] {  

                        tipo_cena, 
                        auto,
                        script_end_id,
                        nome_cena_sequencia_id,
                        tem_transicao_char  
                        
                } ;


                string cena_retorno = new string( cena_retorno_arr );

                return cena_retorno;

                
        }






        public static string Compilar_set(  string _line , int _numero_cena , Interpretador_data _interpretador_data  ){


                int index;

                string[] linhas_itens = Manipulador_texto.Trim_linha( _line );

                int index_final_personagens = 0;


                for(  index = 0  ;  index < linhas_itens.Length   ;   index++  ){

                        char caracter_em_verificacao = linhas_itens[ index ][0];

                        if( caracter_em_verificacao == '/' ) {index_final_personagens = index - 1; break;}
                        if(index == (linhas_itens.Length - 1 )){index_final_personagens = index; break;}

                }


                string[] personagens = Manipulador_texto.Separar_linhas( linhas: linhas_itens , index_inicial: 1 , index_final: index_final_personagens);
                int numero_personagens = personagens.Length;


                string[] nomes = new string[ personagens.Length ]; 

                string[] linhas_com_nome_display_para_compilar_fn = new string[ personagens.Length + 1  ];


                linhas_com_nome_display_para_compilar_fn[ 0 ] = "fn:trocar_nome_display:true";
                bool tem_nomes_display = false;


                int index_apelido = 1;


                for( index = 0 ; index < numero_personagens ; index++){

                        string[] k_v = personagens[ index ].Split(":");
                        string personagem_nome = k_v[0].Trim();
                        nomes[ index ] = personagem_nome;

                        if( k_v.Length == 1){ continue; }

                        linhas_com_nome_display_para_compilar_fn[ index_apelido ] = personagens[ index ];
                        index_apelido++;
                        tem_nomes_display = true;

                }

                
          

                // display
                

                linhas_com_nome_display_para_compilar_fn = Manipulador_texto.Trim_string_arr( linhas_com_nome_display_para_compilar_fn ); 
                

                string nomes_display_cena = "";

                if( tem_nomes_display ){

                        nomes_display_cena  =    Fn_compilador.CRIAR_mudar_nomes_display( linhas_com_nome_display_para_compilar_fn , _interpretador_data) ;

                }



                // acrescentar novos blocos depois


                int adicional_nomes = 0;
                if( tem_nomes_display ) { adicional_nomes = 1; }




                int numero_funcoes_adicionais = linhas_itens.Length - numero_personagens - 1;
                //                                                               set       nome_display
                string[] cenas_retorno = new string[ numero_funcoes_adicionais  + 1  +  adicional_nomes   ];

                cenas_retorno[ 0 ]  = "essa parte vai ser substituida quando tiver as cenas finais"; 

                if( tem_nomes_display ) { cenas_retorno[ 1 ]  =  nomes_display_cena  ; }
                
                int index_cenas_retorno = 1 + adicional_nomes;


                for( index = ( index_final_personagens + 1 ); index < linhas_itens.Length ; index++ ){


                        string linha = linhas_itens [ index ];
                        string[] k_v = linha.Split(":");

                        string nome = k_v[ 0 ].Trim(); 
                        string valor = k_v[ 1 ].Trim();

                        if(nome[0] == '/') continue;


                        switch( linha ){

                                case "proximidade_personagens" :  cenas_retorno[  index_cenas_retorno  ] =  Fn_compilador.CRIAR_Proximidade_personagens(   new string[2]{   "fn:proximidade_personagem:true\r\n",  valor  } , _interpretador_data );break;
                                default: Debug.LogError( "compilador nao aceita fn: "+ nome + " colocado no set"  ); break;

                        }

                        index_cenas_retorno++;
                        continue;


                }


                cenas_retorno = Manipulador_texto.Trim_string_arr( cenas_retorno );

                
                string cena_final = String.Join( "\r\n" , cenas_retorno );





                return cena_final;


        }



        public static void erro(){
                throw new ArgumentException("a");
        }















            public static string Pegar_interpretador_str( Interpretador_data _interpretador_data ){



                /*
                        toda a informacao vai estar contida em 1 linha, o leitor vai quebrar quando iniciar 
                        "&" => separa variaveis
                        "|" => separa arrays 
                        "," => separa itens

                        separar primeiro po "&"


                */

                /*


                        ics => mais importante [][]
                        nomes => []

                        perguntas []
                        possiveis respostas [][]

                        pointer_cena_localizador_int[]
                        pointers_cenas_ids_int[]


                        linhas_localizadoras: se editor

                */



                string[] personagens_nomes = _interpretador_data.nomes_personagens;

                string personagens_nomes_final = String.Join( ',' , personagens_nomes );



                int numero_personagens = personagens_nomes.Length;

                int numero_imagens_totais = 0;

                string[] personagens_images_arr = new string[ numero_personagens ];

                for ( int personagem = 0 ;  personagem < numero_personagens  ; personagem++ ){


                /*  choice:


                                aqui poderia colocar um dicionario no sentido de: 

                                [    nome em script   :    figura::modo::acao  ( em codigo da para fazer 3 bytes + 1 byte + 1 byte  )    ]

                                ** oque eu preciso ter: 
                                
                                quais figuras existem dentro do personagem

                                se der algum erro ele nem salva o script 



                */  choice:
          

                        string[] imagens_nomes = _interpretador_data.personagens_images_nomes[ personagem ];
                        personagens_images_arr[ personagem ] = String.Join( ',' , imagens_nomes );


                }
                string images_final = String.Join( "|" , personagens_images_arr );











                _interpretador_data.perguntas = Manipulador_texto.Trim_string_arr( _interpretador_data.perguntas );

                int numero_perguntas = _interpretador_data.perguntas.Length;

                string perguntas = String.Join( "," , _interpretador_data.perguntas );

                

                string[] possiveis_respostas_arr = new string[ numero_perguntas ];

                for ( int pergunta = 0 ;  pergunta < numero_perguntas  ; pergunta++ ){


                        string[] possiveis_respostas = _interpretador_data.possiveis_respostas_arr[ pergunta ];

                        possiveis_respostas_arr[ pergunta ] = String.Join( ',' , possiveis_respostas );



                }

                string possiveis_respostas_final = String.Join( "|" , possiveis_respostas_arr );





                string[] pointer_id_cena_index_arr = new string[ _interpretador_data.pointer_id_cena_index_arr.Length ];


                for( int pointer_id_cena = 0 ;  pointer_id_cena <  _interpretador_data.pointer_id_cena_index_arr.Length ; pointer_id_cena++ ){

                                pointer_id_cena_index_arr[ pointer_id_cena ] = Convert.ToString( _interpretador_data.pointer_id_cena_index_arr[ pointer_id_cena ] );

                }


                string pointers_id_final = String.Join( ",", pointer_id_cena_index_arr );



                string pointers_str_final =   string.Join(",", _interpretador_data.pointer_id_str  ) ;


                string set_str =  Convert.ToString((char)( (int) Tipo_cena.set + 48 )) + "t";



                string[] final_arr = new string[]{ 

                        set_str,
                        personagens_nomes_final, 
                        images_final,
                        perguntas,
                        possiveis_respostas_final,
                        pointers_id_final,
                        pointers_str_final
                        

                };

                string final =  string.Join(  "&" , final_arr );

                


                return final;

            }












}





























        public static class Manipulador_texto {




                public static void Verificar_dois_pontos( string _line ){

                        bool tem_ponto_E_virgula = false;
                        bool tem_dois_pontos = false;

                        for(int i = 0 ;  i < _line.Length ;i++){

                                if( _line[ i ] == ';' ) tem_ponto_E_virgula = true;
                                if( _line[ i ] == ':' ) tem_dois_pontos = true;

                        }

                        if( tem_ponto_E_virgula && ! tem_dois_pontos ) throw new ArgumentException("foi ; no lugar de :");

                }



                public static char Pegar_bool_linha_0(  string _linha  ){

                        for(int i = 0  ;  i < _linha.Length ;  i++){

                                if(_linha [ i ] == ':' ){

                                        while(true){
                                                i++;
                                                if(i > _linha.Length) break;
                                                if( _linha[ i ] == ' ' ){ continue;}
                                                Checar_auto( _linha[ i ] );
                                                return _linha[ i ];

                                        }
                                
                                }
                                        
                        }
                        return 'f';

                }

        
                public static  string[] Trim_string_arr( string[] arr ){

                                int index_ultimo_valor = ( arr.Length - 1 );
                                bool ja_tem_valor = false;

                                for( int i = 0 ; i < arr.Length ; i++ ){

                                        if( ja_tem_valor ){

                                                if( arr[ i ] != null ){
                                                        

                                                        throw new ArgumentException("em Tirar_index_não_ultilizados_string_arr array tinha buracos de valores. null valor null valor");
                                                } 
                                                continue;
                                        }

                                        if( arr[ i ] == null){

                                                index_ultimo_valor = i - 1;
                                                ja_tem_valor = true;
                                                
                                                continue;

                                        }

                                }


                                int novo_arr_length = index_ultimo_valor + 1;
                        

                                string[] retorno = new string[ novo_arr_length ];

                                for(int k = 0 ; k < novo_arr_length ; k++){

                                        retorno[ k ] = arr[ k ];

                                }

                                return retorno;


                        }



                public static  string[] Separar_linhas(  string[] linhas , int index_inicial , int index_final  ){


                        int nova_length = index_final - index_inicial + 1;
                        if( nova_length < 0  || nova_length > linhas.Length ) {throw new ArgumentException("erro");}
                        
                        string[] retorno = new string[ nova_length ];

                        for( int k = 0 ; k < nova_length; k++ ){

                                retorno[ k ] = linhas [ k + index_inicial ];

                        }

                        return retorno;

                }


                public static string[] Trim_linha( string _linha ){

                        int item;

                        
                        int y = 0;
                        for(int k = 0 ;  k < _linha.Length ;k++){

                                if(_linha[ k ] == '\r' ) y++;

                        }

                        string[] itens_pre = _linha.Split("\r\n");

                        for( item = 0 ; item < itens_pre.Length  ; item++  ){

                                itens_pre[ item ] = itens_pre[ item ].Trim();

                        }


                        if( itens_pre.Length == 1 ){

    //                            Debug.LogError("veio modelo com 1 ");

                                        //  fn  ic  
                                        // fazer formato [fn,true,nome,....]     

                                        string[] retorno_pre = _linha.Split(",");
                                        string tipo = null;

                                        if( retorno_pre.Length == 1){

                                                //  jump e pointer

                                                retorno_pre = _linha.Split(":");

                                                tipo = retorno_pre[ 0 ].Trim();

                                                if(tipo == "jump"){

                                                        retorno_pre[ 1 ] = "vai_para:" + retorno_pre[ 1 ].Trim();
                                                        return retorno_pre;

                                                }

                                                if( tipo == "pointer" ){

                                                        return retorno_pre;

                                                }

                                        }

                                        tipo = Pegar_tipo( retorno_pre[ 0 ] );

                                        retorno_pre[0] = retorno_pre[0].Trim();

                                        int index_para_comecar = 0;

                                        if( tipo == "fn"){


                                                index_para_comecar = 3;
                                                retorno_pre[0] = "fn:" +  retorno_pre[2]  + ":" + retorno_pre[1];

                                        } else 

                                        if( tipo == "jump" ){

                                                retorno_pre = _linha.Split(":");
                                                retorno_pre[ 1 ] = "vai_para:" + retorno_pre[ 1 ];
                                        

                                        } else if( tipo == "text"){

                                                // dentro do text tem ',' isso faz o split com o numero certo

                                                index_para_comecar = 2;
                                                char[] r = _linha.ToCharArray();
                                                int numero_virgulas = 0;

                                                for(  int j = 0 ; j < r.Length  ; j++  ){


                                                        if(  r[ j ] == 't' ){

                                                                if(numero_virgulas == 0) { continue; }

                                                                j++;

                                                                if( r[ j ] == 'e' ){

                                                                        
                                                                        break;
                                                                }
                                                        }

                                                        if( r[ j ] == ',' ) { numero_virgulas++; continue;}

                                                }

                                                retorno_pre = _linha.Split( ",", ( numero_virgulas + 1) );




                                        }
                                        
                                        else {

                                                index_para_comecar = 2;
                                                retorno_pre[0] = retorno_pre[0]  +  ":" +  retorno_pre[1];

                                        }


                                        int numero_argumentos = retorno_pre.Length - index_para_comecar;

                                                                                //      fn:nome;true
                                        string[] retorno = new string[ numero_argumentos  +    1 ];


                                        retorno[ 0 ] = retorno_pre[ 0 ];

                                        for(   int arg = 1  ;   arg < retorno.Length ;  arg++  ){

                                                retorno[ arg ] = retorno_pre[ arg + index_para_comecar - 1 ].Trim();
                                                

                                        }


                                        


                                        return retorno ;
                        }


                        int itens_length = 0 ;

                        

                        for(  item = 0 ;  item < itens_pre.Length ; item++ ){

                                if( itens_pre [ item ] != "" ) {
                                        
                                        itens_length++;
                                }

                        }




                        string[] itens = new string[ itens_length ];
                        int index_final = 0;
                        

                       
                        for( item = 0 ;  item < itens_pre.Length ; item++ ){

                                if( itens_pre [ item ] != "" ) {

                                        itens [ index_final ] = itens_pre [ item ] .Trim();
                                        index_final++;
                                        
                                }
                        }


                        return itens;

                }




                public static void Checar_auto( char _auto ){

                        if( _auto != 't'){

                                if( _auto != 'f' ) {

                                        Debug.Log("char: " + _auto );
                                        Debug.LogError("auto nao aceito");
                                        throw new ArgumentException("");
                                }

                        }
                        return;

                }

                public static void Checar_mod( char _auto ){

                        if( _auto != 'c'){

                                if( _auto != 't' ) {

                                        Debug.LogError("mod nao aceito");
                                        throw new ArgumentException("");
                                }

                        }
                        return;

                }



        public static  string Pegar_tipo( string linha ){
                    
                        int index_inicial = 0;
                        int index_final = 0;

                        int numero_caracteres = linha.Length;
                        int numero_caracteres_tipo = 0;

                        char caracter;

                        int index = -1;
                        
                        // acha primeiro
                        while( index < numero_caracteres ){


                                index++;

                                caracter = linha[ index ];

                                if( caracter == '[' ) continue;
                                if( caracter == ' ' ) continue;
                                if( caracter == '\r' ) continue;
                                if( caracter == '\n' ) continue;

                                
                                index_inicial = index;
                        
                                break;


                        }

                        while( index < numero_caracteres  ){

                                index++; 
                                caracter = linha[ index ];                                

                                if( caracter == ' ' )  { index_final = index; break; }
                                if( caracter == ',' )  { index_final = index; break; }
                                if( caracter == '\r' )  { index_final = index; break; }
                                if( caracter == ':' )  { index_final = index; break; }
                                if( caracter == ';' )  { index_final = index; break; }
                                if( index ==  ( numero_caracteres- 1  ) ){ index_final = (index + 1); break; }
                                
                                continue;
                        
                                
                        }

                               
                        numero_caracteres_tipo = index_final - index_inicial ;

                        char[] linha_char = new char[ numero_caracteres_tipo ];

                        for(int i = 0;  i < numero_caracteres_tipo  ;  i++){

                                linha_char[ i ] = linha[i + index_inicial];

                        }

                        string retorno = new string( linha_char );

                        return retorno;

              }











        }






 //   public static void Garantir_compilado_existe( Nome_screen_play _nome ){


//             string path_nome =     Visual_novel_paths.Pegar_nome_path_screen_play( _nome );
//             string path =  Visual_novel_paths.Pegar_path_file_compilado( _nome_file_path: path_nome , _retirar_extensao: true ) ; 

//             TextAsset text = Resources.Load<TextAsset>( path );

//             if( text == null ){

//                 string path_screen_play_em_producao = Visual_novel_paths.Pegar_path_file_producao( path_nome );
//                 bool file_producao_nao_existe =  ! System.IO.File.Exists( path_screen_play_em_producao );

//                 if( file_producao_nao_existe ){

//                     throw new ArgumentException("screen play não foi encontrado tanto compilado quanto em producao. nome: " + path_nome);

//                 }

//                 Compilador_screen_play.Compilar( path_nome );
//                 Debug.Log(" Compilador_screen_play.Compilar foi ativado");

//             }

//     ////        


//     }
