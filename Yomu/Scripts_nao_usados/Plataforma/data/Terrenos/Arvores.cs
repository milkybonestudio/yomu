using UnityEngine;
using UnityEngine.UI;
using System;



public static class TERRENO_arvores{



    public static void Arvore_1(Terreno _terreno  ,  float _position_x, float _position_y){

        float width_image = 700f;
        float height_image = 1250f;
        
        float width = 50f;
        float height = 1250f;


       
       _terreno.fisica.Setar_size_AND_position(_position_x , _position_y , width , height, width_image, height_image );

       
       

        _terreno.image = _terreno.terreno_game_object.GetComponent<Image>();

        string path = "images/plataforma/terrenos/arvores/arvore_1_700_X_1250";

        _terreno.image.sprite = Resources.Load<Sprite>(path);

         if(_terreno.image.sprite == null) throw new ArgumentException(path);

        _terreno.image.color = Color.white;




       return;

    }



   


}