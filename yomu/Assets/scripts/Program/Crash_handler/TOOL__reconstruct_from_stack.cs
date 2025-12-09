


using System.Collections.Generic;
using System.IO;
using System.Linq;


unsafe public static class TOOL__reconstruct_from_stack{

    public static Stack_reconstruction_result_message Reconstruct(){


        if( System_run.show_program_construction_messages )
            {
                Console.Log( "Will reconstruct the files with the stack()" );
                Console.Log( "WIll delete_all the files in the saving_files_run_time with any other half file" );
            }

        // cuidar que stack_start_files pode estar desatualizado ou atualizado

        // --- nao vai mais estar no run time, vai estar no version, mas não vai dar problemas
        // --- os links tem que tambem manter uma coerencia entre as runs, ids dentro de structs/files não podem se preocupar com "esse id é valido?"
        
        
        Controllers.paths_ids.Define_paths_ids( Paths_version.paths_ids );

        Controllers.context.Force_change_context( Crash_handler.context_path ); // ** change the files to the old ones 

        
        int[] old_files_ids = Controllers.files.storage.Get_current_files_ids();

        for( int index = 0 ; index < old_files_ids.Length ; index++ ){

            string path = Controllers.paths_ids.Get_path_from_id( old_files_ids[ index ] );

            if( ( path == null ) || ( path == "" ) )
                { continue; }

            if ( !!!( Directories.Is_sub_path( path, Paths_version.path_to_version ) ) )
                { return Stack_reconstruction_result_message.Construct( $"The path <Color=lightBlue>{ path }</Color> is not part of the program path <Color=lightBlue>{ Paths_version.path_to_version }</Color>", Stack_reconstruction_result.fail ); }
                
            if( !!!( System.IO.File.Exists( path ) ) )
                { return Stack_reconstruction_result_message.Construct( $"Should have a file in the path <Color=lightBlue>{ path }</Color>", Stack_reconstruction_result.fail ); }

            Controllers.files.operations.Get_file_from_disk( path );

            continue;

        }
        
        if( System_run.show_program_construction_messages )
            { Console.Log( "Will create the folder again empty" ); }
            
        System.IO.Directory.CreateDirectory( Paths_run_time.saving_files_folder );

        if( System_run.show_program_construction_messages )
            { Console.Log( "Will reconstruct the files in ram" ); }


        // ** SPLIT STACK BLOCKS
        byte[] stack_file = Crash_handler.stack_file;
        fixed( byte* pointer_stack = stack_file ){

            int max_length_stack = stack_file.Length;
            int index_in_file = 0;

            while( true ){

                byte* block_pointer = ( pointer_stack + index_in_file );

                int* int_pointer_start = (int*) block_pointer;

                    int block_id = int_pointer_start[ 0 ];
                    int length_block = int_pointer_start[ 1 ]; // ** data + signature + safety -> data + 16 bytes

                    index_in_file += length_block;

                if( System_run.show_program_construction_messages )
                    { Console.Log( $"--- <Color=lightBlue>RECEIVE BLOCK { block_id } and LENGHT { length_block } ----</Color> " ); }
                
                if( ( ( block_id == 0 ) && ( length_block == 0 ) ) || !!!( MANAGER__safety_stack_saver.Security_values_are_OK( block_pointer, length_block ) ) )
                    { 
                        if( System_run.show_program_construction_messages )
                            { Console.Log( "Came to the end of a valid blocks" ); }
                        break; 
                    }
                
                #if UNITY_EDITOR
                    if( block_id == INT.Return_int_4_bytes_asc2( '-' ) ){ break; } // ** to not destroy my eyes I use "-" insted of 0-> "null"
                #endif

                // ** FILE IS OK

                //Stack_reconstruction_result_message result_message = TOOL__handle_stack_BLOCKS.Handle_stack_block( files_in_system, files_OS, block_id, block_pointer, length_block );
                Stack_reconstruction_result_message result_message = TOOL__handle_stack_BLOCKS.Handle_stack_block( block_id, block_pointer, length_block );

                if( result_message.result == Stack_reconstruction_result.fail )
                    { return result_message; }

                
                if( index_in_file < max_length_stack  )
                    { break; }

                continue;

            }

        }
        

        if( System_run.show_program_construction_messages )
            { 
                Console.Log( "All the files in the files[] should already be with the correct state. Will continue with the normal flow of saving the data in case crash when reconstructing" ); 
                Console.Log( "Will save the paths updated" );
            }


        MANAGER__controller_saving_saver.Save_files( new Task_req() );

        // ** SAVE NEW CONTEXT
        string new_context = Controllers.context.Create_program_context_file(
            _current_files_ids: Controllers.files.storage.Get_current_files_ids(),
            _current_packets_storages: Controllers.packets.storage.Get_current_ids()
        );
        Console.Log( new_context );
        
        Files.Save_critical_file( Paths_run_time.context_new, new_context );

        // ** SAVE NEW FILE LINKS

        string[] new_paths_ids = Controllers.paths_ids.Get_current_paths_ids();
        Files.Save_critical_file( Paths_run_time.new_paths_ids, new_paths_ids );
        



        return Stack_reconstruction_result_message.Construct( null, Stack_reconstruction_result.succes );

    }


    private static void Save_files_in_saving_files_folder( Crash_handle_ephemeral_files _files_OS, Crash_cached_files _files ){

        if( System_run.show_program_messages )
            { Console.Log( "Will save the files in the folder saving_files_run_time in the slot.dat format. if the system crashes when recosntruct the stack it can start over again" ); }

        // ** pass data for cached_files -> file_OS

        string[] active_paths = _files_OS.Get_active_paths();

        Files.Save_critical_file( Paths_run_time.new_paths_ids, active_paths );

            for( int path_index = 0  ; path_index < active_paths.Length ; path_index++ ){

                /*jump 0*/
                if( path_index == 0 )
                    { continue; }

                string path = active_paths[ path_index ];

                // ** path -> arquivo mudou
                File_IO_operation operation = default;
                byte[] data = _files_OS.Get_file( path );

                bool have_data_in_cache = ( data != null );
                // bool file_exist_in_real_disk = System.IO.File.Exists( path );

                if( have_data_in_cache )
                    { operation = File_IO_operation._add; }
                    else
                    { operation = File_IO_operation._delete; }

                string path_in_saving_files = File_run_time_saving_operations.Get_run_time_path( path_index, operation );
                data ??= new byte[ 100 ];

                Files.Save_critical_file( path_in_saving_files, data );

            }


        if( System_run.show_program_construction_messages )
            { Console.Log( "Will create the safety_file" ); }


    }



}