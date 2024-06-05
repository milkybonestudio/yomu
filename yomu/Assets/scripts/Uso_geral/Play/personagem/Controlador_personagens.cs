using System;
using UnityEngine;

/*


parte generica  => 

nome : ##
salario : 1520 
posicao atual :  ( int ) posicao
personagens_intimidade_dados : [

  lily : [  ],
  amy : [  ],

]



personagem {

   [ ... ] => contem dados do personagem 
          esse precisa ser especifico para cada personagem?

          coisas: 
                 roupa default
                 salario, 
                 funcao atual, 
                 
   
   [ ... ] => container com estado emocional do personagem
   [ ... ][ ... ] => container com informacoes sobre os personagens
   
 


personagem 


 quando o dia trocar 

    // so vai ter em personagens que estao em foco.  
    // aqui vai ter uns 3 segundos de animacao para mudar de dia. Oque da uns 10b de ciclos


    ** verificar mudancas de variaveis internas 
         ** variaveis fluidas tendem a voltar para o padrao de forma brusca
         ** variaveis padroes podem mudar um pouco de forma lenta 
         
 
    ** assuntos internos => plots / conversas / quests
            ** certos assuntos podem levar um tempo ou ter que verificar alguns outros requisitos   
                    ex: 
 			conversa :   "falar mal de pessoas que usam rosa" => 3 dias depois : "eu estava pensando... se eu usasse rosa voce não iria gostar de mim?" 
                        plot     :   "quer convidar ele para a cacheira caso a intimidade passe de 700" => precisa de 3 relacoes de intimidade primeiro 
                        quest    :   "vai pedir para o player ajudar ela a matar um cavalo que matou o canario dela" => precisa ter 500g para pagar pelo transporte 

  
    ** verificar enviar cartas para o player 
          ** elas sempre vão chegar de manha 

    ** verificar finanças 
         ** verifica os itens que tem e muda tabela de desejos 
         ** verifica o dinheor atual e faz escolhas        

    ** verificar se tem plot imediato *raro => personagem vai falar com player 
    ** checar se vai ficar com algum plot em espera 
  
 
 quando trocar periodo

    ** verificar mudanca de roupa
    ** movimento 
    ** Checar atividade por periodo
    ** checar mudanca variaveis internas por periodo 
          ** se o personagem no periodo passado fez algo que gosta ele vai estar de bom humor 

  
    ----------------------- 
 
    ** personagens nos mesmos lugares podem interagir 



 quando no mesmo espaço que o player: 
   
    
    ** checar se vai triggar com o player por conversa => inicia com algum bloco 
    ** checar se vai triggar com player por plot   
    ** checar se vai triggar com player por quest  

 qunado for iniciar conversa com o player 

    ** verificar plot
    ** verificar quest  
    ** verificar conversa imaediata 

 durante a conversa player 
 
  ** atualizar stats sobre o player e verificar se algum bloco de conversa foi bloqueado 






updates vs atos


Update : depende de tempo 
Ato : depende de algo iniciar 

*/




public class Controlador_personagens {

		// Controlador personagens nao tem porque ter conhecimento de como que os dados estao salvos. Ele simeplesmente executa logica e pede dados a um outro sistema.
		  
		// se um personagem precisa ter update mensal ele pede um certo bloco de dados para algum sistema 

		// personagens nao salva nada, ou seja nao tem porque ele saber sobre como vao ficar os container.dat


		public static Controlador_personagens instancia;
		public static Controlador_personagens Pegar_instancia(){ return instancia;}


		public static Controlador_personagens Construir ( Dados_sistema_personagem[] _dados_sistema_personagens , int _save ){

				throw new Exception( "aind anao pode vir aqui porque eu nao defini como pegar os dados do save ainda " );

				Controlador_personagens controlador = new Controlador_personagens();

						controlador.dados_sistema_personagens = _dados_sistema_personagens;
						controlador.personagens = new Personagem[ controlador.dados_sistema_personagens.Length ];

						controlador.path_folder_dados_personagens = Paths_gerais.Pegar_path_folder_dados_save( _save )  ;
						controlador.path_folder_dados_personagens_morte = Paths_gerais.Pegar_path_folder_dados_save( _save ) + "/morte" ;

						int index_personagem = 0;

						int numero_personagens_ativos = 0;

						for( index_personagem = 0 ; index_personagem <  controlador.dados_sistema_personagens.Length ; index_personagem++){ 

								if( controlador.dados_sistema_personagens[ index_personagem ].personagem_esta_ativo ){ numero_personagens_ativos++;}

						}

						controlador.personagens_ativos = new Personagem_nome[ numero_personagens_ativos ];


						int personagens_ativos_index = 0;
						for( index_personagem = 0 ; index_personagem < controlador.dados_sistema_personagens.Length ; index_personagem++ ){

								Dados_sistema_personagem dados_sistema_personagem = _dados_sistema_personagens[ index_personagem ];

								if( dados_sistema_personagem.personagem_esta_ativo ){ 

										controlador.Carregar_personagem( dados_sistema_personagem );
										
										controlador.personagens_ativos[ personagens_ativos_index ] = dados_sistema_personagem.nome_personagem;
										personagens_ativos_index++;
										continue;
									
								}

						}

				instancia = controlador;
				return instancia;
			
		}

		// aqui todos os personagens exceto a nara vão ser instanciados como null
		public static Controlador_personagens Construir_teste ( ){

				Controlador_personagens controlador = new Controlador_personagens();

						// inicia somente com o player ativo
						string[] persoangens_nomes = Enum.GetNames( typeof( Personagem_nome ) );
						Dados_sistema_personagem[] dados = new Dados_sistema_personagem[ persoangens_nomes.Length ];
						Personagem[] personagens = new Personagem[ persoangens_nomes.Length ];


						for( int per = 0 ; per < persoangens_nomes.Length ; per++ ){ 

								dados[ per ] = new Dados_sistema_personagem();
								
						}

						dados[ ( int ) Personagem_nome.Nara ].personagem_esta_ativo = true;

						controlador.dados_sistema_personagens = dados;
						controlador.personagens = personagens;
						

						Personagem_nome[] personagens_ativos = new Personagem_nome[ 1 ] { Personagem_nome.Nara };

						personagens[ ( int ) Personagem_nome.Nara ] = new Personagem();

				instancia = controlador;				
				return instancia;
			
		}






				
		public Dados_sistema_personagem[] dados_sistema_personagens; 
		public Personagem[] personagens;
		public Personagem_nome[] personagens_ativos;

		public string path_folder_dados_personagens ;
		public string path_folder_dados_personagens_morte;

		





	

		public void Carregar_personagem( Dados_sistema_personagem _dados_sistema_personagem ){



				Personagem_nome personagem_nome = _dados_sistema_personagem.nome_personagem;
				string path_dados_personagem = path_folder_dados_personagens + "/Personagens/" + personagem_nome.ToString() + "/";
				

				Dados_para_construir_personagem dados_para_construir_personagem = Leitor_dados_contrucao_personagem.Pegar( path_dados_personagem, _dados_sistema_personagem );

				Personagem novo_personagem =  Construir_personagem( dados_para_construir_personagem );
				novo_personagem.dados_sistema = _dados_sistema_personagem;


				personagens[ ( int ) personagem_nome ] = novo_personagem; 
				return;

		}






		public void Carregar_personagem_teste ( Dados_sistema_personagem _dados_sistema_personagem , Dados_para_construir_personagem _dados_para_construir_personagem ){



				Personagem_nome personagem_nome = _dados_sistema_personagem.nome_personagem;
				string path_dados_personagem = path_folder_dados_personagens + "/Personagens/" + personagem_nome.ToString() + "/";
				int tipo_armazenamento = _dados_sistema_personagem.tipo_armazenamento;

				Personagem novo_personagem = Construir_personagem_teste( _dados_para_construir_personagem );
				novo_personagem.dados_sistema = _dados_sistema_personagem;


				personagens[ ( int ) personagem_nome ] = novo_personagem; 
				return;

		}









		public Personagem Construir_personagem( Dados_para_construir_personagem _dados ){

				// ** responsavel por passar os bytes[] e instanciar os Gerenciadores 
				
				// precisa dos dados completos

				Personagem personagem = new Personagem();
 
				personagem.gerenciador_estado_mental = Gerenciador_estado_mental_construtor.Construir( personagem,  _dados.dados_gerenciador_estado_mental );


				return personagem;

		}




		public Personagem Construir_personagem_teste( Dados_para_construir_personagem _dados ){

				// a unica diferená é que aqui se vier null ele só constroi o objeto sem dados;


				Personagem personagem = new Personagem();

				if ( _dados.dados_gerenciador_estado_mental != null )

						{ personagem.gerenciador_estado_mental = Gerenciador_estado_mental_construtor.Construir( personagem,  _dados.dados_gerenciador_estado_mental );}
						
						else 
						
						{ personagem.gerenciador_estado_mental = new Gerenciador_estado_mental( personagem );}
		


				return personagem;

		}



		public Personagem Pegar_personagem( Personagem_nome _personagem_nome ){



			if( ! ( dados_sistema_personagens[ ( int )_personagem_nome ].personagem_esta_ativo ) )
				
				{ throw new Exception( $"pediu para pegar o personagem { _personagem_nome } mas ele nao estava ativo" ); }

			
			if( personagens[ ( int ) _personagem_nome ] == null  )
			
				{ throw new Exception( $"pediu para pegar o personagem { _personagem_nome } mas ele nao foi criado" ); }


			return personagens[ ( int )_personagem_nome ];


		}





		
		public byte[][] dados_para_adicionar = new byte[ 10 ][];

		public void Pedir_para_salvar_dados(  byte[] _dados_seguranca ){

				int index = 0;

				for(  ; index < dados_para_adicionar.Length ; index++ ){

						if( dados_para_adicionar[ index ] == null ){ dados_para_adicionar[ index ] = _dados_seguranca; return;}


				}

				// nao tem disponivel

				dados_para_adicionar = BYTE.Aumentar_length_array_2d( dados_para_adicionar, 10 );
				dados_para_adicionar[ index ] = _dados_seguranca;

				return;


		}





  
}



