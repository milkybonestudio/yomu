

unsafe public static class TOOL__loader_character {



        public static void Load_entity_intern( CONTROLLER__characters _controller,  Locator_entity[] _entidades ){

                if( ( _controller.characters_activated.Length - _controller.characters_activated_pointer ) < _entidades.Length )
                    { System.Array.Resize( ref _controller.characters_activated, ( _controller.characters_activated.Length + 25  ) ); }

            // --- ADICIONAR
            for( int character_slot_index = 0 ; character_slot_index < _entidades.Length ; character_slot_index++){ 

                    Locator_entity locator = _entidades[ character_slot_index ];
                    //Loader( locator )

                    _controller.characters_activated[ _controller.characters_activated_pointer++ ] = locator.indentificador;
                    continue;

            }

            // --- SORT
            System.Array.Sort( _controller.characters_activated );
            return;

            
        }


}