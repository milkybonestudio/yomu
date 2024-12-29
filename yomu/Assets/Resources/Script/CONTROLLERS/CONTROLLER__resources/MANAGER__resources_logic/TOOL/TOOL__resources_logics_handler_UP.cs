using System;
using UnityEngine;


public static class TOOL__resources_logics_handler_UP {


        public static int Handle_waiting_to_start( MANAGER__resources_logics _manager, RESOURCE__logic _logic ){


                TOOL__resource_logic.Verify_logic( _logic );

                if( _logic.actual_content != Resource_logic_content.nothing )
                    { CONTROLLER__errors.Throw( $"the image { _logic.name } came to the Handle_waiting_to_start() but the actual content is { _logic.actual_content }" ); }

                int weight = 0;


                    _logic.stage_getting_resource = Resources_getting_logic_stage.finished;


                    if( _logic.content_going_to == Resource_logic_content.nothing )
                        {
                            _logic.actual_content = Resource_logic_content.nothing;
                            return weight; 
                        }


                    if( _logic.content_going_to == Resource_logic_content.method_info )
                        {
                            
                            _logic.method_info = TOOL__resource_logic.Get_method_info( _logic );
                            
                            _logic.actual_content = Resource_logic_content.method_info;
                            weight += 5;
                            return weight; 
                        }



                return CONTROLLER__errors.Throw( $"Could not handle content_going_to { _logic.content_going_to } of the logic { _logic.name }" );

        }


}