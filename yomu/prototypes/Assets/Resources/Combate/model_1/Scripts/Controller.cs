using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public struct Fase{

    public string[] player_start_characters;
    public string[][] mobs_in_world; 
    public string world_model; // ** aponta para uma pasta com 2 prefabs que tem o cenario

}


public enum Stage {

    treasure, // ** get more characters
    player_turn,
    mob_turn,

}

    public struct Options {

        public bool click_auto;
        public bool click_pass_turn;

    }



public class Controller : MonoBehaviour{

    public Button pass_turn_button;
    public Button auto_button;


    public Characters_controller character_controller;
    public Mob_controller mob_controller;
    public Player_inputs player_inputs;
    public World_controller world_controller;

    public Stage stage;

    Combat_character ruby;
    
    void Start(){

        // ** iniciar containers 
        character_controller = new Characters_controller();
        mob_controller = new Mob_controller();
        world_controller = new World_controller();

        player_inputs = new Player_inputs();

        pass_turn_button.onClick.AddListener(  ()=>{ player_inputs.options.click_pass_turn = true; } );
        auto_button.onClick.AddListener(  ()=>{ player_inputs.options.click_auto = true; } );
        
    }


    public void Start_fase( Fase _fase ){

            character_controller.Start_fase( _fase.player_start_characters );

    }


    void Update(){

        Audios.Update();
        VISUAL_CONTAINER__visual_attacks.Update();

        if( Input.GetKeyDown( KeyCode.Space ) )
            {
                VISUAL_CONTAINER__visual_attacks.Add_visual_attack( 
                    CONTAINER__visual_attack.Get_visual_attakc( "slash" ) 
                );
            }

        if( Input.GetKeyDown( KeyCode.Alpha1 ) )
            {
                character_controller.Start_player_turn();
            }

        
        switch( stage ){
            case Stage.waiting_player_inputs: player_inputs.Update(); break;
            default: throw new System.Exception( $"Can not handle stage type { stage }" ); 
        }

        
    }


        public void Start_player_turn(){

            for( int i = 0 ; i < NUMBER_COMBAT_CHARACTERS ; i++ ){
                characters_in_combat[ i ].Liberat_cast();
            }


        }

        public void Start_mob_turn(){

            for( int i = 0 ; i < NUMBER_COMBAT_CHARACTERS ; i++ ){
                characters_in_combat[ i ].Block_cast();
            }


        }




}

