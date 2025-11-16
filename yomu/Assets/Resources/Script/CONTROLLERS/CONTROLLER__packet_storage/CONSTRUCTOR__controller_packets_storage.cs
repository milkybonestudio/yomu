
using System;
using System.Runtime.InteropServices;

unsafe public static class CONSTRUCTOR__controller_packets_storage{

    public static void Construct( ref CONTROLLER__packets_storage _controller_pointer ){

        // --- VERIFICATIONS


        int necessary_info_buffer = ( sizeof( Packet_storage_info ) * (int) Packet_storage_size.END );
        if( Packet_storage.LENGTH_INFO_BUFFER <= necessary_info_buffer )
            { CONTROLLER__errors.Throw( $"The buffer in the packet_storage needs <Color=lightBlue>{ necessary_info_buffer }</Color> but the CONST is <Color=lightBlue>{ Packet_storage.LENGTH_INFO_BUFFER }</Color>" ); }

        
        _controller_pointer.sizes.Start();
        _controller_pointer.creation.Start();
        _controller_pointer.defaults.Start();

        // SIMPLE

        if( System_run.show_big_ram_performance_impact_LONGER )
            { 
                Console.Log( $"packet_controller is very poor optimize");
                // ** vai usar o mesmo para todos os saves e para o program
                // ** a primeira optimizacao seria separar program e saves
                // ** depois separar em mais arquivos para cada save
                // ** quanto mais o jogo cresce pior esse arquivo ficaria 
            }
        
        
        // _controller_pointer.packet_storage_SIMPLE = Construct_SIMPLE_packed_storage_file( Paths_program.packet_storage_SIMPLE );

        // _controller_pointer.packet_storage_SIMPLE = Controllers.packets.Get_packet_storage( Paths_program.packet_storage_SIMPLE );
        
        

        return;

    }

    // --- SIMPLE

    public static Packet_storage* Construct_SIMPLE_packed_storage_file( string _path ){

        // ** porque isso existe?

        Packet_storage_start_data _start_data = Get_SIMPLE_args();
        int file_length = _start_data.Get_file_length();
        Data_file_link file_data_link = Controllers.files.Create_file( _path, file_length );
        Packet_storage* packed_storage = Controllers.packets.creation.Create( file_data_link, _start_data );

        return packed_storage;
        
    }


    public static Packet_storage* Construct_SIMPLE_packed_storage_file( void* _pointer, int _max_length ){

        Packet_storage* packed_storage;
        try{

            Packet_storage_start_data _start_data = Get_SIMPLE_args();
            int file_length = _start_data.Get_file_length();
            
            if( file_length > _max_length )
                { CONTROLLER__errors.Throw( $"Can not create the Packet_storage, the max value for the pointer is <Color=lightBlue>{ _max_length }</Color>" ); }

            packed_storage = Controllers.packets.creation.Apply_create_data( _pointer, _start_data );

        }
        finally {

            Console.Log( "passou" );

        }

        return packed_storage;
        
    }


    private static Packet_storage_start_data Get_SIMPLE_args(){

        int FILE_START_LENGTH = 1_000_000;

        Packet_storage_start_data_PER_SIZE[] sizes = new Packet_storage_start_data_PER_SIZE[]{

            new(){ size = Packet_storage_size._1_byte,     slots_to_need_up = 500, slots = 5_000,  slots_add_per_expansion = 150  },
            new(){ size = Packet_storage_size._2_bytes,    slots_to_need_up = 500, slots = 5_000,  slots_add_per_expansion = 150  },
            new(){ size = Packet_storage_size._3_bytes,    slots_to_need_up = 500, slots = 5_000,  slots_add_per_expansion = 150  },
            new(){ size = Packet_storage_size._4_bytes,    slots_to_need_up = 500, slots = 5_000,  slots_add_per_expansion = 100  },
            new(){ size = Packet_storage_size._5_bytes,    slots_to_need_up = 500, slots = 5_000,  slots_add_per_expansion = 100  },
            new(){ size = Packet_storage_size._10_bytes,   slots_to_need_up = 250, slots = 4_000,  slots_add_per_expansion = 100  },
            new(){ size = Packet_storage_size._20_bytes,   slots_to_need_up = 250, slots = 4_000,  slots_add_per_expansion = 100  },
            new(){ size = Packet_storage_size._40_bytes,   slots_to_need_up = 250, slots = 3_000,  slots_add_per_expansion = 100  },
            new(){ size = Packet_storage_size._60_bytes,   slots_to_need_up = 250, slots = 3_000,  slots_add_per_expansion = 75   },
            new(){ size = Packet_storage_size._80_bytes,   slots_to_need_up = 100, slots = 2_000,  slots_add_per_expansion = 75   },
            new(){ size = Packet_storage_size._120_bytes,  slots_to_need_up = 100, slots = 2_000,  slots_add_per_expansion = 75   },
            new(){ size = Packet_storage_size._160_bytes,  slots_to_need_up = 100, slots = 1_500,  slots_add_per_expansion = 75   },
            new(){ size = Packet_storage_size._200_bytes,  slots_to_need_up = 100, slots = 1_500,  slots_add_per_expansion = 50   },

            new(){ size = Packet_storage_size._250_bytes,  slots_to_need_up = 100, slots = 700,  slots_add_per_expansion = 50    },
            new(){ size = Packet_storage_size._300_bytes,  slots_to_need_up = 100, slots = 500,  slots_add_per_expansion = 25    },
            new(){ size = Packet_storage_size._350_bytes,  slots_to_need_up = 100, slots = 500,  slots_add_per_expansion = 25    },
            new(){ size = Packet_storage_size._400_bytes,  slots_to_need_up = 100, slots = 300,  slots_add_per_expansion = 25    },
            new(){ size = Packet_storage_size._500_bytes,  slots_to_need_up = 75,  slots = 300,  slots_add_per_expansion = 25    },
            new(){ size = Packet_storage_size._700_bytes,  slots_to_need_up = 75,  slots = 150,  slots_add_per_expansion = 15    },
            new(){ size = Packet_storage_size._900_bytes,  slots_to_need_up = 75,  slots = 150,  slots_add_per_expansion = 15    },
            new(){ size = Packet_storage_size._1000_bytes, slots_to_need_up = 30,  slots = 65,  slots_add_per_expansion = 15    },
            new(){ size = Packet_storage_size._1500_bytes, slots_to_need_up = 30,  slots = 65,  slots_add_per_expansion = 15    },
            new(){ size = Packet_storage_size._2000_bytes, slots_to_need_up = 15,  slots = 35,  slots_add_per_expansion = 10    },
            new(){ size = Packet_storage_size._3000_bytes, slots_to_need_up = 15,  slots = 35,  slots_add_per_expansion = 10    },
            new(){ size = Packet_storage_size._4000_bytes, slots_to_need_up = 7,   slots = 25,  slots_add_per_expansion = 7    },
            new(){ size = Packet_storage_size._5000_bytes, slots_to_need_up = 7,   slots = 25,  slots_add_per_expansion = 7    },
            new(){ size = Packet_storage_size._10_kb,      slots_to_need_up = 4,   slots = 15,  slots_add_per_expansion = 4    },
            new(){ size = Packet_storage_size._15_kb,      slots_to_need_up = 3,   slots = 8,  slots_add_per_expansion = 3    },
            new(){ size = Packet_storage_size._20_kb,      slots_to_need_up = 2,   slots = 8,  slots_add_per_expansion = 2    },
            new(){ size = Packet_storage_size._25_kb,      slots_to_need_up = 2,   slots = 8,  slots_add_per_expansion = 2    },
            new(){ size = Packet_storage_size._40_kb,      slots_to_need_up = 1,   slots = 6,  slots_add_per_expansion = 2    },
            new(){ size = Packet_storage_size._55_kb,      slots_to_need_up = 1,   slots = 5,  slots_add_per_expansion = 1    },
            new(){ size = Packet_storage_size._70_kb,      slots_to_need_up = 1,   slots = 5,  slots_add_per_expansion = 1    },
            new(){ size = Packet_storage_size._100_kb,     slots_to_need_up = 1,   slots = 2,  slots_add_per_expansion = 1    },

        };

        return new Packet_storage_start_data(){
            sizes_settings = sizes,
            file_start_length = FILE_START_LENGTH
        };
        
    }





}