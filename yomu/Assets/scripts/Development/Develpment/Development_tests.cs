


public static class Development_tests {


        // ** system files

        public static bool reset_folders_persistent_data_path = true;


        public static Level_machine level_machine = Level_machine.max;


        // --- WHAT IS TESTING
        // ** nao troca direto, tem que trocar no Set_program_environment();
        public static Program_mode program_mode = Program_mode.rebuild_save;
        public static bool use_generic = true;

            // --- TEST

                /* dont need anything */

            // ---LOGIN

                public static string login_test_key = "generic";

            // ---MENU

                public static string menu_test_key = "generic";

            // ---GAME
            
                public static Block_type block_type; // ** usado para o switch
                public static string game_test_key = "generic"; // ** link para o teste
                public static string game_test_sub_key = "a"; // ** no minigame key-> minigame, sub_key -> test



    

}

unsafe public class Generic_test : Test_development {

    // ** TESTES QUE NAO PRECISAM SER GUARDADOS

    // ** seta o programa login, menu, game
    public override void Set_program_environment(){

        
            Controllers_program.data.program_data->program_mode_lock = Program_mode.rebuild_save;
            Controllers_program.program_transition.Switch_program_mode( Development_tests.program_mode, new Transition_program_data() ); 

    }

    // ** com o programa setado vai mudar os dados e forçar algo
    public override void Create_state(){}

    // ** called everyframe
    public override void Update( Control_flow _flow ){}





}
