




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

                controlador.player_cidade_id = _dados_sistema_estado_atual.cidade_player_id;
                controlador.cidades_adjacentes_cidade_player = _dados_sistema_estado_atual.cidades_adjacentes_cidade_player_ids;
                controlador.cidades_relacionadas_cidade_player = _dados_sistema_estado_atual.cidades_relacionadas_cidade_player_ids;

                controlador.cidade_segundo_plano_foco_id = _dados_sistema_estado_atual.segundo_plano_cidade_foco_id;
                controlador.segundo_plano_cidades_relacionadas_ids = _dados_sistema_estado_atual.segundo_plano_cidades_relacionadas_ids;
                controlador.segundo_plano_cidades_adjacentes_ids = _dados_sistema_estado_atual.segundo_plano_cidades_adjacentes_ids;

               
                for( int index_cidade_ativa = 0 ; index_cidade_ativa < cidades_ativas_planos.Length ; index_cidade_ativa++){

                        // --- PEGAR IDS
                        int plano_id = cidades_ativas_planos[ index_cidade_ativa ];
                        int cidade_id = controlador.cidades_ativas[ index_cidade_ativa ]; 

                        // --- CONSTRUIR
                        Cidade cidade_para_adicionar = Criar_cidade( plano_id, cidade_id );
                        controlador.gerenciador_save.instrucoes_cidades[ cidade_id ]  = new byte[ 50 ][];
                        controlador.cidades [ cidade_id ] = nova_cidade; 
                        controlador.dados_sistema_cidades[ index_cidade_ativa ] = cidade_para_adicionar.gerenciador_dados_sistema.Pegar_dados();

                        continue;

                }
				 
                
                

            instancia = controlador;
            return controlador;


    }





		public void Adicionar_cidade( int _plano_para_adicionar_id,  int _cidade_id )  {

			Cidade cidade_para_adicionar = Criar_cidade(  _plano_para_adicionar_id,  _cidade_id );

			cidades [ _cidade_id ] = cidade_para_adicionar; 
			INT.Acrescentar_valor_COMPLETO_GARANTIDO( ref cidades_ativas , _cidade_id );

			// ---- CRIA SLOT INSTRUCOES
			gerenciador_save.instrucoes_cidades[ _cidade_id ]  = new byte[ 50 ][];

			return;

		}



		public cidade Criar_cidade (  int _plano_para_adicionar_id,  int _cidade_id ){

				// ** quando iniciar vai pegar tudo na main thread 


				// ** para um cidade entrar na cidade do player ele precisa primeiro ser carregado em segundo plano => ele já vai estar carregado 
				// mas essa funcao garante que o cidade vai ser criado e define um plano
				// 
				// nao vai ser chamado com frequencia

	
				int cidade_slot = gerenciador_dados_dinamicos.Pegar_slot_cidade( _cidade_id );

				System.Object cidade_AI =   gerenciador_dados_dinamicos.Pegar_AI_cidade( cidade_slot );
				Dados_containers_cidade dados_containers_cidades = gerenciador_dados_dinamicos.Pegar_containers_cidade( cidade_slot );
				Dados_sistema_cidade_essenciais dados_sistema_cidade_essenciais = dados_sistema_cidades_essenciais[ _cidade_id ];

				cidade nova_cidade =  Construtor_cidade.Construir( _cidade_id, _plano_para_adicionar, dados_sistema_cidade_essenciais,  dados_containers_cidades, cidade_AI );
				
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








}