using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst;


[StructLayout(LayoutKind.Sequential)]
unsafe public struct Packet_storage {


    public const int LENGTH_INFO_BUFFER = 3_000;
    // public const int START_POINTER_DATA = 1_000;

    public bool started;
    private Packet_storage* storage_pointer;
    public Data_file_link file_link;
    public int file_length;

    #if UNITY_EDITOR

    // ** TESTING
        
        public static Packet_storage* Start( Heap_key _key ){

            Packet_storage* _pointer = ( Packet_storage* ) _key.Get_pointer();

                _pointer->started = true;
                _pointer->storage_pointer = _pointer;

                _pointer->file_link.heap_key = _key;
                _pointer->file_link.size = _key.Get_length();

                _pointer->file_length = _key.Get_length();
                _pointer->infos = (Packet_storage_info*) _pointer->infos_buffer;

            return _pointer;
        
        }

    #endif


    


    private Packet_storage_info* infos;
    public fixed byte infos_buffer [ LENGTH_INFO_BUFFER ];


    public static Packet_storage* Start( Data_file_link _data_file ){

        Packet_storage* pointer = (Packet_storage*) _data_file.heap_key.Get_pointer();

        pointer->started = true;

        pointer->file_link = _data_file;
            pointer->file_length = _data_file.size;

        pointer->storage_pointer = pointer;
        pointer->infos = (Packet_storage_info*) pointer->infos_buffer;

        return pointer;
    
    }




    public Packet_key Get_key_FOR_TEST( Packet_storage_size _size, int _slot ){


        
        #if !UNITY_EDITOR
            CONTROLLER__errors.Throw( "Tentou chamar<Color=lightBlue>Get_key</Color> mas nao pode ser chamada na build" );
        #endif

        Safety();

        if( !!! ( Can_have_specific_key( _size, _slot ) ) )
            { CONTROLLER__errors.Throw( $"Tried to get the key of the size <Color=lightBlue>{ _size }</Color> and the slot <Color=lightBlue>{ _slot }</Color> but system can not have it" ); }

        if( !!!( Is_slot_used( _size, _slot ) ) )
            { CONTROLLER__errors.Throw( $"Tried to get the key of the size <Color=lightBlue>{ _size }</Color> and the slot <Color=lightBlue>{ _slot }</Color> but system didnt allocated it" ); }



        if( System_run.packet_storage_show_messages )
            { Console.Log( $"will create a copy with NOT the same data of the packet_key {{ size = <Color=lightBlue>{ _size }</Color>, slot = <Color=lightBlue>{ _slot }</Color> }}. " ); }

        // The length is not right because the Packet_storage dont stores it
        return Packet_key.Construct(
            _slot : _slot,
            _size : _size,
            _length : Controllers.packets.sizes.Get_size_in_bytes( _size )
        );
        
    }


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



    public void End(){}



    // ** USES

    public void Update(){

        // ** 
        Safety();

        for( int index = ( int )Packet_storage_size._1_byte ; index < ( int )Packet_storage_size._MAX ; index++ ){

            if( infos[ index ].Can_to_expand() )
                { Expand( index ); }

        }


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

    
    private void Expand_file( int _need_bytes ){

        int multiplier = 1;

        if( _need_bytes < 20_000 )
            { multiplier = 2; }

        if( _need_bytes < 5_000 )
            { multiplier = 4; }

        
        if( _need_bytes < 1_000 )
            { multiplier = 10; }

        if( _need_bytes < 700 )
            { multiplier = 15; }

        int final_size = file_length + ( _need_bytes * multiplier );

        Controllers.files.Sinalize_change_length( ref file_link, final_size );
        file_length = file_link.heap_key.Get_length();

    }

    private void Expand( int _index_info ){

        
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

        infos[ _index_info ].Reajust_data( storage_pointer );


    }
    
    
    public void Force_expand( Packet_storage_size _size ){ Expand( (int)_size ); }
    public void Print_flags( Packet_storage_size _size ){ infos[(int)_size].Print_flags( storage_pointer ); }
    public void Print_actives( Packet_storage_size _size ){ infos[(int)_size].Print_actives( storage_pointer ); }




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


    public Packet_array_pointer Get_array_pointer( Packet_key _key, int _type_size ){

        
        Safety();

        if( !!!(_key.is_valid) )
            { CONTROLLER__errors.Throw( "tried to <Color=lightBlue>get teh pointer</Color> but have a invalid <Color=lightBlue>Packet_key</Color>" ); }

        if( _key.size == Packet_storage_size._0_bytes )
            { 
                if( System_run.packet_storage_show_messages )
                    { Console.Log( "Called Get_array_pointer and is size 0" ); }
                // ** não pode castar, no for(){} nao iria chamar pelo length 0
                return Packet_array_pointer.Construct(

                    _file_link : file_link,
                    _start_point_in_file : 0,
                    _pointer_0 : (void*) storage_pointer,
                    _type_size : 0,
                    _length : 0

                );
                
            } 

        // ** garante que faça sentido

        if( System_run.max_security )
            {
                if( ( _key.length % _type_size ) != 0 )
                    { CONTROLLER__errors.Throw( $"The length of the key {{ <Color=lightBlue>{ _key.length }</Color> }} and the type size {{ <Color=lightBlue>{ _type_size }</Color> }}. The rest of the division is <Color=lightBlue>{ ( _key.length % _type_size ) }</Color> and should be 0" ); }
            }

        int length_array = ( _key.length / _type_size );


        void* pointer_to_data = Get_pointer( _key );
        int off_set = Get_off_set_to_data( _key );

        return Packet_array_pointer.Construct(

            _file_link : file_link,
            _start_point_in_file : off_set,
            _pointer_0 : pointer_to_data,
            _type_size : _type_size,
            _length : length_array

        );



    }


    private int Get_off_set_to_data( Packet_key _key ){

        Packet_storage_info* info = ( infos + (int) _key.size );

            int size_in_bytes = info->size_in_bytes;
            int data_pointer = info->pointer_to_DATA;

            int final_off_set = data_pointer + ( _key.slot * size_in_bytes );
        
        return final_off_set;

    }

    public int* Get_int_pointer( Packet_key _key ){ return (int*) Get_int_pointer( _key ); }
    public byte* Get_byte_pointer( Packet_key _key ){ return (byte*) Get_int_pointer( _key ); }

    public void* Get_pointer( Packet_key _key ){

        Safety();

        if( !!!(_key.is_valid) )
            { CONTROLLER__errors.Throw( "tried to <Color=lightBlue>get teh pointer</Color> but have a invalid <Color=lightBlue>Packet_key</Color>" ); }

        if( _key.size == Packet_storage_size._0_bytes )
            { return (void*) storage_pointer; } // ** não pode castar

        return infos[ (int) _key.size ].Get_pointer( storage_pointer, _key.slot );

    }



    public Packet_key Alloc_packet_of_type_array( int _type_size, int _number ){ return Alloc_packet( _type_size * _number ); }
    public Packet_key Alloc_packet_int_array( int _number ){ return Alloc_packet( sizeof( int ) * _number ); }
    public Packet_key Alloc_packet_float_array( int _number ){ return Alloc_packet( sizeof( float ) * _number ); }


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
        
        Packet_storage_size size = Controllers.packets.sizes.Get_required_size( _size_in_bytes );
        int size_index = ( int ) size;

        // ** garante que tem pelo menos 1
        if( infos[ size_index ].Need_to_force_expand() )
            { Expand( size_index ); } 
                
        int slot = infos[ size_index ].Get_space( storage_pointer );

        if( System_run.packet_storage_show_messages )
            { Console.Log( "current_pointer_of_free_space : " + (infos[ size_index ].current_pointer_of_free_space )); }
        

        return Packet_key.Construct(
            _slot : slot,
            _size : size,
            _length : _size_in_bytes
        );
        
    }

    public void Dealloc_packet( Packet_key _key ){

        Safety();

        if( !!!(_key.is_valid) )
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






//mark
// ** PARA VER






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



        Packet_storage_size new_size = Controllers.packets.sizes.Get_required_size( _new_length );
        void* old_key_pointer = Get_pointer( _key );
        int old_key_off_set = Get_off_set_to_data( _key );

        bool can_use_the_same_key = ( new_size != _key.size );

        if( can_use_the_same_key )
            {
                Controllers.stack.files.Save_data_change_data_in_file(
                    _slot_file            : file_link.id,
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
            _slot_file            : file_link.id,
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

        Controllers.stack.files.Save_data_change_data_in_file(
            _slot_file            : file_link.id,
            _file_point_to_change : _off_set_in_file,
            _data: _value
        );

    }

    public void Sinalize_partial_local_change( int _off_set_in_file, void* _pointer_to_data, int _length ){

        Controllers.stack.files.Save_data_change_data_in_file(
            _slot_file            : file_link.id,
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
            _slot_file            : file_link.id,
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
































    private void Safety(){

        if( !!!( System_run.max_security ) )
            { return; }

        fixed( Packet_storage* pointer = &this ){

            if( pointer == null )
                { CONTROLLER__errors.Throw( "Tried to cast a null pointer" ); }

        }


        if( !!!( started ) )
            { CONTROLLER__errors.Throw( "Tried to use a Packet_storage, but did not started it" ); }

        if( storage_pointer == null )
            { CONTROLLER__errors.Throw( "The pointer of the storage was <Color=lightBlue>NULL</Color>" ); }

        if( infos == null )
            { CONTROLLER__errors.Throw( "The pointer of the storage_infos was <Color=lightBlue>NULL</Color>" ); }


    }

    


}



