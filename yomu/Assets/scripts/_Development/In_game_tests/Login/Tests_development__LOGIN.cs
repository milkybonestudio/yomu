

public static class Tests_development__LOGIN {

        public static In_game_test Get_test( string _key ){

                if( _key == null )
                    { CONTROLLER__errors.Throw( "The Key in get test for th <Color=lightBlue>Login</Color> was null" ); }

                switch( _key ){

                    case "generic": return new TEST_LOGIN__generic();
                    default: CONTROLLER__errors.Throw( $"Do not have an test for the key <Color=lightBlue>{ _key }</Color> in the type <Color=lightBlue>Login</Color>" ); return default;

                }
            

        }

}