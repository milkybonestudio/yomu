



using System;
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

        System.Object _lock_object = Controllers.files.operations.lock_obj;

        req_saving_files = Controllers.tasks.Get_task_request( "saving files" );

        req_saving_files.Give_lock_object( _object_to_lock: _lock_object, _enter: true  );

        // ** SAVE THE STACK IN DISK
        Controllers.stack.Sinalize_will_save_files();
        Controllers.stack.saver.Give_multithread_saving_stack( req_saving_files );

        // ** SAVE LINK_FILE
        req_saving_files.Give_multithread_sequencial_action( MANAGER__controller_saving_saver.Save_link_paths );

        req_saving_files.Give_multithread_sequencial_action( MANAGER__controller_saving_saver.Save_files );

        req_saving_files.Give_multithread_sequencial_action(( Task_req _req)=>{

            Controllers.stack.saver.Clean_file();

        });

        req_saving_files.Give_multithread_sequencial_action( MANAGER__controller_saving_saver.Save_stack_start_files );

        return;

    }



    public bool Finish_saving_files(){

        if( req_saving_files == null )
            { CONTROLLER__errors.Throw( "Tried to verify if the files already saved, but the task is <Color=lightBlue>NULL</Color>" ); }

        return req_saving_files.Is_finalized();

    }

    public static void Save_files( Task_req _req ){

        System.IO.Directory.CreateDirectory( Paths_program.saving_files_folder );

        Data_file_link[] current_datas = Controllers.files.storage.current_files.Values.ToArray();
        Data_file_link[] deleted_datas = Controllers.files.storage.deleted_files.Values.ToArray();



        // ** SAVE FILES IN DISK
        
        foreach( Data_file_link data in current_datas ){ 

            string path = Controllers.files.storage.Get_path_for_file( data );
            if( System.IO.File.Exists( path ) )
                { File_run_time_saving_operations.Save_file_run_time( data, File_IO_operation._switch );  }
                else
                { File_run_time_saving_operations.Save_file_run_time( data, File_IO_operation._create );  }
            
        }

        foreach( var k_v  in Controllers.files.storage.cached_data_files ){

            Data_file_link data = k_v.Value;
            string path =  k_v.Key;

            if( System.IO.File.Exists( path ) )
                { File_run_time_saving_operations.Save_file_run_time( data, File_IO_operation._switch );  }
                else
                { File_run_time_saving_operations.Save_file_run_time( data, File_IO_operation._create );  }
            
        }

        foreach( var k_v  in Controllers.files.storage.deleted_files ){

            Data_file_link data = k_v.Value;
            string path =  k_v.Key;

            if( System.IO.File.Exists( path ) )
                { File_run_time_saving_operations.Save_file_run_time( data, File_IO_operation._delete );  }
                else
                { File_run_time_saving_operations.Save_file_run_time( data, File_IO_operation._nothing );  }
            
        }




        // ** OPERATIONS

        
        foreach( Data_file_link data in current_datas ){ 

            string path = Controllers.files.storage.Get_path_for_file( data );

            // File_run_time_saving_operations.Finish_switch_file( data );

        }





    }


    public static void Save_stack_start_files( Task_req _req ){


        int max_key = Controllers.files.storage.id_TO_path.Keys.Max();

        string[] result = new string[ ( max_key + 1 ) ];

        foreach (var kv in Controllers.files.storage.id_TO_path ) 
            { result[ kv.Key ] = kv.Value; }

        Files.Save_critical_file( Paths_program.stack_start_files, result );

        return;

    }


    public static void Save_link_paths( Task_req _req ){


        int current_max = Controllers.files.storage.id_TO_path.Keys.Max();
        int cached_max = Controllers.files.storage.cached_data_files.Values.Max( s => s.id );
        int max_deleted = Controllers.files.storage.deleted_files.Values.Max( s => s.id );

        int max_key = Math.Max( current_max, Math.Max( cached_max, max_deleted ) );

        string[] result = new string[ ( max_key + 1 ) ];

        foreach (var kv in Controllers.files.storage.id_TO_path ) 
            { result[ kv.Key ] = kv.Value; }

        
        foreach (var kv in Controllers.files.storage.cached_data_files ){ 

            if( result[ kv.Value.id ] != null )
                { CONTROLLER__errors.Throw( $"Tried to creat the new link_paths, but id <Color=lightBlue>{ kv.Value.id }</Color> got duplicated" ); }

            result[ kv.Value.id ] = kv.Key;

        }
        foreach (var kv in Controllers.files.storage.deleted_files ){ 

            if( result[ kv.Value.id ] != null )
                { CONTROLLER__errors.Throw( $"Tried to creat the new link_paths, but id <Color=lightBlue>{ kv.Value.id }</Color> got duplicated" ); }

            result[ kv.Value.id ] = kv.Key;

        }

        
        // ** need to be on the NEW_path because if the system crashes before saved all the files in disk
        // ** it needs to use the old links to reconstruct the stack. this current_links and the one the Reconstruct_stack() 
        // ** should be the same, so same behaviour
        Files.Save_critical_file( Paths_program.saving_link_file_to_path, result );

        return;

    }


}