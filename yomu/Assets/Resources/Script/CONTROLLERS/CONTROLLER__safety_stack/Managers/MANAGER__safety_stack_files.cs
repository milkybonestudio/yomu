

unsafe public struct MANAGER__safety_stack_files {

    public static MANAGER__safety_stack_files Construct( void* _message_pointer ){

        MANAGER__safety_stack_files ret = default;

            ret.origianl_message_pointer = _message_pointer;

        return ret;

    }


    public void End(){}


    public void* origianl_message_pointer;




    public void Save_data_change_data_in_file( int _slot_file, int _file_point_to_change, void* _data_pointer, int _length ){

        // ** create message

        if( System_run.show_stack_messages )
            {
                Console.Log( $"--- WILL SAVE DATA IN THE STACK ---" );
                Console.Log( $"slot_file: { _slot_file }" );
                Console.Log( $"length: { _length }" );
            }

        int* int_pointer = (int*) origianl_message_pointer;

        *( int_pointer + 0 ) = ( int ) Safety_stack_action_type.change_data_in_file;
        *( int_pointer + 1 ) = _slot_file;
        *( int_pointer + 2 ) = _file_point_to_change;
        *( int_pointer + 3 ) = _length;

        byte* byte_pointer = ( byte* )( int_pointer + 3 );
        byte* data_byte = ( byte* ) _data_pointer;

        for( int i = 0 ; i < _length ; i++, byte_pointer++, data_byte++ )
            { *byte_pointer = *data_byte; }

        int length_final_message = (
            _length + 
            1 + // ** type
            1 + // ** slot file
            1 + // ** point in file 
            1   // ** size of the data that changed
        );

        Controllers.stack.Save_data( origianl_message_pointer, length_final_message );

        return;

    }


    public void Save_data_change_data_in_file<T>( int _slot_file, int _file_point_to_change, T _data ) where T:unmanaged {


        //mark
        // ** esta errado 
        // ** REFAZER

        // int _length = sizeof( _data );

        // int* int_pointer = (int*)pointer_with_message;
        // int_pointer[ 0 ] = ( int ) Safety_stack_action_type.change_data_in_file;
        // int_pointer[ 1 ] = _slot_file;
        // int_pointer[ 2 ] = _file_point_to_change;
        // int_pointer[ 3 ] = _length;

        // byte* byte_pointer = ( byte* )( int_pointer + 3 );
        // byte* data_byte = ( byte* ) _data_pointer;



        // for( int i = 0 ; i < _length ; i++, byte_pointer++, data_byte++ )
        //     { *byte_pointer = *data_byte; }

        // int length_final_message = (
        //     _length + 
        //     1 + // ** type
        //     1 + // ** slot file
        //     1 + // ** point in file 
        //     1   // ** size of the data that changed
        // );

        // Save_data( pointer_with_message, length_final_message );

        return;

    }



















    private void Safety(){

        if( System_run.max_security && origianl_message_pointer == null )
            { CONTROLLER__errors.Throw( "Tried to use <Color=lightBlue>origianl_message_pointer</Color> but the pointer is NULL" ); }

    }

}