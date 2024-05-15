



		/*
  			esse arquivo seria interessante manter ele um pouco mais legivel, para se eu precisar ler ele no folder
     
  				--- FORMATO ---
      
      		--- personagem : nome
            --- personagem foi colocado no jogo 
                ** 
	 		--- personagem com trigger 
    		--- lista de trigger personagem 
       				** qualquer coisa que possa triggar vai estar aqui. 
	   			** o sistema pode fazer calculos sem instanciar os personagens 
	 		--- Personagem bloqueado pelo sistema ()
	
	        --- se ja foi apresentado
                    se o personagem nao foi apresentado ele vai usar tudo como default 
                    Sim, default vai focar somente nas coisas mais importantes
                    nao é somente por uma questão de reduzir processamento, mas é de 
                    true => real 
                    false => projecao 
            
	        --- data que o personagem foi apresentado 
		 
		 	--- esta em foco ( interesse do player esta maior que 350 OU deliberadamente selecionou para ficar em foco )
    		--- player marcou para ficar em foco
       			** se o player mostrar interesse no personagem sobre, se nâo mostrar desce.
	            ** nao afeta os dados dos personagens em si, mas faz com que o player possa ter mais interações oque pode levar a mais levels	     
		     
		    --- interesse player : ( numero entre 0 e 1000 )     
	  		--- projecao de interesse : ( numero entre 0 e 1000  );
     			** projecao vai pegar os traços dos personagens que o player gosta e ver se batem 
     		--- afetividade ( numero entre -1000 e 1000 ) isso vai sinalizar se o player tenta prejudicar ou ajudar o personagem
		    --- projecao afetividade ( numero entre -1000 e 1000 )
	            ** projecao se o pleyer vai querer ajudar o personagem 

			// as funcoes de update nao vão mudar com facilidade e não vai ter muitas. 
   			// mudar o update pode significar que o contexto do update mudou completamente 
      			// se algo assim atrapalhar posso mudar para "( char_id_enum )_nome_update"
		    --- funcao_update_movimento : nome  
	  		--- funcao_update_conversas : nome
     		--- ... ( outros updates nomes )

      		  
  		*/

        /*
			      gosta
	  			|
	      			|
		tedio ----------|-------- interesse
	      			|
		       		|
			      odeia
	 
	 	interesse => se o player pode interagir ele interage. 

		interesse alto e 
   
  		*/






public enum Nivel_de_interesse_player_no_personagem : byte {

        muito_baixo ,
        baixo,
        medio, 
        alto,
        muito_alto, 

}


/*
   muito baixo => na dll_geral
   nivel baixo e media => dll_1
   alto e muito alto => dll_2

*/

// ** trocar prioridades também precisa ser controlado 


// sempre que um personagem se afastar da posicao do player ele desce um nivel para cada local
// mesma cidade locais diferentes => -1
// mesmo estado cidades diferentes => -2 
// ...

// ** para mudar o local de um persoangem precisa ter uma funcao especifica. 
// Controlador mundo vai ter os locais que estao cada personagem 





public enum Local_nome {

    Cathedral,

}

public enum Cidade_nome {

    New_ground, 

}

public enum Estado_nome : short {

    San_sebastian,

}

public enum Reino_nome : byte {

    Human

}

public enum Continente_nome : byte {

    central,

}



public struct Posicao {

    public Ponto_nome ponto; 
    public Local_nome local; // catedral 
    public Cidade_nome  cidade; // cidade da catedral
    public Estado_nome estado; // conjunto de cidades 
    public Reino_nome reino;  // conjuntod e estados 
    public Continente_nome continenete; // conjunto de reinos


}



// todo personagem vai ser iniciado com prioridade muito baixa 
// nao vale a pena ficar preocupado em iniciar somente quando algum trigger acontecer 


public class Dados_sistema_personagem {

        // quando for finalizar verificar ou quando for salvar run time 
        public bool esta_salvo = true;

        /*
            Essa classe vai ter os dados essenciais para calculos internos no sistema. 
            vai ter os updates do personagem, como que esta a relação do player com esse personagem ( nao da nara mas o player em si)
                
        */
        
        public Personagem_nome nome_personagem;
        //  entre 0 e 1000.  
        public int interesse_player;
        public int projecao_interesse_player;
        // entre -1000 e 1000
        public int afetividade;
        public int projecao_afetividade;

        
        public Posicao posicao_atual_personagem;
        public bool personagem_ja_foi_apresentado_ao_player;
        public Data quando_personagem_foi_introduzido;
        public Nivel_de_interesse_player_no_personagem nivel_interesse;
        
        public bool player_colocou_personagem_em_foco;

        public bool personagem_bloqueado;
        
        

        public int[] updates;
	
}


public enum Trigger {


}
public enum Caracteristica_fisica {


}
public enum Caracteristica_psicologicas{


}


public class Dados_personagem {


    public Trigger[] trigers;
    public Caracteristica_fisica[] caracteristicas_fisicas;
    public Caracteristica_psicologicas[] caracteristicas_psicologicass;


}

