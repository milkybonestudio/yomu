using System;
using UnityEngine;





public class Controlador_personagens {

		// ** REQUISICAO PARA ADICIONAR PERSONAGEM É SOMENTE TEMPO

		// Controlador personagens nao tem porque ter conhecimento de como que os dados estao salvos. Ele simeplesmente executa logica e pede dados a um outro sistema.
		// se um personagem precisa ter update mensal ele pede um certo bloco de dados para algum sistema 
		// personagens nao salva nada, ou seja nao tem porque ele saber sobre como vao ficar os container.dat


		public static Controlador_personagens instancia;
		public static Controlador_personagens Pegar_instancia(){ return instancia;}

		// --- USAO INTERNO
		public Gerenciador_save_personagens gerenciador_save ;

		public Gerenciador_containers_dinamicos_completos gerenciador_containers_dinamicos_completos ;
		public Gerenciador_objetos_dll_dinamicos gerenciador_objetos_dll_dinamicos ;

		// --- MODIFICADORES

		public Modificador_personagem_conversa modificador_personagem_conversa ;


		public Personagem[] personagens;
		public Dados_sistema_personagem_essenciais[] dados_sistema_personagens_essenciais;
		public Dados_sistema_personagem[] dados_sistema_personagens; 		// ** somente dos personagens ativos + margem


		// ** lembrar que quando mudar de plano 1 para 2 tem que criar uma instrucao
		public int[] personagens_ativos_ids = new int[ 0 ]; // tanto primario quanto secundario 
		

		// primeiro => personagem tem controle ativo 
		// segundo personagem tem controle passivo
		// controlador sistema que precisa ter refs, nao os controladores normais 
	

		// talvez adicionar scripts_entrada[] ?
		

		

		public static Controlador_personagens Construir (  Dados_sistema_personagem_essenciais[] _dados_sistema_personagens_essenciais, Dados_sistema_estado_atual _dados_sistema_estado_atual ) {


				throw new Exception( "aind anao pode vir aqui porque eu nao defini como pegar os dados do save ainda " );

				Controlador_personagens controlador = new Controlador_personagens();


					// ---- DADOS
					
					controlador.gerenciador_save = new Gerenciador_save_personagens( controlador );
					controlador.gerenciador_containers_dinamicos_completos = new Gerenciador_containers_dinamicos_completos( _folder_para_pegar_dados: Paths_sistema.path_dados_save_personagens, _numero_inicial_de_slots: 50 );

					controlador.dados_sistema_personagens_essenciais = _dados_sistema_personagens_essenciais;
					controlador.personagens = new Personagem[ _dados_sistema_personagens_essenciais.Length ];

					controlador.modificador_personagem_conversa = new Modificador_personagem_conversa();



					controlador.personagens_ativos_ids = _dados_sistema_estado_atual.personagens_ativos_ids ;
					int[] personagens_ativos_planos_ids = _dados_sistema_estado_atual.personagens_ativos_planos_ids ;

					controlador.dados_sistema_personagens = new Dados_sistema_personagem[ controlador.personagens_ativos_ids.Length ];


					for( int index_personagem_ativo = 0 ; index_personagem_ativo < personagens_ativos_planos_ids.Length ; index_personagem_ativo++){

							// --- PEGAR IDS
							int plano_id = personagens_ativos_planos_ids[ index_personagem_ativo ];
							int personagem_id = controlador.personagens_ativos_ids[ index_personagem_ativo ]; 

							controlador.Adicionar_personagem_INICIO_JOGO( plano_id , personagem_id, index_personagem_ativo );
							continue;

					}
				
				

				instancia = controlador;
				return instancia;
			
		}


		public void Adicionar_personagem_INICIO_JOGO( int _plano_para_adicionar_id,  int _personagem_id, int _index_dados_sistema ){

				// --- CRIA PERSONAGEM 
				Dados_sistema_personagem_essenciais dados_sistema_personagem_essenciais = dados_sistema_personagens_essenciais[ _personagem_id ];

				// --- PEGA AI
				string personagem_nome = ( ( Personagem_nome ) _personagem_id).ToString();
				string nome_objeto_classe = $"{personagem_nome}_classe" ;
				gerenciador_objetos_dll_dinamicos.Carregar_objeto_NA_MULTITHREAD( _personagem_id, nome_objeto_classe );
				System.Object personagem_AI = gerenciador_objetos_dll_dinamicos.Pegar_objeto( _personagem_id );

				// --- PEGAR CONTAINER

				string path_personagem_dados = $"PERSONAGEM_{ personagem_nome }_dados.dat";
				gerenciador_containers_dinamicos_completos.Carregar_container_NA_MULTITHREAD( _personagem_id, path_personagem_dados );
				byte[] dados_container_personagem_byte =  gerenciador_containers_dinamicos_completos.Pegar_container( _personagem_id );
				Dados_containers_personagem dados_containers_personagens = Construtor_containers_personagens.Construir( dados_container_personagem_byte );

				Personagem personagem_para_adicionar =  Construtor_personagem.Construir( _personagem_id,  _plano_para_adicionar_id, dados_sistema_personagem_essenciais,  dados_containers_personagens, personagem_AI );

				// --- COLOCA DADOS CONTAINERS 
				personagens [ _personagem_id ] = personagem_para_adicionar; 
				dados_sistema_personagens[ _index_dados_sistema ] = personagem_para_adicionar.gerenciador_dados_sistema.Pegar_dados();

				// ---- CRIA SLOT INSTRUCOES
				gerenciador_save.instrucoes_personagens[ _personagem_id ]  = new byte[ 50 ][];

				return;

		}


		

		public void Adicionar_personagem( int _plano_para_adicionar_id,  int _personagem_id )  {

				// --- CRIA PERSONAGEM
				
				System.Object personagem_AI =   gerenciador_objetos_dll_dinamicos.Pegar_objeto( _personagem_id );
				byte[] container_byte = gerenciador_containers_dinamicos_completos.Pegar_container( _personagem_id );
				Dados_containers_personagem dados_containers_personagens = Construtor_containers_personagens.Construir( container_byte );

				Dados_sistema_personagem_essenciais dados_sistema_personagem_essenciais = dados_sistema_personagens_essenciais[ _personagem_id ];

				Personagem personagem_para_adicionar =  Construtor_personagem.Construir( _personagem_id, _plano_para_adicionar_id, dados_sistema_personagem_essenciais,  dados_containers_personagens, personagem_AI );

				// --- COLOCA DADOS CONTAINERS 

				personagens [ _personagem_id ] = personagem_para_adicionar; 
				int index_slot_personagem = INT.Acrescentar_valor_COMPLETO_GARANTIDO( ref personagens_ativos_ids , _personagem_id );
				dados_sistema_personagens[ index_slot_personagem ] = personagem_para_adicionar.gerenciador_dados_sistema.Pegar_dados();

				// ---- CRIA SLOT INSTRUCOES
				gerenciador_save.instrucoes_personagens[ _personagem_id ]  = new byte[ 50 ][];

				return;

		}




		public void Carregar_dados_personagem( int _personagem_id , int _periodos_para_iniciar, int _local_para_colocar ){


			Personagem personagem_na_lixeira = gerenciador_save.Retirar_personagem_da_lixeira( _personagem_id );

			if( personagem_na_lixeira != null )
				{
						#if UNITY_EDITOR
							Console.Log( $"Personagem <color=red> { ((Personagem_nome ) _personagem_id).ToString()  } </color> foi tirado da lixeira e vai ser colocado em dados dinamicos" );
						#endif

						int slot_objeto = gerenciador_objetos_dll_dinamicos.Criar_slot( _personagem_id );
						gerenciador_objetos_dll_dinamicos.objetos[ slot_objeto ] = personagem_na_lixeira.gerenciador_AI.personagem_AI;

						int slot_container = gerenciador_containers_dinamicos_completos.Criar_slot( _personagem_id );
						gerenciador_containers_dinamicos_completos.dados_containers[ slot_container ] = personagem_na_lixeira.gerenciador_containers_dados.Compilar_dados();
		
		
				}
				else
				{
						Dados_sistema_personagem_essenciais dados_sistema_personagem_essenciais = dados_sistema_personagens_essenciais[ _personagem_id ];

						string nome_personagem = ( ( Personagem_nome ) _personagem_id ).ToString();

						// --- CARREGAR AI
						string nome_objeto_classe = $"PERSONAGEM_{ nome_personagem }_classe";
						gerenciador_objetos_dll_dinamicos.Carregar_objeto_NA_MULTITHREAD( _personagem_id, nome_objeto_classe );
						

						// --- PEGAR CONTAINER
						string path_container = $"PERSONAGEM_{ nome_personagem }_dados.dat";
						gerenciador_containers_dinamicos_completos.Carregar_container_NA_MULTITHREAD( _personagem_id, path_container );

						return;
								
				}


			// Agora vai fazer parte do Controlador_sistema

			// INT.Acrescentar_valor_COMPLETO_GARANTIDO( ref personagens_pentendes_para_adicionar , _personagem_id );
			// INT.Acrescentar_valor_COMPLETO_GARANTIDO( ref personagens_pentendes_para_adicionar_local , _local_para_colocar );
			// INT.Acrescentar_valor_COMPLETO_GARANTIDO( ref personagens_pentendes_para_adicionar_tempo , _periodos_para_iniciar );

			return;


		}









		public void Desativar_personagem( int _personagem_id ){

				// ** tem que fazer uma instrucao falando que o personagem foi excluido. 
				// se o sistema precisar reconstuir ele altera os dados mas não coloca ele nos ativos 
				// **se ele nao tiver sido construido tem que retirar a task para pegar os dados dos dados dinamicos


				// MOVE PARA A LIXEIRA

				Personagem personagem = personagens[ _personagem_id ];

				if( personagem == null )
					{ throw new Exception( "nao tinha personagem para excluir" ); }

				


				if ( ! ( INT.Tem_valor_no_array( personagens_ativos_ids, _personagem_id ) ) )
					{ 
						// -- PERSONAGEM NAO ESTAVA ATIVO
						throw new Exception(  $" Foi excluir o personagem <color=red>{ (( Personagem_nome )_personagem_id ).ToString() } </color>"  );
					}

				
				gerenciador_save.Colocar_personagem_na_lixeira( personagem );

				INT.Tirar_valor_COMPLETO_GARANTIDO( ref personagens_ativos_ids , _personagem_id );
				personagens[ _personagem_id ] = null;
				return;


		}








		public void Mudar_plano_personagem( int _novo_plano_personagem_id , int _personagem_id ){

				Personagem personagem = personagens[ _personagem_id ] ;

				if( personagem == null)
					{ throw new Exception( $"tentou mudar o plano do personagem { (( Personagem_nome )personagem.personagem_id).ToString() } mas ele nao esta iniciado"); }

				if( _novo_plano_personagem_id == personagem.plano_id )
					{
						Console.LogError( $"tentou mudar o personagem {  (( Personagem_nome )personagem.personagem_id).ToString() } do plano { ( ( Plano ) personagem.plano_id).ToString() } para o plano { ( ( Plano ) _novo_plano_personagem_id).ToString() }" );
						throw new Exception();
					}


				// ** ver oque precisa depois 
				// precisa talvez instanciar os updates
				
				personagem.plano_id = _novo_plano_personagem_id;
				return;

			

		}


		public Personagem Pegar_personagem ( int _personagem_id ){

			
			if( personagens[ _personagem_id ] == null  )
					{ 
						Personagem_nome personagem = ( Personagem_nome ) _personagem_id;
						Console.LogError( $"Sistema pediu o personagem { personagem } mas ele nao foi criado" );
						throw new Exception( "" );
					}

			return personagens[ _personagem_id ];

		}



  
}



