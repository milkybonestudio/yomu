

unsafe public struct MANAGER__packet_storage_creation {

    public static MANAGER__packet_storage_creation Construct(){ return new(); }    
    public void Destroy(){}


    public void Apply_create_data( void* _pointer, int _pointer_max_length, Packet_storage_start_data _start_data ){

        // info:[   dados necessario  ]  -> [ keys free ][ all keys flags ][ data ]

        if( System_run.max_security )
            {
                if( _start_data.sizes_settings == null )
                    { CONTROLLER__errors.Throw( "sizes setiings came null" ); }

                if( _start_data.Get_file_length() > _pointer_max_length )
                    { CONTROLLER__errors.Throw( $"Tried to construct packed storage but the size required is <Color=lightBlue>{ _start_data.Get_file_length() }</Color> but the max length of the pointer is <Color=lightBlue>{ _pointer_max_length }</Color>" ); }
            }

                
        Packets_storage_data* packets_storage = ( Packets_storage_data* ) _pointer;

        // ** GET FINAL SETTINGS
        Packet_storage_start_data default_args = Controllers.packets.defaults.Get_default_args();
        
        for( int index = 0 ; index < (int) Packet_storage_size.END ; index++  ){ 

            Packet_storage_start_data_PER_SIZE data = _start_data.sizes_settings[ index ];

            if( System_run.max_security )
                { data.Guarantee_size_make_sense(); }

            if( !!!( data.used ) )
                { _start_data.sizes_settings[ index ] = default_args.sizes_settings[ index ]; }

        }

        Packet_storage_start_data correct_data = _start_data;
        Packet_storage_start_data_PER_SIZE[] correct_data_per_size_array = correct_data.sizes_settings;


        int last_byte_of_buffer_pointer = (int)&((Packets_storage_data*)null)->infos_buffer[ Packets_storage_data.LENGTH_INFO_BUFFER - 1 ];
        int current_pointer = ( last_byte_of_buffer_pointer + 1 );

        int* sizes = Controllers.packets.sizes.sizes;
        Packet_storage_info* infos = (Packet_storage_info*) packets_storage->infos_buffer;

        // Console.Log( "size type: " + sizeof( Packet_storage ) );
        
        for( int index = ( int ) Packet_storage_size._1_byte ; index < ( int ) Packet_storage_size._MAX ; index++  )
            { infos[ index ].Applay_start_data( correct_data_per_size_array[ index ], _pointer, &current_pointer, sizes[ index ] ); }




        return;

    }


}