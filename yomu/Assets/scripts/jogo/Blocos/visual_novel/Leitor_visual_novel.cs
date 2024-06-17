using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Leitor_visual_novel{

   
  
        public static Leitor_visual_novel instancia;
        public static Leitor_visual_novel Pegar_instancia(){ return instancia; }


        public static Leitor_visual_novel Construir( BLOCO_visual_novel _bloco ){ 

            Leitor_visual_novel leitor = new Leitor_visual_novel(); 

                leitor.bloco_visual_novel = _bloco;
                
            instancia = leitor;
            return instancia;
            
        }

    
        public BLOCO_visual_novel bloco_visual_novel;

        

        public Cena[] cenas;

        public Screen_play screen_play;

        // public Visual_novel_dados visual_novel_dados; 

        //public string[] personagens_atuais = new string[10];

    


       // nome ruim 
    public void Colocar_dados( Screen_play _screen_play ){


            //  this.visual_novel_dados = _visual_novel_dados;

            this.screen_play = _screen_play;

            this.cenas = _screen_play.cenas;

            Ler_set( this.cenas[ 0 ].cena_texto );   
            Ler_cena( "start" );

            return;
            

    }





    public void Ler_cena( string _origem = "" ){

        // Geral.ClearLog();

        // Debug.Log("============");

        // Debug.Log("veio ler cena");


        
        screen_play.Aumentar_contador_cena();
        int cena_atual = screen_play.cena_atual;
        Cena cena = this.cenas[ cena_atual ];
        cena.cena_texto_inverso =  Cenas_inversas_construtor.Construir( screen_play );



        string cena_texto = cena.cena_texto;

        bool auto = (cena_texto[ 1 ] == 't');
        Tipo_cena tipo =   (Tipo_cena) ((int) cena_texto[0] - 48 );


        // Debug.Log("cena index: " + cena_atual );

        // Debug.Log( "cena: " + cena.cena_texto ) ;
        // Debug.Log("cena inversa: " + cena.cena_texto_inverso ) ;

        // Debug.Log(" tipo: " + tipo );
        



        Ativar_cena(  tipo  , cena_texto  );



        if( auto ){

            Ler_cena("auto");
            
        }



    }




    public void Ler_cena_inversa( string _origem = "" ){

        // Geral.ClearLog();

        int cena_atual = screen_play.cena_atual;

        if( cena_atual == 0 ) return;


        
        Cena cena = this.cenas [ cena_atual ] ;
        
        string cena_texto_inverso = cena.cena_texto_inverso;

        Debug.Log("veio ler cena inverso. Cena: " + cena_atual );
        Debug.Log("texto inverso: " + cena_texto_inverso );

        Tipo_cena tipo =   (Tipo_cena) ((int) cena_texto_inverso[ 0 ] -  48);

        
        bool auto = ( cena_texto_inverso[ 1 ] == 't' ) ;



        Ativar_cena(  tipo  , cena_texto_inverso  );

        if( cena_atual < 2 ){

            screen_play.cena_atual = 0;
            return; 

        }  
        
        screen_play.Diminuir_contador_cena(); // tem que ser no final. cena_atual esta no estado 2, cena inversa vai do 2 para o 1 e a cena que faz isso é a da propria cena atual. se dirar antes vai pegar como se estivesse em outro estado


        if( auto ){

            Ler_cena_inversa( "auto" );

        }


    }


    public void Ativar_cena( Tipo_cena _tipo , string _cena_texto){



        switch( _tipo ){

                case Tipo_cena.set: Ler_set( _cena_texto ); break;
                case Tipo_cena.ic: Ler_ic( _cena_texto ); break;
                case Tipo_cena.mov: Ler_mov( _cena_texto ); break;
                case Tipo_cena.text: Ler_text( _cena_texto ); break;



                case Tipo_cena.audio: Ler_audio( _cena_texto ); break;


                
                case Tipo_cena.choice: Ler_choice( _cena_texto ); break;
                case Tipo_cena.jump: Ler_jump( _cena_texto ); break;
                case Tipo_cena.pointer: Ler_pointer( _cena_texto ); break;
                case Tipo_cena.fn: Ler_fn( _cena_texto ); break;

                case Tipo_cena.end: Ler_end( _cena_texto ); break;

                default: throw new ArgumentException("");
        
        }

        return;


    }







    public void Ler_set ( string _cena ){



            Nome_script_visual_novel_start script_start = ( Nome_script_visual_novel_start ) ( int ) _cena[ 2 ];


            string[] blocos =  _cena.Split("&");


            string[] nomes = blocos[ 1 ].Split(",");

            string[] images_arr = blocos[ 2 ].Split("|");

            string[][] personagens_images = new string[ images_arr.Length ][];

            for( int personagem = 0 ;  personagem < images_arr.Length ; personagem++ ){

                        personagens_images[ personagem ] = images_arr[ personagem ].Split(",");

            }

            string[] perguntas = blocos[ 3 ].Split(",");

            string[] possiveis_respostas_blocos = blocos[ 4 ].Split("|");

            string[][] possiveis_respostas_arr = new string[ perguntas.Length ][];

            for( int pergunta = 0 ;  pergunta < perguntas.Length  ;pergunta ++ ){


                possiveis_respostas_arr[ pergunta ] = possiveis_respostas_blocos[ pergunta ].Split(",");

            }


            string[] pointers_arr = blocos[ 5 ].Split(",");

            int[] pointers_cenas_ids = new int[ pointers_arr.Length ];

            for( int pointer = 0 ; pointer < pointers_arr.Length ; pointer++){

                pointers_cenas_ids [ pointer ] = Convert.ToInt32( pointers_arr[ pointer ] );    

            }


            screen_play.nomes_personagens = nomes;
            screen_play.personagens_paths_imagens = personagens_images;
            screen_play.perguntas = perguntas;
            screen_play.possiveis_respostas = possiveis_respostas_arr;
            screen_play.todas_as_respostas_dadas = new int[ perguntas.Length ];


            for( int pergunta = 0 ; pergunta < perguntas.Length ; pergunta++ ){

                    screen_play.todas_as_respostas_dadas[ pergunta ] = -1;

            }


            string[] pointer_id_str = blocos[ 6 ].Split(",");


            screen_play.pointers_cenas_ids = pointers_cenas_ids;
            screen_play.pointer_id_str = pointer_id_str;








            bloco_visual_novel.controlador_personagens_visual_novel.Criar_personagens( nomes );



            int[] personagens_POR_index = new int[ nomes.Length ];

            int i_personagem = nomes.Length;

            for ( int personagem_POR_index = 0  ; personagem_POR_index < nomes.Length ;  personagem_POR_index++ ){


                    personagens_POR_index[ personagem_POR_index ]  = ( i_personagem - 1 ) ;
                    i_personagem--;
                    continue;
            }

            screen_play.personagens_POR_index = personagens_POR_index;



                
            return;

            

    }


    public void Ler_pointer( string _cena ){



            //   set sempre é responavel por resetar os valores   
            /*                 oque é       auto ( sempre true )      id_start       id ...      */
            //   esperado:      0            t                         '&'         's' + 't' + 'a' + 'r' ...

        return;

    }


    
    public void Ler_jump( string _cena ){


            
            //    set sempre é responavel por resetar os valores   
            /*                 oque é    auto    tem_jump_aut     id_jump_aut       obrigatorio      deafult_id     tem_script     id script       run_)time_id_cena         padrao:     (    index_pergunta        resposta_valor_index      jump_cena_index   )          */
            //   esperado:      0          t         't'/'f'          id_cena          'f'/ 't'          'id'         't'/'f'        '0'              'id'                                   '\u0000'               '\u0000'               '\u0000'                                


            

            char[] args = _cena.ToCharArray();


            int cena_id_jump = ( ( int )args[ 8 ]  - 48 )  ;



            if( cena_id_jump > 0) {

                Ativar_jump( cena_id_jump ); // se tem vai direto

                return;

            }


            bool tem_jump_automatico = ( args[ 2 ] == 't' ) ;


            if( tem_jump_automatico ){

                   Debug.Log("nao era para vir aqui");


                    int  index_jump_automatico = ( int ) ( args[ 3 ]  - 48 ) ;

                    int  index_jump_cena_automatico = screen_play.pointers_cenas_ids[  index_jump_automatico  ];

                    Ativar_jump( index_jump_cena_automatico );

                    //Ir_cena( index_jump_cena_automatico );

                    return;

            }


            bool tem_script = ( args[ 6 ] == 't' );

            if( tem_script ){

                int script_id = ( int ) args [ 7 ] - 48 ;
                if( script_id < 0) { Debug.LogError( "script veio com numero nao aceitavel. veio: " + script_id );throw new ArgumentException("");}

                Nome_script_visual_novel_run script = ( Nome_script_visual_novel_run ) script_id;

                string pointer = Script_visual_novel_run.Ativar_script( script );
                int cena_id = screen_play.Pegar_cena_id_por_pointer( pointer , script_id);

                Ativar_jump( cena_id );

                return;

            }

            





            bool eh_obrigatorio =  ( args[ 4 ] == 't' );
            int default_id_jump = ( ( int ) args[ 5 ] -  48  );

            
            




            int numero_opcoes = ( args.Length -  8  )  / 3 ; 

            // -1 => nada 




            int[] todas_as_respostas_dadas  =  screen_play.todas_as_respostas_dadas;


            for(  int index_opcao = 0 ;   index_opcao < numero_opcoes  ; index_opcao++  ){



                        int index_jump_caso_passe = (( int ) args[ ( index_opcao * 3 ) + 9  ]  - 48 );
                        
                        int index_pergunta =  ( ( int )  args[ ( index_opcao * 3 ) + 9 + 1 ]  - 48  );


                        int index_resposta_necessaria =  (( int ) args[ ( index_opcao * 3 ) + 9 + 2  ] - 48 );


                        int index_cena_caso_passe = screen_play.pointers_cenas_ids[  index_jump_caso_passe  ];

                        int index_resposta_dada_para_a_pergunta = todas_as_respostas_dadas [ index_pergunta ] ;


                        if( index_resposta_dada_para_a_pergunta == -1  ) continue;

                        if( index_resposta_dada_para_a_pergunta == -1 ) {  Debug.LogError("jump pediu resposta para uma pergunta que nao foi respondida") ; throw new ArgumentException(""); }

                        bool passou =  (  index_resposta_dada_para_a_pergunta == index_resposta_necessaria ); 

                        if( passou ) {

                                Ativar_jump( index_cena_caso_passe ); //Ir_cena( index_cena_caso_passe );
                                return;
                                
                        }





            }



            if(  default_id_jump  > -1  ){


                    Debug.Log("veio aqui?") ;
                    Debug.Log("default: " +  default_id_jump);

                    int default_id_cena = screen_play.pointers_cenas_ids[  default_id_jump  ] ;

                    Ativar_jump( default_id_cena ) ;

                    // Ir_cena( default_id_cena );
                    return ;

            }

            Debug.Log("saiu do loop");

            if( eh_obrigatorio ){

                    Debug.LogError("eh obrigatorio mas nenhum caminho pode ser seguido");
                    throw new ArgumentException("");

            }

            Ler_cena ("auto");
            return;







    }




    public void Ler_ic ( string _cena ){



            //    set sempre é responavel por resetar os valores   
            /*                 oque é       auto       index_imagem_personagem_1     index_imagem_personagem_1    */
            //   esperado:      0            t                    ;                           8  
        


            int numero_personagens = ( _cena.Length - 2) / 2;

            string[] imagens_paths = new string[ numero_personagens ];

            int[] path_localizadores  = new int[ numero_personagens ];

            // nada => imagens_path => null e path_id = 0

            int personagem_index;

            Personagem_dados_visual_novel[] personagens_dados = bloco_visual_novel.controlador_personagens_visual_novel.personagens_dados;

            for( personagem_index = 0; personagem_index < numero_personagens ; personagem_index++ ){

                    char personagem_id_char = _cena[  ( personagem_index * 2 ) + 2 ];
                    char path_id_char =  _cena[  ( personagem_index * 2 ) + 2 + 1];

                    int personagem_id = ( int ) personagem_id_char - 48;
                    int path_id = ( int ) path_id_char - 48 ;

                    string nova_imagem_path =  screen_play.personagens_paths_imagens [ personagem_id ] [ path_id ];
                    
                    Personagem_dados_visual_novel personagem = personagens_dados[ personagem_id ];

                    if(nova_imagem_path == "0") continue;

                    string path_final = "images/in_game/personagens/" + ( personagem.nome ) + "/" + nova_imagem_path  ;

                    Sprite nova_imagem = Resources.Load<Sprite>(path_final);
                    if(nova_imagem == null) throw new ArgumentException("nao foi encontrado imagem personagem. path: " + path_final);

                    Rect rect_antigo = personagem.rect_transform.rect;
                    Rect rect_novo = nova_imagem.rect;

                    if(   ( rect_antigo.width != rect_novo.width ) ||  ( rect_antigo.height != rect_novo.height )  ){

                        Geral.Resize( personagem.imagem_game_object ,  rect_novo.width, rect_novo.height );
                    }


                    personagem.image.sprite = nova_imagem;


                    personagem.path_localizador_imagem_atual = path_id;




            }


            

            return;

        
    }
     




    public void Ler_mov ( string _cena ){



        /*

                ta indo muito rapido 

        */



        //    TIPO 0:  
        /*                 oque é       auto       tipo        char_id           sinal         per_1_new x_px    ...    */
        //   esperado:      0            t          0             id          '48'/'49'         '\u01E0'            .. '

        //  sinal 
        //   1d: '48' => 0 => positivo
        //       '49' => 1 => negativo
        //
        //  2d 
        //       '48' =>  0 => x e y positivos
        //       '49' =>  1 => x e y negativos
        //       '50' =>  2 => x positivo y negativo 
        //       '51' =>  3 => x negativo y positivo   
        //
        //    TIPO 1:
        /*                 oque é       auto       tipo     per_1_new x_px       per_1_new Y_pX   */ 
        //   esperado:      0            t          1          '\u01E0'            '\u01E0'


        // se o valor vier como char.MAX nao é para ler o valor 

        
        bool auto = ( _cena[ 1 ] == 't' );

        int tipo =  _cena[ 2 ] - 48; 


        int index_inicial = 3;

        int personagem_index;

        int numero_personagens;

        int personagem_numero;




        Personagem_dados_visual_novel[] personagens_dados = bloco_visual_novel.controlador_personagens_visual_novel.personagens_dados;




        if( tipo == 0 ){


                numero_personagens = ( _cena.Length - index_inicial ) / 3 ;

                for(  personagem_numero = 0  ; personagem_numero < numero_personagens ; personagem_numero++  ){



                            personagem_index = ( int ) (_cena [  index_inicial + (personagem_numero * 3 )  ] - 48 );

                            Personagem_dados_visual_novel personagem = personagens_dados[ personagem_index ];


                            int sign = 1;
                            bool eh_negativo =  _cena[ index_inicial + (personagem_numero * 3 ) + 1  ] == '1';
                            if ( eh_negativo ){ sign = -1; }

                            

                            char px_char = _cena [  index_inicial + (personagem_numero * 3 )  + 2];

                            int px = (int) px_char - 48;
                            if( px == -1 ) continue;

                            px *= sign;

                            float novo_X = (float) px;

                            float Y_atual = personagem.posicao[ 1 ];
                            
                            bloco_visual_novel.controlador_personagens_visual_novel.Mover_char(  personagem ,  novo_X ,  Y_atual ); continue;

                }

                return;

        }




        numero_personagens = (_cena.Length - index_inicial) / 2 ;

        for(  personagem_numero = 0  ; personagem_numero < numero_personagens ; personagem_numero += 4 ){


                personagem_index = ( char ) (_cena [  index_inicial + ( personagem_numero * 4 )  ]  - 48 ) ;

                Personagem_dados_visual_novel personagem = personagens_dados[ personagem_index ];

                char sign = _cena[ index_inicial + (personagem_numero * 4 ) + 1  ];

                int sign_x =1;
                int sign_y =1;

                switch( sign ){

                    case '0': sign_x = 1; sign_y = 1 ;break;
                    case '1': sign_x = -1; sign_y = -1 ;break;
                    case '2': sign_x = 1; sign_y = -1 ;break;
                    case '3': sign_x = -1; sign_y = 1 ;break;
                    

                }


                int px_X = ( int ) _cena [  index_inicial + ( personagem_index * 4 ) + 2 ] -48;
                int px_Y = ( int ) _cena [  index_inicial + ( personagem_index * 4 ) + +3] - 48;

       


                bool ignorar_X = (  px_X >  5000  );
                bool ignorar_Y = (  px_Y >  5000  );

                if( ignorar_X && ignorar_Y ) continue;


                float novo_X = ( float ) ( px_X * sign_x );
                float novo_Y = ( float ) ( px_Y * sign_y );



                if( ignorar_X ) { novo_X = personagem.posicao[ 0 ]; }
                if( ignorar_Y ) { novo_Y = personagem.posicao[ 1 ]; }

            
                bloco_visual_novel.controlador_personagens_visual_novel.Mover_char(  personagem ,  novo_X ,  novo_Y ); continue;

        }


        return;


        
    }





    public void Ler_text (string _cena){


        //  cor texto, cor_pergaminh, tipo pergaminho e voice vao estar em text no nao compilado e vao ser separados na compilacao
      
        /*                 oque é       auto       tipo     personagem     cor-id         forcar_modelo_construcao            texto   */ 
        //   esperado:      0            t          1           3          'id'                 'id'            's' + 't' + 'a' + 'r' + 't' ...

        /* TIPOS:

          0 => cria novo bloco
          1 => continua na mesma linha
          2 => cria texto em baixo


          TIPOS_CONSTRUCAO:

          0 => default
          1=> instantaneo

        */



       bool verificacao_texto_pergaminho = bloco_visual_novel.controlador_tela_visual_novel.pergaminho.Aceita_clicks();

        if(  !verificacao_texto_pergaminho  ){

             screen_play.Diminuir_contador_cena();
             return;

        }

        bloco_visual_novel.controlador_tela_visual_novel.pergaminho.pergaminho_texto.SetActive(true);

        if(bloco_visual_novel.controlador_tela_visual_novel.pergaminho.pergaminho_is_abaixado) bloco_visual_novel.controlador_tela_visual_novel.pergaminho.Levantar_pergaminho();


        int tipo_texto =   ( ( int ) _cena [ 2 ]  - 48 ) ; 



        int personagem_index =   ( ( int ) _cena [ 3 ]  - 48 ) ;
        int cor_id_text =   ( ( int ) _cena [ 4 ]  - 48 ) ; 
        int tipo_construcao_id = ( ( int ) _cena [ 5 ]  - 48 ) ;


        Tipo_construcao_texto tipo_construcao = Tipo_construcao_texto.config_default;

        switch( tipo_construcao_id ){

            case 0 : tipo_construcao = Tipo_construcao_texto.config_default; break;
            case 1 : tipo_construcao = Tipo_construcao_texto.instant; break;
            default: throw new ArgumentException("nao veio tipo aceito. veio: " + tipo_construcao_id );
            
        }

        int numero_caracteres_texto = _cena.Length - 6;

        char[] texto_char_arr = new char[  numero_caracteres_texto  ];


        for( int index_texto = 0 ;  index_texto < numero_caracteres_texto ; index_texto++  ){

                texto_char_arr[ index_texto ] = _cena[ index_texto + 6 ];

        }

        string texto = new string ( texto_char_arr );


        screen_play.personagem_texto_atual = personagem_index;
        screen_play.tipo_texto = tipo_texto;



        switch ( tipo_texto ){

            case 0: screen_play.texto_atual = texto;  break;
            case 1:  screen_play.texto_atual += ( " " +  texto) ; break;
            case 2:  screen_play.texto_atual += ( "\r\n  " +  texto);  break;
            default: throw new ArgumentException("");

        }

        
        
        //Personagem_dados_visual_novel[] personagens_dados = null;
        Personagem_dados_visual_novel personagem = null;
        


        if( personagem_index > 49 ){

            personagem = bloco_visual_novel.controlador_personagens_visual_novel.extras_dados[ ( personagem_index - 50 ) ];

        } else {

            personagem =  bloco_visual_novel.controlador_personagens_visual_novel.personagens_dados[ personagem_index ];
             
        }


        string  nome_display =  personagem.nome_display;
        screen_play.nome_display = nome_display;


        if(  screen_play.is_highlight_activate ) {

                bloco_visual_novel.controlador_personagens_visual_novel.Aplicar_highlight_todos_personagens( _index_personagem_foco: personagem_index ) ;
            
        } 

        
        Color cor =  personagem.cor_texto_atual;
        int nome_cor_personagem_id =  personagem.cor_texto_atual_id ;


        if( cor_id_text != 0 ) {

                Nome_cor nome_cor = ( Nome_cor) cor_id_text;

                cor = Cores.Pegar_cor( nome_cor );
                nome_cor_personagem_id = cor_id_text;
            
        }

        screen_play.cor_texto_atual_id = ( int ) nome_cor_personagem_id;




        bloco_visual_novel.controlador_tela_visual_novel.pergaminho.Escrever(  _texto: texto,  _personagem: nome_display , _cor: cor ,  _tipo: tipo_texto, _tipo_construcao: tipo_construcao );

        return;
    

    }




    public void Ler_choice ( string _cena ){
         
        
        /*                 oque é       auto(sempre falso)          pode voltar         tipo            index_pergunta             pergunta_id_inicio     possivel resposta_id_1   ... */ 
        //   esperado:      0                f                         t/f            'tipo'               'id'                          'id'               '5' 

        //  choice precisa ir para o construtor inverso para pegar o cena[2] paraver se pode voltar a escolha



        char[] cena_caracteres = _cena.ToCharArray();

        

        int numero_de_possiveis_respostas = cena_caracteres.Length - 5;

        bool pode_voltar =  (  cena_caracteres[ 2 ] == 't' );

        int tipo =   ( ( int ) cena_caracteres[ 3 ] - 48);

        int pergunta_index =    ( ( int ) cena_caracteres[ 4 ] - 48 );




        string pergunta = screen_play.perguntas[ pergunta_index ];


        string[] possiveis_respostas = screen_play.possiveis_respostas[ pergunta_index ];


//        foreach(  string resposta in possiveis_respostas )Debug.Log( "p. resposta: " + resposta );


        // depois posso colocar aqui algo para bloquear.



        bloco_visual_novel.controlador_tela_visual_novel.pergaminho.Iniciar_choices( _pergunta: pergunta, _pergunta_index: pergunta_index , _possiveis_respostas: possiveis_respostas );

        

        bloco_visual_novel.Mudar_modo_visual_novel ( Modo_visual_novel.choice );

            return;


    }




    public void Ler_fn ( string  _cena ){


            
              
        //   esperado:      0            f            nome_funcao_char       

        //  split( "&" ) => pode ignorar o primeiro em [ 0 ] 
        // fn pode nao deixar voltar também, tem que enviar ela na cena inversa


        
        char nome_char = _cena[ 2 ];
        Nome_fn nome_fn =  (Nome_fn)  ( (int)  nome_char - 48 );




        switch( nome_fn ){


                case Nome_fn.nada: break;

                

            /// mudancas grandes

                
                case Nome_fn.iniciar_animacao: Fn_methods.Iniciar_animacao ( _cena ); break;
                case Nome_fn.iniciar_modo_comic: Fn_methods.Iniciar_modo_comic ( _cena ); break;

            /// logica

                
                case Nome_fn.bloquear_voltar_cenas: Fn_methods.Bloquear_voltar_cenas(); break;
                case Nome_fn.bloquear_passar_cenas: Fn_methods.Bloquear_passar_cenas(); break;
                case Nome_fn.bloquear_cenas: Fn_methods.Bloquear_cenas( _cena ); break;



            /// criar_coisas_tela

                case Nome_fn.criar_objeto: Fn_methods.Criar_objeto ( _cena ); break;
                case Nome_fn.modificar_objeto: Fn_methods.Modificar_objeto ( _cena ); break;
                case Nome_fn.rotacionar_objeto: Fn_methods.Rotacionar_objeto ( _cena ); break;

                case Nome_fn.colocar_itens_para_pegar: Fn_methods.Colocar_itens_para_pegar ( _cena ); break;
                case Nome_fn.mostrar_mensagem: Fn_methods.Mostrar_mensagem ( _cena ); break;
                
                case Nome_fn.zoom_tela: Fn_methods.Zoom_tela ( _cena ); break;
                case Nome_fn.mudar_foco_camera_personagens: Fn_methods.Mudar_foco_camera_personagens ( _cena ); break;
                
                case Nome_fn.mudar_cor_tela: Fn_methods.Mudar_cor_tela ( _cena ); break;
                case Nome_fn.escolha_rapida: Fn_methods.Escolha_rapida ( _cena ); break;


                case Nome_fn.transicao_inicio: Fn_methods.Transicao ( "inicio" ,  _cena ); break;
                case Nome_fn.transicao_final: Fn_methods.Transicao ( "final" , _cena ); break;


                case Nome_fn.encerrar_transicao: bloco_visual_novel.controlador_tela_visual_novel.Encerrar_transicao(); break;


                /// referentes backgrounds 

                //case Nome_fn.mudar_foco_background: Fn_methods.Flip_foco ( _cena ); break; // vai para mudar background
                case Nome_fn.mudar_background: Fn_methods.Mudar_background ( _cena ); break;

                //case Nome_fn.mudar_modo_tela: Fn_methods.Mudar_modo_tela ( _cena ); break;

                case Nome_fn.tremer_tela: Fn_methods.Tremer_tela ( _cena ); break;
                case Nome_fn.colocar_filtro_tela: Fn_methods.Colocar_filtro_tela ( _cena ); break;
                case Nome_fn.mover_background: Fn_methods.Mover_background ( _cena ); break;

            /// referente ao personagens


                case Nome_fn.mudar_visibilidade_personagens:Fn_methods.Mudar_visibilidade_personagens ( _cena ); break; 

                case Nome_fn.mudar_index_personagens: Fn_methods.Mudar_index_personagens ( _cena ); break;
                
                case Nome_fn.modificar_switch_MODO_personagens: Fn_methods.Modificar_switch_MODO_personagens ( _cena ); break;

                case Nome_fn.modificar_switch_personagens: Fn_methods.Modificar_switch_personagens ( _cena ); break;
                

                case Nome_fn.rotacionar_personagem: Fn_methods.Rotacionar_personagem ( _cena ); break;
                case Nome_fn.animar_personagem: Fn_methods.Animar_personagem ( _cena ); break; 
                case Nome_fn.tremer_personagem: Fn_methods.Tremer_personagem ( _cena ); break;


                case Nome_fn.mudar_cor_personagens: Fn_methods.Mudar_cor_personagens ( _cena ); break;

                case Nome_fn.mudar_scale_personagem: Fn_methods.Mudar_scale_personagem ( _cena ); break;
                case Nome_fn.mudar_nome_display: Fn_methods.Mudar_nome_display ( _cena ); break;



            /// texto

                case Nome_fn.resetar_text : Fn_methods.Resetar_text( _cena );break;
                case Nome_fn.mudar_cor_pergaminho : Fn_methods.Mudar_cor_pergaminho( _cena ); break;
    
                case Nome_fn.abaixar_texto: Fn_methods.Abaixar_texto (); break; 
                case Nome_fn.levantar_texto: Fn_methods.Levantar_texto ( ); break;
                case Nome_fn.mudar_posicao_pergaminho: Fn_methods.Mudar_posicao_pergaminho ( _cena ); break;
                case Nome_fn.trocar_modelo_pergaminho: Fn_methods.Trocar_modelo_pergaminho ( _cena ); break;



                case Nome_fn.mudar_cor_texto_personagens: Fn_methods.Mudar_cor_texto_personagens ( _cena ); break;
                case Nome_fn.tremer_texto: Fn_methods.Tremer_texto ( _cena ); break;



                case Nome_fn.mudar_volume: Fn_methods.Mudar_volume_cena ( _cena ); break;



                default: throw new ArgumentException("fn_name nao foi encontrado, veio :" + nome_fn);
           
        }

         
        return;

        

    }


        public void Ler_audio ( string _cena){


        

            //   set sempre é responavel por resetar os valores    
            /*                 oque é       auto                tipo         slot          tem repeticao          modificador volume            tempo_transicao_ms TIRAR         tempo_transicao_ms colocar              path                 */ 
            //   esperado:      0            t                    5          '\u0001'                 t/f                    '\uaaaa'                           '\uaaaa'                         '\uaaaa'                   's' + 't' +  'a'  + 'r' ......
            //   path sempre comeca no [ 8 ]
            //   mod volume vai ser 0-100
       



            Tipo_audio tipo =  ( Tipo_audio ) ( ( int ) _cena[ 2 ]  - 48 );



            int slot =  (( int ) _cena[ 3 ]  - 48 ); 


            bool loop = ( _cena[ 4 ] == 't' ) ;  


            float modificador_volume =  Convert.ToSingle( ( ( int ) _cena[ 5 ]  - 48 )  )  /  100f  ;


            float tempo_transicao_tirar_ms = Convert.ToSingle(  (( int ) _cena[ 6 ] - 48 ) ) ;


            float  tempo_transicao_colocar_ms = Convert.ToSingle( ( ( int ) _cena[ 7 ]  - 48 ) ) ;

            char[] path_char_arr = new char[ _cena.Length - 8 ];

            for( int i = 0 ; i < path_char_arr.Length ; i++ ){

                path_char_arr[ i ] = _cena[ i + 8 ];

            }

            string path = new string( path_char_arr );






            string path_completo = null ;




            if( tipo == Tipo_audio.sfx ){


                    path_completo  = "audio/jogo/sfx/" + path ;
                    Controlador_audio.Pegar_instancia().Acrecentar_sfx( path_completo , modificador_volume ) ;

                    return;


            } 

            
            if( tipo == Tipo_audio.music ){

                    screen_play.audio_atual = path;

                    if( path == "0"){
                            
                            Controlador_audio.Pegar_instancia().Stop_music( slot , tempo_transicao_tirar_ms);
                            return;
                        
                    } 


                    path_completo = "audio/jogo/music/" + path;

                    Controlador_audio.Pegar_instancia().Start_music( slot ,  path_completo,  tempo_transicao_tirar_ms, tempo_transicao_colocar_ms, modificador_volume );



            } else

            if(tipo == Tipo_audio.voice ){

            // Controlador_audio.Pegar_instancia() ;

            }

            

            return;

            

        }


        public void Ler_end ( string _cena){


                screen_play.esta_ativo = false;


                bloco_visual_novel.controlador_tela_visual_novel.pergaminho.Resetar();

            
                //    set sempre é responavel por resetar os valores                
                
                /*

                            tipo_cena , 
                            auto ,
                            script_end_id ,
                            nome_cena_sequencia_id ,
                            tem_transicao_char  
                
                */



                bool tem_screen_play_sequencia =  ( _cena [ 2 ] == 't' );

                bool screen_play_sequencia_tem_transicao =  ( _cena [ 3 ] == 't' ) ;

                Nome_script_visual_novel_end script_end =   ( Nome_script_visual_novel_end )  ( ( int ) _cena[ 2 ] - 48 ) ;
                Nome_screen_play nome_screen_play_sequencia =     ( Nome_screen_play )   ( ( int ) _cena [ 3 ] - 48 ) ;


                if( script_end  != Nome_script_visual_novel_end.nada ) {

                    // isso poder ser ou pego por reflection ou criar um formato unico para usar somente strings 
                    Scripts_visual_novel_end.Ativar_script( script_end , bloco_visual_novel.screen_play );

                }



                // ** nao existe mais 
                // if( nome_screen_play_sequencia != Nome_screen_play.nada )
                //     {    
                //         bloco_visual_novel.Iniciar_screen_play_por_end( nome_screen_play_sequencia ); 
                //         return; 
                //     }

                    

                Req_transicao req_transicao = new Req_transicao( Tipo_troca_bloco.OUT  ) ;
                req_transicao.tipo_transicao = Tipo_transicao.instantaneo;
                bloco_visual_novel.dados_blocos.req_transicao = req_transicao;



                return;


        }




        


        public string[] Pegar_personagens(  string _linha, int _index_inicial , int _index_final = -1 ){



                int numero_personagens = (_linha.Length - _index_inicial );

                if( _index_final < 0 ) _index_final = numero_personagens;

                string[] personagens_nomes = new string[ numero_personagens ];


            
                for( int personagem_index = 0; personagem_index < numero_personagens ; personagem_index++ ){


                        char personagem_char_id = _linha[ _index_inicial  + personagem_index  ];

                        int personagem_id =  Transformar_index_char_TO_int( personagem_char_id );

                        string personagem_nome =  screen_play.nomes_personagens [ personagem_id ];

                        personagens_nomes[ personagem_index ] = personagem_nome;


                }

                return personagens_nomes;

        }





        public int Transformar_index_char_TO_int ( char _char ){


                int personagem_int = (int) _char ;
                int retorno = personagem_int - 48 ;// 48 == '0';
                return retorno;


        }



        public  void Ir_cena( int _cena ){

                screen_play.Setar_contador_cena( _cena );
                Ler_cena("jump");
                return;

        }


        public void Ativar_jump( int _id_cena_jump ){

                Cena cena_pointer = screen_play.cenas[ _id_cena_jump ];

                int index_atual = screen_play.cena_atual;


                //   [ jump :  ]
                


                ///  se o jump nao for o primeiro vai ficar com buracos
                
                ///  c c c c j x x x x x p c c c c
                


                char[] jump_inverso = new char[]{

                        ( char ) (  (int) Tipo_cena.fn  + 48 ),
                        't',
                        ( char ) ( ( int ) Nome_fn.nada + 48  )

                };


                screen_play.cenas[ index_atual ].cena_texto_inverso  =  new string( jump_inverso )  ; // jump




                char[] pointer_reverso = new char[]{

                    ( char ) (  (int) Tipo_cena.jump  + 48 ),
                    'f',
                    '0',
                    '0',
                    '0',
                    '0',
                    '0',
                    '0', 
                    (( char ) (index_atual  +  48  + 1  ) ),


                };

                cena_pointer.cena_texto_inverso = new string( pointer_reverso ); // pointer inverso
               // cena_pointer.pode_mudar_texto_inverso = false ;

                screen_play.Setar_contador_cena( _id_cena_jump );

                //Ler_cena("jump");
                return;



        }







}
