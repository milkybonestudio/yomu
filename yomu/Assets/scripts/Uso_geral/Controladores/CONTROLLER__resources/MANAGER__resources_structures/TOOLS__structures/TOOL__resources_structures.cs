using UnityEngine;

public static class TOOL__resources_structures {



        public static void Update_resource_level_structure_COPY( RESOURCE__structure_copy _copy ){


                if( _copy.actual_need_content == Resource_structure_content.game_object )
                    { _copy.Flag_need_to_instanciate( ( _copy.structure_game_object == null ) ); }

                return;
            
        }
        
        
        public static void Update_resource_level_structure( RESOURCE__structure _structure ){


                if( ( _structure.count_places_being_used_game_object > 0 ) || ( _structure.count_places_being_used_structure_data > 0 ) )
                    { Going_to_resource_level_STRUCTURE_DATA( _structure ); return; }
            
                if( _structure.count_places_being_used_nothing >= 0  )
                    { Going_to_resource_level_NOTHING( _structure ); return;}

                // ** DELETE

                _structure.module_structures.actives_structures_dictionary.Remove( _structure.structure_key ); // ** nao tem mais update
                _structure.module_structures.manager.container_resources_structures.Return_structure( _structure ); 


        }

        private static void Going_to_resource_level_NOTHING( RESOURCE__structure _structure ){

                // --- NAO TEM QUE TER NADA
                
                if( _structure.actual_content == Resource_structure_content.nothing )
                    { return; } // ** nivelado

                // ** se estivber aqui cada copia também vai estar sem o prefab. Fica por responsabilidades deles de deletarem

                // --- TEM QUE LIMPAR
                _structure.prefab = null;
                _structure.content_going_to = Resource_structure_content.nothing;
                _structure.actual_content   = Resource_structure_content.nothing;

                return;

        }
        

        private static void Going_to_resource_level_STRUCTURE_DATA( RESOURCE__structure _structure ){

                // --- TEM ALGO
                if( _structure.content_going_to == Resource_structure_content.structure_data )
                    { return; } // ** nivel já nivelado

                _structure.content_going_to = Resource_structure_content.structure_data;
                _structure.stage_getting_resource = Resources_getting_structure_stage.waiting_to_start;
            
                return;


        }


        
        public static void Instanciate_copy( RESOURCE__structure _structure, RESOURCE__structure_copy _copy, GameObject _container ){

                Console.Log( "Veio Instanciate" );


                    GameObject game_object = GameObject.Instantiate( _structure.prefab );
                    game_object.name = _structure.prefab.name;

                    GAME_OBJECT.Colocar_parent( _container, game_object );
                
                    _copy.structure_game_object = game_object;
                    _copy.structure_game_object.SetActive( false );

                return;

        }






        public static void Change_actual_need_content_count( RESOURCE__structure_copy _copy, Resource_structure_content _new_content ){


                RESOURCE__structure structure = _copy.structure;

                // ** ATUALIZOU RECURSO DA COPIA 
                
                Decrease_count( structure, _copy.actual_need_content);
                Increase_count( structure, _new_content );

                _copy.actual_need_content = _new_content;

                return;

        }





        // mudar

        public static void Increase_count( RESOURCE__structure _image, Resource_structure_content _state ){ Change( _image, _state, 1 ); }
        public static void Decrease_count( RESOURCE__structure _image, Resource_structure_content _state ){ Change( _image, _state, -1 ); }


        public static void Change( RESOURCE__structure _structure, Resource_structure_content _content, int _value ){


                switch( _content ){

                    case Resource_structure_content.nothing : _structure.count_places_being_used_nothing += _value; break;
                    case Resource_structure_content.structure_data : _structure.count_places_being_used_structure_data += _value; break;
                    case Resource_structure_content.game_object : _structure.count_places_being_used_game_object += _value; break;
                    
                }

        }


}