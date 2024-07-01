using UnityEngine;
using System;

/*

    nao vai existir no jogo, somente no editor

    quando for construir a build =>  compilar para pegar o byte_arr => criar novo .dat
    sempre deixar a ram o .dat com a cidade inteira. se ficar muito grande pode trocar para regiao

*/
#if ( UNITY_EDITOR && CIDADE_SAINT_LAND ) || FORCAR_TODOS_OS_ESTADOS 



    public static class SAINT_LAND__VILLAGE__CENTER_interativos_lista {

        public static Interativo[] interativos;

        public static Interativo Pegar_interativo( int _interativo_id ){

            if( interativos == null )
                { Colocar_interativos(); }

            if( interativos[ _interativo_id ] == null )
                                                           
                { throw new Exception( $" o interativo { ( SAINT_LAND__VILLAGE__CENTER_interativo ) _interativo_id } na nao foi criado" ); }

            return interativos[ _interativo_id ];

        }


        public static void Colocar_interativos(){

            interativos = new Interativo[ 100 ];

            int index = 0;


            interativos[ index ] = new Interativo( index );
            interativos[ index ].tipo =  Tipo_interativo.movimento;
            interativos[ index ].nome =  "aa";


            interativos[ index ].tipo_mouse_hover = Interativo_tipo_mouse_hover.nada_E_nada;
            interativos[ index ].ponto_nome = Ponto_nome.nada;
            interativos[ index ].area = new float[]{0f,0f};
            interativos[ index ].cor_cursor = 0 ;


        }





    }


#endif