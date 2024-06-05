



public static class Construtor_personagem {


	    public static  Personagem Construir( Dados_para_construir_personagem _dados ){

				// ** responsavel por passar os bytes[] e instanciar os Gerenciadores 
				
				// precisa dos dados completos

				Personagem personagem = new Personagem();
 
				personagem.gerenciador_estado_mental = Gerenciador_estado_mental_construtor.Construir( personagem,  _dados.dados_gerenciador_estado_mental );


				return personagem;

		}

		public static Personagem Construir_personagem_teste( Dados_para_construir_personagem _dados ){

				// a unica diferená é que aqui se vier null ele só constroi o objeto sem dados;


				Personagem personagem = new Personagem();

				if ( _dados.dados_gerenciador_estado_mental != null )

						{ personagem.gerenciador_estado_mental = Gerenciador_estado_mental_construtor.Construir( personagem,  _dados.dados_gerenciador_estado_mental );}
						
						else 
						
						{ personagem.gerenciador_estado_mental = new Gerenciador_estado_mental( personagem );}
		


				return personagem;

		}




}