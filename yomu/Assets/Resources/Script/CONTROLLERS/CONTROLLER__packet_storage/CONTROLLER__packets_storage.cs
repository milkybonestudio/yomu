
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

            foreach( Data_file_link file in storage.list_data_files_packets ){

                var storage = (Packets_storage_data*) file.Get_pointer();

                if( storage->Update() )
                    { break; }
                
            }

        }

    }

    
    #if !UNITY_EDITOR
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
    #endif
    public Packets_storage_data* Get_pointer( Data_file_link _data ){

        return (Packets_storage_data*) _data.Get_pointer();
    }




    public void Reset(){

        storage.Reset();
    }


    public void Destroy(){

        sizes.Destroy();

        creation.Destroy();
        defaults.Destroy();
        

    }

    public void Give_context( Program_context _context ){

        int[] packets_storages_ids = _context.current_packets_storages;

        foreach( int id in packets_storages_ids ){

            if( storage.Is_storage_already_taken( new Data_file_link(){ id = id } ) )
                { continue; }

            Data_file_link data = Controllers.files.operations.Get_file( id );
            storage.Add_storage( data );
        }


    }

}

