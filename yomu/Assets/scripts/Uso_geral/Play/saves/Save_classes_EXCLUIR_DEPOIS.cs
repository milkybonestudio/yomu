
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;





public class Lista_personagens_save{

    public Personagem_save sara = new Personagem_save();
    public Personagem_save lily = new Personagem_save();
    public Personagem_save eden = new Personagem_save();
    public Personagem_save jayden = new Personagem_save();
    public Personagem_save dia = new Personagem_save();





}


public class Personagem_save{


   public Personagem_dados sara = new Personagem_dados();
    
    

    


}


public class Personagem_dados{
    
   public int[] Perguntas_respostas = new int[50]; 
  
   public Stats_relacionamento stats_relacionamento = new Stats_relacionamento();


}

