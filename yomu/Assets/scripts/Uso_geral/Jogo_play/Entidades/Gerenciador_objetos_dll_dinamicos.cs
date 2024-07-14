using System;
using System.Reflection;
using UnityEngine;





public class Gerenciador_objetos_dll_dinamicos {


        public Gerenciador_objetos_dll_dinamicos(  string _nome_dll, int _numero_inicial_de_slots ){ 

                nome_dll = _nome_dll;

                localizadores_ids = new int[ _numero_inicial_de_slots ];
                nomes_classes = new string[ _numero_inicial_de_slots ];
                objetos = new System.Object[ _numero_inicial_de_slots ];
                requisicoes = new Task_req[ _numero_inicial_de_slots ];
                
                #if UNITY_EDITOR

                        // o editor consegue pegar eles normalmente
                        asm = Assembly.Load( nome_dll );

                        if( asm == null )
                            { throw new Exception( $"nao foi achado a dll: { nome_dll }" ); }

                #else
                        string path = System.IO.Path.Combine( Paths_sistema.path_dlls_dados_dinamicos, nome_dll );
                        asm = Assembly.LoadFrom( path );
                        if( asm == null )
                            { throw new Exception( $"nao foi achado a dll: { nome_dll }" ); }

                #endif


                return;

        }


        public string nome_entidade;
        public string nome_dll;

        public Entidade_nome entidade;

        
        public Assembly asm;
        
        public int[] localizadores_ids = new int[ 50 ];
        public string[] nomes_classes;
        public System.Object[] objetos = new System.Object[ 50 ];
        public Task_req[] requisicoes = new Task_req[ 50 ];


        public System.Object Pegar_objeto  ( int _localizador_id ){

                // sempre tem que carregar primeiro. Em teste carrega primeiro para colocar o path e logo em sequencia já pega 

                int slot_index = Pegar_slot( _localizador_id );

                System.Object objeto =  objetos[ slot_index ];
                

                // --- VERIFICA SE O OBJETO FOI CARREGADO
                if( objeto != null )
                        {  return objeto ;}


                // --- VAI FORCAR
                string classe_nome =  nomes_classes[ slot_index ];
                objeto =  asm.CreateInstance( classe_nome );

                if( objeto == null )
                        {  throw new Exception( $"tentou criar um objeto com a classe { classe_nome } mas veio null a instancia" ) ;}


                objetos[ slot_index ] = objeto;

                return objeto;

        }



        public void Carregar_objeto_NA_MULTITHREAD( int _localizador_id, string _nome_classe ){

                
                // --- VERIFICAR SE JA FOI PEDIDO
                for( int slot_teste = 0 ; slot_teste < localizadores_ids.Length ; slot_teste++ ){

                        if( localizadores_ids[ slot_teste ] == _localizador_id )
                                { 
                                    // já foi dado a ordem para carregar
                                    // tem que garantir que vai excluir o plots aqui também 
                                        #if UNITY_EDITOR
                                          //Teste_play.Verificar_se_realmente_foi_pedido( slot_teste, _id, requisicoes, dados_containers_entidade, AIs );
                                        #endif
                                        return; 
                                }

                }


                int slot = Criar_slot( _localizador_id );

                // --- CRIAR DADOS

                nomes_classes[ slot ] = _nome_classe;

                Task_req task = new Task_req( new Chave_cache() , ( "pegar_" + entidade.ToString() + "_" + nome_entidade) );
                task.dados_array_suporte = new System.Object[ 1 ];


                task.fn_iniciar = ( Task_req _req ) => {
                                                                // --- CARREGA AI
                                                        
                                                                System.Object AI =  asm.CreateInstance( _nome_classe );
                                                                _req.dados_array_suporte[ 0 ] = AI;

                                                                return;

                                                        };


                task.fn_finalizar = ( Task_req _req )=>{
                                                                System.Object AI = _req.dados_array_suporte[ 0 ];

                                                                // -- VERIFICAR SE OS DADOS FORAM PEGOS CORRETAMENTE

                                                                if( AI == null )
                                                                        { Debug.LogError( $"nao foi achado a entidade  { nome_entidade } nos dados AI plots com o nome : { _nome_classe }" ); throw new Exception(); }

                                                                objetos[ slot ] = AI;
                                                                
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
                objetos[ slot ] = null;

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
                Debug.LogError( $"Pediu o localizador { _localizador_id } mas ninguem pediu ele em objetos_dll"  );
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
                                    //Teste_play.Verificar_se_realmente_foi_pedido( slot_teste, _id, requisicoes, dados_parciais_entidade, AIs );
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

                int[] novo_inds = new int[ localizadores_ids.Length + 20 ];
                System.Object[] novos_objetos = new System.Object[ localizadores_ids.Length + 20];
                

                for( int index_antigo = 0 ; index_antigo < localizadores_ids.Length ; index_antigo++ ){

                        novo_inds[ index_antigo ] = localizadores_ids[ index_antigo ];
                        novos_objetos[ index_antigo ] = objetos[ index_antigo ];
                        
                }

                
                localizadores_ids = novo_inds;
                objetos = novos_objetos;

                localizadores_ids[ index_final_livre ] = _localizador_id;

                return index_final_livre;


        }





}