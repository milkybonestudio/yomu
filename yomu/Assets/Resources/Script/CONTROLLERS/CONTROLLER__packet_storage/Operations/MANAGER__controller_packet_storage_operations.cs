


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


    public Packets_storage Get_storage_from_disk( string _path_to_file ){

        lock( lock_obj ){

            Data_file_link file_data_link = Controllers.files.operations.Get_file_from_disk( _path_to_file );
            ((Packets_storage_data*)file_data_link.Get_pointer())->Set_from_disk();

            Controllers.packets.storage.Add_storage( file_data_link );
            return Packets_storage.Construct( file_data_link );

        }
        
    }



    public Packets_storage Create_new_storage( string _path, Packet_storage_start_data _start_data ){

        lock( lock_obj ){

            if( System_run.max_security )
                { 

                    if( Controllers.files.storage.File_exist_in_final_disk( _path ) )
                        { CONTROLLER__errors.Throw( $"Tried to create a storage but it alreadys exist. Path: <Color=lightBlue>{ _path }</Color>" );  }

                    if( !!!( Directories.Is_sub_path( _path, Paths_version.path_to_version ) ) )
                        { CONTROLLER__errors.Throw( $"Tried to create a storage file but the path is not part of the version: <Color=lightBlue>{ _path }</Color>" ); }

                    if( Controllers.saving.state == Saving_state.saving_files )
                        { CONTROLLER__errors.Throw( $"Tried to create a storage file <Color=lightBlue>{ _path }</Color> from disk, but the system is saving the files. For not corrupt the system it can not happens" ); }

                }

            Data_file_link data_link = Controllers.files.operations.Create_new_file_EMPTY( _path, _start_data.Get_file_length() );

            Controllers.packets.creation.Apply_create_data( data_link, _start_data );    
            Controllers.packets.storage.Add_storage( data_link );

            Controllers.stack.packet_storage.Save_data_create_storage( data_link.id, _start_data );

            return Packets_storage.Construct( data_link );

        }

    }

    
    public Packets_storage Get_storage( string _path_to_file ){

        lock( lock_obj ){

            Data_file_link file_data_link = Controllers.files.operations.Get_file( _path_to_file );
            
            if( System_run.max_security )
                {
                    Packets_storage_data* storage = (Packets_storage_data*) file_data_link.Get_pointer();

                    if( !!!( storage->Is_valid() ) )
                        { CONTROLLER__errors.Throw( $"did not start storage in path <Color=lightBlue>{ _path_to_file }</Color>" ); }
                }


            return Packets_storage.Construct( file_data_link );

        }
        
        
    }

    public void Remove_storage( Packets_storage _storage ){


        lock( lock_obj ){

            if( System_run.max_security )
                {
                    if( !!!( _storage.Is_valid() ) )
                        { CONTROLLER__errors.Throw( $"Tried to remove the storage with an invalid storage" ); }

                    if( !!!( Controllers.files.storage.Is_file_already_taken( _storage.data.id ) ) )
                        { CONTROLLER__errors.Throw( $"Tried to remove the storage with the id <Color=lightBlue>{ _storage.data.id }</Color> but it was not in the system" ); }
                    
                }

            Controllers.packets.storage.Remove_storage( _storage.data );
            Controllers.stack.packet_storage.Save_data_remove_storage( _storage.data.id );

            Controllers.files.operations.Remove_file( _storage.data );

            return;

        }

    }


    public void Delete_storage( Packets_storage _storage ){

        lock( lock_obj ){

            if( System_run.max_security )
                {
                    if( !!!( _storage.Is_valid() ) )
                        { CONTROLLER__errors.Throw( $"Tried to delete the storage with an invalid storage" ); }

                    if( !!!( Controllers.files.storage.File_exist_in_final_disk( _storage.data ) ) )
                        { CONTROLLER__errors.Throw( $"Tried to delete the storage with the id <Color=lightBlue>{ _storage.data.id }</Color> but the file don't exist in final disk" ); }   
                }

            Controllers.packets.storage.Remove_storage( _storage.data );
            Controllers.stack.packet_storage.Save_data_remove_storage( _storage.data.id );

            Controllers.files.operations.Delete_file( _storage.data );

            return;

        }

    }


}