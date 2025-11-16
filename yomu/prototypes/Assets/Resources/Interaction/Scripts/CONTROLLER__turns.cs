


using UnityEngine;
using UnityEngine.UI;


public enum Turn{

    other,
    you, 

}

public class CONTROLLER__turns {

    public CONTROLLER__turns(){

        turn_game_object = GameObject.Find( "Canvas/Turn" );
        image = turn_game_object.GetComponent<Image>();

        you_turn = Resources.Load<Sprite>( Paths.Get_path( "Turns/you" ) );
        other_turn = Resources.Load<Sprite>( Paths.Get_path( "Turns/other" ) );



        Change_turn();

    }


    public void Update(){

        
        switch( current_turn ){

            case Turn.you: You_update(); break;
            case Turn.other: Other_update(); break;

        }

    }



    public void You_update(){


    }


    public void Other_update(){


    }


    public void Change_turn(){

        Sprite new_sprite = null;

        switch( current_turn ){

            case Turn.you: current_turn = Turn.other; new_sprite = other_turn; break;
            case Turn.other: current_turn = Turn.you; new_sprite = you_turn; break;

        }

        image.sprite = new_sprite;

    }

    public Turn current_turn;

    public GameObject turn_game_object;
    public Image image;

    public Sprite you_turn;
    public Sprite other_turn;


}