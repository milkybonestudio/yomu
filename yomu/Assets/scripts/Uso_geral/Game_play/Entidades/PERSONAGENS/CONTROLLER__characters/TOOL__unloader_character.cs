

unsafe public static class TOOL__unloader_character {



        public static void Unload_entity_intern( CONTROLLER__characters _controller, Locator_entidade[] _entidades ){ 

            // -- remove os persoangens 
            for( int character_slot_index = 0 ; character_slot_index < _entidades.Length ; character_slot_index++){ 

                    Locator_entidade locator = _entidades[ character_slot_index ];
                    _controller.slot_entidades_para_excluir.Add_entity_id( locator.indentificador ); 

                    int index = System.Array.BinarySearch( _controller.characters_activated , locator.indentificador );

                    if( index < 0 )
                        { throw new System.Exception( "what" ); }

                    _controller.characters_activated[ index ] = 0;

            }


            INT.Reajust_sort_array_after_deletions( _controller.characters_activated );
            _controller.characters_activated_pointer -= _entidades.Length;

            return; 
        }





}