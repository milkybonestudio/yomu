using System.Runtime.InteropServices;


//mark 
// ** nao testei


[StructLayout(LayoutKind.Explicit)]
unsafe public struct Locator_global_position {

        #if UNITY_EDITOR

            [ FieldOffset( 0 ) ]
            public fixed char regiao_nome[ 50 ]; 

            [ FieldOffset( 50 ) ]
            public fixed char trecho_nome[ 50 ]; 

            [ FieldOffset( 100 ) ]
            public fixed char cidade_no_trecho_nome[ 50 ]; 

                // ** nao vai ficar no personagem, vai ficar no dados essenciais 
                [ FieldOffset( 151 ) ]
                public short regiao_id; // fixo 

                [ FieldOffset( 153 ) ]
                public byte trecho_id; // catedral // cada trecho pode mudar mas o numero de trechos é fixo 

                [ FieldOffset( 154 ) ]
                public byte cidade_no_trecho_id; // qual cidade esta nesse trecho

                [ FieldOffset( 151 ) ]
                public int unique_id;


        #else //--- BUILD

            // ** nao vai ficar no personagem, vai ficar no dados essenciais 
            [ FieldOffset( 0 ) ]
            public short regiao_id; // fixo 

            [ FieldOffset( 3 ) ]
            public byte trecho_id; // catedral // cada trecho pode mudar mas o numero de trechos é fixo 

            [ FieldOffset( 4 ) ]
            public byte cidade_no_trecho_id; // qual cidade esta nesse trecho

            [ FieldOffset( 0 ) ]
            public int unique_id;


        #endif


}

