using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;





public class Icone_barra {

    public Icone_barra_nome icone_nome;
    public GameObject game_object;
    public Image imagem;

    public Sprite imagem_nao_focada;
    public Sprite imagem_focada;

    public bool esta_ativo = false;
    public bool esta_dentro = false;

    public bool ativacao_down = false;
    public bool ativacao_up = false;

   // public Action on_click;

    public void Update() {




    }


    public float[] posicao = new float[ 2 ];

    public bool Checar_mouse(){



        float[] posicao_mouse = Controlador_data.Pegar_instancia().posicao_mouse;

        float x_min = this.posicao[ 0 ] - 25f + 960f;
        float x_max = this.posicao[ 0 ] + 25f + 960f;
        float y_min = this.posicao[ 1 ] - 25f + 540f; 
        float y_max = this.posicao[ 1 ] + 25f + 540f; 

        if( this.esta_dentro == true ){
            
            x_min -= 5f;
            x_max += 5f;
            y_min -= 5f;
            y_max += 5f;

        }

        // Debug.Log( "x: " + x_min );
        // Debug.Log( "X: " + x_max );
        // Debug.Log( "y: " + y_min );
        // Debug.Log( "Y: " + y_max );
        // Debug.Log("mouse_x: " +  posicao_mouse[ 0 ]);
        // Debug.Log("mouse_y: " + posicao_mouse[ 1 ]);

        bool mouse_esta_dentro =  Mat.Verificar_ponto_dentro_retangulo( posicao_mouse[ 0 ] , posicao_mouse [ 1 ] , x_min, x_max, y_min, y_max );


        if( !mouse_esta_dentro ) { 
            esta_dentro = false;
         } else {
            esta_dentro = true;
         }

        return mouse_esta_dentro;



    }


    public Icone_barra (  Icone_barra_nome _nome, GameObject _pai , float _x , float _y  ){


            this.posicao = new float[]{ _x, _y };


            string path_focado = "images/in_game/ui/interface/icones/" + _nome.ToString() + "_on";
            string path_NAO_focado = "images/in_game/ui/interface/icones/" + _nome.ToString() + "_off";

            this.imagem_focada = Resources.Load< Sprite >( path_focado );
            this.imagem_nao_focada = Resources.Load< Sprite >( path_NAO_focado );

            this.icone_nome = _nome;
            this.game_object =  Geral.Criar_imagem(

                _nome: _nome.ToString() ,
                _pai: _pai ,
                _width: 50f ,
                _height: 50f ,
                _path_imagem: path_NAO_focado,
                _alpha: 1f

            );
            this.imagem = Geral.ultima_imagem;

            this.game_object.transform.localPosition = new Vector3( _x, _y , 0f );

            
            // switch( _nome ){

            //     case Icone_barra_nome.nada:  this.on_click = Icones_fn.Ativar_nada ; break;
            //     case Icone_barra_nome.lala:  this.on_click = Icones_fn.Ativar_lala ; break;
                

            // }

    }

}





public enum Icone_barra_nome {

    nada = 0,

    mapa,
    livro_contatos,
    mochila,

    combat,
    livro_config,
    lala,

}




public class Barra_superior_modelo_1 {


    public Icone_barra[] icones;

    public GameObject game_object;// container geral 

    public GameObject barra_superior_parte_1;
    public Image barra_superior_parte_1_imagem;

    public GameObject barra_superior_parte_2;
    public Image barra_superior_parte_2_imagem;

    public GameObject seta;
    public Image seta_imagem;

    public GameObject barra_de_icones;
    public Image barra_de_icones_imagem;


    public Coroutine barra_superior_movimento_coroutine;


    public float posicao_barra_escondida = 150f;


    public Barra_superior_modelo_1 ( Transform _local , Icone_barra_nome[] _icones = null ){ 


            game_object = new GameObject( "Barra_superior_container" );
            game_object.transform.SetParent(  _local , false );



            string path_folder = "images/in_game/ui/interface/dialogo/";

            string barra_parte_1_path = path_folder + "barra_superior_parte_1";
            string barra_parte_2_path = path_folder + "barra_superior_parte_2";
            string seta_path = path_folder + "seta";


            barra_superior_parte_1 = Geral.Criar_imagem(

                _nome: "barra_superior_1" ,
                _pai: game_object ,
                _width: 1920f ,
                _height: 1080f ,
                _path_imagem: barra_parte_1_path,
                _alpha: 1f

            );
            barra_superior_parte_1_imagem = Geral.ultima_imagem;


            seta = Geral.Criar_imagem(

                _nome: "seta" ,
                _pai: game_object ,
                _width: 150f ,
                _height: 30f ,
                _path_imagem: seta_path,
                _alpha: 1f

            );
            seta_imagem = Geral.ultima_imagem;

            seta.transform.localPosition += new Vector3(  0f  ,   488.9f   , 0f   );



            barra_superior_parte_2 = Geral.Criar_imagem(

                _nome: "barra_superior_2" ,
                _pai: game_object ,
                _width: 1920 ,
                _height: 1080f ,
                _path_imagem: barra_parte_2_path,
                _alpha: 1f

            );
            barra_superior_parte_2_imagem = Geral.ultima_imagem;
            









            barra_de_icones  =  new GameObject( "Icones_barra" );
            barra_de_icones.transform.SetParent(  game_object.transform,  false);


            if( _icones == null ){

                _icones = new Icone_barra_nome[]{

                        Icone_barra_nome.livro_contatos, 
                        Icone_barra_nome.mochila, 
                        Icone_barra_nome.mapa, 

                        Icone_barra_nome.combat, 
                        Icone_barra_nome.lala, 
                        Icone_barra_nome.livro_config, 
                        
                };

            }
        

            icones = new Icone_barra [ 6 ];

            float JUMP = 215f;
            float JUMP_RELOGIO = 290f;
            float X_INICIAL = -687f;
            float DEFAULT_y = 495f;

            for( int icone = 0 ; icone < icones.Length ; icone++){


                float posicao_icone_x =  X_INICIAL  +  ( (( float ) icone ) *  JUMP  ) +  (   ( float ) (icone / 3 )  * JUMP_RELOGIO  );

                icones[ icone ] = new Icone_barra ( _icones[ icone ] , barra_de_icones , posicao_icone_x , DEFAULT_y );

            }

            



    }

    public void Off_todos_icones( int _index_para_ignorar = -1 ){

        

        for( int icone_index = 0 ; icone_index < this.icones.Length  ; icone_index++  ){

            if ( icone_index == _index_para_ignorar ) { continue; }

            Icone_barra icone = this.icones[ icone_index ];
            icone.imagem.sprite = icone.imagem_nao_focada;
            icone.ativacao_down = false;
            icone.ativacao_up = false;

        }

    }

    public void On_icone( int _icone_index ){

        Icone_barra icone = this.icones[ _icone_index ];
        icone.imagem.sprite = icone.imagem_focada;
    }





    public void Esconder( bool _instantaneo ){

        if( barra_superior_movimento_coroutine != null ){ 

            Mono_instancia.Stop_coroutine( barra_superior_movimento_coroutine ); 
            barra_superior_movimento_coroutine = null;

        }

        if( _instantaneo ) {

            this.game_object.transform.localPosition = new Vector3(0f, posicao_barra_escondida , 0f);
            return; 
        }


        barra_superior_movimento_coroutine = Mono_instancia.Start_coroutine( Esconder_barra() );


        IEnumerator Esconder_barra(){



                float tempo_ms = 500f;
                int numero_ciclos =  ( int ) (  (tempo_ms / 1000f) * 60f);

                float d_x =   (  this.game_object.transform.localPosition[ 1 ] - posicao_barra_escondida ) / ( float ) numero_ciclos ;

                for( int ciclo_atual = 0 ; ciclo_atual < numero_ciclos ; ciclo_atual++ ){

                        this.game_object.transform.localPosition -= new Vector3( 0f , d_x , 0f );
                        
                        yield return null;
                        
                }

                this.game_object.transform.localPosition = new Vector3(0f, posicao_barra_escondida, 0f);


                barra_superior_movimento_coroutine = null;
                yield break;


        }


    }


    public void Mostrar( bool _instantaneo = false  ){

        if( barra_superior_movimento_coroutine != null ){ 

            Mono_instancia.Stop_coroutine( barra_superior_movimento_coroutine ); 
            barra_superior_movimento_coroutine = null;

        }

        if( _instantaneo ) {

            this.game_object.transform.localPosition = new Vector3(0f, 0f , 0f);
            return; 
        }



        barra_superior_movimento_coroutine = Mono_instancia.Start_coroutine( Mostrar_barra() );


        IEnumerator Mostrar_barra(){

            
                float tempo_ms = 500f;
                int numero_ciclos =  ( int ) (  (tempo_ms / 1000f) * 60f);
                float d_x =   (  this.game_object.transform.localPosition[ 1 ] ) / ( float ) numero_ciclos ;

                for( int ciclo_atual = 0 ; ciclo_atual < numero_ciclos ; ciclo_atual++ ){

                        this.game_object.transform.localPosition -= new Vector3( 0f , d_x , 0f );
                        yield return null;
                        
                }

                this.game_object.transform.localPosition = new Vector3(0f, 0f , 0f);

                barra_superior_movimento_coroutine = null;

                yield break;


        }


    }





}

