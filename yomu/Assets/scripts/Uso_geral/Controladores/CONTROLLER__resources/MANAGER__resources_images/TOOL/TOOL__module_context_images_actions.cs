using System;
using UnityEngine;

public static class TOOL__module_context_images_actions {




        public static Sprite Get_sprite( RESOURCE__image_ref _ref  ){

                RESOURCE__image image = _ref.image;

                CONTROLLER__errors.Verify(  !!!( image.single_image.used ),  "Called Get_sprite() but the image dont have the single_image data" );
                
                if( _ref.state != Resource_state.instanciated )
                    { Instanciate( _ref  ); }

                CONTROLLER__errors.Verify( ( image.single_image.sprite == null ), $"Sprite of the image { image.name } was null" );
                
                return image.single_image.sprite;

        }


        // --- DOWN

        // ** imagem vai ser deletada completamente 
        public static void Delete( RESOURCE__image_ref _ref ){ 

                RESOURCE__image image = _ref.image;

                TOOL__resource_image.Decrease_count( image, _ref.level_pre_allocation ); // ?????

                // ** perde a referencia
                image.refs[ _ref.image_slot_index ].ref_state = RESOURCE__image_ref_state.deleted;
                image.need_reajust = true;

                if( image.count_places_being_used_sprite > 1 )
                    { return; }

                if( image.count_places_being_used_compress_data > 1 )
                    { return; }

                if( image.count_places_being_used_nothing > 1 )
                    { return; } 

                // --- CAN DELETE

                image.module_images.actives_images_dictionary.Remove( image.local_path );
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

                image.single_image.image_compress = null;
                image.module_images.manager.textures_manager.Liberate_texture( image.single_image );                 

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

                Console.Log( "actual content: " + image.actual_content );


                image.module_images.manager.Stop_task( image );

                    // ** GUARANTY IMAGE COMPRESS
                    
                        if( image.actual_content == Resource_image_content.nothing )
                            { 
                                
                                if( image.system_have_low_quality )
                                    {
                                        image.single_image.image_low_quality_compress =  TOOL__get_data_images_resources.Get_single_low_quality( image );
                                        image.actual_content = Resource_image_content.compress_low_quality_data;
                                    }
                                    else
                                    {
                                        image.single_image.image_compress =  TOOL__get_data_images_resources.Get_single( image );
                                        image.actual_content = Resource_image_content.compress_data;
                                    }
  
                            } 

                        if( image.actual_content == Resource_image_content.compress_low_quality_data )
                            { image.stage_getting_resource = Resources_getting_image_stage.waiting_to_get_compress_file_REAJUST; }  // ** setar para pegar o compress 


                        if( image.actual_content == Resource_image_content.compress_data )
                            { /* nao precisa fazer nada */ } 


                        
                    // --- GUARANTY TEXTURE
                        if( image.actual_content < Resource_image_content.texture )
                            { 
                                CONTROLLER__errors.Verify( ( ( image.width * image.height ) == 0 ), $"Image { image.name } is with height { image.height } and width { image.width }" );
                                
                                image.single_image.texture_exclusiva = new Texture2D( image.width, image.height, TextureFormat.RGBA32, false );
                                image.single_image.texture_exclusiva_native_array = image.single_image.texture_exclusiva.GetPixelData<Color32>( 0 );
                                image.single_image.texture_exclusiva.filterMode = UnityEngine.FilterMode.Point;

                                image.actual_content = Resource_image_content.texture;
                            }


                        if( image.actual_content < Resource_image_content.texture_with_pixels )
                            {

                                     if( image.single_image.image_compress != null )
                                        { 
                                            Console.Log( "Vai carregar image_compress" );
                                            TOOL__loader_texture.Transfer_data_PNG( image.single_image.image_compress, image.single_image.texture_exclusiva_native_array );
                                        }           
                                else if( image.single_image.image_low_quality_compress != null )
                                        { 
                                            Console.Log( "Vai carregar image_low_quality_compress" );
                                            TOOL__loader_texture.Transfer_data_WEABP( image, image.single_image ); 
                                        }
                                else if( true )
                                        { 
                                            CONTROLLER__errors.Throw( "nao tinha nem a compress normal nem a webp" ); 
                                        } 

                                image.actual_content = Resource_image_content.texture_with_pixels;

                            }

                    
                        if( image.actual_content < Resource_image_content.texture_with_pixels_applied )
                            {
                                Console.Log( "Vai dar o apply" );
                                image.single_image.texture_exclusiva.Apply( false, false );
                                image.actual_content = Resource_image_content.texture_with_pixels_applied;

                            }

                        // --- GUARANTY SPRITE
                        if( image.actual_content < Resource_image_content.sprite )
                            {
                                Console.Log( "Vai criar a sprite" );
                                image.single_image.sprite = Sprite.Create( image.single_image.texture_exclusiva, new Rect( 0f, 0f, image.width, image.height ), new Vector2(0.5f, 0.5f), 100.0f ,0, SpriteMeshType.FullRect   );
                                Console.Log( "sprite: " + image.single_image.sprite );
                                Console.Log( "texture: " + image.single_image.texture_exclusiva );
                                image.actual_content = Resource_image_content.sprite;
                            }


                CONTROLLER__errors.Verify( ( image.single_image.sprite == null ), $"Tried to get the sprite of the image { image.name }, but do not construct after the fall. actual content: { image.actual_content }" );



                image.actual_content = Resource_image_content.sprite;
                image.content_going_to = Resource_image_content.sprite;
                
                    Resource_image_content actual_ref_need_content = _ref.actual_need_content;
                    Resource_image_content new_ref_need_content = Resource_image_content.sprite;


                    TOOL__resource_image.Decrease_count( image, actual_ref_need_content );
                    TOOL__resource_image.Increase_count( image, new_ref_need_content );

                return;

        }


}