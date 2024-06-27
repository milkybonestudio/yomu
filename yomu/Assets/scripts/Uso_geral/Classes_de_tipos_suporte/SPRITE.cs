using UnityEngine;
using System;





public static class SPRITE {



        public static Sprite Transformar_png_TO_sprite(  byte[] _png  ){


                Texture2D tex = new Texture2D(  1  , 1 , TextureFormat.RGBA32,  false ); 
                tex.LoadImage( _png  );          
                Sprite sprite_retorno =   Sprite.Create(tex  ,     new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f ,0, SpriteMeshType.FullRect   );

                return sprite_retorno;


        }




        public static Sprite Transformar_colors_container_TO_sprite(  Color32[] _container, int _height, int _width  ){

                // pode multithread
                if( ( _height * _width  ) != _container.Length )
                        { throw new Exception( $"dimensoes em Transformar_colors_container_TO_sprite nao vieram corretas, veio {_width}x e { _height }y. O container veio com { _container.Length }px" ); }

                Texture2D tex = new Texture2D(  _width  , _height , TextureFormat.RGBA32,  false ); 

                tex.SetPixelData( _container , 0 );
                tex.Apply( false, false );
                tex.filterMode = UnityEngine.FilterMode.Point;

                Sprite sprite_retorno  =   Sprite.Create(tex  ,     new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f ,0, SpriteMeshType.FullRect   );

                return sprite_retorno;


        }





        public static int Pegar_index_null ( Sprite[] _arr ){


                for( int index =0 ; index < _arr.Length; index++ ){

                        if( _arr[ index ] == null ) { return index; }

                }

                return -1;

        }


        public static Sprite[] Aumentar_length_array( Sprite[] _arr , int numero_para_aumentar ){


                int numero_antigo = _arr.Length ;
                int novo_numero = ( numero_antigo + numero_para_aumentar );
                Sprite[] novo_array = new Sprite[ novo_numero ];

                for( int index =0 ; index < numero_antigo ; index++ ){

                        novo_array [ index ] = _arr[ index ];

                }

                return novo_array;


        }



}


