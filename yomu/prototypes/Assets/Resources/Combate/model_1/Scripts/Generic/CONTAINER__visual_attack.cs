using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public static class CONTAINER__visual_attack {

    
    public static Dictionary<string, Visual_attack> dic = new Dictionary<string, Visual_attack>();

    public static Visual_attack Get_visual_attakc( string _name ){

        if( !!!( dic.TryGetValue( _name, out Visual_attack data ) ) )
            { throw new System.Exception( $"Did not found the visual_attack <Color=lightBlue>{ _name }</Color>" ); }

        return data;

    }

    static CONTAINER__visual_attack(){

        dic.Add( "slash", new(){
            // audio_name = "slash",
            number_frames = 7,
            path_name = "slash"
        });



        dic.Add( "jud", new(){
            // audio_name = "slash",
            number_frames = 13,
            path_name = "jud"
        });


    }

}
