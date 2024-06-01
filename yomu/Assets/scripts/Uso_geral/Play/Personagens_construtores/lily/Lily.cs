using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Lily{

   


    // public Player player;
    // public Dados_combate dados_combate;

    public Relacoes relacoes;

    public Lily_data data;

    public Lily_scripts scripts;
    
    public Lily(){

        

        scripts = new Lily_scripts();
        data = new Lily_data();

        relacoes = new Relacoes();
        relacoes.sara = new Stats_relacionamento();


        relacoes.sara.tesao = 100f;
        relacoes.sara.amizade = 200f;
        relacoes.sara.amor = 100f;
        relacoes.sara.odio = 0f;
        

     
    }





   
    

 

}






