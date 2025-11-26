


unsafe public static class TOOL__handle_stack_BLOCKS {

    public static Stack_reconstruction_result_message Handle_stack_block( Crash_cached_files _files,  Crash_handle_ephemeral_files _files_OS, int _block_id, byte* pointer_start_block, int _length_block ){

        if( System_run.show_program_construction_messages )
            { Console.Log( $"CAME Handle_stack_block() FOR THE BLOCK <Color=lightBlue>{ _block_id }</Color>" ); }

        int value_jump_signature = ( 2 * sizeof( int ) );
        int index_block_file = value_jump_signature;

        int last_2_ints_security_digits = ( 2 * sizeof( int ) );
        int index_final_value = _length_block - last_2_ints_security_digits;

        while( index_block_file < index_final_value ){

            byte* pointer_to_message = ( pointer_start_block + index_block_file );

            Stack_message_core core = *(Stack_message_core*) pointer_to_message;

            if( System_run.show_program_construction_messages_messages_detail_in_block )
                {
                    Console.Log( "-------------" );
                    Console.Log( "Type: " + core.type );
                    Console.Log( "Length: " + core.length );
                    Console.Log( "_length_block: " + _length_block );
                    Console.Log( "index_block_file: " + index_block_file );

                }
                // ** all data here should be valid

                if( ( core.length == 0 ) )
                    {
                        return Stack_reconstruction_result_message.Construct( 
                            $"In the VALID block <Color=lightBlue>{ _block_id }</Color> one message don't have the length. The files for some reason were corrupted",
                            Stack_reconstruction_result.fail
                        );
                    }


                if( ( core.type == Safety_stack_action_type.not_give ) )
                    {
                        return Stack_reconstruction_result_message.Construct( 
                            $"In the VALID block <Color=lightBlue>{ _block_id }</Color> one message don't have a type. The files for some reason were corrupted",
                            Stack_reconstruction_result.fail
                        );

                    }

                if( ( index_block_file + core.length ) >= _length_block )
                    {
                        return Stack_reconstruction_result_message.Construct( 
                            $"In the block <Color=lightBlue>{ _block_id }</Color> the final pointer would pass the length of the block. The files for some reason were corrupted." +
                            $" index_block_file: <Color=lightBlue>{ index_block_file }</Color>, core.Length: <Color=lightBlue>{ core.length }</Color>,_length_block: <Color=lightBlue>{ _length_block }</Color>, final_pointer: <Color=lightBlue>{ ( index_block_file + core.length ) }</Color>",
                            Stack_reconstruction_result.fail
                        );
                    }

            Stack_reconstruction_result_message result = Handle_stack_message( _files, _files_OS,  core.type, pointer_to_message, core.length );


            //mark
            // ** TEST
            // Files.Change_range_file( Controllers )

            if( result.result == Stack_reconstruction_result.fail )
                { return result; }

            index_block_file += core.length;
            continue;
 
        }

        return Stack_reconstruction_result_message.Construct( null, Stack_reconstruction_result.succes );


    }

    private static Stack_reconstruction_result_message Handle_stack_message( Crash_cached_files _files, Crash_handle_ephemeral_files _files_OS, Safety_stack_action_type _type, void* _message, int _length ){

        if( _type < Safety_stack_action_type.FILES_END )
            { return MANAGER__safety_stack_files.Read_message( _files_OS, _files, _message ); }

        if( _type < Safety_stack_action_type.STORAGE_END )
            { return MANAGER__safety_stack_packet_storage.Read_message( _files_OS,  _files, _message ); }


        return Stack_reconstruction_result_message.Construct( $"Can not handle type <Color=lightBlue>{ _type }</Color>", Stack_reconstruction_result.fail );

    }





}