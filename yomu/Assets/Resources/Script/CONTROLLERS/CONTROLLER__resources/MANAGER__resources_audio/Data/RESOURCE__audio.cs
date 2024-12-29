
using System;
using UnityEngine;
using UnityEngine.UI;


unsafe public class RESOURCE__audio {

        
        public MODULE__context_audios module_audios;

        public AudioClip audio_clip;


        public Resource_use_state audio_state;
        public Resource_context audio_context;

        public string main_folder;
        public string local_path;

        public string audio_key;


        public int request_id;
        public string name = "NAO_COLOCOU";


        
        // --- DATA FOR GETTING RESOURCES    

        public Resources_getting_audio_stage stage_getting_resource; // ** precess of getting the resource

        public Resource_audio_content content_going_to; // se estiver em uma transicao de recursos é o ponto final 
        public Resource_audio_content actual_content; // ** o recurso atual

        
        
        // public RESOURCE__image_data[] multiples_image



        // --- REFERENCES

        public RESOURCE__audio_ref[] refs = new RESOURCE__audio_ref[ 100 ];
        public int refs_pointer;
        public bool need_reajust;
                   
        public int count_places_being_used_nothing; 
        public int count_places_being_used_audio_clip; 


        


}


