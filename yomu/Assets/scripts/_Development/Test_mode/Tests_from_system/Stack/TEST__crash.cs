
using System;
using System.IO;
using UnityEngine;

unsafe public static class TEST__crash {

/*
        --> crash tests:
            --> understand the state that stoped and switches to the right handler ( OK )
            --> find edge cases where the files where already all saved ( OK )
            --> find edge cases where the files got corrupted
                    --> temp file duplicated ( OK )
                    --> old file deleted befor correct move ( OK )
            --> handlers: 
                --> data was already saved ( OK )
                --> will reconstruct from the stack (  )
                --> all data in saving_files/already moved ( OK )
            --> expected:
                1_save_stack ( OK )
                2_save_new_slot_file_link ( OK )
                3_create_saving_files_folders ( OK )
                4_create_half_run_time_saving_files ( OK )
                5_create_full_run_time_saving_files ( OK )
                6_create_saving_files_security_file ( OK )
                7_move_files_half ( OK )
                71_move_files_full ( OK )
                72_apply_logic_half ( OK )
                73_apply_logic_full ( OK )
                8_reset_stack ( OK )
                9_delete_saving_files_security_file ( OK )
                91_delete_saving_files_folder ( OK )
        finish,

*/



    public enum Crash {

        save_stack,
        save_new_slot_file_link,
        create_saving_files_folders,

        // ** create files in saving folder
        create_half_run_time_saving_files,
        create_full_run_time_saving_files,

        // ** 
        create_saving_files_security_file,

        // --> have all the data

        // ** apply logic
        apply_logic_half,
        apply_logic_full,



        reset_stack,

        delete_saving_files_folder,
        
        delete_file_links,
        change_stack_start_files,
        finish,

    }



        static string path_1;
        static string path_2;
        static string path_3;
        static string path_4_EXIST_OU_SYSTEM;
        static string path_5_EXIST_OU_SYSTEM;
        static string path_6_DONT_EXIST;
        static string path_7_DONT_EXIST;


        static string path_storage;



        static Data_file_link data_1;
        static Data_file_link data_2;
        static Data_file_link data_3;

        static Packets_storage_data* packet_storage;

        static Crash current_state_crash;

    public static void Set(){

        current_state_crash = Crash.save_stack;

        path_1 = Path.Combine( Paths_program.program_path, "test_1.dat" );
        path_2 = Path.Combine( Paths_program.program_path, "test_2.dat" );
        path_3 = Path.Combine( Paths_program.program_path, "test_3.dat" );
        path_4_EXIST_OU_SYSTEM = Path.Combine( Paths_program.program_path, "test_4.dat" );
        path_5_EXIST_OU_SYSTEM = Path.Combine( Paths_program.program_path, "test_5.dat" );
        path_6_DONT_EXIST = Path.Combine( Paths_program.program_path, "test_6.dat" );
        path_7_DONT_EXIST = Path.Combine( Paths_program.program_path, "test_7.dat" );

        path_storage = Path.Combine( Paths_program.program_path, "storage_test.dat" );


            System.IO.File.WriteAllBytes( path_1, ARRAY.Get_array<byte>( 10_000, (byte)'@' ) );
            System.IO.File.WriteAllBytes( path_2, ARRAY.Get_array<byte>( 10_000, (byte)'9' )  );
            System.IO.File.WriteAllBytes( path_3, ARRAY.Get_array<byte>( 10_000, (byte)'7' )  );
            System.IO.File.WriteAllBytes( path_storage, new byte[ 100_000 ]  );


            System.IO.File.WriteAllBytes( path_4_EXIST_OU_SYSTEM, ARRAY.Get_array<byte>( 1_000, (byte)'^' )  );

            System.IO.File.WriteAllBytes( path_5_EXIST_OU_SYSTEM, ARRAY.Get_array<byte>( 10_000, (byte)'1' )  );
            

        data_1 = Controllers.files.operations.Get_file_from_disk( path_1 );
        data_2 = Controllers.files.operations.Get_file_from_disk( path_2 );
        data_3 = Controllers.files.operations.Get_file_from_disk( path_3 );
        Data_file_link data_storage = Controllers.files.operations.Get_file_from_disk( path_storage );
        
        packet_storage = Packets_storage_data.Start( data_storage );

    }
    

    public static Task_req req = new Task_req();

    private static void Go_to_state_saving_crash(){


        Console.Log( "vai: " + current_state_crash );

        req.data.int_values[ 69 ] = 0;

        if( current_state_crash == Crash.save_stack )
            {
                // ** save a lot of diferent results 
                Controllers.files.operations.Change_data_file( data_1, 5, v );
                data_1 = Controllers.files.operations.Change_length_file( data_1, 500 );
                Controllers.files.operations.Remove_file( data_1 );

                // Controllers.files.operations.Change_data_file( data_2, 20, v );
                 Controllers.files.operations.Change_data_file( data_2, 20, 10d );
                //Controllers.files.operations.Change_data_file( data_2, 20, 4f );
                Controllers.files.operations.Remove_file( data_2 );

                Data_file_link data_4 = Controllers.files.operations.Get_file_from_disk( path_4_EXIST_OU_SYSTEM );
                Controllers.files.operations.Delete_file( path_5_EXIST_OU_SYSTEM );
                
                
                Data_file_link data_6 = Controllers.files.operations.Create_new_file( new byte[ 500 ] , path_6_DONT_EXIST );
                Controllers.files.operations.Change_data_file( data_6, 15, v );

                Data_file_link data_7 = Controllers.files.operations.Create_new_file( new byte[ 500 ] , path_7_DONT_EXIST );
                Controllers.files.operations.Delete_file( path_7_DONT_EXIST );

                //mark
                // Packet_key pk = packet_storage->Alloc_packet( 10 );
                // Packet p = packet_storage->Get_packet( pk );
                // ((int*)( p.Get_pointer_partial() )) [ 0 ] = 4;
                
                Controllers.stack.test.Save_stack_in_disk_sync();

            }


        if( current_state_crash == Crash.save_new_slot_file_link )
            {  MANAGER__controller_saving_saver.Save_link_paths( req ); }



        if( current_state_crash == Crash.create_saving_files_folders )
            { System.IO.Directory.CreateDirectory( Paths_run_time.saving_files_folder ); }

        if( current_state_crash == Crash.create_half_run_time_saving_files )
            {
                MANAGER__controller_saving_saver.Save_files( req );
                string p = File_run_time_saving_operations.Get_run_time_path( data_3.id, File_IO_operation._switch );
                if( !!!( System.IO.File.Exists( p )) ){ CONTROLLER__errors.Throw( "path dont exist: " + p ); }
                System.IO.File.Move( p, Paths_run_time.safety_stack_folder + "AAA.dat" );
            }
            
        if( current_state_crash == Crash.create_full_run_time_saving_files )
            {
                string p = File_run_time_saving_operations.Get_run_time_path( data_3.id, File_IO_operation._switch );
                if( System.IO.File.Exists( p ) ){ CONTROLLER__errors.Throw( "path exist: " + p ); }
                System.IO.File.Move( Paths_run_time.safety_stack_folder + "AAA.dat", p );
            }

        if( current_state_crash == Crash.create_saving_files_security_file )
            { MANAGER__controller_saving_saver.Create_security_file( req ); }

        
        if( current_state_crash == Crash.apply_logic_half )
            { req.data.int_values[ 69 ] = 1; MANAGER__controller_saving_saver.Apply_actions_files_in_saving_folder( req ); }

        if( current_state_crash == Crash.apply_logic_full )
            { req.data.int_values[ 69 ] = 2; MANAGER__controller_saving_saver.Apply_actions_files_in_saving_folder( req ); }


        if( current_state_crash == Crash.reset_stack )
            { MANAGER__controller_saving_saver.Reset_stack( req ); }

        if( current_state_crash == Crash.delete_saving_files_folder )
            { MANAGER__controller_saving_saver.Delete_saving_folder( req ); }

        if( current_state_crash == Crash.delete_file_links )
            { MANAGER__controller_saving_saver.Delete_file_links( req ); }

        if( current_state_crash == Crash.change_stack_start_files )
            { MANAGER__controller_saving_saver.Save_stack_start_files( req ); }
            


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


        if( Input.GetKeyDown( KeyCode.M ) )
            {  
                // Packet pac = packet_storage->Get_packet( Packet_key.Construct( Packet_storage_size._10_bytes, 0, 10 ) ); 
                // Console.Log( (*(int*)pac.Get_pointer_partial()) );
            }


        // --- 

        if( Input.GetKey( KeyCode.Keypad1 )  )
            {

                if( Input.GetKeyDown( KeyCode.P ) )
                    { Go_to_state_saving_crash(); }

                if( Input.GetKeyDown( KeyCode.O ) )
                    { Console.Log( "state: " + _Crash() ); }

                if( Input.GetKeyDown( KeyCode.I ) )
                    { Controllers.stack.saver.test.Force_corrupt_file( 10 ); }
                    
            }


        // ** TESTS FOR STAGES INTERUPTIONS
        if( Input.GetKey( KeyCode.Keypad2 ) )
            {

                if (Input.GetKeyDown( KeyCode.Q ) )
                    { Verify_crash(Crash.save_stack, Crash_handle_route.need_to_recosntruct_with_the_stack ); }

                if( Input.GetKeyDown( KeyCode.W ) )
                    { Verify_crash( Crash.save_new_slot_file_link,  Crash_handle_route.need_to_recosntruct_with_the_stack ); }

                if( Input.GetKeyDown( KeyCode.E ) )
                    { Verify_crash( Crash.create_saving_files_folders,  Crash_handle_route.need_to_recosntruct_with_the_stack ); }

                if( Input.GetKeyDown( KeyCode.R ) )
                    { Verify_crash( Crash.create_half_run_time_saving_files,  Crash_handle_route.need_to_recosntruct_with_the_stack ); }
                
                if( Input.GetKeyDown( KeyCode.T ) )
                    { Verify_crash( Crash.create_full_run_time_saving_files,  Crash_handle_route.need_to_recosntruct_with_the_stack ); }



                if( Input.GetKeyDown( KeyCode.A ) )
                    { Verify_crash( Crash.create_saving_files_security_file,  Crash_handle_route.all_temp_files_were_already_there_just_move ); }

                if( Input.GetKeyDown( KeyCode.S ) )
                    { Verify_crash( Crash.apply_logic_half,  Crash_handle_route.all_temp_files_were_already_there_just_move ); }

                if( Input.GetKeyDown( KeyCode.D ) )
                    { Verify_crash( Crash.apply_logic_full,  Crash_handle_route.all_temp_files_were_already_there_just_move ); }

                if( Input.GetKeyDown( KeyCode.F ) )
                    { Verify_crash( Crash.reset_stack,  Crash_handle_route.all_files_already_got_saved ); }

                if( Input.GetKeyDown( KeyCode.G ) )
                    { Verify_crash( Crash.delete_saving_files_folder,  Crash_handle_route.all_files_already_got_saved ); }


            }


        // ** test for corruptiosn






        


    }

    
    private static Crash_handle_return _Crash(){

        Controllers.stack.saver.strem_stack.Close();
        return Crash_handler.Deal_crash();


    }


    private static void Verify_crash( Crash _crash, Crash_handle_route _expected ){


            Crash_test_until( _crash );
            
            Crash_handle_return ret = _Crash();
            Crash_handle_route real_crash_handler = ret.route;

            if( ret.result == Crash_handle_result.fail )
                { Console.LogError( $"<Color=red>FAIL</Color>FAIL: " + ret.message ); }



            Console.Log( "stage crash test: " + _crash );
            Console.Log( "real route: " + real_crash_handler );
            Console.Log( "expected route: " + _expected );


            if( real_crash_handler != _expected )
                { CONTROLLER__errors.Throw( $"Expedcted <Color=lightBlue>{ _expected }</Color> but give <Color=lightBlue>{ real_crash_handler }</Color>" ); }

            Console.Log( "<Color=lime>PASS TEST</Color>" );

        // try{

        // } catch( Exception e )
        // {
        //     Console
        // }

    }


    private static void Crash_test_until( Crash _crash ){

        current_state_crash = Crash.save_stack;

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