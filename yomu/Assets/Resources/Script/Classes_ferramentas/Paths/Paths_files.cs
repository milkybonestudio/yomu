using System.IO;


public static class Paths_files {


        // ** PERSISTENTDATAPATH

            // ** a versao do persistent tem que ser a mesma que a do persistent
            // ** se for diferente ele tem que verificar se 
            public static string persistent_data_version = Path.Combine( Paths_system.persistent_data_path, "yomu_version.dat" );
            

            // ** PROGRAM

                // ** program have heap?

                public static string program_data = Path.Combine( Paths_folders.program, "program_data.dat" );


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
