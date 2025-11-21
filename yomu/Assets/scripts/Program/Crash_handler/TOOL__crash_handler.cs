


using System.IO;

public static class TOOL__crash_handler {

    
    public static void Save_files_in_saving_files_folder(){

        if( System_run.show_program_messages )
            { Console.Log( "Will save the files in the folder saving_files_run_time in the slot.dat format. if the system crashes when recosntruct the stack it can start over again" ); }
  

        for( int index_file = 0 ; index_file < Crash_handler.files.Length ; index_file++ ){

            Console.Log( "tem que mudar aqui, levando em conta que pode ter delete" );

            Crash_file file = Crash_handler.files[ index_file ];


            Console.Log( "isso aqui poderia mudar depois" );
            if( file.path == null || ( file.path.Length < 15 ) )
                { continue; } // ** no files


            string temp_name = CONTROLLER__data_files.Get_run_time_path( index_file, file.deleted_file );
            file.data ??= new byte[ 100 ];

            Console.Log( "AAAAAAAAAAAAAAAAAAAAA vai salvar path: " + temp_name );
            Console.Log( "index: " +  index_file);
            Console.Log( $"file.path: " + file.path );
            Console.Log( $"file.path: " + file.path.Length );
            
            
            Files.Save_critical_file( temp_name, file.data );

            continue;

        }

        // ** ALL FILES SAVE IN DISK

    }



    public static void Move_files_to_correct_place_as_temp(){

        
        if( System_run.show_program_messages )
            { Console.Log( "Will move the files as temp files" ); }


        for( int index_file = 0 ; index_file < Crash_handler.files.Length ; index_file++ ){

            Crash_file file = Crash_handler.files[ index_file ];

            if( file.path == null )
                { continue; } // nothing

            // ** have something to do

            if( file.deleted_file )
                {
                    if( System.IO.File.Exists( file.path ) )
                        { System.IO.File.Delete( file.path ); }

                    System.IO.File.Delete( CONTROLLER__data_files.Get_run_time_path( index_file, true ) );

                    continue;
                        
                }

            Console.Log( "levar em conta deleteed" );
            if( file.data == null )
                { continue; } // ** no files


            string correct_path = file.path;

            if( ( correct_path == null ) || ( correct_path == "" ) || !!!( Directories.Is_sub_path( correct_path, Paths_version.path_to_version ) ) )
                {  CONTROLLER__errors.Throw( $"Corrupted, path <Color=lightBlue>{ correct_path }</Color> is invalid" ); }

            string slot_path = Path.Combine( Paths_program.saving_files_folder, index_file.ToString() ) + ".dat";
            string temp_path = correct_path + ".temp";


            System.IO.File.Move( slot_path, temp_path );
            
            continue;

        }

    }


    public static void Switch_files_in_correct_place(){

        if( System_run.show_program_messages )
            { Console.Log( "Will make the switch" ); }

        for( int index_file = 0 ; index_file < Crash_handler.files.Length ; index_file++ ){

            Console.Log( "Lvar em conta deleted" );

            if( Crash_handler.files[ index_file ].data == null )
                { continue; } // ** no files


            string correct_path = Crash_handler.files[ index_file ].path;
            string temp_path = correct_path + ".temp";

            System.IO.File.Delete( correct_path );
            System.IO.File.Move( temp_path, correct_path );
            
            continue;

        }

    }



    private static string _Get_saving_name( int _index ){

        string name = _index.ToString();

        if( Crash_handler.files[ _index ].deleted_file )
            { name = ( "-" + name ); }

        

        return Path.Combine( Paths_program.saving_files_folder, name ) + ".dat";
        

    }


}