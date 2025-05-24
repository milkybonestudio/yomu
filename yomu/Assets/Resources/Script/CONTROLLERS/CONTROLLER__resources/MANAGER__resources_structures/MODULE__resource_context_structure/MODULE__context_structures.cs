
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
        // public Dictionary<string, RESOURCE__structure> actives_structures_dictionary;
        




        public RESOURCE__structure_copy Get_structure_copy(  string _main_folder, string _path_local,  Resource_structure_content _level_pre_allocation  ){

                // --- GET RESOURCE

                // RESOURCE__structure structure = null;
                string path_structure = Get_structure_key( _main_folder, _path_local );
                
                if( !!!( Get_dictionary( _main_folder ).TryGetValue( path_structure,  out RESOURCE__structure structure ) ) )
                    { structure = Create_new_structure( _main_folder, _path_local, _level_pre_allocation ); }


                return Get_copy( structure, _level_pre_allocation ); // --- CREATE COPY
                
        }

        private string Get_structure_key( string _main_folder, string _path_local ){

            #if UNITY_EDITOR
                if( _main_folder == null )
                    { return _path_local; }
            #endif

            return $"{ _main_folder }\\{ _path_local }";
        }




        private void Put_data_structure( RESOURCE__structure _structure,  Resource_context _context,  string _main_folder, Structure_locators _locator ){

                // ** structure DATA
                
                _structure.main_folder = _main_folder;
                
                _structure.structure_context = _context; 
                _structure.structure_key = Get_structure_key( _main_folder, _locator.current_structure_local_path );
                _structure.module_structures = this;
                _structure.locators = _locator;

                _structure.resource_path = ( _context.ToString() + "\\" + _main_folder + "\\" + _locator.current_structure_local_path );



                _structure.stage_getting_resource = Resources_getting_structure_stage.finished;
                _structure.actual_content = Resource_structure_content.nothing;
                _structure.content_going_to = Resource_structure_content.nothing;
                

            
        }


        
        private void Force_game_object_for_testing( RESOURCE__structure _structure, string _path_local ){

                _structure.stage_getting_resource = Resources_getting_structure_stage.finished;
                _structure.actual_content = Resource_structure_content.structure_data;
                _structure.content_going_to = Resource_structure_content.structure_data;

                _structure.module_structures = this;

                _structure.structure_key = Get_structure_key( null, _path_local );

                _structure.prefab = GameObject.Find( _path_local );

                if( _structure.prefab == null )
                    { CONTROLLER__errors.Throw( $"Tryied to get a structure in the world for testing, but it was not found in the path <Color=lightBlue>{ _path_local }</Color>" ); }

        }




        private RESOURCE__structure Create_new_structure( string _main_folder, string _path_local, Resource_structure_content _level_pre_allocation ){

                if( Application.isEditor )
                    { return Create_new_structure_EDITOR( _main_folder, _path_local, _level_pre_allocation ); }
                    else
                    { return Create_new_structure_BUILD( _main_folder, _path_local, _level_pre_allocation ); }


                // --- EDITOR
                RESOURCE__structure Create_new_structure_EDITOR( string _main_folder, string _path_local, Resource_structure_content _level_pre_allocation ){


                        // ** GET LOCATOR
                        //mark
                        // ** tem que fazer o parser depois
                        Structure_locators locators = new Structure_locators();
                        locators.current_structure_local_path = _path_local;
                        
                        RESOURCE__structure new_structure = Containers.structure.Get();
                        new_structure.structure_state = Resource_use_state.used;


                        if( ( _main_folder == "" ) || ( _main_folder == null ) )
                            {
                                // ** O OBJETO ESTA NO CAMPO, NAO VAI PROCURAR O PREFAB

                                // ** o path_local pode ser somente o nome do arquivo, não precisa ser o path completo
                                Force_game_object_for_testing( new_structure, _path_local );
                                Get_dictionary( _main_folder ).Add( new_structure.structure_key, new_structure );
                                // ** cria uma copia que sempre vai deixar a structure como 
                                Get_structure_copy( _main_folder, _path_local, Resource_structure_content.structure_data );
                                
                            }
                            else
                            {
                                
                                // ** O OBJETO ESTA EM UM PREFAB
                                Put_data_structure( new_structure, context, _main_folder, locators );

                                if(  Resources.Load<GameObject>( new_structure.resource_path ) == null )
                                    { CONTROLLER__errors.Throw( $"Could not find the prefab in the path: <Color=lightBlue>{ new_structure.resource_path }</Color>" ); }

                                Get_dictionary( _main_folder ).Add( new_structure.structure_key, new_structure );
                            }

                        


                        if( locators.sub_structs == null )
                            { return new_structure; }

                        // --- HAVE SUB STRUCTURES

                            new_structure.sub_structures = new RESOURCE__structure_copy[ locators.sub_structs.Length ];
                            for( int index = 0 ; index < locators.sub_structs.Length ; index++ ) 
                                { new_structure.sub_structures[ index ] = Get_structure_copy(  _main_folder, locators.sub_structs[ index ].current_structure_local_path, _level_pre_allocation ); }

                        return new_structure;

                }
                

                // --- BUILD
                RESOURCE__structure Create_new_structure_BUILD( string _main_folder, string _path_local, Resource_structure_content _level_pre_allocation ){


                    //performance
                    // ** teria como pegar os dados das structures e passar para um .data ou .txt pegar os dados na hora levaria bem mais tmepo.
                    // ** seria algo como "botoes:001botoes/botao_1:001"
                    // ** ou seja path_game_object : components
                    // ** o jeito que é feito agora é um horror
                    // ** mas fazer desse jeito tem a desvantagem que teria que carregar o .txt com as informaçoes
                    // ** poderia deixar o mais compactado possivel e colocar em um grande container
                    // ** poderia separar em "structure_name::{ info }structure_name::{ info }..."
                    // ** depois fazer o trim quando o jogo pedir e guardar o dicionario


                    CONTROLLER__errors.Throw( "ainda tme que fazer" );
                    return null;

                }

        }


        private RESOURCE__structure_copy Get_copy( RESOURCE__structure _structure, Resource_structure_content _copy_level_pre_allocation  ){

                

                // --- GET COPY
                RESOURCE__structure_copy copy = manager.container_resources_structures_copies.Get_resource_structure_copy( _structure, _copy_level_pre_allocation );

                //test
                    copy.place_to_instanciate = manager.container_to_instanciate;
                //test

                // copy.actual_content = Resource_structure_content.nothing;



                if( _structure.copies.Length == _structure.copies_pointer )
                    { Array.Resize( ref _structure.copies, ( _structure.copies.Length + 10 ) ); }

                copy.RESOURCE_index = _structure.copies_pointer;
                _structure.copies[ _structure.copies_pointer++ ].copy = copy;

                
                TOOL__resources_structures.Increase_count( _structure, Resource_structure_content.nothing );

                return copy;

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