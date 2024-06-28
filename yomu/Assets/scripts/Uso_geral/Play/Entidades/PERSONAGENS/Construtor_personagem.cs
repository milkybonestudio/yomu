



public static class Construtor_personagem {


	    public static  Personagem Construir(  int _personagem_id, int _plano_id, Dados_sistema_personagem_essenciais _dados_sistema_personagens_essenciais , Dados_containers_personagem _dados,  System.Object _personagem_AI ){

				// ** responsavel por passar os bytes[] e instanciar os Gerenciadores 
				
				// precisa dos dados completos

				Posicao posicao = new Posicao();


					posicao.posicao_local.ponto_id = ( int ) _dados_sistema_personagens_essenciais.ponto_id;
					posicao.posicao_local.regiao_id = ( int ) _dados_sistema_personagens_essenciais.regiao_id;
					posicao.posicao_local.area_id = ( int ) _dados_sistema_personagens_essenciais.area_id;
					posicao.posicao_local.cidade_id = ( int ) _dados_sistema_personagens_essenciais.posicao_cidade_id;


					posicao.posicao_mundial.cidade_id = ( int ) _dados_sistema_personagens_essenciais.posicao_cidade_id;
					posicao.posicao_mundial.estado_id = ( int ) _dados_sistema_personagens_essenciais.estado_id;
					posicao.posicao_mundial.reino_id = ( int ) _dados_sistema_personagens_essenciais.reino_id;
					posicao.posicao_mundial.continente_id = ( int ) _dados_sistema_personagens_essenciais.continente_id;

		
				int atividade_id = _dados_sistema_personagens_essenciais.atividade_atual_id;
				Personagem personagem = new Personagem( _personagem_id , posicao, atividade_id );

				//** usar plano quando for criar os updates



				personagem.gerenciador_estado_mental = Gerenciador_estado_mental_construtor.Construir( personagem,  _dados.dados_gerenciador_estado_mental );


				return personagem;

		}

		public static Personagem Construir_personagem_teste( int _personagem_id, Atividade _atividade, Posicao _posicao, Dados_containers_personagem _dados ){

				// a unica diferená é que aqui se vier null ele só constroi o objeto sem dados;


				Personagem personagem = new Personagem( _personagem_id , _posicao,  ( int ) _atividade    );

				if ( _dados.dados_gerenciador_estado_mental != null )

						{ personagem.gerenciador_estado_mental = Gerenciador_estado_mental_construtor.Construir( personagem,  _dados.dados_gerenciador_estado_mental );}
						
						else 
						
						{ personagem.gerenciador_estado_mental = new Gerenciador_estado_mental( personagem );}


				
		


				return personagem;

		}

	




}