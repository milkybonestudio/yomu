using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
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



                if( png == null )
                    { CONTROLLER__errors.Throw( "png veio null" ); }

                if( !!!( PNG.Verify_is_png( png ) ) )
                    { CONTROLLER__errors.Throw( "Nao era um png" ); } 


                Image image = null;
                MemoryStream m_s = null; 

                try { m_s = new MemoryStream( png ); image = System.Drawing.Image.FromStream( m_s ); } catch( Exception e ){ CONTROLLER__errors.Throw( $"Could not pass the data of the png { png }, length: { png.Length }" ); }



                Bitmap bm = new Bitmap( image );
            
                BitmapData bitmapData = bm.LockBits (
                                                        new System.Drawing.Rectangle( 0, 0, bm.Width, bm.Height ),
                                                        ImageLockMode.ReadWrite,
                                                        PixelFormat.Format32bppArgb  
                                                    );


                int length = ( bitmapData.Height * bitmapData.Width );

                Color32* native_container_pointer_fix = ( Color32* ) _native_arr_texture.GetUnsafePtr();
                Color32* data_descompress_container_fix = ( ( Color32*)  bitmapData.Scan0.ToPointer() );


                Color32* native_container_pointer = native_container_pointer_fix;
                Color32* data_descompress_container = data_descompress_container_fix;



                // Color32* data_descompress_container_1 = ( data_descompress_container + 0 ) - 4 ; 
                // Color32* data_descompress_container_2 = ( data_descompress_container + 1 ) - 4 ; 
                // Color32* data_descompress_container_3 = ( data_descompress_container + 2 ) - 4 ; 
                // Color32* data_descompress_container_4 = ( data_descompress_container + 3 ) - 4 ; 



                for( int pixel_height = 0 ; pixel_height < ( bitmapData.Height  ) ; pixel_height++ ){


                    int pixels_done = ( ( pixel_height ) * bitmapData.Width );
                    int last_position = ( length - bitmapData.Width );

                    native_container_pointer = native_container_pointer_fix + ( last_position - pixels_done );


                    // Color32* native_container_pointer_1 = ( native_container_pointer + 0 ) - 4 ; 
                    // Color32* native_container_pointer_2 = ( native_container_pointer + 1 ) - 4 ; 
                    // Color32* native_container_pointer_3 = ( native_container_pointer + 2 ) - 4 ; 
                    // Color32* native_container_pointer_4 = ( native_container_pointer + 3 ) - 4 ; 


                    // int loop_length = bitmapData.Width / ( 4 * 4 );
                    // int pixels_left = bitmapData.Width - ( loop_length * ( 4 * 4 ) );   

                    //test
                    // ** nos testes normais nao tem como ter certeza qual é o mais rapido, depois testar melhor

                    System.Buffer.MemoryCopy( ( void* ) data_descompress_container, ( void* ) native_container_pointer, long.MaxValue, ( long ) ( bitmapData.Width * sizeof( Color32 ) ) );
                    data_descompress_container += bitmapData.Width;

                    // for( int pixel_width = 0 ; pixel_width < loop_length ; pixel_width++ ){




                    //         native_container_pointer_1 += 4;
                    //         native_container_pointer_2 += 4;
                    //         native_container_pointer_3 += 4;
                    //         native_container_pointer_4 += 4;

                    //         data_descompress_container_1 += 4;
                    //         data_descompress_container_2 += 4;
                    //         data_descompress_container_3 += 4;
                    //         data_descompress_container_4 += 4;


                    //             *native_container_pointer_1 = *data_descompress_container_1;
                    //             *native_container_pointer_2 = *data_descompress_container_2;
                    //             *native_container_pointer_3 = *data_descompress_container_3;
                    //             *native_container_pointer_4 = *data_descompress_container_4;


                    //         native_container_pointer_1 += 4;
                    //         native_container_pointer_2 += 4;
                    //         native_container_pointer_3 += 4;
                    //         native_container_pointer_4 += 4;

                    //         data_descompress_container_1 += 4;
                    //         data_descompress_container_2 += 4;
                    //         data_descompress_container_3 += 4;
                    //         data_descompress_container_4 += 4;


                    //             *native_container_pointer_1 = *data_descompress_container_1;
                    //             *native_container_pointer_2 = *data_descompress_container_2;
                    //             *native_container_pointer_3 = *data_descompress_container_3;
                    //             *native_container_pointer_4 = *data_descompress_container_4;

                    //         native_container_pointer_1 += 4;
                    //         native_container_pointer_2 += 4;
                    //         native_container_pointer_3 += 4;
                    //         native_container_pointer_4 += 4;

                    //         data_descompress_container_1 += 4;
                    //         data_descompress_container_2 += 4;
                    //         data_descompress_container_3 += 4;
                    //         data_descompress_container_4 += 4;


                    //             *native_container_pointer_1 = *data_descompress_container_1;
                    //             *native_container_pointer_2 = *data_descompress_container_2;
                    //             *native_container_pointer_3 = *data_descompress_container_3;
                    //             *native_container_pointer_4 = *data_descompress_container_4;

                    //         native_container_pointer_1 += 4;
                    //         native_container_pointer_2 += 4;
                    //         native_container_pointer_3 += 4;
                    //         native_container_pointer_4 += 4;

                    //         data_descompress_container_1 += 4;
                    //         data_descompress_container_2 += 4;
                    //         data_descompress_container_3 += 4;
                    //         data_descompress_container_4 += 4;


                    //             *native_container_pointer_1 = *data_descompress_container_1;
                    //             *native_container_pointer_2 = *data_descompress_container_2;
                    //             *native_container_pointer_3 = *data_descompress_container_3;
                    //             *native_container_pointer_4 = *data_descompress_container_4;




                    // }

                    

                    // // ** resto

                    // data_descompress_container_1 += pixels_left;
                    // data_descompress_container_2 += pixels_left;
                    // data_descompress_container_3 += pixels_left;
                    
                
                    // while( pixels_left-- > 0 )
                    //     // { *native_container_pointer_4++ = *data_descompress_container_4++; }
                    //     { *++native_container_pointer_4 = *++data_descompress_container_4; }

 

                }


                m_s.Dispose();
                bm.Dispose();
                image.Dispose();

            

        
            return;


        }


}



