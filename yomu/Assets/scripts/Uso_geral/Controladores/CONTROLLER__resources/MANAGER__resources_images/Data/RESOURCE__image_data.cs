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
            public NativeArray<Color32> texture_exclusiva_native_array;
            public Sprite sprite;



            // ** usar depois
            public Texture_allocated texture_allocated;



            public void Reset(){

                    used = true;

                    image_compress = null;

                    have_low_quality_compress = false; // false => can not have the webp
                    image_low_quality_compress = null;

                    // ** Nao deveria ter
                    CONTROLLER__errors.Verify( ( texture_exclusiva != null ), "deu um reset na image_data mas a texture ainda estava aqui" );

                    texture_exclusiva = null;
                    texture_exclusiva_native_array.Dispose();
                    sprite = null;

            }


}




