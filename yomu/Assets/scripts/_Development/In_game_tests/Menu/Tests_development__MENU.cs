
public static class Tests_development__MENU {

        public static In_game_test Get_test( string _key ){

                if( _key == null )
                    { CONTROLLER__errors.Throw( "The Key in get test for th <Color=lightBlue>menu</Color> was null" ); }

                switch( _key ){

                    case "generic": return new TEST_MENU__generic();
                    default: CONTROLLER__errors.Throw( $"Do not have an test for the key { _key }" ); return default;

                }
            

        }

}