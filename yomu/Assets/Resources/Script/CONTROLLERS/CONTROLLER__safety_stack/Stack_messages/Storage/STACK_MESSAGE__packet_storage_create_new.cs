using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Explicit)]
unsafe public struct STACK_MESSAGE__packet_storage_create_new {

    // ** só tem que mudar no arquivo, a chave vai ser alocada junto como change_data

    [ FieldOffset( 0 ) ]
    public Stack_message_core core_message;

        // ** SPECIFIC FROM TYPE

        [ FieldOffset( 8 ) ]
        public int file_id;

        [ FieldOffset( 12 ) ]
        public int file_start_length;

        [ FieldOffset( 16 ) ]
        public byte data;

        
}

