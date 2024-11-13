

public static class TOOL__resource_image {


        public static void Verify_image( RESOURCE__image image ){


                CONTROLLER__errors.Verify( !!!( image.single_image.used ),  $"In the image request { image.name } was given single and multiples images" );
                
                if( image.actual_content == Resource_image_content.nothing )
                    {
                        if ( image.single_image.image_compress != null )
                            { throw new System.Exception( $"current state was \"nothing\" but there is a compress image in the image ${ image.name }" ); }

                    }

                return;

        }


        public static void Verify_image_ref ( RESOURCE__image_ref image_ref ){

                return;

        }
        
        public static void Increase_count( RESOURCE__image _image, Resource_image_content _content ){ Change( _image, _content, 1 ); }
        public static void Decrease_count( RESOURCE__image _image, Resource_image_content _content ){ Change( _image, _content, -1 ); }


        public static void Change( RESOURCE__image _image, Resource_image_content _content, int _value ){

                
                switch( _content ){

                    case Resource_image_content.nothing: _image.count_places_being_used_nothing += _value; return;
                    case Resource_image_content.compress_low_quality_data: _image.count_places_being_used_compress_low_quality_data += _value; return;
                    case Resource_image_content.compress_data: _image.count_places_being_used_compress_data += _value; return;
                    case Resource_image_content.sprite: _image.count_places_being_used_sprite += _value; return;
                    
                }

        }





}