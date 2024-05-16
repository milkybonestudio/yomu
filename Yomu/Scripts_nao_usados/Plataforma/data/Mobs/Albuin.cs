using UnityEngine;
using UnityEngine.UI;
using System;





public  static class MOB_albuin{
        
        
        public static void Construir(Mob _mob , float _position_x  , float _position_y , string[] _args = null ){

  
                float width = 150f;
                float height = 150f;


                _mob.fisica.Setar_size_AND_position(_position_x , _position_y , width , height);
                _mob.stats.movimentation_speed = 17f;



                _mob.image = _mob.mob_game_object.AddComponent<Image>();
                _mob.image.sprite = Resources.Load<Sprite>("images/plataforma/terreno/grama/grama_01");

                _mob.image.color = Color.red;


                _mob.drops.drops_lista = new Itens_localizador[6];
                _mob.drops.drop_chances = new float[6];

                _mob.drops.drops_lista[0] = Itens_localizador.albuin_meat;
                _mob.drops.drop_chances[0] = 0.5f;

                _mob.drops.drops_lista[1] = Itens_localizador.albuin_skin ;
                _mob.drops.drop_chances[1] = 0.05f;

                _mob.drops.drops_lista[2] = Itens_localizador.albuin_bones ;
                _mob.drops.drop_chances[2] = 0.3f;

                _mob.drops.drops_lista[3] = Itens_localizador.albuin_eye ;
                _mob.drops.drop_chances[3] = 0.01f;

                _mob.drops.drops_lista[4] = Itens_localizador.female_albuin ;
                _mob.drops.drop_chances[4] = 0.002f;

                _mob.drops.drops_lista[5] = Itens_localizador.male_albuin ;
                _mob.drops.drop_chances[5] = 0.004f;


                

                _mob.Update_AI = AI;

                _mob.AI_int_arr = new int[4];






              
                 
                  _mob.animations.transform = _mob.mob_game_object.transform;

                  _mob.animations.tem_animacao = true;


                  

                  _mob.animations.imagem_slot  = _mob.mob_game_object.GetComponent<Image>();


                  _mob.animations.animacao_default_id = 0;
                  

                  _mob.animations.animations_arr = new Animation[25];
                  _mob.animations.animations_direction = new int[25];
                  _mob.animations.repeticao_ponto_loop = new int[25];


                  int numero_animation = 0;

                  int numero_sprites = 0;

                  int index = 0;


                  // andando direita

                  
                        numero_sprites = 5 ;
                        index = 0;
  

                        _mob.animations.animations_arr[ index ] = new Animation();
                        _mob.animations.animations_arr[ index ].animation_id = numero_animation;
                        _mob.animations.animations_arr[ index ].have_repetition = true;
                        _mob.animations.animations_arr[ index ].sprite_arr = new Sprite[numero_sprites];
                        _mob.animations.animations_arr[ index ].frames_for_next_sprite = new int[numero_sprites];



                        _mob.animations.animations_arr[ index ].sprite_arr[0] = Resources.Load<Sprite>("images/plataforma/mobs/albuin/female/andando/1");
                        _mob.animations.animations_arr[ index ].frames_for_next_sprite[0] = 7;

                        
                        _mob.animations.animations_arr[ index ].sprite_arr[1] = Resources.Load<Sprite>("images/plataforma/mobs/albuin/female/andando/2");
                        _mob.animations.animations_arr[ index ].frames_for_next_sprite[1] = 7;

                        
                        _mob.animations.animations_arr[ index ].sprite_arr[2] = Resources.Load<Sprite>("images/plataforma/mobs/albuin/female/andando/3");
                        _mob.animations.animations_arr[ index ].frames_for_next_sprite[2] = 7;

                        
                        _mob.animations.animations_arr[ index ].sprite_arr[3] = Resources.Load<Sprite>("images/plataforma/mobs/albuin/female/andando/4");
                        _mob.animations.animations_arr[ index ].frames_for_next_sprite[3] = 7;

                        
                        _mob.animations.animations_arr[ index ].sprite_arr[4] = Resources.Load<Sprite>("images/plataforma/mobs/albuin/female/andando/5");
                        _mob.animations.animations_arr[ index ].frames_for_next_sprite[4] = 7;

                        

                        

                        _mob.animations.animacao_atual = _mob.animations.animations_arr[_mob.animations.animacao_default_id];
                        _mob.animations.imagem_slot.sprite = _mob.animations.animacao_atual.sprite_arr[0];



   










                return;

        }


        public static void AI( Mob _mob ){
              

             float distancia = 1750f;

             float[] player_position =    _mob.controlador_player.player_atual.fisica.position;
             float[] mob_position =    _mob.fisica.position;

             _mob.stats.movimentation_speed += 0.002f;


             float[] final = new float[]{     (player_position[0] - mob_position[0])  ,   (player_position[1] - mob_position[1])    };

             if(   final[0] * final[0] + final[1] * final[1]  < distancia * distancia   ){

                        
                        
                        _mob.image.color = Color.white;

                        if(player_position[0] - mob_position[0] <= 0f) {

                                
                                if(   _mob.fisica.vectors_speed[0]   <  -_mob.stats.movimentation_speed  ) return;
                        
                             //   if(   _mob.fisica.vectors_speed[0]   > (-_mob.stats.movimentation_speed ) / 2f   &&      _mob.fisica.vectors_speed[0]  > 0f     ) { _mob.fisica.vectors_acc[0] = -(_mob.stats.movimentation_speed * 0.05f);  Debug.Log("bbbb") ;return;} 
                                //if(   _mob.fisica.vectors_speed[0]   > (-_mob.stats.movimentation_speed ) / 2f   ) {  _mob.fisica.vectors_speed[0] = (-_mob.stats.movimentation_speed ) / 2f ;  return;} 
                                

                                //_mob.fisica.vectors_speed[0] =  -_mob.stats.movimentation_speed;     

                                _mob.fisica.vectors_acc[0] = -(_mob.stats.movimentation_speed * 0.01f);


                        } else { 

                                if(   _mob.fisica.vectors_speed[0]   >  _mob.stats.movimentation_speed  ) { return;}
                                 
                               //  if(   _mob.fisica.vectors_speed[0]   < (_mob.stats.movimentation_speed ) / 2f  &&  _mob.fisica.vectors_speed[0]  < 0f    ) {  _mob.fisica.vectors_acc[0] = (_mob.stats.movimentation_speed * 0.05f);   Debug.Log("aAAAA") ;return;} 


                                
                                _mob.fisica.vectors_acc[0] = (_mob.stats.movimentation_speed * 0.01f);      
                        
                        //_mob.fisica.vectors_acc[0] = _mob.stats.movimentation_speed * 0.01f;
                        }
                        

                        
                        return;



             }


             _mob.fisica.vectors_speed[0] = 0f;


             _mob.image.color = Color.red;



                

 
                // if(_mob.AI_int_arr[0] == 0 ){

                //         _mob.AI_int_arr[1] += 1;

                //          _mob.fisica.vectors_speed[0] = 10f;

                //         if(_mob.AI_int_arr[1] == 100 ) {_mob.AI_int_arr[0] = 1;}

                //         if(_mob.AI_int_arr[1] == 20 ) _mob.fisica.vectors_speed[1] = 15f;

  
                // }  


                // else  if(_mob.AI_int_arr[0] == 1 ){

                //         _mob.AI_int_arr[1] -= 1;

                //          _mob.fisica.vectors_speed[0] = -10f;

                //         if(_mob.AI_int_arr[1] == 0 ) {_mob.AI_int_arr[0] = 0;}

                //         //if(_mob.AI_int_arr[1] == 20 ) _mob.fisica.vectors_speed[0] = 15f;

  
                // }

        
                return;

        }



}