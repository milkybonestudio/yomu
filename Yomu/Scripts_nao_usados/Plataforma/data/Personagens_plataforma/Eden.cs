using UnityEngine;
using UnityEngine.UI;
using System;




public enum Eden_animations_enum {
      parada_direita, 
      parada_esquerda,
      andando_direita,
      andando_esquerda,

}



public static class Eden_plataforma {




       public static void Construir(int _id){
            //Dados_combate dados =  Controlador.controlador.controlador_personagens.dia.dados_combate;
        
        // por hora os persoangens vao ser estaticos, mas depois as informacos especiais vao ser passadas pelo controlador
        // ex: player desbloqueou uma nova skill com a Dia. Não vai ser default

        Player _player = new Player(_id, "eden");




        //      default:
        Fisica_objeto fisica =  new Fisica_objeto(_id,  Tipo_objeto.player);

        //   largura
        fisica.dimensions[0] = 50f;

        //  altura
        fisica.dimensions[1] = 128f;


        fisica.mov_type = mov_type.movel;
         
        fisica.shape_type = 1;

        fisica.conteudo = conteudo.solido;






        Stats_objeto stats = new Stats_objeto(  _id,  Tipo_objeto.player);


        

        stats.tem_efeito_contato = false;

        stats.jumps_possiveis = 1;

        stats.jumps_possiveis_atuais = stats.jumps_possiveis;

        stats.movimentation_speed = 15f;

        stats.jump_altura = 18f;
        




       /*     *****          ANIMATION     ******       */


           
        Animations_object animations = new Animations_object(_id, Tipo_objeto.player);

        animations.imagem_slot  = _player.player_game_object.GetComponent<Image>();


        animations.animacao_default_id = (int) Player_default_keys.parado_frente;
        

        animations.animations_arr = new Animation[25];


        int numero_animation = 0;

        int numero_sprites = 0;

        int index = 0;

        










 //     ----------------    Dia  parado frente  -------------------------------
       


        
                numero_sprites = 1 ;
                index = (int) Player_default_keys.parado_frente;


                animations.animations_arr[ index ] = new Animation();
                animations.animations_arr[ index ].animation_id = numero_animation;
                animations.animations_arr[ index ].have_repetition = true;
                animations.animations_arr[ index ].sprite_arr = new Sprite[numero_sprites];
                animations.animations_arr[ index ].frames_for_next_sprite = new int[numero_sprites];



                animations.animations_arr[ index ].sprite_arr[0] = Resources.Load<Sprite>("images/plataforma/personagens/dia/parado_frente/1");
                animations.animations_arr[ index ].frames_for_next_sprite[0] = 1;

                

                



      // -----------------------------------------------------------------------------------
      // -----------------------------------------------------------------------------------











        
        //     ----------------    Dia parada direita  -------------------------------
       


        
                numero_sprites = 6 ;
                index = (int) Player_default_keys.parado_direita;


                animations.animations_arr[ index ] = new Animation();
                animations.animations_arr[ index ].animation_id = numero_animation;
                animations.animations_arr[ index ].have_repetition = true;
                animations.animations_arr[ index ].sprite_arr = new Sprite[numero_sprites];
                animations.animations_arr[ index ].frames_for_next_sprite = new int[numero_sprites];



                animations.animations_arr[ index ].sprite_arr[0] = Resources.Load<Sprite>("images/plataforma/personagens/dia/parada_direita/1");
                animations.animations_arr[ index ].frames_for_next_sprite[0] = 5;

                animations.animations_arr[ index ].sprite_arr[1] = Resources.Load<Sprite>("images/plataforma/personagens/dia/parada_direita/2");
                animations.animations_arr[ index ].frames_for_next_sprite[1] = 5;

                animations.animations_arr[ index ].sprite_arr[2] = Resources.Load<Sprite>("images/plataforma/personagens/dia/parada_direita/3");
                animations.animations_arr[ index ].frames_for_next_sprite[2] = 5;

                animations.animations_arr[ index ].sprite_arr[3] = Resources.Load<Sprite>("images/plataforma/personagens/dia/parada_direita/4");
                animations.animations_arr[ index ].frames_for_next_sprite[3] = 5;

                animations.animations_arr[ index ].sprite_arr[4] = animations.animations_arr[ index ].sprite_arr[2]  ;
                animations.animations_arr[ index ].frames_for_next_sprite[4] = 5;

                animations.animations_arr[ index ].sprite_arr[5] = animations.animations_arr[ index ].sprite_arr[1]  ;
                animations.animations_arr[ index ].frames_for_next_sprite[5] = 5;




      // -----------------------------------------------------------------------------------
      // -----------------------------------------------------------------------------------


   //     ----------------    Dia parada esquerda  -------------------------------
       


        
                numero_sprites = 6 ;
                index = (int) Player_default_keys.parado_esquerda;


                animations.animations_arr[ index ] = new Animation();
                animations.animations_arr[ index ].animation_id = numero_animation;
                animations.animations_arr[ index ].have_repetition = true;
                animations.animations_arr[ index ].sprite_arr = new Sprite[numero_sprites];
                animations.animations_arr[ index ].frames_for_next_sprite = new int[numero_sprites];



                animations.animations_arr[ index ].sprite_arr[0] = Resources.Load<Sprite>("images/plataforma/personagens/dia/parada_esquerda/1");
                animations.animations_arr[ index ].frames_for_next_sprite[0] = 5;

                animations.animations_arr[ index ].sprite_arr[1] = Resources.Load<Sprite>("images/plataforma/personagens/dia/parada_esquerda/2");
                animations.animations_arr[ index ].frames_for_next_sprite[1] = 5;

                animations.animations_arr[ index ].sprite_arr[2] = Resources.Load<Sprite>("images/plataforma/personagens/dia/parada_esquerda/3");
                animations.animations_arr[ index ].frames_for_next_sprite[2] = 5;

                animations.animations_arr[ index ].sprite_arr[3] = Resources.Load<Sprite>("images/plataforma/personagens/dia/parada_esquerda/4");
                animations.animations_arr[ index ].frames_for_next_sprite[3] = 5;

                animations.animations_arr[ index ].sprite_arr[4] = animations.animations_arr[ index ].sprite_arr[2]  ;
                animations.animations_arr[ index ].frames_for_next_sprite[4] = 5;

                animations.animations_arr[ index ].sprite_arr[5] = animations.animations_arr[ index ].sprite_arr[1]  ;
                animations.animations_arr[ index ].frames_for_next_sprite[5] = 5;




      // -----------------------------------------------------------------------------------
      // -----------------------------------------------------------------------------------

















 //     ----------------    Dia  andando direita  -------------------------------
       


        
                numero_sprites = 1 ;
                index = (int) Player_default_keys.andando_direita;


                animations.animations_arr[ index ] = new Animation();
                animations.animations_arr[ index ].animation_id = numero_animation;
                animations.animations_arr[ index ].have_repetition = true;
                animations.animations_arr[ index ].sprite_arr = new Sprite[numero_sprites];
                animations.animations_arr[ index ].frames_for_next_sprite = new int[numero_sprites];



                animations.animations_arr[ index ].sprite_arr[0] = Resources.Load<Sprite>("images/plataforma/personagens/dia/andando_direita/1");
                animations.animations_arr[ index ].frames_for_next_sprite[0] = 60;

                



      // -----------------------------------------------------------------------------------
      // -----------------------------------------------------------------------------------






 //     ----------------    Dia  andando esquerda  -------------------------------
       


        
                numero_sprites = 1 ;
                index = (int) Player_default_keys.andando_esquerda;


                animations.animations_arr[ index ] = new Animation();
                animations.animations_arr[ index ].animation_id = numero_animation;
                animations.animations_arr[ index ].have_repetition = true;
                animations.animations_arr[ index ].sprite_arr = new Sprite[numero_sprites];
                animations.animations_arr[ index ].frames_for_next_sprite = new int[numero_sprites];



                animations.animations_arr[ index ].sprite_arr[0] = Resources.Load<Sprite>("images/plataforma/personagens/dia/andando_esquerda/1");
                animations.animations_arr[ index ].frames_for_next_sprite[0] = 60;

                



      // -----------------------------------------------------------------------------------
      // -----------------------------------------------------------------------------------






 //     ----------------    Dia  andando esquerda  -------------------------------
       


        
                numero_sprites = 1 ;
                index = (int) Player_default_keys.pulando_frente;


                animations.animations_arr[ index ] = new Animation();
                animations.animations_arr[ index ].animation_id = numero_animation;
                animations.animations_arr[ index ].have_repetition = true;
                animations.animations_arr[ index ].sprite_arr = new Sprite[numero_sprites];
                animations.animations_arr[ index ].frames_for_next_sprite = new int[numero_sprites];



                animations.animations_arr[ index ].sprite_arr[0] = Resources.Load<Sprite>("images/plataforma/personagens/dia/pulando_frente/1");
                animations.animations_arr[ index ].frames_for_next_sprite[0] = 60;

                



      // -----------------------------------------------------------------------------------
      // -----------------------------------------------------------------------------------






 //     ----------------    Dia  pulando_direita  -------------------------------
       


        
                numero_sprites = 1 ;
                index = (int) Player_default_keys.pulando_direita;


                animations.animations_arr[ index ] = new Animation();
                animations.animations_arr[ index ].animation_id = numero_animation;
                animations.animations_arr[ index ].have_repetition = true;
                animations.animations_arr[ index ].sprite_arr = new Sprite[numero_sprites];
                animations.animations_arr[ index ].frames_for_next_sprite = new int[numero_sprites];



                animations.animations_arr[ index ].sprite_arr[0] = Resources.Load<Sprite>("images/plataforma/personagens/dia/pulando_direita/1");
                animations.animations_arr[ index ].frames_for_next_sprite[0] = 60;

                



      // -----------------------------------------------------------------------------------
      // -----------------------------------------------------------------------------------





 //     ----------------    Dia  pulando_esquerda  -------------------------------
       


        
                numero_sprites = 1 ;
                index = (int) Player_default_keys.pulando_esquerda;


                animations.animations_arr[ index ] = new Animation();
                animations.animations_arr[ index ].animation_id = numero_animation;
                animations.animations_arr[ index ].have_repetition = true;
                animations.animations_arr[ index ].sprite_arr = new Sprite[numero_sprites];
                animations.animations_arr[ index ].frames_for_next_sprite = new int[numero_sprites];



                animations.animations_arr[ index ].sprite_arr[0] = Resources.Load<Sprite>("images/plataforma/personagens/dia/pulando_esquerda/1");
                animations.animations_arr[ index ].frames_for_next_sprite[0] = 60;

                



      // -----------------------------------------------------------------------------------
      // -----------------------------------------------------------------------------------









//     ----------------    Dia  caindo_frente  -------------------------------
       


        
                numero_sprites = 1 ;
                index = (int) Player_default_keys.caindo_frente;


                animations.animations_arr[ index ] = new Animation();
                animations.animations_arr[ index ].animation_id = numero_animation;
                animations.animations_arr[ index ].have_repetition = true;
                animations.animations_arr[ index ].sprite_arr = new Sprite[numero_sprites];
                animations.animations_arr[ index ].frames_for_next_sprite = new int[numero_sprites];



                animations.animations_arr[ index ].sprite_arr[0] = Resources.Load<Sprite>("images/plataforma/personagens/dia/caindo_frente/1");
                animations.animations_arr[ index ].frames_for_next_sprite[0] = 60;

                



      // -----------------------------------------------------------------------------------
      // -----------------------------------------------------------------------------------


//     ----------------    Dia  caindo_direita -------------------------------
       


        
                numero_sprites = 1 ;
                index = (int) Player_default_keys.caindo_direita;


                animations.animations_arr[ index ] = new Animation();
                animations.animations_arr[ index ].animation_id = numero_animation;
                animations.animations_arr[ index ].have_repetition = true;
                animations.animations_arr[ index ].sprite_arr = new Sprite[numero_sprites];
                animations.animations_arr[ index ].frames_for_next_sprite = new int[numero_sprites];



                animations.animations_arr[ index ].sprite_arr[0] = Resources.Load<Sprite>("images/plataforma/personagens/dia/caindo_direita/1");
                animations.animations_arr[ index ].frames_for_next_sprite[0] = 60;

                



      // -----------------------------------------------------------------------------------
      // -----------------------------------------------------------------------------------




//     ----------------    Dia  caindo_esquerda  -------------------------------
       


        
                numero_sprites = 1 ;
                index = (int) Player_default_keys.caindo_esquerda;


                animations.animations_arr[ index ] = new Animation();
                animations.animations_arr[ index ].animation_id = numero_animation;
                animations.animations_arr[ index ].have_repetition = true;
                animations.animations_arr[ index ].sprite_arr = new Sprite[numero_sprites];
                animations.animations_arr[ index ].frames_for_next_sprite = new int[numero_sprites];



                animations.animations_arr[ index ].sprite_arr[0] = Resources.Load<Sprite>("images/plataforma/personagens/dia/caindo_esquerda/1");
                animations.animations_arr[ index ].frames_for_next_sprite[0] = 60;

                



      // -----------------------------------------------------------------------------------
      // -----------------------------------------------------------------------------------






//     ----------------    Dia  agachado_direita  -------------------------------
       


        
                numero_sprites = 1 ;
                index = (int) Player_default_keys.agachado_direita;


                animations.animations_arr[ index ] = new Animation();
                animations.animations_arr[ index ].animation_id = numero_animation;
                animations.animations_arr[ index ].have_repetition = true;
                animations.animations_arr[ index ].sprite_arr = new Sprite[numero_sprites];
                animations.animations_arr[ index ].frames_for_next_sprite = new int[numero_sprites];



                animations.animations_arr[ index ].sprite_arr[0] = Resources.Load<Sprite>("images/plataforma/personagens/dia/agachado_direita/1");
                animations.animations_arr[ index ].frames_for_next_sprite[0] = 60;

                



      // -----------------------------------------------------------------------------------
      // -----------------------------------------------------------------------------------



//     ----------------    Dia  agachado_esquerda  -------------------------------
       


        
                numero_sprites = 1 ;
                index = (int) Player_default_keys.agachado_esquerda;


                animations.animations_arr[ index ] = new Animation();
                animations.animations_arr[ index ].animation_id = numero_animation;
                animations.animations_arr[ index ].have_repetition = true;
                animations.animations_arr[ index ].sprite_arr = new Sprite[numero_sprites];
                animations.animations_arr[ index ].frames_for_next_sprite = new int[numero_sprites];



                animations.animations_arr[ index ].sprite_arr[0] = Resources.Load<Sprite>("images/plataforma/personagens/dia/agachado_esquerda/1");
                animations.animations_arr[ index ].frames_for_next_sprite[0] = 60;

                



      // -----------------------------------------------------------------------------------
      // -----------------------------------------------------------------------------------










    
     







        //   modificadores:
 
        // ----------------


         

       

        _player.fisica = fisica;
        _player.stats = stats;
        _player.animations = animations;


        // aplicar coisas basicas 





     animations.animacao_atual = animations.animations_arr[animations.animacao_default_id];
     animations.imagem_slot.sprite = animations.animacao_atual.sprite_arr[0];
     




    }





}