


using System.IO;

public static class TOOL__crash_handler {


    public static void Save_files_in_saving_files_folder(){

        if( System_run.show_program_messages )
            { Console.Log( "Will save the files in the folder saving_files_run_time in the slot.dat format. if the system crashes when recosntruct the stack it can start over again" ); }
  

        for( int index_file = 0 ; index_file < Crash_handler.files.Length ; index_file++ ){

            if( Crash_handler.files[ index_file ] == null )
                { continue; } // ** no files

            string path_slot = Path.Combine( Paths_program.saving_files_folder, index_file.ToString() ) + ".dat";
            Files.Save_critical_file( path_slot, Crash_handler.files[ index_file ] );

            continue;

        }

    }

    public static void Move_files_to_correct_place_as_temp(){

        
        if( System_run.show_program_messages )
            { Console.Log( "Will move the files as temp files" ); }


        for( int index_file = 0 ; index_file < Crash_handler.files.Length ; index_file++ ){

            if( Crash_handler.files[ index_file ] == null )
                { continue; } // ** no files


            string correct_path = Crash_handler.paths[ index_file ];

            if( ( correct_path == null ) || ( correct_path == "" ) || !!!( Directories.Is_sub_path( correct_path, Paths_system.persistent_data ) ) )
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

            if( Crash_handler.files[ index_file ] == null )
                { continue; } // ** no files


            string correct_path = Crash_handler.paths[ index_file ];
            string temp_path = correct_path + ".temp";

            System.IO.File.Delete( correct_path );
            System.IO.File.Move( temp_path, correct_path );
            
            continue;

        }

    }


}