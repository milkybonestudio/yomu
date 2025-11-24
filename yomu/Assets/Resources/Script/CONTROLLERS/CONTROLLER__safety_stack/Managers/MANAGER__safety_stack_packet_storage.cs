


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

    // --- ALLOC

    public void Save_alloc( int _slot_file, Packet_storage_size _size, int _slot ){

        Safety();

        STACK_MESSAGE__packet_storage_alloc* message_pointer = (STACK_MESSAGE__packet_storage_alloc*) origianl_message_pointer;

            // message_pointer->core_message. = ( int ) Safety_stack_action_type.alloc_packet;
            // message_pointer[ 1 ] = _slot_file;

            // message_pointer[ 2 ] = _file_point_to_change;
            // message_pointer[ 3 ] = _length;

        //mark mudar
        int length = 2;


        Controllers.stack.test.Save_data_inline( origianl_message_pointer, length );

    }

    public static Stack_reconstruction_result_message Reconstruct_by_message__PACKET_SOTRAGE_ALLOC( Crash_handle_ephemeral_files _files_OS, ref Crash_cached_file[] _files, void* _message ){


        STACK_MESSAGE__packet_storage_alloc message = *(STACK_MESSAGE__packet_storage_alloc*) _message;


        if( message.file_id == 0 )
            { return Stack_reconstruction_result_message.Construct( "The message <Color=lightBlue>STACK_MESSAGE__packet_storage_alloc</Color>> file_id is 0", Stack_reconstruction_result.fail ); }

        if( message.file_id < 0 )
            { return Stack_reconstruction_result_message.Construct( $"The message <Color=lightBlue>STACK_MESSAGE__packet_storage_alloc</Color>> file_id is <Color=lightBlue>{ message.file_id }</Color>", Stack_reconstruction_result.fail ); }

        if( message.file_id >= _files.Length )
            { return Stack_reconstruction_result_message.Construct( $"The file_id in the <Color=lightBlue>STACK_MESSAGE__packet_storage_alloc </Color> file_id is <Color=lightBlue>{ message.file_id }</Color>", Stack_reconstruction_result.fail ); }

    
        if( message.slot == 0 )
            { return Stack_reconstruction_result_message.Construct( "The message <Color=lightBlue>STACK_MESSAGE__packet_storage_alloc</Color>> slot is 0", Stack_reconstruction_result.fail ); }

        if( message.slot < 0 )
            { return Stack_reconstruction_result_message.Construct( $"The message <Color=lightBlue>STACK_MESSAGE__packet_storage_alloc</Color>> slot is <Color=lightBlue>{ message.slot }</Color>", Stack_reconstruction_result.fail ); }


        if( message.size == 0 )
            { return Stack_reconstruction_result_message.Construct( "The message <Color=lightBlue>STACK_MESSAGE__packet_storage_alloc</Color>> size is 0", Stack_reconstruction_result.fail ); }

        if( message.size < 0 )
            { return Stack_reconstruction_result_message.Construct( $"The message <Color=lightBlue>STACK_MESSAGE__packet_storage_alloc</Color>> size is <Color=lightBlue>{ message.size }</Color>", Stack_reconstruction_result.fail ); }

    
        if( System_run.show_program_construction_messages_can_break_if_change_warns )
            { Console.Log( "if storage->Alloc_packet( size ) starts to need the exactly size it will break" ); }




        byte[] storage_file = _files[ message.file_id ].data;

        fixed( byte* pointer_sotorage = storage_file ){

            Packet_storage* storage = (Packet_storage*) pointer_sotorage;
            Data_file_link data = Data_file_link.Construct_fast( pointer_sotorage, message.file_id, storage_file.Length );

            //mark
            // ** ver
            Packet_storage.Start( data )->Alloc_packet( -1 );

        }



        
        return Stack_reconstruction_result_message.Construct( null, Stack_reconstruction_result.succes );



    }


    // --- DEALLOC


    // ** 


    public static Stack_reconstruction_result_message Read_message( Crash_handle_ephemeral_files _files_OS, ref Crash_cached_file[] _files, void* _message ){


        Safety_stack_action_type type = ((Stack_message_core*)_message)->type;

        switch( type ){

            case Safety_stack_action_type.alloc_packet: return Reconstruct_by_message__PACKET_SOTRAGE_ALLOC( _files_OS, ref _files, _message );
            // case Safety_stack_action_type.create_new_file: return Reconstruct_by_message__CHANGE_DATA_IN_FILE( ref _files, ref _paths, _message );
            default: return Stack_reconstruction_result_message.Construct( $"Can not handle message is with type <Color=lightBlue>{ type }</Color>", Stack_reconstruction_result.fail ) ;

        }

    }



    private void Safety(){

        if( System_run.max_security && origianl_message_pointer == null )
            { CONTROLLER__errors.Throw( "Tried t use <Color=lightBlue>origianl_message_pointer</Color> but the pointer  is NULL" ); }

    }

}