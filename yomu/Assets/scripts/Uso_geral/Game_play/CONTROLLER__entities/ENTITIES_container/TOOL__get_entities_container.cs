using System;

unsafe public static class TOOL__get_entities_container {


        // --- ADD

        public static Character[] Get_characters( Character[] characters, int[] _characters_ids ){ 

            fixed( Character* char_p = characters ){ 

                Character[] new_characters = new Character[ _characters_ids.Length ];

                for( int index = 0 ; index < characters.Length ; index++ ){

                    new_characters[ index ] = TOOL__suport_entities.Get_generic_entity( ( Generic_entity* )char_p, characters.Length, _characters_ids[ index ] ).get_character;

                }

                return characters; 

            } 

        }


        public static Plot[] Get_plots( CONTROLLER__entities container, int[] _plots_ids ){ 

            fixed( Plot* char_p = container.activated_plots ){ 

                Plot[] plots = new Plot[ _plots_ids.Length ];

                for( int index = 0 ; index < plots.Length ; index++ ){

                    plots[ index ] = TOOL__suport_entities.Get_generic_entity( ( Generic_entity* )char_p, container.pointer_plots, _plots_ids[ index ] ).get_plot;

                }

                return plots; 

            } 

        }


        public static City[] Get_cities( City[] _cities, int[] _cities_ids ){ 

            fixed( City* char_p = _cities ){ 

                City[] cities = new City[ _cities_ids.Length ];

                for( int index = 0 ; index < cities.Length ; index++ ){

                    cities[ index ] = TOOL__suport_entities.Get_generic_entity( ( Generic_entity* )char_p, _cities.Length, _cities_ids[ index ] ).get_city;

                }

                return cities; 

            } 

        }




}