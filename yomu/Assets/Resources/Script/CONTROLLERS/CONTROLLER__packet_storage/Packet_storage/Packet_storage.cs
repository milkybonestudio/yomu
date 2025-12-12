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

    public Data_file_link data;


    // ** ALOC/FREE
        public Packet_key Alloc_packet( int _size ){ return Get_pointer()->Alloc_packet( _size ); }
        public Packet_key Alloc_packet_array<T>( int _size )where T:unmanaged{ return Get_pointer()->Alloc_packet_array<T>( _size ); }

        public void Dealloc_packet( Packet_key _key ){ Get_pointer()->Dealloc_packet( _key ); }


    // ** PACKETS
        public Packet_array<T> Get_packet_array<T>( Packet_key _key )where T:unmanaged{ return Get_pointer()->Get_packet_array<T>( _key ); }
        public Packet Get_packet( Packet_key _key ){ return Get_pointer()->Get_packet( _key ); }


    // ** WRITE/READ
        public void Overwrite_packet<T>( Packet_key _key, T _value )where T:unmanaged{ Get_pointer()->Overwrite_packet<T>( _key, _value ); }
        public void Overwrite_packet_array<T>( Packet_key _key, int _index, T _value )where T:unmanaged{ Get_pointer()->Overwrite_packet_array<T>( _key, _index, _value ); }


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

