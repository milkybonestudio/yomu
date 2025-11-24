

using System;
using System.IO;
using System.Runtime.InteropServices;
using UnityEngine;

unsafe public static class TEST__files{


    /*

        teste: 
            operations: 
                --> get file that are in the system
                    --> handle dont have file ( OK )
                    --> handle invalid inputs ( OK )
                    --> works normal ( OK )
                --> get file from disk
                    --> normal
                        --> handle already in system ( OK )
                        --> handles file dont exist in final disk( OK )
                        --> handle dont exist because is deleted ( OK )
                        --> handles wrong paths ( OK )
                        --> works normal ( OK )
                        --> works with stack ( OK )
                    --> with cached files 
                        --> works with stack ( OK )
                        --> heap_data transfered ( OK )
                        
                --> remove file
                    --> works normal ( OK )
                    --> worsk with stack ( OK )
                    --> add the files to cached_files ( OK )
                    --> handles dont have file ( OK )
                    --> handles incorrect data ( OK )

                --> delete file
                    --> works normal ( OK )
                        --> giving data, paths
                    --> works with stack ( OK )
                    --> delete file in cache ( OK )
                    --> handle delete a file is already deleted ( OK )
                    --> handles file don't exist ( OK )
                    --> handlers wrong data ids ( OK )
                    --> handle wrong paths ( OK )

                --> create new file
                    --> works normal ( OK )
                    --> works with stack ( OK )
                    --> handles bad paths ( OK )
                    --> handle file already exist  ( OK )
                    --> can create if is deleted ( OK )
                    --> handle invalid data ( OK )

                --> create new file EMPTY
                    --> work normal ( OK )
                    --> works with stack ( OK )
                    --> handles wrong paths ( OK )
                    --> handles wrong data ( OK )

                --> change length file
                    --> works normal ( OK )
                    --> work with stack ( OK )
                    --> handles invalid inputs ( OK )
    
    */
    static string path_1;
    static string path_2;
    static string path_3;
    static string path_4_IN_DISK_NOT_SYSTEM;
    static string path_5_NOT_EXIST;
    static string path_6_OUT_BOUNDS;

    static Data_file_link data_1;
    static Data_file_link data_2;
    static Data_file_link data_3;

    static Data_file_link data_WRONG_0_id;
    static Data_file_link data_WRONG_negative_id;
    static Data_file_link data_WRONG_not_used_id;




    public static void Set(){

        data_WRONG_0_id = new Data_file_link(){ id = 0 };
        data_WRONG_negative_id = new Data_file_link(){ id = -10 };
        data_WRONG_not_used_id = new Data_file_link(){ id = 100 };

        path_1 = Path.Combine( Paths_program.program_path, "test_1.dat" );
        path_2 = Path.Combine( Paths_program.program_path, "test_2.dat" );
        path_3 = Path.Combine( Paths_program.program_path, "test_3.dat" );
        path_4_IN_DISK_NOT_SYSTEM = Path.Combine( Paths_program.program_path, "test_4.dat" );
        path_5_NOT_EXIST = Path.Combine( Paths_program.program_path, "test_5.dat" );
        path_6_OUT_BOUNDS = Path.Combine( Paths_system.persistent_data, "test.txt" );

            System.IO.File.WriteAllBytes( path_1, ARRAY.Get_array<byte>( 10_000, (byte)'@' ) );
            System.IO.File.WriteAllBytes( path_2, ARRAY.Get_array<byte>( 10_000, (byte)'9' )  );
            System.IO.File.WriteAllBytes( path_3, ARRAY.Get_array<byte>( 10_000, (byte)'7' )  );
            System.IO.File.WriteAllBytes( path_4_IN_DISK_NOT_SYSTEM, ARRAY.Get_array<byte>( 10_000, (byte)'4' )  );

            System.IO.File.WriteAllBytes( path_6_OUT_BOUNDS, ARRAY.Get_array<byte>( 10_000, (byte)'&' )  );

            
            

        // Console.Log( "remvoer" );
        // return;

        data_1 = Controllers.files.operations.Get_file_from_disk( path_1 );
        data_2 = Controllers.files.operations.Get_file_from_disk( path_2 );
        data_3 = Controllers.files.operations.Get_file_from_disk( path_3 );



    }

    public static void Update(){

        // ** get file system
        if( Input.GetKey( KeyCode.Keypad1 ) )
            {
                // ** dont have file
                if( Input.GetKeyDown( KeyCode.Q ) )
                    {
                        Test.SHOULD_FAIL( "file dont exist", () => Controllers.files.operations.Get_file( ( path_1 + ".should_not_have" ) ) );
                    }


                // ** invalid inputs
                if( Input.GetKeyDown( KeyCode.W ) )
                    {
                        Test.SHOULD_FAIL( "error path null", () => Controllers.files.operations.Get_file( null ) );
                        // ** exists
                        Test.SHOULD_FAIL( "error path out of bounds", () => Controllers.files.operations.Get_file( path_6_OUT_BOUNDS ) );
                        Test.SHOULD_FAIL( "error path dont exist", () => Controllers.files.operations.Get_file( path_5_NOT_EXIST ) );

                    }

                // ** normal
                if( Input.GetKeyDown( KeyCode.E ) )
                    {
                        Test.SHOULD_PASS( "get file with right data", ()=>Controllers.files.operations.Get_file( path_1 ) );                        
                    }


            }



        // ** get file from disk
        if( Input.GetKey( KeyCode.Keypad2 ) )
            {
                // ** file already in system
                if( Input.GetKeyDown( KeyCode.Q ) )
                    {
                        Test.SHOULD_FAIL( "file already in system", () => Controllers.files.operations.Get_file_from_disk( path_1 ) );
                    }

                // ** file dont exist 
                if( Input.GetKeyDown( KeyCode.W ) )
                    {
                        Test.SHOULD_FAIL( "file dont exist ", () => Controllers.files.operations.Get_file_from_disk( path_5_NOT_EXIST ) );
                        Test.SHOULD_FAIL( "file  out of bounds ", () => Controllers.files.operations.Get_file_from_disk( path_6_OUT_BOUNDS ) );
                        Test.SHOULD_FAIL( "path NULL", () => Controllers.files.operations.Get_file_from_disk( null ) );
                    }

                // ** is deleted
                if( Input.GetKeyDown( KeyCode.E ) )
                    {
                        Test.SHOULD_PASS( "delete file",  ()=>Controllers.files.operations.Delete_file( path_1 ) );

                        Test.SHOULD_FAIL( "error on getting deleted file", ()=> Controllers.files.operations.Get_file_from_disk( path_1 ));
                    }


                // ** works normal
                if( Input.GetKeyDown( KeyCode.R ) )
                    {
                        Test.SHOULD_PASS( "get file all normal",  () => Controllers.files.operations.Get_file_from_disk( path_4_IN_DISK_NOT_SYSTEM ) );

                        Test.Assert(()=>new(
                            "stack give the right message",
                            ( Controllers.stack.Get_last_message( 0 ) == Safety_stack_action_type.got_file_from_disk )
                        ));
                        
                    }

                // ** works with cached data 
                if( Input.GetKeyDown( KeyCode.T ) )
                    {
                        Test.SHOULD_PASS( "remove file", () => Controllers.files.operations.Remove_file( data_1 ) );

                        Test.Assert(()=>new(
                            "path is cached data", ( Controllers.files.storage.Is_file_in_cache( path_1 ) )
                        ));
                        Test.Assert(new Assert_fn[]{

                            () => new ( "path is cached data", ( Controllers.files.storage.Is_file_in_cache( path_1 ) ) ),
                            () => new ( "path dont exist in current", ( !!!( Controllers.files.storage.Is_file_already_taken( path_1 ) ) ) ),

                        });

                        Test.SHOULD_PASS( "get file from disk, but get with cached", () => Controllers.files.operations.Get_file_from_disk( path_1 ) );

                        Test.Assert(()=>new(
                            "stack give the right message",( Controllers.stack.Get_last_message( 0 ) == Safety_stack_action_type.got_file_from_disk )
                        ));


                    }



            }

        // ** REMOVE FILE
        if( Input.GetKey( KeyCode.Keypad3 ) )
            {

                //** works normal + stack
                if( Input.GetKeyDown( KeyCode.Q ) )
                    {
                        Test.SHOULD_PASS( "remove file", () => Controllers.files.operations.Remove_file( data_1 ) );

                        Test.Assert(()=>new(
                            "stack give the right message",
                            ( Controllers.stack.Get_last_message( 0 ) == Safety_stack_action_type.remove_file ), 
                            "last stack action: " + Controllers.stack.Get_last_message( 0 )
                        ));

                        Test.Assert(new Assert_fn[]{

                            () => new ( "path is cached data", ( Controllers.files.storage.Is_file_in_cache( path_1 ) ) ),
                            () => new ( "path dont exist in current", ( !!!( Controllers.files.storage.Is_file_already_taken( path_1 ) ) ) ),

                        });

                    }

                // ** handles dont have file
                if( Input.GetKeyDown( KeyCode.W ) )
                    {
                    
                        Test.SHOULD_PASS( "remove a file that exist", () => Controllers.files.operations.Remove_file( data_3 ) );
                        Test.SHOULD_FAIL( "handles dont have file in systen", () => Controllers.files.operations.Remove_file( data_3 ) );
                    }

                // ** handles incorrect data
                if( Input.GetKeyDown( KeyCode.E ) )
                    {
                    
                        Test.SHOULD_FAIL( "handles incorrect id 0", () => Controllers.files.operations.Remove_file( data_WRONG_0_id ) );
                        Test.SHOULD_FAIL( "handles incorrect id negative", () => Controllers.files.operations.Remove_file( data_WRONG_negative_id ) );
                        Test.SHOULD_FAIL( "handles incorrect id not used", () => Controllers.files.operations.Remove_file( data_WRONG_not_used_id ) );
                        
                    }

            }


        // ** DELETE FILE
        if( Input.GetKey( KeyCode.Keypad4 ) )
            {

                //** works normal + stack
                if( Input.GetKeyDown( KeyCode.Q ) )
                    {

                        Test.SHOULD_PASS( "delete file with DATA ", () => Controllers.files.operations.Delete_file( data_1 ) );

                        Test.Assert(()=>new(
                            "stack give the right message",
                            ( Controllers.stack.Get_last_message( 0 ) == Safety_stack_action_type.delete_file ),
                            "last stack action: " + Controllers.stack.Get_last_message( 0 )
                        ));

                        Test.SHOULD_PASS( "delete file with PATH", () => Controllers.files.operations.Delete_file( path_2 ) );

                        Test.Assert(()=>new(
                            "stack give the right message",
                            ( Controllers.stack.Get_last_message( 0 ) == Safety_stack_action_type.delete_file ), 
                            "last stack action: " + Controllers.stack.Get_last_message( 0 )
                        ));

                        
                        Test.SHOULD_PASS( "delete file only in disk with PATH", () => Controllers.files.operations.Delete_file( path_4_IN_DISK_NOT_SYSTEM ) );

                        Test.Assert(()=>new(
                            "stack give the right message",
                            ( Controllers.stack.Get_last_message( 0 ) == Safety_stack_action_type.delete_file ), 
                            "last stack action: " + Controllers.stack.Get_last_message( 0 )
                        ));

                        

                        Test.Assert(new Assert_fn[]{

                            () => new ( "the path ( give DATA ) is marked to be deletad", ( Controllers.files.storage.Is_file_in_delete_cache( path_1 ) ) ),
                            () => new ( "the path ( give PATH ) is marked to be deletad", ( Controllers.files.storage.Is_file_in_delete_cache( path_2 ) ) ),
                            () => new ( "the path ( NOT IN SYSTEM ) is marked to be deletad", ( Controllers.files.storage.Is_file_in_delete_cache( path_4_IN_DISK_NOT_SYSTEM ) ) ),

                        });

                    }

                // ** handle errors caches
                if( Input.GetKeyDown( KeyCode.W ) )
                    {
                        // ** cache
                            Test.SHOULD_PASS( "will remove file data 1", () => Controllers.files.operations.Remove_file( data_1 ) );
                            Test.SHOULD_FAIL( "will try to delete path 1 with data, but the id is no longer valid", () => Controllers.files.operations.Delete_file( data_1 ) );

                            Test.SHOULD_PASS( "will remove file data 2", () => Controllers.files.operations.Remove_file( data_2 ) );

                            Test.Assert(()=>new( "data 2 is in cache", ( Controllers.files.storage.Is_file_in_cache( path_2 ) )));
                
                            Test.SHOULD_PASS( "will try to delete data 2 with path, should delete from the data", () => Controllers.files.operations.Delete_file( path_2 ) );

                            Test.Assert(new Assert_fn[]{

                                () => new ( "file path 2 is NOT in cache ", !!!( Controllers.files.storage.Is_file_in_cache( path_2 ) ) ),
                                () => new ( "file path 2 is in deleted ", ( Controllers.files.storage.Is_file_in_delete_cache( path_2 ) ) )

                            });            
                    }

                
                // ** try to delete 2 times
                if( Input.GetKeyDown( KeyCode.E ) )
                    {
                        Test.SHOULD_PASS( "will delete file data 3", () => Controllers.files.operations.Delete_file( data_3 ) );
                        Test.SHOULD_FAIL( "will delete file data 3 again", () => Controllers.files.operations.Delete_file( data_3 ) );
                    }


                // ** file dont exist
                if( Input.GetKeyDown( KeyCode.R ) )
                    {
                        Test.SHOULD_FAIL( "file dont exist", () => Controllers.files.operations.Delete_file( path_5_NOT_EXIST ) );
                    }


                // ** wrong ids
                if( Input.GetKeyDown( KeyCode.T ) )
                    {
                        Test.SHOULD_FAIL( "handles incorrect id 0", () => Controllers.files.operations.Delete_file( data_WRONG_0_id ) );
                        Test.SHOULD_FAIL( "handles incorrect id negative", () => Controllers.files.operations.Delete_file( data_WRONG_negative_id ) );
                        Test.SHOULD_FAIL( "handles incorrect id not used", () => Controllers.files.operations.Delete_file( data_WRONG_not_used_id ) );
                    }

                // ** handle wrong paths
                if( Input.GetKeyDown( KeyCode.Y ) )
                    {
                        Test.SHOULD_FAIL( "handles incorrect path NULL", () => Controllers.files.operations.Delete_file( null ) );
                        Test.SHOULD_FAIL( "handles incorrect path dont exist", () => Controllers.files.operations.Delete_file( path_5_NOT_EXIST ) );
                        Test.SHOULD_FAIL( "handles incorrect path out bounds", () => Controllers.files.operations.Delete_file( path_6_OUT_BOUNDS ) );
                    }



            }



        // ** CREATE FILE
        if( Input.GetKey( KeyCode.Keypad5 ) )
            {
                // ** normal
                if( Input.GetKeyDown( KeyCode.Q ) ) 
                    {

                        Test.SHOULD_PASS( "Create a file that dosent exist", () => Controllers.files.operations.Create_new_file( new byte[ 200 ], path_1 + ".test" ) );

                        Test.Assert(new Assert_fn[]{

                            () => new ( "stack first gives _create_file_ message",( Controllers.stack.Get_last_message( 1 ) == Safety_stack_action_type.create_new_file ),("last stack action: " + Controllers.stack.Get_last_message( 1 )) ),
                            () => new ( "stack after gives _change_data_",( Controllers.stack.Get_last_message( 0 ) == Safety_stack_action_type.change_data_in_file ),("last stack action: " + Controllers.stack.Get_last_message( 0 )) ),

                        });     

                    }

                // ** handle wrong paths
                if( Input.GetKeyDown( KeyCode.W ) ) 
                    {
                        Test.SHOULD_FAIL( "handles incorrect path NULL", () => Controllers.files.operations.Create_new_file( new byte[ 100 ], null ) );
                        Test.SHOULD_FAIL( "handles incorrect path already exist in disk", () => Controllers.files.operations.Create_new_file( new byte[ 100 ], path_4_IN_DISK_NOT_SYSTEM ) );
                        Test.SHOULD_FAIL( "handles incorrect path already exist in system", () => Controllers.files.operations.Create_new_file( new byte[ 100 ], path_2 ) );

                        Test.SHOULD_PASS( "remvoe file 1 to have it on cache ", () => Controllers.files.operations.Remove_file( data_1 ) );
                        Test.SHOULD_FAIL( "handles incorrect path already exist in cache", () => Controllers.files.operations.Create_new_file( new byte[ 100 ], path_1 ) );

                        Test.SHOULD_FAIL( "handles incorrect path out bounds", () => Controllers.files.operations.Create_new_file( new byte[ 100 ], path_6_OUT_BOUNDS + ".dont_exist" ) );
                    }

                // ** exist in disk + deleted file
                if( Input.GetKeyDown( KeyCode.E ) ) 
                    {
                        Test.SHOULD_PASS( "Delete data 1", () => Controllers.files.operations.Delete_file( path_1 ) );
                        Test.SHOULD_PASS( "try to create a new in path 1", () => Controllers.files.operations.Create_new_file( new byte[ 100 ], path_1 ) );
                    }


                // ** handle invalid data 
                if( Input.GetKeyDown( KeyCode.R ) ) 
                    {
                        IntPtr pointer = Marshal.AllocHGlobal( 1000 );
                        void* data_pointer = pointer.ToPointer();
                        
                        Test.SHOULD_FAIL( "null array", () => Controllers.files.operations.Create_new_file( null, path_1 + ".data" ) );
                        Test.SHOULD_FAIL( "pointer null", () => Controllers.files.operations.Create_new_file( (void*)0, 1000, path_1 + ".data" ) );
                        Test.SHOULD_FAIL( "length 0", () => Controllers.files.operations.Create_new_file( data_pointer, 0, path_1 + ".data" ) );
                        Test.SHOULD_FAIL( "length negative", () => Controllers.files.operations.Create_new_file( data_pointer, -100, path_1 + ".data" ) );

                        Marshal.FreeHGlobal( pointer );
                    }
            

            }


        // ** CREATE FILE EMPTY
        if( Input.GetKey( KeyCode.Keypad6 ) )
            {

                // ** right data
                if( Input.GetKeyDown( KeyCode.Q ) )
                    {
                        Test.SHOULD_PASS( "test rigth data", () => Controllers.files.operations.Create_new_file_EMPTY( path_1 + ".data", 1_000 ) );
                        Test.Assert(new Assert_fn[]{
                            () => new ( "stack gives _create_file_ message",( Controllers.stack.Get_last_message( 0 ) == Safety_stack_action_type.create_new_file ),("last stack action: " + Controllers.stack.Get_last_message( 0 )) ),
                        });     

                    }



                // ** handle invalid data 
                if( Input.GetKeyDown( KeyCode.W ) ) 
                    {
                        Test.SHOULD_FAIL( "length 0", () => Controllers.files.operations.Create_new_file_EMPTY( path_1 + ".data", 0 ) );
                        Test.SHOULD_FAIL( "length negative", () => Controllers.files.operations.Create_new_file_EMPTY( path_1 + ".data", -100 ) );
                    }


                // ** handle wrong paths
                if( Input.GetKeyDown( KeyCode.E ) ) 
                    {
                        Test.SHOULD_FAIL( "handles incorrect path NULL", () => Controllers.files.operations.Create_new_file_EMPTY( null, 1_000 ) );
                        Test.SHOULD_FAIL( "handles incorrect path already exist in disk", () => Controllers.files.operations.Create_new_file_EMPTY( path_4_IN_DISK_NOT_SYSTEM, 1_000 ) );
                        Test.SHOULD_FAIL( "handles incorrect path already exist in system", () => Controllers.files.operations.Create_new_file_EMPTY( path_2, 1_000 ) );

                        Test.SHOULD_PASS( "remvoe file 1 to have it on cache ", () => Controllers.files.operations.Remove_file( data_1 ) );
                        Test.SHOULD_FAIL( "handles incorrect path already exist in cache", () => Controllers.files.operations.Create_new_file_EMPTY( path_1, 1_000 ) );

                        Test.SHOULD_FAIL( "handles incorrect path out bounds", () => Controllers.files.operations.Create_new_file_EMPTY( path_6_OUT_BOUNDS + ".dont_exist", 1_000  ) );
                    }



            }


        // ** CHNGE LENGTH FILE
        if( Input.GetKey( KeyCode.Keypad7 ) )
            {
                
                // ** right data
                if( Input.GetKeyDown( KeyCode.Q ) )
                    {
                        Test.SHOULD_PASS( "test rigth data", () => Controllers.files.operations.Change_length_file( data_1, 50_000 ) );
                        Test.Assert(new Assert_fn[]{
                            () => new ( "stack gives _create_file_ message",( Controllers.stack.Get_last_message( 0 ) == Safety_stack_action_type.change_length_file ),("last stack action: " + Controllers.stack.Get_last_message( 0 )) ),
                        });     

                    }

                // ** handle wrong data
                if( Input.GetKeyDown( KeyCode.W ) )
                    {
                        Test.SHOULD_FAIL( "handles incorrect path NULL", () => Controllers.files.operations.Change_length_file( new Data_file_link(), 1_000 ) );
                        Test.SHOULD_FAIL( "handles incorrect path dont exist", () => Controllers.files.operations.Change_length_file( data_1, 0 ) );
                        Test.SHOULD_FAIL( "handles incorrect path out bounds", () => Controllers.files.operations.Change_length_file( data_1, -10_000 ) );
                    }


            }




    }



}