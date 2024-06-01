using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Jayden{

    


    // public Player player;
    // public Dados_combate dados_combate;

    public Relacoes relacoes;

    public Jayden_data data;

    public Jayden_scripts scripts;
    
    public Jayden(){

        

        scripts = new Jayden_scripts();
        data = new Jayden_data();

        relacoes = new Relacoes();
        relacoes.sara = new Stats_relacionamento();


        relacoes.sara.tesao = 500f;
        relacoes.sara.amizade = 400f;
        relacoes.sara.amor = 250f;
        relacoes.sara.odio = 0f;
        

     
    }





   
    

 

}






