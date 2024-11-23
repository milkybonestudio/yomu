
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;


public class MODULE__context_complex_structures {


        public MODULE__context_complex_structures( MANAGER__resources_complex_structures _manager, Resource_context _context, int _initial_capacity, int _buffer_cache ){


                manager = _manager;

                context = _context;
                context_folder = _context.ToString();

                #if !!! UNITY_EDITOR
                    file_stream = FILE_STREAM.Criar_stream( _path, buffer_cache );
                #endif

                actives_complex_structures_dictionary = new Dictionary<string, RESOURCE__complex_structure>();
                actives_complex_structures_dictionary.EnsureCapacity( _initial_capacity );


        }

        public int Get_bytes(){ return 0; }

        private string context_folder;
        private Resource_context context;

        public MANAGER__resources_complex_structures manager;
        
        
        public Dictionary<string, RESOURCE__complex_structure> actives_complex_structures_dictionary;
        // public Dictionary<string, RESOURCE__complex_structure> actives_complex_structures_dictionary;
        




        public RESOURCE__complex_structure_copy Get_structure_copy(  string _main_folder, string _path_local,  Resource_complex_structure_content _level_pre_allocation  ){

                // --- GET RESOURCE
                
                RESOURCE__complex_structure structure = null;
                string path_structure = manager.container_resources_complex_structures.Get_complex_structure_key( _main_folder, _path_local );

                if( !!!( Get_dictionary( _main_folder ).TryGetValue( path_structure,  out structure ) ) )
                    { structure = Create_new_structure( _main_folder, _path_local, _level_pre_allocation ); }

                
                return Get_copy( structure, _level_pre_allocation ); // --- CREATE COPY
                
        }


        private RESOURCE__complex_structure Create_new_structure( string _main_folder, string _path_local, Resource_complex_structure_content _level_pre_allocation ){

                
                if( Application.isEditor )
                    { return Create_new_structure_EDITOR( _main_folder, _path_local, _level_pre_allocation ); }
                    else
                    { return Create_new_structure_BUILD( _main_folder, _path_local, _level_pre_allocation ); }


                // --- EDITOR
                RESOURCE__complex_structure Create_new_structure_EDITOR( string _main_folder, string _path_local, Resource_complex_structure_content _level_pre_allocation ){


                        // ** GET LOCATOR
                        //mark
                        // ** tem que fazer o parser depois
                        Complex_structure_locators locators = new Complex_structure_locators();
                        locators.current_complex_structure_local_path = _path_local;
                        string path_file_data = System.IO.Path.Combine( Application.dataPath, "Resources", context.ToString(), _main_folder, ( _path_local + "_DATA.txt") );

                        
                        RESOURCE__complex_structure new_structure = manager.container_resources_complex_structures.Get_resource_complex_structure( this, context, _main_folder, locators  );
                        
                        Get_dictionary( _main_folder ).Add( new_structure.complex_structure_key, new_structure );

                        return new_structure;

                }

                // --- BUILD
                RESOURCE__complex_structure Create_new_structure_BUILD( string _main_folder, string _path_local, Resource_complex_structure_content _level_pre_allocation ){

                    CONTROLLER__errors.Throw( "ainda tme que fazer" );
                    return null;

                }

        }


        private RESOURCE__complex_structure_copy Get_copy( RESOURCE__complex_structure _structure, Resource_complex_structure_content _copy_level_pre_allocation  ){

                
                // --- GET COPY
                RESOURCE__complex_structure_copy copy = manager.container_resources_complex_structures_copies.Get_resource_complex_structure_copy( _structure, _copy_level_pre_allocation );


                if( _structure.copies.Length == _structure.copies_pointer )
                    { Array.Resize( ref _structure.copies, ( _structure.copies.Length + 10 ) ); }

                copy.RESOURCE_index = _structure.copies_pointer;
                _structure.copies[ _structure.copies_pointer++ ].copy = copy;

                TOOL__resources_complex_structures.Increase_count( _structure, Resource_complex_structure_content.nothing );

                return copy;

        }








        // --- INTERNAL

        private Dictionary<string, RESOURCE__complex_structure> Get_dictionary( string _main_folder ){

                // ** por hora vai ter somentye 1 container então só vai ter 1 dicionario. 
                // ** depois cada _main_folder vai ter             

                return actives_complex_structures_dictionary;

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