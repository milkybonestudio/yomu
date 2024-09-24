using System.Runtime.InteropServices;


unsafe public struct Character_desires_data {


    public Internal_pointer sexual_desire_IP; // array de desires
    public Internal_pointer combat_desire_IP;  // 


    public short number_sexual_desires;
    public short number_combat_desires;


}



[ StructLayout(LayoutKind.Explicit) ]        
unsafe public struct Internal_pointer {

    [ FieldOffset( 0 ) ] public int pointer;
    [ FieldOffset( 0 ) ] public byte length; 

}





[ StructLayout(LayoutKind.Explicit ) ]        
unsafe public struct Internal_changing_pointer {

    [ FieldOffset( 0 ) ] public int pointer;
    [ FieldOffset( 0 ) ] public byte number_bytes;
    [ FieldOffset( 4 ) ] public byte data;
    

}



