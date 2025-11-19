
public struct Packet_storage_start_data_PER_SIZE {

    public Packet_storage_size size;
    public int slots;
    
    public int slots_to_need_up;
    public int slots_add_per_expansion;

    public void Guarantee_size_make_sense(){

        
        return;Console.Log_slow( "remover depois" );

        int minimum_need_to_go_up = 1;
        int minimum_slots_add_per_expansion = 1;

        if( ( size >= Packet_storage_size._1_byte ) && ( size < Packet_storage_size._20_bytes) )
            {
                minimum_need_to_go_up = 50;
                minimum_slots_add_per_expansion = 50;
            }

        if( ( size >= Packet_storage_size._20_bytes ) && ( size < Packet_storage_size._200_bytes ) )
            {
                minimum_need_to_go_up = 10;
                minimum_slots_add_per_expansion = 10;
            }

        if( ( size >= Packet_storage_size._200_bytes ) && ( size < Packet_storage_size._1000_bytes ) )
            {
                minimum_need_to_go_up = 3;
                minimum_slots_add_per_expansion = 3;
            }

        if( ( size >= Packet_storage_size._1000_bytes ) && ( size < Packet_storage_size._4000_bytes ) )
            {
                minimum_need_to_go_up = 1;
                minimum_slots_add_per_expansion = 1;
            }

        if( slots_add_per_expansion < minimum_slots_add_per_expansion )
            { CONTROLLER__errors.Throw( $"In the Packet_storage_start_data_PER_SIZE but the slots_add_per_expansion is <Color=lightBlue>{ slots_add_per_expansion }</Color> but should be at least <Color=lightBlue>{ minimum_slots_add_per_expansion }</Color> with the size { size }" ); }

        if( slots_to_need_up < minimum_need_to_go_up )
            { CONTROLLER__errors.Throw( $"In the Packet_storage_start_data_PER_SIZE but the slots_to_need_up is <Color=lightBlue>{ slots_to_need_up }</Color> but should be at least <Color=lightBlue>{ minimum_need_to_go_up }</Color> with the size { size }" ); }

    }

}

