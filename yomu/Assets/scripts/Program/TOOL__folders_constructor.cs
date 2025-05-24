
using System.IO;



unsafe public static class TOOL__folders_constructor {


    private const int LENGTH_SAFETY_FILES = 1_000_000;

    public static void Construct_new_persistent_data_path(){


            // --- PROGRAM DIRECTORY

                if( System.IO.Directory.Exists( Paths_system.persistent_data_path ) )
                    { CONTROLLER__errors.Throw( $"Tried to create a new persistent_data folder but there is a folder in { Paths_system.persistent_data_path }" ); }

                Directory.CreateDirectory( Paths_system.persistent_data_path );

                Directory.CreateDirectory( Paths_folders.program );

                    // --- DATA VERSION

                    byte[] version = CONTROLLER__yomu_version.Get_verion();

                    fixed ( byte* pointer = version )
                        {

                            Files.Save_file( Paths_files.persistent_data_version, ( void* )pointer, version.Length );

                        }

                    // --- DATA BRUTE DATA
                    Program_data program_data = default;
                    //??
                    CONSTRUCTOR__program_data_file.Construct_new_program_file( &program_data );
                    Files.Save_file( Paths_files.program_data, ( void* )&program_data, sizeof( Program_data ) );

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