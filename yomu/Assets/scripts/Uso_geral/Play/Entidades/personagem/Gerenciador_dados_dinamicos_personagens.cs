using System;
using System.Reflection;
using UnityEngine;





public class Gerenciador_dados_dinamicos_personagens {


        public Gerenciador_dados_dinamicos_personagens(){ 

                

                #if UNITY_EDITOR
                        // o editor consegue pegar eles normalmente
                        asm_personagens = Assembly.Load( "Personagens_run_time" );
                #endif
                #if !UNITY_EDITOR
                        asm_personagens = Assembly.LoadFrom( Application.dataPath + "/Run_time_dados/Personagens_run_time.dll" );
                #endif

        }

        

        public Assembly asm_personagens;
        
        public int[] personagens_ids = new int[ 50 ];
        public System.Object[] personagens_AIs = new System.Object[ 50 ];
        public Dados_containers_personagem[] dados_containers_personagens = new Dados_containers_personagem[ 50 ];
        public Task_req[] requisicoes_personagens = new Task_req[ 50 ];


        public System.Object Pegar_AI_personagem ( int _index_slot_personagem ){

                // ** tem que pegar slot antes
                // se nao foi carregado vai forçar para carregar na main

                if( requisicoes_personagens[ _index_slot_personagem] != null )
                        { 
                                // garante que nao vai substituir os dados 
                                requisicoes_personagens[ _index_slot_personagem].pode_executar = false; 
                                requisicoes_personagens[ _index_slot_personagem] = null; 
                        }
                

                System.Object personagem_AI =  personagens_AIs[ _index_slot_personagem ];
                
                if( personagem_AI != null )
                        { return personagem_AI; }
                
                int personagem_id =  personagens_ids[ _index_slot_personagem ] ;

                return Pegar_AI_personagem_NAO_CARREGADO( personagem_id );
                

        }
        
        public System.Object Pegar_AI_personagem_NAO_CARREGADO ( int _personagem_id ){

                string personagem_class_nome =  ( ( Personagem_nome ) _personagem_id  ).ToString() + "_dados";
                System.Object personagem_AI =  asm_personagens.CreateInstance( personagem_class_nome );
                personagens_AIs[ _index_slot_personagem ] = personagem_AI;

                return personagem_AI;
        }


        

        public Dados_containers_personagem Pegar_containers_personagem ( int _index_slot_personagem ){

                // ** tem que pegar slot antes
                // se nao foi carregado vai forçar para carregar 

                if( requisicoes_personagens[ _index_slot_personagem] != null )
                        { 
                                // garante que nao vai substituir os dados 
                                requisicoes_personagens[ _index_slot_personagem].pode_executar = false; 
                                requisicoes_personagens[ _index_slot_personagem] = null;
                        }
                
                Dados_containers_personagem personagem_containers =  dados_containers_personagens[ _index_slot_personagem ];

                if( personagem_containers != null )
                        { return personagem_containers; }

                int personagem_id = personagens_ids[ _index_slot_personagem ];
                return Pegar_containers_personagem_NAO_CARREGADO( personagem_id );

        }

        public Dados_containers_personagem Pegar_containers_personagem_NAO_CARREGADO ( int _personagem_id ){


                string personagem_nome = ( ( Personagem_nome ) personagens_ids[ _index_slot_personagem ] ).ToString() ;
                string path_dados = Paths_sistema.path_dados_personagens + "/" + personagem_nome + "_dados.dat" ;
                byte[] dados_bytes = System.IO.File.ReadAllBytes( path_dados );
                personagem_containers = Construtor_containers_personagens.Construir( dados_bytes );

                return personagem_containers;

        }




        




        public void Carregar_dados_personagem_MULTITHREAD( int _personagem_id ){

                

                // verifica se já foi pedido
                for( int slot_teste = 0 ; slot_teste < personagens_ids.Length ; slot_teste++ ){

                        if( personagens_ids[ slot_teste ] == _personagem_id )
                                // já foi dado a ordem para carregar
                                // tem que garantir que vai excluir o personagem aqui também 
                                { 
                                        #if !UNITY_EDITOR
                                          Teste_play.Verificar_se_personagem_realmente_foi_pedido( slot_teste, requisicoes_personagens, containers_dados_personagens, personagens_AIs );
                                        #endif
                                        return; 
                                }

                }


                int slot_personagem = Criar_slot_personagem( _personagem_id );


                string personagem_nome = ( ( Personagem_nome ) personagens_ids[ slot_personagem ] ).ToString() ;
                string nome_clase_personagem =  personagem_nome + "_dados";
                
                string path_dados = Paths_sistema.path_dados_personagens + "/" + personagem_nome + "_dados.dat" ;

        
                Task_req task = new Task_req( new Chave_cache() , ( "pegar_personagem " + personagem_nome)  );

                task.fn_iniciar = ( Task_req _req ) => {

                        _req.dados_array_suporte = new System.Object[ 2 ];



                        // --- CARREGA AI
                        // a principio vai carregar tudo que pode ser necessario para o personagem 
                        System.Object personagem_AI =  asm_personagens.CreateInstance( nome_clase_personagem );
                        _req.dados_array_suporte[ 0 ] = personagem_AI;


                        // --- PERSONAGEM DADOS
                        byte[] dados_bytes = null;

                        if( ! ( System.IO.File.Exists( path_dados ) ) )
                                { return; } // vai dar erro depois 
                        dados_bytes = System.IO.File.ReadAllBytes( path_dados );
                        Dados_containers_personagem personagem_containers = Construtor_containers_personagens.Construir( dados_bytes );

                        _req.dados_array_suporte[ 1 ] = personagem_containers;

                        return;

                };


                task.fn_finalizar = ( Task_req _req ) => {

                        
                        // -- VERIFICAR SE OS DADOS FORAM PEGOS CORRETAMENTE

                        System.Object personagem_AI = _req.dados_array_suporte[ 0 ];
                        Dados_containers_personagem containers_personagem =  ( Dados_containers_personagem ) _req.dados_array_suporte[ 1 ];

                        if( personagem_AI == null ){

                                Debug.LogError( $"nao foi achado persoangem { personagem_nome } nos dados AI personagens com o nome : { nome_clase_personagem }" );
                                throw new Exception();

                        }

                        if( containers_personagem == null ){

                                Debug.LogError( $"nao foi achado os dados.dat do persoangem { personagem_nome } no path : { path_dados }" );
                                throw new Exception();

                        }

                        personagens_AIs[ slot_personagem ] = personagem_AI;
                        dados_containers_personagens[ slot_personagem ] = containers_personagem;

                        return;


                };

                                                
                // ** --- COLOCAR DEPOIS
        
                // MethodInfo metodo_info = asm_personagens.GetType( personagem_metodo_nome ).GetMethod("Pegar_dados");

                // // opcao 1 => entregar Personagem e o metodo coloca actions e delegados 
                // // opcao 2 => o metodo devolve um objeto que tem os delegados e action
                
                // metodo_info.Invoke(   personagem_objeto_generico , new System.Object[]{ _personagem }  );

                return;


        }




        

        // ---- funcoes suporte


        public int Pegar_slot_personagem( int _personagem_id ){
        
                for( int personagem_slot_index = 0 ; personagem_slot_index < personagens_ids.Length ; personagem_slot_index++ ){

                        if( personagens_ids[ personagem_slot_index ] ==  _personagem_id )
                                { return personagem_slot_index; }

                }

                Debug.Log( "------------ ERRO -------------" );
                Debug.LogError( $"Pediu o slot do personagem { ((Personagem_nome) _personagem_id).ToString() } mas ninguem pediu ele"  );
                Debug.Log( "-------------------------------" );
                throw new Exception();
                
        }



        public int Criar_slot_personagem( int _personagem_id ){


        
                for( int personagem_slot_index = 0 ; personagem_slot_index < personagens_ids.Length ; personagem_slot_index++ ){

                        if( personagens_ids[ personagem_slot_index ] ==  0 )
                                {       
                                        // ** talvez possa colocar algo aqui para verificar se os dados fora excluidos corretamente 
                                        personagens_ids[ personagem_slot_index ] = _personagem_id;
                                        return personagem_slot_index; 
                                }

                }

                // nao tem slots_livres

                int index_final_livre = personagens_ids.Length;


                int[] novo_inds = new int[ personagens_ids.Length ];
                Dados_containers_personagem[] novo_containers = new Dados_containers_personagem[ personagens_ids.Length ];
                System.Object[] novo_AI = new System.Object[ personagens_ids.Length ];

                for( int index_antigo = 0 ; index_antigo < personagens_ids.Length ; index_antigo++ ){

                        novo_inds[ index_antigo ] = personagens_ids[ index_antigo ];
                        novo_containers[ index_antigo ] = dados_containers_personagens[ index_antigo ];
                        novo_AI[ index_antigo ] = personagens_AIs[ index_antigo ];

                }

                personagens_ids[ index_final_livre ] = _personagem_id;

                personagens_AIs = novo_AI;
                personagens_ids = novo_inds;
                dados_containers_personagens = novo_containers;


                return index_final_livre;

        }



        public void Remover_dados_personagem ( int _personagem_id ){

                int slot_personagem = Pegar_slot_personagem( _personagem_id);

                
                personagens_AIs[ slot_personagem ] = null;
                personagens_ids[ slot_personagem ] = 0;
                dados_containers_personagens[ slot_personagem ] = null;

                if( requisicoes_personagens[ slot_personagem ] != null )
                        {
                                requisicoes_personagens[ slot_personagem ].pode_executar = false;
                                requisicoes_personagens[ slot_personagem ] = null;

                        }

                

                return;

        }




}