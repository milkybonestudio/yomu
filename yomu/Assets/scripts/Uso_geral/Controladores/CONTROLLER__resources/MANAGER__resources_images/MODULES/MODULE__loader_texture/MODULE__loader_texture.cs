using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Unity.Collections;
using UnityEngine;


//mark
// ** acho que isso pode excluir
public struct Data_tex {

    public Texture2D tex;
    public NativeArray<Color32> arr;

}


public enum Type_image {

    png, webp,

}


unsafe public static class TOOL__loader_texture {



        // ** seria bom dar o apply tudo de uma vez 

        public static void Transfer_data( RESOURCE__image_data _image, Type_image _type ){

                // switch( _type ){

                //     case Type_image.png: Transfer_data_PNG( _image.png ); return;
                //     case Type_image.webp: Transfer_data_WEABP( _image ); return;

                // }

                // talvez mudar depois
            _image.texture_allocated.texture.Apply();

        }


        

        private static void Generate_information( RESOURCE__image_data _image_data, int _width, int _height ){


                // // ** 1 cenario, dont flip
                // if( _image_data.width <= _width && _image_data.height <= _height )
                //     {
                //         // --- PASSOU
                //         _image_data.default_rotation = 0f;
                //         _image_data.height_margin = ( _height - _image_data.height );
                //         _image_data.width_margin  = ( _width - _image_data.width );
                //         return;

                //     }


                // // ** 2 cenario, dont flip
                // if( _image_data.width <= _height && _image_data.height <= _width )
                //     {
                //         // --- PASSOU
                //         _image_data.default_rotation = 0.25f;
                //         _image_data.height_margin = ( _height - _image_data.width );
                //         _image_data.width_margin  = ( _width - _image_data.height );
                //         return;
                //     }

                throw new System.Exception( "nao pode colocar imagem na texture, texture muito pequena" );

                
        }


    
        public static void Transfer_data_WEABP( RESOURCE__image_data _image_data ){

            // ** somente para low_quality

        }

        public static void Transfer_data_PNG( byte[] png,  NativeArray<Color32> _native_arr_texture ){

                Console.Log( "Veio Transfer_data_PNG" );

                Bitmap bm = new Bitmap( System.Drawing.Image.FromStream( new MemoryStream( png )) );
                
                BitmapData bitmapData = bm.LockBits (
                                                        new System.Drawing.Rectangle( 0, 0, bm.Width, bm.Height ),
                                                        ImageLockMode.ReadOnly,
                                                        PixelFormat.Format32bppArgb // ** talvez trenha que inverter
                                                    );


                // Generate_information( _image_data,  bitmapData.Width, bitmapData.Height );

                

                //mark
                //** ver amanha


                
                int* p_container_origin = stackalloc int[ 4 ];
                

                byte* p_data = ( byte* ) bitmapData.Scan0;
                byte* p_container = ( byte* ) p_container_origin;

                byte* p_container_1 = ( p_container + 0 )  ;
                byte* p_container_2 = ( p_container + 1 )  ;
                byte* p_container_3 = ( p_container + 2 )  ;
                byte* p_container_4 = ( p_container + 3 )  ;

                byte* p_data_1 = ( p_data + 0 ) - 4 ;
                byte* p_data_2 = ( p_data + 1 ) - 4 ;
                byte* p_data_3 = ( p_data + 2 ) - 4 ;
                byte* p_data_4 = ( p_data + 3 ) - 4 ;

                // tem muitas variaveis sendo usadas para passar como funcao
                // tentar pensar em um jeito melhor depois

                // int u = 0;


                for( int height = ( bm.Height - 1 ) ; height > 0  ; height-- ){

                    // ** imagem esta inversa no bitmap. tem que fazer a height ao contrario

                    for( int height_pixel = 0 ; height_pixel < bm.Width ; height_pixel += 4 ){


                            // ** reseta container
                            p_container_1 = ( p_container + 0 )  ;
                            p_container_2 = ( p_container + 1 )  ;
                            p_container_3 = ( p_container + 2 )  ;
                            p_container_4 = ( p_container + 3 )  ;


                            p_data_1 += 4;
                            p_data_2 += 4;
                            p_data_3 += 4;
                            p_data_4 += 4;

                            *p_container_1 = *p_data_3;
                            *p_container_2 = *p_data_2;
                            *p_container_3 = *p_data_1;
                            *p_container_4 = *p_data_4;

                    
                            // --- LEU B1


                            p_container_1 += 4 ;
                            p_container_2 += 4 ;
                            p_container_3 += 4 ;
                            p_container_4 += 4 ;

                            p_data_1 += 4;
                            p_data_2 += 4;
                            p_data_3 += 4;
                            p_data_4 += 4;


                            *p_container_1 = *p_data_3;
                            *p_container_2 = *p_data_2;
                            *p_container_3 = *p_data_1;
                            *p_container_4 = *p_data_4;

                            // --- LEU B2


                            p_container_1 += 4 ;
                            p_container_2 += 4 ;
                            p_container_3 += 4 ;
                            p_container_4 += 4 ;

                            p_data_1 += 4;
                            p_data_2 += 4;
                            p_data_3 += 4;
                            p_data_4 += 4;


                            *p_container_1 = *p_data_3;
                            *p_container_2 = *p_data_2;
                            *p_container_3 = *p_data_1;
                            *p_container_4 = *p_data_4;
                            // --- LEU B3


                            p_container_1 += 4 ;
                            p_container_2 += 4 ;
                            p_container_3 += 4 ;
                            p_container_4 += 4 ;

                            p_data_1 += 4;
                            p_data_2 += 4;
                            p_data_3 += 4;
                            p_data_4 += 4;


                            *p_container_1 = *p_data_3;
                            *p_container_2 = *p_data_2;
                            *p_container_3 = *p_data_1;
                            *p_container_4 = *p_data_4;

                            // --- LEU B4


                            int ponto_pixel = ( height * bm.Width ) + height_pixel;

                            // --- PASSA 4 PIXELS DE 1 VEZ
                            _native_arr_texture[ ponto_pixel + 0 ] =  *( Color32* ) ( p_container_origin + 0 );
                            _native_arr_texture[ ponto_pixel + 1 ] =  *( Color32* ) ( p_container_origin + 1 );
                            _native_arr_texture[ ponto_pixel + 2 ] =  *( Color32* ) ( p_container_origin + 2 );
                            _native_arr_texture[ ponto_pixel + 3 ] =  *( Color32* ) ( p_container_origin + 3 );
                        

                        }

                        int ponto_inicial_final  = bm.Width - ( bm.Width % 4 );

                        for( int i = ponto_inicial_final ; i < bm.Width ; i++ ){


                                p_container_1 += 4 ;
                                p_container_2 += 4 ;
                                p_container_3 += 4 ;
                                p_container_4 += 4 ;

                                p_data_1 += 4;
                                p_data_2 += 4;
                                p_data_3 += 4;
                                p_data_4 += 4;

                                *p_container_1 = *p_data_4;
                                *p_container_2 = *p_data_3;
                                *p_container_3 = *p_data_2;
                                *p_container_4 = *p_data_1;

                                int ponto_pixel = ( height * bm.Width ) + i;

                                _native_arr_texture[ ponto_pixel ] = *( Color32* ) p_container_origin ;
                                continue;

                        }



                }



                // for( int index = ( _native_arr_texture.Length - 1 ) ; index > 0 ; index-- ){
                for( int index = 0 ; index < _native_arr_texture.Length ; index++ ){

                        // u = ( u + 1 ) % 1_000;
                        // if( u == 0 )
                        //     { Console.Log( "index: " + index ); }

                        // // ** reseta container
                        // p_container_1 = ( p_container + 0 )  ;
                        // p_container_2 = ( p_container + 1 )  ;
                        // p_container_3 = ( p_container + 2 )  ;
                        // p_container_4 = ( p_container + 3 )  ;


                        // p_data_1 += 4;
                        // p_data_2 += 4;
                        // p_data_3 += 4;
                        // p_data_4 += 4;

                        // *p_container_1 = *p_data_3;
                        // *p_container_2 = *p_data_2;
                        // *p_container_3 = *p_data_1;

                        // *p_container_4 = *p_data_4;

                
                        // _native_arr_texture[ index ] =  *( Color32* ) ( p_container_origin );
            

                        // // ** reseta container
                        // p_container_1 = ( p_container + 0 )  ;
                        // p_container_2 = ( p_container + 1 )  ;
                        // p_container_3 = ( p_container + 2 )  ;
                        // p_container_4 = ( p_container + 3 )  ;


                        // p_data_1 += 4;
                        // p_data_2 += 4;
                        // p_data_3 += 4;
                        // p_data_4 += 4;

                        // *p_container_1 = *p_data_2;
                        // *p_container_2 = *p_data_3;
                        // *p_container_3 = *p_data_4;
                        // *p_container_4 = *p_data_1;

                
                        // // --- LEU B1


                        // p_container_1 += 4 ;
                        // p_container_2 += 4 ;
                        // p_container_3 += 4 ;
                        // p_container_4 += 4 ;

                        // p_data_1 += 4;
                        // p_data_2 += 4;
                        // p_data_3 += 4;
                        // p_data_4 += 4;


                        // *p_container_1 = *p_data_2;
                        // *p_container_2 = *p_data_3;
                        // *p_container_3 = *p_data_4;
                        // *p_container_4 = *p_data_1;

                        // // --- LEU B2


                        // p_container_1 += 4 ;
                        // p_container_2 += 4 ;
                        // p_container_3 += 4 ;
                        // p_container_4 += 4 ;

                        // p_data_1 += 4;
                        // p_data_2 += 4;
                        // p_data_3 += 4;
                        // p_data_4 += 4;


                        // *p_container_1 = *p_data_2;
                        // *p_container_2 = *p_data_3;
                        // *p_container_3 = *p_data_4;
                        // *p_container_4 = *p_data_1;
                        // // --- LEU B3


                        // p_container_1 += 4 ;
                        // p_container_2 += 4 ;
                        // p_container_3 += 4 ;
                        // p_container_4 += 4 ;

                        // p_data_1 += 4;
                        // p_data_2 += 4;
                        // p_data_3 += 4;
                        // p_data_4 += 4;


                        // *p_container_1 = *p_data_2;
                        // *p_container_2 = *p_data_3;
                        // *p_container_3 = *p_data_4;
                        // *p_container_4 = *p_data_1;

                        // // --- LEU B4


                        // // --- PASSA 4 PIXELS DE 1 VEZ
                        // _native_arr_texture[ index + 0 ] =  *( Color32* ) ( p_container_origin + 0 );
                        // _native_arr_texture[ index + 1 ] =  *( Color32* ) ( p_container_origin + 1 );
                        // _native_arr_texture[ index + 2 ] =  *( Color32* ) ( p_container_origin + 2 );
                        // _native_arr_texture[ index + 3 ] =  *( Color32* ) ( p_container_origin + 3 );

                        continue;


                }

                Console.Log( "terminou loop das cores" );


                // int ponto_inicial_final  = _native_arr_texture.Length - ( _native_arr_texture.Length % 4 );

                // for( int i = ponto_inicial_final ; i < _native_arr_texture.Length ; i++ ){


                //         p_container_1 += 4 ;
                //         p_container_2 += 4 ;
                //         p_container_3 += 4 ;
                //         p_container_4 += 4 ;

                //         p_data_1 += 4;
                //         p_data_2 += 4;
                //         p_data_3 += 4;
                //         p_data_4 += 4;


                //         *p_container_1 = *p_data_4;
                //         *p_container_2 = *p_data_3;
                //         *p_container_3 = *p_data_2;
                //         *p_container_4 = *p_data_1;

                //         _native_arr_texture[ i ] = *( Color32* ) p_container_origin ;
                //         continue;

                // }

            Console.Log( "terminou" );

            return;


        }





}



