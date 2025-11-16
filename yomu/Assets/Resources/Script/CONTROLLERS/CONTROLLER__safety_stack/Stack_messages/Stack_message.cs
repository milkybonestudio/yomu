
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Explicit)]
    unsafe public struct Stack_message {

        [ FieldOffset( 0 ) ]
        public Safety_stack_action_type type;

        [ FieldOffset( 4 ) ]
        public int length;

    }
