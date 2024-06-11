// using System;
// using System.Reflection;
// using UnityEngine;



// public class Dados_containers_cidades {


// }


// public class Dados_dinamicos_cidades {


//         public static Dados_dinamicos_cidades instancia;
//         public static Dados_dinamicos_cidades Pegar_instancia(){ return instancia; }


//         public Dados_dinamicos_cidades(){ 

//                 #if UNITY_EDITOR
//                         // o editor consegue pegar eles normalmente
//                         asm_cidades= Assembly.Load( "World_run_time" );
//                 #endif
//                 #if !UNITY_EDITOR
//                                 // mudar o nome
//                         asm_cidades= Assembly.LoadFrom( Application.dataPath + "/Run_time_dados/World_run_time.dll" );
//                 #endif

//         }


//         public Assembly asm_cidades;
        
//         public int[] cidades_ids = new int[ 50 ];
//         public System.Object[] cidades_AIs = new System.Object[ 50 ];
//         public Dados_containers_cidades[] dados_containers_cidades = new Dados_containers_cidades[ 50 ];
//         public Task_req[] requisicoes_cidades = new Task_req[ 50 ];


//         public System.Object Pegar_AI_cidade ( int _index_slot_cidade ){

//                 // ** tem que pegar slot antes
//                 // se nao foi carregado vai forçar para carregar na main

//                 if( requisicoes_cidades[ _index_slot_cidade] != null )
//                         { 
//                                 // garante que nao vai substituir os dados 
//                                 requisicoes_cidades[ _index_slot_cidade].pode_executar = false; 
//                                 requisicoes_cidades[ _index_slot_cidade] = null; 
//                         }
                

//                 System.Object cidade_AI =  cidades_AIs[ _index_slot_cidade ];
                
//                 if( cidade_AI == null )
//                         {       
//                                 // nao nao conseguiu pegar na multithread, vai forçar na main 
                                
//                                 string cidade_class_nome =  ( ( cidade_nme ) _cidade_id ).ToString() + "_dados";
//                                 cidade_AI =  asm_cidades.CreateInstance( cidade_class_nome );
//                                 cidades_AIs[ _index_slot_cidade ] = cidade_AI;

//                         }

//                 return cidade_AI;

//         }


//         public System.Object Pegar_containers_cidade ( int _index_slot_cidade ){

//                 // ** tem que pegar slot antes
//                 // se nao foi carregado vai forçar para carregar 

//                 if( requisicoes_cidades[ _index_slot_cidade] != null )
//                         { 
//                                 // garante que nao vai substituir os dados 
//                                 requisicoes_cidades[ _index_slot_cidade].pode_executar = false; 
//                                 requisicoes_cidades[ _index_slot_cidade] = null ;
//                         }
                
//                 Containers_dados_cidade cidade_containers =  dados_containers_cidades[ _index_slot_cidade ];

//                 if( cidade_containers == null )
//                         {
//                                 string save_path = Controlador_dados_sistema.Pegar_instancia().save_path;
//                                 string cidade_nome = ( ( cidade_nome ) cidades_ids[ _index_slot_cidade ] ).ToString() ;
//                                 string path_dados = save_path + "/cidades/" + cidade_nome + "_dados.dat" ;
//                                 byte[] dados_bytes = System.IO.File.ReadAllBytes( path_dados );
//                                 cidade_containers = Construtor_containers_cidades.Pegar( dados_bytes );
                                
//                         }

//                 return cidade_containers;

//         }




//         public void Carregar_dados_cidade_MULTITHREAD( int _cidade_id ){

//                 // carrega AI + Containers 
                

//                 // verifica se já foi pedido
//                 for( int slot_teste = 0 ; slot_teste < cidades_ids.Length ; slot_teste++ ){

//                         if( cidades_ids[ slot_teste ] == _cidade_id )
//                                 // já foi dado a ordem para carregar
//                                 // tem que garantir que vai excluir o cidade aqui também 
//                                 { 
//                                         #if !UNITY_EDITOR
//                                           Teste_play.Verificar_se_cidade_realmente_foi_pedido( slot_teste, requisicoes_cidades, containers_dados_cidades, cidades_AIs );
//                                         #endif
//                                         return; 
//                                 }

//                 }


//                 int slot_cidade = Criar_slot_cidade( _cidade_id );




//                 string cidade_nome = ( ( cidade_nome ) cidades_ids[ _index_slot_cidade ] ).ToString() ;
//                 string nome_clase_cidade =  cidade_nome + "_dados";
//                 string save_path = Controlador_dados_sistema.Pegar_instancia().save_path;
//                 string path_dados = save_path + "/cidades/" + cidade_nome + "_dados.dat" ;

        
//                 Task_req task = new Task_req( new Chave_cache() , ( "pegar_cidade " + cidade_nome)  );

//                 task.fn_iniciar = ( Task_req _req ) => {

//                         _req.dados_array_suporte = new System.Object[ 2 ];



//                         // --- CARREGA AI
//                         // a principio vai carregar tudo que pode ser necessario para o cidade 
//                         System.Object cidade_AI =  asm_cidades.CreateInstance( nome_clase_cidade );
//                         _req.dados_array_suporte[ 0 ] = cidade_AI;


//                         // --- cidade DADOS
//                         byte[] dados_bytes = null;

//                         if( ! ( System.IO.File.Exists( path_dados ) ) )
//                                 { return; } // vai dar erro depois 
//                         dados_bytes = System.IO.File.ReadAllBytes( path_dados );
//                         Dados_containers_cidades cidade_containers = Leitor_dados_cidade.Pegar( dados_bytes );

//                         _req.dados_array_suporte[ 1 ] = cidade_containers;

//                         return;

//                 };


//                 task.fn_finalizar = ( Task_req _req ) => {

                        
//                         // -- VERIFICAR SE OS DADOS FORAM PEGOS CORRETAMENTE

//                         System.Object cidade_AI = _req.dados_array_suporte[ 0 ];
//                         Dados_containers_cidades containers_cidade = _req.dados_array_suporte[ 1 ];

//                         if( cidade_AI == null ){

//                                 Debug.LogError( $"nao foi achado persoangem { cidade_nome } nos dados AI cidades com o nome : { nome_clase_cidade }" );
//                                 throw new Exception();

//                         }

//                         if( containers_cidade == null ){

//                                 Debug.LogError( $"nao foi achado os dados.dat do persoangem { cidade_nome } no path : { path_dados }" );
//                                 throw new Exception();

//                         }

//                         cidades_AIs[ slot_cidade ] = cidade_AI;
//                         dados_containers_cidades[ slot_cidade ] = containers_cidade;

//                         return;


//                 };

                                                

//                 _cidade.dados_cidade_run_time = cidade_objeto_generico;

//                 MethodInfo metodo_info = asm_cidades.GetType( cidade_metodo_nome ).GetMethod("Pegar_dados");

//                 // opcao 1 => entregar cidade e o metodo coloca actions e delegados 
//                 // opcao 2 => o metodo devolve um objeto que tem os delegados e action
                
//                 metodo_info.Invoke(   cidade_objeto_generico , new System.Object[]{ _cidade }  );

//                 return;


//         }








//         public int Pegar_slot_cidade( int _cidade_id ){
        
//                 for( int cidade_slot_index = 0 ; cidade_slot_index < cidades_ids.Length ; cidade_slot_index++ ){

//                         if( cidades_ids[ cidade_slot_index ] ==  _cidade_id )
//                                 { return cidade_slot_index; }

//                 }

//                 Debug.Log( "------------ ERRO -------------" );
//                 Debug.LogError( $"Pediu o slot do cidade { ((cidade_nome) _cidade_id).ToString() } mas ninguem pediu ele"  );
//                 Debug.Log( "-------------------------------" );
                
//         }



//         public int Criar_slot_cidade( int _cidade_id ){


        
//                 for( int cidade_slot_index = 0 ; cidade_slot_index < cidades_ids.Length ; cidade_slot_index++ ){

//                         if( cidades_ids[ cidade_slot_index ] ==  0 )
//                                 {       
//                                         // ** talvez possa colocar algo aqui para verificar se os dados fora excluidos corretamente 
//                                         cidades_ids[ cidade_slot_index ] = _cidade_id;
//                                         return cidade_slot_index; 
//                                 }

//                 }

//                 // nao tem slots_livres

//                 int index_final_livre = cidades_ids.Length;


//                 int[] novo_inds = new int[ cidades_ids.Length ];
//                 Dados_containers_cidades[] novo_containers = new Dados_containers_cidades[ cidades_ids.Length ];
//                 System.Object[] novo_AI = new System.Object[ cidades_ids.Length ];

//                 for( int index_antigo = 0 ; index_antigo < cidades_ids.Length ; index_antigo++ ){

//                         novo_inds[ index_antigo ] = cidades_ids[ index_antigo ];
//                         novo_containers[ index_antigo ] = dados_containers_cidades[ index_antigo ];
//                         novo_AI[ index_antigo ] = cidades_AIs[ index_antigo ];

//                 }

//                 cidades_ids[ index_final_livre ] = _cidade_id;

//                 cidades_AIs = novo_AI;
//                 cidades_ids = novo_inds;
//                 dados_containers_cidades = novo_containers;


//                 return index_final_livre;

//         }



//         public void Remover_dados_cidade ( int _cidade_id ){

//                 int slot_cidade = Pegar_slot_cidade( _cidade_id);

                
//                 cidades_AIs[ slot_cidade ] = null;
//                 cidades_ids[ slot_cidade ] = 0;
//                 dados_containers_cidades[ slot_cidade ] = null;

//                 if( requisicoes_cidades[ slot_cidade ] !+ null )
//                         {
//                                 requisicoes_cidades[ slot_cidade ].pode_executar = false;
//                                 requisicoes_cidades[ slot_cidade ] = null;

//                         }

                

//                 return;

//         }





// }