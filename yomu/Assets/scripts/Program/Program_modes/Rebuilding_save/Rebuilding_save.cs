

using UnityEngine;


//mark
// ** tudo que tiver interação com o usuario precisa estar em um device. mesmo que seja mais pratico testar somente com a structure e as UIs 
// ** o codigo fica estranho quando for fazer algo na pratica


unsafe public class Rebuild_save : PROGRAM_MODE {

        public Rebuild_save(){ type = Program_mode.rebuild_save; }


        // public RESOURCE__image_ref image_building;
        // public RESOURCE__image_ref spin_building;
        // public RESOURCE__structure_copy rebuilding_structure;

        

        // public MANAGER__UI_components UIs_manager = MANAGER__UI_components.Construct();
        // public MANAGER__resources necessary_resources = new MANAGER__resources();

        
        // public UI_text_container information;

        public override void Construct(){

                // MANAGER__resources_images images = Controllers.resources.images;

                // image_building = images.Get_image_reference( Resource_context.System, "Rebuilding_save", "image_rebuilding_save", Resource_image_content.sprite );
                //     necessary_resources.Add( image_building );

                // spin_building = images.Get_image_reference( Resource_context.System, "Rebuilding_save", "spin_rebuilding_save", Resource_image_content.sprite );
                //     necessary_resources.Add( spin_building );

                // rebuilding_structure = Controllers.resources.structures.Get_structure_copy( Resource_context.System, "Rebuilding_save", "structure_rebuilding_save", Resource_structure_content.game_object );
                //     necessary_resources.Add( rebuilding_structure );



                // information = UI_text_container.Get_text_container( "Information_rebuild_save" );
                //     UIs_manager.Add( information, "information" );

        }

    
        public override void Destroy(){

            // necessary_resources.Delete_all_resources();

        }

        public override void Update( Control_flow _control_flow ){

            
            // UIs_manager.Update( _control_flow );

            // if( Input.GetKeyDown( KeyCode.Alpha9 ) )
            //     { necessary_resources.Delete_all_resources(); }


            // rebuilding_structure.Get_component_game_object( "spin" ).transform.localRotation *= Quaternion.Euler( 0f,0f,( 180f * Time_info.delta_time ) );

            // information.Move_to( new Vector3( 1000f, 0f, 0f ) );

            // information.Update( _control_flow );


            // if( Input.GetKeyDown( KeyCode.A ) )
            //     {
            //         PROGRAM_DATA__login* login_data = Controllers_program.data.modes.Lock_data__LOGIN();
            //         Controllers_program.program_transition.Switch_program_mode( Program_mode.login, new Transition_program_data() );
            //     }

        }



        public override Transition_program Construct_transition( Transition_program_data _data ){ 

            Transition_program transition = new Transition_program();

                // // --- PASS RESOURCES

                // transition.Add_resources_to_wait_finished( necessary_resources );

                // // Add( image_building );
                // // transition.resource_container_checker.Add( spin_building );
                // // transition.resource_container_checker.Add( rebuilding_structure );

                // // --- TRANSITION


                // transition.sections_actions.preparation = ()=>  {
                //                                                     transition.space_switcher.canvas_space_new.screen_view.material.SetFloat( "_opacity", 0f );
                //                                                     return true;
                //                                                 };



                // transition.sections_actions.mode_start  = ()=>  {
                //                                                     transition.space_switcher.canvas_space_new.screen_view.material.SetFloat( "_opacity", 1f );
                //                                                     transition.space_switcher.Annex_structure( rebuilding_structure );

                //                                                         rebuilding_structure.Get_component_sprite_render( "image" ).sprite = image_building.Get_sprite();
                //                                                         rebuilding_structure.Get_component_sprite_render( "spin" ).sprite = spin_building.Get_sprite();

                //                                                         UIs_manager.Create_data_FROM_creation_data_UIs();
                //                                                         UIs_manager.Link_to_game_object_UIs( rebuilding_structure );
                //                                                         UIs_manager.Get_full_resources_all_UIs();
                //                                                         UIs_manager.Complete_all_UIs();

                //                                                         information.Activate_UI();

                //                                                     return true;
                //                                                 };

            return transition; 

        }

        public void Mode_start(){

        }

        public override void Clean_resources(){ }


}




