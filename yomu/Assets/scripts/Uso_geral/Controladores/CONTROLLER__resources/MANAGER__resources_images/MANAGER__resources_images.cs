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
        public Task_req task_getting_compress_low_quality_file;
        public Task_req task_getting_compress_file;
        public Task_req task_getting_texture; // ** somente se nao tiver o tamanho exato na pull
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

                if( task_getting_texture != null )
                    { return !!!( task_getting_texture.finalizado ); }

                if( task_passing_to_texture != null )
                    { return !!!( task_passing_to_texture.finalizado ); }

                return false;
                
        }

        private int Updata_image( RESOURCE__image _image ){

                // true => pegou uma acao, bloquear
                // ** se veio aqui tem coisa para fazer




                switch( _image.stage_getting_resource ){
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

                }

                return 0;

        }



        private int Handle_waiting_to_start( RESOURCE__image _image ){


                TOOL__resource_image.Verify( _image );

                #if UNITY_EDITOR

                    //** no editor nao tem low_quality

                    if( _image.final_resource_state == Resource_image_content.nothing )
                        { _image.stage_getting_resource = Resources_getting_image_stage.finished;  } 
                        else 
                        { _image.stage_getting_resource = Resources_getting_image_stage.waiting_to_get_compress_file; }
                    
                    return 0;

                #endif


                if ( task_getting_compress_low_quality_file != null )
                    { return 0; }


                // --- GET WEBP

                task_getting_compress_low_quality_file = CONTROLLER__tasks.Pegar_instancia().Get_task_request( "task_getting_compress_low_quality_file" );
                task_getting_compress_low_quality_file.prioridade = 1000;

                int weight = 1;

                if( _image.single_image != null )
                    { task_getting_compress_low_quality_file.fn_multithread = ( Task_req req ) => { TASK_REQ.Add_single_data( req, _image.module_images.Get_single_data( _image.main_folder, ( _image.path_locator + "_low_quality" )  ) ); }; }  // --- SINGLE IMAGE
                    else
                    { task_getting_compress_low_quality_file.fn_multithread = ( Task_req req )=> { TASK_REQ.Add_single_data( req, _image.module_images.Get_multiple_data( _image.main_folder, ( _image.path_locator + "_low_quality" ), _image.number_images ) ); }; } // --- MULTIPLES IMAGES

                _image.stage_getting_resource = Resources_getting_image_stage.getting_compress_low_quality_file;

                return weight;

        }


        private int Handle_getting_compress_low_quality_file( RESOURCE__image _image ){


                CONTROLLER__errors.Verify( ( task_getting_compress_low_quality_file == null ), $"the image { _image.name } was as getting_compress_low_quality_file but the task_req is null" );

                if( !!!(task_getting_compress_low_quality_file.finalizado) )
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
                if( _image.final_resource_state == Resource_image_content.nothing )
                    { _image.stage_getting_resource = Resources_getting_image_stage.finished; return 0; } // ** sempre tem o webp
                
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

                //mark 
                // ** se usar somente png pode pegar height e length aqui

                _image.current_content = Resource_image_content.compress_data;

                // ** se so precisar dos dados é isso ai
                if( _image.final_resource_state == Resource_image_content.compress_data )
                    { 
                        Console.Log("terminou de pegar compress data");
                        
                        _image.stage_getting_resource = Resources_getting_image_stage.finished; 
                        return 0; }
                    
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

                _image.stage_getting_resource = Resources_getting_image_stage.waiting_to_pass_data_to_texture;


                return weight;




                // // ** se precisar criar uma nova texture grande a imagem vai para getting texture, se o sistema conseguir colocar essa imagem em uma texture já exisstente ela vai direto para waiting to pass e locka a texture aqui 

                // if( task_getting_texture != null )
                //     { return 0; }

                // bool precisa_criar = false;

                // if( _image.multiples_images == null )
                //     { precisa_criar = textures_manager.Get_texture( _image.single_image ); } // --- SINGLE
                //     else
                //     { for( int texture_index = 0 ; texture_index < _image.multiples_images.Length ; texture_index++ ){ precisa_criar |= textures_manager.Get_texture( _image.multiples_images[ texture_index ] ); }} // --- MULTIPLES

                // // ** isso indica que tem uma texture quye precisa ser feita
                // if( !!!( precisa_criar ) )
                //     { 
                //         _image.stage_getting_resource = Resources_getting_image_stage.waiting_to_apply_texture;  
                //         return 0; 
                //     }

                // // --- PRECISA CRIAR 


                // task_getting_texture = CONTROLLER__tasks.Pegar_instancia().Get_task_request( "task_getting_texture" ); 
                // task_getting_texture.fn_single_thread = ( Task_req req ) => { textures_manager.Create_textures(); };

                // _image.stage_getting_resource = Resources_getting_image_stage.getting_texture;

                // return 1;
                

        }



        private int Handle_getting_texture( RESOURCE__image image ){ 

            //mark 
            // ** por hora nao vai usar

            // if( !!!( task_getting_texture.finalizado ) )
            //     { return 0; }

            // task_getting_texture = null;

            // image.stage_getting_resource = Resources_getting_image_stage.waiting_to_pass_data_to_texture;
                        
            throw new Exception( "nao era para usar" );
            
        }

        private int Handle_waiting_to_pass_data_to_texture( RESOURCE__image _image ){

                Console.Log( "Handle_waiting_to_pass_data_to_texture" );

                if( task_passing_to_texture != null )
                    { return 0; }
            

                task_passing_to_texture = CONTROLLER__tasks.Pegar_instancia().Get_task_request( "task_passing_to_texture" );

                if( _image.single_image != null )
                    { task_passing_to_texture.fn_multithread = ( Task_req req )=> { TOOL__loader_texture.Transfer_data_PNG( _image.single_image.image_compress, _image.single_image.texture_exclusiva_native_array );  }; }  // --- SINGLE IMAGE
                    else
                    { task_passing_to_texture.fn_multithread = ( Task_req req )=> { foreach( RESOURCE__image_data data in _image.multiples_images ){ TOOL__loader_texture.Transfer_data_PNG( data.image_compress, data.texture_exclusiva_native_array );   }; }; } // --- MULTIPLES _IMAGES

                _image.stage_getting_resource = Resources_getting_image_stage.passing_data_to_texture;

                // if( _image.single_image != null )
                //     { 
                //         // --- SINGLE IMAGE
                //         task_passing_to_texture.fn_multithread = ( Task_req req )=> { TOOL__loader_texture.Transfer_data_PNG( _image.single_image.image_compress, _image.single_image.texture_exclusiva_native_array );  }; 
                //         // lock now
                //         textures_manager.Lock_image_passing_data( _image.single_image );
                //         // will unlockr
                //         task_passing_to_texture.fn_single_thread = ( Task_req _req ) => { textures_manager.Unlock_image_passing_data( _image.single_image ); };

                //     } 
                //     else
                //     { 
                //         // --- MULTIPLES _IMAGES
                //         task_passing_to_texture.fn_multithread = ( Task_req req )=> { foreach( RESOURCE__image_data data in _image.multiples_images ){ TOOL__loader_texture.Transfer_data( data, Type_image.png ); }   }; 
                //         // lock now
                //         foreach( RESOURCE__image_data data in _image.multiples_images ){ textures_manager.Lock_image_passing_data( data ); }
                //         // will unlock
                //         task_passing_to_texture.fn_single_thread = ( Task_req req )=> { foreach( RESOURCE__image_data data in _image.multiples_images ){ textures_manager.Unlock_image_passing_data( data ); }   }; 
                //     } 


                return 0;

        }

    
        private int Handle_passing_data_to_texture( RESOURCE__image _image ){ 

                Console.Log( "Handle_passing_data_to_texture" );

                if( !!!( task_passing_to_texture.finalizado ) )
                    { return 0; }

                // ** imagem foi passada para a texture

                task_passing_to_texture = null;
                _image.current_content = Resource_image_content.texture;
                _image.stage_getting_resource = Resources_getting_image_stage.waiting_to_apply_texture;

                return 0; 

        }



        private int Handle_waiting_to_apply_texture( RESOURCE__image _image ){

                // tem que sinalizar que alguma texture já pode ser dado o apply. cada texture grande tem que ter o controle de quantas imagens precisam dar o ok para tudo dar certo

                //mark
                // ** por hora vai ter texture individual

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

                // ** por hora nao tem applying, como vao ser pequenas acredito que vai ser mais rapido
                _image.stage_getting_resource = Resources_getting_image_stage.waiting_to_create_sprite;
                return weight;


                // if( task_applying_texture != null )
                //     { return 0; }


                // bool can_apply = false;
                // RESOURCE__image_data data_ref = null;

                // if( _image.single_image != null )
                //     { data_ref = _image.single_image; }
                //     else
                //     { data_ref = _image.multiples_images[ 0 ]; }



                // if( !!!( textures_manager.Verify_if_can_apply( data_ref ) ) )
                //     { return 0; }


                // //mark
                // // eu nao sei o quao demorado vai ser para dar um apply em uma texture de 8k
                // // a maior parte do tempo para uma texture pequena é a do sync com a gpu
                // // ver depois e tomar uma decisao

                // task_applying_texture = CONTROLLER__tasks.Pegar_instancia().Get_task_request( "task_applying_texture" );

                // // ** vai garantir que mesmo que alguma outra imagem quiser passar dados ela não pode para garantir o estado
                // textures_manager.Prepare_apply( data_ref );
                // task_applying_texture.fn_single_thread = ( Task_req _req )=>{ data_ref.texture_allocated.texture.Apply(); textures_manager.Unlock_texture_apply( data_ref ); };
                // _image.stage_getting_resource = Resources_getting_image_stage.applying_texture;

                
                
                return 10;

        }


        private int Handle_applying_texture( RESOURCE__image _image ){

                if( !!!( task_applying_texture.finalizado ) )
                    { return 0; }


                task_applying_texture = null;
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


                // tem que sinalizar que alguma texture já pode ser dado o apply. cada texture grande tem que ter o controle de quantas imagens precisam dar o ok para tudo dar certo
                _image.stage_getting_resource = Resources_getting_image_stage.finished;

                return weight;

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
