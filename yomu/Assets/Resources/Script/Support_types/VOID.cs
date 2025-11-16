

using System.Runtime.CompilerServices;

unsafe public static class VOID {

    public static void* Move_pointer( void* _pointer, int _value ){

        return ( void* ) ( (( byte* ) _pointer ) + _value );

    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Transfer_data( void* _pointer_data, void* _pointer_to_transfer, int _length ){

        System.Buffer.MemoryCopy( _pointer_data, _pointer_to_transfer, ( long ) ( _length ), ( long ) ( _length ) ); 
        
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Transfer_data( int _bytes_to_copy, void* _source_data, int _length_source, void* _pointer_to_transfer, int _pointer_to_transfer_length  ){

        if( _bytes_to_copy > _pointer_to_transfer_length )
            { CONTROLLER__errors.Throw( $"Tried to transfer <Color=lightBlue>{ _bytes_to_copy } bytes</Color> but the pointer to transfer have <Color=lightBlue>{ _pointer_to_transfer_length } bytes </Color>" ); }

        if( _bytes_to_copy > _length_source )
            { CONTROLLER__errors.Throw( $"Tried to transfer <Color=lightBlue>{ _bytes_to_copy } bytes</Color> but the pointer <Color=lightBlue>WITH THE DATA</Color> have <Color=lightBlue>{ _length_source } bytes </Color>" ); }

        System.Buffer.MemoryCopy( _source_data, _pointer_to_transfer, ( long ) ( _pointer_to_transfer_length ), ( long ) ( _bytes_to_copy ) ); 
        
    }

}