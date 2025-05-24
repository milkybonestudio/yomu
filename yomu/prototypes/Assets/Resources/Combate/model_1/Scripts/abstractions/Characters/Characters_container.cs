using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public static class SPRITE {

    public static Sprite Get_sprite( string _path ){

        Sprite sprite = Resources.Load<Sprite>( _path );

        if( sprite == null )
            { throw new System.Exception( $"Dont find image in path <Color=lightBlue>{ _path }</Color>" ); }

        return sprite;

    }

}



public static class Combat_character_container {

    public static Dictionary<string, Character_data> characters_data = new Dictionary<string, Character_data>();

    static Combat_character_container(){


        characters_data.Add( "Ruby", new(){

            skill_up = new(){

                name = "slash",
                image_name = "slash",
                description = "ruby gives a slash",
                
            }

        });

    }

}