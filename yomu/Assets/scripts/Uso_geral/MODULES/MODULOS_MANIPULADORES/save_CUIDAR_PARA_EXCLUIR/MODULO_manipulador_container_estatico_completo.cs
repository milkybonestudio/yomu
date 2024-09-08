// using System;
// using System.IO;
// using System.Reflection;
// using UnityEngine;



// public class MODULO_manipulador_container_estatico_completo {

//         // *** vai sempre ter um container carregado e vai entregar partes do container no formato pointer, length
//         // **  pode modificar o container e reescrever dados
        

//         public MODULO_manipulador_container_estatico_completo(  string _nome_manipulador, string _path_container, bool _pode_escrever_no_container, bool _forcar_pegar_container ){ 


//                 if( !( System.IO.File.Exists( _path_container ) ) )
//                     {  throw new Exception( $"nao foi achado o container no path { _path_container }" ); }

                

//                 pode_escrever_no_container = _pode_escrever_no_container;
//                 nome_manipulador = _nome_manipulador;
//                 path_container = _path_container;

                

//                 if( _forcar_pegar_container )
//                         {
//                                 // --- PEGAR AGORA 
//                                 dados_atuais = System.IO.File.ReadAllBytes( _path_container );

//                         }
//                         else
//                         {
//                                 // --- PODE ESPERAR
//                                 Carregar_novo_container( path_container );
//                         }

//                 return;

//         }


//         // --- DADOS

//         public string nome_manipulador;
//         public bool pode_escrever_no_container;
//         public string path_container;
//         public byte[] dados_atuais;
//         public Task_req req_pegar_container;




//         public void Carregar_novo_container( string _path ){


//                         if( req_pegar_container != null )
//                         {
//                                 // --- TEM ALGO SENDO CARREGADO

//                                 // --- NAO DEIXA TERMINAR
//                                 req_pegar_container.pode_executar = false;
//                                 req_pegar_container = null;

//                         }



//                         req_pegar_container = new Task_req( new Chave_cache(), $"Carregando dados do { nome_manipulador }" );

//                         req_pegar_container.fn_iniciar = ( Task_req _req ) =>   {

//                                                                                         byte[] dados = System.IO.File.ReadAllBytes( path_container );

//                                                                                         req_pegar_container.dados = ( System.Object ) dados;
//                                                                                         return;

//                                                                                 };

//                         req_pegar_container.fn_finalizar = ( Task_req _req ) => {

//                                                                                         byte[] dados = ( byte[] ) req_pegar_container.dados;
//                                                                                         dados_atuais = dados;
//                                                                                         return;
//                                                                                         req_pegar_container = null;

//                                                                                 };

//                         return;

//         }



//         public void Escrever_dados(  int _localizador_id , byte[] _dados ){

                
//                 if( !( pode_escrever_no_container ) )
//                         { throw new Exception( $"tentou escrever no container { nome_manipulador }" ); } 



//                 // System.IO.File.WriteAllBytes( path , _dados );

//                 // FileMode file_mode = FileMode.Open;
//                 // FileAccess file_accees = FileAccess.ReadWrite;
//                 // FileShare file_share = FileShare.Read;
//                 // FileOptions file_options = FileOptions.WriteThrough;

//                 // FileStream str = new FileStream(  path_temp,  file_mode, file_accees , file_share, dados.Length , file_options );

//                 // str.Flush();
//                 // str.Close();

//                 return;

//         }
            


//         // ---- FUNCOES SUPORTE


//         public bool Verificar_se_container_ja_foi_pedido( int _localizador_id ){

//         //        // --- VERIFICA SE TEM SLOT
//         //         for( int slot_index = 0 ; slot_index < localizadores_ids.Length ; slot_index++ ){

//         //                 if( localizadores_ids[ slot_index ] ==  _localizador_id )
//         //                         { return true; }
//         //                 continue;

//         //         }

//                 return false;

//         }



// }