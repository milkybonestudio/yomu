using System;
using System.Collections.Generic;
using UnityEngine;




public class MANAGER__resources_images {

        //** os dicionarios tem que ficar dentro de cada modulo


        public MANAGER__resources_images( string path ){

                Resource_context[] resource_contexts = ( Resource_context[] ) System.Enum.GetValues( typeof( Resource_context ) );

                context_images_modules = new MODULE__context_images[ resource_contexts.Length ];

                for( int context_index = 0 ; context_index < resource_contexts.Length ; context_index++ )
                    { context_images_modules[ context_index ] = new MODULE__context_images( _context: resource_contexts[ context_index ], _initial_capacity: 1_000, _buffer_cache: 2_000_000 ); }

                return;

        }

        
        public MANAGER__textures_resources textures_manager;
    
        public MODULE__context_images[] context_images_modules;

        private Resource_context[] contexts;


        public int pointer;
        public bool request_tem_que_encurtar;


        // --- TASK REQUESTS
        public Task_req task_getting_file;
        public Task_req task_getting_texture; // ** somente se nao tiver o tamanho exato na pull
        public Task_req task_passing_to_texture;



        // --- PUBLIC METHODS


                                                            //  personagens          //     lily    //      chave
        public RESOURCE__image_ref Get_image_reference( Resource_context _context, string _main_folder,  string _path, Resource_image_state _level_pre_allocation ){ return context_images_modules[ ( int ) _context ].Get_image_ref( _main_folder, _path, _level_pre_allocation ) ; }



        // --- UPDATE

        private int context_frame;
        public void Update(){

                context_frame = ( context_frame + 1 ) % contexts.Length;

                if( Verify_tasks() )
                    { return; }

                foreach(  RESOURCE__image image in  context_images_modules[ context_frame ].images_dictionary.Values ){
        
                        if( Updata_image( image ) )
                            { return; } // --- TEM QUE ESPERAR ALGO
                }

        }


        private bool Verify_tasks(){

                if( task_getting_file != null )
                    { return !!!( task_getting_file.finalizado ); }

                if( task_getting_texture != null )
                    { return !!!( task_getting_texture.finalizado ); }

                if( task_passing_to_texture != null )
                    { return !!!( task_passing_to_texture.finalizado ); }

                return false;
                
        }

        private bool Updata_image( RESOURCE__image _image ){

                // true => pegou uma acao, bloquear
                // ** se veio aqui tem coisa para fazer

                if( _image.final_resource_state == _image.current_state )
                    { _image.stage_getting_resource = Resources_request_image_stage.finished; return false; }

                switch( _image.stage_getting_resource ){

                    case Resources_request_image_stage.waiting_to_start: return Handle_waiting_to_start( _image );

                            // ** getting png
                            case Resources_request_image_stage.getting_wait_file: return Handle_getting_wait_file( _image );

                            // ** se tiver texture disponivel na pool vai para o proximo passo, se nao tiver vai criar na main thread?
                            case Resources_request_image_stage.getting_texture: return Handle_getting_texture( _image );

                            // ** se tiver texture disponivel na pool vai para o proximo passo
                            case Resources_request_image_stage.passing_to_texture: return Handle_passing_to_texture( _image );


                    case Resources_request_image_stage.finished: return false; // ** tem a tex com os dados já nela

                }

                return false;

        }




        private bool Handle_waiting_to_start( RESOURCE__image _image ){

                TOOL__resource_image.Verify( _image );

                // ** se so precisar dos dados é isso ai
                if( _image.final_resource_state == Resource_image_state.nothing )
                    { _image.stage_getting_resource = Resources_request_image_stage.finished; return false; }
                

                task_getting_file = CONTROLLER__tasks.Pegar_instancia().Get_task_request( "task_getting_file" );

                if( _image.single_image != null )
                    { task_getting_file.fn_multithread = ( Task_req req )=> { TASK_REQ.Add_single_data( req, _image.module_images.Get_single_data( _image ) ); }; } // --- SINGLE IMAGE
                    else
                    { task_getting_file.fn_multithread = ( Task_req req )=> { TASK_REQ.Add_single_data( req, _image.module_images.Get_multiple_data( _image ) ); }; } // --- MULTIPLES IMAGES


                _image.stage_getting_resource = Resources_request_image_stage.getting_wait_file;
                return true;
            

        }



        private bool Handle_getting_wait_file( RESOURCE__image image ){ 


                if( !!!( task_getting_file.finalizado ) )
                    { return true; }

                if( image.multiples_images == null )
                    {
                        // --- somente 1 imagem 
                        image.single_image.image_compress = ( byte[] ) task_getting_file.dados[ 0 ];
                        task_getting_file = null;
                        
                    }
                    else
                    {
                        // multiplas
                        throw new Exception("tem que fazer");
                    }

                //mark 
                // ** se usar somente png pode pegar height e length aqui

                image.current_state = Resource_image_state.compress_data;

                // ** se so precisar dos dados é isso ai
                if( image.final_resource_state == Resource_image_state.compress_data )
                    { image.stage_getting_resource = Resources_request_image_stage.finished; }
                    else
                    { image.stage_getting_resource = Resources_request_image_stage.getting_texture; }
                
                return false; // ** sem tem texture livre pode ser na mesma trhead, mas se precisar criar precisa esperar
            
        }


        private bool Handle_getting_texture( RESOURCE__image image ){ 



            bool precisou_criar = false;

            if( image.multiples_images == null )
                {
                    precisou_criar = textures_manager.Get_texture( image.single_image );
                    
                }
                else
                {
                    for( int texture_index = 0 ; texture_index < image.multiples_images.Length ; texture_index++ )
                        { precisou_criar |= textures_manager.Get_texture( image.multiples_images[ texture_index ] ); }

                }

            image.stage_getting_resource = Resources_request_image_stage.passing_to_texture;

            

            // --- CREATE TASK PASSING 

            task_passing_to_texture = CONTROLLER__tasks.Pegar_instancia().Get_task_request( "task_passing_to_texture" );

            // ** parte multithread => passar 
            // ** parte main threead => indicar que já terminou e pode liberar text
            if( image.single_image != null )
                { 
                    // --- SINGLE IMAGE
                    task_passing_to_texture.fn_multithread = ( Task_req req )=> { TOOL__loader_texture.Transfer_data( image.single_image );  }; 
                    // lock now
                    textures_manager.Lock_image_passing_data( image.single_image );
                    // will unlockr
                    task_passing_to_texture.fn_single_thread = ( Task_req _req ) => { textures_manager.Unlock_image_passing_data( image.single_image ); };

                } 
                else
                { 
                    // --- MULTIPLES IMAGES
                    task_passing_to_texture.fn_multithread = ( Task_req req )=> { foreach( RESOURCE__image_data data in image.multiples_images ){ TOOL__loader_texture.Transfer_data( data ); }   }; 
                    // lock now
                    foreach( RESOURCE__image_data data in image.multiples_images ){ textures_manager.Lock_image_passing_data( data ); }
                    // will unlock
                    task_passing_to_texture.fn_single_thread = ( Task_req req )=> { foreach( RESOURCE__image_data data in image.multiples_images ){ textures_manager.Unlock_image_passing_data( data ); }   }; 
                } 



            
            return precisou_criar; 
            
        }


        private bool Handle_passing_to_texture( RESOURCE__image image ){ 


                if( !!!( task_passing_to_texture.finalizado ) )
                    { return true; }

                // ** imagem foi passada para a texture
                // ** talvez criar a scprite aqui? 

                image.current_state = Resource_image_state.texture;
                image.stage_getting_resource = Resources_request_image_stage.finished;
                image.final_resource_state == Resource_image_state.texture;


                if( image.single_image != null )
                    { 
                        // --- SINGLE IMAGE

                        image.single_image.sprite = Sprite.Create( image.single_image.texture_allocated.texture, new Rect( 0f, 0f, image.single_image.width, image.single_image.height ), new Vector2(0.5f, 0.5f), 100.0f ,0, SpriteMeshType.FullRect   );
                        
                    } 
                    else
                    { 
                        // --- MULTIPLES IMAGES
                        foreach( RESOURCE__image_data data in image.multiples_images ){ data.sprite = Sprite.Create( data.texture_allocated.texture, new Rect( 0f, 0f, data.width, data.height ), new Vector2(0.5f, 0.5f), 100.0f ,0, SpriteMeshType.FullRect   ); }
                    }





            return false; 

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
