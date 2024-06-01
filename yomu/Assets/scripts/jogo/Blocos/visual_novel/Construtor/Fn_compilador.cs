
using System;
using UnityEngine;


public static class Fn_compilador{

    public static void Trava( int _i , int _k ){

        if(_i > _k) throw new ArgumentException("trva ativada");

    }




        public static char[] Pegar_personagens_bool_array(string[] _args , int _index_inicial , Interpretador_data _interpretador_data) {


                int index = 0 ;

                int id_maximo_personagem = _interpretador_data.nomes_personagens.Length;

                char[] personagens_pre = new char[   id_maximo_personagem ];
                for( index = 0 ;  index < id_maximo_personagem ; index++) { personagens_pre[ index ] = '0';}

                int numero_personagens = _args.Length - _index_inicial;
                int persoangem_com_id_mais_alto = 0;
                

                for(  index = 0 ; index < numero_personagens ;  index++  ){

                        string personagem = _args[ index + _index_inicial ].Trim();

                        int id_personagem = _interpretador_data.Pegar_index_personagem( personagem );

                        personagens_pre [ id_personagem ] = '1';
                        if( id_personagem > persoangem_com_id_mais_alto )  persoangem_com_id_mais_alto  = id_personagem;

                }

                char[] retorno = new char[ persoangem_com_id_mais_alto + 1 ];

        
                for( index = 0 ;  index < retorno.Length   ;  index++){

                    retorno[ index ] = personagens_pre[ index ];

                }

                return retorno;


        }

        public static char[] Pegar_personagens_ids_array(string[] _args , int _index_inicial , Interpretador_data _interpretador_data) {


                int numero_personagens = ( _args.Length - _index_inicial );

                char[] retorno  =  new char[ numero_personagens ];

                for(int i = 0  ; i < numero_personagens  ; i++){


                    retorno[ i ] =  ( char )( _interpretador_data.Pegar_index_personagem(  _args[ i ] ) + 48) ;

                }

                return retorno;


        }



        public static bool Nao_tem_k_v( string _linha ){

            for(int i = 0;  i < _linha.Length ; i++){

                if( _linha[ i ] == ':' ) return false;

            }

            return true;

        }




        public static char Pegar_bool_linha_0(  string _linha  ){

            
            int i = 0;
            int numero_dots = 0;
            while(true){

                Trava( i, 100);

                if(_linha [ i ] == ':' ){
                    

                    if(numero_dots == 1){

                        while( true ){
                            
                            Trava( i, 100);
                            i++;
                            if( _linha[ i ] == ' ' ){ continue;}
                            return _linha[ i ];
                        }

                    }
                    numero_dots++;
                }

                i++;
            }


        }








        public static string CRIAR_mudar_nomes_display(  string[] _linhas_limpas , Interpretador_data _interpretador_data  ){



            // _linhas_limpas[ 0 ] => fn: nome :  auto


            // todos iguais
            char  tipo_cena  =  ( char ) (( int )  Tipo_cena.fn  + 48 );
            char  nome_fn = ( char ) (( int ) Nome_fn.mudar_nome_display + 48);
            char  auto = Pegar_bool_linha_0( _linhas_limpas[0] );

            int numero_personagens = _linhas_limpas.Length - 1;

            // vai criar uma fn para cada personagem 
            string [] cenas_fn = new string[ numero_personagens ];

            int index = 0;

            for( int personagem = 0 ; personagem < numero_personagens ; personagem++  ){

                    
                
                    string[] k_v = _linhas_limpas[ personagem + 1 ].Split(":");

                    string nome_personagem = k_v[ 0 ].Trim();
                    string nome_display = k_v[ 1 ].Trim();

                    char personagem_id = ( char )( _interpretador_data.Pegar_index_personagem( nome_personagem ) + 48);

                    int novo_nome_display_length = nome_display.Length;

                                            //   default   nome_id                                    quebra de linha
                    int cena_char_arr_length =   3  +       1        +  novo_nome_display_length  +      2; 
                    char[] cena_char_arr = new char[ cena_char_arr_length ];


                    cena_char_arr[ 0 ] = tipo_cena;
                    cena_char_arr[ 1 ] = auto;
                    cena_char_arr[ 2 ] = nome_fn;
                    cena_char_arr[ 3 ] = personagem_id;

                    for( index = 0 ; index < cena_char_arr_length - 6   ;index++ ){

                        cena_char_arr[ index + 4 ]  = nome_display[ index ];

                    }
                    
                    cena_char_arr[ cena_char_arr_length - 2 ] = '\r';
                    cena_char_arr[ cena_char_arr_length - 1 ] = '\n';

                    cenas_fn[ personagem ] = new string ( cena_char_arr );

                // if( personagem == 1 ) Geral.Salvar_string(  cenas_fn[ personagem ] );

            }   


            string[] k_v_final = _linhas_limpas[ numero_personagens   ].Split(":");

            string nome_personagem_final = k_v_final[ 0 ].Trim();
            string nome_display_final = k_v_final[ 1 ].Trim();

            char personagem_id_final = ( char )( _interpretador_data.Pegar_index_personagem( nome_personagem_final ) + 48 );

            int novo_nome_display_length_final = nome_display_final.Length;

                                        //   default   nome_id                       sem quebra de linha
            int cena_char_arr_final_length =  ( 3  +       1        +  novo_nome_display_length_final )  ;
            char[] cena_char_arr_final = new char[ cena_char_arr_final_length ];

            cena_char_arr_final[ 0 ] = tipo_cena;
            cena_char_arr_final[ 1 ] = auto;
            cena_char_arr_final[ 2 ] = nome_fn;
            cena_char_arr_final[ 3 ] = personagem_id_final;

            for( index = 0 ; index < cena_char_arr_final_length - 4   ;index++ ){

                cena_char_arr_final[ index + 4 ]  = nome_display_final [ index ];

            }
            
            cenas_fn[ numero_personagens - 1  ] = new string ( cena_char_arr_final );
    



            // esperado:
            /*

                4tf2king\r\n
                4tf5???\r\n
                4tf7beach

            */


            
                // 4tf2king\r\n4tf5???\r\n4tf7beach

            string cenas_retorno = string.Concat( cenas_fn );

            return cenas_retorno;

        }


        public static string CRIAR_Proximidade_personagens( string[] args, Interpretador_data _interpretador_data ){

            //  0tn

            
            char auto = Pegar_bool_linha_0( args[ 0 ] );

            string _valor = args[1];

            char[] final_char = new char[ 4 ];


            final_char[ 0 ]  =  (char) (int) Tipo_cena.fn;
            final_char[ 1 ]  =  auto;
            final_char[ 2 ]  =  (char) (int)  Nome_fn.proximidade_personagens;

            switch( _valor ){

                case "amplo":   final_char[ 3 ]   = 'a'; break;
                case "normal":  final_char[ 3 ]  = 'n'; break;
                case "proximo": final_char[ 3 ] = 'p'; break;
                default: throw new ArgumentException("nome nao achado");

            }

            string retorno = new string ( final_char );

            return retorno;



        }






        public static string CRIAR_mudar_background( string[] _args, Interpretador_data _interpretador_data ){



                //  tipo  auto   nome  tem_transicao  tipo_foco id_cor path


                                        // todos iguais
                char  tipo_cena  =  ( char ) (( int )  Tipo_cena.fn  + 48 );
                char  nome_fn = ( char ) (( int ) Nome_fn.mudar_background + 48);
                char  auto = Pegar_bool_linha_0( _args[0] );

                char tipo_foco = '0';
                char tipo_transicao = '1';

                char cor = ( char )(( int ) Nome_cor.white + 48 );
            
                string path = "0";
                


                for(  int arg = 1 ; arg < _args.Length  ; arg++ ){


                        string[] k_v = _args [ arg ].Split(":");
                        if(  k_v.Length == 1   ) { Debug.LogError("chave em trocar background nao veio no formato correto"); throw new ArgumentException(""); }
                        string chave = k_v[ 0 ].Trim();
                        string valor = k_v[ 1 ].Trim();

                        switch( chave ){

                            case "tipo_transicao": tipo_transicao = Pegar_transicao( valor ); break;
                            case "cor": cor  = ( char )( ( int ) (Nome_cor) Enum.Parse(  typeof(Nome_cor) , valor )  + 48 ); break;
                            case "tipo_foco": tipo_foco = Pegar_tipo_foco( valor );break;
                            case "path":  path = valor; break;
                            default:  Debug.LogError( "nao foi achado chave em mudar_background.Veio: " + chave ); throw new ArgumentException(""); 

                        }

                }

                char[] retorno_char = new char[  path.Length  +  6 ];

                    retorno_char[ 0 ] =  tipo_cena;
                    retorno_char[ 1 ] =  auto;
                    retorno_char[ 2 ] =  nome_fn;
                    retorno_char[ 3 ] =  tipo_transicao;
                    retorno_char[ 4 ] =  tipo_foco;
                
                    retorno_char[ 5 ] =  cor;
 



                for(int str_index = 0 ; str_index < path.Length ; str_index++ ){

                    retorno_char[ str_index + 6 ] = path[ str_index ];

                }



                string retorno = new string( retorno_char );

                return retorno;


                char Pegar_transicao( string _tipo ){

                    switch( _tipo ){

                        case "instantaneo": return '0'; 
                        case "normal": return '1'; 
                        case "lento": return '2'; 
                        default: throw new ArgumentException("nao foi achado tipo de transicao. veio: " + _tipo);

                    }                    

                }


                char Pegar_tipo_foco ( string _tipo ){

                    switch( _tipo ){
                        
                        case "nao_alterar": return '0';
                        case "inverter": return '1'; 
                        case "desfoco": return '2'; 
                        case "foco": return '3'; 
                        default: throw new ArgumentException("nao foi achado tipo de foco/desfoco. veio: " + _tipo);

                    }

                }

        }






        public static string CRIAR_visibilidade_personagens( string _visivel,  string[] _args, Interpretador_data _interpretador_data ){




            //                           mod     p1_id   p7_id    p9_id ...
            //  tipo  auto   nome_fn   't'/'f'          0     1    0  ....


                                    // todos iguais
            char  tipo_cena  =  ( char ) (( int )  Tipo_cena.fn  + 48 );

            char  auto = Pegar_bool_linha_0( _args[0] );

            char  nome_fn = ( char ) (( int ) Nome_fn.mudar_visibilidade_personagens  + 48);

            // char mostrar_todos = 'f';

            char mod =  _visivel [ 0 ] ;

            //  ja conta [ 0 ]
            int numero_extras = 1;



            if( _args[ 1 ].Trim() == "todos" ){


                    int numero_todos_personagens = _interpretador_data.nomes_personagens.Length;
                    char[] cena_final_com_todos = new char[ numero_todos_personagens + 4 ];
                    cena_final_com_todos[ 0 ] = tipo_cena;
                    cena_final_com_todos[ 1 ] = auto;
                    cena_final_com_todos[ 2 ] = nome_fn;
                    cena_final_com_todos[ 3 ] = mod;

                    for (  int  k = 0 ;  k < numero_todos_personagens ; k++  ){

                            cena_final_com_todos[ 4 + k  ] = ( char ) (  k  +  48  ) ;

                    }
                
                    return new string( cena_final_com_todos );

            }


            int numero_personagens = _args.Length - numero_extras ;
            

            char[] cena_final = new char[ numero_personagens + 4 ];

            cena_final[ 0 ] = tipo_cena;
            cena_final[ 1 ] = auto;
            cena_final[ 2 ] = nome_fn;
            cena_final[ 3 ] = mod;


            for( int personagem = 0 ;  personagem < numero_personagens   ;  personagem++){
                

                string personagem_nome = _args[  numero_extras + personagem  ];

                char personagem_id_char =  ( char )( _interpretador_data.Pegar_index_personagem( personagem_nome ) + 48 ); 

                cena_final[ 4 + personagem ] = personagem_id_char;

            }

            string retorno = new string (  cena_final  );

           // Geral.Salvar_string( retorno );

            return retorno;
            
        }




        public static string CRIAR_switch_personagens(   string _mod , string _nome  , string[] _args, Interpretador_data _interpretador_data  ){


            //                        variavel_switch_id       _mod          p1_id   p2_id
            //  tipo  auto   nome_fn                         'c'/'t'        0        4 
    


                                    // todos iguais
            char  tipo_cena  =  ( char ) (( int )  Tipo_cena.fn  + 48 );
            char  nome_fn = ( char ) (( int ) Nome_fn.modificar_switch_personagens + 48);
            char  auto = Pegar_bool_linha_0( _args[0] );
            char switch_id =    Pegar_nome( _nome );
            char mod = _mod[0];



            if( _args[ 1 ].Trim() == "todos" ){


                    int numero_todos_personagens = _interpretador_data.nomes_personagens.Length;
                    char[] cena_final_com_todos = new char[ numero_todos_personagens + 5 ];
                    cena_final_com_todos[ 0 ] = tipo_cena;
                    cena_final_com_todos[ 1 ] = auto;
                    cena_final_com_todos[ 2 ] = nome_fn ;
                    cena_final_com_todos[ 3 ] = switch_id ;
                    cena_final_com_todos[ 4 ] = mod ;

                    for (  int  k = 0 ;  k < numero_todos_personagens ; k++  ){

                            cena_final_com_todos[ 5 + k  ] = ( char ) (  k  +  48  ) ;

                    }
                
                    return new string( cena_final_com_todos );

            }




            int numero_personagens = _args.Length - 1 ;

            char[] cena_final = new char[ numero_personagens + 5 ];

            cena_final[ 0 ] = tipo_cena;
            cena_final[ 1 ] = auto;
            cena_final[ 2 ] = nome_fn ;
            cena_final[ 3 ] = switch_id ;
            cena_final[ 4 ] = mod ;




            for( int index = 0 ;  index < numero_personagens   ;  index++){

                string personagem_nome = _args[ index + 1 ];

                int index_personagem = _interpretador_data.Pegar_index_personagem( personagem_nome );

                cena_final[ index + 5 ] = ( char ) ( index_personagem + 48 ) ;

            }

            string retorno = new string (  cena_final  );

            return retorno;

            char Pegar_nome( string _variavel ){

                switch( _variavel ){

                    case "cor": return  ( char ) (  ( int ) Tipo_switch_fn.cor + 48  ) ;
                    case "movimento": return  ( char ) (  ( int ) Tipo_switch_fn.movimento + 48  ) ;
                    case "tem_highlight": return  ( char ) (  ( int ) Tipo_switch_fn.highlight + 48  ) ;
                    case "tem_sombra": return  ( char ) (  ( int ) Tipo_switch_fn.sombras + 48  ) ;
                    case "tamanho": return  ( char ) (  ( int ) Tipo_switch_fn.tamanho + 48  ) ;

                    default: Debug.LogError("nao veio tipo aceitavel. veio: " + _variavel); throw new ArgumentException("");

                }



            }

            
        }



        public static string CRIAR_switch_MODO_personagens (  string _mod , string _variavel ,string[] _args, Interpretador_data _interpretador_data ){



                                        // todos iguais
                char  tipo_cena  =  ( char ) (( int )  Tipo_cena.fn  + 48 );
                char  auto = Pegar_bool_linha_0( _args[0] );
                char  tipo_fn = ( char ) ( ( int ) Nome_fn.modificar_switch_MODO_personagens + 48 );
                char mod = _mod[0]; 
                char variavel = Pegar_variavel( _variavel );



                char[] retorno_char = new char[ 5 ];

                retorno_char[ 0 ] = tipo_cena;
                retorno_char[ 1 ] = auto;
                retorno_char[ 2 ] = tipo_fn;
                retorno_char[ 3 ] = variavel;
                retorno_char[ 4 ] = mod;

                

                string retorno = new string( retorno_char );

                return retorno;



                char Pegar_variavel( string _variavel ){

                        switch( _variavel ){

                            case "sombras": return  ( char ) (  ( int ) Tipo_switch_MODO_fn.sombras + 48  );
                            case "tamanho": return  ( char ) (  ( int ) Tipo_switch_MODO_fn.tamanho + 48  );
                            case "highlight": return  ( char ) (  ( int ) Tipo_switch_MODO_fn.highlight + 48  );

                            default: Debug.LogError("nao veio tipo aceitavel. veio: " + _variavel); throw new ArgumentException("");

                        }

                }

        }






        





        public static string CRIAR_sem_variaveis(   Nome_fn _nome, string[] _args, Interpretador_data _interpretador_data ){


                                                // todos iguais
            char  tipo_cena  =  ( char ) (( int )  Tipo_cena.fn  + 48 );
            char  auto = Pegar_bool_linha_0( _args[ 0 ] );
            char  nome_fn = ( char ) (( int ) _nome + 48);

            char[] retorno_char = new char[]{ tipo_cena, auto , nome_fn  };

            string retorno = new string( retorno_char );

            return retorno;


        }








        public static string CRIAR_bloquear_cenas( string[] _args, Interpretador_data _interpretador_data ){

            // [fn,true,bloquear_passar_cenas , tempo, true_block , numero_clicks ]

                                            // todos iguais
            char  tipo_cena  =  ( char ) (( int )  Tipo_cena.fn  + 48 );
            char  nome_fn = ( char ) (( int ) Nome_fn.bloquear_cenas + 48);

            char auto_apos_completar = Pegar_bool_linha_0( _args[0] );




            char tempo = '0';
            char true_block = 'f';
            char numero_clicks = '3';
            

            

            for(  int arg = 1 ; arg < _args.Length  ; arg++ ){

                    string[] k_v = _args [ arg ].Split(":");
                    string chave = k_v[ 0 ].Trim();
                    string valor = k_v[ 1 ].Trim();

                    switch( chave ){

                        case "duracao": tempo = ( char ) (Convert.ToInt32( valor ) + 48); break;
                        case "numero_clicks": numero_clicks = ( char ) (Convert.ToInt32( valor ) + 48); break;
                        case "true_block": true_block = valor[0] ; break;
                        

                    }

            }

            char[] cena_retorno_char = new char[]{

                  tipo_cena  ,
                  'f' ,
                  nome_fn ,

                 tempo ,
                 true_block ,
                 numero_clicks ,
                 auto_apos_completar


            };

            string cena_retorno = new string( cena_retorno_char );

            return cena_retorno;






        }







        








        public static string CRIAR_transicao(  string _modelo,  string[] _args, Interpretador_data _interpretador_data ){
            /*

            [
                fn: transicao_: true => o true fala se apos do bloqueio terminar tem um click
            ]

            auto de transicao é sempre true e o auto do bloqueio é sempre falso.
            
            */

            /*

                        inicial     meio    final

            fn_tela       x                   x  
            bloqueio      x          x        x 
            encerrar                          x

            
            */





            char  nome_fn = ( char ) (( int ) Nome_fn.nada + 48);


            switch( _modelo  ){

                case "inicio":  nome_fn =  ( char ) ( ( int ) Nome_fn.transicao_inicio + 48 ) ;   break;
                case "final":  nome_fn =  ( char ) ( ( int ) Nome_fn.transicao_final + 48 ) ;   break;

            }


            


                                    // todos iguais
            char  tipo_cena  =  ( char ) (( int )  Tipo_cena.fn  + 48 );
            
            char  tem_click_apos_terminar = Pegar_bool_linha_0( _args[0] );

            char  duracao  =  (char) ( 100 + 48 ) ;

            char tipo = '0';

            


            string tem_click_apos_terminar_str = "true";
            if( tem_click_apos_terminar == 'f' )  { tem_click_apos_terminar_str = "false" ; }



            string true_block = "false";
            string bloqueio_clicks = "3";
            

            for(  int arg = 1 ; arg < _args.Length  ; arg++ ) {

                    string[] k_v = _args [ arg ].Split(":");
                    string chave = k_v[ 0 ].Trim();
                    string valor = k_v[ 1 ].Trim();

                    switch( chave ){

                        case "tipo": tipo = Pegar_tipo( valor );break;
                        case "true_block": true_block = valor ;break;
                        case "bloqueio_clicks": bloqueio_clicks =  valor  ;break;
                        

                        case "duracao": duracao = ( char ) (Convert.ToInt32( valor ) + 48); break;

                        default: throw new ArgumentException("nao foi achado chave em transicao. veio: " + chave);
                        
                        
                    }

            }



            int duracao_ms = ( int ) duracao - 48;




            
            char[] cena_transicao_char = new char[]{

                 tipo_cena,
                 't',
                 nome_fn,
                 tipo,
                 duracao,
                 
                
            };

            string cena_transicao = new string ( cena_transicao_char );



            string cena_bloqueio =  "";
            string encerrar_transicao = "";


            if(  ( int ) duracao > ( 17 + 48 )   ) {

                    string[] bloqueio_str = new string[] {

                            ( "fn:bloquear_passar_cenas:" + tem_click_apos_terminar_str  ) , 
                            ( "duracao:" + Convert.ToString( duracao_ms )) ,
                            ( "true_block:" + true_block ) ,
                            ( "numero_clicks:" + bloqueio_clicks ), 
                            

                    };

                    cena_bloqueio = CRIAR_bloquear_cenas(  bloqueio_str , _interpretador_data   );

            }



            if( _modelo == "meio" ) { return cena_bloqueio; } // meio nao tem nem fn_methods

            if( _modelo== "final" ){

                encerrar_transicao = new string(   new char[]{

                    '\r',
                    '\n',

                    ( char )(( int ) Tipo_cena.fn + 48),
                    't',
                    ( char )(( int ) Nome_fn.encerrar_transicao + 48)

                }   ) ;

            }



            string cena_final = cena_transicao + "\r\n" + cena_bloqueio + encerrar_transicao;


           // Geral.Salvar_string( cena_final , 1);

            return cena_final;


            char Pegar_tipo( string _valor ){

                switch( _valor ){

                    case "cor": return '0';
                    default: throw new ArgumentException( "tipo nao aceito em transciao. veio: " + _valor );

                }

            }


            
            
        }




















        public static string  CRIAR_mudar_cor_pergaminho( string[] _args, Interpretador_data _interpretador_data ){


                return new string(   
                    
                    new char[]{
                        
                        ( char ) (( int )  Tipo_cena.fn  + 48 ) ,
                        Pegar_bool_linha_0( _args[0] ) , 
                        ( char ) (( int ) Nome_fn.mudar_cor_pergaminho + 48) ,
                        ( char ) (( int ) (Nome_cor) Enum.Parse(  typeof(Nome_cor) , _args[ 1 ] ) + 48 )

                    }
                );



        }



        public static string CRIAR_mudar_cor_personagens(   Nome_fn _nome , string[] _args, Interpretador_data _interpretador_data ){


                        // [fn,true, nome ,   personagem_1  , cor_id, personagem_2  ,cor_id  ....]

                                            // todos iguais

            char  tipo_cena  =  ( char ) (( int )  Tipo_cena.fn  + 48 );
            char  nome_fn = ( char ) (( int ) _nome + 48);
            char  auto = Pegar_bool_linha_0( _args[0] );


            int numero_personagens = _args.Length - 1;


            char[] retorno_arr = new char[ numero_personagens * 2  +  3  ];

            retorno_arr[ 0 ] = tipo_cena;
            retorno_arr[ 1 ] = auto;
            retorno_arr[ 2 ] = nome_fn;

            for( int i = 0 ;  i < numero_personagens  ; i++ ){

          
                    string[] k_v = _args[ i + 1  ].Split(":");
                    string nome_personagem = k_v[ 0 ].Trim();
                    string cor_nome = k_v[ 1 ].Trim();

                    int index_persoangem = _interpretador_data.Pegar_index_personagem( nome_personagem );

                    retorno_arr[ ( i  * 2 )  + 3 ] =  (char) (index_persoangem + 48);

                    retorno_arr[   (i  * 2 )  + 4 ] = ( char ) (( int ) (Nome_cor) Enum.Parse(  typeof(Nome_cor) , cor_nome ) + 48 );


            }


            string cena_final = new string( retorno_arr );

            return cena_final;

            
        }






        public static string CRIAR_mudar_posicao_pergaminho( string[] _args, Interpretador_data _interpretador_data ){
            
                char  tipo_cena  =  ( char ) (( int )  Tipo_cena.fn  + 48 );
                char  nome_fn = ( char ) (( int ) Nome_fn.mudar_posicao_pergaminho + 48);
                char  auto = Pegar_bool_linha_0( _args[0] );


                char[] retorno_arr = new char[ 4 ];

                retorno_arr[ 0 ] = tipo_cena;
                retorno_arr[ 1 ] = auto;
                retorno_arr[ 2 ] = nome_fn;
                retorno_arr[ 3 ] = Pegar_direcao_pergaminho( _args[ 1 ] );



                string cena_final = new string( retorno_arr );

                return cena_final;


                char Pegar_direcao_pergaminho( string _direcao ){

                        switch(_direcao  ){

                                case "baixo": return '0';
                                case "cima": return '1';
                                case "esquerda": return '2'; 
                                case "direita": return '3';
                                default: throw new ArgumentException("tipo nao foi achado em mudar direcao pergaminho");

                        }

                }
            
        }



        // nao sei porque ou como(formato) direito

        // public static string  Mudar_transicoes_personagem( string[] _args , Interpretador_data _interpretador_data  ){





        //         [
        //             fn:mudar_transicoes_personagens

        //             nadia: 
        //             cor:
        //             movimento:

        //         ]




        // }







        public static string CRIAR_mudar_volume( string[] _args, Interpretador_data _interpretador_data ){



             // [fn,false,mudar_volume_cena,music_1,50,1000]


            char  tipo_cena  =  ( char ) (( int )  Tipo_cena.fn  + 48 );
            char  nome_fn = ( char ) (( int ) Nome_fn.mudar_volume + 48);
            char  auto = Pegar_bool_linha_0( _args[0] );

            char tipo = '1' ; // music  '0' => master
            char slot = '1' ;
            char tempo_transicao = (char) ( 100 + 48 );
            char volume = (char) ( 100 + 48 );


            for(  int arg = 1 ; arg < _args.Length  ; arg++ ){

                    string[] k_v = _args [ arg ].Split(":");
                    string chave = k_v[ 0 ].Trim();
                    string valor = k_v[ 1 ].Trim();

                    switch( chave ){

                        case "tipo": tipo = Pegar_tipo( valor );break;
                        case "slot": slot = ( char ) (  Convert.ToInt32( valor ) + 48 ); break;
                        case "tempo_transicao": tempo_transicao = ( char ) (Convert.ToInt32( valor ) + 48); break;
                        case "volume":  volume = ( char ) (Convert.ToInt32( valor ) + 48); break;


                    }

            }


            char[] cena = new char[]{

                 tipo_cena,
                 auto,
                 nome_fn,

                 tipo,
                 slot,

                 tempo_transicao,
                 volume
                 
                
            };

            string cena_final = new string( cena );

            return cena_final;



            char Pegar_tipo(  string _tipo ){

                switch( _tipo ){

                    case "music": return  ( char )(( int ) Tipo_audio.music + 48 );
                    case "sfx": return ( char )(( int ) Tipo_audio.sfx + 48 );
                    case "voice": return ( char )(( int ) Tipo_audio.voice + 48 );
                    
                    default: throw new ArgumentException("nao veio tipo aceitavel. veio: " + _tipo);

                }

            }
             
            
        }




        public static string CRIAR_mudar_index_personagens ( string[] _args, Interpretador_data _interpretador_data ){


            //   fn  auto  nome       


            char  tipo_cena  =  ( char ) (( int )  Tipo_cena.fn  + 48 );
            char  nome_fn = ( char ) (( int ) Nome_fn.mudar_index_personagens + 48);
            char  auto = Pegar_bool_linha_0( _args[0] );

            int numero_personagens = _args.Length - 1;

            char[] cena_arr  =  new char[  3 + ( numero_personagens * 2 ) ];

            cena_arr[ 0 ] = tipo_cena;
            cena_arr[ 1 ] = auto;
            cena_arr[ 2 ] = nome_fn;

            

            //     0 1 2 3
            //      0  => 3
            //      1  => 2
            //      

            //    ( length ) - id ;





            int[] index_para_verificar = new int[ numero_personagens ];

            // for ( int numero = 0 ; numero < numero_persoangens ; numero++ ){

            //     index_para_verificar[ numero ] = -1;

            // }

            int numero_maximo_personagens = _interpretador_data.nomes_personagens.Length;
            

            for(   int personagem = 0 ;  personagem < numero_personagens  ; personagem++   ){


                    string[] k_v = _args[ personagem + 1 ].Split(":");

                    string nome = k_v[ 0 ].Trim();
                    int personagem_id_int = _interpretador_data.Pegar_index_personagem(  nome  ) ;

                    char personagem_id =  ( char ) (  personagem_id_int + 48 );

                    int novo_index_int_pre = Convert.ToInt32( k_v[ 1 ].Trim() );

                    int novo_index_int =   numero_maximo_personagens   - novo_index_int_pre  - 1 ;

                    char novo_index =  ( char ) ( novo_index_int  + 48  );

                    cena_arr [  ( personagem * 2 ) + 3  ] = personagem_id;
                    cena_arr [  ( personagem * 2 ) + 3  + 1 ] = novo_index;

                    Verificar_index( index_para_verificar, novo_index_int );
                                                            //  0 => -1 , 1 => 0
                    


            }

            // verificar se algum index nao é maior que o maximo em interpretador.nomes

    
            string nova_cena = new string( cena_arr );
//            Geral.Salvar_string( nova_cena );
            return nova_cena;

            
            void Verificar_index( int[] _arr , int _valor ){


                int valor = _valor + 1;

                
                    for( int i = 0 ; i < _arr.Length ; i++  ){


                            if( _arr[ i ] == 0 ){
                                
                                    _arr[ i ] = valor;
                                    return;
                            
                            }

                            if( _arr[ i ] == valor) {

                                    Debug.LogError("veio 2 ids iguais em mudar_index_personagens");
                                    throw new ArgumentException("");

                            }


                    }

                
            }



        }




        public static string CRIAR_mudar_foco_camera_personagens ( string[] _args, Interpretador_data _interpretador_data ){


            char  tipo_cena  =  ( char ) (( int )  Tipo_cena.fn  + 48 );
            char  nome_fn = ( char ) (( int ) Nome_fn.mudar_foco_camera_personagens + 48);
            char  auto = Pegar_bool_linha_0( _args[0] );

            char  modo = '0' ;
            char instantaneo = 'f' ;

            for( int  i = 1  ;   i < _args.Length  ; i++  ){

                string[] k_v = _args[ i ].Split(":");

                if( k_v.Length < 2 ) { Debug.LogError("nao veio com o modelo correto"); throw new ArgumentException(""); }

                string propriedade = k_v[ 0 ].Trim();
                string valor = k_v[ 1 ].Trim();
                
                switch( propriedade ){

                    case "modo": modo = Pegar_modo( valor );  break; 
                    case "instantaneo" : instantaneo = valor[ 0 ]; break;
                    default: Debug.LogError("nao veio propriedade aceita em mudar_foco_camera_personagens. veio: " + propriedade); throw new ArgumentException("");

                }


            }

            char[] retorno = new char[]{

                tipo_cena,
                auto,
                nome_fn, 
                modo,
                instantaneo

            };


            return new string( retorno );


            char Pegar_modo( string valor ){

                
                switch ( valor ){
                    case "normal": return '0';
                    case "afastado": return '1';
                    case "proximo": return '2';
                    case "sem_alteracao": return '3';
                    default: Debug.LogError("nao veio tipo aceitavel de modo em mudar_foco_camera_personagens. Veio: " + valor); throw new ArgumentException("");

                }

            }
        }
        






        public static string CRIAR_iniciar_plataforma( string[] _args, Interpretador_data _interpretador_data ){


                char  tipo_cena  =  ( char ) ( ( int )  Tipo_cena.fn  + 48 ) ;
                char  auto = 'f';
                char  nome_fn = ( char ) (( int ) Nome_fn.iniciar_plataforma + 48 ) ;



                return new string (       new string(   new char[]{ tipo_cena , auto, nome_fn }   )      +   _args[ 1 ]     );
            
        }




        public static string CRIAR_iniciar_animacao( string[] _args, Interpretador_data _interpretador_data ){return"";}
        public static string CRIAR_iniciar_modo_comic( string[] _args, Interpretador_data _interpretador_data ){return"";}
        public static string CRIAR_criar_objeto( string[] _args, Interpretador_data _interpretador_data ){return"";}
        public static string CRIAR_modificar_objeto( string[] _args, Interpretador_data _interpretador_data ){return"";}
        public static string CRIAR_rotacionar_objeto( string[] _args, Interpretador_data _interpretador_data ){return"";}
        public static string CRIAR_colocar_itens_para_pegar( string[] _args, Interpretador_data _interpretador_data ){return"";}
        public static string CRIAR_mostrar_mensagem( string[] _args, Interpretador_data _interpretador_data ){return"";}
        public static string CRIAR_zoom_tela( string[] _args, Interpretador_data _interpretador_data ){return"";}
        public static string CRIAR_mudar_cor_tela( string[] _args, Interpretador_data _interpretador_data ){return"";}
        public static string CRIAR_escolha_rapida( string[] _args, Interpretador_data _interpretador_data ){return"";}
        public static string CRIAR_tremer_tela( string[] _args, Interpretador_data _interpretador_data ){return"";}
        public static string CRIAR_colocar_filtro_tela( string[] _args, Interpretador_data _interpretador_data ){return"";}
        public static string CRIAR_mover_background( string[] _args, Interpretador_data _interpretador_data ){return"";}
        public static string CRIAR_rotacionar_personagem( string[] _args, Interpretador_data _interpretador_data ){return"";}
        public static string CRIAR_mudar_scale_personagem( string[] _args, Interpretador_data _interpretador_data ){return"";}
        public static string CRIAR_trocar_modelo_pergaminho( string[] _args, Interpretador_data _interpretador_data ){return"";}
        public static string CRIAR_tremer_texto( string[] _args, Interpretador_data _interpretador_data ){return"";}
        public static string CRIAR_animar_personagem( string[] _args, Interpretador_data _interpretador_data ){return"";}
        public static string CRIAR_tremer_personagem( string[] _args, Interpretador_data _interpretador_data ){return"";}
        
        





}