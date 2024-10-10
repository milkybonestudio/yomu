using System;
using System.Collections.Generic;
using UnityEngine;




public class MANAGER__resources_images {


        public MANAGER__resources_images( string path ){

            characters_images = new MODULE__images_streams( _context: Resource_context.characters, _initial_capacity: 1_000, _buffer_cache: 2_000_000 );

            dic = new Dictionary<string,RESOURCE__image>();
            
        }

        
        public MODULE__textures_manager textures_manager;
        public MODULE__loader_texture loader_texture;

        public MODULE__images_streams characters_images;


        private Dictionary<string,RESOURCE__image> dic;

        private RESOURCE__image[] requests = new RESOURCE__image[ 50 ];

        public int pointer;
        public bool request_tem_que_encurtar;

        // --- TASK REQUESTS

        public Task_req task_getting_file;
        public Task_req task_getting_texture; // ** somente se nao tiver o tamanho exato na pull
        public Task_req task_passing_to_texture;



        public RESOURCE__image Verify_exist_request( string _main_folder,  string _path ){



        }
        

        public void Finish_image_single( RESOURCE__image _image ){

            RESOURCE__image_data single_image = _image.single_image;
            
            // --- GARANTE QUE TEM COMPRESS
            if( _image.stage == Resources_request_image_stage.waiting_to_start )
                {  single_image.image_compress = Get_single_file( _image ); _image.stage = Resources_request_image_stage.getting_texture; }


            // ** getting png
            if( _image.stage == Resources_request_image_stage.getting_wait_file )
                { task_getting_file.pode_executar_single_thread = false; } // --- nao vai mais usar 

            
            if( _image.stage == Resources_request_image_stage.getting_texture ) // ** significa que não tem texture
                { 

                    textures_manager.Get_texture( single_image );  

                } 
            

            if( _image.stage == Resources_request_image_stage.passing_to_texture )
                { 
                    // ** esse vai ser o mais complicado porque 

                    // *** AINDA PRECISA EXECUTAR A PARTE NA MAIN PARA LIBERAR A TEXTURE
                    task_passing_to_texture.pode_executar_parte_multithread = false; 

                    task_passing_to_texture = null;
                    _image.single_image.Liberate_texture(); // ** vai pegar outra

                }



        }

        
        public void Finish_image_multiples( RESOURCE__image _image ){

                throw new Exception("a");

        }

        public void Finish_image( RESOURCE__image _image ){


                Verify_image( _image );

                if( _image.single_image != null )
                    { Finish_image_single( _image ); } // --- IMAGEM SIMPLES
                    else
                    { Finish_image_multiples( _image ); } // --- MULTIPLES

        }


        //                                                personagens          //     lily    //      chave
        public RESOURCE__image Get_image_reference( Resource_context _context, string _main_folder,  string _path ){

                



                RESOURCE__image request = null;

                switch( _context ){

                    case Resource_context.characters: request = characters_images.Verify_exist_request(  _main_folder,  _path ); break; 

                }



                request = new RESOURCE__image( _context );

                if( pointer == requests.Length )
                    { Array.Resize( ref requests, ( requests.Length + 20 ) ); } 


                request.request_id = pointer;
                requests[ pointer++ ] = request;

                return request;

        }



        public void Update(){

                if( request_tem_que_encurtar )
                    { Reduze_image(); }
                

                for( int index = 0 ; index < requests.Length; index++ ){

                        RESOURCE__image image = requests[ index ];
                        if( image == null )
                            { return; }
        
                        if( Updata_image( image ) )
                            { return; } // --- TEM QUE ESPERAR ALGO
                        
                }

        }

        private bool Updata_image( RESOURCE__image image ){

                // true => pegou uma acao, bloquear
                // ** se veio aqui tem coisa para fazer

                switch( image.stage ){

                    case Resources_request_image_stage.waiting_to_start: return Handle_waiting_to_start( image );


                            // ** getting png
                            case Resources_request_image_stage.getting_wait_file: return Handle_getting_wait_file( image );

                            // ** se tiver texture disponivel na pool vai para o proximo passo, se nao tiver vai criar na main thread?
                            case Resources_request_image_stage.getting_texture: return Handle_getting_texture( image );

                            // ** se tiver texture disponivel na pool vai para o proximo passo
                            case Resources_request_image_stage.passing_to_texture: return Handle_passing_to_texture( image );


                    case Resources_request_image_stage.finished: return false; // ** tem a tex com os dados já nela

                }

                return false;

        }


        private void Verify_image( RESOURCE__image image ){


                if( image.level_pre_allocation_image == Level_pre_allocation_image.not_give )
                    { CONTROLLER__errors.Throw( $"In the image request { image.name } was not give the level of pre allocation" ); }
                
                if( image.multiples_images == null && image.single_image == null )
                    { CONTROLLER__errors.Throw( $"In the image request { image.name } was not given the image data" ); }

                if( image.multiples_images != null && image.single_image != null )
                    { CONTROLLER__errors.Throw( $"In the image request { image.name } was given single and multiples images" ); }


        }



        private bool Handle_waiting_to_start( RESOURCE__image _image ){

                Verify_image( _image );

                // ** se so precisar dos dados é isso ai
                if( _image.level_pre_allocation_image == Level_pre_allocation_image.nothing )
                    { _image.stage = Resources_request_image_stage.finished; return false; }

                if( _image.single_image != null )
                    {
                        // --- SINGLE IMAGE

                        task_getting_file = CONTROLLER__tasks.Pegar_instancia().Get_task_request( "task_getting_file" );
                        task_getting_file.fn_multithread = ( Task_req req )=> { TASK_REQ.Add_single_data( req, Get_single_file( _image ) ); };
                        return true;
                        
                    }

                if( _image.multiples_images != null )
                    {
                        // --- MULTIPLES IMAGES

                        task_getting_file = CONTROLLER__tasks.Pegar_instancia().Get_task_request( "task_getting_file" );
                        task_getting_file.fn_multithread = Get_multiples_file_task( _image );
                        return true;
                        
                    }

                

                
                _image.stage = Resources_request_image_stage.getting_wait_file;
                return true;
            

        }


    
        private Action<Task_req> Get_single_file_task( RESOURCE__image image ){

                return ( Task_req req )=> { TASK_REQ.Add_single_data( req, Get_single_file( image ) ); };

        }

        private byte[] Get_single_file( RESOURCE__image _image ){

                byte[] image = null;

                switch( _image.image_context ){

                    case Resource_context.characters: return  characters_images.Get_data( _image ); 
                    default: throw new Exception( $"Can not handle the type { _image.image_context}" ); 
                    
                }

                return image;
            
        }



        private Action<Task_req> Get_multiples_file_task( RESOURCE__image image ){

                return ( Task_req req )=> {

                    switch( image.image_context ){

                        case Resource_context.characters: TASK_REQ.Add_single_data( req, ( object ) characters_images.Get_multiple_data( image ) ); break;
                        default: throw new Exception( $"Can not handle the type { image.image_context}" ); 
                        
                    }

                };

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
                    }


                // ** se so precisar dos dados é isso ai
                if( image.level_pre_allocation_image == Level_pre_allocation_image.compress_data )
                    { image.stage = Resources_request_image_stage.finished; return false; }
                

                image.stage = Resources_request_image_stage.getting_texture;
                return false; // ** sem tem texture livre pode ser na mesma trhead, mas se precisar criar precisa esperar
            
        }


        private bool Handle_getting_texture( RESOURCE__image image ){ 

            image.stage = Resources_request_image_stage.passing_to_texture;

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

            
            return false; 
            
        }


        private bool Handle_passing_to_texture( RESOURCE__image image ){ 

            //mark
            // ** 
            // ** a task do passing texture tem que de algum jeito falar que uma texture esta protna para ser liberada. 



            return false; 

        }


        private void Reduze_image(){

                int pointer_atual = 0;
                for( int index = 0 ; index < requests.Length ; index++ ){

                    if( requests[ index ] == null )
                        { continue; }
                    
                    requests[ pointer_atual ] = requests[ index ];
                    requests[ pointer_atual ].request_id = pointer_atual;
                    pointer_atual++;
                    continue;
                    
                }


        }



        public void Remove_request( RESOURCE__image _request ){

                // ** quando fizer o sistema com a textures temq ue liberar elas aqui

                switch( _request.stage ){

                    case Resources_request_image_stage.waiting_to_start: break;
                    case Resources_request_image_stage.getting_texture: task_getting_texture = null; break;
                    case Resources_request_image_stage.getting_wait_file: task_getting_file = null; break;
                    case Resources_request_image_stage.passing_to_texture: task_passing_to_texture = null; break;

                }



                requests[ _request.request_id ] = null;
                request_tem_que_encurtar = true;
                return;

        }


        public int Get_bytes_allocated(){

                int accumulator = 0;

                // --- IMAGES COMPRESS
                for( int image_index = 0 ; image_index < requests.Length ; image_index++){


                        RESOURCE__image image = requests[ image_index ];
                        if( image == null )
                            { return accumulator; }
                        
                        if( image.multiples_images != null )
                            {
                                for( int multiple_iamge_index = 0 ; multiple_iamge_index < image.multiples_images.Length ; multiple_iamge_index++ ){

                                        if( image.multiples_images[ multiple_iamge_index ].image_compress != null )
                                            { accumulator += image.multiples_images[ multiple_iamge_index ].image_compress.Length; } // --- have image
                                        continue;

                                }

                                continue;
                            }

                        // -- SINGLE

                        if( image.single_image.image_compress == null )
                            { continue; }

                        accumulator += image.single_image.image_compress.Length;
                        continue;
                    
                }


                // --- TEXTURES

                accumulator += textures_manager.Get_bytes_allocated();

                return accumulator;
            

        }



    


}
