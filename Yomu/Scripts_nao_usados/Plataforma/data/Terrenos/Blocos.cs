using UnityEngine;
using UnityEngine.UI;
using System;



public static class BLOCOS{



    public static void bloco_simples(Terreno _terreno  ,  float _position_x, float _position_y, string _args){




            string[] args = _args.Split(",");

        

            float width = Convert.ToSingle(  args[0]  );
            float height = Convert.ToSingle(  args[1]  );


            _terreno.fisica.Setar_size_AND_position(_position_x , _position_y , width , height);

            _terreno.image = _terreno.terreno_game_object.GetComponent<Image>();

            
        
            if(args.Length > 5 ){

                float c_1 = Convert.ToSingle( args[2] ) / 100f ;
                float c_2 = Convert.ToSingle( args[3] ) / 100f ;
                float c_3 = Convert.ToSingle( args[4] ) / 100f ;
                float c_4 = Convert.ToSingle( args[5] ) / 100f;

                _terreno.image.color = new Color(  c_1 ,c_2 ,c_3,c_4  );





            } else {

                _terreno.image.color = Color.black;
            }

            

            return;
            

    }






   


}