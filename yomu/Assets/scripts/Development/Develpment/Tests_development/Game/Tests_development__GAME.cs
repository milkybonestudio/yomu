

public static class Tests_development__GAME {

    public static Test_development Get_test( Block_type _block, string _key ){


            switch( _block ){

                case Block_type.interacao: return TESTS_INTERACTION.Get( _key );

            }

            return default;

    }

}