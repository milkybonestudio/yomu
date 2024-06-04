using System;
using UnityEngine;

/*


*** personagens que não estão em foco não precisam de dados?
*** isso vai fazer 
** o total de ram que o sistema vai usar por conta dos personagens vai ser numero_maximo_de_personagens * dados_por_personagem * espaço_medio_por_dado
   certas coisas vao precisar ser strings ( ? ) 
   poderia ser enum. 

o numero de personagens não pode crescer infinitamente, mas eu não tenho ainda noção de escala 

o valor principal para ver é o tamanho da dll. 
quanto de memoria eu estou disposto a usar? 

somente o jogo normal com a unity gasta em torno de 150mb 
acho que até 300mb é algo aceitavel 
150mb => 150_000_000 bytes
com 150 personagens pode ter 1mb
todas as classes com os metodos vão ser estaticos. 
Pois como oque é realmente grande vai ser as proprios funcoes nao faz sentido colocar parte da logica dentro da dll. 

oque eu tenhop que pensar é quem vai conseguir puxar essa funcao e quem vai conseguir mudar 

  sistema :: assembly.class().metodo 

  a classe precisa ter um metodo que coloca os dados

  public enum Tipo_mov_lily {

  	default, 
        normal, 
  
  }

  precisa ser algo: class {

  		//                                esses dados estariam complexos 
  		void Colocar_dados( Lily _lily , string _dados_str ) { 

				// 
    				int index_movimento = 0; 
    				char tipo_mov_char = _dados_str [ index_movimento ];
				Tipo_mov_lily tipo_mov = ( Tipo_mov_lily ) tipo_mov_char;

    				switch( tipo_mov ){
					case Tipo_mov_lily.default: _lily.Updat_movimento = Lily_lidar_movimento; break; 
					default : Exception("a");	
     
				}

 
		}
	
  
  }

chamar o metodo nao vai ter muito custo, mas colocar tem. 


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
   
 
   dados_atualizar_dia

   Update_dia(){



   }




}


ponto_atual 

public action(){

}


lily.Movimentar( mes , semana, dia , priodo ){


	switch( dia_semana ){	

	case Dia.Segunda : lidar_movimento_segunda( mes , semana, dia , priodo )


}


lidar_movimento_segunda(){


      switch( periodo ){

case Periodo.Manha: {

if( variavel ) { dados[ clothes ] = clothes.duck; return;} 
if( variavel_2 ) { dados[ clothes ] = clothes.normal; return;} 


braak;


}

}
      if( variavel ) { dados[ clothe ] = Clothes.duck; }



}



}




** dados 

   todo personagem precisa de dados dinamicos que são resetados depois de cada dia 

 

 
tempo para atualizar


 - mensal 
 - semana
 - dia
 - periodo 
 - tempo real




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





** preciso checar mais oque? 




reposta = Pegar_resposta()::bool 

mudar_valor()::void





lily_comeu_biscoito => bool 
quantos_biscoitos_lily_comeu => 10


 
*/




/*




	save /  

	      personagens  /

    	 	                lily  /

									// dados exclusivos do save 

									dados_sistema.txt

									// se o personagem esta em foco 

									dados_container_bool.dat
									dados_container_int.dat
									dados_container_string.txt
									dados_container_datas.dat

								
							ruby  /
							



** oque pode introduzir personagens
         => tempo       
		 => mudar de local 
		 => quests 
	** nao precisa ser o player. 
	se a lily for para outra cidade o jogo precisa iniciar todos os personagens da cidade. 
	mas não é iniciar na ram, vai ser soment efazer uma copia dos arquivos de cada personagem para o save.
						
 

*/

public static class Dados_sistema_personagens_ferramentas {


		public static Dados_sistema_personagem Ler( string _dados_str ){

			return null;


		}

	

}



// public class Personagem {


// 	public Ass



// }


	



public class Controlador_personagens {

		// Controlador personagens nao tem porque ter conhecimento de como que os dados estao salvos. Ele simeplesmente executa logica e pede dados a um outro sistema.
		  
		// se um personagem precisa ter update mensal ele pede um certo bloco de dados para algum sistema 

		// personagens nao salva nada, ou seja nao tem porque ele saber sobre como vao ficar os container.dat

		/*

			Cada persoangem tem dlls corespondetes para cada regiao			
		
		*/

		public static Controlador_personagens instancia;
		public static Controlador_personagens Pegar_instancia(){ return instancia;}
		
		public static Controlador_personagens Construir ( Dados_sistema_personagem[] _dados_sistema_personagens , int _save ){


				instancia = new Controlador_personagens();

				instancia.dados_sistema_personagens = _dados_sistema_personagens;
				instancia.personagens = new Personagem[ instancia.dados_sistema_personagens.Length ];

				int index_personagem = 0;

				int numero_personagens_ativos = 0;

				for( index_personagem = 0 ; index_personagem <  instancia.dados_sistema_personagens.Length ; index_personagem++){ 

						if( instancia.dados_sistema_personagens[ index_personagem ].personagem_esta_ativo ){ numero_personagens_ativos++;}

				}

				Personagem_nome[] personagens_ativos = new Personagem_nome[ numero_personagens_ativos ];


				int personagens_ativos_index = 0;
				for( index_personagem = 0 ; index_personagem < instancia.dados_sistema_personagens.Length ; index_personagem++ ){

						Dados_sistema_personagem dados_sistema_personagem = _dados_sistema_personagens[ index_personagem ];
						if( dados_sistema_personagem.personagem_esta_ativo ){ 
								
								personagens_ativos[ personagens_ativos_index ] = dados_sistema_personagem.nome_personagem;
								personagens_ativos_index++;

								Personagem novo_personagem = new Personagem();

								// por hora vai ser criado no script
								novo_personagem.dados_sistema = dados_sistema_personagem;
								
								Personagem_nome personagem_nome = dados_sistema_personagem.nome_personagem;
								string path_dados_personagem = Paths_gerais.Pegar_path_folder_dados_save( _save ) + "/Personagens/" + personagem_nome.ToString() + "/";

								int tipo_armazenamento = dados_sistema_personagem.tipo_armazenamento;

								if( tipo_armazenamento == 0 ){
										// ** o compacto vai ser na realidade mais dificil, vale a pena por hora fazer todos com arquivos separados
										// container compacto

										throw new System.Exception( "nao era para vir aqui, tipo armazenamento 0 no personagem " + personagem_nome.ToString() );

								}

								if( tipo_armazenamento == 1 ){
										// arquivos separados

										// Tradutor_personagens_completo.Traduzir( instancia , path_dados_personagem );

								}

								
								instancia.personagens[ index_personagem ] = novo_personagem; 
								continue;
							
						}


				}

				return instancia;
			
		}




		// aqui todos os personagens exeto a nara vão ser instanciados como null
		public static Controlador_personagens Construir_teste ( ){


				instancia = new Controlador_personagens();

				// inicia somente com o player ativo
				string[] persoangens_nomes = Enum.GetNames( typeof( Personagem_nome ) );
				Dados_sistema_personagem[] dados = new Dados_sistema_personagem[ persoangens_nomes.Length ];
				Personagem[] personagens = new Personagem[ persoangens_nomes.Length ];


				for( int per = 0 ; per < persoangens_nomes.Length  ; per++){ 

						dados[ per ] = new Dados_sistema_personagem(); 
						
				}

				dados[ ( int ) Personagem_nome.Nara ].personagem_esta_ativo = true;

				instancia.dados_sistema_personagens = dados;
				instancia.personagens = personagens;
				

				Personagem_nome[] personagens_ativos = new Personagem_nome[ 1 ] { Personagem_nome.Nara };
				personagens[ ( int ) Personagem_nome.Nara ] = new Personagem();
				
				return instancia;

			
		}








		public Personagem Construir_personagem( Dados_sistema_personagem _dados_sistema_personagem, int _save ){

				return null;

		}

		public Personagem Construir_personagem_teste(){

			return null;

                // // por hora vai ser criado no script
                // this.dados_sistema = _dados_sistema_persoangem;
                // return;


                // Personagem_nome personagem_nome = _dados_sistema_persoangem.nome_personagem;
                // string path_dados_personagem = Paths_gerais.Pegar_path_folder_dados_save( _save ) + "/Personagens/" + personagem_nome.ToString() + "/";

                // int tipo_armazenamento = dados_sistema.tipo_armazenamento;

                // if( tipo_armazenamento == 0 ){
                //     // ** o compacto vai ser na realidade mais dificil, vale a pena por hora fazer todos com arquivos separados
                //     // container compacto

                //     throw new System.Exception( "nao era para vir aqui, tipo armazenamento 0 no personagem " + personagem_nome.ToString() );

                // }

                // if( tipo_armazenamento == 1 ){
                //     // arquivos separados

                //     Tradutor_personagens_completo.Traduzir( this , path_dados_personagem );

                // }


		}



		public Personagem Pegar_personagem( Personagem_nome _personagem_nome ){

			if( ! ( dados_sistema_personagens[ ( int )_personagem_nome ].personagem_esta_ativo ) ){ 

				throw new Exception( $"pediu para pegar o personagem { _personagem_nome } mas ele nao estava ativo" );

			 }

			return personagens[ ( int )_personagem_nome ];

		}








		
		public Dados_sistema_personagem[] dados_sistema_personagens; 

		public string path_folder_dados_personagens ;
		public string path_save_morte;

		// save in buffer dont save in disk


		public Personagem[] personagens;

		// vao ser resetados quando os dados forem salvos 
		
		public byte[][] dados_para_adicionar = new byte[ 10 ][];

		public void Pedir_para_salvar_dados(  byte[] _dados_seguranca ){


				for( int index = 0 ; index < dados_para_adicionar.Length ; index++ ){

						if( dados_para_adicionar[ index ] == null ){ dados_para_adicionar[ index ] = _dados_seguranca; return;}


				}

				byte[][] novo_arr = new byte[ dados_para_adicionar.Length + 10 ][];

				int length_para_adicionar = dados_para_adicionar.Length;
				novo_arr[ length_para_adicionar ] = _dados_seguranca;

				
				for( int index_arr = 0 ; index_arr < dados_para_adicionar.Length ; index_arr++ ){

						novo_arr[ index_arr ] =  dados_para_adicionar[ index_arr ];

				}

				dados_para_adicionar = novo_arr;

				return;
				




		}





  
}



