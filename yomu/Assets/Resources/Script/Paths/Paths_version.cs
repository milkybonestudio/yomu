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

        security_file = Get_security_file( _path_to_version );
        data_link_current_files = Get_data_link_current_files( _path_to_version );

        saves = Get_all_saves_folder( _path_to_version );
            Paths_saves.Define_saves_folder( saves );

        program = Get_program( _path_to_version );
            Paths_program.Define_program_folder( program );

        run_time = Get_run_time( _path_to_version );
            Paths_run_time.Define_run_time_folder( run_time );
        

        return;

    }


    public static void Guarantee_version_folder(){

        if( saves == null )
            { CONTROLLER__errors.Throw( $"The version folder was not defined, function <Color=lightBlue>Define_version_folder</Color> was not called" );  }

    }


    public static string path_to_version;

    // ** SECURITY FILE

        public const string security_file_name = "security_file";
        public static string security_file;
        public static string Get_security_file( string _path_to_version ){ return Combine( _path_to_version, security_file_name ); }

    
    // ** RUN TIME

        
        public const string run_time_NAME = "run_time";
        public static string run_time;
        public static string Get_run_time( string _path_to_version ){ return Combine( _path_to_version, run_time_NAME ); }



    // ** SAVES

        public const string saves_name = "saves";
        public static string saves;
        public static string Get_all_saves_folder( string _path_to_version ){ return Combine( _path_to_version, saves_name ); }



    // ** PROGRAM
    
        public const string program_name = "program";
        public static string program;
        public static string Get_program( string _path_to_version ){ return Combine( _path_to_version, program_name ); }


    // ** CURRENT FILES

        public const string data_link_current_files_NAME = "data_link_current_files.txt";
        public static string data_link_current_files;
        public static string Get_data_link_current_files( string _path_to_version ){ return Combine( _path_to_version, data_link_current_files_NAME ); }




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

