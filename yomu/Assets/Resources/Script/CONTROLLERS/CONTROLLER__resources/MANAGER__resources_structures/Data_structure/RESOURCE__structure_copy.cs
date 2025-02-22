

using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class RESOURCE__structure_copy : RESOURCE__ref {


        public int RESOURCE_index; 

        // ** trocar por estado ( use, unused, waitign to delete )
        public bool deleted;

        public RESOURCE__structure structure;

        public Resource_use_state ref_state; // trocar nome

        //test
        public Resource_structure_content actual_content;
        

        public Resource_state state;

        public Resource_structure_content level_pre_allocation; // minimun 
        public Resource_structure_content actual_need_content;

        
        public GameObject structure_game_object; // proprio



        // ** precisa ficar aqui, cada image tem um pointer diferente
        public Dictionary<string,Unity_main_components> components_dic;



        

        // --- SUPPORT
        
                private void Guaranty_copy(){ if( deleted ){ CONTROLLER__errors.Throw( $"Tried to use the structure copy <Color=white><b>{ name }</b></Color> but the copy was deleted" ); } }
                private void Guaranty_dic(){ if( actual_content < Resource_structure_content.game_object ){ CONTROLLER__errors.Throw( $"Tried to get a component in structure copy <Color=white><b>{ name }</b></Color> but the structure actual content is <Color=white><b>{ structure.actual_content }</b></Color>" ); } }
                private void Guaranty_instance(){ if( state < Resource_state.instanciated ){ CONTROLLER__errors.Throw( $"The structure copy <Color=white><b>{ name }</b></Color> was not instanciated" ); } }
                

        // --- RESOURCE

                // ** up resources
                public override void Load(){ Guaranty_copy(); TOOL__resource_structure_handler_ACTIONS.Load( this ); }
                public override void Activate(){ Guaranty_copy(); TOOL__resource_structure_handler_ACTIONS.Activate( this ); }

                // _container -> null -> continue no container structs
                // public RESOURCE__structure_copy Instanciate( GameObject _container = null, bool _set = true ){ TOOL__resource_structure_handler_ACTIONS.Instanciate( this, _container ); structure_game_object.SetActive( _set ); return this; }

                public GameObject Get_game_object( GameObject _container = null, bool _set = true ){ TOOL__resource_structure_handler_ACTIONS.Instanciate( this, _container ); structure_game_object.SetActive( _set ); return structure_game_object; }

                public override void Instanciate(){ TOOL__resource_structure_handler_ACTIONS.Instanciate( this, null ); structure_game_object.SetActive( true ); }
                public void Set( bool _set  ){ structure_game_object.SetActive( _set ); }

                // ** down resources

                public override void Unload(){ Guaranty_copy(); TOOL__resource_structure_handler_ACTIONS.Unload( this ); }
                public override void Deactivate(){ Guaranty_copy(); TOOL__resource_structure_handler_ACTIONS.Deactivate( this ); }
                public override void Deinstanciate(){ Guaranty_copy(); TOOL__resource_structure_handler_ACTIONS.Deinstanciate( this ); }

                public override void Delete(){ Guaranty_copy(); TOOL__resource_structure_handler_ACTIONS.Delete( this ); }
                
                // ** support resource
                public void Change_level_pre_allocation( Resource_structure_content _new_level ){  Guaranty_copy(); TOOL__resource_structure_handler_ACTIONS.Change_level_pre_allocation( this, _new_level );}
                public void Flag_need_to_instanciate( bool _value ){ structure.copies[ RESOURCE_index ].need_to_get_instanciate = _value; }

                public void Set_parent( GameObject _parent ){ Guaranty_copy(); Guaranty_instance(); structure_game_object.transform.SetParent( _parent.transform, false ); }


        // --- UTILITY

                public GameObject Get_component_game_object( string _component_key ){ Guaranty_copy(); Guaranty_dic(); return TOOL__resources_structures.Get_component_game_object( this, _component_key ); }
                public Image Get_component_image( string _component_key ){ Guaranty_copy(); Guaranty_dic(); return TOOL__resources_structures.Get_component_image( this, _component_key ); }
                public SpriteRenderer Get_component_sprite_render( string _component_key ){ Guaranty_copy(); Guaranty_dic(); return TOOL__resources_structures.Get_component_sprite_render( this, _component_key ); }

                public Unity_main_components Get_components( string _component_key ){ Guaranty_copy(); Guaranty_dic(); return TOOL__resources_structures.Get_components( this, _component_key ); }

                public override bool Got_to_minimun(){

                    // Console.Log( "actual_content: " + actual_content );
                    // Console.Log( "level_pre_allocation: " + level_pre_allocation );

                    return ( actual_content == level_pre_allocation );

                }



        


}