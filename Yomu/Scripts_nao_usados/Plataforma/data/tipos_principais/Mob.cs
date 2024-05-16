using UnityEngine;
using UnityEngine.UI;
using System;






public class Mob {




    public Animations_object animations;

    public Fisica_objeto fisica;

    public Stats_objeto stats;



    public Controlador_player controlador_player;


  
    public int id;
     
    public string object_name;

    public GameObject mob_game_object;

    public Image image;

    public Drop_objeto drops;






    public int[] AI_int_arr;
    public float[] AI_float_arr;


    public Action<Mob> Update_AI;





    public Mob(int _id){


      object_name = "Mob_" +  Convert.ToString(_id);

      mob_game_object = new GameObject(object_name);


      controlador_player = BLOCO_plataforma.Pegar_instancia().controlador_player;

      fisica = new Fisica_objeto(_id, Tipo_objeto.mob);

      stats  = new Stats_objeto(_id, Tipo_objeto.mob);

      animations  =new Animations_object(_id, Tipo_objeto.mob);

      drops = new Drop_objeto();


      fisica.conteudo = conteudo.fluido;
      fisica.mov_type = mov_type.movel;
      id = _id;

     


    }




 

}




