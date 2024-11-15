using UnityEngine;



public enum RESOURCE__image_ref_state {

        no_instanciated,
        instanciated,
        deleted,

}

public class RESOURCE__image_ref {

        
        public string localizador; // ** localizador local
        public RESOURCE__image image;
        public MODULE__context_images module;
        public int image_slot_index;

        public RESOURCE__image_ref_state ref_state;
        

        public Resource_state state;

        public Resource_image_content level_pre_allocation; // minimun 
        public Resource_image_content actual_need_content;



        //teste


        //mark

        // ** ainda precisa resolver como lidar quando não tem webp

        /*

            getting slot: ok
            not let create off level pre alloc: ok

            create:
                nothing: ok
                low quality: ok
                compress: ok
                sprite: ok


            nothing -> thing

            load: 
                nothing: ok
                low quality: ok
                compress data: ok

                Get_sprite:  ok?

            Activate:  ok
            Instanciate:  


                



            partindo minimo: 
                partindo nothing: 
                partindo compress_low_quality: 
                partindo compress: 

                partindo texture:
                partindo texture_com_pixels: 
                partindo texture_com_pixels_applyed: 

                partindo sprite: 


            Instanciate: 

                partindo nothing: 

                                partindo minimo: 
                                    partindo nothing: 
                                    partindo compress_low_quality: 
                                    partindo compress: 

                                    partindo texture:
                                    partindo texture_com_pixels: 
                                    partindo texture_com_pixels_applyed: 

                                    partindo sprite: 



            switches: 



        
        */




        public Sprite Get_sprite(){ Guaranty_ref(); return TOOL__module_context_images_actions.Get_sprite( this );  }
    

        private void Guaranty_ref(){ if( ref_state == RESOURCE__image_ref_state.deleted ){ CONTROLLER__errors.Throw( $"Tried to use ref { localizador } but the ref was deleted" ); } if( ref_state == RESOURCE__image_ref_state.no_instanciated ){ CONTROLLER__errors.Throw( $"Tried to use ref { localizador } but the ref was not instanciated" ); } }

        // ** DOWN

        
        public void Delete(){ Guaranty_ref(); TOOL__module_context_images_actions.Delete( this ); } 
        public void Unload(){ Guaranty_ref(); TOOL__module_context_images_actions.Unload( this ); }
        public void Deactivate(){ Guaranty_ref(); TOOL__module_context_images_actions.Deactivate( this ); }
        public void Deinstanciate(){ Guaranty_ref(); TOOL__module_context_images_actions.Deinstanciate( this ); }

        // ** UP

        public void Load(){ TOOL__module_context_images_actions.Load( this ); }
        public void Activate(){ TOOL__module_context_images_actions.Activate( this ); }
        public void Instanciate(){ TOOL__module_context_images_actions.Instanciate( this ); }

    
        public void Change_level_pre_allocation( Resource_image_content _new_pre_alloc ){}



 
}
