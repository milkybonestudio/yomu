using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst;


[StructLayout(LayoutKind.Sequential)]
unsafe public struct Packet_storage_info {


    
    public int size_in_bytes;

    public int pointer_to_section;

    public int space_needed_ACTIVE_POINTERS;
    public int space_needed_FLAGS;
    public int space_needed_DATA;
        public int total_space_needed;



    public int number_of_free_spaces;
    public int current_pointer_of_free_space;

    public int number_of_slots_available;



    public int pointer_to_FREE_SPACES;
    public int pointer_to_FLAGS;
    public int pointer_to_DATA;

    public int number_slots;
    public int number_slots_to_need_up;
    public int number_slots_add_per_expansion;



    public void* Get_pointer( Packets_storage_data* _storage_pointer, int _slot ){

        if( _slot >= number_slots )
            { CONTROLLER__errors.Throw( $"Tried to get the slot <Color=lightBlue>{ _slot }</Color> in the size <Color=lightBlue>{ size_in_bytes }</Color> but there are <Color=lightBlue>{ number_slots }</Color> slots" ); }

        byte* real_pointer_to_FLAGS =  ( ((byte*)_storage_pointer) + pointer_to_FLAGS );
        bool is_allocated =  ( real_pointer_to_FLAGS[ _slot ] == 1 );

        if( !!!( is_allocated ) )
            { CONTROLLER__errors.Throw( $"The slot <Color=lightBlue>{ _slot }</Color> in the size <Color=lightBlue>{ size_in_bytes }</Color> is not allocated, but tried to <Color=lightBlue>get the pointer to the data</Color>" ); }

        byte* start_data_pointer =  ( (byte*)_storage_pointer + pointer_to_DATA );
        byte* pointer_to_slot_data = start_data_pointer + ( _slot * size_in_bytes );

        return (void*) pointer_to_slot_data;

    }
    

    public bool Is_slot_used( Packets_storage_data* _storage_pointer, int _slot ){

        if( _slot > number_slots )
            { return false; }


        if( System_run.max_security && _slot < 0 )
            { CONTROLLER__errors.Throw( $"Triued to see if the slot <Color=lightBlue>{ _slot }</Color> was used in the size <Color=lightBlue>{ size_in_bytes }</Color>" ); }


        return ((((byte*)_storage_pointer) + pointer_to_FLAGS )[ _slot ] == 1 );

    }



    public void Dealloc( Packets_storage_data* _storage_pointer, int _slot ){

        Controllers.stack.Need_to_add_stack_function();
    
        if( number_slots <= _slot )
            { CONTROLLER__errors.Throw( $"tried to Deallocate a packet key in the slot <Color=lightBlue>{ _slot }</Color> and the size <Color=lightBlue>{ size_in_bytes }</Color>. But there are <Color=lightBlue>{ number_slots }</Color> slots" ); }


        byte* real_pointer_to_FLAGS =  ( ((byte*)_storage_pointer) + pointer_to_FLAGS );
        bool is_allocated =  ( real_pointer_to_FLAGS[ _slot ] == 1 );

        if( !!!( is_allocated ) )
            { CONTROLLER__errors.Throw( $"The slot <Color=lightBlue>{ _slot }</Color> in the size <Color=lightBlue>{ size_in_bytes }</Color> is not allocated, but tried to <Color=lightBlue>DEallocate</Color>" ); }

        if( System_run.packet_storage_show_messages )
            { Console.Log( $"Vai liberar no tamanho <Color=lightBlue>{ size_in_bytes }</Color> no slot <Color=lightBlue>{ _slot }</Color>" ); }

        
        // ** data will be there?
        real_pointer_to_FLAGS[ _slot ] = 0;

        number_of_slots_available += 1;
        
        return;

    }

    public int Get_space( Packets_storage_data* _storage_pointer ){

        Controllers.stack.Need_to_add_stack_function();

        if( _storage_pointer == null )
            { CONTROLLER__errors.Throw( "storage_pointer was null" ); }

        if( number_of_slots_available == 0 )
            { CONTROLLER__errors.Throw( "Didn't have a free space" ); }
        

        int* real_pointer_to_FREE_SPACES = (int*)( ((byte*)_storage_pointer) + pointer_to_FREE_SPACES );

        

        if( current_pointer_of_free_space == number_of_free_spaces )
            { Get_more_free_spaces( _storage_pointer, real_pointer_to_FREE_SPACES ); }
        

        int slot = real_pointer_to_FREE_SPACES[ current_pointer_of_free_space ];

        current_pointer_of_free_space++;
        number_of_slots_available--;

        if( System_run.packet_storage_show_messages )
            {
                Console.Log( "current_pointer_of_free_space: " + Formater.Format_number( current_pointer_of_free_space ) );
                Console.Log( "number_of_free_spaces: " + Formater.Format_number( number_of_free_spaces ) );
                Console.Log( "number_of_slots_available: " + Formater.Format_number( number_of_slots_available ) );
            }


        if( System_run.packet_storage_show_messages )
            {
                Console.Log( "slot: " + slot );
                Console.Log( "current_pointer_of_free_space: " + current_pointer_of_free_space );
            }


        *( ((byte*)_storage_pointer) + pointer_to_FLAGS + slot ) = 1; // ** change flag 

        return slot;
        
    }



    public void Print_flags( Packets_storage_data* _storage_pointer ){

        byte* flag_pointer = ( ((byte*)_storage_pointer) + pointer_to_FLAGS );

        Console.Log( "<Color=lightBlue>----------------FLAGS-------------------</Color>" );

        for( int flag_index = 0 ; flag_index < number_slots ; flag_index++ ){

            if( flag_pointer[ flag_index ] == 1 )
                { Console.Log( $"slot  { flag_index } is already alloc" ); }
                else
                { Console.Log( $"slot  { flag_index } is free" ); }

        }

    }

    public void Print_actives( Packets_storage_data* _storage_pointer ){


        Console.Log( $"<Color=lightBlue>----------------ACTIVES FOR { size_in_bytes } BYTES-------------------</Color>" );

        int* free_slot_pointer = (int*)( ((byte*)_storage_pointer) + pointer_to_FREE_SPACES );
        byte* flag_pointer = ( ((byte*)_storage_pointer) + pointer_to_FLAGS );
        Console.Log( Formater.Format_number( flag_pointer ) );
        Console.Update();

        for( int slot_index = 0 ; slot_index < number_of_free_spaces ; slot_index++ ){

            int slot = free_slot_pointer[ slot_index ];
            

            if( flag_pointer[ slot ] == 1 )
                { Console.Log( $"slot  { slot } is already alloc" ); }
                else
                { Console.Log( $"slot  { slot } is free" ); }

        }

        Console.Log( "<Color=lightBlue>-----------------------------------</Color>" );

    }

    public void Print_data( Packets_storage_data* _storage_pointer ){


        Console.Log( $"<Color=lightBlue>----------------Data FOR { size_in_bytes } BYTES-------------------</Color>" );

        Console.Log( $" size_in_bytes: " +  size_in_bytes );

        Console.Log( $" pointer_to_section: " +  pointer_to_section );

        Console.Log( $" space_needed_ACTIVE_POINTERS: " +  space_needed_ACTIVE_POINTERS );
        Console.Log( $" space_needed_FLAGS: " +  space_needed_FLAGS );
        Console.Log( $" space_needed_DATA: " +  space_needed_DATA );
            Console.Log( $" total_space_needed: " +  total_space_needed );



        Console.Log( $" number_of_free_spaces: " +  number_of_free_spaces );
        Console.Log( $" current_pointer_of_free_space: " +  current_pointer_of_free_space );

        Console.Log( $" number_of_slots_available: " +  number_of_slots_available );



        Console.Log( $" pointer_to_FREE_SPACES: " +  pointer_to_FREE_SPACES );
        Console.Log( $" pointer_to_FLAGS: " +  pointer_to_FLAGS );
        Console.Log( $" pointer_to_DATA: " +  pointer_to_DATA );

        Console.Log( $" number_slots: " +  number_slots );
        Console.Log( $" number_slots_to_need_up: " +  number_slots_to_need_up );
        Console.Log( $" number_slots_add_per_expansion: " +  number_slots_add_per_expansion );


        Console.Log( "<Color=lightBlue>-----------------------------------</Color>" );

    }





    private void Get_more_free_spaces( void* _storage_pointer, int* real_pointer_to_FREE_SPACES ){

        if( System_run.packet_storage_show_messages )
            { Console.Log( $"CALLED <Color=lightBlue>Get_more_free_spaces </Color>" ); }
        
    
        byte* flag_pointer = ( ((byte*)_storage_pointer) + pointer_to_FLAGS );

        
        //mark
        // ** tem que fazer quando da o lock
        // ** WILL SWITCH THE 0 TO 1 IN THE FLAGS
        // for( int index_free_space = 0 ; index_free_space < number_of_free_spaces ; index_free_space++ ){

        //     int slot_id = real_pointer_to_FREE_SPACES[ index_free_space ];
        //     flag_pointer[ slot_id ] = 1; // ** SINALIZE IT WAS USED

        // }
        
        int current_free_space = 0;
        int index_starting_from_end = ( number_of_free_spaces - 1 );

        // Console.Log( "number_of_free_spaces: " + number_of_free_spaces );

        for( int flag_index = 0 ; flag_index < number_slots ; flag_index++ ){

            if( flag_pointer[ flag_index ] == 1 )
                { 
                    if( System_run.packet_storage_show_messages )
                        { Console.Log( $"slot  { flag_index } is already alloc" ); }
                    continue; 
                }

            // FREE

            if( current_free_space == number_of_free_spaces )
                { break; } // get all it needs

            // index_starting_from_end = ( number_of_free_spaces - current_free_space - 1 );

            real_pointer_to_FREE_SPACES[ ( index_starting_from_end - current_free_space ) ] = flag_index;
            // Console.Log( $"will put the value { flag_index } in the index { index_starting_from_end - current_free_space }" );

            current_free_space++;

        }


        if( System_run.packet_storage_show_messages )
            {
                for( int i = 0 ; i < number_of_free_spaces ; i++ )
                    { Console.Log( "index " + i + " value: " + real_pointer_to_FREE_SPACES[ i ] ); }
            }





        if( current_free_space == 0 )
            { CONTROLLER__errors.Throw( "There are no slots available" ); }

        if( System_run.packet_storage_show_messages )
            { Console.Log( "index_starting_from_end: " + (index_starting_from_end - current_free_space + 1 )  ); }
        

        current_pointer_of_free_space = ( index_starting_from_end - ( current_free_space ) + 1 );

        if( System_run.packet_storage_show_messages )
            { Console.Log( $"current_pointer_of_free_space: <Color=lightBlue>{ current_pointer_of_free_space }</Color>" ); }
        

    }


    public bool Can_to_expand(){

        if( System_run.packet_storage_show_messages )
            { Console.Log( "need: " + (number_of_slots_available < number_slots_to_need_up) ); }
        
        return number_of_slots_available < number_slots_to_need_up;

    }

    public bool Need_to_force_expand(){

        if( System_run.packet_storage_show_messages )
            {
                Console.Log( "size: " + size_in_bytes );
                Console.Log( "number_of_slots_available: " + Formater.Format_number( number_of_slots_available ) );
                Console.Log( "number_slots_to_need_up: " + Formater.Format_number( number_slots_to_need_up ) );
                Console.Log( "Need: " +  (number_of_slots_available == 0) );
            }

        return number_of_slots_available == 0;

    }



    public int Get_bytes_to_expand(){



        int _number_slots = ( number_slots + number_slots_add_per_expansion );

        if( System_run.packet_storage_show_messages )
            { Console.Log( "WILL ADD " + number_slots_add_per_expansion + "SLOTS" ); }

        
    
        int new_space_needed_ACTIVE_POINTERS = ( Get_number_active_flags_slots( _number_slots ) * sizeof( int ) );
        int new_space_needed_FLAGS = _number_slots;
        int new_space_needed_DATA = ( _number_slots * size_in_bytes );

            int new_total_space_needed = ( new_space_needed_ACTIVE_POINTERS + new_space_needed_FLAGS + new_space_needed_DATA );

        int current_space = total_space_needed;

        int diff = ( new_total_space_needed - current_space );

        return diff;
        

    }


    public int Reajust_data( Packets_storage_data* storage_pointer ){

        // ** Will assume the Packet_storage already moved the bigger sizes in the file

        int new_number_slots = ( number_slots + number_slots_add_per_expansion );
        int old_number_slots = number_slots;
    
        int new_space_needed_ACTIVE_POINTERS = ( Get_number_active_flags_slots( new_number_slots ) * sizeof( int ) );
        int new_space_needed_FLAGS = new_number_slots;
        int new_space_needed_DATA = ( new_number_slots * size_in_bytes );


        int old_space_needed_ACTIVE_POINTERS = space_needed_ACTIVE_POINTERS;
        int old_space_needed_FLAGS = space_needed_FLAGS;
        int old_space_needed_DATA = space_needed_DATA;

            int new_total_space_needed = ( new_space_needed_ACTIVE_POINTERS + new_space_needed_FLAGS + new_space_needed_DATA );
            int old_total_space_needed = ( space_needed_ACTIVE_POINTERS + space_needed_FLAGS + space_needed_DATA );

        int diff_space_needed_ACTIVE_POINTERS = ( new_space_needed_ACTIVE_POINTERS - space_needed_ACTIVE_POINTERS) ;
        int diff_space_needed_FLAGS = ( new_space_needed_FLAGS - space_needed_FLAGS) ;
        int diff_space_needed_DATA = ( new_space_needed_DATA - space_needed_DATA) ;


        // ** the loop will be from the end to the start
        byte* new_data_pointer_final = ( (byte*) storage_pointer ) + pointer_to_section + new_total_space_needed - 1;
        byte* old_data_pointer_final = ( (byte*) storage_pointer ) + pointer_to_section + old_total_space_needed - 1;


        // ** TRANSFER DATA

            // ** ALL ZEROS->JUST JUMP
            new_data_pointer_final -= diff_space_needed_DATA;
            
            for( int data_transfer_index = 0 ; data_transfer_index < old_space_needed_DATA ; data_transfer_index++ ){

                *new_data_pointer_final = *old_data_pointer_final;
                new_data_pointer_final--;
                old_data_pointer_final--;

            }

        if( System_run.packet_storage_show_messages ){ Console.Log( "-------------- ACABOU DATA ----------------" ); }
        
        

        // ** FLAGS

            // ** ALL ZEROS->JUST JUMP
            new_data_pointer_final -= diff_space_needed_FLAGS;

            
            for( int flags_transfer_index = 0 ; flags_transfer_index < old_space_needed_FLAGS ; flags_transfer_index++ ){

                // Console.Log( $"Vai adicionar no index { flags_transfer_index } o valor { *old_data_pointer_final } " );
                *new_data_pointer_final = *old_data_pointer_final;
                new_data_pointer_final--;
                old_data_pointer_final--;

            }

        if( System_run.packet_storage_show_messages ){ Console.Log( "-------------- ACABOU FLAGS ----------------" ); }
        
        // ** FREE SPACES

            // ** TRANSFER ALL STILL FREE
            // ** if it comes here will probably not have anything 
            // ** but can have a method Force_expand() or something
            int number_of_free_spaces_actually_free_IN_BYTES = ( number_of_free_spaces - current_pointer_of_free_space ) * sizeof( int ) ;
            for( int free_spaces_transfer_index = 0 ; free_spaces_transfer_index < number_of_free_spaces_actually_free_IN_BYTES ; free_spaces_transfer_index++ ){

                *new_data_pointer_final = *old_data_pointer_final;
                // Console.Log( $"Vai adicionar no pointer { (long)new_data_pointer_final } o valor { *old_data_pointer_final } " );
                new_data_pointer_final--;
                old_data_pointer_final--;

            }
        
            // ** MAKE THE REST ALSO AVAILABLE 

            int* new_data_pointer_final_int = (int*) ( new_data_pointer_final - ( sizeof(int) - 1 ));

            int number_of_new_active_slots = ( diff_space_needed_ACTIVE_POINTERS / sizeof( int ) );

            int empty_slot_space = ( number_of_new_active_slots + current_pointer_of_free_space );
            int slots_guarantee_to_exist = ( new_number_slots - old_number_slots );
            int free_slot_added_index = 0;

            if( System_run.packet_storage_show_messages )
                {
                    Console.Log( $"empty_slot_space: <Color=lightBlue>{ empty_slot_space }</Color>" );
                    Console.Log( $"slots_guarantee_to_exist: <Color=lightBlue>{ slots_guarantee_to_exist }</Color>" );
                }
        

            for( free_slot_added_index = 0 ; ( free_slot_added_index < empty_slot_space ) && ( free_slot_added_index < slots_guarantee_to_exist ); free_slot_added_index++ ){
                
                int free_index_like_yeah = ( old_number_slots + free_slot_added_index );
                *new_data_pointer_final_int = free_index_like_yeah;
                
                if( System_run.packet_storage_show_messages )
                    { Console.Log( $"Vai adicionar no index { free_slot_added_index } o valor { free_index_like_yeah } " ); }
                

                new_data_pointer_final_int--;

            }


        if( System_run.packet_storage_show_messages ){ Console.Log( "-------------- ACABOU FREE SPACES ----------------" ); }
        

        number_slots = new_number_slots;
        number_of_slots_available += number_slots_add_per_expansion;
        current_pointer_of_free_space = ( empty_slot_space - free_slot_added_index );

        number_of_free_spaces = Get_number_active_flags_slots( new_number_slots );

        space_needed_ACTIVE_POINTERS = new_space_needed_ACTIVE_POINTERS;
        space_needed_FLAGS = new_space_needed_FLAGS;
        space_needed_DATA = new_space_needed_DATA;

            total_space_needed = new_total_space_needed;

        pointer_to_section += 0; // ** dont change

            pointer_to_FREE_SPACES = pointer_to_section;
            pointer_to_FLAGS = ( pointer_to_FREE_SPACES + space_needed_ACTIVE_POINTERS );
            pointer_to_DATA = ( pointer_to_FLAGS + space_needed_FLAGS );

        // ** print free slots

        if( System_run.packet_storage_show_messages )
            {
                int* free_slots_print = (int*)((byte*) storage_pointer + pointer_to_FREE_SPACES );

                int k = 0;
                for( k = 0 ; k < number_of_free_spaces ; k++ )
                    { Console.Log( $"free slot index <Color=lightBlue>{ k }</Color> have slot: <Color=lightBlue>{ free_slots_print[ k ] }</Color>" ); }

                Console.Log( $"current_pointer_of_free_space after reajust: <Color=lightBlue>{ current_pointer_of_free_space }</Color>" );
            }

        return new_total_space_needed;

    }

    

    // ** NEVER THE ONE ADJUSTED
    public void Move_data( Packets_storage_data* storage_pointer, int how_many_bytes_it_needs_to_expand ){

        // Console.Log( "Will move the info size : " + size_in_bytes );

        // ** MOVE ALL BYTES
        int current_total_space = total_space_needed;

        byte* pointer_to_final = ( ( ( byte* ) storage_pointer ) + pointer_to_section + current_total_space );
        byte* pointer_to_alocate_data = ( pointer_to_final + how_many_bytes_it_needs_to_expand );

        for( int byte_to_info_data = 0 ; byte_to_info_data < current_total_space ; byte_to_info_data++ )
            { pointer_to_alocate_data[ ( 0 - byte_to_info_data ) ] = pointer_to_final[ ( 0 - byte_to_info_data ) ]; }

        pointer_to_section += how_many_bytes_it_needs_to_expand;

            pointer_to_FREE_SPACES += how_many_bytes_it_needs_to_expand;
            pointer_to_FLAGS += how_many_bytes_it_needs_to_expand;
            pointer_to_DATA += how_many_bytes_it_needs_to_expand;



    }



    // ** CREATION

    public void Applay_start_data( Packet_storage_start_data_PER_SIZE _data, void* _packed_storage_to_put_free_spaces, int* _current_pointer, int _size_in_bytes ){

        size_in_bytes = _size_in_bytes;
        number_slots_to_need_up = _data.slots_to_need_up;
        number_slots_add_per_expansion = _data.slots_add_per_expansion;
        

        number_slots = _data.slots;
        current_pointer_of_free_space = 0;
        number_of_slots_available = number_slots;


        // ** GET ALL THE DATA 

        
        number_of_free_spaces = Get_number_active_flags_slots( number_slots );

        space_needed_ACTIVE_POINTERS = ( number_of_free_spaces * sizeof( int ) );
        space_needed_FLAGS = number_slots;
        space_needed_DATA = ( number_slots * size_in_bytes );

            total_space_needed = ( space_needed_ACTIVE_POINTERS + space_needed_FLAGS + space_needed_DATA );


        pointer_to_section = *_current_pointer;
        // Console.Log( "pointer_to_section: " + pointer_to_section );

            pointer_to_FREE_SPACES = pointer_to_section;
            pointer_to_FLAGS = ( pointer_to_FREE_SPACES + space_needed_ACTIVE_POINTERS );
            pointer_to_DATA = ( pointer_to_FLAGS + space_needed_FLAGS );

        // ** advance the pointer
        *_current_pointer = ( pointer_to_DATA + space_needed_DATA );


        // ** copy the ids

        int* start_pointer_free_spaces = (int*)( (byte*)_packed_storage_to_put_free_spaces + pointer_to_FREE_SPACES );

        for( int index_of_free_space = 0 ; index_of_free_space < number_of_free_spaces ; index_of_free_space++ )
            { start_pointer_free_spaces[ index_of_free_space ] = index_of_free_space; }

        return;

    }


    public int Get_number_active_flags_slots( int _slots ){

        if( _slots > 5 )
            { return ( ( 2 * _slots ) / 10 ); }

        if( _slots < 0 )
            { return 1; }

        return 0;

    }

    


}

