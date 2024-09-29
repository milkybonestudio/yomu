

unsafe public static class TOOL__loader_cities {



        public static void Load_entity_intern( CONTROLLER__cities _controller,  Locator_entity[] _entidades ){

                if( ( _controller.cities_activated.Length - _controller.cities_activated_pointer ) < _entidades.Length )
                    { System.Array.Resize( ref _controller.cities_activated, ( _controller.cities_activated.Length + 25  ) ); }

            // --- ADICIONAR
            for( int character_slot_index = 0 ; character_slot_index < _entidades.Length ; character_slot_index++){ 

                    Locator_entity locator = _entidades[ character_slot_index ];
                    //Loader( locator )

                    _controller.cities_activated[ _controller.cities_activated_pointer++ ] = locator.indentificador;
                    continue;

            }

            // --- SORT
            System.Array.Sort( _controller.cities_activated );
            return;

            
        }


}