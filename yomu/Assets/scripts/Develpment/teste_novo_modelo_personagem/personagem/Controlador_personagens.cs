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

// public static class Dados_sistema_personagens_ferramentas {


// 		public static Dados_sistema_personagem Ler( string _dados_str ){

// 			return null;


// 		}

	

// }


// // classe dinamica 
// // toda classe dinamica precisa iniciar com o save para pegar o local dos dados 
// public class Controlador_personagens {

// 		public static Controlador_personagens instancia;
// 		public static Controlador_personagens Pegar_instancia(){ return instancia;}
// 		public static void Construir( int _save ){ instancia = new Controlador_personagens( _save ); return; }


		
// 		public Dados_sistema_personagem[] dados_sistema_personagens; 

// 		public string path_folder_dados_personagens ;
// 		public string path_save_morte;


// 		// Controlador personagem vai estar em dados dinamicos  
// 		public Controlador_personagens( int _save ){



				
// 				path_folder_dados_personagens = Paths_gerais.Pegar_path_folder_dados_save( _save ) + "/Personagens";

// 				// ** nao precisa aqui
// 				// path_save_morte = Paths_gerais.Pegar_path_folder_dados_save( _save ) + "/Save_morte/Personagens";

// 				string[] personagens_nomes = Enum.GetNames( typeof( Personagem_nome ));
// 				int numero_personagens = personagens_nomes.Length ;

				


// 				dados_sistema_personagens = new Dados_sistema_personagem[ numero_personagens ];
// 				personagens = new Personagem[ numero_personagens ];

// 				for( int personagem_index = 0 ; personagem_index < numero_personagens ; personagem_index++  ){


// 						string nome_personagem = personagens_nomes[ personagem_index ];
// 						string path_personagem_dados_sistema = path_folder_dados_personagens + "/" + nome_personagem + "_dados_sistema.txt";

// 						// os dados aqui vao estar compactados
// 						// eu nao vou ser capaz de usar strings 
// 						// minha mente vai ser a minha propria derrota
// 						string[] texto_linhas = System.IO.File.ReadAllLines( path_personagem_dados_sistema );
// 						Dados_sistema_personagem dados  = new Dados_sistema_personagem();
// 						dados_sistema_personagens[ personagem_index ] = dados;

// 						dados.esta_salvo = true;
// 						dados.nome_personagem = ( Personagem_nome ) personagem_index;
// 						dados.interesse_player = 200;

// 						dados.posicao_atual_personagem = new Posicao();



						
// 				}

				
// 			//	personagens = new Personagem[];
					
			
// 		}

		
// 		public Dados_sistema_personagem Pegar_dados_sistema( string _nome){
// 			return null;

// 			string path = this.path_folder_dados_personagens + _nome + "/dados_sistema.dat";
// 			string[] dados = System.IO.File.ReadAllLines( path );
// 			if( dados == null ){ throw new System.Exception( "nao foi achado dados no path: " + path ) ;}

// 			Dados_sistema_personagem dados_retorno = new Dados_sistema_personagem();


// 			// deixar o nome do personafgem seria bom se caso eu tiver o arquivo para saber de qual personagem é 





// 			// dados_retorno.nome_personagem = _nome;
// 			// dados__retorno.interesse_player = 

			
			
// 		}


// 	/*

// 		**funcao 
// 		pega os personagens;
// 		entrega os personagens;
// 		guarda actions;
		
	
// 	*/

// 		public Personagem[] personagens;

// 		public string Pegar_path_dados_sistema( string _nome_personagem ){
			
// 			string path_folder_personagens = "colocar_path";
// 			return path_folder_personagens + _nome_personagem + "/";
			
// 		}

// 		public Personagem Pegar_personagem( Personagem_nome _personagem_nome ){

// 			return null;

			
			
// 		}



  
// }



