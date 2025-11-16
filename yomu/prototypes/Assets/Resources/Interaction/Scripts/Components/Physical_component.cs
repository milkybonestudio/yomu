using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum Physical_action{

    kiss, 
    hug,

}

public class Physical_component : MonoBehaviour{

    public string physical_name;
    
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

        switch( physical_name ){

            case "hug" : return Hug();
            case "kiss" : return Kiss();
            default: throw new System.Exception( $"Did not find the physical_name " + physical_name );

        }

    }

    private int Kiss(){

        Controllers.character.Physical_action( Physical_action.kiss );
        return 0;

    }

    private int Hug(){

        Controllers.character.Physical_action( Physical_action.hug );
        return 0;

    }

}
