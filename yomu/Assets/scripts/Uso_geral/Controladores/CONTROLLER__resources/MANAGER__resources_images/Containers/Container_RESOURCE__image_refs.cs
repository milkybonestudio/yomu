using System;
using UnityEngine;



public class Container_RESOURCE__image_refs {


        public Container_RESOURCE__image_refs(){

                references_available = new RESOURCE__image_ref[ 100 ];

                for( int index = 0 ; index < references_available.Length ; index++ )
                    { references_available[ index ] = new RESOURCE__image_ref(); }

        }


        public RESOURCE__image_ref[] references_available;

        public RESOURCE__image_ref Get_resource_image_ref( RESOURCE__image _image, Resource_image_content _level_pre_allocation ){

               int image_slot = 0;

                while(  image_slot++ < ( references_available.Length - 1 )  ){

                        RESOURCE__image_ref reference = references_available[ image_slot ];
                        if( references_available[ image_slot ] == null )
                            { continue; }

                        Put_data_image_ref( reference, _image, _level_pre_allocation );
                        references_available[ image_slot ] = null;
                        return reference;
                        
                }

                Console.Log( "vai entrar" );
                Array.Resize( ref references_available, references_available.Length + 25 );

                while(  image_slot++ < ( references_available.Length - 1 )  ){

                        references_available[ image_slot ] = new RESOURCE__image_ref();
                        
                }

                RESOURCE__image_ref new_ref = references_available[ ^1 ];
                references_available[ ^1 ] = null;
                return new_ref;
            

        }


        public void Return_image_ref( RESOURCE__image_ref _image ){


                for( int image_slot = 0 ; image_slot < references_available.Length ; image_slot++ ){

                        if( references_available[ image_slot ] != null )
                            { continue; }
                        
                        references_available[ image_slot ] = _image;
                        Reset_data( _image );
                        return;
                        
                }

                CONTROLLER__errors.Throw( "tried to return a resource__image_ref but there was no space for it" );

        }


        private void Put_data_image_ref( RESOURCE__image_ref _ref,  RESOURCE__image _image, Resource_image_content _level_pre_allocation ){


                CONTROLLER__errors.Verify( ( _image == null  ), "Tried to creat a image ref but the image comes null" ); 
                CONTROLLER__errors.Verify( ( ( _level_pre_allocation & ( Resource_image_content.compress_data | Resource_image_content.sprite | Resource_image_content.nothing  | Resource_image_content.compress_low_quality_data ) ) == 0   ), $"Resource not accept: { _level_pre_allocation }" ); 
                
            
                _ref.localizador = "NAO COLOCOU?"; // ** localizador local
                _ref.image = _image;
                _ref.module = _image.module_images;

                _ref.state = Resource_state.nothing;

                _ref.level_pre_allocation = _level_pre_allocation;
                _ref.actual_need_content = Resource_image_content.nothing;

                _ref.ref_state = RESOURCE__image_ref_state.instanciated;

        }

        private void Reset_data( RESOURCE__image_ref _ref ){

                _ref.localizador = null; // ** localizador local
                _ref.image = null;
                _ref.module = null;
                _ref.image_slot_index = -1;

                _ref.ref_state = RESOURCE__image_ref_state.deleted;
                
                _ref.state = Resource_state.nothing;

                _ref.level_pre_allocation = Resource_image_content.not_give; // minimun 
                _ref.actual_need_content = Resource_image_content.not_give;
        

        }


}

