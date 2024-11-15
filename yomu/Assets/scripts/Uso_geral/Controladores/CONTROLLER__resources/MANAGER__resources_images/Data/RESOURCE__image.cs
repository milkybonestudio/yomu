
using System;
using UnityEngine;


    // ** a imagem so tem 2 modelos, ou esta no minimo ou esta ativo, se um dispositivo tiver mais hierarquias e pode ter multiplas layers e precisar mudar na hora o minimo de uma imagem isso tem que ser feito no dispositivo. 
    // ** o minimo da imagem sempre é o mais alto das referencias, 


    // ** isso vai ficar somente no manager ou nos modulos
    // ** o nivel minimo de prealocation sempre vai ser definido pelo maior das referencias



unsafe public class RESOURCE__image {

        
        // --- IMAGE DATA

        public MODULE__context_images module_images;


        // ** pegar no localizador

        public int width; 
        public int height; 
        public int pointer_container; 
        public int data_size; 
        public int number_images; 

    
        public Resource_context image_context;
        public string main_folder;
        public string local_path;

        public string image_key;


        public int request_id;
        public string name = "NAO_COLOCOU";


        
        // --- DATA FOR GETTING RESOURCES    

        public Resources_getting_image_stage stage_getting_resource; // ** precess of getting the resource

    
        // --- IMAGE DATA 

        public Resource_image_content content_going_to; // se estiver em uma transicao de recursos é o ponto final 
        public Resource_image_content actual_content; // ** o recurso atual

    
    
        // --- DATAs;



        public bool system_have_low_quality;
        public RESOURCE__image_data single_image;
        
        // public RESOURCE__image_data[] multiples_image



        // --- REFERENCES

        public RESOURCE__image_ref[] refs = new RESOURCE__image_ref[ 100 ];
        public int refs_pointer;
        public bool need_reajust;
                   
        public int count_places_being_used_nothing; // precisa de nada
        public int count_places_being_used_compress_data; // precisa do minimo
        public int count_places_being_used_compress_low_quality_data; // precisa do minimo
        public int count_places_being_used_sprite; // precisa de tudo





}


