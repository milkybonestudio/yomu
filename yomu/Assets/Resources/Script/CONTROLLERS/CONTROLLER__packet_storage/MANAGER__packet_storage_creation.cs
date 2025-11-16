

unsafe public struct MANAGER__packet_storage_creation {

    
    public void Start(){}
    public void Destroy(){}

    public Packet_storage* Create( Data_file_link _data_file_link, Packet_storage_start_data _start_data ){

        Controllers.stack.Need_to_add_stack_function();

        if( _start_data.sizes_settings == null )
            { CONTROLLER__errors.Throw( "sizes setiings came null" ); }

        Packet_storage* packet_storage = Apply_create_data( _data_file_link.heap_key.Get_pointer(), _start_data );

        Packet_storage.Start( _data_file_link );
        
        // ** já esta pronto para uso
        return packet_storage;

    }

    public Packet_storage* Apply_create_data( void* _pointer, Packet_storage_start_data _start_data ){

        // info:[   dados necessario  ]  -> [ keys free ][ all keys flags ][ data ]
                
        Packet_storage* packet_storage = ( Packet_storage* ) _pointer;
        Packet_storage_start_data default_args = Controllers.packets.defaults.Get_default_args();
        
        foreach( Packet_storage_start_data_PER_SIZE data in _start_data.sizes_settings ){ 

            if( System_run.max_security )
                { data.Guarantee(); }
            default_args.sizes_settings[ ( int ) data.size ] = data; 

        }


        Packet_storage_start_data correct_data = default_args;
        Packet_storage_start_data_PER_SIZE[] correct_data_per_size_array = correct_data.sizes_settings;

        int last_byte_of_buffer_pointer = (int)&((Packet_storage*)null)->infos_buffer[ Packet_storage.LENGTH_INFO_BUFFER - 1 ];
        int current_pointer = ( last_byte_of_buffer_pointer + 1 );

        int* sizes = Controllers.packets.sizes.sizes;
        Packet_storage_info* infos = (Packet_storage_info*) packet_storage->infos_buffer;

        Console.Log( "size type: " + sizeof( Packet_storage ) );
        
        for( int index = ( int ) Packet_storage_size._1_byte ; index < ( int ) Packet_storage_size._MAX ; index++  )
            { infos[ index ].Applay_start_data( correct_data_per_size_array[ index ], _pointer, &current_pointer, sizes[ index ] ); }

        return packet_storage;

    }


}