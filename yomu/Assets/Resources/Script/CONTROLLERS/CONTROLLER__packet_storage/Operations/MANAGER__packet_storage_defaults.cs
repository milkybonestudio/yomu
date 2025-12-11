

using System;

unsafe public struct MANAGER__packet_storage_defaults {

    public void Start(){

        default_args = Create_default_args();
        public_default_args = Create_default_args();

        if(  System_run.max_security )
            { Check_default_args_values(); }

        return;

    }


    public Packet_storage_start_data Get_default_args(){

        Restore_values_in_public_defaults();
        return public_default_args; 

    }

    public void Destroy(){}

    // ** safity
    
    public Packet_storage_start_data public_default_args;
    private Packet_storage_start_data default_args;

    private void Restore_values_in_public_defaults(){

        if( default_args.sizes_settings == null )
            { CONTROLLER__errors.Throw( "Did not creat deafult_args" ); }

        if( public_default_args.sizes_settings == null )
            { CONTROLLER__errors.Throw( "Did not creat public_default_args" ); }


        for( int index_final = 0 ; index_final < default_args.sizes_settings.Length ; index_final++ )
            { public_default_args.sizes_settings[ index_final ] = default_args.sizes_settings[ index_final ]; }

        return ;

    }

    private Packet_storage_start_data Create_default_args(){

        int LENGTH_FILE = 500_000;

        Packet_storage_start_data_PER_SIZE[] sizes = new Packet_storage_start_data_PER_SIZE[]{

            // ** VIRTUAL ONLY
            new(){ size = Packet_storage_size._0_bytes,     slots_to_need_up = 100,  slots = 1_000 , slots_add_per_expansion =50  },

            new(){ size = Packet_storage_size._1_byte,     slots_to_need_up = 100,  slots = 1_000 , slots_add_per_expansion =50  },
            new(){ size = Packet_storage_size._2_bytes,    slots_to_need_up = 100,  slots = 500 , slots_add_per_expansion =50  },
            new(){ size = Packet_storage_size._3_bytes,    slots_to_need_up = 50,  slots = 500 , slots_add_per_expansion =50  },
            new(){ size = Packet_storage_size._4_bytes,    slots_to_need_up = 50,  slots = 500 , slots_add_per_expansion =50  },
            new(){ size = Packet_storage_size._5_bytes,    slots_to_need_up = 50,   slots = 300   , slots_add_per_expansion =50  },
            new(){ size = Packet_storage_size._10_bytes,   slots_to_need_up = 12,   slots = 50   , slots_add_per_expansion = 50  },
            new(){ size = Packet_storage_size._20_bytes,   slots_to_need_up = 50,   slots = 150   , slots_add_per_expansion =50  },
            new(){ size = Packet_storage_size._40_bytes,   slots_to_need_up = 50,   slots = 150   , slots_add_per_expansion =50  },
            new(){ size = Packet_storage_size._60_bytes,   slots_to_need_up = 20,   slots = 100   , slots_add_per_expansion =50  },
            new(){ size = Packet_storage_size._80_bytes,   slots_to_need_up = 10,   slots = 100   , slots_add_per_expansion =10  },
            new(){ size = Packet_storage_size._120_bytes,  slots_to_need_up = 10,   slots = 100   , slots_add_per_expansion =10  },
            
            new(){ size = Packet_storage_size._160_bytes,  slots_to_need_up = 10,   slots = 100   , slots_add_per_expansion =10  },
            new(){ size = Packet_storage_size._200_bytes,  slots_to_need_up = 10,   slots = 100   , slots_add_per_expansion =10  },
            new(){ size = Packet_storage_size._250_bytes,  slots_to_need_up = 5,   slots = 75   , slots_add_per_expansion =5  },
            new(){ size = Packet_storage_size._300_bytes,  slots_to_need_up = 5,   slots = 75   , slots_add_per_expansion =5  },
            new(){ size = Packet_storage_size._350_bytes,  slots_to_need_up = 5,   slots = 75   , slots_add_per_expansion =5  },
            new(){ size = Packet_storage_size._400_bytes,  slots_to_need_up = 5,   slots = 50  , slots_add_per_expansion =5  },
            new(){ size = Packet_storage_size._500_bytes,  slots_to_need_up = 5,   slots = 50  , slots_add_per_expansion =5  },
            new(){ size = Packet_storage_size._700_bytes,  slots_to_need_up = 5,   slots = 50  , slots_add_per_expansion =5  },
            new(){ size = Packet_storage_size._900_bytes,  slots_to_need_up = 5,   slots = 25  , slots_add_per_expansion =3  },
            new(){ size = Packet_storage_size._1000_bytes, slots_to_need_up = 5,   slots = 10  , slots_add_per_expansion =2  },

            new(){ size = Packet_storage_size._1500_bytes, slots_to_need_up = 1,   slots = 5   , slots_add_per_expansion =2  },
            new(){ size = Packet_storage_size._2000_bytes, slots_to_need_up = 1,   slots = 3   , slots_add_per_expansion =1  },
            new(){ size = Packet_storage_size._3000_bytes, slots_to_need_up = 1,   slots = 2   , slots_add_per_expansion =1  },
            new(){ size = Packet_storage_size._4000_bytes, slots_to_need_up = 1,   slots = 0   , slots_add_per_expansion =1  },
            new(){ size = Packet_storage_size._5000_bytes, slots_to_need_up = 1,   slots = 0   , slots_add_per_expansion =1  },
            new(){ size = Packet_storage_size._10_kb,      slots_to_need_up = 1,   slots = 0   , slots_add_per_expansion =1  },
            new(){ size = Packet_storage_size._15_kb,      slots_to_need_up = 1,   slots = 0   , slots_add_per_expansion =1  },
            new(){ size = Packet_storage_size._20_kb,      slots_to_need_up = 1,   slots = 0   , slots_add_per_expansion =1  },
            new(){ size = Packet_storage_size._25_kb,      slots_to_need_up = 1,   slots = 0   , slots_add_per_expansion =1  },
            new(){ size = Packet_storage_size._40_kb,      slots_to_need_up = 1,   slots = 0   , slots_add_per_expansion =1  },
            new(){ size = Packet_storage_size._55_kb,      slots_to_need_up = 1,   slots = 0   , slots_add_per_expansion =1  },
            new(){ size = Packet_storage_size._70_kb,      slots_to_need_up = 1,   slots = 0   , slots_add_per_expansion =1  },
            new(){ size = Packet_storage_size._100_kb,     slots_to_need_up = 1,   slots = 0   , slots_add_per_expansion =1  },

        };

        return new Packet_storage_start_data(){

            sizes_settings = sizes,
            file_start_length = LENGTH_FILE

        };

    }

    private void Check_default_args_values(){

        Packet_storage_size[] sizes = (Packet_storage_size[]) Enum.GetValues( typeof(Packet_storage_size) );

        // ** todos que não foram ENDS nao foram colocados
        foreach( Packet_storage_start_data_PER_SIZE data in default_args.sizes_settings )
            { sizes[ (int) data.size ] = Packet_storage_size.END; }

    
        for( int index = 0 ; index < (int) Packet_storage_size._MAX ; index++ ){

            if( sizes[ index ] != Packet_storage_size.END )
                { CONTROLLER__errors.Throw( $"The default args dont put the size <Color=lightBlue>{ (Packet_storage_size) index }</Color> in the right spot" ); }
        }

    }


    
}
