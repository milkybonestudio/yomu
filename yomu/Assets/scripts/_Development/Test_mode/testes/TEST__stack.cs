using System.IO;
using System.Text;
using UnityEngine;

unsafe public static class TEST__stack {

    /*

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

            System.IO.File.WriteAllBytes( path_1, new byte[ 10_000 ] );
            System.IO.File.WriteAllBytes( path_2, new byte[ 10_000 ] );
            System.IO.File.WriteAllBytes( path_3, new byte[ 10_000 ] );

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
                byte[] data = ARRAY.Get_array<byte>( 5, (byte)'@' ); 
                Controllers.stack.Save_data( data, data.Length );

                Controllers.stack.Save_stack_in_disk_sync();

                data = ARRAY.Get_array<byte>( 5, (byte)'$' ); 
                Controllers.stack.Save_data( data, data.Length );

                Controllers.stack.Save_stack_in_disk_sync();

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
                Controllers.files.Save_file_run_time( data_1 );
                Controllers.files.Save_file_run_time( data_2 );
            }
            
        if( current_state_crash == Crash._5_add_slots_files_full )
            {
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



        

    }

    public static void Test_crash(){



        if( Input.GetKeyDown( KeyCode.Q ) )
            {
                Go_to_state_saving_crash();
                current_state_crash++;
            }

        if( Input.GetKeyDown( KeyCode.W ) )
            {
                Controllers.stack.saver.End();
                Crash_handler.Deal_crash();
            }

        


    }

    
    public static void Update(){

        Test_crash();
        return;

        if( Input.GetKeyDown( KeyCode.Space ) )
            {
                byte[] data = ARRAY.Get_array<byte>( 1000, (byte)'2' ); 
                Controllers.stack.Save_data( data, data.Length );

                Controllers.stack.Save_stack_in_disk_sync();
            }


        

        return;


        // ** UPDATE
        if( Input.GetKeyDown( KeyCode.Space ) )
            {
                Console.Log( "<Color=lightBlue>----- WILL UPDATE STACK -----</Color>" );
                Controllers.stack.Update( new Control_flow() );
                Console.Log( "<Color=lightBlue>----- END UPDATE -----</Color>" );
            }



        // ** TESTS


        void Go_return_no_space(){

            if( Controllers.stack.buffer.pointer_in_buffer != 0 )
                { CONTROLLER__errors.Throw( "Pointer to buffer need to be 0" ); }

            byte first_byte = (byte)'#';
            Controllers.stack.Save_data( &first_byte, 1 );
            Controllers.stack.Save_data( &first_byte, 1 );

            Controllers.stack.Save_data( &first_byte, 1 );
            Controllers.stack.Save_data( &first_byte, 1 );
            Controllers.stack.Save_data( &first_byte, 1 );
            Controllers.stack.Save_data( &first_byte, 1 );
            Controllers.stack.Save_data( &first_byte, 1 );
            Controllers.stack.Save_data( &first_byte, 1 );
            Controllers.stack.Save_data( &first_byte, 1 );
            Controllers.stack.Save_data( &first_byte, 1 );
            Controllers.stack.Save_data( &first_byte, 1 );
            Controllers.stack.Save_data( &first_byte, 1 );


            Controllers.stack.Force_try_to_save_stack();

            // ** go to limit: 


            byte primeiro_byte = (byte)'$';
            Controllers.stack.Save_data( &primeiro_byte, 1 );

            byte[] data = ARRAY.Get_array<byte>( ( Controllers.stack.buffer.buffer_size - 14 ), (byte)'7' ); 
            Controllers.stack.Save_data( data, data.Length );

            byte penultimo_byte = (byte)'@';
            Controllers.stack.Save_data( &penultimo_byte, 1 );



        }
        
        if( Input.GetKey( KeyCode.LeftControl ) )
            {

                // ** PASS DATA TO NORMAL BUFFER
                if( Input.GetKeyDown( KeyCode.A ) )
                    {
                        Console.Log( "<Color=lightBlue>--- TESTE loop + pass of no_space to normal buffer ---</Color>"  );

                        // ** ca add data
                        Go_return_no_space();

                        byte VALUE_return_buffer = (byte)'A';
                        Controllers.stack.Save_data( &VALUE_return_buffer, 1 );

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
                        Controllers.stack.Save_data( fff, fff.Length );

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
                        Controllers.stack.Save_data( &VALUE_return_buffer, 1 );

                        byte[] data = ARRAY.Get_array<byte>( ( Controllers.stack.buffer.key_no_space.Get_length() - 2 ), (byte)'8' ); 
                        Controllers.stack.Save_data( data, data.Length );

                        VALUE_return_buffer = (byte)'K';
                        Controllers.stack.Save_data( &VALUE_return_buffer, 1 );

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

                Controllers.stack.Save_data( &value, 1 );

                // ** vai salvar ( move pointers )
                Controllers.stack.Force_try_to_save_stack();

                // ** vai salvar no NO SPACE
                Controllers.stack.buffer.Start_save_data_with_no_space( 1_000 );

                ++value;
                Controllers.stack.Save_data( &value, 1 );

                ++value;
                Controllers.stack.Save_data( &value, 1 );

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
                Controllers.stack.Save_data( &v, 1 );
                value++;
            }

        if( Input.GetKeyDown( KeyCode.W ) )
            {
                byte[] aaa = Encoding.UTF8.GetBytes( "<<VALUE>>" );
                fixed ( byte* p = aaa ){
                    Controllers.stack.Save_data( p, aaa.Length );
                }
            }

        if( Input.GetKeyDown( KeyCode.E ) )
            {
                byte value = (byte)'a';
                byte[] arr = ARRAY.Get_array<byte>( 100_000, (byte) 'a' );
                fixed ( byte* p = arr ){
                    Controllers.stack.Save_data( p, arr.Length );
                }
            }




        if( Input.GetKeyDown( KeyCode.R ) )
            {
                byte value = (byte)'a';
                byte[] arr = ARRAY.Get_array<byte>( 10_000_000, (byte) 'a' );
                fixed ( byte* p = arr ){
                    Controllers.stack.Save_data( p, arr.Length );
                }
            }

        if( Input.GetKeyDown( KeyCode.T ) )
            {
                byte value = (byte)'a';
                byte[] arr = ARRAY.Get_array<byte>( 8_000_000, (byte) 'a' );
                fixed ( byte* p = arr ){
                    Controllers.stack.Save_data( p, arr.Length );
                }
            }


        // if( Input.GetKeyDown( KeyCode.Y ) )
        //     {
        //         byte value = (byte)'a';
        //         byte[] arr = ARRAY.Get_array<byte>( 10_000_000, (byte) 'a' );
        //         fixed ( byte* p = arr ){
        //             Controllers.stack.Save_data( p, -1 );
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