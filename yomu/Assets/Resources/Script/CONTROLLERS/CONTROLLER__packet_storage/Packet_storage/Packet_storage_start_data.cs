
unsafe public class Packet_storage_start_data {

    public int file_start_length;
    public Packet_storage_start_data_PER_SIZE[] sizes_settings;

    // public Packet_storage_size size;
    // public int slots;
    
    // public int slots_to_need_up;
    // public int slots_add_per_expansion;


    public int Get_file_length(){

        
        int minimum_size = Get_minimun_size();
        if( minimum_size > file_start_length )
            { CONTROLLER__errors.Throw( $"Asked to create a packet_storage but asked to create with a size of <Color=lightBlue>{ Formater.Format_number( file_start_length ) }</Color> but it needs at least <Color=lightBlue>{ Formater.Format_number( minimum_size ) }</Color>" ); }

        return file_start_length;


    }

    public int Get_minimun_size(){


        Console.Log( "Vai iniciar" );
        int minimum_space = sizeof( Packet_storage );
        Console.Log( "minimum_space: " + minimum_space );

        foreach( Packet_storage_start_data_PER_SIZE size_data in sizes_settings ){

            int size_bytes = Controllers.packets.sizes.Get_size_in_bytes( size_data.size );

            int flags_size = size_data.slots;
            int content_size = ( size_data.slots * size_bytes );

            int size_length = ( flags_size + content_size );

            Console.Log( $"size { size_data.size } vai adicionar { size_length } totalizando { minimum_space }" );
            minimum_space += size_length;

        }

        return minimum_space;

    }



}

