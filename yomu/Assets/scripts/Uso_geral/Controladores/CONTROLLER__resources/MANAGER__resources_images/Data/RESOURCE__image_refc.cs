using UnityEngine;


public class RESOURCE__image_ref {



        public RESOURCE__image_ref( RESOURCE__image _image, Resource_image_content _level_pre_allocation ){ 


                CONTROLLER__errors.Verify( ( _image == null  ), "Tried to creat a image ref but the image comes null" ); 
                CONTROLLER__errors.Verify( ( ( _level_pre_allocation & ( Resource_image_content.compress_data | Resource_image_content.sprite | Resource_image_content.nothing  | Resource_image_content.compress_low_quality_data ) ) == 0   ), $"Resource not accept: { _level_pre_allocation }" ); 
                
            
                image = _image;
                module = _image.module_images;

                state = Resource_state.nothing;

                level_pre_allocation = _level_pre_allocation;
                actual_need_content = Resource_image_content.nothing;
            
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



        //teste

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

                // ** por hora nao esta mudando o actual_content para compress_low_quality
                low quality: ok
                compress data: ok
                sprite:  ok

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
        public Sprite[] Get_sprites(){ Guaranty_ref(); return TOOL__module_context_images_actions.Get_sprites( this );  }



        private void Guaranty_ref(){ if( ref_deleted ){ CONTROLLER__errors.Throw( $"Tried to use ref { localizador } but the ref was deleted" ); } }

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
