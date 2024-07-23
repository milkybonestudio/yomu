using UnityEngine;

public static class Gerenciador_imagens_MENU {

    // --- 

    public static  Sprite[] sprites_background;
    public static  Sprite[] sprites_interativos;
    public static  Sprite[] sprites_objetos_estaticos;

    public static  byte[][] pngs;


    // *** formato : [ tipo menu ( 2 bytes) ] => pointer localizador_1 => [ poiner_localizador_1 ( 4 bytes ) ]  => poiner inicial imagens background 
    //                                                                    [ poiner_localizador_1 ( 4 bytes ) + 4 ] => poiner inicial imagens interativos
    //                                                                    [ poiner_localizador_1 ( 4 bytes ) + 8 ] => pointer numero de imagens estaticas( 2 bytes ) => pointer inicial imagens estaticas

    public static byte[] localizador_imagens;
    public static  MODULO_manipulador_imagens_dinamicas manipulador_imagens_dinamicas;


    public static Sprite Pegar_sprite_background( int _background_id ){

            int localizador = Pegar_id_unico_background( _background_id );
            Sprite sprite = manipulador_imagens_dinamicas.Pegar_sprite( localizador, -1, -1 );
            return sprite;

    }


    public static Sprite Pegar_sprite_interativo( int _interativo_id ){

            int localizador = Pegar_id_unico_interativo( _interativo_id );
            Sprite sprite = manipulador_imagens_dinamicas.Pegar_sprite( localizador, -1, -1 );
            return sprite;

    }


    public static Sprite Pegar_sprite_objeto_estatico( int _objeto_estatico_id ){

            int localizador = Pegar_id_unico_objeto_estatico( _objeto_estatico_id );
            Sprite sprite = manipulador_imagens_dinamicas.Pegar_sprite( localizador, -1, -1 );
            return sprite;

    }




    static Gerenciador_imagens_MENU(){

            localizador_imagens = System.IO.File.ReadAllBytes( Paths_sistema.path_arquivo__localizador__menu_imagens );
            manipulador_imagens_dinamicas  =  new MODULO_manipulador_imagens_dinamicas  ( 
                                                                                            _nome_modulo: "",
                                                                                            _path_container: Paths_sistema.path_arquivo__dados_estaticos__uso_parcial__menu_imagens,
                                                                                            _numero_inicial_de_slots: 50
                                                                                        );
            return;
    }


    public static  void Carregar_imagens( Dados_menu _dados ){





            // ** tem quando for pedir as imagens tem que leva em conta que cada tipo de menu vai comecar m um lugar diferente do localizador

            int ponto_inicial = 0;

            // --- CARREGAR SAVES E PRINTS COMPRIMIDAS

            // como?


            // --- PEGA POINTERS
            
            Tipo_menu_background tipo_menu = _dados.tipo_menu_background;
            int pointer_interno = 0;
            pointer_interno += ( ( int ) localizador_imagens[ ( ( int ) tipo_menu ) ] << 8 );
            pointer_interno += ( ( int ) localizador_imagens[ ( ( int ) tipo_menu ) ] << 0 );


            int pointer_inicio_imagens_background_menu = 0;
            pointer_inicio_imagens_background_menu += ( ( int ) localizador_imagens[ pointer_interno ] << 8 );
            pointer_inicio_imagens_background_menu += ( ( int ) localizador_imagens[ pointer_interno ] << 0 );


            int pointer_inicio_imagens_interativos_menu = 0;
            pointer_inicio_imagens_interativos_menu += ( ( int ) localizador_imagens[ ( pointer_interno * 4 ) + 2 ] << 8 );
            pointer_inicio_imagens_interativos_menu += ( ( int ) localizador_imagens[ ( pointer_interno * 4 ) + 2 ] << 0 );


            int numero_de_imagens_estaticas = 0;
            numero_de_imagens_estaticas += ( ( int ) localizador_imagens[ ( pointer_interno * 4 ) + 4 ] << 8 );
            numero_de_imagens_estaticas += ( ( int ) localizador_imagens[ ( pointer_interno * 4 ) + 4 ] << 0 );

            int pointer_inicio_imagens_objetos_estaticos_menu = 0;
            pointer_inicio_imagens_objetos_estaticos_menu += ( ( int ) localizador_imagens[ ( pointer_interno * 4 ) + 6 ] << 8 );
            pointer_inicio_imagens_objetos_estaticos_menu += ( ( int ) localizador_imagens[ ( pointer_interno * 4 ) + 6 ] << 0 );





            

            // --- PEGAR MENU BACKGROUND IMAGENS 

            int[] ids_background_e_posicao = _dados.background_imagens_ids_E_posicoes;

            int numero_backgrounds = ( ids_background_e_posicao.Length / 3 ) ;

            for( int background_index = 0 ; background_index < numero_backgrounds ; background_index++ ){

                    int id = ids_background_e_posicao[ ( background_index * 3 ) ];

                    int pointer_1 = localizador_imagens[ pointer_inicio_imagens_background_menu + id + 0 ];
                    int pointer_2 = localizador_imagens[ pointer_inicio_imagens_background_menu + id + 1 ];
                    int length = ( pointer_2 - pointer_1 );

                    manipulador_imagens_dinamicas.Pegar_sprite(  Pegar_id_unico_background( id ), ponto_inicial , length ,-1, -1  );

                    continue;
                    
            }




            // --- PEGA OBJETOS ESTATICOS
            
            bool[] objetos_estaticos_liberados = _dados.objetos_estaticos_liberados;

            for( int objeto_estatico_id = 0 ; objeto_estatico_id < numero_de_imagens_estaticas ; objeto_estatico_id++ ){

                    if( !!! ( objetos_estaticos_liberados[ objeto_estatico_id ] ) )
                        { continue; }


                    int pointer_1 = localizador_imagens[ pointer_inicio_imagens_objetos_estaticos_menu + objeto_estatico_id + 0 ];
                    int pointer_2 = localizador_imagens[ pointer_inicio_imagens_objetos_estaticos_menu + objeto_estatico_id + 1 ];
                    int length = ( pointer_2 - pointer_1 );

                    manipulador_imagens_dinamicas.Pegar_sprite(  Pegar_id_unico_objeto_estatico( objeto_estatico_id ), ponto_inicial , length ,-1, -1  );

                    continue;
                    
            }



            // --- PEGAR MENU INTERATIVOS IMAGENS


            int[] interativos_menu_blocos_separados = INT.Transformar_array_2d_em_1d( _dados.interativos_menu_imagens_por_bloco );
            int[] posicao_interativos_por_bloco = INT.Transformar_array_2d_em_1d( _dados.posicoes_interativos_menu_por_bloco);
            

            for( int interativo_index = 0 ; interativo_index < interativos_menu_blocos_separados.Length ; interativo_index++ ){{

                int id = interativos_menu_blocos_separados[ interativo_index ];

                int pointer_1 = localizador_imagens[ pointer_inicio_imagens_interativos_menu + id + 0 ];
                int pointer_2 = localizador_imagens[ pointer_inicio_imagens_interativos_menu + id + 1 ];
                int length = ( pointer_2 - pointer_1 );

                manipulador_imagens_dinamicas.Pegar_sprite(  Pegar_id_unico_interativo( id ) , ponto_inicial , length ,-1, -1  );

                continue;


            }



            }
            

            return;



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