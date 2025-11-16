using System.IO;
using System.Runtime.CompilerServices;

// persistentDataPath -> coisas que vão ser unicas de cada versao

//     ----- current ( 0.0.1 )
//             ---- saves
//             ---- program

// ** pode ser usado se a pessoa abrir um executavel com outra versao
//     ----- other_version ( 0.0.0 )
//             ---- saves
//             ---- program

// ** data_path fica dentro de cada versao do jogo e nao vai ficar salvo caso o player exclua a pasta do jogo


public static class Paths_version {

    public static void Define_version_folder( string _path_to_version ){

        path_to_version = _path_to_version;

        saves = Get_all_saves_folder( _path_to_version );

        program = Get_program( _path_to_version );
            Paths_program.Define_program_folder( program );
        

    }


    public static void Guarantee_version_folder(){

        if( saves == null )
            { CONTROLLER__errors.Throw( $"The version folder was not defined, function <Color=lightBlue>Define_version_folder</Color> was not called" );  }

    }


    public static string path_to_version;

    // ** SAVES

        public const string saves_name = "saves";
        public static string saves;
        public static string Get_all_saves_folder( string _path_to_version ){ return Combine( _path_to_version, saves_name ); }

        public const string save_prefix_name = "save_";
        public static string Get_save_folder( int _save ){

                if( saves == null )
                    { CONTROLLER__errors.Throw( $"Tried to get the save { _save }, but the function <Color=lightBlue>Define_version_folder</Color> was not called" );  }

                if( _save > 7 )
                    { CONTROLLER__errors.Throw( $"Can not handle save number <Color=lightBlue>{ _save }</Color>" ); }

                return Combine( saves, save_prefix_name, INT.ToString( _save ) );

        }

        public static string Get_save_folder( string _path_to_saves, int _save ){

                if( _save > 7 )
                    { CONTROLLER__errors.Throw( $"Can not handle save number <Color=lightBlue>{ _save }</Color>" ); }

                return Combine( _path_to_saves, $"{ save_prefix_name }{ INT.ToString( _save ) }"  );

        }


    // ** PROGRAM

    
        public const string program_name = "program";
        public static string program;
        public static string Get_program( string _path_to_version ){ return Combine( _path_to_version, program_name ); }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static string Combine( string _str_1, string _str_2 ){

            if( _str_1 == null )
                { return null; }

            return Path.Combine( _str_1, _str_2 );

        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static string Combine( string _str_1, string _str_2, string _str_3 ){

            if( _str_1 == null )
                { return null; }

            return Path.Combine( _str_1, _str_2, _str_3 );

        }



}

