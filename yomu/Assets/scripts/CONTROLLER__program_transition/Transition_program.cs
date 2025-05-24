


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



}

