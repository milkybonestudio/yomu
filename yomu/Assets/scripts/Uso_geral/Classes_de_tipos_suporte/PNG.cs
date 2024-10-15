using System;
using UnityEngine;
using Png_decoder;


public static class PNG {


        public static Color32[] Descomprimir( byte[] _png ){

                int[] width_E_height = Pegar_width_e_height( _png );
                int width = width_E_height[ 0 ] ;
                int height = _png[ 0 ] ;

                Png image = Png.Open( _png );

                Color32[] container_cores = new Color32[  ( width *  height )  ];

                int p = 0;

                for( int h = 0 ; h < height ; h++ ){

                        for(  int w = 0 ; w < width ; w++ ){

                            Pixel pixel = image.GetPixel( w, ( height - 1 -  h ) );

                            // int p = ( w ) + ( h  * width );

                            container_cores[ p ].r =  pixel.R;
                            container_cores[ p ].g =  pixel.G; 
                            container_cores[ p ].b =  pixel.B; 
                            container_cores[ p ].a =  pixel.A; 
                            p++;

                        }

                }


                return container_cores;

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