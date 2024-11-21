
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;


public class MODULE__context_structures {


        public MODULE__context_structures( MANAGER__resources_structures _manager, Resource_context _context, int _initial_capacity, int _buffer_cache ){


                manager = _manager;

                context = _context;
                context_folder = _context.ToString();

                #if !!! UNITY_EDITOR
                    file_stream = FILE_STREAM.Criar_stream( _path, buffer_cache );
                #endif

                actives_structures_dictionary = new Dictionary<string, RESOURCE__structure>();
                actives_structures_dictionary.EnsureCapacity( _initial_capacity );


        }

        public int Get_bytes(){ return 0; }

        private string context_folder;
        private Resource_context context;

        public MANAGER__resources_structures manager;
        
        public Dictionary<string, RESOURCE__structure> actives_structures_dictionary;
        

        public RESOURCE__structure_copy Get_structure_copy(  string _main_folder, Structure_locators _locators, Resource_structure_content _level_pre_allocation  ){

                CONTROLLER__errors.Verify( ( _locators == null ), $"Sub_struct came null" );
                CONTROLLER__errors.Verify( ( _locators.main_struct_name == null ), $"Sub_struct doesnt has a name" );

                // --- GET RESOURCE
                
                if( !!!( Get_dictionary( _main_folder ).TryGetValue( Get_path( _main_folder, _locators.main_struct_name ),  out RESOURCE__structure structure ) ) )
                    { structure = Create_new_structure( _main_folder, _locators, _level_pre_allocation ); }

                
                return Get_copy( structure, _level_pre_allocation ); // --- CREATE COPY
                
        }


        private RESOURCE__structure Create_new_structure( string _main_folder, Structure_locators _locators, Resource_structure_content _level_pre_allocation ){


                RESOURCE__structure new_structure = new RESOURCE__structure( this, context, _main_folder, _locators );
                Get_dictionary( _main_folder ).Add( Get_path( _main_folder, _locators.main_struct_name ), new_structure );

                if( _locators.sub_structs == null )
                    { return new_structure; }

                // --- HAVE SUB STRUCTURES

                    new_structure.sub_structures = new RESOURCE__structure_copy[ _locators.sub_structs.Length ];
                    for( int index = 0 ; index < _locators.sub_structs.Length ; index++ ) 
                        { new_structure.sub_structures[ index ] = Get_structure_copy(  _main_folder, _locators.sub_structs[ index ], _level_pre_allocation  ); }

                return new_structure;

        }


        private RESOURCE__structure_copy Get_copy( RESOURCE__structure _structure, Resource_structure_content _copy_level_pre_allocation  ){

                
                // --- CREATE COPY 
                RESOURCE__structure_copy copy = new RESOURCE__structure_copy( _structure, _copy_level_pre_allocation, _structure.copies_pointer );

                TOOL__resources_structures.Increase_count( _structure, Resource_structure_content.nothing );

                if( _structure.copies.Length == _structure.copies_pointer )
                    { Array.Resize( ref _structure.copies, ( _structure.copies.Length + 10 ) ); }

                //Console.Log( $"a: { _structure.copies_pointer }" );

                _structure.copies[ _structure.copies_pointer++ ].copy = copy;

                // Console.Log( $"b: { _structure.copies_pointer }" );

                return copy;

        }









        public void Change_pre_alloc( RESOURCE__structure_copy _copy, Resource_structure_content _new_pre_alloc ){

                Console.Log( "Veio Change_pre_alloc()" );

                // --- CHANGE
                Resource_structure_content old_pre_alloc = _copy.level_pre_allocation;
                _copy.level_pre_allocation = _new_pre_alloc;

                Console.Log( "novo level: " + _copy.level_pre_allocation );


                if( _copy.state != Resource_state.minimun )
                    { return; } // ** nao vai importar



                if( old_pre_alloc == _new_pre_alloc )
                    { Console.Log( "Mesmo alloc" ); return; } // ** eh o mesmo

                // ** IS IN MINIMUN AND IS DIFERENT

                _copy.actual_need_content = _new_pre_alloc;

                RESOURCE__structure structure = _copy.structure;
        
                // ** so muda se estiver usando o minimo
                TOOL__resources_structures.Decrease_count( structure, old_pre_alloc );
                TOOL__resources_structures.Increase_count( structure, _new_pre_alloc );
                
                
                if( ( structure.stage_getting_resource != Resources_getting_structure_stage.finished ) && ( structure.stage_getting_resource != Resources_getting_structure_stage.waiting_to_start ) )  
                    { CONTROLLER__errors.Throw( "No" ); } // ** ARE IN TRANSITION


                // --- SIMPLE, NOT ON A RESOURCE TRANSITION

                if( old_pre_alloc == Resource_structure_content.game_object )
                    {
                        // ** REMOVE INSTANCE
                        if( _copy.structure_game_object != null )
                            { GameObject.Destroy( _copy.structure_game_object ); _copy.structure_game_object = null; }
                            else 
                            { structure.number_copies_need_to_get_instanciated--; } // ** tinha pedido apra instanciar mas nao foi instanciado. Agora nao precisa mais
                    }

                if( _new_pre_alloc == Resource_structure_content.game_object )
                    { structure.number_copies_need_to_get_instanciated++; }


                //?? 
                if( _new_pre_alloc > old_pre_alloc )
                    {            
                        // NEED TO GET NEW CONTENT
                        structure.stage_getting_resource = Resources_getting_structure_stage.waiting_to_start;
                        structure.content_going_to = _new_pre_alloc;
                    }

                // VAI ATUALIZAR O RECURSO ORIGINAL
                TOOL__resources_structures.Update_resource_level_structure( structure );

        }


        // --- DOWN

        public void Delete( RESOURCE__structure_copy _copy ){ 

                Console.Log( "Veio Delete()" );

                if( _copy.state == Resource_state.instanciated )
                    { Deinstanciate( _copy ); }

                if( _copy.state == Resource_state.active )
                    { Deactivate( _copy ); }

                if( _copy.state == Resource_state.minimun )
                    { Unload( _copy ); }


                RESOURCE__structure structure = _copy.structure;
                structure.copies_deleted++;
                structure.copies[ _copy.RESOURCE_index ].copy = null;
                _copy.structure = null;
                _copy.deleted = true;

                // ** copy lost everything

                return; 
        } 



        // ** dados vao ser perdidos, mas a referencia da imagem volta 
        public void Unload( RESOURCE__structure_copy _copy ){


                Console.Log( "Veio Unload()" );
                
                if( _copy.state == Resource_state.nothing )
                    { Console.Log( "state menor" ); return; } // ** nao tem nada para remover

                if( _copy.state == Resource_state.instanciated )
                    { Deinstanciate( _copy ); }

                if( _copy.state == Resource_state.active )
                    { Deactivate( _copy ); }

                _copy.state = Resource_state.nothing;
                
                
                RESOURCE__structure structure = _copy.structure;
            
                Resource_structure_content old_need_content = _copy.actual_need_content;
                Resource_structure_content new_need_content = Resource_structure_content.nothing;

                if( old_need_content == Resource_structure_content.nothing )
                    {  return; } // ** nao tinha nada


                _copy.actual_need_content = new_need_content;

                // ** VERIFY IF WAS INSTANCE
                if( _copy.structure_game_object == null && old_need_content == Resource_structure_content.game_object )
                    { structure.number_copies_need_to_get_instanciated--; } // ** tinha pedido apra instanciar mas nao foi instanciado. Agora nao precisa mais

                if( _copy.structure_game_object != null )
                    {
                        GameObject.Destroy( _copy.structure_game_object );
                        _copy.structure_game_object = null;
                    }


                
                TOOL__resources_structures.Decrease_count( structure, old_need_content );
                TOOL__resources_structures.Increase_count( structure, new_need_content );

                // VAI ATUALIZAR O RECURSO ORIGINAL
                TOOL__resources_structures.Update_resource_level_structure( structure );

                return;





        }

        public void Deactivate( RESOURCE__structure_copy _copy ){

                // ** vai para o minimo

                Console.Log( "Veio Deactivate()" );

                if( ( _copy.state < Resource_state.active ) )
                    {  Console.Log( "state menor" ); return; } // ** nao tem recursos para remover

                if( _copy.state == Resource_state.instanciated )
                    { Deinstanciate( _copy ); } // ** traz para o active

                _copy.state = Resource_state.minimun;

                RESOURCE__structure structure = _copy.structure;
            
                CONTROLLER__errors.Verify( ( _copy.actual_need_content != Resource_structure_content.game_object ), $"a copy is marked as { _copy.state } but the resources is not teh isntance" );

                if( _copy.level_pre_allocation < Resource_structure_content.game_object )
                    { Destroy_game_object( ref _copy.structure_game_object ); } // ** se o minimo for instncia nao vai chegar aqui


                TOOL__resources_structures.Change_actual_content_count(  _copy ,_copy.level_pre_allocation );
                
                // VAI ATUALIZAR O RECURSO ORIGINAL
                TOOL__resources_structures.Update_resource_level_structure( structure );
                TOOL__resources_structures.Update_resource_level_structure_COPY( _copy.structure );

                return;


        }

        private void Destroy_game_object( ref GameObject _game_object_ref ){

                if( _game_object_ref != null )
                    { GameObject.Destroy( _game_object_ref ); _game_object_ref = null; }

        }



        public void Deinstanciate( RESOURCE__structure_copy _copy ){

                Console.Log( "Veio Deinstanciate()" );

                if( _copy.state < Resource_state.instanciated )
                    {  Console.Log( "state menor" ); return; }

                _copy.state = Resource_state.active;
                manager.Put_in_waiting_container( _copy );

                return;

        }

        



        // --- UP

        // ** sinaliza que a imagem pode carregar o pre alloc
        public void Load( RESOURCE__structure_copy _copy ){


                Console.Log( "Veio Load()" );

                if( _copy.state >= Resource_state.minimun )
                    { return; }
                _copy.state = Resource_state.minimun;

                CONTROLLER__errors.Verify( ( _copy.actual_need_content != Resource_structure_content.nothing ), $"Tentou dar Load na copia { _copy.structure.locators.main_struct_name } mas o state estava como { _copy.state } mas o actua_need_content como nothing" );
                
                if( _copy.level_pre_allocation == Resource_structure_content.nothing )
                    { return; } // ** dont need anything

                TOOL__resources_structures.Change_actual_content_count(  _copy ,_copy.level_pre_allocation );
                
                TOOL__resources_structures.Update_resource_level_structure( _copy.structure );
                TOOL__resources_structures.Update_resource_level_structure_COPY( _copy.structure );

                return;

        }

        public void Activate( RESOURCE__structure_copy _copy ){

                Console.Log( "Veio Activate()" );

                if( _copy.state >= Resource_state.active )
                    { return; } // ** already active
                _copy.state = Resource_state.active;
                
                if( _copy.actual_need_content == Resource_structure_content.game_object )
                    { return; } // ** o minimo estava como o maximo


                TOOL__resources_structures.Change_actual_content_count(  _copy ,Resource_structure_content.game_object );

                _copy.Flag_need_to_instanciate( true );

                TOOL__resources_structures.Update_resource_level_structure( _copy.structure );

                return;


        }


        public void Instanciate( RESOURCE__structure_copy _copy, GameObject _container ){

                Console.Log( "Veio Instanciate()" );

                if( _copy.state == Resource_state.instanciated )
                    { return; } // ** ja instanciado

                _copy.state = Resource_state.instanciated;
                TOOL__resources_structures.Change_actual_content_count(  _copy ,Resource_structure_content.game_object );

                _copy.Flag_need_to_instanciate( false );

                
                RESOURCE__structure structure = _copy.structure;


                // ** GURANTY PREFAB
                if( structure.actual_content < Resource_structure_content.structure_data )
                    {
                        
                        structure.content_going_to = Resource_structure_content.structure_data;
                        structure.actual_content = Resource_structure_content.structure_data;
                        structure.stage_getting_resource = Resources_getting_structure_stage.finished;

                        structure.prefab = Resources.Load<GameObject>( structure.resource_path );

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


        // --- INTERNAL

        private Dictionary<string, RESOURCE__structure> Get_dictionary( string _main_folder ){

                // ** por hora vai ter somentye 1 container então só vai ter 1 dicionario. 
                // ** depois cada _main_folder vai ter             

                return actives_structures_dictionary;

        }





        #if UNITY_EDITOR

            private string Get_path_file( string _main_folder, string _path ){

                    return Path.Combine( Application.dataPath, "Resources", context_folder, _main_folder,  ( _path + ".png") ) ;     

            }

            private string Get_folder_file( string _main_folder, string _path ){

                return Directory.GetParent( Get_path_file(_main_folder, _path) ).FullName;

            }


        #endif

    
        private string Get_path( string _main_folder, string _name ){ 

                // ** quando for expandir vai ser somente o _path porque vai ter 1 dic para cada main_folder
                return ( _main_folder + "\\" + _name );

        } 

}