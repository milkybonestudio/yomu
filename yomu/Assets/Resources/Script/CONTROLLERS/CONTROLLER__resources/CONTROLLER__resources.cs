using System;
using System.Collections.Generic;



/*

    recursos tem 4 estado basicos: 
        -> nothing 
        -> minimo 
        -> active
        -> instanciate
            **( depois mudar ativo / instanciate )


    tem 3 acoes de aumentar os recursos ( se menor ) :
        -> Load() -> vai para o minimo
        -> Activate() -> vai para o active 
        -> instanciate - > garante recurso final
        
    tem 3 acoes de diminuir os recursos ( se maior ) :
        -> Unload() -> reduz para nothing 
        -> Deactivate() -> reduz para o minimo
        -> Deinstanciate() -> reduz para active 

    é possivel mudar o minimo de acordo com a necessidade
        -> Change_pre_alloc( new_level )
    
    delete() -> perde a referencia



    image_ref = CONTROLLER__resources.Get_instance().resources_images.Get_image_reference( Resource_context.Characters, "Lily", "Clothes/lily_clothes_body_1", Resource_image_content.compress_data );


*/


public class CONTROLLER__resources {


        // --- IMAGES
        public MANAGER__resources_images images;
        public MANAGER__resources_images_sequences resources_images_sequences;


        public MANAGER__resources_combined_images resources_combined_images;

        // --- AUDIOS
        public MANAGER__resources_audios resources_audios;

        // --- STRUCTURES
        public MANAGER__resources_structures structures;
        public MANAGER__resources_complex_structures resources_complex_structures;

        // --- LOGICS
        public MANAGER__resources_logics resources_logics;


        public Circular_list<MANAGER__RESOURCES> managers;

        public void Update( Control_flow _control_flow ){

                managers.Get().Update();

        }



        public int Get_bytes_allocated(){

            int total_bytes = 0;

            total_bytes += images.Get_bytes_allocated();

            return total_bytes;

        }

        

}




// public enum Resources_type {

//     image, 
//     audio, 
//     dat_files,

// }


