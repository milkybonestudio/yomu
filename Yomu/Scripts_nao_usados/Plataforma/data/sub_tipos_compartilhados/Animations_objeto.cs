using UnityEngine;
using System;
using UnityEngine.UI;



public class Animation{
     


     public int animation_id;

     public bool have_repetition;

     public Sprite[] sprite_arr;

     public int[] frames_for_next_sprite;

     


}


public class Animations_object{


     public int id;
     public Tipo_objeto tipo;


     public Animations_object(int _id, Tipo_objeto _tipo){

          id = _id;
          tipo = _tipo;

     }


     public Animation[] animations_arr;

     public int[] animations_direction;
     public int[] repeticao_ponto_loop = new int[30];

     public Image imagem_slot;
     public Transform transform;

     
     public Animation animacao_atual;

     public int animacao_atual_id = 0;
     public int proxima_animacao = 0;

     public int animacao_default_id = 0;

     public int frame_atual_entre_sprites = 0;
     public int sprite_atual = 0;

     public bool tem_animacao = false;





     public void Update(){


          if( !tem_animacao ) return;

          if(animacao_atual_id != proxima_animacao ){

               
               if(animations_direction != null){

                              // flipa
                         if(    animations_direction[proxima_animacao] == 1 && transform?.localScale[0] == 1f) {

                              transform.localScale = new Vector3(-1f , 1f, 1f);
                              
                         }
                         else if( animations_direction[proxima_animacao] == 0 && transform?.localScale[0] == -1f) {     
                              
                               transform.localScale = new Vector3(1f , 1f, 1f); 
                               
                         }

               }


               animacao_atual_id = proxima_animacao;
               animacao_atual = animations_arr[proxima_animacao];
               imagem_slot.sprite =  animacao_atual.sprite_arr[0];
               frame_atual_entre_sprites = 0;
               sprite_atual = repeticao_ponto_loop[proxima_animacao];
               return;
          }

          if(animacao_atual.frames_for_next_sprite[sprite_atual]   ==  frame_atual_entre_sprites    ) {

               sprite_atual++;

                  if( (sprite_atual) == animacao_atual.sprite_arr.Length ){
                            
                             frame_atual_entre_sprites = 1;

                              if(animacao_atual.have_repetition){

                                   if(repeticao_ponto_loop != null ){

                                        sprite_atual  = repeticao_ponto_loop[animacao_atual_id];                                        

                                   } else {

                                        sprite_atual = 0;

                                   }

                                   imagem_slot.sprite = animacao_atual.sprite_arr[   sprite_atual   ];
                                   return;

                              }
                         
                              animacao_atual = animations_arr[  animacao_default_id ];
                              animacao_atual_id = animacao_default_id;
                              imagem_slot.sprite = animacao_atual.sprite_arr[0];
                              return;

                    }
                   
                    imagem_slot.sprite = animacao_atual.sprite_arr[sprite_atual];
                    frame_atual_entre_sprites = 1;         
                    return;

          }

           frame_atual_entre_sprites++;
           return;
          
     }

}


