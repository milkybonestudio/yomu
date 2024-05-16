using UnityEngine;
using System;



public static class Fisica_plataforma{

  //                      px/segundo2
  
  public static     float gravidade_horizontal   =    -25f;

  public static     float gravidade_vertical     =      0f;

  //public static     float speed_maxima_gravidade =    100f;
 
  public static     float speed_maxima           =   125f;

  public static     float fps_factor             = 0.0167f;

   
     public static void Update_fisica(BLOCO_plataforma _plataforma){


           
         for(  int pr = 0 ;  pr < _plataforma.projeteis_arr.Length  ; pr++    ){


            if( _plataforma.projeteis_arr[ pr ] == null ) continue;
            if( !_plataforma.projeteis_arr[ pr ].fisica_afeta) continue;

            Aplicar_gravidade(_plataforma.projeteis_arr[ pr ].fisica.vectors_acc);
            Aplicar_aceleracao(_plataforma.projeteis_arr[ pr ].fisica);


         }

          for(  int mob = 0 ;  mob < _plataforma.mobs_in_world.Length  ; mob++    ){

            if(_plataforma.mobs_in_world[ mob ].stats.is_inativo) continue;
            if(_plataforma.mobs_in_world[ mob ].stats.is_destruido) continue;

               Aplicar_gravidade(_plataforma.mobs_in_world[ mob ].fisica.vectors_acc);
               Aplicar_aceleracao(_plataforma.mobs_in_world[ mob ].fisica);


         }


           for(  int terreno = 0 ;  terreno < _plataforma.terrenos_in_world.Length  ; terreno++    ){

            if(_plataforma.terrenos_in_world[ terreno ].fisica.mov_type == mov_type.fixo) continue;

            if(_plataforma.terrenos_in_world[terreno].stats.is_inativo) continue;
            if(_plataforma.terrenos_in_world[terreno].stats.is_destruido) continue;

               Aplicar_gravidade(_plataforma.terrenos_in_world[terreno].fisica.vectors_acc);
               Aplicar_aceleracao(_plataforma.terrenos_in_world[terreno].fisica);


         }




         Aplicar_gravidade(_plataforma.controlador_player.player_atual.fisica.vectors_acc);
         
         Aplicar_aceleracao(_plataforma.controlador_player.player_atual.fisica);


        return;

     }






     public static void Update_velocidade(BLOCO_plataforma  _plataforma){


       for(  int pr = 0 ;  pr < _plataforma.projeteis_arr.Length  ; pr++    ){

            if( _plataforma.projeteis_arr[pr] == null ) continue;


            //if(!_plataforma.projeteis_arr[pr].fisica_afeta) continue;

            Aplicar_velocidade(_plataforma.projeteis_arr[pr].fisica);
           


         }

          for(  int mob = 0 ;  mob < _plataforma.mobs_in_world.Length  ; mob++    ){

            if(_plataforma.mobs_in_world[ mob ].stats.is_inativo) continue;
            if(_plataforma.mobs_in_world[ mob ].stats.is_destruido) continue;

               Aplicar_velocidade(_plataforma.mobs_in_world[ mob ].fisica);
               // Debug.Log("position mob: " + _plataforma.mobs_in_world[ mob ].fisica.position[0]);
               // Debug.Log("velocidade_mob: " + _plataforma.mobs_in_world[ mob ].fisica.vectors_speed[0]);
               


         }

         
          for(  int terreno = 0 ;  terreno < _plataforma.terrenos_in_world.Length  ; terreno++    ){


            if(_plataforma.terrenos_in_world[ terreno ].fisica.mov_type == mov_type.fixo) continue;

            if(_plataforma.terrenos_in_world[ terreno ].stats.is_inativo) continue;
            if(_plataforma.terrenos_in_world[ terreno ].stats.is_destruido) continue;

               Aplicar_velocidade(_plataforma.terrenos_in_world[ terreno ].fisica);
               


         }





         Aplicar_velocidade(_plataforma.controlador_player.player_atual.fisica);
         


        return;



     }




     public static void Update_movimento(BLOCO_plataforma  _plataforma){





         for(  int pr = 0 ;  pr < _plataforma.projeteis_arr.Length  ; pr++    ){

            if( _plataforma.projeteis_arr[pr] == null ) continue;


            //if(!_plataforma.projeteis_arr[pr].fisica_afeta) continue;

            Aplicar_movimento(_plataforma.projeteis_arr[pr].fisica  , _plataforma.projeteis_arr[pr].projetil_game_object.transform );
           


         }

          for(  int mob = 0 ;  mob < _plataforma.mobs_in_world.Length  ; mob++    ){

            if(_plataforma.mobs_in_world[ mob ].stats.is_inativo) continue;
            if(_plataforma.mobs_in_world[ mob ].stats.is_destruido) continue;

               Aplicar_movimento(_plataforma.mobs_in_world[ mob ].fisica , _plataforma.mobs_in_world[ mob ].mob_game_object.transform );
               

         }



           for(  int terreno = 0 ;  terreno < _plataforma.terrenos_in_world.Length  ; terreno++    ){

            if(_plataforma.terrenos_in_world[ terreno ].fisica.mov_type == mov_type.fixo) continue;
            

            if(_plataforma.terrenos_in_world[ terreno ].stats.is_inativo) continue;
            if(_plataforma.terrenos_in_world[ terreno ].stats.is_destruido) continue;

            

               Aplicar_movimento(_plataforma.terrenos_in_world[ terreno ].fisica , _plataforma.terrenos_in_world[terreno].terreno_game_object.transform );
               


         }


         
 
         Aplicar_movimento(_plataforma.controlador_player.player_atual.fisica , _plataforma.controlador_player.player_container_transform );
         


        return;





     }



     public static void Aplicar_movimento(Fisica_objeto _fisica  ,  Transform _transform){

      

               if(_fisica.tipo == Tipo_objeto.terreno){
                  

                  Debug.Log(_fisica.position[1]);
                  Debug.Log(_fisica.project_position[1]);
                  
               }
               
               _fisica.position[0] =  _fisica.project_position[0];
               _fisica.position[1] =  _fisica.project_position[1];


 
               

               _fisica.pontos = Mat.Transformar_dados_em_pontos(_fisica.position,  _fisica.dimensions);


               _transform.localPosition = new Vector3(   _fisica.position[0], _fisica.position[1], 0f);
               //_transform.localPosition = new Vector3(   0f, 0f, 0f);

               _fisica.speed_collision_multiplier[0] = 1f;
               _fisica.speed_collision_multiplier[1] = 1f;



     }



     public static void Aplicar_velocidade(Fisica_objeto _fisica){

            _fisica.project_position[0] =  _fisica.position[0] +     _fisica.vectors_speed[0]  ; 
            _fisica.project_position[1] =  _fisica.position[1] +     _fisica.vectors_speed[1]  ;
       
            _fisica.project_pontos = Mat.Transformar_dados_em_pontos(_fisica.project_position,  _fisica.dimensions);
     }



     public static void Aplicar_gravidade(float[] _vec){


        _vec[1]  += gravidade_horizontal * fps_factor;
        _vec[0]  += gravidade_vertical * fps_factor;

        return;


     }



     public static void Aplicar_aceleracao( Fisica_objeto _fisica ) {

     
        
       
       
        float acc_h = _fisica.vectors_acc[0];
        float acc_v = _fisica.vectors_acc[1];

        float nova_speed_h = _fisica.vectors_speed[0] + acc_h ;
        float nova_speed_v = _fisica.vectors_speed[1] + acc_v ;

        float absolute = Mathf.Sqrt(     (nova_speed_h * nova_speed_h )  +    (nova_speed_v * nova_speed_v  )   );

        



        if(absolute > speed_maxima){

           // Debug.Log("speed maxima alcançada, speed: " + absolute );

            float a = speed_maxima / absolute;

            nova_speed_h *= a;
            nova_speed_v *= a;


        }

    //   Debug.Log("speed: " + absolute );

        _fisica.vectors_speed[0] = nova_speed_h;
        _fisica.vectors_speed[1]= nova_speed_v;

        _fisica.vectors_acc[0] = 0f;
        _fisica.vectors_acc[1]= 0f;
        

        return;


     }



 



}


