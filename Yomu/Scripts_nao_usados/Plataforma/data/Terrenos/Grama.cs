using UnityEngine;
using UnityEngine.UI;
using System;



public static class TERRENO_grama{



    public static void Grama_01(Terreno _terreno  ,  float _position_x, float _position_y){

        float width = 2000f;
        float height = 90f;

       
       _terreno.fisica.Setar_size_AND_position(_position_x , _position_y , width , height);

       
       
       

        _terreno.image = _terreno.terreno_game_object.GetComponent<Image>();

        _terreno.image.sprite = Resources.Load<Sprite>("images/plataforma/terrenos/grama/bloco_terra_2000_X_90");

        _terreno.image.color = Color.white;




       return;


    }


     public static void Grama_02(Terreno _terreno  ,  float _position_x, float _position_y){

        float width = 200f;
        float height = 200f;

       


        _terreno.fisica.Setar_size_AND_position(_position_x , _position_y , width , height);

        _terreno.image = _terreno.terreno_game_object.GetComponent<Image>();

        _terreno.image.sprite = Resources.Load<Sprite>("images/plataforma/terrenos/grama/grama_01");



       return;


    }



   


}