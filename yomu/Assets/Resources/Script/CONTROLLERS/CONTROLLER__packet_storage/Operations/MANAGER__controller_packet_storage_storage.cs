


using System;
using System.Collections.Generic;
using System.Linq;

unsafe public struct MANAGER__controller_packet_storage_storage {

    public static MANAGER__controller_packet_storage_storage Construct(){

        MANAGER__controller_packet_storage_storage ret = default;

            ret.list_data_files_packets = new HashSet<Data_file_link>();
            
        return ret;

    }


    public void End(){}

    public HashSet<Data_file_link> list_data_files_packets;
    

    public void Reset(){

        list_data_files_packets.Clear();
        
    }

    public int[] Get_current_ids(){

        int[] ids = list_data_files_packets.Select( x => x.id ).ToArray<int>();
        Array.Sort( ids );
        
        return ids;

    }

    public bool Is_storage_already_taken( Data_file_link _file_data_link ){

        return list_data_files_packets.Contains( _file_data_link );

    }

    public void Add_storage( Data_file_link _data ){

        if( list_data_files_packets.Contains( _data ) )
            { CONTROLLER__errors.Throw( $"Tried to add file <Color=lightBlue>{ _data.id }</Color> but it was already in the list" ); }

        list_data_files_packets.Add( _data );
        
        Controllers.stack.packet_storage.Save_data_add_storage( _data.id );

    }


    public void Remove_storage( Data_file_link _data ){

        list_data_files_packets.Remove( _data );
        
    }

    


}