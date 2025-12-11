
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

        // ** SAVE FILES
        
            // ** the files will be in majority in cached 
            Controllers.files.storage.Force_syncronize_to_disk_PROGRAM_CONSTRUCTOR();
            
            Controllers.stack.Reset_stack();
            Controllers.files.Reset_files();
            
            Controllers.paths_ids.Save_current_paths_in_disk();

        // --- SAFETY FILE

            Files.Save_critical_file( Paths_version.security_file, new byte[]{ 55, 55, 55 } );
    
        return;

    }
    

    private static void Create_program_folder(){

        Directory.CreateDirectory( Paths_version.program );

        // --- PACKED STORAGE

            Packet_storage_start_data program_storage_data = CONSTRUCTOR__controller_packets_storage.Get_SIMPLE_args();
            Packets_storage storage_program = Controllers.packets.operations.Create_new_storage( Paths_program.program_storage_SIMPLE, program_storage_data );

            


        // --- CURRENT PACKETS_STORES

            Files.Save_critical_file( Paths_program.current_packets_storages, new string[]{ "null" }  );
            
        
        // --- PROGAM DATA FILE

            Program_data* pointer_program = ( Program_data* ) Controllers.heap.Get_fast_pointer( sizeof( Program_data ) );
            CONSTRUCTOR__program_data_file.Construct_new_program_file(  ( Program_data* ) pointer_program );
            Controllers.files.operations.Create_new_file( pointer_program, sizeof( Program_data ), Paths_program.program_data );
            

        

        
        Controllers.context.Save_current_data_as_context( Paths_program.program_context );



        return;
    }

    
    private static void Create_saves_folder(){


        Directory.CreateDirectory( Paths_version.saves );

        // ** specific for all saves

        
        // --- CREATE EACH SAVE FOLDER
        for( int save_slot = 0 ; save_slot < 8 ; save_slot++ )
            { Create_save_folder( save_slot ); }

        Paths_current_save.Start_save( 0 );

        return;

    }


    private static void Create_save_folder( int _save ){

        // ** starts with program
        Program_context context_start = Controllers.context.Get_context_with_path( Paths_program.program_context );
        // ** dont have side effects on controller_context
        Controllers.context.Change_context_data( context_start );

        Paths_current_save.Start_save( _save );

        // NORMAL   
        Directory.CreateDirectory( Paths_current_save.save_path );
        
        // DEATH
        Directory.CreateDirectory( Paths_current_save.save_death );


        // ** crate

        Save_data* pointer_program = ( Save_data* ) Controllers.heap.Get_fast_pointer( sizeof( Save_data ) );
        Controllers.files.operations.Create_new_file( pointer_program, sizeof( Save_data ), Paths_current_save.brute_data );

        
        Controllers.context.Save_current_data_as_context( Paths_current_save.save_context );


        return;

    }





}