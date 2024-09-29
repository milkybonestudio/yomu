using System;

unsafe public static class TOOL__add_entities_container {


        // --- ADD

        public static void Add_characters( Character[] _current_characters, Character[] characters_add ){ 
        
                if ( _current_characters.Length + characters_add.Length >= _current_characters.Length )
                    { Array.Resize( ref _current_characters, ( _current_characters.Length + 50 ) ); }
                
                fixed( Character* data_pointer = characters_add, add_pointer = characters_add ){  

                    TOOL__suport_entities.Add_generic_entities( ( Generic_entity* )data_pointer, characters_add.Length, ( Generic_entity* )add_pointer, characters_add.Length ); 
                    
                }
        
        }

        public static void Add_cities( City[] _cities, City[] cities_add ){ 
        
                if ( cities_add.Length >= cities_add.Length )
                    { Array.Resize( ref _cities, ( _cities.Length + 50 ) ); }
                
                fixed( City* data_pointer = _cities, add_pointer = cities_add ){  

                    TOOL__suport_entities.Add_generic_entities( ( Generic_entity* )data_pointer, _cities.Length, ( Generic_entity* )add_pointer, cities_add.Length ); 
                    
                }
        
        }



        public static void Add_plots( Plot[] _plots, Plot[] plots_add ){ 
        
                if ( plots_add.Length >= _plots.Length )
                    { Array.Resize( ref _plots, ( _plots.Length + 50 ) ); }
                
                fixed( Plot* data_pointer = _plots, add_pointer = plots_add ){  

                    TOOL__suport_entities.Add_generic_entities( ( Generic_entity* )data_pointer, _plots.Length, ( Generic_entity* )add_pointer, plots_add.Length ); 
                    
                }
        
        }





}