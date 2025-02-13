

unsafe public class Nothing : PROGRAM_MODE {

        public Nothing(){ type = Program_mode.nothing; }

        public override void Construct(){}
        public override Transition Construct_transition( Transition_data _data ){ return null; }
        public override void Update( Control_flow _control_flow ){}
        public override void Clean_resources(){}
        public override void Destroy(){}

}