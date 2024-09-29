using System;

unsafe public static class TOOL__get_entity_container {


        // --- ADD

        public static Character Get_character( Character[] _characters , int _character_id ){ 

            fixed( Character* char_p = _characters ){ 

                return TOOL__suport_entities.Get_generic_entity( ( Generic_entity* )char_p, _characters.Length, _character_id ).get_character; 

            } 

        }


        public static City Get_city( City[] activated_cities,  int _character_id ){ 

            fixed( City* char_p = activated_cities ){ 

                return TOOL__suport_entities.Get_generic_entity( ( Generic_entity* )char_p, activated_cities.Length, _character_id ).get_city; 

            }

        }


        public static Plot Get_plot( CONTROLLER__entities container, int _character_id ){ 

            fixed( Plot* char_p = container.activated_plots ){ 

                return TOOL__suport_entities.Get_generic_entity( ( Generic_entity* )char_p, container.pointer_plots, _character_id ).get_plot;
            }

        }




}