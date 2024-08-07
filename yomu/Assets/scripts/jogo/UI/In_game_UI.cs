using System;
using UnityEngine;







public static  class In_game_UI {


    public static void Zerar(){

            pergaminho_esta_ativo = true;
            barra_esta_ativo = true;


    }




    
    public static  GameObject game_object = null;

    public static  Pergaminho_modelo_1 pergaminho = null;
    public static  Barra_superior_modelo_1 barra_superior = null;

    public static  UI_info info ;

    public static bool pergaminho_esta_ativo = true;
    public static bool barra_esta_ativo = true;

    


    public static void Iniciar ( bool _instantaneo = false , bool[] _partes = null ){

            // Zerar();


            // game_object = new GameObject("UI_pergaminho");

            // game_object.transform.SetParent(   Controlador_UI.Pegar_instancia().game_object.transform , false );

            // pergaminho = new Pergaminho_modelo_1( game_object.transform );
            // barra_superior = new Barra_superior_modelo_1( game_object.transform );

            // Controlador_tela_visual_novel.Pegar_instancia().pergaminho  =  pergaminho;
            // Controlador_tela_jogo.Pegar_instancia().pergaminho  =  pergaminho;

            // info = new UI_info(  game_object, Tipo_UI.in_game, Mudar_visibilidade, Esconder_UI  , Mostrar_UI );

            // Controlador_UI.Pegar_instancia().info = info ;
            // Controlador_UI.Pegar_instancia().UI_objeto_update = Update;
            // Controlador_UI.Pegar_instancia().UI_objeto_update();

            // Mudar_visibilidade( _partes , _instantaneo );

    
    }

    public static void Finalizar(){

            Mono_instancia.Destroy( game_object );
            Mono_instancia.Destroy( pergaminho.pergaminho_container );
            Mono_instancia.Destroy( barra_superior.game_object );

            game_object = null;
            pergaminho = null;
            barra_superior = null;

    }




    public static  void Mudar_visibilidade( bool[] _visibilidade_arr , bool _instantaneo ){

        // for( int  i = 0 ; i < _visibilidade_arr.Length ; i++ ){

        //     Debug.Log(  "index " + i  + " veio : " +  _visibilidade_arr[ i ]  ) ;


        // }


    //    Debug.LogError("instantanio: " + _instantaneo );


        if(   _visibilidade_arr[  ( int ) In_game_UI_partes.todas ]  ) {


            // so mostra 
            barra_superior.Mostrar( _instantaneo ); return; 

        } 



        if(   _visibilidade_arr[  ( int ) In_game_UI_partes.barra_superior ]  )  {  
    
            
            if( !barra_esta_ativo ) {  barra_superior.Mostrar( _instantaneo ) ; }
            barra_esta_ativo = true;

        } else { 

     
            if( barra_esta_ativo ) {

                 barra_superior.Esconder( _instantaneo );
            }

            barra_esta_ativo = false;
            
        }




        if(   _visibilidade_arr[  ( int ) In_game_UI_partes.pergaminho ]      )  {


               if( !pergaminho_esta_ativo ) { pergaminho.Mostrar( _instantaneo ) ; }  
                pergaminho_esta_ativo = true;

        } else { 


            if( pergaminho_esta_ativo ) { pergaminho.Esconder( _instantaneo );}  
            pergaminho_esta_ativo = false;
        
            
         }



    }

    public static  void Esconder_UI(){

        pergaminho.Esconder( _instantaneo : false );
        barra_superior.Esconder( _instantaneo : false );

    } 

    public static  void Mostrar_UI(){

        pergaminho.Mostrar( _instantaneo : false );
        barra_superior.Mostrar( _instantaneo : false );

    }




    public static void Update(){


        // acho que eles nunca vao estar ativos ao mesmo tempo

        //  if input => return  

           
           if( Update_icones() )  { Controlador_UI.Pegar_instancia().foi_ativado = true; return; }
           
           if( Update_choice() )  { Controlador_UI.Pegar_instancia().foi_ativado = true; return; }
           
           if( Update_conversa() )  { Controlador_UI.Pegar_instancia().foi_ativado = true; return; }


           

           
        

        return;

    }



    public static bool Update_icones(){



        Icone_barra[] icones = barra_superior.icones;

        int icone_index = 0;

        for ( icone_index = 0 ; icone_index < icones.Length ; icone_index++ ){

                Icone_barra icone = icones[ icone_index ];

                if( icone.esta_ativo ){

                    // icone ativo nao depende da posicao do mouse => se o icone voltar true vai ser dado como se ele nao existisse 

                    Update_Icone_barra( icone );

                    return true;

                }

        }


        for ( icone_index = 0 ; icone_index < icones.Length ; icone_index++ ){

                Icone_barra icone = icones[ icone_index ];

                if( icone.Checar_mouse() ){


                        barra_superior.Off_todos_icones( _index_para_ignorar : icone_index );
                        barra_superior.On_icone( icone_index );

                        if( Controlador_input.Get_down ( Key_code.mouse_left) ) {icone.ativacao_down = true; }
                        if( Controlador_input.Get_up ( Key_code.mouse_left) ) { icone.ativacao_up = true; }

                        if( icone.ativacao_down && icone.ativacao_up ) { 

                            icone.ativacao_down  = false ;
                            icone.ativacao_up = false;

                            icone.esta_ativo = true;
                            barra_superior.Off_todos_icones( );
                            Ativar_icone( icone.icone_nome );
                            
                        }

                        

                        return true;

                }

        }

        barra_superior.Off_todos_icones();


        return false;



    }


    public static  void Ativar_icone( Icone_barra_nome _nome ){

        switch( _nome ){

            case Icone_barra_nome. mapa:  Icone_barra_mapa.Criar (  game_object  ); break;
            case Icone_barra_nome. mochila:  Icone_barra_mochila.Criar (  game_object  ); break;
            default:  Debug.Log( "tipo ainda nao aceito: " + _nome.ToString() ); break;

        }


    }



public static  void Update_Icone_barra( Icone_barra _icone ){

    Icone_barra_nome nome = _icone.icone_nome;

    bool encerrar = false;

    switch( nome ){

        case Icone_barra_nome.mapa: encerrar =  Icone_barra_mapa.Update(); break;
        case Icone_barra_nome.mochila: encerrar =  Icone_barra_mochila.Update(); break;
        default: Debug.Log("tipo ainda nao aceito: " + nome.ToString() ); encerrar = true; break;


    }

    if( encerrar ){ _icone.esta_ativo = false; }

    


}






    public static  bool  Update_choice() {




            if( pergaminho.choices_concluida ){

                    pergaminho.choices_esta_ativa = false;
                    pergaminho.choices_concluida = false;
                    // BLOCO_visual_novel.Pegar_instancia().Mudar_modo_visual_novel( Modo_visual_novel.normal );
                    // Leitor_visual_novel.Pegar_instancia().Ler_cena("choice");
                    
                    return false ;

            }

            if(!pergaminho.choices_esta_ativa) { return false; } // inverteu


            bool mouse_is_click =  Controlador_input.Get_down( Key_code.mouse_left );

            float[] posicao_mouse = Controlador_dados.Pegar_instancia().posicao_mouse;
            


            for(int  i = 0;  i < pergaminho.possiveis_respostas.Length ;i++){

                    float[] area_choice =  pergaminho.choices_areas[i];

                    bool verificacao = false ; // Mat.Verificar_ponto_dentro_poligono( posicao_mouse, area_choice);

                    if(verificacao){
 

                            if(   mouse_is_click  ){

                                    //Visual_novel_dados visual_novel_dados = BLOCO_visual_novel.Pegar_instancia().visual_novel_dados;
                                    //int index_pergunta_atual = visual_novel_dados.choice_index_atual;


                                    Screen_play screen_play = BLOCO_visual_novel.Pegar_instancia().screen_play;

                                    int pergunta_id =  pergaminho.pergunta_index ; 
                                    pergaminho.pergunta_index = -1 ;

                                    screen_play.todas_as_respostas_dadas[ pergunta_id ] = i ;
                                
                                    Controlador_cursor.Pegar_instancia().Mudar_cursor( Cor_cursor.off ) ;

                                    pergaminho.Finalizar_choices() ;

                                    return true;
                            
                            }


                            Controlador_cursor.Pegar_instancia().Mudar_cursor( Cor_cursor.red );

                            return true ;


            }

            }

            Controlador_cursor.Pegar_instancia().Mudar_cursor(Cor_cursor.off);
            return true ;

    }








    public static  bool Update_conversa(){




            if(!pergaminho.blocos_conversas_esta_ativo) { return false; } // inverteu

            if( Controlador_input.Get_down( Key_code.esc ) ){

                Debug.Log("veio update conversa encerrar");
                pergaminho.Finalizar_conversas();
                //Controlador_conversas.Pegar_instancia().Encerrar_conversa();
                return true;


            }

  




            // if( pergaminho.blocos_conversas_esta_concluido ){

            //         pergaminho.blocos_conversas_esta_ativo = false;
            //         pergaminho.blocos_conversas_esta_concluido = false;
    
            //         return false ;

            // }


            bool mouse_is_click =  Controlador_input.Get_down( Key_code.mouse_left );

            float[] posicao_mouse = Controlador_dados.Pegar_instancia().posicao_mouse;
            float p_x = posicao_mouse[ 0 ] ; 
            float p_y = posicao_mouse[ 1 ]  -  pergaminho.pergaminho_texto.transform.localPosition[ 1 ] - 178f; 


            Display_texto_simples[] textos_display =  pergaminho.blocos_textos;


            


            for(int  i = 0;  i < textos_display.Length ;i++){

                    Display_texto_simples texto_display  =  textos_display[ i ];

                    float[] min_max_rect =  texto_display.min_max_rect ;



                    bool verificacao = Mat.Verificar_ponto_dentro_retangulo ( 
                        
                        p_x,
                        p_y,
                        min_max_rect  [ 0 ] ,
                        min_max_rect  [ 1 ] ,
                        min_max_rect  [ 2 ] ,
                        min_max_rect  [ 3 ]

                    );

                    if(verificacao){


                            if(   mouse_is_click  ){

                                    int numero_bloco = pergaminho.blocos_numeros[ i ];

                                    //Controlador_conversas.Pegar_instancia().Ler_bloco( numero_bloco );

                                    Controlador_cursor.Pegar_instancia().Mudar_cursor( Cor_cursor.off );

                                    pergaminho.Finalizar_conversas();

                                    return true;
                            
                            }

                            texto_display.Mudar_cor( Color.red );
                            Controlador_cursor.Pegar_instancia().Mudar_cursor(Cor_cursor.red);

                            while ( i < ( textos_display.Length - 1 ) ) {

                                    i++;
                                    textos_display[ i ].Mudar_cor( Color.black );

                            }

                            return true ;

                    }

                    textos_display[ i ].Mudar_cor( Color.black );


            }



            Controlador_cursor.Pegar_instancia().Mudar_cursor(Cor_cursor.off);
            return true ;





    }









}



