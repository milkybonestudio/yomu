



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





using System.IO;


// ** trocar prioridades também precisa ser controlado 


// sempre que um personagem se afastar da posicao do player ele desce um nivel para cada local
// mesma cidade locais diferentes => -1
// mesmo estado cidades diferentes => -2 
// ...

// ** para mudar o local de um persoangem precisa ter uma funcao especifica. 
// Controlador mundo vai ter os locais que estao cada personagem 


    //10  =>  15



// todo personagem vai ser iniciado com prioridade muito baixa 
// nao vale a pena ficar preocupado em iniciar somente quando algum trigger acontecer 


public enum Atividade {

    nada

}


public class Posicao_geral {


        public int cidade_id;
        public Posicao_local posicao_local;
        public Posicao_mundial posicao_mundial;


}



public struct Posicao_local {

    public int ponto;
    public int area;
    public int regiao;

}

public struct Posicao_mundial {

    public byte continente;
    public byte reinos;
    public byte estados;


}




public class Dados_sistema_personagem {


            // essa logica vai ficar em Player_dados_sistema
            // public bool player_colocou_personagem_em_foco; // mesmo com interesse baixo fica em foco alto 
            
            // isso faz mais sentido ficar dentro dos proprios dados. 
            // se tudo vai ser somente 1 container 

            public int update; 

            // ** tipo_de_armazenamento só vai importar na pratica quando for salvar
            // os dados sao descompactados quando eles sao colocados em cada container 

            public byte tipo_armazenamento = 1 ; // 0 => container_compactado, 1 => arquivos separados
            // ** lembrar de adicionar
            public int[] localizadores_container_geral; // so usar se for 0
            public int[] length_containers;    // so usar se for 1
    

            // pode mudar dependendo do ponto da historia 
        
            public Trigger[] triggers;
            public Caracteristica_fisica[] caracteristicas_fisicas;
            public Caracteristica_psicologicas caracteristicas_psicologicas;






}









public enum Trigger {


}
public enum Caracteristica_fisica {


}
public enum Caracteristica_psicologicas{


}


// public class Dados_personagem {


//     public Trigger[] trigers;
//     public Caracteristica_fisica[] caracteristicas_fisicas;
//     public Caracteristica_psicologicas[] caracteristicas_psicologicass;


// }

