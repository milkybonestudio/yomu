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

  
    public static Packet_storage* packet_storage;
    
    public static void Set(){

        if( packet_storage != null )
            { Console.Log( "Didn't save the last packet_storage, lose the data" ); }

        packet_storage = null;
        packet_key_test = default;

        
    }

    public static Heap_key key;

    public static Packet_key packet_key;
    public static Packet_key packet_key_test;

    public static int file_length = 1_000_000;
    public static string path_to_packet_storage = $"{ System.IO.Directory.GetCurrentDirectory() }\\Assets\\Editor\\packet_storage.dat"; 

    unsafe public struct Test_packet {

        public int a;
        public int b;
        
    }


    public static void Update(){


        // ** carregar 
        if( Input.GetKeyDown( KeyCode.Q ) )
            {
                if( System.IO.File.Exists( path_to_packet_storage ) )
                    {
                        if( packet_storage == null )
                            {
                                byte[] data = System.IO.File.ReadAllBytes( path_to_packet_storage );

                                packet_storage = Packet_storage.Start(
                                    Data_file_link.Construct_fast(
                                        _data_pointer: Controllers.heap.Get_unique( data ).Get_pointer(), 
                                        _length: data.Length,
                                        _id: 10
                                    )  
                                );
                                Console.Log( "Load packet store" );

                            }
                            else
                            { Console.Log( "pointer already have a file" ); }
                    }
                    else
                    { 
                        Console.Log( "File didnt exist" ); 
                    }
            }




        // ** criar
        if( Input.GetKeyDown( KeyCode.W ) )
            {

                if( packet_storage != null )
                    { Console.Log( "already have the packet storage" ); goto jump_create; }

                if( System.IO.File.Exists( path_to_packet_storage ) )
                    { Console.Log( "Arquivo já existe" ); goto jump_create; }


                key = Controllers.heap.Get_unique( file_length );
                packet_storage = Controllers.packets.creation.Apply_create_data( 
                    _pointer   : key.Get_pointer(), 
                    _pointer_max_length: file_length,
                    _start_data: Controllers.packets.defaults.Get_default_args()
                );

                packet_storage = Packet_storage.Start(
                    Data_file_link.Construct_fast(
                        _data_pointer: Controllers.heap.Get_unique( file_length ).Get_pointer(), 
                        _length: file_length,
                        _id: 10
                    )  
                );

                
                Console.Log( "Created packet store" );


            }

            /**/ jump_create: 

        // ** salvar
        if( Input.GetKeyDown( KeyCode.E ) )
            {

                if( packet_storage != null )    
                    { 
                        Files.Save_file( path_to_packet_storage, packet_storage, file_length );
                        Controllers.heap.Return_key( packet_storage->file_link.heap_key );
                        packet_storage = null;
                        Console.Log( "Saved packet store" );
                        
                    }
                    else
                    { Console.Log( "didnt have any store_packet" ); }

            }


        // ** zerar
        if( Input.GetKeyDown( KeyCode.R ) )
            {

                if( packet_storage != null )    
                    { 
                        Controllers.heap.Return_key( packet_storage->file_link.heap_key );
                        packet_storage = null;
                    }

                if( System.IO.File.Exists( path_to_packet_storage ) )
                    { System.IO.File.Delete( path_to_packet_storage ); }

                Console.Log( "Removed all data" );
            }


        if( Input.GetKeyDown( KeyCode.M ) )
            { packet_storage->Force_expand( Packet_storage_size._10_bytes ); }

        if( Input.GetKeyDown( KeyCode.N ) )
            { packet_storage->Print_actives( Packet_storage_size._10_bytes ); }

        if( Input.GetKeyDown( KeyCode.B ) )
            { packet_storage->Print_flags( Packet_storage_size._10_bytes ); }





        // ** ADD 10
        if( Input.GetKeyDown( KeyCode.Alpha1 ) )
            {
                // Guarantee_pointer();
                packet_key = packet_storage->Alloc_packet( 10 );
                Console.Log( "slot: " +  packet_key.slot );
            }


        // ** DEALLOCATE key
        if( Input.GetKeyDown( KeyCode.Alpha2 ) )
            {
                // Guarantee_pointer();
                packet_storage->Dealloc_packet( packet_key );
                packet_key = default;
            }



        // ** ALLOC + DEALLOCATE key
        if( Input.GetKeyDown( KeyCode.Alpha3 ) )
            {
                packet_key = packet_storage->Alloc_packet( 10 );
                packet_storage->Dealloc_packet( packet_key );
            }


        // ** use data




        // ** GET KEY
        if( Input.GetKeyDown( KeyCode.H ) )
            {
                packet_key_test = packet_storage->test.Get_key_FOR_TEST( packet_storage, Packet_storage_size._10_bytes, 10 );
                packet_key_test.length = 8;
            }


        // ** COLOCAR VALOR
        if( Input.GetKeyDown( KeyCode.J ) )
            {
                int* data_pointer = (int*) packet_storage->Get_pointer( packet_key_test );
                *data_pointer = ( *data_pointer + 10 );
            }

        // ** LER VALOR
        if( Input.GetKeyDown( KeyCode.K ) )
            {
                int* dados = (int*) packet_storage->Get_pointer( packet_key_test );
                Console.Log( "valor: " + *dados );
            }




        // ** LER VALOR
        if( Input.GetKeyDown( KeyCode.Z ) )
            {
                Packet_array_pointer dados =  packet_storage->Get_array_pointer( packet_key_test, sizeof( int ) );

                for( int index = 0 ; index < dados.length ; index++ ){

                    Console.Log( (*(int*) dados.Get( index )) );
                    
                }


                int* a = (int*) packet_storage->Get_pointer( packet_key_test );

                for( int index_2 = 0 ; index_2 < (packet_key_test.length / sizeof( int )) ; index_2++ ){

                    Console.Log( a[ index_2 ] );
                    
                }



                Packet pk = packet_storage->Get_packet( packet_key_test );


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

                Packet pk = packet_storage->Get_packet( packet_key_test );

                var tipo = (Test_packet*) pk.Get_pointer_complete();

                    // pk.Change( &tipo->a, 10 );

                    // ** usar

                    tipo->a = 2;
                    tipo->b = 5;
                    
                
                pk.Finish_use();
                

            }


        // ** CHANGE PACKET PARTIAL
        if( Input.GetKeyDown( KeyCode.U ) )
            {

                Console.Log( $"--------{ packet_key_test.Get_text_of_identification() }---------" );

                Packet pk = packet_storage->Get_packet( packet_key_test );

                var tipo = (Test_packet*) pk.Get_pointer_partial();

                    pk.Change( &tipo->a, 2 );
                    pk.Change( &tipo->b, 5 );

                pk.Finish_use();
                

            }









    }



    private  static void Guarantee_pointer(){

        if( packet_storage == null )
            { CONTROLLER__errors.Throw( "pointer null" ); }

    }


}