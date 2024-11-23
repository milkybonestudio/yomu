
using System;
using UnityEngine;



public class CONTAINER__resource_structure {


        public CONTAINER__resource_structure(){

                structures_available = new RESOURCE__structure[ 100 ];

                for( int index = 0 ; index < structures_available.Length ; index++ )
                    { structures_available[ index ] = new RESOURCE__structure(); }

                structures_waiting_to_reset = new RESOURCE__structure[ 20 ];

        }


        private RESOURCE__structure[] structures_available;
    
        private RESOURCE__structure[] structures_waiting_to_reset;
        private int pointer_structure_to_delete = 0;

        public RESOURCE__structure Get_resource_structure( MODULE__context_structures _module_structures,  Resource_context _context,  string _main_folder, Structure_locators locator ){

               int structure_slot = 0;

                while(  structure_slot++ < ( structures_available.Length - 1 )  ){

                        RESOURCE__structure structure = structures_available[ structure_slot ];
                        if( structures_available[ structure_slot ] == null )
                            { continue; }

                        Put_data_structure( structure, _module_structures, _context, _main_folder, locator );
                        structure.structure_state = Resource_use_state.used;

                        structures_available[ structure_slot ] = null;
                        return structure;
                        
                }

                Console.Log( "vai entrar" );
                Array.Resize( ref structures_available, structures_available.Length + 25 );

                while(  structure_slot++ < ( structures_available.Length - 1 )  ){

                        structures_available[ structure_slot ] = new RESOURCE__structure();
                        
                }

                RESOURCE__structure new_structure = structures_available[ ^1 ];
                structures_available[ ^1 ] = null;
                return new_structure;
            

        }


        public void Return_structure( RESOURCE__structure _structure ){


                _structure.structure_state = Resource_use_state.waiting_to_delete; 

                if( structures_waiting_to_reset.Length == pointer_structure_to_delete )
                    { Array.Resize( ref structures_waiting_to_reset, ( structures_waiting_to_reset.Length + 10 ) );  }

                structures_waiting_to_reset[ pointer_structure_to_delete++ ] = _structure;

        }


        public int Update( int _weight_to_stop, int _current_weight ){

                for( int slot = 0 ; slot < pointer_structure_to_delete ; slot++ ){

                        if( structures_waiting_to_reset[ slot ] == null )
                            { continue; }

                        _current_weight += Return_structure_to_available( structures_waiting_to_reset[ slot ] );
                        structures_waiting_to_reset[ slot ] = null;

                        if( _current_weight >= _weight_to_stop )
                            { return _current_weight; }

                        continue;
                    
                }

                return _current_weight;

        }



        private int Return_structure_to_available( RESOURCE__structure _structure ){


                for( int structure_slot = 0 ; structure_slot < structures_available.Length ; structure_slot++ ){

                        if( structures_available[ structure_slot ] != null )
                            { continue; }
                        
                        structures_available[ structure_slot ] = _structure;
                        return Reset_data( _structure );
                        
                }

                CONTROLLER__errors.Throw( "tried to return a resource__structure but there was no space for it" );
                return 0;

        }


        public string Get_structure_key( string _main_folder, string _path_local ){

            return  $"{ _main_folder }\\{ _path_local }";
        }


        private void Put_data_structure( RESOURCE__structure _structure,  MODULE__context_structures _module_structures,  Resource_context _context,  string _main_folder, Structure_locators _locator ){

            Console.Log( "veiuo Put_data_structure()" );


                // ** structure DATA
                
                _structure.main_folder = _main_folder;
                
                _structure.structure_context = _context; 
                _structure.structure_key = Get_structure_key( _main_folder, _locator.current_structure_local_path );
                _structure.module_structures = _module_structures;
                _structure.locators = _locator;

                _structure.resource_path = ( _context.ToString() + "\\" + _main_folder + "\\" + _locator.current_structure_local_path );



                _structure.stage_getting_resource = Resources_getting_structure_stage.finished;
                _structure.actual_content = Resource_structure_content.nothing;
                _structure.content_going_to = Resource_structure_content.nothing;
                

            
        }



        private int Reset_data( RESOURCE__structure _structure ){


                int weight = 0;
                    // ** IMPORTANT
                    _structure.structure_state = Resource_use_state.unused;


                    _structure.structure_context = Resource_context.not_given; 
                    _structure.main_folder = null;
                    _structure.structure_key = null;
                    _structure.module_structures = null;
                

                    _structure.stage_getting_resource = Resources_getting_structure_stage.not_give;
                    _structure.actual_content = Resource_structure_content.not_give;
                    _structure.content_going_to = Resource_structure_content.not_give;
                    
                return weight;
        
        }


}

