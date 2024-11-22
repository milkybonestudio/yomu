using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class MANAGER__resources_audios {

        /*

            _audio: nao vale muito a pena pensar nisso agora. 

            por hora todos os audios vao ser usados como stream. stremusa muita cpu e quando tiver mais sfx vai ser bem ruim.
            o processo pode ser optimizado como é feito com as imagens mas vai ser um saco de fazer. boa sorte eu do futuro. 
            a outra alternativa é usar descompres on load e usar loadAssync. mas por hora não tem o porque. descomprimir audio gera em torno de 2.5ms/ segundo de audio. 
            Audios grandes seriam um problema para fazer na main thread sem ser por streaming.

            LoadAsync como tudo nessa merda de unity não faz o minimo que deveria. 
            fazer Resources.LoadAsync vai continuar pegando o resource somente quando precisar e vai ser na main thread. 

            as opcoes: 
                -> stream para qualquer audio ( mesmo na build )
                -> sistema proprio ( vai levar muito tempo )



        */

        
        public MANAGER__resources_audios(){

                contexts = contexts = System_enums.resource_context;// ( Resource_context[] ) System.Enum.GetValues( typeof( Resource_context ) );

                container_audios = new Container_RESOURCE__audios();
                container_audio_refs = new Container_RESOURCE__audios_refs();
                context_audios_modules = new MODULE__context_audios[ contexts.Length ];

                for( int context_index = 0 ; context_index < contexts.Length ; context_index++ )
                    { context_audios_modules[ context_index ] = new MODULE__context_audios( _manager: this, _context: contexts[ context_index ], _initial_capacity: 1_000, _buffer_cache: 2_000_000 ); }

                return;

        }

        
        public Container_RESOURCE__audios container_audios;
        public Container_RESOURCE__audios_refs container_audio_refs;
    
        public MODULE__context_audios[] context_audios_modules;



        private Resource_context[] contexts;


        public int pointer;
        public bool request_tem_que_encurtar;


        // --- TASK REQUESTS

        // --- PUBLIC METHODS

        // ** single
                                                            //  personagens          //     lily    //      chave
        public RESOURCE__audio_ref Get_audio_reference( Resource_context _context, string _main_folder,  string _path, Resource_audio_content _level_pre_allocation ){ return context_audios_modules[ ( int ) _context ].Get_audio_ref( _main_folder, _path, _level_pre_allocation ) ; }
    


        // --- UPDATE

        private const int weight_to_stop = 5;
        private int context_frame;
        public void Update(){

                //** fazer para dar preferencia pelo tipo depois a ordem

                context_frame = ( context_frame + 1 ) % contexts.Length;

                int current_weight = 0;
                foreach(  RESOURCE__audio image in  context_audios_modules[ context_frame ].actives_audios_dictionary.Values ){

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
                    
                    // ** um mp3 compresso tem +- 1/5 do damanho, mas a qualidade é meio merda
                    // ** andes de pensar em fazer um low_quality precisa ver se comprensa 
                    // ** tempo_recurso = ( tempo para pegar disco ) + ( tempo descompressao ) 
                    // ** se o tempo para descomprimir foi muito talvez não valha a pena

                // --- REAJUSTING
                    

                case Resources_getting_audio_stage.finished: return 0;
                                        
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
