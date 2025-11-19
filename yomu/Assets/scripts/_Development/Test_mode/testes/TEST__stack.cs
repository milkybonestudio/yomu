using System;
using System.IO;
using System.Text;
using System.Threading;
using UnityEngine;

unsafe public static class TEST__stack {

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
                4_add_slots_files_half ( OK )
                5_add_slots_files_full ( OK )
                6_create_saving_files_security_file ( OK )
                7_move_files_half ( OK )
                71_move_files_full ( OK )
                72_switch_files_half ( OK )
                73_switch_files_full ( OK )
                8_reset_stack ( OK )
                9_delete_saving_files_security_file ( OK )
                91_delete_saving_files_folder ( OK )
        finish,

            
            

        --> update funciona 1 vez (OK)
        --> add data generic (OK)
        --> ciclo do update renova 
        --> save data in disk

        --> saver:
            --> normal
                --> save in file ( OK )
            

        --> buffer: 
            --> normal
                -> add data single (OK)
                -> add data multiples (OK)
                -> block negative length (OK)
                -> call loop from update when it can (OK)
                -> weight makes sense (OK)
                -> can call expand from update ()

            --> expansion:
                -> works (OK)
                    * expand -> save data -> disk == save in disk
                    * save data -> expand -> disk == save in disk
                -> checks if makes sense to expand (OK)
                -> prevent add too little or too much (OK)
                -> stop if buffer pass the limit (OK)
                -> checks if can really expand (OK)


            --> working with NO SPACE
                -> Start works (OK)
                -> add data (OK)
                -> handle weird sizes (OK)

                -> End works
                    --> pass NO SPACE to buffer ( most common )( OK )
                    --> pass buffer to no space and switches (OK)
                    --> create a new space (OK)

                -> clean all data when finish ( OK )
                -> auto reajust size ( OK )




            --> buffer loop:
                --> loop:
                    --> loop works
                    --> don't loop when is in 0 (OK)
                    --> protect when can't loop (OK)

                --> when things go right:
                    --> buffer add data ( OK )
                    --> see if the system needs to expand
                    --> when there is no space more try to handle
                    
                --> when things go wrong:
                    --> block invalid lengths (negative or too big )
                    --> check if is_passing_data makes sense
                    --> expands the buffer when there is no space
                    --> create small expansion when dont have space and is saving
                    --> switchs from methods dependind if is saving or not

    
    */



    public static void Set(){

        value = (byte)'0';
        Set_crash();
    }


    public static int file_length = 1_000_000;
    public static string path_to_packet_storage = $"{ System.IO.Directory.GetCurrentDirectory() }\\Assets\\Editor\\packet_storage.dat"; 

    public static byte value = (byte)'0';

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




    private static void Set_crash(){

        current_state_crash = Crash._1_save_stack;

        path_1 = Path.Combine( Paths_program.program_path, "test_1.dat" );
        path_2 = Path.Combine( Paths_program.program_path, "test_2.dat" );
        path_3 = Path.Combine( Paths_program.program_path, "test_3.dat" );

            System.IO.File.WriteAllBytes( path_1, ARRAY.Get_array<byte>( 10_000, (byte)'a' ) );
            System.IO.File.WriteAllBytes( path_2, ARRAY.Get_array<byte>( 10_000, (byte)'b' )  );
            System.IO.File.WriteAllBytes( path_3, ARRAY.Get_array<byte>( 10_000, (byte)'c' )  );

        data_1 = Controllers.files.Get_file( path_1, 10_000 );
        data_2 = Controllers.files.Get_file( path_2, 10_000 );
        data_3 = Controllers.files.Get_file( path_3, 10_000 );

    }

        static string path_1;
        static string path_2;
        static string path_3;

        static Data_file_link data_1;
        static Data_file_link data_2;
        static Data_file_link data_3;

        static Crash current_state_crash;

    private static void Crash_test_until( Crash _crash ){

        current_state_crash = Crash._1_save_stack;

        while( current_state_crash <= _crash )
            { Go_to_state_saving_crash(); }


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

                Controllers.stack.Save_stack_in_disk_sync();

                // Controllers.stack.files.Save_data_change_data_in_file( data_2.id, 5, v );
                // Controllers.stack.files.Save_data_change_data_in_file( data_2.id, 100, v );

                // Controllers.stack.Save_stack_in_disk_sync();

            }


        if( current_state_crash == Crash._2_save_new_slot_file_link )
            {
                Controllers.files.Save_link_paths_sync();
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

    public static void Test_crash(){


        // --- 

        if( Input.GetKeyDown( KeyCode.P ) )
            { Go_to_state_saving_crash(); }

        if( Input.GetKeyDown( KeyCode.O ) )
            { Console.Log( "state: " + _Crash() ); }

        if( Input.GetKeyDown( KeyCode.I ) )
            { Controllers.stack.saver.test.Force_corrupt_file( 10 ); }

            




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

                    Controllers.stack.Save_stack_in_disk_sync();

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

    public struct SS{

        public int a;
        public int b;
        public int c;
        public int d;
        public int e;
        public int f;

    }

    
    public static void Update(){

        Test_crash();
        return;



        // ** UPDATE
        if( Input.GetKeyDown( KeyCode.Space ) )
            {
                Console.Log( "<Color=lightBlue>----- WILL UPDATE STACK -----</Color>" );
                Controllers.stack.Update( new Control_flow() );
                Console.Log( "<Color=lightBlue>----- END UPDATE -----</Color>" );
            }


        if( Input.GetKeyDown( KeyCode.B ) )
            {
                Controllers.tasks.Get_task_request( "a" ).Give_multithread_final( (Task_req _) => { Controllers.heap.Get_fast_pointer( 10 ); } );
            }



        // ** TESTS


        void Go_return_no_space(){

            if( Controllers.stack.buffer.pointer_in_buffer != 0 )
                { CONTROLLER__errors.Throw( "Pointer to buffer need to be 0" ); }

            byte first_byte = (byte)'#';
            Controllers.stack.test.Save_data( &first_byte, 1 );
            Controllers.stack.test.Save_data( &first_byte, 1 );

            Controllers.stack.test.Save_data( &first_byte, 1 );
            Controllers.stack.test.Save_data( &first_byte, 1 );
            Controllers.stack.test.Save_data( &first_byte, 1 );
            Controllers.stack.test.Save_data( &first_byte, 1 );
            Controllers.stack.test.Save_data( &first_byte, 1 );
            Controllers.stack.test.Save_data( &first_byte, 1 );
            Controllers.stack.test.Save_data( &first_byte, 1 );
            Controllers.stack.test.Save_data( &first_byte, 1 );
            Controllers.stack.test.Save_data( &first_byte, 1 );
            Controllers.stack.test.Save_data( &first_byte, 1 );


            Controllers.stack.Force_try_to_save_stack();

            // ** go to limit: 


            byte primeiro_byte = (byte)'$';
            Controllers.stack.test.Save_data( &primeiro_byte, 1 );

            byte[] data = ARRAY.Get_array<byte>( ( Controllers.stack.buffer.buffer_size - 14 ), (byte)'7' ); 
            Controllers.stack.test.Save_data( data, data.Length );

            byte penultimo_byte = (byte)'@';
            Controllers.stack.test.Save_data( &penultimo_byte, 1 );



        }
        
        if( Input.GetKey( KeyCode.LeftControl ) )
            {


                if( Input.GetKeyDown( KeyCode.Z ) )
                    {
                        Console.Log( "a" );

                        Controllers.stack.files.Save_data_change_data_in_file<byte>( (byte)'%', (byte)'*', (byte)'a' );
                        Controllers.stack.files.Save_data_change_data_in_file<int>( (byte)'%', (byte)'*', 350 );

                        SS v = new SS(){
                            a = 65,
                            b = 66,
                            c = 67,
                            d = 68,
                            e = 69,
                            f = 70
                        };

                        Controllers.stack.files.Save_data_change_data_in_file( (byte)'%', (byte)'*', v ); // ** T
                        Controllers.stack.files.Save_data_change_data_in_file( (byte)'%', (byte)'*', &v ); // ** T*
                        Controllers.stack.files.Save_data_change_data_in_file( (byte)'%', (byte)'*', (void*)&v, sizeof( SS ) ); // void*

                        Controllers.stack.Save_stack_in_disk_sync();
                    }



                // ** PASS DATA TO NORMAL BUFFER
                if( Input.GetKeyDown( KeyCode.A ) )
                    {
                        Console.Log( "<Color=lightBlue>--- TESTE loop + pass of no_space to normal buffer ---</Color>"  );

                        // ** ca add data
                        Go_return_no_space();

                        byte VALUE_return_buffer = (byte)'A';
                        Controllers.stack.test.Save_data( &VALUE_return_buffer, 1 );

                            Controllers.stack.buffer.Save_file_normal_buffer();
                            Controllers.stack.buffer.Save_file_NO_SPACE_buffer();

                        // ** execute ( jump multithread )
                        Controllers.stack.saver.req_saving.fn_multithread( Controllers.stack.saver.req_saving );
                        Controllers.stack.saver.req_saving.stage = Task_req_stage.finished;

                        Console.Log( "last byte: " + new string( new char[] {(char)Controllers.stack.buffer.Get_pointer_buffer( ( Controllers.stack.buffer.buffer_size - 1 ))[ 0 ] })  );
                        Console.Log( "first byte: " + new string( new char[] {(char)Controllers.stack.buffer.Get_pointer_buffer( ( 0 ))[ 0 ] })  );

                        Console.Log( "<Color=lightBlue>PASS</Color>" );

                        

                    }


                // ** USE NO_SPACE
                if( Input.GetKeyDown( KeyCode.S ) )
                    {
                        Console.Log( "<Color=lightBlue>--- TESTE pass data from normal buffer to NO SPACE and switch  ---</Color>"  );

                        // ** ca add data
                        Go_return_no_space();

                        byte[] fff = new byte[]{

                            (byte)'<',

                                (byte)'0',
                                (byte)'0',
                                (byte)'0',
                                (byte)'0',
                                (byte)'0',

                                (byte)'0',
                                (byte)'0',
                                (byte)'0',
                                (byte)'0',
                                (byte)'0',

                                (byte)'0',
                                (byte)'0',
                                (byte)'0',
                                (byte)'0',
                                (byte)'0',

                                (byte)'0',
                                (byte)'0',
                                (byte)'0',
                                (byte)'0',
                                (byte)'0',

                            (byte)'>',

                        };
                        Controllers.stack.test.Save_data( fff, fff.Length );

                            Controllers.stack.buffer.Save_file_normal_buffer();
                            Controllers.stack.buffer.Save_file_NO_SPACE_buffer();

                        // ** execute ( jump multithread )
                        Controllers.stack.saver.req_saving.fn_multithread( Controllers.stack.saver.req_saving );
                        Controllers.stack.saver.req_saving.stage = Task_req_stage.finished;

                        Console.Log( "last byte: " + new string( new char[] {(char)Controllers.stack.buffer.Get_pointer_buffer( ( Controllers.stack.buffer.buffer_size - 1 ))[ 0 ] })  );
                        Console.Log( "first byte: " + new string( new char[] {(char)Controllers.stack.buffer.Get_pointer_buffer( ( 0 ))[ 0 ] })  );

                        Console.Log( "<Color=lightBlue>PASS</Color>" );

                        

                    }



                // ** USE NO_SPACE
                if( Input.GetKeyDown( KeyCode.D ) )
                    {
                        Console.Log( "<Color=lightBlue>--- TESTE NEED TO CREATE NEW ---</Color>"  );

                        // ** ca add data
                        Go_return_no_space();

                        
                        byte VALUE_return_buffer = (byte)'S';
                        Controllers.stack.test.Save_data( &VALUE_return_buffer, 1 );

                        byte[] data = ARRAY.Get_array<byte>( ( Controllers.stack.buffer.key_no_space.Get_length() - 2 ), (byte)'8' ); 
                        Controllers.stack.test.Save_data( data, data.Length );

                        VALUE_return_buffer = (byte)'K';
                        Controllers.stack.test.Save_data( &VALUE_return_buffer, 1 );

                            Controllers.stack.buffer.Save_file_normal_buffer();
                            Controllers.stack.buffer.Save_file_NO_SPACE_buffer();

                        // ** execute ( jump multithread )
                        Controllers.stack.saver.req_saving.fn_multithread( Controllers.stack.saver.req_saving );
                        Controllers.stack.saver.req_saving.stage = Task_req_stage.finished;

                        Console.Log( "last byte: " + new string( new char[] {(char)Controllers.stack.buffer.Get_pointer_buffer( ( Controllers.stack.buffer.buffer_size - 1 ))[ 0 ] })  );
                        Console.Log( "first byte: " + new string( new char[] {(char)Controllers.stack.buffer.Get_pointer_buffer( ( 0 ))[ 0 ] })  );

                        Console.Log( "<Color=lightBlue>PASS</Color>" );

                        

                    }



                Controllers.stack.Change_state( SAFETY_STACK__state.waiting_to_save_stack );

                return;
                
            }




            if( Input.GetKeyDown( KeyCode.Y ) )
                {
                    Controllers.stack.saver.Clean_file();

                }

        // ** TEST END NO SPACE 
        if( Input.GetKeyDown( KeyCode.M ) )
            {
                byte value = (byte)'a';

                Controllers.stack.test.Save_data( &value, 1 );

                // ** vai salvar ( move pointers )
                Controllers.stack.Force_try_to_save_stack();

                // ** vai salvar no NO SPACE
                Controllers.stack.buffer.Start_save_data_with_no_space( 1_000 );

                ++value;
                Controllers.stack.test.Save_data( &value, 1 );

                ++value;
                Controllers.stack.test.Save_data( &value, 1 );

                // ** vai encerrar automaticamente quando a task ativar a multithread

            }

        if( Input.GetKeyDown( KeyCode.O ) )
            {
                Controllers.stack.buffer.Save_file_normal_buffer();
                Controllers.stack.buffer.Save_file_NO_SPACE_buffer();
            }


        // ** ADD VALUE
        if( Input.GetKeyDown( KeyCode.Q ) )
            {
                byte v = value;
                Controllers.stack.test.Save_data( &v, 1 );
                value++;
            }

        if( Input.GetKeyDown( KeyCode.W ) )
            {
                byte[] aaa = Encoding.UTF8.GetBytes( "<<VALUE>>" );
                fixed ( byte* p = aaa ){
                    Controllers.stack.test.Save_data( p, aaa.Length );
                }
            }

        if( Input.GetKeyDown( KeyCode.E ) )
            {
                byte value = (byte)'a';
                byte[] arr = ARRAY.Get_array<byte>( 100_000, (byte) 'a' );
                fixed ( byte* p = arr ){
                    Controllers.stack.test.Save_data( p, arr.Length );
                }
            }




        if( Input.GetKeyDown( KeyCode.R ) )
            {
                byte value = (byte)'a';
                byte[] arr = ARRAY.Get_array<byte>( 10_000_000, (byte) 'a' );
                fixed ( byte* p = arr ){
                    Controllers.stack.test.Save_data( p, arr.Length );
                }
            }

        if( Input.GetKeyDown( KeyCode.T ) )
            {
                byte value = (byte)'a';
                byte[] arr = ARRAY.Get_array<byte>( 8_000_000, (byte) 'a' );
                fixed ( byte* p = arr ){
                    Controllers.stack.test.Save_data( p, arr.Length );
                }
            }


        // if( Input.GetKeyDown( KeyCode.Y ) )
        //     {
        //         byte value = (byte)'a';
        //         byte[] arr = ARRAY.Get_array<byte>( 10_000_000, (byte) 'a' );
        //         fixed ( byte* p = arr ){
        //             Controllers.stack.test.Save_data( p, -1 );
        //         }
        //     }





        // ** LOOP

        if( Input.GetKeyDown( KeyCode.L ) )
            {
                Controllers.stack.buffer.Loop();
            }


        if( Input.GetKeyDown( KeyCode.C ) )
            {
                Console.Log( "can loop:" + Controllers.stack.buffer.Can_loop() );
            }



        if( Input.GetKeyDown( KeyCode.G ) )
            { 
                
                Controllers.stack.Force_try_to_save_stack();
                Controllers.tasks.Block_multithread_TEST();
                // Controllers.stack.buffer.Start_save_data_with_no_space( 1_000 ); 

            }
            

        if( Input.GetKeyDown( KeyCode.H ) )
            {
                Controllers.tasks.Liberate_multithread_TEST();
                // Controllers.stack.Change_state( SAFETY_STACK__state.saving_stack );
                // Controllers.stack.buffer.Simulate_is_passing_data_TEST();

            }


        if( Input.GetKeyDown( KeyCode.K ) )
            {
                Controllers.stack.Change_state( SAFETY_STACK__state.saving_stack );
                

            }





        if( Input.GetKeyDown( KeyCode.J ) )
            { Controllers.stack.buffer.End_save_data_with_no_space(); }


        



            
        // ** support

        if( Input.GetKeyDown( KeyCode.P ) )
            {
                Controllers.stack.Print_data();
            }
        if( Input.GetKeyDown( KeyCode.S ) )
            {
                Controllers.stack.Force_try_to_save_stack();
            }
        


        if( Input.GetKeyDown( KeyCode.Alpha0 ) )
            {
                Controllers.stack.buffer.Expand_buffer( 0 );
            }

        if( Input.GetKeyDown( KeyCode.Alpha1 ) )
            {
                Controllers.stack.buffer.Expand_buffer( 1 );
            }

        if( Input.GetKeyDown( KeyCode.Alpha2 ) )
            {
                Controllers.stack.buffer.Expand_buffer( 1_000 );
            }


        // ** EXPAND BUFFER
        if( Input.GetKeyDown( KeyCode.Alpha3 ) )
            {
                Controllers.stack.buffer.Expand_buffer( 50_000 );
            }


        // ** EXPAND BUFFER
        if( Input.GetKeyDown( KeyCode.Alpha4 ) )
            {
                Controllers.stack.buffer.Expand_buffer( 10_000_000 );
            }

        if( Input.GetKeyDown( KeyCode.Alpha5 ) )
            {
                Controllers.stack.buffer.Expand_buffer( -10 );
            }

            

    }



    public static void Testing_crash_handler_update(){




    }









}