using System;
using UnityEngine;

public static class TOOL__module_context_images_actions {




        public static Sprite Get_sprite( RESOURCE__image_ref _ref  ){

                RESOURCE__image image = _ref.image;

                if( image.single_image == null )
                    {
                        if( image.multiples_images == null )
                            { CONTROLLER__errors.Throw( "Called Get_sprite() but the image dont have the single_image or even the multiples_images data" ); }

                        CONTROLLER__errors.Throw( "Called Get_sprite() but the image dont have the single_image data" );
                    }

                if( _ref.state != Resource_state.instanciated )
                    { Instanciate( _ref  ); }

                CONTROLLER__errors.Verify( ( image.single_image.sprite == null ), $"Sprite of the image { image.name } was null" );
                
                return image.single_image.sprite;

        }


        public static Sprite[] Get_sprites( RESOURCE__image_ref _ref  ){

                RESOURCE__image image = _ref.image;

                if( image.multiples_images == null )
                    {
                        if( image.single_image == null )
                            { CONTROLLER__errors.Throw( "Called Get_sprites() but the image dont have the multiples_images or even the single_image data" ); }

                        CONTROLLER__errors.Throw( "Called Get_sprites() but the image dont have the multiples_images data" );
                    }



                if( _ref.state != Resource_state.instanciated )
                    { Instanciate( _ref  ); }

                int index = 0;
                Sprite[] sprites = new Sprite[ image.multiples_images.Length ];

                foreach( RESOURCE__image_data image_data in image.multiples_images ){ 
                        sprites[ index++ ] = image_data.sprite;
                        CONTROLLER__errors.Verify( ( image_data.sprite == null ), $"One sprite of the image { image.name } was null" ); 
                }

            
                return sprites;

        }




        // --- DOWN

        // ** imagem vai ser deletada completamente 
        public static void Delete( RESOURCE__image_ref _ref ){ 

                RESOURCE__image image = _ref.image;

                TOOL__resource_image.Decrease_count( image, _ref.level_pre_allocation ); // ?????

                // ** perde a referencia
                image.refs[ _ref.image_slot_index ] = null;
                image.need_reajust = true;

                if( image.count_places_being_used_sprite > 1 )
                    { return; }

                if( image.count_places_being_used_compress_data > 1 )
                    { return; }

                if( image.count_places_being_used_nothing > 1 )
                    { return; } 

                // --- CAN DELETE

                image.module_images.actives_images_dictionary.Remove( image.path_locator );
                Unload( _ref );
                
                return;

        } 

        
        public static void Unload( RESOURCE__image_ref _ref ){

                // ** VAI PARA O NADA

                RESOURCE__image image = _ref.image;

                TOOL__resource_image.Decrease_count( image, _ref.level_pre_allocation );

                if( image.count_places_being_used_sprite > 1 )
                    { return; }

                if( image.count_places_being_used_compress_data > 1 )
                    { return; }

                if( image.count_places_being_used_nothing > 1 )
                    {}


                if( image.single_image != null )
                    { 
                        // --- SINGLE 

                        image.single_image.image_compress = null;
                        image.module_images.manager.textures_manager.Liberate_texture( image.single_image ); 
                    }
                    else
                    { 
                        // --- MULTIPLES

                        for( int index_image_data = 0 ; index_image_data < image.multiples_images.Length ; index_image_data++ )
                            { 
                                image.multiples_images[ index_image_data ].image_compress = null;
                                image.module_images.manager.textures_manager.Liberate_texture( image.multiples_images[ index_image_data ] );
                            } 
                    }
                

        }

        public static void Deactivate( RESOURCE__image_ref _image_ref ){

            // ** GO BACK TO MINIMUN


        }

        public static void Deinstanciate( RESOURCE__image_ref _image_ref ){

            // ** FORCE TO GO TO 

        }




        // --- PEGAR RECURSOS

        // ** sinaliza que a imagem pode carregar o minimo 
        public static void Load( RESOURCE__image_ref _ref ){

                Console.Log( "Veio Load()" );

                if( _ref.state > Resource_state.nothing )
                    { return; }

                _ref.state = Resource_state.minimun;

                if( _ref.actual_need_content == _ref.level_pre_allocation )
                    { Console.Log( "actual_need_content is equal to level_pre_allocation" ); return; } // ** mesmo nivel

                
                RESOURCE__image image = _ref.image;

                    TOOL__resource_image.Increase_count( image, _ref.level_pre_allocation );
                    TOOL__resource_image.Decrease_count( image, _ref.actual_need_content  );

                    _ref.actual_need_content = _ref.level_pre_allocation;

                TOOL__module_context_images.Update_resource_level( image );

                return;

        }

        // ** sinaliza que pode começar a pegar a texture
        public static void Activate( RESOURCE__image_ref _ref ){

                if( _ref.state == Resource_state.active )
                    { return; }

                _ref.state = Resource_state.active;

                RESOURCE__image image = _ref.image;

                    Resource_image_content actual_ref_need_content = _ref.actual_need_content;
                    Resource_image_content new_ref_need_content = Resource_image_content.sprite;

                    _ref.actual_need_content = new_ref_need_content;

                    TOOL__resource_image.Decrease_count( image, actual_ref_need_content );
                    TOOL__resource_image.Increase_count( image, new_ref_need_content );

                TOOL__module_context_images.Update_resource_level( image );
                
                return;

        }

        public static void Instanciate( RESOURCE__image_ref _ref ){

                // ** FORCE TO CREATE SPRITE 

                if( _ref.state == Resource_state.instanciated )
                    { return; }

                _ref.state = Resource_state.instanciated;
            
                
                RESOURCE__image image = _ref.image;
                
                if( image.single_image != null )
                    { Instanciate_SINGLE( image ); }
                    else 
                    { Instanciate_MULTI( image ); }


                image.actual_content = Resource_image_content.sprite;
                image.content_going_to = Resource_image_content.sprite;
                
                    Resource_image_content actual_ref_need_content = _ref.actual_need_content;
                    Resource_image_content new_ref_need_content = Resource_image_content.sprite;


                    TOOL__resource_image.Decrease_count( image, actual_ref_need_content );
                    TOOL__resource_image.Increase_count( image, new_ref_need_content );

                return;

        }

        private static void Instanciate_SINGLE( RESOURCE__image _image ){


                _image.module_images.manager.Stop_task( _image );

                RESOURCE__image_data single_image = _image.single_image;

                    // ** GUARANTY IMAGE COMPRESS
                    
                        if( _image.actual_content == Resource_image_content.nothing )
                            { 

                                
                                single_image.image_low_quality_compress =  TOOL__get_data_images_resources.Get_single_low_quality( _image );

                                //single_image.image_low_quality_compress =  System.IO.File.ReadAllBytes( System.IO.Path.Combine( Application.dataPath, "Resources", "Development", "Webp_default_1.webp" ) ) ;

                                // ** se nao tiver nada vai primeiro pegar o low quality e depois ir pegando o normal. Quando tiver o normal fazer o flip
                                _image.actual_content = Resource_image_content.compress_low_quality_data;


                                
                            } 

                        if( _image.actual_content == Resource_image_content.compress_low_quality_data )
                            {  _image.stage_getting_resource = Resources_getting_image_stage.waiting_to_get_compress_file_REAJUST; }  // ** setar para pegar o compress 

                        if( _image.actual_content == Resource_image_content.compress_data )
                            { /* nao precisa fazer nada */ } 

                        
                    // --- GUARANTY TEXTURE
                        if( _image.actual_content < Resource_image_content.texture )
                            { 
                                CONTROLLER__errors.Verify( ( _image.width * _image.height == 0 ), $"Image { _image.name } is with height { _image.height } and width { _image.width }" );
                                
                                single_image.texture_exclusiva = new Texture2D( _image.width, _image.height, TextureFormat.RGBA32, false );
                                single_image.texture_exclusiva_native_array = single_image.texture_exclusiva.GetPixelData<Color32>( 0 );
                                single_image.texture_exclusiva.filterMode = UnityEngine.FilterMode.Point;
                                _image.actual_content = Resource_image_content.texture;
                            }


                        if( _image.actual_content < Resource_image_content.texture_with_pixels )
                            {

                                     if( single_image.image_compress != null )
                                        { 
                                            TOOL__loader_texture.Transfer_data_PNG( single_image.image_compress, single_image.texture_exclusiva_native_array );
                                        }           
                                else if( single_image.image_low_quality_compress != null )
                                        { 
                                            Console.Log( "Veio aqui" );
                                            TOOL__loader_texture.Transfer_data_WEABP( _image, single_image ); 
                                        }
                                else if( true )
                                        { 
                                            CONTROLLER__errors.Throw( "nao tinha nem a compress normal nem a webp" ); 
                                        } 

                                _image.actual_content = Resource_image_content.texture_with_pixels;

                            }

                    
                        if( _image.actual_content < Resource_image_content.texture_with_pixels_applied )
                            {
                                Console.Log( "Vai dar o apply" );
                                single_image.texture_exclusiva.Apply( false, false );
                                _image.actual_content = Resource_image_content.texture_with_pixels_applied;

                            }

                        // --- GUARANTY SPRITE
                        if( _image.actual_content < Resource_image_content.sprite )
                            {
                                Console.Log( "Vai criar a sprite" );
                                single_image.sprite = Sprite.Create( _image.single_image.texture_exclusiva, new Rect( 0f, 0f, _image.width, _image.height ), new Vector2(0.5f, 0.5f), 100.0f ,0, SpriteMeshType.FullRect   );
                                _image.actual_content = Resource_image_content.sprite;
                            }

                CONTROLLER__errors.Verify( ( single_image.sprite == null ), $"Tried to get the sprite of the image { _image.name }, but do not construct after the fall" );


                return ;



        }


        private static void Instanciate_MULTI( RESOURCE__image _image ){

                return;

        }



}