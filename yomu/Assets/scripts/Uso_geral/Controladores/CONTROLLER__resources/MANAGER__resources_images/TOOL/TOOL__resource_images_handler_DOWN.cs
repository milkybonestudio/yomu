using UnityEngine;


public static class TOOL__resource_images_handler_DOWN {


        public static int Handle_waiting_to_destroy_current_resource( MANAGER__resources_images _manager, RESOURCE__image _image ){

                int weight = 0;

                if( _image.content_going_to <= Resource_image_content.compress_data )
                    { weight += Destroy_resource_texture( _manager, _image ); }

                if( _image.content_going_to <= Resource_image_content.compress_low_quality_data )
                    { weight += Destroy_compress_data( _manager, _image ); }
                
                if( _image.content_going_to == Resource_image_content.nothing )
                    { weight += Destroy_compress_low_quality_data( _manager, _image ); }

                return weight;

        }



        private static int Destroy_compress_low_quality_data( MANAGER__resources_images _manager, RESOURCE__image _image ){

                Console.Log( "Veio Destroy_compress_low_quality_data()" );

                // --- DESTROY
                _image.single_image.image_low_quality_compress = null;
                _image.actual_content = Resource_image_content.nothing;
                return 0;

        }

        
        private static int Destroy_compress_data( MANAGER__resources_images _manager, RESOURCE__image _image ){

                Console.Log( "Veio Destroy_compress_data()" );

                // --- DESTROY
                _image.single_image.image_compress = null;
                _image.actual_content = Resource_image_content.compress_low_quality_data;

                return 0;

        }

        private static int Destroy_resource_texture( MANAGER__resources_images _manager, RESOURCE__image _image ){

                Console.Log( "Destroy_resource_texture" );

                // --- DESTROY
                GameObject.Destroy( _image.single_image.texture_exclusiva );

                _image.single_image.texture_exclusiva_native_array.Dispose();
                _image.actual_content = Resource_image_content.compress_data;

                return 1;


        }







}