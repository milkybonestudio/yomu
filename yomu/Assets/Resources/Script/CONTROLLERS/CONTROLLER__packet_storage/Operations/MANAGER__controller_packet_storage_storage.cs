


using System;
using System.Collections.Generic;

unsafe public struct MANAGER__controller_packet_storage_storage {

    public static MANAGER__controller_packet_storage_storage Construct(){

        MANAGER__controller_packet_storage_storage ret = default;
            
        return ret;

    }


    public void End(){

        

    }

    public List<Data_file_link> list_data_files_packets;

    public bool Have_data( Data_file_link _file_data_link ){

        return list_data_files_packets.Have_value( _file_data_link );

    }

    public void Add_storage( Data_file_link _data ){

        list_data_files_packets.Add( _data );

    }


    public void Remove_storage( Data_file_link _data ){

        list_data_files_packets.Remove( _data );

    }

    


    // public Dictionary<Data_file_link>




}