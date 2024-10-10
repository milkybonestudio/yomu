
using System;
using UnityEngine;





unsafe public class RESOURCE__image {


        // ** isso vai ficar somente no manager ou nos modulos
        // ** o nivel minimo de prealocation sempre vai ser definido pelo maior das referencias


        public RESOURCE__image( Resource_context _context ) { 

            image_context = _context; 
            count_places_being_used = 1;

        }

        private RESOURCE__image_ref[] refs = new RESOURCE__image_ref[ 100 ];
        private int refs_pointer;

        public RESOURCE__image_ref Add_ref(  Level_pre_allocation_image _level_pre_allocation ){

                RESOURCE__image_ref image_ref = new RESOURCE__image_ref( this );

                // --- GARANTE TAMANHO
                if( refs_pointer == refs.Length )
                    { Array.Resize( ref refs, ( refs.Length + 20 ) ); }

                // --- GURADA REF
                refs[ refs_pointer++ ] = image_ref;

                // --- PEGA O PRE ALLOC MAIS ALTO
                if( _level_pre_allocation  > level_pre_allocation_image )
                    { level_pre_allocation_image = _level_pre_allocation; }

                return image_ref;

        }


        public int count_places_being_used; // precisa do minimo
        public int count_places_being_used_activated; // precisa de tudo


        public Resource_context image_context;

        public Type_image type;
        
        public int request_id;

        public string name = "NAO_COLOCOU";
        public Level_pre_allocation_image level_pre_allocation_image;

        public Resources_request_image_stage stage;
    
    
        public RESOURCE__image_data single_image;
        public RESOURCE__image_data[] multiples_images;


        // ** informa que a referencia nao pode mais ser usado 
        public void Delete(){

            
            if( multiples_images != null )
                {
                    for( int image_data_index = 0 ; image_data_index < multiples_images.Length ; image_data_index++ )
                        { multiples_images[ image_data_index ].Liberate_texture(); }
                }
                else
                {
                    single_image.Free();
                }


        }


        // ** libera o maximo que pode liberar
        public void Free(){


            if( count_places_being_used > 0 )
                { return; } // --- ESTA SENDO USADO EM OUTRO LUGAR

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




        private void Free_individual(){

                // ** lose image reference
                image_compress = null;
                Liberate_texture();

        }


        private void Liberate_texture( RESOURCE__image_data _data ){


                CONTROLLER__resources resources = CONTROLLER__resources.Get_instance();

                if( ( _data.texture_allocated.native_array ) == null )
                    { return; }

                
                if( _data.texture_allocated.exclusive_texture )
                    { 
                        // --- ONLY EXCLUSIVE
                        
                        Texture2D texture = resources.resources_images.textures_manager.textures_exclusivas[ _data.texture_allocated.exclusive_texture_id ]; 
                        resources.resources_images.textures_manager.textures_exclusivas[ _data.texture_allocated.exclusive_texture_id ] = null;

                        Mono_instancia.Destroy( texture );

                        return;
                    }


                // ** normal
                resources.resources_images.textures_manager.textures_locks[ texture_allocated.texture_size_slot ][ texture_allocated.texture_id ].allocated_in_image = false; 


                texture_allocated.texture_active = false;
                image_compress = null;
                

        }





}


