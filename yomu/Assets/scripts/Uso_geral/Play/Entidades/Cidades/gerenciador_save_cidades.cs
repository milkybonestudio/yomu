



public class Gerenciador_save_cidades {


        // ---- PERSONAGENS LIXEIRA

        public Cidade[] cidades_esperando_para_serem_excluidos;
        public int[] cidades_esperando_para_serem_excluidos_ids;

        // ---------------------------------


        // --- USO SALVANDO STACK
        public int[] cidades_sendo_salvos_segunda_stack; // instanciar quando precisar
        public int[] cidades_com_dados_nao_salvos_na_stack ;// cidades que estao na lixeira também esta aqui 
        public int cidade_sendo_salvo; // dados vao para a segunda stack. se ja esta na segunda precisa disso?
        
        public byte[][][] instrucoes_cidades; // length = numero de cidades
        public int[] index_instrucao_atual; // length = numero de cidades





        public Dados_para_salvar Pegar_cidade_para_salvar( Modo_save _modo ){



                if( _modo == Modo_save.salvando_stack )
                        {
                                // o foco quando a stack estiver sendo trocada vai ser sempre 

                                for( int cidade_primeira_stack_index = 0 ; cidade_primeira_stack_index < personagens_com_dados_nao_salvos_na_stack.Length; cidade_primeira_stack_index++ ){

                                        if ( personagens_com_dados_nao_salvos_na_stack[ cidade_primeira_stack_index ] == 0 )
                                                { continue; }
                                                
                                        return Criar_dados_para_salvar_cidade( cidades_esperando_para_serem_excluidos_ids[ cidade_primeira_stack_index ] ); 
                                        
                                }

                                // --- SE ESTA SALVANDO A STACK NAO VAI PARA A LIXEIRA 
                                // ** tudo que estava na lixeira e agora nao esta na lista já foi salvo e agora aquele persoangem esta sendo salvo na stack 2 
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
                        cidades_esperando_para_serem_excluidos[ _cidade_id ] = 0;

                        string personagem_nome = ( ( Personagem_nome ) _cidade_id ).ToString() ;
                        string path = Paths_sistema.path_dados_cidades + "/" + personagem_nome + "_dados.dat";

                        dados_retorno.path = path;

                        return dados_retorno;

        }




        public byte[][][][] Pegar_instrucoes_de_seguranca( Modo_save _modo ){


                return new byte[][][][]{

                        new byte[ 0 ][][],
                        new byte[ 0 ][][],
                        new byte[ 0 ][][],
                        new byte[ 0 ][][]

                };
                

        }






}

