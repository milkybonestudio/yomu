using System;



/*

    assim que um personagem for introduzido ele sempre vai estar como generico 

*/


/*



    ** movimento 
    ** lidar com conversas 
            => lidar modificadores 
            => 
    




*/



public enum Kink {


    
}




public class Personagem_dados_sistema {

    public bool personagem_apresentado = false ;
    public bool personagem_em_foco = false ;

    /*
        mostra o quanto o player esta demonstrando que esta interessado no personagem 
    */
    public int personagem_score_do_player = 0; 



    public Kink[] kinks_ativadas = null;


}


public class Personagem_generico {


    public Personagem_generico( Personagem_nome _personagem_nome ) {


     
            /*
                vai ficar responsavel por pegar os dados estaticos e cosntruir o personagem.
            */

            this.personagem_nome = _personagem_nome;

            string path_stats = Paths.Pegar_path_dados_personagem( _personagem_nome.ToString() );

            
            if(  !( System.IO.File.Exists( path_stats ) )  ){

                // criar arquivo

            }

    }

    public Personagem_nome personagem_nome;

    public Pegar_dados_personagem_plataforma_del Pegar_dados_personagem_plataforma; 

    


}



public delegate Player Pegar_dados_personagem_plataforma_del(); 
public class Player{}



public class Personagem_especifico_construtor {

    // essa classe só faria sentido para passar actions ou delegados especificos 


    // ** movimento é especifico 
    //     
    // 

    // ** conceito : pode ter sempre 2 modelos de update, 1 deles é bem generico e é mais simples de fazer. as informacoes vao sempre serem importadas na dll principal 
    // mas se o player interagir mais com o personagem pode ter uma segunda dll com infomracoes mais precisas referentes a tudo que for especifico 


    public Personagem_generico Construir(){


        /*

            vai ficar responsavel por pegar os dados estaticos e cosntruir o personagem.

        */


        Personagem_generico personagem_retorno = new Personagem_generico( Personagem_nome.Lily );

        return personagem_retorno;




    }








}


public static class Paths {

    public static string Pegar_path_dados_personagem( string _nome_personagem ){

        return "path/" + _nome_personagem.ToString();

    }

}