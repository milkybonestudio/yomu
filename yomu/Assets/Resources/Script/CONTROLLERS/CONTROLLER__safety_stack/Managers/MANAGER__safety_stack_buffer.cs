
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Unity.Collections.LowLevel.Unsafe;

unsafe public struct MANAGER__safety_stack_buffer {


    public static MANAGER__safety_stack_buffer Construct( ref CONTROLLER__safety_stack _controller ){

        MANAGER__safety_stack_buffer ret = default;

            ret.pointer_in_buffer = 0;
            
            ret.buffer_size = 500_000;
            ret.buffer_length_use_to_loop = 400_000;

            // ** sempre tem uma copia da stack, para evitar problemas
            ret.heap_key_buffer = Controllers.heap.Get_unique( ret.buffer_size );
            ret.buffer_pointer_0 = ret.heap_key_buffer.Get_pointer();


        return ret;

    }


    public void Reset(){

        Clean_normal_buffer();
        Clean_no_space();
        is_passing_data = 0;

        return;
    }

    // ** WILL BE A "COPY" OF THE STACK FILE, BUT ONLY IN BLOCKS
    // ** the file will probably be bigger, so this needs to loop in itself

    public void Clean_normal_buffer(){

        if( heap_key_buffer.Is_valid() )
            { UnsafeUtility.MemClear( buffer_pointer_0, ( long ) heap_key_buffer.Get_length() ); }

        pointer_in_buffer = 0;

    }

    // --- NORMAL BUFFER
    // ** pointer_in_buffer 
    private Heap_key heap_key_buffer;
    private void* buffer_pointer_0;
    public int pointer_in_buffer;
    public int buffer_size;
    public int buffer_length_use_to_loop;


    
    private void Change_normal_buffer( Heap_key _heap_key_buffer ){

        if( heap_key_buffer.Is_valid() )
            { CONTROLLER__errors.Throw(""); }


    }

    public void End(){

        if( heap_key_buffer.Is_valid() )
            { Controllers.heap.Return_key( heap_key_buffer ); }

        

    }


    public void Simulate_is_passing_data_TEST(){

        Console.Log( " Called Simulate_is_passing_data_TEST()" );
        is_passing_data = 1;

    }

    public int Get_bytes_in_normal_buffer_still_not_saved(){

        if( System_run.max_security )
            {
                if( Controllers.stack.state == SAFETY_STACK__state.saving_stack )
                    { CONTROLLER__errors.Throw( "The function Get_bytes_in_normal_buffer_still_not_saved() works only if the system is not saving" ); }
            }

        return ( pointer_in_buffer - Controllers.stack.saver.pointer_buffer_already_saved - 1 );

    }

    public void Print_data(){

        Console.Log( "WILL PRINT DATA BUFFER" );

        Console.Log( "- FLAGS: " );
        Console.Log( "--- is_saving_with_no_space: " + is_saving_with_no_space );
        Console.Log( "--- is_passing_data: " + is_passing_data );


        Console.Log( "- NORMAL BUFFER: " );
        Console.Log( "--- pointer_in_buffer: " + Formater.Format_number( pointer_in_buffer ) );
        Console.Log( "--- pointer_buffer_already_saved: " + Formater.Format_number( Controllers.stack.saver.pointer_buffer_already_saved ) );
        
        Console.Log( "--- number of bytes: " + Formater.Format_number( pointer_in_buffer - Controllers.stack.saver.pointer_buffer_already_saved - 1 ) );
        Console.Log( "--- buffer_size: " + Formater.Format_number( buffer_size ) );
        Console.Log( "--- key length: " + Formater.Format_number( heap_key_buffer.Get_length() ) );
        Console.Log( "--- buffer_length_use_to_loop: " + Formater.Format_number( buffer_length_use_to_loop ) );
        Console.Log( "--- buffer_pointer_0: " + Formater.Format_number( buffer_pointer_0 ) );


        if( is_saving_with_no_space == 1 )
            {
                Console.Log( "- NO SPACE BUFFER: " );

                Console.Log( "--- pointer_in_NO_SPACE_buffer: " + Formater.Format_number( pointer_in_NO_SPACE_buffer ) );
                Console.Log( "--- bytes used: " + Formater.Format_number( pointer_in_NO_SPACE_buffer ) );
                Console.Log( "--- key length: " + Formater.Format_number( key_no_space.Get_length() ) );
                Console.Log( "--- pointer_no_space_buffer: " + Formater.Format_number( pointer_no_space_buffer ) );

            }

        return;

    }


    public void Print_values_normal_buffer(){

        if( pointer_in_buffer < 30 )
            {
                for( int index = 0 ; index < 30 ; index++ )
                    { Console.Log( $"index[ <Color=lightBlue>{ index }</Color> ]: <Color=lightBlue>{ *Get_pointer_buffer( index ) }</Color>" ); }

            }

    }



    public void Save_file_normal_buffer(){

        Console.Log( "---- <Color=lightBlue>{ WILL SAVE NORMAL BUFFER IN FILE TO TEST }</Color> ----" );

        try{ Files.Save_critical_file( ( Paths_run_time.safety_stack_file + "NORMAL_BUFFER.dat" ), buffer_pointer_0, buffer_size ); } catch( Exception e ){ Console.Log( "Could not save file NORMAL BUFFER" ); }

    }

    public void Save_file_NO_SPACE_buffer(){

        if( is_saving_with_no_space == 0 )
            {

                try{

                    Console.Log( "---- is not saving no space ----" );
                    byte* aaa = stackalloc byte[ 10 ];
                    Files.Save_critical_file( ( Paths_run_time.safety_stack_file + "NO_SPACE.dat" ),  aaa, 10 );

                } catch( Exception e ){
                    Console.Log( "Could not save file NO_SPACE_buffer" );
                }
                return;
            }

        try{

            Console.Log( "---- <Color=lightBlue>{ WILL SAVE NO SPACE BUFFER IN FILE TO TEST }</Color> ----" );
            Files.Save_critical_file( ( Paths_run_time.safety_stack_file + "NO_SPACE.dat" ), key_no_space.Get_pointer(), key_no_space.Get_length() );

        } catch( Exception e ){

            Console.Log( "Could not save file NO_SPACE_buffer" );

        }



    }




    public bool Can_loop(){

        if( System_run.show_stack_messages_buffer )
            { Console.Log( "Came in Can_loop()" ); }

        if( Controllers.stack.state != SAFETY_STACK__state.waiting_to_save_stack )
            { 
                if( System_run.show_stack_messages_buffer )
                    { Console.Log( $"The state is <Color=lightBlue>{ Controllers.stack.state }</Color>, so it can't loop" ); }

                return false; 
            }

        // ** STATE IS FINE 

        bool can_loop = ( pointer_in_buffer > buffer_length_use_to_loop );

        if( System_run.show_stack_messages_buffer )
            { 
                Console.Log( "pointer_in_buffer: " + pointer_in_buffer ); 
                Console.Log( "buffer_length_use_to_loop: " + buffer_length_use_to_loop ); 
                Console.Log( "can_loop: " + can_loop ); 
            }

        return can_loop;

    }

    public int Loop(){

        if( System_run.show_stack_messages_buffer )
            { Console.Log( "Call loop()" ); }

        if( System_run.max_security )
            {
                if( buffer_pointer_0 == null )
                    { CONTROLLER__errors.Throw( "pointer is null" ); }

                if( Controllers.stack.saver.pointer_buffer_already_saved > buffer_size )
                    { CONTROLLER__errors.Throw( "Index saved is bigger than the buffer, dont make sense" ); }

            }

        
        int index_already_saved = Controllers.stack.saver.pointer_buffer_already_saved;

        if( index_already_saved == -1 )
            {
                if( System_run.show_stack_messages_buffer )
                    { 
                        Console.Log( "The index_already_saved is in -1, what means that there is no space to loop back. will return" ); 
                    }
                return 0;
            }


        byte* pointer_0 = (byte*) buffer_pointer_0;
        byte* poiter_to_data_no_saved = ( pointer_0 + ( index_already_saved + 1 ) );

        int number_of_bytes_used = ( pointer_in_buffer - index_already_saved - 1 );


        if( System_run.show_stack_messages_buffer )
            { 
                Console.Log( "pointer_in_buffer: " + pointer_in_buffer );
                Console.Log( "index_already_saved: " + index_already_saved );

                Console.Log( "number_of_bytes_used: " + number_of_bytes_used );
                Console.Log( "Will pass the data from the most in the right to the left");
            }


        for( int index = 0 ; index < number_of_bytes_used ; index++ )
            { pointer_0[ index ] = poiter_to_data_no_saved[ index ]; }

        if( System_run.show_stack_messages_buffer )
            { Console.Log( "Data passed" ); }


        pointer_in_buffer = number_of_bytes_used;

        Controllers.stack.saver.Sinalize_buffer_loop();
        
        int weight = Control_flow.Get_weight( 1_000_000_000, number_of_bytes_used );

        if( System_run.show_stack_messages_buffer )
            { Console.Log( "weight: " + weight ); }
        
        return weight;

    }


    public void Save_data( byte[] _data, int _length ){ fixed( byte* data = _data ){ Save_data_inline( data, _length ); }}
    public void Save_data( void* _data_pointer, int _length ){ Save_data_inline( _data_pointer, _length ); }


    public bool is_reconstructing_stack;
    // public void Activate__is_reconstructing_stack(){

    //     is_reconstructing_stack = true;

    // }

    public void Deactivate__is_reconstructing_stack(){


        is_reconstructing_stack = false;

    }


    #if !UNITY_EDITOR
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    #endif
    public void Save_data_inline( void* _data_pointer, int _length ){


        //mark
        // ** TEST
        // ** dont need, the stack in the reconstruct will be a new one. The file in the disk will not change iven if change here
        // ** after the reconstruct will give a Clean() and returns to nromal

        // if( is_reconstructing_stack )
        //     { 
        //         // ** in the reconstruct will call a lot of functions to change data again
        //         // ** and this functions will call stack.save again, so block here
        //         return; 
        //     } 

        if( System_run.show_stack_messages_buffer )
            { 
                Console.Log( "----- WILL SAVE DATA BUFFER ----- " ); 
                Console.Log( "is_saving_with_no_space: " + is_saving_with_no_space ); 
                Console.Log( "is_passing_data: " + is_passing_data  ); 
                Console.Log( $"Length to add: <Color=lightBlue>{ _length }</Color>" ); 
                
            }

        int final_pointer = ( pointer_in_buffer + _length );


        if( is_saving_with_no_space == 1 )
            { Save_data_with_no_space( _data_pointer, _length ); return; }

        if( final_pointer > buffer_size )
            {
                bool need_break_save_data = Handle_overflow( final_pointer, _data_pointer, _length );
                if( need_break_save_data )
                    { return; }
            }

        if( System_run.max_security  )
            { 
                if( _data_pointer == null )
                    { Console.Log ( "Came in Save_data() in the stack, but the data pointer is null " ); }

                if( _length < 0 )
                    { CONTROLLER__errors.Throw ( $"Came in Save_data() in the stack, but the length is { _length } " ); }
            }

        if( _length == 0 )
            {
                if( System_run.show_stack_messages )
                    { Console.Log( "Came in Save_data() in the stack, but the length is <Color=lightBlue>0</Color>" ); }
                return;
            }

        void* pointer = Get_pointer_buffer();

        if( System_run.show_stack_messages_buffer )
            {
                Console.Log( "pointer 0: " + Formater.Format_number( buffer_pointer_0 ) );
                Console.Log( "pointer : " + Formater.Format_number( pointer ) );
            }

        System.Buffer.MemoryCopy( _data_pointer, pointer, long.MaxValue, ( long ) ( _length ) );

        pointer_in_buffer += _length;
        return;

    }

    private const int BUFFER_MAX_SIZE = ( ( FULL_HD_IMAGE_NO_COMPRESSION * 5 ) + 1_000 );
    private const int EXPAND_BUFFER_MAX_ADD_BYTES = ( FULL_HD_IMAGE_NO_COMPRESSION + 100 );
    private const int EXPAND_BUFFER_MIN_ADD_BYTES = 100_000;

    private const int MAX_SAVING_BYTES = EXPAND_BUFFER_MAX_ADD_BYTES;

    private const int FULL_HD_IMAGE_NO_COMPRESSION = ( 8_294_400 + 100 ); // ** full hd * 4 bytes rgba + 100 margin



    public void Expand_buffer( int _number_of_bytes_lacking ){


        if( System_run.show_stack_messages_buffer )
            { 
                Console.Log( $"Will expand buffer" ); 
                Console.Log( $"Will verify if is in the right state to expand" ); 
            }

    //mark
    // ** excluir false
        if( System_run.max_security && false )
            { 
                if( Controllers.stack.state != SAFETY_STACK__state.waiting_to_save_stack )
                    { CONTROLLER__errors.Throw( $"Trie to Expand the buffer in the stack, but the state is <Color=lightBlue>{ Controllers.stack.state }</Color>" );  }

                if( _number_of_bytes_lacking == 0 )
                    { CONTROLLER__errors.Throw( $"Tried to Expand buffer but the number of bytes is <Color=lightBlue>0</Color>" ); }


                if( _number_of_bytes_lacking < 0 )
                    { CONTROLLER__errors.Throw( $"Tried to Expand buffer with a negative number: <Color=lightBlue>{ _number_of_bytes_lacking }</Color>" ); }

                int current_free_space = ( buffer_size - pointer_in_buffer );

                if( _number_of_bytes_lacking < current_free_space )
                    { CONTROLLER__errors.Throw( $"The number to add to the buffer in the stack is less than the space already available. Have: <Color=lightBlue>{ Formater.Format_number( current_free_space ) }</Color> and needs: <Color=lightBlue>{ Formater.Format_number( _number_of_bytes_lacking ) }</Color>" ); }

            }

        int minimum_to_add = _number_of_bytes_lacking;
        int bytes_to_add = minimum_to_add;

        if( minimum_to_add < 10_000 )
            { bytes_to_add += 50_000; }

        if( minimum_to_add < 20_000 )
            { bytes_to_add += 20_000; }

        if( minimum_to_add < 30_000 )
            { bytes_to_add += 20_000; }



        if( _number_of_bytes_lacking > EXPAND_BUFFER_MAX_ADD_BYTES )
            { CONTROLLER__errors.Throw( $"Tried to expand_buffer, but it asks for <Color=lightBlue>{ Formater.Format_number( _number_of_bytes_lacking ) }</Color>. Teh max is <Color=lightBlue>{ Formater.Format_number( EXPAND_BUFFER_MAX_ADD_BYTES ) }</Color>" ); }


        if( bytes_to_add < EXPAND_BUFFER_MIN_ADD_BYTES )
            {
                if( System_run.show_stack_messages_buffer )
                    { Console.Log( $"The numbers of bytes to add is too low: <Color=lightBlue>{ Formater.Format_number( bytes_to_add ) }</Color>, so will force to add the minimun <Color=lightBlue>{ Formater.Format_number( EXPAND_BUFFER_MIN_ADD_BYTES ) }</Color>" ); }
                    
                bytes_to_add = EXPAND_BUFFER_MIN_ADD_BYTES;
            }

        int new_size = ( buffer_size + bytes_to_add );

        if( new_size > BUFFER_MAX_SIZE )
            { CONTROLLER__errors.Throw( $"Tried to expand_buffer, but with the current ADD the buffer will have  <Color=lightBlue>{ Formater.Format_number( new_size ) }</Color>. Thr max is <Color=lightBlue>{ Formater.Format_number( BUFFER_MAX_SIZE ) }</Color>" ); }


        buffer_size += bytes_to_add;
        buffer_length_use_to_loop += ( 3 * ( bytes_to_add / 4 ) );

        if( System_run.show_stack_messages_buffer )
            {
                Console.Log( $"buffer_size: <Color=lightBlue>{ Formater.Format_number( buffer_size ) }</Color>" );
                Console.Log( $"buffer_length_use_to_loop: <Color=lightBlue>{ Formater.Format_number( buffer_length_use_to_loop ) }</Color>" );

                Console.Log( $"--- WILL return the heap key, to get a new one?" );
            }



        // --- NEED TO EXPAND
        if( System_run.show_stack_messages_buffer )
            { Console.Log( "Will EXPAND" );}

        
        int weight = 0;

        int weight_of_getting_new_space = 0;
        Heap_key new_key = Controllers.heap.Get_unique( new_size, ref weight_of_getting_new_space );

        if( System_run.show_stack_messages_buffer )
            { Console.Log( "Get the new key heap, weight: " + weight_of_getting_new_space ); }

        weight += weight_of_getting_new_space;

        int weight_to_pass_data = 0;
        Controllers.heap.Transfer_data_UNIQUE( 
            _key_with_data: heap_key_buffer,
            _key_destination: new_key,
            _can_lose_data_from_source: false, 
            _weight_ref: ref weight_to_pass_data
        );

        
        if( System_run.show_stack_messages_buffer )
            { Console.Log( "Transfer data, weight: " + weight_to_pass_data ); }
        
        weight += weight_to_pass_data;

        int weight_return_key = 0;
        Controllers.heap.Return_key( ref heap_key_buffer, ref weight_return_key );

        if( System_run.show_stack_messages_buffer )
            { Console.Log( "Return old key, weight: " + weight_return_key ); }
        

        weight += weight_return_key;
        
        heap_key_buffer = new_key;
        buffer_pointer_0 = new_key.Get_pointer();

        if( System_run.show_stack_messages_buffer )
            { Console.Log( "FINISH expand" ); }
        
        // ** SPACE GUARANTEE
        return;

    }

    public void Handle_lack_of_space( int _number_of_bytes_lacking ){

        // ** CAN LOOP OR EXPAND BUFFER

        int number_of_bytes_to_gain_from_loop = ( Controllers.stack.saver.pointer_buffer_already_saved + 1 );

        if( System_run.show_stack_messages_buffer )
            { Console.Log( "number_of_bytes_to_gain_from_loop: " + number_of_bytes_to_gain_from_loop ); }
        


        if( number_of_bytes_to_gain_from_loop >= _number_of_bytes_lacking )
            { 
                if( System_run.show_stack_messages_buffer )
                    { Console.Log( "System can operates after the loop, will not expand just loop" ); }

                Loop();
                
            }
            else
            {
                if( System_run.show_stack_messages_buffer )
                    { Console.Log( "System can not handle only with the loop, need to expand" ); }

                Expand_buffer( _number_of_bytes_lacking );
            }

        return;

    }


    public bool Handle_overflow(  int _final_pointer, void* _data_pointer, int _length  ){


        if( System_run.show_stack_messages_buffer )
            { Console.Log( $"Came in Handle_overflow" ); }

        bool need_break_save_data = false;
            int bytes_need = ( _final_pointer - buffer_size );
            if( System_run.show_stack_messages_buffer )
                { 
                    Console.Log( "--- NEED TO REAJUST THE BUFFER ---" );
                    Console.Log( $"There is a diference of <Color=lightBlue>{ Formater.Format_number( bytes_need ) }</Color>" );
                    Console.Log( $"The final pointer is <Color=lightBlue>{ Formater.Format_number( _final_pointer ) }</Color> but the buffer size is <Color=lightBlue>{ Formater.Format_number( buffer_size ) }</Color>" ); 
                    Console.Log( "is_passing_data: " + is_passing_data );
                }

            if( is_passing_data == 0 )
                { 
                    Handle_lack_of_space( bytes_need ); 
                }
                else
                {
                    Start_save_data_with_no_space( _length ); 
                    Save_data_with_no_space( _data_pointer, _length );
                    need_break_save_data = true;
                }

                
        return need_break_save_data;

    }




    // --- NO SPACE

    public void Clean_no_space(){

        if( key_no_space.Is_valid() )
            { Controllers.heap.Return_key( key_no_space ); }

        key_no_space = default;        
        pointer_no_space_buffer = default;
        is_saving_with_no_space = default;
        pointer_in_NO_SPACE_buffer = default;
    }

    public Heap_key key_no_space;
    public void* pointer_no_space_buffer;
    public volatile int is_saving_with_no_space;
    private int pointer_in_NO_SPACE_buffer; // ** always go up, no loop and can not be used in anywhere else


    private int Save_data_with_no_space( void* _data_pointer, int _length ){

        if( System_run.show_stack_messages_buffer )
            { 
                Console.Log( "WILL SAVE DATA WITH NO SPACE" ); 
                Console.Log( $"number of bytes: <Color=lightBlue>{ Formater.Format_number( _length ) }</Color>" );
            }


        if( System_run.max_security )
            { 
                if( Controllers.stack.state != SAFETY_STACK__state.saving_stack )
                    { CONTROLLER__errors.Throw( $"Trie to save data in the NO SPACE buffer, but the state is <Color=lightBlue>{ Controllers.stack.state }</Color>" ); }

                if( _length == 0 )
                    { CONTROLLER__errors.Throw( $"Trie to save data in the NO SPACE buffer, but the number of bytes is <Color=lightBlue>0</Color>" ); }

                if( _length < 0 )
                    { CONTROLLER__errors.Throw( $"Trie to save data in the NO SPACE buffer with a negative number: <Color=lightBlue>{ _length }</Color>" ); }

                if( _data_pointer == null )
                    { CONTROLLER__errors.Throw( $"Trie to save data in the NO SPACE buffer but the pointer of teh data was <Color=lightBlue>NULL</Color>" ); }

                if( _length > MAX_SAVING_BYTES )
                    { CONTROLLER__errors.Throw( $" The length of the data to save is too large: <Color=lightBlue>{ Formater.Format_number( _length ) }</Color> and the max is <Color=lightBlue>{ Formater.Format_number( MAX_SAVING_BYTES ) }</Color>" ); }

                if( !!!( key_no_space.Is_valid() ) )
                    { CONTROLLER__errors.Throw( $" The key is not valid" ); }

                if( pointer_no_space_buffer == null )
                    { CONTROLLER__errors.Throw( $" The pointer to the NO SPACE buffer is null" ); }


            }



        int weight = 0;

        int current_length = key_no_space.Get_length();
        int pointer_necessary = ( _length + pointer_in_NO_SPACE_buffer );

        if( pointer_necessary > current_length )
            {
                // --- NEED TO EXPAND
                if( System_run.show_stack_messages_buffer )
                    { 
                        Console.Log( "<Color=lightBlue> ----Will need to expand NO SPACE buffer</Color>" );
                        Console.Log( $"Currently have: <Color=lightBlue>{ current_length }</Color>" );
                        Console.Log( $"Need at least: <Color=lightBlue>{ pointer_necessary }</Color>" );
                    }

                int new_size = ( current_length + _length + 100_000 );

                if( System_run.max_security )
                    {
                        if( new_size > BUFFER_MAX_SIZE )
                            { CONTROLLER__errors.Throw( $"The <Color=lightBlue>BUFFER NO SPACE</Color> would need <Color=lightBlue>{ Formater.Format_number( new_size ) }</Color> bytes, but the max size is { Formater.Format_number( BUFFER_MAX_SIZE ) }" ); }
                    }

                if( System_run.show_stack_messages_buffer )
                    { Console.Log( "new_size: " + new_size ); }

                int weight_of_getting_new_space = 0;
                Heap_key new_key = Controllers.heap.Get_unique( new_size, ref weight_of_getting_new_space );

                if( System_run.show_stack_messages_buffer )
                    { Console.Log( "Get the new key heap, weight: " + weight_of_getting_new_space ); }

                weight += weight_of_getting_new_space;

                int weight_to_pass_data = 0;
                Controllers.heap.Transfer_data_UNIQUE( 
                    _key_with_data: key_no_space,
                    _key_destination: new_key,
                    _can_lose_data_from_source: false, 
                    _weight_ref: ref weight_to_pass_data
                );

                
                if( System_run.show_stack_messages_buffer )
                    { Console.Log( "Transfer data, weight: " + weight_to_pass_data ); }
                
                weight += weight_to_pass_data;

                int weight_return_key = 0;
                Controllers.heap.Return_key( ref key_no_space, ref weight_return_key );

                if( System_run.show_stack_messages_buffer )
                    { Console.Log( "Return old key, weight: " + weight_return_key ); }
                

                weight += weight_return_key;
                
                key_no_space = new_key;
                pointer_no_space_buffer = new_key.Get_pointer();

                if( System_run.show_stack_messages_buffer )
                    { Console.Log( "FINISH expand NO SPACE" ); }
                
   
            }
            else
            {
                if( System_run.show_stack_messages_buffer )
                    { Console.Log( "Don't need to expand, data will fit" ); }
            }

        // ** PASS DATA

        if( System_run.show_stack_messages_buffer )
            { Console.Log( "--- WILL PASS DATA TO NO SPACE BUFFER" ); }

        byte* pointer = ( ( ( byte* ) pointer_no_space_buffer ) + pointer_in_NO_SPACE_buffer );
        System.Buffer.MemoryCopy( _data_pointer, pointer, (long) key_no_space.Get_length(), ( long ) ( _length ) );

        
        if( System_run.show_stack_messages_buffer )
            { Console.Log( "--- end transfer data" ); }

        pointer_in_NO_SPACE_buffer += _length;

        if( System_run.show_stack_messages_buffer )
            { 
                Console.Log( "new pointer in NO SPACE buffer: " + pointer_in_NO_SPACE_buffer ); 
                Console.Log( "FINISH ");

            }


        return weight;
    }


    public void Start_save_data_with_no_space( int _bytes_need ){

        if( System_run.show_stack_messages_buffer )
            { 
                Console.Log( $"Will Srtar save data with no space" );
                Console.Log( $"I should not came here, is more a necessity" );
            }

        int length_of_key = ( 500_000 + _bytes_need );

        if( System_run.show_stack_messages_buffer )
            { Console.Log( $"Will get a key of size <Color=lightBlue>{ length_of_key }</Color>" ); }

        if( System_run.max_security )
            {
                if( key_no_space.Is_valid() )
                    { CONTROLLER__errors.Throw( "The key for the NO SPACE is valid, should not be" ); }
            }

        key_no_space = Controllers.heap.Get_unique( length_of_key );
        pointer_no_space_buffer = key_no_space.Get_pointer();

        Interlocked.Exchange( ref is_saving_with_no_space, 1 );

        return;

    }

    public void End_save_data_with_no_space(){


        if( System_run.show_stack_messages_buffer )
            { Console.Log( "Came End_save_data_with_no_space()" ); }

        if( System_run.max_security )
            {
                if( is_saving_with_no_space == 0 )
                    { CONTROLLER__errors.Throw( "is_saving_with_no_space is flagged as 0" ); }

                if( pointer_in_NO_SPACE_buffer == 0 )
                    { CONTROLLER__errors.Throw( "pointer_in_NO_SPACE_buffer is 0.If it is saving in NO SPACE it should have something" ); }

                if( !!!( key_no_space.Is_valid() ) )
                    { CONTROLLER__errors.Throw( "Tried to <Color=lightBlue>End_save_data_with_no_space</Color> but the key of the heap is not valid" ); }
                
            }



        int number_of_bytes_used_in_normal_buffer = ( pointer_in_buffer - Controllers.stack.saver.pointer_buffer_already_saved - 1  );
        int number_of_bytes_used_in_no_space_buffer = ( pointer_in_NO_SPACE_buffer );

        int total_bytes_need = ( number_of_bytes_used_in_normal_buffer + number_of_bytes_used_in_no_space_buffer );

        if( System_run.show_stack_messages_buffer )
            { 
                Console.Log(  "pointer_in_buffer: " + pointer_in_buffer );
                Console.Log(  "pointer_buffer_already_saved: " + Controllers.stack.saver.pointer_buffer_already_saved );
                Console.Log( "number_of_bytes_used_in_normal_buffer: " + number_of_bytes_used_in_normal_buffer ); 
                Console.Log( "number_of_bytes_used_in_no_space_buffer: " + number_of_bytes_used_in_no_space_buffer ); 
                Console.Log( "total_bytes_need: " + total_bytes_need ); 
                
            }

            if( total_bytes_need <= buffer_size )
                { 
                    End_no_space_pass_data_USE_NORMAL_BUFFER(); // ** 99%
                }
        else if( total_bytes_need < key_no_space.Get_length() )
                {
                    End_no_space_pass_data_USE_NO_SPACE(); // ** rare
                }
        else if( true )
                {
                    End_no_space_pass_data_USE_NEW_BUFFER(); // ** worst, only edge cases
                }
        

        // ** CHANGE DATA

        key_no_space = default;
        pointer_no_space_buffer = default;
        Interlocked.Exchange( ref pointer_in_NO_SPACE_buffer, 0 );
        Interlocked.Exchange( ref is_saving_with_no_space, 0 );


        Console.Log( "FINISH" );

        return;
        
    }

    private void End_no_space_pass_data_USE_NORMAL_BUFFER(){


        
        if( System_run.show_stack_messages_buffer )
            { 
                Console.Log( " <Color=lightBlue>--- CALLED End_no_space_pass_data_USE_NORMAL_BUFFER() ---</Color>" ); 
                Console.Log( "Will loop()" ); 
            }

        // ** pass the data already in the buffer
        Loop();

        // ** pass the rest

        if( System_run.show_stack_messages_buffer )
            { Console.Log( "Will pass the data from the NO SPACE BUFFER to the NORMAL BUFFER" ); }

        Console.Log(  "pointer_in_buffer: " + pointer_in_buffer );

        byte* pointer_data_NO_SPACE = (byte*) pointer_no_space_buffer;
        byte* pointer_start_data_in_normal_buffer = Get_pointer_buffer();

        int number_of_bytes = pointer_in_NO_SPACE_buffer;

        pointer_in_buffer += pointer_in_NO_SPACE_buffer;



        for( int index = 0 ; index < number_of_bytes ; index++ )
            { pointer_start_data_in_normal_buffer[ index ] =  pointer_data_NO_SPACE[ index ]; }


        if( System_run.show_stack_messages_buffer )
            { Console.Log( "Passed all the data, will free the heap_key" ); }
        

        int weight = 0;

        Controllers.heap.Return_key( ref key_no_space, ref weight );

        Console.Log(  "pointer_in_buffer: " + pointer_in_buffer );

        return;

    }

    private void End_no_space_pass_data_USE_NO_SPACE(){

        if( System_run.show_stack_messages_buffer )
            { 
                Console.Log( "--- <Color=lightBlue>Call End_no_space_pass_data_USE_NO_SPACE()</Color>---" ); 
                Console.Log( "Will loop()" ); 
            }

        // ** pass the rest

        // --> move data in the no_space
        // --> pass the data 

        // ** ADJUST DATA IN NO_SPACE
        if( System_run.show_stack_messages_buffer )
            { Console.Log( "Will adjust the data of the NO SPACE BUFFER" ); }



        // ** MOVE DATA IN NO SPACE

        int bytes_still_in_normal = ( pointer_in_buffer - Controllers.stack.saver.pointer_buffer_already_saved - 1 );
        byte* pointer_start_no_space = (byte*) pointer_no_space_buffer;
        int last_pointer_no_space_used = ( pointer_in_NO_SPACE_buffer - 1 );
        int off_set_no_space_last_byte = ( last_pointer_no_space_used + bytes_still_in_normal );


        if( System_run.show_stack_messages_buffer )
            {
                Console.Log( "bytes_still_in_normal: " + bytes_still_in_normal );
                Console.Log( "last_pointer_no_space_used: " + last_pointer_no_space_used );
                Console.Log( "off_set_no_space_last_byte: " + off_set_no_space_last_byte );
                Console.Log( "Length buffer: " + buffer_size );
                Console.Log( "length NO SPACE : " + key_no_space.Get_length() );
            }


        byte* pointer_data_NO_SPACE_last_byte_data = ( pointer_start_no_space + last_pointer_no_space_used );
        byte* pointer_data_NO_SPACE_last_byte_to_transfer = ( pointer_start_no_space + off_set_no_space_last_byte );

        
        int number_of_bytes_to_transfer_NO_SPACE = pointer_in_NO_SPACE_buffer;


        for( int index = 0; -index < number_of_bytes_to_transfer_NO_SPACE ; index-- )
            { pointer_data_NO_SPACE_last_byte_to_transfer[ index ] = pointer_data_NO_SPACE_last_byte_data[ index ]; }



        // ** COPY FROM NORMAL TO NO_SPACE

        if( System_run.show_stack_messages_buffer )
            { Console.Log( "Will pass the data from the NORMAL BUFFER to the NO SPACE BUFFER" ); }

        byte* pointer_start_data_in_normal_buffer = Get_pointer_buffer( Controllers.stack.saver.pointer_buffer_already_saved );

        for( int index = 0 ; index < bytes_still_in_normal ; index++ )
            { pointer_start_no_space[ index ] =  pointer_start_data_in_normal_buffer[ index ]; }

        Save_file_normal_buffer();
        Save_file_NO_SPACE_buffer();


        if( System_run.show_stack_messages_buffer )
            { Console.Log( "Passed all the data, will operate the keys" ); }
        

        int weight = 0;

        Controllers.heap.Return_key( ref heap_key_buffer, ref weight );


        // ** CHANGE DATA 

        heap_key_buffer = key_no_space;
        buffer_pointer_0 = key_no_space.Get_pointer();
        buffer_size = key_no_space.Get_length();
        pointer_in_buffer = ( off_set_no_space_last_byte + 1 );
        buffer_length_use_to_loop = ( buffer_size / 10 ) * 7;


        Controllers.stack.saver.pointer_buffer_already_saved = -1;


    
        return;


    }

    private void End_no_space_pass_data_USE_NEW_BUFFER(){

        if( System_run.show_stack_messages_buffer )
            { 
                Console.Log( "--- <Color=lightBlue>Call End_no_space_pass_data_USE_NEW_BUFFER()</Color>---" ); 
                Console.Log( "Will loop()" ); 
            }

        // ** PEGAR NOVO BUFFER

        int number_of_bytes_used_in_normal_buffer = ( pointer_in_buffer - Controllers.stack.saver.pointer_buffer_already_saved - 1  );
        int number_of_bytes_used_in_no_space_buffer = ( pointer_in_NO_SPACE_buffer );

        int total_bytes_need = ( number_of_bytes_used_in_normal_buffer + number_of_bytes_used_in_no_space_buffer );

        total_bytes_need += 100_000;

        Heap_key new_key = Controllers.heap.Get_unique( total_bytes_need );




        // ** MOVE DATA IN NO SPACE

        int bytes_still_in_normal = ( pointer_in_buffer - Controllers.stack.saver.pointer_buffer_already_saved - 1 );

        byte* pointer_start_no_space = (byte*) pointer_no_space_buffer;
        byte* pointer_start_new_space = (byte*) new_key.Get_pointer();

        int last_pointer_no_space_used = ( pointer_in_NO_SPACE_buffer - 1 );
        int off_set_no_space_last_byte = ( last_pointer_no_space_used + bytes_still_in_normal );


        if( System_run.show_stack_messages_buffer )
            {
                Console.Log( "bytes_still_in_normal: " + bytes_still_in_normal );
                Console.Log( "last_pointer_no_space_used: " + last_pointer_no_space_used );
                Console.Log( "off_set_no_space_last_byte: " + off_set_no_space_last_byte );
                Console.Log( "Length buffer: " + buffer_size );
                Console.Log( "length NO SPACE : " + key_no_space.Get_length() );
            }


        byte* pointer_data_NO_SPACE_last_byte_data = ( pointer_start_no_space + last_pointer_no_space_used );
        byte* pointer_data_NEW_SPACE_last_byte_to_transfer = ( pointer_start_new_space + off_set_no_space_last_byte );

        
        int number_of_bytes_to_transfer_NO_SPACE = pointer_in_NO_SPACE_buffer;


        for( int index = 0; -index < number_of_bytes_to_transfer_NO_SPACE ; index-- )
            { pointer_data_NEW_SPACE_last_byte_to_transfer[ index ] = pointer_data_NO_SPACE_last_byte_data[ index ]; }



        // ** COPY FROM NORMAL TO NO_SPACE

        if( System_run.show_stack_messages_buffer )
            { Console.Log( "Will pass the data from the NORMAL BUFFER to the NO SPACE BUFFER" ); }

        byte* pointer_start_data_in_normal_buffer = Get_pointer_buffer( Controllers.stack.saver.pointer_buffer_already_saved );

        for( int index = 0 ; index < bytes_still_in_normal ; index++ )
            { pointer_start_new_space[ index ] =  pointer_start_data_in_normal_buffer[ index ]; }


        Save_file_normal_buffer();
        Save_file_NO_SPACE_buffer();

        if( System_run.show_stack_messages_buffer )
            { Console.Log( "Passed all the data, will operate the keys" ); }
        


        int weight = 0;

        Controllers.heap.Return_key( ref heap_key_buffer, ref weight );
        Controllers.heap.Return_key( ref key_no_space, ref weight );


        // ** CHANGE DATA 

        heap_key_buffer = new_key;
        buffer_pointer_0 = new_key.Get_pointer();
        buffer_size = new_key.Get_length();
        pointer_in_buffer = ( off_set_no_space_last_byte + 1 );
        buffer_length_use_to_loop = ( buffer_size / 10 ) * 7;


        Controllers.stack.saver.pointer_buffer_already_saved = -1;


    }

    public void Sinalize_saved_all_files(){

        // ** don't change logic specific for the switch
        // ** it calls to save the stack file, so the is_passing_data is TRUE
        // ** the buffer and the stack_file are not 1:1 so even if the real file is lock or clean, the buffer is a second thing
        // ** if it needs space it will not loop or expand, just use the NO_SPACE
        // ** when all the files are saved will just finish
        // ** Return_pointer_to_pass_data_to_disk() is no more called in the Save_in_disk in the saver
        // ** is called in the update
        // ** so when is "saving_stack" will call as soon as possible
        // ** but when is "Waiting_save_all_files" will call with the Sinalize_saved_all_files() 

        Return_pointer_to_pass_data_to_disk();
        return;

    }


    // ** sinaliza que esta passando os dados
    // ** se acabar o buffer, da um jeito ai

    public volatile int is_passing_data;
    public int Get_pointer_to_pass_data_to_disk(){

        Interlocked.Exchange( ref is_passing_data, 1 );
        // ** pass 
        return ( pointer_in_buffer - 1 );

    }
    public void Return_pointer_to_pass_data_to_disk(){

        if( System_run.show_stack_messages_buffer )
            { Console.Log( "Came Return_pointer_to_pass_data_to_disk()" ); }

        if( is_saving_with_no_space == 1 )
            { End_save_data_with_no_space(); }

         
        
        if( System_run.show_stack_messages_buffer )
            { Console.Log( "Will change flag" ); }


        Interlocked.Exchange( ref is_passing_data, 0 );


        return;

    }


    



    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public byte* Get_pointer_buffer(){ return ((byte*)buffer_pointer_0 + pointer_in_buffer); }


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public byte* Get_pointer_buffer( int _off_set ){ return ((byte*)buffer_pointer_0 + _off_set ); }


}
