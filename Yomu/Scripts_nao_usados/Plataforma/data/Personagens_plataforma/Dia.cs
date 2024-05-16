using UnityEngine;
using UnityEngine.UI;
using System;




public enum Dia_animations_enum {
      parada_direita, 
      parada_esquerda,
      andando_direita,
      andando_esquerda,

}


// public enum Skill_type{
        
//         normal = 1, // aguarda para ser castada  
//         desativada = 2, // nao pode ser ativada por algum motivo => cooldown ou 
//         timer_skill = 3

// }

/*

            skill => vai ser mais para interface e informacoes; 

*/






public  class Dia_plataforma {


      public  Dia dia;
      public  Player player;
      public  Controlador_player controlador_player;
      public  BLOCO_plataforma plataforma;

      public int id_personagem;



      //******
      // teclado variaveis
      

      //******


      public  Skill[] skills;

      public  int skill_q = 0;
      public  int skill_w = 1;
      public  int skill_e = 2;
      public  int skill_r = 3;


      public Skill q_skill;
      public Skill w_skill;
      public Skill e_skill;
      public Skill r_skill;

       
       public  void teclado(){


            Teclado_default.Aplicar_jump(player);
            Teclado_default.Aplicar_left_right(player);


            if( Controlador_input.Get_down(Key_code.q) ) Q();
            if( Controlador_input.Get_down(Key_code.w) ) W();
            if( Controlador_input.Get_down(Key_code.e) ) E();
            if( Controlador_input.Get_down(Key_code.r) ) R();

            return;
            

       }







       public void Q(){


            if( !q_skill.can_cast ){return;}

                 // Magia_de_gelo();

            
            return;

       }


       public void W(){


            if( !w_skill.can_cast ){return;}

            Bola_de_fogo();

            
            return;



       }
       public void E(){

            if( !e_skill.can_cast ){return;}
            
            Tornado();

            return;

       }
       public void R(){

            if( !r_skill.can_cast ){ return; };

            Raio();


            
            return;
       }



       public void Magia_de_gelo(){


                  /*  mudar_animation()   */

                  /*
                  
                  *
                  *    testar: talvez valha mais a pena criar as funcoes aqui, passar uma ref do objeto ,
                  *    passar um numero e fazer um switch 
                  *

                  */

                  Projetil pr =  new Projetil(   id_personagem   , "rajada vendo 1");

                  pr.dados_int_projetil = new int[5];

                  plataforma.Adicionar_projetil(pr);


                  Vector3 vec = controlador_player.player_container_transform.localPosition;


                  pr.fisica.Setar_size_AND_position(vec[0], vec[1] , 100f , 100f); 


                  pr.Colocar_world();

                  pr.fisica.vectors_speed[0] = 10f;
                  pr.fisica.vectors_speed[1] = 15f;

                  pr.fisica.id = 152;


                  pr.projetil_game_object.AddComponent<Image>();

                  pr.fisica.mov_type = mov_type.movel;
                  pr.fisica.conteudo = conteudo.fluido;

                  pr.fisica_afeta = true;

                  pr.ids_objetos_atingidos = new int[10];
                  pr.tipos_objetos_atingidos  = new Tipo_objeto[10];
                  
                  pr.stats.efeito_contato = (Fisica_objeto _fisica,  Stats_objeto _stats)=>{



                        if(_stats.tipo != Tipo_objeto.mob) return;




                        Tipo_objeto tipo = _fisica.tipo;
                        //   vai iniciar todos com 0, dai usa 0 como -1(livre) e 1 como 0+(index)
                        int id = _fisica.id + 1;

                        int[] arr_id  =   pr.ids_objetos_atingidos;
                        Tipo_objeto[] arr_tipo =  pr.tipos_objetos_atingidos;
                        int index_livre = -1;

                        
                        for(int id_mob = 0 ;  id_mob < pr.ids_objetos_atingidos.Length    ; id_mob++){


                              if(   arr_id[ id_mob ] == id   &&  arr_tipo[ id_mob ] == _fisica.tipo ) return;
                              if(arr_id[ id_mob ] == 0) index_livre = id_mob;


                        }

                        // vai ter contato pela primeira vez agora 

                        if( index_livre<0 ){

                              // teve que aumentar o array


                              int[] novo_arr_id = new int[arr_tipo.Length + 10];
                              Tipo_objeto[] novo_arr_tipo = new Tipo_objeto[ arr_tipo.Length + 10];
                        
                              Array.Copy(  arr_id ,  novo_arr_id , arr_tipo.Length );
                              Array.Copy(  arr_tipo ,  novo_arr_tipo , arr_tipo.Length );

                              novo_arr_id[ arr_tipo.Length ] = id;
                              novo_arr_tipo[ arr_tipo.Length ] = tipo;

                              pr.ids_objetos_atingidos = novo_arr_id;
                              pr.tipos_objetos_atingidos = novo_arr_tipo;


                        } else {


                              // nao teve que aumentar

                              arr_id[ index_livre ] = id;
                              arr_tipo[ index_livre ] = tipo;


                        }



                        _stats.vida -= 10f;
                        Debug.Log("vida atual: " + _stats.vida);


                        
                  };
                  

                        
                  pr.efeito_tempo = ()=>{



                        pr.dados_int_projetil[0] = pr.dados_int_projetil[0] + 1;
                        
                        // pr.fisica.vectors_speed[0] += 0.05f;
                        

            
                        //pr.fisica.Aplicar_velocidade(pr.projetil_game_object.transform);


                        if(pr.dados_int_projetil[0] < 10 ) {pr.projetil_game_object.GetComponent<Image>().color = Color.blue;}
                        else if(pr.dados_int_projetil[0] < 20) {pr.projetil_game_object.GetComponent<Image>().color = Color.red;}
                        else if(pr.dados_int_projetil[0] < 30) {pr.projetil_game_object.GetComponent<Image>().color = Color.green;}
                        else  {



                                    pr.projetil_game_object.GetComponent<Image>().color = Color.white;
                                    pr.fisica.mov_type = mov_type.fixo;
                                    pr.fisica.conteudo = conteudo.solido;
                                    pr.fisica.vectors_speed[0] = 0f;
                                    pr.fisica.vectors_speed[1] = 0f;
                                    pr.fisica_afeta = false;


                        }

                        if(pr.dados_int_projetil[0] == 1250) plataforma.Remover_projetil(pr.id);
                        


                  };


       }


       public void Bola_de_fogo(){


                        if( player.stats.mana <= 0 ){return ;}
                        player.stats.mana-= 10;
                        Debug.Log("mana: " + player.stats.mana);


                        /*  mudar_animation()   */



                        /*
                         
                         *
                         *    testar: talvez valha mais a pena criar as funcoes aqui, passar uma ref do objeto ,
                         *    passar um numero e fazer um switch 
                         *

                        */

                        Projetil pr =  new Projetil( id_personagem , "bola de fogo");


                        


                        pr.stats.id_unico = "dia_w";

                        pr.dados_int_projetil = new int[2];

                        plataforma.Adicionar_projetil(pr);
                  
                        Vector3 vec = controlador_player.player_container_transform.localPosition;


                        pr.fisica.Setar_size_AND_position(vec[0], vec[1] , 50f , 50f); 


                        pr.Colocar_world();


                        pr.fisica.vectors_speed[0] = -15f;

                        //pr.fisica.vectors_speed[1] = 15f;

                        pr.fisica_afeta = false;

                        pr.fisica.mov_type = mov_type.movel;
                        pr.fisica.conteudo = conteudo.fluido;

                        pr.ids_objetos_atingidos = new int[10];
                        pr.tipos_objetos_atingidos  = new Tipo_objeto[10];



                      


                        pr.animations.tem_animacao = true;

                        pr.animations.imagem_slot = pr.projetil_game_object.AddComponent<Image>();

                        RectTransform rect = pr.projetil_game_object.GetComponent<RectTransform>();
                        rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 256f  );
                        rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 256f );

                        pr.animations.animacao_default_id = 0;

                        pr.animations.animations_arr = new Animation[2];




                        pr.animations.animations_arr[0] = new Animation();

                        pr.animations.animations_arr[0].have_repetition = true;
                        pr.animations.animations_arr[0].animation_id = 0;

                        pr.animations.animations_arr[0].sprite_arr = new Sprite[3];
                        pr.animations.animations_arr[0].sprite_arr[0] = Resources.Load<Sprite>("images/plataforma/personagens/dia/skills/fire_ball/01");
                        pr.animations.animations_arr[0].sprite_arr[1] = Resources.Load<Sprite>("images/plataforma/personagens/dia/skills/fire_ball/02");
                        pr.animations.animations_arr[0].sprite_arr[2] = Resources.Load<Sprite>("images/plataforma/personagens/dia/skills/fire_ball/03");


                        pr.animations.animations_arr[0].frames_for_next_sprite = new int[3]{   3 , 3 , 3   };




                        
                        pr.animations.animations_arr[1] = new Animation();

                        pr.animations.animations_arr[1].have_repetition = true;
                        pr.animations.animations_arr[1].animation_id = 1;

                        pr.animations.animations_arr[1].sprite_arr = new Sprite[8];
                        pr.animations.animations_arr[1].frames_for_next_sprite = new int[8] ;

                        pr.animations.animations_arr[1].sprite_arr[0] = Resources.Load<Sprite>("images/plataforma/personagens/dia/skills/fire_ball/exp_01");
                        pr.animations.animations_arr[1].frames_for_next_sprite[0]  = 3;
                        pr.animations.animations_arr[1].sprite_arr[1] = Resources.Load<Sprite>("images/plataforma/personagens/dia/skills/fire_ball/exp_02");
                        pr.animations.animations_arr[1].frames_for_next_sprite[1]  = 3;



                        pr.animations.animations_arr[1].sprite_arr[2] = Resources.Load<Sprite>("images/plataforma/personagens/dia/skills/fire_ball/exp_03");
                        pr.animations.animations_arr[1].frames_for_next_sprite[2]  = 4;
                        pr.animations.animations_arr[1].sprite_arr[3] = Resources.Load<Sprite>("images/plataforma/personagens/dia/skills/fire_ball/exp_04");
                        pr.animations.animations_arr[1].frames_for_next_sprite[3]  = 4;
                        pr.animations.animations_arr[1].sprite_arr[4] = Resources.Load<Sprite>("images/plataforma/personagens/dia/skills/fire_ball/exp_05");
                        pr.animations.animations_arr[1].frames_for_next_sprite[4]  = 4;
                        pr.animations.animations_arr[1].sprite_arr[5] = Resources.Load<Sprite>("images/plataforma/personagens/dia/skills/fire_ball/exp_06");

                        pr.animations.animations_arr[1].frames_for_next_sprite[5]  = 4;
                        pr.animations.animations_arr[1].sprite_arr[6] = Resources.Load<Sprite>("images/plataforma/personagens/dia/skills/fire_ball/exp_07");
                        pr.animations.animations_arr[1].frames_for_next_sprite[6]  = 5;

                        pr.animations.animations_arr[1].sprite_arr[7] = Resources.Load<Sprite>("images/plataforma/personagens/dia/skills/fire_ball/exp_08");
                     
                        pr.animations.animations_arr[1].frames_for_next_sprite[7]  = 5;


                        


                       



                        pr.animations.animacao_atual = pr.animations.animations_arr[pr.animations.animacao_default_id];

                        pr.animations.imagem_slot.sprite = pr.animations.animacao_atual.sprite_arr[0];
                         




                        pr.stats.efeito_contato = (Fisica_objeto _fisica,  Stats_objeto _stats)=>{


                                    

                                    if(_fisica.tipo == Tipo_objeto.player || _stats.id_unico == "dia_w"  ) return;




                                    pr.fisica.vectors_speed[0] = 0f;
                                    pr.animations.proxima_animacao = 1;
                                    pr.dados_int_projetil[1] = 1;

                                    


                                    //if(_stats.tipo != Tipo_objeto.mob) return;


                                    Tipo_objeto tipo = _fisica.tipo;
                                    //   vai iniciar todos com 0, dai usa 0 como -1(livre) e 1 como 0+(index)
                                    int id = _fisica.id + 1;

                                    int[] arr_id  =   pr.ids_objetos_atingidos;
                                    Tipo_objeto[] arr_tipo =  pr.tipos_objetos_atingidos;
                                    int index_livre = -1;

                                    
                                    for(int id_mob = 0 ;  id_mob < pr.ids_objetos_atingidos.Length    ; id_mob++){


                                          if(   arr_id[ id_mob ] == id   &&  arr_tipo[ id_mob ] == _fisica.tipo ) return;
                                          if(arr_id[ id_mob ] == 0) index_livre = id_mob;
                                          

                                    }

                                    // vai ter contato pela primeira vez agora 

                                    if( index_livre<0 ){

                                          // teve que aumentar o array


                                          int[] novo_arr_id = new int[arr_tipo.Length + 10];
                                          Tipo_objeto[] novo_arr_tipo = new Tipo_objeto[ arr_tipo.Length + 10];
                                    
                                          Array.Copy(  arr_id ,  novo_arr_id , arr_tipo.Length );
                                          Array.Copy(  arr_tipo ,  novo_arr_tipo , arr_tipo.Length );

                                          novo_arr_id[ arr_tipo.Length ] = id;
                                          novo_arr_tipo[ arr_tipo.Length ] = tipo;

                                          pr.ids_objetos_atingidos = novo_arr_id;
                                          pr.tipos_objetos_atingidos = novo_arr_tipo;


                                    } else {


                                          // nao teve que aumentar

                                          arr_id[ index_livre ] = id;
                                          arr_tipo[ index_livre ] = tipo;


                                    }

                                    
                                    _stats.vida -= 10f;
                                    _fisica.vectors_speed[0] -= 5f;
                                    

                                    if(_fisica.vectors_speed[0] < 0f ) _fisica.vectors_speed[0] = 0f;






                              
                        };
                        


                        
                        pr.efeito_tempo = ()=>{



                             // Debug.Log(pr.dados_int_projetil[0]);


                             


                              if(pr.dados_int_projetil[1] == 1) pr.dados_int_projetil[0] = pr.dados_int_projetil[0] + 1;
                              if( pr.dados_int_projetil[0] == 32) plataforma.Remover_projetil(pr.id);
 
                               

                              
                           //RectTransform rect = pr.projetil_game_object.GetComponent<RectTransform>();

                           //pr.fisica.Setar_size_AND_position(pr.fisica.position[0] ,pr.fisica.position[1] , pr.fisica.dimensions[0] + 2f , pr.fisica.dimensions[1] + 2f );

                        //    rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal , pr.fisica.dimensions[0] );
                        //    rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical , pr.fisica.dimensions[1] );

                               
                              // pr.fisica.vectors_speed[0] += 0.05f;
                               

                               //pr.fisica.Aplicar_velocidade(pr.projetil_game_object.transform);


                              //  if(pr.dados_int_projetil[0] < 50 ) {pr.projetil_game_object.GetComponent<Image>().color = Color.blue;}
                              //  else if(pr.dados_int_projetil[0] < 100) {pr.projetil_game_object.GetComponent<Image>().color = Color.red;}
                              //  else if(pr.dados_int_projetil[0] < 150) {pr.projetil_game_object.GetComponent<Image>().color = Color.green;}
                              //  else  {pr.projetil_game_object.GetComponent<Image>().color = Color.white;}

                               


                        };


                        

                         



       }

       public void Tornado(){

       }

       public void Raio(){

       }












        public  Player Pegar_player(int _id_personagem){


                  this.id_personagem = _id_personagem;


                  //Dados_combate dados =  Controlador.controlador.controlador_personagens.dia.dados_combate;
                  
                  // por hora os persoangens vao ser estaticos, mas depois as informacos especiais vao ser passadas pelo controlador
                  // ex: player desbloqueou uma nova skill com a Dia. Não vai ser default


                  

                  player = new Player(_id_personagem,"dia");

                  
                   
                  dia = Controlador_personagens.Pegar_instancia().personagens.dia;

                  player.Update_teclado = teclado;

                //  Controlador.controlador.controlador_personagens.personagens.dia.player = player;

                  plataforma = BLOCO_plataforma.Pegar_instancia();

                  controlador_player = plataforma.controlador_player;

                  




                  //      default:
                  Fisica_objeto fisica =  new Fisica_objeto(_id_personagem , Tipo_objeto.player);

                  //   largura
                  fisica.dimensions[0] = 50f;

                  //  altura
                  fisica.dimensions[1] = 128f;

                  fisica.mov_type = mov_type.movel;
                  fisica.shape_type = 1;
                  fisica.conteudo = conteudo.fluido;

                  
                  Stats_objeto stats = new Stats_objeto( _id_personagem , Tipo_objeto.player);

                  
                  stats.jumps_possiveis = 1;
                  stats.vida = 350f;

                  stats.jumps_possiveis_atuais = stats.jumps_possiveis;

                  stats.movimentation_speed = 15f;

                  stats.jump_altura = 18f;
                  

                  stats.efeito_contato =  (Fisica_objeto _fisica , Stats_objeto _stats ) => {


                        /// OBVIAMENTE MUDAR DEPOIS
                        if(_stats.tipo != Tipo_objeto.mob) return;
                        
                        stats.vida -= 1f;


                     ///plataforma.Destruir_objeto( _fisica.id, _fisica.tipo);

                       

                  };


                  /*     *****          SKILLS     ******       */

                  skills = new Skill[10];
                  

                  q_skill = new Skill();


                  q_skill.descricao = "It fires a water projectile that has 2 states. She raises a water bubble that then freezes in the air"; 

                  q_skill.player = player;

                  
                  q_skill.verifiar_mudanca = ()=>{
                        
                  };


                  q_skill.can_cast = true;

                  q_skill.cooldown = false;
                  q_skill.tempo_atual = 0f;
                  q_skill.tempo_recarga = 3f;

                  //   pegar path
                  q_skill.sprite_icone = Resources.Load<Sprite>("images/");

                  q_skill.mana_requisito = 10f;

            



                  w_skill = new Skill();
                  w_skill.descricao = "Fires a fireball";
                  w_skill.player = player;
                  w_skill.sprite_icone = Resources.Load<Sprite>("images/");

                  w_skill.can_cast = true;
                  w_skill.cooldown = false;
                  w_skill.tempo_atual = 0f;
                  w_skill.tempo_recarga = 3f;

                  w_skill.mana_requisito = 10f;



                  
                  e_skill = new Skill();
                  e_skill.descricao = "";
                  e_skill.player = player;
                  e_skill.sprite_icone = Resources.Load<Sprite>("images/");

                  e_skill.can_cast = false;
                  e_skill.cooldown = false;
                  e_skill.tempo_atual = 0f;
                  e_skill.tempo_recarga = 3f;

                  e_skill.mana_requisito = 10f;

                  
                  r_skill = new Skill();
                  r_skill.descricao = "";
                  r_skill.player = player;
                  r_skill.sprite_icone = Resources.Load<Sprite>("images/");

                  r_skill.can_cast = false;
                  r_skill.cooldown = false;
                  r_skill.tempo_atual = 0f;
                  r_skill.tempo_recarga = 3f;

                  r_skill.mana_requisito = 10f;
    





                  




                  /*     *****          ANIMATION     ******       */


                  
                  Animations_object animations = new Animations_object(_id_personagem, Tipo_objeto.player);

                  
                  animations.transform = player.player_game_object.transform;

                  animations.tem_animacao = true;


                  

                  animations.imagem_slot  = player.player_game_object.GetComponent<Image>();


                  animations.animacao_default_id = (int) Player_default_keys.parado_frente;
                  

                  animations.animations_arr = new Animation[25];
                  animations.animations_direction = new int[25];
                  animations.repeticao_ponto_loop = new int[25];


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



                        animations.animations_arr[ index ].sprite_arr[0] = Resources.Load<Sprite>("images/plataforma/personagens/dia/body_animations/parado_frente/1");
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



                        animations.animations_arr[ index ].sprite_arr[0] = Resources.Load<Sprite>("images/plataforma/personagens/dia/body_animations/parada_direita/1");
                        animations.animations_arr[ index ].frames_for_next_sprite[0] = 5;

                        animations.animations_arr[ index ].sprite_arr[1] = Resources.Load<Sprite>("images/plataforma/personagens/dia/body_animations/parada_direita/2");
                        animations.animations_arr[ index ].frames_for_next_sprite[1] = 5;

                        animations.animations_arr[ index ].sprite_arr[2] = Resources.Load<Sprite>("images/plataforma/personagens/dia/body_animations/parada_direita/3");
                        animations.animations_arr[ index ].frames_for_next_sprite[2] = 5;

                        animations.animations_arr[ index ].sprite_arr[3] = Resources.Load<Sprite>("images/plataforma/personagens/dia/body_animations/parada_direita/4");
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



                        animations.animations_arr[ index ].sprite_arr[0] = Resources.Load<Sprite>("images/plataforma/personagens/dia/body_animations/parada_esquerda/1");
                        animations.animations_arr[ index ].frames_for_next_sprite[0] = 5;

                        animations.animations_arr[ index ].sprite_arr[1] = Resources.Load<Sprite>("images/plataforma/personagens/dia/body_animations/parada_esquerda/2");
                        animations.animations_arr[ index ].frames_for_next_sprite[1] = 5;

                        animations.animations_arr[ index ].sprite_arr[2] = Resources.Load<Sprite>("images/plataforma/personagens/dia/body_animations/parada_esquerda/3");
                        animations.animations_arr[ index ].frames_for_next_sprite[2] = 5;

                        animations.animations_arr[ index ].sprite_arr[3] = Resources.Load<Sprite>("images/plataforma/personagens/dia/body_animations/parada_esquerda/4");
                        animations.animations_arr[ index ].frames_for_next_sprite[3] = 5;

                        animations.animations_arr[ index ].sprite_arr[4] = animations.animations_arr[ index ].sprite_arr[2]  ;
                        animations.animations_arr[ index ].frames_for_next_sprite[4] = 5;

                        animations.animations_arr[ index ].sprite_arr[5] = animations.animations_arr[ index ].sprite_arr[1]  ;
                        animations.animations_arr[ index ].frames_for_next_sprite[5] = 5;




                  // -----------------------------------------------------------------------------------
                  // -----------------------------------------------------------------------------------

















            //     ----------------    Dia  andando direita  -------------------------------
                  


                  
                        numero_sprites = 8;
                        index = (int) Player_default_keys.andando_direita;


                        animations.animations_direction[index] = 1;

                        animations.animations_arr[ index ] = new Animation();
                        animations.animations_arr[ index ].animation_id = numero_animation;
                        animations.animations_arr[ index ].have_repetition = true;
                        animations.animations_arr[ index ].sprite_arr = new Sprite[numero_sprites];
                        animations.animations_arr[ index ].frames_for_next_sprite = new int[numero_sprites];



                        animations.animations_arr[ index ].sprite_arr[0] = Resources.Load<Sprite>("images/plataforma/personagens/dia/body_animations/andando/1");
                        animations.animations_arr[ index ].frames_for_next_sprite[0] = 2;

                        animations.animations_arr[ index ].sprite_arr[1] = Resources.Load<Sprite>("images/plataforma/personagens/dia/body_animations/andando/2");
                        animations.animations_arr[ index ].frames_for_next_sprite[1] = 2;

                        animations.animations_arr[ index ].sprite_arr[2] = Resources.Load<Sprite>("images/plataforma/personagens/dia/body_animations/andando/3");
                        animations.animations_arr[ index ].frames_for_next_sprite[2] = 2;

                        animations.animations_arr[ index ].sprite_arr[3] = Resources.Load<Sprite>("images/plataforma/personagens/dia/body_animations/andando/4");
                        animations.animations_arr[ index ].frames_for_next_sprite[3] = 2;

                        animations.animations_arr[ index ].sprite_arr[4] = Resources.Load<Sprite>("images/plataforma/personagens/dia/body_animations/andando/5");
                        animations.animations_arr[ index ].frames_for_next_sprite[4] = 2;

                        animations.animations_arr[ index ].sprite_arr[5] = Resources.Load<Sprite>("images/plataforma/personagens/dia/body_animations/andando/6");
                        animations.animations_arr[ index ].frames_for_next_sprite[5] = 2;

                        animations.animations_arr[ index ].sprite_arr[6] = Resources.Load<Sprite>("images/plataforma/personagens/dia/body_animations/andando/7");
                        animations.animations_arr[ index ].frames_for_next_sprite[6] = 2;

                        animations.animations_arr[ index ].sprite_arr[7] = Resources.Load<Sprite>("images/plataforma/personagens/dia/body_animations/andando/8");
                        animations.animations_arr[ index ].frames_for_next_sprite[7] = 2;
                        
                        

                        



                  // -----------------------------------------------------------------------------------
                  // -----------------------------------------------------------------------------------






            //     ----------------    Dia  andando esquerda  -------------------------------
                  


                  
                        numero_sprites = 8 ;
                        index = (int) Player_default_keys.andando_esquerda;


                        animations.animations_arr[ index ] = new Animation();
                        animations.animations_arr[ index ].animation_id = numero_animation;
                        animations.animations_arr[ index ].have_repetition = true;
                        animations.animations_arr[ index ].sprite_arr = new Sprite[numero_sprites];
                        animations.animations_arr[ index ].frames_for_next_sprite = new int[numero_sprites];



                        animations.animations_arr[ index ].sprite_arr[0] = Resources.Load<Sprite>("images/plataforma/personagens/dia/body_animations/andando/1");
                        animations.animations_arr[ index ].frames_for_next_sprite[0] = 4;

                        animations.animations_arr[ index ].sprite_arr[1] = Resources.Load<Sprite>("images/plataforma/personagens/dia/body_animations/andando/2");
                        animations.animations_arr[ index ].frames_for_next_sprite[1] = 4;

                        animations.animations_arr[ index ].sprite_arr[2] = Resources.Load<Sprite>("images/plataforma/personagens/dia/body_animations/andando/3");
                        animations.animations_arr[ index ].frames_for_next_sprite[2] = 4;

                        animations.animations_arr[ index ].sprite_arr[3] = Resources.Load<Sprite>("images/plataforma/personagens/dia/body_animations/andando/4");
                        animations.animations_arr[ index ].frames_for_next_sprite[3] = 4;

                        animations.animations_arr[ index ].sprite_arr[4] = Resources.Load<Sprite>("images/plataforma/personagens/dia/body_animations/andando/5");
                        animations.animations_arr[ index ].frames_for_next_sprite[4] = 4;

                        animations.animations_arr[ index ].sprite_arr[5] = Resources.Load<Sprite>("images/plataforma/personagens/dia/body_animations/andando/6");
                        animations.animations_arr[ index ].frames_for_next_sprite[5] = 4;

                        animations.animations_arr[ index ].sprite_arr[6] = Resources.Load<Sprite>("images/plataforma/personagens/dia/body_animations/andando/7");
                        animations.animations_arr[ index ].frames_for_next_sprite[6] = 4;

                        animations.animations_arr[ index ].sprite_arr[7] = Resources.Load<Sprite>("images/plataforma/personagens/dia/body_animations/andando/8");
                        animations.animations_arr[ index ].frames_for_next_sprite[7] = 4;
                        



                  // -----------------------------------------------------------------------------------
                  // -----------------------------------------------------------------------------------






            //     ----------------    Dia  pulando  -------------------------------
                  


                  
                        numero_sprites = 2 ;
                        index = (int) Player_default_keys.pulando_frente;


                        
                        animations.animations_arr[ index ] = new Animation();
                        animations.animations_arr[ index ].animation_id = numero_animation;
                        animations.animations_arr[ index ].have_repetition = true;
                        animations.animations_arr[ index ].sprite_arr = new Sprite[numero_sprites];
                        animations.animations_arr[ index ].frames_for_next_sprite = new int[numero_sprites];



                        animations.animations_arr[ index ].sprite_arr[0] = Resources.Load<Sprite>("images/plataforma/personagens/dia/body_animations/pulando_frente/1");
                        animations.animations_arr[ index ].frames_for_next_sprite[0] = 3;

                        
                        animations.animations_arr[ index ].sprite_arr[1] = Resources.Load<Sprite>("images/plataforma/personagens/dia/body_animations/pulando_frente/2");
                        animations.animations_arr[ index ].frames_for_next_sprite[1] = 3;


                        



                  // -----------------------------------------------------------------------------------
                  // -----------------------------------------------------------------------------------






            //     ----------------    Dia  pulando_direita  -------------------------------
                  


                  
                        numero_sprites = 3 ;
                        index = (int) Player_default_keys.pulando_direita;



                        

                        animations.animations_arr[ index ] = new Animation();
                        animations.animations_arr[ index ].animation_id = numero_animation;
                        animations.animations_arr[ index ].have_repetition = true;
                        animations.animations_arr[ index ].sprite_arr = new Sprite[numero_sprites];
                        animations.animations_arr[ index ].frames_for_next_sprite = new int[numero_sprites];



                            animations.animations_arr[ index ].sprite_arr[0] = Resources.Load<Sprite>("images/plataforma/personagens/dia/body_animations/diagonal/p_1");
                        animations.animations_arr[ index ].frames_for_next_sprite[0] = 3;


                        animations.animations_arr[ index ].sprite_arr[1] = Resources.Load<Sprite>("images/plataforma/personagens/dia/body_animations/diagonal/p_2");
                        animations.animations_arr[ index ].frames_for_next_sprite[1] = 3;


                        animations.animations_arr[ index ].sprite_arr[2] = Resources.Load<Sprite>("images/plataforma/personagens/dia/body_animations/diagonal/p_3");
                        animations.animations_arr[ index ].frames_for_next_sprite[2] = 3;



                        



                  // -----------------------------------------------------------------------------------
                  // -----------------------------------------------------------------------------------





            //     ----------------    Dia  pulando_esquerda  -------------------------------
                  


                  
                        numero_sprites = 3 ;
                        index = (int) Player_default_keys.pulando_esquerda;

                        animations.animations_direction[index] = 1;


                        animations.animations_arr[ index ] = new Animation();
                        animations.animations_arr[ index ].animation_id = numero_animation;
                        animations.animations_arr[ index ].have_repetition = true;
                        animations.animations_arr[ index ].sprite_arr = new Sprite[numero_sprites];
                        animations.animations_arr[ index ].frames_for_next_sprite = new int[numero_sprites];



                        animations.animations_arr[ index ].sprite_arr[0] = Resources.Load<Sprite>("images/plataforma/personagens/dia/body_animations/diagonal/p_1");
                        animations.animations_arr[ index ].frames_for_next_sprite[0] = 3;


                        animations.animations_arr[ index ].sprite_arr[1] = Resources.Load<Sprite>("images/plataforma/personagens/dia/body_animations/diagonal/p_2");
                        animations.animations_arr[ index ].frames_for_next_sprite[1] = 3;


                        animations.animations_arr[ index ].sprite_arr[2] = Resources.Load<Sprite>("images/plataforma/personagens/dia/body_animations/diagonal/p_3");
                        animations.animations_arr[ index ].frames_for_next_sprite[2] = 3;


                        



                  // -----------------------------------------------------------------------------------
                  // -----------------------------------------------------------------------------------









            //     ----------------    Dia  caindo_frente  -------------------------------
                  


                  
                        numero_sprites = 3 ;
                        index = (int) Player_default_keys.caindo_frente;

                        animations.repeticao_ponto_loop[index] = 1;
                        

                        animations.animations_arr[ index ] = new Animation();
                        animations.animations_arr[ index ].animation_id = numero_animation;
                        animations.animations_arr[ index ].have_repetition = true;
                        animations.animations_arr[ index ].sprite_arr = new Sprite[numero_sprites];
                        animations.animations_arr[ index ].frames_for_next_sprite = new int[numero_sprites];

                        animations.animations_arr[ index ].sprite_arr[0] = Resources.Load<Sprite>("images/plataforma/personagens/dia/body_animations/caindo_frente/0");
                        animations.animations_arr[ index ].frames_for_next_sprite[0] = 10;

                        animations.animations_arr[ index ].sprite_arr[1] = Resources.Load<Sprite>("images/plataforma/personagens/dia/body_animations/caindo_frente/1");
                        animations.animations_arr[ index ].frames_for_next_sprite[1] = 3;
                        
                        animations.animations_arr[ index ].sprite_arr[2] = Resources.Load<Sprite>("images/plataforma/personagens/dia/body_animations/caindo_frente/2");
                        animations.animations_arr[ index ].frames_for_next_sprite[2] = 3;

                        

                        



                  // -----------------------------------------------------------------------------------
                  // -----------------------------------------------------------------------------------


            //     ----------------    Dia  caindo_direita -------------------------------
                  


                  
                        numero_sprites = 3 ;
                        index = (int) Player_default_keys.caindo_direita;

                        animations.animations_direction[index] = 1;


                        animations.animations_arr[ index ] = new Animation();
                        animations.animations_arr[ index ].animation_id = numero_animation;
                        animations.animations_arr[ index ].have_repetition = true;
                        animations.animations_arr[ index ].sprite_arr = new Sprite[numero_sprites];
                        animations.animations_arr[ index ].frames_for_next_sprite = new int[numero_sprites];



                        animations.animations_arr[ index ].sprite_arr[0] = Resources.Load<Sprite>("images/plataforma/personagens/dia/body_animations/diagonal/c_1");
                        animations.animations_arr[ index ].frames_for_next_sprite[0] = 3;


                        animations.animations_arr[ index ].sprite_arr[1] = Resources.Load<Sprite>("images/plataforma/personagens/dia/body_animations/diagonal/c_2");
                        animations.animations_arr[ index ].frames_for_next_sprite[1] = 3;


                        animations.animations_arr[ index ].sprite_arr[2] = Resources.Load<Sprite>("images/plataforma/personagens/dia/body_animations/diagonal/c_3");
                        animations.animations_arr[ index ].frames_for_next_sprite[2] = 3;



                        



                  // -----------------------------------------------------------------------------------
                  // -----------------------------------------------------------------------------------




            //     ----------------    Dia  caindo_esquerda  -------------------------------
                  


                  
                        numero_sprites = 3 ;
                        index = (int) Player_default_keys.caindo_esquerda;


                        animations.animations_arr[ index ] = new Animation();
                        animations.animations_arr[ index ].animation_id = numero_animation;
                        animations.animations_arr[ index ].have_repetition = true;
                        animations.animations_arr[ index ].sprite_arr = new Sprite[numero_sprites];
                        animations.animations_arr[ index ].frames_for_next_sprite = new int[numero_sprites];



                       
                        animations.animations_arr[ index ].sprite_arr[0] = Resources.Load<Sprite>("images/plataforma/personagens/dia/body_animations/diagonal/c_1");
                        animations.animations_arr[ index ].frames_for_next_sprite[0] = 3;


                        animations.animations_arr[ index ].sprite_arr[1] = Resources.Load<Sprite>("images/plataforma/personagens/dia/body_animations/diagonal/c_2");
                        animations.animations_arr[ index ].frames_for_next_sprite[1] = 3;


                        animations.animations_arr[ index ].sprite_arr[2] = Resources.Load<Sprite>("images/plataforma/personagens/dia/body_animations/diagonal/c_3");
                        animations.animations_arr[ index ].frames_for_next_sprite[2] = 3;


                  
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


                        animations.animations_arr[ index ].sprite_arr[0] = Resources.Load<Sprite>("images/plataforma/personagens/dia/body_animations/agachado_direita/1");
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



                        animations.animations_arr[ index ].sprite_arr[0] = Resources.Load<Sprite>("images/plataforma/personagens/dia/body_animations/agachado_esquerda/1");
                        animations.animations_arr[ index ].frames_for_next_sprite[0] = 60;

                        



                  // -----------------------------------------------------------------------------------
                  // -----------------------------------------------------------------------------------





                  //   modificadores:
            
                  // ----------------


                  

                  

                  player.fisica = fisica;
                  player.stats = stats;
                  player.animations = animations;


                  // aplicar coisas basicas 





            animations.animacao_atual = animations.animations_arr[animations.animacao_default_id];
            animations.imagem_slot.sprite = animations.animacao_atual.sprite_arr[0];


            return player;




    }





}