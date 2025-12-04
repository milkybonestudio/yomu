
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Explicit)]
unsafe public struct STACK_MESSAGE__delete_file {

    // ** ONLY GIVE THE ID TO A PATH

    [ FieldOffset( 0 ) ]
    public Stack_message_core core_message;

    // ** SPECIFIC FROM TYPE

    [ FieldOffset( 8 ) ]
    public int file_id;

    [ FieldOffset( 12 ) ]
    public int length_path;

    [ FieldOffset( 16 ) ]
    public byte pointer_data_path;

    // ** DATA


}

