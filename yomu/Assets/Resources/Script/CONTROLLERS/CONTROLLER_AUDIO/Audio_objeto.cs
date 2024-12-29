using System;
using UnityEngine;



public class Audio_objeto {

          
        public AudioSource audio_source;
        public GameObject game_object;

        public Coroutine coroutine;
        public Tipo_audio tipo;
        public CONTROLLER__audio controlador_audio;



        public AudioClip audio_final;
        public string path = "0";
        public float tempo_ms_tirar_restante = 0f;
        public float tempo_ms_colocar_restante = 0f;
        



        public Audio_objeto( string _id, Tipo_audio _tipo){


                controlador_audio = CONTROLLER__audio.Pegar_instancia();
                game_object = new GameObject( _id );
                tipo = _tipo;
                audio_source = game_object.AddComponent<AudioSource>();
                game_object.transform.SetParent( controlador_audio.audio_game_object.transform, false );

        }


        public void Destruir(){

                Mono_instancia.DestroyImmediate( game_object );
                return;

        }

        public void Atualizar_volume(){

                float volume_tipo = 0f;
                float volume_tipo_interno = 1f;

                switch( tipo ){

                        case Tipo_audio.music: volume_tipo = controlador_audio.music_volume; volume_tipo_interno = controlador_audio.music_volume_interno;  break;
                        case Tipo_audio.sfx: volume_tipo = controlador_audio.sfx_volume; volume_tipo_interno = controlador_audio.sfx_volume_interno; break;
                        case Tipo_audio.voice: volume_tipo = controlador_audio.voice_volume; volume_tipo_interno = controlador_audio.voice_volume_interno; break;

                }


                audio_source.volume = ( controlador_audio.master_volume * volume_tipo * volume_tipo_interno );

        }



}

