using UnityEngine;

public static class TOOL__module_context_logics {


        public static void Update_resource_level( RESOURCE__logic _logic ){


                Console.Log( "veio: { Update_resource_level }" );

                Verify_stage_for_content( _logic );

                if( _logic.count_places_being_used_nothing > 0 )
                    { Going_to_resource_level_NOTHING( _logic ); return; }

                if( _logic.count_places_being_used_method_info > 0 )
                    { Going_to_resource_level_logic_METHOD_INFO( _logic ); return; }


                // ** DELETE LOGIC
                
                _logic.module_logics.actives_logics_dictionary.Remove( _logic.logic_key ); // ** nao tem mais update
                _logic.module_logics.manager.container_logics.Return_logic( _logic ); 
                
         
        }

        
        private static int Going_to_resource_level_NOTHING( RESOURCE__logic _logic ){

                Console.Log( "Veio Going_to_resource_level_NOTHING()" );

                if( _logic.content_going_to == Resource_logic_content.nothing )
                    { return 0; } // ** ja nivelado
                    
                _logic.content_going_to = Resource_logic_content.nothing;


                // --- UP                
                // --- EQUAL
                // --- DOWN


                return TOOL__resource_logic.Down_resources( _logic );

        }

        private static int Going_to_resource_level_logic_METHOD_INFO( RESOURCE__logic _logic ){

                Console.Log( "Veio Going_to_resource_level_logic_CLIP()" );

                
                if( _logic.content_going_to == Resource_logic_content.method_info )
                    { return 0; } // ** ja nivelado
                _logic.content_going_to = Resource_logic_content.method_info;

                Console.Log( _logic.actual_content );


                // --- UP 
                    if( _logic.actual_content == Resource_logic_content.nothing )
                        { 
                            _logic.stage_getting_resource = Resources_getting_logic_stage.waiting_to_start;
                            return 0;  
                        }

                // --- EQUAL

                    if( _logic.actual_content == Resource_logic_content.method_info )
                        { return 0; }

                // --- DOWN

                return TOOL__resource_logic.Down_resources( _logic );

        }
        


        private static void Verify_stage_for_content( RESOURCE__logic _logic ){


                Resources_getting_logic_stage possible_stages = Resources_getting_logic_stage.not_give;

                switch( _logic.actual_content ){

                    case Resource_logic_content.nothing: possible_stages = Resources_getting_logic_stage.nothing_acceptable_stages; break;
                    case Resource_logic_content.method_info: possible_stages = Resources_getting_logic_stage.method_acceptable_stages; break;
                    
                }

                if( !!!( TOOL__resource_logic.Verify_stage( _logic, possible_stages ) ) )
                    { CONTROLLER__errors.Throw( $"Image { _logic.name } is with content { _logic.actual_content } but the stage is { _logic.stage_getting_resource }" ); }
                    
                return;

        }


}