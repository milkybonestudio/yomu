using System.Runtime.InteropServices;

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