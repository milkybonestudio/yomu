
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

unsafe public struct MANAGER__safety_stack_saver {


    public static MANAGER__safety_stack_saver Construct( ref CONTROLLER__safety_stack _controller_ref ){

        MANAGER__safety_stack_saver ret = default;

            ret.stream_size = 50_000;
            

            // ret.strem_stack = FILE_STREAM.Criar_stream( Paths_program.safety_stack_file, ret.stream_size );
            ret.strem_stack = FILE_STREAM.Criar_stream( Paths_program.safety_stack_file, ret.stream_size );
            ret.file_size = _controller_ref.safety_file_size;


            ret.req_saving = new Task_req( "req_saving" );
            ret.req_saving.Change_stage( Task_req_stage.finished );

            // ** didn't save the 0
            ret.pointer_buffer_already_saved = -1;
            
            ret.heap_key_span_safety_digits = Controllers.heap.Get_unique( ( 2 * sizeof( int ) ) );


        return ret;

    }


    public void End(){

        Controllers.heap?.Return_key( heap_key_span_safety_digits );
        strem_stack?.Close();

    }


    public bool Stack_file_is_close_to_end(){

        int _80 = 8 * ( current_pointer_in_file / 10 );

        return file_size > ( _80 );

    }


    public void Print_data(){

        Console.Log( "WILL PRINT DATA SAVER" );

        Console.Log( "--- pointer_buffer_already_saved: " + pointer_buffer_already_saved );
        Console.Log( "--- current_pointer_in_file: " + current_pointer_in_file );
        Console.Log( "--- file_size: " + file_size );
        Console.Log( "--- block_number: " + block_number );


    }

    private Heap_key heap_key_span_safety_digits;
    private ReadOnlySpan<byte> Get_span(){ return new ReadOnlySpan<byte>( heap_key_span_safety_digits.Get_pointer(), heap_key_span_safety_digits.Get_length() ); }

    public int file_size; // ** need for the stream
    public int stream_size;

    public FileStream strem_stack;
    public Task_req req_saving;



    // public volatile int pointer_save_START;
    // public volatile int pointer_save_END;

    public volatile int pointer_buffer_already_saved;
    public volatile int current_pointer_in_file;
    public volatile int block_number;


    // private volatile int current_block_signature_index;
    // private volatile int current_length_signature_index;

    
    public void Sinalize_saved_all_files(){

        if( System_run.show_stack_messages )
            { Console.Log( "Called Sinalize_saved_all_files() in <Color=lightBlue>saver</Color>" ); }

        // ** reset file 

        Clean_file();
        Interlocked.Exchange( ref current_pointer_in_file, 0 );
        Interlocked.Exchange( ref block_number, 0 );
        

    }

    public void Clean_file(){

        strem_stack.Seek( 0, SeekOrigin.Begin );


        const int buffer_size = ( 256 * 1024 ); // 4 MB
        byte[] buffer_0 = new byte[ buffer_size ];
        
        int bytes_still_with_data = (int) strem_stack.Length;

        while ( bytes_still_with_data > 0 ){

            int bytes_write = Math.Min( buffer_size, bytes_still_with_data );
            bytes_still_with_data -= bytes_write;
            
            strem_stack.Write( buffer_0, 0, bytes_write );

            continue;

        }


    }


    public void Sinalize_buffer_loop(){

        pointer_buffer_already_saved = -1;
        return;

    }


    public Task_req Sinalize_to_save(){

        req_saving = new Task_req( "req saving stack in disk" );

            req_saving.Give_multithread_final( MANAGER__safety_stack_saver.Save_in_disk );
            req_saving.Change_priority( 10_000 );

            // ** sempre referentes ao buffer 
            req_saving.data.int_values[ 0 ] = ( Controllers.stack.saver.pointer_buffer_already_saved + 1 );
            req_saving.data.int_values[ 1 ] = Controllers.stack.buffer.Get_pointer_to_pass_data_to_disk();


        Controllers.tasks.Adicionar_task( req_saving );

        return req_saving;

    }




    // -- CALLED IN THE MULTITHREAD
    // ** NEED TO GET THE STRUCT AGAIN WITH THE STATIC DATA
    public static void Save_in_disk( Task_req _req ){

        
        // ** NEED TO GET BEFORE BECAUSE THE SYSTEM CAN CONTIUE TO ADD MORE DATA IN THE SINGLE, BUT WILL ONLY SRTART IN THE MULTI
        int pointer_save_START = _req.data.int_values[ 0 ];
        int pointer_save_END = _req.data.int_values[ 1 ];

        int total_bytes_to_save = ( pointer_save_END - pointer_save_START + 1 );
        int total_bytes_to_pass_to_file = (
            ( 2 * sizeof( int ) ) + // **  block + length
            total_bytes_to_save + // ** data
            ( 2 * sizeof( int ) )  // **  2 numbers safety
        );

        if( System_run.show_stack_messages )
            {
                Console.Log( "pointer_save_END: " + pointer_save_END );
                Console.Log( "pointer_save_START: " + pointer_save_START );
                Console.Log( "total_bytes_to_save: " + total_bytes_to_save );
            }

        if( total_bytes_to_save <= 0 )
            { CONTROLLER__errors.Throw( $"Tried to save <Color=lightBlue>{ total_bytes_to_save }</Color> bytes" ); }


        if( System_run.show_stack_messages )
            { Console.Log( $"Will give Seek in the stream to the point <Color=lightBlue>{ Controllers.stack.saver.current_pointer_in_file }</Color> in the file" ); }


        // ** MOVE TEH POINTER IN FILE
        Controllers.stack.saver.strem_stack.Seek( Controllers.stack.saver.current_pointer_in_file, SeekOrigin.Begin  ); // --- DEFINE AGAIN FOR SAFETY
        Interlocked.Add( ref Controllers.stack.saver.current_pointer_in_file, total_bytes_to_pass_to_file );

        // --- START

        byte* signature_start_data_pointer = stackalloc byte[ 2 * sizeof( int ) ];

            ((int*) signature_start_data_pointer)[ 0 ] = Interlocked.Add( ref Controllers.stack.saver.block_number, 1 );
            ((int*) signature_start_data_pointer)[ 1 ] = total_bytes_to_save;


        ReadOnlySpan<byte> signature_start_data_span = new ReadOnlySpan<byte>( signature_start_data_pointer, (2 * sizeof( int )) );
        
        if( System_run.show_stack_messages )
            { Console.Log( $"Will write the signature bytes, block: <Color=lightBlue>{ Controllers.stack.saver.block_number }</Color> and length: <Color=lightBlue>{ total_bytes_to_save }</Color>" ); }

        Controllers.stack.saver.strem_stack.Write( signature_start_data_span );


        // --- PASS DATA



        byte* pointer_to_buffer = Controllers.stack.buffer.Get_pointer_buffer( pointer_save_START );
        ReadOnlySpan<byte> data_span = new ReadOnlySpan<byte>( pointer_to_buffer, total_bytes_to_save );

        

        if( System_run.show_stack_messages )
            { 
                Console.Log( $"Will write the data <Color=lightBlue>in the stream</Color>" ); 
                if( total_bytes_to_save < 10 )
                    {
                        Console.Log( "--- VALUES THAT WILL SAVE IN DISK: " );
                        for( int print_index = 0 ; print_index < total_bytes_to_save ; print_index++ )
                            { Console.Log( $"----- index <Color=lightBlue>{ print_index }</Color>: <Color=lightBlue>{ pointer_to_buffer[ print_index ] }</Color>" ); }

                        Console.Log( "--- END VALUES " );

                    }
                    else
                    { 
                        Console.Log( "Too many bytes to print" ); 
                    }
            }

        Controllers.stack.saver.strem_stack.Write( data_span );

        
        // --- ADD SAFETY DIGITS

        byte* safety_digit = stackalloc byte[ 2 * sizeof( int ) ];

            ((int*) safety_digit)[ 0 ] = SECURITY_VALUE;
            ((int*) safety_digit)[ 1 ] = SECURITY_VALUE;

        ReadOnlySpan<byte> safety_digit_span = new ReadOnlySpan<byte>( safety_digit, (2 * sizeof( int )) );


        if( System_run.show_stack_messages )
            { Console.Log( $"Will write 8 bytes <Color=lightBlue>SECURITY_VALUE</Color>" ); }

        Controllers.stack.saver.strem_stack.Write( safety_digit_span );

        
        // --- FINISHES


        
        if( System_run.show_stack_messages )
            { Console.Log( $"Will write the data <Color=lightBlue>IN DISK</Color> by the strem.flush()" ); }

        Controllers.stack.saver.strem_stack.Flush();


        Interlocked.Exchange( ref Controllers.stack.saver.pointer_buffer_already_saved, pointer_save_END );
        
            

        if( System_run.show_stack_messages )
            { Console.Log( $" --- <Color=lightBlue>FINISH SAVE STACK IN DISC</Color> ---" ); }

        return;

    }

    // public const int SECURITY_VALUE = 0b_0001_1001__0111_1101__0001_0111__0101_1111;
    public const int SECURITY_VALUE = 64;




}
