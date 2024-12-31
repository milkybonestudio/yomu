using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEngine;



public class MODULE__context_logics {


        public MODULE__context_logics( MANAGER__resources_logics _manager, Resource_context _context, int _initial_capacity, int _buffer_cache ){

                
                context = _context;
                context_folder = _context.ToString();
                manager = _manager;

                #if !!! UNITY_EDITOR
                    file_stream = FILE_STREAM.Criar_stream( _path, buffer_cache );
                #endif

                actives_logics_dictionary = new Dictionary<string, RESOURCE__logic>();
                actives_logics_dictionary.EnsureCapacity( _initial_capacity );

                asm = Load_asm( _context );

        }


        private Assembly Load_asm( Resource_context _context ){

            Assembly assembly = null;

            // if( Application.isEditor )
            //     {

            //         try { assembly = Assembly.Load( _context.ToString() ); } 
            //             catch( Exception e ) 
            //             { CONTROLLER__errors.Throw( $"Could not find the dll of the context <Color=lightBlue>{ _context.ToString() }</Color>" ); }

            //         if( assembly == null )
            //             { CONTROLLER__errors.Throw( $"Could not find the dll of the context <Color=lightBlue>{ _context.ToString() }</Color>" ); };

            //     }
            //     else
            //     { 
            //         string path = System.IO.Path.Combine( Application.dataPath, ( _context.ToString() + ".dll" ) );

            //         try { assembly = Assembly.LoadFrom( path ); } 
            //             catch( Exception e ) 
            //             { CONTROLLER__errors.Throw( $"Could not find the dll of the context <Color=lightBlue>{ _context.ToString() }</Color>" ); }
            //     }

            return assembly;            

        }

        public int Get_bytes(){ return 0; }


        public string context_folder;
        public Resource_context context;

        public MANAGER__resources_logics manager;

        public FileStream file_stream;
        
        public Assembly asm;
        public Dictionary<string, RESOURCE__logic> actives_logics_dictionary;
    


        public RESOURCE__logic_ref Get_logic_ref(  string _class_name, string _method_name,  Resource_logic_content _level_pre_allocation  ){


                RESOURCE__logic logic = null;

                string key = ( _class_name + "_" + _method_name );

                // --- VERIFY IF logic ALREADY EXISTS
                if( !!!( actives_logics_dictionary.TryGetValue( key, out logic ) ) )
                    {  logic = Create_new_logic( _class_name, _method_name, key  );} 

                return Create_logic_ref( logic, _level_pre_allocation );
                    
        }



        private RESOURCE__logic Create_new_logic( string _class_name, string _method_name, string _key ){



                if( Application.isEditor )
                    { return Create_new_logic_EDITOR( _class_name, _method_name, _key ); }
                    else
                    { return Create_new_logic_BUILD( _class_name, _method_name, _key ); }



                // --- EDITOR
                RESOURCE__logic Create_new_logic_EDITOR( string _class_name, string _method_name, string _key ){


                        RESOURCE__logic logic = manager.container_logics.Get_resource_logic( this, context, _class_name, _method_name, _key );

                        actives_logics_dictionary.Add( logic.logic_key, logic );

                        return logic;

                }

                // --- BUILD
                RESOURCE__logic Create_new_logic_BUILD( string _class_name, string _method_name, string _key ){

                    
                        RESOURCE__logic logic = manager.container_logics.Get_resource_logic( this, context, _class_name, _method_name, _key );

                        actives_logics_dictionary.Add( logic.logic_key, logic );

                        return logic;

                }

        }




        private RESOURCE__logic_ref Create_logic_ref( RESOURCE__logic _logic, Resource_logic_content _level_pre_allocation ){


                RESOURCE__logic_ref logic_ref = manager.container_logic_refs.Get_resource_logic_ref( _logic, _level_pre_allocation );

                ARRAY.Guaranty_size( ref _logic.refs, _logic.refs_pointer, 1, 20 );

                // --- GURADA REF
                logic_ref.logic_slot_index = _logic.refs_pointer;
                _logic.refs[ _logic.refs_pointer++ ] = logic_ref;
                
                TOOL__resource_logic.Increase_count( _logic, Resource_logic_content.nothing );

                return logic_ref;

        }




        // --- INTERNAL

        private Dictionary<string, RESOURCE__logic> Get_dictionary( string _class_name ){

                // ** por hora vai ter somentye 1 container então só vai ter 1 dicionario. 
                // ** depois cada _class_name vai ter             

                return actives_logics_dictionary;

        }



}