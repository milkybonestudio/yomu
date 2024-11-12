using System;
using UnityEngine;


public static class TOOL__resources_images_handler_UP {


        public static int Handle_waiting_to_start( MANAGER__resources_images _manager, RESOURCE__image _image ){


                TOOL__resource_image.Verify_image( _image );

                #if UNITY_EDITOR

                    //** no editor nao tem low_quality

                    if( _image.content_going_to == Resource_image_content.nothing )
                        { _image.stage_getting_resource = Resources_getting_image_stage.finished;  } 
                        else 
                        { _image.stage_getting_resource = Resources_getting_image_stage.waiting_to_get_compress_file; }
                    
                    return 0;

                #endif


                // --- VERIFICA SE PRECISA TER
                if( _image.data_size < 2_000 )
                    {
                        // --- TOO SMALL 
                        if( _image.content_going_to == Resource_image_content.nothing )
                            { _image.stage_getting_resource = Resources_getting_image_stage.finished; } 
                            else 
                            { _image.stage_getting_resource = Resources_getting_image_stage.waiting_to_get_compress_file; }

                        return 0;

                    }


                if ( _manager.task_getting_compress_low_quality_file != null )
                    { return 0; } // fica esperando?


                // --- GET WEBP
                
                _image.stage_getting_resource = Resources_getting_image_stage.getting_compress_low_quality_file;

                _manager.task_getting_compress_low_quality_file = CONTROLLER__tasks.Pegar_instancia().Get_task_request( "task_getting_compress_low_quality_file" );
                _manager.task_getting_compress_low_quality_file.prioridade = 1000;

                int weight = 1;

                if( _image.single_image != null )
                    { _manager.task_getting_compress_low_quality_file.fn_multithread = ( Task_req req ) => { TASK_REQ.Add_single_data( req, TOOL__get_data_images_resources.Get_single_low_quality( _image ) ); }; }  // --- SINGLE IMAGE
                    else
                    { _manager.task_getting_compress_low_quality_file.fn_multithread = ( Task_req req ) => { TASK_REQ.Add_single_data( req, TOOL__get_data_images_resources.Get_multiples_data( _image.main_folder, ( _image.path_locator + "_low_quality" ), _image.number_images ) ); }; } // --- MULTIPLES IMAGES


                return weight;

        }



        public static int Handle_getting_compress_low_quality_file( MANAGER__resources_images _manager, RESOURCE__image _image ){


                CONTROLLER__errors.Verify( ( _manager.task_getting_compress_low_quality_file == null ), $"the image { _image.name } was as getting_compress_low_quality_file but the task_req is null" );

                if( !!!( _manager.task_getting_compress_low_quality_file.finalizado ) )
                    { return 0; }

                // --- JA PEGOU A IMAGEM

                if( _image.single_image != null )
                    { 
                        // --- SINGLE IMAGE
                        _image.single_image.image_low_quality_compress = ( byte[] ) _manager.task_getting_compress_low_quality_file.dados[ 0 ];
                    } 
                    else
                    { 
                        // --- MULTIPLES IMAGES
                        byte[][] webps = ( byte[][] ) _manager.task_getting_compress_low_quality_file.dados[ 0 ];
                        for( int webp_index = 0 ; webp_index < _image.multiples_images.Length ; webp_index++ )
                            { _image.multiples_images[ webp_index ].image_low_quality_compress = webps[ webp_index ]; }

                    } 

                _manager.task_getting_compress_low_quality_file = null;


                // ** se so precisar dos dados é isso ai
                if( _image.content_going_to == Resource_image_content.nothing )
                    { _image.stage_getting_resource = Resources_getting_image_stage.finished; return 0; } // ** sempre tem o webp?
                
                _image.stage_getting_resource = Resources_getting_image_stage.waiting_to_get_compress_file;

                return 0;

        }

        public static int Handle_waiting_to_get_compress_file( MANAGER__resources_images _manager, RESOURCE__image _image ){

                int weight = 0;

                if( _manager.task_getting_compress_file != null )
                    { return weight; } // ** algum outro arquivo esta pegando 
                
                Console.Log( "veio Handle_waiting_to_get_compress_file" );
                
                _manager.task_getting_compress_file = CONTROLLER__tasks.Pegar_instancia().Get_task_request( "task_getting_compress_file" );

                if( _image.single_image != null )
                    { _manager.task_getting_compress_file.fn_multithread = ( Task_req req )=> { TASK_REQ.Add_single_data( req, TOOL__get_data_images_resources.Get_single( _image ) ); };  } // --- SINGLE IMAGE
                    else
                    { _manager.task_getting_compress_file.fn_multithread = ( Task_req req )=> { TASK_REQ.Add_single_data( req, TOOL__get_data_images_resources.Get_multiples_data( _image.main_folder, ( _image.path_locator ), _image.number_images ) ); }; } // --- MULTIPLES IMAGES

                
                _image.stage_getting_resource = Resources_getting_image_stage.getting_compress_file;

                return weight;

        }


        public static int Handle_getting_compress_file( MANAGER__resources_images _manager, RESOURCE__image _image ){ 

                Console.Log( "Handle_getting_compress_file" );

                CONTROLLER__errors.Verify( ( _manager.task_getting_compress_file == null ), $"the image { _image.name } was as getting_compress_file but the task_req is null" );

                if( !!!( _manager.task_getting_compress_file.finalizado ) )
                    { return 0; }

                Console.Log( "Pegou o arquivo" );

                if( _image.content_going_to < Resource_image_content.compress_data )
                    { CONTROLLER__errors.Throw( $"Get the png for the image { _image.name }, but the content_going_to is { _image.content_going_to }" ); }

                // ** passa o PNG para a imagem
                if( _image.multiples_images == null )
                    {
                        // --- somente 1 imagem 
                        _image.single_image.image_compress = ( byte[] ) _manager.task_getting_compress_file.dados[ 0 ];
                        Console.Log( "Png length: " + _image.single_image.image_compress.Length.ToString("#,0").Replace( ".", "_" ) );
                        Dimensions dimensions = PNG.Get_dimensions( _image.single_image.image_compress );
                        _image.width = dimensions.width;
                        _image.height = dimensions.height;
                         
                    }
                    else
                    {

                        byte[][] pngs = ( byte[][] ) _manager.task_getting_compress_file.dados[ 0 ];
                        Dimensions dimensions = PNG.Get_dimensions( pngs[ 0 ] );
                        _image.width = dimensions.width;
                        _image.height = dimensions.height;

                        for( int png_index = 0 ; png_index < _image.multiples_images.Length ; png_index++ )
                            { _image.multiples_images[ png_index ].image_compress = pngs[ png_index ]; }
                        
                    }

                _manager.task_getting_compress_file = null;

                _image.actual_content = Resource_image_content.compress_data;
                Console.Log( "_image.content_going_to: " + _image.content_going_to );

                // ** se so precisar dos dados é isso ai
                if( _image.content_going_to == Resource_image_content.compress_data )
                    { 
                        Console.Log("terminou de pegar compress data");
                        
                        _image.stage_getting_resource = Resources_getting_image_stage.finished; 
                        return 0; 
                    }
                    
                _image.stage_getting_resource = Resources_getting_image_stage.waiting_to_get_texture;
                
                return 0;
            
        }

        

        public static int Handle_waiting_to_get_texture( MANAGER__resources_images _manager, RESOURCE__image _image ){


                // ** por hora nao vai fazer isso, vai criar 1 especifica para cada para simplificar
                // ** o apply vai ser dado quando terminar de passar os pixels

                Console.Log( "Handle_waiting_to_get_texture" );

                int weight = 0;

                if( _image.single_image != null  )
                    {
                        _image.single_image.texture_exclusiva = new Texture2D( _image.width, _image.height, TextureFormat.RGBA32, false );
                        _image.single_image.texture_exclusiva_native_array = _image.single_image.texture_exclusiva.GetPixelData<Color32>( 0 );
                        weight = 3;

                    }
                    else
                    {

                        for( int texture_index = 0 ; texture_index < _image.multiples_images.Length ; texture_index++ ){ 

                            RESOURCE__image_data data = _image.multiples_images[ texture_index ];
                            data.texture_exclusiva = new Texture2D( _image.width, _image.height, TextureFormat.RGBA32,  false );
                            data.texture_exclusiva_native_array =  data.texture_exclusiva.GetPixelData<Color32>( 0 );
                            weight++;

                        }

                    }

                _image.actual_content = Resource_image_content.texture;
                _image.stage_getting_resource = Resources_getting_image_stage.waiting_to_pass_data_to_texture;


                return weight;


        }



        public static int Handle_getting_texture( MANAGER__resources_images _manager, RESOURCE__image image ){ 
                        
            throw new Exception( "nao era para usar" );
            
        }

        public static int Handle_waiting_to_pass_data_to_texture( MANAGER__resources_images _manager, RESOURCE__image _image ){

                Console.Log( "Handle_waiting_to_pass_data_to_texture" );

                if( _manager.task_passing_to_texture != null )
                    { return 0; }            

                _manager.task_passing_to_texture = CONTROLLER__tasks.Pegar_instancia().Get_task_request( "task_passing_to_texture" );

                if( _image.single_image != null )
                    { _manager.task_passing_to_texture.fn_multithread = ( Task_req req ) => { TOOL__loader_texture.Transfer_data_PNG( _image.single_image.image_compress, _image.single_image.texture_exclusiva_native_array );  }; }  // --- SINGLE IMAGE
                    else
                    { _manager.task_passing_to_texture.fn_multithread = ( Task_req req ) => { foreach( RESOURCE__image_data data in _image.multiples_images ){ TOOL__loader_texture.Transfer_data_PNG( data.image_compress, data.texture_exclusiva_native_array );   }; }; } // --- MULTIPLES _IMAGES

                _image.stage_getting_resource = Resources_getting_image_stage.passing_data_to_texture;

 
                return 0;

        }

    
        public static int Handle_passing_data_to_texture( MANAGER__resources_images _manager, RESOURCE__image _image ){ 

                Console.Log( "Handle_passing_data_to_texture" );

                CONTROLLER__errors.Verify( ( _manager.task_passing_to_texture == null ), $"the image { _image.name } was as passing data to the texturew but the task_req is null" );

                if( !!!( _manager.task_passing_to_texture.finalizado ) )
                    { return 0; }

                // ** imagem foi passada para a texture

                _manager.task_passing_to_texture = null;
                _image.actual_content = Resource_image_content.texture_with_pixels_applied;
                _image.stage_getting_resource = Resources_getting_image_stage.waiting_to_apply_texture;

                return 0; 

        }



        public static int Handle_waiting_to_apply_texture( MANAGER__resources_images _manager, RESOURCE__image _image ){

                Console.Log( "Handle_waiting_to_apply_texture" );

                int weight = 0;
                if( _image.single_image != null )
                    { 
                        _image.single_image.texture_exclusiva.Apply(); 
                        weight++;
                    }
                    else
                    {
                        foreach( RESOURCE__image_data data in _image.multiples_images ){ 

                            data.texture_exclusiva.Apply();
                            weight++;
                            
                        }

                    }

                _image.actual_content = Resource_image_content.texture_with_pixels_applied;
                _image.stage_getting_resource = Resources_getting_image_stage.waiting_to_create_sprite;
                return weight;


                            
                return 10;

        }



        public static int Handle_applying_texture( MANAGER__resources_images _manager, RESOURCE__image _image ){

                CONTROLLER__errors.Throw( "Nao era para ter vindo aqui" );

                return 0;

                // if( !!!( task_applying_texture.finalizado ) )
                //     { return 0; }

                // task_applying_texture = null;
                // _image.actual_content = Resource_image_content.texture_with_pixels_applied;
                // _image.stage_getting_resource = Resources_getting_image_stage.waiting_to_create_sprite;

                // // tem que sinalizar que alguma texture já pode ser dado o apply. cada texture grande tem que ter o controle de quantas imagens precisam dar o ok para tudo dar certo
                // return 0;

        }

        public static int Handle_waiting_to_create_sprite( MANAGER__resources_images _manager, RESOURCE__image _image ){

                Console.Log( "Handle_waiting_to_create_sprite" );

                int weight = 0;

                // ** por hora esta sendo usado a _image.single_image.texture_exclusiva
                if( _image.single_image != null )
                    { weight = 1; _image.single_image.sprite = Sprite.Create( _image.single_image.texture_exclusiva, new Rect( 0f, 0f, _image.width, _image.height ), new Vector2(0.5f, 0.5f), 100.0f ,0, SpriteMeshType.FullRect   ); }  // --- SINGLE _IMAGE
                    else
                    { weight = _image.multiples_images.Length; foreach( RESOURCE__image_data data in _image.multiples_images ){ data.sprite = Sprite.Create( data.texture_allocated.texture, new Rect( 0f, 0f, _image.width, _image.height ), new Vector2(0.5f, 0.5f), 100.0f ,0, SpriteMeshType.FullRect   ); }} // --- MULTIPLES IMAGES


                _image.actual_content = Resource_image_content.sprite;
                _image.stage_getting_resource = Resources_getting_image_stage.finished;

                return weight;

        }





}