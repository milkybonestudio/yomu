



public class Gerenciador_save_plots {

        
        public Gerenciador_save_plots( Controlador_plots _controlador_plots){
                controlador_plots = _controlador_plots;
        }



        public Controlador_plots controlador_plots;


        // ---- plots LIXEIRA

        public Plot[] plots_esperando_para_serem_excluidos;
        public int[] plots_esperando_para_serem_excluidos_ids;

        // ---------------------------------


        // --- USO SALVANDO STACK
        public int[] plots_sendo_salvos_segunda_stack; // instanciar quando precisar
        public int[] plots_com_dados_nao_salvos_na_stack ;// plots que estao na lixeira também esta aqui 
        public int plot_sendo_salvo; // dados vao para a segunda stack. se ja esta na segunda precisa disso?
        
        public byte[][][] instrucoes_plots; // length = numero de plots
        public int[] index_instrucao_atual; // length = numero de plots




        public void Colocar_plot_na_lixeira( Plot _plot ){
                // ** Plots nao podem ser reciclados. 
                // quando um plot for concretizado as informacoes importantes vao passar para os containers de cada personagem/cidade


                for( int slot_teste = 0 ; slot_teste < plots_esperando_para_serem_excluidos.Length ;slot_teste++ ){

                        if( plots_esperando_para_serem_excluidos_ids[ slot_teste ] == 0)
                                {
                                        plots_esperando_para_serem_excluidos_ids[ slot_teste ] = _plot.plot_id;
                                        plots_esperando_para_serem_excluidos[ slot_teste ] = _plot;
                                        return;
                                }

                }


                Plot[] novo_plots = new Plot[ plots_esperando_para_serem_excluidos_ids.Length + 5 ];
                int[] novo_plots_ids = new int[ plots_esperando_para_serem_excluidos_ids.Length + 5 ];

                int index_para_acrescentar = plots_esperando_para_serem_excluidos_ids.Length;

                for( int novo_arr_index = 0; novo_arr_index < plots_esperando_para_serem_excluidos_ids.Length; novo_arr_index++ ){

                        novo_plots_ids[ novo_arr_index ]  =  plots_esperando_para_serem_excluidos_ids[ novo_arr_index ];
                        novo_plots[ novo_arr_index ]  =  plots_esperando_para_serem_excluidos[ novo_arr_index ];
                        
                }


                plots_esperando_para_serem_excluidos = novo_plots;
                plots_esperando_para_serem_excluidos_ids = novo_plots_ids;

                plots_esperando_para_serem_excluidos_ids[ index_para_acrescentar ] = _plot.plot_id;
                plots_esperando_para_serem_excluidos[ index_para_acrescentar ] = _plot;



                return;

        
        }


        // tem que checar plots também 
        public Plot Retirar_plot_da_lixeira( int _plot_id ){

                for( int plot_slot_index = 0; plot_slot_index  < plots_esperando_para_serem_excluidos_ids.Length; plot_slot_index ++ ){

                        if( plots_esperando_para_serem_excluidos_ids[ plot_slot_index ] == _plot_id )
                                { 
                                        Plot plot = plots_esperando_para_serem_excluidos[ plot_slot_index ];
                                        plots_esperando_para_serem_excluidos[ plot_slot_index ] = null;
                                        plots_esperando_para_serem_excluidos_ids[ plot_slot_index ] = 0;
                                        return plot; 

                                }

                        continue;

                        
                }

                return null;

        }








        public Dados_para_salvar Pegar_plot_para_salvar( Modo_save _modo ){


                if( _modo == Modo_save.salvando_stack )
                        {
                                // o foco quando a stack estiver sendo trocada vai ser sempre 

                                for( int plot_primeira_stack_index = 0 ; plot_primeira_stack_index < plots_com_dados_nao_salvos_na_stack.Length; plot_primeira_stack_index++ ){

                                        if ( plots_com_dados_nao_salvos_na_stack[ plot_primeira_stack_index ] == 0 )
                                                { continue; }
                                                
                                        return Criar_dados_para_salvar_plot( plots_esperando_para_serem_excluidos_ids[ plot_primeira_stack_index ] ); 
                                        
                                }

                                // --- SE ESTA SALVANDO A STACK NAO VAI PARA A LIXEIRA 
                                return null;
                        }

                
                // --- VERIFICAR LIXEIRA
                for( int plot_lixeira_index = 0 ; plot_lixeira_index < plots_esperando_para_serem_excluidos_ids.Length ; plot_lixeira_index++ ){

                        if( plots_esperando_para_serem_excluidos_ids[ plot_lixeira_index ] != 0 )
                                { return Criar_dados_para_salvar_plot( plots_esperando_para_serem_excluidos_ids[ plot_lixeira_index ] ); }

                }
 
                return null ;

        }



        public Dados_para_salvar Criar_dados_para_salvar_plot( int _plot_id ) {


                        Dados_para_salvar dados_retorno = new Dados_para_salvar();
                
                        // isso talvez possa demorar 
                        Plot plot_esperando_para_ser_excluido = plots_esperando_para_serem_excluidos[ _plot_id ];
                        dados_retorno.dados = plot_esperando_para_ser_excluido.gerenciador_containers_dados.Compilar_dados();

                        // dados agora vai para a segunda stack
                        plots_esperando_para_serem_excluidos_ids[ _plot_id ] = 0;

                        dados_retorno.path = Paths_sistema.Pegar_path_arquivo__dados_dinamicos__entidade( Entidade_nome.plot , plot_esperando_para_ser_excluido.ToString() );

                        return dados_retorno;

        }


        public void Colocar_instrucoes_de_seguranca_plot(  int _plot_id,  byte[] _dados_seguranca  ){


                int index = index_instrucao_atual[ _plot_id ];
                index_instrucao_atual[ _plot_id ] = index + 1;

                if( index == instrucoes_plots[ _plot_id ].Length )
                        { instrucoes_plots[ _plot_id ] = BYTE.Aumentar_length_array_2d( instrucoes_plots[ _plot_id ], 10 ); }

                instrucoes_plots[ _plot_id ][ index ] = _dados_seguranca;

                return; 

        }



        




        public byte[][][][] Pegar_instrucoes_de_seguranca_plots( Modo_save _modo ){



                // [ stack ][ plot ][ instrucoes ][ bytes_instucoes ]

                byte[][][][] retorno = new byte[ 2 ][][][]{

                        new byte[ 0 ][][], 
                        new byte[ 0 ][][], 

                };


                int numero_plots_primeira_stack = INT.Length_elementos_maiores_que_0( plots_com_dados_nao_salvos_na_stack );
                retorno[ 0 ] = new byte[ numero_plots_primeira_stack  ][][]; 
                

                // --- PEGA PRIMEIRA STACK
                for(  int plot_primeira_stack_index = 0 ; plot_primeira_stack_index < plots_com_dados_nao_salvos_na_stack.Length ; plot_primeira_stack_index++ ){

                        int plot_id = plots_com_dados_nao_salvos_na_stack[ plot_primeira_stack_index ];
                        byte[][] plot_instrucoes = instrucoes_plots[ plot_id ];
                        retorno[ 0 ][ plot_primeira_stack_index ] = plot_instrucoes;
                        // reseta slot 
                        instrucoes_plots[ plot_id ] = new byte[ 20 ][];
                        continue;

                }



                if( _modo == Modo_save.salvando_stack )
                        {
                                
                                int numero_plots_segunda_stack = INT.Length_elementos_maiores_que_0( plots_sendo_salvos_segunda_stack );                                
                                retorno[ 1 ] = new byte[ numero_plots_segunda_stack  ][][]; 

                                // --- PEGA SEGUNDA STACK
                                for(  int plot_segunda_stack_index = 0 ; plot_segunda_stack_index < plots_sendo_salvos_segunda_stack.Length ; plot_segunda_stack_index++ ){

                                        int plot_id = plots_sendo_salvos_segunda_stack[ plot_segunda_stack_index ];
                                        byte[][] plot_instrucoes = instrucoes_plots[ plot_id ];
                                        retorno[ 2 ][ plot_segunda_stack_index ] = plot_instrucoes;
                                        // reseta slot 
                                        instrucoes_plots[ plot_id ] = new byte[ 20 ][];
                                        continue;

                                }


                        }

                return retorno;

                

        }






}

