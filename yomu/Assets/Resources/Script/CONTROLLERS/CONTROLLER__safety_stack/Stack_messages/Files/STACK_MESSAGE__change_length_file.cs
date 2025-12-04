

using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Explicit)]
unsafe public struct STACK_MESSAGE__change_length_file {

    // ** NEVER ADD DATA< JUST CUT/EXPAND
    
    [ FieldOffset( 0 ) ]
    public Stack_message_core core_message;

    // ** SPECIFIC FROM TYPE

    [ FieldOffset( 8 ) ]
    public int file_id;


    [ FieldOffset( 12 ) ]
    public int new_length;



}
