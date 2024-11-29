using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;



public class MANAGER__resources_images_sequences {

        //** os dicionarios tem que ficar dentro de cada modulo

        public MANAGER__resources_images_sequences(){

                contexts = contexts = System_enums.resource_context;// ( Resource_context[] ) System.Enum.GetValues( typeof( Resource_context ) );

                context_images_modules = new MODULE__context_images_sequences[ contexts.Length ];

                for( int context_index = 0 ; context_index < contexts.Length ; context_index++ )
                    { context_images_modules[ context_index ] = new MODULE__context_images_sequences( _manager: this, _context: contexts[ context_index ], _initial_capacity: 1_000, _buffer_cache: 2_000_000 ); }

                return;

        }

        
        public MANAGER__textures_resources textures_manager;
    
        public MODULE__context_images_sequences[] context_images_modules;

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


        private int Updata_image( RESOURCE__image _image ){

                // ** VERIFY IF HAVE SOMEWHERE TO GO
                if( ( _image.content_going_to == _image.actual_content ) && ( ( _image.stage_getting_resource & Resources_getting_image_stage.all_reajust_stages ) == 0 ) )
                    { 
                        if( _image.stage_getting_resource != Resources_getting_image_stage.finished )
                            { CONTROLLER__errors.Throw( "what" ); }
                        return 0; 
                    }

                switch( _image.stage_getting_resource ){

                    // --- GET RESOURCE
                    case Resources_getting_image_stage.waiting_to_start: return TOOL__resources_images_sequences_handler_UP.Handle_waiting_to_start( this, _image );
                        case Resources_getting_image_stage.getting_compress_low_quality_file: return TOOL__resources_images_sequences_handler_UP.Handle_getting_compress_low_quality_file( this,  _image );
                            case Resources_getting_image_stage.waiting_to_get_compress_file: return TOOL__resources_images_sequences_handler_UP.Handle_waiting_to_get_compress_file( this,  _image );
                                case Resources_getting_image_stage.getting_compress_file: return TOOL__resources_images_sequences_handler_UP.Handle_getting_compress_file( this,  _image );
                                    case Resources_getting_image_stage.waiting_to_get_texture: return TOOL__resources_images_sequences_handler_UP.Handle_waiting_to_get_texture( this,  _image );
                                        case Resources_getting_image_stage.getting_texture: return TOOL__resources_images_sequences_handler_UP.Handle_getting_texture( this,  _image );
                                            case Resources_getting_image_stage.waiting_to_pass_data_to_texture: return TOOL__resources_images_sequences_handler_UP.Handle_waiting_to_pass_data_to_texture( this,  _image );
                                                case Resources_getting_image_stage.passing_data_to_texture: return TOOL__resources_images_sequences_handler_UP.Handle_passing_data_to_texture( this,  _image );
                                                    case Resources_getting_image_stage.waiting_to_apply_texture: return TOOL__resources_images_sequences_handler_UP.Handle_waiting_to_apply_texture( this,  _image );
                                                        case Resources_getting_image_stage.applying_texture: return TOOL__resources_images_sequences_handler_UP.Handle_applying_texture( this,  _image );
                                                            case Resources_getting_image_stage.waiting_to_create_sprite: return TOOL__resources_images_sequences_handler_UP.Handle_waiting_to_create_sprite( this,  _image );
                                                                case Resources_getting_image_stage.finished: return 0; // ** tem a tex com os dados já nela

                                                
                // --- DOWN RESOURCE
                    
                    case Resources_getting_image_stage.waiting_to_destroy_current_resource: return TOOL__resource_images_sequences_handler_DOWN.Handle_waiting_to_destroy_current_resource( this, _image );

                // --- REAJUSTING
                    case Resources_getting_image_stage.getting_compress_file_REAJUST: return TOOL__resources_images_sequences_handler_REAJUST.Handle_getting_compress_file_REAJUST( this, _image );
                        case Resources_getting_image_stage.waiting_to_get_compress_file_REAJUST: return TOOL__resources_images_sequences_handler_REAJUST.Handle_waiting_to_get_compress_file_REAJUST( this, _image );
                            case Resources_getting_image_stage.passing_data_to_texture_REAJUST: return TOOL__resources_images_sequences_handler_REAJUST.Handle_passing_data_to_texture_REAJUST( this, _image );
                                case Resources_getting_image_stage.waiting_to_pass_data_to_texture_REAJUST: return TOOL__resources_images_sequences_handler_REAJUST.Handle_waiting_to_pass_data_to_texture_REAJUST( this, _image );
                                    case Resources_getting_image_stage.waiting_to_apply_texture_REAJUST: return TOOL__resources_images_sequences_handler_REAJUST.Handle_waiting_to_apply_texture_REAJUST( this, _image );

                                        
                    default: CONTROLLER__errors.Throw( $"Nao foi achado { _image.stage_getting_resource }" ); break;

                }
       
                return 0;

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
                for( int image_index = 0 ; image_index < context_images_modules.Length ; image_index++)
                    { accumulator += context_images_modules[ image_index ].Get_bytes(); }

                // --- TEXTURES
                accumulator += textures_manager.Get_bytes_allocated();

                return accumulator;
            
        }

}
