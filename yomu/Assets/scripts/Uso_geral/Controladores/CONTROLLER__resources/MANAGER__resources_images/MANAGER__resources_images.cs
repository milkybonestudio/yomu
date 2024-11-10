using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;




public class MANAGER__resources_images {

        //** os dicionarios tem que ficar dentro de cada modulo


        public MANAGER__resources_images(){


                contexts = contexts = System_enums.resource_context;// ( Resource_context[] ) System.Enum.GetValues( typeof( Resource_context ) );

                context_images_modules = new MODULE__context_images[ contexts.Length ];

                for( int context_index = 0 ; context_index < contexts.Length ; context_index++ )
                    { context_images_modules[ context_index ] = new MODULE__context_images( _manager: this, _context: contexts[ context_index ], _initial_capacity: 1_000, _buffer_cache: 2_000_000 ); }

                return;

        }

        
        public MANAGER__textures_resources textures_manager;
    
        public MODULE__context_images[] context_images_modules;

        private Resource_context[] contexts;


        public int pointer;
        public bool request_tem_que_encurtar;


        // --- TASK REQUESTS

        //mark
        // ** por hora assumir que task_getting_texture, e task_applying_texture nao sao tasks e váo ser feitas aqui
        // ** o sistema tem que aceitar mudacas, entáo depois quando precisar implementar náo vai ser muito complicado

        public Task_req task_getting_compress_low_quality_file;
        public Task_req task_getting_compress_file;

            // public Task_req task_getting_texture; // ** somente se nao tiver o tamanho exato na pull

        public Task_req task_passing_to_texture;

            public Task_req task_applying_texture;



        // --- PUBLIC METHODS

        // ** single
                                                            //  personagens          //     lily    //      chave
        public RESOURCE__image_ref Get_image_reference( Resource_context _context, string _main_folder,  string _path, Resource_image_content _level_pre_allocation ){ return context_images_modules[ ( int ) _context ].Get_image_ref( _main_folder, _path, false, _level_pre_allocation ) ; }
        public RESOURCE__image_ref Get_image_reference_multiples( Resource_context _context, string _main_folder,  string _path, Resource_image_content _level_pre_allocation ){ return context_images_modules[ ( int ) _context ].Get_image_ref( _main_folder, _path, true, _level_pre_allocation ) ; }



        // --- UPDATE

        private const int weight_to_stop = 5;
        private int context_frame;
        public void Update(){


                context_frame = ( context_frame + 1 ) % contexts.Length;

                int current_weight = 0;
                foreach(  RESOURCE__image image in  context_images_modules[ context_frame ].actives_images_dictionary.Values ){

                        current_weight += Updata_image( image );
        
                        if( current_weight >= weight_to_stop )
                            { return; } 
                }

        }


        private bool Verify_tasks(){

                if( task_getting_compress_file != null )
                    { return !!!( task_getting_compress_file.finalizado ); }

                if( task_passing_to_texture != null )
                    { return !!!( task_passing_to_texture.finalizado ); }

                return false;
                
        }

        private int Updata_image( RESOURCE__image _image ){

                // true => pegou uma acao, bloquear
                // ** se veio aqui tem coisa para fazer

                // ** VERIFY IF HAVE SOMEWHERE TO GO
                if( _image.content_going_to == _image.actual_content )
                    { CONTROLLER__errors.Verify( (_image.stage_getting_resource != Resources_getting_image_stage.finished), "what" ); return 0; }


                // ** o ponto final sempre vai ser nothing, compress_data, sprite

                
                switch( _image.stage_getting_resource ){

                    // --- GET RESOURCE
                    case Resources_getting_image_stage.waiting_to_start: return Handle_waiting_to_start( _image );
                        case Resources_getting_image_stage.getting_compress_low_quality_file: return Handle_getting_compress_low_quality_file( _image );
                            case Resources_getting_image_stage.waiting_to_get_compress_file: return Handle_waiting_to_get_compress_file( _image );
                                case Resources_getting_image_stage.getting_compress_file: return Handle_getting_compress_file( _image );
                                    case Resources_getting_image_stage.waiting_to_get_texture: return Handle_waiting_to_get_texture( _image );
                                        case Resources_getting_image_stage.getting_texture: return Handle_getting_texture( _image );
                                            case Resources_getting_image_stage.waiting_to_pass_data_to_texture: return Handle_waiting_to_pass_data_to_texture( _image );
                                                case Resources_getting_image_stage.passing_data_to_texture: return Handle_passing_data_to_texture( _image );
                                                    case Resources_getting_image_stage.waiting_to_apply_texture: return Handle_waiting_to_apply_texture( _image );
                                                        case Resources_getting_image_stage.applying_texture: return Handle_applying_texture( _image );
                                                            case Resources_getting_image_stage.waiting_to_create_sprite: return Handle_waiting_to_create_sprite( _image );
                                                                case Resources_getting_image_stage.finished: return 0; // ** tem a tex com os dados já nela

                                                
                // --- DOWN RESOURCE
                    
                    case Resources_getting_image_stage.waiting_to_destroy_current_resource: return Handle_waiting_to_destroy_current_resource( _image );
                    
                    
                    default: CONTROLLER__errors.Throw( $"Nao foi achado { _image.stage_getting_resource }" ); break;

                }
       
                return 0;

        }

        private int Handle_waiting_to_destroy_current_resource( RESOURCE__image _image ){

                int weight = 0;

                if( _image.content_going_to <= Resource_image_content.compress_data )
                    { weight += Destroy_resource_texture( _image ); }

                if( _image.content_going_to <= Resource_image_content.compress_low_quality_data )
                    { weight += Destroy_compress_data( _image ); }
                
                if( _image.content_going_to == Resource_image_content.nothing )
                    { weight += Destroy_compress_low_quality_data( _image ); }

                return weight;

        }



        private int Destroy_compress_low_quality_data( RESOURCE__image _image ){


                if( _image.single_image != null )
                    {
                        _image.single_image.image_low_quality_compress = null;
                    }
                    else
                    {

                    }

                _image.actual_content = Resource_image_content.nothing;
                return 0;

        }

        

        private int Destroy_compress_data( RESOURCE__image _image ){

                _image.actual_content = Resource_image_content.compress_low_quality_data;

                if( _image.single_image != null )
                    {
                        _image.single_image.image_compress = null;
                        if( _image.single_image.image_low_quality_compress == null )
                            { _image.actual_content = Resource_image_content.nothing; }

                    }
                    else
                    {

                    }

                return 0;

        }

        private int Destroy_resource_texture( RESOURCE__image _image ){

                int weight = 0;
                if( _image.single_image != null )
                    {
                        weight += 1;
                        Console.Log( "Veio destruir texture" );
                        GameObject.Destroy( _image.single_image.texture_exclusiva );
                        _image.single_image.texture_exclusiva_native_array.Dispose();
                    }
                    else
                    {

                    }
                        
                _image.actual_content = Resource_image_content.compress_data;
                return weight;


        }



        private int Handle_waiting_to_start( RESOURCE__image _image ){


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


                if ( task_getting_compress_low_quality_file != null )
                    { return 0; } // fica esperando?


                // --- GET WEBP
                
                _image.stage_getting_resource = Resources_getting_image_stage.getting_compress_low_quality_file;

                task_getting_compress_low_quality_file = CONTROLLER__tasks.Pegar_instancia().Get_task_request( "task_getting_compress_low_quality_file" );
                task_getting_compress_low_quality_file.prioridade = 1000;

                int weight = 1;

                if( _image.single_image != null )
                    { task_getting_compress_low_quality_file.fn_multithread = ( Task_req req ) => { TASK_REQ.Add_single_data( req, _image.module_images.Get_single_data( _image.main_folder, ( _image.path_locator + "_low_quality" )  ) ); }; }  // --- SINGLE IMAGE
                    else
                    { task_getting_compress_low_quality_file.fn_multithread = ( Task_req req ) => { TASK_REQ.Add_single_data( req, _image.module_images.Get_multiple_data( _image.main_folder, ( _image.path_locator + "_low_quality" ), _image.number_images ) ); }; } // --- MULTIPLES IMAGES


                return weight;

        }


        public byte[] Get_low_quality_bytes_single( RESOURCE__image _image ){

            return _image.module_images.Get_single_data( _image.main_folder, ( _image.path_locator + "_low_quality" ) );

        }

        public byte[][] Get_low_quality_byte_arrays_multiples( RESOURCE__image _image ){

            return _image.module_images.Get_multiple_data( _image.main_folder, ( _image.path_locator + "_low_quality" ), _image.number_images );

        }

        


        private int Handle_getting_compress_low_quality_file( RESOURCE__image _image ){


                CONTROLLER__errors.Verify( ( task_getting_compress_low_quality_file == null ), $"the image { _image.name } was as getting_compress_low_quality_file but the task_req is null" );

                if( !!!( task_getting_compress_low_quality_file.finalizado ) )
                    { return 0; }

                // --- JA PEGOU A IMAGEM

                if( _image.single_image != null )
                    { 
                        // --- SINGLE IMAGE
                        _image.single_image.image_low_quality_compress = ( byte[] ) task_getting_compress_low_quality_file.dados[ 0 ];
                    } 
                    else
                    { 
                        // --- MULTIPLES IMAGES
                        byte[][] webps = ( byte[][] ) task_getting_compress_low_quality_file.dados[ 0 ];
                        for( int webp_index = 0 ; webp_index < _image.multiples_images.Length ; webp_index++ )
                            { _image.multiples_images[ webp_index ].image_low_quality_compress = webps[ webp_index ]; }

                    } 

                task_getting_compress_low_quality_file = null;


                // ** se so precisar dos dados é isso ai
                if( _image.content_going_to == Resource_image_content.nothing )
                    { _image.stage_getting_resource = Resources_getting_image_stage.finished; return 0; } // ** sempre tem o webp?
                
                _image.stage_getting_resource = Resources_getting_image_stage.waiting_to_get_compress_file;

                return 0;

        }

        private int Handle_waiting_to_get_compress_file( RESOURCE__image _image ){

                int weight = 0;

                if( task_getting_compress_file != null )
                    { return weight; } // ** algum outro arquivo esta pegando 
                
                Console.Log( "veio Handle_waiting_to_get_compress_file" );
                
                task_getting_compress_file = CONTROLLER__tasks.Pegar_instancia().Get_task_request( "task_getting_compress_file" );

                if( _image.single_image != null )
                    { task_getting_compress_file.fn_multithread = ( Task_req req )=> { TASK_REQ.Add_single_data( req, _image.module_images.Get_single_data( _image.main_folder, _image.path_locator ) ); };  } // --- SINGLE IMAGE
                    else
                    { task_getting_compress_file.fn_multithread = ( Task_req req )=> { TASK_REQ.Add_single_data( req, _image.module_images.Get_multiple_data( _image.main_folder, _image.path_locator, _image.number_images ) ); }; } // --- MULTIPLES IMAGES

                
                _image.stage_getting_resource = Resources_getting_image_stage.getting_compress_file;

                return weight;

        }


        private int Handle_getting_compress_file( RESOURCE__image _image ){ 

                Console.Log( "Handle_getting_compress_file" );

                CONTROLLER__errors.Verify( ( task_getting_compress_file == null ), $"the image { _image.name } was as getting_compress_file but the task_req is null" );

                if( !!!( task_getting_compress_file.finalizado ) )
                    { return 0; }

                Console.Log( "Pegou o arquivo" );

                if( _image.content_going_to < Resource_image_content.compress_data )
                    { CONTROLLER__errors.Throw( $"Get the png for the image { _image.name }, but the content_going_to is { _image.content_going_to }" ); }

                // ** passa o PNG para a imagem
                if( _image.multiples_images == null )
                    {
                        // --- somente 1 imagem 
                        _image.single_image.image_compress = ( byte[] ) task_getting_compress_file.dados[ 0 ];
                        Console.Log( "Png length: " + _image.single_image.image_compress.Length.ToString("#,0").Replace( ".", "_" ) );
                        Dimensions dimensions = PNG.Get_dimensions( _image.single_image.image_compress );
                        _image.width = dimensions.width;
                        _image.height = dimensions.height;
                         
                    }
                    else
                    {

                        byte[][] pngs = ( byte[][] ) task_getting_compress_file.dados[ 0 ];
                        Dimensions dimensions = PNG.Get_dimensions( pngs[ 0 ] );
                        _image.width = dimensions.width;
                        _image.height = dimensions.height;

                        for( int png_index = 0 ; png_index < _image.multiples_images.Length ; png_index++ )
                            { _image.multiples_images[ png_index ].image_compress = pngs[ png_index ]; }
                        
                    }

                task_getting_compress_file = null;

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

        

        private int Handle_waiting_to_get_texture( RESOURCE__image _image ){


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



        private int Handle_getting_texture( RESOURCE__image image ){ 
                        
            throw new Exception( "nao era para usar" );
            
        }

        private int Handle_waiting_to_pass_data_to_texture( RESOURCE__image _image ){

                Console.Log( "Handle_waiting_to_pass_data_to_texture" );

                if( task_passing_to_texture != null )
                    { return 0; }
            

                task_passing_to_texture = CONTROLLER__tasks.Pegar_instancia().Get_task_request( "task_passing_to_texture" );

                if( _image.single_image != null )
                    { task_passing_to_texture.fn_multithread = ( Task_req req ) => { TOOL__loader_texture.Transfer_data_PNG( _image.single_image.image_compress, _image.single_image.texture_exclusiva_native_array );  }; }  // --- SINGLE IMAGE
                    else
                    { task_passing_to_texture.fn_multithread = ( Task_req req ) => { foreach( RESOURCE__image_data data in _image.multiples_images ){ TOOL__loader_texture.Transfer_data_PNG( data.image_compress, data.texture_exclusiva_native_array );   }; }; } // --- MULTIPLES _IMAGES

                _image.stage_getting_resource = Resources_getting_image_stage.passing_data_to_texture;

 
                   return 0;

        }

    
        private int Handle_passing_data_to_texture( RESOURCE__image _image ){ 

                Console.Log( "Handle_passing_data_to_texture" );

                if( !!!( task_passing_to_texture.finalizado ) )
                    { return 0; }

                // ** imagem foi passada para a texture

                task_passing_to_texture = null;
                _image.actual_content = Resource_image_content.texture_with_pixels_applied;
                _image.stage_getting_resource = Resources_getting_image_stage.waiting_to_apply_texture;

                return 0; 

        }



        private int Handle_waiting_to_apply_texture( RESOURCE__image _image ){

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


        private int Handle_applying_texture( RESOURCE__image _image ){

                if( !!!( task_applying_texture.finalizado ) )
                    { return 0; }


                task_applying_texture = null;
                _image.actual_content = Resource_image_content.texture_with_pixels_applied;
                _image.stage_getting_resource = Resources_getting_image_stage.waiting_to_create_sprite;

                // tem que sinalizar que alguma texture já pode ser dado o apply. cada texture grande tem que ter o controle de quantas imagens precisam dar o ok para tudo dar certo
                return 0;

        }

        private int Handle_waiting_to_create_sprite( RESOURCE__image _image ){

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


        


        public void Stop_task( RESOURCE__image _image ){

            
            switch( _image.stage_getting_resource ){

                case Resources_getting_image_stage.getting_compress_file: TASK_REQ.Cancel_task( ref task_getting_compress_file ); return;
                case Resources_getting_image_stage.getting_compress_low_quality_file: TASK_REQ.Cancel_task( ref task_getting_compress_low_quality_file ); return;
                case Resources_getting_image_stage.passing_data_to_texture: TASK_REQ.Cancel_task( ref task_passing_to_texture ); return;

                case Resources_getting_image_stage.applying_texture: CONTROLLER__errors.Throw( $"Came on Stop_task for the image { _image.name }, but can not handle { _image.stage_getting_resource }" ); return;
                case Resources_getting_image_stage.getting_texture: CONTROLLER__errors.Throw( $"Came on Stop_task for the image { _image.name }, but can not handle { _image.stage_getting_resource }" ); return;
                                
            }

        }




        // --- EXTRA



        public int Get_bytes_allocated(){

                int accumulator = 0;

                // --- IMAGES COMPRESS
                for( int image_index = 0 ; image_index < context_images_modules.Length ; image_index++){

                        accumulator += context_images_modules[ image_index ].Get_bytes();

                        // RESOURCE__image image = requests[ image_index ];
                        // if( image == null )
                        //     { return accumulator; }
                        
                        // if( image.multiples_images != null )
                        //     {
                        //         for( int multiple_iamge_index = 0 ; multiple_iamge_index < image.multiples_images.Length ; multiple_iamge_index++ ){

                        //                 if( image.multiples_images[ multiple_iamge_index ].image_compress != null )
                        //                     { accumulator += image.multiples_images[ multiple_iamge_index ].image_compress.Length; } // --- have image
                        //                 continue;

                        //         }

                        //         continue;
                        //     }

                        // // -- SINGLE

                        // if( image.single_image.image_compress == null )
                        //     { continue; }

                        // accumulator += image.single_image.image_compress.Length;
                        // continue;
                    
                }


                // --- TEXTURES

                accumulator += textures_manager.Get_bytes_allocated();

                return accumulator;
            

        }



    


}
