

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


    public static Stack_reconstruction_result_message Read_message( Crash_handle_ephemeral_files _files_OS, Crash_cached_files _files, void* _message ){



        Safety_stack_action_type type = ((Stack_message_core*)_message)->type;

        if( System_run.show_program_construction_messages ) 
            { Console.Log( "type: " + type ); }

        

        switch( type ){

            // ** OK
            case Safety_stack_action_type.change_data_in_file: return Reconstruct_by_message__CHANGE_DATA_IN_FILE( _files_OS, _files, _message ); 
            // ** OK
            case Safety_stack_action_type.got_file_from_disk: return Reconstruct_by_message__GOT_FILE_FROM_DISK( _files_OS, _files, _message );

            
            case Safety_stack_action_type.create_new_file: return Reconstruct_by_message__CREATE_NEW_FILE( _files_OS, _files, _message );
            case Safety_stack_action_type.change_length_file: return Reconstruct_by_message__CHANGE_LENGTH_FILE( _files_OS, _files, _message );

            case Safety_stack_action_type.delete_file: return Reconstruct_by_message__DELETE_FILE( _files_OS, _files, _message );
            case Safety_stack_action_type.remove_file: return Reconstruct_by_message__REMOVE_FILE( _files_OS, _files, _message );

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


        if( System_run.max_security )
            {
                if( _data_pointer == default )
                    { CONTROLLER__errors.Throw( "Pointer null" ); }

                if( _file_id <= 0 )
                    {CONTROLLER__errors.Throw( "Invalid file_id: " + _file_id ); }
                if( _length <= 0 )
                    { CONTROLLER__errors.Throw( "Length negative: " + _length ); }

                if( _file_point_to_change < 0 )
                    { CONTROLLER__errors.Throw( "point to change negative: " + _file_point_to_change ); }

                if( origianl_message_pointer == default )
                    { CONTROLLER__errors.Throw( "origianl_message_pointer is null" ); }

                if( !!!( Controllers.files.storage.Is_id_valid( _file_id ) ) )
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
        
        Controllers.stack.Save_message( message_length );

        return;


    }


    private static Stack_reconstruction_result_message Reconstruct_by_message__CHANGE_DATA_IN_FILE( Crash_handle_ephemeral_files _files_OS, Crash_cached_files _files, void* _message ){

        if( System_run.show_program_construction_messages )
            { Console.Log( "Came Reconstruct_by_message__CHANGE_DATA_IN_FILE()" ); }
        

        STACK_MESSAGE__file_change* message = (STACK_MESSAGE__file_change*) _message;

        
        if( System_run.show_program_construction_messages )
            { 
                Console.Log( "file_id: " + ( message->file_id ) );
                Console.Log( "point_to_change: " + ( message->point_to_change ) );
                Console.Log( "length: " + ( message->length ) );
                
            }

        if( message->file_id <= 0 )
            { return Stack_reconstruction_result_message.Construct( $"The message <Color=lightBlue>STACK_MESSAGE__file_change</Color> file_id is invalid: <Color=lightBlue>{ message->file_id }</Color>", Stack_reconstruction_result.fail ); }

        byte[] file_data = _files.Get_data( message->file_id );

        if(  !!!( _files.Have_data( message->file_id ) ) )
            { return Stack_reconstruction_result_message.Construct( $"came in <Color=lightBlue>STACK_MESSAGE__file_change </Color> but there is no file in the file id  <Color=lightBlue>{ message->file_id }</Color>", Stack_reconstruction_result.fail ); }

        if( message->length <= 0 )
            { return Stack_reconstruction_result_message.Construct( $"The message <Color=lightBlue>STACK_MESSAGE__file_change</Color> length is <Color=lightBlue>{ message->length }</Color>", Stack_reconstruction_result.fail ); }

        if( message->point_to_change < 0 )
            { return Stack_reconstruction_result_message.Construct( $"The message <Color=lightBlue>STACK_MESSAGE__file_change</Color> point_to_change is <Color=lightBlue>{ message->point_to_change }</Color>", Stack_reconstruction_result.fail ); }

        int final_pointer = ( message->point_to_change + message->length - 1 );

        
        if( System_run.show_program_construction_messages )
            { Console.Log( "final_pointer: " + final_pointer ); }

        if( final_pointer >= file_data.Length )
            { 
                return Stack_reconstruction_result_message.Construct( 
                    $"The file <Color=lightBlue>{ message->file_id } </Color>in the <Color=lightBlue>STACK_MESSAGE__file_change " + 
                    $"</Color> final pointer is <Color=lightBlue>{ Formater.Format_number( final_pointer )  }</Color> but the file have <Color=lightBlue>{ Formater.Format_number( file_data.Length ) }</Color> bytes", 
                    Stack_reconstruction_result.fail
                ); 
            }


    	fixed( byte* data_pointer = file_data )
            { VOID.Transfer_data( &message->pointer_data, ( data_pointer + message->point_to_change ), message->length ); }


        
        //mark
        Data_file_link link = Controllers.files.storage.Get_data( message->file_id );
        Controllers.files.operations.Change_data_file( link, message->point_to_change, &message->pointer_data, message->length );


        return Stack_reconstruction_result_message.Construct( null, Stack_reconstruction_result.succes );

    }


    // CREATE NEW FILE

    #if !UNITY_EDITOR
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
    #endif
    public void Save_data_create_new_file( int _file_id, int _file_length, string _path ){


        if( System_run.max_security )
            {
                if( _path == null )
                    { CONTROLLER__errors.Throw( "Tried to create a new file in the stack with a null path" ); }

                if( _file_id <= 0 )
                    { CONTROLLER__errors.Throw( "Tried to create a new file in the stack but the id of the file is: " + _file_id ); }

                if( _file_length <= 0 )
                    { CONTROLLER__errors.Throw( "Tried to create a new file in the stack but the id of the file is: " + _file_id ); }

                if( !!!( Directories.Is_sub_path( _path, Paths_version.path_to_version ))  )
                    { CONTROLLER__errors.Throw( $"Tried to create a new file message, but the path is not in the version folder:<Color=lightBlue>{ _path }</Color>" ); }

                //mark
                // ** is conflicting with lock_id(), if came here the file dont exist
                // if( Controllers.files.storage.File_exist_in_final_disk( _path ) )
                //     { CONTROLLER__errors.Throw( $"Tried to create a new file message, but the file already exist in the path :<Color=lightBlue>{ _path }</Color>" ); }

                // if( Controllers.files.storage.Is_id_valid( _file_id ) )
                //     { CONTROLLER__errors.Throw( $"Tried to create a new file message, but the file id { _file_id } is already in use" ); }


                
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


    private static Stack_reconstruction_result_message Reconstruct_by_message__CREATE_NEW_FILE( Crash_handle_ephemeral_files _files_OS, Crash_cached_files _files, void* _message ){


        STACK_MESSAGE__create_new_file* message = (STACK_MESSAGE__create_new_file*) _message;


        int file_id = message->file_id;
        int file_length = message->length_file;
        int path_length = message->length_path;


        if( file_id <= 0 )
            { return Stack_reconstruction_result_message.Construct( $"The message <Color=lightBlue>STACK_MESSAGE__create_new_file</Color> file_id is <Color=lightBlue>{ file_id }</Color>", Stack_reconstruction_result.fail ); }

        if( file_length <= 0 )
            { return Stack_reconstruction_result_message.Construct( $"The message <Color=lightBlue>STACK_MESSAGE__create_new_file</Color> length is negative: <Color=lightBlue>{ file_length }</Color>", Stack_reconstruction_result.fail ); }

        if( path_length <= 0 )
            { return Stack_reconstruction_result_message.Construct( $"The message <Color=lightBlue>STACK_MESSAGE__create_new_file</Color> length path is negative: <Color=lightBlue>{ path_length }</Color>", Stack_reconstruction_result.fail ); }


        string path = STRING.Reconstruct_string( &message->pointer_data_path, path_length );
        

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


        if( _files.Have_data( file_id ) )
            { return Stack_reconstruction_result_message.Construct( "This id is already in use: " + path, Stack_reconstruction_result.fail ); }
        

        // ** create file
        byte[] data = _files_OS.Create_new_file( path, file_length );
        _files.Add_data( path, file_id, data );


        //mark
        Controllers.files.operations.Create_new_file_EMPTY( path, file_length );


        return Stack_reconstruction_result_message.Construct( null, Stack_reconstruction_result.succes );

    }







    // ** DELETE FILE
    #if !UNITY_EDITOR
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
    #endif
    public void Save_data_delete_file( int _file_id, string _path  ){


        Console.Log( "remover false depois" );
        if( false && System_run.max_security )
            {
                if( _path == null )
                    { CONTROLLER__errors.Throw( "Tried to delete file in the stack with a null path" ); }

                if( _file_id <= 0 )
                    { CONTROLLER__errors.Throw( $"Tried to delete file in the stack but the id of the file is invalid: <Color=lightBlue>{ _file_id }</Color>" ); }
            }

        STACK_MESSAGE__delete_file* message = (STACK_MESSAGE__delete_file*) origianl_message_pointer;

        byte[] path_bytes = System.Text.Encoding.UTF8.GetBytes( _path );

        message->file_id = _file_id;
        message->length_path = path_bytes.Length;

        fixed( byte* b_p = path_bytes )
            { VOID.Transfer_data( b_p, &message->pointer_data_path, path_bytes.Length ); }


        message->core_message.type = Safety_stack_action_type.delete_file;
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


    private static Stack_reconstruction_result_message Reconstruct_by_message__DELETE_FILE( Crash_handle_ephemeral_files _files_OS, Crash_cached_files _files, void* _message ){

        if( System_run.show_program_construction_messages_messages_detail_in_messages )
            { Console.Log( "Came Reconstruct_by_message__DELETE_FILE()" ); }

        STACK_MESSAGE__delete_file* message = (STACK_MESSAGE__delete_file*) _message;


        int file_id = message->file_id;
        int path_length = message->length_path;

        if( System_run.show_program_construction_messages_messages_detail_in_messages )
            {
                Console.Log( "file_id: " + file_id );
                Console.Log( "path_length: " + path_length );
            }


        if( file_id == 0 )
            { return Stack_reconstruction_result_message.Construct( $"The message <Color=lightBlue>STACK_MESSAGE__delete_file</Color> file_id is 0", Stack_reconstruction_result.fail ); }

        if( file_id < 0 )
            { return Stack_reconstruction_result_message.Construct( $"The message <Color=lightBlue>STACK_MESSAGE__delete_file</Color> file_id is <Color=lightBlue>{ file_id }</Color>", Stack_reconstruction_result.fail ); }


        if( path_length == 0 )
            { return Stack_reconstruction_result_message.Construct( $"The message <Color=lightBlue>STACK_MESSAGE__delete_file</Color> point_to_change is 0", Stack_reconstruction_result.fail ); }

        if( path_length < 0 )
            { return Stack_reconstruction_result_message.Construct( $"The message <Color=lightBlue>STACK_MESSAGE__delete_file</Color> length path is negative: <Color=lightBlue>{ path_length }</Color>", Stack_reconstruction_result.fail ); }


        
        string path = STRING.Reconstruct_string( &message->pointer_data_path, message->length_path );

        if( System_run.show_program_construction_messages_messages_detail_in_messages )
            { Console.Log( $"path to delete: " + path ); }


        if( !!!( Directories.Is_sub_path( path, Paths_version.path_to_version ) ) )
            { 
                return Stack_reconstruction_result_message.Construct( 
                    $"Tried to delete a file in the path <Color=lightBlue>{ path }</Color>, but don't make part of the program path " +
                    $"<Color=lightBlue>{ Paths_version.path_to_version }</Color>",
                    Stack_reconstruction_result.fail 
                );
            }


        bool file_is_in_the_system = _files.Have_data( path );
        bool file_is_in_OS = _files_OS.Have_file( path );

        if( !!!( file_is_in_the_system ) && !!!( file_is_in_OS ) )
            { return Stack_reconstruction_result_message.Construct( $"The message <Color=lightBlue>STACK_MESSAGE__delete_file</Color> there is no fle to delete in the id <Color=lightBlue>{ file_id }</Color>", Stack_reconstruction_result.fail ); }

        
        if( file_is_in_the_system )
            { _files.Remove_data( file_id ); }

        if( file_is_in_OS )
            { _files_OS.Delete_file( path ); }


        // // ** create file
        // _files[ file_id ].data = _files_OS.Get_file( path );
        // _files[ file_id ].path = path;
        
        
        //mark
        Controllers.files.operations.Delete_file( path );


        return Stack_reconstruction_result_message.Construct( null, Stack_reconstruction_result.succes );

    }






    // REMOVE FILKE

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Save_data_remove_file( int _file_id  ){


        if( System_run.max_security )
            {
                if( _file_id <= 0 )
                    { CONTROLLER__errors.Throw( $"Tried to create a new file in the stack but the id of the file was invalid: <Color=lightBlue>{ _file_id }</Color>" ); }
            }

        STACK_MESSAGE__remove_file* message = (STACK_MESSAGE__remove_file*) origianl_message_pointer;

        message->file_id = _file_id;


        message->core_message.type = Safety_stack_action_type.remove_file;
        int message_length = (
            1 * sizeof( int ) + // ** length of the message
            1 * sizeof( int ) + // ** type of the message
            1 * sizeof( int )   // ** file id
        );

        message->core_message.length = message_length;

        
        Controllers.stack.Save_message( message_length );

        return;


    }


    private static Stack_reconstruction_result_message Reconstruct_by_message__REMOVE_FILE( Crash_handle_ephemeral_files _files_OS, Crash_cached_files _files, void* _message ){


        STACK_MESSAGE__remove_file* message = (STACK_MESSAGE__remove_file*) _message;

        int file_id = message->file_id;

        if( file_id <= 0 )
            { return Stack_reconstruction_result_message.Construct( $"The message <Color=lightBlue>STACK_MESSAGE__remove_file</Color> file_id is <Color=lightBlue>{ file_id }</Color>", Stack_reconstruction_result.fail ); }

        if( !!!( _files.Have_data( file_id ) ) )
            { return Stack_reconstruction_result_message.Construct( $"There is no file in the id <Color=lightBlue>{ file_id }</Color>", Stack_reconstruction_result.fail ); }


        _files_OS.Switch_file( _files.Get_path( file_id ), _files.Get_data( file_id ) );
        _files.Remove_data( file_id );


        //mark
        Data_file_link link = Controllers.files.storage.Get_data( file_id );
        Controllers.files.operations.Remove_file( link );


        return Stack_reconstruction_result_message.Construct( null, Stack_reconstruction_result.succes );

    }


































    // ** GOT FILE FROM DISK

    //mark
    // ** CHANGE NAME TO SAVE_MESSAGE__thing()
    #if !UNITY_EDITOR
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
    #endif
    public void Save_data_got_file_from_disk( int _file_id, string _path  ){


        if( System_run.max_security )
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


    private static Stack_reconstruction_result_message Reconstruct_by_message__GOT_FILE_FROM_DISK( Crash_handle_ephemeral_files _files_OS, Crash_cached_files _files, void* _message ){


        if( System_run.show_program_construction_messages_messages_detail_in_messages )
            { Console.Log( "Came Reconstruct_by_message__GOT_FILE_FROM_DISK()" ); }

        STACK_MESSAGE__got_file_from_disk* message = (STACK_MESSAGE__got_file_from_disk*) _message;


        int file_id = message->file_id;
        int path_length = message->length_path;

        if( System_run.show_program_construction_messages_messages_detail_in_messages )
            { Console.Log( $"file_id: { file_id } path_length: { path_length }" ); }


        if( file_id <= 0 )
            { return Stack_reconstruction_result_message.Construct( $"The message <Color=lightBlue>STACK_MESSAGE__add_file</Color> file_id is <Color=lightBlue>{ file_id }</Color>", Stack_reconstruction_result.fail ); }

        if( path_length <= 0 )
            { return Stack_reconstruction_result_message.Construct( $"The message <Color=lightBlue>STACK_MESSAGE__add_file</Color> point_to_change is <Color=lightBlue>{ path_length }</Color>", Stack_reconstruction_result.fail ); }


        string path = STRING.Reconstruct_string( &message->pointer_data_path, message->length_path );

        if( System_run.show_program_construction_messages_messages_detail_in_messages )
            { Console.Log( $"path: " + path ); }


        if( !!!( Directories.Is_sub_path( path, Paths_version.path_to_version ) ) )
            { 
                return Stack_reconstruction_result_message.Construct( 
                    $"Tried to get a file in disk but the file is out of bounds with the version folder. file in the path <Color=lightBlue>{ path }</Color>" +
                    $" version path: <Color=lightBlue>{ Paths_version.path_to_version }</Color>",
                    Stack_reconstruction_result.fail 
                );
            }

        
        if( _files.Have_data( file_id ) )
            { return Stack_reconstruction_result_message.Construct( "Should get a file, but it was already in the system so got duplicated: " + path, Stack_reconstruction_result.fail ); }

        
        if( !!!( _files_OS.Have_file( path ) ) )
            { return Stack_reconstruction_result_message.Construct( "File don't exist in path: " + path, Stack_reconstruction_result.fail ); }


        // ** create file
        _files.Add_data( path, file_id, _files_OS.Get_file( path ) );


        //mark
        Controllers.files.operations.Get_file_from_disk( path );
        

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


    private static Stack_reconstruction_result_message Reconstruct_by_message__CHANGE_LENGTH_FILE( Crash_handle_ephemeral_files _files_OS, Crash_cached_files _files, void* _message ){


        STACK_MESSAGE__change_length_file* message = (STACK_MESSAGE__change_length_file*) _message;


        int file_id = message->file_id;
        int new_length = message->new_length;


        if( file_id <= 0 )
            { return Stack_reconstruction_result_message.Construct( $"The message <Color=lightBlue>STACK_MESSAGE__change_length_file</Color> file_id is <Color=lightBlue>{ file_id }</Color>", Stack_reconstruction_result.fail ); }

        if( new_length <= 0 )
            { return Stack_reconstruction_result_message.Construct( $"The message <Color=lightBlue>STACK_MESSAGE__change_length_file</Color> point_to_change is <Color=lightBlue>{ new_length }</Color>", Stack_reconstruction_result.fail ); }

        if( !!!( _files.Have_data( file_id ) ) )
            { return Stack_reconstruction_result_message.Construct( $"The message <Color=lightBlue>STACK_MESSAGE__change_length_file</Color> but there is no file in the id <Color=lightBlue>{ file_id }</Color>. Can not expand a file that don't exist", Stack_reconstruction_result.fail ); }

        _files.Change_length_data( file_id, new_length );



        Data_file_link link = Controllers.files.storage.Get_data( file_id );
        Controllers.files.operations.Change_length_file( link, new_length );
        

        return Stack_reconstruction_result_message.Construct( null, Stack_reconstruction_result.succes );

    }







    private void Safety(){

        if( System_run.max_security && origianl_message_pointer == null )
            { CONTROLLER__errors.Throw( "Tried to use <Color=lightBlue>origianl_message_pointer</Color> but the pointer is NULL" ); }

    }

}