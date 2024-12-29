using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;



public static class TOOL__resources_structures {




        public static void Create_dictionary( RESOURCE__structure_copy _copy ){

                _copy.components_dic = new Dictionary<string,Unity_main_components>( 30 );
                int a = Get_components(  0, null, _copy.structure_game_object, _copy.components_dic );
                Console.Log( "number interactions: " + a );
                
        }


        private static int Get_components(  int _number_interations, string _root_path, GameObject _obj, Dictionary<string,Unity_main_components> _dic ){

                if( _number_interations > 1000 )
                    { CONTROLLER__errors.Throw( $"Tried to get_component but the interation count pass 1_000" ); }
                    
                Console.Log( $"interaction { _number_interations } name: { _obj.name }" );
                _number_interations++;
                
                // --- ADD CURRENT TRANSFORM

                string key = null;
                if( _root_path == null )
                    { key = _obj.name; }
                    else
                    { key = ( _root_path + "/" + _obj.transform.gameObject.name ); }                        

                Unity_main_components unity_main_components = new Unity_main_components();

                    unity_main_components.active = true;
                    unity_main_components.game_object = _obj;    
                    _obj.TryGetComponent<Image>( out unity_main_components.image );
                    

                if( !!!( _dic.TryAdd( key, unity_main_components ) ) )
                    { CONTROLLER__errors.Throw( $"Could not add in the key { key } in Get_component for structure" ); }

                // --- APPLY TO CHILDREN
                int child_count = _obj.transform.childCount;

                for( int child = 0 ; child < child_count ; child++ )
                    { _number_interations = Get_components(  _number_interations , key, _obj.transform.GetChild( child ).gameObject, _dic ); }

                return _number_interations;

        }


        public static GameObject Get_component_game_object( RESOURCE__structure_copy _copy, string _component_key ){


                Unity_main_components main_components = new Unity_main_components();

                Console.Log( $"Vai tentar pegar o componente { _component_key } em game_object" );
                
                if( !!!( _copy.components_dic.TryGetValue( _component_key, out main_components ) ) )
                    { CONTROLLER__errors.Throw( $"Did not found the component <Color=lightBlue>{ _component_key }</Color> in the structure <Color=lightBlue>{ _copy.name }</Color>" ); }

                if( !!!( main_components.active ) )
                    { CONTROLLER__errors.Throw( $"The component in the key <Color=lightBlue>{ _component_key }</Color> in the structure <Color=lightBlue>{ _copy.name }</Color> is not active" ); }

                if( main_components.game_object == null )
                    { CONTROLLER__errors.Throw( $"The component in the key <Color=lightBlue>{ _component_key }</Color> in the structure <Color=lightBlue>{ _copy.name }</Color> dont have the Game_object" ); }

                Console.Log( "Conseguiu pegar game_object" );

                return main_components.game_object;

        }



        public static Image Get_component_image( RESOURCE__structure_copy _copy, string _component_key ){


                Unity_main_components main_components = new Unity_main_components();

                Console.Log( $"Vai tentar pegar o componente { _component_key } em image" );
                Console.Log( "B: " + _copy );
                
                if( !!!( _copy.components_dic.TryGetValue( _component_key, out main_components ) ) )
                    { CONTROLLER__errors.Throw( $"Did not found the component <Color=lightBlue>{ _component_key }</Color> in the structure <Color=lightBlue>{ _copy.name }</Color>" ); }

                if( !!!( main_components.active ) )
                    { CONTROLLER__errors.Throw( $"The component in the key <Color=lightBlue>{ _component_key }</Color> in the structure <Color=lightBlue>{ _copy.name }</Color> is not active" ); }

                if( main_components.image == null )
                    { CONTROLLER__errors.Throw( $"The component in the key <Color=lightBlue>{ _component_key }</Color> in the structure <Color=lightBlue>{ _copy.name }</Color> dont have the Game_object" ); }

                Console.Log( "Conseguiu pegar image" );

                main_components.image.color = Color.red;

                return main_components.image;

        }




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

                    TOOL__resources_structures.Create_dictionary( _copy );

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