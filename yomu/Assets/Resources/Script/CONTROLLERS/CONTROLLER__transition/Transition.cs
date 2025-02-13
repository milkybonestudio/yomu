



public class Resource_container_minimun_checker { 


    // ** todos vao estar como minimo 

    // ** os recursos aqui nao são contatos como referencias
    // ** cada modo cria oque precisa e depois transfere para ca para verificar se ja terminou

    private int slot_intern;
    public RESOURCE__ref[] resource_refs = new RESOURCE__ref[ 200 ];

    public void Add( RESOURCE__ref _ref ){

        
        resource_refs[ slot_intern++ ] = _ref;


        if( resource_refs.Length == slot_intern )
            { System.Array.Resize( ref resource_refs, ( resource_refs.Length + 50 ) ); }



    }

    public bool End(){

            bool load_all = true;

            for( int slot = 0 ; slot < resource_refs.Length ; slot++ ){

                    if( resource_refs[ slot ] == null )
                        { break; }
                    
                    if( resource_refs[ slot ].Got_to_minimun() )
                        { continue; }
                    
                    load_all = false; 
                    break; 

            }

            //Console.Log( "deu: " + load_all );
            return load_all;

    }

    // public RESOURCE__audio_ref[] audios;



}


public class Transition {


        // --- DATA
        public Transition_stage stage;
        public Switching_cameras_data cameras_data;

        public void Pass_stage(){ stage++; }

        public Transition_checks[] checks = new Transition_checks[ ( int ) Transition_stage.END ];
        
        public Transition_sections_actions sections_actions;


        // --- UI

        public Device[,,] UIs = new Device[ ( int ) Transition_stage.END, 15, 2 ];// stage, thing, action action, thing, stage
        public Transition_stage stage_to_liberate_UI;


        // --- RESOURCES
        public Resource_container_minimun_checker resource_container_minimun_checker = new Resource_container_minimun_checker();
        public Task_req data_requisition;
        public Task_req resources_requisition;
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

