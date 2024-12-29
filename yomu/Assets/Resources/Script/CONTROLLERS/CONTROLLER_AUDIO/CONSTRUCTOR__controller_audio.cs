using UnityEngine;


public static class CONSTRUCTOR__controller_audio {


    public static CONTROLLER__audio Construct(){

        
                CONTROLLER__audio controlador = new CONTROLLER__audio(); 
                CONTROLLER__audio.instancia = controlador;
        
                    controlador.audio_game_object =  GameObject.Find( "Audio" );

                    controlador.music_1 = new Audio_objeto( "Music_1", Tipo_audio.music );
                    controlador.music_2 = new Audio_objeto( "Music_2", Tipo_audio.music );

                    controlador.voice_1 = new Audio_objeto( "Voice_1", Tipo_audio.voice );
                    controlador.voice_2 = new Audio_objeto( "Voice_2", Tipo_audio.voice );
                    controlador.voice_3 = new Audio_objeto( "Voice_3", Tipo_audio.voice );

                    controlador.audio_source_uso_interno = new Audio_objeto( "audio_source_uso_interno", Tipo_audio.INTERNO );

                return controlador;

    }

}