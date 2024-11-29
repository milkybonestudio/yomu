using UnityEngine;
using UnityEngine.UI;




public class RESOURCE__audio_ref {


        
        //public string localizador; // ** localizador local
        public string identifire;
        public RESOURCE__audio audio;

        public MODULE__context_audios module;
        public int audio_slot_index;

        public RESOURCE__audio_ref_state ref_state;

        public string ref_name;
        

        public Resource_state state;

        public Resource_audio_content level_pre_allocation; // minimun 
        public Resource_audio_content actual_need_content;




        public AudioClip Get_audio_clip(){ Guaranty_ref(); return TOOL__module_context_audios_actions.Get_audio_clip( this );  }
    

        private void Guaranty_ref(){
                if( ref_state == RESOURCE__audio_ref_state.deleted )
                    { CONTROLLER__errors.Throw( $"Tried to use ref { ref_name } but the ref was deleted" ); } 
                if( ref_state == RESOURCE__audio_ref_state.no_instanciated )
                    { CONTROLLER__errors.Throw( $"Tried to use ref { ref_name } but the ref was not instanciated" ); } 
                if( audio == null )
                    { CONTROLLER__errors.Throw( $"Tried to use ref { identifire }, but the RESOURCE__audio is null"); }
        }

        // ** DOWN

        
        public void Delete( ref RESOURCE__audio_ref _ref_ref ){ if( ( _ref_ref.ref_name != ref_name ) ){ CONTROLLER__errors.Throw( "Not the same ref" ); } Guaranty_ref(); TOOL__module_context_audios_actions.Delete( this ); _ref_ref = null; } 
        public void Unload(){ Guaranty_ref(); TOOL__module_context_audios_actions.Unload( this ); }
        public void Deactivate(){ Guaranty_ref(); TOOL__module_context_audios_actions.Deactivate( this ); }
        public void Deinstanciate(){ Guaranty_ref(); TOOL__module_context_audios_actions.Deinstanciate( this );  }

        // ** UP

        public void Load(){ TOOL__module_context_audios_actions.Load( this ); }
        public void Activate(){ TOOL__module_context_audios_actions.Activate( this ); }
        public void Instanciate(){ TOOL__module_context_audios_actions.Instanciate( this ); }



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


    
        public void Change_level_pre_allocation( Resource_audio_content _new_pre_alloc ){}


 
}



