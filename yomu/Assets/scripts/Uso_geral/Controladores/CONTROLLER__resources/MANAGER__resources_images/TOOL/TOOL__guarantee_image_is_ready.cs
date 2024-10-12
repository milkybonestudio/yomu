

public static class TOOL_MANAGER__guarantee_image_is_ready {


    
        public static void Guarantee( MANAGER__resources_images _manager, RESOURCE__image_ref _ref ){

                
                TOOL__resource_image.Verify( _ref.image );

                if( _ref.image.single_image != null )
                    { Guarantee_image_is_ready_SINGLE( _manager, _ref.image ); } // --- IMAGEM SIMPLES
                    else
                    { Guarantee_image_is_ready_MULTIPLE( _manager, _ref.image ); } // --- MULTIPLES

                return;
                
        }


        private static void Guarantee_image_is_ready_SINGLE( MANAGER__resources_images _manager, RESOURCE__image _image ){

                RESOURCE__image_data single_image = _image.single_image;


                MODULE__context_images module_images = _manager.context_images_modules[ ( int ) _image.image_context ];
                
                
                // --- GARANTE QUE TEM COMPRESS
                if( _image.stage_getting_resource == Resources_getting_image_stage.waiting_to_start )
                    {  single_image.image_compress = TOOL__get_data_images_resources.Get( module_images, _image ); _image.stage_getting_resource = Resources_getting_image_stage.getting_texture; }


                // ** getting png
                if( _image.stage_getting_resource == Resources_getting_image_stage.getting_wait_file )
                    { _manager.task_getting_file.pode_executar_single_thread = false; } // --- nao vai mais usar 

                
                if( _image.stage_getting_resource == Resources_getting_image_stage.getting_texture ) // ** significa que não tem texture
                    { 

                        _manager.textures_manager.Get_texture( single_image );  

                    } 
                

                if( _image.stage_getting_resource == Resources_getting_image_stage.passing_to_texture )
                    { 
                        // ** esse vai ser o mais complicado porque 

                        // *** AINDA PRECISA EXECUTAR A PARTE NA MAIN PARA LIBERAR A TEXTURE
                        _manager.task_passing_to_texture.pode_executar_parte_multithread = false; 

                        _manager.task_passing_to_texture = null;
                        //mark
                        //_image.single_image.Liberate_texture(); // ** vai pegar outra

                    }

                return;

        }

        
        private static void Guarantee_image_is_ready_MULTIPLE( MANAGER__resources_images _manager, RESOURCE__image _image ){

                throw new System.Exception("a");

        }







}