using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Explicit)]
unsafe public struct STACK_MESSAGE__packet_storage_alloc {

    // ** só tem que mudar no arquivo, a chave vai ser alocada junto como change_data

    [ FieldOffset( 0 ) ]
    public Stack_message_core core_message;

    // ** SPECIFIC FROM TYPE

    [ FieldOffset( 8 ) ]
    public Packet_storage_size size;

    
    [ FieldOffset( 12 ) ]
    public int slot;


    // FILE_ID? 
    
    [ FieldOffset( 16 ) ]
    public int file_id;


}

