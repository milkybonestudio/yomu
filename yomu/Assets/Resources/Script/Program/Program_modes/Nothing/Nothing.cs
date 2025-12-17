

unsafe public class Nothing : PROGRAM_MODE {


        

        public Nothing(){ type = Program_mode.nothing; }
        public override void Construct(){}

        public RESOURCE__structure_copy nothing_structure;
        public override Transition_program Construct_transition( Transition_program_data _data ){  return new Transition_program(); }
        public override void Update( Control_flow _control_flow ){}
        public override void Clean_resources(){}
        public override void Destroy(){}

}