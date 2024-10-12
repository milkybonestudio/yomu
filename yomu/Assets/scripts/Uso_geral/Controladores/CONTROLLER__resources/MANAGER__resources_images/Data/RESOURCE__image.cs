
using System;
using UnityEngine;


    // ** a imagem so tem 2 modelos, ou esta no minimo ou esta ativo, se um dispositivo tiver mais hierarquias e pode ter multiplas layers e precisar mudar na hora o minimo de uma imagem isso tem que ser feito no dispositivo. 
    // ** o minimo da imagem sempre é o mais alto das referencias, 


    // ** isso vai ficar somente no manager ou nos modulos
    // ** o nivel minimo de prealocation sempre vai ser definido pelo maior das referencias


unsafe public class RESOURCE__image {

        
        public RESOURCE__image( MODULE__context_images _module_images,  Resource_context _context,  string _main_folder, string _path ) { 

                image_context = _context; 
                main_folder = _main_folder;
                path = _path;
                module_images = _module_images;

                stage_getting_resource = Resources_getting_image_stage.finished;
                current_content = Resource_image_content.nothing;
                current_state = Resource_image_state.nothing;
                
        }



        // --- IMAGE DATA

        public MODULE__context_images module_images;

        public Resource_context image_context;
        public string main_folder;
        public string path;

        public string path_locator;


        public Type_image type;
        public int request_id;
        public string name = "NAO_COLOCOU";



        
        // --- DATA FOR GETTING RESOURCES
        
        public Resources_getting_image_stage stage_getting_resource; // ** precess of getting the resource
        public Resource_image_content final_resource_state; // se estiver em uma transicao de recursos é o ponto final 


        // --- IMAGE DATA 

        public Resource_image_state current_final_state; // ** can not have going_to 
        public Resource_image_state current_state;  
        

        public Resource_image_content level_pre_allocation_image; // minimun
        public Resource_image_content current_content; // ** o recurso atual




    
    
        // --- DATA
        public RESOURCE__image_data single_image;
        public RESOURCE__image_data[] multiples_images;




        // --- REFERENCES

        public RESOURCE__image_ref[] refs = new RESOURCE__image_ref[ 100 ];
        public int refs_pointer;
        public bool need_reajust;
                   
        public int count_places_being_used_nothing; // precisa de nada
        public int count_places_being_used_compress_data; // precisa do minimo
        public int count_places_being_used_texture; // precisa de tudo



}


