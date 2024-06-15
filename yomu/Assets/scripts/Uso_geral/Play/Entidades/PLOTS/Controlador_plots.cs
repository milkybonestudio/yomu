using System;




public class Controlador_plots {

        public static Controlador_plots instancia;
        public static Controlador_plots Pegar_instancia(){ return instancia; }


        public Gerenciador_dados_dinamicos_plots gerenciador_dados_dinamicos;
        public Gerenciador_save_plots gerenciador_save;

        public Dados_sistema_plot_essenciais[] dados_sistema_plots_essenciais;
        public Dados_sistema_plot[] dados_sistema_plots;
                                               

        public Plot[] plots;

        public int[] plots_ativos_ids;
        public int[] plots_ativos_planos;





        public static Controlador_plots Construir( Dados_sistema_plot_essenciais[] _dados_sistema_plots_essenciais , Dados_sistema_estado_atual _dados_sistema_estado_atual ) {

                Controlador_plots controlador = new Controlador_plots();


                        controlador.gerenciador_dados_dinamicos = new Gerenciador_dados_dinamicos_plots();
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
                        System.Object plot_AI =   gerenciador_dados_dinamicos.Pegar_AI_plot_NAO_CARREGADO( _plot_id );
                        Dados_containers_plot dados_containers_plots = gerenciador_dados_dinamicos.Pegar_containers_plot_NAO_CARREGADO( _plot_id );

                        Plot plot_para_adicionar =  Construtor_plot.Construir( _plano_para_adicionar_id, _plano_para_adicionar_id, dados_sistema_plot_essenciais,  dados_containers_plots, plot_AI );

                        // --- COLOCA DADOS CONTAINERS 
                        plots [ _plot_id ] = plot_para_adicionar; 
                        dados_sistema_plots[ _index_dados_sistema ] = plot_para_adicionar.gerenciador_dados_sistema.Pegar_dados();

                        // ---- CRIA SLOT INSTRUCOES
                        gerenciador_save.instrucoes_plots[ _plot_id ]  = new byte[ 50 ][];

                        return;

        }


        

        public void Adicionar_plot( int _plano_para_adicionar_id,  int _plot_id )  {

                        // --- CRIA plot
                        
                        int plot_slot = gerenciador_dados_dinamicos.Pegar_slot_plot( _plot_id );

                        System.Object plot_AI =   gerenciador_dados_dinamicos.Pegar_AI_plot( plot_slot );
                        Dados_containers_plot dados_containers_plots = gerenciador_dados_dinamicos.Pegar_containers_plot( plot_slot );
                        Dados_sistema_plot_essenciais dados_sistema_plot_essenciais = dados_sistema_plots_essenciais[ _plot_id ];

                        Plot plot_para_adicionar =  Construtor_plot.Construir( _plano_para_adicionar_id, _plano_para_adicionar_id, dados_sistema_plot_essenciais,  dados_containers_plots, plot_AI );

                        // --- COLOCA DADOS CONTAINERS 

                        plots [ _plot_id ] = plot_para_adicionar; 
                        int index_slot_plot = INT.Acrescentar_valor_COMPLETO_GARANTIDO( ref plots_ativos_ids , _plot_id );
                        dados_sistema_plots[ index_slot_plot ] = plot_para_adicionar.gerenciador_dados_sistema.Pegar_dados();

                        // ---- CRIA SLOT INSTRUCOES
                        gerenciador_save.instrucoes_plots[ _plot_id ]  = new byte[ 50 ][];

                        return;

        }





        public void Carregar_dados_plot( int _plot_id , int _periodos_para_iniciar ){


                Plot plot_na_lixeira = gerenciador_save.Retirar_plot_da_lixeira( _plot_id );

                if( plot_na_lixeira != null )
                        {
                                #if UNITY_EDITOR
                                        Console.Log( $"plot <color=red> { (( Plot_nome ) _plot_id).ToString()  } </color> foi tirado da lixeira e vai ser colocado em dados dinamicos" );
                                #endif
                                int slot =  gerenciador_dados_dinamicos.Criar_slot_plot( _plot_id );
                                gerenciador_dados_dinamicos.plots_AIs[ slot ] = plot_na_lixeira.gerenciador_AI_plot.plot_AI;
                                gerenciador_dados_dinamicos.dados_containers_plots[ slot ] = plot_na_lixeira.gerenciador_containers_dados.dados;
                        }
                        else
                        {
                                gerenciador_dados_dinamicos.Carregar_dados_plot_MULTITHREAD( _plot_id );
                        }

                
                // ** passou para sistema
                // INT.Acrescentar_valor_COMPLETO_GARANTIDO( ref plots_pentendes_para_adicionar , _plot_id );
                // INT.Acrescentar_valor_COMPLETO_GARANTIDO( ref plots_pentendes_para_adicionar_tempo , _periodos_para_iniciar );

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