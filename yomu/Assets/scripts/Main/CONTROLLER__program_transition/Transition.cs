


public class Transition_program {


        public static Transition_program intern_transition = new Transition_program();
        public static Transition_program Get(){

        
                // --- RESET CHECKS

                Transition_program transition = intern_transition;

                Device[,,] UIs = transition.UIs;

                int length_devices = UIs.GetLength( 1 );
                    
                for( int device_stage = 0 ; device_stage <  ( int ) Transition_stage.END; device_stage++ ){

                    for( int device_index = 0 ; device_index < length_devices ; device_index++ ){

                            UIs[ device_stage, device_index, 0 ] = default;
                            UIs[ device_stage, device_index, 1 ] = default;

                        }

                }

                transition.resource_container_checker = null;
                transition.stage = default;
                transition.stage_to_liberate_UI = default;
                transition.sections_actions = Transition_sections_actions.Construct();

                return transition;


        }

        // --- DATA
        public Transition_stage stage;
        public Cameras_switching_data cameras_data;

        public void Pass_stage(){ stage++; }
        
        public Transition_sections_actions sections_actions = Transition_sections_actions.Construct();

        // public Transition_response response;


        // --- UI

        // ** pode expandir se precisar



        public Device[,,] UIs = new Device[ ( int ) Transition_stage.END, 15, 2 ];// stage, thing, action 


        public Transition_stage stage_to_liberate_UI;


        // --- RESOURCES
        public Resource_container_checker resource_container_checker = new Resource_container_checker();
        public Task_req[] tasks;

        


        // SCREEN

        /*
            coisas que transicao controla
                -->  modificar planos entre as textures/uis + material -> cameras
                -->  como que o old vai sair
                -->  como que o new vai entrar 
                -->  
        
        */



}

