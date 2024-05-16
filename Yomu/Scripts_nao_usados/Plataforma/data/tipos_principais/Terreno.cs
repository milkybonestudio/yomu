using UnityEngine;
using UnityEngine.UI;
using System;





public class Terreno {




   

    public int id;
    
     
    public string object_name;
    
    public GameObject terreno_game_object;


    public Image image;




    public Stats_objeto stats;

    public Fisica_objeto fisica;

    public Animations_object animations;




    public Action<Terreno> Update_AI;




    public Terreno(  int _id  ){


        object_name = "Terreno_" + Convert.ToString(_id);

        terreno_game_object = new GameObject( object_name );

        image = terreno_game_object.AddComponent<Image>();

        fisica = new Fisica_objeto(_id, Tipo_objeto.terreno);

        animations = new Animations_object(_id, Tipo_objeto.terreno);

        stats = new Stats_objeto(_id, Tipo_objeto.terreno);

        id = _id;




        
    }





}




