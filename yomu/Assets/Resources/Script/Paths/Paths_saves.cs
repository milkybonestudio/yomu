
using System.IO;


// **save_1
//     ** save_morte
//         ...
//     ** data_heap
//         storage.dat
//         data_1.dat
//         data_2.dat
//         .
//         .
//         .
//     ** brute_data.dat
//         {
//             blocks_data.dat
//             characters.dat
//             places.dat
//             plot.dat
//             .
//             .
//             .
//         }
//     ** save_image.png



public static class Paths_saves {


    public static void Define_saves_folder( string _path_to_saves_folder ){

        saves_path = _path_to_saves_folder;

                

        return;
        
    }



    public static string saves_path;


    public const string save_prefix_name = "save_";
    public static string Get_save_folder( int _save ){

            if( saves_path == null )
                { CONTROLLER__errors.Throw( $"Tried to get the save { _save }, but the function <Color=lightBlue>Define_version_folder</Color> was not called" );  }

            if( _save > 7 )
                { CONTROLLER__errors.Throw( $"Can not handle save number <Color=lightBlue>{ _save }</Color>" ); }

            return Path.Combine( saves_path, ( save_prefix_name + INT.ToString( _save ) ) );

    }

    public static string Get_save_folder( string _path_to_saves, int _save ){

            if( _save > 7 )
                { CONTROLLER__errors.Throw( $"Can not handle save number <Color=lightBlue>{ _save }</Color>" ); }

            return Path.Combine( _path_to_saves, $"{ save_prefix_name }{ INT.ToString( _save ) }"  );

    }



}

