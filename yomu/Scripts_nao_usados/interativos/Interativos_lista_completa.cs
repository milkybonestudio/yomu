// using System.Reflection;
// using UnityEngine;



// public static class Interativos_lista_completa {



//     public static Interativo[] Pegar_lista(){

//         int numero_de_interativos = System.Enum.GetNames( typeof( Interativo_nome ) ).Length;
//         Interativo[] lista_completa = new Interativo[ numero_de_interativos ];

//         Interativos_lista_0.Colocar_interativos();
//         return lista_completa;

//     }

//     // ** modelo : dll

//     private static Assembly asm;
//     private static System.Object instancia;

//     public static Interativo Pegar_interativo( int _interativo_id ){


//         if( _interativo_id < 1000 )
//             {
//                 if( asm == null )
//                     {
//                         // LOAD
//                     }
                
//                 return  ( Interativo ) (( MethodInfo ) instancia ).Invoke (  null, new System.Object[ 0 ]  );
//             }

//         return null;


//     }


//     // modo : .dat

//     public static byte[] dados;
    
//     public static Interativo Pegar_interativo_( int _interativo_id ){

//         // PEGA BYTES PONTO INICIAL
//         byte ponto_inicial_b1 = dados[ (_interativo_id * 4 ) + 0 ];
//         byte ponto_inicial_b2 = dados[ (_interativo_id * 4 ) + 1 ];
//         byte ponto_inicial_b3 = dados[ (_interativo_id * 4 ) + 2 ];
//         byte ponto_inicial_b4 = dados[ (_interativo_id * 4 ) + 3 ];

//         // PEGA BYTES PONTO FINAL
//         byte ponto_final_b1 = dados[ (_interativo_id * 4 ) + 0 + 4 ];
//         byte ponto_final_b2 = dados[ (_interativo_id * 4 ) + 1 + 4 ];
//         byte ponto_final_b3 = dados[ (_interativo_id * 4 ) + 2 + 4 ];
//         byte ponto_final_b4 = dados[ (_interativo_id * 4 ) + 3 + 4 ];

//         // CRIA PONTO INICIAL
//         int ponto_inicial = 0;

//         ponto_inicial += ( ( int ) ponto_inicial_b1 ) << 24 ;
//         ponto_inicial += ( ( int ) ponto_inicial_b2 ) << 16 ;
//         ponto_inicial += ( ( int ) ponto_inicial_b3 ) << 8 ;
//         ponto_inicial += ( ( int ) ponto_inicial_b4 ) << 0 ;


//         // CRIA PONTO FINAL
//         int ponto_final = 0;

//         ponto_final += ( ( int ) ponto_final_b1 ) << 24 ;
//         ponto_final += ( ( int ) ponto_final_b2 ) << 16 ;
//         ponto_final += ( ( int ) ponto_final_b3 ) << 8 ;
//         ponto_final += ( ( int ) ponto_final_b4 ) << 0 ;

//         int length_dados = ( ponto_final = ponto_inicial );

//         byte[] interativo_dados = new byte[ length_dados ];

//         for( int byte_index = 0; byte_index < length_dados ; byte_index++ ){

//             interativo_dados[ byte_index ] = dados[ ponto_inicial + byte_index ];
//             continue;

//         }

//         Interativo retorno = new Interativo( 0 );

//         retorno.interativo_nome = ( Interativo_nome )   (
//                                                             ( ( int ) interativo_dados[ 0 ] << 8 )  
//                                                             +
//                                                             ( ( int ) interativo_dados[ 1 ] << 0 )  
//                                                         );

//                                                     return null;



//     }








// }

