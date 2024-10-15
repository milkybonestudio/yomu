using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;


public class RESOURCE__image_data {


            // ** low quality
            public byte[] image_low_quality_compress;
            public Texture2D texture_low_quality;
            public Sprite sprite_low_quality;  

            

            // ** por hora nao vai ter texture alloc, vai ser somente 1 texture para cada 
            // ** depois começar a usar 
            public byte[] image_compress;
            public Texture2D texture_exclusiva;
            public NativeArray<Color32> texture_exclusiva_native_array;
            public Sprite sprite;

            // ** usar depois
            public Texture_allocated texture_allocated;


}




