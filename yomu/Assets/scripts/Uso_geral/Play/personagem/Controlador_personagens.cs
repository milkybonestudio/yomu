using System;
using UnityEngine;





public enum Tipo_requisito_adicionar_personagem {

		periodo,

}









public class Controlador_personagens {

		// Controlador personagens nao tem porque ter conhecimento de como que os dados estao salvos. Ele simeplesmente executa logica e pede dados a um outro sistema.
		  
		// se um personagem precisa ter update mensal ele pede um certo bloco de dados para algum sistema 

		// personagens nao salva nada, ou seja nao tem porque ele saber sobre como vao ficar os container.dat


		public static Controlador_personagens instancia;
		public static Controlador_personagens Pegar_instancia(){ return instancia;}

		public Posicao_geral posicao_geral_player; 

		public Gerenciador_save_personagens gerenciador_save_personagens;


		// personagens que existem atualmente 
		public int[] personagens_primeiro_plano;
		public int[] personagens_segundo_plano;


	
	

		public int[] personagens_pentendes_para_adicionar;
		public int[] personagens_para_criar;


		// tem que atualizar sempre que um personagem for excluido 
		public int[] personagens_que_estao_sendo_descarregados = new int[ 10 ];

		// tem que atualizar sempre que um personagem for carregado
		public int[] personagens_que_estao_sendo_carregado = new int[ 10 ];


		public void Criar_personagem( int _personagem_id ){

				// verificar personagens_que_estao_sendo_carregado ( _personagem_id );



		}
		


		



		public Personagem[] personagens;

		public string path_folder_dados_personagens ;
		public string path_folder_dados_personagens_morte;
		public string path_dados_personagem;
		public Dados_sistema_personagem_essenciais[] dados_sistema_personagens_essencias;



		public static Controlador_personagens Construir (  

															int _save, 
															Dados_sistema_personagem_essenciais[] _dados_sistema_personagens_essenciais ,
															Dados_sistema_cidade_essenciais[] _dados_sistema_cidades_essenciais,  
															Dados_sistema_player _dados_sistema_player, 
															Dados_sistema_estado_atual _dados_sistema_estado_atual ) {




				throw new Exception( "aind anao pode vir aqui porque eu nao defini como pegar os dados do save ainda " );


				Controlador_personagens controlador = new Controlador_personagens();


					// ---- DADOS
					controlador.dados_sistema_personagens_essencias = _dados_sistema_personagens_essenciais;
					controlador.personagens = new Personagem[ _dados_sistema_personagens_essenciais.Length ];

					controlador.gerenciador_save_personagens = new Gerenciador_save_personagens();

					controlador.personagens_para_criar = new int[ 0 ];
				
					
					controlador.personagens_pentendes_para_adicionar = new int[ 0 ];// talvez mudar


					// ---- PATHS
					controlador.path_folder_dados_personagens = Paths_gerais.Pegar_path_folder_dados_save( _save )  ;
					controlador.path_folder_dados_personagens_morte = Paths_gerais.Pegar_path_folder_dados_save( _save ) + "/morte" ;
					controlador.path_dados_personagem = controlador.path_folder_dados_personagens + "/Personagens";


					// --- pegar personagens que estao na mesma cidade que o player 
					// talvez se o player controlar mais persoangens pode mudar aqui

					// ---- PRIMEIRO PLANO

					int personagem_atual_player_id =  _dados_sistema_player.personagem_atual; 

					int cidade_id_player = _dados_sistema_personagens_essenciais[ personagem_atual_player_id ].posicao_atual_personagem.cidade_id;
					int[] personagens_primeiro_plano = _dados_sistema_cidades_essenciais[ cidade_id_player ].personagens_na_cidade ;
					controlador.personagens_primeiro_plano = personagens_primeiro_plano;


					int index_no_plano = 0;


					for( index_no_plano = 0 ; index_no_plano < personagens_primeiro_plano.Length ; index_no_plano++ ){

							int persoangem_id = personagens_primeiro_plano[ index_no_plano ];
							controlador.Construir_personagem( Plano.primeiro, persoangem_id );	

					}



					// ----- SEGUNDO PLANO

					int cidade_segundo_plano_id =  _dados_sistema_estado_atual.segundo_plano_cidade_foco_id;

					int[] personagens_segundo_plano  =  _dados_sistema_cidades_essenciais[ cidade_segundo_plano_id ].personagens_na_cidade ;

					int[] cidades_adjacentes_segundo_plano_id =  _dados_sistema_estado_atual.segundo_plano_cidades_adjacentes_ids;
					int[] cidades_relacionadas_segundo_plano_id =  _dados_sistema_estado_atual.segundo_plano_cidades_relacionadas_ids;


					


					for( index_no_plano = 0 ; index_no_plano < personagens_segundo_plano.Length ; index_no_plano++ ){

							int personagem_id = personagens_segundo_plano[ index_no_plano ];
							controlador.Construir_personagem( Plano.segundo, personagem_id );	

					}
			

					controlador.personagens_segundo_plano = personagens_segundo_plano;




				instancia = controlador;
				return instancia;
			
		}






		public void Construir_personagem(  Plano _plano_para_adicionar,  int _personagem_id ){



				// ** para um personagem entrar na cidade do player ele precisa primeiro ser carregado em segundo plano => ele já vai estar carregado 
				// mas essa funcao garante que o personagem vai ser criado e define um plano
				// 
				// nao vai ser chamado com frequencia


	
				Dados_dinamicos_personagens dados_dinamicos_personagens = Controlador_dados_dinamicos.Pegar_instancia().dados_dinamicos_personagens;

				int personagem_slot = dados_dinamicos_personagens.Pegar_slot_personagem( _personagem_id );

				System.Object personagem_AI =   dados_dinamicos_personagens.Pegar_AI_personagem( personagem_slot );
				Dados_containers_personagem dados_containers_personagens = dados_dinamicos_personagens.Pegar_containers_personagem( personagem_slot );
				Dados_sistema_personagem_essenciais dados_sistema_personagem_essenciais = dados_sistema_personagens_essencias[ _personagem_id ];


				Personagem novo_personagem =  Construtor_personagem.Construir( _personagem_id, _plano_para_adicionar, dados_sistema_personagem_essenciais,  dados_containers_personagens, personagem_AI );
				
				personagens [ _personagem_id ] = novo_personagem; 



				// --- COLOCA PERSONAGEM NO PLANO

				int[] plano = null;

				switch( _plano_para_adicionar ){

					case Plano.primeiro : plano = personagens_primeiro_plano; break;
					case Plano.segundo : plano = personagens_segundo_plano; break;

				}
	

				INT.Acrescentar_valor_COMPLETO_GARANTIDO( ref plano , _personagem_id );


				// ---- CRIA SLOT INSTRUCOES

				gerenciador_save_personagens.instrucoes_personagens[ _personagem_id ]  = new byte[ 50 ][];


	
				return;


		}



		public void Destruir_personagem( int _personagem_id ){


				// personagem tem que existir para poder excluir 

				Personagem personagem = personagens[ _personagem_id ];

				if( personagem == null )
					{ throw new Exception( "nao tinha personagem para excluir" ); }

				Plano plano_personagem = personagem.plano;

				int[] plano = null;

				switch( plano_personagem ){

					case Plano.primeiro : plano = personagens_primeiro_plano; break;
					case Plano.segundo : plano = personagens_segundo_plano; break;

				}

				INT.Tirar_valor_COMPLETO_GARANTIDO( ref plano , _personagem_id );

				//  ** ver oque tem que remover




		}







		// ---- CRIAR PERSONAGENS NORMAIS 



		public void Carregar_dados_personagem( int _personagem_id , int _periodos_para_iniciar ){


			Controlador_dados_dinamicos.Pegar_instancia().dados_dinamicos_personagens.Carregar_dados_personagem_MULTITHREAD( _personagem_id );

			INT.Acrescentar_valor_COMPLETO_GARANTIDO( ref personagens_para_criar , _personagem_id );


		}




		public void Mudar_plano_personagem( Plano _novo_plano_personagem , int _personagem_id ){

				Personagem personagem = personagens[ _personagem_id ] ;

				if( _novo_plano_personagem == personagem.plano )
					{
						Debug.LogError( $"tentou mudar o personagem {  (( Personagem_nome )personagem.personagem_id).ToString() } do plano { personagem.plano.ToString() } para o plano { _novo_plano_personagem.ToString() }" );
						throw new Exception();
					}



				int[] plano_ids = null;

				switch( _novo_plano_personagem ){

					case Plano.primeiro : plano_ids = personagens_primeiro_plano; break;
					case Plano.segundo : plano_ids = personagens_segundo_plano; break;
					// case Plano.terceiro : plano_ids = personagens_terceiro_plano; break;

				}

				for( int index = 0 ; index < plano_ids.Length ; index++ ){

					if ( plano_ids[ index ] == _personagem_id )
						{
							// achou

						}

				}

				// nao achou 


		}










		// aqui todos os personagens exceto a nara vão ser instanciados como null
		public static Controlador_personagens Construir_teste (){

				// precisa cuidadar para quando for por teste. 
				// quando o sitema pedir para carregar um personagem ele nao pode ir para o normal

				Controlador_personagens controlador = new Controlador_personagens();

						// inicia somente com o player ativo
						string[] personagens_nomes = Enum.GetNames( typeof( Personagem_nome ) );
						controlador.dados_sistema_personagens_essencias = new Dados_sistema_personagem_essenciais[ personagens_nomes.Length ];
						Personagem[] personagens = new Personagem[ personagens_nomes.Length ];

						//controlador.personagens_ativos = new int [ 20 ];


						for( int per = 0 ; per < personagens_nomes.Length ; per++ ){ 

								controlador.dados_sistema_personagens_essencias[ per ] = new Dados_sistema_personagem_essenciais();
								
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







		public Personagem Pegar_personagem ( Personagem_nome _personagem_nome ){

			int personagem_id = ( int ) _personagem_nome ;

			
			if( personagens[ personagem_id ] == null  )
					{ 
						Debug.LogError( $"Sistema pediu o personagem { _personagem_nome } mas ele nao foi criado" );

						for( int primeiro_index = 0 ; primeiro_index < personagens_primeiro_plano.Length; primeiro_index++ ){

								if( personagens_primeiro_plano[ primeiro_index ] == personagem_id )
									{ break; }
								if( ( primeiro_index ==  personagens_primeiro_plano.Length - 1 ) )
									{ Debug.LogError( "O personagem também não estava no plano 1" ); }

						}

						for( int segundo_index = 0 ; segundo_index < personagens_segundo_plano.Length; segundo_index++ ){

								if( personagens_segundo_plano[ segundo_index ] == personagem_id )
									{ break; }
								if( ( segundo_index ==  personagens_segundo_plano.Length - 1 ) )
									{ Debug.LogError( "O personagem também não estava no plano 1" ); }

						}

						throw new Exception( "" ); 

					}

			return personagens[ personagem_id ];
		}







  
}








