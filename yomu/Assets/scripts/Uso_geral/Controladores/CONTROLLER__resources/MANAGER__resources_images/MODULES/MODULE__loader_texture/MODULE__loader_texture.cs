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




unsafe public static class TOOL__loader_texture {



        // ** seria bom dar o apply tudo de uma vez 

        public static void Transfer_data( RESOURCE__image_data _image ){

                switch( _image.type){

                    case Type_image.png: Transfer_data_PNG( _image ); return;
                    case Type_image.webp: Transfer_data_WEABP( _image ); return;

                }

                // talvez mudar depois
            _image.texture_allocated.texture.Apply();

        }


        

        private static void Generate_information( RESOURCE__image_data _image_data, int _width, int _height ){


                // ** 1 cenario, dont flip
                if( _image_data.width <= _width && _image_data.height <= _height )
                    {
                        // --- PASSOU
                        _image_data.default_rotation = 0f;
                        _image_data.height_margin = ( _height - _image_data.height );
                        _image_data.width_margin  = ( _width - _image_data.width );
                        return;

                    }


                // ** 2 cenario, dont flip
                if( _image_data.width <= _height && _image_data.height <= _width )
                    {
                        // --- PASSOU
                        _image_data.default_rotation = 0.25f;
                        _image_data.height_margin = ( _height - _image_data.width );
                        _image_data.width_margin  = ( _width - _image_data.height );
                        return;
                    }

                throw new System.Exception( "nao pode colocar imagem na texture, texture muito pequena" );

                
        }


    
        public static void Transfer_data_WEABP( RESOURCE__image_data _image_data ){}

        public static void Transfer_data_PNG( RESOURCE__image_data _image_data ){



                byte[] png =  _image_data.image_compress;
                if( png == null )
                    { CONTROLLER__error.Throw( $"image { _image_data.name } come to transfer the png to the texture, but the png is null" ); } 
                NativeArray<Color32> _native_arr_texture = _image_data.texture_allocated.native_array;

                Bitmap bm = new Bitmap( System.Drawing.Image.FromStream( new MemoryStream( _png )) );

                BitmapData bitmapData = bm.LockBits (
                                                        new System.Drawing.Rectangle(0, 0, bm.Width, bm.Height),
                                                        ImageLockMode.ReadOnly,
                                                        PixelFormat.Format32bppArgb // ** talvez trenha que inverter
                                                    );


                Generate_information( _image_data,  bitmapData.Width, bitmapData.Height );

                int height_margin = _image_data.height_margin;
                int width_margin  = _image_data.width_margin;
                float rotation = _image_data.default_rotation;

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

                for( int index = 0 ; index < ( _native_arr_texture.Length ); index += 4 ){


                        // ** reseta container
                        p_container_1 = ( p_container + 0 )  ;
                        p_container_2 = ( p_container + 1 )  ;
                        p_container_3 = ( p_container + 2 )  ;
                        p_container_4 = ( p_container + 3 )  ;


                        p_data_1 += 4;
                        p_data_2 += 4;
                        p_data_3 += 4;
                        p_data_4 += 4;

                        *p_container_1 = *p_data_4;
                        *p_container_2 = *p_data_3;
                        *p_container_3 = *p_data_2;
                        *p_container_4 = *p_data_1;

                
                        // --- LEU B1


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

                        // --- LEU B2


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
                        // --- LEU B3


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

                        // --- LEU B4


                        // --- PASSA 4 PIXELS DE 1 VEZ
                        _native_arr_texture[ index + 0 ] =  *( Color32* ) ( p_container_origin + 0 );
                        _native_arr_texture[ index + 1 ] =  *( Color32* ) ( p_container_origin + 1 );
                        _native_arr_texture[ index + 2 ] =  *( Color32* ) ( p_container_origin + 2 );
                        _native_arr_texture[ index + 3 ] =  *( Color32* ) ( p_container_origin + 3 );

                        continue;


                }


                int ponto_inicial_final  = _native_arr_texture.Length - ( _native_arr_texture.Length % 4 );

                for( int i = ponto_inicial_final ; i < _native_arr_texture.Length ; i++ ){


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

                        _native_arr_texture[ i ] = *( Color32* ) p_container_origin ;
                        continue;

                }


            return;


        }





}



