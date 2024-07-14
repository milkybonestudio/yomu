using System;
using System.Reflection;
using UnityEngine;



public class Gerenciador_containers_dinamicos_completos {


        public Gerenciador_containers_dinamicos_completos(  string _folder_para_pegar_dados, int _numero_inicial_de_slots  ){ 

                nome_folder = _folder_para_pegar_dados;

                containers_paths= new string[ _numero_inicial_de_slots ];
                localizadores_ids = new int[ _numero_inicial_de_slots ];
                dados_containers = new byte[ _numero_inicial_de_slots ][];
                requisicoes = new Task_req[ _numero_inicial_de_slots ];            
                return;

        }


        public string nome_folder;
        
        public int[] localizadores_ids;
        public string[] containers_paths;

        public byte[][] dados_containers;
        public Task_req[] requisicoes;
            

        

        public byte[] Pegar_container ( int _localizador_id ){

                // sempre tem que carregar primeiro. Em teste carrega primeiro para colocar o path e logo em sequencia já pega 


                // --- GARANTE QUE TEM
                int slot_index = Pegar_slot( _localizador_id );
                
                byte[] container =  dados_containers[ slot_index ];

                // --- VERIFICA SE O CONTAINER FOI CARREGADO
                if( container != null )
                        {  return container; }


                // --- VAI FORCAR

                string container_path = containers_paths[ slot_index ];

                string path_dados = System.IO.Path.Combine( nome_folder, container_path );

                if( ! ( System.IO.File.Exists( path_dados ) ) )
                        { throw new Exception( $"O arquivo no path { path_dados } nao foi encontrado" ); }

                byte[] dados_bytes = System.IO.File.ReadAllBytes( path_dados );

                dados_containers[ slot_index ] = dados_bytes;

                return dados_bytes;
                

        }


        public void Carregar_container_NA_MULTITHREAD( int _localizador_id, string _container_path ){

                
                int slot_index = Criar_slot( _localizador_id );

                // --- CRIAR DADOS
                string container_path = containers_paths[ slot_index ];
                string path_dados = System.IO.Path.Combine( nome_folder, container_path );


                Task_req task = new Task_req( new Chave_cache() , $"pegar_{ _localizador_id }_containers_dinamicos_completos" );

                task.dados_array_suporte = new System.Object[ 0 ];

                task.fn_iniciar = ( Task_req _req ) => {
                                                                // --- DADOS CONTAINERS

                                                                if( !( System.IO.File.Exists( path_dados ) ) )
                                                                        { throw new Exception( $"nao foi achado o arquivo no path: { path_dados }" ); }

                                                                byte[] dados_bytes = System.IO.File.ReadAllBytes( path_dados );
                                                                _req.dados_array_suporte[ 0 ] = ( System.Object ) dados_bytes;

                                                                return;

                                                        };

                task.fn_finalizar = ( Task_req _req )=>{
                                                                byte[] container =  ( byte[] ) _req.dados_array_suporte[ 0 ];
                                                                dados_containers[ slot_index ] = container;

                                                                return;

                                                        };

                                                
                // ** --- COLOCAR DEPOIS
        
                // MethodInfo metodo_info = asm.GetType( metodo_nome ).GetMethod("Pegar_dados");

                // // opcao 1 => entregar plots e o metodo coloca actions e delegados 
                // // opcao 2 => o metodo devolve um objeto que tem os delegados e action
                
                // metodo_info.Invoke(   objeto_generico , new System.Object[]{  }  );

                return;


        }


        // ---- FUNCOES SUPORTE


        public bool Verificar_se_container_ja_foi_pedido( int _localizador_id ){

               // --- VERIFICA SE TEM SLOT
                for( int slot_index = 0 ; slot_index < localizadores_ids.Length ; slot_index++ ){

                        if( localizadores_ids[ slot_index ] ==  _localizador_id )
                                { return true; }
                        continue;

                }

                return false;

        }

        public void Remover_dados ( int _localizador_id ){

                int slot = Pegar_slot( _localizador_id );

                            
                localizadores_ids[ slot ] = 0;
                dados_containers[ slot ] = null;

                if( requisicoes[ slot ] != null )
                        {
                                requisicoes[ slot ].pode_executar = false;
                                requisicoes[ slot ] = null;

                        }

                return;

        }


        // --- INTERNO 

        public int Pegar_slot( int _localizador_id ){
        
                for( int slot_index = 0 ; slot_index < localizadores_ids.Length ; slot_index++ ){

                        if( localizadores_ids[ slot_index ] ==  _localizador_id )
                                { return slot_index; }
                        continue;
                }

                

                Debug.Log( "------------ ERRO -------------" );
                Debug.LogError( $"Pediu para pegar o localizador { _localizador_id } mas ninguem pediu ele"  );
                Debug.Log( "-------------------------------" );
                throw new Exception();
                
        }

        public int Criar_slot( int _localizador_id ){


                // --- VERIFICA SE TEM SLOT

                int slot_livre = -1;
                for( int slot_index = 0 ; slot_index < localizadores_ids.Length ; slot_index++ ){

                        // --- VERIFICA SE ESTA LIVRE
                        if( localizadores_ids[ slot_index ] ==  0 )
                                {       
                                        // ** talvez possa colocar algo aqui para verificar se os dados fora excluidos corretamente 
                                        slot_livre = slot_index;
                                        localizadores_ids[ slot_index ] = _localizador_id;
                                        continue;
                                }

                        // --- VERIFICA SE NAO FOI PEGO ANTES
                        if( localizadores_ids[ slot_index ] ==  0 )
                            { 
                                #if UNITY_EDITOR
                                    //Teste_play.Verificar_se_realmente_foi_pedido( slot_teste, _id, requisicoes, dados_containers_entidade, AIs );
                                #endif
                                return slot_index; 
                            }

                        continue;

                }

                // --- SE TIVER VAI RETORNAR

                if( slot_livre != -1 )
                    { return slot_livre; }
                

                // --- CRIA MAIS SLOTS

                int index_final_livre = localizadores_ids.Length;

                int[] novo_inds = new int[ localizadores_ids.Length ];
                byte[][] novo_containers = new byte[ localizadores_ids.Length ][];
                

                for( int index_antigo = 0 ; index_antigo < localizadores_ids.Length ; index_antigo++ ){

                        novo_inds[ index_antigo ] = localizadores_ids[ index_antigo ];
                        novo_containers[ index_antigo ] = dados_containers[ index_antigo ];
                        
                }

                
                localizadores_ids = novo_inds;
                dados_containers = novo_containers;

                localizadores_ids[ index_final_livre ] = _localizador_id;

                return index_final_livre;


        }


}