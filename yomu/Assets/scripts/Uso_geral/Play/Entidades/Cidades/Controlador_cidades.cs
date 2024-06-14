




public class Controlador_cidades {

    public static Controlador_cidades instancia;
    public static Controlador_cidades Pegar_instancia(){ return instancia; }


    public Gerenciador_dados_dinamicos_cidades gerenciador_dados_dinamicos;
    public Gerenciador_save_cidades gerenciador_save;

    public Dados_sistema_cidade_essenciais[] dados_sistema_cidades_essenciais;
    public Dados_sistema_cidade[] dados_sistema_cidades;

    public Cidade[] cidades;

    // ** talvez elas se cruzem cruzem 
    public int player_cidade_id;
    public int[] cidades_adjacentes_cidade_player;
    public int[] cidades_relacionadas_cidade_player;


    public int cidade_segundo_plano_foco_id;
    public int[] segundo_plano_cidades_adjacentes_ids;
    public int[] segundo_plano_cidades_relacionadas_ids;

    public static Controlador_cidades Construir( Dados_sistema_cidade_essenciais[] _dados_sistema_cidades_essenciais , Dados_sistema_estado_atual _dados_sistema_estado_atual ) {

            Controlador_cidades controlador = new Controlador_cidades();


                controlador.gerenciador_save = new Gerenciador_save_cidades( controlador );
                controlador.gerenciador_dados_dinamicos = new Gerenciador_dados_dinamicos_cidades();

                controlador.dados_sistema_cidades_essenciais = _dados_sistema_cidades_essenciais;
				controlador.cidades = new Cidade[ _dados_sistema_cidades_essenciais.Length ];

                controlador.player_cidade_id = _dados_sistema_estado_atual.cidade_player_id;
                controlador.cidades_adjacentes_cidade_player = _dados_sistema_estado_atual.cidades_adjacentes_cidade_player_ids;
                controla


    }dor.cidades_relacionadas_cidade_player = _dados_sistema_estado_atual.cidades_relacionadas_cidade_player_ids;

                controlador.cidade_segundo_plano_foco_id = _dados_sistema_estado_atual.segundo_plano_cidade_foco_id;
                controlador.segundo_plano_cidades_relacionadas_ids = _dados_sistema_estado_atual.segundo_plano_cidades_relacionadas_ids;
                controlador.segundo_plano_cidades_adjacentes_ids = _dados_sistema_estado_atual.segundo_plano_cidades_adjacentes_ids;

               
                for( int index_cidade_ativa = 0 ; index_cidade_ativa < cidades_ativas_planos.Length ; index_cidade_ativa++){

                        // --- PEGAR IDS
                        int plano_id = cidades_ativas_planos[ index_cidade_ativa ];
                        int cidade_id = controlador.cidades_ativas[ index_cidade_ativa ]; 

                        // --- CONSTRUIR
                       	Adicionar_cidade_INICIO_JOGO( plano_id, cidade_id , index_cidade_ativa );

                        continue;

                }
				 
                
            

            instancia = controlador;
            return controlador;




        public void Adicionar_cidade_INICIO_JOGO( int _plano_para_adicionar_id,  int _cidade_id, int _index_dados_sistema ){

                        // --- CRIA cidade 
                        Dados_sistema_cidade_essenciais dados_sistema_cidade_essenciais = dados_sistema_cidades_essenciais[ _cidade_id ];
                        System.Object cidade_AI =   gerenciador_dados_dinamicos.Pegar_AI_cidade_NAO_CARREGADO( _cidade_id );
                        Dados_containers_cidade dados_containers_cidades = gerenciador_dados_dinamicos.Pegar_AI_cidade_NAO_CARREGADO( _cidade_id );

                        Cidade cidade_para_adicionar =  Construtor_cidade.Construir( _cidade_id, _plano_para_adicionar_id, dados_sistema_cidade_essenciais,  dados_containers_cidades, cidade_AI );

                        // --- COLOCA DADOS CONTAINERS 
                        cidades [ _cidade_id ] = cidade_para_adicionar; 
                        dados_sistema_cidades[ _index_dados_sistema ] = cidade_para_adicionar.gerenciador_dados_sistema.Pegar_dados();

                        // ---- CRIA SLOT INSTRUCOES
                        gerenciador_save.instrucoes_cidades[ _cidade_id ]  = new byte[ 50 ][];

                        return;

        }


        

        public void Adicionar_cidade( int _plano_para_adicionar_id,  int _cidade_id )  {

                        // --- CRIA cidade
                        
                        int cidade_slot = gerenciador_dados_dinamicos.Pegar_slot_cidade( _cidade_id );

                        System.Object cidade_AI =   gerenciador_dados_dinamicos.Pegar_AI_cidade( cidade_slot );
                        Dados_containers_cidade dados_containers_cidades = gerenciador_dados_dinamicos.Pegar_containers_cidade( cidade_slot );
                        Dados_sistema_cidade_essenciais dados_sistema_cidade_essenciais = dados_sistema_cidades_essenciais[ _cidade_id ];

                        cidade cidade_para_adicionar =  Construtor_cidade.Construir( _cidade_id, _plano_para_adicionar, dados_sistema_cidade_essenciais,  dados_containers_cidades, cidade_AI );

                        // --- COLOCA DADOS CONTAINERS 

                        cidades [ _cidade_id ] = cidade_para_adicionar; 
                        int index_slot_cidade = INT.Acrescentar_valor_COMPLETO_GARANTIDO( ref cidades_ativos , _cidade_id );
                        dados_sistema_cidades[ index_slot_cidade ] = cidade_para_adicionar.gerenciador_dados_sistema.Pegar_dados();

                        // ---- CRIA SLOT INSTRUCOES
                        gerenciador_save.instrucoes_cidades[ _cidade_id ]  = new byte[ 50 ][];

                        return;

        }






		public void Carregar_dados_cidade( int _cidade_id , int _periodos_para_iniciar, int _local_para_colocar ){


			cidade cidade_na_lixeira = gerenciador_save.Retirar_cidade_da_lixeira( _cidade_id );

			if( cidade_na_lixeira != null )
				{
					#if UNITY_EDITOR
						Debug.Log( $"cidade <color=red> { ((cidade_nome ) _cidade_id).ToString()  } </color> foi tirado da lixeira e vai ser colocado em dados dinamicos" );
					#endif
					int slot =  gerenciador_dados_dinamicos.Criar_slot_cidade( _cidade_id );
					gerenciador_dados_dinamicos.cidades_AIs[ slot ] = cidade_na_lixeira.gerenciador_AI_cidade.cidade_AI;
					gerenciador_dados_dinamicos.dados_containers_cidades[ slot ] = cidade_na_lixeira.gerenciador_containers_dados.dados_containers;
				}
				else
				{
					gerenciador_dados_dinamicos.Carregar_dados_cidade_MULTITHREAD( _cidade_id );
				}

			INT.Acrescentar_valor_COMPLETO_GARANTIDO( ref cidades_pentendes_para_adicionar , _cidade_id );
			INT.Acrescentar_valor_COMPLETO_GARANTIDO( ref cidades_pentendes_para_adicionar_local , _local_para_colocar );
			INT.Acrescentar_valor_COMPLETO_GARANTIDO( ref cidades_pentendes_para_adicionar_tempo , _periodos_para_iniciar );

			return;


		}



	




			public void Desativar_cidade( int _personagem_id ){

				// ** tem que fazer os calculos la 

				// MOVE PARA A LIXEIRA

				Personagem personagem = personagens[ _personagem_id ];

				if( personagem == null )
					{ throw new Exception( "nao tinha personagem para excluir" ); }

				


				if ( ! ( INT.Tem_valor_no_array( personagens_ativos, _personagem_id ) ) )
					{ 
						// -- PERSONAGEM NAO ESTAVA ATIVO
						throw new Exception(  $" Foi excluir o personagem <color=red>{ (( Personagem_nome )_personagem_id ).ToString() } </color>"  );
					}

				
				gerenciador_save.Colocar_personagem_na_lixeira( personagem );

				INT.Tirar_valor_COMPLETO_GARANTIDO( ref personagens_ativos , _personagem_id );
				personagens[ _personagem_id ] = null;
				return;


		}













}