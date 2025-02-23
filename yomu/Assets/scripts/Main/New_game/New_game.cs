

unsafe public class New_game : PROGRAM_MODE {

        public New_game(){ type = Program_mode.new_game; }

        

        public override void Construct(){

            

        }
        
        public override void Destroy(){}


        public override void Update( Control_flow _control_flow ){}

        public override Transition_program Construct_transition( Transition_program_data _data ){ 

            Transition_program transition = Transition_program.Get();

                transition.sections_actions.down = () => { return true; };

            return transition;

        }



        public override void Clean_resources(){



        }


}