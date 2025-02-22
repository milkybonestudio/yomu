


public class Transition {


        public static Transition intern_transition = new Transition();
        public static Transition Get(){


                // --- RESET CHECKS

                Device[,,] UIs = intern_transition.UIs;

                int length_devices = UIs.GetLength( 1 );
                    
                for( int device_stage = 0 ; device_stage <  ( int ) Transition_stage.END; device_stage++ ){

                    for( int device_index = 0 ; device_index < length_devices ; device_index++ ){

                            UIs[ device_stage, device_index, 0 ] = default;
                            UIs[ device_stage, device_index, 1 ] = default;

                        }

                }

                
                intern_transition.stage = default;
                intern_transition.stage_to_liberate_UI = default;
                intern_transition.sections_actions = Transition_sections_actions.Construct();

                return intern_transition;


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

