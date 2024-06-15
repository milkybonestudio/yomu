using System;

public class Controlador_cidades {

	//** !! controlador_entidade nao se comunica com outros controladores entidades. Ele tem ferramentas para fazer a interacao fn( entidade_1, entidade_2 ) 

    public static Controlador_cidades instancia;
    public static Controlador_cidades Pegar_instancia(){ return instancia; }


    public Gerenciador_dados_dinamicos_cidades gerenciador_dados_dinamicos;
    public Gerenciador_save_cidades gerenciador_save;

    public Dados_sistema_cidade_essenciais[] dados_sistema_cidades_essenciais;
    public Dados_sistema_cidade[] dados_sistema_cidades;

    public Cidade[] cidades;

    // ** talvez elas se cruzem cruzem 
    public int player_cidade_id; // sempre primeiro plano
    public int cidade_segundo_plano_foco_id; // sempre segundo_plano


	public int[] cidades_segundo_plano_ativas; // sempre segundo_plano // adjacentes podem ser gograficas ou de importancia


    // public int[] cidades_adjacentes_cidade_player;
    // public int[] cidades_relacionadas_cidade_player;
    // public int[] segundo_plano_cidades_adjacentes_ids;
    // public int[] segundo_plano_cidades_relacionadas_ids;



    public static Controlador_cidades Construir( Dados_sistema_cidade_essenciais[] _dados_sistema_cidades_essenciais , Dados_sistema_estado_atual _dados_sistema_estado_atual ) {


            Controlador_cidades controlador = new Controlador_cidades();

					controlador.gerenciador_save = new Gerenciador_save_cidades( controlador );
					controlador.gerenciador_dados_dinamicos = new Gerenciador_dados_dinamicos_cidades();

					controlador.dados_sistema_cidades_essenciais = _dados_sistema_cidades_essenciais;
					controlador.cidades = new Cidade[ _dados_sistema_cidades_essenciais.Length ];

					controlador.player_cidade_id = _dados_sistema_estado_atual.cidade_player_id;
					//controlador.cidades_adjacentes_cidade_player = _dados_sistema_estado_atual.cidades_adjacentes_cidade_player_ids;
				
					//controlador.cidades_relacionadas_cidade_player = _dados_sistema_estado_atual.cidades_relacionadas_cidade_player_ids;

					controlador.cidade_segundo_plano_foco_id = _dados_sistema_estado_atual.segundo_plano_cidade_foco_id;
					// controlador.segundo_plano_cidades_relacionadas_ids = _dados_sistema_estado_atual.segundo_plano_cidades_relacionadas_ids;
					// controlador.segundo_plano_cidades_adjacentes_ids = _dados_sistema_estado_atual.segundo_plano_cidades_adjacentes_ids;

					controlador.cidades_segundo_plano_ativas = _dados_sistema_estado_atual.cidades_segundo_plano_ativas;
					
					controlador.Adicionar_cidade_INICIO_JOGO( ( int ) Plano.primeiro, controlador.player_cidade_id , 0 );
					controlador.Adicionar_cidade_INICIO_JOGO( ( int ) Plano.segundo, controlador.cidade_segundo_plano_foco_id , 1 );
					int index_inicial = 2;

					for( int cidade_ativa_index = ( 0 + index_inicial ) ; cidade_ativa_index < controlador.cidades_segundo_plano_ativas.Length ; cidade_ativa_index++ ){

								// --- todas segundo plano 
								// --- PEGAR ID
								int cidade_id = controlador.cidades_segundo_plano_ativas[ cidade_ativa_index ]; 

								// --- CONSTRUIR
								controlador.Adicionar_cidade_INICIO_JOGO( ( int ) Plano.segundo, cidade_id , cidade_ativa_index );
							
								continue;

					}

				
					
            instancia = controlador;
            return controlador;

		}





        public void Adicionar_cidade_INICIO_JOGO( int _plano_para_adicionar_id,  int _cidade_id, int _index_dados_sistema ){

                        // --- CRIA cidade 
                        Dados_sistema_cidade_essenciais dados_sistema_cidade_essenciais = dados_sistema_cidades_essenciais[ _cidade_id ];
                        System.Object cidade_AI =   gerenciador_dados_dinamicos.Pegar_AI_cidade_NAO_CARREGADO( _cidade_id );
                        Dados_containers_cidade dados_containers_cidades = gerenciador_dados_dinamicos.Pegar_containers_cidade_NAO_CARREGADO( _cidade_id );

                        Cidade cidade_para_adicionar =  Construtor_cidade.Construir( _cidade_id, _plano_para_adicionar_id, dados_sistema_cidade_essenciais,  dados_containers_cidades, cidade_AI );

                        // --- COLOCA DADOS CONTAINERS 
                        cidades [ _cidade_id ] = cidade_para_adicionar; 
                        dados_sistema_cidades[ _index_dados_sistema ] = cidade_para_adicionar.gerenciador_dados_sistema.Pegar_dados();

                        // ---- CRIA SLOT INSTRUCOES
                        gerenciador_save.instrucoes_cidades[ _cidade_id ]  = new byte[ 50 ][];

                        return;

        }




		
		
        

        public void Adicionar_cidade( int _plano_para_adicionar_id,  int _cidade_id )  {

					// sempre adiciona uma cidade como segundo plano?
					// nao, o player pode fazer uma viagem longa que pula cidades 

					// se primeiro plano => 

					// --- CRIA cidade
					
					int cidade_slot = gerenciador_dados_dinamicos.Pegar_slot_cidade( _cidade_id );

					System.Object cidade_AI =   gerenciador_dados_dinamicos.Pegar_AI_cidade( cidade_slot );
					Dados_containers_cidade dados_containers_cidades = gerenciador_dados_dinamicos.Pegar_containers_cidade( cidade_slot );
					Dados_sistema_cidade_essenciais dados_sistema_cidade_essenciais = dados_sistema_cidades_essenciais[ _cidade_id ];

					Cidade cidade_para_adicionar =  Construtor_cidade.Construir( _cidade_id, _plano_para_adicionar_id, dados_sistema_cidade_essenciais,  dados_containers_cidades, cidade_AI );

					// --- COLOCA DADOS CONTAINERS 

					cidades [ _cidade_id ] = cidade_para_adicionar; 
					int index_slot_cidade = INT.Acrescentar_valor_COMPLETO_GARANTIDO( ref cidades_segundo_plano_ativas , _cidade_id );
					dados_sistema_cidades[ index_slot_cidade ] = cidade_para_adicionar.gerenciador_dados_sistema.Pegar_dados();

					// ---- CRIA SLOT INSTRUCOES
					gerenciador_save.instrucoes_cidades[ _cidade_id ]  = new byte[ 50 ][];

					return;

        }






		public void Carregar_dados_cidade( int _cidade_id , int _periodos_para_iniciar  ){

			

			Cidade cidade_na_lixeira = gerenciador_save.Retirar_cidade_da_lixeira( _cidade_id );

			if( cidade_na_lixeira != null )
				{
					#if UNITY_EDITOR
						Console.Log( $"cidade <color=red> { (( Cidade_nome ) _cidade_id ).ToString()  } </color> foi tirado da lixeira e vai ser colocado em dados dinamicos" );
					#endif
					int slot =  gerenciador_dados_dinamicos.Criar_slot_cidade( _cidade_id );
					gerenciador_dados_dinamicos.cidades_AIs[ slot ] = cidade_na_lixeira.gerenciador_AI.cidade_AI;
					gerenciador_dados_dinamicos.dados_containers_cidades[ slot ] = cidade_na_lixeira.gerenciador_containers_dados.dados_containers;
				}
				else
				{
					gerenciador_dados_dinamicos.Carregar_dados_cidade_MULTITHREAD( _cidade_id );
				}

			// agora vai ser feito no Controlador_sistema

			// INT.Acrescentar_valor_COMPLETO_GARANTIDO( ref cidades_segundo_plano_pentendes_para_adicionar , _cidade_id );
			// INT.Acrescentar_valor_COMPLETO_GARANTIDO( ref cidades_segundo_plano_pentendes_para_adicionar_tempo , _periodos_para_iniciar );

			return;


		}



	




			public void Desativar_cidade( int _personagem_id ){

				// ** tem que fazer os calculos la 

				// MOVE PARA A LIXEIRA

				// ** PENSAR DEPOIS

				// Personagem personagem = personagens[ _personagem_id ];

				// if( personagem == null )
				// 	{ throw new Exception( "nao tinha personagem para excluir" ); }

				


				// if ( ! ( INT.Tem_valor_no_array( cidade_ativas, _personagem_id ) ) )
				// 	{ 
				// 		// -- PERSONAGEM NAO ESTAVA ATIVO
				// 		throw new Exception(  $" Foi excluir o personagem <color=red>{ (( Personagem_nome )_personagem_id ).ToString() } </color>"  );
				// 	}

				
				// gerenciador_save.Colocar_personagem_na_lixeira( personagem );

				// INT.Tirar_valor_COMPLETO_GARANTIDO( ref personagens_ativos , _personagem_id );
				// personagens[ _personagem_id ] = null;
				// return;


		}













}