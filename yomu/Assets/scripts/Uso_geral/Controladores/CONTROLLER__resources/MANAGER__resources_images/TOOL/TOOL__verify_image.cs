

public static class TOOL__resource_image {


        public static void Verify( RESOURCE__image image ){


                if( image.level_pre_allocation_image == Resource_image_content.not_give )
                    { CONTROLLER__errors.Throw( $"In the image request { image.name } was not give the level of pre allocation" ); }
                
                if( image.multiples_images == null && image.single_image == null )
                    { CONTROLLER__errors.Throw( $"In the image request { image.name } was not given the image data" ); }

                if( image.multiples_images != null && image.single_image != null )
                    { CONTROLLER__errors.Throw( $"In the image request { image.name } was given single and multiples images" ); }


                if( image.current_content == Resource_image_content.nothing )
                    {
                        if( image.single_image!= null )
                            { 
                                // single
                                if ( image.single_image.image_compress != null )
                                    { throw new System.Exception( $"current state was \"nothing\" but there is a compress image in the image ${ image.name }" ); }

                                if ( image.single_image.texture_allocated.texture_active )
                                    { throw new System.Exception( $"current state was \"nothing\" but there is a texture activated image in the image ${ image.name }" ); }

                            } 
                            else
                            {  } // multiple
                    }



                return;

        }




}