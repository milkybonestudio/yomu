

using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class RESOURCE__structure_copy {


        public int RESOURCE_index; 

        public string name;

        // ** trocar por estado ( use, unused, waitign to delete )
        public bool deleted;

        public RESOURCE__structure structure;

        public Resource_use_state ref_state; // trocar nome


        public Resource_state state;

        public Resource_structure_content level_pre_allocation; // minimun 
        public Resource_structure_content actual_need_content;

        
        public GameObject structure_game_object; // proprio


        // ** precisa ficar aqui, cada image tem um pointer diferente
        public Dictionary<string,Unity_main_components> components_dic;




        // --- SUPPORT
        
                private void Guaranty_copy(){ if( deleted ){ CONTROLLER__errors.Throw( $"Tried to use the structure copy <Color=white><b>{ name }</b></Color> but the copy was deleted" ); } }
                private void Guaranty_dic(){ if( structure.actual_content < Resource_structure_content.game_object ){ CONTROLLER__errors.Throw( $"Tried to get a component in structure copy <Color=white><b>{ name }</b></Color> but the structure actual content is <Color=white><b>{ structure.actual_content }</b></Color>" ); } }
                private void Guaranty_field( ref RESOURCE__structure_copy _copy_ref ){ if( _copy_ref == null ){ CONTROLLER__errors.Throw( $"Tried to use the structure copy <Color=white><b>{ name }</b></Color> but the field was null" ); } }

        // --- RESOURCE

                // ** up resources
                public void Load(){ Guaranty_copy(); TOOL__resource_structure_handler_ACTIONS.Load( this ); }
                public void Activate(){ Guaranty_copy(); TOOL__resource_structure_handler_ACTIONS.Activate( this ); }
                public void Instanciate( GameObject _container ){ TOOL__resource_structure_handler_ACTIONS.Instanciate( this, _container ); }

                // ** down resources

                public void Unload(){ Guaranty_copy(); TOOL__resource_structure_handler_ACTIONS.Unload( this ); }
                public void Deactivate(){ Guaranty_copy(); TOOL__resource_structure_handler_ACTIONS.Deactivate( this ); }
                public void Deinstanciate(){ Guaranty_copy(); TOOL__resource_structure_handler_ACTIONS.Deinstanciate( this ); }

                public void Delete( ref RESOURCE__structure_copy _copy_ref ){ Guaranty_field( ref _copy_ref ); Guaranty_copy(); TOOL__resource_structure_handler_ACTIONS.Delete( this ); _copy_ref = null; }
                
                // ** support resource
                public void Change_level_pre_allocation( Resource_structure_content _new_level ){  Guaranty_copy(); TOOL__resource_structure_handler_ACTIONS.Change_level_pre_allocation( this, _new_level );}
                public void Flag_need_to_instanciate( bool _value ){ structure.copies[ RESOURCE_index ].need_to_get_instanciate = _value; }


        // --- UTILITY

                public GameObject Get_component_game_object( string _component_key ){ Guaranty_copy(); Guaranty_dic(); return TOOL__resources_structures.Get_component_game_object( this, _component_key ); }
                public Image Get_component_image( string _component_key ){ Guaranty_copy(); Guaranty_dic(); return TOOL__resources_structures.Get_component_image( this, _component_key ); }

                



        


}