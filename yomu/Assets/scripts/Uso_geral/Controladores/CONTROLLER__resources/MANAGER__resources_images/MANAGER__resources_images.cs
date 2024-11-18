using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class MANAGER__resources_images {

        
        public MANAGER__resources_images(){

                contexts = contexts = System_enums.resource_context;// ( Resource_context[] ) System.Enum.GetValues( typeof( Resource_context ) );

                container_images = new Container_RESOURCE__images();
                container_image_refs = new Container_RESOURCE__image_refs();
                context_images_modules = new MODULE__context_images[ contexts.Length ];

                for( int context_index = 0 ; context_index < contexts.Length ; context_index++ )
                    { context_images_modules[ context_index ] = new MODULE__context_images( _manager: this, _context: contexts[ context_index ], _initial_capacity: 1_000, _buffer_cache: 2_000_000 ); }

                return;

        }

        
        public MANAGER__textures_resources textures_manager;

        public Container_RESOURCE__images container_images;
        public Container_RESOURCE__image_refs container_image_refs;
    
        public MODULE__context_images[] context_images_modules;



        private Resource_context[] contexts;


        public int pointer;
        public bool request_tem_que_encurtar;


        // --- TASK REQUESTS

        public Task_req task_getting_compress_low_quality_file;
        public Task_req task_getting_compress_file;
            // public Task_req task_getting_texture;  // ** por hora assumir que task_getting_texture, e task_applying_texture nao sao tasks e váo ser feitas aqui
        public Task_req task_passing_to_texture;
            // public Task_req task_applying_texture;

            // ** reajust

            public Task_req task_getting_compress_file_REAJUST;
            public Task_req task_passing_to_texture_REAJUST;



        // --- PUBLIC METHODS

        // ** single
                                                            //  personagens          //     lily    //      chave
        public RESOURCE__image_ref Get_image_reference( Resource_context _context, string _main_folder,  string _path, Resource_image_content _level_pre_allocation ){ return context_images_modules[ ( int ) _context ].Get_image_ref( _main_folder, _path, _level_pre_allocation ) ; }
        public RESOURCE__image_ref Get_image_reference_multiples( Resource_context _context, string _main_folder,  string _path, Resource_image_content _level_pre_allocation ){ return context_images_modules[ ( int ) _context ].Get_image_ref( _main_folder, _path, _level_pre_allocation ) ; }



        // --- UPDATE

        private const int weight_to_stop = 5;
        private int context_frame;
        public void Update(){

                //** fazer para dar preferencia pelo tipo depois a ordem

                context_frame = ( context_frame + 1 ) % contexts.Length;

                int current_weight = 0;
                foreach(  RESOURCE__image image in  context_images_modules[ context_frame ].actives_images_dictionary.Values ){

                        current_weight += Updata_image( image );
        
                        if( current_weight >= weight_to_stop )
                            { return; } 
                }

                
        }


        private int Updata_image( RESOURCE__image _image ){


                TOOL__resource_image.Verify_image( _image );

                if( !!!( TOOL__resource_image.Need_to_update( _image ) ) )
                    { return 0; }


                switch( _image.stage_getting_resource ){

                    // --- GET RESOURCE
                    case Resources_getting_image_stage.waiting_to_start: return TOOL__resources_images_handler_UP.Handle_waiting_to_start( this, _image );
                        case Resources_getting_image_stage.getting_compress_low_quality_file: return TOOL__resources_images_handler_UP.Handle_getting_compress_low_quality_file( this,  _image );
                            case Resources_getting_image_stage.waiting_to_get_compress_file: return TOOL__resources_images_handler_UP.Handle_waiting_to_get_compress_file( this,  _image );
                                case Resources_getting_image_stage.getting_compress_file: return TOOL__resources_images_handler_UP.Handle_getting_compress_file( this,  _image );
                                    case Resources_getting_image_stage.waiting_to_get_texture: return TOOL__resources_images_handler_UP.Handle_waiting_to_get_texture( this,  _image );
                                        case Resources_getting_image_stage.getting_texture: return TOOL__resources_images_handler_UP.Handle_getting_texture( this,  _image );
                                            case Resources_getting_image_stage.waiting_to_pass_data_to_texture: return TOOL__resources_images_handler_UP.Handle_waiting_to_pass_data_to_texture( this,  _image );
                                                case Resources_getting_image_stage.passing_data_to_texture: return TOOL__resources_images_handler_UP.Handle_passing_data_to_texture( this,  _image );
                                                    case Resources_getting_image_stage.waiting_to_apply_texture: return TOOL__resources_images_handler_UP.Handle_waiting_to_apply_texture( this,  _image );
                                                        case Resources_getting_image_stage.applying_texture: return TOOL__resources_images_handler_UP.Handle_applying_texture( this,  _image );
                                                            case Resources_getting_image_stage.waiting_to_create_sprite: return TOOL__resources_images_handler_UP.Handle_waiting_to_create_sprite( this,  _image );
                                                                case Resources_getting_image_stage.finished: return 0; // ** tem a tex com os dados já nela

                                                
                // --- DOWN RESOURCE
                    
                    case Resources_getting_image_stage.waiting_to_destroy_current_resource: return TOOL__resource_images_handler_DOWN.Handle_waiting_to_destroy_current_resource( this, _image );
                    

                // --- REAJUSTING
                    case Resources_getting_image_stage.waiting_to_get_compress_file_REAJUST: return TOOL__resources_images_handler_REAJUST.Handle_waiting_to_get_compress_file_REAJUST( this, _image );
                        case Resources_getting_image_stage.getting_compress_file_REAJUST: return TOOL__resources_images_handler_REAJUST.Handle_getting_compress_file_REAJUST( this, _image );
                            case Resources_getting_image_stage.waiting_to_pass_data_to_texture_REAJUST: return TOOL__resources_images_handler_REAJUST.Handle_waiting_to_pass_data_to_texture_REAJUST( this, _image );
                                case Resources_getting_image_stage.passing_data_to_texture_REAJUST: return TOOL__resources_images_handler_REAJUST.Handle_passing_data_to_texture_REAJUST( this, _image );
                                    case Resources_getting_image_stage.waiting_to_apply_texture_REAJUST: return TOOL__resources_images_handler_REAJUST.Handle_waiting_to_apply_texture_REAJUST( this, _image );

                                        
                    default: CONTROLLER__errors.Throw( $"Nao foi achado { _image.stage_getting_resource }" ); break;

                }
       
                return 0;

        }


        
        public void Stop_task( RESOURCE__image _image ){

                // ** acho que nao faz mais sentido
            
                switch( _image.stage_getting_resource ){

                    
                    // ** REAJUST
                    case Resources_getting_image_stage.getting_compress_file_REAJUST: TASK_REQ.Cancel_task( ref task_getting_compress_file_REAJUST ); return;
                    case Resources_getting_image_stage.passing_data_to_texture_REAJUST: TASK_REQ.Cancel_task( ref task_passing_to_texture_REAJUST ); return;

                    // ** NORMAL
                    case Resources_getting_image_stage.getting_compress_file: TASK_REQ.Cancel_task( ref task_getting_compress_file ); return;
                    case Resources_getting_image_stage.getting_compress_low_quality_file: TASK_REQ.Cancel_task( ref task_getting_compress_low_quality_file ); return;
                    case Resources_getting_image_stage.passing_data_to_texture: TASK_REQ.Cancel_task( ref task_passing_to_texture ); return;


                    default: CONTROLLER__errors.Throw( $"Came on Stop_task for the image { _image.name }, but can not handle { _image.stage_getting_resource }" ); return;
                                    
                }

        }


        // --- EXTRA

        public int Get_bytes_allocated(){

                int accumulator = 0;

                // --- IMAGES COMPRESS
                for( int image_index = 0 ; image_index < context_images_modules.Length ; image_index++)
                    { accumulator += context_images_modules[ image_index ].Get_bytes(); }

                // --- TEXTURES
                accumulator += textures_manager.Get_bytes_allocated();

                return accumulator;
            
        }

}
