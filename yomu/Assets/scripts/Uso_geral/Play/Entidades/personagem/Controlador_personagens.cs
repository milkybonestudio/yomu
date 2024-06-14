using System;
using UnityEngine;







public class Controlador_personagens {

		// ** REQUISICAO PARA ADICIONAR PERSONAGEM É SOMENTE TEMPO

		// Controlador personagens nao tem porque ter conhecimento de como que os dados estao salvos. Ele simeplesmente executa logica e pede dados a um outro sistema.
		  
		// se um personagem precisa ter update mensal ele pede um certo bloco de dados para algum sistema 

		// personagens nao salva nada, ou seja nao tem porque ele saber sobre como vao ficar os container.dat


		public static Controlador_personagens instancia;
		public static Controlador_personagens Pegar_instancia(){ return instancia;}


		public Gerenciador_save_personagens gerenciador_save;
		public Gerenciador_dados_dinamicos_personagens gerenciador_dados_dinamicos;

		public Personagem[] personagens;
		public Dados_sistema_personagem_essenciais[] dados_sistema_personagens_essenciais;
	
		// ** somente dos personagens ativos + margem
		public Dados_sistema_personagem[] dados_sistema_personagens;


		// ** lembrar que quando mudar de plano 1 para 2 tem que criar uma instrucao
		public int[] personagens_ativos_ids = new int[ 0 ]; // tanto primario quanto secundario 
		


		// primeiro => personagem tem controle ativo 
		// segundo personagem tem controle passivo

		// controlador sistema que precisa ter refs, nao os controladores normais 
	

		public int[] personagens_pentendes_para_adicionar;
		public int[] personagens_pentendes_para_adicionar_local;
		public int[] personagens_pentendes_para_adicionar_tempo;
		// talvez adicionar scripts_entrada[] ?
		

		


		public static Controlador_personagens Construir (  Dados_sistema_personagem_essenciais[] _dados_sistema_personagens_essenciais, Dados_sistema_estado_atual _dados_sistema_estado_atual ) {

				throw new Exception( "aind anao pode vir aqui porque eu nao defini como pegar os dados do save ainda " );


				Controlador_personagens controlador = new Controlador_personagens();


					// ---- DADOS
					controlador.dados_sistema_personagens_essenciais = _dados_sistema_personagens_essenciais;
					controlador.personagens = new Personagem[ _dados_sistema_personagens_essenciais.Length ];
					controlador.gerenciador_save = new Gerenciador_save_personagens( controlador );
					controlador.gerenciador_dados_dinamicos = new Gerenciador_dados_dinamicos_personagens();

					controlador.personagens_pentendes_para_adicionar =  _dados_sistema_estado_atual.personagens_pentendes_para_adicionar;
					controlador.personagens_pentendes_para_adicionar_local =  _dados_sistema_estado_atual.personagens_pentendes_para_adicionar_local;
					controlador.personagens_pentendes_para_adicionar_tempo = _dados_sistema_estado_atual.personagens_pentendes_para_adicionar_tempo;

					controlador.personagens_ativos_ids = _dados_sistema_estado_atual.personagens_ativos_ids ;
					int[] personagens_ativos_planos = _dados_sistema_estado_atual.personagens_ativos_planos ;

					controlador.dados_sistema_personagens = new Dados_sistema_personagem[ controlador.personagens_ativos.Length ];


					for( int index_personagem_ativo = 0 ; index_personagem_ativo < personagens_ativos_planos.Length ; index_personagem_ativo++){

							// --- PEGAR IDS
							int plano_id = personagens_ativos_planos[ index_personagem_ativo ];
							int personagem_id = controlador.personagens_ativos[ index_personagem_ativo ]; 

							// --- CONSTRUIR
							Personagem personagem_para_adicionar = Criar_personagem( plano_id, personagem_id );
							controlador.gerenciador_save.instrucoes_personagens[ personagem_id ]  = new byte[ 50 ][];
							controlador.personagens [ personagem_id ] = novo_personagem; 
							controlador.dados_sistema_personagens[ index_personagem_ativo ] = personagem_para_adicionar.gerenciador_dados_sistema.Pegar_dados();

							continue;

					}
				
				

				instancia = controlador;
				return instancia;
			
		}


		public void Adicionar_personagem( int _plano_para_adicionar_id,  int _personagem_id )  {

			Personagem personagem_para_adicionar = Criar_personagem(  _plano_para_adicionar_id,  _personagem_id );

			personagens [ _personagem_id ] = personagem_para_adicionar; 
			INT.Acrescentar_valor_COMPLETO_GARANTIDO( ref personagens_ativos , _personagem_id );

			// ---- CRIA SLOT INSTRUCOES
			gerenciador_save.instrucoes_personagens[ _personagem_id ]  = new byte[ 50 ][];

			return;

		}



		public Personagem Criar_personagem (  int _plano_para_adicionar_id,  int _personagem_id ){

				// ** quando iniciar vai pegar tudo na main thread 


				// ** para um personagem entrar na cidade do player ele precisa primeiro ser carregado em segundo plano => ele já vai estar carregado 
				// mas essa funcao garante que o personagem vai ser criado e define um plano
				// 
				// nao vai ser chamado com frequencia

	
				int personagem_slot = gerenciador_dados_dinamicos.Pegar_slot_personagem( _personagem_id );

				System.Object personagem_AI =   gerenciador_dados_dinamicos.Pegar_AI_personagem( personagem_slot );
				Dados_containers_personagem dados_containers_personagens = gerenciador_dados_dinamicos.Pegar_containers_personagem( personagem_slot );
				Dados_sistema_personagem_essenciais dados_sistema_personagem_essenciais = dados_sistema_personagens_essenciais[ _personagem_id ];

				Personagem novo_personagem =  Construtor_personagem.Construir( _personagem_id, _plano_para_adicionar, dados_sistema_personagem_essenciais,  dados_containers_personagens, personagem_AI );
				
				return;


		}




		public void Carregar_dados_personagem( int _personagem_id , int _periodos_para_iniciar, int _local_para_colocar ){


			Personagem personagem_na_lixeira = gerenciador_save.Retirar_personagem_da_lixeira( _personagem_id );

			if( personagem_na_lixeira != null )
				{
					#if UNITY_EDITOR
						Debug.Log( $"Personagem <color=red> { ((Personagem_nome ) _personagem_id).ToString()  } </color> foi tirado da lixeira e vai ser colocado em dados dinamicos" );
					#endif
					int slot =  gerenciador_dados_dinamicos.Criar_slot_personagem( _personagem_id );
					gerenciador_dados_dinamicos.personagens_AIs[ slot ] = personagem_na_lixeira.gerenciador_AI_personagem.personagem_AI;
					gerenciador_dados_dinamicos.dados_containers_personagens[ slot ] = personagem_na_lixeira.gerenciador_containers_dados.dados_containers;
				}
				else
				{
					gerenciador_dados_dinamicos.Carregar_dados_personagem_MULTITHREAD( _personagem_id );
				}

			INT.Acrescentar_valor_COMPLETO_GARANTIDO( ref personagens_pentendes_para_adicionar , _personagem_id );
			INT.Acrescentar_valor_COMPLETO_GARANTIDO( ref personagens_pentendes_para_adicionar_local , _local_para_colocar );
			INT.Acrescentar_valor_COMPLETO_GARANTIDO( ref personagens_pentendes_para_adicionar_tempo , _periodos_para_iniciar );

			return;


		}






		public void Desativar_personagem( int _personagem_id ){

				// ** tem que fazer uma instrucao falando que o personagem foi excluido. 
				// se o sistema precisar reconstuir ele altera os dados mas não coloca ele nos ativos 


				// MOVO PARA A LIXEIRA

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








		public void Mudar_plano_personagem( Plano _novo_plano_personagem , int _personagem_id ){

				Personagem personagem = personagens[ _personagem_id ] ;

				if( personagem == null)
					{ throw new Exception( $"tentou mudar o plano do personagem { (( Personagem_nome )personagem.personagem_id).ToString() } mas ele nao esta iniciado"); }

				if( _novo_plano_personagem == personagem.plano )
					{
						Debug.LogError( $"tentou mudar o personagem {  (( Personagem_nome )personagem.personagem_id).ToString() } do plano { personagem.plano.ToString() } para o plano { _novo_plano_personagem.ToString() }" );
						throw new Exception();
					}


				// ** ver oque precisa depois 
				// precisa talvez instanciar os updates
				
				personagem.plano = _novo_plano_personagem;
				return;

			

		}










		// aqui todos os personagens exceto a nara vão ser instanciados como null
		public static Controlador_personagens Construir_teste (){

				// precisa cuidadar para quando for por teste. 
				// quando o sitema pedir para carregar um personagem ele nao pode ir para o normal

				Controlador_personagens controlador = new Controlador_personagens();

						// inicia somente com o player ativo
						string[] personagens_nomes = Enum.GetNames( typeof( Personagem_nome ) );
						controlador.dados_sistema_personagens_essenciais = new Dados_sistema_personagem_essenciais[ personagens_nomes.Length ];
						Personagem[] personagens = new Personagem[ personagens_nomes.Length ];

						//controlador.personagens_ativos = new int [ 20 ];


						for( int per = 0 ; per < personagens_nomes.Length ; per++ ){ 

								controlador.dados_sistema_personagens_essenciais[ per ] = new Dados_sistema_personagem_essenciais();
								
						}

						int nara_id = ( int ) Personagem_nome.Nara;
						
					
						controlador.personagens = personagens;
						personagens[ nara_id ] = new Personagem( nara_id, new Posicao_geral(), Atividade.nada );


				instancia = controlador;				
				return instancia;
			
		}


		public void Carregar_personagem_teste ( Personagem_nome personagem_nome, Atividade _atividade, Posicao_geral _posicao  , Dados_containers_personagem _dados_para_construir_personagem ){

				Debug.Log( "vai carregar personagem : " + personagem_nome );

				Personagem novo_personagem = Construtor_personagem.Construir_personagem_teste(  ( int ) personagem_nome,  _atividade, _posicao, _dados_para_construir_personagem );				
				personagens[ ( int ) personagem_nome ] = novo_personagem; 
				return;

		}







		public Personagem Pegar_personagem ( int _personagem_id ){

			
			if( personagens[ _personagem_id ] == null  )
					{ 
						Personagem_nome personagem = ( Personagem_nome ) _personagem_id;
						Debug.LogError( $"Sistema pediu o personagem { personagem } mas ele nao foi criado" );
						throw new Exception( "" );
					}

			return personagens[ _personagem_id ];

		}







  
}








