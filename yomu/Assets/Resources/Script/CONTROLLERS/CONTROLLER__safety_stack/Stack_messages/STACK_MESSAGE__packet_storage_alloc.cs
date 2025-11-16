using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Explicit)]
    unsafe public struct STACK_MESSAGE__packet_storage_alloc {

        [ FieldOffset( 0 ) ]
        public Stack_message core_message;

        // ** SPECIFIC FROM TYPE

        [ FieldOffset( 8 ) ]
        public Packet_storage_size size;

        
        [ FieldOffset( 12 ) ]
        public int slot;

        
        [ FieldOffset( 16 ) ]
        public int file_id;


    }



