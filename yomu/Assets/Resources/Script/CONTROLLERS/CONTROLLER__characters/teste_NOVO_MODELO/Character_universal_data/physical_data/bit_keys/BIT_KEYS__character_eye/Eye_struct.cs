using System.Runtime.InteropServices;


[StructLayout(LayoutKind.Explicit)]        
unsafe public struct Eye {


        [ FieldOffset( 0 ) ] public long value;

        [ FieldOffset( 0 ) ] public byte type;
        [ FieldOffset( 1 ) ] public byte size;
        [ FieldOffset( 2 ) ] public byte line;
        [ FieldOffset( 3 ) ] public byte shape;

        [ FieldOffset( 4 ) ] public short color;
        [ FieldOffset( 6 ) ] public byte details;
        [ FieldOffset( 7 ) ] public byte flow;

} 

