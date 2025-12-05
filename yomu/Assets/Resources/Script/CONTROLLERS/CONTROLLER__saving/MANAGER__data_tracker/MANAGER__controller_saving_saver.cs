



using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;


unsafe public struct MANAGER__controller_saving_saver {


    public static MANAGER__controller_saving_saver Construct(){

        MANAGER__controller_saving_saver manager = default;

            manager.req_saving_files = new Task_req( "default_saving_task" );
            manager.req_saving_files.Change_stage( Task_req_stage.finished );
            
        return manager;

    }


    public Task_req req_saving_files;

    
    public void Start_saving_files(){

        if( System_run.saving_show_messages )
            { Console.Log( "came Start_saving_files()" ); }

        System.Object _lock_object = Controllers.files.operations.lock_obj;

        req_saving_files = Controllers.tasks.Get_task_request( "saving files" );

        req_saving_files.Give_lock_object( _object_to_lock: _lock_object, _enter: true  );

        // ** SAVE THE STACK IN DISK
        Controllers.stack.Sinalize_will_save_files();
        Controllers.stack.saver.Give_multithread_saving_stack( req_saving_files );

        // ** SAVE LINK_FILE
        req_saving_files.Give_multithread_sequencial_action( Save_link_paths );
        req_saving_files.Give_multithread_sequencial_action( Create_saving_folder );
        req_saving_files.Give_multithread_sequencial_action( Save_files );
        req_saving_files.Give_multithread_sequencial_action( Create_security_file );
        req_saving_files.Give_multithread_sequencial_action( Apply_actions_files_in_saving_folder );
        req_saving_files.Give_multithread_sequencial_action( Reset_stack );
        req_saving_files.Give_multithread_sequencial_action( Delete_saving_folder );
        req_saving_files.Give_multithread_sequencial_action( Delete_file_links );
        req_saving_files.Give_multithread_sequencial_action( Save_stack_start_files );
        
        
        req_saving_files.Give_single_final( End_saving );

        return;

    }

    //mark
    // ** talvez passar para Save_ids_TO_paths()
    public static void Save_link_paths( Task_req _req ){


        string[] linked_files_lines = Controllers.files.storage.Get_link_files_lines();
        _req.managed_data.string_array = linked_files_lines;
        
        // ** need to be on the NEW_path because if the system crashes before saved all the files in disk
        // ** it needs to use the old links to reconstruct the stack. this current_links and the one the Reconstruct_stack() 
        // ** should be the same, so same behaviour
        Files.Save_critical_file( Paths_run_time.saving_link_file_to_path, linked_files_lines );

        return;

    }

    public static void Create_saving_folder( Task_req _req ){

        System.IO.Directory.CreateDirectory( Paths_run_time.saving_files_folder );

    }


    public static void Save_files( Task_req _req ){

        // ** SAVE FILES IN DISK

        Dictionary<int,File_IO_operation> dic = new Dictionary<int, File_IO_operation>();
        
        if( System_run.saving_show_messages )
            { Console.Log( "Will loop throught the current files:" ); }
        
        foreach( var k_v  in Controllers.files.storage.current_files ){ 

            int id = k_v.Value.id;
            string path = Controllers.files.storage.Get_path_for_file( k_v.Value );

            if( System_run.saving_show_messages )
                { Console.Log( $"--- have id " + id ); }

            File_IO_operation operation = default;

            if( System.IO.File.Exists( path ) )
                { operation = File_IO_operation._switch; }
                else
                { operation = File_IO_operation._create; }
                

            File_run_time_saving_operations.Save_file_run_time( k_v.Value, operation );

            dic[ id ] = operation;
            
        }

        
        if( System_run.saving_show_messages )
            { Console.Log( "Will loop throught the cached files:" ); }

        foreach( var k_v  in Controllers.files.storage.cached_data_files ){

            Data_file_link data = k_v.Value;
            string path =  k_v.Key;

            
            File_IO_operation operation = default;

            if( System.IO.File.Exists( path ) )
                { operation = File_IO_operation._switch; }
                else
                { operation = File_IO_operation._create; }
                

            File_run_time_saving_operations.Save_file_run_time( k_v.Value, operation );

            dic[ data.id ] = operation;
            
        }


        if( System_run.saving_show_messages )
            { Console.Log( "Will loop throught the deleted files:" ); }

        foreach( var k_v  in Controllers.files.storage.deleted_files ){

            Data_file_link data = k_v.Value;
            string path =  k_v.Key;

                        
            if( System_run.saving_show_messages )
                { Console.Log( $"--- have id " + data.id ); }

            File_IO_operation operation = default;

            if( System.IO.File.Exists( path ) )
                { operation = File_IO_operation._delete; }
                else
                { operation = File_IO_operation._nothing; }
                

            File_run_time_saving_operations.Save_file_run_time( k_v.Value, operation );
            dic[ data.id ] = operation;
            
        }


        int max_id = dic.Keys.Max();
        int[] actions_ints = new int[ max_id + 1 ];

        foreach( int id in dic.Keys )
            { actions_ints[ id ] = (int) dic[ id ]; }

        _req.managed_data.int_array = actions_ints;
        
    }


    public static void Create_security_file( Task_req _req ){

        Files.Save_critical_file( Paths_run_time.saving_files_security_file, new byte[ 500 ] );

    }

    public static void Apply_actions_files_in_saving_folder( Task_req _req ){

        string[] paths_of_slots =_req.managed_data.string_array;
        int[] operations_array = _req.managed_data.int_array;

        if( paths_of_slots.Length != operations_array.Length )
            { CONTROLLER__errors.Throw( $"the links files have less ids than operatiosn. Operations: { operations_array.Length } links: { paths_of_slots.Length }" ); }

        int _testing = _req.data.int_values[ 69 ];

        for( int file_id = 0 ; file_id < operations_array.Length ; file_id++ ){

            // jump last
            if( ( _testing == 1 )  && ( file_id == operations_array.Length - 1 ) )
                { break; }

            // go to last
            if( _testing == 2 )
                    { file_id = operations_array.Length - 1; }

            File_IO_operation operation = ( File_IO_operation ) operations_array[ file_id ];

            if(  operation == default )
                { continue; }

            string final_path = paths_of_slots[ file_id ];
            string path_in_disk_saving_folder = File_run_time_saving_operations.Get_run_time_path( file_id, operation );
            string temp_path = File_run_time_saving_operations.Get_run_time_path_TEMP( final_path, operation );


            if( final_path == null )
                { CONTROLLER__errors.Throw( $"final path is null. File id { file_id }, operation { operation }" ); }
            
            if( !!!( System.IO.File.Exists( path_in_disk_saving_folder ) ) )
                { CONTROLLER__errors.Throw( $"file dont exist in <Color=lightBlue>{ path_in_disk_saving_folder }</Color>" ); }


            if( operation == File_IO_operation._switch )
                {
                    if( !!!( System.IO.File.Exists( final_path ) ) )
                        { CONTROLLER__errors.Throw( "file dont exist in path : " + final_path ); }

                    if( !!!( System.IO.File.Exists( path_in_disk_saving_folder ) ) )
                        { CONTROLLER__errors.Throw( "file dont exist in path : " + path_in_disk_saving_folder ); }

                    try{
                        System.IO.File.Move( path_in_disk_saving_folder , temp_path );
                        System.IO.File.Delete( final_path );
                        System.IO.File.Move( temp_path, final_path );

                    }catch( Exception e ){
                        Console.Log( "path_in_disk_saving_folder: " + path_in_disk_saving_folder );
                        Console.Log( "temp_path: " + temp_path );
                    }

                }

            if( operation == File_IO_operation._create )
                {
                    if( System.IO.File.Exists( final_path ) )
                        { CONTROLLER__errors.Throw( "file exist and should NOT in path : " + final_path ); }

                    if( !!!( System.IO.File.Exists( path_in_disk_saving_folder ) ) )
                        { CONTROLLER__errors.Throw( "file dont exist in path : " + path_in_disk_saving_folder ); }                    


                    System.IO.File.Move( path_in_disk_saving_folder , final_path );

                }

            if( operation == File_IO_operation._delete )
                {
                    
                    if( !!!( System.IO.File.Exists( final_path ) ) )
                        { CONTROLLER__errors.Throw( "file dont exist in path : " + final_path ); }

                    if( !!!( System.IO.File.Exists( path_in_disk_saving_folder ) ) )
                        { CONTROLLER__errors.Throw( "file dont exist in path : " + path_in_disk_saving_folder ); }

                    System.IO.File.Move( path_in_disk_saving_folder , temp_path );
                    System.IO.File.Delete( final_path );
                    System.IO.File.Delete( temp_path );
                }

            

        }



    }


    public static void Reset_stack( Task_req _req ){

        if( Controllers.stack.saver.strem_stack != null )
            { Controllers.stack.saver.Clean_file(); }
            else
            { Files.Save_critical_file( Paths_run_time.safety_stack_file, new byte[ 100_000 ] ); }  
        
        return;

    }

    public static void Delete_saving_folder( Task_req _req ){

        if( !!!( Directories.Is_sub_path( Paths_run_time.saving_files_folder, Paths_version.path_to_version ) ) )
            { CONTROLLER__errors.Throw( "path wrong" ); }

        System.IO.Directory.Delete( Paths_run_time.saving_files_folder, true );

    }

    public static void Delete_file_links( Task_req _req ){

        System.IO.File.Delete( Paths_run_time.saving_link_file_to_path );

    }

    public static void Save_stack_start_files( Task_req _req ){

        //mark
        // ** no file will be add or removed, because will NOT save in game, will stop when it can and wait it ends

        string[] start_lines = Controllers.files.storage.Get_current_links_lines();

        System.IO.File.Delete( Paths_run_time._stack_start_files );
        Files.Save_critical_file( Paths_run_time._stack_start_files, start_lines );

        return;

    }

    public static void End_saving( Task_req _req ){

        // ** clean all the heap pointer, delete paths, dics, etc
        Controllers.files.storage.Sinalize_saved_files();

    }



    public bool Is_saving_files_task_finished(){

        if( req_saving_files == null )
            { CONTROLLER__errors.Throw( "Tried to verify if the files already saved, but the task is <Color=lightBlue>NULL</Color>" ); }

        return req_saving_files.Is_finalized();

    }









}


