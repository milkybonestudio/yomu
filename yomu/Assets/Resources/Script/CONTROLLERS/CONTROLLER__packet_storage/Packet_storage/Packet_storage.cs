using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Unity.Burst;




unsafe public struct Packets_storage {

    public static Packets_storage Construct( Data_file_link _data ){
        return new(){
            data = _data
        };
    }


    //mark
    // ** need to only have the id
    public Data_file_link data;



    // ** WRITE/READ
        public Packet_array<T> Get_packet_array<T>( Packet_key _key )where T:unmanaged{ return Get_pointer()->Get_packet_array<T>( _key ); }
        public Packet Get_packet( Packet_key _key ){ return Get_pointer()->Get_packet( _key ); }


    // ** ALOC/FREE

        public Packet_key Alloc_packet( int _size ){ return Get_pointer()->Alloc_packet( _size ); }
        public Packet_key Alloc_packet_array<T>( int _size )where T:unmanaged{ return Get_pointer()->Alloc_packet_array<T>( _size ); }

        public void Dealloc_packet( Packet_key _key ){ Get_pointer()->Dealloc_packet( _key ); }


    // ** CHANGES

        public void Sinalize_partial_local_change<T>( int _point_to_change_in_file, T _value )where T: unmanaged{ Get_pointer()->Sinalize_partial_local_change<T>( _point_to_change_in_file, _value ); }

        public void Force_expand( Packet_storage_size _size ){ Get_pointer()->Force_expand( _size ); }

    // ** CHECKS

        public bool Is_valid(){ return data.Is_valid(); }


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Packets_storage_data* Get_pointer(){

        return Controllers.packets.Get_pointer( data );

    }

}

[StructLayout(LayoutKind.Sequential)]
unsafe public struct Packets_storage_data {


    public bool Is_valid(){

        return Controllers.files.storage.Is_id_valid( file_link );

    }

    // ** called in the controller
    public void Set_from_disk(){

        if( !!!( file_link.Is_valid() ) )
            { CONTROLLER__errors.Throw( "Tried to Set_from_disk() but dont give a valid data_key" ); }

        storage_pointer = (Packets_storage_data*)file_link.Get_pointer();
        infos = (Packet_storage_info*)&( storage_pointer->infos);

        return;
    }

    // ** stay in controller

    
    public Packets_storage_data* storage_pointer;
    public Data_file_link file_link;
    public Packet_storage_size_manager sizes;
    public int file_length;
    
    // public Packet_storage_TEST test;

    
    private Packet_storage_info* infos;
    public const int LENGTH_INFO_BUFFER = 3_000;
    public fixed byte infos_buffer [ LENGTH_INFO_BUFFER ];




    public void End(){}


    // ** USES

    public bool Update(){

        Safety();

        bool need_to_update = false;

        for( int index = ( int )Packet_storage_size._1_byte ; index < ( int )Packet_storage_size._MAX ; index++ ){

            if( infos[ index ].Can_to_expand() )
                { Expand( index ); need_to_update = true; }

        }

        return need_to_update;

    }







    // ** KEYS

    public Packet_key Alloc_packet_of_type_array( int _type_size, int _number ){ return Alloc_packet( _type_size * _number ); }
    public Packet_key Alloc_packet_int_array( int _number ){ return Alloc_packet( sizeof( int ) * _number ); }
    public Packet_key Alloc_packet_float_array( int _number ){ return Alloc_packet( sizeof( float ) * _number ); }

    public Packet_key Alloc_packet_array<T>( int _number_elements ) where T : unmanaged { return Alloc_packet( sizeof( T ) * _number_elements ); }
    public Packet_key Alloc_packet( int _size_in_bytes ){

        Safety();
        if( System_run.packet_storage_show_messages )
            { Console.Log( $"--------- WILL ALLOC <Color=lightBlue>{ _size_in_bytes }</Color>----------" ); }
        
        if( _size_in_bytes == 0 )
            {
                if( System_run.packet_storage_show_messages )
                    { Console.Log( "Alloced a 0 byte size" ); }

                return Packet_key.Construct(
                    _slot : 0,
                    _size : Packet_storage_size._0_bytes,
                    _length : _size_in_bytes
                );
            
            }
        
        Packet_storage_size size = sizes.Get_required_size( _size_in_bytes );
        int size_index = ( int ) size;

        // ** garante que tem pelo menos 1
        if( infos[ size_index ].Need_to_force_expand() )
            { Expand( size_index ); } 
                
        int slot = infos[ size_index ].Get_space( storage_pointer );

        if( System_run.packet_storage_show_messages )
            { Console.Log( "current_pointer_of_free_space : " + (infos[ size_index ].current_pointer_of_free_space )); }

        Controllers.stack.packet_storage.Save_data_alloc( file_link.id, size, _size_in_bytes, slot );
        

        return Packet_key.Construct(
            _slot : slot,
            _size : size,
            _length : _size_in_bytes
        );
        
    }

    public void Dealloc_packet( Packet_key _key ){

        Safety();

        if( !!!( _key.is_valid ) )
            { CONTROLLER__errors.Throw( "tried to deallocate a invalid <Color=lightBlue>Packet_key</Color>" ); }

        if( _key.size == Packet_storage_size._0_bytes )
            { 
                if( System_run.packet_storage_show_messages )
                    { Console.Log( "Deallocated a 0 bytes key" ); }
                
                return;
            } // ** nao temo que liberar 

        infos[ ( int ) _key.size ].Dealloc( storage_pointer, _key.slot );

        return;

    }


    public void Change_length_packet_key( Packet_key* _key, int _new_length ){ *_key = Change_length_packet_key( *_key, _new_length ); }

    public Packet_key Change_length_packet_key( Packet_key _key, int _new_length ){

        if( System_run.max_security )
            {
                if( !!!( _key.Have_data() ) )
                    { CONTROLLER__errors.Throw( $"Tried to change length a key, but the key is not valid. { _key.Get_text_of_situation() }" ); }

                if( _new_length < 0 )
                    { CONTROLLER__errors.Throw( $"Tried to change length a key, but the length is <Color=lightBlue>{ _new_length }</Color>" ); }
            }

        
        if( System_run.packet_storage_show_messages )
            { Console.Log( $"---will change length of the key { _key.Get_text_of_identification() }---" ); }
        

        // ** SAME LENGTH 
        if( _key.length == _new_length )
            {
                if( System_run.packet_storage_show_messages )
                    { Console.Log( $"Tried to change length of the key { _key.Get_text_of_identification() } but the length is the same" ); }
                return _key;
            }


        Packet_storage_size new_size = sizes.Get_required_size( _new_length );
        void* old_key_pointer = Get_pointer( _key );
        int old_key_off_set = Get_off_set_to_data( _key );

        bool can_use_the_same_key = ( new_size <= _key.size );

        if( can_use_the_same_key )
            {
                Controllers.stack.files.Save_data_change_data_in_file(
                    _file_id              : file_link.id,
                    _file_point_to_change : old_key_off_set,
                    _data_pointer         : old_key_pointer,
                    _length               : _new_length
                );

                return _key;
            }

        if( System_run.packet_storage_show_messages )
            { Console.Log( $"---need a new packet_key---" ); }
  

        if( System_run.packet_storage_show_messages )
            { Console.Log( $"---will allocate a new packet_key---" ); }

        Packet_key new_key = Alloc_packet( _new_length );
        byte* pointer_new_key_byte = (byte*) Get_pointer( new_key );
        byte* pointer_old_key_byte = (byte*) old_key_pointer;

        
        if( System_run.packet_storage_show_messages )
            { Console.Log( $"---will transfer the data from the old one to the new one---" ); }

        // ** pass the maximun data as possible
        for( int index = 0 ; ( index < new_key.length ) && ( index < _key.length ) ; index++ )
            { pointer_new_key_byte[ index ] = pointer_old_key_byte[ index ]; }

        
        if( System_run.packet_storage_show_messages )
            { Console.Log( $"---will deallocate the old packet key---" ); }

        Dealloc_packet( _key );

        if( System_run.packet_storage_show_messages )
            { Console.Log( $"---finish the change lenght---" ); }


        return new_key;


    }







    // ** PACKETS

    public Packet Get_packet( Packet_key _key ){

        Safety();

        if( System_run.packet_storage_show_messages )
            { Console.Log( $" Will get the Packet for the key { _key.Get_text_of_identification() }" ); }

        return Packet.Create(
            _packet_storage_pointer: storage_pointer,
            _key: _key,
            _pointer_to_data: Get_pointer( _key ),
            _off_set_to_data_in_file: Get_off_set_to_data( _key )
        );

    }


    public Packet_array<T> Get_packet_array<T>( Packet_key _key ) where T : unmanaged {

        Safety();

        int _type_size = sizeof( T );

        if( !!!(_key.is_valid ) )
            { CONTROLLER__errors.Throw( "tried to <Color=lightBlue>get teh pointer</Color> but have a invalid <Color=lightBlue>Packet_key</Color>" ); }

        if( _key.size == Packet_storage_size._0_bytes )
            { 
                if( System_run.packet_storage_show_messages )
                    { Console.Log( "Called Get_array_pointer and is size 0" ); }
                // ** não pode castar, no for(){} nao iria chamar pelo length 0
                return Packet_array<T>.Construct(
                    _key = _key,
                    _file_link : file_link,
                    _start_point_in_file : 0,
                    _pointer_0 : (void*) storage_pointer
                );
                
            } 


        return Packet_array<T>.Construct(
            _key : _key,
            _file_link : file_link,
            _start_point_in_file : Get_off_set_to_data( _key ),
            _pointer_0 : Get_pointer( _key )
        );

    }


    private int Get_off_set_to_data( Packet_key _key ){

        Packet_storage_info* info = ( infos + (int) _key.size );

            int size_in_bytes = info->size_in_bytes;
            int data_pointer = info->pointer_to_DATA;

            int final_off_set = data_pointer + ( _key.slot * size_in_bytes );
        
        return final_off_set;

    }


    // public int* Get_int_pointer( Packet_key _key ){ return (int*) Get_int_pointer( _key ); }
    // public byte* Get_byte_pointer( Packet_key _key ){ return (byte*) Get_int_pointer( _key ); }


    private void* Get_pointer( Packet_key _key ){

        Safety();

        if( System_run.max_security && !!!( _key.is_valid ) )
            { CONTROLLER__errors.Throw( "tried to <Color=lightBlue>get teh pointer</Color> but have a invalid <Color=lightBlue>Packet_key</Color>" ); }

        if( _key.size == Packet_storage_size._0_bytes )
            { return (void*) storage_pointer; } // ** não pode castar

        return infos[ (int) _key.size ].Get_pointer( storage_pointer, _key.slot );

    }





    // ** Only activate stack
    // ** the system would need to get a struct pointer to change/use the data 
    // ** so the struct need to be big
    public void Sinalize_change( Packet_key _key ){

        if( System_run.max_security )
            {
                if( !!!( _key.Have_data() ) )
                    { CONTROLLER__errors.Throw( $"Tried to change the data to a key, but the key is not valid. { _key.Get_text_of_situation() }" ); }
            }

        if( System_run.packet_storage_show_messages )
            { Console.Log( $"---will sinalize the value change of the key { _key.Get_text_of_identification() }---" ); }


        Controllers.stack.files.Save_data_change_data_in_file(
            _file_id              : file_link.id,
            _file_point_to_change : Get_off_set_to_data( _key ),
            _data_pointer         : Get_pointer( _key ),
            _length               : _key.length
        );


        if( System_run.packet_storage_show_messages )
            { 
                Console.Log( "----pass change to stack----" ); 
                Console.Log( "----FINISHED----" ); 
            }

    }



    // --- LOCAL CHANGES
    // ** most in data/flags

    public void Sinalize_partial_local_change<T>( int _off_set_in_file, T _value ) where T : unmanaged {

        Controllers.stack.files.Save_data_change_data_in_file<T>(
            _file_id              : file_link.id,
            _file_point_to_change : _off_set_in_file,
            _data                 : _value
        );

    }

    public void Sinalize_partial_local_change( int _off_set_in_file, void* _pointer_to_data, int _length ){

        Controllers.stack.files.Save_data_change_data_in_file(
            _file_id              : file_link.id,
            _file_point_to_change : _off_set_in_file,
            _data_pointer         : _pointer_to_data,
            _length               : _length
        );

    }














    // ** Change_data
    // ** the struct would be copy to the function scope and then saved when is not more necessary
    public void Change_value_packet( Packet_key _key, void* _pointer_new_data, int _length ){


        if( _key.size == Packet_storage_size._0_bytes )
            {
                if( System_run.packet_storage_show_messages )
                    { Console.Log( $"Tried to change value packet a key a size <Color=lightBlue>0 BYTES</Color>. will skip" ); }
                
                return;
            }

        if( System_run.max_security )
            {

                if( _pointer_new_data == null )
                    { CONTROLLER__errors.Throw( $"Tried to change value of the size { _key.size } in slot { _key.slot } but the pointer to the data is NULL" ); }

                if( _length <= 0 )
                    { CONTROLLER__errors.Throw( $"Tried to change value of the size { _key.size } in slot { _key.slot } but the length for the new data is <Color=lightBlue>{ _length }</Color>" ); }


                if( !!!( _key.Have_data() ) )
                    { CONTROLLER__errors.Throw( $"Tried to change the data to a key, but the key is not valid. { _key.Get_text_of_situation() }" ); }

                if( _length != _key.length )
                    { CONTROLLER__errors.Throw( $"Tried to change value of the size { _key.size } in slot { _key.slot } but the length of the new data is <Color=lightBlue>{ _length }</Color> and in the key is <Color=lightBlue>{ _key.length }</Color>" ); }

            }

        if( System_run.packet_storage_show_messages )
            {
                Console.Log( $"---will change the value of the key { _key.Get_text_of_identification() }---" );

                if( _length < 10 )
                    { for( int index = 0 ; index < _length ; index++ ){ Console.Log( $"Index { index } value: " + (((byte*)_pointer_new_data)[index]) ); } }
                    else
                    { Console.Log( $"Size have <Color=lightBlue>{ _length }</Color>, is too long to print the bytes" ); }
            }


        void* key_data_pointer = Get_pointer( _key );

        VOID.Transfer_data( _pointer_data: _pointer_new_data, _pointer_to_transfer: key_data_pointer, _length  );


        if( System_run.packet_storage_show_messages )
            { Console.Log( "----changed data in store----" ); }

        void* pointer_to_data = Get_pointer( _key );
        int off_set = Get_off_set_to_data( _key );

        Controllers.stack.files.Save_data_change_data_in_file(
            _file_id              : file_link.id,
            _file_point_to_change : off_set,
            _data_pointer         : pointer_to_data,
            _length               : _length
        );


        if( System_run.packet_storage_show_messages )
            { 
                Console.Log( "----pass change to stack----" ); 
                Console.Log( "----FINISHED----" ); 
            }


    }

    public void B(){

        Character_desire str = default;
        Packet_key key = default;

        Change_value_packet( key, &str, sizeof( Character_desire ) );

    }




    // ** FILE OPERATIONS
    
    private void Expand_file( int _need_bytes ){


        int final_size = file_length + _need_bytes + 10_000 ;

        // ** if it's reconstructing with the stack it will NEVER came here
        // ** the message ( add ) is alwasy after the function executes. if it need more space it will call EXPAND 
        // ** what means the message ( change length ) is always called before ( ADD ) -> the length the packet sees should be enough 
        file_link = Controllers.files.operations.Change_length_file( file_link, final_size );

        file_length = file_link.heap_key.Get_length();

    }

    private int Expand( int _index_info ){

        
        // ** logica é mudar os blocos 
        Safety();


        int how_many_bytes_it_needs_to_expand = infos[ _index_info ].Get_bytes_to_expand();

        if( Verify_if_needs_to_expand_file( how_many_bytes_it_needs_to_expand ) )
            { Expand_file( _index_info ); }

        if( System_run.packet_storage_show_messages )
            { Console.Log( $"<Color=lightBlue>WILL EXPAND SIZE: { (Packet_storage_size ) _index_info }</Color>" ); }

        int last_size = ( (int) Packet_storage_size._MAX - 1 );
        for( int index_to_expand = last_size ; index_to_expand > 0 ; index_to_expand-- )
            { infos[ index_to_expand ].Move_data( storage_pointer, how_many_bytes_it_needs_to_expand ); }

        // ** mover 

        return infos[ _index_info ].Reajust_data( storage_pointer );


    }
    





    // --- DEBUG AND TEST

    public int Force_expand( Packet_storage_size _size ){ return Expand( (int)_size ); }
    public void Print_flags( Packet_storage_size _size ){ infos[(int)_size].Print_flags( storage_pointer ); }
    public void Print_actives( Packet_storage_size _size ){ infos[(int)_size].Print_actives( storage_pointer ); }


    // --- VERIFICATIONS AND INFORMATION


    public bool Is_slot_used( Packet_storage_size _size, int _slot ){

        Safety();
        return infos[ (int)_size ].Is_slot_used( storage_pointer, _slot );

    }
 

    public bool Can_have_specific_key( Packet_storage_size _size, int _slot ){

        Safety();

        if( _slot < 0 )
            { CONTROLLER__errors.Throw( $"Came to <Color=lightBlue>Can_have_specific_key</Color>, but the slot asked for is <Color=lightBlue>{ _slot }</Color>" ); }

        int max_slot = infos[ (int)_size ].number_slots;

        bool can_have = _slot < max_slot;

        if( System_run.packet_storage_show_messages )
            {
                Console.Log( "max_slot: " + max_slot );
                Console.Log( "slot: " + _slot );
                Console.Log( "can_have: " + can_have );
                
            }

        return can_have;
        

    }

    private bool Verify_if_needs_to_expand_file( int _how_many_bytes_it_needs_to_expand ){


        bool need = ( Get_used_bytes() + _how_many_bytes_it_needs_to_expand ) > file_length ;

        if( System_run.packet_storage_show_messages && need )
            { Console.Log( "Need to expand file" ); }

    
        return need;

    }


    public int Get_used_bytes(){


        Packet_storage_info* last_size_info = infos + ( ( int ) Packet_storage_size._MAX - 1 );
        int length_until_last_size_data = last_size_info->pointer_to_DATA;
        int last_size_data = last_size_info->space_needed_DATA;

        int current_used_length = ( length_until_last_size_data + last_size_data );

        if( System_run.packet_storage_show_messages )
            { Console.Log( "CURRENT BYTES: " + Formater.Format_number( current_used_length ) ); }
        
        return current_used_length;

    }



















    public void Safety_change(){

        

    }

    public void Safety(){

        if( !!!( System_run.max_security ) )
            { return; }

        fixed( Packets_storage_data* pointer = &this ){

            if( pointer == null )
                { CONTROLLER__errors.Throw( "Tried to cast a null pointer" ); }

        }


        if( !!!( Is_valid() ) )
            { CONTROLLER__errors.Throw( "Tried to use a Packet_storage, but did not started it" ); }

        if( storage_pointer == null )
            { CONTROLLER__errors.Throw( "The pointer of the storage was <Color=lightBlue>NULL</Color>" ); }

        if( infos == null )
            { CONTROLLER__errors.Throw( "The pointer of the storage_infos was <Color=lightBlue>NULL</Color>" ); }

        // ** this type of storage can not be used in multithread
        if( Thread.CurrentThread.ManagedThreadId != System_information.main_thread_id )
            { CONTROLLER__errors.Throw( "Wrong thread id" ); }


    }

    


}



