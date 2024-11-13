using System;
using UnityEngine;


public static class TOOL__resources_images_handler_UP {


        public static int Handle_waiting_to_start( MANAGER__resources_images _manager, RESOURCE__image _image ){


                TOOL__resource_image.Verify_image( _image );

                int weight = 0;

                // --- VERIFICA SE PRECISA TER
                if( _image.data_size < 2_000 )
                    {
                        // --- TOO SMALL 
                        if( _image.content_going_to == Resource_image_content.nothing )
                            { _image.stage_getting_resource = Resources_getting_image_stage.finished; } 
                            else 
                            { _image.stage_getting_resource = Resources_getting_image_stage.waiting_to_get_compress_file; }

                        return weight;

                    }


                if ( _manager.task_getting_compress_low_quality_file != null )
                    { return weight; } // --- TASK ALREADY IN USE


                // --- GET WEBP
                
                _image.stage_getting_resource = Resources_getting_image_stage.getting_compress_low_quality_file;

                _manager.task_getting_compress_low_quality_file = CONTROLLER__tasks.Pegar_instancia().Get_task_request( "task_getting_compress_low_quality_file" );
                _manager.task_getting_compress_low_quality_file.prioridade = 1000;
                
                _manager.task_getting_compress_low_quality_file.fn_multithread = ( Task_req req ) => { TASK_REQ.Add_single_data( req, TOOL__get_data_images_resources.Get_single_low_quality( _image ) ); };

                return weight;

        }



        public static int Handle_getting_compress_low_quality_file( MANAGER__resources_images _manager, RESOURCE__image _image ){

                Console.Log( "veio Handle_getting_compress_low_quality_file()" );

                CONTROLLER__errors.Verify( ( _manager.task_getting_compress_low_quality_file == null ), $"the image { _image.name } was as getting_compress_low_quality_file but the task_req is null" );
                int weight = 0;

                if( !!!( _manager.task_getting_compress_low_quality_file.finalizado ) )
                    { return weight; }

                // --- JA PEGOU A IMAGEM

                _image.single_image.image_low_quality_compress = ( byte[] ) _manager.task_getting_compress_low_quality_file.dados[ 0 ];
                _manager.task_getting_compress_low_quality_file = null;
                _image.actual_content = Resource_image_content.compress_low_quality_data;


                if( _image.content_going_to == Resource_image_content.compress_low_quality_data )
                    { _image.stage_getting_resource = Resources_getting_image_stage.finished; return weight; } // ** sempre tem o webp?
                
                _image.stage_getting_resource = Resources_getting_image_stage.waiting_to_get_compress_file;

                return weight;

        }

        public static int Handle_waiting_to_get_compress_file( MANAGER__resources_images _manager, RESOURCE__image _image ){

                int weight = 0;

                Console.Log( "veio Handle_waiting_to_get_compress_file" );

                if( _manager.task_getting_compress_file != null )
                    { return weight; } // --- TASK ALREADY IN USE
                

                _manager.task_getting_compress_file = CONTROLLER__tasks.Pegar_instancia().Get_task_request( "task_getting_compress_file" );
                _manager.task_getting_compress_file.fn_multithread = ( Task_req req )=> { TASK_REQ.Add_single_data( req, TOOL__get_data_images_resources.Get_single( _image ) ); };

                _image.stage_getting_resource = Resources_getting_image_stage.getting_compress_file;

                return weight;

        }


        public static int Handle_getting_compress_file( MANAGER__resources_images _manager, RESOURCE__image _image ){ 


                Console.Log( "Handle_getting_compress_file()" );

                CONTROLLER__errors.Verify( ( _manager.task_getting_compress_file == null ), $"the image { _image.name } was as getting_compress_file but the task_req is null" );
                CONTROLLER__errors.Verify( ( _image.content_going_to < Resource_image_content.compress_data ), $"Get the png for the image { _image.name }, but the content_going_to is { _image.content_going_to }" );

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
                if( _image.content_going_to == _image.actual_content )
                    { _image.stage_getting_resource = Resources_getting_image_stage.finished; }
                    else
                    { _image.stage_getting_resource = Resources_getting_image_stage.waiting_to_get_texture; }
                    
                return weight;
            
        }

        

        public static int Handle_waiting_to_get_texture( MANAGER__resources_images _manager, RESOURCE__image _image ){


                // ** por hora nao vai fazer isso, vai criar 1 especifica para cada para simplificar
                // ** o apply vai ser dado quando terminar de passar os pixels

                Console.Log( "Handle_waiting_to_get_texture" );

                int weight = 3;

                CONTROLLER__errors.Verify( ( _image.width * _image.height == 0 ), $"Was going to get the texture for the image { _image.name }, but the width was { _image.width } and the height was { _image.height }" );
                CONTROLLER__errors.Verify( ( _image.content_going_to < Resource_image_content.sprite ), $"The image { _image.name } was going to create the texture, but the content_going_to is { _image.content_going_to }" );

                // --- CREATE DATA
                _image.single_image.texture_exclusiva = new Texture2D( _image.width, _image.height, TextureFormat.RGBA32, false );
                _image.single_image.texture_exclusiva.filterMode = FilterMode.Point;
                _image.single_image.texture_exclusiva_native_array = _image.single_image.texture_exclusiva.GetPixelData<Color32>( 0 );
                
                // --- NEXT STEAP
                _image.actual_content = Resource_image_content.texture;
                _image.stage_getting_resource = Resources_getting_image_stage.waiting_to_pass_data_to_texture;


                return weight;

        }


        public static int Handle_getting_texture( MANAGER__resources_images _manager, RESOURCE__image image ){ CONTROLLER__errors.Throw( "Nao era para ter vindo aqui" ); return 0; }


        public static int Handle_waiting_to_pass_data_to_texture( MANAGER__resources_images _manager, RESOURCE__image _image ){

                Console.Log( "Handle_waiting_to_pass_data_to_texture" );

                CONTROLLER__errors.Verify( ( _image.content_going_to < Resource_image_content.sprite ), $"The image { _image.name } was going to create passing the data to the texture, but the content_going_to is { _image.content_going_to }" );
                CONTROLLER__errors.Verify( ( _image.actual_content != Resource_image_content.texture ), $"The image { _image.name } was going to pass data to the texture, but the actual content is { _image.actual_content }" );

                int weight = 0;

                if( _manager.task_passing_to_texture != null )
                    { return weight; } // --- TASK ALREADY IN USE


                CONTROLLER__errors.Verify( ( !!!( PNG.Verify_is_png( _image.single_image.image_compress ) ) ), "was not a png" );

                // --- GET TASK
                _manager.task_passing_to_texture = CONTROLLER__tasks.Pegar_instancia().Get_task_request( "task_passing_to_texture" );
                _manager.task_passing_to_texture.fn_multithread = ( Task_req req ) => { TOOL__loader_texture.Transfer_data_PNG( _image.single_image.image_compress, _image.single_image.texture_exclusiva_native_array );  };

                // --- NEXT STEAP
                _image.stage_getting_resource = Resources_getting_image_stage.passing_data_to_texture;

                return weight;

        }

    
        public static int Handle_passing_data_to_texture( MANAGER__resources_images _manager, RESOURCE__image _image ){ 


                Console.Log( "Handle_passing_data_to_texture" );

                CONTROLLER__errors.Verify( ( _manager.task_passing_to_texture == null ), $"the image { _image.name } was as passing data to the texturew but the task_req is null" );
                CONTROLLER__errors.Verify( ( _image.content_going_to < Resource_image_content.sprite ), $"The image { _image.name } was passing the data to the texture, but the content_going_to is { _image.content_going_to }" );

                if( !!!( _manager.task_passing_to_texture.finalizado ) )
                    { return 0; }

                
                // --- NEXT STEAP
                _manager.task_passing_to_texture = null;
                _image.actual_content = Resource_image_content.texture_with_pixels;
                _image.stage_getting_resource = Resources_getting_image_stage.waiting_to_apply_texture;

                return 0; 

        }


        public static int Handle_waiting_to_apply_texture( MANAGER__resources_images _manager, RESOURCE__image _image ){


                Console.Log( "Handle_waiting_to_apply_texture" );

                CONTROLLER__errors.Verify( ( _image.content_going_to < Resource_image_content.sprite ), $"The image { _image.name } was going to create passing the data to the texture, but the content_going_to is { _image.content_going_to }" );
                CONTROLLER__errors.Verify( ( _image.actual_content != Resource_image_content.texture_with_pixels ), $"The image { _image.name } was going to apply the texture, but the actual content is { _image.actual_content }" );

                int weight = 1;

                // --- APPLY
                _image.single_image.texture_exclusiva.Apply();
                
                // --- NEXT STEAP
                _image.actual_content = Resource_image_content.texture_with_pixels_applied;
                _image.stage_getting_resource = Resources_getting_image_stage.waiting_to_create_sprite;

                return weight;

        }


        public static int Handle_applying_texture( MANAGER__resources_images _manager, RESOURCE__image _image ){ CONTROLLER__errors.Throw( "Nao era para ter vindo aqui" ); return 0; }

        public static int Handle_waiting_to_create_sprite( MANAGER__resources_images _manager, RESOURCE__image _image ){

                Console.Log( "Handle_waiting_to_create_sprite" );

                int weight = 1;

                // --- CREATE SPRITE
                _image.single_image.sprite = Sprite.Create( _image.single_image.texture_exclusiva, new Rect( 0f, 0f, _image.width, _image.height ), new Vector2(0.5f, 0.5f), 100.0f ,0, SpriteMeshType.FullRect   ); 

                // --- NEXT STEAP
                _image.actual_content = Resource_image_content.sprite;
                _image.stage_getting_resource = Resources_getting_image_stage.finished;

                return weight;

        }





}