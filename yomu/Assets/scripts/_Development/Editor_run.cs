

public static class Editor_run {


        // --- WHAT IS TESTING

        public static Type_testing type_testing = Type_testing.test;


        
        // --- FILE SYSTEM
        public static bool reset_version_folder = true;


        // --- CHANGE BEHAVIOR

        public static Level_machine level_machine = Level_machine.max;


        // ** nao troca direto, tem que trocar no Set_program_environment();
        public static Program_mode program_mode = Program_mode.login;
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

