using UnityEngine;
using UnityEngine.UI;
using System;



public class Player{





      public GameObject player_game_object;
      public Transform transform;

      
      public string character;

      public Action Update_teclado;


      public Fisica_objeto fisica;
      public Stats_objeto stats;
      public Animations_object animations;


      public bool right_is_active = false;
      public bool left_is_active = false;
      public bool is_right_AND_left = false;


      public bool is_dead = false;

      

      public Player (  int _id,  string _nome_personagem = "char"){

      
            player_game_object =  new GameObject(_nome_personagem);
            character = _nome_personagem;
            player_game_object.AddComponent<Image>();
            RectTransform rect_player =  player_game_object.GetComponent<RectTransform>();


            rect_player.SetSizeWithCurrentAnchors(  RectTransform.Axis.Horizontal , 128f);
            rect_player.SetSizeWithCurrentAnchors(  RectTransform.Axis.Vertical , 128f);

            
            transform = player_game_object.transform;






            //     fisica

            fisica = new Fisica_objeto(  _id , Tipo_objeto.player);

            fisica.mov_type = mov_type.movel;
            fisica.conteudo = conteudo.fluido;



            //    stats
            stats = new Stats_objeto(_id , Tipo_objeto.player);
            stats.jumps_possiveis = 2;
            stats.jumps_possiveis_atuais = 2;



            //    animations



            animations = new Animations_object(_id , Tipo_objeto.player);
            // animations.animations_arr = new Animation[1];
            // animations.animations_arr[0] = new Animation();




            // animations.animations_arr[0].sprite_arr = new Sprite[1];

           // animations.animations_arr[0].sprite_arr[0] = Resources.Load<Sprite>("images/plataforma/personagens/dia/teste_mov");

            //Animation.Atualizar();

           // player_game_object.GetComponent<Image>().sprite = animations.animations_arr[0].sprite_arr[0];



      


      
      }






}




