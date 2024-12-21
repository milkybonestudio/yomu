using System;
using UnityEngine;



public class CONTAINER__RESOURCE__logics_refs {


        public CONTAINER__RESOURCE__logics_refs(){

                references_available = new RESOURCE__logic_ref[ 100 ];

                for( int index = 0 ; index < references_available.Length ; index++ )
                    { references_available[ index ] = new RESOURCE__logic_ref(); }

        }


        public RESOURCE__logic_ref[] references_available;

        public RESOURCE__logic_ref Get_resource_logic_ref( RESOURCE__logic _image, Resource_logic_content _level_pre_allocation ){

               int image_slot = 0;

                while(  image_slot++ < ( references_available.Length - 1 )  ){

                        RESOURCE__logic_ref reference = references_available[ image_slot ];
                        if( references_available[ image_slot ] == null )
                            { continue; }

                        Put_data_logic_ref( reference, _image, _level_pre_allocation );
                        references_available[ image_slot ] = null;
                        return reference;
                        
                }

                Console.Log( "vai entrar" );
                Array.Resize( ref references_available, references_available.Length + 25 );

                while(  image_slot++ < ( references_available.Length - 1 )  ){

                        references_available[ image_slot ] = new RESOURCE__logic_ref();
                        
                }

                RESOURCE__logic_ref new_ref = references_available[ ^1 ];
                references_available[ ^1 ] = null;
                return new_ref;
            

        }


        public void Return_logic_ref( RESOURCE__logic_ref _image ){


                for( int image_slot = 0 ; image_slot < references_available.Length ; image_slot++ ){

                        if( references_available[ image_slot ] != null )
                            { continue; }
                        
                        references_available[ image_slot ] = _image;
                        Reset_data( _image );
                        return;
                        
                }

                CONTROLLER__errors.Throw( "tried to return a resource__logic_ref but there was no space for it" );

        }


        private void Put_data_logic_ref( RESOURCE__logic_ref _ref,  RESOURCE__logic _logic, Resource_logic_content _level_pre_allocation ){

                
                if( _logic == null )
                    { CONTROLLER__errors.Throw( "Tried to creat a image ref but the image comes null" ); }
        
            
                _ref.ref_name = "NAO COLOCOU?"; // ** localizador local
                _ref.logic = _logic;
                _ref.module = _logic.module_logics;

                _ref.state = Resource_state.nothing;

                _ref.level_pre_allocation = _level_pre_allocation;
                _ref.actual_need_content = Resource_logic_content.nothing;

                _ref.ref_state = RESOURCE__logic_ref_state.instanciated;

        }

        private void Reset_data( RESOURCE__logic_ref _ref ){

                _ref.ref_name = null; // ** localizador local
                _ref.logic = null;
                _ref.module = null;
                _ref.logic_slot_index = -1;

                _ref.ref_state = RESOURCE__logic_ref_state.deleted;
                
                _ref.state = Resource_state.nothing;

                _ref.level_pre_allocation = Resource_logic_content.not_give; // minimun 
                _ref.actual_need_content = Resource_logic_content.not_give;
        

        }


}

