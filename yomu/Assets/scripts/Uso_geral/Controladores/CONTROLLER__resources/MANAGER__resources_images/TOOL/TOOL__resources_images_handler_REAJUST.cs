

public static class TOOL__resources_images_handler_REAJUST {



        public static int Handle_waiting_to_get_compress_file_REAJUST( MANAGER__resources_images _manager, RESOURCE__image _image ){ 


                int weight = 0;

                Console.Log( "veio Handle_waiting_to_get_compress_file_REAJUST()" );

                if( _manager.task_getting_compress_file != null )       
                    { return weight; } // --- TASK ALREADY IN USE
                
                _manager.task_getting_compress_file = CONTROLLER__tasks.Pegar_instancia().Get_task_request( "task_getting_compress_file_REAJUST" );
                _manager.task_getting_compress_file.fn_multithread = ( Task_req req )=> { TASK_REQ.Add_single_data( req, TOOL__get_data_images_resources.Get_single( _image ) ); };

                _image.stage_getting_resource = Resources_getting_image_stage.getting_compress_file_REAJUST;

                return weight;

            return 0; 

        }



        public static int Handle_getting_compress_file_REAJUST( MANAGER__resources_images _manager,  RESOURCE__image _image ){ 
            
                Console.Log( "Handle_getting_compress_file_REAJUST()" );

                CONTROLLER__errors.Verify( ( _manager.task_getting_compress_file == null ), $"the image { _image.name } was as getting_compress_file but the task_req is null" );
                CONTROLLER__errors.Verify( ( _image.content_going_to != Resource_image_content.sprite ), $"was getting the compress file in REAJUST  { _image.name }, but the content_going_to is { _image.content_going_to }. Need to be sprite" );

                int weight = 0;

                if( !!!( _manager.task_getting_compress_file.finalizado ) )
                    { return weight; }

                // --- TASK GET THE PNG                

                CONTROLLER__errors.Verify( ( _manager.task_getting_compress_file.dados[ 0 ] == null ), $"the image { _image.name } was as getting_compress_file but the png is null" );

                // --- CHANGE DATA
                _image.single_image.image_compress = ( byte[] ) _manager.task_getting_compress_file.dados[ 0 ];
                _manager.task_getting_compress_file = null;
                _image.actual_content = Resource_image_content.compress_data;

                CONTROLLER__errors.Verify( ( !!!( PNG.Verify_is_png( _image.single_image.image_compress ) ) ), "was not a png NO HANLDE" );

                ARRAY.Print_length( "Png length", _image.single_image.image_compress );

                // --- NEXT STEAP
                _image.stage_getting_resource = Resources_getting_image_stage.waiting_to_pass_data_to_texture_REAJUST;
                    
                return weight;
                
        }

        public static int Handle_waiting_to_pass_data_to_texture_REAJUST( MANAGER__resources_images _manager, RESOURCE__image _image ){ 


                Console.Log( "Handle_waiting_to_pass_data_to_texture_REAJUST" );

                CONTROLLER__errors.Verify( ( _image.content_going_to != Resource_image_content.sprite ), $"The image { _image.name } was going to create passing the data to the texture in the REAJUS, but the content_going_to is { _image.content_going_to }" );

                int weight = 0;

                if( _manager.task_passing_to_texture != null )
                    { return weight; } // --- TASK ALREADY IN USE


                CONTROLLER__errors.Verify( ( !!!( PNG.Verify_is_png( _image.single_image.image_compress ) ) ), "was not a png" );

                // --- GET TASK
                _manager.task_passing_to_texture = CONTROLLER__tasks.Pegar_instancia().Get_task_request( "task_passing_to_texture" );
                _manager.task_passing_to_texture.fn_multithread = ( Task_req req ) => { TOOL__loader_texture.Transfer_data_PNG( _image.single_image.image_compress, _image.single_image.texture_exclusiva_native_array );  };

                // --- NEXT STEAP
                _image.stage_getting_resource = Resources_getting_image_stage.passing_data_to_texture_REAJUST;

                return weight;

        }

        public static int Handle_passing_data_to_texture_REAJUST( MANAGER__resources_images _manager, RESOURCE__image _image ){ 


            
                Console.Log( "Handle_passing_data_to_texture" );

                CONTROLLER__errors.Verify( ( _manager.task_passing_to_texture == null ), $"the image { _image.name } was as passing data to the texturew but the task_req is null" );
                CONTROLLER__errors.Verify( ( _image.content_going_to < Resource_image_content.sprite ), $"The image { _image.name } was passing the data to the texture, but the content_going_to is { _image.content_going_to }" );

                if( !!!( _manager.task_passing_to_texture.finalizado ) )
                    { return 0; }

                
                // --- NEXT STEAP
                _manager.task_passing_to_texture = null;
                _image.stage_getting_resource = Resources_getting_image_stage.waiting_to_apply_texture_REAJUST;

                return 0; 

            
        }
        public static int Handle_waiting_to_apply_texture_REAJUST( MANAGER__resources_images _manager, RESOURCE__image _image ){ 

                Console.Log( "Handle_waiting_to_apply_texture_REAJUST" );

                CONTROLLER__errors.Verify( ( _image.content_going_to != Resource_image_content.sprite ), $"The image { _image.name } was going to create passing the data to the texture, but the content_going_to is { _image.content_going_to }" );
                
                int weight = 1;

                // --- APPLY
                _image.single_image.texture_exclusiva.Apply();
                
                // ** TERMINOU
                _image.stage_getting_resource = Resources_getting_image_stage.finished;

                return weight;
            
            return 0; 
        }



}