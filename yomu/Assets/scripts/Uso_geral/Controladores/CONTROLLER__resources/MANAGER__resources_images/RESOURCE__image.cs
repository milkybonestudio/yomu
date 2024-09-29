
using UnityEngine;




unsafe public class RESOURCE__image {

        public Type_image type;
        
        public int request_id;

        public string name = "NAO_COLOCOU";

        public Level_pre_allocation_image level_pre_allocation_image;
        public Resources_request_image_stage stage;
    
    
    
        public RESOURCE__image_data single_image;
        public RESOURCE__image_data[] multiples_images;


        // ** imagem nao vai mais ser usada
        public void Delete(){

        
            if( multiples_images != null )
                {
                    for( int image_data_index = 0 ; image_data_index < multiples_images.Length ; image_data_index++ )
                        { 
                            multiples_images[ image_data_index ].Liberate_texture();
                        }
                }
                else
                {
                    single_image.Free();
                }


        }


        // ** libera o maximo que pode liberar
        public void Free(){

            // ** libera o maximo que pode 

            // ** se é para deixar tudo na memoria, nao tem nada para liberar
            if( level_pre_allocation_image == Level_pre_allocation_image.all )
                { return; }


            
            if( multiples_images == null )
                {
                    // --- SE NAO FOR ALL SEMRPE LIBERA TEXTURE
                    single_image.Liberate_texture();

                    if( level_pre_allocation_image == Level_pre_allocation_image.nothing )
                        { single_image.image_compress = null; } // --- LIBERA DATA
                        return;

                }
            
            // --- MULTIPLAS

            // --- SE NAO FOR ALL SEMRPE LIBERA TEXTURE

            int image_data_index = 0;
            for( image_data_index = 0 ; image_data_index < multiples_images.Length ; image_data_index++ )
                { multiples_images[ image_data_index ].Liberate_texture(); }

            if( level_pre_allocation_image != Level_pre_allocation_image.nothing )
                { return; }

            for( image_data_index = 0 ; image_data_index < multiples_images.Length ; image_data_index++ )
                { multiples_images[ image_data_index ].image_compress = null; }

            return;



        }


}
