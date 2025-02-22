using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class MANAGER__resources_logics : MANAGER__RESOURCES {

        
        public MANAGER__resources_logics(){

                container_logics = new CONTAINER__RESOURCE__logics();
                container_logic_refs = new CONTAINER__RESOURCE__logics_refs();
                context_logics_modules = new MODULE__context_logics[ ( int ) Resource_context.END ];

                for( int context_index = ( ( int ) Resource_context.not_given + 1 )  ; context_index < ( int ) Resource_context.END ; context_index++ )
                    { context_logics_modules[ context_index ] = new MODULE__context_logics( _manager: this, _context: ( Resource_context ) context_index, _initial_capacity: 1_000, _buffer_cache: 1_000 ); }

                return;

        }

        
        public CONTAINER__RESOURCE__logics container_logics;
        public CONTAINER__RESOURCE__logics_refs container_logic_refs;
    
        public MODULE__context_logics[] context_logics_modules;


        public int pointer;
        public bool request_tem_que_encurtar;


        // --- TASK REQUESTS

        // --- PUBLIC METHODS

        public RESOURCE__logic_ref Get_logic_reference( Resource_context _context, string _class_name,  string _method_name, Resource_logic_content _level_pre_allocation ){ return context_logics_modules[ ( int ) _context ].Get_logic_ref( _class_name, _method_name, _level_pre_allocation ) ; }
    


        // --- UPDATE

        private const int weight_to_stop = 5;
        public override void Update(){

                //** fazer para dar preferencia pelo tipo depois a ordem

                int current_weight = 0;

                for( int context_slot = ( int )( Resource_context.not_given + 1 ) ; context_slot < ( int ) Resource_context.END ; context_slot++ ){

                        
                        foreach( RESOURCE__logic logic in context_logics_modules[ context_slot ].actives_logics_dictionary.Values ){

                                current_weight += Updata_logic( logic );
                
                                if( current_weight >= weight_to_stop )
                                    { return; } 

                        }

                    
                }

                
        }


        private int Updata_logic( RESOURCE__logic _image ){


                TOOL__resource_logic.Verify_logic( _image );


                if( !!!( TOOL__resource_logic.Need_to_update( _image ) ) )
                    { return 0; }


                switch( _image.stage_getting_resource ){

                    // --- GET RESOURCE
                    case Resources_getting_logic_stage.waiting_to_start: return TOOL__resources_logics_handler_UP.Handle_waiting_to_start( this, _image );
                            
                                                
                    // --- DOWN RESOURCE
                    // --- REAJUSTING
                        

                case Resources_getting_logic_stage.finished: return 0;
                                        
                    default: CONTROLLER__errors.Throw( $"Nao foi achado { _image.stage_getting_resource }" ); break;

                }
       
                return 0;

        }



        // --- EXTRA

        public override int Get_bytes_allocated(){

                int accumulator = 0;


                return accumulator;
            
        }

}
