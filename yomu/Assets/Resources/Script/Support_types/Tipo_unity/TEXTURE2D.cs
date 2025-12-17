using System;
using UnityEngine;

public static class TEXTURE2D {

    public static Texture2D Resize( Texture2D texture, int _compress_w, int _compress_h ){


        int  compress_w = _compress_w;
        int  compress_h = _compress_h;

        int image_w = texture.width;
        int image_h = texture.height;
        
        Texture2D texture_compress = new Texture2D(  compress_w , compress_h  );

        int pular_h = 0;
        int pular_w = 0;

        int image_h_final = 0;
        int image_w_final = 0;


        if(  ( (float)  ( (float)image_h  /  (float) image_w) )    > 0.5625f)
            {

                image_h_final =    Convert.ToInt32((float) image_w * 0.5625f);
                image_w_final =    image_w;

                pular_h =  Convert.ToInt32 ( (float)( image_h - image_h_final ) / 2f );
                pular_w = 0;

            }  
            else
            {

                image_w_final = Convert.ToInt32( (float) image_h * 1.7777f);
                image_h_final = image_h;

                pular_w = Convert.ToInt32 (  (float) (    image_w - image_w_final) / 2f  );
                pular_h =   0;

            }
    
        int I_H = pular_h;
        int I_W = pular_w;

        for( int i_h = 0 ; i_h < compress_h ; i_h++ ){

                I_H =   (pular_h ) +  (int)   (   (float) i_h *  (  (float) (image_h_final)/  (float)  compress_h) )  ;

                for( int i_w = 0;   i_w < compress_w  ;i_w++  ){

                    I_W = pular_w   +   (int)   (   (float) i_w  *  ( (float) (image_w_final)  / (float) compress_w) )  ;
                    texture_compress.SetPixel(   i_w, i_h,  (Color)  texture.GetPixel(   I_W  ,  I_H )  );

                }
        }

        return texture_compress;


    }

}


