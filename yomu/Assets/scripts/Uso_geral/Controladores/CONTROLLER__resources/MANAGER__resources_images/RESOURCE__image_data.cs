using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;


public class RESOURCE__image_data {


        public Type_image type;

        // ** LOCATOR
        public string image_path;


        // ** nao faz sentido ficar aqui?
        //mark
        // ** resources so trabalha com paths, mas os dados vão ser pedidos pelas figures. 
        // ** no script eles não vão pedir as imagens individualmente então não vai ficar muito grande nos scripts 
        // ** vai ser algo como ( id personagem 2 bytes )( acao_figure 1 byte )
        // ** e a figure vai transformar esse acao_figure em um path apropriado
        // public Image_localizers image_localizers;

        
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
                        // --- ONLY EXCLUSIVE
                        
                        Texture2D texture = resources.resources_images.textures_manager.textures_exclusivas[ texture_allocated.exclusive_texture_id ]; 
                        resources.resources_images.textures_manager.textures_exclusivas[ texture_allocated.exclusive_texture_id ] = null;

                        Mono_instancia.Destroy( texture );

                        return;
                    }


                // ** normal
                resources.resources_images.textures_manager.textures_locks[ texture_allocated.texture_size_slot ][ texture_allocated.texture_id ].allocated_in_image = false; 


                texture_allocated.texture_active = false;
                image_compress = null;
                

        }


}




