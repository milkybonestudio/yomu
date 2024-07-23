



public static class Construtor_personagem {


	    public static  Personagem Construir(  int _personagem_id, int _plano_id, Dados_sistema_personagem_essenciais _dados_sistema_personagens_essenciais , Dados_containers_personagem _dados,  System.Object _personagem_AI ){

				// ** responsavel por passar os bytes[] e instanciar os Gerenciadores 
				
				// precisa dos dados completos

				Posicao posicao = new Posicao();


					posicao.regiao_id = _dados_sistema_personagens_essenciais.regiao_id; 
					posicao.trecho_id = _dados_sistema_personagens_essenciais.trecho_id; 
					posicao.cidade_no_trecho_id = _dados_sistema_personagens_essenciais.cidade_no_trecho_id; 

					posicao.zona_id = _dados_sistema_personagens_essenciais.zona_id ; 
					
					posicao.local_id = _dados_sistema_personagens_essenciais.local_id;  
					posicao.area_id =  _dados_sistema_personagens_essenciais.area_id;
					posicao.ponto_id =  _dados_sistema_personagens_essenciais.ponto_id;
					



		
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