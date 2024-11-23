using UnityEngine;
using UnityEngine.UI;

public static class TOOL__resource_structure_handler_UP {

        public static int Handle_waiting_to_start( RESOURCE__structure _structure ){

                // ** mudar para o relogio talvez? 

                int weight = 0;

                if( _structure.content_going_to == Resource_structure_content.nothing )
                    { 
                        _structure.prefab = null;
                        _structure.actual_content = Resource_structure_content.nothing;
                        _structure.stage_getting_resource = Resources_getting_structure_stage.finished; 
                        return weight; 
                    }
                

                // ** MAXIMUN
                if( _structure.content_going_to == Resource_structure_content.structure_data )
                    {
                        
                        // --- PEGOU O PREFAB 
                        _structure.prefab = Resources.Load<GameObject>( _structure.resource_path );

                        CONTROLLER__errors.Verify( ( _structure.prefab == null ), $"Not found prefab <Color=lightBlue>{ _structure.resource_path }</Color>" );

                        _structure.actual_content = Resource_structure_content.structure_data;
                        weight = 3;

                        _structure.stage_getting_resource = Resources_getting_structure_stage.finished;
                        return weight;

                    }
                
                CONTROLLER__errors.Throw( $"Can not handle { _structure.content_going_to }" ); return -1;

        }


}
