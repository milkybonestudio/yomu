
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Collections.LowLevel.Unsafe;


unsafe public class CONTROLLER__heap {

    public static CONTROLLER__heap instance;
    public static CONTROLLER__heap Get_instance(){ return instance; }

    public IntPtr fix_pointer;
    public void* current_pointer;
    public int total_used;
    public int fix_space_length;

    public volatile int current_id;



    public void Override_all_bytes( Heap_key _key, byte _new_value ){


        switch( _key.type ){
            case Heap_key_type.unique: Override_all_bytes_UNIQUE( _key.unique_key, _new_value ); break;
            default: CONTROLLER__errors.Throw( $"Can not handle type: <Color=lightBlue>{ _key.type }</Color> when Override_all_bytes" ); break;
        }

    }

    public void Override_all_bytes_UNIQUE( Heap_key_UNIQUE _key, byte _new_value ){

        byte* pointer = (byte*) _key.pointer;

        for( int index = 0 ; index < _key.length ; index++ ){

            pointer[ index ] = _new_value;

        }

    }

    public Heap_key Change_length_key( Heap_key _key, int _new_length ){

        Heap_key new_key = default;

        switch( _key.type ){
            case Heap_key_type.unique: new_key = Get_unique( _new_length ); break;
            default: CONTROLLER__errors.Throw( $"Can not handle type: <Color=lightBlue>{ _key.type }</Color> when changing length" ); break;
        }

        Return_key( _key );
        return new_key;

    }


    public void Transfer_data_UNIQUE( Heap_key _key_with_data, Heap_key _key_destination, bool _can_lose_data_from_source, ref int _weight_ref ){

        Transfer_data_UNIQUE( _key_with_data, _key_destination, _can_lose_data_from_source );

        int bytes_to_transfer = ( _key_with_data.Get_length() < _key_destination.Get_length() ) ? (( _key_with_data.Get_length() )) : (( _key_destination.Get_length() ));

        _weight_ref = Control_flow.Get_weight( 2_000_000_000, bytes_to_transfer );

    }

    public void Transfer_data_UNIQUE( Heap_key _key_with_data, Heap_key _key_destination, bool _can_lose_data_from_source = false ){

        if( System_run.heap_show_messages )
            { Console.Log( "Came in Transfer_data_UNIQUE()" ); }

        if( ( _key_with_data.type != Heap_key_type.unique ) || ( _key_destination.type != Heap_key_type.unique )  )
            { CONTROLLER__errors.Throw( $"Called <Color=lightBlue>Transfer_data_UNIQUE()</Color> but the type of source is <Color=lightBlue>{ _key_with_data.type }</Color> and the destination is <Color=lightBlue>{ _key_destination.type }</Color>" ); }

        bool source_have_less_data = ( _key_with_data.Get_length() < _key_destination.Get_length() );

        if( System_run.heap_show_messages )
            { Console.Log( "Source have less data: " + source_have_less_data ); }

        if( !!!( _can_lose_data_from_source ) && !!!( source_have_less_data ) )
            { CONTROLLER__errors.Throw( "Tried to Transfer_data_UNIQUE() but the source have <Color=lightBlue>MORE</Color> data than the destination" ); }

        int bytes_to_transfer = source_have_less_data ? (( _key_with_data.Get_length() )) : (( _key_destination.Get_length() ));

        VOID.Transfer_data( 
            _bytes_to_copy: bytes_to_transfer,
            _source_data : _key_with_data.Get_pointer(),
            _length_source: _key_with_data.Get_length(),
            _pointer_to_transfer: _key_destination.Get_pointer(),
            _pointer_to_transfer_length: _key_destination.Get_length()
        );
        
    }
    

    public Heap_key Get_unique( int _size, ref int _weight_ref ){

        Heap_key ret = Get_unique( _size );

            // ** CALCULATE WEIGHT

                //mark
                // ** ver melhor depois
                _weight_ref = Control_flow.Get_weight( 2_000_000, 1 );

        return ret;

    }
    public Heap_key Get_unique( int _size ){

        Heap_key return_key = default;
            return_key.type = Heap_key_type.unique;
            return_key.unique_id= current_id++;

            Heap_key_UNIQUE key = default;

            IntPtr pointer = Marshal.AllocHGlobal( _size );
            UnsafeUtility.MemClear( pointer.ToPointer(), _size);
            
                key.int_pointer = pointer;
                key.pointer = pointer.ToPointer();
                key.length = _size;

        return_key.unique_key = key;
        unique_keys[ return_key.unique_id ] = return_key;

        return return_key;

    }

    public Heap_key Get_unique( byte[] _data ){

        Heap_key key = Get_unique( _data.Length );
        Files.Transfer_data( _data, key.Get_pointer() );

        return key;

    }

    private int Get_weight_free(){ return Control_flow.Get_weight( 2_000_000, 1 ); }

    public void Return_key( ref Heap_key _key, ref int _weight_ref ){ Return_key( _key ); _key = default; _weight_ref = Get_weight_free(); return; }
    public void Return_key( ref Heap_key _key ){ Return_key( _key ); _key = default; return; }
    public void Return_key( Heap_key _key ){

        switch( _key.type ){
            case Heap_key_type.unique: Return_key_UNIQUE( _key ); break;
            default: CONTROLLER__errors.Throw( $"Can not handle type: <Color=lightBlue>{ _key.type }</Color> when return a heap key" ); break;
        }

    }

    private void Return_key_UNIQUE( Heap_key key, bool _remove_from_list = true ){

        Heap_key_UNIQUE key_unique = key.unique_key;

        if( key.Get_pointer() == null )
            { CONTROLLER__errors.Throw( "pointer is null" ); }

        
        if( key.type != Heap_key_type.unique )
            { CONTROLLER__errors.Throw( "type is not UNIQUE" ); }

        Marshal.FreeHGlobal( key.unique_key.int_pointer );

        if( _remove_from_list )
            { unique_keys.Remove( key.unique_id ); }
            

    }




    public Dictionary<int,Heap_key> unique_keys;


    public Heap_size Get_necessary_size( int _size ){

        if( _size < 0 )
            { CONTROLLER__errors.Throw( $"Tried to get a Heap_size, but the size was <Color=lightBlue>{ _size }</Color>" ); }
        
        if( _size < 100 ){ return Heap_size._100_b; }
        if( _size < 1_000 ){ return Heap_size._1_kb; }
        if( _size < 5_000 ){ return Heap_size._5_kb; }
        if( _size < 10_000 ){ return Heap_size._10_kb; }
        if( _size < 20_000 ){ return Heap_size._20_kb; }
        if( _size < 40_000 ){ return Heap_size._40_kb; }
        if( _size < 60_000 ){ return Heap_size._60_kb; }
        if( _size < 100_000 ){ return Heap_size._100_kb; }
        if( _size < 500_000 ){ return Heap_size._500_kb; }
        if( _size < 1_000_000 ){ return Heap_size._1_mb; }

        CONTROLLER__errors.Throw( $"Can not handle size <Color=lightBlue>{ _size }</Color>" );

        return Heap_size.not_give;

    }

    public void Destroy(){

        foreach( Heap_key key in unique_keys.Values )
            { Return_key_UNIQUE( key, false ); }

    }

    

}

