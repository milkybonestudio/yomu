



using UnityEngine;

unsafe public class Rebuild_save : PROGRAM_MODE {

        public Rebuild_save(){ type = Program_mode.rebuild_save; }


        public RESOURCE__image_ref image_building;
        public RESOURCE__image_ref spin_building;
        public RESOURCE__structure_copy rebuilding_structure;

        public UI_text_container information;


        public override void Construct(){

                image_building = Controllers.resources.resources_images.Get_image_reference( Resource_context.System, "Rebuilding_save", "image_rebuilding_save", Resource_image_content.sprite );
                spin_building = Controllers.resources.resources_images.Get_image_reference( Resource_context.System, "Rebuilding_save", "spin_rebuilding_save", Resource_image_content.sprite );
                rebuilding_structure = Controllers.resources.resources_structures.Get_structure_copy( Resource_context.System, "Rebuilding_save", "structure_rebuilding_save", Resource_structure_content.game_object );


                information = UI_text_container.Get_text_container();

        }

    
        public override void Destroy(){}
        public override void Update( Control_flow _control_flow ){

            rebuilding_structure.Get_component_game_object( "spin" ).transform.localRotation *= Quaternion.Euler( 0f,0f,( 180f * Time_info.delta_time ) );

        }
        public override Transition_program Construct_transition( Transition_program_data _data ){ 

            Transition_program transition = Transition_program.Get();

                transition.resource_container_checker.Add( image_building );
                transition.resource_container_checker.Add( spin_building );
                transition.resource_container_checker.Add( rebuilding_structure );

                transition.sections_actions.mode_start  = ()=>{
                                                                    transition.cameras_data.Annex_structure( rebuilding_structure );

                                                                        rebuilding_structure.Get_component_sprite_render( "image" ).sprite = image_building.Get_sprite();
                                                                        rebuilding_structure.Get_component_sprite_render( "spin" ).sprite = spin_building.Get_sprite();

                                                                    return true;
                                                              };

            return transition; 

        }

        public void Mode_start(){

        }

        public override void Clean_resources(){ }


}




