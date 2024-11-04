using UnityEngine;


public class RESOURCE__image_ref {



        public RESOURCE__image_ref( RESOURCE__image _image, Resource_image_content _level_pre_allocation ){ 


                CONTROLLER__errors.Verify( ( _image == null  ), "Tried to creat a image ref but the image comes null" ); 
            
                image = _image;
                module = _image.module_images;
                level_pre_allocation = _level_pre_allocation;
            
        }

        
        public string localizador; // ** localizador local
        public RESOURCE__image image;
        public MODULE__context_images module;
        public int image_slot_index;

        public bool ref_deleted;
        

        // public Resource_image_content reference_level_pre_allocation_image;



        public Resource_state state;

        public Resource_image_content level_pre_allocation; // minimun 
        public Resource_image_content actual_need_content;



    
        // --- METODOS QUE VAO PARA O MODULO


        public UnityEngine.Sprite Get_sprite(){ return module.Get_sprite( this ); }
        public Texture Get_texture(){ return module.Get_texture( this ); }


        private void Guaranty_ref(){ if( ref_deleted ){ CONTROLLER__errors.Throw( $"Tried to use ref { localizador } but the ref was deleted" ); } }

        // ** DOWN

        
        public void Delete(){ Guaranty_ref(); module.Delete( this ); } 
        public void Unload(){ Guaranty_ref(); module.Unload( this ); }
        public void Deactivate(){ Guaranty_ref(); module.Deactivate( this ); }
        public void Deinstanciate(){ Guaranty_ref(); module.Deinstanciate( this ); }

        // ** UP

        public void Load(){ module.Load( this ); }
        public void Activate(){ module.Activate( this ); }
        public void Instanciate(){ module.Instanciate( this ); }

    
        public void Change_level_pre_allocation( Resource_image_content _new_pre_alloc ){}



 
}
