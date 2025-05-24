using UnityEngine;
using UnityEngine.UI;



/*


    UI_visual_container -> 1 image
    UI_visual_warehouse -> multiples images ** rotation

    UI_visual_factory -> 1 image with multiples components, like figure but dont have 1 texture per mode, all modes same dimensions
    UI_visual_industrial_zone -> multiples factories ** 2d rotation ( factory, mode )

*/



public class CONTAINER__UI_visual_container : CONTAINER__generic<UI_visual_container> {


        public override void Reset_data( UI_visual_container ex ){

            // ** change

            ex.material_manager.Change_material( null );
            ex.material_manager = default;
            Controllers.resources.images.container_image_refs.Return_image_ref( ex.image_ref );
            ex.image_ref = null; 

        }

}





public class UI_visual_container : UI_component {

        

        public static UI_visual_container Get( string _name ){ 

                UI_visual_container visual_container = Containers.UI_visual_container.Get();

                    visual_container.name = _name;

                return visual_container;

        }


    public override void Force_active(){}
    public override void Force_inactive(){ material_manager.render.sprite = image_ref.Get_sprite(); }
    public override void Force_nothing(){}

        
        protected override void Destroy_abs(){

            resources_container.Delete_all_resources();
            Containers.UI_visual_container.Return_object( this );
        }


        // ** IMAGE DATA

        private Resource_context context;
        private string main_folder;
        private string path;
        private Resource_image_content pre_allocation_content;



        public void Change_image( Resource_context _context, string _main_folder, string _path, Resource_image_content _pre_allocation_content ){ 

            if( image_ref != null )
                { 
                    image_ref.Delete(); 
                    image_ref = null;
                }

            image_ref = Controllers.resources.images.Get_image_reference( _context, _main_folder,  _path, _pre_allocation_content );
    
        }


        public RESOURCE__image_ref image_ref;
        public Individual_components_material_manager material_manager;


        public UI_visual_container(){

                resources_container = new MANAGER__resources();
                material_manager.material = new Material( Shaders.individual_components );
                material_manager.UI = this;

        }


        protected override void Update_phase( Control_flow _flow ){

            if( material_manager.material != null )
                { material_manager.Update_material(); }
                                
        }
            

        protected override void Link_to_UI_game_object_in_structure( GameObject _UI_game_object ){ 

                material_manager.render = _UI_game_object.GetComponent<SpriteRenderer>();

                // talvez fazer um container generico
                material_manager.render.material = material_manager.material;

                

        }


        protected override void Create_data_FROM_creation_data(){ 

            if( image_ref == null )
                { CONTROLLER__errors.Throw( $"did not create the image_ref in the { name }" ); } 

            resources_container.Add( image_ref );

            // ** isso aqui eu nao sei nao
            resources_container.Load_all_resources();


        }

 


}
