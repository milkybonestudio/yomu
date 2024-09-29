using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;


public class RESOURCE__image_data {


        public Type_image type;

        // ** LOCATOR
        public int data_container_id;
        public int image_id;

        // --- ORIGINAL IMAGE

        public int height;
        public int width;

        // --- INFORMATION TO DEAL DIFFERENCES

        // ** add
        public float default_rotation = 0;
        public int width_margin;
        public int height_margin;
    

        // --- DATA
        public byte[] image_compress;
        public Texture_allocated texture_allocated;


        public void Free(){

                // ** lose image reference
                image_compress = null;
                Liberate_texture();

        }


        public void Liberate_texture(){


                CONTROLLER__resources resources = CONTROLLER__resources.Get_instance();

                if( ( texture_allocated.native_array ) == null )
                    { return; }

                
                if( texture_allocated.exclusive_texture )
                    { 
                        
                        Texture2D texture = resources.resources_images.textures_manager.textures_exclusivas[ texture_allocated.exclusive_texture_id ]; 
                        resources.resources_images.textures_manager.textures_exclusivas[ texture_allocated.exclusive_texture_id ] = null;

                        Mono_instancia.Destroy( texture );

                        return;
                    }
                    else
                    { 
                        resources.resources_images.textures_manager.textures_locks[ texture_allocated.texture_size_slot ][ texture_allocated.texture_id ] = false; 
                    }



                texture_allocated.texture_active = false;
                image_compress = null;
                

        }


}




