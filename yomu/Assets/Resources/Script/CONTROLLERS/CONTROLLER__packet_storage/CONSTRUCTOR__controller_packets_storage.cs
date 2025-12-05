
using System;
using System.Runtime.InteropServices;

unsafe public static class CONSTRUCTOR__controller_packets_storage{

    public static CONTROLLER__packets_storage Construct(){

        // --- VERIFICATIONS


        int necessary_info_buffer = ( sizeof( Packet_storage_info ) * (int) Packet_storage_size.END );

        if( Packets_storage_data.LENGTH_INFO_BUFFER <= necessary_info_buffer )
            { CONTROLLER__errors.Throw( $"The buffer in the packet_storage needs <Color=lightBlue>{ necessary_info_buffer }</Color> but the CONST is <Color=lightBlue>{ Packets_storage_data.LENGTH_INFO_BUFFER }</Color>" ); }

        
        CONTROLLER__packets_storage ret = default;

            ret.operations = MANAGER__controller_packet_storage_operations.Construct();
            ret.storage = MANAGER__controller_packet_storage_storage.Construct();

            ret.sizes.Start();
            ret.creation = MANAGER__packet_storage_creation.Construct();
            ret.defaults.Start();

    
        
        if( System_run.show_big_ram_performance_impact_LONGER )
            { 
                Console.Log( $"packet_controller is very poor optimize");
                // ** vai usar o mesmo para todos os saves e para o program
                // ** a primeira optimizacao seria separar program e saves
                // ** depois separar em mais arquivos para cada save
                // ** quanto mais o jogo cresce pior esse arquivo ficaria 
            }
        
        
        

        return ret;

    }


    private static void Change_value( Packet_storage_start_data_PER_SIZE[] _sizes, Packet_storage_size _size, int _slots_to_need_up, int _slots, int _slots_add_per_expansion ){

        _sizes[ (int) _size ] = Packet_storage_start_data_PER_SIZE.Construct( _size, _slots, _slots_to_need_up, _slots_add_per_expansion );

    }

    public static Packet_storage_start_data Get_SIMPLE_args(){

        int FILE_START_LENGTH = 4_500_000;

        Packet_storage_start_data_PER_SIZE[] sizes = new Packet_storage_start_data_PER_SIZE[ (int) Packet_storage_size.END ];
        

            Change_value( _sizes: sizes, _size : Packet_storage_size._1_byte,     _slots_to_need_up : 500, _slots : 5_000,  _slots_add_per_expansion : 150  );
            Change_value( _sizes: sizes, _size : Packet_storage_size._2_bytes,    _slots_to_need_up : 500, _slots : 5_000,  _slots_add_per_expansion : 150  );
            Change_value( _sizes: sizes, _size : Packet_storage_size._3_bytes,    _slots_to_need_up : 500, _slots : 5_000,  _slots_add_per_expansion : 150  );
            Change_value( _sizes: sizes, _size : Packet_storage_size._4_bytes,    _slots_to_need_up : 500, _slots : 5_000,  _slots_add_per_expansion : 100  );
            Change_value( _sizes: sizes, _size : Packet_storage_size._5_bytes,    _slots_to_need_up : 500, _slots : 5_000,  _slots_add_per_expansion : 100  );
            Change_value( _sizes: sizes, _size : Packet_storage_size._10_bytes,   _slots_to_need_up : 250, _slots : 4_000,  _slots_add_per_expansion : 100  );
            Change_value( _sizes: sizes, _size : Packet_storage_size._20_bytes,   _slots_to_need_up : 250, _slots : 4_000,  _slots_add_per_expansion : 100  );
            Change_value( _sizes: sizes, _size : Packet_storage_size._40_bytes,   _slots_to_need_up : 250, _slots : 3_000,  _slots_add_per_expansion : 100  );
            Change_value( _sizes: sizes, _size : Packet_storage_size._60_bytes,   _slots_to_need_up : 250, _slots : 3_000,  _slots_add_per_expansion : 75   );
            Change_value( _sizes: sizes, _size : Packet_storage_size._80_bytes,   _slots_to_need_up : 100, _slots : 2_000,  _slots_add_per_expansion : 75   );
            Change_value( _sizes: sizes, _size : Packet_storage_size._120_bytes,  _slots_to_need_up : 100, _slots : 2_000,  _slots_add_per_expansion : 75   );
            Change_value( _sizes: sizes, _size : Packet_storage_size._160_bytes,  _slots_to_need_up : 100, _slots : 1_500,  _slots_add_per_expansion : 75   );
            Change_value( _sizes: sizes, _size : Packet_storage_size._200_bytes,  _slots_to_need_up : 100, _slots : 1_000,  _slots_add_per_expansion : 50   );

            Change_value( _sizes: sizes, _size : Packet_storage_size._250_bytes,  _slots_to_need_up : 100, _slots : 700,  _slots_add_per_expansion : 50    );
            Change_value( _sizes: sizes, _size : Packet_storage_size._300_bytes,  _slots_to_need_up : 100, _slots : 500,  _slots_add_per_expansion : 25    );
            Change_value( _sizes: sizes, _size : Packet_storage_size._350_bytes,  _slots_to_need_up : 100, _slots : 500,  _slots_add_per_expansion : 25    );
            Change_value( _sizes: sizes, _size : Packet_storage_size._400_bytes,  _slots_to_need_up : 100, _slots : 300,  _slots_add_per_expansion : 25    );
            Change_value( _sizes: sizes, _size : Packet_storage_size._500_bytes,  _slots_to_need_up : 75,  _slots : 300,  _slots_add_per_expansion : 25    );
            Change_value( _sizes: sizes, _size : Packet_storage_size._700_bytes,  _slots_to_need_up : 75,  _slots : 150,  _slots_add_per_expansion : 15    );
            Change_value( _sizes: sizes, _size : Packet_storage_size._900_bytes,  _slots_to_need_up : 75,  _slots : 150,  _slots_add_per_expansion : 15    );
            Change_value( _sizes: sizes, _size : Packet_storage_size._1000_bytes, _slots_to_need_up : 30,  _slots : 65,  _slots_add_per_expansion : 15    );
            Change_value( _sizes: sizes, _size : Packet_storage_size._1500_bytes, _slots_to_need_up : 30,  _slots : 65,  _slots_add_per_expansion : 15    );
            Change_value( _sizes: sizes, _size : Packet_storage_size._2000_bytes, _slots_to_need_up : 15,  _slots : 35,  _slots_add_per_expansion : 10    );
            Change_value( _sizes: sizes, _size : Packet_storage_size._3000_bytes, _slots_to_need_up : 15,  _slots : 35,  _slots_add_per_expansion : 10    );
            Change_value( _sizes: sizes, _size : Packet_storage_size._4000_bytes, _slots_to_need_up : 7,   _slots : 25,  _slots_add_per_expansion : 7    );
            Change_value( _sizes: sizes, _size : Packet_storage_size._5000_bytes, _slots_to_need_up : 7,   _slots : 25,  _slots_add_per_expansion : 7    );
            Change_value( _sizes: sizes, _size : Packet_storage_size._10_kb,      _slots_to_need_up : 4,   _slots : 15,  _slots_add_per_expansion : 4    );
            Change_value( _sizes: sizes, _size : Packet_storage_size._15_kb,      _slots_to_need_up : 3,   _slots : 8,  _slots_add_per_expansion : 3    );
            Change_value( _sizes: sizes, _size : Packet_storage_size._20_kb,      _slots_to_need_up : 2,   _slots : 8,  _slots_add_per_expansion : 2    );
            Change_value( _sizes: sizes, _size : Packet_storage_size._25_kb,      _slots_to_need_up : 2,   _slots : 8,  _slots_add_per_expansion : 2    );
            Change_value( _sizes: sizes, _size : Packet_storage_size._40_kb,      _slots_to_need_up : 1,   _slots : 6,  _slots_add_per_expansion : 1    );
            Change_value( _sizes: sizes, _size : Packet_storage_size._55_kb,      _slots_to_need_up : 1,   _slots : 2,  _slots_add_per_expansion : 1    );
            Change_value( _sizes: sizes, _size : Packet_storage_size._70_kb,      _slots_to_need_up : 0,   _slots : 1,  _slots_add_per_expansion : 1    );
            Change_value( _sizes: sizes, _size : Packet_storage_size._100_kb,     _slots_to_need_up : 0,   _slots : 1,  _slots_add_per_expansion : 1    );

        return new Packet_storage_start_data(){
            sizes_settings = sizes,
            file_start_length = FILE_START_LENGTH
        };
        
    }





}