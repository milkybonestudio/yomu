using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gift_component : MonoBehaviour{

    public string action_name;
    
    private void Start(){

        gameObject.GetComponent<Button>().onClick.AddListener( Activate_button );
        
    }

    // Update is called once per frame
    private void Update(){
        
    }


    public void Activate_button(){

        Activate();

    }
    public int Activate(){

        switch( action_name ){

            case "flower_red" : return Flower_red();
            case "flower_blue" : return Flower_blue();
            default: throw new System.Exception( $"Did not find the action_name " + action_name );

        }

    }


    private int Flower_blue(){

        Controllers.character.Give_present( Present.flor_azul );
        return 0;

    }


    private int Flower_red(){

        Controllers.character.Give_present( Present.flor_vermelha );
        return 0;

    }
    
}
