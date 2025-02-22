
using System;
using UnityEngine;


public class CONTAINER__resource_structure_copy {


        public CONTAINER__resource_structure_copy(){

                copies_available = new RESOURCE__structure_copy[ 100 ];

                for( int index = 0 ; index < copies_available.Length ; index++ )
                    { copies_available[ index ] = new RESOURCE__structure_copy(); }

                structures_waiting_to_reset = new RESOURCE__structure_copy[ 20 ];

        }


        private RESOURCE__structure_copy[] copies_available;
    
        private RESOURCE__structure_copy[] structures_waiting_to_reset;
        private int pointer_structure_to_delete = 0;




        public RESOURCE__structure_copy Get_resource_structure_copy( RESOURCE__structure _structure, Resource_structure_content _level_pre_allocation ){

               int structure_slot = 0;

                while(  structure_slot++ < ( copies_available.Length - 1 )  ){

                        RESOURCE__structure_copy copy = copies_available[ structure_slot ];
                        if( copy == null )
                            { continue; }

                        Put_data_copy( copy, _structure, _level_pre_allocation );
                        copy.ref_state = Resource_use_state.used;

                        copies_available[ structure_slot ] = null;
                        return copy;
                        
                }

                Console.Log( "vai entrar" );
                Array.Resize( ref copies_available, copies_available.Length + 25 );

                while(  structure_slot++ < ( copies_available.Length - 1 )  ){

                        copies_available[ structure_slot ] = new RESOURCE__structure_copy();
                        
                }

                RESOURCE__structure_copy new_structure = copies_available[ ^1 ];
                copies_available[ ^1 ] = null;
                return new_structure;
            

        }


        public void Return_structure_copy( RESOURCE__structure_copy _copy ){


                _copy.ref_state = Resource_use_state.waiting_to_delete; 

                if( structures_waiting_to_reset.Length == pointer_structure_to_delete )
                    { Array.Resize( ref structures_waiting_to_reset, ( structures_waiting_to_reset.Length + 10 ) );  }

                structures_waiting_to_reset[ pointer_structure_to_delete++ ] = _copy;

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



        private int Return_structure_to_available( RESOURCE__structure_copy _structure ){


                for( int structure_slot = 0 ; structure_slot < copies_available.Length ; structure_slot++ ){

                        if( copies_available[ structure_slot ] != null )
                            { continue; }
                        
                        copies_available[ structure_slot ] = _structure;
                        return Reset_data( _structure );
                        
                }

                CONTROLLER__errors.Throw( "tried to return a resource__structure_copy but there was no space for it" );
                return 0;

        }


        public string Get_structure_key( string _main_folder, string _path_local ){

            return  $"{ _main_folder }\\{ _path_local }";
        }


        private void Put_data_copy( RESOURCE__structure_copy _copy, RESOURCE__structure _structure,  Resource_structure_content _level_pre_allocation ){

                _copy.structure = _structure;
                _copy.name = _structure.structure_key;

                _copy.level_pre_allocation = _level_pre_allocation;
                _copy.actual_need_content = Resource_structure_content.nothing;
                _copy.actual_content = Resource_structure_content.nothing;

                // ** _copy.components_dic => created when need it

                _copy.deleted = false;

            
        }


        private int Reset_data( RESOURCE__structure_copy _copy ){


                int weight = 0;

                    _copy.ref_state = Resource_use_state.waiting_to_delete;
                    _copy.structure = null;
                    _copy.level_pre_allocation = Resource_structure_content.not_give;
                    _copy.actual_need_content = Resource_structure_content.not_give; // ** nothing / instanciate
                    _copy.name = null;
                    _copy.RESOURCE_index = -1;
                    _copy.deleted = true;
                    
                    _copy.components_dic.Clear();
                    _copy.components_dic = null;

                            
                return weight;
        
        }


}

