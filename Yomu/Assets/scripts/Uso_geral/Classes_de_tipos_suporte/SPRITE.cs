using UnityEngine;
using System;





public static class SPRITE {



        public static int Pegar_index_null ( Sprite[] _arr ){


                for( int index =0 ; index < _arr.Length; index++ ){

                        if( _arr[ index ] == null ) { return index; }

                }

                return -1;

        }


        public static void Aumentar_length_array( ref Sprite[] _arr , int numero_para_aumentar ){


                int numero_antigo = _arr.Length ;
                int novo_numero = ( numero_antigo + numero_para_aumentar );
                Sprite[] novo_array = new Sprite[ novo_numero ];

                for( int index =0 ; index < numero_antigo ; index++ ){

                        novo_array [ index ] = _arr[ index ];

                }

                _arr = novo_array;


        }



}


