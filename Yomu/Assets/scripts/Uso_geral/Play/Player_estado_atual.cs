using System;
using UnityEngine;



public class Player_estado_atual{

    public static Player_estado_atual instancia;
    public static Player_estado_atual Pegar_instancia( bool _forcar = false  ){

            if( _forcar ) {if( Verificador_instancias_nulas.Verificar_se_pode_criar_objetos("Player_estado_atual")) { instancia = new Player_estado_atual();instancia.Iniciar();} return instancia;}
            if(  instancia == null) { instancia = new Player_estado_atual(); instancia.Iniciar(); }
            return instancia;

    }




    public int posicao_atual = 0;

    public int[] interativos = new int[0]{};

    public int dinheiro = 100;

    public int[] mochila = new int[9];

    public Item_nome[] itens_mochila = new Item_nome[ 9 ]{
        Item_nome.albuin_meat,
        Item_nome.nada,
        Item_nome.nada,
        Item_nome.nada,
        Item_nome.nada,
        Item_nome.nada,
        Item_nome.nada,
        Item_nome.nada,
        Item_nome.nada,
    };

    public int[] bau = new int[24];

    public Ponto_nome[] posicao_arr = new Ponto_nome[20];

    public float sadismo = 0f;

    public Ponto ponto_atual ;


    public Bloco[] blocos_anteriores = new Bloco[10];

    public Bloco bloco_atual;



    public string mapa_atual = "catedral" ;
    public Ponto_nome[] pontos_mapa = new Ponto_nome[]{

        Ponto_nome.UP_quarto_nara,
        Ponto_nome.CORREDOR_1

    };


    public float[][] pontos_mapa_posicoes = new float[][]{

        new float[] { -100f,-100f }, 
        new float[] { 100f,100f }

    };




    public void Iniciar(){


        ponto_atual = new Ponto();
        ponto_atual.ponto_flip = 0;
        ponto_atual.folder_path = "background/catedral/nara_room/";
        ponto_atual.background_name = "up_d";
        ponto_atual.interativos_nomes = new Interativo_nome[] {  Interativo_nome.nada  };
        ponto_atual.personagens_no_ponto = new Personagem_nome[0];
        ponto_atual.script_entrada = 0;


    }


    public void Zerar_dados(){


     interativos = new int[0];

     dinheiro = 0;

     mochila = new int[9];

     bau = new int[24];

     posicao_atual = 0;

     posicao_arr = new Ponto_nome[20];

     sadismo = 0f;

           

    }

    public Ponto_nome Pegar_posicao_atual(){

            int index = 0 ;

            for ( int i = 0; i < posicao_arr.Length ;i++){

            if( posicao_arr[ i ] == Ponto_nome.nada ){

                index = i;
                break;

            }

            }

            if(index == 0) { return 0; }

            return posicao_arr[  index-1 ];


    }

    public Ponto_nome Pegar_posicao_anterior(){

            int index = 0 ;

            for ( int i = 0; i < posicao_arr.Length ;i++){

                    if( posicao_arr[ i ] == Ponto_nome.nada ){

                            index = i;
                            break;

                    }
                    
            }


            if(index <  2){   

                Debug.Log("VOLTAR PLAYER ERA PARA FLIP");
                return posicao_arr[ 0 ];
                
            }

            return posicao_arr[ index -2 ] ;


    }



    public string Pegar_path_imagem_background(){


            return   "images/in_game/" + ponto_atual.folder_path + ponto_atual.background_name;


    }













      public void Acrecentar_posicao (    Ponto _ponto,  bool _resetar = false ) {


            ponto_atual = _ponto;
            Ponto_nome novo_ponto =   _ponto.ponto_nome;

            if(_resetar) {    posicao_arr = new Ponto_nome[20] ; posicao_arr[0] = novo_ponto ; return;} 


            int posicao = 0;


            int index_livre = 1;
            int index_novo_ponto_ja_tem = -1;



            for ( posicao = 0 ; posicao < posicao_arr.Length ; posicao++){

                    if( posicao_arr[ posicao ] == Ponto_nome.nada ){ index_livre = posicao ; break;}
            }


            for( posicao = 0 ; posicao < posicao_arr.Length; posicao++  ){

                    if( posicao_arr[ posicao ] == novo_ponto ) { 

                            index_novo_ponto_ja_tem = posicao ;
                            break ;

                    }

            }



            if( index_novo_ponto_ja_tem != -1 ){

                    /* so tem que fazer flip se o mesmo ponto estiver no index 0, no 1 ele so pula*/

                    if( index_novo_ponto_ja_tem == 0  ){

                            /// flip
                            Ponto_nome x = posicao_arr[ 1 ] ;

                            posicao_arr[ 1 ] = posicao_arr[ 0 ] ; 
                            posicao_arr[ 0 ] = x ;  
                            return ;


                    }

                    for( posicao =( index_novo_ponto_ja_tem + 1 ) ; posicao < posicao_arr.Length; posicao++ ){

                            posicao_arr[ posicao ] = Ponto_nome.nada ;

                    }

                    return;

            }

            // nao tem o ponto na lista


            if( index_livre == 0 ){ posicao_arr[ 0 ] = novo_ponto ; return ; }


            int posicao_atual =  index_livre - 1 ;
            Debug.Log("posicao_atual: " + posicao_atual);
            Ponto_nome ponto_nome_atual = posicao_arr[ posicao_atual ];


            if( ponto_nome_atual == novo_ponto   ) { return; }

            posicao_arr[ index_livre ] = novo_ponto;


            return;




    }









    public void Adicionar_modo_tela(Bloco _novo_bloco){


        for(int  i = 0 ;   i < blocos_anteriores.Length ; i++){

            if(blocos_anteriores[i] == Bloco.nada) { 

                this.blocos_anteriores[i] = _novo_bloco;
                this.bloco_atual = _novo_bloco;

                return;
            }

        }

        throw new ArgumentException("Nao tem mais espaço no slot para modos tela anteriores em player_estado_atual");

    }

    



    public Bloco Pegar_bloco_anterior(){

        int index_modo_tela_atual_int = -1;

        for(int  i = 0 ;   i < blocos_anteriores.Length ; i++){


            if( blocos_anteriores[i] == Bloco.nada ) {

                if(i < 2) {


                    return Bloco.nada;
                    
                }

                int modo_tela_vazio_int = i;
                index_modo_tela_atual_int = modo_tela_vazio_int - 1; 
                break;

            }

        }

        int index_modo_tela_anterior_int = index_modo_tela_atual_int - 1; 

        Bloco modo_tela_anterior =  blocos_anteriores[ index_modo_tela_anterior_int ];

        return modo_tela_anterior;

    }


    public Bloco Pegar_bloco_atual(){ return bloco_atual;}




    public void Voltar_modo_tela( ) {

        Bloco novo_bloco = Pegar_bloco_anterior();
        bloco_atual = novo_bloco;

        for(int  i = 0 ;   i < blocos_anteriores.Length ; i++){

            if( blocos_anteriores[ i ] == Bloco.nada ) { blocos_anteriores[ i - 1 ] = Bloco.nada;  return;}

        }

    }



    public void Trocar_itens_mochila( int slot_1 ,  int slot_2 ){

        Item_nome item_1 = itens_mochila[ slot_1 ];
        Item_nome item_2 = itens_mochila[ slot_2 ];

        itens_mochila[ slot_1 ] = item_2;
        itens_mochila[ slot_2 ] = item_1;

        return;

    }

  

}
