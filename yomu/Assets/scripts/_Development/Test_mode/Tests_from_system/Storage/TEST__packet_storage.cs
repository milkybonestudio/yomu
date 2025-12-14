using System.Threading.Tasks;
using UnityEngine;

unsafe public static class TEST__packet_storage {

/*        
    -> salvar/ler arquivo

    -> colocar dados
    -> trocar dados/length
    -> liberar slots
    -> pegar_dados
    -> pegar com pointer
    -> pegar com array de bytes/types



*/

  
    public static Packets_storage packet_storage;
    
    
    public static void Set(){

        if( packet_storage.Is_valid() )
            { Console.Log( "Didn't save the last packet_storage, lose the data" ); }

        packet_storage = default;
            packet_key_SIMPLE = default;
            packet_key_ARRAY = default;

        // packet_storage_pointer = null;
        packet_key_test = default;

        
    }

    public static Heap_key key;

    public static Packet_key packet_key;

    public static Packet_key packet_key_10;
    public static Packet_key packet_key_189;
    public static Packet_key packet_key_1_500;

    public static Packet_key packet_key_test;

    public static Packet_key packet_key_SIMPLE;
    public static Packet_key packet_key_ARRAY;

    public static Test_packet test_packet_simple_parcial;
    public static Test_packet test_packet_simple_complete;
    public static Test_packet test_packet_simple_overwrite;

    public static Test_packet test_packet_array;

    public static int file_length = 1_000_000;
    public static string path_to_packet_storage = $"{ Paths_system.persistent_data }\\packet_storage.dat"; 

    unsafe public struct Test_packet {

        
        public int a;
        public int b;

        public float c;
        
    }


    public static void Update(){


        Packets_storage_data p;
        Packet_key k;
        Packet pp;
        
        

        // ** FIX TESTS
        if( Input.GetKey( KeyCode.Keypad0 ) )
            {
                // ** create storage
                if( Input.GetKeyDown( KeyCode.Q ) )
                    {

                        

                    }

            }



        // ** I/O OPERATONS
        if( Input.GetKey( KeyCode.Keypad1 ) )
            {

                // ** carregar 
                if( Input.GetKeyDown( KeyCode.Q ) )
                    {

                        if( !!!( Controllers.files.storage.File_exist_in_final_disk( path_to_packet_storage ) ))
                            { Console.Log( "File didnt exist" ); return; }
                            
                        packet_storage = Controllers.packets.operations.Get_storage_from_disk( path_to_packet_storage );

                        Console.Log( "Load packet store" );
                        
                    }




                // ** criar
                if( Input.GetKeyDown( KeyCode.W ) )
                    {

                        if( packet_storage.Is_valid() )
                            { Console.Log( "already have the packet storage" ); return; }
                        
                        if( Controllers.files.storage.File_exist_in_final_disk( path_to_packet_storage ) )
                            { Console.Log( "Arquivo já existe" ); return; }

                        packet_storage = Controllers.packets.operations.Create_new_storage( path_to_packet_storage, Controllers.packets.defaults.Get_default_args() );
                        
                        Console.Log( "Created packet store" );
                        
                    }

                // ** salvar
                if( Input.GetKeyDown( KeyCode.E ) )
                    {

                        if( !!!( packet_storage.Is_valid() ) )
                            { Console.Log( "didnt have any store_packet" ); return; }

                        
                        Controllers.packets.operations.Remove_storage( packet_storage );
                        Controllers.saving.saver.Force_save_synchronous_safe();

                        
                        
                    }


                // ** zerar
                if( Input.GetKeyDown( KeyCode.R ) )
                    {

                        if( packet_storage.Is_valid() )
                            { Controllers.packets.operations.Delete_storage( packet_storage ); }
                            
                        if( Controllers.files.storage.File_exist_in_final_disk( path_to_packet_storage ) )
                            { Controllers.files.operations.Delete_file( path_to_packet_storage ); }

                        Controllers.saving.saver.Force_save_synchronous_safe(); 
                        Console.Log( "Removed all data" );
                    }

            }


        // printing
        if( Input.GetKey( KeyCode.P ) )
            {

                if( Input.GetKeyDown( KeyCode.Q ) )
                    { 
                        packet_storage.Get_pointer()->Print_actives( Packet_storage_size._10_bytes ); 
                        packet_storage.Get_pointer()->Print_flags( Packet_storage_size._10_bytes );
                        packet_storage.Get_pointer()->Print_data( Packet_storage_size._10_bytes );
                    }

                if( Input.GetKeyDown( KeyCode.W ) )
                    { 
                        packet_storage.Get_pointer()->Print_actives( Packet_storage_size._200_bytes ); 
                        packet_storage.Get_pointer()->Print_flags( Packet_storage_size._200_bytes );
                        packet_storage.Get_pointer()->Print_data( Packet_storage_size._200_bytes );
                        
                    }

                if( Input.GetKeyDown( KeyCode.E ) )
                    { 
                        packet_storage.Get_pointer()->Print_actives( Packet_storage_size._1500_bytes ); 
                        packet_storage.Get_pointer()->Print_flags( Packet_storage_size._1500_bytes );
                        packet_storage.Get_pointer()->Print_data( Packet_storage_size._1500_bytes );
                    }

                
            }





        // OPERATIONS
        if( Input.GetKey( KeyCode.Keypad2 ) )
            {


                // 10 BYTES

                    // ** ALLOC 
                    if( Input.GetKeyDown( KeyCode.Q ) )
                        {
                            // Guarantee_pointer();
                            packet_key_10 = packet_storage.Alloc_packet( 10 );
                            Console.Log( "slot: " +  packet_key_10.slot );
                        }


                    // ** DEALLOCATE key
                    if( Input.GetKeyDown( KeyCode.W ) )
                        {
                            // Guarantee_pointer();
                            packet_storage.Dealloc_packet( packet_key_10 );
                            packet_key_10 = default;
                        }



                    // ** ALLOC + DEALLOCATE key
                    if( Input.GetKeyDown( KeyCode.E ) )
                        {
                            packet_key_10 = packet_storage.Alloc_packet( 10 );
                            packet_storage.Dealloc_packet( packet_key_10 );
                    }

                // 189 BYTES

                    
                    if( Input.GetKeyDown( KeyCode.A ) )
                        {
                            // Guarantee_pointer();
                            packet_key_189 = packet_storage.Alloc_packet( 189 );
                            Console.Log( "slot: " +  packet_key_189.slot );
                        }


                    // ** DEALLOCATE key
                    if( Input.GetKeyDown( KeyCode.S ) )
                        {
                            // Guarantee_pointer();
                            packet_storage.Dealloc_packet( packet_key_189 );
                            packet_key_189 = default;
                        }



                    // ** ALLOC + DEALLOCATE key
                    if( Input.GetKeyDown( KeyCode.D ) )
                        {
                            packet_key_189 = packet_storage.Alloc_packet( 200 );
                            packet_storage.Dealloc_packet( packet_key_189 );
                        }

                // 1500 BYTES

                    
                    if( Input.GetKeyDown( KeyCode.Z ) )
                        {
                            // Guarantee_pointer();
                            packet_key_1_500 = packet_storage.Alloc_packet( 1_500 );
                            Console.Log( "slot: " +  packet_key_1_500.slot );
                        }


                    // ** DEALLOCATE key
                    if( Input.GetKeyDown( KeyCode.X ) )
                        {
                            // Guarantee_pointer();
                            packet_storage.Dealloc_packet( packet_key_1_500 );
                            packet_key_1_500 = default;
                        }



                    // ** ALLOC + DEALLOCATE key
                    if( Input.GetKeyDown( KeyCode.C ) )
                        {
                            packet_key_1_500 = packet_storage.Alloc_packet( 1_500 );
                            packet_storage.Dealloc_packet( packet_key_1_500 );
                        }

                return;

            }






        // OPERATIONS
        if( Input.GetKey( KeyCode.Keypad3 ) )
            {

                // ** FORCE EXPAND

                    if( Input.GetKeyDown( KeyCode.Q ) )
                        { packet_storage.Force_expand( Packet_storage_size._10_bytes ); }

                    
                    if( Input.GetKeyDown( KeyCode.W ) )
                        { packet_storage.Force_expand( Packet_storage_size._200_bytes ); }

                    
                    if( Input.GetKeyDown( KeyCode.E ) )
                        { packet_storage.Force_expand( Packet_storage_size._1500_bytes ); }

            }



        // ** PACKETS
        if( Input.GetKey( KeyCode.Keypad4 ) )
            {
                if( !!!( packet_storage.Is_valid() ) )
                    { Console.Log( "Dont have packet storage" );  return;  }

                if( !!!( packet_key_SIMPLE.Is_valid() ) )
                    { packet_key_SIMPLE = packet_storage.Alloc_packet( sizeof( Test_packet ) ); }

                if( !!!( packet_key_ARRAY.Is_valid() ) )
                    { packet_key_ARRAY = packet_storage.Alloc_packet_array<Test_packet>( 10 ); }

                // ** SIMPLE

                    // ** PARTIAL
                    if( Input.GetKeyDown( KeyCode.Q ) )
                        {

                            // ** TYPE 1
                                Packet packet = packet_storage.Get_packet( packet_key_SIMPLE );
                            // ** TYPE 2
                                Packet packet_2 = packet_key_SIMPLE.Get_packet(); 

                            Test_packet* pointer = packet.Get_pointer_partial<Test_packet>();

                                packet.Change( &pointer->a, ( pointer->a + 10 ) );
                                packet.Change<int>( &pointer->b, ( pointer->b + 5 ) );
                                packet.Change( &pointer->c, ( pointer->c + 5 ) );
                                
                            Console.Log( packet_storage.Get_value<Test_packet>( packet_key_SIMPLE ).a );

                            
                        }

                    // ** COMPLETE
                    if( Input.GetKeyDown( KeyCode.W ) )
                        {

                            Packet packet = packet_storage.Get_packet( packet_key_SIMPLE );
                            Test_packet* pointer = packet.Get_pointer_complete<Test_packet>();

                                pointer->a += 10;
                                pointer->b += 5;
                        
                            packet.Finish_use();

                            Console.Log( packet_key_SIMPLE.Get_value<Test_packet>().a );

                        }

                    // ** OVERWRITE
                    if( Input.GetKeyDown( KeyCode.E ) )
                        {
                            packet_storage.Overwrite_packet<Test_packet>( packet_key_SIMPLE, new(){
                                a = test_packet_simple_overwrite.a + 4,
                                b = test_packet_simple_overwrite.b + 4,
                                c = test_packet_simple_overwrite.c + 4
                                
                            });

                            Console.Log( packet_key_SIMPLE.Get_value<Test_packet>().a );

                            packet_key_SIMPLE.Overwrite<Test_packet>(new(){
                                a = 14,
                                b = 78,
                                c = 2f
                            });

                        }

                // ** ARRAY

                    // ** PARTIAL
                    if( Input.GetKeyDown( KeyCode.A ) )
                        {

                            Packet_array<Test_packet> dados =  packet_storage.Get_packet_array<Test_packet>( packet_key_ARRAY );

                            for( int index = 0 ; index < dados.length ; index++ ){

                                Test_packet* pointer = dados.Get_element_parcial( index );

                                    dados.Add( &pointer->a, index );
                                    Console.Log( ( dados.Get_value( index ).a ) );
                                
                            }
                            
                        }

                    // ** COMPLETE
                    if( Input.GetKeyDown( KeyCode.S ) )
                        {

                            Packet_array<Test_packet> dados =  packet_storage.Get_packet_array<Test_packet>( packet_key_ARRAY );

                            for( int index = 0 ; index < dados.length ; index++ ){

                                Test_packet* pointer = dados.Get_element_complete( index );

                                    pointer->a += 10;
                                    Console.Log( ( dados.Get_value( index ).a ) );

                                dados.Finish_use();
                                
                            }


                            Test_packet[] arr = new Test_packet[ 10 ];

                            for( int index_2 = 0 ; index_2 < arr.Length; index_2++  ){

                                arr[ index_2  ].a += 10;
                                
                            }

                        }

                    // ** OVERWRITE 1 INDIVIDUAL 
                    if( Input.GetKeyDown( KeyCode.D ) )
                        {

                            for( int index = 0 ; index < packet_key_ARRAY.length / sizeof(Test_packet) ; index++ ){

                                packet_key_ARRAY.Overwrite_packet_array<Test_packet>( index, new Test_packet(){ a = 17 }  );
                                packet_storage.Overwrite_packet_array<Test_packet>( packet_key_ARRAY, index, new Test_packet(){ a = 17 } );

                                Console.Log( ( packet_key_ARRAY.Get_value_array<Test_packet>( index ).a ) );
                                
                            }

                        }

                    // ** OVERWRITE 
                    if( Input.GetKeyDown( KeyCode.S ) )
                        {

                            Packet_array<Test_packet> dados = packet_storage.Get_packet_array<Test_packet>( packet_key_ARRAY );

                            for( int index = 0 ; index < dados.length ; index++ ){

                                dados.Overwrite( index, new(){ 
                                    a = 10,
                                    b = 15,
                                    c = 15f
                                });

                                Console.Log( ( dados.Get_value( index ).a ) );
                                
                            }

                        }


            }




    }


    public Test_packet[] arr;
    public void Fn(){

        // ** ALLOC
        arr = new Test_packet[ 10 ];
        
        for( int i = 0 ; i < arr.Length ; i++ ){

            // ** change value
            arr[ i ].a = 10;

            // ** get value
            Console.Log( arr[ i ].b );

        }

        // ** GC will clean
        arr = null;

    }




}