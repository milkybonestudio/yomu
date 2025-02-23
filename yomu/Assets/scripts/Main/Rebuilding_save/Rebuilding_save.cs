



using UnityEngine;

unsafe public class Rebuild_save : PROGRAM_MODE {

        public Rebuild_save(){ type = Program_mode.rebuild_save; }


        public RESOURCE__image_ref image_building;
        public RESOURCE__image_ref spin_building;
        public RESOURCE__structure_copy rebuilding_structure;

        public UI_text_container information;

        public Resource_container_checker necessary_resources = new Resource_container_checker();


        public override void Construct(){

                MANAGER__resources_images images = Controllers.resources.resources_images;

                image_building = images.Get_image_reference( Resource_context.System, "Rebuilding_save", "image_rebuilding_save", Resource_image_content.sprite );
                    necessary_resources.Add( image_building );

                spin_building = images.Get_image_reference( Resource_context.System, "Rebuilding_save", "spin_rebuilding_save", Resource_image_content.sprite );
                    necessary_resources.Add( spin_building );

                rebuilding_structure = Controllers.resources.resources_structures.Get_structure_copy( Resource_context.System, "Rebuilding_save", "structure_rebuilding_save", Resource_structure_content.game_object );
                    necessary_resources.Add( rebuilding_structure );


                information = UI_text_container.Get_text_container();

        }

    
        public override void Destroy(){

            necessary_resources.Delete_all();
            // rebuilding_structure.Delete();
            // image_building.Delete();
            // spin_building.Delete();
            // rebuilding_structure.Delete();

        }

        public override void Update( Control_flow _control_flow ){



            rebuilding_structure.Get_component_game_object( "spin" ).transform.localRotation *= Quaternion.Euler( 0f,0f,( 180f * Time_info.delta_time ) );


            if( Input.GetKeyDown( KeyCode.A ) )
                {
                    PROGRAM_DATA__login* login_data = Program_data.Lock_data__LOGIN();
                    Controllers_program.program_transition.Switch_program_mode( Program_mode.login, new Transition_program_data() );
                }

        }



        public override Transition_program Construct_transition( Transition_program_data _data ){ 

            Transition_program transition = Transition_program.Get();

                // --- PASS RESOURCES

                transition.resource_container_checker = necessary_resources;
                // Add( image_building );
                // transition.resource_container_checker.Add( spin_building );
                // transition.resource_container_checker.Add( rebuilding_structure );

                // --- TRANSITION


                transition.sections_actions.preparation = ()=>  {
                                                                    transition.cameras_data.material_mode_transition.SetFloat( "_opacity", 0f );
                                                                    return true;
                                                                };



                transition.sections_actions.mode_start  = ()=>  {
                                                                    transition.cameras_data.material_mode_transition.SetFloat( "_opacity", 1f );
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




