
unsafe public class Packet_storage_start_data {

    public Packet_storage_start_data(){

        sizes_settings = new Packet_storage_start_data_PER_SIZE[ (int) Packet_storage_size.END ];

    }

    public int file_start_length;
    public Packet_storage_start_data_PER_SIZE[] sizes_settings;


    public int Get_file_length(){

        
        int minimum_size = Get_minimun_size();

        if( file_start_length == 0 )
            { file_start_length = ( ( minimum_size * 12 ) / 10 ); }

        if( minimum_size > file_start_length )
            { CONTROLLER__errors.Throw( $"Asked to create a packet_storage but asked to create with a size of <Color=lightBlue>{ Formater.Format_number( file_start_length ) }</Color> but it needs at least <Color=lightBlue>{ Formater.Format_number( minimum_size ) }</Color>" ); }

        return file_start_length;


    }

    public int Get_minimun_size(){


        int minimum_space = sizeof( Packets_storage_data );

        foreach( Packet_storage_start_data_PER_SIZE size_data in sizes_settings ){

            int size_bytes = Controllers.packets.sizes.Get_size_in_bytes( size_data.size );

            int flags_size = size_data.slots;
            int content_size = ( size_data.slots * size_bytes );

            int size_length = ( flags_size + content_size );

            if( System_run.packet_show_messages_full_detail )
                { Console.Log( $"size { size_data.size } vai adicionar { Formater.Format_number( size_length ) } totalizando { Formater.Format_number( minimum_space )  }" ); }

            minimum_space += size_length;

        }

        if( System_run.packet_show_messages_full_detail )
            { Console.Log( "minimum_space: " + minimum_space ); }
        

        return minimum_space;
        

    }



}

