using UnityEngine;
using System;










public enum Player_default_keys{
       
       parado_frente = 0,

       parado_direita = 1,
       parado_esquerda = 2,


       andando_direita = 3,
       andando_esquerda = 4,

       pulando_frente = 5,
       pulando_direita = 6, 
       pulando_esquerda = 7,

       caindo_frente = 8,
       caindo_direita = 9,
       caindo_esquerda = 10,

       agachado_direita = 11,
       agachado_esquerda = 12,

       andando_agachado_direita = 13,
       andando_agachado_esquerda = 14,

       subindo = 15,
       descendo = 16,

       death = 17,

}


public static class Teclado_default{



 public static void Aplicar_jump(Player player){
              

            //if(  Input.GetKeyDown(KeyCode.UpArrow) && player.stats.jumps_possiveis_atuais > 0 ){
            if(  Controlador_input.Get_down( Key_code.up_arrow ) && player.stats.jumps_possiveis_atuais > 0 ){

                  player.stats.jumps_possiveis_atuais--;

                //player.fisica.vectors_speed[1] += 18f;
                  player.fisica.vectors_speed[1] = player.stats.jump_altura;
                //Debug.Log(player.fisica.vectors_speed[1]);

            }

      }


 public static void Aplicar_left_right(Player player){

 
            //if(    Input.GetKey( KeyCode.LeftArrow )    &&    Input.GetKey( KeyCode.RightArrow )    ){
            if(    Controlador_input.Get( Key_code.left_arrow )    &&    Controlador_input.Get( Key_code.right_arrow )    ){
      
                  if(  player.is_right_AND_left  ){

                           //  ta caindo;
                       if(  player.fisica.vectors_speed[1] <= 0f  && -player.fisica.vectors_speed[1] > 0.6f  ){

                                    // ta indo para a esquerda
                              if(   player.fisica.vectors_speed[0] <= 0f  && -player.fisica.vectors_speed[0] > 0.6f   ) {

                                    player.animations.proxima_animacao  = (int)Player_default_keys.caindo_esquerda;

                                    //  ta indo para a direita
                              } else if(  player.fisica.vectors_speed[0] >= 0f  &&  player.fisica.vectors_speed[0] > 0.6f  ){

                                    player.animations.proxima_animacao  = (int)Player_default_keys.caindo_direita;

                                    //  esta centrado
                              } else {
                                     
                                    player.animations.proxima_animacao  = (int)Player_default_keys.caindo_frente;
                                       
                                 }


                              // ta subindo
                       } else if(player.fisica.vectors_speed[1] >= 0f  /*&&  player.fisica.vectors_speed[1] > 0.6f  */ ){


                                  // ta indo para a esquerda
                                 if(   player.fisica.vectors_speed[0] <= 0f  && -player.fisica.vectors_speed[0] > 0.6f   ) {

                                       player.animations.proxima_animacao  = (int)Player_default_keys.pulando_direita;


                                    //  ta indo para a direita
                                 } else if(  player.fisica.vectors_speed[0] >= 0f  &&  player.fisica.vectors_speed[0] > 0.6f ){

                                       player.animations.proxima_animacao  = (int)Player_default_keys.pulando_esquerda;


                                    //  esta centrado
                                 } else {

                                       player.animations.proxima_animacao  = (int)Player_default_keys.pulando_frente;

                                 }

                           // esta em algo fixo
                       } else {
                                                     
                         // ta indo para a esquerda
                                 if(   player.fisica.vectors_speed[0] <= 0f  && -player.fisica.vectors_speed[0] > 0.6f   ) {

                                       player.animations.proxima_animacao  = (int) Player_default_keys.andando_direita;

                                    //  ta indo para a direita
                                 } else if(  player.fisica.vectors_speed[0] >= 0f  &&  player.fisica.vectors_speed[0] > 0.6f ){

                                       player.animations.proxima_animacao  = (int)Player_default_keys.andando_esquerda;

                                    //  esta centrado
                                 } else {

                                       player.animations.proxima_animacao  = (int)Player_default_keys.parado_frente;

                                 }
                            
                       }
                     
                       return;
                  } 


                  /*
                  *
                  *    mudar animacao + calcular speed 
                  *    vai usar right_is_activate e left_isActivate para calcular a velocidade e depois eles são dados como false, 
                  *    para quando o player soltar o botão ele calcular como se tivesse cliclado novamente
                  *   
                  */
                  

                  // direita ativada => agora ativar esquerda
                  // logica: o objetivo aqui é deixar o mais proximo de 0, se o player já esta indo 
                  // para a esquerda dar mais velocidade ia parecer que o player deu um pulo;
                  if(player.right_is_active ){ 
                      
                        if(   player.fisica.vectors_speed[0]    <=  0f     ){

                              player.is_right_AND_left = true;
                              player.right_is_active = false; 
                              player.left_is_active = false;
                              return;
                        }
                     
                        player.fisica.vectors_speed[0]  -=  player.stats.movimentation_speed;

                        if(  Mathf.Abs(player.fisica.vectors_speed[0] ) < player.stats.movimentation_speed  ) {

                              player.fisica.vectors_speed[0] = 0f;

                        }
                     
                  }


                  // esquerda ativada => agora ativar direita
                  if(player.left_is_active ){ 

                        if(   player.fisica.vectors_speed[0]    >=  0f     ){

                              player.is_right_AND_left = true;
                              player.right_is_active = false; 
                              player.left_is_active = false;
                              return;
                        }

                     player.fisica.vectors_speed[0]  +=  player.stats.movimentation_speed;


                     if(  Mathf.Abs(player.fisica.vectors_speed[0] )   < player.stats.movimentation_speed  ) {

                           player.fisica.vectors_speed[0] = 0f;

                     }

                     
                  }


                  player.is_right_AND_left = true;
                  player.right_is_active = false; 
                  player.left_is_active = false;

                  return;
       
            }
 
    
            if(Controlador_input.Get( Key_code.left_arrow ) )  {


               // sempre vai tender para a velocidade 
                  if(player.left_is_active){

                        if(player.fisica.vectors_speed[1] < 0f &&   -player.fisica.vectors_speed[1] > 0.6f ){

                              // ta caindo 
                              player.animations.proxima_animacao  = (int)Player_default_keys.caindo_esquerda;

                        } else if(player.fisica.vectors_speed[1] > 0f &&  player.fisica.vectors_speed[1] > 0.6f){

                             // ta subindo
                             player.animations.proxima_animacao  = (int)Player_default_keys.pulando_esquerda;

                        } else {

                               //  ta centradp
                             player.animations.proxima_animacao  = (int)Player_default_keys.andando_esquerda;

                        }

                        if(player.fisica.vectors_speed[0]  >   -player.stats.movimentation_speed  ){

                               //testar
                              player.fisica.vectors_acc[0] -= player.stats.movimentation_speed/10f;

                        }

                        return;

                  } 

                  // animation change
  
                  player.animations.proxima_animacao  = (int)Player_default_keys.andando_esquerda;
  
                   //********

                  player.fisica.vectors_speed[0]  -=  player.stats.movimentation_speed;
                  player.left_is_active = true;
                  player.is_right_AND_left = false;



                  if(player.right_is_active ){  
         
                        player.fisica.vectors_speed[0]  -=  player.stats.movimentation_speed;
                        player.right_is_active = false;
         
                  }


                    //   se mover para a direita e consegue mover o personagem para a direita ele sempre completa com 100%
                    // vai ser interessante para gravidades verticais
                 if(  -player.fisica.vectors_speed[0] > 0f  &&   -player.fisica.vectors_speed[0] < player.stats.movimentation_speed   ) {

                        player.fisica.vectors_speed[0] = -player.stats.movimentation_speed   ;

                  }

                  return;

            };

   
            if( Controlador_input.Get( Key_code.right_arrow )  )  {

                  if(player.right_is_active){
        
                        if(player.fisica.vectors_speed[1] < 0f &&   -player.fisica.vectors_speed[1] > 0.6f ){
                              // ta caindo

                              player.animations.proxima_animacao  = (int)Player_default_keys.caindo_direita;

                        } else if(player.fisica.vectors_speed[1] > 0f &&  player.fisica.vectors_speed[1] > 0.6f){
 
                              // ta subindo

                              player.animations.proxima_animacao  = (int)Player_default_keys.pulando_direita;

                        }

                        else {
                               //  ta centradp
                              player.animations.proxima_animacao  = (int)Player_default_keys.andando_direita;

                        }

                        if(player.fisica.vectors_speed[0]  <   player.stats.movimentation_speed  ){

                             //testar
                              player.fisica.vectors_acc[0] += player.stats.movimentation_speed/10f ;

                        }
            
                        return;

                  } 

                      // animation change

                  player.animations.proxima_animacao = (int) Player_default_keys.andando_direita;


                   //*********


                  player.fisica.vectors_speed[0]  +=  player.stats.movimentation_speed;
                  player.right_is_active = true;  
                  player.is_right_AND_left = false;

                  if(player.left_is_active ){

                        player.fisica.vectors_speed[0]  +=  player.stats.movimentation_speed;
                        player.left_is_active = false; 
         
                 } 



                  if(  player.fisica.vectors_speed[0] > 0f  &&   player.fisica.vectors_speed[0] < player.stats.movimentation_speed   ) {

                        player.fisica.vectors_speed[0] = player.stats.movimentation_speed   ;
 
                  }

                  return;


            };




                                          // animacao parado

               //  ta caindo;
               
            if(  player.fisica.vectors_speed[1] <= 0f  && -player.fisica.vectors_speed[1] > 0.6f  ){

                                    // ta indo para a esquerda
                  if(   player.fisica.vectors_speed[0] <= 0f  && -player.fisica.vectors_speed[0] > 0.6f   ) {

                        player.animations.proxima_animacao  = (int)Player_default_keys.caindo_esquerda;

                                    //  ta indo para a direita
                  } else if(  player.fisica.vectors_speed[0] >= 0f  &&  player.fisica.vectors_speed[0] > 0.6f    ){

                        player.animations.proxima_animacao  = (int)Player_default_keys.caindo_direita;

                                    //  esta centrado
                  } else {
                                     
                        player.animations.proxima_animacao  = (int)Player_default_keys.caindo_frente;
                                       
                  }


            // ta subindo
            } else if(player.fisica.vectors_speed[1] >= 0f  /*&&  player.fisica.vectors_speed[1] > 0.6f  */ ){

                         // ta indo para a esquerda
                  if(   player.fisica.vectors_speed[0] <= 0f  && -player.fisica.vectors_speed[0] > 0.6f   ) {

                        player.animations.proxima_animacao  = (int)Player_default_keys.pulando_direita;

                                    //  ta indo para a direita
                  } else if(  player.fisica.vectors_speed[0] >= 0f  &&  player.fisica.vectors_speed[0] > 0.6f    ){

                        player.animations.proxima_animacao  = (int)Player_default_keys.pulando_esquerda;

                                    //  esta centrado
                  } else {

                        player.animations.proxima_animacao  = (int)Player_default_keys.pulando_frente;

                  }

                           // esta em algo fixo
            } else {
                     
                         // ta indo para a esquerda
                  if(   player.fisica.vectors_speed[0] <= 0f  && -player.fisica.vectors_speed[0] > 0.6f   ) {

                              player.animations.proxima_animacao  = (int)Player_default_keys.andando_direita;

                                    //  ta indo para a direita
                  } else if(  player.fisica.vectors_speed[0] >= 0f  &&  player.fisica.vectors_speed[0] > 0.6f    ){

                        player.animations.proxima_animacao  = (int)Player_default_keys.andando_esquerda;

                                    //  esta centrado
                  } else {

                        player.animations.proxima_animacao  = (int)Player_default_keys.parado_frente;

                  }
                            
            }

                      

            if ( !player.right_is_active  && !player.left_is_active  && !player.is_right_AND_left  ) return;

            if(player.is_right_AND_left ) {
                        
                        //  ?
                  if(    Mathf.Abs(player.fisica.vectors_speed[0] )  < player.stats.movimentation_speed ) {

                        player.fisica.vectors_speed[0] = 0f; 

                  }

                  player.is_right_AND_left = false;

                  return;

            }
    

             // calcular soltar

 

            if(player.right_is_active ){
      
                  player.fisica.vectors_speed[0]  -=  player.stats.movimentation_speed;

            }

            if(player.left_is_active ){ 
      
                  player.fisica.vectors_speed[0]  +=  player.stats.movimentation_speed;
      
            }


            if(    Mathf.Abs(player.fisica.vectors_speed[0] )  <= player.stats.movimentation_speed ) {
      
                  player.fisica.vectors_speed[0] = 0f; 
      
            }

     
            player.right_is_active = false;
            player.left_is_active = false;
            player.is_right_AND_left = false;


            return;

            

      }
























}




