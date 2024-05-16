using UnityEngine;
using System;



public class Controlador_camera {




      
    public static Controlador_camera instancia;
    public static Controlador_camera Pegar_instancia( bool _forcar = false  ){

            if( _forcar ) {if( Verificador_instancias_nulas.Verificar_se_pode_criar_objetos("Controlador_camera_)bloco_plataforma")) { instancia = new Controlador_camera();instancia.Iniciar();} return instancia;}
            if(  instancia == null) { instancia = new Controlador_camera(); instancia.Iniciar(); }
            return instancia;

    }







public BLOCO_plataforma plataforma;




public bool is_seguindo_player = true;

public float x_position_camera = 0f;
public float y_position_camera = 0f;

public float speed_prox_x = 0.0167f;
public float speed_prox_y =0.0167f;
public float distancia_maxima = 300f;
public int time_count = 0;

public void Iniciar(){

    plataforma = BLOCO_plataforma.Pegar_instancia();


}

public void Mover_camera(float _novo_x, float _novo_y){



    

    if( _novo_x + x_position_camera  > 500f ) {

        x_position_camera =  - _novo_x +  500f;

    } else if(   -(_novo_x + x_position_camera ) > 500f    ){
       
       x_position_camera =  - _novo_x  -  500f;

    }
    
    else {


        x_position_camera =  x_position_camera  -  ((  _novo_x + x_position_camera  ) * 0.02f);

    }





  if( _novo_y + y_position_camera  > 300f ) {

        y_position_camera =  - _novo_y +  300f;

    } else if(   -(_novo_y + y_position_camera ) > 300f    ){
       
       y_position_camera =  - _novo_y  -  300f;

    }
    
    else {


        y_position_camera =  y_position_camera  -  ((  _novo_y + y_position_camera  ) * 0.02f);



    }


    


    plataforma.world.transform.localPosition = new Vector3(  x_position_camera, y_position_camera, 0f);
    
    return;

    


   
     



}




public void Seguir_player(){

     if(!is_seguindo_player) return;




     float new_x = plataforma.controlador_player.player_container_transform.localPosition[0];
     float new_y = plataforma.controlador_player.player_container_transform.localPosition[1];

     if(new_x == x_position_camera &&   new_y == y_position_camera ){
        
        time_count = 0;
        
        return;

     }
      
      float d_x =  new_x - x_position_camera ;
      float d_y =  new_y - y_position_camera ;
      float distancia_player =  200f;

     if(          (   (d_x * d_x )  +  (d_y * d_y)  > distancia_player * distancia_player )   || time_count > 15  || true){

        Mover_camera(new_x, new_y);
        return;
        

     }

     time_count++;
     return;
   

    


}



}




