using System;
using System.Reflection;
using UnityEngine;





public class Gerenciador_dados_dinamicos_plots {


        public Gerenciador_dados_dinamicos_plots(){ 

                
                #if UNITY_EDITOR
                        // o editor consegue pegar eles normalmente
                        asm_plots = Assembly.Load( "plots_run_time" );
                #endif
                #if !UNITY_EDITOR
                        asm_plots = Assembly.LoadFrom( Application.dataPath + "/Run_time_dados/plots_run_time.dll" );
                #endif

        }

        
        public Assembly asm_plots;
        
        public int[] plots_ids = new int[ 50 ];
        public System.Object[] plots_AIs = new System.Object[ 50 ];
        public Dados_containers_plot[] dados_containers_plot = new Dados_containers_plot[ 50 ];
        public Task_req[] requisicoes_plots = new Task_req[ 50 ];


        public System.Object Pegar_AI_plots  ( int _index_slot_plots ){

                // ** tem que pegar slot antes
                // se nao foi carregado vai forçar para carregar na main

                if( requisicoes_plots[ _index_slot_plots] != null )
                        { 
                                // garante que nao vai substituir os dados 
                                requisicoes_plots[ _index_slot_plots].pode_executar = false; 
                                requisicoes_plots[ _index_slot_plots] = null; 
                        }
                

                System.Object plots_AI =  plots_AIs[ _index_slot_plots ];
                
                if( plots_AI != null )
                        {  return plots_AI ;}


                int plot_id = plots_ids[ _index_slot_plots ];
                return Pegar_AI_plots_NAO_CARREGADO( plot_id );


        }


        public System.Object Pegar_AI_plots_NAO_CARREGADO ( int _index_slot_plots ){

                string plots_class_nome =  ( ( Plot_nome ) plots_ids[ _index_slot_plots ] ).ToString() + "_dados";
                plots_AI =  asm_plots.CreateInstance( plots_class_nome );
                plots_AIs[ _index_slot_plots ] = plots_AI;
                System.Object plots_AI =  plots_AIs[ _index_slot_plots ];
                
                return plots_AI;

        }
        



        public Dados_containers_plot Pegar_containers_plot ( int _index_slot_plots ){

                // ** tem que pegar slot antes
                // se nao foi carregado vai forçar para carregar 

                if( requisicoes_plots[ _index_slot_plots] != null )
                        { 
                                // garante que nao vai substituir os dados 
                                requisicoes_plots[ _index_slot_plots].pode_executar = false; 
                                requisicoes_plots[ _index_slot_plots] = null;
                        }
                
                Dados_containers_plot plots_containers =  dados_containers_plot[ _index_slot_plots ];

                if( plots_containers != null )
                        {  return plots_containers; }

                int personagem_id = plots_ids[ _index_slot_plots ];
                return Pegar_containers_plot_NAO_CARREGADO( personagem_id ) ;

        }


        public Dados_containers_plot Pegar_containers_plot_NAO_CARREGADO( int _personagem_id ){

                string plots_nome = ( ( Plot_nome ) _personagem_id ).ToString() ;
                string path_dados = Paths_sistema.path_dados_plots + plots_nome + "_dados.dat" ;
                byte[] dados_bytes = System.IO.File.ReadAllBytes( path_dados );
                Dados_containers_plot plots_containers = Construtor_containers_plots.Construir( dados_bytes );
                return plots_containers;

        }












        public void Carregar_dados_plots_MULTITHREAD( int _plots_id ){

                

                // verifica se já foi pedido
                for( int slot_teste = 0 ; slot_teste < plots_ids.Length ; slot_teste++ ){

                        if( plots_ids[ slot_teste ] == _plots_id )
                                // já foi dado a ordem para carregar
                                // tem que garantir que vai excluir o plots aqui também 
                                { 
                                        #if !UNITY_EDITOR
                                          Teste_play.Verificar_se_plots_realmente_foi_pedido( slot_teste, requisicoes_plots, containers_dados_plots, plots_AIs );
                                        #endif
                                        return; 
                                }

                }


                int slot_plots = Criar_slot_plots( _plots_id );


                string plots_nome = ( ( Plot_nome ) plots_ids[ slot_plots ] ).ToString() ;
                string nome_clase_plots =  plots_nome + "_dados";
                
                string path_dados = Paths_sistema.path_dados_plots + "/" + plots_nome + "_dados.dat" ;

        
                Task_req task = new Task_req( new Chave_cache() , ( "pegar_plots " + plots_nome)  );

                task.fn_iniciar = ( Task_req _req ) => {

                        _req.dados_array_suporte = new System.Object[ 2 ];



                        // --- CARREGA AI
                        // a principio vai carregar tudo que pode ser necessario para o plots 
                        System.Object plots_AI =  asm_plots.CreateInstance( nome_clase_plots );
                        _req.dados_array_suporte[ 0 ] = plots_AI;


                        // --- plots DADOS
                        byte[] dados_bytes = null;

                        if( ! ( System.IO.File.Exists( path_dados ) ) )
                                { return; } // vai dar erro depois 
                        dados_bytes = System.IO.File.ReadAllBytes( path_dados );
                        Dados_containers_plot plots_containers = Construtor_containers_plots.Construir( dados_bytes );

                        _req.dados_array_suporte[ 1 ] = plots_containers;

                        return;

                };


                task.fn_finalizar = ( Task_req _req ) => {

                        
                        // -- VERIFICAR SE OS DADOS FORAM PEGOS CORRETAMENTE

                        System.Object plots_AI = _req.dados_array_suporte[ 0 ];
                        Dados_containers_plot containers_plots =  ( Dados_containers_plot ) _req.dados_array_suporte[ 1 ];

                        if( plots_AI == null ){

                                Debug.LogError( $"nao foi achado plot { plots_nome } nos dados AI plots com o nome : { nome_clase_plots }" );
                                throw new Exception();

                        }

                        if( containers_plots == null ){

                                Debug.LogError( $"nao foi achado os dados.dat do plot { plots_nome } no path : { path_dados }" );
                                throw new Exception();

                        }

                        plots_AIs[ slot_plots ] = plots_AI;
                        dados_containers_plot[ slot_plots ] = containers_plots;

                        return;


                };

                                                
                // ** --- COLOCAR DEPOIS
        
                // MethodInfo metodo_info = asm_plots.GetType( plots_metodo_nome ).GetMethod("Pegar_dados");

                // // opcao 1 => entregar plots e o metodo coloca actions e delegados 
                // // opcao 2 => o metodo devolve um objeto que tem os delegados e action
                
                // metodo_info.Invoke(   plots_objeto_generico , new System.Object[]{ _plots }  );

                return;


        }

        // ---- funcoes suporte


        public int Pegar_slot_plots( int _plots_id ){
        
                for( int plots_slot_index = 0 ; plots_slot_index < plots_ids.Length ; plots_slot_index++ ){

                        if( plots_ids[ plots_slot_index ] ==  _plots_id )
                                { return plots_slot_index; }

                }

                Debug.Log( "------------ ERRO -------------" );
                Debug.LogError( $"Pediu o slot do plots { ((Plot_nome) _plots_id).ToString() } mas ninguem pediu ele"  );
                Debug.Log( "-------------------------------" );
                throw new Exception();
                
        }



        public int Criar_slot_plots( int _plots_id ){


        
                for( int plots_slot_index = 0 ; plots_slot_index < plots_ids.Length ; plots_slot_index++ ){

                        if( plots_ids[ plots_slot_index ] ==  0 )
                                {       
                                        // ** talvez possa colocar algo aqui para verificar se os dados fora excluidos corretamente 
                                        plots_ids[ plots_slot_index ] = _plots_id;
                                        return plots_slot_index; 
                                }

                }

                // nao tem slots_livres

                int index_final_livre = plots_ids.Length;


                int[] novo_inds = new int[ plots_ids.Length ];
                Dados_containers_plot[] novo_containers = new Dados_containers_plot[ plots_ids.Length ];
                System.Object[] novo_AI = new System.Object[ plots_ids.Length ];

                for( int index_antigo = 0 ; index_antigo < plots_ids.Length ; index_antigo++ ){

                        novo_inds[ index_antigo ] = plots_ids[ index_antigo ];
                        novo_containers[ index_antigo ] = dados_containers_plot[ index_antigo ];
                        novo_AI[ index_antigo ] = plots_AIs[ index_antigo ];

                }

                plots_ids[ index_final_livre ] = _plots_id;

                plots_AIs = novo_AI;
                plots_ids = novo_inds;
                dados_containers_plot = novo_containers;


                return index_final_livre;

        }



        public void Remover_dados_plots ( int _plots_id ){

                int slot_plots = Pegar_slot_plots( _plots_id);

                
                plots_AIs[ slot_plots ] = null;
                plots_ids[ slot_plots ] = 0;
                dados_containers_plot[ slot_plots ] = null;

                if( requisicoes_plots[ slot_plots ] != null )
                        {
                                requisicoes_plots[ slot_plots ].pode_executar = false;
                                requisicoes_plots[ slot_plots ] = null;

                        }

                

                return;

        }




}