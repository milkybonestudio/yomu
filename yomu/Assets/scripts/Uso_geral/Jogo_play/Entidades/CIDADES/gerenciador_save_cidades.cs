



public class Gerenciador_save_cidades {

        
        public Gerenciador_save_cidades( Controlador_cidades _controlador_cidades ){
                controlador_cidades = _controlador_cidades;
        }



        public Controlador_cidades controlador_cidades;


        // ---- CIDADES LIXEIRA

        public Cidade[] cidades_esperando_para_serem_excluidos;
        public int[] cidades_esperando_para_serem_excluidos_ids;

        // ---------------------------------


        // --- USO SALVANDO STACK
        public int[] cidades_sendo_salvos_segunda_stack; // instanciar quando precisar
        public int[] cidades_com_dados_nao_salvos_na_stack ;// cidades que estao na lixeira também esta aqui 
        public int cidade_sendo_salvo; // dados vao para a segunda stack. se ja esta na segunda precisa disso?
        
        public byte[][][] instrucoes_cidades; // length = numero de cidades
        public int[] index_instrucao_atual; // length = numero de cidades




        public void Colocar_cidade_na_lixeira( Cidade _cidade ){


                for( int slot_teste = 0 ; slot_teste < cidades_esperando_para_serem_excluidos.Length ;slot_teste++ ){

                        if( cidades_esperando_para_serem_excluidos_ids[ slot_teste ] == 0)
                                {
                                        cidades_esperando_para_serem_excluidos_ids[ slot_teste ] = _cidade.cidade_id;
                                        cidades_esperando_para_serem_excluidos[ slot_teste ] = _cidade;
                                        return;
                                }

                }


                Cidade[] novo_cidades = new Cidade[ cidades_esperando_para_serem_excluidos_ids.Length + 5 ];
                int[] novo_cidades_ids = new int[ cidades_esperando_para_serem_excluidos_ids.Length + 5 ];

                int index_para_acrescentar = cidades_esperando_para_serem_excluidos_ids.Length;

                for( int novo_arr_index = 0; novo_arr_index < cidades_esperando_para_serem_excluidos_ids.Length; novo_arr_index++ ){

                        novo_cidades_ids[ novo_arr_index ]  =  cidades_esperando_para_serem_excluidos_ids[ novo_arr_index ];
                        novo_cidades[ novo_arr_index ]  =  cidades_esperando_para_serem_excluidos[ novo_arr_index ];
                        
                }

                
                cidades_esperando_para_serem_excluidos_ids  =  novo_cidades_ids;
                cidades_esperando_para_serem_excluidos      =  novo_cidades;

                cidades_esperando_para_serem_excluidos_ids[ index_para_acrescentar ] = _cidade.cidade_id;
                cidades_esperando_para_serem_excluidos[ index_para_acrescentar ] = _cidade;

                return;

        
        }


        // tem que checar cidades também 
        public Cidade Retirar_cidade_da_lixeira( int _cidade_id ){

                for( int cidade_slot_index = 0; cidade_slot_index  < cidades_esperando_para_serem_excluidos_ids.Length; cidade_slot_index ++ ){

                        if( cidades_esperando_para_serem_excluidos_ids[ cidade_slot_index ] == _cidade_id )
                                { 
                                        Cidade cidade = cidades_esperando_para_serem_excluidos[ cidade_slot_index ];
                                        cidades_esperando_para_serem_excluidos[ cidade_slot_index ] = null;
                                        cidades_esperando_para_serem_excluidos_ids[ cidade_slot_index ] = 0;
                                        return cidade; 

                                }

                        continue;

                        
                }

                return null;

        }








        public Dados_para_salvar Pegar_cidade_para_salvar( Modo_save _modo ){


                if( _modo == Modo_save.salvando_stack )
                        {
                                // o foco quando a stack estiver sendo trocada vai ser sempre 

                                for( int cidade_primeira_stack_index = 0 ; cidade_primeira_stack_index < cidades_com_dados_nao_salvos_na_stack.Length; cidade_primeira_stack_index++ ){

                                        if ( cidades_com_dados_nao_salvos_na_stack[ cidade_primeira_stack_index ] == 0 )
                                                { continue; }
                                                
                                        return Criar_dados_para_salvar_cidade( cidades_esperando_para_serem_excluidos_ids[ cidade_primeira_stack_index ] ); 
                                        
                                }

                                // --- SE ESTA SALVANDO A STACK NAO VAI PARA A LIXEIRA 
                                return null;
                        }

                
                // --- VERIFICAR LIXEIRA
                for( int cidade_lixeira_index = 0 ; cidade_lixeira_index < cidades_esperando_para_serem_excluidos_ids.Length ; cidade_lixeira_index++ ){

                        if( cidades_esperando_para_serem_excluidos_ids[ cidade_lixeira_index ] != 0 )
                                { return Criar_dados_para_salvar_cidade( cidades_esperando_para_serem_excluidos_ids[ cidade_lixeira_index ] ); }

                }
 
                return null ;

        }



        public Dados_para_salvar Criar_dados_para_salvar_cidade( int _cidade_id ) {


                        Dados_para_salvar dados_retorno = new Dados_para_salvar();
                
                        // isso talvez possa demorar 
                        dados_retorno.dados = cidades_esperando_para_serem_excluidos[ _cidade_id ].gerenciador_containers_dados.Compilar_dados();

                        // dados agora vai para a segunda stack
                        cidades_esperando_para_serem_excluidos_ids[ _cidade_id ] = 0;

                        string cidade_nome = ( ( Cidade_nome ) _cidade_id ).ToString() ;
                        dados_retorno.path =  Paths_sistema.Pegar_path_arquivo__dados_dinamicos__entidade( Entidade_nome.cidade, $"{ cidade_nome }_dados.dat" ) ;
                         

                        return dados_retorno;

        }


        public void Colocar_instrucoes_de_seguranca_cidade(  int _cidade_id,  byte[] _dados_seguranca  ){


                int index = index_instrucao_atual[ _cidade_id ];
                index_instrucao_atual[ _cidade_id ] = index + 1;

                if( index == instrucoes_cidades[ _cidade_id ].Length )
                        { instrucoes_cidades[ _cidade_id ] = BYTE.Aumentar_length_array_2d( instrucoes_cidades[ _cidade_id ], 10 ); }

                instrucoes_cidades[ _cidade_id ][ index ] = _dados_seguranca;

                return; 

        }



        




        public byte[][][][] Pegar_instrucoes_de_seguranca_cidades( Modo_save _modo ){



                // [ stack ][ cidade ][ instrucoes ][ bytes_instucoes ]

                byte[][][][] retorno = new byte[ 2 ][][][]{

                        new byte[ 0 ][][], 
                        new byte[ 0 ][][], 

                };


                int numero_cidades_primeira_stack = INT.Length_elementos_maiores_que_0( cidades_com_dados_nao_salvos_na_stack );
                retorno[ 0 ] = new byte[ numero_cidades_primeira_stack  ][][]; 
                

                // --- PEGA PRIMEIRA STACK
                for(  int cidade_primeira_stack_index = 0 ; cidade_primeira_stack_index < cidades_com_dados_nao_salvos_na_stack.Length ; cidade_primeira_stack_index++ ){

                        int cidade_id = cidades_com_dados_nao_salvos_na_stack[ cidade_primeira_stack_index ];
                        byte[][] cidade_instrucoes = instrucoes_cidades[ cidade_id ];
                        retorno[ 0 ][ cidade_primeira_stack_index ] = cidade_instrucoes;
                        // reseta slot 
                        instrucoes_cidades[ cidade_id ] = new byte[ 20 ][];
                        continue;

                }



                if( _modo == Modo_save.salvando_stack )
                        {
                                
                                int numero_cidades_segunda_stack = INT.Length_elementos_maiores_que_0( cidades_sendo_salvos_segunda_stack );                                
                                retorno[ 1 ] = new byte[ numero_cidades_segunda_stack  ][][]; 

                                // --- PEGA SEGUNDA STACK
                                for(  int cidade_segunda_stack_index = 0 ; cidade_segunda_stack_index < cidades_sendo_salvos_segunda_stack.Length ; cidade_segunda_stack_index++ ){

                                        int cidade_id = cidades_sendo_salvos_segunda_stack[ cidade_segunda_stack_index ];
                                        byte[][] cidade_instrucoes = instrucoes_cidades[ cidade_id ];
                                        retorno[ 2 ][ cidade_segunda_stack_index ] = cidade_instrucoes;
                                        // reseta slot 
                                        instrucoes_cidades[ cidade_id ] = new byte[ 20 ][];
                                        continue;

                                }


                        }

                return retorno;

                

        }






}

