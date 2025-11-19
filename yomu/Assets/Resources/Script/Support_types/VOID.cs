

using System.Runtime.CompilerServices;

unsafe public static class VOID {

    public static void* Move_pointer( void* _pointer, int _value ){

        return ( void* ) ( (( byte* ) _pointer ) + _value );

    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Transfer_data( void* _pointer_data, void* _pointer_to_transfer, int _length ){


        if( _length == 0 )
            { return; }

        if( _length < 150 )
            {

                int left = _length % ( sizeof( int ) * 4  );

                byte* byte_p = (byte*) _pointer_data;
                byte* transfer_byte_p = (byte*)_pointer_to_transfer;


                for( int index_short = 0; index_short < left ; index_short++  )
                    { transfer_byte_p[ index_short ] =  byte_p[ index_short ]; }


                if( left == _length )
                    {return; }

                int* start_pointer_data = (int*) ( byte_p + left );

                    int* int_pointer_data_1 = start_pointer_data + 0;
                    int* int_pointer_data_2 = start_pointer_data + 1;
                    int* int_pointer_data_3 = start_pointer_data + 2;
                    int* int_pointer_data_4 = start_pointer_data + 3;

                int* start_pointer_transfer = (int*) ( transfer_byte_p + left  );

                    int* int_pointer_transfer_1 = start_pointer_transfer + 0;
                    int* int_pointer_transfer_2 = start_pointer_transfer + 1;
                    int* int_pointer_transfer_3 = start_pointer_transfer + 2;
                    int* int_pointer_transfer_4 = start_pointer_transfer + 3;

                int number_cycles = _length / ( sizeof( int ) * 4  );

                for( int index = 0; index < number_cycles ; index += 4 ){

                    int_pointer_transfer_1[ index ] = int_pointer_data_1[ index ];
                    int_pointer_transfer_2[ index ] = int_pointer_data_2[ index ];
                    int_pointer_transfer_3[ index ] = int_pointer_data_3[ index ];
                    int_pointer_transfer_4[ index ] = int_pointer_data_4[ index ];

                }


            }
            else
            {
                System.Buffer.MemoryCopy( _pointer_data, _pointer_to_transfer, ( long ) ( _length ), ( long ) ( _length ) ); 
            }

        
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