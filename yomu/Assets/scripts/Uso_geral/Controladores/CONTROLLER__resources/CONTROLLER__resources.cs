using System;


public class CONTROLLER__resources {


        public static CONTROLLER__resources instance;
        public static CONTROLLER__resources Get_instance(){ return instance; }



        // --- IMAGES
        public MANAGER__resources_images resources_images;


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


