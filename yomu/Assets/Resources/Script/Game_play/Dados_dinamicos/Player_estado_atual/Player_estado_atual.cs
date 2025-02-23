using System;
using UnityEngine;



public class Player_estado_atual {

    // player pode controlar tanto a nara quando a lala


    public static Player_estado_atual instancia;
    public static Player_estado_atual Pegar_instancia(){ return instancia; }
    
    public static Player_estado_atual Construir(){ instancia = new Player_estado_atual(); return instancia;}




    public Character personagem_sendo_controlado_player;

    public int posicao_atual = 0;

    public int[] interativos = new int[0]{};

    public int dinheiro = 100;

    public int[] mochila = new int[9];

    // public Item_localizador[] itens_mochila = new Item_localizador[ 9 ];


    public int[] bau = new int[24];

    public Locator_position[] posicao_arr = new Locator_position[20];
    


    public float sadismo = 0f;



    public Block_type[] blocos_anteriores = new Block_type[ 10 ];

    public Block_type bloco_atual;



    public string mapa_atual = "catedral" ;
    public Locator_position[] pontos_mapa;


    public float[][] pontos_mapa_posicoes = new float[][]{

        new float[] { -100f,-100f }, 
        new float[] { 100f,100f }

    };




    public void Iniciar(){}
    public void Zerar_dados(){}



    public void Adicionar_modo_tela( Block_type _novo_bloco ){


        for(int  i = 0 ;   i < blocos_anteriores.Length ; i++){

            if(blocos_anteriores[i] == Block_type.nada) { 

                this.blocos_anteriores[i] = _novo_bloco;
                this.bloco_atual = _novo_bloco;

                return;
            }

        }

        throw new ArgumentException("Nao tem mais espaço no slot para modos tela anteriores em player_estado_atual");

    }

    



    public Block_type Pegar_bloco_anterior(){

        int index_modo_tela_atual_int = -1;

        for( int  i = 0 ; i < blocos_anteriores.Length ; i++ ){

            if( blocos_anteriores[ i ] == Block_type.nada ) {

                if( i < 2 )
                    { return Block_type.nada; }

                int modo_tela_vazio_int = i;
                index_modo_tela_atual_int = ( modo_tela_vazio_int - 1 ); 
                break;

            }

        }

        int index_modo_tela_anterior_int = index_modo_tela_atual_int - 1; 

        Block_type modo_tela_anterior =  blocos_anteriores[ index_modo_tela_anterior_int ];

        return modo_tela_anterior;

    }


    public Block_type Pegar_bloco_atual(){ return bloco_atual;}




    public void Voltar_modo_tela( ) {

        Block_type novo_bloco = Pegar_bloco_anterior();
        bloco_atual = novo_bloco;

        for(int  i = 0 ;   i < blocos_anteriores.Length ; i++){

            if( blocos_anteriores[ i ] == Block_type.nada ) { blocos_anteriores[ i - 1 ] = Block_type.nada;  return;}

        }

    }



    public void Trocar_itens_mochila( int slot_1 ,  int slot_2 ){

        // Item_nome item_1 = itens_mochila[ slot_1 ];
        // Item_nome item_2 = itens_mochila[ slot_2 ];

        // itens_mochila[ slot_1 ] = item_2;
        // itens_mochila[ slot_2 ] = item_1;

        return;

    }



    //public Molde_icone[] icones_movimento;

  

}
