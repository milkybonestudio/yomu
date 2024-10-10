using System;


public class CONTROLLER__resources {


        public static CONTROLLER__resources instance;
        public static CONTROLLER__resources Get_instance(){ return instance; }



        // --- IMAGES
        private MANAGER__resources_images resources_images;

        public RESOURCE__image_ref Get_image_reference( Resource_context _context ){ return resources_images.Get_image_request( _context ); }

        public RESOURCE__image Get_image_request( Resource_context _context ){ return resources_images.Get_image_request( _context ); }
        public void Guarantee_image_is_ready( RESOURCE__image image ){ return resources_images.Finish_image( _context ); } 

        


        public void Update(){

            resources_images.Update();

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


