using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mental_component : MonoBehaviour{
    

    public string mental_name;
    void Start(){

        gameObject.GetComponent<Button>().onClick.AddListener( Activate_button );
        
    }

    
    void Update(){
        
    }

    public void Activate_button(){

        Activate();

    }
    public int Activate(){

        switch( mental_name ){

            case "Flor" : return Flor();
            default: throw new System.Exception( $"Did not find the action_name " + mental_name );

        }

    }


    private int Flor(){

        return 0;

    }

}
