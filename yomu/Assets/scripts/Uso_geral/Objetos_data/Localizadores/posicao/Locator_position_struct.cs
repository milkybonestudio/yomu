using System.Runtime.InteropServices;


//mark 
// ** nao testei


[StructLayout(LayoutKind.Explicit)]
unsafe public struct Locator_position {

        #if UNITY_EDITOR

            [ FieldOffset( 0 ) ]
            public Locator_global_position global_position;
            [ FieldOffset( 155 ) ]
            public Locator_local_position local_position;

            [ FieldOffset( 151 ) ]
            public long unique_id;

        #else
            // --- BUILD


            [ FieldOffset( 0 ) ]
            public Locator_global_position global_position;
            [ FieldOffset( 4 ) ]
            public Locator_local_position local_position;

            [ FieldOffset( 0 ) ]
            public long unique_id;
            
        #endif

}
