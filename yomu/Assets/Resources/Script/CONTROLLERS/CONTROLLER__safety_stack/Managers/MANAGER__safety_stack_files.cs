

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;



unsafe public struct MANAGER__safety_stack_files {

    public static MANAGER__safety_stack_files Construct( void* _message_pointer ){

        MANAGER__safety_stack_files ret = default;

            ret.origianl_message_pointer = _message_pointer;

        return ret;

    }


    public void End(){

        origianl_message_pointer = default;

    }


    public void* origianl_message_pointer;




    public static Stack_reconstruction_result_message Read_message( ref byte[][] _files, ref string[] _paths, void* _message ){


        Safety_stack_action_type type = ((Stack_message_core*)_message)->type;

        switch( type ){

            case Safety_stack_action_type.change_data_in_file: return Reconstruct_by_message__CHANGE_DATA_IN_FILE( ref _files, ref _paths, _message );
            case Safety_stack_action_type.create_new_file: return Reconstruct_by_message__CHANGE_DATA_IN_FILE( ref _files, ref _paths, _message );
            default: return Stack_reconstruction_result_message.Construct( $"Can not handle message is with type <Color=lightBlue>{ type }</Color>", Stack_reconstruction_result.fail ) ;

        }

    }


    // ** CHANGE DATA IN FILE

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Save_data_change_data_in_file<T>( int _file_id, int _file_point_to_change, T* _data ) where T:unmanaged {

        Save_data_change_data_in_file( _file_id, _file_point_to_change, _data, sizeof( T ) );

    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Save_data_change_data_in_file<T>( int _file_id, int _file_point_to_change, T _data ) where T:unmanaged {

        Save_data_change_data_in_file( _file_id, _file_point_to_change, &_data, sizeof( T ) );

    }



    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Save_data_change_data_in_file( int _file_id, int _file_point_to_change, void* _data_pointer, int _length ){


        STACK_MESSAGE__file_change* message = (STACK_MESSAGE__file_change*) origianl_message_pointer;

        message->file_id = _file_id;
        message->point_to_change = _file_point_to_change;
        message->length = _length;


        // ** I assume compiler will choose the better compile time 
        // ** data is always in the end -> can overwrite iw some 0s

            if( _length < 4 )
                {
                    *(int*)( &message->pointer_data ) = *(int*)_data_pointer;
                }
        else if( _length < 8 )
                {
                    *(long*)( &message->pointer_data ) = *(long*)_data_pointer;
                }
        else if( _length < 16 )
                {
                    *(decimal*)( &message->pointer_data ) = *(decimal*)_data_pointer;
                }   
        else if( true )
                {
                    VOID.Transfer_data( _data_pointer, &message->pointer_data, _length );
                }


        message->core_message.type = Safety_stack_action_type.change_data_in_file;
        int message_length = (
            1 * sizeof( int ) + // ** length of the message
            1 * sizeof( int ) + // ** type of the message
            _length + 
            1 * sizeof( int ) + // ** slot file
            1 * sizeof( int ) + // ** point in file 
            1 * sizeof( int )   // ** size of the data that changed
        );

        message->core_message.length = message_length;

        
        Controllers.stack.Save_message( message_length );

        return;


    }


    private static Stack_reconstruction_result_message Reconstruct_by_message__CHANGE_DATA_IN_FILE( ref byte[][] _files, ref string[] _paths, void* _message ){

        Console.Log( "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" );


        STACK_MESSAGE__file_change* message = (STACK_MESSAGE__file_change*) _message;


        if( message->file_id == 0 )
            { return Stack_reconstruction_result_message.Construct( "The message <Color=lightBlue>STACK_MESSAGE__file_change</Color>> file_id is 0", Stack_reconstruction_result.fail ); }

        if( message->file_id < 0 )
            { return Stack_reconstruction_result_message.Construct( $"The message <Color=lightBlue>STACK_MESSAGE__file_change</Color>> file_id is <Color=lightBlue>{ message->file_id }</Color>", Stack_reconstruction_result.fail ); }


        if( message->file_id >= _files.Length )
            { return Stack_reconstruction_result_message.Construct( $"The file_id in the <Color=lightBlue>STACK_MESSAGE__file_change </Color> file_id is <Color=lightBlue>{ message->file_id }</Color>", Stack_reconstruction_result.fail ); }

        byte[] file = _files[ message->file_id ];

        if( message->length == 0 )
            { return Stack_reconstruction_result_message.Construct( "The message <Color=lightBlue>STACK_MESSAGE__file_change</Color>> length is 0", Stack_reconstruction_result.fail ); }

        if( message->point_to_change == 0 )
            { return Stack_reconstruction_result_message.Construct( "The message <Color=lightBlue>STACK_MESSAGE__file_change</Color>> point_to_change is 0", Stack_reconstruction_result.fail ); }


        int final_pointer = ( message->length + message->point_to_change );

        if( final_pointer >= file.Length )
            { 
                return Stack_reconstruction_result_message.Construct( 
                    $"The file <Color=lightBlue>{ message->file_id } </Color>in the <Color=lightBlue>STACK_MESSAGE__file_change " + 
                    $"</Color>> final pointer is <Color=lightBlue>{ final_pointer }</Color> but the file have <Color=lightBlue>{ file.Length }</Color> bytes", 
                    Stack_reconstruction_result.fail
                ); 
            }

    	fixed( byte* data_pointer = file )
            { VOID.Transfer_data( &message->pointer_data, ( data_pointer + message->point_to_change ), _files.Length ); }
        
        return Stack_reconstruction_result_message.Construct( null, Stack_reconstruction_result.succes );

    }


    // CREATE NEW FILE


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Save_data_create_new_file( int _file_id, int _file_length, string _path ){


        if( System_run.max_security )
            {
                if( _path == null )
                    { CONTROLLER__errors.Throw( "Tried to create a new file in the stack with a null path" ); }

                if( _file_id == 0 )
                    { CONTROLLER__errors.Throw( "Tried to create a new file in the stack but the id of the file was 0" ); }
            }

        STACK_MESSAGE__create_new_file* message = (STACK_MESSAGE__create_new_file*) origianl_message_pointer;

        byte[] path_bytes = System.Text.Encoding.UTF8.GetBytes( _path );

        message->file_id = _file_id;
        message->length_file = _file_length;
        message->length_path = path_bytes.Length;


        fixed( byte* b_p = path_bytes )
            { VOID.Transfer_data( b_p, &message->pointer_data_path, path_bytes.Length ); }

        


        // ** I assume compiler will choose the better compile time 
        // ** data is always in the end -> can overwrite iw some 0s



        message->core_message.type = Safety_stack_action_type.create_new_file;
        int message_length = (
            1 * sizeof( int ) + // ** length of the message
            1 * sizeof( int ) + // ** type of the message
            path_bytes.Length +           // ** path
            1 * sizeof( int ) + // ** file id
            1 * sizeof( int ) + // ** length file
            1 * sizeof( int )   // ** length path
        );

        message->core_message.length = message_length;

        
        Controllers.stack.Save_message( message_length );

        return;


    }


    private static Stack_reconstruction_result_message Reconstruct_by_message__CREATE_NEW_FILE( ref byte[][] _files, ref string[] _paths, void* _message ){


        STACK_MESSAGE__create_new_file* message = (STACK_MESSAGE__create_new_file*) _message;


        int file_id = message->file_id;
        int file_length = message->length_file;
        int path_length = message->length_path;


        if( file_id == 0 )
            { return Stack_reconstruction_result_message.Construct( $"The message <Color=lightBlue>STACK_MESSAGE__create_new_file</Color> file_id is 0", Stack_reconstruction_result.fail ); }

        if( file_id < 0 )
            { return Stack_reconstruction_result_message.Construct( $"The message <Color=lightBlue>STACK_MESSAGE__create_new_file</Color> file_id is <Color=lightBlue>{ file_id }</Color>", Stack_reconstruction_result.fail ); }


        if( file_length == 0 )
            { return Stack_reconstruction_result_message.Construct( $"The message <Color=lightBlue>STACK_MESSAGE__create_new_file</Color> length is 0", Stack_reconstruction_result.fail ); }

        if( file_length < 0 )
            { return Stack_reconstruction_result_message.Construct( $"The message <Color=lightBlue>STACK_MESSAGE__create_new_file</Color> length is negative: <Color=lightBlue>{ file_length }</Color>", Stack_reconstruction_result.fail ); }


        if( path_length == 0 )
            { return Stack_reconstruction_result_message.Construct( $"The message <Color=lightBlue>STACK_MESSAGE__create_new_file</Color> point_to_change is 0", Stack_reconstruction_result.fail ); }

        if( path_length < 0 )
            { return Stack_reconstruction_result_message.Construct( $"The message <Color=lightBlue>STACK_MESSAGE__create_new_file</Color> length path is negative: <Color=lightBlue>{ path_length }</Color>", Stack_reconstruction_result.fail ); }


        // ** CREATE PATH
        byte[] path_bytes = new byte[ path_length ];

        fixed( byte* b_p = path_bytes )
            { VOID.Transfer_data( &message->pointer_data_path, b_p, path_bytes.Length ); }
        
        string path = System.Text.Encoding.UTF8.GetString( path_bytes );


        if( !!!( Directories.Is_sub_path( path, Paths_program.program_path ) ) )
            { 
                return Stack_reconstruction_result_message.Construct( 
                    $"Tried to save a file in the path <Color=lightBlue>{ path }</Color>, but don't make part of the program path " +
                    $"<Color=lightBlue>{ Paths_program.program_path }</Color>",
                    Stack_reconstruction_result.fail 
                );
            }


        if( _files.Length <= file_id )
            {
                // ** need to expand
                Array.Resize( ref _files, ( file_id + 20 ) );
                Array.Resize( ref _paths, ( file_id + 20 ) );
            }


        if( _files[ file_id ] == null )
            {
                
                if( _paths[ file_id ] != null )
                    { return Stack_reconstruction_result_message.Construct( "Path exist but the file didn't for the path: " + path, Stack_reconstruction_result.fail ); }

                // ** create file
                _files[ file_id ] = new byte[ file_length ];
                _paths[ file_id ] = path;
            }


        return Stack_reconstruction_result_message.Construct( null, Stack_reconstruction_result.succes );

    }







    private void Safety(){

        if( System_run.max_security && origianl_message_pointer == null )
            { CONTROLLER__errors.Throw( "Tried to use <Color=lightBlue>origianl_message_pointer</Color> but the pointer is NULL" ); }

    }

}