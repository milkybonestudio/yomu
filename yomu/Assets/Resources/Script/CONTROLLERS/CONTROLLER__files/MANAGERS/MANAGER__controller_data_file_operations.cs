

using System;

unsafe public struct MANAGER__controller_data_file_operations {

    public static MANAGER__controller_data_file_operations Construct(){

        MANAGER__controller_data_file_operations manager = default;
            manager.lock_obj = new();
        return manager;

    }


    #if !UNITY_EDITOR
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
    #endif
    public void Change_data_file<T>( Data_file_link _data, int _off_set, T* _data_pointer ) where T: unmanaged{

        Change_data_file( _data, _off_set, _data_pointer, sizeof( T ) );

    }

    #if !UNITY_EDITOR
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
    #endif
    public void Change_data_file<T>( Data_file_link _data, int _off_set, T _data_value ) where T: unmanaged{

        Change_data_file( _data, _off_set, &_data_value, sizeof( T ) );

    }


    #if !UNITY_EDITOR
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
    #endif
    public void Change_data_file( Data_file_link _data, int _off_set, void* _data_pointer, int _length ){

        // no need to use stack

        lock( lock_obj ){

            void* file_pointer = default;
            int length_file = default;

            if( System_run.max_security )   
                {
                    if( !!!( Controllers.files.storage.Is_id_valid( _data.id ) ) )
                        { CONTROLLER__errors.Throw( $"Tried to change data of the file <Color=lightBlue>{ _data.id }</Color> the id is not valid" ); }

                    file_pointer = _data.Get_pointer();
                    length_file = _data.Get_length();

                    if( _off_set <= 0 )
                        { CONTROLLER__errors.Throw( $"Tried to change data in the file {_data.id } but the _off_set is { _off_set }" ); }

                    if( _data_pointer == null )
                        { CONTROLLER__errors.Throw( $"Tried to change data in the file {_data.id } but the _data_pointer is null" ); }

                    if( _length <= 0 )
                        { CONTROLLER__errors.Throw( $"Tried to change data in the file {_data.id } but the length to change is <Color=lightBlue>{ _length }</Color>" ); }
                    
                    if( ( _off_set + _length - 1 ) >= length_file )
                        { CONTROLLER__errors.Throw( $"Tried to change data in the file {_data.id } but the final pointer would pass the file to change is <Color=lightBlue>{ _length }</Color>" ); }
                   
                }


            void* start_pointer = (void*)( ( ( byte*) file_pointer ) + _off_set );

            // ** I assume compiler will choose the better compile time 
            // ** data is always in the end -> can overwrite iw some 0s

                 if( _length == 1 )
                    {
                        *(byte*)( start_pointer ) = *(byte*)_data_pointer;
                    }
            else if( _length == 2 )
                    {
                        *(short*)( start_pointer ) = *(short*)_data_pointer;
                    }
            else if( _length == 4 )
                    {
                        *(int*)( start_pointer ) = *(int*)_data_pointer;
                    }
            else if( _length == 8 )
                    {
                        *(long*)( start_pointer ) = *(long*)_data_pointer;
                    }   
            else if( _length == 16 )
                    {
                        *(decimal*)( start_pointer ) = *(decimal*)_data_pointer;
                    }
            else if( true )
                    {
                        VOID.Transfer_data( _data_pointer, start_pointer, _length );
                    }


            Controllers.stack.files.Save_data_change_data_in_file( _data.id, _off_set, _data_pointer, _length );
            return;

        }
        
    }

    
    public Object lock_obj;

    // ** call only when the file already exists
    public Data_file_link Get_file( string _path ){

        // no need to use stack

        lock( lock_obj ){

            if( System_run.max_security )   
                {
                    if( _path == null  )
                        { CONTROLLER__errors.Throw( $"Tried to get a file but teh path is <Color=lightBlue>NULL</Color>" ); }

                    if( !!!( Directories.Is_sub_path( _path, Paths_version.path_to_version ) ) )
                        { CONTROLLER__errors.Throw( $"Tried to get a file but the path is not part of the version. Path: <Color=lightBlue>{ _path }</Color>" ); }

                    if( !!!( Controllers.files.storage.Is_file_already_taken( _path )) )
                        { CONTROLLER__errors.Throw( $"Tried to get the file in the path <Color=lightBlue>{ _path }</Color>, but it dosent exist" ); }
                    
                }

            return Controllers.files.storage.Get_data( _path );

        }
        
    }



    // ** call only when the file already exists
    public Data_file_link Get_file( int _file_id ){

        // no need to use stack

        lock( lock_obj ){

            if( System_run.max_security )   
                {

                    if( _file_id <= 0 )
                        { CONTROLLER__errors.Throw( $"Tried to get a file but the id is not valid. Id: <Color=lightBlue>{ _file_id }</Color>" ); }

                    if( !!!( Controllers.files.storage.Is_id_valid( _file_id )) )
                        { CONTROLLER__errors.Throw( $"Tried to get the file with the id <Color=lightBlue>{ _file_id }</Color>, but it's not valid" ); }
                    
                }

            return Controllers.files.storage.Get_data( _file_id );

        }
        
    }




    // ** 
    public Data_file_link Get_file_from_disk( string _path ){

        // add slot

        lock( lock_obj ){

            if( System_run.max_security )
                {
                    if( _path == null  )
                        { CONTROLLER__errors.Throw( $"Tried to get a file but tethe path is <Color=lightBlue>NULL</Color>" ); }

                    if( !!!( Directories.Is_sub_path( _path, Paths_version.path_to_version ) ) )
                        { CONTROLLER__errors.Throw( $"Tried to get a file from disk but the paths is not part of the version. The path: <Color=lightBlue>{ _path }</Color>" ); }
                
                    if( Controllers.files.storage.Is_file_already_taken( _path ) )
                        { CONTROLLER__errors.Throw( $"Tried to get the file <Color=lightBlue>{ _path }</Color> from disk, but the system already heve it in with the index <Color=lightBlue>{ Controllers.files.storage.path_TO_id[ _path ] }</Color>" ); }

                    if( !!!( Controllers.files.storage.File_exist_in_final_disk( _path ) ) )
                        { CONTROLLER__errors.Throw( $"File don't exist in disk. path: <Color=lightBlue>{ _path }</Color>" ); }
                    
                    if( Controllers.saving.state == Saving_state.saving_files )
                        { CONTROLLER__errors.Throw( $"Tried to get the file <Color=lightBlue>{ _path }</Color> from disk, but the system is saving the files. For not corrupt the system it can not happens" ); }
                }


            // ** cached is always the most current version
            if( Controllers.files.storage.Is_file_in_cache( _path ) )
                { 
                    Data_file_link data_cached = Controllers.files.storage.Get_via_cached_data( _path ); 
                    Controllers.stack.files.Save_data_got_file_from_disk( data_cached.id, _path );
                    return data_cached;
                }
            
            byte[] data = System.IO.File.ReadAllBytes( _path );

            Data_file_link data_link = Controllers.files.storage.Lock_slot( _path, data.Length );
            Controllers.stack.files.Save_data_got_file_from_disk( data_link.id, _path );

            VOID.Transfer_data( data, data_link.heap_key.Get_pointer() );


            return data_link;

        }

    }

    public void Remove_file( Data_file_link _data_file ){

        lock( lock_obj ){

            if( System_run.max_security )
                {                    
                    if( !!!( Controllers.files.storage.Is_id_valid( _data_file.id ) ) )
                        { 
                            CONTROLLER__errors.Throw( 
                                $"Tried to remove a file from the system <Color=lightBlue>{ Controllers.files.storage.Get_path_for_file( _data_file ) }</Color> from disk," + 
                                $" but the system is saving the files. For not corrupt the system it can not happens" 
                            );
                        }

                    if( Controllers.saving.state == Saving_state.saving_files )
                        { 
                            CONTROLLER__errors.Throw( 
                                $"Tried to remove a file from the system <Color=lightBlue>{ Controllers.files.storage.Get_path_for_file( _data_file ) }</Color> from disk, " + 
                                $"but the system is saving the files. For not corrupt the system it can not happens"
                            ); 
                        }

                }

            Controllers.files.storage.Remove_file( _data_file );

            Console.Log( "VER O CERTO DEPOIS DEPOIS" );
            Controllers.stack.files.Save_data_remove_file( _data_file.id );

            return;
        }

    }


    public Data_file_link Create_new_file( byte[] _data, string _path ){

        if( _data == null )
            { CONTROLLER__errors.Throw( "tried to create a path but the data is null" ); }

        fixed( byte* data_pointer = _data )
            { return Create_new_file( data_pointer, _data.Length, _path ); }
    }

    public Data_file_link Create_new_file( void* _file_pointer, int _file_length, string _path ){

        // ** call only when create run time files

        lock( lock_obj ){

            if( System_run.max_security )
                { 
                    if( _file_pointer == null )
                        { CONTROLLER__errors.Throw( $"null pointer in Create_new_file" ); }

                    if( _file_length == 0 )
                        { CONTROLLER__errors.Throw( $"Came in Create_new_file() but the file_length is <Color=lightBlue>0</Color>" ); }

                    if( _file_length < 0 )
                        { CONTROLLER__errors.Throw( $"Came in Create_new_file() but the file_length is negative: <Color=lightBlue>{ _file_length }</Color>" ); }

                    if( _path == null )
                        { CONTROLLER__errors.Throw( $"null path in Create_new_file" ); }

                    if( !!!( Directories.Is_sub_path( _path, Paths_version.path_to_version ) ) )
                        { CONTROLLER__errors.Throw( $"Tried to create a file but the path is not part of the version: <Color=lightBlue>{ _path }</Color>" ); }

                    if( Controllers.files.storage.File_exist_in_final_disk( _path ) )
                        { CONTROLLER__errors.Throw( $"Tried to create a file, but it already exists. Path: <Color=lightBlue>{ _path }</Color>" );  }

                    if( Controllers.saving.state == Saving_state.saving_files )
                        { CONTROLLER__errors.Throw( $"Tried to create a new file but the files are being saved. For not corrupt the system it can not happens" ); }

                }


            Data_file_link data_file = Controllers.files.storage.Lock_slot( _path, _file_length );

            VOID.Transfer_data( _file_pointer, data_file.Get_pointer(), _file_length );
            
                // STACK

                Controllers.stack.files.Save_data_create_new_file( data_file.id, _file_length, _path );
                Controllers.stack.files.Save_data_change_data_in_file( 
                    _file_id                : data_file.id,
                    _file_point_to_change   : 0,
                    _data_pointer           : _file_pointer, 
                    _length                 : _file_length

                );


            return data_file;

        }

    }



    public Data_file_link Create_new_file_EMPTY( string _path, int _file_length ){

        // ** call only when create run time files

        lock( lock_obj ){

            if( System_run.max_security )
                { 

                    if( Controllers.files.storage.File_exist_in_final_disk( _path ) )
                        { CONTROLLER__errors.Throw( $"Tried to create a file but it alreadys exist. Path: <Color=lightBlue>{ _path }</Color>" );  }

                    if( _file_length == 0 )
                        { CONTROLLER__errors.Throw( $"Tried to create a empty file but the length is 0 " );  }

                    if( _file_length < 0 )
                        { CONTROLLER__errors.Throw( $"Tried to create a empty file but the length is negative:  " + _file_length );  }

                    if( !!!( Directories.Is_sub_path( _path, Paths_version.path_to_version ) ) )
                        { CONTROLLER__errors.Throw( $"Tried to create a empty file but the path is not part of the version: <Color=lightBlue>{ _path }</Color>" ); }

                    if( Controllers.saving.state == Saving_state.saving_files )
                        { CONTROLLER__errors.Throw( $"Tried to create a new EMPTY file <Color=lightBlue>{ _path }</Color> from disk, but the system is saving the files. For not corrupt the system it can not happens" ); }

                }

            
            Data_file_link data_link = Controllers.files.storage.Lock_slot( _path, _file_length );

            Controllers.stack.files.Save_data_create_new_file( data_link.id, data_link.size, _path );
            
            return data_link;

        }

    }






    public void Delete_file( Data_file_link _data ){

        lock( lock_obj ){

            Delete_file_intern( Controllers.files.storage.Get_path_for_file( _data ) );

        }

    }

    public void Delete_file( string _path ){

        lock( lock_obj ){

            Delete_file_intern( _path );

        }

    }



    private void Delete_file_intern( string _path ){

    
        if( System_run.max_security )
            {             
                if( _path == null )
                    { CONTROLLER__errors.Throw( $"Tried to delete a file but the path is <Color=lightBlue>NULL</Color>" ); }

                if( !!!( Directories.Is_sub_path( _path, Paths_version.path_to_version ))  )
                    { CONTROLLER__errors.Throw( $"Tried to delete a file, but the path is not on the version folder: <Color=lightBlue>{ _path }</Color>" ); }

                if( !!!( Controllers.files.storage.File_exist_in_final_disk( _path ) ) )
                    { 
                        CONTROLLER__errors.Throw( 
                            $"Tried to delete the file but it dosent exist in final disk." + 
                            $"Path <Color=lightBlue>{ _path }</Color> dont exist in any place, not in disk, not in data and either in the cached area"
                        ); 
                    }

                
                if( Controllers.saving.state == Saving_state.saving_files )
                    { 
                        CONTROLLER__errors.Throw( 
                            $"Tried to remove a file from the system <Color=lightBlue>{ _path }</Color> from disk, " + 
                            $"but the system is saving the files. For not corrupt the system it can not happens"
                        ); 
                    }
            }


        Data_file_link data_link = Controllers.files.storage.Delete_file( _path );


        Controllers.stack.files.Save_data_delete_file( data_link.id, _path );

        return;

    }


    public Data_file_link Change_length_file( Data_file_link _data_link, int _new_length ){

        lock( lock_obj ){

            
            if( Controllers.files.is_reconstructing_stack_from_CRASH )
                { return _data_link; }

            if( System_run.max_security )
                {                    
                    if( Controllers.saving.state == Saving_state.saving_files )
                        { CONTROLLER__errors.Throw( $"Tried to change the length of the file <Color=lightBlue>{ Controllers.files.storage.Get_path_for_file( _data_link ) }</Color> from disk, but the system is saving the files. For not corrupt the system it can not happens" ); }
                }

            Heap_key heap_key = Controllers.heap.Change_length_key( _data_link.heap_key, _new_length );
            _data_link.heap_key = heap_key;

            Controllers.files.storage.current_files[ _data_link.id ] = _data_link;

            Controllers.stack.files.Save_data_change_length_file( _data_link.id, _new_length );

            return _data_link;

        }

    }


}