using System;
using System.IO;
using UnityEngine;



public static class Paths_containers {

        public static string path_resources_structures_container = "Containers/Structures";
        public static string path_resources_complex_structures_container = "Tela/Container_structures";

}


public static class Paths_files {


        // ** PERSISTENTDATAPATH


            public static string program_data_version = Path.Combine( Paths_system.persistent_data_path, "version.dat" );

            // ** PROGRAM

                // ** program have heap?

                public static string program_brute_data = Path.Combine( Paths_folders.program, "program_brute_data.dat" );


                // ** lembrar que tem que guardar qual o save esta usando
                public static string safety_data_stack = Path.Combine( Paths_system.persistent_data_path, "safety_data_stack.dat" );



            // ** SAVES

                public static string Get_save_brute_data( int _save ){ return Path.Combine( Paths_folders.Get_save( _save ), "brute_data.dat" ); }
        

                public static string Get_save_heap_data( int _save ){ return Path.Combine( Paths_folders.Get_save( _save ), "heap_data.dat" ); }
                public static string Get_save_heap_data_slot( int _save, int _slot ){ return Path.Combine( Get_save_heap_data( _save ), $"data_{ _slot.ToString() }.dat" ); }


        // ** DATA
    
            public static string Get_resources_container( Resource_context _context ){  Garanty_build(); return Path.Combine( Paths_system.data_path, $"resources_container{ _context.ToString() }.dat" ); }


        /*
            o linker vai ter pointers para pegar o recurso, tem que ser no formato " "chave", pointer_1, pointer_2, dados[...]"
            o linker sempre vai ser usado para criar um dic<stirng, type_info>

            os recursos normais não vão ter dados, talvez tipo?

        */

        public static string Get_resources_container_linker( Resource_context _context ){ Garanty_build(); return Path.Combine( Paths_system.data_path, $"resources_container{ _context.ToString() }_linker.txt" ); }



        private static void Garanty_build(){

                #if UNITY_EDITOR
                    CONTROLLER__errors.Throw( "Can not call in editor" );
                #endif
        }

        
    
}

public static class Paths_folders {


        public static string saves = Path.Combine( Paths_system.persistent_data_path, "saves" );
        public static string program = Path.Combine( Paths_system.persistent_data_path, "program" );




        public static string Get_heap_save( int _save ){ return System.IO.Path.Combine( Get_save( _save ), "data_heap" ); }


        public static string Get_save( int _save ){

                if( _save > 7 )
                    { CONTROLLER__errors.Throw( $"Can not handle save number <Color=lightBlue>{ _save }</Color>" ); }

                return System.IO.Path.Combine( Paths_folders.saves, ( "save_" + _save.ToString() ) );

        }


        public static string Get_saves_death( int _save ){ return System.IO.Path.Combine( Get_save( _save ) , "death"  ); }
        public static string Get_specific_save_death( int _save,  int _slot ){ return System.IO.Path.Combine( Get_saves_death( _save ) , ( "death_" + _slot.ToString() ) ); }




}


public static class Paths_system {


        // ** MAIN ENTRY POINTS


        #if UNITY_EDITOR

            public static string persistent_data_path = Path.Combine( Application.dataPath, "Editor", "persistentDataPath" );
            public static string data_path = Path.Combine( Application.dataPath, "Editor", "dataPath" );
            
        #else 

            public static string persistent_data_path = Application.persistentDataPath;
            public static string data_path = Path.Combine( Application.dataPath, "Data" );

        #endif


}