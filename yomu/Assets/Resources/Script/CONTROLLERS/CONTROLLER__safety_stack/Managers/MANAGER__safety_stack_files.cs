

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Collections.LowLevel.Unsafe;



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




    public static Stack_reconstruction_result_message Read_message( Crash_handle_ephemeral_files _files_OS, ref Crash_file[] _files, void* _message ){



        Safety_stack_action_type type = ((Stack_message_core*)_message)->type;

        if( System_run.show_program_construction_messages ) 
            { Console.Log( "type: " + type ); }

        

        switch( type ){

            // ** OK
            case Safety_stack_action_type.change_data_in_file: return Reconstruct_by_message__CHANGE_DATA_IN_FILE( _files_OS, ref _files, _message ); 
            // ** OK
            case Safety_stack_action_type.got_file_from_disk: return Reconstruct_by_message__GOT_FILE_FROM_DISK( _files_OS, ref _files, _message );

            
            case Safety_stack_action_type.create_new_file: return Reconstruct_by_message__CREATE_NEW_FILE( _files_OS, ref _files, _message );
            case Safety_stack_action_type.change_length_file: return Reconstruct_by_message__CHANGE_LENGTH_FILE( _files_OS, ref _files, _message );

            default: return Stack_reconstruction_result_message.Construct( $"Can not handle message is with type <Color=lightBlue>{ type }</Color>", Stack_reconstruction_result.fail ) ;

        }

    }


    // ** CHANGE DATA IN FILE

    #if !UNITY_EDITOR
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    #endif
    public void Save_data_change_data_in_file<T>( int _file_id, int _file_point_to_change, T* _data ) where T:unmanaged {

        Save_data_change_data_in_file( _file_id, _file_point_to_change, _data, sizeof( T ) );

    }

    #if !UNITY_EDITOR
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    #endif
    public void Save_data_change_data_in_file<T>( int _file_id, int _file_point_to_change, T _data ) where T:unmanaged {

        Save_data_change_data_in_file( _file_id, _file_point_to_change, &_data, sizeof( T ) );

    }



    #if !UNITY_EDITOR
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    #endif
    public void Save_data_change_data_in_file( int _file_id, int _file_point_to_change, void* _data_pointer, int _length ){


        if( System_run.show_stack_messages_message_constructor )
            { 
                Console.Log( "Came Save_data_change_data_in_file()" ); 
                Console.Log( "_file_id: " + _file_id ); 
                Console.Log( "_file_point_to_change: " + _file_point_to_change ); 
                Console.Log( "_length: " + _length ); 

            }

        if( _length == 0 )
            { 
                if( System_run.show_stack_messages_message_constructor )
                    { Console.Log( "Length 0, will return" ); }
                return; 
            }


        Console.Log( "REMOVE FALSE LATER" );
        if( false && System_run.max_security )
            {
                if( _data_pointer == default )
                    { CONTROLLER__errors.Throw( "Pointer null" ); }

                if( _file_id <= 0 )
                    {CONTROLLER__errors.Throw( "Invalid file_id: " + _file_id ); }
                if( _length < 0 )
                    { CONTROLLER__errors.Throw( "Length negative: " + _length ); }

                if( _file_point_to_change < 0 )
                    { CONTROLLER__errors.Throw( "point to change negative: " + _file_point_to_change ); }

                if( origianl_message_pointer == default )
                    { CONTROLLER__errors.Throw( "origianl_message_pointer is null" ); }

                if( !!!( Controllers.files.Is_id_valid( _file_id ) ) )
                    { CONTROLLER__errors.Throw( $"File is <Color=lightBlue>{ _file_id }</Color> is not in the files_data controllers" ); }

            }

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

        Console.Log( "Length: " + _length );

        
        Controllers.stack.Save_message( message_length );

        return;


    }


    private static Stack_reconstruction_result_message Reconstruct_by_message__CHANGE_DATA_IN_FILE( Crash_handle_ephemeral_files _files_OS, ref Crash_file[] _files, void* _message ){

        if( System_run.show_program_construction_messages )
            { Console.Log( "Came Reconstruct_by_message__CHANGE_DATA_IN_FILE()" ); }
        

        STACK_MESSAGE__file_change* message = (STACK_MESSAGE__file_change*) _message;

        
        if( System_run.show_program_construction_messages )
            { 
                Console.Log( "file_id: " + ( message->file_id ) );
                Console.Log( "point_to_change: " + ( message->point_to_change ) );
                Console.Log( "length: " + ( message->length ) );
                
            }


        if( message->file_id == 0 )
            { return Stack_reconstruction_result_message.Construct( "The message <Color=lightBlue>STACK_MESSAGE__file_change</Color> file_id is 0", Stack_reconstruction_result.fail ); }

        if( message->file_id < 0 )
            { return Stack_reconstruction_result_message.Construct( $"The message <Color=lightBlue>STACK_MESSAGE__file_change</Color> file_id is <Color=lightBlue>{ message->file_id }</Color>", Stack_reconstruction_result.fail ); }


        if( message->file_id >= _files.Length )
            { return Stack_reconstruction_result_message.Construct( $"The file_id in the <Color=lightBlue>STACK_MESSAGE__file_change </Color> file_id is <Color=lightBlue>{ message->file_id }</Color> but the max id is <Color=lightBlue>{ ( _files.Length - 1 ) }</Color>", Stack_reconstruction_result.fail ); }

        byte[] file = _files[ message->file_id ].data;

        if( file == null )
            { return Stack_reconstruction_result_message.Construct( $"came in <Color=lightBlue>STACK_MESSAGE__file_change </Color> but there is no file in the file id  <Color=lightBlue>{ message->file_id }</Color>", Stack_reconstruction_result.fail ); }

        if( message->length == 0 )
            { return Stack_reconstruction_result_message.Construct( "The message <Color=lightBlue>STACK_MESSAGE__file_change</Color> length is 0", Stack_reconstruction_result.fail ); }

        if( message->point_to_change == 0 )
            { return Stack_reconstruction_result_message.Construct( "The message <Color=lightBlue>STACK_MESSAGE__file_change</Color> point_to_change is 0", Stack_reconstruction_result.fail ); }

        if( message->point_to_change < 0 )
            { return Stack_reconstruction_result_message.Construct( $"The message <Color=lightBlue>STACK_MESSAGE__file_change</Color> point_to_change is negative: <Color=lightBlue>{ message->point_to_change }</Color>", Stack_reconstruction_result.fail ); }


        int final_pointer = ( message->length + message->point_to_change );

        
        if( System_run.show_program_construction_messages )
            { Console.Log( "final_pointer: " + final_pointer ); }

        if( final_pointer >= file.Length )
            { 
                return Stack_reconstruction_result_message.Construct( 
                    $"The file <Color=lightBlue>{ message->file_id } </Color>in the <Color=lightBlue>STACK_MESSAGE__file_change " + 
                    $"</Color> final pointer is <Color=lightBlue>{ Formater.Format_number( final_pointer )  }</Color> but the file have <Color=lightBlue>{ Formater.Format_number( file.Length ) }</Color> bytes", 
                    Stack_reconstruction_result.fail
                ); 
            }

    	fixed( byte* data_pointer = file )
            { VOID.Transfer_data( &message->pointer_data, ( data_pointer + message->point_to_change ), message->length ); }
        
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


    private static Stack_reconstruction_result_message Reconstruct_by_message__CREATE_NEW_FILE( Crash_handle_ephemeral_files _files_OS, ref Crash_file[] _files, void* _message ){


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


        if( !!!( Directories.Is_sub_path( path, Paths_version.path_to_version ) ) )
            { 
                return Stack_reconstruction_result_message.Construct( 
                    $"Tried to save a file in the path <Color=lightBlue>{ path }</Color>, but don't make part of the program path " +
                    $"<Color=lightBlue>{ Paths_version.path_to_version }</Color>",
                    Stack_reconstruction_result.fail 
                );
            }

        if( _files_OS.Have_file( path ) )
            { return Stack_reconstruction_result_message.Construct( $"There is already a file in the path <Color=lightBlue>{ path }</Color>", Stack_reconstruction_result.fail ); }


        if( _files.Length <= file_id ) 
            {
                if( System_run.show_program_construction_messages )
                    { Console.Log( $"need to expand for the id <Color=lightBlue>{ file_id }</Color>" ); }
                // ** need to expand
                Array.Resize( ref _files, ( file_id + 20 ) );
            }





        if( _files[ file_id ].data != null )
            { return Stack_reconstruction_result_message.Construct( "This id is already in use: " + path, Stack_reconstruction_result.fail ); }
        
        if( _files[ file_id ].deleted_file )
            { return Stack_reconstruction_result_message.Construct( "This id was already used: " + path, Stack_reconstruction_result.fail ); }


        // ** create file
        _files[ file_id ].data = _files_OS.Create_new_file( path, file_length );
        _files[ file_id ].path = path;


        return Stack_reconstruction_result_message.Construct( null, Stack_reconstruction_result.succes );

    }







    // ** GOT FILE FROM DISK

    
    // [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Save_data_got_file_from_disk( int _file_id, string _path  ){


        Console.Log( "remover false depois" );
        if( false && System_run.max_security )
            {
                if( _path == null )
                    { CONTROLLER__errors.Throw( "Tried to create a new file in the stack with a null path" ); }

                if( _file_id == 0 )
                    { CONTROLLER__errors.Throw( "Tried to create a new file in the stack but the id of the file was 0" ); }
            }

        STACK_MESSAGE__got_file_from_disk* message = (STACK_MESSAGE__got_file_from_disk*) origianl_message_pointer;

        byte[] path_bytes = System.Text.Encoding.UTF8.GetBytes( _path );

        message->file_id = _file_id;
        message->length_path = path_bytes.Length;

        fixed( byte* b_p = path_bytes ){

            VOID.Transfer_data( b_p, &message->pointer_data_path, path_bytes.Length ); 

        }


        message->core_message.type = Safety_stack_action_type.got_file_from_disk;
        int message_length = (
            1 * sizeof( int ) + // ** length of the message
            1 * sizeof( int ) + // ** type of the message
            path_bytes.Length +           // ** path
            1 * sizeof( int ) + // ** file id
            1 * sizeof( int )   // ** length path
        );

        message->core_message.length = message_length;
        
        Controllers.stack.Save_message( message_length );

        return;


    }


    private static Stack_reconstruction_result_message Reconstruct_by_message__GOT_FILE_FROM_DISK( Crash_handle_ephemeral_files _files_OS, ref Crash_file[] _files, void* _message ){


        STACK_MESSAGE__got_file_from_disk* message = (STACK_MESSAGE__got_file_from_disk*) _message;


        int file_id = message->file_id;
        int path_length = message->length_path;


        if( file_id == 0 )
            { return Stack_reconstruction_result_message.Construct( $"The message <Color=lightBlue>STACK_MESSAGE__add_file</Color> file_id is 0", Stack_reconstruction_result.fail ); }

        if( file_id < 0 )
            { return Stack_reconstruction_result_message.Construct( $"The message <Color=lightBlue>STACK_MESSAGE__add_file</Color> file_id is <Color=lightBlue>{ file_id }</Color>", Stack_reconstruction_result.fail ); }


        if( path_length == 0 )
            { return Stack_reconstruction_result_message.Construct( $"The message <Color=lightBlue>STACK_MESSAGE__add_file</Color> point_to_change is 0", Stack_reconstruction_result.fail ); }

        if( path_length < 0 )
            { return Stack_reconstruction_result_message.Construct( $"The message <Color=lightBlue>STACK_MESSAGE__add_file</Color> length path is negative: <Color=lightBlue>{ path_length }</Color>", Stack_reconstruction_result.fail ); }


        // ** CREATE PATH
        byte[] path_bytes = new byte[ path_length ];

        fixed( byte* b_p = path_bytes )
            { VOID.Transfer_data( &message->pointer_data_path, b_p, path_bytes.Length ); }
        
        string path = System.Text.Encoding.UTF8.GetString( path_bytes );


        if( !!!( Directories.Is_sub_path( path, Paths_version.path_to_version ) ) )
            { 
                return Stack_reconstruction_result_message.Construct( 
                    $"Tried to save a file in the path <Color=lightBlue>{ path }</Color>, but don't make part of the program path " +
                    $"<Color=lightBlue>{ Paths_version.path_to_version }</Color>",
                    Stack_reconstruction_result.fail 
                );
            }


        if( _files.Length <= file_id )
            {
                if( System_run.show_program_construction_messages )
                    { Console.Log( $"need to expand for the id <Color=lightBlue>{ file_id }</Color>" ); }

                // ** need to expand
                Array.Resize( ref _files, ( file_id + 20 ) );
            }

        
        
        if( _files[ file_id ].data != null )
            { return Stack_reconstruction_result_message.Construct( "Should get a file, but it was already in the system so got duplicated: " + path, Stack_reconstruction_result.fail ); }

        
        if( _files[ file_id ].deleted_file )
            { return Stack_reconstruction_result_message.Construct( "Should get a file, but it was load and deleted. The id howuld have changed. Path : " + path, Stack_reconstruction_result.fail ); }

        
        if( !!!( _files_OS.Have_file( path ) ) )
            { return Stack_reconstruction_result_message.Construct( "File don't exist in path: " + path, Stack_reconstruction_result.fail ); }


        // ** create file
        _files[ file_id ].data = _files_OS.Get_file( path );
        _files[ file_id ].path = path;
        


        return Stack_reconstruction_result_message.Construct( null, Stack_reconstruction_result.succes );

    }



    // ** CHANGE LENGTH

    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Save_data_change_length_file( int _file_id, int _new_length ){


        if( System_run.max_security )
            {
                if( _file_id == 0 )
                    { CONTROLLER__errors.Throw( "Tried to change the length of a file in the stack, but the file id is 0" ); }
                
                if( _file_id < 0 )
                    { CONTROLLER__errors.Throw( $"Tried to change the length of a file in the stack, but the file id is negative: <Color=lightBlue>{ _file_id }</Color>" ); }

                if( _new_length == 0 )
                    { CONTROLLER__errors.Throw( "Tried to change the length of a file in the stack but the new length is 0 " ); }

                if( _new_length < 0 )
                    { CONTROLLER__errors.Throw( $"Tried to change the length of a file in the stack but the new length is negative: <Color=lightBlue>{ _new_length }</Color>" ); }

            }

        STACK_MESSAGE__change_length_file* message = (STACK_MESSAGE__change_length_file*) origianl_message_pointer;

            message->file_id = _file_id;
            message->new_length = _new_length;


        message->core_message.type = Safety_stack_action_type.change_length_file;
        int message_length = (
            1 * sizeof( int ) + // ** length of the message
            1 * sizeof( int ) + // ** type of the message
            1 * sizeof( int ) + // ** file id
            1 * sizeof( int )   // ** new legnth
        );

        message->core_message.length = message_length;

        
        Controllers.stack.Save_message( message_length );

        return;


    }


    private static Stack_reconstruction_result_message Reconstruct_by_message__CHANGE_LENGTH_FILE( Crash_handle_ephemeral_files _files_OS, ref Crash_file[] _files, void* _message ){


        STACK_MESSAGE__change_length_file* message = (STACK_MESSAGE__change_length_file*) _message;


        int file_id = message->file_id;
        int new_length = message->new_length;


        if( file_id == 0 )
            { return Stack_reconstruction_result_message.Construct( $"The message <Color=lightBlue>STACK_MESSAGE__change_length_file</Color> file_id is 0", Stack_reconstruction_result.fail ); }

        if( file_id < 0 )
            { return Stack_reconstruction_result_message.Construct( $"The message <Color=lightBlue>STACK_MESSAGE__change_length_file</Color> file_id is <Color=lightBlue>{ file_id }</Color>", Stack_reconstruction_result.fail ); }


        if( new_length == 0 )
            { return Stack_reconstruction_result_message.Construct( $"The message <Color=lightBlue>STACK_MESSAGE__change_length_file</Color> point_to_change is 0", Stack_reconstruction_result.fail ); }

        if( new_length < 0 )
            { return Stack_reconstruction_result_message.Construct( $"The message <Color=lightBlue>STACK_MESSAGE__change_length_file</Color> length path is negative: <Color=lightBlue>{ new_length }</Color>", Stack_reconstruction_result.fail ); }

        if( _files.Length <= file_id )
            { return Stack_reconstruction_result_message.Construct( $"The message <Color=lightBlue>STACK_MESSAGE__change_length_file</Color> the file id is bigger than the files. Can not expand a file that don't exist", Stack_reconstruction_result.fail ); }

        if( _files[ file_id ].data == null )
            { return Stack_reconstruction_result_message.Construct( $"The message <Color=lightBlue>STACK_MESSAGE__change_length_file</Color> but there is no file in the id <Color=lightBlue>{ file_id }</Color>. Can not expand a file that don't exist", Stack_reconstruction_result.fail ); }

        _files[ file_id ].data = _files_OS.Change_length_file( _files[ file_id ].path, new_length );


        return Stack_reconstruction_result_message.Construct( null, Stack_reconstruction_result.succes );

    }







    private void Safety(){

        if( System_run.max_security && origianl_message_pointer == null )
            { CONTROLLER__errors.Throw( "Tried to use <Color=lightBlue>origianl_message_pointer</Color> but the pointer is NULL" ); }

    }

}