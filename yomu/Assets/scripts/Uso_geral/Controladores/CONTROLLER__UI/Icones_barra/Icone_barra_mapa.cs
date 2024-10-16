using UnityEngine;
using UnityEngine.UI;
using System;





    public class Mapa_ponto {



        public Locator_position ponto_destino;
        public GameObject game_object = null;
        public Image ponto_imagem = null ;
        public Cor_cursor cor_cursor = Cor_cursor.red ;
        public float[] min_max_rect = new float [ 4 ] ;
        public float[] posicao = new float[ 2 ] ;

        public void Colocar_posicao ( float[] _posicao ){

            posicao = _posicao;

            game_object.transform.localPosition = new Vector3(  posicao[ 0 ], posicao[ 1 ],  0f );

            min_max_rect[ 0 ] =  posicao[ 0 ] - 25f + 960f ;
            min_max_rect[ 1 ] =  posicao[ 0 ] + 25f + 960f ;

            min_max_rect[ 2 ] = posicao[ 1 ] - 25f + 540f ;
            min_max_rect[ 3 ] = posicao[ 1 ] + 25f + 540f ;

            return;



        }
        

    }




public static class Icone_barra_mapa {

    public static Mapa_ponto[] pontos = null;


    public static bool Update() { 
                                  
                                                        
            if( Input.GetKeyDown( KeyCode.Escape) ) { 

                Encerrar() ;
                return true ;
                
            }


            float[] posicao = CONTROLLER__data.Pegar_instancia().posicao_mouse;



            for( int ponto_index = 0 ; ponto_index < pontos.Length ; ponto_index++ ) {


                    Mapa_ponto ponto = pontos[ ponto_index ] ;
                    float[] min_max = ponto.min_max_rect ;

                    bool passou = Rectangle.Check_point_inside ( posicao[ 0 ] , posicao[ 1 ] , min_max[ 0 ] , min_max[ 1 ] , min_max[ 2 ] , min_max[ 3 ] ) ;

                    if( passou ){

                            if( Input.GetMouseButtonDown( 0 ) ){

                                    //BLOCO_jogo.Pegar_instancia().update_tipo_atual = Jogo_update_tipo.movimento;

                                    // ** ver depois
                                    //BLOCO_conector.Pegar_instancia().Mover_player( ponto.ponto_destino , true  ); 

                                    Encerrar();
                                    return true;

                            }

                            Controlador_cursor.Pegar_instancia().Change_action( Cursor_action.choice ); //  Mudar_cursor( Cor_cursor.red );
                            break;

                    }

                    Controlador_cursor.Pegar_instancia().Change_action( Cursor_action.choice ); // Mudar_cursor( Cor_cursor.off );


            }

            return false ;



    }



    public static void Encerrar(){

            Mono_instancia.Destroy( game_object ) ;
            game_object = null ; 


    }

    public static GameObject game_object = null;


    public static void  Criar( GameObject _game_object ){

        game_object = new GameObject( "mapa" );
        IMAGE.Criar_imagem (
                                _game_object: game_object,
                                _pai : _game_object,
                                _width: 800f,
                                _height: 600f,
                                _path : null,
                                _sprite: null,
                                _alpha: 1f

                            );
        

        Player_estado_atual p  =  Player_estado_atual.Pegar_instancia() ; 

        string mapa_atual = p.mapa_atual;
        Locator_position[] pontos_mapa = p.pontos_mapa;

        float[][] pontos_mapa_posicoes = p.pontos_mapa_posicoes;

        int numero_pontos = pontos_mapa.Length ;

        pontos = new Mapa_ponto[ numero_pontos ];

        string mapa_path = "images/in_game/ui/mapa/" + mapa_atual + "/" ;

        for( int i = 0 ; i < numero_pontos ; i++ ){

                float[] posicao = pontos_mapa_posicoes[ i ] ;

                Mapa_ponto mapa_ponto = new Mapa_ponto() ;
                pontos[ i ] =  mapa_ponto ;

                string path_ponto_sprite = mapa_path + pontos_mapa[ i ] ;
                
                mapa_ponto.game_object = new GameObject( "ponto_mapa_" + pontos_mapa[ i ].ToString() );
                mapa_ponto.ponto_imagem =IMAGE.Criar_imagem (
                                                                _game_object: mapa_ponto.game_object,
                                                                _pai : game_object,
                                                                _width: 50f,
                                                                _height: 50f,
                                                                _path : path_ponto_sprite,
                                                                _sprite: null,
                                                                _alpha: 1f

                                                            );

        

                mapa_ponto.Colocar_posicao( posicao );

                mapa_ponto.ponto_destino = pontos_mapa[ i ];



        }




        /*       p1   ----   p2  ---  X  --    p3       */



    } 


    public static void Destruir(){}




}