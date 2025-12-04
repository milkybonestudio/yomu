
using System;
using System.Runtime.InteropServices;

unsafe public static class CONSTRUCTOR__controller_packets_storage{

    public static void Construct( ref CONTROLLER__packets_storage _controller_pointer ){

        // --- VERIFICATIONS


        int necessary_info_buffer = ( sizeof( Packet_storage_info ) * (int) Packet_storage_size.END );
        if( Packet_storage.LENGTH_INFO_BUFFER <= necessary_info_buffer )
            { CONTROLLER__errors.Throw( $"The buffer in the packet_storage needs <Color=lightBlue>{ necessary_info_buffer }</Color> but the CONST is <Color=lightBlue>{ Packet_storage.LENGTH_INFO_BUFFER }</Color>" ); }

        
        _controller_pointer.operations = MANAGER__controller_packet_storage_operations.Construct();
        _controller_pointer.storage = MANAGER__controller_packet_storage_storage.Construct();

        _controller_pointer.sizes.Start();
        _controller_pointer.creation = MANAGER__packet_storage_creation.Construct();
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
        
        
        

        return;

    }




    public static Packet_storage_start_data Get_SIMPLE_args(){

        int FILE_START_LENGTH = 4_500_000;

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
            new(){ size = Packet_storage_size._200_bytes,  slots_to_need_up = 100, slots = 1_000,  slots_add_per_expansion = 50   },

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
            new(){ size = Packet_storage_size._40_kb,      slots_to_need_up = 1,   slots = 6,  slots_add_per_expansion = 1    },
            new(){ size = Packet_storage_size._55_kb,      slots_to_need_up = 1,   slots = 2,  slots_add_per_expansion = 1    },
            new(){ size = Packet_storage_size._70_kb,      slots_to_need_up = 0,   slots = 1,  slots_add_per_expansion = 1    },
            new(){ size = Packet_storage_size._100_kb,     slots_to_need_up = 0,   slots = 1,  slots_add_per_expansion = 1    },

        };

        return new Packet_storage_start_data(){
            sizes_settings = sizes,
            file_start_length = FILE_START_LENGTH
        };
        
    }





}