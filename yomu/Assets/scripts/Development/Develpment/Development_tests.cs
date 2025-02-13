


public static class Development_tests {


        public static Level_machine level_machine = Level_machine.max;


        // --- WHAT IS TESTING
        // ** nao troca direto, tem que trocar no Set_program_environment();
        public static Program_mode program_mode = Program_mode.test;
        public static bool use_generic = false;

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

public class Generic_test : Test_development {

    // ** TESTES QUE NAO PRECISAM SER GUARDADOS

    // ** seta o programa login, menu, game
    public override void Set_program_environment(){

        // base.Set_program_environment();
    }

    // ** com o programa setado vai mudar os dados e forçar algo
    public override void Create_state(){}

    // ** called everyframe
    public override void Update( Control_flow _flow ){}





}
