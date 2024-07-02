using System;
using System.Reflection;
using UnityEngine;





public class Gerenciador_dados_dinamicos_cidades {


        public Gerenciador_dados_dinamicos_cidades(){ 

                
                #if UNITY_EDITOR
                        // o editor consegue pegar eles normalmente
                        asm_cidades = Assembly.Load( "Cidades_run_time" );
                #endif
                #if !UNITY_EDITOR
                        asm_cidades = Assembly.LoadFrom( Application.dataPath + "/Run_time_dados/Cidades_run_time.dll" );
                #endif

        }

        
        public Assembly asm_cidades;
        
        public int[] cidades_ids = new int[ 50 ];
        public System.Object[] cidades_AIs = new System.Object[ 50 ];
        public Dados_containers_cidade[] dados_containers_cidades = new Dados_containers_cidade[ 50 ];
        public Task_req[] requisicoes_cidades = new Task_req[ 50 ];


        public System.Object Pegar_AI_cidade ( int _index_slot_cidades ){

                // ** tem que pegar slot antes
                // se nao foi carregado vai forçar para carregar na main

                if( requisicoes_cidades[ _index_slot_cidades] != null )
                        { 
                                // garante que nao vai substituir os dados 
                                requisicoes_cidades[ _index_slot_cidades].pode_executar = false; 
                                requisicoes_cidades[ _index_slot_cidades] = null; 
                        }
                
                System.Object cidades_AI =  cidades_AIs[ _index_slot_cidades ];
                
                if( cidades_AI != null )
                        {  return cidades_AI ; }

                int cidade_id = cidades_ids[ _index_slot_cidades ];
                return Pegar_AI_cidade_NAO_CARREGADO( cidade_id );

        }

        public System.Object Pegar_AI_cidade_NAO_CARREGADO ( int _personagem_id ){

                string cidades_class_nome =  ( ( Cidade_nome ) _personagem_id ).ToString() + "_dados";
                System.Object cidade_AI =  asm_cidades.CreateInstance( cidades_class_nome );
                return cidade_AI;

        }





        public Dados_containers_cidade Pegar_containers_cidade ( int _index_slot_cidades ){

                // ** tem que pegar slot antes
                // se nao foi carregado vai forçar para carregar 

                if( requisicoes_cidades[ _index_slot_cidades] != null )
                        { 
                                // garante que nao vai substituir os dados 
                                requisicoes_cidades[ _index_slot_cidades].pode_executar = false; 
                                requisicoes_cidades[ _index_slot_cidades] = null;
                        }
                
                Dados_containers_cidade cidades_containers =  dados_containers_cidades[ _index_slot_cidades ];

                if( cidades_containers == null )
                        {
                                string save_path = Paths_sistema.path_save;
                                string cidades_nome = ( ( Cidade_nome ) cidades_ids[ _index_slot_cidades ] ).ToString() ;
                                string path_dados = Paths_sistema.path_dados_cidades + cidades_nome + "_dados.dat" ;
                                byte[] dados_bytes = System.IO.File.ReadAllBytes( path_dados );
                                //cidades_containers = Construtor_containers_cidades.Construir( dados_bytes );
                                
                        }

                return cidades_containers;

        }



        public Dados_containers_cidade Pegar_containers_cidade_NAO_CARREGADO ( int _cidade_id ){

 
                string cidades_nome =  ( ( Cidade_nome ) _cidade_id ).ToString() ;
                string path_dados = Paths_sistema.path_dados_cidades  + "/" + cidades_nome + "_dados.dat" ;
                byte[] dados_bytes = System.IO.File.ReadAllBytes( path_dados );
                Dados_containers_cidade cidades_containers =  null;// Construtor_containers_cidades.Construir( dados_bytes );
                return cidades_containers;


        }






        public void Carregar_dados_cidade_MULTITHREAD( int _cidades_id ){

                

                // verifica se já foi pedido
                for( int slot_teste = 0 ; slot_teste < cidades_ids.Length ; slot_teste++ ){

                        if( cidades_ids[ slot_teste ] == _cidades_id )
                                // já foi dado a ordem para carregar
                                // tem que garantir que vai excluir o cidades aqui também 
                                { 
                                        #if UNITY_EDITOR
                                          Teste_play.Verificar_se_cidade_realmente_foi_pedida( slot_teste, _cidades_id,requisicoes_cidades, dados_containers_cidades, cidades_AIs );
                                        #endif
                                        return; 
                                }

                }


                int slot_cidades = Criar_slot_cidade( _cidades_id );


                string cidades_nome = ( ( Cidade_nome ) cidades_ids[ slot_cidades ] ).ToString() ;
                string nome_clase_cidades =  cidades_nome + "_dados";
                
                string path_dados = Paths_sistema.path_dados_cidades + "/" + cidades_nome + "_dados.dat" ;

        
                Task_req task = new Task_req( new Chave_cache() , ( "pegar_cidades " + cidades_nome)  );

                task.fn_iniciar = ( Task_req _req ) => {

                        _req.dados_array_suporte = new System.Object[ 2 ];



                        // --- CARREGA AI
                        // a principio vai carregar tudo que pode ser necessario para o cidades 
                        System.Object cidades_AI =  asm_cidades.CreateInstance( nome_clase_cidades );
                        _req.dados_array_suporte[ 0 ] = cidades_AI;


                        // --- cidades DADOS
                        byte[] dados_bytes = null;

                        if( ! ( System.IO.File.Exists( path_dados ) ) )
                                { return; } // vai dar erro depois 
                        dados_bytes = System.IO.File.ReadAllBytes( path_dados );
                        Dados_containers_cidade cidades_containers = null;

                        _req.dados_array_suporte[ 1 ] = cidades_containers;

                        return;

                };


                task.fn_finalizar = ( Task_req _req ) => {

                        
                        // -- VERIFICAR SE OS DADOS FORAM PEGOS CORRETAMENTE

                        System.Object cidades_AI = _req.dados_array_suporte[ 0 ];
                        Dados_containers_cidade containers_cidades =  ( Dados_containers_cidade ) _req.dados_array_suporte[ 1 ];

                        if( cidades_AI == null ){

                                Debug.LogError( $"nao foi achado cidade { cidades_nome } nos dados AI cidades com o nome : { nome_clase_cidades }" );
                                throw new Exception();

                        }

                        if( containers_cidades == null ){

                                Debug.LogError( $"nao foi achado os dados.dat do cidade { cidades_nome } no path : { path_dados }" );
                                throw new Exception();

                        }

                        cidades_AIs[ slot_cidades ] = cidades_AI;
                        dados_containers_cidades[ slot_cidades ] = containers_cidades;

                        return;


                };

                                                
                // ** --- COLOCAR DEPOIS
        
                // MethodInfo metodo_info = asm_cidades.GetType( cidades_metodo_nome ).GetMethod("Pegar_dados");

                // // opcao 1 => entregar cidades e o metodo coloca actions e delegados 
                // // opcao 2 => o metodo devolve um objeto que tem os delegados e action
                
                // metodo_info.Invoke(   cidades_objeto_generico , new System.Object[]{ _cidades }  );

                return;


        }

        // ---- funcoes suporte


        public int Pegar_slot_cidade( int _cidades_id ){
        
                for( int cidades_slot_index = 0 ; cidades_slot_index < cidades_ids.Length ; cidades_slot_index++ ){

                        if( cidades_ids[ cidades_slot_index ] ==  _cidades_id )
                                { return cidades_slot_index; }

                }

                Debug.Log( "------------ ERRO -------------" );
                Debug.LogError( $"Pediu o slot do cidades { ((Cidade_nome) _cidades_id).ToString() } mas ninguem pediu ele"  );
                Debug.Log( "-------------------------------" );
                throw new Exception();
                
        }



        public int Criar_slot_cidade( int _cidades_id ){


        
                for( int cidades_slot_index = 0 ; cidades_slot_index < cidades_ids.Length ; cidades_slot_index++ ){

                        if( cidades_ids[ cidades_slot_index ] ==  0 )
                                {       
                                        // ** talvez possa colocar algo aqui para verificar se os dados fora excluidos corretamente 
                                        cidades_ids[ cidades_slot_index ] = _cidades_id;
                                        return cidades_slot_index; 
                                }

                }

                // nao tem slots_livres

                int index_final_livre = cidades_ids.Length;


                int[] novo_inds = new int[ cidades_ids.Length ];
                Dados_containers_cidade[] novo_containers = new Dados_containers_cidade[ cidades_ids.Length ];
                System.Object[] novo_AI = new System.Object[ cidades_ids.Length ];

                for( int index_antigo = 0 ; index_antigo < cidades_ids.Length ; index_antigo++ ){

                        novo_inds[ index_antigo ] = cidades_ids[ index_antigo ];
                        novo_containers[ index_antigo ] = dados_containers_cidades[ index_antigo ];
                        novo_AI[ index_antigo ] = cidades_AIs[ index_antigo ];

                }

                cidades_ids[ index_final_livre ] = _cidades_id;

                cidades_AIs = novo_AI;
                cidades_ids = novo_inds;
                dados_containers_cidades = novo_containers;


                return index_final_livre;

        }



        public void Remover_dados_cidade ( int _cidades_id ){

                int slot_cidades = Pegar_slot_cidade( _cidades_id);

                
                cidades_AIs[ slot_cidades ] = null;
                cidades_ids[ slot_cidades ] = 0;
                dados_containers_cidades[ slot_cidades ] = null;

                if( requisicoes_cidades[ slot_cidades ] != null )
                        {
                                requisicoes_cidades[ slot_cidades ].pode_executar = false;
                                requisicoes_cidades[ slot_cidades ] = null;

                        }

                

                return;

        }




}