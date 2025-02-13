


public static class TESTS_INTERACTION {

        // ** o teste que seta o modo

        public static Test_development Get( string _key ){

                switch( _key ){

                    case "generic": return new TESTS_INTERACTION__generic();

                }

                return default;

        }

}
