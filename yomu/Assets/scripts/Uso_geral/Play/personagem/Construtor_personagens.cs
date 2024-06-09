



public static class Construtor_personagem {


	    public static  Personagem Construir(  Dados_sistema_personagem_essenciais _dados_istema_essenciais , Containers_dados_personagem _dados ){

				// ** responsavel por passar os bytes[] e instanciar os Gerenciadores 
				
				// precisa dos dados completos

				Personagem personagem = new Personagem( _dados_istema_essenciais );


				personagem.dados_personagem_run_time = Controlador_dados_dinamicos.Pegar_instancia().dados_run_time.Pegar_personagem(  )
 
				personagem.gerenciador_estado_mental = Gerenciador_estado_mental_construtor.Construir( personagem,  _dados.dados_gerenciador_estado_mental );


				return personagem;

		}

		public static Personagem Construir_personagem_teste( Containers_dados_personagem _dados ){

				// a unica diferená é que aqui se vier null ele só constroi o objeto sem dados;


				Personagem personagem = new Personagem();

				if ( _dados.dados_gerenciador_estado_mental != null )

						{ personagem.gerenciador_estado_mental = Gerenciador_estado_mental_construtor.Construir( personagem,  _dados.dados_gerenciador_estado_mental );}
						
						else 
						
						{ personagem.gerenciador_estado_mental = new Gerenciador_estado_mental( personagem );}


				
		


				return personagem;

		}

	




}