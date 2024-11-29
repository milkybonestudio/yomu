

public static class TOOL__resources_images_handler_REAJUST {



        public static int Handle_waiting_to_get_compress_file_REAJUST( MANAGER__resources_images _manager, RESOURCE__image _image ){ 


                int weight = 0;

                Console.Log( "veio Handle_waiting_to_get_compress_file_REAJUST()" );

                if( _manager.task_getting_compress_file_REAJUST != null )       
                    { return weight; } // --- TASK ALREADY IN USE
                
                _manager.task_getting_compress_file_REAJUST = CONTROLLER__tasks.Pegar_instancia().Get_task_request( "task_getting_compress_file_REAJUST_REAJUST" );
                _manager.task_getting_compress_file_REAJUST.fn_multithread = ( Task_req req )=> { TASK_REQ.Add_single_data( req, TOOL__get_data_images_resources.Get_single( _image ) ); };

                _image.stage_getting_resource = Resources_getting_image_stage.getting_compress_file_REAJUST;

                return weight;

            return 0; 

        }



        public static int Handle_getting_compress_file_REAJUST( MANAGER__resources_images _manager,  RESOURCE__image _image ){ 
            
                Console.Log( "Handle_getting_compress_file_REAJUST()" );

                if( _manager.task_getting_compress_file_REAJUST == null )
                    { CONTROLLER__errors.Throw(  $"the image { _image.name } was as getting_compress_file but the task_req is null" ); }

                if( _image.content_going_to != Resource_image_content.sprite )
                    { CONTROLLER__errors.Throw(  $"was getting the compress file in REAJUST  { _image.name }, but the content_going_to is { _image.content_going_to }. Need to be sprite" ); }

                int weight = 0;

                if( !!!( _manager.task_getting_compress_file_REAJUST.finalizado ) )
                    { return weight; }

                // --- TASK GET THE PNG                

                if( _manager.task_getting_compress_file_REAJUST.dados[ 0 ] == null )
                    { CONTROLLER__errors.Throw( $"the image { _image.name } was as getting_compress_file but the png is null" ); }  

                // --- CHANGE DATA
                _image.single_image.image_compress = ( byte[] ) _manager.task_getting_compress_file_REAJUST.dados[ 0 ];
                _manager.task_getting_compress_file_REAJUST = null;

                //_image.actual_content = Resource_image_content.compress_data;

                if( !!!( PNG.Verify_is_png( _image.single_image.image_compress ) ) )
                    { CONTROLLER__errors.Throw( "was not a png NO HANLDE" ); }

                ARRAY.Print_length( "Png length", _image.single_image.image_compress );

                // --- NEXT STEAP
                _image.stage_getting_resource = Resources_getting_image_stage.waiting_to_pass_data_to_texture_REAJUST;
                    
                return weight;
                
        }

        public static int Handle_waiting_to_pass_data_to_texture_REAJUST( MANAGER__resources_images _manager, RESOURCE__image _image ){ 


                Console.Log( "Handle_waiting_to_pass_data_to_texture_REAJUST" );

                if( _image.content_going_to != Resource_image_content.sprite )
                    { CONTROLLER__errors.Throw(  $"The image { _image.name } was going to create passing the data to the texture in the REAJUS, but the content_going_to is { _image.content_going_to }" ); }

                int weight = 0;

                if( _manager.task_passing_to_texture_REAJUST != null )
                    { return weight; } // --- TASK ALREADY IN USE

                if( !!!( PNG.Verify_is_png( _image.single_image.image_compress ) ) )
                    { CONTROLLER__errors.Throw( "was not a png" ); }

                // --- GET TASK
                _manager.task_passing_to_texture_REAJUST = CONTROLLER__tasks.Pegar_instancia().Get_task_request( "task_passing_to_texture_REAJUST" );
                _manager.task_passing_to_texture_REAJUST.fn_multithread = ( Task_req req ) => { TOOL__loader_texture.Transfer_data_PNG( _image.single_image.image_compress, _image.single_image.texture_exclusiva_native_array );  };

                // --- NEXT STEAP
                _image.stage_getting_resource = Resources_getting_image_stage.passing_data_to_texture_REAJUST;

                return weight;

        }

        public static int Handle_passing_data_to_texture_REAJUST( MANAGER__resources_images _manager, RESOURCE__image _image ){ 

            
                Console.Log( "Handle_passing_data_to_texture" );

                if( _manager.task_passing_to_texture_REAJUST == null )
                    { CONTROLLER__errors.Throw(  $"the image { _image.name } was as passing data to the texturew but the task_req is null" ); }

                if( _image.content_going_to < Resource_image_content.sprite )
                    { CONTROLLER__errors.Throw(  $"The image { _image.name } was passing the data to the texture, but the content_going_to is { _image.content_going_to }" ); }


                if( !!!( _manager.task_passing_to_texture_REAJUST.finalizado ) )
                    { return 0; }

                
                // --- NEXT STEAP
                _manager.task_passing_to_texture_REAJUST = null;
                _image.stage_getting_resource = Resources_getting_image_stage.waiting_to_apply_texture_REAJUST;

                return 0; 

        }

        public static int Handle_waiting_to_apply_texture_REAJUST( MANAGER__resources_images _manager, RESOURCE__image _image ){ 

                Console.Log( "Handle_waiting_to_apply_texture_REAJUST" );

                if( _image.content_going_to != Resource_image_content.sprite )
                    { CONTROLLER__errors.Throw( $"The image { _image.name } was going to create passing the data to the texture, but the content_going_to is { _image.content_going_to }" ); }
                
                int weight = 1;

                // --- APPLY
                _image.single_image.texture_exclusiva.Apply();
                
                // ** TERMINOU
                _image.stage_getting_resource = Resources_getting_image_stage.finished;

                return weight;
            
            return 0; 
        }



}