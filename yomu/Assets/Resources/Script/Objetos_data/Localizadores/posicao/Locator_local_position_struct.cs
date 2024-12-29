using System.Runtime.InteropServices;


//mark 
// ** nao testei





[StructLayout(LayoutKind.Explicit)]
unsafe public struct Locator_local_position {



        #if UNITY_EDITOR

            [ FieldOffset( 0 ) ]
            public byte zona_id;  // zona leste da catedral

            [ FieldOffset( 1 ) ]
            public byte local_id; // dormitorio_feminino

            [ FieldOffset( 2 ) ]
            public byte area_id;  // nara room 

            [ FieldOffset( 3 ) ]
            public byte ponto_id; // ponto

            [ FieldOffset( 0 ) ]
            public int unique_id;

                [FieldOffset( 54 )]
                public fixed char zona_nome[ 50 ];

                [FieldOffset( 104 )]
                public fixed char local_nome[ 50 ];

                [FieldOffset( 154 )]
                public fixed char area_nome[ 50 ];

                [FieldOffset( 204 )]
                public fixed char ponto_nome[ 50 ];

        #else

            [ FieldOffset( 0 ) ]
            public byte zona_id;  // zona leste da catedral

            [ FieldOffset( 1 ) ]
            public byte local_id; // dormitorio_feminino

            [ FieldOffset( 2 ) ]
            public byte area_id;  // nara room 

            [ FieldOffset( 3 ) ]
            public byte ponto_id; // ponto

            [ FieldOffset( 0 ) ]
            public int unique_id;

        #endif

}
