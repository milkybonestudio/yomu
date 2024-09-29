

unsafe public static class TOOL__unloader_cities {



        public static void Unload_entity_intern( CONTROLLER__cities _controller, Locator_entity[] _entidades ){ 


            // -- remove os persoangens 
            for( int character_slot_index = 0 ; character_slot_index < _entidades.Length ; character_slot_index++){ 

                    Locator_entity locator = _entidades[ character_slot_index ];
                    _controller.slot_entidades_para_excluir.Add_entity_id( locator.indentificador ); 

                    int index = System.Array.BinarySearch( _controller.cities_activated , locator.indentificador );

                    if( index < 0 )
                        { throw new System.Exception( "what" ); }

                    _controller.cities_activated[ index ] = 0;

            }


            INT.Reajust_sort_array_after_deletions( _controller.cities_activated );
            _controller.cities_activated_pointer -= _entidades.Length;

            return; 
        }





}