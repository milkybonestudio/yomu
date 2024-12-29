using System.Reflection;
using UnityEngine;
using UnityEngine.UI;




public class RESOURCE__logic_ref {


        
        //public string localizador; // ** localizador local
        public string identifire;
        public RESOURCE__logic logic;
        

        public MODULE__context_logics module;
        public int logic_slot_index;

        public RESOURCE__logic_ref_state ref_state;

        public string ref_name;
        

        public Resource_state state;

        public Resource_logic_content level_pre_allocation; // minimun 
        public Resource_logic_content actual_need_content;





        public object Invoke( object[] _args ){ Guaranty_ref();  return TOOL__module_context_logics_actions.Invoke( this, _args );  }
    

        private void Guaranty_ref(){

                if( ref_state == RESOURCE__logic_ref_state.deleted )
                    { CONTROLLER__errors.Throw( $"Tried to use ref { ref_name } but the ref was deleted" ); } 
                if( ref_state == RESOURCE__logic_ref_state.no_instanciated )
                    { CONTROLLER__errors.Throw( $"Tried to use ref { ref_name } but the ref was not instanciated" ); } 
                if( logic == null )
                    { CONTROLLER__errors.Throw( $"Tried to use ref { identifire }, but the RESOURCE__logic is null"); }
        }

        // ** DOWN

        
        public void Delete( ref RESOURCE__logic_ref _ref_ref ){ if( ( _ref_ref.ref_name != ref_name ) ){ CONTROLLER__errors.Throw( "Not the same ref" ); } Guaranty_ref(); TOOL__module_context_logics_actions.Delete( this ); _ref_ref = null; } 
        public void Unload(){ Guaranty_ref(); TOOL__module_context_logics_actions.Unload( this ); }
        public void Deactivate(){ Guaranty_ref(); TOOL__module_context_logics_actions.Deactivate( this ); }
        public void Deinstanciate(){ Guaranty_ref(); TOOL__module_context_logics_actions.Deinstanciate( this );  }

        // ** UP

        public void Load(){ TOOL__module_context_logics_actions.Load( this ); }
        public void Activate(){ TOOL__module_context_logics_actions.Activate( this ); }
        public void Instanciate(){ TOOL__module_context_logics_actions.Instanciate( this ); }



        public void Activate_resource_action( Resource_action _action ){

            switch( _action ){

                // ** UP
                case Resource_action.load: Load(); break;
                case Resource_action.activate: Activate(); break;
                case Resource_action.instanciate: Instanciate(); break;

                case Resource_action.unload: Unload(); break;
                case Resource_action.deactivate: Deactivate(); break;
                case Resource_action.deinstanciate: Deinstanciate(); break;
                
            }

        }


    
        public void Change_level_pre_allocation( Resource_logic_content _new_pre_alloc ){ TOOL__module_context_logics_actions.Change_level_pre_allocation( this, _new_pre_alloc ); }
 

 
}



