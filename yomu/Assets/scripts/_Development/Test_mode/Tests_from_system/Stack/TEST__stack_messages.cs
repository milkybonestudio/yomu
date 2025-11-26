
using System.IO;
using System.Text;
using UnityEngine;


/*    

    creat new file:
        --> workds with normal data (  )
        --> handle errors:
            --> path dont have file (  ) 
            --> path is not in the version folder (  ) 
            --> duplication (  )


*/

unsafe public static class TEST__stack_messages {



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


        // ** TESTS FOR MESSAGES

        if ( Input.GetKeyDown( KeyCode.A ) )
            { Controllers.stack.test.Save_stack_in_disk_sync(); }



        // ** CREATE NEW FILE
        if( Input.GetKey( KeyCode.Keypad1 ) )
            {


                // string path_6_OUT_BOUNDS = Path.Combine( Paths_system.persistent_data, "can_not_get.txt" );
                string path_new_file = path_1 + ".abc";
                string path_that_already_exist = path_1;


                // ** normal 
                if( Input.GetKeyDown( KeyCode.Q ) )
                    {
                        Test.SHOULD_PASS( "message create new file", () => Controllers.stack.files.Save_data_create_new_file( 20, 10_000, path_5_NOT_EXIST ) );
                        Test.Assert(()=>new( "stack give the right message", ( Controllers.stack.Get_last_message( 0 ) == Safety_stack_action_type.create_new_file ), "last stack action: " + Controllers.stack.Get_last_message( 0 ) ));
                    }


                // ** wrogn path
                if( Input.GetKeyDown( KeyCode.W ) )
                    {
                        Test.SHOULD_FAIL( "path null", () => Controllers.stack.files.Save_data_create_new_file( 20, 10_000, null ) );
                        Test.SHOULD_FAIL( "path out bound", () => Controllers.stack.files.Save_data_create_new_file( 20, 10_000, path_6_OUT_BOUNDS ) );
                        Test.SHOULD_FAIL( "file already exist", () => Controllers.stack.files.Save_data_create_new_file( 20, 10_000, path_1 ) );
                    }



                // ** wrong ID
                if( Input.GetKeyDown( KeyCode.E ) )
                    {
                        Test.SHOULD_FAIL( "id 0", () => Controllers.stack.files.Save_data_create_new_file( 0, 10_000, (path_1 + "1.dat") ) );
                        Test.SHOULD_FAIL( "negative id", () => Controllers.stack.files.Save_data_create_new_file( -10, 10_000, (path_1 + "2.dat") ) );
                        Test.SHOULD_FAIL( "alredy existing id", () => Controllers.stack.files.Save_data_create_new_file( 2, 10_000, (path_1 + "3.dat") ) );
                    }


                // ** wrong data
                if( Input.GetKeyDown( KeyCode.R ) )
                    {
                        Test.SHOULD_FAIL( "length 0", () => Controllers.stack.files.Save_data_create_new_file( 50, 0, (path_1 + "1.dat") ) );
                        Test.SHOULD_FAIL( "negative length", () => Controllers.stack.files.Save_data_create_new_file( 50, -10_000, (path_1 + "2.dat") ) );
                        Test.SHOULD_FAIL( "length too big", () => Controllers.stack.files.Save_data_create_new_file( 50, 10_000_000, (path_1 + "3.dat") ) );
                    }

            
            }




            //mark
            return; 






        //mark
        // ** need to jump PART of set(), can not get the data
        // ** GOT FILE FROM DISK
        if( false )
            {

                /*

                    got file from disk:
                        --> workds with normal data ( OK )
                        --> handle errors:
                            --> path dont have file ( OK ) 
                            --> path is not in the version folder ( OK ) 
                            --> duplication ( OK )
                
                */

                string path_6_OUT_BOUNDS = Path.Combine( Paths_system.persistent_data, "can_not_get.txt" );
                string path_dont_exist = path_1 + ".abc";

                System.IO.File.WriteAllBytes( path_6_OUT_BOUNDS, new byte[ 100 ] );


                // ** OK
                if ( Input.GetKeyDown( KeyCode.Q ) )
                    { 
                        data_1 = Controllers.files.operations.Get_file_from_disk( path_1 );
                        Controllers.stack.files.Save_data_change_data_in_file( data_1.id, 5, v );
                    }

                

                // ** path dont have file
                if ( Input.GetKeyDown( KeyCode.W ) )
                    { data_1 = Controllers.files.operations.Get_file_from_disk( path_dont_exist ); }

                // ** path dont have file in reconstruct
                if ( Input.GetKeyDown( KeyCode.E ) )
                    { Controllers.stack.files.Save_data_got_file_from_disk( 20, path_dont_exist ); }


                // ** path is not part of version 
                if ( Input.GetKeyDown( KeyCode.R ) )
                    { data_1 = Controllers.files.operations.Get_file_from_disk( path_6_OUT_BOUNDS  ); }
                
                // ** path is not part of version
                if ( Input.GetKeyDown( KeyCode.T ) )
                    { Controllers.stack.files.Save_data_got_file_from_disk( 20, path_6_OUT_BOUNDS ); }






                // ** path is null  OK
                if ( Input.GetKeyDown( KeyCode.Y ) )
                    { Controllers.stack.files.Save_data_got_file_from_disk( 20, null ); }


                // ** path is null OK
                if ( Input.GetKeyDown( KeyCode.U ) )
                    { data_1 = Controllers.files.operations.Get_file_from_disk( null  ); }






                // ** try to add the same id twice OK
                if ( Input.GetKeyDown( KeyCode.I ) )
                    { 
                        Controllers.stack.files.Save_data_got_file_from_disk( 20, path_1 ); 
                        Controllers.stack.files.Save_data_got_file_from_disk( 20, path_1 ); 
                    }


                // ** id invalid for creation
                if ( Input.GetKeyDown( KeyCode.O ) )
                    { Controllers.stack.files.Save_data_got_file_from_disk( 0, path_1 ); }

                
                // ** id invalid for creation
                if ( Input.GetKeyDown( KeyCode.P ) )
                    { Controllers.stack.files.Save_data_got_file_from_disk( -10, path_1 ); }




            }





        // ** CHANGE FILE MESSAGES
        if( true )
            {

                /*

                    change file:
                        --> workds with normal data ( OK )
                        --> handle errors:
                            --> change 0 bytes ( OK )
                            --> change negative off set ( OK )
                            --> chnage off range ( OK )
                            --> invalid file id[ 0, negative, invalid ] ( OK )
                            --> 
                
                */


                // ** Change file 0
                if ( Input.GetKeyDown( KeyCode.Q ) )
                    { Controllers.stack.files.Save_data_change_data_in_file( data_1.id, 0, v ); }

                // ** Change file negative
                if ( Input.GetKeyDown( KeyCode.W ) )
                    { Controllers.stack.files.Save_data_change_data_in_file( data_1.id, -10, v ); }

                // ** Change file out of file a lot
                if ( Input.GetKeyDown( KeyCode.E ) )
                    { Controllers.stack.files.Save_data_change_data_in_file( data_1.id, data_1.Get_length() + 100_000, v ); }

                // ** Change file starts ok, but in length pass
                if ( Input.GetKeyDown( KeyCode.R ) )
                    { Controllers.stack.files.Save_data_change_data_in_file( data_1.id, data_1.Get_length() - sizeof( SS ), v ); }

                
                // ** Change file starts ok, but in length pass
                if ( Input.GetKeyDown(KeyCode.B) )
                    { Controllers.stack.files.Save_data_change_data_in_file( data_1.id, data_1.Get_length() - sizeof( SS ), v ); }



                // ** wrong id 0
                if ( Input.GetKeyDown( KeyCode.T ) )
                    { Controllers.stack.files.Save_data_change_data_in_file( 0, 5, v ); }

                
                // ** wrong id negative
                if ( Input.GetKeyDown( KeyCode.Y ) )
                    { Controllers.stack.files.Save_data_change_data_in_file( -100, 5, v ); }

                // ** wrong id not exist
                if ( Input.GetKeyDown( KeyCode.U ) )
                    { Controllers.stack.files.Save_data_change_data_in_file( 100, 5, v ); }

                                        // ** wrong id not exist
                if ( Input.GetKeyDown( KeyCode.J ) )
                    { Controllers.stack.files.Save_data_change_data_in_file( 5, 5, v ); }


                

                // ** size dont make sense
                if ( Input.GetKeyDown( KeyCode.I ) )
                    { fixed( SS* pp = &v ){Controllers.stack.files.Save_data_change_data_in_file( data_1.id, 5, pp, 200_000 );} }


                // ** Change file OK
                if ( Input.GetKeyDown( KeyCode.O ) )
                    { Controllers.stack.files.Save_data_change_data_in_file( data_1.id, 10, v ); }




            }



    }

    static SS v = new SS(){
        a = INT.Return_int_4_bytes_asc2( 'a' ),
        b = INT.Return_int_4_bytes_asc2( 'b' ),
        c = INT.Return_int_4_bytes_asc2( 'c' ),
        d = INT.Return_int_4_bytes_asc2( 'd' ),
        e = INT.Return_int_4_bytes_asc2( 'e' ),
        f = INT.Return_int_4_bytes_asc2( 'f' ),
    };




}