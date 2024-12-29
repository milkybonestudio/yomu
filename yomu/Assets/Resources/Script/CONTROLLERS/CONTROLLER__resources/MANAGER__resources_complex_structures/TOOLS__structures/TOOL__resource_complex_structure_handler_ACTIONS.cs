using UnityEngine;

public static class TOOL__resource_complex_structure_handler_ACTIONS {





        //mark
        // ** depois passar para tool__actions



        public static void Change_level_pre_allocation( RESOURCE__complex_structure_copy _copy, Resource_complex_structure_content _new_pre_alloc ){


                if( _copy.level_pre_allocation == _new_pre_alloc )
                    { return; } // --- SAME LEVEL

                _copy.level_pre_allocation = _new_pre_alloc;


                if( _copy.state != Resource_state.minimun )
                    { return; } // nao muda nada

                TOOL__resources_complex_structures.Change_actual_need_content_count( _copy, _copy.level_pre_allocation );
                
    
                // VAI ATUALIZAR O RECURSO ORIGINAL
                TOOL__resources_complex_structures.Update_resource_level_complex_structure( _copy.structure );
                TOOL__resources_complex_structures.Update_resource_level_complex_structure_COPY( _copy );

        }


        // --- DOWN

        public static void Delete( RESOURCE__complex_structure_copy _copy ){ 

                Console.Log( "Veio Delete()" );

                if( _copy.state == Resource_state.instanciated )
                    { Deinstanciate( _copy ); }

                if( _copy.state == Resource_state.active )
                    { Deactivate( _copy ); }

                if( _copy.state == Resource_state.minimun )
                    { Unload( _copy ); }


                RESOURCE__complex_structure structure = _copy.structure;
    
                structure.copies[ _copy.RESOURCE_index ].copy = null;

                structure.module_complex_structures.manager.container_resources_complex_structures_copies.Return_complex_structure_copy( _copy );

                TOOL__resources_complex_structures.Update_resource_level_complex_structure( structure );

                // ** copy lost everything

                return; 
        } 



        // ** dados vao ser perdidos, mas a referencia da imagem volta 
        public static void Unload( RESOURCE__complex_structure_copy _copy ){


                Console.Log( "Veio Unload()" );
                
                if( _copy.state == Resource_state.nothing )
                    { Console.Log( "state menor" ); return; } // ** nao tem nada para remover

                Deactivate( _copy );
                _copy.state = Resource_state.nothing;
                
                
                if( _copy.actual_need_content == Resource_complex_structure_content.nothing )
                    {  return; } // ** nao tinha nada


                Destroy_game_object( ref _copy.structure_game_object );


                TOOL__resources_complex_structures.Change_actual_need_content_count(  _copy , Resource_complex_structure_content.nothing );



                // VAI ATUALIZAR O RECURSO ORIGINAL
                TOOL__resources_complex_structures.Update_resource_level_complex_structure( _copy.structure );
                TOOL__resources_complex_structures.Update_resource_level_complex_structure_COPY( _copy );

                return;


        }


        public static void Deactivate( RESOURCE__complex_structure_copy _copy ){

                // ** vai para o minimo

                Console.Log( "Veio Deactivate()" );

                if( ( _copy.state < Resource_state.active ) )
                    {  Console.Log( "state menor" ); return; } // ** nao tem recursos para remover

                Deinstanciate( _copy );
                _copy.state = Resource_state.minimun;

                
                if( _copy.actual_need_content != Resource_complex_structure_content.game_object )
                    { CONTROLLER__errors.Throw( $"a copy is marked as { _copy.state } but the resources is not teh isntance" ); }

                if( _copy.level_pre_allocation < Resource_complex_structure_content.game_object )
                    { Destroy_game_object( ref _copy.structure_game_object ); } // ** se o minimo for instncia nao vai chegar aqui


                TOOL__resources_complex_structures.Change_actual_need_content_count(  _copy ,_copy.level_pre_allocation );
                
                // VAI ATUALIZAR O RECURSO ORIGINAL
                TOOL__resources_complex_structures.Update_resource_level_complex_structure( _copy.structure );
                TOOL__resources_complex_structures.Update_resource_level_complex_structure_COPY( _copy );

                return;


        }

        private static void Destroy_game_object( ref GameObject _game_object_ref ){

                if( _game_object_ref != null )
                    { GameObject.Destroy( _game_object_ref ); _game_object_ref = null; }

        }



        public static void Deinstanciate( RESOURCE__complex_structure_copy _copy ){

                Console.Log( "Veio Deinstanciate()" );

                if( _copy.state < Resource_state.instanciated )
                    {  Console.Log( "state menor" ); return; }

                _copy.state = Resource_state.active;
                _copy.structure.module_complex_structures.manager.Put_in_waiting_container( _copy );

                return;

        }

        



        // --- UP

        // ** sinaliza que a imagem pode carregar o pre alloc
        public static void Load( RESOURCE__complex_structure_copy _copy ){


                Console.Log( "Veio Load()" );

                if( _copy.state >= Resource_state.minimun )
                    { return; }
                _copy.state = Resource_state.minimun;

                if( _copy.actual_need_content != Resource_complex_structure_content.nothing )
                    { CONTROLLER__errors.Throw( $"Tentou dar Load na copia { _copy.structure.complex_structure_key } mas o state estava como { _copy.state } mas o actua_need_content como nothing" ); }
                
                if( _copy.level_pre_allocation == Resource_complex_structure_content.nothing )
                    { return; } // ** dont need anything

                TOOL__resources_complex_structures.Change_actual_need_content_count(  _copy ,_copy.level_pre_allocation );
                
                TOOL__resources_complex_structures.Update_resource_level_complex_structure( _copy.structure );
                TOOL__resources_complex_structures.Update_resource_level_complex_structure_COPY( _copy );

                return;

        }

        public static void Activate( RESOURCE__complex_structure_copy _copy ){

                Console.Log( "Veio Activate()" );

                if( _copy.state >= Resource_state.active )
                    { return; } // ** already active
                _copy.state = Resource_state.active;
                
                if( _copy.actual_need_content == Resource_complex_structure_content.game_object )
                    { return; } // ** o minimo estava como o maximo


                TOOL__resources_complex_structures.Change_actual_need_content_count(  _copy ,Resource_complex_structure_content.game_object );

                _copy.Flag_need_to_instanciate( true );

                TOOL__resources_complex_structures.Update_resource_level_complex_structure( _copy.structure );
                TOOL__resources_complex_structures.Update_resource_level_complex_structure_COPY( _copy );

                return;


        }


        public static void Instanciate( RESOURCE__complex_structure_copy _copy, GameObject _container ){

                Console.Log( "Veio Instanciate()" );

                if( _copy.state == Resource_state.instanciated )
                    { return; } // ** ja instanciado

                _copy.state = Resource_state.instanciated;
                TOOL__resources_complex_structures.Change_actual_need_content_count(  _copy ,Resource_complex_structure_content.game_object );
                

                _copy.Flag_need_to_instanciate( false );

                
                RESOURCE__complex_structure structure = _copy.structure;
                if( structure == null )
                    { CONTROLLER__errors.Throw( "struct null" ); }


                // ** GURANTY PREFAB
                if( structure.actual_content < Resource_complex_structure_content.structure_data )
                    {
                        
                        structure.content_going_to = Resource_complex_structure_content.structure_data;
                        structure.actual_content = Resource_complex_structure_content.structure_data;
                        structure.stage_getting_resource = Resources_getting_complex_structure_stage.finished;

                        structure.prefab = Resources.Load<GameObject>( structure.resource_path );

                        Console.Log( "AAA: " + structure.resource_path );
                        
                    }

                // ** GURANTY STRUCTURE
                if( _copy.structure_game_object == null )
                    {
                        // --- FORCE INSTANCIATE
                        _copy.structure_game_object = GameObject.Instantiate( structure.prefab );
                        _copy.structure_game_object.name = structure.prefab.name;

                    }
                

                // ** set 
                GAME_OBJECT.Colocar_parent( _container, _copy.structure_game_object );
                _copy.structure_game_object.SetActive( true );

                return;
                
        }




}