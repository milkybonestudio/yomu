




public static class Construtor_cidade {


	    public static Cidade Construir(  int _cidade_id,  int _plano_id, Dados_sistema_cidade_essenciais _dados_sistema_cidades_essenciais , Dados_containers_cidade _dados,  System.Object _cidade_AI ){

				// ** responsavel por passar os bytes[] e instanciar os Gerenciadores 
				
				
				Cidade cidade = new Cidade( _cidade_id );

				//** usar plano quando for criar os updates


				// cidade.gerenciador_estado_mental = Gerenciador_estado_mental_construtor.Construir( cidade,  _dados.dados_gerenciador_estado_mental );


				return cidade;

		}

		public static Cidade Construir_cidade_teste( int _cidade_id , Dados_containers_cidade _dados ){

				// a unica diferená é que aqui se vier null ele só constroi o objeto sem dados;


				Cidade cidade = new Cidade( _cidade_id   );

				// if ( _dados.dados_gerenciador_estado_mental != null )

				// 		{ cidade.gerenciador_estado_mental = Gerenciador_estado_mental_construtor.Construir( cidade,  _dados.dados_gerenciador_estado_mental );}
						
				// 		else 
						
				// 		{ cidade.gerenciador_estado_mental = new Gerenciador_estado_mental( cidade );}


				
		


				return cidade;

		}

	




}