



public static class Construtor_personagem {


	    public static  Personagem Construir(  int _personagem_id, int _plano_id, Dados_sistema_personagem_essenciais _dados_sistema_personagens_essenciais , Dados_containers_personagem _dados,  System.Object _personagem_AI ){

				// ** responsavel por passar os bytes[] e instanciar os Gerenciadores 
				
				// precisa dos dados completos

				Posicao_geral posicao_geral = new Posicao_geral();


					posicao_geral.posicao_local.ponto = ( int ) _dados_sistema_personagens_essenciais.ponto;
					posicao_geral.posicao_local.regiao = ( int ) _dados_sistema_personagens_essenciais.regiao;
					posicao_geral.posicao_local.area = ( int ) _dados_sistema_personagens_essenciais.area;
					posicao_geral.posicao_local.cidade = ( int ) _dados_sistema_personagens_essenciais.posicao_cidade_id;


					posicao_geral.posicao_mundial.cidade = ( int ) _dados_sistema_personagens_essenciais.posicao_cidade_id;
					posicao_geral.posicao_mundial.estado = ( int ) _dados_sistema_personagens_essenciais.estado;
					posicao_geral.posicao_mundial.reino = ( int ) _dados_sistema_personagens_essenciais.reino;
					posicao_geral.posicao_mundial.continente = ( int ) _dados_sistema_personagens_essenciais.continente;

		
				int atividade_id = _dados_sistema_personagens_essenciais.atividade_atual_id;
				Personagem personagem = new Personagem( _personagem_id , posicao_geral, atividade_id );

				//** usar plano quando for criar os updates



				personagem.gerenciador_estado_mental = Gerenciador_estado_mental_construtor.Construir( personagem,  _dados.dados_gerenciador_estado_mental );


				return personagem;

		}

		public static Personagem Construir_personagem_teste( int _personagem_id, Atividade _atividade, Posicao_geral _posicao_geral, Dados_containers_personagem _dados ){

				// a unica diferená é que aqui se vier null ele só constroi o objeto sem dados;


				Personagem personagem = new Personagem( _personagem_id , _posicao_geral,  ( int ) _atividade    );

				if ( _dados.dados_gerenciador_estado_mental != null )

						{ personagem.gerenciador_estado_mental = Gerenciador_estado_mental_construtor.Construir( personagem,  _dados.dados_gerenciador_estado_mental );}
						
						else 
						
						{ personagem.gerenciador_estado_mental = new Gerenciador_estado_mental( personagem );}


				
		


				return personagem;

		}

	




}