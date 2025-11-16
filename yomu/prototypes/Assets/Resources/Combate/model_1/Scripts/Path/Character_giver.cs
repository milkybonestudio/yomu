

using UnityEngine;
using UnityEngine.UI;

public static class Character_giver {


    public static void Start(){

        ob = GameObject.Find( "Canvas/Character_giver" );
        ob.SetActive( false );
     
    }


    public static GameObject ob;


    public static void Start( Combat_character _character ){

        
        ob.SetActive( true );
        GameObject.Find( "Canvas/Character_giver/Character_image" ).GetComponent<Image>().sprite = _character.character_image.sprite;
        bool activate = false;

        for( int i = 0 ; i < 5 ; i++ ){

            int  k = i;

            GameObject.Find( $"Canvas/Character_giver/slot_{ k + 1 }" ).GetComponent<Button>().onClick.AddListener(()=>{

                if( activate )
                    { return; }

                activate = true;

                Controllers.characters.Change_character( _character, k );

                ob.SetActive( false );

            });


        }



    }

}