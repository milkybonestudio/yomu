using System;
using UnityEngine;



public static class Conversor {



        public static Sprite Converter_PNG_para_SPRITE(  byte[] _byte_arr  ){

                    // pode levar um tempo e interromper a thread. se o png for grande vale mais a pena usar em multi e esperar terminar

                    Texture2D tex = new Texture2D(1,1); 
                    tex.LoadImage( _byte_arr );          
                    Sprite sprite_retorno  =   Sprite.Create(tex  ,     new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f ,0, SpriteMeshType.FullRect   );
                    return sprite_retorno;

        }



}

