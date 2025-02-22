using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;



public class MANAGER__resources_structures : MANAGER__RESOURCES {

        
        public MANAGER__resources_structures(){

                context_structures_modules = new MODULE__context_structures[ ( int ) Resource_context.END ];

                resources_structures__CONTAINER = new CONTAINER__resource_structure();
                container_resources_structures_copies = new CONTAINER__resource_structure_copy();

                container_to_instanciate = GameObject.Find( Paths_containers.path_resources_structures_container );
                
                if( container_to_instanciate == null )
                    { CONTROLLER__errors.Throw( $"container_to_instanciate was not found int the path { Paths_containers.path_resources_structures_container }" ); }


                for( int context_index = 0 ; context_index < ( int ) Resource_context.END ; context_index++ )
                    { context_structures_modules[ context_index ] = new MODULE__context_structures( _manager: this, _context: ( ( Resource_context ) context_index ), _initial_capacity: 1_000, _buffer_cache: 2_000_000 ); }

                // lose the reference -> always in memory
                Get_structure_copy_null();
                container_to_instanciate.SetActive( false );


                return;

        }


        public MODULE__context_structures[] context_structures_modules;


        public CONTAINER__resource_structure resources_structures__CONTAINER;
        public CONTAINER__resource_structure_copy container_resources_structures_copies;
        


        // --- PUBLIC METHODS
                                                        //  personagens          //     lily    //      chave
        public RESOURCE__structure_copy Get_structure_copy( Resource_context _context, string _main_folder, string _path_local, Resource_structure_content _level_pre_allocation ){ return context_structures_modules[ ( int ) _context ].Get_structure_copy( _main_folder, _path_local, _level_pre_allocation ) ; }

        public RESOURCE__structure_copy Get_structure_copy_null(){ return context_structures_modules[ ( int ) Resource_context.Devices ].Get_structure_copy( "default", "structure_null", Resource_structure_content.game_object ) ; } 
        


        // --- NECESSARY DATA

        public GameObject container_to_instanciate;



        // --- UPDATE

        private const int weight_to_stop = 5;
        private int context_frame;

        private System.Diagnostics.Stopwatch relogio = new System.Diagnostics.Stopwatch();
        public override void Update(){

                
                context_frame = ( context_frame + 1 ) % ( int ) Resource_context.END;

                int current_weight = 0;
                
                foreach(  RESOURCE__structure structure in  context_structures_modules[ context_frame ].actives_structures_dictionary.Values ){

                        current_weight += Update_structure( structure );
                        current_weight += Update_all_structures_copys_of_structure( structure, current_weight );

                        if( current_weight >= weight_to_stop )
                            { return; } 
                }

        }



        private int Update_structure( RESOURCE__structure _structure ){


                switch( _structure.stage_getting_resource ){

                    // ** UP
                    case Resources_getting_structure_stage.waiting_to_start: return TOOL__resource_structure_handler_UP.Handle_waiting_to_start( _structure );

                    // ** DOWN
                        // ** talvez depois

                    case Resources_getting_structure_stage.finished: return 0;
                    default: CONTROLLER__errors.Throw( $"Can not handle: { _structure.stage_getting_resource } in the structure { _structure.structure_key }" ); return -1;
              
                }

        }


        private int Update_all_structures_copys_of_structure( RESOURCE__structure structure, int _current_weight ){

                if( structure.actual_content < Resource_structure_content.structure_data )
                    { return _current_weight; }

                
                for( int slot = 0 ; slot < structure.copies.Length ; slot++ ){

                        

                        if( !!!( structure.copies[ slot ].need_to_get_instanciate ) )
                            { continue; }


                        Debug.Log( "actual_need_content: " + structure.copies[ slot ].copy.actual_need_content );
                        

                        RESOURCE__structure_copy copy = structure.copies[ slot ].copy;
                        copy.Flag_need_to_instanciate( false );
                        
                        if( copy == null )
                            { CONTROLLER__errors.Throw( $"The flag to instanciate copy was true, but the structure_copy was null in the slot { slot }" ); }

                        if( copy.actual_need_content != Resource_structure_content.game_object ) 
                            { CONTROLLER__errors.Throw( $"The flag to instanciate copy was true, but the actual need content is { copy.actual_need_content }" ); }

                        if( copy.structure_game_object != null )
                            { CONTROLLER__errors.Throw( $"The flag to instanciate copy was true, but the structure_game_object is already instanciated" ); }

                        
                        relogio.Start();
                            TOOL__resources_structures.Instanciate_copy( structure, copy, container_to_instanciate );
                        relogio.Reset();

                        _current_weight += ( int )( relogio.ElapsedMilliseconds + 1l ); 

                        if( _current_weight >= weight_to_stop )
                            { break; }

                        continue;

                }

                return _current_weight;


        }




        public void Put_in_waiting_container( RESOURCE__structure_copy _copy ){

            
                if( _copy.structure_game_object == null )
                    { CONTROLLER__errors.Throw( $"Tried to deinstanciate { _copy.structure.structure_key } but the structure_game_object is null" ); }

                _copy.structure_game_object.transform.SetParent( container_to_instanciate.transform, false );
                _copy.structure_game_object.SetActive( false );

        }



        
        // --- EXTRA

        public override int Get_bytes_allocated(){

                return 0;     

        }



    


}
