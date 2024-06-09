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

public enum Plano_para_salvar {

	primeiro, 
	segundo,

}



public class Controlador_personagens {

		// Controlador personagens nao tem porque ter conhecimento de como que os dados estao salvos. Ele simeplesmente executa logica e pede dados a um outro sistema.
		  
		// se um personagem precisa ter update mensal ele pede um certo bloco de dados para algum sistema 

		// personagens nao salva nada, ou seja nao tem porque ele saber sobre como vao ficar os container.dat


		public static Controlador_personagens instancia;
		public static Controlador_personagens Pegar_instancia(){ return instancia;}

		public Posicao_longe posicao_longe_player; 


		// personagens_primeiro-plano nao sao adicionados com frequencia
		public int[] personagens_segundo_plano;
		public int[] personagens_primeiro_plano;



		public Personagem[] personagens;

		public string path_folder_dados_personagens ;
		public string path_folder_dados_personagens_morte;
		public string path_dados_personagem;
		public Dados_sistema_personagem_essenciais[] dados_sistema_personagens_essencias;



		public static Controlador_personagens Construir (  int _save, Dados_sistema_personagem_essenciais[] _dados_sistema_personagens_essenciais , Dados_sistema_cidade_essenciais[] _dados_sistema_cidades_essenciais,  Dados_sistema_player _dados_sistema_player, Dados_sistema_estado_atual _dados_sistema_estado_atual ){

				throw new Exception( "aind anao pode vir aqui porque eu nao defini como pegar os dados do save ainda " );


				Controlador_personagens controlador = new Controlador_personagens();


					// ---- DADOS
					controlador.dados_sistema_personagens_essencias = _dados_sistema_personagens_essenciais;
					controlador.personagens = new Personagem[ _dados_sistema_personagens_essenciais.Length ];
					controlador.personagens_ativos = new int [ 20 ];
					controlador.instrucoes_para_salvar = new byte[ _dados_sistema_personagens_essenciais.Length ][];


					// ---- PATHS
					controlador.path_folder_dados_personagens = Paths_gerais.Pegar_path_folder_dados_save( _save )  ;
					controlador.path_folder_dados_personagens_morte = Paths_gerais.Pegar_path_folder_dados_save( _save ) + "/morte" ;
					controlador.path_dados_personagem = controlador.path_folder_dados_personagens + "/Personagens";


					// --- pegar personagens que estao na mesma cidade que o player 
					// talvez se o player controlar mais persoangens pode mudar aqui

					int personagem_atual_player_id =  _dados_sistema_player.personagem_atual; 

					cidade_id_player = _dados_sistema_personagens_essenciais[ personagem_atual_player_id ].posicao_atual_personagem.cidade_id;
					int[] personagens_primeiro_plano = _dados_sistema_cidades_essenciais[ cidade_id_player ] ;
					controlador.personagens_primeiro_plano = personagens_primeiro_plano;

					int cidade_segundo_plano_id =  _dados_sistema_estado_atual.segundo_plano_cidade_id;
					
					int[] personagens_segundo_plano  =  _dados_sistema_cidades_essenciais[ cidade_segundo_plano_id ] ;
					controlador.personagens_segundo_plano = personagens_segundo_plano;

					int index_no_plano = 0;


					for( index_no_plano = 0 ; index_no_plano < personagens_primeiro_plano.Length ; index_no_plano++ ){

							int persoangem_id = personagens_primeiro_plano[ index_no_plano ];
							controlador.Construir_personagem(  persoangem_id );	

					}


					for( index_no_plano = 0 ; index_no_plano < personagens_segundo_plano.Length ; index_no_plano++ ){

							int persoangem_id = personagens_segundo_plano[ index_no_plano ];
							controlador.Construir_personagem(  personagem_id );	

					}


				instancia = controlador;
				return instancia;
			
		}

		

		public enum Plano_sistema {

			primeiro,
			segundo

		}



		// controlador personagens precisa saber? 

		// 



		public void Construir_personagem(  Plano_sistema _plano,  int _personagem_id ){


				// ** para um personagem entrar na cidade do player ele precisa primeiro ser carregado em segundo plano => ele já vai estar carregado 
				// nao vai ser chamado com frequencia
				

				throw new Exception( "aind anao pode vir aqui" );

				/*

					- pegar personagem run time 
					- load dados disco

				*/

				Controlador_dados_dinamicos controlador_dados_dinamicos = Controlador_dados_dinamicos.Pegar_instancia();


				System.Object personagem_run_time_data = controlador_dados_dinamicos.dados_run_time.Pegar_personagem( _personagem_id );

				Containers_dados_personagem dados_para_construir_personagem = Leitor_dados_personagem.Pegar( path_dados_personagem, personagem_id );

				Personagem novo_personagem =  Construtor_personagem.Construir( dados_para_construir_personagem );
				
				personagens [ personagem_id ] = novo_personagem; 



				// --- COLOCA PERSONAGEM NO PLANO
			
				int[] personagens_plano = null;

				switch( _plano ){

						case Plano_sistema.primeiro : personagens_plano = personagens_primeiro_plano; break;
						case Plano_sistema.segundo  : personagens_plano = personagens_segundo_plano; break;
						
				}

				INT.Acrescentar_valor_COMPLETO_GARANTIDO( ref personagens_plano , _personagem_id );


				// ---- CRIA SLOT INSTRUCOES

				instrucoes_para_salvar[ _personagem_id ]  = new byte[ 50 ][];


	
				return;



		}




		public void Carregar_personagem_MULTITHREAD(  Plano_sistema _plano,  int _personagem_id ){





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

						controlador.personagens_ativos = new int [ 20 ];


						for( int per = 0 ; per < personagens_nomes.Length ; per++ ){ 

								controlador.dados_sistema_personagens_essencias[ per ] = new Dados_sistema_personagem_essenciais();
								
						}

						int nara_id = ( int ) Personagem_nome.Nara;
						controlador.dados_sistema_personagens_essencias[ nara_id ].personagem_esta_ativo = true;
						controlador.Acrescentar_personagem_ativo( nara_id );
						

						controlador.personagens = personagens;
						personagens[ nara_id ] = new Personagem();


				instancia = controlador;				
				return instancia;
			
		}


		public void Carregar_personagem_teste ( Personagem_nome personagem_nome, Containers_dados_personagem _dados_para_construir_personagem ){

				Debug.Log( "vai carregar personagem : " + personagem_nome );

				Personagem novo_personagem = Construtor_personagem. Construir_personagem_teste( _dados_para_construir_personagem );				
				personagens[ ( int ) personagem_nome ] = novo_personagem; 
				return;

		}










		public void Acrescentar_personagem_ativo( int personagem_id ){


				for( int slot_personagem_index = 0 ; slot_personagem_index < personagens_ativos.Length ; slot_personagem_index++ ){

					if( personagens_ativos[ slot_personagem_index ] == ( int ) Personagem_nome.nada ) { personagens_ativos[ slot_personagem_index ] = personagem_id; return; }

				}

				personagens_ativos = INT.Aumentar_length_array( personagens_ativos , 10 );

				personagens_ativos[ personagens_ativos.Length - 10 ] = personagem_id;



		}




		public Personagem Pegar_personagem ( Personagem_nome _personagem_nome ){

			int personagem_id = ( int ) _personagem_nome ;

			
			if( personagens[ personagem_id ] == null  )
					{ 
						Debug.LogError( $"Sistema pediu o personagem { _personagem_nome } mas ele nao foi criado" );

						for( int personagem_ativo_index = 0 ; personagem_ativo_index < personagens_ativos.Length; personagem_ativo_index++ ){

								if( personagens_ativos[ personagem_ativo_index ] == personagem_id )
									{ break; }
								if( ( personagem_ativo_index - personagens_ativos.Length ) == 1 )
									{ Debug.LogError( "O personagem também não estava ativo" ); }

						}

						throw new Exception( "" ); 

					}

			return personagens[ personagem_id ];
		}




		public byte[][] instrucoes_para_salvar;



		public int[] personagens_de_cada_instrucao_1 = new int[ 10 ];
		public byte[][] dados_para_adicionar_primeiro_plano = new byte[ 10 ][];

		public int[] personagens_de_cada_instrucao_2 = new int[ 10 ];
		public byte[][] dados_para_adicionar_segundo_plano = new byte[ 10 ][];

		

		public void Colocar_instrucoes_de_seguranca(   Plano_para_salvar _plano_para_salvar,  int personagem,  byte[] _dados_seguranca  ){


				byte[][] dados_para_adicionar = null;
				int[] personagens_localizador = null;

				switch( _plano_para_salvar ){

						case Plano_para_salvar.primeiro : dados_para_adicionar = dados_para_adicionar_primeiro_plano; break;
						case Plano_para_salvar.segundo : dados_para_adicionar = dados_para_adicionar_segundo_plano; break;

				}
				
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








