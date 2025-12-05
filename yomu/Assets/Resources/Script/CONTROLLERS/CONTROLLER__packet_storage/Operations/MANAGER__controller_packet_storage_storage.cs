


using System;
using System.Collections.Generic;

unsafe public struct MANAGER__controller_packet_storage_storage {

    public static MANAGER__controller_packet_storage_storage Construct(){

        MANAGER__controller_packet_storage_storage ret = default;

            ret.list_data_files_packets = new List<Data_file_link>( 10 );
            ret.pointers = new Dictionary<int, long>( 10 );
            
        return ret;

    }


    public void End(){

        

    }

    public List<Data_file_link> list_data_files_packets;
    public Dictionary<int,long> pointers;

    public bool Have_data( Data_file_link _file_data_link ){

        return list_data_files_packets.Have_value( _file_data_link );

    }

    public void Add_storage( Data_file_link _data ){

        list_data_files_packets.Add( _data );

        if( pointers.ContainsKey( _data.id ) )
            { CONTROLLER__errors.Throw( $"Already have a file for the id <Color=lightBlue>{ _data.id }</Color>" ); }

        pointers[ _data.id ] = ( long ) _data.Get_pointer();

    }


    public void Remove_storage( Data_file_link _data ){

        list_data_files_packets.Remove( _data );
        pointers.Remove( _data.id );

    }

    


    // public Dictionary<Data_file_link>




}