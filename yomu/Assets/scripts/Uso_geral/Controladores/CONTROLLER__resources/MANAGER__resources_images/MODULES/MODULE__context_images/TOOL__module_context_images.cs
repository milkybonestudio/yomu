using UnityEngine;

public static class TOOL__module_context_images {


        public static void Update_resource_level( RESOURCE__image _image ){


                Console.Log( "veio: { Update_resource_level }" );

                TOOL__module_context_images.Verify_stage_for_content( _image );

                Resources_getting_image_stage blocked_for_now = ( Resources_getting_image_stage.getting_texture | Resources_getting_image_stage.applying_texture );

                
                if( ( int ) ( _image.stage_getting_resource & blocked_for_now  ) != 0  )
                    { CONTROLLER__errors.Throw( $"Tried to update resources level, but the current resources stage is not allowed: { _image.stage_getting_resource }" ); }

                if( _image.count_places_being_used_sprite > 0 )
                    { Going_to_resource_level_SPRITE( _image ); return; }

                if( _image.count_places_being_used_compress_low_quality_data > 0 )
                    {  Update_resource_level_COMPRESS_LOW_QUALITY_DATA( _image ); return; }

                if( _image.count_places_being_used_compress_data > 0 )
                    {  Going_to_resource_level_COMPRESS_DATA( _image ); return; }
                
                if( _image.count_places_being_used_nothing > 0 )
                    { Going_to_resource_level_NOTHING( _image ); return; }

                // ** imagem perdeu todas as referencias, tem que deletar tudo

                // ** DELETE IMAGE

                
                _image.module_images.actives_images_dictionary.Remove( _image.image_key ); // ** nao tem mais update
                _image.module_images.manager.container_images.Return_image( _image ); 
                
         
        }

        
        private static int Going_to_resource_level_NOTHING( RESOURCE__image _image ){

                Console.Log( "Veio Going_to_resource_level_NOTHING()" );

                if( _image.content_going_to == Resource_image_content.nothing )
                    { return 0; } // ** ja nivelado
                _image.content_going_to = Resource_image_content.nothing;


                // --- UP                
                // --- EQUAL

                    if( _image.actual_content == Resource_image_content.nothing )
                        { 
                            if( _image.stage_getting_resource == Resources_getting_image_stage.getting_compress_low_quality_file )
                                { return TOOL__resource_image.Set_stage_cancelling_task( _image, Resources_getting_image_stage.finished, ref _image.module_images.manager.task_getting_compress_low_quality_file ); }
                                else
                                { return TOOL__resource_image.Set_stage( _image, Resources_getting_image_stage.finished ); }
                        }

                // --- DOWN

                    return TOOL__resource_image.Down_resources( _image );

        }


       private static int Update_resource_level_COMPRESS_LOW_QUALITY_DATA( RESOURCE__image _image ){

                Console.Log( "Veio Update_resource_level_COMPRESS_LOW_QUALITY_DATA()" );

                if( _image.content_going_to == Resource_image_content.compress_low_quality_data )
                    { return 0; } // ** ja nivelado

                _image.content_going_to = Resource_image_content.compress_low_quality_data;


                // ** UP

                    if( _image.actual_content == Resource_image_content.nothing )
                        { return TOOL__resource_image.Set_stage( _image, Resources_getting_image_stage.waiting_to_start ); }

                // ** EQUAL

                    if( _image.actual_content == Resource_image_content.compress_low_quality_data )
                        {
                            if( _image.stage_getting_resource == Resources_getting_image_stage.getting_compress_file )
                                { return TOOL__resource_image.Set_stage_cancelling_task( _image, Resources_getting_image_stage.finished, ref _image.module_images.manager.task_getting_compress_file ); }

                            if( TOOL__resource_image.Verify_stage( _image, ( Resources_getting_image_stage.waiting_to_get_compress_file | Resources_getting_image_stage.waiting_to_destroy_current_resource ) ) )
                                { return TOOL__resource_image.Set_stage( _image, Resources_getting_image_stage.finished ); }
                        }
                    
                // ** DOWN

                    return TOOL__resource_image.Down_resources( _image );

        }





        private static int Going_to_resource_level_COMPRESS_DATA( RESOURCE__image _image ){

                Console.Log( "Veio Going_to_resource_level_COMPRESS_DATA()" );
                Console.Log( "Actual content: " + _image.actual_content );

                // ** TEM QUE TER COMPRESS
                if( _image.content_going_to == Resource_image_content.compress_data )
                    { return 0; } // ** ja nivelado

                _image.content_going_to = Resource_image_content.compress_data;


                // UP

                    if( _image.actual_content == Resource_image_content.nothing )
                        { 
                            if( TOOL__resource_image.Verify_stage( _image, ( Resources_getting_image_stage.finished ) ) )
                                { return TOOL__resource_image.Set_stage( _image, Resources_getting_image_stage.waiting_to_start ); }

                            if( TOOL__resource_image.Verify_stage( _image, ( Resources_getting_image_stage.getting_compress_low_quality_file | Resources_getting_image_stage.waiting_to_start ) ) )
                                { return 0; }
                        }

                    if( _image.actual_content == Resource_image_content.compress_low_quality_data )
                        { 
                            if( TOOL__resource_image.Verify_stage( _image, ( Resources_getting_image_stage.getting_compress_file | Resources_getting_image_stage.waiting_to_get_compress_file ) ) )
                                { return 0; }

                            if( TOOL__resource_image.Verify_stage( _image, ( Resources_getting_image_stage.finished | Resources_getting_image_stage.waiting_to_destroy_current_resource ) ) )
                                { return TOOL__resource_image.Set_stage( _image, Resources_getting_image_stage.waiting_to_get_compress_file ); }
                        }


                // EQUAL

                    if( _image.actual_content == Resource_image_content.compress_data )
                        { 
                            if(  TOOL__resource_image.Verify_stage( _image, ( Resources_getting_image_stage.waiting_to_destroy_current_resource | Resources_getting_image_stage.waiting_to_get_texture ) ) )
                                { return TOOL__resource_image.Set_stage( _image, Resources_getting_image_stage.finished ); }

                        }

                // DOWN

                    return TOOL__resource_image.Down_resources( _image );

        }



        private static int Going_to_resource_level_SPRITE( RESOURCE__image _image ){

                Console.Log( "Veio Going_to_resource_level_SPRITE()" );

                // ** TEM QUE TER COMPRESS
                if( _image.content_going_to == Resource_image_content.sprite )
                    { return 0; } // ** ja nivelado

                _image.content_going_to = Resource_image_content.sprite;


                // UP

                    if( _image.actual_content == Resource_image_content.nothing )
                        { 
                            if( TOOL__resource_image.Verify_stage( _image, ( Resources_getting_image_stage.finished ) ) )
                                { return TOOL__resource_image.Set_stage( _image, Resources_getting_image_stage.waiting_to_start ); }
                                
                            if( TOOL__resource_image.Verify_stage( _image, ( Resources_getting_image_stage.getting_compress_low_quality_file | Resources_getting_image_stage.waiting_to_start | Resources_getting_image_stage.finished ) ) )
                                { return 0; }
                        }

                    if( _image.actual_content == Resource_image_content.compress_low_quality_data )
                        { 
                            if( TOOL__resource_image.Verify_stage( _image, ( Resources_getting_image_stage.getting_compress_file | Resources_getting_image_stage.waiting_to_get_compress_file ) ) )
                                { return 0; }

                            if( TOOL__resource_image.Verify_stage( _image, ( Resources_getting_image_stage.finished | Resources_getting_image_stage.waiting_to_destroy_current_resource ) ) )
                                { return TOOL__resource_image.Set_stage( _image, Resources_getting_image_stage.waiting_to_get_compress_file ); }
                        }


                    if( _image.actual_content == Resource_image_content.compress_data )
                        { 
                            if( TOOL__resource_image.Verify_stage( _image, ( Resources_getting_image_stage.waiting_to_get_texture ) ) )
                                { return 0; }

                            if( TOOL__resource_image.Verify_stage( _image, ( Resources_getting_image_stage.finished | Resources_getting_image_stage.waiting_to_destroy_current_resource ) ) )
                                { return TOOL__resource_image.Set_stage( _image, Resources_getting_image_stage.waiting_to_get_texture ); }
                        }


                    if( _image.actual_content == Resource_image_content.all_textures_possibilities )
                        { 
                            if( TOOL__resource_image.Verify_stage( _image, ( Resources_getting_image_stage.waiting_to_destroy_current_resource ) ) )
                                { 
                                    switch( _image.actual_content ){

                                        case Resource_image_content.texture: return TOOL__resource_image.Set_stage( _image, Resources_getting_image_stage.waiting_to_pass_data_to_texture ); 
                                        case Resource_image_content.texture_with_pixels: return TOOL__resource_image.Set_stage( _image, Resources_getting_image_stage.waiting_to_apply_texture ); 
                                        case Resource_image_content.texture_with_pixels_applied: return TOOL__resource_image.Set_stage( _image, Resources_getting_image_stage.waiting_to_create_sprite ); 

                                    }

                                }

                        }

                // EQUAL

                    if( _image.actual_content == Resource_image_content.sprite )
                        { 
                            if(  TOOL__resource_image.Verify_stage( _image, Resources_getting_image_stage.waiting_to_destroy_current_resource ) )
                                { return TOOL__resource_image.Set_stage( _image, Resources_getting_image_stage.finished ); }

                        }

                // DOWN ( what )
                CONTROLLER__errors.Throw( $"The image { _image.local_path } need to change to Sprite, but the actual content is: { _image.actual_content }, the going-to_content is : { _image.content_going_to } and the stage_getting_resource is: { _image.stage_getting_resource }" );
                return -1;

        }




        private static void Verify_stage_for_content( RESOURCE__image _image ){


                Resources_getting_image_stage possible_stages = Resources_getting_image_stage.not_give;

                switch( _image.actual_content ){

                    case Resource_image_content.nothing: possible_stages = Resources_getting_image_stage.nothing_acceptable_stages; break;
                    case Resource_image_content.compress_low_quality_data: possible_stages = Resources_getting_image_stage.compress_low_quality_data_acceptable_stages; break;
                    case Resource_image_content.compress_data: possible_stages = Resources_getting_image_stage.compress_data_acceptable_stages; break;
                    case Resource_image_content.texture: possible_stages = Resources_getting_image_stage.texture_acceptable_stages; break;
                    case Resource_image_content.texture_with_pixels: possible_stages = Resources_getting_image_stage.texture_with_pixels_acceptable_stages; break;
                    case Resource_image_content.texture_with_pixels_applied: possible_stages = Resources_getting_image_stage.texture_with_pixels_applied_acceptable_stages; break;
                    case Resource_image_content.sprite: possible_stages = Resources_getting_image_stage.sprite_acceptable_stages; break;
                    
                }

                if( !!!( TOOL__resource_image.Verify_stage( _image, possible_stages ) ) )
                    { CONTROLLER__errors.Throw( $"Image { _image.name } is with content { _image.actual_content } but the stage is { _image.stage_getting_resource }" ); }
                    
                return;

        }


}