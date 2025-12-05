


using System;

unsafe public struct MANAGER__controller_packet_storage_operations {

    public static MANAGER__controller_packet_storage_operations Construct(){

        MANAGER__controller_packet_storage_operations ret = default;
            ret.lock_obj = new object();
        return ret;

    }


    public void End(){

        lock_obj = null;

    }

    public Object lock_obj;

    // ** Assume the storege already exist in disk
    public Packets_storage_data* Get_storage_from_disk( string _path_to_file ){

        lock( lock_obj ){

            Data_file_link file_data_link = Controllers.files.operations.Get_file_from_disk( _path_to_file );
            Controllers.packets.storage.Add_storage( file_data_link );

            Packets_storage_data* storage = Packets_storage_data.Start( file_data_link );

            return storage;

        }
        
        
    }

    public Packets_storage_data* Get_storage( string _path_to_file ){

        lock( lock_obj ){


            Data_file_link file_data_link = Controllers.files.operations.Get_file( _path_to_file );
            
            Packets_storage_data* storage = (Packets_storage_data*) file_data_link.Get_pointer();

            if( System_run.max_security )
                {
                    if( !!!( storage->started ) )
                        { CONTROLLER__errors.Throw( $"did not start storage in path <Color=lightBlue>{ _path_to_file }</Color>" ); }

                    if( !!!( Controllers.packets.storage.Have_data( file_data_link ) ))
                        { CONTROLLER__errors.Throw( $"the data link was not in the list for the path: <Color=lightBlue>{ _path_to_file }</Color>" ); }
                }


            return storage;

        }
        
        
    }


    public Packets_storage_data* Create_new_storage( string _path, int _file_length, Packet_storage_start_data _start_data ){

    
        lock( lock_obj ){

            if( System_run.max_security )
                { 

                    if( Controllers.files.storage.File_exist_in_final_disk( _path ) )
                        { CONTROLLER__errors.Throw( $"Tried to create a storage but it alreadys exist. Path: <Color=lightBlue>{ _path }</Color>" );  }

                    if( _file_length == 0 )
                        { CONTROLLER__errors.Throw( $"Tried to create a storage file but the length is 0 " );  }

                    if( _file_length < 0 )
                        { CONTROLLER__errors.Throw( $"Tried to create a storage file but the length is negative:  " + _file_length );  }

                    if( !!!( Directories.Is_sub_path( _path, Paths_version.path_to_version ) ) )
                        { CONTROLLER__errors.Throw( $"Tried to create a storage file but the path is not part of the version: <Color=lightBlue>{ _path }</Color>" ); }

                    if( Controllers.saving.state == Saving_state.saving_files )
                        { CONTROLLER__errors.Throw( $"Tried to create a storage file <Color=lightBlue>{ _path }</Color> from disk, but the system is saving the files. For not corrupt the system it can not happens" ); }

                    if( _start_data.Get_file_length() > _file_length )
                        { CONTROLLER__errors.Throw( $"Tried to create a storage file but tried to create with <Color=lightBlue>{ _file_length }</Color>> bytes but it need at least <Color=lightBlue>{ _start_data.Get_file_length() }</Color>" ); }

                }

            
            Data_file_link data_link = Controllers.files.operations.Create_new_file_EMPTY( _path, _file_length );
            Controllers.packets.creation.Apply_create_data( data_link.heap_key.Get_pointer(), data_link.Get_length(), _start_data );

            Controllers.stack.packet_storage.Save_data_create_storage( data_link.id, _start_data );

            Packets_storage_data* storage = Packets_storage_data.Start( data_link );

            return storage;

        }

    }




}