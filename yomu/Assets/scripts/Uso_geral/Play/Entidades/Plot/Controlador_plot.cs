using System;




public class Controlador_plots {

        public static Controlador_plots instancia;
        public static Controlador_plots Pegar_instancia(){ return instancia; }


        public Gerenciador_dados_dinamicos_plots gerenciador_dados_dinamicos;
        public Gerenciador_save_plots gerenciador_save;

        public Dados_sistema_plot_essenciais[] dados_sistema_plots_essenciais;
                                               

        public Plot[] plots;

        public int[] plots_ativos_ids;

        // plot nao tem lugar ou plano. 
        // eles geralmente sao menores e precisam ser excluidos rapidamente para nao gastar muita memoria
        public int[] plots_pentendes_para_adicionar;
        public int[] plots_pentendes_para_adicionar_tempo;



        public static Controlador_plots Construir( Dados_sistema_plot_essenciais[] _dados_sistema_plots_essenciais , Dados_sistema_estado_atual _dados_sistema_estado_atual ) {

                Controlador_plots controlador = new Controlador_plots();


                        controlador.gerenciador_dados_dinamicos = new Gerenciador_dados_dinamicos_plots();
                        controlador.gerenciador_save = new Gerenciador_save_plots( controlador );

                        controlador.dados_sistema_plots_essenciais = _dados_sistema_plots_essenciais;
                        controlador.plots_ativos_ids = _dados_sistema_estado_atual.plots_ativos_ids;
                        controlador.plots_pentendes_para_adicionar = _dados_sistema_estado_atual.plots_pentendes_para_adicionar;
                        controlador.plots_pentendes_para_adicionar_tempo = _dados_sistema_estado_atual.plots_pentendes_para_adicionar_tempo;

            
                instancia = controlador;
                return controlador;


        }

        public static Controlador_plots Construir_teste() {

                Controlador_plots controlador = new Controlador_plots();


                        controlador.gerenciador_dados_dinamicos = new Gerenciador_dados_dinamicos_plots();
                        controlador.gerenciador_save = new Gerenciador_save_plots( controlador );

                        controlador.dados_sistema_plots_essenciais = new Dados_sistema_plot_essenciais[ Enum.GetNames( typeof( Plot_nome ) ).Length ];
                        controlador.plots_ativos_ids = new int[ 0 ];

            
                instancia = controlador;
                return controlador;


        }





        public void Iniciar_plot(  int _plot_id ){



                int plot_slot = gerenciador_dados_dinamicos.Pegar_slot_plots( _plot_id );

                System.Object plot_AI =   gerenciador_dados_dinamicos.Pegar_AI_plots( plot_slot );
                Dados_containers_plot dados_containers_plot = gerenciador_dados_dinamicos.Pegar_containers_plot( plot_slot );
                Dados_sistema_plot_essenciais dados_sistema_plot_essenciais = dados_sistema_plots_essenciais[ _plot_id ];

                Plot novo_plot =  Construtor_plot.Construir( _plot_id, dados_sistema_plot_essenciais,  dados_containers_plot, plot_AI );
                
                plots [ _plot_id ] = novo_plot; 

                // --- COLOCA plot NO PLANO
                INT.Acrescentar_valor_COMPLETO_GARANTIDO( ref plots_ativos_ids , _plot_id );


                // ---- CRIA SLOT INSTRUCOES
                gerenciador_save.instrucoes_plots[ _plot_id ]  = new byte[ 50 ][];

                byte[] intrucao_colocar = Instrucoes_plots.Pegar_instrucao( ( int ) Instrucao_plot.iniciar );
                gerenciador_save.Colocar_instrucoes_de_seguranca_plot( _plot_id ,intrucao_colocar );



                return;


        }





        // diferente de personagem quando um plot é descartado ele nao pode voltar 
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