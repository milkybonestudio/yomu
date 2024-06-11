// using System;
// using System.Reflection;
// using UnityEngine;




// public class Dados_containers_plots {

// }


// public class Dados_dinamicos_plots {


//         public static Dados_dinamicos_plots instancia;
//         public static Dados_dinamicos_plots Pegar_instancia(){ return instancia; }


//         public Dados_dinamicos_plots(){ 

//                 #if UNITY_EDITOR
//                         // o editor consegue pegar eles normalmente
//                         asm_plots= Assembly.Load( "World_run_time" );
//                 #endif
//                 #if !UNITY_EDITOR
//                                 // mudar o nome
//                         asm_plots= Assembly.LoadFrom( Application.dataPath + "/Run_time_dados/World_run_time.dll" );
//                 #endif

//         }


//         public Assembly asm_plots;
        
//         public int[] plots_ids = new int[ 50 ];
//         public System.Object[] plots_AIs = new System.Object[ 50 ];
//         public Dados_containers_plots[] dados_containers_plots = new Dados_containers_plots[ 50 ];
//         public Task_req[] requisicoes_plots = new Task_req[ 50 ];


//         public System.Object Pegar_AI_plot ( int _index_slot_plot ){

//                 // ** tem que pegar slot antes
//                 // se nao foi carregado vai forçar para carregar na main

//                 if( requisicoes_plots[ _index_slot_plot] != null )
//                         { 
//                                 // garante que nao vai substituir os dados 
//                                 requisicoes_plots[ _index_slot_plot].pode_executar = false; 
//                                 requisicoes_plots[ _index_slot_plot] = null; 
//                         }
                

//                 System.Object plot_AI =  plots_AIs[ _index_slot_plot ];
                
//                 if( plot_AI == null )
//                         {       
//                                 // nao nao conseguiu pegar na multithread, vai forçar na main 
                                
//                                 string plot_class_nome =  ( ( plot_nme ) _plot_id ).ToString() + "_dados";
//                                 plot_AI =  asm_plots.CreateInstance( plot_class_nome );
//                                 plots_AIs[ _index_slot_plot ] = plot_AI;

//                         }

//                 return plot_AI;

//         }


//         public System.Object Pegar_containers_plot ( int _index_slot_plot ){

//                 // ** tem que pegar slot antes
//                 // se nao foi carregado vai forçar para carregar 

//                 if( requisicoes_plots[ _index_slot_plot] != null )
//                         { 
//                                 // garante que nao vai substituir os dados 
//                                 requisicoes_plots[ _index_slot_plot].pode_executar = false; 
//                                 requisicoes_plots[ _index_slot_plot] = null; 
//                         }
                
//                 Containers_dados_plot plot_containers =  dados_containers_plots[ _index_slot_plot ];

//                 if( plot_containers == null )
//                         {
//                                 string save_path = Controlador_dados_sistema.Pegar_instancia().save_path;
//                                 string plot_nome = ( ( plot_nome ) plots_ids[ _index_slot_plot ] ).ToString() ;
//                                 string path_dados = save_path + "/plots/" + plot_nome + "_dados.dat" ;
//                                 byte[] dados_bytes = System.IO.File.ReadAllBytes( path_dados );
//                                 plot_containers = Construtor_containers_plots.Pegar( dados_bytes );
                                
//                         }

//                 return plot_containers;

//         }




//         public void Carregar_dados_plot_MULTITHREAD( int _plot_id ){

//                 // carrega AI + Containers 
                

//                 // verifica se já foi pedido
//                 for( int slot_teste = 0 ; slot_teste < plots_ids.Length ; slot_teste++ ){

//                         if( plots_ids[ slot_teste ] == _plot_id )
//                                 // já foi dado a ordem para carregar
//                                 // tem que garantir que vai excluir o plot aqui também 
//                                 { 
//                                         #if !UNITY_EDITOR
//                                           Teste_play.Verificar_se_plot_realmente_foi_pedido( slot_teste, requisicoes_plots, containers_dados_plots, plots_AIs );
//                                         #endif
//                                         return; 
//                                 }

//                 }


//                 int slot_plot = Criar_slot_plot( _plot_id );




//                 string plot_nome = ( ( plot_nome ) plots_ids[ _index_slot_plot ] ).ToString() ;
//                 string nome_clase_plot =  plot_nome + "_dados";
//                 string save_path = Controlador_dados_sistema.Pegar_instancia().save_path;
//                 string path_dados = save_path + "/plots/" + plot_nome + "_dados.dat" ;

        
//                 Task_req task = new Task_req( new Chave_cache() , ( "pegar_plot " + plot_nome)  );

//                 task.fn_iniciar = ( Task_req _req ) => {

//                         _req.dados_array_suporte = new System.Object[ 2 ];



//                         // --- CARREGA AI
//                         // a principio vai carregar tudo que pode ser necessario para o plot 
//                         System.Object plot_AI =  asm_plots.CreateInstance( nome_clase_plot );
//                         _req.dados_array_suporte[ 0 ] = plot_AI;


//                         // --- plot DADOS
//                         byte[] dados_bytes = null;

//                         if( ! ( System.IO.File.Exists( path_dados ) ) )
//                                 { return; } // vai dar erro depois 
//                         dados_bytes = System.IO.File.ReadAllBytes( path_dados );
//                         Dados_containers_plots plot_containers = Leitor_dados_plot.Pegar( dados_bytes );

//                         _req.dados_array_suporte[ 1 ] = plot_containers;

//                         return;

//                 };


//                 task.fn_finalizar = ( Task_req _req ) => {

                        
//                         // -- VERIFICAR SE OS DADOS FORAM PEGOS CORRETAMENTE

//                         System.Object plot_AI = _req.dados_array_suporte[ 0 ];
//                         Dados_containers_plots containers_plot = _req.dados_array_suporte[ 1 ];

//                         if( plot_AI == null ){

//                                 Debug.LogError( $"nao foi achado persoangem { plot_nome } nos dados AI plots com o nome : { nome_clase_plot }" );
//                                 throw new Exception();

//                         }

//                         if( containers_plot == null ){

//                                 Debug.LogError( $"nao foi achado os dados.dat do persoangem { plot_nome } no path : { path_dados }" );
//                                 throw new Exception();

//                         }

//                         plots_AIs[ slot_plot ] = plot_AI;
//                         dados_containers_plots[ slot_plot ] = containers_plot;

//                         return;


//                 };

                                                

//                 _plot.dados_plot_run_time = plot_objeto_generico;

//                 MethodInfo metodo_info = asm_plots.GetType( plot_metodo_nome ).GetMethod("Pegar_dados");

//                 // opcao 1 => entregar plot e o metodo coloca actions e delegados 
//                 // opcao 2 => o metodo devolve um objeto que tem os delegados e action
                
//                 metodo_info.Invoke(   plot_objeto_generico , new System.Object[]{ _plot }  );

//                 return;


//         }








//         public int Pegar_slot_plot( int _plot_id ){
        
//                 for( int plot_slot_index = 0 ; plot_slot_index < plots_ids.Length ; plot_slot_index++ ){

//                         if( plots_ids[ plot_slot_index ] ==  _plot_id )
//                                 { return plot_slot_index; }

//                 }

//                 Debug.Log( "------------ ERRO -------------" );
//                 Debug.LogError( $"Pediu o slot do plot { ((plot_nome) _plot_id).ToString() } mas ninguem pediu ele"  );
//                 Debug.Log( "-------------------------------" );
                
//         }



//         public int Criar_slot_plot( int _plot_id ){


        
//                 for( int plot_slot_index = 0 ; plot_slot_index < plots_ids.Length ; plot_slot_index++ ){

//                         if( plots_ids[ plot_slot_index ] ==  0 )
//                                 {       
//                                         // ** talvez possa colocar algo aqui para verificar se os dados fora excluidos corretamente 
//                                         plots_ids[ plot_slot_index ] = _plot_id;
//                                         return plot_slot_index; 
//                                 }

//                 }

//                 // nao tem slots_livres

//                 int index_final_livre = plots_ids.Length;


//                 int[] novo_inds = new int[ plots_ids.Length ];
//                 Dados_containers_plots[] novo_containers = new Dados_containers_plots[ plots_ids.Length ];
//                 System.Object[] novo_AI = new System.Object[ plots_ids.Length ];

//                 for( int index_antigo = 0 ; index_antigo < plots_ids.Length ; index_antigo++ ){

//                         novo_inds[ index_antigo ] = plots_ids[ index_antigo ];
//                         novo_containers[ index_antigo ] = dados_containers_plots[ index_antigo ];
//                         novo_AI[ index_antigo ] = plots_AIs[ index_antigo ];

//                 }

//                 plots_ids[ index_final_livre ] = _plot_id;

//                 plots_AIs = novo_AI;
//                 plots_ids = novo_inds;
//                 dados_containers_plots = novo_containers;


//                 return index_final_livre;

//         }



//         public void Remover_dados_plot ( int _plot_id ){

//                 int slot_plot = Pegar_slot_plot( _plot_id);

                
//                 plots_AIs[ slot_plot ] = null;
//                 plots_ids[ slot_plot ] = 0;
//                 dados_containers_plots[ slot_plot ] = null;

//                 if( requisicoes_plots[ slot_plot ] !+ null )
//                         {
//                                 requisicoes_plots[ slot_plot ].pode_executar = false;
//                                 requisicoes_plots[ slot_plot ] = null;

//                         }

                

//                 return;

//         }





// }