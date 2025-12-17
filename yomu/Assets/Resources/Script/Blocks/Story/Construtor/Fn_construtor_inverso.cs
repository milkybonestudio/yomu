using System; 
using UnityEngine;





public static class Fn_construtor_inverso {



    public static string CRIAR_mudar_cor_pergaminho_inverso( char _auto ){

                return new string(   
                    
                    new char[]{
                        
                        ( char ) (( int )  Tipo_cena.fn  + 48 ) ,
                        _auto,
                        ( char ) (( int ) Nome_fn.mudar_cor_pergaminho + 48) ,
                        // ( char ) (  ( int )  Controlador_tela_story.Pegar_instancia().pergaminho.cor_pergaminho_atual     + 48 )

                    }
                );



    }




    public static string CRIAR_iniciar_plataforma_inverso(){




            char[] cena_para_trocar = new char[]{

                ( char ) (( int ) Tipo_cena.fn  + 48  ),
                'f',
                ( char ) (( int ) Nome_fn.bloquear_voltar_cenas + 48  )

            };

            return new string( cena_para_trocar );

    }




    public static string CRIAR_transicao_inicio_inverso(){





        char[] cena_para_trocar = new char[]{

            ( char ) (( int ) Tipo_cena.fn  + 48  ),

            'f',

            ( char ) (( int ) Nome_fn.bloquear_voltar_cenas  + 48  )

        };


        return new string( cena_para_trocar  ) ;


         


        // char[] cena_para_trocar = new char[]{

        //     ( char ) (( int ) Tipo_cena.fn  + 48  ),

        //     't',

        //     ( char ) (( int ) Nome_fn.encerrar_transicao  + 48  )

        // };


         

        // string retorno = new string( cena_para_trocar );


        // return retorno;

    }

    
    public static string CRIAR_transicao_final_inverso(){


        char[] cena_para_trocar = new char[]{

            ( char ) (( int ) Tipo_cena.fn  + 48  ),

            'f',

            ( char ) (( int ) Nome_fn.bloquear_voltar_cenas  + 48  )

        };

        
        return new string( cena_para_trocar  ) ;




        // if ( Controlador_tela_story.Pegar_instancia().vai_ser_escondido  ){
        //     // tem transicao


        //         char[] cena_para_trocar = new char[]{

        //                 ( char ) (( int ) Tipo_cena.fn  + 48  ),

        //                 't',

        //                 ( char ) (( int ) Nome_fn.transicao_inicio  + 48  ),

        //                 '0',

        //                 ( char ) (  0  + 48  )

        //         };

        //         return new string( cena_para_trocar );

        // }

        // return CRIAR_nada_inverso();

        

    }




    public static string CRIAR_bloquear_voltar_cenas_inverso( string _cena_texto , char _auto ,Screen_play _screen_play  ){

      

        char[] cena_para_trocar = new char[]{

            ( char ) (( int ) Tipo_cena.fn  + 48  ),

            't',

            ( char ) (( int ) Nome_fn.nada  + 48  )


        };


        Cena cena = _screen_play.Pegar_cena_atual();
        cena.cena_texto = new string( cena_para_trocar );


        return _cena_texto;

    }



    public static string CRIAR_bloquear_passar_cenas_inverso(  ){

        char[] cena_inversa = new char[]{

            ( char ) (( int ) Tipo_cena.fn  + 48  ),

            't',

            ( char ) (( int ) Nome_fn.nada  + 48  )


        };

        return new string ( cena_inversa );
        
    }

    public static string CRIAR_nada_inverso () {


            char[] cena_inversa = new char[]{

                ( char ) ( ( int ) Tipo_cena.fn  + 48  ),

                't',

                ( char ) ( ( int ) Nome_fn.nada  + 48  )


            };

            return new string ( cena_inversa );


    }


    public static string CRIAR_mudar_foco_camera_personagens_inverso( string _cena_texto , char _auto, Screen_play _screen_play ){

        int modo_id  = BLOCO_story.Pegar_instancia().screen_play.foco_camera_personagens_atual_id ;

        char tipo_cena = ( char )  (  ( int ) Tipo_cena.fn + 48 );
        char auto = _auto;
        char nome_fn = ( char ) (  ( int ) Nome_fn.mudar_foco_camera_personagens + 48 );

        char id_char =  ( char ) (modo_id + 48);

        char instantaneo =  _cena_texto[ 4 ] ; // BLOCO_story.Pegar_instancia().screen_play.foco_camera_personagens_instantaneo;



        return new string( 
            new char[]{

                tipo_cena, 
                auto, 
                nome_fn,

                id_char,
                instantaneo

            }
         );

    }



    public static string CRIAR_mudar_background_inverso( string _cena_texto, char  _auto ,Screen_play _screen_play ){

        Screen_play screen_play =  BLOCO_story.Pegar_instancia().screen_play;

        string path =  screen_play.path_background_atual;

        char tipo_cena = ( char )  (  ( int ) Tipo_cena.fn + 48 );

        char auto = _auto;

        char nome_fn = ( char ) (  ( int ) Nome_fn.mudar_background + 48 );

        char instantaneo = _cena_texto[ 3 ] ;  // yes

        char foco = '2';  if( Controlador_tela_story.Pegar_instancia().Background_esta_em_foco() ) { foco = '3' ; }
    
        char cor_id = ( char ) ( screen_play.background_cor_id + 48 ) ;




        string parte_1 = new string( new char[]{

                tipo_cena,
                auto,
                nome_fn,

                instantaneo,
                foco,
                cor_id,

            } 
        );

        return ( parte_1 + path );

    }

    public static string CRIAR_mudar_visibilidade_personagens_inverso ( string _cena_texto, char  _auto ,Screen_play _screen_play ){

       // Debug.LogError("====================");

        
            //                           mod     p1_id   p7_id    p9_id ...
            //  tipo  auto   nome_fn   't'/'f'          0     1    0  ....


        char[] args = _cena_texto.ToCharArray();

        char[] retorno_parte_1 = new char[ 4 ];

        retorno_parte_1[ 0 ] = ( char )  (  ( int ) Tipo_cena.fn + 48 );
        retorno_parte_1[ 1 ] = _auto;
        retorno_parte_1[ 2 ] = ( char ) (  ( int ) Nome_fn.mudar_visibilidade_personagens + 48 );

        retorno_parte_1[ 3 ] = 't'; if( _cena_texto[ 3 ] == 't' ){  retorno_parte_1[ 3 ] = 'f'; }

        bool mod_vai_mostrar =  ( retorno_parte_1[ 3 ] == 't');





        int numero_personagens = ( _cena_texto.Length - 4 ); 

        Personagem_dados_visual_novel[] personagens_dados = Controlador_personagens_visual_novel.Pegar_instancia().personagens_dados;

        int personagens_para_modificar = 0;

        char[] personagens_pre = new char[ numero_personagens ];

        for(  int personagem_index = 0 ; personagem_index < numero_personagens ; personagem_index++  ){


                char personagem_id_char = _cena_texto[  personagem_index + 4 ];

                int personagem_id = (( int ) personagem_id_char - 48 );


                Personagem_dados_visual_novel personagem =  personagens_dados[ personagem_id ];

                bool personagem_nao_vai_ser_alterado = false;


                if (  !mod_vai_mostrar ) {

                        if ( personagem.cor_final [ 3 ]  == 1f ) { personagem_nao_vai_ser_alterado = true ; }
                        if ( personagem.cor_final [ 3 ]  == 0f ) { personagem_nao_vai_ser_alterado = false ; }

                }

                if(    mod_vai_mostrar  ){
                        if ( personagem.cor_final [ 3 ]  == 1f ) { personagem_nao_vai_ser_alterado = false ; }
                        if ( personagem.cor_final [ 3 ]  == 0f ) { personagem_nao_vai_ser_alterado = true ; }

                }
                


                if( personagem_nao_vai_ser_alterado ) { continue; }

                personagens_para_modificar++;
                personagens_pre [ personagens_para_modificar - 1 ] = personagem_id_char;
                continue;

        }

        char[] retorno_parte_2 = new char[ personagens_para_modificar ];


        for( int i = 0 ; i < personagens_para_modificar ; i++ ){

            retorno_parte_2[ i ] = personagens_pre[ i ];

        }


        return (    new string( retorno_parte_1 )   +  new string( retorno_parte_2 )      );
    


    }


    public static string CRIAR_mudar_index_personagens_inverso( string _cena_texto, char  _auto ,Screen_play _screen_play ){

        
        char tipo_cena = ( char )  (  ( int ) Tipo_cena.fn + 48 );
        char auto = _auto;
        char nome_fn = ( char ) (  ( int ) Nome_fn.mudar_index_personagens + 48 );

        int[] personagens_POR_index = _screen_play.personagens_POR_index;

        int numero_personagens = personagens_POR_index.Length;

        char[] retorno = new char[ ( personagens_POR_index.Length  * 2 )  + 3 ];

        retorno[ 0 ] = tipo_cena ;
        retorno[ 1 ] = auto ;
        retorno[ 2 ] = nome_fn ;

        for( int index = 0 ; index < numero_personagens ; index++ ){

            retorno[ ( index * 2) + 3       ] = ( char ) (  personagens_POR_index[ index ] + 48 );
            retorno[ ( index * 2) + 3 + 1   ] = ( char ) (  index + 48  );

        }

        return new string( retorno );



    }


    public static string CRIAR_modificar_switch_MODO_personagens_inverso( string _cena_texto, char  _auto ,Screen_play _screen_play ){


        // 000   switch_id   mod  

        char[] retorno = new char[ 5 ];
        
        retorno[ 0 ]  =  ( char )  (  ( int ) Tipo_cena.fn + 48 );
        retorno[ 1 ]  =  _auto;
        retorno[ 2 ]  =  ( char ) (  ( int ) Nome_fn.modificar_switch_MODO_personagens + 48 );

        retorno[ 3 ] = _cena_texto[ 3 ];
        retorno[ 4 ] = 'c'; if( _cena_texto[ 4 ] == 'c' ){ retorno[ 4 ] = 't'; }


        char variavel_switch_MODO_id = _cena_texto[ 3 ];

        bool mod =  (  retorno[ 4 ] == 't'  ) ;
        

        Tipo_switch_MODO_fn tipo =   ( Tipo_switch_MODO_fn ) ( ( int ) variavel_switch_MODO_id - 48 ) ;

        switch( tipo ){

            case Tipo_switch_MODO_fn.highlight:  if( _screen_play.is_highlight_activate != mod ) {return CRIAR_nada_inverso() ; } break;
            case Tipo_switch_MODO_fn.sombras:    if( _screen_play.is_sombras_activate != mod ) {return CRIAR_nada_inverso() ; } break;
            case Tipo_switch_MODO_fn.tamanho:    if( _screen_play.is_tamanho_activate != mod ) {return CRIAR_nada_inverso() ; } break;

        }


        return new string( retorno );


    }




    public static string CRIAR_modificar_switch_personagens_inverso ( string _cena_texto, char  _auto ,Screen_play _screen_play ){


            // 000   switch_id   mod  

            char[] retorno_parte_1 = new char[ 5 ];
            
            retorno_parte_1[ 0 ]  =  ( char )  (  ( int ) Tipo_cena.fn + 48 );
            retorno_parte_1[ 1 ]  =  _auto;
            retorno_parte_1[ 2 ]  =  ( char ) (  ( int ) Nome_fn.modificar_switch_personagens + 48 );

            retorno_parte_1[ 3 ] = _cena_texto[ 3 ];
            
            retorno_parte_1 [ 4 ] = 'c'; if( _cena_texto[ 4 ] == 'c' ){ retorno_parte_1[ 4 ] = 't'; }




            char variavel_switch_id = _cena_texto[ 3 ];

            bool mod =  (  retorno_parte_1[ 4 ] == 'c'  ) ;
            
            Tipo_switch_fn tipo =   ( Tipo_switch_fn ) ( ( int ) variavel_switch_id - 48 ) ;





            int numero_personagens = ( _cena_texto.Length - 5 ) ;
           // Debug.LogError("numero persoangens:  " + numero_personagens);
            char[] personagens_pre = new char[ numero_personagens ];

            int personagens_para_modificar = 0;


            Personagem_dados_visual_novel[] personagens_dados = Controlador_personagens_visual_novel.Pegar_instancia().personagens_dados;

            //Debug.LogError("pre lg : " + numero_personagens );

            for( int personagem_index = 0 ; personagem_index < numero_personagens   ; personagem_index ++ ){


                    char personagem_id_char = _cena_texto[ personagem_index + 5 ];
                    int personagem_id = (( int ) personagem_id_char - 48 );

                    Personagem_dados_visual_novel personagem =  personagens_dados[ personagem_index ];

                    switch( tipo ){

                            case Tipo_switch_fn.highlight :  if( personagem.tem_highlight  != mod ){ continue;};break;
                            case Tipo_switch_fn.movimento :  if( personagem.tem_transicao_movimento  != mod ){ continue;};break;
                            case Tipo_switch_fn.cor :  if( personagem.tem_transicao_cor  != mod ){ continue;};break;
                            default: throw new ArgumentException("tipo nao aceito");
                    }

                    personagens_para_modificar++;

                    personagens_pre[ personagens_para_modificar - 1 ] = personagem_id_char;

                    continue;

            }


            char[] retorno_parte_2 = new char[ personagens_para_modificar ];

            for( int i = 0 ; i < personagens_para_modificar ; i++ ){

                    retorno_parte_2[ i ] = personagens_pre[ i ];

            }



            return (    new string( retorno_parte_1 )   +  new string( retorno_parte_2 )  );
    
    }


    public static string CRIAR_Mudar_cor_personagens_inverso( string _cena_texto, char  _auto ,Screen_play _screen_play ){

        char[] retorno = _cena_texto.ToCharArray();

        int numero_personagens = ( ( _cena_texto.Length - 3 ) / 2 );

        Personagem_dados_visual_novel[] personagens_dados = Controlador_personagens_visual_novel.Pegar_instancia().personagens_dados;

        for(  int personagem_index = 0 ; personagem_index < numero_personagens ; personagem_index++ ){


                char personagem_id_char = _cena_texto[ ( personagem_index * 2 ) + 3  ] ;
                int personagem_id = ( ( int )personagem_id_char - 48 );

                Personagem_dados_visual_novel personagem = personagens_dados[ personagem_id ];
                char cor_id = ( char ) ( personagem.cor_personagem_atual_id + 48 ) ;

                retorno [ ( personagem_index * 2 ) + 3 + 1 ] = cor_id;

        }


        return new string( retorno );

    }


    public static string CRIAR_mudar_nomes_display_inverso ( string _cena_texto , char _auto , Screen_play _screen_play ) {



            char personagem_id_char = _cena_texto[ 3 ];
            int personagem_id = (  ( int ) personagem_id_char - 48  );
           // Debug.LogError( "persoangem id: "  + personagem_id);

            string nome_display = Controlador_personagens_visual_novel.Pegar_instancia().personagens_dados[ personagem_id ].nome_display;

            char[] retorno = new char[ nome_display.Length + 4 ];

            retorno[ 0 ] = _cena_texto[ 0 ];
            retorno[ 1 ] = _auto;
            retorno[ 2 ] = _cena_texto[ 2 ];
            retorno[ 3 ] = _cena_texto[ 3 ];

            for( int i = 0 ;  i < nome_display.Length ; i++ ){

                retorno[ i + 4 ] = nome_display[ i ];

            }

            return new string( retorno );


    }


    public static string CRIAR_abaixar_texto_inverso ( string _cena_texto , char _auto , Screen_play _screen_play ){

        // bool esta_abaixado = Controlador_tela_story.Pegar_instancia().pergaminho.pergaminho_is_abaixado;

        // if( esta_abaixado )  { return CRIAR_nada_inverso(); }

        char tipo_cena = ( char )  (  ( int ) Tipo_cena.fn + 48 );
        char auto = _auto;
        char nome_fn = ( char ) (  ( int ) Nome_fn.levantar_texto + 48 );

        return new string( new char[]{

            tipo_cena, 
            auto,
            nome_fn

        } );

    }


    public static string CRIAR_levantar_texto_inverso ( string _cena_texto , char _auto , Screen_play _screen_play ){

        bool esta_levantado = false ; // !Controlador_tela_story.Pegar_instancia().pergaminho.pergaminho_is_abaixado;

        if( esta_levantado )  { return CRIAR_nada_inverso(); }

        char tipo_cena = ( char )  (  ( int ) Tipo_cena.fn + 48 );
        char auto = _auto;
        char nome_fn = ( char ) (  ( int ) Nome_fn.abaixar_texto + 48 );

        return new string( new char[]{

            tipo_cena, 
            auto,
            nome_fn

        } );

    }

    

    public static string CRIAR_mudar_posicao_pergaminho_inverso  ( string _cena_texto , char _auto , Screen_play _screen_play ){


            int posicao_pergaminho_atual_id = _screen_play.posicao_pergaminho_atual_id; 
            char posicao_atual =   ( char ) (  posicao_pergaminho_atual_id + 48 );


            char[] retorno = _cena_texto.ToCharArray();

            retorno[ 3 ] = posicao_atual;

            return new string( retorno );


    }

        

    public static string CRIAR_mudar_cor_texto_personagens_inverso  ( string _cena_texto , char _auto , Screen_play _screen_play ){


        int numero_personagens = (_cena_texto.Length - 3 ) / 2;



        char[] args = _cena_texto.ToCharArray();

        char[] retorno = new char[_cena_texto.Length];

        for( int  i = 0 ; i < retorno.Length  ; i++ ){

            retorno[ i ] = args[ i ];

        }

        
        retorno[ 1 ] = _auto;


        


        Personagem_dados_visual_novel[] personagens_dados = Controlador_personagens_visual_novel.Pegar_instancia().personagens_dados;
        

        for( int personagem_index = 0 ; personagem_index < numero_personagens ; personagem_index++ ){

                char personagem_id_char = _cena_texto[ ( personagem_index * 2 ) + 3  ] ;
                int personagem_id = ( ( int ) personagem_id_char - 48 ) ;

                Personagem_dados_visual_novel personagem = personagens_dados[ personagem_id ];

                int cor_id_atual = personagem.cor_texto_atual_id; 
                
                char cor_id_char  = ( char ) ( cor_id_atual + 48 );

                retorno[ ( personagem_index * 2 ) + 3 + 1   ] = cor_id_char;


        }


        string retorno_string = new string( retorno ) ;




        return retorno_string ;





    }


    public static string CRIAR_mudar_volume_cena_inverso  ( string _cena_texto , char _auto , Screen_play _screen_play ){

        char[] args = _cena_texto.ToCharArray();
        

        args[ 5 ] =  (char)(((  ( int ) args[ 5 ] - 48  ) / 2 ) + 48 ) ;

        float volume_atual = 0f;

        Tipo_audio tipo =  ( Tipo_audio )  ( ( int ) args [ 3 ] - 48 ) ; 

        CONTROLLER__audio controlador_audio = CONTROLLER__audio.Pegar_instancia();


        switch( tipo ){


            case Tipo_audio.music :  volume_atual = controlador_audio.music_volume_interno  * 100f ; ;break;
            case Tipo_audio.sfx :  volume_atual = controlador_audio.sfx_volume_interno  * 100f ; ;break;
            case Tipo_audio.voice :  volume_atual = controlador_audio.voice_volume_interno  * 100f ; ;break;


        }

        
        int  volume_atual_int = Convert.ToInt32( volume_atual );



        
        
        args [ 6 ] =  ( char ) ( volume_atual_int  + 48  ) ; //Pegar() ; 


        // char[] cena = new char[]{

        //         tipo_cena,
        //         auto,
        //         nome_fn,

        //         tipo,
        //         slot,

        //         tempo_transicao,
        //         volume
                
            
        // };

        return new string( args );



        


    }



    
    
    







}