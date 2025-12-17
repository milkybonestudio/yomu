

unsafe public class New_game_standart : PROGRAM_MODE__INTERFACE {


        private NEW_GAME_DATA__global* global;
        private NEW_GAME_DATA__standart* standart;

        public override void Construct(){

            PROGRAM_DATA__new_game* data = default;
            
                global = &( data->global );
                standart = &( data->standart );
            
            // ** udar data

        }

        public override void Update( Control_flow _control_flow ){}

        public override Transition_program Construct_transition( Transition_program_data _data ){ 

            Transition_program transition = new Transition_program();

                transition.sections_actions.down = () => { return true; };

            return transition;

        }


        public override void Clean_resources(){}
        public override void Destroy(){}





}