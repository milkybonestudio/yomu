using UnityEngine;
using System;









  public class Player_slots{

           
            public Player[] players = new Player[3];

            public GameObject[] players_game_objecs = new GameObject[3];

            
  }


public class Controlador_player{



    public static Controlador_player instancia;
    public static Controlador_player Pegar_instancia( bool _forcar = false  ){

            if( _forcar ) {if( Verificador_instancias_nulas.Verificar_se_pode_criar_objetos("Controlador_player_bloco_plataforma")) { instancia = new Controlador_player();instancia.Iniciar();} return instancia;}
            if(  instancia == null) { instancia = new Controlador_player(); instancia.Iniciar(); }
            return instancia;

    }






            public GameObject player_container_game_object;
            public Transform player_container_transform;

            public float sqrt_2 =   Mathf.Sqrt(2);

            public float fps_factor = 0.0167f;

            public BLOCO_plataforma plataforma;

            public Player  player_atual;

            public Player_slots player_slots = new Player_slots();


            public void Iniciar(){
      
                  plataforma = BLOCO_plataforma.Pegar_instancia();

            }


            
            public void Pegar_personagens_player(    string[] _personagens){

                  
                  for(int i = 0; i < _personagens.Length ;i++){

                        if( _personagens[i] == "") continue;

                        
                        switch(_personagens[i]){
                  
                              case "dia"      :   player_slots.players[i]   =  (new Dia_plataforma()).Pegar_player(i) ; break;
                              // case "lily"     : if(  Personagens.Pegar_instancia().lily.player     ==   null)    {  Lily_plataforma.Construir(i);};       player_slots.players[i]   =   Personagens.Pegar_instancia().lily.player           ; break;
                              // case "jayden"   : if(  Personagens.Pegar_instancia().jayden.player   ==   null)    {  Jayden_plataforma.Construir(i);};     player_slots.players[i]   =   Personagens.Pegar_instancia().jayden.player         ; break;
                              // case "eden"     : if(  Personagens.Pegar_instancia().eden.player     ==   null)    {  Eden_plataforma.Construir(i);};       player_slots.players[i]   =   Personagens.Pegar_instancia().eden.player           ; break;
                        
                              default: throw new ArgumentException("não foi achado o personagem, personagem: " + _personagens[i]);

                        }

                  }

                  


            }
   

    


     
            public void Colocar_personagem_no_world(){
            

                  
                  player_container_game_object = new GameObject("Player");

                  

                  player_slots.players_game_objecs[0] = new GameObject("Player_1");
                  player_slots.players_game_objecs[1] = new GameObject("Player_2");
                  player_slots.players_game_objecs[2] = new GameObject("Player_3");


                  player_slots.players_game_objecs[0].transform.SetParent(  player_container_game_object.transform  , false  );
                  player_slots.players_game_objecs[1].transform.SetParent(  player_container_game_object.transform  , false  );
                  player_slots.players_game_objecs[2].transform.SetParent(  player_container_game_object.transform  , false  );

                  
                  player_slots.players[0].player_game_object.transform.SetParent(player_slots.players_game_objecs[0].transform, false);

                  if(player_slots.players[1]  != null){

                        player_slots.players[1].player_game_object.transform.SetParent(player_slots.players_game_objecs[1].transform, false);

                  }


                  if(player_slots.players[2]  != null){

                        player_slots.players[2].player_game_object.transform.SetParent(player_slots.players_game_objecs[2].transform, false);

                  }


                  player_atual = player_slots.players[0];

                  player_atual.player_game_object = player_container_game_object;
                  player_container_game_object.transform.SetParent(   plataforma.meio_p_2.transform, false  );

            

                  RectTransform rect;
                  if( player_container_game_object.GetComponent<RectTransform>() == null ){

                        rect = player_container_game_object.AddComponent<RectTransform>();

                  } else {
                        rect = player_container_game_object.GetComponent<RectTransform>();
                  }
            

                  player_container_transform = player_container_game_object.transform;
                  
            
                  


                  rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal  ,  player_atual.fisica.dimensions[0]);
                  rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical  ,   player_atual.fisica.dimensions[1]);





                  player_slots.players_game_objecs[1].SetActive(false);
                  player_slots.players_game_objecs[2].SetActive(false);

            }


}




