



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

        
        req_saving_files.Give_multithread_sequencial_action( Save_logic_files );
        req_saving_files.Give_multithread_sequencial_action( Save_files );
        req_saving_files.Give_multithread_sequencial_action( Apply_actions_files_in_saving_folder );
        req_saving_files.Give_multithread_sequencial_action( Move_logic_files );
        req_saving_files.Give_multithread_sequencial_action( Finish_saving );
        
        req_saving_files.Give_single_final( End_saving );

        return;

    }


    public void Force_save_synchronous_safe(){

        // ** SAVE STACK
        Task_req req_stack = Controllers.stack.saver.Sinalize_to_save();
            req_stack.fn_multithread( req_stack );
            req_stack.stage = Task_req_stage.finished;
        Controllers.stack.buffer.Return_pointer_to_pass_data_to_disk();

        // ** GO FILES
        Task_req req = new Task_req( "Save_synchronous" );

            Save_logic_files( req );
            Save_files( req );
            Apply_actions_files_in_saving_folder( req );
            Move_logic_files( req );
            Finish_saving( req );

        End_saving( req );

        return;

    }

    


    public static void Save_logic_files( Task_req _req ){

        // ** CONTEXT
        int[] current_files_ids = Controllers.files.storage.Get_current_files_ids();
        int[] current_packets_ids = Controllers.packets.storage.Get_current_ids();

        string context = Controllers.context.Create_program_context_file( _current_files_ids: current_files_ids, _current_packets_storages: current_packets_ids );

        Files.Save_critical_file( Paths_run_time.context_new, context );

        // ** PATHS
        string[] current_paths_ids = Controllers.paths_ids.Get_current_paths_ids();

        Files.Save_critical_file( Paths_run_time.new_paths_ids, current_paths_ids );


        // ** create folder to save files
        System.IO.Directory.CreateDirectory( Paths_run_time.saving_files_folder );

        // ** define state
        Files.Save_critical_file( Paths_run_time.logic_data_saved, new byte[ 100 ] );

        return;

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

            File_run_time_saving_operations.Save_file_run_time( k_v.Value, File_IO_operation._add );

            dic[ id ] = File_IO_operation._add;
            
        }

        
        if( System_run.saving_show_messages )
            { Console.Log( "Will loop throught the cached files:" ); }

        foreach( var k_v  in Controllers.files.storage.cached_data_files ){

            Data_file_link data = k_v.Value;
            string path =  k_v.Key;

            File_run_time_saving_operations.Save_file_run_time( k_v.Value, File_IO_operation._add );

            dic[ data.id ] = File_IO_operation._add;
            
        }


        if( System_run.saving_show_messages )
            { Console.Log( "Will loop throught the deleted files:" ); }

        foreach( var k_v  in Controllers.files.storage.deleted_files ){

            Data_file_link data = k_v.Value;
            string path =  k_v.Key;
                        
            if( System_run.saving_show_messages )
                { Console.Log( $"--- have id " + data.id ); }

            File_run_time_saving_operations.Save_file_run_time( k_v.Value, File_IO_operation._delete);
            dic[ data.id ] = File_IO_operation._delete;
            
        }


        int max_id = dic.Keys.Max();
        int[] actions_ints = new int[ max_id + 1 ];

        foreach( int id in dic.Keys )
            { actions_ints[ id ] = (int) dic[ id ]; }

        _req.managed_data.int_array = actions_ints;

        // ** define state
        Files.Save_critical_file( Paths_run_time.data_files_saved_in_folder, new byte[ 100 ] );
        
    }





    public static void Apply_actions_files_in_saving_folder( Task_req _req ){

        string[] paths_of_slots = Controllers.paths_ids.Get_current_paths_ids(); // File.ReadAllLines( Paths_run_time.new_paths_ids );
        int[] operations_array = _req.managed_data.int_array;

        int _testing = _req.data.int_values[ 69 ];

        for( int file_id = 0 ; file_id < operations_array.Length ; file_id++ ){

            
            if( ( _testing == 1 )  && ( file_id == operations_array.Length - 1 ) ){ break; }// jump last
            if( _testing == 2 ){ file_id = operations_array.Length - 1; }// go to last

            
            File_IO_operation operation = ( File_IO_operation ) operations_array[ file_id ];

            if( operation == default )
                { continue; }

            string final_path = paths_of_slots[ file_id ];
            string path_in_disk_saving_folder = File_run_time_saving_operations.Get_run_time_path( file_id, operation );
            string temp_path = File_run_time_saving_operations.Get_run_time_path_TEMP( final_path, operation );


            if( final_path == null )
                { CONTROLLER__errors.Throw( $"final path is null. File id { file_id }, operation { operation }" ); }
            
            if( !!!( System.IO.File.Exists( path_in_disk_saving_folder ) ) )
                { CONTROLLER__errors.Throw( $"file dont exist in <Color=lightBlue>{ path_in_disk_saving_folder }</Color>" ); }

            switch( operation ){
                case File_IO_operation._add: Files.Try_override( path_in_disk_saving_folder, final_path ); break;
                case File_IO_operation._delete: Files.Try_delete( final_path ); File.Delete( path_in_disk_saving_folder ); break;
            }
            

        }


        // ** define state
        Files.Save_critical_file( Paths_run_time.data_files_actions_applied, new byte[ 100 ] );

        if( _testing != 0 )
            { File.Delete( Paths_run_time.data_files_actions_applied ); }

        return;

    }


    public static void Move_logic_files( Task_req _req ){

        string path_to_context = Paths_run_time.path_to_file_with_context_path;
        Files.Try_override( Paths_run_time.context_new, File.ReadAllText( path_to_context ) );
        Files.Try_override( Paths_run_time.new_paths_ids, Paths_version.paths_ids );

        // ** define state
        Files.Save_critical_file( Paths_run_time.saving_finished, new byte[ 100 ] );

        return;

    }

    public static void Finish_saving( Task_req _req ){

        if( Controllers.stack.saver.strem_stack != null )
            { Controllers.stack.saver.Clean_file(); }
            
        Directories.Delete_safe( Paths_run_time.saving_files_folder );

        // ** delete states

            System.IO.File.Delete( Paths_run_time.logic_data_saved );
            System.IO.File.Delete( Paths_run_time.data_files_saved_in_folder );
            System.IO.File.Delete( Paths_run_time.data_files_actions_applied );
            System.IO.File.Delete( Paths_run_time.saving_finished );

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


