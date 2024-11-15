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


        public static WebP w = new WebP();
    
        public static void Transfer_data_WEABP( RESOURCE__image _image,  RESOURCE__image_data _image_data ){

                // ** somente para low_quality

                byte[] webp =  _image_data.image_low_quality_compress;
                try{

                    w.Transfer_data( webp, _image.width, _image.height, _image_data.texture_exclusiva_native_array );

                } catch ( Exception E ){

                    Console.Log( E.Message );
                }
                
                return;

        }

        public static void Transfer_data_PNG( byte[] png,  NativeArray<Color32> _native_arr_texture ){

                Console.Log( "Veio Transfer_data_PNG" );
                
                CONTROLLER__errors.Verify( ( png == null ) , "png veio null" );
                CONTROLLER__errors.Verify( !!!( PNG.Verify_is_png( png ) ), "Nao era um png" );

                Image image = null;
                MemoryStream m_s = null; 

                try { m_s = new MemoryStream( png ); image = System.Drawing.Image.FromStream( m_s ); } catch( Exception e ){ CONTROLLER__errors.Throw( $"Could not pass the data of the png { png }, length: { png.Length }" ); }


                Bitmap bm = new Bitmap( image );

                BitmapData bitmapData = bm.LockBits (
                                                        new System.Drawing.Rectangle( 0, 0, bm.Width, bm.Height ),
                                                        ImageLockMode.ReadOnly,
                                                        PixelFormat.Format32bppArgb // ** talvez trenha que inverter
                                                    );


                


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


                for( int height = ( bm.Height - 1 ) ; height > -1  ; height-- ){

                        // ** imagem esta inversa no bitmap. tem que fazer a height ao contrario

                        int teste_length = ( bm.Width / 4 ) * 4 ;

                        for( int height_pixel = 0 ; height_pixel < teste_length ; height_pixel += 4 ){

                                
                                // ** reseta container
                                p_container_1 = ( p_container + 0 ) ;
                                p_container_2 = ( p_container + 1 ) ;
                                p_container_3 = ( p_container + 2 ) ;
                                p_container_4 = ( p_container + 3 ) ;
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

                Console.Log( "finalizou" );

                // --- CLEAN 

                m_s.Dispose();
                bm.Dispose();
                image.Dispose();

        
            return;


        }





}



