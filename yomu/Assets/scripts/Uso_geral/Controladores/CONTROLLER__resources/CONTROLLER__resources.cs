using System;



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


        public static CONTROLLER__resources instance;
        public static CONTROLLER__resources Get_instance(){ return instance; }


        // --- IMAGES
        public MANAGER__resources_images resources_images = new MANAGER__resources_images();
        public MANAGER__resources_images_sequences resources_images_sequences = new MANAGER__resources_images_sequences();

        public MANAGER__resources_audios resources_audios = new MANAGER__resources_audios();

        public MANAGER__resources_structures resources_structures = new MANAGER__resources_structures();
        public MANAGER__resources_complex_structures resources_complex_structures = new MANAGER__resources_complex_structures();
        


        int count = 0;

        public void Update(){


                count = ( count + 1 ) % 3;

                switch( count ){

                    case 0: resources_images.Update(); break;
                    case 1: resources_structures.Update(); break;
                    case 2: resources_audios.Update(); break;
                    
                    //case 2: resources_images_sequences.Update(); break;

                }
                

        }



        public int Get_bytes_allocated(){

            int total_bytes = 0;

            total_bytes += resources_images.Get_bytes_allocated();

            return total_bytes;

        }

        

}




public enum Resources_type {

    image, 
    audio, 
    dat_files,

}


