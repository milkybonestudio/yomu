using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class MANAGER__resources_audios {

        
        public MANAGER__resources_audios(){

                contexts = contexts = System_enums.resource_context;// ( Resource_context[] ) System.Enum.GetValues( typeof( Resource_context ) );

                container_images = new Container_RESOURCE__audios();
                container_image_refs = new Container_RESOURCE__audios_refs();
                context_images_modules = new MODULE__context_audios[ contexts.Length ];

                for( int context_index = 0 ; context_index < contexts.Length ; context_index++ )
                    { context_images_modules[ context_index ] = new MODULE__context_audios( _manager: this, _context: contexts[ context_index ], _initial_capacity: 1_000, _buffer_cache: 2_000_000 ); }

                return;

        }

        
        public Container_RESOURCE__audios container_images;
        public Container_RESOURCE__audios_refs container_image_refs;
    
        public MODULE__context_audios[] context_images_modules;



        private Resource_context[] contexts;


        public int pointer;
        public bool request_tem_que_encurtar;


        // --- TASK REQUESTS

        public Task_req task_getting_compress_low_quality_file;
        public Task_req task_getting_compress_file;


        // --- PUBLIC METHODS

        // ** single
                                                            //  personagens          //     lily    //      chave
        public RESOURCE__audio_ref Get_audio_reference( Resource_context _context, string _main_folder,  string _path, Resource_audio_content _level_pre_allocation ){ return context_images_modules[ ( int ) _context ].Get_audio_ref( _main_folder, _path, _level_pre_allocation ) ; }
    



        // --- UPDATE

        private const int weight_to_stop = 5;
        private int context_frame;
        public void Update(){

                //** fazer para dar preferencia pelo tipo depois a ordem

                context_frame = ( context_frame + 1 ) % contexts.Length;

                int current_weight = 0;
                foreach(  RESOURCE__audio image in  context_images_modules[ context_frame ].actives_images_dictionary.Values ){

                        current_weight += Updata_audio( image );
        
                        if( current_weight >= weight_to_stop )
                            { return; } 
                }

                
        }


        private int Updata_audio( RESOURCE__audio _image ){


                TOOL__resource_audio.Verify_audio( _image );

                if( !!!( TOOL__resource_audio.Need_to_update( _image ) ) )
                    { return 0; }


                switch( _image.stage_getting_resource ){

                    // --- GET RESOURCE
                    case Resources_getting_audio_stage.waiting_to_start: return TOOL__resources_audios_handler_UP.Handle_waiting_to_start( this, _image );
                                                
                // --- DOWN RESOURCE
                    
                    case Resources_getting_audio_stage.waiting_to_destroy_current_resource: return TOOL__resource_audios_handler_DOWN.Handle_waiting_to_destroy_current_resource( this, _image );
                    

                // ** um mp3 compresso tem +- 1/5 do damanho, mas a qualidade é meio merda
                // ** andes de pensar em fazer um low_quality precisa ver se comprensa 
                // ** tempo_recurso = ( tempo para pegar disco ) + ( tempo descompressao ) 
                // ** se o tempo para descomprimir foi muito talvez não valha a pena

                // --- REAJUSTING
                    
                                        
                    default: CONTROLLER__errors.Throw( $"Nao foi achado { _image.stage_getting_resource }" ); break;

                }
       
                return 0;

        }



        // --- EXTRA

        public int Get_bytes_allocated(){

                int accumulator = 0;


                return accumulator;
            
        }

}
