
using System;
using UnityEngine;



public class CONTAINER__RESOURCE__complex_structure {


        public CONTAINER__RESOURCE__complex_structure(){

                structures_available = new RESOURCE__complex_structure[ 100 ];

                for( int index = 0 ; index < structures_available.Length ; index++ )
                    { structures_available[ index ] = new RESOURCE__complex_structure(); }

                structures_waiting_to_reset = new RESOURCE__complex_structure[ 20 ];

        }


        private RESOURCE__complex_structure[] structures_available;
    
        private RESOURCE__complex_structure[] structures_waiting_to_reset;
        private int pointer_complex_structure_to_delete = 0;

        public RESOURCE__complex_structure Get_resource_complex_structure( MODULE__context_complex_structures _module_complex_structures,  Resource_context _context,  string _main_folder, Complex_structure_locators locator ){

               int structure_slot = 0;

                while(  structure_slot++ < ( structures_available.Length - 1 )  ){

                        RESOURCE__complex_structure structure = structures_available[ structure_slot ];
                        if( structures_available[ structure_slot ] == null )
                            { continue; }

                        Put_data_complex_structure( structure, _module_complex_structures, _context, _main_folder, locator );
                        structure.complex_structure_state = Resource_use_state.used;

                        structures_available[ structure_slot ] = null;
                        return structure;
                        
                }

                Console.Log( "vai entrar" );
                Array.Resize( ref structures_available, structures_available.Length + 25 );

                while(  structure_slot++ < ( structures_available.Length - 1 )  ){

                        structures_available[ structure_slot ] = new RESOURCE__complex_structure();
                        
                }

                RESOURCE__complex_structure new_complex_structure = structures_available[ ^1 ];
                structures_available[ ^1 ] = null;
                return new_complex_structure;
            

        }


        public void Return_complex_structure( RESOURCE__complex_structure _complex_structure ){


                _complex_structure.complex_structure_state = Resource_use_state.waiting_to_delete; 

                if( structures_waiting_to_reset.Length == pointer_complex_structure_to_delete )
                    { Array.Resize( ref structures_waiting_to_reset, ( structures_waiting_to_reset.Length + 10 ) );  }

                structures_waiting_to_reset[ pointer_complex_structure_to_delete++ ] = _complex_structure;

        }


        public int Update( int _weight_to_stop, int _current_weight ){

                for( int slot = 0 ; slot < pointer_complex_structure_to_delete ; slot++ ){

                        if( structures_waiting_to_reset[ slot ] == null )
                            { continue; }

                        _current_weight += Return_complex_structure_to_available( structures_waiting_to_reset[ slot ] );
                        structures_waiting_to_reset[ slot ] = null;

                        if( _current_weight >= _weight_to_stop )
                            { return _current_weight; }

                        continue;
                    
                }

                return _current_weight;

        }



        private int Return_complex_structure_to_available( RESOURCE__complex_structure _complex_structure ){


                for( int structure_slot = 0 ; structure_slot < structures_available.Length ; structure_slot++ ){

                        if( structures_available[ structure_slot ] != null )
                            { continue; }
                        
                        structures_available[ structure_slot ] = _complex_structure;
                        return Reset_data( _complex_structure );
                        
                }

                CONTROLLER__errors.Throw( "tried to return a resource__complex_structure but there was no space for it" );
                return 0;

        }


        public string Get_complex_structure_key( string _main_folder, string _path_local ){

            return  $"{ _main_folder }\\{ _path_local }";
        }


        private void Put_data_complex_structure( RESOURCE__complex_structure _complex_structure,  MODULE__context_complex_structures _module_complex_structures,  Resource_context _context,  string _main_folder, Complex_structure_locators _locator ){

            Console.Log( "veiuo Put_data_complex_structure()" );


                // ** structure DATA
                
                _complex_structure.main_folder = _main_folder;
                
                _complex_structure.complex_structure_context = _context; 
                _complex_structure.complex_structure_key = Get_complex_structure_key( _main_folder, _locator.current_complex_structure_local_path );
                _complex_structure.module_complex_structures = _module_complex_structures;
                _complex_structure.locators = _locator;

                _complex_structure.resource_path = ( _context.ToString() + "\\" + _main_folder + "\\" + _locator.current_complex_structure_local_path );



                _complex_structure.stage_getting_resource = Resources_getting_complex_structure_stage.finished;
                _complex_structure.actual_content = Resource_complex_structure_content.nothing;
                _complex_structure.content_going_to = Resource_complex_structure_content.nothing;
                

            
        }



        private int Reset_data( RESOURCE__complex_structure _complex_structure ){


                int weight = 0;
                    // ** IMPORTANT
                    _complex_structure.complex_structure_state = Resource_use_state.unused;


                    _complex_structure.complex_structure_context = Resource_context.not_given; 
                    _complex_structure.main_folder = null;
                    _complex_structure.complex_structure_key = null;
                    _complex_structure.module_complex_structures = null;
                

                    _complex_structure.stage_getting_resource = Resources_getting_complex_structure_stage.not_give;
                    _complex_structure.actual_content = Resource_complex_structure_content.not_give;
                    _complex_structure.content_going_to = Resource_complex_structure_content.not_give;
                    
                return weight;
        
        }


}

