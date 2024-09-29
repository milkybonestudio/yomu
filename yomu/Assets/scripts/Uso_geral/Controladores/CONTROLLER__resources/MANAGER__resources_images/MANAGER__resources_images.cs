using System;


public class MANAGER__resources_images {


        public MANAGER__resources_images(){}

        public MODULE__textures_manager textures_manager;
        public MODULE__loader_texture loader_texture;

        private RESOURCE__image[] requests = new RESOURCE__image[ 50 ];
        public int pointer;
        public bool request_tem_que_encurtar;

        // --- TASK REQUESTS

        public Task_req task_getting_file;
        public Task_req task_getting_texture; // ** somente se nao tiver o tamanho exato na pull
        public Task_req task_passing_to_texture;
        


        public RESOURCE__image Get_image(){

                RESOURCE__image request = new RESOURCE__image();

                if( pointer == requests.Length )
                    { Array.Resize( ref requests, ( requests.Length + 20 ) ); } 


                request.request_id = pointer;
                requests[ pointer++ ] = request;

                return request;


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



        private bool Handle_waiting_to_start( RESOURCE__image image ){

                // ** o jogo fica resposnavel por ter qualquer tipo de header encessario
            
                // ** se so precisar dos dados é isso ai
                if( image.level_pre_allocation_image == Level_pre_allocation_image.nothing )
                    { image.stage = Resources_request_image_stage.finished; return false; }

                if( image.multiples_images == null )
                    {
                        // --- somente 1 imagem 
                        task_getting_file = new Task_req( "task_getting_file" );
                        

                    }
                    else
                    {
                        // --- multiplas imagens 

                    }

                image.stage = Resources_request_image_stage.getting_wait_file;
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
                    precisou_criar = textures_manager.Get_texture( _indentificador: image.name, image.single_image );
                    
                }
                else
                {
                    for( int texture_index = 0 ; texture_index < image.multiples_images.Length ; texture_index++ )
                        { precisou_criar |= textures_manager.Get_texture( _indentificador: $"{ image.name }_{ texture_index }", image.multiples_images[ texture_index ] ); }

                }

            
            return false; 
            
        }


        private bool Handle_passing_to_texture( RESOURCE__image image ){ return false; }


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

    


}
