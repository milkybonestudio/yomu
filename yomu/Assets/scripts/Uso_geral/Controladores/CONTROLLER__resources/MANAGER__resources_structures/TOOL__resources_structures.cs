

public static class TOOL__resources_structures {


        public static void Change_level_pre_allocation( RESOURCE__structure_copy _copy,  Resource_structure_content _new_level ){


                if( _copy.level_pre_allocation == _new_level )
                    { return; } // --- SAME LEVEL

                Decrease_count( _copy.structure, _copy.level_pre_allocation );
                Increase_count( _copy.structure, _new_level );

                




                if( _copy.level_pre_allocation < _new_level )
                    {
                        // --- DIMINUIR
                        

                    }
                    else
                    {
                        // --- AUMENTAR

                    }



        }





        public static void Increase_count( RESOURCE__structure _image, Resource_structure_content _state ){

                switch( _state ){

                    case Resource_structure_content.nothing : _image.count_places_being_used_nothing++; break;
                    case Resource_structure_content.structure_data : _image.count_places_being_used_structure_data++; break;
                    case Resource_structure_content.instance : _image.count_places_being_used_instance++; break;
                    
                }

        }

        public static void Decrease_count( RESOURCE__structure _image, Resource_structure_content _state ){


                switch( _state ){

                    case Resource_structure_content.nothing : _image.count_places_being_used_nothing--; break;
                    case Resource_structure_content.structure_data : _image.count_places_being_used_structure_data--; break;
                    case Resource_structure_content.instance : _image.count_places_being_used_instance--; break;
                    
                }

        }



}