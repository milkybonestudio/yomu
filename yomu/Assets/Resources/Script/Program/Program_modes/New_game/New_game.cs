

unsafe public class New_game : PROGRAM_MODE {


    public New_game(){ type = Program_mode.new_game; }

    private NEW_GAME_DATA__global* global;

    public override void Construct(){

        PROGRAM_DATA__new_game* data = default;
        
            global = &( data->global );
    
        // ** udar data

    }

    public override void Update(){}

    public override Transition_program Construct_transition( Transition_program_data _data ){ 

        Transition_program transition = new Transition_program();

            transition.sections_actions.down = () => { return true; };

        return transition;

    }


    public override void Clean_resources(){}
    public override void Destroy(){}

}