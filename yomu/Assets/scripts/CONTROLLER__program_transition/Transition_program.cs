


// 1 array 
// 1 obj 


public class Transition_program {


        // --- DATA
        public Transition_stage stage;
        public Space_switcher space_switcher;

        public void Pass_stage(){ stage++; }
        
        public Transition_sections_actions sections_actions = Transition_sections_actions.Construct();

        // public Transition_response response;


        // --- UI

        // ** pode expandir se precisar

        public Device[,,] UIs = new Device[ ( int ) Transition_stage.END, 15, 2 ];// stage, thing, action 


        public Transition_stage stage_to_liberate_UI;


        // --- THINGS TO WAIT

        public void Add_resources_to_wait_finished( MANAGER__resources _resource_container_checker ){ resource_container_checker = _resource_container_checker; }

        public MANAGER__resources resource_container_checker = new MANAGER__resources();
        public Task_req[] tasks;

        // --- DEVICES



        


        // SCREEN

        /*
            coisas que transicao controla
                -->  modificar planos entre as textures/uis + material -> cameras
                -->  como que o old vai sair
                -->  como que o new vai entrar 
                -->  
        
        */



        public void EXAMPLE( Transition_program_data _data ){ 

            // Transition_program transition = new Transition_program();

            //     // // --- PASS RESOURCES

            //     transition.Add_resources_to_wait_finished( necessary_resources );

            //     // Add( image_building );
            //     // transition.resource_container_checker.Add( spin_building );
            //     // transition.resource_container_checker.Add( rebuilding_structure );

            //     // --- TRANSITION


            //     transition.sections_actions.preparation = ()=>  {
            //                                                         transition.space_switcher.canvas_space_new.screen_view.material.SetFloat( "_opacity", 0f );
            //                                                         return true;
            //                                                     };



            //     transition.sections_actions.mode_start  = ()=>  {
            //                                                         transition.space_switcher.canvas_space_new.screen_view.material.SetFloat( "_opacity", 1f );
            //                                                         transition.space_switcher.Annex_structure( rebuilding_structure );

            //                                                             rebuilding_structure.Get_component_sprite_render( "image" ).sprite = image_building.Get_sprite();
            //                                                             rebuilding_structure.Get_component_sprite_render( "spin" ).sprite = spin_building.Get_sprite();

            //                                                             UIs_manager.Create_data_FROM_creation_data_UIs();
            //                                                             UIs_manager.Link_to_game_object_UIs( rebuilding_structure );
            //                                                             UIs_manager.Get_full_resources_all_UIs();
            //                                                             UIs_manager.Complete_all_UIs();

            //                                                             information.Activate_UI();

            //                                                         return true;
            //                                                     };

            // return transition; 

        }





}

