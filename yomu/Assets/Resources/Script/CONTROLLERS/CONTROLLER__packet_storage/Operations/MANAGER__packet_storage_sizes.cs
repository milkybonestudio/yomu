
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst;


unsafe public struct MANAGER__packet_storage_sizes {

    public void Start(){

        if( is_being_used )
            { CONTROLLER__errors.Throw( "Packet_storage_general was not end()" ); }

        is_being_used = true;
        int required_bytes = ( int ) Packet_storage_size.END * sizeof( int );         
        sizes = ( int* ) Controllers.heap.Get_unique( required_bytes ).Get_pointer();

        sizes_enum = (Packet_storage_size[]) Enum.GetValues( typeof(Packet_storage_size) );

        sizes[ ( int ) Packet_storage_size._0_bytes ] = 0;
        sizes[ ( int ) Packet_storage_size._1_byte ] = 1;
        sizes[ ( int ) Packet_storage_size._2_bytes ] = 2;
        sizes[ ( int ) Packet_storage_size._3_bytes ] = 3;
        sizes[ ( int ) Packet_storage_size._4_bytes ] = 4;
        sizes[ ( int ) Packet_storage_size._5_bytes ] = 5;
        sizes[ ( int ) Packet_storage_size._10_bytes ] = 10;
        sizes[ ( int ) Packet_storage_size._20_bytes ] = 20;
        sizes[ ( int ) Packet_storage_size._40_bytes ] = 40;
        sizes[ ( int ) Packet_storage_size._60_bytes ] = 60;
        sizes[ ( int ) Packet_storage_size._80_bytes ] = 80;
        sizes[ ( int ) Packet_storage_size._120_bytes ] = 120;
        sizes[ ( int ) Packet_storage_size._160_bytes ] = 160;
        sizes[ ( int ) Packet_storage_size._200_bytes ] = 200;
        sizes[ ( int ) Packet_storage_size._250_bytes ] = 250;
        sizes[ ( int ) Packet_storage_size._300_bytes ] = 300;
        sizes[ ( int ) Packet_storage_size._350_bytes ] = 350;
        sizes[ ( int ) Packet_storage_size._400_bytes ] = 400;
        sizes[ ( int ) Packet_storage_size._500_bytes ] = 500;
        sizes[ ( int ) Packet_storage_size._700_bytes ] = 700;
        sizes[ ( int ) Packet_storage_size._900_bytes ] = 900;
        sizes[ ( int ) Packet_storage_size._1000_bytes ] = 1000;
        sizes[ ( int ) Packet_storage_size._1500_bytes ] = 1500;
        sizes[ ( int ) Packet_storage_size._2000_bytes ] = 2000;
        sizes[ ( int ) Packet_storage_size._3000_bytes ] = 3000;
        sizes[ ( int ) Packet_storage_size._4000_bytes ] = 4000;
        sizes[ ( int ) Packet_storage_size._5000_bytes ] = 5000;
        sizes[ ( int ) Packet_storage_size._10_kb ] = 10_000;
        sizes[ ( int ) Packet_storage_size._15_kb ] = 15_000;
        sizes[ ( int ) Packet_storage_size._20_kb ] = 20_000;
        sizes[ ( int ) Packet_storage_size._25_kb ] = 25_000;
        sizes[ ( int ) Packet_storage_size._40_kb ] = 40_000;
        sizes[ ( int ) Packet_storage_size._55_kb ] = 55_000;
        sizes[ ( int ) Packet_storage_size._70_kb ] = 70_000;
        sizes[ ( int ) Packet_storage_size._100_kb ] = 100_000;
        
            sizes[ ( int ) Packet_storage_size._MAX ] = int.MaxValue;

        if( System_run.max_security )
            {
                foreach( Packet_storage_size size in sizes_enum ) 
                    {
                        if( sizes[ ( int ) size ] == 0 && ( size != Packet_storage_size.END ) && ( size != Packet_storage_size._0_bytes ) )
                            { CONTROLLER__errors.Throw( $"Did not define value for the size <Color=lightBlue>{ size }</Color>" ); }
                    }
            }

        

    }

    public bool is_being_used;
    public int* sizes;



    public void Destroy(){

        is_being_used = false;
        sizes = default;

    }


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int Get_size_in_bytes( Packet_storage_size _size ){

        if( sizes == null )
            { Start(); }

        if( System_run.max_security )
            {
                if( _size < Packet_storage_size._0_bytes || _size > Packet_storage_size._MAX )
                    { CONTROLLER__errors.Throw( $"Can not handle size <Color=lightBlue>{ _size }</Color>" ); }
            }

        return sizes[ ( int ) _size ];

    }


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Packet_storage_size Get_required_size( int _size_in_bytes ){

        if( sizes == null )
            { Start(); }
        
        int index = Ceiling( sizes, ( int ) Packet_storage_size.END , _size_in_bytes );

        if( System_run.max_security )
            {
                if( index < 0 )
                    { CONTROLLER__errors.Throw( $"Negative index in <Color=lightBlue>Get_size </Color>" ); }

                if( index > ( int ) Packet_storage_size._MAX )
                    { CONTROLLER__errors.Throw( $"Problem with the Ceiling function, return the index <Color=lightBlue>{ index }</Color>, but the max is <Color=lightBlue>{ ( int ) Packet_storage_size._100_kb }</Color>" ); }

                if( index == ( int ) Packet_storage_size._MAX )
                    { CONTROLLER__errors.Throw( $"Can not handle size <Color=lightBlue>{ _size_in_bytes }</Color>, the max is <Color=lightBlue>{ sizes[ ( int ) Packet_storage_size._MAX - 1 ] }</Color>" ); }

            }

        return ( Packet_storage_size ) index;

    }

    [BurstCompile]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private int Ceiling( int* _data, int _length, int _value ){

        int low = 0;
        int high = _length;

        while ( low <= high ){

            int mid = ( low + high ) >> 1;
            int midVal = _data[ mid ];

            if ( midVal < _value )
                { low = mid + 1; }
                else
                { high = mid - 1; }
                
        }

        return low;

    }

    public Packet_storage_size[] sizes_enum;




}