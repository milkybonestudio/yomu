
using System.IO;



unsafe public static class TOOL__folders_constructor {


    private const int LENGTH_SAFETY_FILES = 1_000_000;

    public static void Construct_new_persistent_data_path(){


            // --- PROGRAM DIRECTORY

                Directory.CreateDirectory( Paths_folders.program );

                    // --- DATA VERSION
                    Program_data_version data_version = Program_data_version.Construct();
                    Files.Save_file( Paths_files.program_data_version, ( void* )&data_version, sizeof( Program_data_version ) );

                    // --- DATA BRUTE DATA
                    Program_brute_data brute_data = default;
                    Program_brute_data.Construct( &brute_data );
                    Files.Save_file( Paths_files.program_brute_data, ( void* )&brute_data, sizeof( Program_brute_data ) );

                    // --- SAFETY FILE
                    byte[] safety_file = new byte[ LENGTH_SAFETY_FILES ];
                    
                    System.IO.File.WriteAllBytes( Paths_files.safety_data_stack, safety_file );
                    

            
            // --- CREATE SAVES FOLDERS


                Directory.CreateDirectory( Paths_folders.saves );

                Heap_data heap_data = default;
                Heap_data.Construct( &heap_data );

                for( int save_slot = 0 ; save_slot < 8 ; save_slot++ ){

                    string save_path = Paths_folders.Get_save( save_slot );
                    Directory.CreateDirectory( save_path );

                    string path_heap_data = Paths_files.Get_save_heap_data( save_slot );
                    Files.Save_file( path_heap_data, ( void* )&heap_data, sizeof( Heap_data ) );


                }




    }


}