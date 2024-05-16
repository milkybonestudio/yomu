using UnityEngine;
using UnityEngine.UI;

using System;


public class Skill {


      

      public static Sprite sprite_default = Resources.Load<Sprite>("images/plataforma/utilidade_geral/teste_skill");

      public string descricao = ""; 

      public Player player;

      public Sprite sprite_icone = Skill.sprite_default;


      public Action verifiar_mudanca;


      public bool can_cast;
      public bool cooldown;



      public float tempo_atual;
      public float tempo_recarga;


      public float mana_requisito;


      //public Action cast = () => {};


      


      public void Passar_tempo(){
          

            tempo_atual -= 0.0167f;

            // mudar_animacao();

            if(tempo_atual < 0f) {

                cooldown = false;
                
            }


      }
      
      
}