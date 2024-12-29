using System;
using UnityEngine;


// 1 default, 1 espeficio player( dif ) e 1 current
unsafe public struct Cursor_binding {

        public fixed int _default[ 250 ]; 
        public fixed int _mouse_2[ 250 ];

}


unsafe public class MANAGER__cursor {


        public void Change_action( Cursor_action _action ){}

        // ** nao vai saber qual mouse vai estar sendo usado, vai entregar todas as possivbilidades 
        // ** nao vai ser muito usado
        public void Change_mode( int[] _possible_modes ){}
        
        // ** o player nao consegue mudar o binding mas o sistema consegue. 
        // ** se precisar mudar para algum pode mudar runtime por aqui e tem que mudar em algum lugar que va salvar
        // ** mas o binding também depende dos cursores
        
        public void Change_binds( Cursor_binding* _binds ){

            // salvar mudança binds(  ( byte* )_binds, sizeof( Cursor_binding ) )

        } // ??

        public void Restore_binds(){} 

        
        public void Change_cursor_( Cursor_type _novo_cursor ){ 


            if( type == _novo_cursor )
                { return; }
            
            type = _novo_cursor;

            // ** tem que deletar as textures e audios

            // ** 



            switch( _novo_cursor ){

                case Cursor_type._default: cursor = new Cursor_default(); break;
                default : throw new Exception( $"Nao achou o cursor { _novo_cursor }" );

            }

        }
    


    public INTERFACE__cursor cursor;
    public Cursor_type type;

    public Vector2 posicao_cursor;
    public GameObject cursor_game_object;



    public void Mover_cursor( float _adicional_x, float _adicional_y ){

            float nova_posicao_x = ( posicao_cursor.x + _adicional_x );
            float nova_posicao_y = ( posicao_cursor.y + _adicional_y );
            

    }

    public void Setar_posicao_cursor( float _posicao_x, float _posicao_y ){

    }





}