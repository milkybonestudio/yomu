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

  
    public static Packets_storage packet_storage_NEW;
    // ** antigo
    public static Packets_storage_data* packet_storage_pointer;
    
    public static void Set(){

        if( packet_storage_NEW.Is_valid() )
            { Console.Log( "Didn't save the last packet_storage, lose the data" ); }

        packet_storage_NEW = default;
        // packet_storage_pointer = null;
        packet_key_test = default;

        
    }

    public static Heap_key key;

    public static Packet_key packet_key;

    public static Packet_key packet_key_10;
    public static Packet_key packet_key_189;
    public static Packet_key packet_key_1_500;

    public static Packet_key packet_key_test;

    public static int file_length = 1_000_000;
    public static string path_to_packet_storage = $"{ Paths_system.persistent_data }\\packet_storage.dat"; 

    unsafe public struct Test_packet {

        public int a;
        public int b;
        
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

                        // Test.SHOULD_PASS( "message create new file", () => {

                        //     Data_file_link data = Data_file_link.Construct_fast()

                        // });

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
                            
                        packet_storage_NEW = Controllers.packets.operations.Get_storage_from_disk( path_to_packet_storage );

                        Console.Log( "Load packet store" );
                        
                    }




                // ** criar
                if( Input.GetKeyDown( KeyCode.W ) )
                    {

                        if( packet_storage_NEW.Is_valid() )
                            { Console.Log( "already have the packet storage" ); return; }
                        
                        if( Controllers.files.storage.File_exist_in_final_disk( path_to_packet_storage ) )
                            { Console.Log( "Arquivo já existe" ); return; }

                        packet_storage_NEW = Controllers.packets.operations.Create_new_storage( path_to_packet_storage, Controllers.packets.defaults.Get_default_args() );
                
                        Console.Log( "Created packet store" );
                        Console.Log( path_to_packet_storage );

                    }

                // ** salvar
                if( Input.GetKeyDown( KeyCode.E ) )
                    {

                        if( !!!( packet_storage_NEW.Is_valid() ) )
                            { Console.Log( "didnt have any store_packet" ); return; }


                        Controllers.packets.operations.Remove_storage( packet_storage_NEW );
                        Controllers.saving.saver.Force_save_synchronous_safe();

                        
                        
                    }


                // ** zerar
                if( Input.GetKeyDown( KeyCode.R ) )
                    {

                        if( packet_storage_NEW.Is_valid() )
                            { Controllers.packets.operations.Delete_storage( packet_storage_NEW ); }
                            
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
                        packet_storage_pointer->Print_actives( Packet_storage_size._10_bytes ); 
                        packet_storage_pointer->Print_flags( Packet_storage_size._10_bytes );
                    }

                if( Input.GetKeyDown( KeyCode.W ) )
                    { 
                        packet_storage_pointer->Print_actives( Packet_storage_size._200_bytes ); 
                        packet_storage_pointer->Print_flags( Packet_storage_size._200_bytes );
                    }

                if( Input.GetKeyDown( KeyCode.E ) )
                    { 
                        packet_storage_pointer->Print_actives( Packet_storage_size._1500_bytes ); 
                        packet_storage_pointer->Print_flags( Packet_storage_size._1500_bytes );
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
                            packet_key_10 = packet_storage_pointer->Alloc_packet( 10 );
                            Console.Log( "slot: " +  packet_key_10.slot );
                        }


                    // ** DEALLOCATE key
                    if( Input.GetKeyDown( KeyCode.W ) )
                        {
                            // Guarantee_pointer();
                            packet_storage_pointer->Dealloc_packet( packet_key_10 );
                            packet_key_10 = default;
                        }



                    // ** ALLOC + DEALLOCATE key
                    if( Input.GetKeyDown( KeyCode.E ) )
                        {
                            packet_key_10 = packet_storage_pointer->Alloc_packet( 10 );
                            packet_storage_pointer->Dealloc_packet( packet_key_10 );
                    }

                // 189 BYTES

                    
                    if( Input.GetKeyDown( KeyCode.A ) )
                        {
                            // Guarantee_pointer();
                            packet_key_189 = packet_storage_pointer->Alloc_packet( 189 );
                            Console.Log( "slot: " +  packet_key_189.slot );
                        }


                    // ** DEALLOCATE key
                    if( Input.GetKeyDown( KeyCode.S ) )
                        {
                            // Guarantee_pointer();
                            packet_storage_pointer->Dealloc_packet( packet_key_189 );
                            packet_key_189 = default;
                        }



                    // ** ALLOC + DEALLOCATE key
                    if( Input.GetKeyDown( KeyCode.D ) )
                        {
                            packet_key_189 = packet_storage_pointer->Alloc_packet( 200 );
                            packet_storage_pointer->Dealloc_packet( packet_key_189 );
                        }

                // 1500 BYTES

                    
                    if( Input.GetKeyDown( KeyCode.Z ) )
                        {
                            // Guarantee_pointer();
                            packet_key_1_500 = packet_storage_pointer->Alloc_packet( 1_500 );
                            Console.Log( "slot: " +  packet_key_1_500.slot );
                        }


                    // ** DEALLOCATE key
                    if( Input.GetKeyDown( KeyCode.X ) )
                        {
                            // Guarantee_pointer();
                            packet_storage_pointer->Dealloc_packet( packet_key_1_500 );
                            packet_key_1_500 = default;
                        }



                    // ** ALLOC + DEALLOCATE key
                    if( Input.GetKeyDown( KeyCode.C ) )
                        {
                            packet_key_1_500 = packet_storage_pointer->Alloc_packet( 1_500 );
                            packet_storage_pointer->Dealloc_packet( packet_key_1_500 );
                        }

                return;

            }






        // OPERATIONS
        if( Input.GetKey( KeyCode.Keypad3 ) )
            {

                // ** FORCE EXPAND

                    if( Input.GetKeyDown( KeyCode.Q ) )
                        { packet_storage_pointer->Force_expand( Packet_storage_size._10_bytes ); }

                    
                    if( Input.GetKeyDown( KeyCode.W ) )
                        { packet_storage_pointer->Force_expand( Packet_storage_size._200_bytes ); }

                    
                    if( Input.GetKeyDown( KeyCode.E ) )
                        { packet_storage_pointer->Force_expand( Packet_storage_size._1500_bytes ); }



            }





        // ** GET KEY
        if( Input.GetKeyDown( KeyCode.H ) )
            {
                packet_key_test = packet_storage_pointer->test.Get_key_FOR_TEST( packet_storage_pointer, Packet_storage_size._10_bytes, 10 );
                packet_key_test.length = 8;
            }


        // ** COLOCAR VALOR
        if( Input.GetKeyDown( KeyCode.J ) )
            {
                int* data_pointer = (int*) packet_storage_pointer->Get_pointer( packet_key_test );
                *data_pointer = ( *data_pointer + 10 );
            }

        // ** LER VALOR
        if( Input.GetKeyDown( KeyCode.K ) )
            {
                int* dados = (int*) packet_storage_pointer->Get_pointer( packet_key_test );
                Console.Log( "valor: " + *dados );
            }




        // ** LER VALOR
        if( Input.GetKeyDown( KeyCode.Z ) )
            {

                Packet_array<int> dados =  packet_storage_pointer->Get_packet_array<int>( packet_key_test );
                int* pointer = dados.Get( 0 );

                for( int index = 0 ; index < dados.length ; index++ ){

                    Console.Log( (*(int*) dados.Get( index )) );
                    
                }


                


                int* a = (int*) packet_storage_pointer->Get_pointer( packet_key_test );

                for( int index_2 = 0 ; index_2 < (packet_key_test.length / sizeof( int )) ; index_2++ ){

                    Console.Log( a[ index_2 ] );
                    
                }



                Packet pk = packet_storage_pointer->Get_packet( packet_key_test );


                // var tipo = (Tipo*) pk.pointer;


                // // ** save isolate data
                // pk.Change( &tipo->age, 10 );


                // tipo->age = 18;

                

                // int o = &(((Packet_usable_key*)null )->pointer);


            }





        // ** CHANGE PACKET COMPLETE
        if( Input.GetKeyDown( KeyCode.Y ) )
            {

                Console.Log( $"--------{ packet_key_test.Get_text_of_identification() }---------" );

                Packet pk = packet_storage_pointer->Get_packet( packet_key_test );
                Test_packet* tipo = (Test_packet*) pk.Get_pointer_complete();

                    // ** usar

                    tipo->a = 2;
                    tipo->b = 5;
                    
                
                pk.Finish_use();
                

            }


        // ** CHANGE PACKET PARTIAL
        if( Input.GetKeyDown( KeyCode.U ) )
            {

                Console.Log( $"--------{ packet_key_test.Get_text_of_identification() }---------" );

                Packet pk = packet_storage_pointer->Get_packet( packet_key_test );
                Test_packet* tipo = (Test_packet*) pk.Get_pointer_partial();

                pk.Change<int>( &tipo->a, 2 );
                pk.Change<float>( &tipo->b, 5 );

                
            }



    }



    private  static void Guarantee_pointer(){

        if( packet_storage_pointer == null )
            { CONTROLLER__errors.Throw( "pointer null" ); }

    }


}