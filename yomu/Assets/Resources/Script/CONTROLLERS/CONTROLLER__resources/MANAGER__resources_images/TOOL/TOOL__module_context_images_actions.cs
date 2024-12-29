using System;
using UnityEngine;
using UnityEngine.UI;

public static class TOOL__module_context_images_actions {



        public static void Change_level_pre_allocation( RESOURCE__image_ref _ref, Resource_image_content _new_pre_alloc ){

                Console.Log( "Veio Change_pre_alloc()" );

                // --- CHANGE
                Resource_image_content old_pre_alloc = _ref.level_pre_allocation;
                _ref.level_pre_allocation = _new_pre_alloc;

                if( _ref.state != Resource_state.minimun )
                    { return; } // ** nao vai importar

                if( old_pre_alloc == _new_pre_alloc )
                    { Console.Log( "Mesmo alloc" ); return; } // ** eh o mesmo

                // ** IS IN MINIMUN AND IS DIFERENT
                TOOL__resource_image.Change_actual_need_content_count( _ref, _new_pre_alloc );
                
                TOOL__module_context_images.Update_resource_level( _ref.image );
                
                return;

        }




        public static Sprite Get_sprite( RESOURCE__image_ref _ref ){


                RESOURCE__image image = _ref.image;
                
                if( !!!( image.single_image.used ) )
                    { CONTROLLER__errors.Throw( "Called Get_sprite() but the image dont have the single_image data" ); }

                if( _ref.state != Resource_state.instanciated )
                    { Instanciate( _ref  ); }

                if( image.single_image.sprite == null )
                    { CONTROLLER__errors.Throw( $"Sprite of the image { image.name } was null" ); }
                

                return image.single_image.sprite;

        }


        // --- DOWN

        // ** imagem vai ser deletada completamente 
        public static void Delete( RESOURCE__image_ref _ref ){ 


                RESOURCE__image image = _ref.image;

                // ** LOSE REF
                image.need_reajust = true;
                image.refs[ _ref.image_slot_index ] = null;

                TOOL__resource_image.Decrease_count( image, _ref.actual_need_content ); 
                _ref.image.module_images.manager.container_image_refs.Return_image_ref( _ref );
                
                TOOL__module_context_images.Update_resource_level( image );
                
                return;

        } 

        
        public static void Unload( RESOURCE__image_ref _ref ){

                // ** VAI PARA O NADA

                Console.Log( "Veio Unload()" );

                if( _ref.image == null )
                    { CONTROLLER__errors.Throw( $"Tried to Unload ref { _ref.identifire }, but the RESOURCE__image is null" ); }


                if( _ref.state == Resource_state.nothing )
                    { return; } _ref.state = Resource_state.nothing;

                if( _ref.actual_need_content == Resource_image_content.nothing )
                    { return; }

                TOOL__resource_image.Change_actual_need_content_count( _ref, Resource_image_content.nothing );

                TOOL__module_context_images.Update_resource_level( _ref.image );

                return;            

        }

        public static void Deactivate( RESOURCE__image_ref _ref ){

            // ** GO BACK TO MINIMUN

                // ** VAI PARA O NADA

                Console.Log( "Veio Deactivate()" );

                if( _ref.image == null )
                    { CONTROLLER__errors.Throw( $"Tried to Deactivate ref { _ref.identifire }, but the RESOURCE__image is null" ); }


                if( _ref.state <= Resource_state.minimun )
                    { return; } _ref.state = Resource_state.minimun;

                if( _ref.actual_need_content == _ref.level_pre_allocation )
                    { return; }

                TOOL__resource_image.Change_actual_need_content_count( _ref, _ref.level_pre_allocation );

                TOOL__module_context_images.Update_resource_level( _ref.image );

                return;    


        }

        public static void Deinstanciate( RESOURCE__image_ref _ref ){

            // ** FORCE TO GO TO activate if isntanciate

                Console.Log( "Veio Deinstanciate()" );

                if( _ref.image == null )
                    { CONTROLLER__errors.Throw( $"Tried to Deactivate ref { _ref.identifire }, but the RESOURCE__image is null" ); }


                if( _ref.state <= Resource_state.active )
                    { return; } _ref.state = Resource_state.active;

                if( _ref.actual_need_content == Resource_image_content.sprite )
                    { return; }


                TOOL__resource_image.Change_actual_need_content_count( _ref, _ref.level_pre_allocation );

                TOOL__module_context_images.Update_resource_level( _ref.image );

                return;    

        }



        // --- UP

        // ** sinaliza que a imagem pode carregar o minimo 
        public static void Load( RESOURCE__image_ref _ref ){

                if( _ref.image == null )
                    { CONTROLLER__errors.Throw( $"Tried to Load ref { _ref.identifire }, but the RESOURCE__image is null" ); }

                if( _ref.state >= Resource_state.minimun )
                    { return; } _ref.state = Resource_state.minimun;

                if( _ref.actual_need_content >= _ref.level_pre_allocation )
                    { return; }

            
                TOOL__resource_image.Change_actual_need_content_count( _ref, _ref.level_pre_allocation );
                TOOL__module_context_images.Update_resource_level( _ref.image );

                return;

        }

        // ** sinaliza que pode começar a pegar a texture
        public static void Activate( RESOURCE__image_ref _ref ){

            
                if( _ref.image == null )
                    { CONTROLLER__errors.Throw( $"Tried to Activate ref { _ref.identifire }, but the RESOURCE__image is null" ); }

                if( _ref.state >= Resource_state.active )
                    { return; } _ref.state = Resource_state.active;

                if( _ref.actual_need_content == Resource_image_content.sprite )
                    { return; }


                TOOL__resource_image.Change_actual_need_content_count( _ref, Resource_image_content.sprite );
                TOOL__module_context_images.Update_resource_level( _ref.image );
                
                return;

        }

    
        public static void Instanciate( RESOURCE__image_ref _ref ){

                // ** FORCE TO CREATE SPRITE 

                if( _ref.image == null )
                    { CONTROLLER__errors.Throw( $"Tried to Activate ref { _ref.identifire }, but the RESOURCE__image is null" ); }

                if( _ref.state == Resource_state.instanciated )
                    { return; } _ref.state = Resource_state.instanciated;


                RESOURCE__image image = _ref.image;
                MANAGER__resources_images manager = image.module_images.manager;

                // --- ALL NORMAL

                // image.module_images.manager.Stop_task( image );

                if(  ( image.stage_getting_resource & Resources_getting_image_stage.all_reajust_stages ) != 0 )
                    { return; } // ** already going to switch the sprite


                image.stage_getting_resource = Resources_getting_image_stage.finished;
                image.content_going_to = Resource_image_content.sprite;

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
                            { 
                                if( !!!( image.system_have_low_quality ) )
                                    {
                                        image.single_image.image_compress =  TOOL__get_data_images_resources.Get_single( image );
                                        image.actual_content = Resource_image_content.compress_data;
                                    }
                                    else
                                    {
                                        image.stage_getting_resource = Resources_getting_image_stage.waiting_to_get_compress_file_REAJUST;
                                    }
                            }  


                        if( image.actual_content == Resource_image_content.compress_data )
                            { /* nao precisa fazer nada */ } 

                        
                    // --- GUARANTY TEXTURE
                        if( image.actual_content < Resource_image_content.texture )
                            { 
                                if( ( image.width * image.height ) == 0 )
                                    { CONTROLLER__errors.Throw( $"Image { image.name } is with height { image.height } and width { image.width }" ); }
                                
                                image.single_image.texture_exclusiva = new Texture2D( image.width, image.height, TextureFormat.RGBA32, false );
                                image.single_image.texture_exclusiva_native_array = image.single_image.texture_exclusiva.GetPixelData<Color32>( 0 );
                                image.single_image.texture_exclusiva.filterMode = UnityEngine.FilterMode.Point;

                                image.actual_content = Resource_image_content.texture;
                            }


                        if( image.actual_content < Resource_image_content.texture_with_pixels )
                            {

                                     if( image.single_image.image_compress != null )
                                        { 
                                            
                                            TOOL__loader_texture.Transfer_data_PNG( image.single_image.image_compress, image.single_image.texture_exclusiva_native_array );
                                        }           
                                else if( image.single_image.image_low_quality_compress != null )
                                        { 
                                            
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
                                image.single_image.texture_exclusiva.Apply( false, false );
                                image.actual_content = Resource_image_content.texture_with_pixels_applied;

                            }

                        // --- GUARANTY SPRITE
                        if( image.actual_content < Resource_image_content.sprite )
                            {
                                if( ( image.stage_getting_resource & Resources_getting_image_stage.all_reajust_stages ) != 0  )
                                    {
                                        // ** handle 

                                    }
                                    
                                image.single_image.sprite = Sprite.Create( image.single_image.texture_exclusiva, new Rect( 0f, 0f, image.width, image.height ), new Vector2(0.5f, 0.5f), 100.0f ,0, SpriteMeshType.FullRect   );
                                image.actual_content = Resource_image_content.sprite;
                            }


                if( image.single_image.sprite == null )
                    { CONTROLLER__errors.Throw( $"Tried to get the sprite of the image { image.name }, but do not construct after the fall. actual content: { image.actual_content }" ); }

                TOOL__resource_image.Change_actual_need_content_count( _ref, Resource_image_content.sprite );


                // Console.Log( " ACTUAL CONTENT:  " + image.actual_content );

                // Console.Log( "content_going_to: " + image.content_going_to );
                // Console.Log( "actual_content: " + image.actual_content );
                // Console.Log( "stage_getting_resource: " + image.stage_getting_resource );


                
                return;

        }


}