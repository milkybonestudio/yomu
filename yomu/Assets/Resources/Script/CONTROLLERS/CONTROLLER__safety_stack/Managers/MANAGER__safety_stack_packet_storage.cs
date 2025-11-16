


unsafe public struct MANAGER__safety_stack_packet_storage {

    public static MANAGER__safety_stack_packet_storage Construct( void* _message_pointer ){

        MANAGER__safety_stack_packet_storage ret = default;

            ret.origianl_message_pointer = _message_pointer;

        return ret;

    }

    public void End(){}
    public void* origianl_message_pointer;

    public void Save_alloc( int _slot_file, Packet_storage_size _size, int _slot ){

        Safety();

        STACK_MESSAGE__packet_storage_alloc* message_pointer = (STACK_MESSAGE__packet_storage_alloc*) origianl_message_pointer;

            // message_pointer->core_message. = ( int ) Safety_stack_action_type.alloc_packet;
            // message_pointer[ 1 ] = _slot_file;

            // message_pointer[ 2 ] = _file_point_to_change;
            // message_pointer[ 3 ] = _length;

        //mark mudar
        int length = 2;


        Controllers.stack.Save_data_inline( origianl_message_pointer, length );

    }






    private void Safety(){

        if( System_run.max_security && origianl_message_pointer == null )
            { CONTROLLER__errors.Throw( "Tried t use <Color=lightBlue>origianl_message_pointer</Color> but the pointer  is NULL" ); }

    }

}