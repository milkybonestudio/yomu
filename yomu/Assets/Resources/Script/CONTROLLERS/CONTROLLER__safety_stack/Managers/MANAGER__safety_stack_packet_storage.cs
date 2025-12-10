


unsafe public struct MANAGER__safety_stack_packet_storage {

    public static MANAGER__safety_stack_packet_storage Construct( void* _message_pointer ){

        MANAGER__safety_stack_packet_storage ret = default;

            ret.origianl_message_pointer = _message_pointer;

        return ret;

    }

    public void End(){

        origianl_message_pointer = default;
        
    }

    public void* origianl_message_pointer;

    public static Stack_reconstruction_result_message Read_message( void* _message ){


        Safety_stack_action_type type = ((Stack_message_core*)_message)->type;

        switch( type ){

            case Safety_stack_action_type.alloc_packet: return Reconstruct_by_message__PACKET_SOTRAGE_ALLOC( _message );
            case Safety_stack_action_type.dealloc_packet: return Reconstruct_by_message__PACKET_SOTRAGE_DEALLOC( _message );

            case Safety_stack_action_type.create_new_storage: return Reconstruct_by_message__PACKET_SOTRAGE_CREATE_NEW( _message );
            case Safety_stack_action_type.resize_size_packet_storage: return Reconstruct_by_message__PACKET_SOTRAGE_RESIZE_SIZE( _message );

            default: return Stack_reconstruction_result_message.Construct( $"Can not handle message is with type <Color=lightBlue>{ type }</Color>", Stack_reconstruction_result.fail ) ;

        }



    }




    // --- ALLOC

    public void Save_data_alloc( int _file_id, Packet_storage_size _size, int _bytes_alloc, int _slot ){

        Safety();

        STACK_MESSAGE__packet_storage_alloc* message = (STACK_MESSAGE__packet_storage_alloc*) origianl_message_pointer;

        message->file_id = _file_id;
        message->size = _size;
        message->slot = _slot;
        message->bytes_alloc = _bytes_alloc;
        

        message->core_message.type = Safety_stack_action_type.alloc_packet;
        int message_length = (
            1 * sizeof( int ) + // ** length of the message
            1 * sizeof( int ) + // ** type of the message

            1 * sizeof( int ) + // ** file id
            1 * sizeof( int ) + // ** size
            1 * sizeof( int ) + // ** bytes_alloc
            1 * sizeof( int ) // ** slot

        );
        message->core_message.length = message_length;

        
        Controllers.stack.Save_message( message_length );


    }


    public static Stack_reconstruction_result_message Reconstruct_by_message__PACKET_SOTRAGE_ALLOC( void* _message ){


        STACK_MESSAGE__packet_storage_alloc* message = (STACK_MESSAGE__packet_storage_alloc*) _message;

        int file_id = message->file_id;
        Packet_storage_size size = message->size;
        int slot = message->slot;
        int bytes_alloc = message->bytes_alloc;
        
        
        if( file_id <= 0 )
            { return Stack_reconstruction_result_message.Construct( $"The message <Color=lightBlue>STACK_MESSAGE__packet_storage_alloc</Color> file_id is <Color=lightBlue>{ file_id }</Color>", Stack_reconstruction_result.fail ); }

        if( slot <= 0 )
            { return Stack_reconstruction_result_message.Construct( $"The message <Color=lightBlue>STACK_MESSAGE__packet_storage_alloc</Color> slot is: <Color=lightBlue>{ slot }</Color>", Stack_reconstruction_result.fail ); }

        if( size < 0 || ( (int) size >= (int) Packet_storage_size.END ) )
            { return Stack_reconstruction_result_message.Construct( $"The message <Color=lightBlue>STACK_MESSAGE__packet_storage_alloc</Color> slot is: <Color=lightBlue>{ size }</Color>", Stack_reconstruction_result.fail ); }

        if( !!!( Controllers.files.storage.Is_file_already_taken( file_id ) ) )
            { return Stack_reconstruction_result_message.Construct( $"the message  <Color=lightBlue>STACK_MESSAGE__packet_storage_alloc </Color> dont have file for id <Color=lightBlue>{ file_id }</Color>", Stack_reconstruction_result.fail ); }

        if( size != Controllers.packets.sizes.Get_required_size( bytes_alloc ) )
            { return Stack_reconstruction_result_message.Construct( $"tried to alloc but the size in the message is  <Color=lightBlue>{ size }</Color> and for { bytes_alloc } needs <Color=lightBlue>{ Controllers.packets.sizes.Get_required_size( bytes_alloc ) }</Color>", Stack_reconstruction_result.fail ); }
    

        void* pointer_storage = Controllers.files.operations.Get_file( file_id ).Get_pointer();

        Packets_storage_data* storage = (Packets_storage_data*) pointer_storage;

        if( storage->Is_slot_used( size, slot ) )
            { return Stack_reconstruction_result_message.Construct( $"tried to alloc a slot and size that wa already allocated. slot: <Color=lightBlue>{ slot }</Color> size: <Color=lightBlue>{ size }</Color>", Stack_reconstruction_result.fail ); }
        

        // ** the resize will always come before save the message of alloc -> will never resize here because IF need it already did
        Packet_key key = storage->Alloc_packet( bytes_alloc );
        
        if( key.slot != slot )
            { return Stack_reconstruction_result_message.Construct( $"tried to alloc but slot real is <Color=lightBlue>{ key.slot }</Color> and in ht emessage is <Color=lightBlue>{ slot }</Color>", Stack_reconstruction_result.fail ); }





        return Stack_reconstruction_result_message.Construct( null, Stack_reconstruction_result.succes );

    }


    // --- DEALLOC

    public void Save_data_dealloc( int _file_id, Packet_storage_size _size, int _slot ){

        Safety();

        STACK_MESSAGE__packet_storage_dealloc* message = (STACK_MESSAGE__packet_storage_dealloc*) origianl_message_pointer;

        message->file_id = _file_id;
        message->size = _size;
        message->slot = _slot;
        

        message->core_message.type = Safety_stack_action_type.dealloc_packet;
        int message_length = (
            1 * sizeof( int ) + // ** length of the message
            1 * sizeof( int ) + // ** type of the message

            1 * sizeof( int ) + // ** file id
            1 * sizeof( int ) + // ** size
            1 * sizeof( int ) // ** slot

        );
        message->core_message.length = message_length;

        
        Controllers.stack.Save_message( message_length );


    }

    public static Stack_reconstruction_result_message Reconstruct_by_message__PACKET_SOTRAGE_DEALLOC( void* _message ){


        STACK_MESSAGE__packet_storage_dealloc* message = (STACK_MESSAGE__packet_storage_dealloc*) _message;

        int file_id = message->file_id;
        Packet_storage_size size = message->size;
        int slot = message->slot;
        
        
        if( file_id <= 0 )
            { return Stack_reconstruction_result_message.Construct( $"The message <Color=lightBlue>STACK_MESSAGE__packet_storage_dealloc</Color> file_id is <Color=lightBlue>{ file_id }</Color>", Stack_reconstruction_result.fail ); }

        if( slot <= 0 )
            { return Stack_reconstruction_result_message.Construct( $"The message <Color=lightBlue>STACK_MESSAGE__packet_storage_dealloc</Color> slot is: <Color=lightBlue>{ slot }</Color>", Stack_reconstruction_result.fail ); }

        if( size < 0 || ( (int) size >= (int) Packet_storage_size.END ) )
            { return Stack_reconstruction_result_message.Construct( $"The message <Color=lightBlue>STACK_MESSAGE__packet_storage_dealloc</Color> slot is: <Color=lightBlue>{ size }</Color>", Stack_reconstruction_result.fail ); }

    
        if(  !!!( Controllers.files.storage.Is_file_already_taken( file_id ) ) )
            { return Stack_reconstruction_result_message.Construct( $"the message  <Color=lightBlue>STACK_MESSAGE__packet_storage_dealloc </Color> dont have file for id <Color=lightBlue>{ file_id }</Color>", Stack_reconstruction_result.fail ); }
    


        Packets_storage_data* storage = (Packets_storage_data*) Controllers.files.operations.Get_file( file_id ).Get_pointer();

        if( storage->Is_slot_used( size, slot ) )
            { CONTROLLER__errors.Throw( $"tried to alloc a slot and size that wa already allocated. slot: <Color=lightBlue>{ slot }</Color> size: <Color=lightBlue>{ size }</Color>" ); }

        Packet_key key = Packet_key.Construct( size, slot, Controllers.packets.sizes.Get_size_in_bytes( size ) );
        
        storage->Dealloc_packet( key );


        return Stack_reconstruction_result_message.Construct( null, Stack_reconstruction_result.succes );

    }






















    // --- EXPAND SIZE

    
    public void Save_data_resize_size( int _file_id, Packet_storage_size _size, int _new_size_length ){

        Safety();

        STACK_MESSAGE__packet_storage_resize_size* message = (STACK_MESSAGE__packet_storage_resize_size*) origianl_message_pointer;

        message->file_id = _file_id;
        message->size = _size;
        message->new_size_length = _new_size_length;
    
        message->core_message.type = Safety_stack_action_type.resize_size_packet_storage;
        int message_length = (
            1 * sizeof( int ) + // ** length of the message
            1 * sizeof( int ) + // ** type of the message

            1 * sizeof( int ) + // ** file id
            1 * sizeof( int ) + // ** size
            1 * sizeof( int )   // ** new size length

        );
        message->core_message.length = message_length;

        
        Controllers.stack.Save_message( message_length );


    }

    public static Stack_reconstruction_result_message Reconstruct_by_message__PACKET_SOTRAGE_RESIZE_SIZE( void* _message ){


        STACK_MESSAGE__packet_storage_resize_size* message = (STACK_MESSAGE__packet_storage_resize_size*) _message;

        int file_id = message->file_id;
        Packet_storage_size size = message->size;
        int new_size_length = message->new_size_length;
        
        
        if( file_id <= 0 )
            { return Stack_reconstruction_result_message.Construct( $"The message <Color=lightBlue>STACK_MESSAGE__packet_storage_resize_size</Color> file_id is <Color=lightBlue>{ file_id }</Color>", Stack_reconstruction_result.fail ); }

        if( new_size_length <= 0 )
            { return Stack_reconstruction_result_message.Construct( $"The message <Color=lightBlue>STACK_MESSAGE__packet_storage_resize_size</Color> new_size_length is: <Color=lightBlue>{ new_size_length }</Color>", Stack_reconstruction_result.fail ); }

        if( size < 0 || ( (int) size >= (int) Packet_storage_size.END ) )
            { return Stack_reconstruction_result_message.Construct( $"The message <Color=lightBlue>STACK_MESSAGE__packet_storage_resize_size</Color> slot is: <Color=lightBlue>{ size }</Color>", Stack_reconstruction_result.fail ); }

        if(  !!!( Controllers.files.storage.Is_file_already_taken( file_id ) ) )
            { return Stack_reconstruction_result_message.Construct( $"the message  <Color=lightBlue>STACK_MESSAGE__packet_storage_resize_size </Color> dont have file for id <Color=lightBlue>{ file_id }</Color>", Stack_reconstruction_result.fail ); }
    

        Packets_storage_data* storage = (Packets_storage_data*) Controllers.files.operations.Get_file( file_id ).Get_pointer();
        int real_size = storage->Force_expand( size );

        if( real_size != new_size_length )
            { return Stack_reconstruction_result_message.Construct( $"the message <Color=lightBlue>STACK_MESSAGE__packet_storage_resize_size </Color> but the real_size is <Color=lightBlue>{ real_size }</Color> and in the message is <Color=lightBlue>{ new_size_length }</Color>", Stack_reconstruction_result.fail ); }
            


        return Stack_reconstruction_result_message.Construct( null, Stack_reconstruction_result.succes );

    }
    





    // --- CREATE NEW

    public void Save_data_create_storage( int _file_id, Packet_storage_start_data _start_data ){

        Safety();

        STACK_MESSAGE__packet_storage_create_new* message = (STACK_MESSAGE__packet_storage_create_new*) origianl_message_pointer;

        message->file_id = _file_id;

        Packet_storage_start_data_PER_SIZE* data_pointer = (Packet_storage_start_data_PER_SIZE*)&( message->data );

        for( int index = 0 ; index < (int) Packet_storage_size.END ; index++ )
            { data_pointer[ index ] = _start_data.sizes_settings[ index ]; }

        

        message->core_message.type = Safety_stack_action_type.create_new_storage;
        int message_length = (
            1 * sizeof( int ) + // ** length of the message
            1 * sizeof( int ) + // ** type of the message

            1 * sizeof( int ) + // ** file id
            1 * sizeof( int ) + // ** length start
            ( (int) Packet_storage_size.END ) * Packet_storage_start_data_PER_SIZE.BYTES_PER_SIZE // ** data
        );

        message->core_message.length = message_length;

        
        Controllers.stack.Save_message( message_length );


    }


    public static Stack_reconstruction_result_message Reconstruct_by_message__PACKET_SOTRAGE_CREATE_NEW( void* _message ){


        STACK_MESSAGE__packet_storage_create_new* message = (STACK_MESSAGE__packet_storage_create_new*) _message;

        int file_id = message->file_id;
        int start_file_length = message->file_start_length;
        
        if( file_id <= 0 )
            { return Stack_reconstruction_result_message.Construct( $"The message <Color=lightBlue>STACK_MESSAGE__packet_storage_create_new</Color> file_id is <Color=lightBlue>{ file_id }</Color>", Stack_reconstruction_result.fail ); }

        if( start_file_length <= 0 )
            { return Stack_reconstruction_result_message.Construct( $"The message <Color=lightBlue>STACK_MESSAGE__packet_storage_create_new</Color> length is negative: <Color=lightBlue>{ start_file_length }</Color>", Stack_reconstruction_result.fail ); }
    
        if(  !!!( Controllers.files.storage.Is_file_already_taken( file_id ) ) )
            { return Stack_reconstruction_result_message.Construct( $"the message  <Color=lightBlue>STACK_MESSAGE__packet_storage_create_new </Color> dont have file for id <Color=lightBlue>{ file_id }</Color>", Stack_reconstruction_result.fail ); }
    


        Data_file_link data_link = Controllers.files.operations.Get_file( file_id );

        Packet_storage_start_data new_start_data = new();

        new_start_data.file_start_length = start_file_length;
        
        Packet_storage_start_data_PER_SIZE* data_pointer = (Packet_storage_start_data_PER_SIZE*)&(message->data);

        for( int index = 0 ; index < (int) Packet_storage_size.END ; index++ )
            {  new_start_data.sizes_settings[ index ] = data_pointer[ index ]; }

        Controllers.packets.creation.Apply_create_data( data_link.Get_pointer(), data_link.Get_length(), new_start_data );

        
        return Stack_reconstruction_result_message.Construct( null, Stack_reconstruction_result.succes );



    }




    private void Safety(){

        if( System_run.max_security && origianl_message_pointer == null )
            { CONTROLLER__errors.Throw( "Tried t use <Color=lightBlue>origianl_message_pointer</Color> but the pointer  is NULL" ); }

    }

}