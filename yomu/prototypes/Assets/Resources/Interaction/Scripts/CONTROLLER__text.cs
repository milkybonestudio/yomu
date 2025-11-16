

using TMPro;
using UnityEngine;

public class CONTROLLER__text{

    public CONTROLLER__text(){

        text = GameObject.Find( "Canvas/Text_container/Container/Text" ).GetComponent<TextMeshProUGUI>();
        text.text = "text";
        text_character = GameObject.Find( "Canvas/Text_container/Container/Text_character" ).GetComponent<TextMeshProUGUI>();
        text_character.text = "Character";

    }

    public void Change_character( string _character ){

        text_character.text = _character;
    }

    public void Change_text( string _text ){

        text.text = _text;

    }

    
    public TextMeshProUGUI text_character;
    public TextMeshProUGUI text;


}