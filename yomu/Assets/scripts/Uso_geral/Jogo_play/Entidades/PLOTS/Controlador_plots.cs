using System;




public class Controlador_plots {

        public static Controlador_plots instancia;
        public static Controlador_plots Pegar_instancia(){ return instancia; }


        public Gerenciador_save_plots gerenciador_save;

        public Gerenciador_containers_dinamicos_completos gerenciador_containers_dinamicos_completos;
        public Gerenciador_objetos_dll_dinamicos gerenciador_objetos_dll_dinamicos;
        

        public Dados_sistema_plot_essenciais[] dados_sistema_plots_essenciais;
        public Dados_sistema_plot[] dados_sistema_plots;
                                               

        public Plot[] plots;

        public int[] plots_ativos_ids;
        public int[] plots_ativos_planos;





        public static Controlador_plots Construir( Dados_sistema_plot_essenciais[] _dados_sistema_plots_essenciais , Dados_sistema_estado_atual _dados_sistema_estado_atual ) {

                Controlador_plots controlador = new Controlador_plots();


                        controlador.gerenciador_objetos_dll_dinamicos = new Gerenciador_objetos_dll_dinamicos( _nome_dll: "Plot", _numero_inicial_de_slots: 10 );
                        controlador.gerenciador_containers_dinamicos_completos = new Gerenciador_containers_dinamicos_completos( _folder_para_pegar_dados: Paths_sistema.path_dados_save_plots, _numero_inicial_de_slots: (controlador.plots_ativos_ids.Length + 10) );

                        controlador.gerenciador_save = new Gerenciador_save_plots( controlador );

                        controlador.dados_sistema_plots_essenciais = _dados_sistema_plots_essenciais;
                        controlador.plots_ativos_ids = _dados_sistema_estado_atual.plots_ativos_ids;
                        controlador.plots_ativos_ids = _dados_sistema_estado_atual.plots_ativos_planos;


                        controlador.dados_sistema_plots = new Dados_sistema_plot[ controlador.plots_ativos_ids.Length ] ;


                        for( int index_plot_ativo = 0 ; index_plot_ativo < controlador.plots_ativos_planos.Length ; index_plot_ativo++){

                                // --- PEGAR IDS
                                int plano_id = controlador.plots_ativos_planos[ index_plot_ativo ];
                                int plot_id = controlador.plots_ativos_ids[ index_plot_ativo ]; 

                                // --- CONSTRUIR
                                controlador.Adicionar_plot_INICIO_JOGO( plano_id , index_plot_ativo, index_plot_ativo );

                                continue;

                        }
            
                instancia = controlador;
                return controlador;


        }




        public void Adicionar_plot_INICIO_JOGO( int _plano_para_adicionar_id,  int _plot_id, int _index_dados_sistema ){

                        // --- CRIA plot 
                        Dados_sistema_plot_essenciais dados_sistema_plot_essenciais = dados_sistema_plots_essenciais[ _plot_id ];

                        if( dados_sistema_plot_essenciais.nome_plot == null )
                                { throw new Exception( $"nome plot { _plot_id } veio null"); }

                        // --- PEGAR AI
                        string nome_objeto_classe = $"plot_{ dados_sistema_plot_essenciais.nome_plot }_classe";
                        gerenciador_objetos_dll_dinamicos.Carregar_objeto_NA_MULTITHREAD( _plot_id, nome_objeto_classe );
                        System.Object plot_AI =   gerenciador_objetos_dll_dinamicos.Pegar_objeto( _plot_id );

                        // --- PEGAR CONTAINER
                        string path_container = $"plot_{ dados_sistema_plot_essenciais.nome_plot }_dados.dat";
                        gerenciador_containers_dinamicos_completos.Carregar_container_NA_MULTITHREAD( _plot_id, path_container );
                        byte[] dados_containers_plots_bytes = gerenciador_containers_dinamicos_completos.Pegar_container( _plot_id );
                        Dados_containers_plot dados_containers_plot = Construtor_containers_plots.Construir( dados_containers_plots_bytes );

                        // --- CONSTROI plot
                        Plot plot_para_adicionar =  Construtor_plot.Construir( _plot_id, _plano_para_adicionar_id, dados_sistema_plot_essenciais,  dados_containers_plot, plot_AI );

                        // --- COLOCA DADOS CONTAINERS 
                        plots [ _plot_id ] = plot_para_adicionar; 
                        dados_sistema_plots[ _index_dados_sistema ] = plot_para_adicionar.gerenciador_dados_sistema.Pegar_dados();

                        // ---- CRIA SLOT INSTRUCOES
                        gerenciador_save.instrucoes_plots[ _plot_id ]  = new byte[ 50 ][];

                        return;

        }


        

        public void Adicionar_plot( int _plano_para_adicionar_id,  int _plot_id )  {

					
                        System.Object plot_AI =   gerenciador_objetos_dll_dinamicos.Pegar_objeto( _plot_id );
                        byte[] dados_containers_plots_byte = gerenciador_containers_dinamicos_completos.Pegar_container( _plot_id );
                        Dados_containers_plot dados_containers_plot = Construtor_containers_plots.Construir( dados_containers_plots_byte );

                        Dados_sistema_plot_essenciais dados_sistema_plot_essenciais = dados_sistema_plots_essenciais[ _plot_id ];

                        Plot plot_para_adicionar =  Construtor_plot.Construir( _plot_id, _plano_para_adicionar_id, dados_sistema_plot_essenciais,  dados_containers_plot, plot_AI );

                        // --- COLOCA DADOS CONTAINERS 

                        plots [ _plot_id ] = plot_para_adicionar; 
                        
                        // *** TEM QUE REPENSAR ESSA PARTE

                        //plots_ativos_ids[]
                        // int index_slot_plot = INT.Acrescentar_valor_COMPLETO_GARANTIDO( ref plots_segundo_plano_ativos , _plot_id );
                        // dados_sistema_plots[ index_slot_plot ] = dados_containers_plot[ _plot_id ];



                        // ---- CRIA SLOT INSTRUCOES
                        gerenciador_save.instrucoes_plots[ _plot_id ]  = new byte[ 50 ][];

                        return;

        }





        public void Carregar_dados_plot( int _plot_id , int _periodos_para_iniciar ){



                        Plot plot_na_lixeira = gerenciador_save.Retirar_plot_da_lixeira( _plot_id );

                        if( plot_na_lixeira != null )
                                        {
                                                        #if UNITY_EDITOR
                                                                        Console.Log( $"plot <color=red> { plot_na_lixeira.plot_nome  } </color> foi tirado da lixeira e vai ser colocado em dados dinamicos" );
                                                        #endif
                                                        // --- TEM QUE COLOCAR OS DADOS DE VOLTA

                                                        int slot_objeto = gerenciador_objetos_dll_dinamicos.Criar_slot( _plot_id );
                                                        gerenciador_objetos_dll_dinamicos.objetos[ slot_objeto ] = plot_na_lixeira.gerenciador_AI.plot_AI;

                                                        int slot_container = gerenciador_containers_dinamicos_completos.Criar_slot( _plot_id );
                                                        gerenciador_containers_dinamicos_completos.dados_containers[ slot_container ] = plot_na_lixeira.gerenciador_containers_dados.Compilar_dados();
                                                        
                                                        return;

                                        }
                                        else
                                        {
                                                        

                                                        // --- CARREGAR AI
                                                        string nome_objeto_classe = $"PLOT_{ plot_na_lixeira.plot_nome }_classe";
                                                        gerenciador_objetos_dll_dinamicos.Carregar_objeto_NA_MULTITHREAD( _plot_id, nome_objeto_classe );
                                                        

                                                        // --- PEGAR CONTAINER
                                                        string path_container = $"PLOT_{ plot_na_lixeira.plot_nome }_dados.dat";
                                                        gerenciador_containers_dinamicos_completos.Carregar_container_NA_MULTITHREAD( _plot_id, path_container );

                                                        return;
                                                        
                                                
                                        }
                return;


        }





        // diferente de plot quando um plot é descartado ele nao pode voltar e ser alterado, mas ele pode ser pego de volta para ler => nao precisa carregar AI 
        // alguns plots podem executar alguma funcao quando o plot nao puder ser executado
        public void Terminar_plot( int _plot_id ){


                        // MOVO PARA A LIXEIRA

                        Plot plot = plots[ _plot_id ];

                        if( plot == null )
                                { throw new Exception( "nao tinha plot para excluir" ); }

                        


                        if ( ! ( INT.Tem_valor_no_array( plots_ativos_ids, _plot_id ) ) )
                                { 
                                        string plot_nome = (( Plot_nome ) _plot_id ).ToString();
                                        throw new Exception(  $" Foi excluir o plot <color=red>{ plot_nome } </color>"  );
                                }

                        
                        gerenciador_save.Colocar_plot_na_lixeira( plot );

                        INT.Tirar_valor_COMPLETO_GARANTIDO( ref plots_ativos_ids , _plot_id );
                        plots[ _plot_id ] = null;
                        return;


        }




        // --- SUPORTE


        public Plot Pegar_plot ( int _plot_id ){

        
                if( plots[ _plot_id ] == null  )
                        { 
                                string plot_nome = (( Plot_nome ) _plot_id ).ToString();
                                Console.LogError( $"Sistema pediu o plot { plot_nome } mas ele nao foi criado" );
                                throw new Exception( "" ); 
                        }

                return plots[ _plot_id ];

        }



}