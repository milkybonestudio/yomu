


// unsafe public struct Packet_storage_TEST {

//     public Packet_key Get_key_FOR_TEST( Packets_storage_data* _pointer, Packet_storage_size _size, int _slot ){

//         //mark
//         // ???????????????????????????????????????????

//         #if !UNITY_EDITOR
//             CONTROLLER__errors.Throw( "Tentou chamar<Color=lightBlue>Get_key</Color> mas nao pode ser chamada na build" );
//         #endif

//         _pointer->Safety();

//         if( !!! ( _pointer->Can_have_specific_key( _size, _slot ) ) )
//             { CONTROLLER__errors.Throw( $"Tried to get the key of the size <Color=lightBlue>{ _size }</Color> and the slot <Color=lightBlue>{ _slot }</Color> but system can not have it" ); }

//         if( !!!( _pointer->Is_slot_used( _size, _slot ) ) )
//             { CONTROLLER__errors.Throw( $"Tried to get the key of the size <Color=lightBlue>{ _size }</Color> and the slot <Color=lightBlue>{ _slot }</Color> but system didnt allocated it" ); }



//         if( System_run.packet_storage_show_messages )
//             { Console.Log( $"will create a copy with NOT the same data of the packet_key {{ size = <Color=lightBlue>{ _size }</Color>, slot = <Color=lightBlue>{ _slot }</Color> }}. " ); }

//         // The length is not right because the Packet_storage dont stores it
//         return Packet_key.Construct(
//             _slot : _slot,
//             _size : _size,
//             _length : _pointer->sizes.Get_size_in_bytes( _size )
//         );
        
//     }



// }
