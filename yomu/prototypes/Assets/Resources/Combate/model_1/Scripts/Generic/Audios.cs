
using System.Collections.Generic;
using UnityEngine;

public static class Audios{

    public static Dictionary<int, Audio> list = new Dictionary<int, Audio>();

    public static int id;
    public static void Create_audio( ){

        // Debug.Log( "Veio criar audio" );

        Audio audio = default;
        audio.game_object = new GameObject( "audio" );
        audio.audio_source = audio.game_object.AddComponent<AudioSource>();
        audio.audio_source.clip = Resources.Load<AudioClip>( Paths_combate_modelo_1.Get_path( "SFX" ) );

        audio.audio_source.volume = 0.5f;
        audio.id = ++id;
        audio.audio_source.Play();

        

        list.Add( id, audio );

    }


    public static void Start_music(){

        
        GameObject.Find( "Audio" ).GetComponent<AudioSource>().Play();

    }

    private static int[] values_to_remove = new int[ 1_000 ];
    private static int index_values_to_remove = -1;



    public static void Update(){

        return;

        foreach( KeyValuePair<int, Audio> kv in list ){

            if( kv.Value.audio_source.isPlaying  )
                { continue; }

            GameObject.Destroy( kv.Value.game_object );
            index_values_to_remove++;
            values_to_remove[ index_values_to_remove ] = kv.Key;

        }
        for( int index = 0 ; index < ( index_values_to_remove + 1 ) ; index++ ){
            list.Remove( values_to_remove[ index ] );
        }

        index_values_to_remove = -1;

    }

}