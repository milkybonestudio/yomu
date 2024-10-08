// using System;
// using UnityEngine;

// public static class GERENCIADOR__dados_dispositivos_SUPORTE {




//         public static void Verificar_tempos_sequencia( float[] _tempos, Color[] _cores, string _indentificador ){

//             if( _cores == null )
//                 { 
//                     if( _tempos != null )
//                         { throw new Exception( $"Nao foi definido as cores no {_indentificador } mas foi definido os tempos" );}

//                     return; 
//                 }

//             if( _tempos == null )
//                 { return; }

//             if( _tempos.Length != _cores.Length )
//                 { throw new Exception($"Foi declarado {_tempos.Length} tempos para a sequencia {_indentificador }, mas tinha { _cores.Length}"); }

//             return;

//         }

//         public static void Verificar_nome( string nome_dispositivo, string _nome ){

//                if( _nome == "" || _nome == null )
//                     { throw new Exception( $"Nao foi colocado o nome da imagem estatica no dispositivo <Color=lighBlue><b>{ nome_dispositivo }</b></color>" ); }
//                 return;
//         }


//         public static Color Mudar_cor_default( Color _cor_nos_dados, Color _cor_default ){


//                 if( _cor_nos_dados != Cores.cor_default_dispositivo )
//                     { return _cor_nos_dados; }


//                 // --- COLOCAR DEFAULT
//                 return _cor_default; 
                    
                    
//         }


//         public static Color[] Mudar_cor_default_sequecia( Tipo_pegar_sprite _tipo, Color[] _cor_nos_dados, int[] _ids, object[] chaves, Color _cor_default, string _indentificador = "NAO INDENTIFICADO" ){

//                 // --- PEGAR IMAGENS

//                 int numero_de_imagens = -1;

//                 if( _tipo == Tipo_pegar_sprite.nada )
//                     { return null; }

//                 if( _tipo == Tipo_pegar_sprite.imagem_especifica )
//                     { numero_de_imagens = _ids.Length; }

//                 if( _tipo == Tipo_pegar_sprite.imagem_geral )
//                     { numero_de_imagens = chaves.Length; }



//                 if( _cor_nos_dados != null )
//                     { 
//                         // --- VERIFICAR SE CORES FAZEN SENTIDO

//                         if( _cor_nos_dados.Length != numero_de_imagens )
//                             { throw new Exception( $"Declarou cores no indentificador { _indentificador } mas tinham { _cor_nos_dados.Length } cores e a sequencia tinha { numero_de_imagens } imagens" ); }

//                         return _cor_nos_dados; 
                        
//                     }



//                 Color[] retorno =  new Color[ numero_de_imagens ];

//                 for( int index = 0 ; index < retorno.Length ; index++ )
//                     { retorno[ index ] = _cor_default; }

//                 return retorno;

//         }



//         public static Tipo_pegar_sprite Pegar_tipo_pegar_imagem_simples( string nome_dispositivo, string _nome_parte, int _imagem_id, object _chaves, bool _precisa_definir ){


//                 bool tem_especifico = ( _imagem_id > 0 );
//                 bool tem_geral = ( _chaves != null );

//                 // --- VERIFICA

                        
//                 if ( tem_especifico && tem_geral  )
//                     {  throw new Exception($"No <Color=lightBlue><b>{ _nome_parte }</b></color> do dispositivo <Color=lightBlue><b>{ nome_dispositivo }</b></color> foi colocado tanto chaves validas (chave 1: <Color=lightBlue><b>{ _chaves.GetType().Name.Split( "__" )[ 0 ] }</b></color>, chave 2: <Color=lightBlue><b>{ _chaves.ToString() }</b></color>) quando foi colocado um id (<Color=lightBlue><b>{ _imagem_id }</b></color>)"); }

//                 if( tem_especifico )
//                     { return Tipo_pegar_sprite.imagem_especifica; }

//                 if( tem_geral )
//                     { return Tipo_pegar_sprite.imagem_geral; }

//                 if( _precisa_definir )
//                     { throw new Exception($"No <Color=lightBlue><b>{ _nome_parte }</b></color> do dispositivo <Color=lightBlue><b>{ nome_dispositivo }</b></color> nao foi colocado dados para definir qual o tipo de imagem") ; }


//                 return Tipo_pegar_sprite.nada; 

                

//         }

        
//         public static Tipo_pegar_sprite Pegar_tipo_pegar_imagem_sequencia( string nome_dispositivo, string _nome_parte, int[] _ids, object[] _chaves, bool _imagem_vazia, bool _precisa_definir ){



//                 bool tem_especifico = ( _ids != null );
//                 bool tem_geral = ( _chaves != null );

//                 // --- VERIFICA

//                 if( tem_especifico && _imagem_vazia )
//                     { throw new Exception($"No <Color=lightBlue><b>{ _nome_parte }</b></color> do dispositivo <Color=lightBlue><b>{ nome_dispositivo }</b></color> foi colocado tanto um ids validos quando foi indicado que era uma <Color=lightBlue><b>imagem vazia</b></color>"); }

//                 if( tem_geral && _imagem_vazia )
//                     { throw new Exception($"No <Color=lightBlue><b>{ _nome_parte }</b></color> do dispositivo <Color=lightBlue><b>{ nome_dispositivo }</b></color> foi colocado tanto chaves validas quando foi indicado que era uma <Color=lightBlue><b>imagem vazia</b></color>"); }

//                 if ( tem_especifico && tem_geral )
//                     {  throw new Exception($"No <Color=lightBlue><b>{ _nome_parte }</b></color> do dispositivo <Color=lightBlue><b>{ nome_dispositivo }</b></color> foi colocado tanto chaves validas quando foi colocado ids validos"); }


//                 if( tem_especifico )
//                     { return Tipo_pegar_sprite.imagem_especifica; }


//                 if( tem_geral )
//                     { return Tipo_pegar_sprite.imagem_geral; }


//                 if( _imagem_vazia ) 
//                     { return Tipo_pegar_sprite.nada; }

//                 if( _precisa_definir )
//                     { throw new Exception($"No <Color=lightBlue><b>{ _nome_parte }</b></color> do dispositivo <Color=lightBlue><b>{ nome_dispositivo }</b></color> nao foi colocado dados para definir qual o tipo de imagem");  }

//                 return Tipo_pegar_sprite.nada; 

           
//         }
        







// }