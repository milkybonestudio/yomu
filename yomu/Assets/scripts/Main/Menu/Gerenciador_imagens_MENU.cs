using UnityEngine;

public static class Gerenciador_imagens_MENU {

        // --- 

        public static  Sprite[] sprites_background;
        public static  string[] sprites_backgrounds_nomes;


        public static  Sprite[] sprites_interativos;
        public static  string[] sprites_interativos_nomes;


        public static  Sprite[] sprites_objetos;
        public static  string[] sprites_objetos_nomes;


        public static  Sprite[] sprites_UI; // botoes
        public static  string[] sprites_UI_nomes;



        public static  byte[][]  pngs_galeria_previa;
        public static  byte[][]  pngs_personagens_previa;
        



        // *** formato : [ tipo menu ( 2 bytes) ] => pointer localizador_1 => [ poiner_localizador_1 ( 4 bytes ) ]  => poiner inicial imagens background 
        //                                                                    [ poiner_localizador_1 ( 4 bytes ) + 4 ] => poiner inicial imagens interativos
        //                                                                    [ poiner_localizador_1 ( 4 bytes ) + 8 ] => pointer numero de imagens estaticas( 2 bytes ) => pointer inicial imagens estaticas

        public static byte[] localizador_imagens;
        public static  MODULO__desmembrador_de_arquivo desmembrador_de_arquivo;




        public static Sprite Pegar_sprite_background( int _background_id ){

                int localizador = Pegar_id_unico_background( _background_id );
                byte[] png = desmembrador_de_arquivo.Pegar_dados_por_localizador( localizador );
                Sprite sprite = SPRITE.Transformar_png_TO_sprite( png );
                return sprite;

        }


        public static Sprite Pegar_sprite_interativo( int _interativo_id ){

                int localizador = Pegar_id_unico_interativo( _interativo_id );
                byte[] png = desmembrador_de_arquivo.Pegar_dados_por_localizador( localizador );
                Sprite sprite = SPRITE.Transformar_png_TO_sprite( png );
                return sprite;

        }


        public static Sprite Pegar_sprite_objeto_estatico( int _objeto_estatico_id ){

                int localizador = Pegar_id_unico_objeto_estatico( _objeto_estatico_id );
                byte[] png = desmembrador_de_arquivo.Pegar_dados_por_localizador( localizador );
                Sprite sprite = SPRITE.Transformar_png_TO_sprite( png );
                return sprite;

        }

        

        private static Sprite Pegar_sprite( int _localizador  , int _ponto_inicial , int _length  ){

                byte[] dados = desmembrador_de_arquivo.Pegar_dados( _localizador, _ponto_inicial, _length );
                Sprite retorno = SPRITE.Transformar_png_TO_sprite( dados );
                return retorno;

        }



        static Gerenciador_imagens_MENU(){

                localizador_imagens = System.IO.File.ReadAllBytes( Paths_sistema.path_arquivo__localizador__menu_imagens );
                desmembrador_de_arquivo  =  new MODULO__desmembrador_de_arquivo( 
                                                                                                        _gerenciador_nome: "",
                                                                                                        _path_arquivo: Paths_sistema.path_arquivo__dados_estaticos__uso_parcial__menu_imagens,
                                                                                                        _numero_inicial_de_slots: 50
                                                                                                );
                return;
        }


        public static void Liberar_dados(){

                throw new System.Exception("tem que fazer");

        }


        public static  void Carregar_imagens( Dados_menu _dados ){


                // ** tem quando for pedir as imagens tem que leva em conta que cada tipo de menu vai comecar m um lugar diferente do localizador

                int ponto_inicial = 0;

                // --- CARREGAR SAVES E PRINTS COMPRIMIDAS



                // --- PEGA POINTERS

                Tipo_menu_background tipo_menu = _dados.tipo_menu_background;

                
                int pointer_personagens_icones = 0;
                pointer_personagens_icones += ( ( int ) localizador_imagens[ ( ( int ) tipo_menu ) + 0 + 0 ] << 8 );
                pointer_personagens_icones += ( ( int ) localizador_imagens[ ( ( int ) tipo_menu ) + 0 + 1 ] << 0 );

                // depende da lingua depois
                int pointer_inicio_UI = 0;
                pointer_inicio_UI += ( ( int ) localizador_imagens[ ( ( int ) tipo_menu ) + 2 + 0 ] << 8 );
                pointer_inicio_UI += ( ( int ) localizador_imagens[ ( ( int ) tipo_menu ) + 2 + 1 ] << 0 );



                // --- PEGA POINTER PARA O TIPO DE MENU
                int pointer_interno_inicial = 0;
                pointer_interno_inicial += ( ( int ) localizador_imagens[ ( ( int ) tipo_menu ) + 4 + 0 ] << 8 );
                pointer_interno_inicial += ( ( int ) localizador_imagens[ ( ( int ) tipo_menu ) + 4 + 1 ] << 0 );

                // --- PEGA NUEMRO 

                int numero_backgrounds =  ( int ) localizador_imagens[ ( ( int ) pointer_interno_inicial ) + 0 ]  ;
                pointer_interno_inicial++;

                int numero_interativos =  ( int ) localizador_imagens[ ( ( int ) pointer_interno_inicial ) + 1 ]  ;
                pointer_interno_inicial++;

                int numero_objetos     =  ( int ) localizador_imagens[ ( ( int ) pointer_interno_inicial ) + 2 ]  ;
                pointer_interno_inicial++;


                // --- CRIA SLOTS

                sprites_background = new Sprite[ numero_backgrounds ];
                sprites_backgrounds_nomes = new string[ numero_backgrounds ];


                sprites_interativos = new Sprite[ numero_interativos ];
                sprites_interativos_nomes = new string[ numero_interativos ];


                sprites_objetos = new Sprite[ numero_objetos ];
                sprites_objetos_nomes = new string[ numero_objetos ];

                
                sprites_UI = new Sprite[ (System.Enum.GetValues( typeof( UI_menu ) )).Length ];
                sprites_UI_nomes = System.Enum.GetNames( typeof( UI_menu ) );



                int pointer_inicial = pointer_interno_inicial;

                // --- PEGA OS POINTER E PEGA A IMAGEM
                for( int background_index = 0 ; background_index < numero_backgrounds ; background_index += 8 ){

                        
                        int pointer_1 = 0;
                        pointer_1 += localizador_imagens[ pointer_inicial + ( background_index * 4 ) + 0 ];
                        pointer_1 += localizador_imagens[ pointer_inicial + ( background_index * 4 ) + 1 ];
                        pointer_1 += localizador_imagens[ pointer_inicial + ( background_index * 4 ) + 2 ];
                        pointer_1 += localizador_imagens[ pointer_inicial + ( background_index * 4 ) + 3 ];


                        int pointer_2 = 0;
                        pointer_2 += localizador_imagens[ pointer_inicial + ( background_index * 4 ) + 4 + 0 ];
                        pointer_2 += localizador_imagens[ pointer_inicial + ( background_index * 4 ) + 4 + 1 ];
                        pointer_2 += localizador_imagens[ pointer_inicial + ( background_index * 4 ) + 4 + 2 ];
                        pointer_2 += localizador_imagens[ pointer_inicial + ( background_index * 4 ) + 4 + 3 ];


                        int length_background = ( pointer_2 - pointer_1 );

                        sprites_background[ background_index ] = Pegar_sprite(  Pegar_id_unico_background( background_index ), ponto_inicial , length_background   );
                        sprites_backgrounds_nomes[ background_index ] = Pegar_nome_background_enum( tipo_menu, background_index );

                        continue;
                        
                }

                // --- PULA O NUMERO DE BYTES USADOS NO BACKGROUND
                pointer_inicial += ( numero_backgrounds * 4 ) * 2;


                int pointer_1_interativo;
                int pointer_2_interativo;
                int length_interativo;



                // --- NOVO JOGO

                        pointer_1_interativo = BYTE.Pegar_int_em_byte_array( localizador_imagens, pointer_inicial + ( ( int ) Interativo_menu_nome.quadro_novo_jogo * 4 ) + 0 );
                        pointer_2_interativo = BYTE.Pegar_int_em_byte_array( localizador_imagens, pointer_inicial + ( ( int ) Interativo_menu_nome.quadro_novo_jogo * 4 ) + 4 );
                        
                        length_interativo = ( pointer_1_interativo - pointer_2_interativo );


                        sprites_interativos[ ( int ) Interativo_menu_nome.quadro_novo_jogo  ] = Pegar_sprite(  Pegar_id_unico_background( ( int ) Interativo_menu_nome.quadro_novo_jogo ), ponto_inicial , length_interativo   );
                        sprites_interativos_nomes[ ( int ) Interativo_menu_nome.quadro_novo_jogo  ] = Interativo_menu_nome.quadro_novo_jogo.ToString();


                // --- SAVE


                        string path_save_1 = Paths_sistema.Pegar_path_imagem_save( 1 );
                        sprites_interativos[ ( int ) Interativo_menu_nome.save_slot_1  ] = SPRITE.Transformar_png_TO_sprite( System.IO.File.ReadAllBytes( path_save_1 ) );
                        sprites_interativos_nomes[ ( int ) Interativo_menu_nome.save_slot_1  ] = Interativo_menu_nome.save_slot_1.ToString();

                        string path_save_2 = Paths_sistema.Pegar_path_imagem_save( 2 );
                        sprites_interativos[ ( int ) Interativo_menu_nome.save_slot_2  ] = SPRITE.Transformar_png_TO_sprite( System.IO.File.ReadAllBytes( path_save_2 ) );
                        sprites_interativos_nomes[ ( int ) Interativo_menu_nome.save_slot_2  ] = Interativo_menu_nome.save_slot_2.ToString();

                        string path_save_3 = Paths_sistema.Pegar_path_imagem_save( 3 );
                        sprites_interativos[ ( int ) Interativo_menu_nome.save_slot_3  ] = SPRITE.Transformar_png_TO_sprite( System.IO.File.ReadAllBytes( path_save_3 ) );
                        sprites_interativos_nomes[ ( int ) Interativo_menu_nome.save_slot_3  ] = Interativo_menu_nome.save_slot_3.ToString();

                        string path_save_4 = Paths_sistema.Pegar_path_imagem_save( 4 );
                        sprites_interativos[ ( int ) Interativo_menu_nome.save_slot_4  ] = SPRITE.Transformar_png_TO_sprite( System.IO.File.ReadAllBytes( path_save_4 ) );
                        sprites_interativos_nomes[ ( int ) Interativo_menu_nome.save_slot_4  ] = Interativo_menu_nome.save_slot_4.ToString();
                        
                        

                        // --- BOTAO DIREITO

                        pointer_1_interativo = BYTE.Pegar_int_em_byte_array( localizador_imagens, pointer_inicial + ( ( int ) Interativo_menu_nome.save_botao_direita * 4 ) + 0 );
                        pointer_2_interativo = BYTE.Pegar_int_em_byte_array( localizador_imagens, pointer_inicial + ( ( int ) Interativo_menu_nome.save_botao_direita * 4 ) + 4 );
                        length_interativo = ( pointer_1_interativo - pointer_2_interativo );


                        sprites_interativos[ ( int ) Interativo_menu_nome.save_botao_direita  ] = Pegar_sprite(  Pegar_id_unico_background( ( int ) Interativo_menu_nome.save_botao_direita ), ponto_inicial , length_interativo   );
                        sprites_interativos_nomes[ ( int ) Interativo_menu_nome.save_botao_direita  ] = Interativo_menu_nome.save_botao_direita.ToString();


                        // --- BOTAO ESQUERDO
                        
                        pointer_1_interativo = BYTE.Pegar_int_em_byte_array( localizador_imagens, pointer_inicial + ( ( int ) Interativo_menu_nome.save_botao_esquerdo * 4 ) + 0 );
                        pointer_2_interativo = BYTE.Pegar_int_em_byte_array( localizador_imagens, pointer_inicial + ( ( int ) Interativo_menu_nome.save_botao_esquerdo * 4 ) + 4 );
                        length_interativo = ( pointer_1_interativo - pointer_2_interativo );


                        sprites_interativos[ ( int ) Interativo_menu_nome.save_botao_esquerdo  ] = Pegar_sprite(  Pegar_id_unico_background( ( int ) Interativo_menu_nome.save_botao_esquerdo ), ponto_inicial , length_interativo   );
                        sprites_interativos_nomes[ ( int ) Interativo_menu_nome.save_botao_esquerdo  ] = Interativo_menu_nome.save_botao_esquerdo.ToString();


                

                // --- GALERIA

                        string folder_galeria = Paths_sistema.path_folder__imagens_galeria;

                        string[] nomes_arquivos = System.IO.Directory.GetFiles( folder_galeria );

                        // *** tem que ter 2 de cada 

                        if( ( nomes_arquivos.Length % 2 != 0 ) )
                                { throw new System.Exception("nao veio par no numero de pngs da galeria"); }

                
                        pngs_galeria_previa = new byte[ ( nomes_arquivos.Length / 2 ) ][];

                        // ** galeria : path para imagem completa ( id ) => path_arr( id * 2 + 1 )

                        for( int galeria_index = 0 ; galeria_index < nomes_arquivos.Length ; galeria_index += 2 ){

                                string path = System.IO.Path.Combine( folder_galeria, nomes_arquivos[ galeria_index ] );
                                pngs_galeria_previa[ ( galeria_index / 2 ) ] = System.IO.File.ReadAllBytes( path );
                                continue;

                        }


                        // --- COLOCA OS PRIMEIROS 6
                        sprites_interativos[ ( int ) Interativo_menu_nome.galeria_quadro_1  ] = SPRITE.Transformar_png_TO_sprite( pngs_galeria_previa[ 0 ] );
                        sprites_interativos_nomes[ ( int ) Interativo_menu_nome.galeria_quadro_1  ] = Interativo_menu_nome.galeria_quadro_1.ToString();

                        
                        sprites_interativos[ ( int ) Interativo_menu_nome.galeria_quadro_2  ] = SPRITE.Transformar_png_TO_sprite( pngs_galeria_previa[ 1 ] );
                        sprites_interativos_nomes[ ( int ) Interativo_menu_nome.galeria_quadro_2  ] = Interativo_menu_nome.galeria_quadro_2.ToString();

                        
                        sprites_interativos[ ( int ) Interativo_menu_nome.galeria_quadro_3  ] = SPRITE.Transformar_png_TO_sprite( pngs_galeria_previa[ 2 ] );
                        sprites_interativos_nomes[ ( int ) Interativo_menu_nome.galeria_quadro_3  ] = Interativo_menu_nome.galeria_quadro_3.ToString();

                        
                        sprites_interativos[ ( int ) Interativo_menu_nome.galeria_quadro_4  ] = SPRITE.Transformar_png_TO_sprite( pngs_galeria_previa[ 3 ] );
                        sprites_interativos_nomes[ ( int ) Interativo_menu_nome.galeria_quadro_4  ] = Interativo_menu_nome.galeria_quadro_4.ToString();

                        
                        sprites_interativos[ ( int ) Interativo_menu_nome.galeria_quadro_5  ] = SPRITE.Transformar_png_TO_sprite( pngs_galeria_previa[ 4 ] );
                        sprites_interativos_nomes[ ( int ) Interativo_menu_nome.galeria_quadro_5  ] = Interativo_menu_nome.galeria_quadro_5.ToString();


                        sprites_interativos[ ( int ) Interativo_menu_nome.galeria_quadro_6  ] = SPRITE.Transformar_png_TO_sprite( pngs_galeria_previa[ 5 ] );
                        sprites_interativos_nomes[ ( int ) Interativo_menu_nome.galeria_quadro_6  ] = Interativo_menu_nome.galeria_quadro_6.ToString();

          

        
                        // --- BOTAO DIREITO

                        pointer_1_interativo = BYTE.Pegar_int_em_byte_array( localizador_imagens, ( pointer_inicial + ( ( int ) Interativo_menu_nome.galeria_botao_direito * 4 ) + 0 ) );
                        pointer_2_interativo = BYTE.Pegar_int_em_byte_array( localizador_imagens, ( pointer_inicial + ( ( int ) Interativo_menu_nome.galeria_botao_direito * 4 ) + 4 ) );
                        length_interativo = ( pointer_2_interativo - pointer_1_interativo );

                        sprites_interativos[ ( int ) Interativo_menu_nome.galeria_botao_direito  ] = Pegar_sprite(  Pegar_id_unico_background( ( int ) Interativo_menu_nome.galeria_botao_direito ), ponto_inicial , length_interativo   );
                        sprites_interativos_nomes[ ( int ) Interativo_menu_nome.galeria_botao_direito  ] = Interativo_menu_nome.galeria_botao_direito.ToString();


                        // --- BOTAO ESQUERDO

                        pointer_1_interativo = BYTE.Pegar_int_em_byte_array( localizador_imagens, ( pointer_inicial + ( ( int ) Interativo_menu_nome.galeria_botao_esquerdo * 4 ) + 0 ) );
                        pointer_2_interativo = BYTE.Pegar_int_em_byte_array( localizador_imagens, ( pointer_inicial + ( ( int ) Interativo_menu_nome.galeria_botao_esquerdo * 4 ) + 4 ) );
                        length_interativo = ( pointer_2_interativo - pointer_1_interativo );

                        sprites_interativos[ ( int ) Interativo_menu_nome.galeria_botao_esquerdo  ] = Pegar_sprite(  Pegar_id_unico_background( ( int ) Interativo_menu_nome.galeria_botao_esquerdo ), ponto_inicial , length_interativo   );
                        sprites_interativos_nomes[ ( int ) Interativo_menu_nome.galeria_botao_esquerdo  ] = Interativo_menu_nome.galeria_botao_esquerdo.ToString();





                // --- PERSONAGEM



                        int[] personagens_ids = _dados.personagens_ids;
                        pngs_personagens_previa = new byte[ personagens_ids.Length ][];


                        // ** se estiver consumindo muito tempo pode tentar pedir todos de uma vez
                        for( int personagem_index = 0 ; personagem_index < personagens_ids.Length ; personagem_index++ ){

                                int personagem_id = personagens_ids[ personagem_index ];

                                int pointer_1_personagem = localizador_imagens[ pointer_personagens_icones + ( 2 * personagem_id ) + 0  ];
                                int pointer_2_personagem = localizador_imagens[ pointer_personagens_icones + ( 2 * personagem_id ) + 1  ];
                                int length_personagem_icone = ( pointer_2_personagem - pointer_1_personagem );
                                
                                pngs_personagens_previa[ personagem_index ] = desmembrador_de_arquivo.Pegar_dados(  Pegar_id_unico_interativo( personagem_id ), pointer_1_personagem, length_personagem_icone );
                                continue;

                        }


                        // --- COLOCA OS PRIMEIROS 6
                        sprites_interativos[ ( int ) Interativo_menu_nome.personagem_slot_1  ] = SPRITE.Transformar_png_TO_sprite( pngs_galeria_previa[ 0 ] );
                        sprites_interativos_nomes[ ( int ) Interativo_menu_nome.personagem_slot_1  ] = Interativo_menu_nome.personagem_slot_1.ToString();

                        
                        sprites_interativos[ ( int ) Interativo_menu_nome.personagem_slot_2  ] = SPRITE.Transformar_png_TO_sprite( pngs_galeria_previa[ 1 ] );
                        sprites_interativos_nomes[ ( int ) Interativo_menu_nome.personagem_slot_2  ] = Interativo_menu_nome.personagem_slot_2.ToString();

                        
                        sprites_interativos[ ( int ) Interativo_menu_nome.personagem_slot_3  ] = SPRITE.Transformar_png_TO_sprite( pngs_galeria_previa[ 2 ] );
                        sprites_interativos_nomes[ ( int ) Interativo_menu_nome.personagem_slot_3  ] = Interativo_menu_nome.personagem_slot_3.ToString();

                        
                        sprites_interativos[ ( int ) Interativo_menu_nome.personagem_slot_4  ] = SPRITE.Transformar_png_TO_sprite( pngs_galeria_previa[ 3 ] );
                        sprites_interativos_nomes[ ( int ) Interativo_menu_nome.personagem_slot_4  ] = Interativo_menu_nome.personagem_slot_4.ToString();

                        
                        sprites_interativos[ ( int ) Interativo_menu_nome.personagem_slot_5  ] = SPRITE.Transformar_png_TO_sprite( pngs_galeria_previa[ 4 ] );
                        sprites_interativos_nomes[ ( int ) Interativo_menu_nome.personagem_slot_5  ] = Interativo_menu_nome.personagem_slot_5.ToString();


                        sprites_interativos[ ( int ) Interativo_menu_nome.personagem_slot_6  ] = SPRITE.Transformar_png_TO_sprite( pngs_galeria_previa[ 5 ] );
                        sprites_interativos_nomes[ ( int ) Interativo_menu_nome.personagem_slot_6  ] = Interativo_menu_nome.personagem_slot_6.ToString();

          

        
                        // --- BOTAO DIREITO

                        pointer_1_interativo = BYTE.Pegar_int_em_byte_array( localizador_imagens, ( pointer_inicial + ( ( int ) Interativo_menu_nome.personagens_botao_direito * 4 ) + 0 ) );
                        pointer_2_interativo = BYTE.Pegar_int_em_byte_array( localizador_imagens, ( pointer_inicial + ( ( int ) Interativo_menu_nome.personagens_botao_direito * 4 ) + 4 ) );
                        
                        length_interativo = ( pointer_2_interativo - pointer_1_interativo );


                        sprites_interativos[ ( int ) Interativo_menu_nome.personagens_botao_direito  ] = Pegar_sprite(  Pegar_id_unico_background( ( int ) Interativo_menu_nome.personagens_botao_direito ), pointer_1_interativo , length_interativo   );
                        sprites_interativos_nomes[ ( int ) Interativo_menu_nome.personagens_botao_direito  ] = Interativo_menu_nome.personagens_botao_direito.ToString();

                        // --- BOTAO ESQUERDO

                        pointer_1_interativo = BYTE.Pegar_int_em_byte_array( localizador_imagens, ( pointer_inicial + ( ( int ) Interativo_menu_nome.personagens_botao_esquerdo * 4 ) + 0 ) );
                        pointer_2_interativo = BYTE.Pegar_int_em_byte_array( localizador_imagens, ( pointer_inicial + ( ( int ) Interativo_menu_nome.personagens_botao_esquerdo * 4 ) + 4 ) );
                        
                        length_interativo = ( pointer_2_interativo - pointer_1_interativo );


                        sprites_interativos[ ( int ) Interativo_menu_nome.personagens_botao_esquerdo  ] = Pegar_sprite(  Pegar_id_unico_background( ( int ) Interativo_menu_nome.personagens_botao_esquerdo ), pointer_1_interativo , length_interativo   );
                        sprites_interativos_nomes[ ( int ) Interativo_menu_nome.personagens_botao_esquerdo  ] = Interativo_menu_nome.personagens_botao_esquerdo.ToString();







            // --- PEGA OBJETOS 
            
            bool[] objetos_liberados = _dados.objetos_liberados;

                if( numero_objetos != objetos_liberados.Length )
                        { throw new System.Exception( "length dos objetos_liberados menu nao estavao iguais" ); }


            for( int objeto_id = 0 ; objeto_id < numero_objetos ; objeto_id++ ){

                        if( !!!( objetos_liberados[ objeto_id ] ) )
                                { continue; }

                        int pointer_1_objeto = BYTE.Pegar_int_em_byte_array( localizador_imagens, ( pointer_inicial + ( ( int ) Interativo_menu_nome.personagens_botao_direito * 4 ) + 0 ) );
                        int pointer_2_objeto = BYTE.Pegar_int_em_byte_array( localizador_imagens, ( pointer_inicial + ( ( int ) Interativo_menu_nome.personagens_botao_direito * 4 ) + 4 ) );
                        
                        int length_objeto = ( pointer_2_objeto - pointer_1_objeto );

                        sprites_objetos[ objeto_id ] = Pegar_sprite( Pegar_id_unico_objeto_estatico( objeto_id ) , ponto_inicial, length_objeto );
                        sprites_objetos_nomes[ objeto_id ] = Pegar_nome_objeto_enum( tipo_menu, objeto_id );
                        
                        continue;
                    
            }


    

            // --- PEGAR UI

                int language_id = ( int ) Controlador_configuracoes.Pegar_instancia().idioma;



                // -- PERSONAGENS
                int pointer_1_UI_personagens  = BYTE.Pegar_int_em_byte_array(  localizador_imagens, pointer_inicio_UI + ( language_id * 5 * 4  ) + ( ( ( int ) UI_menu.personagens ) * 4 ) + 0 );
                int pointer_2_UI_personagens  = BYTE.Pegar_int_em_byte_array(  localizador_imagens, pointer_inicio_UI + ( language_id * 5 * 4  ) + ( ( ( int ) UI_menu.personagens ) * 4 ) + 4 );
                int length_UI_personagens = ( pointer_2_UI_personagens - pointer_1_UI_personagens );

                sprites_UI[ ( ( int ) UI_menu.personagens ) ] = Pegar_sprite( Pegar_id_unico_objeto_estatico( ( ( int ) UI_menu.personagens ) ) , pointer_1_UI_personagens, length_UI_personagens );
                sprites_objetos_nomes[ ( ( int ) UI_menu.personagens ) ] = UI_menu.personagens.ToString();


                // --- GALERIA
                int pointer_1_UI_galeria  = BYTE.Pegar_int_em_byte_array(  localizador_imagens, pointer_inicio_UI + ( language_id * 5 * 4  ) + ( ( ( int ) UI_menu.galeria ) * 4 ) + 0 );
                int pointer_2_UI_galeria  = BYTE.Pegar_int_em_byte_array(  localizador_imagens, pointer_inicio_UI + ( language_id * 5 * 4  ) + ( ( ( int ) UI_menu.galeria ) * 4 ) + 4 );
                int length_UI_galeria = ( pointer_2_UI_galeria - pointer_1_UI_galeria );

                sprites_UI[ ( ( int ) UI_menu.galeria ) ] = Pegar_sprite( Pegar_id_unico_objeto_estatico( ( ( int ) UI_menu.galeria ) ) , pointer_1_UI_galeria, length_UI_galeria );
                sprites_objetos_nomes[ ( ( int ) UI_menu.galeria ) ] = UI_menu.galeria.ToString();


                // --- HOME
                int pointer_1_UI_home  = BYTE.Pegar_int_em_byte_array(  localizador_imagens, pointer_inicio_UI + ( language_id * 5 * 4  ) + ( ( ( int ) UI_menu.home ) * 4 ) + 0 );
                int pointer_2_UI_home  = BYTE.Pegar_int_em_byte_array(  localizador_imagens, pointer_inicio_UI + ( language_id * 5 * 4  ) + ( ( ( int ) UI_menu.home ) * 4 ) + 4 );
                int length_UI_home = ( pointer_2_UI_home - pointer_1_UI_home );

                sprites_UI[ ( ( int ) UI_menu.home ) ] = Pegar_sprite( Pegar_id_unico_objeto_estatico( ( ( int ) UI_menu.home ) ) , pointer_1_UI_home, length_UI_home );
                sprites_objetos_nomes[ ( ( int ) UI_menu.home ) ] = UI_menu.home.ToString();
            

                // --- SAVES
                int pointer_1_UI_saves  = BYTE.Pegar_int_em_byte_array(  localizador_imagens, pointer_inicio_UI + ( language_id * 5 * 4  ) + ( ( ( int ) UI_menu.saves ) * 4 ) + 0 );
                int pointer_2_UI_saves  = BYTE.Pegar_int_em_byte_array(  localizador_imagens, pointer_inicio_UI + ( language_id * 5 * 4  ) + ( ( ( int ) UI_menu.saves ) * 4 ) + 4 );
                int length_UI_saves = ( pointer_2_UI_saves - pointer_1_UI_saves );

                sprites_UI[ ( ( int ) UI_menu.saves ) ] = Pegar_sprite( Pegar_id_unico_objeto_estatico( ( ( int ) UI_menu.saves ) ) , pointer_1_UI_saves, length_UI_saves );
                sprites_objetos_nomes[ ( ( int ) UI_menu.saves ) ] = UI_menu.saves.ToString();


                // --- CONFIGURATIONS
                int pointer_1_UI_configuracoes  = BYTE.Pegar_int_em_byte_array(  localizador_imagens, pointer_inicio_UI + ( language_id * 5 * 4  ) + ( ( ( int ) UI_menu.configuracoes ) * 4 ) + 0 );
                int pointer_2_UI_configuracoes  = BYTE.Pegar_int_em_byte_array(  localizador_imagens, pointer_inicio_UI + ( language_id * 5 * 4  ) + ( ( ( int ) UI_menu.configuracoes ) * 4 ) + 4 );
                int length_UI_configuracoes = ( pointer_2_UI_configuracoes - pointer_1_UI_configuracoes );

                sprites_UI[ ( ( int ) UI_menu.configuracoes ) ] = Pegar_sprite( Pegar_id_unico_objeto_estatico( ( ( int ) UI_menu.configuracoes ) ) , pointer_1_UI_configuracoes, length_UI_configuracoes );
                sprites_objetos_nomes[ ( ( int ) UI_menu.configuracoes ) ] = UI_menu.configuracoes.ToString();
            


            return;



    }


        public static string Pegar_nome_background_enum( Tipo_menu_background _tipo, int _id ){


                switch( _tipo ){

                        case Tipo_menu_background.catedral_corredor : return (( Catedral_corredor_imagens_background ) _id ).ToString();
                        default: throw new System.Exception( $"Nao foi possivel lidar com o tipo { _tipo.ToString() } em Pegar_nome_background_enum" );

                }

        }



        public static string Pegar_nome_objeto_enum( Tipo_menu_background _tipo, int _id ){


                switch( _tipo ){

                        case Tipo_menu_background.catedral_corredor : return (( Catedral_corredor_objetos_estaticos ) _id ).ToString();
                        default: throw new System.Exception( $"Nao foi possivel lidar com o tipo { _tipo.ToString() } em Pegar_nome_background_enum" );

                }

        }





    private static int Pegar_id_unico_background( int _id ){

        return  _id;

    }

    private static int Pegar_id_unico_interativo( int _id ){

        return _id * 1_000;

    }

    private static int Pegar_id_unico_objeto_estatico( int _id ){

        return _id * 1_000_000;

    }




}