using System;
using System.Reflection;
using UnityEngine;





public class Gerenciador_dados_dinamicos {


        public Gerenciador_dados_dinamicos(  Entidade_nome _entidade ){ 

                nome_dll = _entidade.ToString() + "_dll";
                nome_entidade = _entidade.ToString();
                entidade =  _entidade;

                
                #if UNITY_EDITOR

                        // o editor consegue pegar eles normalmente
                        asm = Assembly.Load( $"{ nome_dll }" );

                        if( asm == null )
                            { throw new Exception( $"nao foi achado a dll: { nome_dll }" ); }

                #else
                        asm = Assembly.LoadFrom( Application.dataPath + $"/Run_time_dados/{ nome_dll }.dll" );
                        if( asm == null )
                            { throw new Exception( $"nao foi achado a dll: { nome_dll }" ); }

                #endif


                return;

        }


        public string nome_entidade;
        public string nome_dll;

        public Entidade_nome entidade;

        
        public Assembly asm;
        
        public int[] entidades_ids = new int[ 50 ];
        public System.Object[] entidades_AIs = new System.Object[ 50 ];
        public Dados_containers_entidade[] dados_containers_entidades = new Dados_containers_entidade[ 50 ];
        public Task_req[] requisicoes = new Task_req[ 50 ];


        public System.Object Pegar_AI  ( int _index_slot ){

                // ** tem que pegar slot antes
                // se nao foi carregado vai forçar para carregar na main

                if( requisicoes[ _index_slot] != null )
                        { 
                                // garante que nao vai substituir os dados 
                                requisicoes[ _index_slot].pode_executar = false; 
                                requisicoes[ _index_slot] = null; 
                        }
                

                System.Object AI =  entidades_AIs[ _index_slot ];
                
                if( AI != null )
                        {  return AI ;}


                int id = entidades_ids[ _index_slot ];
                return Pegar_AI_NAO_CARREGADO( id );


        }


        public System.Object Pegar_AI_NAO_CARREGADO ( int _index_slot ){

                // ????
                string class_nome =  Pegar_nome_entidade( _index_slot ) + "_dados";
                System.Object AI =  asm.CreateInstance( class_nome );
                entidades_AIs[ _index_slot ] = AI;

                return AI;

        }


        public string Pegar_nome_entidade( int _entidade_id ){

            
                switch( entidade ){

                        case Entidade_nome.personagem: return ( ( Personagem_nome ) _entidade_id ).ToString().ToUpper();
                        case Entidade_nome.plot: return ( ( Plot_nome ) _entidade_id ).ToString().ToUpper();
                        case Entidade_nome.mob: return ( ( Mob_nome ) _entidade_id ).ToString().ToUpper();
                        case Entidade_nome.boss: return ( ( Boss_nome ) _entidade_id ).ToString().ToUpper();

                        case Entidade_nome.cidade: return ( ( Cidade_nome ) _entidade_id ).ToString().ToUpper();
                        case Entidade_nome.estado: return ( ( Estado_nome ) _entidade_id ).ToString().ToUpper();
                        case Entidade_nome.reino: return ( ( Reino_nome ) _entidade_id ).ToString().ToUpper();

                        default: throw new Exception( $"entidade nao encontrada: { entidade }" );

                }



        }


        public Dados_containers_entidade Transformar_bytes_em_containers( byte[] _dados_bytes ){


                switch( entidade ){


                        //case Entidade_nome.personagem: return Construtor_containers_personagens.Construir( _dados_bytes );
                        case Entidade_nome.mob: return Construtor_containers_mobs.Construir( _dados_bytes );
                        case Entidade_nome.boss: return Construtor_containers_bosses.Construir( _dados_bytes );

                        case Entidade_nome.reino: return Construtor_containers_reinos.Construir( _dados_bytes );
                        case Entidade_nome.estado: return Construtor_containers_estados.Construir( _dados_bytes );
                        //case Entidade_nome.cidade: return Construtor_containers_cidades.Construir( _dados_bytes );

                        //case Entidade_nome.plot: return Construtor_containers_plots.Construir( _dados_bytes );

                        default: throw new Exception( $"nao foi achado o Construtor_container para a entidade { entidade }." );

                }



        }




        



        public Dados_containers_entidade Pegar_containers ( int _index_slot ){

                // ** tem que pegar slot antes
                // se nao foi carregado vai forçar para carregar 

                if( requisicoes[ _index_slot] != null )
                        { 
                                // garante que nao vai substituir os dados 
                                requisicoes[ _index_slot].pode_executar = false; 
                                requisicoes[ _index_slot] = null;
                        }
                
                Dados_containers_entidade containers =  dados_containers_entidades[ _index_slot ];

                if( containers != null )
                        {  return containers; }

                int personagem_id = entidades_ids[ _index_slot ];

                return Pegar_containers_NAO_CARREGADO( personagem_id ) ;

        }


        public Dados_containers_entidade Pegar_containers_NAO_CARREGADO( int _entidade_id ){

                string nome_entidade_folder = Pegar_nome_entidade( _entidade_id );
                string path_dados = Paths_sistema.path_folder__save + "/" + nome_entidade_folder + "_dados.dat" ;

                if( ! ( System.IO.File.Exists( path_dados ) ) )
                        { throw new Exception( $" path { path_dados } " ); }

                byte[] dados_bytes = System.IO.File.ReadAllBytes( path_dados );

                return Transformar_bytes_em_containers( dados_bytes );
                
        }






        public void Carregar_dados_MULTITHREAD( int _id ){

                

                // --- VERIFICAR SE JA FOI PEDIDO
                for( int slot_teste = 0 ; slot_teste < entidades_ids.Length ; slot_teste++ ){

                        if( entidades_ids[ slot_teste ] == _id )
                                { 
                                    // já foi dado a ordem para carregar
                                    // tem que garantir que vai excluir o plots aqui também 
                                        #if UNITY_EDITOR
                                          //Teste_play.Verificar_se_realmente_foi_pedido( slot_teste, _id, requisicoes, dados_containers_entidade, AIs );
                                        #endif
                                        return; 
                                }

                }


                int slot = Criar_slot( _id );

                // --- CRIAR DADOS
                string nome_entidade = Pegar_nome_entidade( _id );
                string nome_classe = nome_entidade + "_dados";
                string nome_dados_path = Paths_sistema.path_folder__save + nome_classe + ".dat";

                Task_req task = new Task_req( new Chave_cache() , ( "pegar_" + entidade.ToString() + "_" + nome_entidade) );                                                
                task.dados_array_suporte = new System.Object[ 2 ];


                task.fn_iniciar = ( Task_req _req ) => {
                                                                // --- CARREGA AI
                                                        
                                                                System.Object AI =  asm.CreateInstance( nome_classe );
                                                                _req.dados_array_suporte[ 0 ] = AI;


                                                                // --- DADOS CONTAINERS

                                                                if( !( System.IO.File.Exists( nome_dados_path ) ) )
                                                                        { throw new Exception( $"nao foi achado o arquivo no path: { nome_dados_path }" ); }

                                                                byte[] dados_bytes = System.IO.File.ReadAllBytes( nome_dados_path );

                                                                Dados_containers_entidade containers = Transformar_bytes_em_containers( dados_bytes );
                                                                
                                                                _req.dados_array_suporte[ 1 ] = ( System.Object ) containers;

                                                                return;

                                                        };


                task.fn_finalizar = ( Task_req _req )=>{

                        

                                                                System.Object AI = _req.dados_array_suporte[ 0 ];
                                                                Dados_containers_entidade containers =  ( Dados_containers_entidade ) _req.dados_array_suporte[ 1 ];

                                                                // -- VERIFICAR SE OS DADOS FORAM PEGOS CORRETAMENTE

                                                                if( AI == null )
                                                                        { Debug.LogError( $"nao foi achado a entidade  { nome_entidade } nos dados AI plots com o nome : { nome_classe }" ); throw new Exception(); }

                                                                if( containers == null )
                                                                        { Debug.LogError( $"nao foi achado os dados.dat do plot { nome_entidade } no path : { nome_dados_path }" );throw new Exception(); }


                                                                // --- coloca nos slots
                                                                entidades_AIs[ slot ] = AI;
                                                                dados_containers_entidades[ slot ] = containers;

                                                                return;

                                                        };

                                                
                // ** --- COLOCAR DEPOIS
        
                // MethodInfo metodo_info = asm.GetType( metodo_nome ).GetMethod("Pegar_dados");

                // // opcao 1 => entregar plots e o metodo coloca actions e delegados 
                // // opcao 2 => o metodo devolve um objeto que tem os delegados e action
                
                // metodo_info.Invoke(   objeto_generico , new System.Object[]{  }  );

                return;


        }

        // ---- funcoes suporte


        public int Pegar_slot( int _id ){
        
                for( int slot_index = 0 ; slot_index < entidades_ids.Length ; slot_index++ ){

                        if( entidades_ids[ slot_index ] ==  _id )
                                { return slot_index; }

                }

                Debug.Log( "------------ ERRO -------------" );
                Debug.LogError( $"Pediu o slot do plots { Pegar_nome_entidade( _id ) } mas ninguem pediu ele"  );
                Debug.Log( "-------------------------------" );
                throw new Exception();
                
        }



        public int Criar_slot( int _id ){


        
                for( int slot_index = 0 ; slot_index < entidades_ids.Length ; slot_index++ ){

                        if( entidades_ids[ slot_index ] ==  0 )
                                {       
                                        // ** talvez possa colocar algo aqui para verificar se os dados fora excluidos corretamente 
                                        entidades_ids[ slot_index ] = _id;
                                        return slot_index; 
                                }

                }

                // nao tem slots_livres

                int index_final_livre = entidades_ids.Length;


                int[] novo_inds = new int[ entidades_ids.Length ];
                Dados_containers_entidade[] novo_containers = new Dados_containers_entidade[ entidades_ids.Length ];
                System.Object[] novo_AI = new System.Object[ entidades_ids.Length ];

                for( int index_antigo = 0 ; index_antigo < entidades_ids.Length ; index_antigo++ ){

                        novo_inds[ index_antigo ] = entidades_ids[ index_antigo ];
                        novo_containers[ index_antigo ] = dados_containers_entidades[ index_antigo ];
                        novo_AI[ index_antigo ] = entidades_AIs[ index_antigo ];

                }

                entidades_AIs = novo_AI;
                entidades_ids = novo_inds;
                dados_containers_entidades = novo_containers;

                entidades_ids[ index_final_livre ] = _id;


                return index_final_livre;

        }



        public void Remover_dados ( int _id ){

                int slot = Pegar_slot( _id);

                
                entidades_AIs[ slot ] = null;
                entidades_ids[ slot ] = 0;
                dados_containers_entidades[ slot ] = null;

                if( requisicoes[ slot ] != null )
                        {
                                requisicoes[ slot ].pode_executar = false;
                                requisicoes[ slot ] = null;

                        }

                

                return;

        }




}