
using System;
using System.IO;
using System.Runtime.InteropServices;
using Unity.Collections.LowLevel.Unsafe;


// ** criar root ( versao )
// ** criar folders saves + program
// ** criar program
// ** criar saves 


unsafe public static class TOOL__version_folders_constructor {


    private const int LENGTH_SAFETY_FILES = 1_000_000;
    private const int LENGTH_CREATE_FILE = 2_500_000;

    public static void Construct(){

        Directory.CreateDirectory( Paths_system.persistent_data );
        Create_program_folder();
        Create_saves_folder();


        Controllers.files.operations.Create_new_file_EMPTY( Paths_program.program_data + ".aaa", 100  );
        Controllers.files.operations.Create_new_file_EMPTY( Paths_program.program_data + ".bbb", 100 );
        
        Controllers.files.storage.Force_syncronize_to_disk_PROGRAM_CONSTRUCTOR();

        // ** SAVE FILES
        Program_context_operations.Save_current_data_as_context( Paths_program.program_context );

        // ** PATHS
        Controllers.paths_ids.Save_current_paths_in_disk();
        

        
        Controllers.stack.Reset_stack();
        Controllers.files.Reset_files();
        

        // --- SAFETY FILE

            Files.Save_critical_file( Paths_version.security_file, new byte[]{ 55, 55, 55 } );

    
        return;

    }
    

    private static void Create_program_folder(){

        Directory.CreateDirectory( Paths_version.program );

        // --- PROGAM DATA FILE

            Program_data* pointer_program = ( Program_data* ) Controllers.heap.Get_fast_pointer( sizeof( Program_data ) );
            CONSTRUCTOR__program_data_file.Construct_new_program_file(  ( Program_data* ) pointer_program );
            Controllers.files.operations.Create_new_file( pointer_program, sizeof( Program_data ), Paths_program.program_data );
            
        // --- PACKED STORAGE

        if( false )
            {
                Packet_storage_start_data program_storage_data = CONSTRUCTOR__controller_packets_storage.Get_SIMPLE_args();
                
                int length_storage_program = program_storage_data.Get_file_length();
                void* pointer_storage_program = Controllers.heap.Get_fast_pointer( length_storage_program );

                Controllers.packets.creation.Apply_create_data( pointer_storage_program, length_storage_program , program_storage_data );

                Files.Save_critical_file( Paths_program.program_storage_SIMPLE, pointer_storage_program, length_storage_program );
            // --- CURRENT PACKETS_STORES

                Files.Save_critical_file( Paths_program.current_packets_storages, new string[]{ "null" }  );
                
            }





        return;
    }

    
    private static void Create_saves_folder(){


        Directory.CreateDirectory( Paths_version.saves );

        // ** specific for all saves

        
        // --- CREATE EACH SAVE FOLDER
        for( int save_slot = 0 ; save_slot < 8 ; save_slot++ )
            { Create_save_folder( save_slot ); }

        return;

    }


    private static void Create_save_folder( int _save ){

        // NORMAL   
        string  save_path = Paths_saves.Get_save_folder( _save );
        Directory.CreateDirectory( save_path );
        
        // DEATH
        string save_DEATH = Paths_current_save.Get_save_death( save_path );
        Directory.CreateDirectory( save_DEATH );

        return;

    }





}