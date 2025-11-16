using UnityEngine;
using UnityEngine.UI;


public class CONTROLLER__combat {


        public static CONTROLLER__combat instance;
        

        public CONTROLLER__combat(){

            Controllers.combat = this;
            container = GameObject.Find( "Canvas/Game" );

            instance = this;

            new CONTROLLER__player();
            new CONTROLLER__mobs();
            new CONTROLLER__world();

            scene_container = GameObject.Find( "Canvas/Game/Scene" );
            quad  = GameObject.Find( "Canvas/Game/Scene/Quad" );



        }

        public GameObject scene_container;
        public GameObject quad;

        public GameObject container;

        public Combat_stage stage;



        public bool is_final;

        public void End_path(){

            Controllers.player.End();
            Controllers.mobs.End();

            if( is_final )
                { Controllers.main.Finalise(); return; }

            Controllers.main.Change_stage( Stage.choosing_path );

        }



        public void Destroy(){

            stage = Combat_stage.player_turn;
            Controllers.player.Destroy();
            Controllers.mobs.Destroy();

        }


        public void Update(){

            if( Input.GetKeyDown( KeyCode.Alpha5 ) )
                { Controllers.main.Change_stage( Stage.choosing_path ); }

            Controllers.world.Update();

            switch( stage ){

                case Combat_stage.player_turn: Controllers.player.Update(); break;
                case Combat_stage.mobs_turn: Controllers.mobs.Update(); break;
                default: throw new System.Exception( "nao consegue handler " + stage );

            }

        }


        public void Start_path( string[][] _mobs, bool _is_final ){

            // Debug.Log( "Veio em Start_path" );

            is_final = _is_final;


            Controllers.main.Change_stage( Stage.combat );
            Controllers.mobs.Start_path( _mobs );
            Controllers.characters.Give_life_characters();

            // ** create

        }



        public void Start_player_turn(){

            // Debug.Log( "Veio Start_player_turn" );

            Controllers.player.Start_turn();
            Controllers.mobs.End_turn();
            stage = Combat_stage.player_turn;



        }

        public void Start_mob_turn(){


            Controllers.player.End_turn();
            Controllers.mobs.Start_turn();
            stage = Combat_stage.mobs_turn;



        }
        
        public void Start_fase( Fase _fase ){

            is_final = false;

            Controllers.world.Set_world( _fase );
            Controllers.player.Start_fase();
            Controllers.mobs.Start_fase();
            // characters_controller;

        }


}


