


using System.Linq;

unsafe public static class TOOL__reconstruct_from_stack{

    public static Stack_reconstruction_result_message Reconstruct(){


        if( System_run.show_program_construction_messages )
            {
                Console.Log( "Will reconstruct the files with the stack()" );
                Console.Log( "WIll delete_all the files in the saving_files_run_time with any other half file" );
            }

        // cuidar que stack_start_files pode estar desatualizado ou atualizado
        string[] start_paths = System.IO.File.ReadAllLines( Paths_program.stack_start_files ); // ** only the files to save

        Crash_cached_file[] files = new Crash_cached_file[ start_paths.Length ];
        Crash_handle_ephemeral_files files_OS = new Crash_handle_ephemeral_files();

        for( int index = 0 ; index < start_paths.Length ; index++ ){ 

            string path = start_paths[ index ];

            if( ( path == null ) || ( path == "" ) )
                { continue; }

            if ( !!!( Directories.Is_sub_path( path, Paths_version.path_to_version ) ) )
                { return Stack_reconstruction_result_message.Construct( $"The path <Color=lightBlue>{ path }</Color> is not part of the program path <Color=lightBlue>{ Paths_version.path_to_version }</Color>", Stack_reconstruction_result.fail ); }
                

            if( !!!( files_OS.Have_file( path ) ) )
                { return Stack_reconstruction_result_message.Construct( $"Should have a file in the path <Color=lightBlue>{ path }</Color>", Stack_reconstruction_result.fail ); }


            byte[] data = files_OS.Get_file( path );

            files[ index ].path = path;
            files[ index ].data = data;

            continue;

        }
        



        if( System.IO.Directory.Exists( Paths_program.saving_files_folder ) )
            { System.IO.Directory.Delete( Paths_program.saving_files_folder, true ); }
        

        if( System_run.show_program_construction_messages )
            { Console.Log( "Will create the folder again empty" ); }
            
        System.IO.Directory.CreateDirectory( Paths_program.saving_files_folder );

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
                    // ** data + signature + safety -> data + 16 bytes
                    int length_block = int_pointer_start[ 1 ];

                    index_in_file += length_block;

                if( System_run.show_program_construction_messages )
                    { Console.Log( $"--- <Color=lightBlue>RECEIVE BLOCK { block_id } and LENGHT { length_block } ----</Color> " ); }
                

                if( ( block_id == 0 ) || ( length_block == 0 ) )
                    { 
                        if( System_run.show_program_construction_messages )
                            { Console.Log( "Came to the end of blocks" ); }
                        break; 
                    }
                
                #if UNITY_EDITOR

                    // ** to not destroy my eyes I use "-" insted of 0-> "null"
                    if( block_id == INT.Return_int_4_bytes_asc2( '-' ) )
                        { break; }

                #endif

                if( !!!( MANAGER__safety_stack_saver.Security_values_are_OK( block_pointer, length_block ) ) )
                    { 
                        Console.Log( "block was saving when crash. Will discart it" );
                        break; 
                    } 

                // ** FILE IS OK

                Stack_reconstruction_result_message result_message = TOOL__handle_stack_BLOCKS.Handle_stack_block( ref files, files_OS, block_id, block_pointer, length_block );

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

        if( System_run.show_program_construction_messages )
            {}

        Files.Save_critical_file( Paths_program.saving_link_file_to_path,  files.Select( s => s.path ).ToArray() );


        Save_files_in_saving_files_folder( files_OS, files );


        if( System_run.show_program_construction_messages )
            { Console.Log( "Will create the safety_file" ); }

        Files.Save_critical_file( Paths_program.saving_files_security_file, new byte[]{ 0,0 } );

        // ** poderia simplesmente chamar em cima de novo

        return Stack_reconstruction_result_message.Construct( null, Stack_reconstruction_result.succes );

    }


    private static void Save_files_in_saving_files_folder( Crash_handle_ephemeral_files _files_OS, Crash_cached_file[] _files ){

        if( System_run.show_program_messages )
            { Console.Log( "Will save the files in the folder saving_files_run_time in the slot.dat format. if the system crashes when recosntruct the stack it can start over again" ); }
  

        for( int index_file = 0 ; index_file < _files.Length ; index_file++ ){
            
            Crash_cached_file file = _files[ index_file ];

            if( file.path == null || ( file.path == "" ) )
                { continue; } // ** no files

            File_IO_operation operation = default;

            if( file.Is_deleted() )
                { operation = File_IO_operation._delete; }

            if( file.Have_content()  && !!!( _files_OS.Have_file( file.path ) ) )
                { operation = File_IO_operation._create; }

            if( file.Have_content()  && _files_OS.Have_file( file.path )  )
                { operation = File_IO_operation._switch; }


            string temp_name = File_run_time_saving_operations.Get_run_time_path( index_file, operation );
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

    



}