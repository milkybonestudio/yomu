using UnityEngine;

public static class TOOL__resource_image {



        public static void Verify_image( RESOURCE__image _image ){




                CONTROLLER__errors.Verify( !!!( _image.single_image.used ),  $"In the image request { _image.name } was given single and multiples images" );
                
                if( _image.actual_content == Resource_image_content.nothing )
                    {
                        if ( _image.single_image.image_compress != null )
                            { throw new System.Exception( $"current state was \"nothing\" but there is a compress image in the image ${ _image.name }" ); }

                    }


                return;

        }


        public static bool Need_to_update( RESOURCE__image _image ){

                bool need_update = ( _image.content_going_to != _image.actual_content ) || ( ( _image.stage_getting_resource & Resources_getting_image_stage.all_reajust_stages ) != 0 );


                if( !!!( need_update ) && ( _image.stage_getting_resource != Resources_getting_image_stage.finished ) )
                    {

                        Console.LogError( $"Image is tecnicly finished, but the stage is not in the image { _image.name }" );
                        Console.LogError( $"   stage_getting_resource: { _image.stage_getting_resource }" );
                        Console.LogError( $"   actual_content: { _image.actual_content }" );
                        Console.LogError( $"   content_going_to: { _image.content_going_to }" );
                    
                        CONTROLLER__errors.Throw( $"" ); 
                    }
                    

                return need_update;
        
        }



        public static int Down_resources( RESOURCE__image _image ){

                Console.Log( "Veio down resources" );

                if( Verify_stage( _image, Resources_getting_image_stage.all_reajust_stages ) )
                    { Remove_REAJUST( _image ); }
                    else
                    { Remove_getting( _image ); }

                return Set_stage( _image, Resources_getting_image_stage.waiting_to_destroy_current_resource );

        }


        // ** faz nao dar merda 
        public static void Remove_getting( RESOURCE__image _image ){

                MANAGER__resources_images manager = _image.module_images.manager;
                        
                    if( _image.stage_getting_resource == Resources_getting_image_stage.getting_compress_file )
                        {  
                            if( ( manager.task_getting_compress_file.finalizado ) )
                                { 
                                    // --- APROVEITAR 
                                    _image.single_image.image_compress = ( byte[] ) _image.module_images.manager.task_getting_compress_file.dados[ 0 ];
                                    _image.actual_content = Resource_image_content.compress_data; 
                                }
                                else
                                {
                                    TASK_REQ.Cancel_task( ref manager.task_getting_compress_file );
                                }

                        }
                else if( _image.stage_getting_resource == Resources_getting_image_stage.getting_compress_low_quality_file )
                        {  

                            if( _image.single_image.have_low_quality_compress )
                                {
                                    // --- APROVEITAR 
                                    if( ( manager.task_getting_compress_low_quality_file.finalizado ) )
                                        { 
                                            _image.single_image.image_low_quality_compress = ( byte[] ) _image.module_images.manager.task_getting_compress_low_quality_file.dados[ 0 ];
                                            _image.actual_content = Resource_image_content.compress_data; 
                                        }
                                        else
                                        {
                                            TASK_REQ.Cancel_task( ref manager.task_getting_compress_low_quality_file );
                                        }

                                }

                        }
                else if( _image.stage_getting_resource == Resources_getting_image_stage.passing_data_to_texture )
                        {  
                            
                            if( ( manager.task_passing_to_texture.finalizado ) )
                                { 
                                    // --- APROVEITAR 
                                    _image.actual_content = Resource_image_content.texture_with_pixels; 
                                }
                                else
                                {
                                    _image.actual_content = Resource_image_content.compress_data;
                                    Lose_texture( _image, manager.task_passing_to_texture );
                                    TASK_REQ.Cancel_task( ref manager.task_passing_to_texture );
                                }

                        }

                
        }



        public static void Remove_REAJUST( RESOURCE__image _image ){


                MANAGER__resources_images manager = _image.module_images.manager;

                        if( _image.stage_getting_resource == Resources_getting_image_stage.waiting_to_get_compress_file_REAJUST )
                        {  
                            // TASK_REQ.Cancel_task( ref manager.task_getting_compress_file_REAJUST );
                
                            _image.actual_content = Resource_image_content.compress_low_quality_data; 
                            _image.single_image.sprite = null; // not real sprite 
                        }
                else if( _image.stage_getting_resource == Resources_getting_image_stage.getting_compress_file_REAJUST )
                        { 

                            if( ( _image.module_images.manager.task_getting_compress_file_REAJUST.finalizado ) )
                                { 
                                    // --- APROVEITAR 
                                    _image.single_image.image_compress = ( byte[] ) manager.task_getting_compress_file_REAJUST.dados[ 0 ];
                                    CONTROLLER__errors.Verify( ( !!!( PNG.Verify_is_png( _image.single_image.image_compress ) ) ), " not a png " );
                                    _image.actual_content = Resource_image_content.texture; 
                                }
                                else
                                {
                                    Lose_texture( _image, manager.task_getting_compress_file_REAJUST );
                                    _image.actual_content = Resource_image_content.compress_low_quality_data;
                                }

                            manager.task_getting_compress_file_REAJUST = null;
            
                        }
                else if( _image.stage_getting_resource == Resources_getting_image_stage.waiting_to_pass_data_to_texture_REAJUST )
                        {  
                            _image.actual_content = Resource_image_content.texture; // ** ignora os pixels que já estavam ali
                        }
                else if( _image.stage_getting_resource == Resources_getting_image_stage.passing_data_to_texture_REAJUST )
                        { 
                            if( ( manager.task_passing_to_texture_REAJUST.finalizado ) )
                                { 
                                    // --- APROVEITAR
                                    _image.actual_content = Resource_image_content.texture_with_pixels;
                                }
                                else
                                {
                                    Lose_texture( _image, manager.task_passing_to_texture_REAJUST );
                                    _image.actual_content = Resource_image_content.compress_data;
                                }
                            manager.task_passing_to_texture_REAJUST = null;

                        }
                else if( _image.stage_getting_resource == Resources_getting_image_stage.waiting_to_apply_texture_REAJUST )
                        {  
                            _image.actual_content = Resource_image_content.texture_with_pixels; 
                        }


        }


        public static void Lose_texture( RESOURCE__image _image, Task_req _req ){

                // ** LOSE TEXTURE

                if( _image.single_image.texture_exclusiva == null )
                    { return; } // ? 

                _req.data_1 = _image.single_image.texture_exclusiva;
                _image.single_image.texture_exclusiva = null;
                _req.fn_single_thread = ( Task_req _req )  =>   {  try{ GameObject.Destroy( ( Texture2D ) _req.data_1 );} catch( System.Exception e ){ Console.LogError( "AAAAAAA:" + _req.dados[ 0 ] ); } };

        }



        public static void Verify_image_ref ( RESOURCE__image_ref image_ref ){

                return;

        }


        public static void Change_actual_content_count( RESOURCE__image_ref _image_ref, Resource_image_content _new_content ){


                RESOURCE__image image = _image_ref.image;

                Resource_image_content old_content = _image_ref.actual_need_content;
                
                if( old_content == _new_content )
                    { return; }

                Increase_count( image, _new_content );
                Decrease_count( image, old_content );

                _image_ref.actual_need_content = _new_content;

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





        public static bool Verify_stage( RESOURCE__image _image, Resources_getting_image_stage _stage ){

            return ( ( _image.stage_getting_resource & _stage ) != 0 );

        }

    
        public static bool Verify_actual_content( RESOURCE__image _image, Resource_image_content _content ){

            return ( ( _image.actual_content & _content ) != 0 );

        }

    
        public static int Set_stage( RESOURCE__image _image,  Resources_getting_image_stage _stage ){

            _image.stage_getting_resource = _stage;
            return 0;

        }

        public static int Set_stage_cancelling_task( RESOURCE__image _image,  Resources_getting_image_stage _stage, ref Task_req _task_ref ){

            _image.stage_getting_resource = _stage;
            TASK_REQ.Cancel_task( ref _task_ref );
            return 0;

        }




        public static void Print_image_data( RESOURCE__image_ref _image_ref ){


                if( _image_ref == null )
                    { return; }

                RESOURCE__image image = _image_ref.image;

                Console.Clear();

                Console.Log( "<Color=lightBlue>-------------------</Color>" );
                Console.Log( "<Color=lightBlue>REF:</Color>" );


                Console.Log( $" state: { _image_ref.state } " );
                Console.Log( $" actual_need_content: { _image_ref.actual_need_content } " );
                Console.Log( $" level_pre_allocation: { _image_ref.level_pre_allocation } " );
                Console.Log( $" ref_state: { _image_ref.ref_state } " );
                Console.Log( $" module: { _image_ref.module } " );
                Console.Log( $" image: { _image_ref.image } " );
                Console.Log( $" image_slot_index: { _image_ref.image_slot_index } " );

                if( image == null )
                    {  return; }

                Console.Log( "<Color=lightBlue>  IMAGE:</Color>" );
                Console.Log( $"   actual_content: { image.actual_content }" );
                Console.Log( $"   content_going_to: { image.content_going_to }" );
                Console.Log( $"   stage_getting_resource: { image.stage_getting_resource }" );

                // -- image 

                if(  image.single_image.image_compress != null )
                    { Console.Log( $"     image_compress.Length:  { Formater.Format_number(  image.single_image.image_compress.Length ) }" ); }
                    else 
                    { Console.Log( $"     image_compress.Length:  " ); }
                    

                Console.Log( $"     tem low_quality: "  + image.single_image.have_low_quality_compress );
                if(  image.single_image.image_low_quality_compress != null )
                    { Console.Log( $"     image_low_quality_compress.Length:  {  Formater.Format_number( image.single_image.image_low_quality_compress.Length ) }" ); }
                    else
                    { Console.Log( $"     image_low_quality_compress.Length:  " ); }


                Console.Log( $"     single_image.sprite: { image.single_image.sprite }" );

                if( image.single_image.texture_exclusiva != null )
                    { Console.Log( $"     tamanho: { Formater.Format_number( image.single_image.texture_exclusiva.width * image.single_image.texture_exclusiva.height ) } px" ); }

                Console.Log( $"     counts: " );
                Console.Log( $"         image.count_places_being_used_nothing: { image.count_places_being_used_nothing }" );
                Console.Log( $"         image.count_places_being_used_compress_low_quality_data: { image.count_places_being_used_compress_low_quality_data }" );
                Console.Log( $"         image.count_places_being_used_compress_data: { image.count_places_being_used_compress_data }" );
                Console.Log( $"         image.count_places_being_used_sprite: { image.count_places_being_used_sprite }" );
            
                

        }



}