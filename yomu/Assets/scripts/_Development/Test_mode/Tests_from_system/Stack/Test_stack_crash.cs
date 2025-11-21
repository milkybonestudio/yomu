
using System;
using System.IO;
using UnityEngine;

unsafe public static class Test_stack_crash {


    public enum Crash {

        _1_save_stack,
        _2_save_new_slot_file_link,
        _3_create_saving_files_folders, 
        _4_add_slots_files_half,
        _5_add_slots_files_full,
        _6_create_saving_files_security_file, 
        _7_move_files_half, 
        _71_move_files_full,
        _72_switch_files_half,
        _73_switch_files_full,
        _8_reset_stack,
        _9_delete_saving_files_security_file,
        _91_delete_saving_files_folder,
        finish,

    }





        static string path_1;
        static string path_2;
        static string path_3;

        static Data_file_link data_1;
        static Data_file_link data_2;
        static Data_file_link data_3;

        static Crash current_state_crash;

    public static void Set(){

        current_state_crash = Crash._1_save_stack;

        path_1 = Path.Combine( Paths_program.program_path, "test_1.dat" );
        path_2 = Path.Combine( Paths_program.program_path, "test_2.dat" );
        path_3 = Path.Combine( Paths_program.program_path, "test_3.dat" );

            System.IO.File.WriteAllBytes( path_1, ARRAY.Get_array<byte>( 10_000, (byte)'@' ) );
            System.IO.File.WriteAllBytes( path_2, ARRAY.Get_array<byte>( 10_000, (byte)'9' )  );
            System.IO.File.WriteAllBytes( path_3, ARRAY.Get_array<byte>( 10_000, (byte)'7' )  );

        // Console.Log( "remvoer" );
        // return;

        data_1 = Controllers.files.Get_file_from_disk( path_1 );
        data_2 = Controllers.files.Get_file_from_disk( path_2 );
        data_3 = Controllers.files.Get_file_from_disk( path_3 );

    }
    


    private static void Go_to_state_saving_crash(){


        Console.Log( "vai: " + current_state_crash );


        if( current_state_crash == Crash._1_save_stack )
            {

                SS v = new SS(){
                        a = INT.Return_int_4_bytes_asc2( 'a' ),
                        b = INT.Return_int_4_bytes_asc2( 'b' ),
                        c = INT.Return_int_4_bytes_asc2( 'c' ),
                        d = INT.Return_int_4_bytes_asc2( 'd' ),
                        e = INT.Return_int_4_bytes_asc2( 'e' ),
                        f = INT.Return_int_4_bytes_asc2( 'f' ),
                };


                Controllers.stack.files.Save_data_change_data_in_file( data_1.id, 5, v );
                Controllers.stack.files.Save_data_change_data_in_file( data_1.id, 100, v );
                Controllers.stack.files.Save_data_change_data_in_file( data_1.id, 1500, v );
                Controllers.stack.files.Save_data_change_data_in_file( data_1.id, 2500, v );

                Controllers.stack.test.Save_stack_in_disk_sync();

                // Controllers.stack.files.Save_data_change_data_in_file( data_2.id, 5, v );
                // Controllers.stack.files.Save_data_change_data_in_file( data_2.id, 100, v );

                // Controllers.stack.Save_stack_in_disk_sync();

            }


        if( current_state_crash == Crash._2_save_new_slot_file_link )
            {
                Controllers.files.test.Save_link_paths_sync();
            }

        if( current_state_crash == Crash._3_create_saving_files_folders )
            {
                System.IO.Directory.CreateDirectory( Paths_program.saving_files_folder );
            }

        if( current_state_crash == Crash._4_add_slots_files_half )
            {
                data_1.Fill_TEST( (byte)'$' );
                Controllers.files.Save_file_run_time( data_1 );
                data_2.Fill_TEST( (byte)'%' );
                Controllers.files.Save_file_run_time( data_2 );
            }
            
        if( current_state_crash == Crash._5_add_slots_files_full )
            {
                data_3.Fill_TEST( (byte)'@' );
                Controllers.files.Save_file_run_time( data_3 );
            }

        if( current_state_crash == Crash._6_create_saving_files_security_file )
            {
                System.IO.File.WriteAllBytes( Paths_program.saving_files_security_file, new byte[ 1_000 ] );
            }
        if( current_state_crash == Crash._7_move_files_half )
            {
                Controllers.files.Move_file( data_1 );
                Controllers.files.Move_file( data_2 );
            }

        if( current_state_crash == Crash._71_move_files_full )
            {
                Controllers.files.Move_file( data_3 );
            }

        if( current_state_crash == Crash._72_switch_files_half )
            {
                Controllers.files.Switch_files( data_1 );
                Controllers.files.Switch_files( data_2 );
            }

        if( current_state_crash == Crash._73_switch_files_full )
            {
                Controllers.files.Switch_files( data_3 );
            }


        if( current_state_crash == Crash._8_reset_stack )
            { 
                Controllers.stack.saver.Clean_file();
            }

        if( current_state_crash == Crash._9_delete_saving_files_security_file )
            {
                System.IO.File.Delete( Paths_program.saving_files_security_file );
            }
            
        if( current_state_crash == Crash._91_delete_saving_files_folder )
            {
                System.IO.Directory.Delete( Paths_program.saving_files_folder );
            }


        current_state_crash++;
        

    }


    static SS v = new SS(){
        a = INT.Return_int_4_bytes_asc2( 'a' ),
        b = INT.Return_int_4_bytes_asc2( 'b' ),
        c = INT.Return_int_4_bytes_asc2( 'c' ),
        d = INT.Return_int_4_bytes_asc2( 'd' ),
        e = INT.Return_int_4_bytes_asc2( 'e' ),
        f = INT.Return_int_4_bytes_asc2( 'f' ),
    };



    public static void Update(){


        // --- 

        if( false  )
            {

                if( Input.GetKeyDown( KeyCode.P ) )
                    { Go_to_state_saving_crash(); }

                if( Input.GetKeyDown( KeyCode.O ) )
                    { Console.Log( "state: " + _Crash() ); }

                if( Input.GetKeyDown( KeyCode.I ) )
                    { Controllers.stack.saver.test.Force_corrupt_file( 10 ); }

                if( Input.GetKeyDown( KeyCode.L ) )
                    { 
                        Controllers.stack.files.Save_data_got_file_from_disk( '&', Paths_program.program_path );
                        Controllers.stack.files.Save_data_got_file_from_disk( '*', @"C:/Users/User/Desktop/yomu_things/yomu/yomu/abcdefghi" );
                        Controllers.stack.files.Save_data_got_file_from_disk( '%', @"FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF" );
                        
                        Controllers.stack.test.Save_stack_in_disk_sync(); 
                    }

                    
            }







        // ** TESTS FOR MESSAGES

        if( true )
            {

                if ( Input.GetKeyDown( KeyCode.Keypad1 ) )
                    {
                        
                        Controllers.stack.test.Save_stack_in_disk_sync(); 

                    }

                if ( Input.GetKeyDown( KeyCode.Keypad2 ) )
                    {
                        
                        Console.Log( "state: " + _Crash() );

                    }




                // ** CREATE NEW FILE
                if( false )
                    {

                        /*

                            creat new file:
                                --> workds with normal data (  )
                                --> handle errors:
                                    --> path dont have file (  ) 
                                    --> path is not in the version folder (  ) 
                                    --> duplication (  )
                        
                        */

                        string path_can_not_get = Path.Combine( Paths_system.persistent_data, "can_not_get.txt" );
                        string path_new_file = path_1 + ".abc";
                        string path_that_already_exist = path_1;

                        System.IO.File.WriteAllBytes( path_can_not_get, new byte[ 100 ] );


                        // ** OK
                        if ( Input.GetKeyDown( KeyCode.Q ) )
                            { Controllers.stack.files.Save_data_create_new_file( 20, 10_000, path_new_file ); }


                        // ID 
                        // ** invalid
                        if ( Input.GetKeyDown( KeyCode.W ) )
                            { Controllers.stack.files.Save_data_create_new_file( 0, 10_000, path_new_file ); }

                        if ( Input.GetKeyDown( KeyCode.E ) )
                            { Controllers.stack.files.Save_data_create_new_file( -1, 10_000, path_new_file ); }

                        
                        if ( Input.GetKeyDown( KeyCode.R ) )
                            { 
                                Controllers.stack.files.Save_data_create_new_file( 2, 10_000, path_new_file ); 
                                Controllers.stack.files.Save_data_create_new_file( 2, 10_000, path_new_file ); 
                            }

                        // ** invalid path 

                        // ** out version
                        if ( Input.GetKeyDown( KeyCode.T ) )
                            { Controllers.stack.files.Save_data_create_new_file( 5, 10_000, path_can_not_get ); }

                        // ** file already exist
                        if ( Input.GetKeyDown( KeyCode.Y ) )
                            { Controllers.stack.files.Save_data_create_new_file( 5, 10_000, path_that_already_exist ); }

                        // ** path null
                        if ( Input.GetKeyDown( KeyCode.U ) )
                            { Controllers.stack.files.Save_data_create_new_file( 5, 10_000, null ); }

                        

                        // SIZE PROBLEM

                        // ** too much 
                        if ( Input.GetKeyDown( KeyCode.I ) )
                            { Controllers.stack.files.Save_data_create_new_file( 20, 10_000_000, path_new_file ); }

                        // ** negative length
                        if ( Input.GetKeyDown( KeyCode.O ) )
                            { Controllers.stack.files.Save_data_create_new_file( 20, -1_000, path_new_file ); }

                        
                        // ** negative length
                        if ( Input.GetKeyDown( KeyCode.P ) )
                            { Controllers.stack.files.Save_data_create_new_file( 20, 0, path_new_file ); }
                        

                    }











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

                        string path_can_not_get = Path.Combine( Paths_system.persistent_data, "can_not_get.txt" );
                        string path_dont_exist = path_1 + ".abc";

                        System.IO.File.WriteAllBytes( path_can_not_get, new byte[ 100 ] );


                        // ** OK
                        if ( Input.GetKeyDown( KeyCode.Q ) )
                            { 
                                data_1 = Controllers.files.Get_file_from_disk( path_1 );
                                Controllers.stack.files.Save_data_change_data_in_file( data_1.id, 5, v );
                            }

                        

                        // ** path dont have file
                        if ( Input.GetKeyDown( KeyCode.W ) )
                            { data_1 = Controllers.files.Get_file_from_disk( path_dont_exist ); }

                        // ** path dont have file in reconstruct
                        if ( Input.GetKeyDown( KeyCode.E ) )
                            { Controllers.stack.files.Save_data_got_file_from_disk( 20, path_dont_exist ); }



                        // ** path is not part of version 
                        if ( Input.GetKeyDown( KeyCode.R ) )
                            { data_1 = Controllers.files.Get_file_from_disk( path_can_not_get  ); }
                        
                        // ** path is not part of version
                        if ( Input.GetKeyDown( KeyCode.T ) )
                            { Controllers.stack.files.Save_data_got_file_from_disk( 20, path_can_not_get ); }






                        // ** path is null  OK
                        if ( Input.GetKeyDown( KeyCode.Y ) )
                            { Controllers.stack.files.Save_data_got_file_from_disk( 20, null ); }


                        // ** path is null OK
                        if ( Input.GetKeyDown( KeyCode.U ) )
                            { data_1 = Controllers.files.Get_file_from_disk( null  ); }






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
                            { Controllers.stack.files.Save_data_change_data_in_file( data_1.id, 5, v ); }




                    }




            }


        // ** TESTS FOR STAGES INTERUPTIONS
        if( false )
            {
                if (Input.GetKeyDown(KeyCode.Alpha0))
                    { 
                            SS v = new SS(){
                                a = INT.Return_int_4_bytes_asc2( 'a' ),
                                b = INT.Return_int_4_bytes_asc2( 'b' ),
                                c = INT.Return_int_4_bytes_asc2( 'c' ),
                                d = INT.Return_int_4_bytes_asc2( 'd' ),
                                e = INT.Return_int_4_bytes_asc2( 'e' ),
                                f = INT.Return_int_4_bytes_asc2( 'f' ),
                            };


                            Controllers.stack.files.Save_data_change_data_in_file( data_1.id, 5, v );
                            Controllers.stack.files.Save_data_change_data_in_file( data_1.id, 100, v );
                            Controllers.stack.files.Save_data_change_data_in_file( data_1.id, 150, v );

                            Controllers.stack.test.Save_stack_in_disk_sync();

                            // Controllers.stack.files.Save_data_change_data_in_file( data_2.id, 5, v );
                            // Controllers.stack.files.Save_data_change_data_in_file( data_2.id, 100, v );

                            // Controllers.stack.Save_stack_in_disk_sync();

                            // Controllers.stack.saver.test.Force_corrupt_file( 10 );

                            Console.Log( "state: " + _Crash() );
                        
                    }


                if (Input.GetKeyDown(KeyCode.Alpha1))
                { Verify_crash(Crash._1_save_stack, Crash_handle_situation.need_to_recosntruct_with_the_stack); }

                if( Input.GetKeyDown( KeyCode.Alpha2 ) )
                    { Verify_crash( Crash._2_save_new_slot_file_link,  Crash_handle_situation.need_to_recosntruct_with_the_stack ); }

                if( Input.GetKeyDown( KeyCode.Alpha3 ) )
                    { Verify_crash( Crash._3_create_saving_files_folders,  Crash_handle_situation.need_to_recosntruct_with_the_stack ); }

                if( Input.GetKeyDown( KeyCode.Alpha4 ) )
                    { Verify_crash( Crash._4_add_slots_files_half,  Crash_handle_situation.need_to_recosntruct_with_the_stack ); }

                
                if( Input.GetKeyDown( KeyCode.Alpha5 ) )
                    { Verify_crash( Crash._5_add_slots_files_full,  Crash_handle_situation.need_to_recosntruct_with_the_stack ); }

                if( Input.GetKeyDown( KeyCode.Alpha6 ) )
                    { Verify_crash( Crash._6_create_saving_files_security_file,  Crash_handle_situation.all_temp_files_were_already_there_just_move ); }

                if( Input.GetKeyDown( KeyCode.Alpha7 ) )
                    { Verify_crash( Crash._7_move_files_half,  Crash_handle_situation.all_temp_files_were_already_there_just_move ); }

                if( Input.GetKeyDown( KeyCode.Alpha8 ) )
                    { Verify_crash( Crash._71_move_files_full,  Crash_handle_situation.all_temp_files_were_already_there_just_move ); }

                if( Input.GetKeyDown( KeyCode.Alpha9 ) )
                    { Verify_crash( Crash._72_switch_files_half,  Crash_handle_situation.all_temp_files_were_already_there_just_move ); }

                if( Input.GetKeyDown( KeyCode.Q ) )
                    { Verify_crash( Crash._73_switch_files_full,  Crash_handle_situation.all_temp_files_were_already_there_just_move ); }

                if( Input.GetKeyDown( KeyCode.W ) )
                    { Verify_crash( Crash._8_reset_stack,  Crash_handle_situation.all_files_already_got_saved ); }

                if( Input.GetKeyDown( KeyCode.E ) )
                    { Verify_crash( Crash._9_delete_saving_files_security_file,  Crash_handle_situation.all_files_already_got_saved ); }

                if( Input.GetKeyDown( KeyCode.R ) )
                    { Verify_crash( Crash._91_delete_saving_files_folder,  Crash_handle_situation.all_files_already_got_saved ); }




            }









        


    }

    
    private static Crash_handle_situation _Crash(){

        Controllers.stack.saver.strem_stack.Close();
        return Crash_handler.Deal_crash();


    }


    private static void Verify_crash( Crash _crash, Crash_handle_situation _expected ){

        try{

            Crash_test_until( _crash );
            Crash_handle_situation real_crash_handler = _Crash();

            if( real_crash_handler != _expected )
                { CONTROLLER__errors.Throw( $"Expedcted <Color=lightBlue>{ _expected }</Color> but give <Color=lightBlue>{ real_crash_handler }</Color>" ); }

            Console.Log( "stage crash: " + _crash );
            Console.Log( "real_crash_handler: " + real_crash_handler );

            Console.Log( "<Color=lime>PASS TEST</Color>" );


        } catch( Exception e ){}

    }


    private static void Crash_test_until( Crash _crash ){

        current_state_crash = Crash._1_save_stack;

        while( current_state_crash <= _crash )
            { Go_to_state_saving_crash(); }


    }



}

    public struct SS{

        public int a;
        public int b;
        public int c;
        public int d;
        public int e;
        public int f;

    }