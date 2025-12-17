using System;
using  UnityEngine;
using System.Text.RegularExpressions;


public static class Conversas_compilador {


    public static string Compilar(  string _personagem ,  string _nome_file  ){

        return null;


        // return null;

        // string path_folder = System.IO.Directory.GetCurrentDirectory() + "\\Assets\\Editor\\files_em_producao\\conversas\\";

        // string path = path_folder + _personagem + "\\"  +  _nome_file  + ".txt" ;


        // string texto_raw = System.IO.File.ReadAllText( path );

        // if( texto_raw == null ){Debug.LogError("nao foi achado conversa.txt no path: " + path); }

        // string cenas_trim_texto = Manipulador_texto.Pegar_cenas( texto_raw );

        // return cenas_trim_texto;



        


        // /*

        // [ thing:valor,thong:[] ]

        // */


        // string texto_raw_sem_chaves = null;



        // string texto_somente_com_cenas = Regex.Replace( texto_raw_sem_chaves, @"\](.|\s)*?\[", "]\r\n[");

        // Geral.Salvar_string(  texto_somente_com_cenas );

        // string[] texto_cenas_raw = texto_somente_com_cenas.Split("]\r\n[");


        // string[] cenas_finais_compiladas = new string[ texto_cenas_raw.Length ];

        // for(   int cena_index = 0 ;  cena_index < texto_cenas_raw.Length  ; cena_index++  ){

        //     string cena_raw = texto_cenas_raw[ cena_index ];

        //     string[] cena_partes = Manipulador_texto.Trim_linha( cena_raw );
            

        // }




        return null;



    }




}





//  estava dando problema, classe com o mesmo nome 
public static class Manipulador_texto_ {


        public static string[] Trim_linha( string _linha ) {

                int item;
                int y = 0;

                for(int k = 0 ;  k < _linha.Length ;k++){

                        if(_linha[ k ] == '\r' ) y++;

                }

                string[] itens_pre = _linha.Split("\r\n");

                for( item = 0 ; item < itens_pre.Length  ; item++  ){

                        itens_pre[ item ] = itens_pre[ item ].Trim();

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



        public static string[] Pegar_cenas( string texto_raw ){



                char[] texto_raw_char_arr = texto_raw.ToCharArray();
                
                int c = 0;
                char caracter_em_analise = '0';


                // for( c = 0  ;  c < texto_raw_char_arr.Length  ; c++  ){

                //     caracter_em_analise =  texto_raw_char_arr[ c ];

                //     if( caracter_em_analise == '{') texto_raw_char_arr[ c ] = '[';
                //     if( caracter_em_analise == '}') texto_raw_char_arr[ c ] = ']';


                // }

                //  tamanho nao importa 




                int[] index_cenas_start = new int[ 200 ];
                int[] index_cenas_final = new int[ 200 ];


                int numero_cenas = 0;

                bool esta_buscando_fim = false;
                int numero_chaves_para_ignorar = 0;

                

                for( c = 0  ;  c <  texto_raw_char_arr.Length  ;  c++ ){


                    caracter_em_analise =  texto_raw_char_arr[ c ];

                    if( caracter_em_analise == '['){

                        if( esta_buscando_fim  ) { 

                                numero_chaves_para_ignorar++;
                                continue; 

                        }

                        esta_buscando_fim = true;

                        index_cenas_start[ numero_cenas ] = c;

                    }

                    if( caracter_em_analise == ']'){


                            if( numero_chaves_para_ignorar  !=  0  ) { 

                                    numero_chaves_para_ignorar--;
                                    continue; 

                            }

                            index_cenas_final[ numero_cenas ] = c;
                            numero_cenas++;
                            
                            esta_buscando_fim = false;
                            continue;
                        
                    }


                }



                /*


                [
                    abc: [
                        def: true
                    ] 

                    ghi: [
                        lmn: false
                    ]
                ]

                lg = n


                =>

                [abc:[def:true],ghi:[lmn:false]]

                lg = (n - k)




                [ _ _ _'\r''\n' _ a b c _ _ d _ _ '\r' '\n'


                */







                string[] cenas_retorno = new string[ numero_cenas ];  //   type : info



                for( int cena = 0 ; cena < numero_cenas ; cena++ ){



                        int index_inicial = index_cenas_start [ cena ];
                        int index_final = index_cenas_final [ cena ];

                        int numero_caracteres = ( index_final - index_inicial + 1 );

                        char[] retorno_char = new char[ numero_caracteres ];


                        for( c = 0 ; c < numero_caracteres  ; c++ ){

                                retorno_char[ c ] = texto_raw_char_arr[ c + index_inicial ];

                        }

                        
                        cenas_retorno[ cena ] = new string( retorno_char );

                }



                return cenas_retorno;




                


                // for( int cena = 0 ; cena < numero_cenas ; cena++ ){

                //         int index_inicial = index_cenas_start [ cena ];
                //         int index_final = index_cenas_final [ cena ];



                //         Debug.Log("cena: " + cena );
                //         Debug.Log( "index_inicial: " + index_inicial );
                //         Debug.Log( "index_final: " + index_final );

                //         int numero_caracteres_raw = index_final - index_inicial + 1;
                //         int numero_caracteres_limpos = 0;

                //         int numero_linhas = -1; // se tem qualquer texto ele já faz ++.
                //         int spaces_atual = 0;

                //         // need: char[ length trim ]


                //         /// reader



                //         int numero_itens = -2; //  [ +1     (+n)    ] +1 



                        
                //         for( c = 0; c < numero_caracteres_raw ;c++  ){

                //                 caracter_em_analise = texto_raw_char_arr [ c + index_inicial ];


                //                 if( caracter_em_analise  == '\r' ){

                //                         numero_caracteres_limpos -= spaces_atual;    
                //                         spaces_atual = 0;

                //                         c++;
                //                         for( ; c < numero_caracteres_raw  ;c++ ){

                //                                 caracter_em_analise = texto_raw_char_arr [ c + index_inicial ];

                //                                 // verificar se tem algo na linha

                //                                 if( caracter_em_analise == '\r' ) { continue; }
                //                                 if( caracter_em_analise == '\n' ) { continue; }
                //                                 if( caracter_em_analise == ' '  ) { continue; }
                //                                 if( caracter_em_analise == ']' ) { numero_caracteres_limpos++; continue;}
                //                                 if( caracter_em_analise == '[' ) { numero_caracteres_limpos++; continue;}
                //                                 numero_linhas++;

                //                                 break;

                                    
                //                         }


                //                 }

                //                 // texto valido


                //                 if( caracter_em_analise == ' ' ) { 

                //                         numero_caracteres_limpos++;
                //                         spaces_atual++; 
                //                         continue; 

                //                 }

                //                 spaces_atual = 0;
                //                 numero_caracteres_limpos++;
                                


                //         }

                //         Debug.Log("limpos: " + numero_caracteres_limpos);
                //         Debug.Log("numero linhas: " + numero_linhas);


                //         // Debug.Log("numero caracteres_raw: " + numero_caracteres_raw);
                //         // Debug.Log("numero caracteres_limpos: " + numero_caracteres_limpos);



                //         // throw new ArgumentException("a");


                //         /// working


                //         //                                                           ',' * numero
                //         char[] cena_retorno = new char[ numero_caracteres_limpos  +  ( numero_linhas - 1) ];


                //         Debug.Log("cena_char_length: " + cena_retorno.Length);

                //         int c_cena_final = 0 ;

                //         bool espaco_NAO_foi_verificado = false;



                //         bool eh_o_primeiro = true;
                //         bool esta_pegando_valor = false;







                //         for( c = 0 ; c < numero_caracteres_raw  ; c++  ){

                //                // if( c_cena_final == cena_retorno.Length ) { break; }

                //                 caracter_em_analise =  texto_raw_char_arr[ c + index_inicial ] ;


                //                 if( caracter_em_analise == '\r' || caracter_em_analise == '\n' ) {  



                //                         c++;


                //                         for( ;; c++ ){

                //                                 caracter_em_analise = texto_raw_char_arr[ c + index_inicial ];

                //                                 if( caracter_em_analise == '\n' ) { continue; }
                //                                 if( caracter_em_analise == '\r' ) { continue; }
                //                                 if( caracter_em_analise == ' ' ) { continue; }
                //                                 break;

                //                         }




                //                         if( caracter_em_analise == '[' ) {

                //                         }

                //                         if( caracter_em_analise == ']' ) {


                //                                 cena_retorno [ c_cena_final ] = caracter_em_analise;
                //                                 c_cena_final++;

                //                                 Debug.Log("c_cena_final: " + c_cena_final);
                //                                 Debug.Log( "cena_retorno.Length: " + cena_retorno.Length );

                //                                 if( c_cena_final == ( cena_retorno.Length) ) { break; }

                                                
                //                         }



                //                         if ( !eh_o_primeiro ){

                //                                 Debug.Log("VEIO AQUI");
                                                
                //                                 cena_retorno [ c_cena_final ] = ',';
                //                                 c_cena_final++;

                //                         } else {

                //                                 eh_o_primeiro = false;

                //                         }








                //                 }





                //                 /// [ _ _ _'\r''\n' _ a _ : b _ _  c : d _  _ _ '\r' '\n'

                //                 //    (x + ,) => ( , + x ) - first => yes

                //                 if( caracter_em_analise == ' ' ){

                //                         if( espaco_NAO_foi_verificado ){

                //                                 int c_analise = c;

                //                                 for( ;; c_analise++ ){

                //                                         caracter_em_analise = texto_raw_char_arr[ c_analise + index_inicial ];

                //                                         if( caracter_em_analise == ' ' ) { continue; }

                //                                         if( caracter_em_analise == '\r' ) { 

                //                                                 c = c_analise ;
                //                                                 break;

                //                                         }

                //                                         espaco_NAO_foi_verificado = false;
                //                                         break;

                //                                 }

                //                                 if( c_analise == c ) { 
                //                                         Debug.Log("veio aqui em igual");

                //                                         continue; 
                //                                 }

                //                         }

                //                         Debug.Log("COLOCOU");
                //                         cena_retorno[ c_cena_final ] = ' ';
                //                         c_cena_final++;
                //                         continue;



                //                 }


                //                 espaco_NAO_foi_verificado = true;

                //                 Debug.Log("caracter: " + caracter_em_analise );
                //                 cena_retorno[ c_cena_final ] = caracter_em_analise;
                //                 c_cena_final++;
                //                 continue;

                //         }





                //         string teste_str = new string( cena_retorno );



                //         //Geral.Salvar_string( teste_str );




                // }


            return null;
                


        }



}
