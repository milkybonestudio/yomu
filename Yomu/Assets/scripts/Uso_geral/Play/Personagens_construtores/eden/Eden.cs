using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Eden{

    


    // public Player player;
    // public Dados_combate dados_combate;

    public Relacoes relacoes;

    public Eden_data data;

    public Eden_scripts scripts;
    
    public Eden(){

        

        scripts = new Eden_scripts();
        data = new Eden_data();

        relacoes = new Relacoes();
        relacoes.sara = new Stats_relacionamento();


        relacoes.sara.tesao = 500f;
        relacoes.sara.amizade = 400f;
        relacoes.sara.amor = 250f;
        relacoes.sara.odio = 0f;
        

     
    }





   
    

 

}






