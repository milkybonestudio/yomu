using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CONTROLLER : MonoBehaviour{

    
    private void Start(){
        
        Controllers.Create();
        Controllers.character.Set_character( new Lily() );

        
    }

    
    private void Update(){

        Controllers.bars_message.Update();

        if( Input.GetKeyDown( KeyCode.Alpha1 ) )
            { Controllers.character.Change_emotion( Emotion.sad ); }

        if( Input.GetKeyDown( KeyCode.Alpha2 ) )
            { Controllers.character.Change_emotion( Emotion.happy ); }

        if( Input.GetKeyDown( KeyCode.Alpha3 ) )
            { Controllers.character.Change_emotion( Emotion.rage ); }


        
    }


}
