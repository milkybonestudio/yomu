// using System;
// using System.IO;
// using System.Reflection;
// using UnityEngine;





// public class MODULO_manipulador_containers_estaticos_parciais {

//         // ** carrega parte de um grande arquivo em cessoes. 

//         public MODULO_manipulador_containers_estaticos_parciais(  string _path_container, int _numero_inicial_de_slots  ){ 


//                 path_container = _path_container;

//                 localizadores_ids = new int[ _numero_inicial_de_slots ];
//                 quantidade_de_bytes_dados = new int[ _numero_inicial_de_slots ];
//                 set_dados_parciais = new byte[ _numero_inicial_de_slots ][];
//                 requisicoes = new Task_req[ _numero_inicial_de_slots ];

//                 return;

//         }


//         public string path_container;
        
//         public int[] localizadores_ids;

//         public int[] quantidade_de_bytes_dados;

//         public byte[][] set_dados_parciais;
//         public Task_req[] requisicoes;


//         public void Update(){
//                 // -1 => guardar indefinidamente 
//                 //  0 => ja excluiu
//                 // >0 => esperando para excluir


//                 // for( int sprite_slot = 0 ; sprite_slot < sprite_ids_unicos.Length ; sprite_slot++ ){

//                 //         // --- VERIFICA SE O SLOT ESTA SENDO USADO
//                 //         if( sprite_ids_unicos[ sprite_slot ] == 0 )
//                 //                 { continue; } // --- NAO ESTA SENDO USADO




//                 //         // --- VERIFICA SE O SLOT SPRITE PODE SER EXCLUIDO
//                 //         if( frames_para_guardar_sprites[ sprite_slot ] == 1 )
//                 //                 { 
//                 //                         // --- PODE SER APAGADO ESSE FRAME
//                 //                         frames_para_guardar_sprites[ sprite_slot ] = 0;
//                 //                         sprites_atuais[ sprite_slot ] = null;
//                 //                 } 

//                 //         // --- VERIFICAR SE TEM TEMPO PARA DESCONTAR
//                 //         if( frames_para_guardar_sprites[ sprite_slot ] > 1 )
//                 //                 { frames_para_guardar_sprites[ sprite_slot ]--; } // --- TIRA 1 FRAME 
                        

                        
                                
//                 //         // --- VERIFICA SE O SLOT SPRITE PODE SER EXCLUIDO
//                 //         if( frames_para_guardar_sprites[ sprite_slot ] == 1 )
//                 //                 { 
//                 //                         // --- PODE SER APAGADO ESSE FRAME
//                 //                         frames_para_guardar_pngs[ sprite_slot ] = 0;
//                 //                         sprites_atuais[ sprite_slot ] = null;
//                 //                 } 
                        

//                 //         // --- VERIFICAR SE TEM TEMPO PARA DESCONTAR
//                 //         if( frames_para_guardar_pngs[ sprite_slot ] > 1 )
//                 //                 { frames_para_guardar_pngs[ sprite_slot ]--; } // --- TIRA 1 FRAME 





//                 //         // --- VERIFICA SE PODE APAGAR SLOT            
//                 //         if( sprites_atuais[ sprite_slot ] == null && pngs_atuais[ sprite_slot ] == null )
//                 //                 { sprite_ids_unicos[ sprite_slot ] = 0;  }// --- SLOT VAI SER LIMPO


//                 //         // --- VAI PARA O PROXIMO
//                 //         continue;

//                 // } 

//         }
            

//         public byte[][] Pegar_set_dados_parciais(){ return null; }


//         public byte[] Pegar_dados ( int _localizador_id ){

//                 // sempre tem que carregar primeiro. Em teste carrega primeiro para colocar o path e logo em sequencia já pega 


//                 // --- GARANTE QUE TEM
//                 int slot_index = Pegar_slot( _localizador_id );
                
//                 byte[] container =  set_dados_parciais[ slot_index ];

//                 // --- VERIFICA SE O CONTAINER FOI CARREGADO
//                 if( container != null )
//                         {  return container; }


//                 // --- VAI FORCAR
                
//                 if( requisicoes[ slot_index ] != null )
//                         {
//                                 requisicoes[ slot_index ].pode_executar = false;
//                                 requisicoes[ slot_index ] = null;

//                         }
                
//                 int length_dados = quantidade_de_bytes_dados[ slot_index ];


//                 FileMode file_mode = FileMode.Open;
//                 FileAccess file_accees = FileAccess.Read;
//                 FileShare file_share = FileShare.Read;
//                 FileOptions file_options = FileOptions.None; // talvez nao?
//                 FileStream file_stream = new FileStream( path_container,file_mode, file_accees , file_share, length_dados , file_options );


//                 file_stream.Seek(  _localizador_id,  SeekOrigin.Begin );

//                 byte[] buffer  = new byte[ length_dados ];
//                 file_stream.Read( buffer, 0, length_dados );
//                 file_stream.Close();

//                 set_dados_parciais[ slot_index ] = buffer;

//                 return buffer;
                

//         }


//         public void Carregar_dados_NA_MULTITHREAD( int _localizador_id, int _length_dados ){

                
//                 int slot = Criar_slot( _localizador_id );

//                 quantidade_de_bytes_dados[ slot ] = _length_dados;


//                 Task_req task = new Task_req( new Chave_cache() , $"pegar_{ _localizador_id } dados parciais"  );                                                

//                 task.dados_array_suporte = new System.Object[ 0 ];

//                 task.fn_iniciar = ( Task_req _req ) => {
//                                                                 // --- CRIA STREAM
//                                                                 FileMode file_mode = FileMode.Open;
//                                                                 FileAccess file_accees = FileAccess.Read;
//                                                                 FileShare file_share = FileShare.Read;
//                                                                 FileOptions file_options = FileOptions.None; // talvez nao?

//                                                                 FileStream file_stream = new FileStream( path_container,file_mode, file_accees , file_share, _length_dados , file_options );
//                                                                 file_stream.Seek(  _localizador_id,  SeekOrigin.Begin );

//                                                                 // --- PEGA OS DADOS
//                                                                 byte[] buffer  = new byte[ _length_dados ];
//                                                                 file_stream.Read( buffer, 0, _length_dados );
//                                                                 file_stream.Close();

//                                                                 _req.dados_array_suporte[ 0 ] = ( System.Object ) buffer;

//                                                                 return;

//                                                         };

//                 task.fn_finalizar = ( Task_req _req )=>{
//                                                                 byte[] dados_parciais =  ( byte[] ) _req.dados_array_suporte[ 0 ];
//                                                                 set_dados_parciais[ slot ] = dados_parciais;

//                                                                 return;

//                                                         };

//                 return;


//         }


//         // ---- FUNCOES SUPORTE


//         public bool Verificar_se_container_ja_foi_pedido( int _localizador_id ){

//                // --- VERIFICA SE TEM SLOT
//                 for( int slot_index = 0 ; slot_index < localizadores_ids.Length ; slot_index++ ){

//                         if( localizadores_ids[ slot_index ] ==  _localizador_id )
//                                 { return true; }
//                         continue;

//                 }

//                 return false;

//         }

//         public void Remover_dados ( int _localizador_id ){

//                 int slot = Pegar_slot( _localizador_id );

                            
//                 localizadores_ids[ slot ] = 0;
//                 set_dados_parciais[ slot ] = null;

//                 if( requisicoes[ slot ] != null )
//                         {
//                                 requisicoes[ slot ].pode_executar = false;
//                                 requisicoes[ slot ] = null;

//                         }

//                 return;

//         }


//         // --- INTERNO 

//         public int Pegar_slot( int _localizador_id ){
        
//                 for( int slot_index = 0 ; slot_index < localizadores_ids.Length ; slot_index++ ){

//                         if( localizadores_ids[ slot_index ] ==  _localizador_id )
//                                 { return slot_index; }
//                         continue;
//                 }

                

//                 Debug.Log( "------------ ERRO -------------" );
//                 Debug.LogError( $"Pediu o localizador { _localizador_id } mas ninguem pediu ele" );
//                 Debug.Log( "-------------------------------" );
//                 throw new Exception();
                
//         }

//         public int Criar_slot( int _localizador_id ){


//                 // --- VERIFICA SE TEM SLOT

//                 int slot_livre = -1;
//                 for( int slot_index = 0 ; slot_index < localizadores_ids.Length ; slot_index++ ){

//                         // --- VERIFICA SE ESTA LIVRE
//                         if( localizadores_ids[ slot_index ] ==  0 )
//                                 {       
//                                         // ** talvez possa colocar algo aqui para verificar se os dados fora excluidos corretamente 
//                                         slot_livre = slot_index;
//                                         localizadores_ids[ slot_index ] = _localizador_id;
//                                         continue;
//                                 }

//                         // --- VERIFICA SE NAO FOI PEGO ANTES
//                         if( localizadores_ids[ slot_index ] ==  0 )
//                             { 
//                                 #if UNITY_EDITOR
//                                     //Teste_play.Verificar_se_realmente_foi_pedido( slot_teste, _id, requisicoes, dados_parciais_entidade, AIs );
//                                 #endif
//                                 return slot_index; 
//                             }

//                         continue;

//                 }

//                 // --- SE TIVER VAI RETORNAR

//                 if( slot_livre != -1 )
//                     { return slot_livre; }
                

//                 // --- CRIA MAIS SLOTS

//                 int index_final_livre = localizadores_ids.Length;

//                 int[] novo_inds = new int[ localizadores_ids.Length + 20 ];
//                 byte[][] novo_containers = new byte[ localizadores_ids.Length + 20][];
                

//                 for( int index_antigo = 0 ; index_antigo < localizadores_ids.Length ; index_antigo++ ){

//                         novo_inds[ index_antigo ] = localizadores_ids[ index_antigo ];
//                         novo_containers[ index_antigo ] = set_dados_parciais[ index_antigo ];
                        
//                 }

                
//                 localizadores_ids = novo_inds;
//                 set_dados_parciais = novo_containers;

//                 localizadores_ids[ index_final_livre ] = _localizador_id;

//                 return index_final_livre;


//         }


// }