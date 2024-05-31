using UnityEngine;
using UnityEngine.UI;
using System;





    public class Mochila_slot {


        public Item_nome item_nome = Item_nome.nada; 
        public Slot_generico generico = null;


        public Mochila_slot(    Item_nome _item_nome  ,  string _nome,  GameObject _pai, string _path_imagem , float[] _posicao , Cor_cursor _cor      ){


            float _height = 100f;
            float _width  = 100f;

            generico =  new Slot_generico(   _nome,  _pai, _height , _width  ,  _path_imagem , _posicao ,  _cor  );
            item_nome = _item_nome;

        }



    }

    public class Slot_generico { 


            public GameObject game_object = null;
            public Image imagem = null ;
            public Cor_cursor cor_cursor = Cor_cursor.red ;
            public float[] min_max_rect = new float [ 4 ] ;
            public float[] posicao = new float[ 2 ] ;


            public Slot_generico(   string _nome,  GameObject _pai, float _height , float _width  , string _path_imagem , float[] _posicao , Cor_cursor _cor ) {


                        this.game_object = Geral.Criar_imagem(   _nome,  _pai,  _width,  _height,  _path_imagem , 1f  ) ;
                        this.imagem = Geral.ultima_imagem ;

                        posicao = _posicao ;
                    
                        game_object.transform.localPosition = new Vector3(  posicao[ 0 ], posicao[ 1 ],  0f ) ;

                        min_max_rect[ 0 ] =  posicao[ 0 ] - ( _width / 2f ) + 960f ;
                        min_max_rect[ 1 ] =  posicao[ 0 ] + ( _width / 2f ) + 960f ;

                        min_max_rect[ 2 ] = posicao[ 1 ] - ( _height / 2f ) + 540f ;
                        min_max_rect[ 3 ] = posicao[ 1 ] + ( _height / 2f ) + 540f ;

                        return;

            }


    }







public static class Icone_barra_mochila {

    public static Mochila_slot[] slots_mochila = null ;
    public static string dinheiro = "$0" ;


    public static bool hold_esta_ativado = false ;
    public static int hold_slot = -1 ;
    public static Vector3 posicao_hold_original = Vector3.zero ;

    public static Display_texto_simples display_dinheiro = null ;
    

    public static bool Update() { 





                                  
                                                        
            if( Controlador_input.Get_down ( Key_code.esc) ) { 

                Encerrar() ;
                return true ;
                
            }


            bool click = Controlador_input.Get_down( Key_code.mouse_left );
            float[] posicao = Controlador_dados.Pegar_instancia().posicao_mouse;
            


            if( hold_esta_ativado ){

                    

                    Mochila_slot slot_hold  =  slots_mochila[ hold_slot ];


                    if( !Controlador_input.Get_up( Key_code.mouse_left ) ){
                        // arastar

                            
                        slot_hold.generico.game_object.transform.localPosition = new Vector3(  posicao[ 0 ] - 960f,  posicao[ 1 ] - 540f , 0f ) ;
                        return false;

                    } 

                    //   soltar
                    //  verificar se pode ser colocado em algum slot

                    slot_hold.generico.game_object.transform.localPosition = posicao_hold_original ;
                    



                    for( int slot_index_soltar = 0 ; slot_index_soltar < slots_mochila.Length ; slot_index_soltar++ ) {


                            Mochila_slot slot = slots_mochila [ slot_index_soltar ] ;
                            
                            float[] min_max = slot.generico.min_max_rect ;

                            bool passou  =  Mat.Verificar_ponto_dentro_retangulo ( posicao[ 0 ] , posicao[ 1 ] , min_max[ 0 ] , min_max[ 1 ] , min_max[ 2 ] , min_max[ 3 ] ) ;

                            if( passou ){

                                    if( slot_index_soltar == hold_slot ){

                                            break;

                                    }

                                    // Trocar_itens_slots()


                                    Player_estado_atual.Pegar_instancia().Trocar_itens_mochila( hold_slot, slot_index_soltar );


                                    Item_nome item_slot_1 = slot_hold.item_nome;
                                    Item_nome item_slot_2 = slot.item_nome;

                                    slot_hold.item_nome = item_slot_2;
                                    slot.item_nome = item_slot_1;

                                    Cor_cursor cor_1 = slot_hold.generico.cor_cursor;
                                    Cor_cursor cor_2 = slot.generico.cor_cursor;

                                    slot_hold.generico.cor_cursor = cor_2 ;
                                    slot.generico.cor_cursor = cor_1 ;

                                    Sprite sprite_1 = slot_hold.generico.imagem.sprite;
                                    Sprite sprite_2 = slot.generico.imagem.sprite;

                                    slot_hold.generico.imagem.sprite = sprite_2;
                                    slot.generico.imagem.sprite = sprite_1;

                                    break;


                            }

                    }

                    posicao_hold_original = Vector3.zero ;
                    hold_esta_ativado = false;
                    hold_slot = -1;
                    return false;
                
            }


            // nao esta segutando nada


            for( int slot_index = 0 ; slot_index < slots_mochila.Length ; slot_index++ ) {


                    Mochila_slot slot = slots_mochila [ slot_index ] ;
                    
                    float[] min_max = slot.generico.min_max_rect ;

                    bool passou  =  Mat.Verificar_ponto_dentro_retangulo ( posicao[ 0 ] , posicao[ 1 ] , min_max[ 0 ] , min_max[ 1 ] , min_max[ 2 ] , min_max[ 3 ] ) ;

                    if( passou ){

                            if( click ) {

                                    // comecar segurar
                                                
                                    posicao_hold_original = slot.generico.game_object.transform.localPosition;
                                    slot.generico.game_object.transform.SetSiblingIndex( ( slots_mochila.Length - 1 ) );
                                    hold_esta_ativado = true;
                                    hold_slot = slot_index;
                                    Controlador_cursor.Pegar_instancia().Mudar_cursor( Cor_cursor.blue );
                                    return false ;

                            }


                            Controlador_cursor.Pegar_instancia().Mudar_cursor( Cor_cursor.red ) ;
                            return false ;


                    }

            }

            Controlador_cursor.Pegar_instancia().Mudar_cursor( Cor_cursor.off );

            return false ;


    }



    public static void Encerrar(){

            Debug.Log("veio encerrar");

            Mono_instancia.Destroy( game_object ) ;
            game_object = null ; 


    }



    public static void Soltar(){


    }







    public static GameObject game_object = null;


    public static void  Criar( GameObject _game_object ){



        game_object = Geral.Criar_imagem("mochila", _game_object , 550f, 725f, null, 1f );
        
        Player_estado_atual p  =  Player_estado_atual.Pegar_instancia() ; 

        int dinheiro = p.dinheiro;

        display_dinheiro = new Display_texto_simples( "dinheiro" ,300f, 70f, 30f );
        display_dinheiro.Setar_display( game_object.transform ,  0f, -320f );
        display_dinheiro.Colocar_texto(  "$" + dinheiro.ToString() , Color.black );
        display_dinheiro.Centralizar_texto();

        Item_nome[] itens = p.itens_mochila;

        int numero_itens = itens.Length ;

        slots_mochila = new Mochila_slot[ numero_itens ];
        
        string fundo = "images/utilidade_geral/icones_itens/";


        for( int i = 0 ; i < numero_itens ; i++ ){


                float[] posicao = Pegar_posicao( i );
                string path_ponto_sprite = ( fundo + itens[ i ].ToString() );


                Mochila_slot mochila_slot = new Mochila_slot(

                    _item_nome: itens[ i ],
                    _nome: ( "item_ " + itens[ i ].ToString() + "_" + i.ToString()),
                    _pai : game_object,
                    _path_imagem: path_ponto_sprite,
                    _posicao: posicao,
                    _cor: Cor_cursor.red

                ) ;


                slots_mochila[ i ] =  mochila_slot ;

                mochila_slot.item_nome = itens [ i ];



        }


        //  Item_nome _item_nome  ,  string _nome,  GameObject _pai, string _path_imagem , float[] _posicao , Cor_cursor _cor   


        float[] Pegar_posicao( int index ){

            float[] retorno = new float[ 2 ];

            retorno[ 0 ] =  ( float ) ((( index ) % 3) - 1)  * 150f;

            retorno[ 1 ] =  ( float ) ( 1 - ( index / 3 )) * 200f  ;

            return retorno;

        }


    } 


    public static void Destruir(){}




}