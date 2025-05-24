


public static class TESTS_INTERACTION {

        // ** o teste que seta o modo

        public static In_game_test Get( string _key ){

                switch( _key ){

                    case "generic": return new TESTS_INTERACTION__generic();

                }

                return default;

        }

}
