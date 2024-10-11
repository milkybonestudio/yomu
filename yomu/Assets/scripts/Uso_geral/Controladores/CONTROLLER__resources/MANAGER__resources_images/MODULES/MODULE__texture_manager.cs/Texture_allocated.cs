using Unity.Collections;
using UnityEngine;


public struct Texture_allocated {

        // ** just destroy when free
        public int texture_size_slot; 
        public int texture_id;


        public bool exclusive_texture;
        public int exclusive_texture_id;
        
        public bool texture_active;
        
        public int texture_width;
        public int texture_height;

        public NativeArray<Color32> native_array; // somente? 
        public Texture2D texture;


}
