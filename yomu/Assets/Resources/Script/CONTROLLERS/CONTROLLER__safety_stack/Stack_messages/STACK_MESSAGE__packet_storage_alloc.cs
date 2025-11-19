using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Explicit)]
unsafe public struct STACK_MESSAGE__packet_storage_alloc {

    [ FieldOffset( 0 ) ]
    public Stack_message_core core_message;

    // ** SPECIFIC FROM TYPE

    [ FieldOffset( 8 ) ]
    public Packet_storage_size size;

    
    [ FieldOffset( 12 ) ]
    public int slot;

    
    [ FieldOffset( 16 ) ]
    public int file_id;


}


[StructLayout(LayoutKind.Explicit)]
unsafe public struct STACK_MESSAGE__file_change {

    [ FieldOffset( 0 ) ]
    public Stack_message_core core_message;

    // ** SPECIFIC FROM TYPE

    [ FieldOffset( 8 ) ]
    public int file_id;

    
    [ FieldOffset( 12 ) ]
    public int point_to_change;

    
    [ FieldOffset( 16 ) ]
    public int length;

    [ FieldOffset( 20 ) ]
    public byte pointer_data;

    // ** DATA


}



[StructLayout(LayoutKind.Explicit)]
unsafe public struct STACK_MESSAGE__create_new_file {

    [ FieldOffset( 0 ) ]
    public Stack_message_core core_message;

    // ** SPECIFIC FROM TYPE

    [ FieldOffset( 8 ) ]
    public int file_id;


    [ FieldOffset( 12 ) ]
    public int length_file;

    [ FieldOffset( 16 ) ]
    public int length_path;

    [ FieldOffset( 20 ) ]
    public byte pointer_data_path;

    // ** DATA


}





