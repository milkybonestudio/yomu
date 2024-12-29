using UnityEngine;

public static class TOOL__resources_complex_structures {



        public static void Update_resource_level_complex_structure_COPY( RESOURCE__complex_structure_copy _copy ){


                if( _copy.actual_need_content == Resource_complex_structure_content.game_object )
                    { _copy.Flag_need_to_instanciate( ( _copy.structure_game_object == null ) ); }

                return;
            
        }
        
        
        public static void Update_resource_level_complex_structure( RESOURCE__complex_structure _complex_structure ){


                if( ( _complex_structure.count_places_being_used_game_object > 0 ) || ( _complex_structure.count_places_being_used_complex_structure_data > 0 ) )
                    { Going_to_resource_level_complex_STRUCTURE_DATA( _complex_structure ); return; }
            
                if( _complex_structure.count_places_being_used_nothing >= 0  )
                    { Going_to_resource_level_NOTHING( _complex_structure ); return;}

                // ** DELETE

                _complex_structure.module_complex_structures.actives_complex_structures_dictionary.Remove( _complex_structure.complex_structure_key ); // ** nao tem mais update
                _complex_structure.module_complex_structures.manager.container_resources_complex_structures.Return_complex_structure( _complex_structure ); 


        }

        private static void Going_to_resource_level_NOTHING( RESOURCE__complex_structure _complex_structure ){

                // --- NAO TEM QUE TER NADA
                
                if( _complex_structure.actual_content == Resource_complex_structure_content.nothing )
                    { return; } // ** nivelado

                // ** se estivber aqui cada copia também vai estar sem o prefab. Fica por responsabilidades deles de deletarem

                // --- TEM QUE LIMPAR
                _complex_structure.prefab = null;
                _complex_structure.content_going_to = Resource_complex_structure_content.nothing;
                _complex_structure.actual_content   = Resource_complex_structure_content.nothing;

                return;

        }
        

        private static void Going_to_resource_level_complex_STRUCTURE_DATA( RESOURCE__complex_structure _complex_structure ){

                // --- TEM ALGO
                if( _complex_structure.content_going_to == Resource_complex_structure_content.structure_data )
                    { return; } // ** nivel já nivelado

                _complex_structure.content_going_to = Resource_complex_structure_content.structure_data;
                _complex_structure.stage_getting_resource = Resources_getting_complex_structure_stage.waiting_to_start;
            
                return;


        }


        
        public static void Instanciate_copy( RESOURCE__complex_structure _complex_structure, RESOURCE__complex_structure_copy _copy, GameObject _container ){

                Console.Log( "Veio Instanciate" );


                    GameObject game_object = GameObject.Instantiate( _complex_structure.prefab );
                    game_object.name = _complex_structure.prefab.name;

                    GAME_OBJECT.Colocar_parent( _container, game_object );
                
                    _copy.structure_game_object = game_object;
                    _copy.structure_game_object.SetActive( false );

                return;

        }






        public static void Change_actual_need_content_count( RESOURCE__complex_structure_copy _copy, Resource_complex_structure_content _new_content ){


                RESOURCE__complex_structure structure = _copy.structure;

                // ** ATUALIZOU RECURSO DA COPIA 
                
                Decrease_count( structure, _copy.actual_need_content);
                Increase_count( structure, _new_content );

                _copy.actual_need_content = _new_content;

                return;

        }





        // mudar

        public static void Increase_count( RESOURCE__complex_structure _image, Resource_complex_structure_content _state ){ Change( _image, _state, 1 ); }
        public static void Decrease_count( RESOURCE__complex_structure _image, Resource_complex_structure_content _state ){ Change( _image, _state, -1 ); }


        public static void Change( RESOURCE__complex_structure _complex_structure, Resource_complex_structure_content _content, int _value ){


                switch( _content ){

                    case Resource_complex_structure_content.nothing : _complex_structure.count_places_being_used_nothing += _value; break;
                    case Resource_complex_structure_content.structure_data : _complex_structure.count_places_being_used_complex_structure_data += _value; break;
                    case Resource_complex_structure_content.game_object : _complex_structure.count_places_being_used_game_object += _value; break;
                    
                }

        }


}