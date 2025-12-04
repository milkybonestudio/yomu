
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;


unsafe public struct CONTROLLER__packets_storage {


    public MANAGER__controller_packet_storage_operations operations;
    public MANAGER__controller_packet_storage_storage storage;

    public MANAGER__packet_storage_sizes sizes;
    public MANAGER__packet_storage_creation creation;
    public MANAGER__packet_storage_defaults defaults;


    public void Update(){

        lock( operations.lock_obj ){

            foreach( Data_file_link file in storage.list_data_files_packets.values ){

                var storage = (Packet_storage*) file.Get_pointer();

                if( storage->Update() )
                    { break; }
                
            }

        }

    }

    

    


    // ** Assume the storege already exist in disk
    public Packet_storage* Get_from_disk( string _path_to_file ){
        
        Data_file_link file_data_link = Controllers.files.operations.Get_file( _path: _path_to_file );
        Packet_storage* storage = Packet_storage.Start( file_data_link );
        return storage;
        
    }


    // // ** create a new file
    // public Packet_storage* Create_new( string _path_to_file, Packet_storage_start_data _start_data ){

    //     int file_length = _start_data.Get_file_length();

    //     Data_file_link file_data_link_new_file = operations.Create_new_storage( _path_to_file, file_length, _start_data );

    //     // Data_file_link file_data_link_new_file = Controllers.files.operations.Create_new_file_EMPTY( _path_to_file, file_length );

    //         creation.Create_new_storage( file_data_link_new_file, _start_data );

    //     Packet_storage* storage =  Packet_storage.Start( file_data_link_new_file );

    //     return storage;

    // }



    public void Destroy(){

        sizes.Destroy();

        creation.Destroy();
        defaults.Destroy();
        

    }

    

}

