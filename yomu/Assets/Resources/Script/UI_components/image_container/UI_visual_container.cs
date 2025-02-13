using UnityEngine;
using UnityEngine.UI;



/*


    UI_visual_container -> 1 image
    UI_visual_warehouse -> multiples images ** rotation

    UI_visual_factory -> 1 image with multiples components, like figure but dont have 1 texture per mode, all modes same dimensions
    UI_visual_industrial_zone -> multiples factories ** 2d rotation ( factory, mode )

*/






public class UI_visual_container : UI_component {

    public static UI_visual_container Get(){ return new UI_visual_container(); }

    // ** so tem 1 imagem
    // ** nao tem tipos secundarios


        public RESOURCE__image_ref image_ref;
        public Individual_components_material_manager material_manager;

        // public SpriteRenderer render;
        // public Material material ;

        public UI_visual_container(){

                material_manager.material = new Material( Shaders.individual_components );
                material_manager.UI = this;

        }

        

        public override void Update( Control_flow _flow ){

                base.Update( _flow );

                if( material_manager.material != null )
                    { material_manager.Update_material(); }

                
        }
            

        public override void Link_to_UI_game_object_in_structure(){ 

                material_manager.render = structure_container.GetComponent<SpriteRenderer>();
            
                // talvez fazer um container generico
                material_manager.render.material = material_manager.material;

        }


        public override void Convert_creation_data_TO_resources(){ if( image_ref == null ){ CONTROLLER__errors.Throw( $"did not create the image_ref in the { name }" ); } }

        public override void Start_UI(){ material_manager.render.sprite = image_ref.Get_sprite(); }

        public override void Load(){ image_ref.Load(); }


        public void Change_image( RESOURCE__image_ref _new_image_ref ){ 


                if( image_ref != null )
                    { 
                        image_ref.Delete(); 
                        image_ref = null;
                    }

                

                image_ref = _new_image_ref;

                if( state == UI_state.instanciated )
                    { material_manager.render.sprite = image_ref.Get_sprite(); }
        }

}
