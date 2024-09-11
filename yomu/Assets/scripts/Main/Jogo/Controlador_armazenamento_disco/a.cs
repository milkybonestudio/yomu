// using System.Runtime.InteropServices;



// [StructLayout(LayoutKind.Explicit)]
// public struct Plot_localizador{

//         [FieldOffset(0)]
//         public byte a_1;

//         [FieldOffset(0)]
//         public byte a_2;

//         [FieldOffset(0)]
//         public byte a_3;

//         [FieldOffset(0)]
//         public byte a_4;
        
//         [FieldOffset(0)]
//         public int indentificador;

// }



// public struct Dados {

//     public byte bloco; // 1 bytes
//     public short p_localizador; // ** 2 bytes


// }



// unsafe public class Load {


//     public byte[] Compress( Dados_brutos _dados ){

//         byte[] dados_compress = new byte[ sizeof( Dados ) ];

//         fixed( byte* dados_compres_pointer = dados_compress ){

//             Dados* dados_pointer = ( Dados* ) dados_compres_pointer;

//         }

                

//     }


//     public Dados Des_compress( byte[] _dados_raw ){

//         Dados dados = new Dados();


//     }

// }




// public class Load {

//     public byte[] Compress( Dados_brutos _dados ){

//         byte[] dados_compress = new byte[ 100 ];

//         int index = 0;

//         dados_compress[ ( int ) Localizador_dados.bloco ] = ( byte ) _dados.bloco;

//         dados_compress[ ( ( int ) Localizador_dados.personagem  + 0 ) ] = ( byte ) ( ( int )_dados.bloco >> 8 );
//         dados_compress[ ( ( int ) Localizador_dados.personagem  + 1 ) ] = ( byte ) ( ( int )_dados.bloco >> 0 );
                

//     }


//     public Dados_brutos Des_compress( byte[] _dados_raw ){

//         Dados_brutos dados = new Dados_brutos();

//         int index = 0;

//         dados.bloco = ( Bloco )( int ) _dados_raw[ ( int ) Localizador_dados.bloco ];

//         dados.personagem = ( Personagem_localizador )   (   
//                                                             ( _dados_raw[ ( ( int ) Localizador_dados.personagem  + 0 ) ] << 8 )  
//                                                             + 
//                                                             ( _dados_raw[ ( ( int ) Localizador_dados.personagem  + 1 ) ] << 0 ) 
//                                                         );
                

//     }




// }




