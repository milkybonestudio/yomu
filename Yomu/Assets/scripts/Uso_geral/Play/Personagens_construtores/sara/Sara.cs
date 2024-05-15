using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Sara{

    


    // public Player player;
    // public Dados_combate dados_combate;

    public Relacoes relacoes;

    public Sara_data data;

    public Sara_scripts scripts;
    
    public Sara(){

        

        scripts = new Sara_scripts();
        data = new Sara_data();

        relacoes = new Relacoes();
        relacoes.sara = new Stats_relacionamento();


        relacoes.sara.tesao = 500f;
        relacoes.sara.amizade = 400f;
        relacoes.sara.amor = 250f;
        relacoes.sara.odio = 0f;
        

     
    }





   
    

 

}






