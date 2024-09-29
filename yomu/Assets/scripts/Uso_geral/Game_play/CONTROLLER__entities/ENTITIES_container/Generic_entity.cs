using System.Runtime.InteropServices;


[StructLayout(LayoutKind.Explicit)]        
unsafe public struct Generic_entity {


    
    [FieldOffset( 0 )] public int entity_id;    
    [FieldOffset( 8 )] public void* entity_universal_data;
    [FieldOffset( 16 )] public void* entity_specific_data;
    [FieldOffset( 24 )] public void* entity_system_data;
    [FieldOffset( 32 )] public void* entity_fundamental_data;

    [FieldOffset( 0 )] public Character get_character;
    [FieldOffset( 0 )] public Plot get_plot;
    [FieldOffset( 0 )] public City get_city;


}