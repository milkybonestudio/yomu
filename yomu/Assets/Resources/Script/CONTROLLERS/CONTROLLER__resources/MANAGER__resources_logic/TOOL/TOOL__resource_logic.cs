using System;
using System.Reflection;
using UnityEngine;

public static class TOOL__resource_logic {




        public static MethodInfo Get_method_info( RESOURCE__logic _logic ){

                string _class_name = _logic.class_name;
                string _method_name = _logic.method_name;

                // ** talvez depois colocar na multithread
                //test
                // ** tem que ver se Assembly.LoadFrom funciona na multi

                Assembly asm = _logic.module_logics.asm;

                Type type = asm.GetType( _class_name );

                if( type == null )
                    { CONTROLLER__errors.Throw( $"Could not find the class <Color=lightBlue>{ _class_name }</Color> in the dll <Color=lightBlue>{ asm.GetName().Name }</Color>" ); }

                MethodInfo m_info = type.GetMethod( _method_name );

                if( m_info == null )
                    { CONTROLLER__errors.Throw( $"Could not find the method <Color=lightBlue>{ _method_name }</Color> in the class <Color=lightBlue>{ _class_name }</Color> in the dll <Color=lightBlue>{ asm.GetName().Name }</Color>" ); }

                if( m_info.Name == null )
                    { m_info = null; } // ** para forcar a pegar?

                return m_info;
                

        }


        public static void Verify_logic( RESOURCE__logic _logic ){ 
        
                return; 
                
        }
        public static bool Need_to_update( RESOURCE__logic _logic ){ return true; }


        public static int Down_resources( RESOURCE__logic _logic ){ 

                int weight = 0;
                
                if( _logic.content_going_to <= Resource_logic_content.nothing )
                    { weight += Destroy_method_info( _logic ); }
                
                return 0; 

        }

        private static int Destroy_method_info( RESOURCE__logic _logic ){

                if( _logic.actual_content < Resource_logic_content.method_info )
                    { return 0; }

                
                _logic.method_info = null;
                _logic.actual_content = Resource_logic_content.nothing;

                return 0;

        }


        public static void Verify_logic_ref ( RESOURCE__logic_ref logic_ref ){ return; }


        public static void Change_actual_content_count( RESOURCE__logic_ref _logic_ref, Resource_logic_content _new_content ){


                RESOURCE__logic logic = _logic_ref.logic;

                Resource_logic_content old_content = _logic_ref.actual_need_content;
                
                if( old_content == _new_content )
                    { return; }

                Increase_count( logic, _new_content );
                Decrease_count( logic, old_content );

                _logic_ref.actual_need_content = _new_content;

                return;

        }
        
        public static void Increase_count( RESOURCE__logic _logic, Resource_logic_content _content ){ Change( _logic, _content, 1 ); }
        public static void Decrease_count( RESOURCE__logic _logic, Resource_logic_content _content ){ Change( _logic, _content, -1 ); }


        public static void Change( RESOURCE__logic _logic, Resource_logic_content _content, int _value ){

                
                switch( _content ){

                    case Resource_logic_content.nothing: _logic.count_places_being_used_nothing += _value; return;
                    case Resource_logic_content.method_info: _logic.count_places_being_used_method_info += _value; return;
                    default: CONTROLLER__errors.Throw( $"Can not ahndle the content <Color=lightBlue>{ _content }</Color> in the logic { _logic.name }" ); return;
                    
                }

        }





        public static bool Verify_stage( RESOURCE__logic _logic, Resources_getting_logic_stage _stage ){

            return ( ( _logic.stage_getting_resource & _stage ) != 0 );

        }

    
        public static bool Verify_actual_content( RESOURCE__logic _logic, Resource_logic_content _content ){

            return ( ( _logic.actual_content & _content ) != 0 );

        }

    
        public static int Set_stage( RESOURCE__logic _logic,  Resources_getting_logic_stage _stage ){

            _logic.stage_getting_resource = _stage;
            return 0;

        }

        public static int Set_stage_cancelling_task( RESOURCE__logic _logic,  Resources_getting_logic_stage _stage, ref Task_req _task_ref ){

            _logic.stage_getting_resource = _stage;
            TASK_REQ.Cancel_task( ref _task_ref );
            return 0;

        }






}