using UnityEngine;
using UnityEngine.UI;




public class RESOURCE__audio_ref : RESOURCE__ref  {


        
        //public string localizador; // ** localizador local
        public string identifire;
        public RESOURCE__audio audio;

        public MODULE__context_audios module;
        public int audio_slot_index;

        public RESOURCE__audio_ref_state ref_state;

        public string ref_name;
        

        public Resource_audio_content level_pre_allocation; // minimum 
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

    public override bool Got_to_minimum(){

        return ( audio.actual_content == level_pre_allocation );
        
    }

    public override bool Got_to_full(){

        return ( audio.actual_content == Resource_audio_content.audio_clip );
    }


    public override void Delete(){ Guaranty_ref(); TOOL__module_context_audios_actions.Delete( this ); } 
        public override void Unload(){ Guaranty_ref(); TOOL__module_context_audios_actions.Unload( this ); }
        public override void Deactivate(){ Guaranty_ref(); TOOL__module_context_audios_actions.Deactivate( this ); }
        public override void Deinstanciate(){ Guaranty_ref(); TOOL__module_context_audios_actions.Deinstanciate( this );  }

        // ** UP

        public override void Load(){ TOOL__module_context_audios_actions.Load( this ); }
        public override void Activate(){ TOOL__module_context_audios_actions.Activate( this ); }
        public override void Instanciate(){ TOOL__module_context_audios_actions.Instanciate( this ); }



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


    
        public void Change_level_pre_allocation( Resource_audio_content _new_pre_alloc ){ TOOL__module_context_audios_actions.Change_level_pre_allocation( this, _new_pre_alloc ); }


 
}



