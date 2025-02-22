




unsafe public abstract class PROGRAM_MODE {

        
        public Program_mode type;
        public Program program = Program.instancia;

            // ** nao faz sentido colocar como obrigação de cada mode ter uma struct propria
            // ** internamente eles vão ter, mas então cada modo fica responsavel por colcoar ele na camera
            
            public abstract void Update( Control_flow _control_flow );
            public abstract Transition_program Construct_transition( Transition_program_data _data );
            
            public abstract void Clean_resources();
            // public abstract void End(); // ** need to destroy de object

            // ** used only in the main interface
            public abstract void Construct();

            // ** need in the main interface and the object_interface
            public abstract void Destroy();
            

}


