using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;



public class MANAGER__resources_structures {

        //mark
        // ** por hora quando uma copia ou a structure ems i não precisa mais do gameobject ele só vai ser destruido.
        // ** isso pode impactar se muitos forem destruidos ao mesmo tempo. Pode ter algum sistema para juntar varios e distribuir o tempo

        //mark
        // ** ainda nao esta usando containers


        public MANAGER__resources_structures(){

                contexts = System_enums.resource_context;  // ( Resource_context[] ) System.Enum.GetValues( typeof( Resource_context ) );
                context_structures_modules = new MODULE__context_structures[ contexts.Length ];

                container_to_instanciate = GameObject.Find( Paths_system.path_resources_structures_container );
                CONTROLLER__errors.Verify( ( container_to_instanciate == null ), $"container_to_instanciate was not found int the path { Paths_system.path_resources_structures_container }" ); 

                for( int context_index = 0 ; context_index < contexts.Length ; context_index++ )
                    { context_structures_modules[ context_index ] = new MODULE__context_structures( _manager: this, _context: contexts[ context_index ], _initial_capacity: 1_000, _buffer_cache: 2_000_000 ); }

                return;

        }
        
        public MODULE__context_structures[] context_structures_modules;

        private Resource_context[] contexts;


        // --- TASK REQUESTS
        public Task_req task;


        // --- PUBLIC METHODS
                                                        //  personagens          //     lily    //      chave
        public RESOURCE__structure_copy Get_structure_copy( Resource_context _context, string _main_folder, Structure_locators _locators, Resource_structure_content _level_pre_allocation ){ return context_structures_modules[ ( int ) _context ].Get_structure_copy( _main_folder, _locators, _level_pre_allocation ) ; }
        
        public GameObject container_to_instanciate;



        // --- UPDATE

        private const int weight_to_stop = 5;
        private int context_frame;

        private System.Diagnostics.Stopwatch relogio = new System.Diagnostics.Stopwatch();
        public void Update(){

                //Console.Log( "a" );

                context_frame = ( context_frame + 1 ) % contexts.Length;

                int current_weight = 0;
                
                foreach(  RESOURCE__structure structure in  context_structures_modules[ context_frame ].actives_structures_dictionary.Values ){

                        current_weight += Update_structure( structure );
                        current_weight += Update_structure_copy( structure, current_weight );


             
                        if( current_weight >= weight_to_stop )
                            { return; } 
                }

        }



        private int Update_structure( RESOURCE__structure _structure ){


                if( _structure.content_going_to == _structure.actual_content )
                    {  _structure.stage_getting_resource = Resources_getting_structure_stage.finished; }

                switch( _structure.stage_getting_resource ){

                    // ** UP
                    case Resources_getting_structure_stage.waiting_to_start: return Handle_waiting_to_start( _structure );

                    // ** DOWN
                    // ** talvez depois


                    case Resources_getting_structure_stage.finished: return 0;
              
                }

                return 0;

        }



        private int Update_structure_copy( RESOURCE__structure structure, int _current_weight ){

                if( structure.actual_content < Resource_structure_content.structure_data )
                    { return _current_weight; }

                int number = 0;

                for( int slot = 0 ; slot < structure.copies.Length ; slot++ ){


                        if( !!!( structure.copies[ slot ].need_to_get_instanciate ) )
                            { continue; }

                        number++;

                        structure.copies[ slot ].need_to_get_instanciate = false;
                        
                        RESOURCE__structure_copy copy = structure.copies[ slot ].copy;
                        
                        CONTROLLER__errors.Verify( ( copy == null ), $"The flag to instanciate copy was true, but the structure_copy was null in the slot { slot }" );
                        CONTROLLER__errors.Verify( ( copy.actual_need_content != Resource_structure_content.game_object ) , $"The flag to instanciate copy was true, but the actual need content is { copy.actual_need_content }" );
                        CONTROLLER__errors.Verify( ( copy.structure_game_object != null ), $"The flag to instanciate copy was true, but the structure_game_object is already instanciated" );

                        _current_weight += Instanciate( structure, copy );

                        if( _current_weight >= weight_to_stop )
                            { break; }

                        continue;

                }

                
                relogio.Reset(); 
                return _current_weight;


        }





        private int Handle_waiting_to_start( RESOURCE__structure _structure ){

                // ** mudar para o relogio talvez? 

                int weight = 0;

                if( _structure.content_going_to == Resource_structure_content.nothing )
                    { 
                        _structure.prefab = null;
                        _structure.actual_content = Resource_structure_content.nothing;
                        _structure.stage_getting_resource = Resources_getting_structure_stage.finished; 
                        return weight; 
                    }
                

                // ** MAXIMUN
                if( _structure.content_going_to == Resource_structure_content.structure_data )
                    {
                        
                        // --- PEGOU O PREFAB 
                        _structure.prefab = Resources.Load<GameObject>( _structure.resource_path );

                        CONTROLLER__errors.Verify( ( _structure.prefab == null ), $"Not found prefab <Color=lightBlue>{ _structure.resource_path }</Color>" );
                        _structure.actual_content = Resource_structure_content.structure_data;
                        weight = 2;

                        _structure.stage_getting_resource = Resources_getting_structure_stage.finished;
                        return weight;

                    }
                
                CONTROLLER__errors.Throw( $"Can not handle { _structure.content_going_to }" ); return -1;

        }




        // ?? 
        private int Instanciate( RESOURCE__structure _structure, RESOURCE__structure_copy _copy ){

                Console.Log( "Veio Instanciate" );

                relogio.Start();

                    GameObject game_object = GameObject.Instantiate( _structure.prefab );
                    game_object.name = _structure.prefab.name;

                    GAME_OBJECT.Colocar_parent( container_to_instanciate, game_object );
                
                    _copy.structure_game_object = game_object;
                    _copy.structure_game_object.SetActive( false );

                    
                    int time = ( int )( relogio.ElapsedMilliseconds + 1l );

                relogio.Reset();

                return time;

        }


        public void Put_in_waiting_container( RESOURCE__structure_copy _copy ){

            Console.Log( "Veio Put_in_waiting_container()" );

                
                CONTROLLER__errors.Verify( ( _copy.structure_game_object == null ), $"Tried to deinstanciate { _copy.structure.locators.main_struct_name } but the structure_game_object is null" );

                _copy.structure_game_object.transform.SetParent( container_to_instanciate.transform, false );
                _copy.structure_game_object.SetActive( false );

        }



        
        // --- EXTRA

        public int Get_bytes_allocated(){

                return 0;     

        }



    


}
