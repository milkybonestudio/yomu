using System;
using UnityEngine;


public static class PNG {



        public static void Save_png( string _path, Texture2D _image ){

            System.IO.File.WriteAllBytes( _path, _image.EncodeToPNG() );

        }



        public static Sprite Transformar_png_TO_sprite(  byte[] _png  ){


                Texture2D tex = new Texture2D(  1, 1, TextureFormat.RGBA32, false ); 
                tex.LoadImage( _png  );
                Sprite sprite_retorno = Sprite.Create( tex, new Rect( 0.0f, 0.0f, tex.width, tex.height ), new Vector2( 0.5f, 0.5f ), 100.0f, 0, SpriteMeshType.FullRect );

                return sprite_retorno;

        }


        public static bool Verify_is_png( byte[] _bytes ){

            int i = 10;

            if( _bytes[ 0 ] != 137 )
                { i = i * 0; }
            
            if( _bytes[ 1 ] != 80 )
                { i = i * 0; }

            if( _bytes[ 2 ] != 78 )
                { i = i * 0; }
            if( _bytes[ 3 ] != 71 )
                { i = i * 0; }
            if( _bytes[ 4 ] != 13 )
                { i = i * 0; }
            if( _bytes[ 5 ] != 10 )
                { i = i * 0; }
            if( _bytes[ 6 ] != 26 )
                { i = i * 0; }
            if( _bytes[ 7 ] != 10 )
                { i = i * 0; }

            return i > 0;

        }


        public static Dimensions Get_dimensions( byte[] _png_byte_arr ){


                /*


                ordem dos bytes: 
                primeiros 8 são sempre: 137 80 78 71 13 10 26 10 ( bytes de assinatura do png)
                depois vem os chunks. O primeiro ( IHDR ) tem as informacoes de width e height 
                formato dos chunks: 
                - 4 bytes : quantos bytes os dados tem
                - 4 bytes referentes ao tipo 
                - data 
                - 4 bytes que mostram quantos bytes tem no chunk ( mas não pega a length ( 4 primeiros  ) por algum motivo ) 

                O ihdr:

                                Width:              4 bytes
                                Height:             4 bytes
                                Bit depth:          1 byte
                                Color type:         1 byte
                                Compression method: 1 byte
                                Filter method:      1 byte
                                Interlace method:   1 byte

                
                */

                // 8 iniciais + 4 do length + 4 do tipo = 16 => termina no elemento 16 => termina no index 15 => começa no index 16 
                // 137 80 78 71 13 10 26 10 x x x x y y y y ( start )  

                int width = 0;
                int height = 0;
                int ponto_inicial = 16;
                Dimensions retorno = new Dimensions();

                int index = 0;
                int multiplicador = 1;

                for( index = 3 ; index != -1 ; index--  ){


                        width +=   multiplicador  *  _png_byte_arr[ ponto_inicial + index ]  ;
                        height +=   multiplicador  *  _png_byte_arr[ ponto_inicial + index + 4 ]  ;

                        multiplicador *= 256;

                }


                retorno.width = width ;
                retorno.height = height ;

                return retorno;


        }




        public static int[] Pegar_width_e_height( byte[]  _png_byte_arr ){


                /*


                ordem dos bytes: 
                primeiros 8 são sempre: 137 80 78 71 13 10 26 10 ( bytes de assinatura do png)
                depois vem os chunks. O primeiro ( IHDR ) tem as informacoes de width e height 
                formato dos chunks: 
                - 4 bytes : quantos bytes os dados tem
                - 4 bytes referentes ao tipo 
                - data 
                - 4 bytes que mostram quantos bytes tem no chunk ( mas não pega a length ( 4 primeiros  ) por algum motivo ) 

                O ihdr:

                                Width:              4 bytes
                                Height:             4 bytes
                                Bit depth:          1 byte
                                Color type:         1 byte
                                Compression method: 1 byte
                                Filter method:      1 byte
                                Interlace method:   1 byte

                
                */

                // 8 iniciais + 4 do length + 4 do tipo = 16 => termina no elemento 16 => termina no index 15 => começa no index 16 
                // 137 80 78 71 13 10 26 10 x x x x y y y y ( start )  

                int width = 0;
                int height = 0;
                int ponto_inicial = 16;
                int[] retorno = new int[ 2 ];

                int index = 0;
                int multiplicador = 1;

                for( index = 3 ; index != -1 ; index--  ){


                        width +=   multiplicador  *  _png_byte_arr[ ponto_inicial + index ]  ;
                        height +=   multiplicador  *  _png_byte_arr[ ponto_inicial + index + 4 ]  ;

                        multiplicador *= 256;

                }

                Debug.Log( "height: " + height ) ;
                Debug.Log( "width: " + width ) ;

                retorno[ 0 ] = width ;
                retorno[ 1 ] = height ;

                return retorno;


        }






}