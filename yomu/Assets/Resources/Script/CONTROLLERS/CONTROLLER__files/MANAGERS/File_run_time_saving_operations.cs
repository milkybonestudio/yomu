

using System.IO;

unsafe public static class File_run_time_saving_operations {



    public static void Finish_switch_file( Data_file_link _data ){

        Move_switch_file( _data );
        Switch_files( _data );

    }

    // ** MORE FOR TESTING / CRASH
    public static void Move_switch_file( Data_file_link _data ){

        if( System_run.files_show_messages )
            { Console.Log( "Called Move_file()" ); }


        string path_run_time = Get_run_time_path( _data.id, File_IO_operation._add );

        string path_final = Controllers.files.storage.Get_path_for_file( _data );
        string final_path_temp = Get_run_time_path_TEMP( path_final, File_IO_operation._add );

        if( System_run.max_security )
            {
                if( !!!( System.IO.File.Exists( path_run_time ) ) )
                    { CONTROLLER__errors.Throw( $"Tried to move a file in the path <Color=lightBlue>{ path_run_time }</Color> but it dosent exist" ); }
            }


        if( System_run.files_show_messages )
            { Console.Log( "Will move the file" ); }

        System.IO.File.Move( path_run_time , final_path_temp );

        
        if( System_run.files_show_messages )
            { Console.Log( "Moved the file" ); }

        return;

    }

    public static void Switch_files( Data_file_link _data ){

        string path_final = Controllers.files.storage.Get_path_for_file( _data );
        string temp_file = Get_run_time_path_TEMP( path_final, File_IO_operation._add );

        if( System_run.max_security )
            {
                if( !!!( System.IO.File.Exists( path_final ) ) )
                    { CONTROLLER__errors.Throw( $"In witch files the <Color=lightBlue>OLD</Color> file didn't exist in the path: <Color=lightBlue>{ path_final }</Color>" ); }

                if( !!!( System.IO.File.Exists( temp_file ) ) )
                    { CONTROLLER__errors.Throw( $"In witch files the <Color=lightBlue>NEW</Color> file didn't exist in the path: <Color=lightBlue>{ temp_file }</Color>" ); }

            }

        System.IO.File.Delete( path_final );
        System.IO.File.Move( temp_file, path_final );

    }


    public static void Delete_files( Data_file_link _data ){

        string path_final = Controllers.files.storage.Get_path_for_file( _data );
        string path_run_time = Get_run_time_path( _data.id, File_IO_operation._delete );

        if( System_run.max_security )
            {
                if( !!!( System.IO.File.Exists( path_final ) ) )
                    { CONTROLLER__errors.Throw( $"In DELETE files the <Color=lightBlue>OLD</Color> file didn't exist in the path: <Color=lightBlue>{ path_final }</Color>" ); }

                if( !!!( System.IO.File.Exists( path_run_time ) ) )
                    { CONTROLLER__errors.Throw( $"In DELETE files the <Color=lightBlue>NEW</Color> file didn't exist in the path: <Color=lightBlue>{ path_run_time }</Color>" ); }

            }

        System.IO.File.Delete( path_final );
        System.IO.File.Delete( path_run_time );

        return;

    }

    public static void Save_file_run_time( Data_file_link _data, File_IO_operation _operation ){

        string path = Get_run_time_path( _data.id, _operation );

        if( _data.Get_heap_key_type() == Heap_key_type.empty )
            {
                Files.Save_critical_file( path, new byte[ 100 ]);
                return;
            }
        
        Files.Save_critical_file( path, _data );

        return;         

    }


    

    
    public static string Get_run_time_path( int _slot, File_IO_operation _operation ){


        string suf = null;

        switch( _operation ){

            case File_IO_operation._add: suf = ".add"; break;
            case File_IO_operation._delete: suf = ".delete"; break;
            default: CONTROLLER__errors.Throw( "Can not handle type: " + _operation ); break;

        }

        return Path.Combine( Paths_run_time.saving_files_folder, ( INT.ToString( _slot ) + suf ) );


    }


    public static string Get_run_time_path_TEMP( string _path_final, File_IO_operation _operation ){

        return _path_final + ".temp" + _operation.ToString();

    }


    public static string Get_run_time_path_TEMP( string _path_final ){

        return ( _path_final + ".temp" );

    }





}
