
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

    private static IntPtr space_to_create_data;

    public static void Construct( string _path_to_persistent_location ){

        if( space_to_create_data.ToPointer() == null )
            { space_to_create_data = Marshal.AllocHGlobal( LENGTH_CREATE_FILE ); }

        // --- CREATE VERSION FOLDER

        Yomu_version version = System_information.version;
        string version_folder = Path.Combine( _path_to_persistent_location, Yomu_version.Get_name( version ) );

        if( System.IO.Directory.Exists( version_folder ) )
            { CONTROLLER__errors.Throw( $"Tried to create a new version folder but there is already a folder in { version_folder }" ); }

        // --- CREATE VERSIOn

        Directory.CreateDirectory( version_folder );

            // ** garante que não vai dar conflito/sobre-escrever folders
            Create_program_persistent_files( version_folder );
            Create_saves( version_folder );

    
        Marshal.FreeHGlobal( space_to_create_data );
        space_to_create_data = default;
    
        return;

    }
    

    private static void* Get_pointer(){

        void* pointer = space_to_create_data.ToPointer();

        if( pointer == null )
            { CONTROLLER__errors.Throw( "Pointer to transfer data was null" ); }

        return pointer;

    }

    private static void Create_program_persistent_files( string _version_path ){

        void* pointer = Get_pointer();


        string pre_version_path = Paths_version.path_to_version;

        Paths_version.Define_version_folder( _version_path );


        string program_path = Path.Combine( _version_path, Paths_version.program_name );

        Directory.CreateDirectory( program_path );

        // --- PROGAM DATA FILE

            if( LENGTH_CREATE_FILE <= sizeof( Program_data ) )
                { CONTROLLER__errors.Throw( "Size insufficient" ); }

            CONSTRUCTOR__program_data_file.Construct_new_program_file( ( Program_data* ) pointer );
            Save_file( Paths_program.program_data, pointer, sizeof( Program_data ) );

        // --- PACKED STORAGE

            Console.Log( "ver depois" );
            // CONSTRUCTOR__controller_packets_storage.Construct_SIMPLE_packed_storage_file( (Packet_storage*) pointer, LENGTH_CREATE_FILE );


        // --- SAVING RUN TIME

        Directory.CreateDirectory( Paths_program.saving_run_time_folder );
        
            Directory.CreateDirectory( Paths_program.safety_stack_folder );

        // ** se tiver algum arquivo aqui dentro o sistema foi encerrado incorretamente



        // ** VOLTA AO PADRAO
        Paths_version.Define_version_folder( pre_version_path );

        return;
    }


    private static void Create_saves( string _version_path ){


        string saves_path = Paths_version.Get_all_saves_folder( _version_path );
        Directory.CreateDirectory( saves_path );

        // ** specific for all saves

        // --- CREATE EACH SAVE FOLDER
        for( int save_slot = 0 ; save_slot < 8 ; save_slot++ ){ 
   
            string  save_path = Paths_version.Get_save_folder( saves_path, save_slot );
            // NORMAL   
            Create_save_files( save_path ); 

            // DEATH
            string save_DEATH = Paths_save.Get_save_death( save_path );
            Create_save_files( save_DEATH ); 

            continue;

        }

        return;

    }




    private static void Create_save_files( string _save_path ){

    
        Directory.CreateDirectory( _save_path );
        void* pointer = Get_pointer();


        string brute_data_path = Paths_save.Get_save_brute_data( _save_path );

        // --- SAVE_DATA

        string path_to_save_data = Paths_save.Get_save_data( _save_path );
        Save_data.Construct( (Save_data*) pointer );
        Save_file( path_to_save_data, pointer, sizeof( Save_data ) );

        // --- IMAGE

        //mark
        // ** fazer depois

        // --- HEAP

        string heap_data_path = Paths_save.Get_save_heap_data( _save_path );

        Save_file( heap_data_path, ( void* )&pointer, sizeof( Heap_data ) );


    }

    private static void Save_file( string _path, void* _pointer, int _size ){

        Files.Save_file( _path, _pointer, _size );

        // ** CLEAN POINTER 

        if( _size > 1_000 )
            {
                UnsafeUtility.MemClear( _pointer, ( long ) _size );
            }
            else
            {
                int* int_pointer = ( int* ) _pointer;
                int number_big_loops = ( _size / 4 );
                for( int i = 0 ; i < number_big_loops ; i++, int_pointer++ )
                    { *( int_pointer ) = 0; }
                
                int rest = ( _size % 4 );
                byte* byte_pointer = ( byte* )int_pointer;
                for( int k = 0 ; k < rest ; k++, byte_pointer++ )
                    { *byte_pointer = ( byte )0; }
                
                
            }


    }


}