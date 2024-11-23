using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;



public class MANAGER__resources_complex_structures {

        
        public MANAGER__resources_complex_structures(){

                contexts = System_enums.resource_context;  // ( Resource_context[] ) System.Enum.GetValues( typeof( Resource_context ) );
                context_complex_structures_modules = new MODULE__context_complex_structures[ contexts.Length ];

                container_resources_complex_structures = new CONTAINER__resource_complex_structure();
                container_resources_complex_structures_copies = new CONTAINER__resource_complex_structure_copy();

                container_to_instanciate = GameObject.Find( Paths_system.path_resources_complex_structures_container );
                CONTROLLER__errors.Verify( ( container_to_instanciate == null ), $"container_to_instanciate was not found int the path { Paths_system.path_resources_complex_structures_container }" ); 

                for( int context_index = 0 ; context_index < contexts.Length ; context_index++ )
                    { context_complex_structures_modules[ context_index ] = new MODULE__context_complex_structures( _manager: this, _context: contexts[ context_index ], _initial_capacity: 1_000, _buffer_cache: 2_000_000 ); }

                return;

        }
        
        public MODULE__context_complex_structures[] context_complex_structures_modules;

        private Resource_context[] contexts;

        public CONTAINER__resource_complex_structure container_resources_complex_structures;
        public CONTAINER__resource_complex_structure_copy container_resources_complex_structures_copies;
        


        // --- TASK REQUESTS
        public Task_req task;


        // --- PUBLIC METHODS
                                                        //  personagens          //     lily    //      chave
        public RESOURCE__complex_structure_copy Get_complex_structure_copy( Resource_context _context, string _main_folder, string _path_local, Resource_complex_structure_content _level_pre_allocation ){ return context_complex_structures_modules[ ( int ) _context ].Get_structure_copy( _main_folder, _path_local, _level_pre_allocation ) ; }
        
        public GameObject container_to_instanciate;



        // --- UPDATE

        private const int weight_to_stop = 5;
        private int context_frame;

        private System.Diagnostics.Stopwatch relogio = new System.Diagnostics.Stopwatch();
        public void Update(){

                //Console.Log( "a" );

                context_frame = ( context_frame + 1 ) % contexts.Length;

                int current_weight = 0;
                
                foreach(  RESOURCE__complex_structure structure in  context_complex_structures_modules[ context_frame ].actives_complex_structures_dictionary.Values ){

                        current_weight += Update_structure( structure );
                        current_weight += Update_structure_copy( structure, current_weight );


             
                        if( current_weight >= weight_to_stop )
                            { return; } 
                }

        }



        private int Update_structure( RESOURCE__complex_structure _structure ){


                switch( _structure.stage_getting_resource ){

                    // ** UP
                    case Resources_getting_complex_structure_stage.waiting_to_start: return Handle_waiting_to_start( _structure );

                    // ** DOWN
                    // ** talvez depois

                    case Resources_getting_complex_structure_stage.finished: return 0;
                    default: CONTROLLER__errors.Throw( $"Can not handle: { _structure.stage_getting_resource } in the structure { _structure.complex_structure_key }" ); return -1;
              
                }

        }


        private int Update_structure_copy( RESOURCE__complex_structure structure, int _current_weight ){

                if( structure.actual_content < Resource_complex_structure_content.structure_data )
                    { return _current_weight; }

                int number = 0;

                for( int slot = 0 ; slot < structure.copies.Length ; slot++ ){


                        if( !!!( structure.copies[ slot ].need_to_get_instanciate ) )
                            { continue; }

                        number++;

                        structure.copies[ slot ].need_to_get_instanciate = false;
                        
                        RESOURCE__complex_structure_copy copy = structure.copies[ slot ].copy;
                        
                        CONTROLLER__errors.Verify( ( copy == null ), $"The flag to instanciate copy was true, but the structure_copy was null in the slot { slot }" );
                        CONTROLLER__errors.Verify( ( copy.actual_need_content != Resource_complex_structure_content.game_object ) , $"The flag to instanciate copy was true, but the actual need content is { copy.actual_need_content }" );
                        CONTROLLER__errors.Verify( ( copy.structure_game_object != null ), $"The flag to instanciate copy was true, but the structure_game_object is already instanciated" );

                        
                        relogio.Start();
                            TOOL__resources_complex_structures.Instanciate_copy( structure, copy, container_to_instanciate );
                        relogio.Reset();

                        _current_weight += ( int )( relogio.ElapsedMilliseconds + 1l ); 

                        if( _current_weight >= weight_to_stop )
                            { break; }

                        continue;

                }

                int a = 0;
                
                relogio.Reset(); 
                return _current_weight;


        }





        private int Handle_waiting_to_start( RESOURCE__complex_structure _structure ){

                // ** mudar para o relogio talvez? 

                int weight = 0;

                if( _structure.content_going_to == Resource_complex_structure_content.nothing )
                    { 
                        _structure.prefab = null;
                        _structure.actual_content = Resource_complex_structure_content.nothing;
                        _structure.stage_getting_resource = Resources_getting_complex_structure_stage.finished; 
                        return weight; 
                    }
                

                // ** MAXIMUN
                if( _structure.content_going_to == Resource_complex_structure_content.structure_data )
                    {
                        
                        // --- PEGOU O PREFAB 
                        _structure.prefab = Resources.Load<GameObject>( _structure.resource_path );

                        CONTROLLER__errors.Verify( ( _structure.prefab == null ), $"Not found prefab <Color=lightBlue>{ _structure.resource_path }</Color>" );
                        _structure.actual_content = Resource_complex_structure_content.structure_data;
                        weight = 2;

                        _structure.stage_getting_resource = Resources_getting_complex_structure_stage.finished;
                        return weight;

                    }
                
                CONTROLLER__errors.Throw( $"Can not handle { _structure.content_going_to }" ); return -1;

        }





        public void Put_in_waiting_container( RESOURCE__complex_structure_copy _copy ){

            Console.Log( "Veio Put_in_waiting_container()" );

                
                CONTROLLER__errors.Verify( ( _copy.structure_game_object == null ), $"Tried to deinstanciate { _copy.structure.complex_structure_key } but the structure_game_object is null" );

                _copy.structure_game_object.transform.SetParent( container_to_instanciate.transform, false );
                _copy.structure_game_object.SetActive( false );

        }



        
        // --- EXTRA

        public int Get_bytes_allocated(){

                return 0;     

        }



    


}
