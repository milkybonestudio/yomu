using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;


public struct RESOURCE__image_data {


            public bool used;

            // ** por hora nao vai ter texture alloc, vai ser somente 1 texture para cada 
            // ** depois começar a usar 
            public byte[] image_compress;


            public bool have_low_quality_compress; // false => can not have the webp
            public byte[] image_low_quality_compress;


            public Texture2D texture_exclusiva;
            public int slot_texture;
            
            public NativeArray<Color32> texture_exclusiva_native_array;
            public Sprite sprite;


            // ** usar depois
            public Texture_allocated texture_allocated;



}




