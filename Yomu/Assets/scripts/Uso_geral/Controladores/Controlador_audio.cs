using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using System;





//    passar para data








 public class Controlador_audio {

    public static Controlador_audio instancia;
    public static Controlador_audio Pegar_instancia( bool _forcar = false  ){

            if( _forcar ) {if( Verificador_instancias_nulas.Verificar_se_pode_criar_objetos("Controlador_audio")) { instancia = new Controlador_audio();instancia.Iniciar();} return instancia;}
            if(  instancia == null) { instancia = new Controlador_audio(); instancia.Iniciar(); }
            return instancia;

    }





        public  float master_volume = 1f;
        public float music_volume = 1f;
        public float sfx_volume = 1f;
        public float voice_volume = 1f;


        public float music_volume_interno = 1f;
        public float sfx_volume_interno = 1f;
        public float voice_volume_interno = 1f;

        public GameObject audio_game_object;
        public AudioMixerGroup master_mixer;
        public AudioMixerGroup music_mixer;
        public AudioMixerGroup sfx_mixer;
        public AudioMixerGroup voice_mixer;
        
        public Coroutine music_1_coroutine;

        public AudioSource  master;

        public Audio_objeto music_1;
        public Audio_objeto music_2;

        public Audio_objeto voice_1;
        public Audio_objeto voice_2;
        public Audio_objeto voice_3;

        public Audio_objeto[] sfx_arr = new Audio_objeto[1];

        public Audio_objeto audio_source_uso_interno;

        
        public  void Iniciar(){
     
                audio_game_object =  GameObject.Find("Audio");

                music_1 = new Audio_objeto("Music_1" , Tipo_audio.music);
                music_2 = new Audio_objeto("Music_2" , Tipo_audio.music);

                voice_1 = new Audio_objeto("Voice_1" , Tipo_audio.voice);
                voice_2 = new Audio_objeto("Voice_2" , Tipo_audio.voice);
                voice_3 = new Audio_objeto("Voice_3" , Tipo_audio.voice);

                audio_source_uso_interno = new Audio_objeto("audio_source_uso_interno" , Tipo_audio.INTERNO);

        }
        
         public void Update(){

                Checar_sfx();

       }

        public void Alterar_volume_mixer(Tipo_audio _tipo , float _novo_volume){
      
                      switch(_tipo){
                          
                        case Tipo_audio.master: master_volume = _novo_volume ;break;
                        case Tipo_audio.music: music_volume = _novo_volume ;break;
                        case Tipo_audio.sfx: sfx_volume = _novo_volume ;break;
                        case Tipo_audio.voice: voice_volume = _novo_volume ;break;
                        default: throw new ArgumentException("nao veio tipo de audio aceitavel");

                      }

                      for(int i = 0;  i < sfx_arr.Length  ;i++){

                        if(sfx_arr[i] != null) sfx_arr[i].Atualizar_volume();
                        
                      }

                      music_1.Atualizar_volume();
                      music_2.Atualizar_volume();
                      voice_1.Atualizar_volume();
                      voice_1.Atualizar_volume();

        }


       public void Acrecentar_sfx ( string _path_completo , float _modificador = 1f ) {


                        //if( _path_completo == null) _path_completo =  "audio/jogo/sfx/" + _path;
          
                        int index_disponivel = -1;
                        int ultimo_index_com_coisa = 0;

                        for(int i = 0; i< sfx_arr.Length  ; i++){
                                
                                if(sfx_arr[i] == null){

                                        if(index_disponivel < 0) index_disponivel = i;
                                        continue;

                                } else {
                                        ultimo_index_com_coisa = i;
                                        continue;
                                }


                        }

                        if(index_disponivel == -1) {

                                index_disponivel = sfx_arr.Length;
                                Modificar_sfx_arr(5);

                        } else if( sfx_arr.Length - ultimo_index_com_coisa > 5 && sfx_arr.Length > 10 ){

                                Modificar_sfx_arr(-5);

                        }


                        Audio_objeto obj  = new Audio_objeto("sfx" , Tipo_audio.sfx);
                        AudioClip audio_source = Resources.Load<AudioClip>( _path_completo );
                        if(audio_source == null) throw new ArgumentException("nao foi achado o audio no path: " + _path_completo );

                        obj.audio_source.clip = audio_source;
                        obj.audio_source.volume = ( master_volume * sfx_volume ) * _modificador;

                        /*  talvez depois por transicao  */


                        obj.audio_source.Play();
                        sfx_arr[index_disponivel] = obj;
                

       }

       public void Checar_sfx(){
     
             int ultimo_index_com_coisa = 0;

                 for(int i = 0;   i < sfx_arr.Length   ;i++){

                         if(sfx_arr[i] == null) { continue; }
                         
                         if(sfx_arr[i].audio_source.isPlaying ){

                                ultimo_index_com_coisa = i;
                                 continue;

                         }

                         sfx_arr[i].Destruir();
                         sfx_arr[i] = null;

                 }

                 if(   sfx_arr.Length - ultimo_index_com_coisa > 5  &&   sfx_arr.Length > 6  ){

                        Modificar_sfx_arr(-5);
                        
                 }

       }


       public void Modificar_sfx_arr(int _numero){

                int n_atual = sfx_arr.Length; 
                int novo_n = n_atual + _numero;
                Audio_objeto[] novo_arr = new Audio_objeto[novo_n];

                if(n_atual < novo_n ) novo_n = n_atual;
                Array.Copy(   sfx_arr, novo_arr , novo_n  );
                sfx_arr = novo_arr;

       }






        public void Stop_music( int _slot , float _tempo_ms_tirar = 500f ){



                Audio_objeto music_object = music_1;

                if( _slot ==  2 ) music_object = music_2;

                if(music_object.coroutine != null){Mono_instancia.Stop_coroutine(music_object.coroutine);}
                
                music_object.coroutine = Mono_instancia.Start_coroutine(  Parar_clip_music() );
               
                return;

                IEnumerator Parar_clip_music(){

                        if( _tempo_ms_tirar > 0f ){

                                float volume_inicial = music_object.audio_source.volume;
                                float d_v =  ( volume_inicial  * 1000f  ) / (  _tempo_ms_tirar  * 60f  ); 
                                float volume = volume_inicial;
                 
                                while (volume > 0f) {

                                        volume = volume - d_v;
                                        music_object.audio_source.volume = volume; 
                                        yield return null;
                                }
                                
                        }

                        music_object.audio_source.Stop();
                        music_object.coroutine = null;
                        yield break;

                } 

        }


        public void Mudar_volume_musica_unico(   int _slot , float _modificador_volume, float _tempo_ms = 500f){

                music_volume_interno = _modificador_volume;


                Audio_objeto music_object = music_1;
                if( _slot == 2 ) music_object = music_2;

                
                float tempo_ms_colocar_restante = music_object.tempo_ms_colocar_restante;
                float tempo_ms_tirar_restante = music_object.tempo_ms_tirar_restante;
                string path = music_object.path;


                if(music_object.coroutine == null){ 

                        music_object.coroutine = Mono_instancia.Start_coroutine( Mudar_volume_simples_c() );
                        return;

                }



                if(tempo_ms_colocar_restante > 0f){

                        Start_music( _slot , path,  tempo_ms_tirar_restante , music_object.tempo_ms_colocar_restante,_modificador_volume );
                        return;

                } 


                Mono_instancia.Stop_coroutine( music_object.coroutine );
                music_object.coroutine = Mono_instancia.Start_coroutine( Mudar_volume_simples_c() );



          
                        IEnumerator Mudar_volume_simples_c(){

                                float volume_inicial = music_object.audio_source.volume;
                                Debug.Log("VOLUME INICIAL: " + volume_inicial);
                                float volume_final = master_volume * music_volume * _modificador_volume;
                                float v_dif = volume_final - volume_inicial;
                                int numero_ciclos = (int)   (  (_tempo_ms / 1000f) * 60f);

                          
                                float d_v =  v_dif / (float) numero_ciclos; 
                                
                                float volume = volume_inicial;

                                int i = 0;

                                while ( i < numero_ciclos ){

                                        
                                        i++;
                                        music_object.tempo_ms_tirar_restante -= 0.0166f;
                                        volume = volume + d_v;
                                        music_object.audio_source.volume = volume;
                                        yield return null;

                                }

                                music_object.audio_source.volume = volume_final;
                                music_object.coroutine = null;
                                yield break;


                        }


        }



        
        public bool Pegar_loop ( Tipo_audio _tipo , int slot ){


                if(  _tipo == Tipo_audio.music  ){

                        if( slot == 1 ) return music_1.audio_source.loop;
                        if( slot == 2 ) return music_2.audio_source.loop;

                }

                
                if(  _tipo == Tipo_audio.voice  ){

                        if( slot == 1 ) return voice_1.audio_source.loop;
                        if( slot == 2 ) return voice_2.audio_source.loop;

                }

                return false;

                
        }

        
        public float Pegar_modificador_volume ( Tipo_audio _tipo ){

                switch ( _tipo ){

                        case Tipo_audio.music: return music_volume_interno;
                        case Tipo_audio.voice: return voice_volume_interno;
                        case Tipo_audio.sfx: return sfx_volume_interno;

                }

                throw new ArgumentException("a");

        }


        


        public string Pegar_path( Tipo_audio _tipo , int slot ){


                if(  _tipo == Tipo_audio.music  ){

                        if( slot == 1 ) return music_1.path;
                        if( slot == 2 ) return music_2.path;

                }

                
                if(  _tipo == Tipo_audio.voice  ){

                        if( slot == 1 ) return voice_1.path;
                        if( slot == 2 ) return voice_2.path;

                }

                return null;

        }


        public void Start_music( int _slot , string _path_completo ,  float _tempo_ms_tirar = 500f , float _tempo_ms_colocar = 500f, float _modificador_volume = 1f){


                music_volume_interno = _modificador_volume;

                
                Audio_objeto music_object = music_1;
                if( _slot == 2 ) music_object = music_2;

//                if(_path_completo == "0" ) { Stop_music( _slot , _tempo_ms_tirar ); return; }

                AudioClip _audio_clip =  Resources.Load<AudioClip>(   _path_completo  );
                music_object.audio_final = _audio_clip;
                music_object.path = _path_completo;
                music_object.tempo_ms_tirar_restante = _tempo_ms_tirar;
                music_object.tempo_ms_colocar_restante = _tempo_ms_colocar;


                if(_audio_clip == null) throw new ArgumentException( "nao foi achado clip de audio, veio: " + _path_completo );          
                if(music_object.coroutine != null){ Mono_instancia.Stop_coroutine(music_object.coroutine);}

                music_object.coroutine = Mono_instancia.Start_coroutine(  Trocar_clip_music() );

                IEnumerator Trocar_clip_music(){


                        if( _tempo_ms_tirar > 0f ){

                                
                                float volume_inicial = music_object.audio_source.volume;
                                float d_v =  ( volume_inicial  * 1000f  ) / (  _tempo_ms_tirar  * 60f  ); 
                                float volume = volume_inicial;

                                while (volume > 0f){

                                        music_object.tempo_ms_tirar_restante -= 0.0166f;
                                        volume = volume - d_v;
                                        music_object.audio_source.volume = volume;
                                        yield return null;

                                }

                                music_object.tempo_ms_tirar_restante  = 0f;

                                
                        } else{

                        }


                        music_object.audio_source.clip = _audio_clip;
                        music_object.audio_source.Play();
                        music_object.audio_source.loop = true;

                        float volume_final = master_volume * music_volume * music_volume_interno;
                        
                        float d_v_final = (volume_final * 1000f ) / ( _tempo_ms_colocar * 60f ); 
                        float volume_novo_audio = 0f;

                        while(  volume_novo_audio < volume_final ){


                                music_object.tempo_ms_colocar_restante -= 16.666f;
                                

                                music_object.audio_source.volume = volume_novo_audio;
                                volume_novo_audio = volume_novo_audio + d_v_final;
                                

                                yield return null;

                        }

                        

                        music_object.tempo_ms_colocar_restante = 0f;

                        music_object.audio_source.volume = volume_final;
                        music_object.coroutine = null;

                        yield break;
            
                } 

        }   

        public void Zerar_volumes_internos(){
                
                music_volume_interno = 1f;
                sfx_volume_interno = 1f;
                voice_volume_interno = 1f;
                return;

        }




        



}