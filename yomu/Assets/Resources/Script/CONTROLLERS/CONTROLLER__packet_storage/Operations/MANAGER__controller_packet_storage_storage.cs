


using System;
using System.Collections.Generic;
using System.Linq;

unsafe public struct MANAGER__controller_packet_storage_storage {

    public static MANAGER__controller_packet_storage_storage Construct(){

        MANAGER__controller_packet_storage_storage ret = default;

            ret.list_data_files_packets = new List<Data_file_link>( 0 );
            ret.pointers = new Dictionary<int, long>();
            
        return ret;

    }


    public void End(){}



    public List<Data_file_link> list_data_files_packets;

    //mark
    // ** vai ter que ser por data_link, pointer pode ficar com o valor errado
    // ** se o arquivo mudar de tamanho
    public Dictionary<int,long> pointers;

    public void Reset(){

        list_data_files_packets.Reset();
        pointers.Clear();

    }

    public int[] Get_current_ids(){

        int[] ids = list_data_files_packets.values.Select( x => x.id ).ToArray<int>();
        Array.Sort( ids );
        // Console.Log( ids.ToString() );

        return ids;

    }

    public bool Have_data( Data_file_link _file_data_link ){

        return list_data_files_packets.Have_value( _file_data_link );

    }

    public void Add_storage( Data_file_link _data ){

        // Console.Log( "vai adicionar " + _data.id );

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