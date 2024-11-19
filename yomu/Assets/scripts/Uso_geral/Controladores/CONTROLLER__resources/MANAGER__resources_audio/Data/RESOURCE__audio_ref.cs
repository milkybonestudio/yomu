using UnityEngine;
using UnityEngine.UI;




public class RESOURCE__audio_ref {

        
        public string localizador; // ** localizador local
        public string identifire;
        public RESOURCE__audio image;
        public Image image_component;
        public MODULE__context_audios module;
        public int image_slot_index;

        public RESOURCE__audio_ref_state ref_state;
        

        public Resource_state state;

        public Resource_audio_content level_pre_allocation; // minimun 
        public Resource_audio_content actual_need_content;



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
                sprite:  ok


            Activate: ok

            Instanciate:  ok


            DOWN : 

                unload : 

                    nothing : ok
                    minimun : 
                            nothing : ok
                            compress low quality : ok
                            compress : ok
                            sprite : ok

                    activated : ok
                    intanciated : ok

                Deactivate : 

                    nothing : 

                            nothing : ok
                            compress low quality : ok
                            compress : ok
                            sprite : ok


                    minimun : ok

                    activated : 

                            nothing : ok
                            compress low quality : ok
                            compress : ok
                            sprite : ok


                    intanciated : 

                            nothing : ok
                            compress low quality : ok
                            compress : ok
                            sprite : ok


                Deinstanciate : 

                    nothing : ok
                    minimun : 

                            nothing : ok
                            compress low quality : 
                            compress : 
                            sprite : 

                    activated : ok
                    intanciated : ok

                


            ** teste trocas rapidas: 

                instanciate -> activate -> instanciate : imagem fica webp



        */



        public Sprite Get_sprite(){ Guaranty_ref(); return TOOL__module_context_audios_actions.Get_sprite( this );  }
    

        private void Guaranty_ref(){ if( ref_state == RESOURCE__audio_ref_state.deleted ){ CONTROLLER__errors.Throw( $"Tried to use ref { localizador } but the ref was deleted" ); } if( ref_state == RESOURCE__audio_ref_state.no_instanciated ){ CONTROLLER__errors.Throw( $"Tried to use ref { localizador } but the ref was not instanciated" ); } }

        // ** DOWN

        
        public void Delete( ref RESOURCE__image_ref _ref_ref ){ Guaranty_ref(); TOOL__module_context_audios_actions.Delete( this ); _ref_ref = null; } 
        public void Unload(){ Guaranty_ref(); TOOL__module_context_audios_actions.Unload( this ); }
        public void Deactivate(){ Guaranty_ref(); TOOL__module_context_audios_actions.Deactivate( this ); }
        public void Deinstanciate(){ Guaranty_ref(); TOOL__module_context_audios_actions.Deinstanciate( this );  }

        // ** UP

        public void Load(){ TOOL__module_context_audios_actions.Load( this ); }
        public void Activate(){ TOOL__module_context_audios_actions.Activate( this ); }
        public void Instanciate(){ TOOL__module_context_audios_actions.Instanciate( this ); }

    
        public void Change_level_pre_allocation( Resource_image_content _new_pre_alloc ){}


 
}



