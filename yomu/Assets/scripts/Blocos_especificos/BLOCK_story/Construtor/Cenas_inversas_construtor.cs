using UnityEngine;
using System;


public static class Cenas_inversas_construtor {


        /**/




        public static string Construir( Screen_play _screen_play){

            int cena_atual = _screen_play.cena_atual;
            int cena_anterior = cena_atual - 1;

            Cena cena = _screen_play.cenas[ cena_atual ];


            if ( cena.cena_texto_inverso != null  &&  !cena.pode_mudar_texto_inverso ) {


                Debug.Log("veio devolver a mesma cena");
                Debug.Log("Cena: " + cena.cena_texto_inverso );
                Debug.Log("Cena atual contruir: " + cena_atual );
                return cena.cena_texto_inverso; 


            }






            string cena_texto   = cena.cena_texto;

            char auto_inverso = _screen_play.Pegar_cena_texto_anterior()[ 1 ];



            
        
            Tipo_cena tipo =   (Tipo_cena) ( (int) cena_texto[0] - 48 );
            
            string cena_inversa  = null;

            switch( tipo ){


                    case Tipo_cena.mov: cena_inversa =  Construir_mov_inverso ( cena_texto, auto_inverso , _screen_play  );break;
                    case Tipo_cena.text: cena_inversa =  Construir_text_inverso ( cena_texto, auto_inverso , _screen_play  );break;
                    case Tipo_cena.ic: cena_inversa =  Construir_ic_inverso ( cena_texto, auto_inverso ,_screen_play  );break;
                    

                    case Tipo_cena.choice: cena_inversa =  Construir_choice_inverso ( cena_texto, auto_inverso ,_screen_play  );break;
                    case Tipo_cena.jump: cena_inversa =  Construir_jump_inverso ( cena_texto, auto_inverso ,_screen_play  );break;
                    case Tipo_cena.pointer: cena_inversa =  Construir_pointer_inverso ( cena_texto, auto_inverso ,_screen_play  );break;


                    case Tipo_cena.audio: cena_inversa =  Construir_audio_inverso ( cena_texto, auto_inverso ,_screen_play  );break;
                    case Tipo_cena.fn: cena_inversa =  Construir_fn_inverso ( cena_texto, auto_inverso ,_screen_play  );break;
                    case Tipo_cena.end: cena_inversa = ""; break;

                    default: throw new System.ArgumentException("veio modelo nao aceito em construir inverso. veio: " + tipo );
            

            }


            return cena_inversa;

        }


        public static string Construir_ic_inverso( string _cena_texto , char _auto , Screen_play _screen_play   ){

            Controlador_personagens_visual_novel controlador_personagens = Controlador_personagens_visual_novel.Pegar_instancia();
            Personagem_dados_visual_novel[] personagens_dados =  controlador_personagens.personagens_dados;


            char[] cena_retorno = new char[ _cena_texto.Length ];

            cena_retorno[ 0 ] = _cena_texto[ 0 ];
            cena_retorno[ 1 ] = _auto;


            int numero_personagens = (_cena_texto.Length - 2 ) / 2 ;


            for (  int personagem_index = 0 ; personagem_index < numero_personagens ;personagem_index++ ){

                char personagem_id_char = _cena_texto[ ( personagem_index * 2 ) + 2  ];

                int personagem_id  = ( ( int) personagem_id_char - 48 );

                Personagem_dados_visual_novel personagem = personagens_dados[ personagem_id ];

                char personagem_image_path_atual_char = ( char ) (personagem.path_localizador_imagem_atual + 48 );



                cena_retorno[ (personagem_index * 2 ) + 2 ] = personagem_id_char;
                cena_retorno[ (personagem_index * 2 ) + 2 + 1 ] = personagem_image_path_atual_char;

            }

            return new string ( cena_retorno );
            


        }


        public static string Construir_mov_inverso( string _cena_texto, char _auto , Screen_play _screen_play  ){


            //    TIPO 0:  
            /*                 oque é       auto       tipo        char_id           sinal         per_1_new x_px    ...    */
            //   esperado:      0            t          0             id          '48'/'49'         '\u01E0'            .. '

            //    TIPO 1:  
            /*                 oque é       auto       tipo        char_id           sinal         per_1_new x_px    per_1_new x_px    */
            //   esperado:      0            t          0             id          '48'/'49'         '\u01E0'            's'   '
        

            char tipo_cena = _cena_texto[ 0 ] ;
            char auto = _auto ;
            char tipo = _cena_texto[ 2 ] ;

            char[] cena_retorno = new char [ _cena_texto.Length ] ;

            cena_retorno[ 0 ] = tipo_cena;
            cena_retorno[ 1 ] = auto;
            cena_retorno[ 2 ] = tipo;

            bool IS_1D =( tipo == (char) 48 );

//            Geral.Salvar_string( _cena_texto );

            int numero_personagens = 0;
            int personagem_index = 0;


            Personagem_dados_visual_novel[] personagens_dados = Controlador_personagens_visual_novel.Pegar_instancia().personagens_dados;


            if( IS_1D ){

                    numero_personagens = ( cena_retorno.Length - 3 ) / 3;


                    for( personagem_index = 0 ;   personagem_index < numero_personagens  ;  personagem_index++ ){

                        char personagem_id_char =  _cena_texto[ ( personagem_index * 3 ) + 3  ];
                        int personagem_id =  ( int ) personagem_id_char - 48 ;

                        Personagem_dados_visual_novel personagem = personagens_dados[ personagem_id ];

                        char sinal = '0';

                        float p_x = personagem.posicao[ 0 ];
                        
                        if( p_x < 0f ){

                            sinal = '1';
                            p_x *= -1;

                        }

                        char p_x_char =  ( char ) (Convert.ToInt32( p_x ) + 48 );

                        cena_retorno[ ( personagem_index * 3 ) + 3  ] = personagem_id_char;
                        cena_retorno[ ( personagem_index * 3 ) + 3 + 1 ] = sinal ;
                        cena_retorno[ ( personagem_index * 3 ) + 3 + 2 ] = p_x_char;
                        
                    }


                    return new string( cena_retorno );


            }


            numero_personagens = ( cena_retorno.Length - 3 ) / 4;

            for( personagem_index = 0 ;   personagem_index < numero_personagens  ;  personagem_index++ ){

                char personagem_id_char =  _cena_texto[ ( personagem_index * 4 ) + 3  ];
                int personagem_id =  ( int ) personagem_id_char - 48 ;

                Personagem_dados_visual_novel personagem = personagens_dados[ personagem_id ];

                char sinal = '0';

                float p_x = personagem.posicao[ 0 ];
                float p_y = personagem.posicao[ 1 ];

                int med = 0;
                


                if( p_x < 0f ){ med += 1;  }
                if( p_y < 0f ){ med += 2;  }

                switch ( med ){

                    case 0: sinal =  '0' ; break;
                    case 1: sinal =  '2' ; break;  // 2 =. +x
                    case 2: sinal =  '2' ; break;
                    case 3: sinal =  '1' ; break;

                }

                char p_x_char =  ( char ) (Convert.ToInt32( p_x ) + 48 );
                char p_y_char =  ( char ) (Convert.ToInt32( p_y ) + 48 );
                
                cena_retorno[ ( personagem_index * 3 ) + 3  ] = personagem_id_char;
                cena_retorno[ ( personagem_index * 3 ) + 3 + 1 ] = sinal ;
                cena_retorno[ ( personagem_index * 3 ) + 3 + 2 ] = p_x_char;
                cena_retorno[ ( personagem_index * 3 ) + 3 + 3 ] = p_y_char;
                
            }


            return new string( cena_retorno );



        }

        


        public static string Construir_text_inverso( string _cena_texto , char _auto , Screen_play _screen_play  ){


                  
        /*                 oque é       auto       tipo     personagem     cor-id        forcar_modelo_construcao            texto   */ 
        //   esperado:      0            t          1           3          'id'                 'id'            's' + 't' + 'a' + 'r' + 't' ...


                
                int personagem_index = _screen_play.personagem_texto_atual ;

                string texto = _screen_play.texto_atual;
                int tipo_texto = _screen_play.tipo_texto;

                int cor_id = _screen_play.cor_texto_atual_id;



                bool eh_o_primeiro_text = ( personagem_index == -1 );
                bool pergaminho_abaixado = Controlador_tela_story.Pegar_instancia().pergaminho.pergaminho_is_abaixado ;



                if( eh_o_primeiro_text ){

                        char fn_tipo =   ( char ) ( ( int ) Tipo_cena.fn + 48 );

                        char fn_nome =  ( char )  (   ( int ) Nome_fn.resetar_text   + 48     );

                        char abaixar_pergaminho = 'f';


     


                        if (  pergaminho_abaixado  ) {  return Fn_construtor_inverso.CRIAR_levantar_texto_inverso("",'a',null);}


                        char[] retorno_caso_primeiro = new char[]{

                                fn_tipo,
                                _auto,
                                fn_nome

                        };

                        return new string( retorno_caso_primeiro );


                }

                
                if (  pergaminho_abaixado  ) {  return Fn_construtor_inverso.CRIAR_levantar_texto_inverso("",'a',null);}


                int novo_tipo_texto =  ( ( int )  _cena_texto[ 2 ] - 48  );
                int novo_personagem = ( ( int )_cena_texto[ 3 ]  - 48 ) ;


                char personagem_index_char = (char )( personagem_index + 48 );

                char cor_id_char = ( char ) ( cor_id + 48 ) ;


                char tipo_construcao = '0';


                char[] retorno = new char[ texto.Length + 6 ];

                retorno[ 0 ] = _cena_texto[ 0 ];
                retorno[ 1 ] = _auto;
                retorno[ 2 ] = '0';
                retorno[ 3 ] = personagem_index_char;
                retorno[ 4 ] =  cor_id_char ;
                retorno[ 5 ] = tipo_construcao;

                // precisa por automatico

                for( int i = 6 ;  i < retorno.Length   ; i++ ){

                    retorno[ i ] = texto[ i - 6 ];
                    
                }



                if( novo_personagem == personagem_index && novo_tipo_texto != 0 ){ 

                    retorno[ 1 ] = 't'; // auto
                    //retorno[ 4 ] = '1'; // instantaneo
                    

                  }

                return new string ( retorno );




        }




        public static string Construir_fn_inverso( string _cena_texto, char _auto , Screen_play _screen_play  ){

            Nome_fn nome_fn = ( Nome_fn ) ( ( int )  _cena_texto[ 2 ] - 48 ) ;

            switch( nome_fn ){


                case Nome_fn.nada: return Fn_construtor_inverso.CRIAR_nada_inverso();

                

            /// mudancas grandes

                case Nome_fn.iniciar_plataforma:   return Fn_construtor_inverso.CRIAR_iniciar_plataforma_inverso ( ); 
                // case Nome_fn.iniciar_animacao: Fn_construtor_inverso.Iniciar_animacao ( _cena ); break;
                // case Nome_fn.iniciar_modo_comic: Fn_construtor_inverso.Iniciar_modo_comic ( _cena ); break;

            /// logica

            
                case Nome_fn.bloquear_voltar_cenas: return Fn_construtor_inverso.CRIAR_bloquear_voltar_cenas_inverso( _cena_texto, _auto , _screen_play );  /*DONE*/// FOCO
                case Nome_fn.bloquear_passar_cenas: return Fn_construtor_inverso.CRIAR_nada_inverso(  );  /*DONE*/// FOCO
                case Nome_fn.bloquear_cenas: return Fn_construtor_inverso.CRIAR_nada_inverso( ); /*DONE*/// FOCO



            /// criar_coisas_tela

                // case Nome_fn.criar_objeto: Fn_construtor_inverso.Criar_objeto ( _cena -); break;
                // case Nome_fn.modificar_objeto: Fn_construtor_inverso.Modificar_objeto ( _cena ); break;
                // case Nome_fn.rotacionar_objeto: Fn_construtor_inverso.Rotacionar_objeto ( _cena ); break;

                // case Nome_fn.colocar_itens_para_pegar: Fn_construtor_inverso.Colocar_itens_para_pegar ( _cena ); break;
                // case Nome_fn.mostrar_mensagem: Fn_construtor_inverso.Mostrar_mensagem ( _cena ); break;
                
                // case Nome_fn.zoom_tela: Fn_construtor_inverso.Zoom_tela ( _cena ); break;
                
                // case Nome_fn.mudar_cor_tela: Fn_construtor_inverso.Mudar_cor_tela ( _cena ); break;
                // case Nome_fn.escolha_rapida: Fn_construtor_inverso.Escolha_rapida ( _cena ); break;



                case Nome_fn.encerrar_transicao: return Fn_construtor_inverso.CRIAR_nada_inverso();

                case Nome_fn.transicao_inicio: return Fn_construtor_inverso.CRIAR_transicao_inicio_inverso ( ); 
                case Nome_fn.transicao_final: return Fn_construtor_inverso.CRIAR_transicao_final_inverso ( ); 

                case Nome_fn.mudar_foco_camera_personagens:  return Fn_construtor_inverso.CRIAR_mudar_foco_camera_personagens_inverso (  _cena_texto, _auto , _screen_play ); /*DONE*/// FOCO


                /// referentes backgrounds 

                
                case Nome_fn.mudar_background: return Fn_construtor_inverso.CRIAR_mudar_background_inverso( _cena_texto, _auto , _screen_play ); /*DONE*/// FOCO

                

                // case Nome_fn.tremer_tela: Fn_construtor_inverso.Tremer_tela ( _cena ); break;
                // case Nome_fn.colocar_filtro_tela: Fn_construtor_inverso.Colocar_filtro_tela ( _cena ); break;
                // case Nome_fn.mover_background: Fn_construtor_inverso.Mover_background ( _cena ); break;

            /// referente ao personagens


                case Nome_fn.mudar_visibilidade_personagens: return Fn_construtor_inverso.CRIAR_mudar_visibilidade_personagens_inverso (  _cena_texto, _auto , _screen_play ); /*DONE*/// FOCO

                case Nome_fn.mudar_index_personagens: return Fn_construtor_inverso.CRIAR_mudar_index_personagens_inverso (  _cena_texto, _auto , _screen_play );  /*DONE*/// FOCO
                
                case Nome_fn.modificar_switch_MODO_personagens: return  Fn_construtor_inverso.CRIAR_modificar_switch_MODO_personagens_inverso (  _cena_texto, _auto , _screen_play );

                case Nome_fn.modificar_switch_personagens: return Fn_construtor_inverso.CRIAR_modificar_switch_personagens_inverso (  _cena_texto, _auto , _screen_play ); /*DONE*/// FOCO


                

                // case Nome_fn.rotacionar_personagem: Fn_construtor_inverso.Rotacionar_personagem (  _cena_texto, _auto , _screen_play ); break;
                // case Nome_fn.animar_personagem: Fn_construtor_inverso.Animar_personagem (  _cena_texto, _auto , _screen_play ); break; 
                // case Nome_fn.tremer_personagem: Fn_construtor_inverso.Tremer_personagem (  _cena_texto, _auto , _screen_play ); break;


                case Nome_fn.mudar_cor_personagens: return Fn_construtor_inverso.CRIAR_Mudar_cor_personagens_inverso (  _cena_texto, _auto , _screen_play ); /*DONE*/// FOCO

                //case Nome_fn.mudar_scale_personagem: Fn_construtor_inverso.Mudar_scale_personagem (  _cena_texto, _auto , _screen_play ); break;
            
                case Nome_fn.mudar_nome_display: return Fn_construtor_inverso.CRIAR_mudar_nomes_display_inverso  (  _cena_texto, _auto , _screen_play );  /*DONE*/// FOCO



            /// texto

                case Nome_fn.mudar_cor_pergaminho : return Fn_construtor_inverso.CRIAR_mudar_cor_pergaminho_inverso(   _auto  );

                case Nome_fn.resetar_text :return  Fn_construtor_inverso.CRIAR_nada_inverso();
    
                case Nome_fn.abaixar_texto: return Fn_construtor_inverso.CRIAR_abaixar_texto_inverso (  _cena_texto, _auto , _screen_play );/*DONE*/// FOCO
                case Nome_fn.levantar_texto: return Fn_construtor_inverso.CRIAR_levantar_texto_inverso (  _cena_texto, _auto , _screen_play );/*DONE*/// FOCO

                case Nome_fn.mudar_posicao_pergaminho: return Fn_construtor_inverso.CRIAR_mudar_posicao_pergaminho_inverso (  _cena_texto, _auto , _screen_play );/*DONE*/// FOCO

                // case Nome_fn.trocar_modelo_pergaminho: Fn_construtor_inverso.Trocar_modelo_pergaminho (  _cena_texto, _auto , _screen_play ); break;

                case Nome_fn.mudar_cor_texto_personagens: return Fn_construtor_inverso.CRIAR_mudar_cor_texto_personagens_inverso (  _cena_texto, _auto , _screen_play );/*DONE*/// FOCO

                //case Nome_fn.tremer_texto: Fn_construtor_inverso.Tremer_texto (  _cena_texto, _auto , _screen_play ); break;



                case Nome_fn.mudar_volume: return Fn_construtor_inverso.CRIAR_mudar_volume_cena_inverso (  _cena_texto, _auto , _screen_play ); /*DONE*/// FOCO



                default: throw new ArgumentException("fn " + nome_fn + " ainda nao esta feito em criar inverso");


            }



            return "";
        }

        public static string Construir_audio_inverso( string _cena_texto, char _auto , Screen_play _screen_play  ){


            char[] retorno_parte_1 = new char[ 8 ];

            retorno_parte_1[ 0 ] = _cena_texto[ 0 ] ;
            retorno_parte_1[ 1 ] = _cena_texto[ 1 ] ;
            retorno_parte_1[ 2 ] = _cena_texto[ 2 ] ;
            retorno_parte_1[ 3 ] = _cena_texto[ 3 ] ;


            retorno_parte_1[ 5 ] = _cena_texto[ 5 ]; // mod => pegar_audio

            retorno_parte_1[ 6 ] = _cena_texto[ 6 ];
            retorno_parte_1[ 7 ] = _cena_texto[ 7 ];



            Tipo_audio tipo_audio =  ( Tipo_audio ) ( ( int )retorno_parte_1[ 2 ] - 48 );

            int slot = ( ( int )retorno_parte_1[ 3 ] - 48 );

            Controlador_audio controlador_audio = Controlador_audio.Pegar_instancia( );


            string path_audio_atual = null ;


            if( tipo_audio == Tipo_audio.music ){

                path_audio_atual = _screen_play.audio_atual;

            } else if( tipo_audio == Tipo_audio.sfx ){


                return Fn_construtor_inverso.CRIAR_nada_inverso();



                // char[] path_audio_atual_char_arr = new char[ _cena_texto.Length - 8 ] ;

                // for( int c = 0 ; c < path_audio_atual_char_arr.Length ; c++ ){

                //         path_audio_atual_char_arr[ c ] = _cena_texto[ c + 8 ] ;

                // }

                // path_audio_atual = new string( path_audio_atual_char_arr );

                // Debug.Log("path sfx: " + path_audio_atual );

            }
            



        
            
            bool tem_loop = controlador_audio.Pegar_loop( tipo_audio , slot );
            char audio_loop = 'f'; if( tem_loop ) { audio_loop = 'f' ;}

            float modificador_volume = controlador_audio.Pegar_modificador_volume( tipo_audio );

            char  mod_volume =   ( char ) (( Convert.ToInt32( modificador_volume * 100f ) ) + 48 ) ;



            retorno_parte_1[ 4 ] = audio_loop ;
            retorno_parte_1[ 5 ] = mod_volume ;

            retorno_parte_1[ 6 ] =  ( char )  ( 500 +  48 )   ;
            retorno_parte_1[ 7 ] =  ( char )  ( 500 +  48 )   ;

            return ( new string( retorno_parte_1 ) + path_audio_atual );


            // cena_final_char_arr[ 0 ] = tipo;
            // cena_final_char_arr[ 1 ] = auto;
            // cena_final_char_arr[ 2 ] = tipo_audio;
            // cena_final_char_arr[ 3 ] = slot;

            // cena_final_char_arr[ 4 ] = loop;

            // cena_final_char_arr[ 5 ] = modificador_volume;
            // cena_final_char_arr[ 6 ] = tempo_down;
            // cena_final_char_arr[ 7 ] = tempo_up;
            
        }






        public static string Construir_choice_inverso( string _cena_texto, char _auto , Screen_play _screen_play  ){


            

            bool pode_voltar = ( _cena_texto[ 2 ] == 't' );

            if( pode_voltar ){

                Debug.Log("veio em pode voltar");

                char tipo_cena_volta = ( char ) ( ( int ) Tipo_cena.fn + 48 );
                char auto_volta = 't';
                char nome_fn_volta =  ( char ) (  ( int ) Nome_fn.nada + 48); 
                char[] retorno_char_volta  =   new char[]{ tipo_cena_volta , auto_volta, nome_fn_volta };

                return new string(  retorno_char_volta  );

            }





            char tipo_cena = ( char ) ( ( int ) Tipo_cena.fn + 48 );
            char auto = 'f';
            char nome_fn =  ( char ) (  ( int ) Nome_fn.bloquear_voltar_cenas + 48); 
            char[] retorno_char  =   new char[]{ tipo_cena , auto, nome_fn };
            return  new string( retorno_char );
            
            



            // int proxima_cena_id = ( _screen_play.cena_atual + 1 );

            // Cena proxima_cena = _screen_play.cenas[ proxima_cena_id ];

            // proxima_cena.pode_mudar_texto_inverso = false;



            // char tipo_cena = ( char ) ( ( int ) Tipo_cena.fn + 48 );
            // char auto = 'f';
            // char nome_fn =  ( char ) (  ( int ) Nome_fn.bloquear_voltar_cenas + 48); 
            // char[] retorno_char  =   new char[]{ tipo_cena , auto, nome_fn };
            // proxima_cena.cena_texto_inverso = new string( retorno_char );
            
            // return "";

            
        }
        public static string Construir_jump_inverso( string _cena_texto, char _auto , Screen_play _screen_play  ){



            char tipo_cena = ( char ) ( ( int ) Tipo_cena.fn + 48 );
            char auto = 'f';
            char nome_fn =  ( char ) (  ( int ) Nome_fn.bloquear_voltar_cenas + 48); 
            char[] retorno_char  =   new char[]{ tipo_cena , auto, nome_fn };

            return new string( retorno_char);


        }
        public static string Construir_pointer_inverso( string _cena_texto, char _auto , Screen_play _screen_play  ){

            
            char tipo_cena = ( char ) ( ( int ) Tipo_cena.fn + 48 );
            char auto = 'f';
            char nome_fn =  ( char ) (  ( int ) Nome_fn.bloquear_voltar_cenas + 48); 
            char[] retorno_char  =   new char[]{ tipo_cena , auto, nome_fn };

            return new string( retorno_char);


        }


    

}