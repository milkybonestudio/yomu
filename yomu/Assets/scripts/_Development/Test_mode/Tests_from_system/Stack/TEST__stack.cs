

using System.IO;
using System.Text;
using UnityEngine;


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

unsafe public static class TEST__stack {


    public static void Set(){

        value = (byte)'0';

    }

    public static byte value = (byte)'0';
    public static void Update(){



        if( Input.GetKeyDown( KeyCode.A ) )
            {
                Controllers.stack.files.Save_data_got_file_from_disk( '&', "path_to_file"  );
                Controllers.stack.test.Save_stack_in_disk_sync();
            }


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

                        Controllers.stack.test.Save_stack_in_disk_sync();
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

                                (byte)'0',(byte)'0',(byte)'0',(byte)'0',(byte)'0',    (byte)'0',(byte)'0',(byte)'0',(byte)'0',(byte)'0',
                                (byte)'0',(byte)'0',(byte)'0',(byte)'0',(byte)'0',   (byte)'0',(byte)'0',(byte)'0',(byte)'0',(byte)'0',

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



}