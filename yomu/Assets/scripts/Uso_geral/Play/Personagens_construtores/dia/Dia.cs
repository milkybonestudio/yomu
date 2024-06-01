using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class Dia{

    
 //   public Player player;

    public Generic_info plataforma_info;

    public Relacoes relacoes;

    public Dia_data data;

    public Dia_scripts scripts;


  //  public Conversa conversa;


    // class Conversa{


    //        public void Iniciar_conversa(){

    //          // so vai ter 1 personagem na tela
    //          // vai ter só 2 modelos, [mudar info] e [perguntas/respostas] 
             
    //          // fn() => dados conversa 

    //          // dia semana 
    //          // stats relacionamento
    //          // 

    //        }


    // }

    
    public Dia(){

        

        scripts = new Dia_scripts();
        data = new Dia_data();

        relacoes = new Relacoes();
        relacoes.sara = new Stats_relacionamento();


        relacoes.sara.tesao = 500f;
        relacoes.sara.amizade = 400f;
        relacoes.sara.amor = 250f;
        relacoes.sara.odio = 0f;
        

     
    }





   
    

 

}






