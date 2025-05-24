using UnityEngine;

public static class TOOL__resource_structure_handler_ACTIONS {





        //mark
        // ** depois passar para tool__actions



        public static void Change_level_pre_allocation( RESOURCE__structure_copy _copy, Resource_structure_content _new_pre_alloc ){


                if( _copy.level_pre_allocation == _new_pre_alloc )
                    { return; } // --- SAME LEVEL

                _copy.level_pre_allocation = _new_pre_alloc;


                if( _copy.state != Resource_state.minimum )
                    { return; } // nao muda nada

                TOOL__resources_structures.Change_actual_need_content_count( _copy, _copy.level_pre_allocation );
                
    
                // VAI ATUALIZAR O RECURSO ORIGINAL
                TOOL__resources_structures.Update_resource_level_structure( _copy.structure );
                TOOL__resources_structures.Update_resource_level_structure_COPY( _copy );

        }


        // --- DOWN

        public static void Delete( RESOURCE__structure_copy _copy ){ 

                
                if( _copy.state == Resource_state.instanciated )
                    { Deinstanciate( _copy ); }

                if( _copy.state == Resource_state.active )
                    { Deactivate( _copy ); }

                if( _copy.state == Resource_state.minimum )
                    { Unload( _copy ); }


                RESOURCE__structure structure = _copy.structure;
    
                structure.copies[ _copy.RESOURCE_index ].copy = null;

                structure.module_structures.manager.container_resources_structures_copies.Return_structure_copy( _copy );

                TOOL__resources_structures.Update_resource_level_structure( structure );

                // ** copy lost everything

                return; 
        } 



        // ** dados vao ser perdidos, mas a referencia da imagem volta 
        public static void Unload( RESOURCE__structure_copy _copy ){

                
                if( _copy.state == Resource_state.nothing )
                    { return; } // ** nao tem nada para remover

                Deactivate( _copy );
                _copy.state = Resource_state.nothing;
                
                
                if( _copy.actual_need_content == Resource_structure_content.nothing )
                    {  return; } // ** nao tinha nada


                Destroy_game_object( ref _copy.structure_game_object );


                TOOL__resources_structures.Change_actual_need_content_count(  _copy , Resource_structure_content.nothing );



                // VAI ATUALIZAR O RECURSO ORIGINAL
                TOOL__resources_structures.Update_resource_level_structure( _copy.structure );
                TOOL__resources_structures.Update_resource_level_structure_COPY( _copy );

                return;


        }


        public static void Deactivate( RESOURCE__structure_copy _copy ){

                // ** vai para o minimo

                if( ( _copy.state < Resource_state.active ) )
                    { return; } // ** nao tem recursos para remover

                Deinstanciate( _copy );
                _copy.state = Resource_state.minimum;

                
                if( _copy.actual_need_content != Resource_structure_content.game_object )
                    { CONTROLLER__errors.Throw( $"a copy is marked as { _copy.state } but the resources is not teh isntance" ); }

                if( _copy.level_pre_allocation < Resource_structure_content.game_object )
                    { Destroy_game_object( ref _copy.structure_game_object ); } // ** se o minimo for instncia nao vai chegar aqui


                TOOL__resources_structures.Change_actual_need_content_count(  _copy ,_copy.level_pre_allocation );
                
                // VAI ATUALIZAR O RECURSO ORIGINAL
                TOOL__resources_structures.Update_resource_level_structure( _copy.structure );
                TOOL__resources_structures.Update_resource_level_structure_COPY( _copy );

                return;


        }

        private static void Destroy_game_object( ref GameObject _game_object_ref ){

                if( _game_object_ref != null )
                    { GameObject.Destroy( _game_object_ref ); _game_object_ref = null; }

        }



        public static void Deinstanciate( RESOURCE__structure_copy _copy ){

                
                if( _copy.state < Resource_state.instanciated )
                    { return; }

                _copy.state = Resource_state.active;
                _copy.structure.module_structures.manager.Put_in_waiting_container( _copy );

                return;

        }

        



        // --- UP

        // ** sinaliza que a imagem pode carregar o pre alloc
        public static void Load( RESOURCE__structure_copy _copy ){


                if( _copy.state >= Resource_state.minimum )
                    { return; } _copy.state = Resource_state.minimum;

                if( _copy.actual_need_content != Resource_structure_content.nothing )
                    { CONTROLLER__errors.Throw( $"Tentou dar Load na copia { _copy.structure.structure_key } mas o state estava como { _copy.state } mas o actua_need_content como nothing" ); }
                
                if( _copy.level_pre_allocation == Resource_structure_content.nothing )
                    { return; } // ** dont need anything

                TOOL__resources_structures.Change_actual_need_content_count(  _copy ,_copy.level_pre_allocation );
                
                TOOL__resources_structures.Update_resource_level_structure( _copy.structure );
                TOOL__resources_structures.Update_resource_level_structure_COPY( _copy );

                return;

        }

        public static void Activate( RESOURCE__structure_copy _copy ){

                
                if( _copy.state >= Resource_state.active )
                    { return; } // ** already active

                _copy.state = Resource_state.active;
                
                if( _copy.actual_need_content == Resource_structure_content.game_object )
                    { return; } // ** o minimo estava como o maximo


                TOOL__resources_structures.Change_actual_need_content_count(  _copy ,Resource_structure_content.game_object );

                _copy.Flag_need_to_instanciate( true );

                TOOL__resources_structures.Update_resource_level_structure( _copy.structure );
                TOOL__resources_structures.Update_resource_level_structure_COPY( _copy );

                return;


        }






        public static void Instanciate( RESOURCE__structure_copy _copy, GameObject _container ){


                if( _copy.place_to_instanciate == null )
                    { CONTROLLER__errors.Throw( $"Tried to isntanciate the structure <Color=lightBlue>{ _copy.name }</Color> but the <Color=lightBlue>place_to_instanciate was null</Color>" ); }

                
                //mark
                // ** esse vai ser chamado quando a copia precisar ser instanciada na hora

                if( _copy.state == Resource_state.instanciated )
                    { return; } // ** ja instanciado


                _copy.state = Resource_state.instanciated;
                TOOL__resources_structures.Change_actual_need_content_count(  _copy ,Resource_structure_content.game_object );
                

                _copy.Flag_need_to_instanciate( false );

                
                RESOURCE__structure structure = _copy.structure;

                if( structure == null )
                    { CONTROLLER__errors.Throw( "struct null" ); }


                // ** GURANTY PREFAB
                if( structure.actual_content < Resource_structure_content.structure_data )
                    {
                        
                        structure.prefab = Resources.Load<GameObject>( structure.resource_path );

                        structure.content_going_to = Resource_structure_content.structure_data;
                        structure.actual_content = Resource_structure_content.structure_data;
                        structure.stage_getting_resource = Resources_getting_structure_stage.finished;
                        
                    }

                // ** GURANTY STRUCTURE
                if( _copy.actual_content < Resource_structure_content.game_object )
                    {
                        // --- FORCE INSTANCIATE
                        _copy.structure_game_object = GameObject.Instantiate( structure.prefab );
                        _copy.structure_game_object.name = structure.prefab.name;
                        _copy.actual_content = Resource_structure_content.game_object;
                        //mark
                        // ** porque o dicionario esta sendo criado na copia e não no generico?
                        // ** tem se algo vor movido ele troca no dicionario?
                        TOOL__resources_structures.Create_dictionary( _copy );

                    }
                


                // ** set 
                // ** null -> nao pode parecer -> default

                if( _container == null )
                    { _container = structure.module_structures.manager.container_to_instanciate; }

                GAME_OBJECT.Colocar_parent( _copy.place_to_instanciate, _copy.structure_game_object );
                _copy.structure_game_object.SetActive( true );

                return;
                
        }



        //test

        // public static void Instanciate( RESOURCE__structure_copy _copy, GameObject _container ){


        //         if( _copy.state == Resource_state.instanciated )
        //             { return; } // ** ja instanciado

        //         _copy.state = Resource_state.instanciated;
        //         TOOL__resources_structures.Change_actual_need_content_count(  _copy ,Resource_structure_content.game_object );
                

        //         _copy.Flag_need_to_instanciate( false );

                
        //         RESOURCE__structure structure = _copy.structure;

        //         if( structure == null )
        //             { CONTROLLER__errors.Throw( "struct null" ); }


        //         // ** GURANTY PREFAB
        //         if( structure.actual_content < Resource_structure_content.structure_data )
        //             {
                        
        //                 structure.prefab = Resources.Load<GameObject>( structure.resource_path );

        //                 structure.content_going_to = Resource_structure_content.structure_data;
        //                 structure.actual_content = Resource_structure_content.structure_data;
        //                 structure.stage_getting_resource = Resources_getting_structure_stage.finished;
                        
        //             }

        //         // ** GURANTY STRUCTURE
        //         if( structure.actual_content < Resource_structure_content.game_object )
        //             {
        //                 // --- FORCE INSTANCIATE
        //                 _copy.structure_game_object = GameObject.Instantiate( structure.prefab );
        //                 structure.actual_content = Resource_structure_content.game_object;
        //                 _copy.structure_game_object.name = structure.prefab.name;
        //                 TOOL__resources_structures.Create_dictionary( _copy );

        //             }
                


        //         // ** set 
        //         // ** null -> nao pode parecer -> default

        //         if( _container == null )
        //             { _container = structure.module_structures.manager.container_to_instanciate; }

        //         GAME_OBJECT.Colocar_parent( _container, _copy.structure_game_object );
        //         _copy.structure_game_object.SetActive( true );

        //         return;
                
        // }




}