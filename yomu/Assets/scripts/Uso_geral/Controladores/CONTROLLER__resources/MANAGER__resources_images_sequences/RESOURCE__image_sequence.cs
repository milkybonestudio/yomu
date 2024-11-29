
using System;
using UnityEngine;




unsafe public class RESOURCE__image_sequence {
    

        public RESOURCE__image_sequence( MODULE__context_images_sequences _module_images,  Resource_context _context,  string _main_folder, string _path, Resource_image_sequence_localizer locator ) { 


                image_context = _context; 
                main_folder = _main_folder;
                path_locator = _path;
                module_images = _module_images;


                stage_getting_resource = Resources_getting_image_stage.finished;
                actual_content = Resource_image_content.nothing;
                content_going_to = Resource_image_content.nothing;
                

                width = locator.width;
                height = locator.height;
                pointer_container = locator.pointer;
                data_size = locator.data_size;
                number_images = locator.number_images;
                

                multiples_images = new RESOURCE__image_data[ locator.number_images ];
                if( locator.number_images < 2 )
                    { CONTROLLER__errors.Throw( $"tried to get multiples images { path_locator } but the length was { locator.number_images }" ); }
        
                // ** ver como vai fazer 
                for( int i = 0 ; i < multiples_images.Length ; i++ )
                    {  multiples_images[ i ] = new RESOURCE__image_data(); }

                CONTROLLER__errors.Throw( "ainda nao esta pronto" );

                
        }



        // --- IMAGE DATA

        public MODULE__context_images_sequences module_images;


        // ** pegar no localizador

    
        public int width;
        public int height;
        public int pointer_container;
        public int data_size;
        public int number_images;

    
        public Resource_context image_context;
        public string main_folder;
        public string path_locator;




        public int request_id;
        public string name = "NAO_COLOCOU";


        
        // --- DATA FOR GETTING RESOURCES
        
        public Resources_getting_image_stage stage_getting_resource; // ** precess of getting the resource
        
        // --- IMAGE DATA 

        public Resource_image_content content_going_to; // se estiver em uma transicao de recursos é o ponto final 
        public Resource_image_content actual_content; // ** o recurso atual


        // --- DATA
        public RESOURCE__image_data[] multiples_images;


        // --- REFERENCES

        public RESOURCE__image_sequence_ref[] refs = new RESOURCE__image_sequence_ref[ 100 ];
        public int refs_pointer;
        public bool need_reajust;
                   
        public int count_places_being_used_nothing; // precisa de nada
        public int count_places_being_used_compress_data; // precisa do minimo
        public int count_places_being_used_compress_low_quality_data; // precisa do minimo
        public int count_places_being_used_sprite; // precisa de tudo


    

}


