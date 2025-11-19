
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Explicit)]
    unsafe public struct Stack_message_core {

        [ FieldOffset( 0 ) ]
        public int length;

        [ FieldOffset( 4 ) ]
        public Safety_stack_action_type type;

    }
