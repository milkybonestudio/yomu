using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public static class TOOL__module_context_logics_actions {



        public static void Change_level_pre_allocation( RESOURCE__logic_ref _ref, Resource_logic_content _new_pre_alloc ){


                Console.Log( "Veio Change_pre_alloc()" );

                // --- CHANGE
                Resource_logic_content old_pre_alloc = _ref.level_pre_allocation;
                _ref.level_pre_allocation = _new_pre_alloc;

                if( _ref.state != Resource_state.minimun )
                    { return; } // ** nao vai importar

                if( old_pre_alloc == _new_pre_alloc )
                    { Console.Log( "Mesmo alloc" ); return; } // ** eh o mesmo

                // ** IS IN MINIMUN AND IS DIFERENT
                TOOL__resource_logic.Change_actual_content_count( _ref, _new_pre_alloc );
                
                TOOL__module_context_logics.Update_resource_level( _ref.logic );


        }


        public static MethodInfo Get_method_info( RESOURCE__logic_ref _ref ){


                RESOURCE__logic logic = _ref.logic;
                                
                if( _ref.state != Resource_state.instanciated )
                    { Instanciate( _ref  ); }

                return logic.method_info;

        }


        // --- DOWN

        // ** imagem vai ser deletada completamente 
        public static void Delete( RESOURCE__logic_ref _ref ){


                RESOURCE__logic logic = _ref.logic;

                // ** LOSE REF
                logic.need_reajust = true;
                logic.refs[ _ref.logic_slot_index ] = null;

                TOOL__resource_logic.Decrease_count( logic, _ref.actual_need_content ); 
                logic.module_logics.manager.container_logic_refs.Return_logic_ref( _ref );
                
                TOOL__module_context_logics.Update_resource_level( logic );
                
                return;

        } 

        
        public static void Unload( RESOURCE__logic_ref _ref ){

                // ** VAI PARA O NADA

                Console.Log( "Veio Unload()" );

                if( _ref.state == Resource_state.nothing )
                    { return; } _ref.state = Resource_state.nothing;

                if( _ref.actual_need_content == Resource_logic_content.nothing )
                    { return; }

                TOOL__resource_logic.Change_actual_content_count( _ref, Resource_logic_content.nothing );

                TOOL__module_context_logics.Update_resource_level( _ref.logic );

                return;            

        }

        public static void Deactivate( RESOURCE__logic_ref _ref ){

            // ** GO BACK TO MINIMUN

                // ** VAI PARA O NADA

                Console.Log( "Veio Deactivate()" );
                

                if( _ref.state <= Resource_state.minimun )
                    { return; } _ref.state = Resource_state.minimun;

                if( _ref.actual_need_content == _ref.level_pre_allocation )
                    { return; }

                TOOL__resource_logic.Change_actual_content_count( _ref, _ref.level_pre_allocation );

                TOOL__module_context_logics.Update_resource_level( _ref.logic );

                return;    


        }

        public static void Deinstanciate( RESOURCE__logic_ref _ref ){

            // ** FORCE TO GO TO activate if isntanciate

                Console.Log( "Veio Deinstanciate()" );
                

                if( _ref.state <= Resource_state.active )
                    { return; } _ref.state = Resource_state.active;

                if( _ref.actual_need_content == Resource_logic_content.method_info )
                    { return; }


                TOOL__resource_logic.Change_actual_content_count( _ref, _ref.level_pre_allocation );

                TOOL__module_context_logics.Update_resource_level( _ref.logic );

                return;    

        }



        // --- UP

        // ** sinaliza que a imagem pode carregar o minimo 
        public static void Load( RESOURCE__logic_ref _ref ){


                Console.Log( "Veio Load()" );
                

                Console.Log(  "_ref.state: " + _ref.state  );
                Console.Log(  "_ref.actual_need_content: " + _ref.actual_need_content  );

                if( _ref.state >= Resource_state.minimun )
                    { return; } _ref.state = Resource_state.minimun;

                if( _ref.actual_need_content >= _ref.level_pre_allocation )
                    { return; }

            
                TOOL__resource_logic.Change_actual_content_count( _ref, _ref.level_pre_allocation );

                TOOL__module_context_logics.Update_resource_level( _ref.logic );

                return;

        }

        // ** sinaliza que pode começar a pegar a texture
        public static void Activate( RESOURCE__logic_ref _ref ){


                Console.Log( "veio Activate()" );

                
                if( _ref.state >= Resource_state.active )
                    { return; } _ref.state = Resource_state.active;

                if( _ref.actual_need_content == Resource_logic_content.method_info )
                    { return; }


                TOOL__resource_logic.Change_actual_content_count( _ref, Resource_logic_content.method_info );
                TOOL__module_context_logics.Update_resource_level( _ref.logic );

                Console.Log( _ref.logic.actual_content );
                
                return;

        }

    

        public static void Instanciate( RESOURCE__logic_ref _ref ){

                // ** FORCE TO GET logic
                
                if( _ref.state == Resource_state.instanciated )
                    { return; } _ref.state = Resource_state.instanciated;

                RESOURCE__logic logic = _ref.logic;

                logic.stage_getting_resource = Resources_getting_logic_stage.finished;


                if( logic.actual_content == Resource_logic_content.nothing )
                    {
                        logic.method_info =  TOOL__resource_logic.Get_method_info( logic ); 
                        logic.actual_content = Resource_logic_content.method_info;
                    }

                if( logic.actual_content == Resource_logic_content.method_info )
                    { /*nada*/ }

                if( logic.method_info == null )
                    { CONTROLLER__errors.Throw( $"There was no image in the resources: { logic.logic_key }. Actual content: { logic.actual_content }" ); }
                                            

                TOOL__resource_logic.Change_actual_content_count( _ref, Resource_logic_content.method_info );

                return;

        }


        public static object Invoke( RESOURCE__logic_ref _ref,  object[] _args ){ 

            Debug.Log( "veio invoke" );

            Instanciate( _ref );

            object ret = null;

            try { 
                    ret = _ref.logic.method_info.Invoke( null, _args ); 
                } 
                catch( System.Exception e )
                { 
                    Debug.LogError( $"Problem in the class <Color=lightBlue>{ _ref.logic.class_name }</Color>, method <Color=lightBlue>{ _ref.logic.method_name }</Color>, asm <Color=lightBlue>{ _ref.module.context }</Color>" );
                    Console.Update();
                    CONTROLLER__errors.Throw_exception( e ); 
                }

            return ret;


        }



}