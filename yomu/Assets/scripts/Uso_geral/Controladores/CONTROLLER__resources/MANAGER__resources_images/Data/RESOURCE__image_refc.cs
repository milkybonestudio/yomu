using UnityEngine;
using UnityEngine.UI;




public class RESOURCE__image_ref {

        
        public string localizador; // ** localizador local
        public string identifire;
        public RESOURCE__image image;
        public Image image_component;
        public MODULE__context_images module;
        public int image_slot_index;

        public RESOURCE__image_ref_state ref_state;
        

        public Resource_state state;

        public Resource_image_content level_pre_allocation; // minimun 
        public Resource_image_content actual_need_content;



        public Sprite Get_sprite(){ Guaranty_ref(); return TOOL__module_context_images_actions.Get_sprite( this );  }
    

        private void Guaranty_ref(){ if( ref_state == RESOURCE__image_ref_state.deleted ){ CONTROLLER__errors.Throw( $"Tried to use ref { localizador } but the ref was deleted" ); } if( ref_state == RESOURCE__image_ref_state.no_instanciated ){ CONTROLLER__errors.Throw( $"Tried to use ref { localizador } but the ref was not instanciated" ); } }

        // ** DOWN

        
        public void Delete( ref RESOURCE__image_ref _ref_ref ){ Guaranty_ref(); TOOL__module_context_images_actions.Delete( this ); _ref_ref = null; } 
        public void Unload(){ Guaranty_ref(); TOOL__module_context_images_actions.Unload( this ); }
        public void Deactivate(){ Guaranty_ref(); TOOL__module_context_images_actions.Deactivate( this ); }
        public void Deinstanciate(){ Guaranty_ref(); TOOL__module_context_images_actions.Deinstanciate( this );  }

        // ** UP

        public void Load(){ TOOL__module_context_images_actions.Load( this ); }
        public void Activate(){ TOOL__module_context_images_actions.Activate( this ); }
        public void Instanciate(){ TOOL__module_context_images_actions.Instanciate( this ); }

    
        public void Change_level_pre_allocation( Resource_image_content _new_pre_alloc ){ Guaranty_ref(); TOOL__module_context_images_actions.Change_level_pre_allocation( this, _new_pre_alloc ); }


 
}




public class Image_container {


        public RESOURCE__image_ref image_ref;
        public Image image_component;

        public void Put_image( Image _image_component ){

            CONTROLLER__errors.Verify( ( image_component != null ), "blablabla" );
            CONTROLLER__errors.Verify( ( _image_component != null ), "blablabla_2" );
            image_component = _image_component;

            Sprite sprite = image_ref.Get_sprite();
            image_component.sprite = sprite;
            
        }


}
